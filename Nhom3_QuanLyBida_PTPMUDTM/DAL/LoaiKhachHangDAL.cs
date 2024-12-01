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
        private QuanLyBidaDataContext db = new QuanLyBidaDataContext();
        public List<LOAIKH> GetListLoaiKhachHang()
        {
            return db.LOAIKHs.ToList();
        }
    }
}
