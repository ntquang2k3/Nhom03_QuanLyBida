using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongKeMonDTOExcel
    {
        public int STT { get; set; }  
        public string IDMon { get; set; }
        public string TenMon { get; set; }
        public int? SoLuongBanDuoc { get; set; }
        public string GiaTien { get; set; }
        public string ThanhTien { get; set; }
   
    }
}
