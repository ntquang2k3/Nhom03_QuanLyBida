using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NiemYetDAL
    {
        private QuanLyBidaDataContext db = new QuanLyBidaDataContext();
        public List<NiemYet> GetListNiemYet()
        {
            return db.NiemYets.ToList();
        }
        public bool AddNiemYet(NiemYet niemYet)
        {
            try
            {
                db.NiemYets.InsertOnSubmit(niemYet);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteNiemYet(string maNiemYet)
        {
            try
            {
                var niemYet = db.NiemYets.SingleOrDefault(kv => kv.MaNiemYet == maNiemYet);

                if (niemYet != null)
                {
                 
                    var chiTiet = db.ChiTietNiemYetBans.Where(lb => lb.MaNiemYet == maNiemYet).ToList();

                    // Xóa tất cả các BAN liên quan
                    db.ChiTietNiemYetBans.DeleteAllOnSubmit(chiTiet);

                    // Xóa khu vực
                    db.NiemYets.DeleteOnSubmit(niemYet);

                    // Lưu thay đổi
                    db.SubmitChanges();
                    return true;
                }

                Console.WriteLine("Không tìm thấy Niêm Yết cần xóa.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa Niêm Yết: " + ex.Message);
                return false;
            }
        }

        public bool UpdateNiemYet(NiemYet updateNiemYet)
        {
            try
            {
                var niemYet = db.NiemYets.FirstOrDefault(hh => hh.MaNiemYet == updateNiemYet.MaNiemYet);

                if (niemYet != null)
                {
                    niemYet.TenNiemYet = updateNiemYet.TenNiemYet;
                  
                    db.SubmitChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật Niêm Yết: " + ex.Message);
                return false;
            }
        }

    }
}
