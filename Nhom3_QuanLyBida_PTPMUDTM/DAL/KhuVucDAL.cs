using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class KhuVucDAL
    {
        private QuanLyBidaDataContext db = new QuanLyBidaDataContext();
        public List<KHUVUC> GetListKhuVuc()
        {
            return db.KHUVUCs.ToList();
        }
        public bool AddKhuVuc(KHUVUC khuVuc)
        {
            try
            {
                db.KHUVUCs.InsertOnSubmit(khuVuc);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteKhuVuc(string maKV)
        {
            try
            {
                var khuVuc = db.KHUVUCs.SingleOrDefault(kv => kv.MaKV == maKV);

                if (khuVuc != null)
                {
                    // Lấy danh sách các BAN liên quan
                    var ban = db.BANs.Where(lb => lb.MaKV == maKV).ToList();

                    // Xóa tất cả các BAN liên quan
                    db.BANs.DeleteAllOnSubmit(ban);

                    // Xóa khu vực
                    db.KHUVUCs.DeleteOnSubmit(khuVuc);

                    // Lưu thay đổi
                    db.SubmitChanges();
                    return true;
                }

                Console.WriteLine("Không tìm thấy khu vực cần xóa.");
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa khu vực: " + ex.Message);
                return false;
            }
        }

        public bool UpdateKhuVuc(KHUVUC updateKhuVuc)
        {
            try
            {
                var khuVuc = db.KHUVUCs.FirstOrDefault(hh => hh.MaKV == updateKhuVuc.MaKV);

                if (khuVuc != null)
                {
                    khuVuc.TenKV = updateKhuVuc.TenKV;
                    khuVuc.GiaTien = updateKhuVuc.GiaTien;
                    khuVuc.MaLoaiBan = updateKhuVuc.MaLoaiBan;
                    db.SubmitChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật khu vực: " + ex.Message);
                return false;
            }
        }

        public List<KHUVUC> SearchKhuVucByMaLoaiBan(int maLoaiBan)
        {
            try
            {
               
                var khuVuc = db.KHUVUCs.Where(ct => ct.MaLoaiBan == maLoaiBan)
                                            .ToList();
                if (khuVuc.Count == 0)
                {
                    return new List<KHUVUC>();
                }

                return khuVuc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn khu vực: " + ex.Message);
            }
        }
    }
}

