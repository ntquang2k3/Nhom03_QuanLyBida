using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DanhMucManHinhDAL
    {
        QuanLyBidaDataContext db = new QuanLyBidaDataContext();
        public List<DanhMucManHinh> LayDanhSachManHinh()
        {
            return db.DanhMucManHinhs.ToList();
        }
        public List<DanhMucManHinh> LayDanhSachManHinh(string maNV)
        {
            NHANVIEN nv = db.NHANVIENs.FirstOrDefault(x => x.MaNV == maNV);
            List<DanhMucManHinh> lst = new List<DanhMucManHinh>();
            //Lấy danh sách danh mục màn hình từ nhân viên
            var dsmh = from dmmh in db.DanhMucManHinhs
                       join qlpq in db.QL_PhanQuyens on dmmh.MaManHinh equals qlpq.MaManHinh
                       join ql_nnd in db.QL_NhomNguoiDungs on qlpq.MaNhomNguoiDung equals ql_nnd.MaNhomNguoiDung
                       join ql_nnd_nv in db.QL_NhanVien_NhomNguoiDungs on ql_nnd.MaNhomNguoiDung equals ql_nnd_nv.MaNhomNguoiDung
                       where ql_nnd_nv.MaNV == maNV
                       select dmmh;
            lst = dsmh.ToList();
            return lst;
        }

        public List<DanhMucManHinh> LayDanhSachManHinhChuaCo(string maNhomNguoiDung)
        {
            return db.DanhMucManHinhs.Where(x => !db.QL_PhanQuyens.Any(y => y.MaManHinh == x.MaManHinh && y.MaNhomNguoiDung == maNhomNguoiDung)).ToList();
        }

        //Lấy danh mục màn hình truyền vào manhomnguoidung
        public List<DanhMucManHinh> LayDanhSachManHinhTheoNhomNguoiDung(string maNhomNguoiDung)
        {
            List<DanhMucManHinh> lst = new List<DanhMucManHinh>();
            //Lấy danh sách danh
            var dsmh = from dmmh in db.DanhMucManHinhs
                       join qlpq in db.QL_PhanQuyens on dmmh.MaManHinh equals qlpq.MaManHinh
                       where qlpq.MaNhomNguoiDung == maNhomNguoiDung
                       select dmmh;
            lst = dsmh.ToList();
            return lst;
        }

        public bool ThemManHinhVaoNhomNguoiDung(string maNhomNguoiDung, string maManHinh)
        {
            //Thêm màn hình vào nhóm người dùng
            try
            {
                QL_PhanQuyen qlpq = new QL_PhanQuyen();
                qlpq.MaNhomNguoiDung = maNhomNguoiDung;
                qlpq.MaManHinh = maManHinh;
                db.QL_PhanQuyens.InsertOnSubmit(qlpq);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool XoaManHinhKhoiNhomNguoiDung(string text, string maManHinh)
        {
            //Xóa màn hình khỏi nhóm người dùng
            try
            {
                QL_PhanQuyen qlpq = db.QL_PhanQuyens.FirstOrDefault(x => x.MaNhomNguoiDung == text && x.MaManHinh == maManHinh);
                db.QL_PhanQuyens.DeleteOnSubmit(qlpq);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
