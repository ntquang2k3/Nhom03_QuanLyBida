using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class BangThongKeDAL
    {
        private QuanLyBidaDataContext dbContext;

        public BangThongKeDAL()
        {
            dbContext = new QuanLyBidaDataContext();
        }

        public List<bangthongke> LayDanhSachBangThongKe()
        {
            return dbContext.bangthongkes.ToList();
        }
        public List<bangthongke> LayBangThongKeTheoThang(int month)
        {
            var query = dbContext.bangthongkes
                        .Where(bt => bt.NgayXuatHD.Month == month)
                        .ToList();
            return query;
        }
        public List<bangthongke> LayBangThongKeTheoNgay(DateTime ngay)
        {
            using (var db = new QuanLyBidaDataContext()) 
            {
                return db.bangthongkes
                         .Where(b => b.NgayXuatHD.Date == ngay.Date)
                         .ToList();
            }
        }
        public bool XoaThongKe(DateTime ngayhd)
        {
            using (var db = new QuanLyBidaDataContext()) 
            {
                var thongKe = db.bangthongkes.FirstOrDefault(b => b.NgayXuatHD == ngayhd);
                if (thongKe == null) return false;

                db.bangthongkes.DeleteOnSubmit(thongKe);
                db.SubmitChanges();
                return true;
            }
        }

        public bool SuaThongKe(bangthongke thongKe)
        {
            using (var db = new QuanLyBidaDataContext())
            {
                var existingThongKe = db.bangthongkes.FirstOrDefault(b => b.NgayXuatHD == thongKe.NgayXuatHD); 
                if (existingThongKe == null) return false;

                existingThongKe.NgayXuatHD = thongKe.NgayXuatHD;
                existingThongKe.DoanhThu = thongKe.DoanhThu;

                db.SubmitChanges();
                return true;
            }
        }

    }
}
