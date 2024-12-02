using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class NhomNguoiDungDAL
    {
        QuanLyBidaDataContext db = new QuanLyBidaDataContext();
        public List<QL_NhomNguoiDung> LayDanhSachNhomNguoiDung()
        {
            return db.QL_NhomNguoiDungs.ToList();
        }

        public List<QL_NhomNguoiDung> LayDanhSachNhomNguoiDungTheoMaNV(string manv)
        {
            return db.QL_NhomNguoiDungs.Where(x => x.QL_NhanVien_NhomNguoiDungs.Any(y => y.MaNV == manv)).ToList();
        }
        //Lấy danh sách nhóm người dùng chưa có theo mã nhân viên
        public List<QL_NhomNguoiDung> LayDanhSachNhomNguoiDungChuaCoTheoMaNV(string manv)
        {
            return db.QL_NhomNguoiDungs.Where(x => !x.QL_NhanVien_NhomNguoiDungs.Any(y => y.MaNV == manv)).ToList();
        }
        public QL_NhomNguoiDung LayNhomNguoiDungTheoMa(string ma)
        {
            return db.QL_NhomNguoiDungs.FirstOrDefault(x => x.MaNhomNguoiDung == ma);
        }

        public bool SuaNhomNguoiDung(QL_NhomNguoiDung nhomNguoiDung)
        {
            //Sửa nhóm người dùng
            try
            {
                QL_NhomNguoiDung nhomNguoiDungSua = db.QL_NhomNguoiDungs.FirstOrDefault(x => x.MaNhomNguoiDung == nhomNguoiDung.MaNhomNguoiDung);
                nhomNguoiDungSua.TenNhomNguoiDung = nhomNguoiDung.TenNhomNguoiDung;
                nhomNguoiDungSua.GhiChu = nhomNguoiDung.GhiChu;
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ThemNhomNguoiDung(QL_NhomNguoiDung nhomNguoiDung)
        {
            //Thêm nhóm người dùng
            try
            {
                db.QL_NhomNguoiDungs.InsertOnSubmit(nhomNguoiDung);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool XoaNhomNguoiDung(string maNhomNguoiDung)
        {
            //Xóa nhóm người dùng
            try
            {
                QL_NhomNguoiDung nhomNguoiDung = db.QL_NhomNguoiDungs.FirstOrDefault(x => x.MaNhomNguoiDung == maNhomNguoiDung);
                db.QL_NhomNguoiDungs.DeleteOnSubmit(nhomNguoiDung);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool ThemNhomNguoiDungVaoNhanVien(string text, string maNhomNguoiDung)
        {
            //Thêm nhóm người dùng vào nhân viên
            try
            {
                QL_NhanVien_NhomNguoiDung ql_nnd = new QL_NhanVien_NhomNguoiDung();
                ql_nnd.MaNV = text;
                ql_nnd.MaNhomNguoiDung = maNhomNguoiDung;
                db.QL_NhanVien_NhomNguoiDungs.InsertOnSubmit(ql_nnd);
                db.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool XoaNhomNguoiDungTheoMaNhanVien(string text, string maNhomNguoiDung)
        {
            //Xóa nhóm người dùng theo mã nhân viên
            try
            {
                QL_NhanVien_NhomNguoiDung ql_nnd = db.QL_NhanVien_NhomNguoiDungs.FirstOrDefault(x => x.MaNV == text && x.MaNhomNguoiDung == maNhomNguoiDung);
                db.QL_NhanVien_NhomNguoiDungs.DeleteOnSubmit(ql_nnd);
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
