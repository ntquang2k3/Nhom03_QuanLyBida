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
        private QuanLyBidaDataContext dbContext = new QuanLyBidaDataContext();
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

       

        
    }
}
