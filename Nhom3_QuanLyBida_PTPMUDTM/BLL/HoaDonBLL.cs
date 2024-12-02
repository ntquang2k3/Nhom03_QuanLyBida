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
