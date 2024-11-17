using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class LoaiBanBLL
    {
        private LoaiBanDAL loaiBanDAL;
        public LoaiBanBLL()
        {
            loaiBanDAL = new LoaiBanDAL();
        }
        public List<LoaiBan> LayDanhSachLoaiBan()
        {
            return loaiBanDAL.GetListLoaiBan();
        }
        public bool AddLoaiBan(LoaiBan loaiBan)
        {
            return loaiBanDAL.AddLoaiBan(loaiBan);
        }

        public bool DeleteLoaiBan(int maLoaiBan)
        {
            return loaiBanDAL.DeleteLoaiBan(maLoaiBan);
        }

        public bool UpdateLoaiBan(LoaiBan loaiBan)
        {
            return loaiBanDAL.UpdateLoaiBan(loaiBan);
        }
    }
}
