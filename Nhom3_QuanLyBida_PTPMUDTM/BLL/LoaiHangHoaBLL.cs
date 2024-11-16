using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiHangHoaBLL
    {
        private LoaiHangHoaDAL loaihhDAL = new LoaiHangHoaDAL();
        public List<LOAIHH> LayDanhSachLoaiHangHoa()
        {
            return loaihhDAL.LayDanhSachLoaiHangHoa();
        }
        public bool AddLoaiHang(LOAIHH loaihh)
        {
            return loaihhDAL.AddLoaiHangHoa(loaihh);
        }
        public bool DeleteLoaiHang(string maLoai)
        {
            return loaihhDAL.DeleteLoaiHang(maLoai);
        }
        public bool UpdateLoaiHang(LOAIHH loaiHang)
        {
            return loaihhDAL.UpdateLoaiHang(loaiHang);
        }
    }
}
