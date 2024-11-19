using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ChiTietHoaDonDTO
    {
        public int ID { get; set; }           // ID của hóa đơn
        public string TenDichVu { get; set; }  // Tên dịch vụ từ bảng HANGHOA
        public int? Gia { get; set; }           // Đơn giá từ bảng HANGHOA
        public int? SoLuong { get; set; }       // Số lượng từ bảng CHITIETHOADON
        public int? ThanhTien { get; set; }     // Thành tiền từ bảng CHITIETHOADON
    }

}
