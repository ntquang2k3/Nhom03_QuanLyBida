using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BLL
{
    public class KhachHangBLL
    {
        private KhachHangDAL khachHangDAL;
        public KhachHangBLL()
        {
            khachHangDAL = new KhachHangDAL();
        }
        public List<KHACHHANG> LayDanhSachKhachHang()
        {
            return khachHangDAL.GetListKhachHang();
        }
        public bool AddKhachHang(KHACHHANG khachHang)
        {
            return khachHangDAL.AddKhachHang(khachHang);
        }

        public bool DeleteKhachHang(string maKH)
        {
            return khachHangDAL.DeleteKhachHang(maKH);
        }

        public bool UpdateKhachHang(KHACHHANG khachHang)
        {
            return khachHangDAL.UpdateKhachHang(khachHang);
        }
    }
}
