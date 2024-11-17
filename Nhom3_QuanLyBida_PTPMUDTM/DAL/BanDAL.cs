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
        public List<BAN> GetListBan()
        {
            return dbContext.BANs.ToList();
        }
        public bool AddBan(BAN ban)
        {
            try
            {
                dbContext.BANs.InsertOnSubmit(ban);
                dbContext.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteBan(string maBan)
        {
            try
            {
                // Tìm đối tượng HANGHOA dựa vào maHH
                var ban = dbContext.BANs.SingleOrDefault(hh => hh.MaBan == maBan);
                if (ban != null)
                {
                    dbContext.BANs.DeleteOnSubmit(ban);
                    dbContext.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa bàn: " + ex.Message);
                return false;
            }
        }
        public bool UpdateBan(BAN updateBan)
        {
            try
            {
                var ban = dbContext.BANs.FirstOrDefault(hh => hh.MaBan == updateBan.MaBan);

                if (ban != null)
                {
                    ban.TenBan = updateBan.TenBan;
                    ban.KHUVUC = updateBan.KHUVUC;
                    ban.TrangThai = updateBan.TrangThai;
                    dbContext.SubmitChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật bàn: " + ex.Message);
                return false;
            }
        }

        public List<BAN> SearchBanByMaKhuVuc(string maKhuVuc)
        {
            try
            {

                var ban = dbContext.BANs.Where(ct => ct.MaKV == maKhuVuc)
                                            .ToList();
                if (ban.Count == 0)
                {
                    return new List<BAN>();
                }

                return ban;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn bàn: " + ex.Message);
            }
        }
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
