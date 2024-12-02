using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class NhanVienBLL_Quang
    {
        private NhanVienDAL_Quang nhanVienDAL;
        public NhanVienBLL_Quang()
        {
           nhanVienDAL = new NhanVienDAL_Quang();
        }
        public List<NHANVIEN> LayDanhSachNhanVien()
        {
            return nhanVienDAL.GetListNhanVien();
        }
        public bool AddNhanVien(NHANVIEN nhanVien)
        {
            return nhanVienDAL.AddNhanVien(nhanVien);
        }

        public bool DeleteNhanVien(string maNV)
        {
            return nhanVienDAL.DeleteNhanVien(maNV);
        }

        public bool UpdateNhanVien(NHANVIEN nhanVien)
        {
            return nhanVienDAL.UpdateNhanVien(nhanVien);
        }

        public bool DoiMatKhau(string taiKhoan, string text1, string text2)
        {
            return nhanVienDAL.DoiMatKhau(taiKhoan, text1, text2);
        }
    }
}
