using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiKhachHangBLL_Quang
    {
        LoaiKhachHangDAL_Quang loaiKhachHangDAL = new LoaiKhachHangDAL_Quang();
        public LoaiKhachHangBLL_Quang() 
        {
            loaiKhachHangDAL = new LoaiKhachHangDAL_Quang();
        }
        public List<LOAIKH> LayDanhSachLoaiKhachHang()
        {
            return loaiKhachHangDAL.GetListLoaiKhachHang();
        }

    }
}
