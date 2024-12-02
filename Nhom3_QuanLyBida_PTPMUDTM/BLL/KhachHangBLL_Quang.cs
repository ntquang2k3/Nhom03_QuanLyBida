﻿using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace BLL
{
    public class KhachHangBLL_Quang
    {
        private KhachHangDAL_Quang khachHangDAL;
        public KhachHangBLL_Quang()
        {
            khachHangDAL = new KhachHangDAL_Quang();
        }
        public List<KHACHHANG> LayDanhSachKhachHang()
        {
            return khachHangDAL.GetListKhachHang();
        }
        public KHACHHANG GetKHACHHANG(string id)
        {
            return khachHangDAL.GetKHACHHANG(id);
        }
        public KHACHHANG GetKHACHHANGBySDT(string sdt)
        {
            return khachHangDAL.GetKHACHHANGBySDT(sdt);
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