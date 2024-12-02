using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class DanhMucManHinhBLL
    {
        DanhMucManHinhDAL dal = new DanhMucManHinhDAL();
        public List<DanhMucManHinh> LayDanhSachManHinh()
        {
            return dal.LayDanhSachManHinh();
        }
        public List<DanhMucManHinh> LayDanhSachManHinh(string maNV)
        {
            return dal.LayDanhSachManHinh(maNV);
        }

        public List<DanhMucManHinh> LayDanhSachManHinhChuaCo(string maNhomNguoiDung)
        {
            return dal.LayDanhSachManHinhChuaCo(maNhomNguoiDung);
        }

        //Lấy danh mục màn hình truyền vào manhomnguoidung
        public List<DanhMucManHinh> LayDanhSachManHinhTheoNhomNguoiDung(string maNhomNguoiDung)
        {
            return dal.LayDanhSachManHinhTheoNhomNguoiDung(maNhomNguoiDung);
        }

        public bool ThemManHinhVaoNhomNguoiDung(string maNhomNguoiDung, string maManHinh)
        {
            return dal.ThemManHinhVaoNhomNguoiDung(maNhomNguoiDung, maManHinh);
        }

        public bool XoaManHinhKhoiNhomNguoiDung(string text, string maManHinh)
        {
            return dal.XoaManHinhKhoiNhomNguoiDung(text, maManHinh);
        }
    }
}
