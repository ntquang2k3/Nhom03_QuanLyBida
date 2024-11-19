using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class DB_BLL
    {
        DB_DAL dal = new DB_DAL();
        
        public DataTable LayDanhSachLoaiBan()
        {           
            return dal.LayDanhSachLoaiBan();
        }
        public DataTable LayDanhSachKhuVuc(int maLoaiBan)
        {
            return dal.LayDanhSachKhuVuc(maLoaiBan);
        }
        public DataTable LayTatCaDanhSachKhuVuc()
        {
            return dal.LayTatCaDanhSachKhuVuc();
        }
        public DataTable LayDanhSachTrangThaiBan()
        {
            return dal.LayDanhSachTrangThaiBan();
        }
        public DataTable LayDanhSachBan(int maLoaiBan, string maKhuVuc, string trangThai)
        {
            return dal.LayDanhSachBan(maLoaiBan,maKhuVuc,trangThai);
        }
        public DataTable LayDanhSachLoaiHangHoa()
        {
            return dal.LayDanhSachLoaiHangHoa();
        }
        public DataTable LayDanhSachHangHoa(string maLoaiHangHoa)
        {
            return dal.LayDanhSachHangHoa(maLoaiHangHoa);
        }
        public bool ThemMotHoaDon(HOADON hd)
        {
            return dal.ThemMotHoaDon(hd);
        }
        public HOADON LayMotHoaDon(int maHoaDon)
        {
            return dal.LayMotHoaDon(maHoaDon);
        }
        public HOADON LayHoaDonMoiNhat(string maBan)
        {
            return dal.LayHoaDonMoiNhat(maBan);
        }
        public bool XoaMotHoaDon(int maHoaDon)
        {
            return dal.XoaMotHoaDon(maHoaDon);
        }
        public int TaoMaHoaDon()
        {
            return dal.TaoMaHoaDon();
        }
        public bool ThemChiTietHoaDon(int mahoadon, CHITIETHOADON cthd)
        {
            return dal.ThemChiTietHoaDon(mahoadon, cthd);
        }
        public bool XoaChiTietHoaDon(int mahoadon, string mahh)
        {
            return dal.XoaChiTietHoaDon(mahoadon,mahh);
        }
        public DataTable LayChiTietHoaDon(int maHoaDon)
        {
            return dal.LayChiTietHoaDon(maHoaDon);
        }
        public CHITIETHOADON LayChiTietHoaDonVoiMaHH(int maHoaDon, string maHH)
        {
            return dal.LayChiTietHoaDonVoiMaHH(maHoaDon, maHH);
        }
        public bool CapNhatSoLuongCTHD(int maHoaDon, string maHH, CHITIETHOADON cthd)
        {
            return dal.CapNhatSoLuongCTHD(maHoaDon,maHH, cthd);
        }
        public BAN LayMotBan(string maBan)
        {
            return dal.LayMotBan(maBan);
        }
        public bool CapNhatTrangThaiBan(BAN ban, string trangThai)
        {
            return dal.CapNhatTrangThaiBan(ban, trangThai);
        }
        public bool CapNhatBanCuaHoaDon(HOADON hd, string maBan)
        {
            return dal.CapNhatBanCuaHoaDon(hd,maBan);
        }
        public int TinhTienDichVuHoaDon(int maHoaDon)
        {
            return dal.TinhTienDichVuHoaDon(maHoaDon);
        }
    }
}
