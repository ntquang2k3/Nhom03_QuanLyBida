using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DTO;
namespace BLL
{
    public class HoaDonBLL
    {
        private HoaDonDAL hoaDonDAL;

        public HoaDonBLL()
        {
            hoaDonDAL = new HoaDonDAL();
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
        public List<ChiTietHoaDonDTO> LayChiTietHoaDon(int maHDBH)
        {
            return hoaDonDAL.GetChiTietHoaDon(maHDBH);
        }

        public HOADON LayHoaDon(int maHDBH)
        {
            return hoaDonDAL.GetHoaDon(maHDBH);
        }

        public List<HOADON> GetHoaDonByMaKH(string maKH)
        {
            return hoaDonDAL.SearchHoaDonMaKH(maKH);
        }

    }

}
