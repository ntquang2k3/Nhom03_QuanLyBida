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
