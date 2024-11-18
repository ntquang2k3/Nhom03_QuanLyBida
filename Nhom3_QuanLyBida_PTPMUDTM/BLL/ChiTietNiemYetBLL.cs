using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ChiTietNiemYetBLL
    {
        private ChiTIetNiemYetDAL chiTietNiemYetDAL = new ChiTIetNiemYetDAL();
        public List<ChiTietNiemYetBan> LayDanhSachChiTietNiemYet()
        {
            return chiTietNiemYetDAL.GetListChiTIetNiemYet();
        }
        public List<ChiTietNiemYetBan> GetChiTietNiemYetByMaNY(string maNY)
        {
            return chiTietNiemYetDAL.SearchChiTietNiemYetByMaNY(maNY);
        }
        public bool AddChiTietNiemYet(ChiTietNiemYetBan chiTietNiemYet)
        {
            return chiTietNiemYetDAL.AddChiTietNiemYet(chiTietNiemYet);
        }

        public bool DeleteChiTietNiemYet(string maBan)
        {
            return chiTietNiemYetDAL.DeleteCTNiemYet(maBan);
        }

        public bool UpdateChiTietNiemYet(ChiTietNiemYetBan chiTietNiemYet)
        {
            return chiTietNiemYetDAL.UpdateCTNiemYet(chiTietNiemYet);
        }
    }
}
