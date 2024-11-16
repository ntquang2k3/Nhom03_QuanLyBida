using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class LoaiHangHoaDAL
    {
        private DbConnectDataContext dbContext = new DbConnectDataContext();
        public List<LOAIHH> LayDanhSachLoaiHangHoa()
        {
            return dbContext.LOAIHHs.ToList();
        }

        public bool AddLoaiHangHoa(LOAIHH loAIHH)
        {
            try
            {
                if (GetLoaiHangHoaByCode(loAIHH.MaLH))
                {
                    Console.WriteLine("Loại hàng hóa với mã này đã tồn tại.");
                    return false; 
                }

                dbContext.LOAIHHs.InsertOnSubmit(loAIHH);
                dbContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi thêm loại hàng hóa: " + ex.Message);
                return false;
            }
        }
        public bool GetLoaiHangHoaByCode(string maLH)
        {
            try
            {
                // Kiểm tra xem loại hàng hóa với mã MaLH có tồn tại không
                bool exists = dbContext.LOAIHHs.Any(loaiHH => loaiHH.MaLH == maLH);
                return exists;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi kiểm tra loại hàng hóa: " + ex.Message);
                return false; 
            }
        }


        public bool DeleteLoaiHang(string maLH)
        {
            try
            {
                var loaiHH = dbContext.LOAIHHs.SingleOrDefault(lh => lh.MaLH == maLH);

                if (loaiHH != null)
                {
                    // Kiểm tra xem loại hàng hóa này có tồn tại hàng hóa liên quan hay không
                    bool hasRelatedHangHoa = dbContext.HANGHOAs.Any(hh => hh.MaLH == maLH);

                    if (hasRelatedHangHoa)
                    {
                        Console.WriteLine("Không thể xóa loại hàng hóa vì đang có hàng hóa liên quan.");
                        return false;
                    }
                    // Nếu không có hàng hóa liên quan, tiến hành xóa
                    dbContext.LOAIHHs.DeleteOnSubmit(loaiHH);
                    dbContext.SubmitChanges();
                    return true;
                }
                return false; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi xóa loại hàng hóa: " + ex.Message);
                return false;
            }
        }
        public bool UpdateLoaiHang(LOAIHH updatedLoaiHang)
        {
            try
            {
                var loaiHang = dbContext.LOAIHHs.FirstOrDefault(lh => lh.MaLH == updatedLoaiHang.MaLH);

                if (loaiHang != null)
                {
                    loaiHang.TenLH = updatedLoaiHang.TenLH;
                    loaiHang.MoTa = updatedLoaiHang.MoTa;

                    dbContext.SubmitChanges();
                    return true; 
                }

                return false; 
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi khi cập nhật loại hàng: " + ex.Message);
                return false; 
            }
        }

    }
}
