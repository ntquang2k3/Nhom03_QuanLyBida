using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class NiemYetBLL
    {
        NiemYetDAL niemYetDAL = new NiemYetDAL();
        public List<NiemYet> LayDanhSachNiemYet()
        {
            return niemYetDAL.GetListNiemYet();
        }
        public bool AddNiemYet(NiemYet niemYet)
        {
            return niemYetDAL.AddNiemYet(niemYet);
        }

        public bool DeleteNiemYet(string maNiemYet)
        {
            return niemYetDAL.DeleteNiemYet(maNiemYet);
        }

        public bool UpdateNiemYet(NiemYet niemYet)
        {
            return niemYetDAL.UpdateNiemYet(niemYet);
        }
    }
}
