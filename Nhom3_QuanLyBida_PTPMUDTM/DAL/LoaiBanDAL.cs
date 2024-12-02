using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiBanDAL
    {
        private QuanLyBidaDataContext db = new QuanLyBidaDataContext();
        public List<LoaiBan> GetListLoaiBan()
        {
            return db.LoaiBans.ToList();
        }
        public bool AddLoaiBan(LoaiBan loaiBan)
        {
            try
            {
            
                db.LoaiBans.InsertOnSubmit(loaiBan);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteLoaiBan(int maLoaiBan)
        {
            try
            {
                var loaiBan = db.LoaiBans.SingleOrDefault(kv => kv.maban == maLoaiBan);

                if (loaiBan != null)
                {
                    // Lấy danh sách các BAN liên quan
                    var khuVuc = db.KHUVUCs.Where(lb => lb.MaLoaiBan == maLoaiBan).ToList();

                    // Xóa tất cả các BAN liên quan
                    db.KHUVUCs.DeleteAllOnSubmit(khuVuc);

                    // Xóa khu vực
                    db.LoaiBans.DeleteOnSubmit(loaiBan);

                    // Lưu thay đổi
                    db.SubmitChanges();
                    return true;
                }

                Console.WriteLine("Không tìm thấy loại bàn cần xóa.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa loại bàn: " + ex.Message);
                return false;
            }
        }

        public bool UpdateLoaiBan(LoaiBan updateLoaiBan)
        {
            try
            {
                var loaiBan = db.LoaiBans.FirstOrDefault(hh => hh.maban == updateLoaiBan.maban);

                if (loaiBan != null)
                {
                    loaiBan.tenloaiban = updateLoaiBan.tenloaiban;
                    loaiBan.GiaGioChoi = updateLoaiBan.GiaGioChoi;
                   
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật loại bàn: " + ex.Message);
                return false;
            }
        }
    }
}
