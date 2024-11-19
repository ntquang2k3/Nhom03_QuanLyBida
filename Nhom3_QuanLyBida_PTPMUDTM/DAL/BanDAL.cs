using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class BanDAL
    {
        private DbConnectDataContext dbContext = new DbConnectDataContext();

        public List<BanChoiNhieuDTO> LayDanhSachBanVaSoGioChoi()
        {
            var query = from ban in dbContext.BANs
                        join hoaDon in dbContext.HOADONs on ban.MaBan equals hoaDon.MaBan
                        where hoaDon.ThoiGianVao != null && hoaDon.ThoiGianRa != null
                        group hoaDon by new { ban.MaBan, ban.TenBan } into g
                        select new BanChoiNhieuDTO
                        {
                            IDBan = g.Key.MaBan,
                            TenBan = g.Key.TenBan,
                            SoGioChoi = g.Sum(hd => System.Data.Linq.SqlClient.SqlMethods.DateDiffHour(hd.ThoiGianVao, hd.ThoiGianRa))
                        };

            return query.ToList();
        }
        public List<BanChoiNhieuDTO> LayDanhSachBanVaSoGioChoi(DateTime? ngay)
        {
            var query = from ban in dbContext.BANs
                        join hoaDon in dbContext.HOADONs on ban.MaBan equals hoaDon.MaBan
                        where hoaDon.ThoiGianVao != null && hoaDon.ThoiGianRa != null
                        select new
                        {
                            MaBan = ban.MaBan,
                            TenBan = ban.TenBan,
                            SoGioChoi = System.Data.Linq.SqlClient.SqlMethods.DateDiffHour(hoaDon.ThoiGianVao, hoaDon.ThoiGianRa),
                            NgayXuatHD = hoaDon.NgayXuatHD
                        };

            if (ngay.HasValue)
            {
                query = query.Where(hd => hd.NgayXuatHD == ngay.Value.Date);
            }

            var result = query.GroupBy(hd => new { hd.MaBan, hd.TenBan })
                              .Select(g => new BanChoiNhieuDTO
                              {
                                  IDBan = g.Key.MaBan,
                                  TenBan = g.Key.TenBan,
                                  SoGioChoi = g.Sum(hd => hd.SoGioChoi)
                              });

            return result.ToList();
        }
    }
}
