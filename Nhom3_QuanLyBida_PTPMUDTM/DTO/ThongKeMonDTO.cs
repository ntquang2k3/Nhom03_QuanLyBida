using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ThongKeMonDTO
    {
        public string IDMon { get; set; }
        public string TenMon { get; set; }
        public int? SoLuongBanDuoc { get; set; }
        public decimal? GiaTien { get; set; }
        public int? ThanhTien { get; set; }
        public DateTime? NgayXuatHD { get; set; }
    }
}
