using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
namespace BLL
{
    public class BangThongKeBLL
    {
        private BangThongKeDAL bangThongKeDAL;

        public BangThongKeBLL()
        {
            bangThongKeDAL = new BangThongKeDAL();
        }

        public List<bangthongke> LayDanhSachBangThongKe()
        {
            return bangThongKeDAL.LayDanhSachBangThongKe();
        }
        public List<bangthongke> LayBangThongKeTheoThang(int month)
        {
            return bangThongKeDAL.LayBangThongKeTheoThang(month);
        }
        public List<bangthongke> LayBangThongKeTheoNgay(DateTime ngay)
        {
            return bangThongKeDAL.LayBangThongKeTheoNgay(ngay);
        }
        public bool XoaThongKe(DateTime ngayhd)
        {
            return bangThongKeDAL.XoaThongKe(ngayhd);
        }

        public bool SuaThongKe(bangthongke thongKe)
        {
            return bangThongKeDAL.SuaThongKe(thongKe);
        }


    }
}
