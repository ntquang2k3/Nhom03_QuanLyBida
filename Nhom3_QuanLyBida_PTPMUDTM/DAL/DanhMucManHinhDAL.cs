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
   }
}
