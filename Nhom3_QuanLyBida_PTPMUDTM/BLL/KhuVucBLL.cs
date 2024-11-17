using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class KhuVucBLL
    {
        private KhuVucDAL khuVucDAL;
        public KhuVucBLL()
        {
            khuVucDAL = new KhuVucDAL();
        }
        public List<KHUVUC> LayDanhSachKhuVuc()
        {
            return khuVucDAL.GetListKhuVuc();
        }
        public bool AddKhuVuc(KHUVUC khuVuc)
        {
            return khuVucDAL.AddKhuVuc(khuVuc);
        }

        public bool DeleteKhuVuc(string maKV)
        {
            return khuVucDAL.DeleteKhuVuc(maKV);
        }

        public bool UpdateKhuVuc(KHUVUC khuVuc)
        {
            return khuVucDAL.UpdateKhuVuc(khuVuc);
        }
        public List<KHUVUC> GetKhuVucByMaLoaiBan(int maLoaiBan)
        {
            return khuVucDAL.SearchKhuVucByMaLoaiBan(maLoaiBan);
        }

    }
}
