using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class NhanVienDAL
    {
        private QuanLyBidaDataContext db = new QuanLyBidaDataContext();
        public List<NHANVIEN> GetListNhanVien()
        {
            return db.NHANVIENs.ToList();
        }
        public bool AddNhanVien(NHANVIEN nhanVien)
        {
            try
            {
                db.NHANVIENs.InsertOnSubmit(nhanVien);
                db.SubmitChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool DeleteNhanVien(string maNV)
        {
            try
            {
                // Tìm đối tượng HANGHOA dựa vào maHH
                var nhanVien = db.NHANVIENs.SingleOrDefault(hh => hh.MaNV == maNV);
                if (nhanVien != null)
                {
                    db.NHANVIENs.DeleteOnSubmit(nhanVien);
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa nhân viên: " + ex.Message);
                return false;
            }
        }
        public bool UpdateNhanVien(NHANVIEN updateNhanVien)
        {
            try
            {
                var nhanVien = db.NHANVIENs.FirstOrDefault(hh => hh.MaNV == updateNhanVien.MaNV);

                if (nhanVien != null)
                {
                    nhanVien.TenNV = updateNhanVien.TenNV;
                    nhanVien.GioiTinh = updateNhanVien.GioiTinh;
                    nhanVien.DiaChi = updateNhanVien.DiaChi;
                    nhanVien.SoDienThoai = updateNhanVien.SoDienThoai;
                    nhanVien.PhanQuyen = updateNhanVien.PhanQuyen;
                    nhanVien.MatKhau = updateNhanVien.MatKhau;
                    nhanVien.HoatDong = updateNhanVien.HoatDong;
                    db.SubmitChanges();
                    return true;
                }

                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật nhân viên: " + ex.Message);
                return false;
            }
        }

        public bool DoiMatKhau(string taiKhoan, string text1, string text2)
        {
            //Đổi mật khẩu cho nhân viên
            try
            {
                NHANVIEN nv = db.NHANVIENs.FirstOrDefault(x => x.MaNV == taiKhoan && x.MatKhau == text1);
                if (nv != null)
                {
                    nv.MatKhau = text2;
                    db.SubmitChanges();
                    return true;
                }
                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
