using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiKhachHangBLL
    {
        LoaiKhachHangDAL loaiKhachHangDAL = new LoaiKhachHangDAL();
        public LoaiKhachHangBLL() 
        {
            loaiKhachHangDAL = new LoaiKhachHangDAL();
        }
        public List<LOAIKH> LayDanhSachLoaiKhachHang()
        {
            return loaiKhachHangDAL.GetListLoaiKhachHang();
        }

    }
}
