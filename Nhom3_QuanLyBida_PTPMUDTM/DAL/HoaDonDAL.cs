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

        public IQueryable<dynamic> GetHoaDonForGridView()
        {
            var query = from hd in dbContext.HOADONs
                        join b in dbContext.BANs on hd.MaBan equals b.MaBan
                        select new
                        {
                            ID = hd.MaHDBH,
                            MaKH = hd.MaKH,
                            MaNV = hd.MaNV,
                            MaBan = hd.MaBan,
                            TenBan = b.TenBan,
                            ThoiGianVao = hd.ThoiGianVao,
                            ThoiGianRa = hd.ThoiGianRa,
                            NgayXuatHD = hd.NgayXuatHD,
                            TienThanhToan = hd.SoTienThanhToan,
                            GiamGia = hd.GiamGia,
                            TongTien = hd.TongTien
                        };

            return query;
        }
        public IQueryable<dynamic> GetHoaDonFiltered(string maBan, string maNhanVien, bool? datCoc, DateTime? ngayChoi)
        {
            var query = from hd in dbContext.HOADONs
                        join b in dbContext.BANs on hd.MaBan equals b.MaBan
                        join nv in dbContext.NHANVIENs on hd.MaNV equals nv.MaNV
                        select new
                        {
                            ID = hd.MaHDBH,
                            MaKH = hd.MaKH,
                            MaNV = hd.MaNV,
                            MaBan = hd.MaBan,

                            TenBan = b.TenBan,
                            ThoiGianVao = hd.ThoiGianVao,
                            ThoiGianRa = hd.ThoiGianRa,
                            NgayXuatHD = hd.NgayXuatHD,
                            TienThanhToan = hd.SoTienThanhToan,
                            GiamGia = hd.GiamGia,
                            TongTien = hd.TongTien
                        };

            // Áp dụng các bộ lọc dựa trên giá trị của ComboBox
            if (!string.IsNullOrEmpty(maBan))
            {
                query = query.Where(h => h.MaBan == maBan);
            }

            if (!string.IsNullOrEmpty(maNhanVien))
            {
                query = query.Where(h => h.MaNV == maNhanVien);
            }
            if (ngayChoi.HasValue)
            {
                query = query.Where(h => h.NgayXuatHD == ngayChoi.Value.Date);
            }
            return query;
        }
        public IQueryable<dynamic> LayDanhSachNhanVien()
        {
            return from nv in dbContext.NHANVIENs
                   select new
                   {
                       MaNV = nv.MaNV,
                       TenNV = nv.TenNV
                   };
        }

        // Lấy danh sách bàn
        public IQueryable<dynamic> LayDanhSachBan()
        {
            return from b in dbContext.BANs
                   select new
                   {
                       MaBan = b.MaBan,
                       TenBan = b.TenBan
                   };
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

        public List<HoaDonReport> LayChiTietHoaDonReport(int maHDBH)
        {
            List<HoaDonReport> lst = new List<HoaDonReport> ();
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
            int i = 1;
            foreach (var monAn in query)
            {
                HoaDonReport pbc = new HoaDonReport
                {
                    STT = i.ToString(),
                    TENMONAN = monAn.TenDichVu.ToString(),
                    SOLUONG = int.Parse(monAn.SoLuong.ToString()),
                    DONGIA = double.Parse(monAn.Gia.ToString()),
                    THANHTIEN = double.Parse(monAn.ThanhTien.ToString())
                };
                lst.Add(pbc);
                i++;
            }

            return lst;
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
        public IQueryable<dynamic> GetHoaDonFiltered(string maBan, string maNhanVien, DateTime? ngayChoi)
        {
            var query = from hd in dbContext.HOADONs
                        join b in dbContext.BANs on hd.MaBan equals b.MaBan
                        join nv in dbContext.NHANVIENs on hd.MaNV equals nv.MaNV
                        select new
                        {
                            ID = hd.MaHDBH,
                            MaKH = hd.MaKH,
                            MaNV = hd.MaNV,
                            TenNV = nv.TenNV,
                            MaBan = hd.MaBan,
                            TenBan = b.TenBan,
                            ThoiGianVao = hd.ThoiGianVao,
                            ThoiGianRa = hd.ThoiGianRa,
                            NgayXuatHD = hd.NgayXuatHD,
                            TienThanhToan = hd.SoTienThanhToan,
                            GiamGia = hd.GiamGia,
                            TongTien = hd.TongTien
                        };

            // Áp dụng các bộ lọc dựa trên giá trị của ComboBox
            if (!string.IsNullOrEmpty(maBan))
            {
                query = query.Where(h => h.MaBan == maBan);
            }

            if (!string.IsNullOrEmpty(maNhanVien))
            {
                query = query.Where(h => h.MaNV == maNhanVien);
            }
            if (ngayChoi.HasValue)
            {
                query = query.Where(h => h.NgayXuatHD.Value.Date == ngayChoi.Value.Date);
            }
            return query;
        }
    }
}
