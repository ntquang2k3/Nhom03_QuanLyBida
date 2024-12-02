using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class NhomNguoiDungBLL_Quang
    {
        NhomNguoiDungDAL_Quang nhomNguoiDungDAL = new NhomNguoiDungDAL_Quang();
        public List<QL_NhomNguoiDung> LayDanhSachNhomNguoiDung()
        {
            return nhomNguoiDungDAL.LayDanhSachNhomNguoiDung();
        }

        public List<QL_NhomNguoiDung> LayDanhSachNhomNguoiDungTheoMaNV(string manv)
        {
            //Lấy danh sách nhóm người dùng theo mã nhân viên
            return nhomNguoiDungDAL.LayDanhSachNhomNguoiDungTheoMaNV(manv);
        }
        //Lấy danh sách nhóm người dùng chưa có theo mã nhân viên
        public List<QL_NhomNguoiDung> LayDanhSachNhomNguoiDungChuaCoTheoMaNV(string manv)
        {
            return nhomNguoiDungDAL.LayDanhSachNhomNguoiDungChuaCoTheoMaNV(manv);
        }
        public QL_NhomNguoiDung LayNhomNguoiDungTheoMa(string ma)
        {
            return nhomNguoiDungDAL.LayNhomNguoiDungTheoMa(ma);
        }

        public bool SuaNhomNguoiDung(QL_NhomNguoiDung nhomNguoiDung)
        {
            //Sửa nhóm người dùng
            return nhomNguoiDungDAL.SuaNhomNguoiDung(nhomNguoiDung);
        }

        public bool ThemNhomNguoiDung(QL_NhomNguoiDung nhomNguoiDung)
        {
            //Thêm nhóm người dùng
            return nhomNguoiDungDAL.ThemNhomNguoiDung(nhomNguoiDung);
        }

        public bool XoaNhomNguoiDung(string maNhomNguoiDung)
        {
            return nhomNguoiDungDAL.XoaNhomNguoiDung(maNhomNguoiDung);
        }

        public bool ThemNhomNguoiDungVaoNhanVien(string text, string maNhomNguoiDung)
        {
            return nhomNguoiDungDAL.ThemNhomNguoiDungVaoNhanVien(text, maNhomNguoiDung);
        }

        public bool XoaNhomNguoiDungTheoMaNhanVien(string text, string maNhomNguoiDung)
        {
            return nhomNguoiDungDAL.XoaNhomNguoiDungTheoMaNhanVien(text, maNhomNguoiDung);
        }
    }
}
