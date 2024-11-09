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
        public List<ThongKeMonDTO> LayThongKeMon(DateTime? selectedDate = null)
        {
            return hangHoaDAL.LayThongKeMon(selectedDate);
        }

    }
}
