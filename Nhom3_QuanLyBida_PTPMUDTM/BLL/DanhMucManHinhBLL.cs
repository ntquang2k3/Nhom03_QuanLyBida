using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class DanhMucManHinhBLL
    {
        DanhMucManHinhDAL dal = new DanhMucManHinhDAL();
        public List<DanhMucManHinh> LayDanhSachManHinh()
        {
            return dal.LayDanhSachManHinh();
        }
        public List<DanhMucManHinh> LayDanhSachManHinh(string maNV)
        {
            return dal.LayDanhSachManHinh(maNV);
        }
        //Lấy danh mục màn hình truyền vào manhomnguoidung
        public List<DanhMucManHinh> LayDanhSachManHinhTheoNhomNguoiDung(string maNhomNguoiDung)
        {
            return dal.LayDanhSachManHinhTheoNhomNguoiDung(maNhomNguoiDung);
        }

    }
}
