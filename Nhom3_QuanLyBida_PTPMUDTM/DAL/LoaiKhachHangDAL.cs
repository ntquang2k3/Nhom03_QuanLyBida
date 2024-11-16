using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class LoaiKhachHangDAL
    {
        private DbConnectDataContext db = new DbConnectDataContext();
        public List<LOAIKH> GetListLoaiKhachHang()
        {
           return db.LOAIKHs.ToList();
        }
    }
}
