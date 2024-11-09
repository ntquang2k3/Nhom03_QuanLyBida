using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
namespace BLL
{
    public class BanBLL
    {
        private BanDAL banDAL = new BanDAL();

        public List<BanChoiNhieuDTO> LayDanhSachBanVaSoGioChoi()
        {
            return banDAL.LayDanhSachBanVaSoGioChoi();
        }
        public List<BanChoiNhieuDTO> LayDanhSachBanVaSoGioChoi(DateTime? ngay = null)
        {
            return banDAL.LayDanhSachBanVaSoGioChoi(ngay);
        }
    }
}
