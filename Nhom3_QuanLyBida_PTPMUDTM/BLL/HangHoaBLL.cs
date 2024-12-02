using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class HangHoaBLL
    {
        private HangHoaDAL hangHoaDAL;
        public HangHoaBLL()
        {
            hangHoaDAL = new HangHoaDAL();
        }
        public bool AddHangHoa(HANGHOA hangHoa)
        {
            return hangHoaDAL.AddHangHoa(hangHoa);
        }

        public bool DeleteHangHoa(string hangHoa)
        {
            return hangHoaDAL.DeleteHangHoa(hangHoa) ;
        }

        public bool UpdateHangHoa(HANGHOA hangHoa)
        {
            return hangHoaDAL.UpdateHangHoa(hangHoa);
        }

        public List<HANGHOA> GetHangHoaByMaLH(string maLH)
        {
            return hangHoaDAL.SearchHangHoaMaLH(maLH);
        }
     
        
        public List<HANGHOA> LayDanhSachHangHoa()
        {
            return hangHoaDAL.LayDanhSachHangHoa();
        }

    }
}
