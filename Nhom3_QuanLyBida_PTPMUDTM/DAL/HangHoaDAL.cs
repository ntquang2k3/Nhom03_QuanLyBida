using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class HangHoaDAL
    {
        private DbConnectDataContext dbContext = new DbConnectDataContext();
        public List<HANGHOA> LayDanhSachHangHoa()
        {
            return dbContext.HANGHOAs.ToList();
        }
        public bool AddHangHoa(HANGHOA newHangHoa)
        {
            try
            {
                dbContext.HANGHOAs.InsertOnSubmit(newHangHoa);
                dbContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteHangHoa(string maHH)
        {
            try
            {
                // Tìm đối tượng HANGHOA dựa vào maHH
                var hangHoa = dbContext.HANGHOAs.SingleOrDefault(hh => hh.MaHH == maHH);
                if (hangHoa != null)
                {
                    dbContext.HANGHOAs.DeleteOnSubmit(hangHoa);
                    dbContext.SubmitChanges();
                    return true;
                }
                return false; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa hàng hóa: " + ex.Message);
                return false;
            }
        }
        public bool UpdateHangHoa(HANGHOA updatedHangHoa)
        {
            try
            {
                var hangHoa = dbContext.HANGHOAs.FirstOrDefault(hh => hh.MaHH == updatedHangHoa.MaHH);

                if (hangHoa != null)
                {
                    hangHoa.TenHH = updatedHangHoa.TenHH;
                    hangHoa.MaLH = updatedHangHoa.MaLH;
                    hangHoa.GiaSP = updatedHangHoa.GiaSP;
                    hangHoa.HinhAnh = updatedHangHoa.HinhAnh;
                    dbContext.SubmitChanges();
                    return true; 
                }

                return false; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật hàng hóa: " + ex.Message);
                return false; 
            }
        }

        public List<HANGHOA> SearchHangHoaMaLH(string maLH)
        {
            try
            {
                if (string.IsNullOrEmpty(maLH))
                {

                    return new List<HANGHOA>();
                }

                var hangHoa = dbContext.HANGHOAs
                                            .Where(ct => ct.MaLH == maLH)
                                            .ToList();
                if (hangHoa.Count == 0)
                {
                    return new List<HANGHOA>();
                }

                return hangHoa;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn chi tiết phiếu nhập: " + ex.Message);
            }
        }

        public List<ThongKeMonDTO> LayThongKeMon(DateTime? selectedDate = null)
        {
            using (var db = new DbConnectDataContext())
            {
                var query = from cthd in db.CHITIETHOADONs
                            join hh in db.HANGHOAs on cthd.MaHH equals hh.MaHH
                            join hd in db.HOADONs on cthd.MaHDBH equals hd.MaHDBH
                            select new
                            {
                                hh.MaHH,
                                hh.TenHH,
                                hh.GiaSP,
                                cthd.SoLuong,
                                cthd.ThanhTien,
                                NgayXuatHD = hd.NgayXuatHD
                            };

                // Áp dụng lọc nếu có selectedDate và chỉ lấy các bản ghi có NgayXuatHD không bị null
                if (selectedDate.HasValue)
                {
                    query = query.Where(item => item.NgayXuatHD.HasValue && item.NgayXuatHD.Value.Date == selectedDate.Value.Date);
                }

                var result = query
                    .GroupBy(item => new { item.MaHH, item.TenHH, item.GiaSP })
                    .Select(g => new ThongKeMonDTO
                    {
                        IDMon = g.Key.MaHH,
                        TenMon = g.Key.TenHH,
                        SoLuongBanDuoc = g.Sum(x => x.SoLuong),
                        GiaTien = g.Key.GiaSP,
                        ThanhTien = g.Sum(x => x.SoLuong * x.GiaSP)
                    });

                return result.ToList();
            }

        }
    }
}
