using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class KhachHangDAL
    {
        private DbConnectDataContext db = new DbConnectDataContext();
        public List<KHACHHANG> GetListKhachHang()
        {
            return db.KHACHHANGs.ToList();
        }
        public bool AddKhachHang(KHACHHANG khachHang)
        {
            try
            {
                db.KHACHHANGs.InsertOnSubmit(khachHang);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteKhachHang(string maKH)
        {
            try
            {
                var khachHang = db.KHACHHANGs.SingleOrDefault(lh => lh.MaKH == maKH);

                if (khachHang != null)
                {
                    // Kiểm tra xem loại hàng hóa này có tồn tại hàng hóa liên quan hay không
                    bool hasRelatedHoaDon = db.HOADONs.Any(hh => hh.MaKH == maKH);

                    if (hasRelatedHoaDon)
                    {
                        Console.WriteLine("Không thể xóa khách hàng đang có hóa đơn liên quan.");
                        return false;
                    }
                    // Nếu không có hàng hóa liên quan, tiến hành xóa
                    db.KHACHHANGs.DeleteOnSubmit(khachHang);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa loại hàng hóa: " + ex.Message);
                return false;
            }
            //try
            //{
            //    // Tìm đối tượng KHACHHANG dựa vào maHH
            //    var khachHang = db.KHACHHANGs.SingleOrDefault(hh => hh.MaKH == maKH);
            //    if (khachHang != null)
            //    {
            //        db.KHACHHANGs.DeleteOnSubmit(khachHang);
            //        db.SubmitChanges();
            //        return true;
            //    }
            //    return false;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine("Lỗi khi xóa khách hàng: " + ex.Message);
            //    return false;
            //}
        }
        public bool UpdateKhachHang(KHACHHANG updateKhachHang)
        {
            try
            {
                // Tìm khách hàng cần cập nhật
                var khachHang = db.KHACHHANGs.SingleOrDefault(hh => hh.MaKH == updateKhachHang.MaKH);
                if (khachHang == null)
                {
                    Console.WriteLine($"Không tìm thấy khách hàng với MaKH = {updateKhachHang.MaKH}");
                    return false;
                }

                // Kiểm tra khóa ngoại (LOAIKH) có tồn tại không
                var loaiKH = db.LOAIKHs.SingleOrDefault(l => l.MaLKH == updateKhachHang.MaLKH);
                if (loaiKH == null)
                {
                    Console.WriteLine($"Không tìm thấy loại khách hàng với MaLKH = {updateKhachHang.MaLKH}");
                    return false;
                }

                // Cập nhật thông tin khách hàng
                khachHang.TenKH = updateKhachHang.TenKH ?? khachHang.TenKH;
                khachHang.DiaChi = updateKhachHang.DiaChi ?? khachHang.DiaChi;
                khachHang.DiemTichLuy = updateKhachHang.DiemTichLuy;
                khachHang.SDT = updateKhachHang.SDT ?? khachHang.SDT;
                khachHang.MatKhau = updateKhachHang.MatKhau ?? khachHang.MatKhau;
                khachHang.HoatDong = updateKhachHang.HoatDong;

                // Gán đối tượng liên quan thay vì trực tiếp thay đổi MaLKH
                khachHang.LOAIKH = loaiKH;

                // Lưu thay đổi
                db.SubmitChanges();
                Console.WriteLine("Cập nhật khách hàng thành công.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi cập nhật khách hàng: {ex.Message}");
                return false;
            }
        }



        //public bool UpdateKhachHang(KHACHHANG updateKhachHang)
        //{
        //    try
        //    {
        //        var khachHang = db.KHACHHANGs.FirstOrDefault(hh => hh.MaKH == updateKhachHang.MaKH);

        //        if (khachHang != null)
        //        {
        //            khachHang.TenKH = updateKhachHang.TenKH;
        //            khachHang.MaLKH = updateKhachHang.MaLKH;
        //            khachHang.DiaChi = updateKhachHang.DiaChi;
        //            khachHang.DiemTichLuy = updateKhachHang.DiemTichLuy;
        //            khachHang.SDT = updateKhachHang.SDT;
        //            khachHang.MatKhau = updateKhachHang.MatKhau;
        //            khachHang.HoatDong = updateKhachHang.HoatDong;
        //            db.SubmitChanges();
        //            return true;
        //        }

        //        return false;
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("Lỗi khi cập nhật khách hàng: " + ex.Message);
        //        return false;
        //    }
    }
}

