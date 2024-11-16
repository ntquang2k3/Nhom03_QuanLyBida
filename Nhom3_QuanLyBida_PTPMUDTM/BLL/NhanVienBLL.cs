using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class NhanVienBLL
    {
        private NhanVienDAL nhanVienDAL;
        public NhanVienBLL()
        {
           nhanVienDAL = new NhanVienDAL();
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

    }
}
