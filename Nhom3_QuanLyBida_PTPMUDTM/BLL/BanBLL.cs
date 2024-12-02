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
        public List<BAN> LayDanhSachBan()
        {
            return banDAL.GetListBan();
        }
        public List<BAN> GetBanByMaKhuVuc(string maKV)
        {
            return banDAL.SearchBanByMaKhuVuc(maKV);
        }
        public bool AddBan(BAN ban)
        {
            return banDAL.AddBan(ban);
        }

        public bool DeleteBan(string maBan)
        {
            return banDAL.DeleteBan(maBan);
        }

        public bool UpdateBan(BAN ban)
        {
            return banDAL.UpdateBan(ban);
        }
      
    }
}
