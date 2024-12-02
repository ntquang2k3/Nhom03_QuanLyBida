using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class HoaDonBLL_Quang
    {
        private HoaDonDAL_Quang hoaDonDAL;

        public HoaDonBLL_Quang()
        {
            hoaDonDAL = new HoaDonDAL_Quang();
        }

        public IQueryable<dynamic> LayHoaDonHienThi()
        {
            return hoaDonDAL.GetHoaDonForGridView();
        }
        public IQueryable<dynamic> LayHoaDonLoc(string maBan, string maNhanVien, bool? datCoc, DateTime? ngayChoi)
        {
            return hoaDonDAL.GetHoaDonFiltered(maBan, maNhanVien, datCoc, ngayChoi);
        }
        public IQueryable<dynamic> LayDanhSachNhanVien()
        {
            return hoaDonDAL.LayDanhSachNhanVien();
        }

        public IQueryable<dynamic> LayDanhSachBan()
        {
            return hoaDonDAL.LayDanhSachBan();
        }
        public bool XoaHoaDon(int maHDBH)
        {
            return hoaDonDAL.XoaHoaDon(maHDBH);
        }
        public List<ChiTietHoaDonDTO_Quang> LayChiTietHoaDon(int maHDBH)
        {
            return hoaDonDAL.GetChiTietHoaDon(maHDBH);
        }
        public List<HoaDonReport_Quang> LayChiTietHoaDonReport(int maHDBH)
        {
            return hoaDonDAL.LayChiTietHoaDonReport(maHDBH) ;
        }

        public HOADON LayHoaDon(int maHDBH)
        {
            return hoaDonDAL.GetHoaDon(maHDBH);
        }

        public List<HOADON> GetHoaDonByMaKH(string maKH)
        {
            return hoaDonDAL.SearchHoaDonMaKH(maKH);
        }
        public IQueryable<dynamic> LayHoaDonLoc(string maBan, string maNhanVien, DateTime? ngayChoi)
        {
            return hoaDonDAL.GetHoaDonFiltered(maBan, maNhanVien, ngayChoi);
        }
    }

}
