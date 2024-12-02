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
        private QuanLyBidaDataContext dbContext = new QuanLyBidaDataContext();
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
                    //ban.KHUVUC = updateBan.KHUVUC;
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
       
    }
}
