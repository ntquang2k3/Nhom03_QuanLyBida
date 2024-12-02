using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class HoaDonDAL
    {
        private QuanLyBidaDataContext dbContext;

        public HoaDonDAL()
        {
            dbContext = new QuanLyBidaDataContext();
        }

       
        public bool XoaHoaDon(int maHDBH)
        {
            try
            {
                // Xóa các chi tiết hóa đơn liên quan đến mã hóa đơn
                var chiTietHoaDons = dbContext.CHITIETHOADONs
                                        .Where(ct => ct.MaHDBH == maHDBH);
                dbContext.CHITIETHOADONs.DeleteAllOnSubmit(chiTietHoaDons);

                // Xóa hóa đơn
                var hoaDon = dbContext.HOADONs
                              .FirstOrDefault(hd => hd.MaHDBH == maHDBH);
                if (hoaDon != null)
                {
                    dbContext.HOADONs.DeleteOnSubmit(hoaDon);
                }


                dbContext.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public List<ChiTietHoaDonDTO> GetChiTietHoaDon(int maHDBH)
        {

            var query = (from ct in dbContext.CHITIETHOADONs
                         join hh in dbContext.HANGHOAs on ct.MaHH equals hh.MaHH
                         where ct.MaHDBH == maHDBH
                         select new ChiTietHoaDonDTO
                         {
                             ID = ct.MaHDBH,
                             TenDichVu = hh.TenHH,
                             Gia = hh.GiaSP,
                             SoLuong = ct.SoLuong,
                             ThanhTien = ct.ThanhTien
                         }).ToList();

            return query;
        }

        public HOADON GetHoaDon(int maHDBH)
        {
            return dbContext.HOADONs.SingleOrDefault(hd => hd.MaHDBH == maHDBH);
        }

        public List<HOADON> SearchHoaDonMaKH(string maKH)
        {
            try
            {
                if (string.IsNullOrEmpty(maKH))
                {

                    return new List<HOADON>();
                }

                var hoaDon = dbContext.HOADONs
                                            .Where(ct => ct.MaKH == maKH)
                                            .ToList();
                if (hoaDon.Count == 0)
                {
                    return new List<HOADON>();
                }

                return hoaDon;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi khi truy vấn hóa đơn: " + ex.Message);
            }
        }
    }
}
