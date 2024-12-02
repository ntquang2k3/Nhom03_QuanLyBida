using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DB_DAL_Quang
    {
        QuanLyBidaDataContext qlbd = new QuanLyBidaDataContext();
        public DB_DAL_Quang()
        {
        }
        public DataTable LayDanhSachLoaiBan()
        {
            var dsLoaiBan = from loaiBan in qlbd.LoaiBans
                            where loaiBan != null
                            select loaiBan;
            // Khởi tạo DataTable và cấu hình các cột
            DataTable dt = new DataTable();
            dt.Columns.Add("maban", typeof(int)); // Cột maban kiểu int
            dt.Columns.Add("tenloaiban", typeof(string)); // Cột tenloaiban kiểu string
            dt.Columns.Add("GiaGioChoi", typeof(int)); // Cột GiaGioChoi kiểu int
            foreach (var item in dsLoaiBan)
            {
                DataRow dr = dt.NewRow();
                dr["maban"] = item.maban;
                dr["tenloaiban"] = item.tenloaiban;
                dr["GiaGioChoi"] = item.GiaGioChoi;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public DataTable LayDanhSachKhuVuc(int maLoaiBan)
        {
            var dsKhuVuc = from khuVuc in qlbd.KHUVUCs
                           where khuVuc.MaLoaiBan == maLoaiBan
                           select khuVuc;
            // Khởi tạo DataTable và cấu hình các cột
            DataTable dt = new DataTable();
            dt.Columns.Add("MaKV", typeof(string)); // Cột maban kiểu int
            dt.Columns.Add("TenKV", typeof(string)); // Cột tenloaiban kiểu string
            dt.Columns.Add("GiaTien", typeof(int)); // Cột GiaGioChoi kiểu int
            dt.Columns.Add("MaLoaiBan", typeof(int)); // Cột GiaGioChoi kiểu int
            foreach (var item in dsKhuVuc)
            {
                DataRow dr = dt.NewRow();
                dr["MaKV"] = item.MaKV;
                dr["TenKV"] = item.TenKV;
                dr["GiaTien"] = item.GiaTien;
                dr["MaLoaiBan"] = item.MaLoaiBan;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public DataTable LayTatCaDanhSachKhuVuc()
        {
            var dsKhuVuc = from khuVuc in qlbd.KHUVUCs
                           select khuVuc;
            // Khởi tạo DataTable và cấu hình các cột
            DataTable dt = new DataTable();
            dt.Columns.Add("MaKV", typeof(string)); // Cột maban kiểu int
            dt.Columns.Add("TenKV", typeof(string)); // Cột tenloaiban kiểu string
            dt.Columns.Add("GiaTien", typeof(int)); // Cột GiaGioChoi kiểu int
            dt.Columns.Add("MaLoaiBan", typeof(int)); // Cột GiaGioChoi kiểu int
            foreach (var item in dsKhuVuc)
            {
                DataRow dr = dt.NewRow();
                dr["MaKV"] = item.MaKV;
                dr["TenKV"] = item.TenKV;
                dr["GiaTien"] = item.GiaTien;
                dr["MaLoaiBan"] = item.MaLoaiBan;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public DataTable LayDanhSachTrangThaiBan()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("MaTrangThai", typeof(string));
            dt.Columns.Add("TenTrangThai", typeof(string));
            DataRow dataRow1 = dt.NewRow();
            dataRow1["MaTrangThai"] = "All";
            dataRow1["TenTrangThai"] = "Tất cả";
            dt.Rows.Add(dataRow1);
            DataRow dataRow2 = dt.NewRow();
            dataRow2["MaTrangThai"] = "Empty";
            dataRow2["TenTrangThai"] = "Trống";
            dt.Rows.Add(dataRow2);
            DataRow dataRow3 = dt.NewRow();
            dataRow3["MaTrangThai"] = "InUse";
            dataRow3["TenTrangThai"] = "Đang chơi";
            dt.Rows.Add(dataRow3);
            return dt;
        }
        public DataTable LayDanhSachBan(int maLoaiBan, string maKhuVuc, string trangThai)
        {
            string trangThaiDisplay = "";
            switch (trangThai)
            {
                case "All":
                    trangThaiDisplay = "";
                    break;
                case "Empty":
                    trangThaiDisplay = "Trống";
                    break;
                case "InUse":
                    trangThaiDisplay = "Đang chơi";
                    break;
                default:
                    break;
            }
            if (maKhuVuc == "All")
            {
                maKhuVuc = "";
            }
            var dsBanBida = from ban in qlbd.BANs
                            join khuVuc in qlbd.KHUVUCs on ban.MaKV equals khuVuc.MaKV // Liên kết với bảng KHUVUC
                            join loaiBan in qlbd.LoaiBans on khuVuc.MaLoaiBan equals loaiBan.maban // Liên kết với bảng LOAIBAN
                            where ban.TrangThai.Contains(trangThaiDisplay) && khuVuc.MaKV.Contains(maKhuVuc) && loaiBan.maban.Equals(maLoaiBan)
                            select new
                            {
                                MaBan = ban.MaBan,             // Mã bàn
                                TenBan = ban.TenBan,
                                TrangThai = ban.TrangThai,  // Tên bàn
                                TenKhuVuc = khuVuc.TenKV,
                                MaLoaiBan = ban.MaKV,// Tên khu vực
                                TenLoaiBan = loaiBan.tenloaiban,    // Tên loại bàn
                                GiaLoaiBan = loaiBan.GiaGioChoi,     // Giá giờ chơi
                                GiaKhuVuc = khuVuc.GiaTien,

                            };
            // Khởi tạo DataTable và cấu hình các cột
            DataTable dt = new DataTable();
            dt.Columns.Add("MaBan", typeof(string)); // Cột maban kiểu int
            dt.Columns.Add("TenBan", typeof(string)); // Cột tenloaiban kiểu string
            dt.Columns.Add("TrangThai", typeof(string)); // Cột tenloaiban kiểu string
            dt.Columns.Add("TenKhuVuc", typeof(string));
            dt.Columns.Add("MaLoaiBan", typeof(string));// Cột maban kiểu int
            dt.Columns.Add("TenLoaiBan", typeof(string)); // Cột tenloaiban kiểu string
            dt.Columns.Add("GiaLoaiBan", typeof(int)); // Cột maban kiểu int
            dt.Columns.Add("GiaKhuVuc", typeof(int)); // Cột tenloaiban kiểu string
            foreach (var item in dsBanBida)
            {
                DataRow dr = dt.NewRow();
                dr["MaBan"] = item.MaBan;
                dr["TenBan"] = item.TenBan;
                dr["TenKhuVuc"] = item.TenKhuVuc;
                dr["MaLoaiBan"] = item.MaLoaiBan;
                dr["TenLoaiBan"] = item.TenLoaiBan;
                dr["GiaLoaiBan"] = item.GiaLoaiBan;
                dr["GiaKhuVuc"] = item.GiaKhuVuc;
                dr["TrangThai"] = item.TrangThai;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public DataTable LayDanhSachLoaiHangHoa()
        {
            var dsLoaiHH = from loaiHH in qlbd.LOAIHHs
                           where loaiHH != null
                           select loaiHH;
            // Khởi tạo DataTable và cấu hình các cột
            DataTable dt = new DataTable();
            dt.Columns.Add("MaLH", typeof(string)); // Cột maban kiểu int
            dt.Columns.Add("TenLH", typeof(string)); // Cột tenloaiban kiểu string
            dt.Columns.Add("MoTa", typeof(string)); // Cột GiaGioChoi kiểu int
            foreach (var item in dsLoaiHH)
            {
                DataRow dr = dt.NewRow();
                dr["MaLH"] = item.MaLH;
                dr["TenLH"] = item.TenLH;
                dr["MoTa"] = item.MoTa;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public DataTable LayDanhSachHangHoa(string maLoaiHangHoa)
        {
            if (maLoaiHangHoa == "All")
            {
                maLoaiHangHoa = "";
            }
            var dsHangHoa = from hangHoa in qlbd.HANGHOAs
                            join loaiHangHoa in qlbd.LOAIHHs on hangHoa.MaLH equals loaiHangHoa.MaLH
                            where hangHoa.MaLH.Contains(maLoaiHangHoa)
                            select hangHoa;
            // Khởi tạo DataTable và cấu hình các cột
            DataTable dt = new DataTable();
            dt.Columns.Add("MaHH", typeof(string));
            dt.Columns.Add("MaLH", typeof(string)); // Cột maban kiểu int
            dt.Columns.Add("TenHH", typeof(string)); // Cột tenloaiban kiểu string
            dt.Columns.Add("HinhAnh", typeof(string)); // Cột GiaGioChoi kiểu int
            dt.Columns.Add("GiaSP", typeof(int)); // Cột GiaGioChoi kiểu int
            foreach (var item in dsHangHoa)
            {
                DataRow dr = dt.NewRow();
                dr["MaHH"] = item.MaHH;
                dr["MaLH"] = item.MaLH;
                dr["TenHH"] = item.TenHH;
                dr["HinhAnh"] = item.HinhAnh;
                dr["GiaSP"] = item.GiaSP;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        //Thêm mới 1 hóa đơn
        public DataTable LayChiTietHoaDon(int maHoaDon)
        {
            var dsCTHD = from cthd in qlbd.CHITIETHOADONs
                         join hoadon in qlbd.HOADONs on cthd.MaHDBH equals hoadon.MaHDBH
                         join hanghoa in qlbd.HANGHOAs on cthd.MaHH equals hanghoa.MaHH
                         where cthd.MaHDBH.Equals(maHoaDon)
                         select new
                         {
                             MaHDBH = cthd.MaHDBH,
                             MaHH = cthd.MaHH,
                             TenHH = hanghoa.TenHH,
                             SoLuong = cthd.SoLuong,
                             ThanhTien = cthd.ThanhTien
                         };
            // Khởi tạo DataTable và cấu hình các cột
            DataTable dt = new DataTable();
            dt.Columns.Add("MaHDBH", typeof(int));
            dt.Columns.Add("MaHH", typeof(string)); // Cột maban kiểu int
            dt.Columns.Add("TenHH", typeof(string)); // Cột maban kiểu int
            dt.Columns.Add("SoLuong", typeof(int)); // Cột tenloaiban kiểu string
            dt.Columns.Add("ThanhTien", typeof(int)); // Cột GiaGioChoi kiểu int
            foreach (var item in dsCTHD)
            {
                DataRow dr = dt.NewRow();
                dr["MaHDBH"] = item.MaHDBH;
                dr["MaHH"] = item.MaHH;
                dr["TenHH"] = item.TenHH;
                dr["SoLuong"] = item.SoLuong;
                dr["ThanhTien"] = item.ThanhTien;
                dt.Rows.Add(dr);
            }
            return dt;
        }
        public CHITIETHOADON LayChiTietHoaDonVoiMaHH(int maHoaDon, string maHH)
        {
            // Sử dụng FirstOrDefault để tìm chi tiết hóa đơn có cả hai điều kiện MaHDBH và MaHH
            var cthd = qlbd.CHITIETHOADONs
                          .FirstOrDefault(t => t.MaHDBH == maHoaDon && t.MaHH == maHH);

            return cthd;
        }
        public bool CapNhatSoLuongCTHD(int maHoaDon, string maHH, CHITIETHOADON newCTHD)
        {
            try
            {
                // Tìm chi tiết hóa đơn có MaHDBH và MaHH tương ứng
                var cthd = qlbd.CHITIETHOADONs
                              .FirstOrDefault(t => t.MaHDBH == maHoaDon && t.MaHH == maHH);

                // Nếu tìm thấy chi tiết hóa đơn
                if (cthd != null)
                {
                    // Cập nhật số lượng
                    cthd.SoLuong = newCTHD.SoLuong;
                    int gia = (int)cthd.HANGHOA.GiaSP;
                    cthd.ThanhTien = cthd.SoLuong * gia;

                    // Lưu thay đổi vào cơ sở dữ liệu
                    qlbd.SubmitChanges();
                    return true; // Thành công
                }

                // Nếu không tìm thấy chi tiết hóa đơn
                return false; // Không tìm thấy chi tiết hóa đơn
            }
            catch (Exception)
            {
                // Xử lý lỗi (nếu có)
                return false;
            }
        }

        public HOADON LayMotHoaDon(int maHoaDon)
        {
            var hoadon = qlbd.HOADONs
                          .FirstOrDefault(b => b.MaHDBH == maHoaDon);  // Tìm phần tử đầu tiên hoặc null nếu không tìm thấy

            if (hoadon != null)
            {
                return hoadon;  // Trả về đối tượng HOADON nếu tìm thấy
            }
            else
            {
                // Xử lý khi không tìm thấy bàn (có thể trả về null hoặc ném lỗi, tùy nhu cầu)
                return null;  // Hoặc có thể ném một ngoại lệ nếu cần
            }
        }
        public int TinhTienDichVuHoaDon(int maHoaDon)
        {
            var hoadon = qlbd.HOADONs
                          .FirstOrDefault(b => b.MaHDBH == maHoaDon);  // Tìm phần tử đầu tiên hoặc null nếu không tìm thấy

            if (hoadon != null)
            {
                var tienDichVu = hoadon.CHITIETHOADONs.Sum(t => t.ThanhTien);
                return (int)tienDichVu;
            }
            else
            {
                // Xử lý khi không tìm thấy bàn (có thể trả về null hoặc ném lỗi, tùy nhu cầu)
                return -1;  // Hoặc có thể ném một ngoại lệ nếu cần
            }
        }
        public bool ThemMotHoaDon(HOADON hd)
        {
            qlbd.HOADONs.InsertOnSubmit(hd);
            try
            {
                // Lưu thay đổi vào cơ sở dữ liệu
                qlbd.SubmitChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ThemChiTietHoaDon(int mahoadon, CHITIETHOADON cthd)
        {
            try
            {
                // Tìm hóa đơn có MaHoaDon tương ứng
                var hoaDon = qlbd.HOADONs.FirstOrDefault(hd => hd.MaHDBH == mahoadon);

                // Nếu tìm thấy hóa đơn, thêm chi tiết hóa đơn vào
                if (hoaDon != null)
                {
                    hoaDon.CHITIETHOADONs.Add(cthd);
                    qlbd.SubmitChanges();
                    return true;
                }

                // Nếu không tìm thấy hóa đơn
                return false;
            }
            catch (Exception ex)
            {
                // Xử lý lỗi nếu có (ví dụ như exception trong quá trình thêm)
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        public bool XoaChiTietHoaDon(int mahoadon, string mahh)
        {
            // Tìm hóa đơn cần xóa trong bảng HoaDon dựa trên MaHDBH
            var cthd = qlbd.CHITIETHOADONs.FirstOrDefault(hd => hd.MaHDBH == mahoadon && hd.MaHH == mahh);

            // Nếu tìm thấy hóa đơn, thực hiện xóa
            if (cthd != null)
            {
                qlbd.CHITIETHOADONs.DeleteOnSubmit(cthd); // Xóa hóa đơn
                qlbd.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool XoaMotHoaDon(int maHoaDon)
        {
            // Tìm hóa đơn cần xóa trong bảng HoaDon dựa trên MaHDBH
            var hoaDon = qlbd.HOADONs.FirstOrDefault(hd => hd.MaHDBH == maHoaDon);

            // Nếu tìm thấy hóa đơn, thực hiện xóa
            if (hoaDon != null)
            {
                qlbd.HOADONs.DeleteOnSubmit(hoaDon); // Xóa hóa đơn
                qlbd.SubmitChanges(); // Lưu thay đổi vào cơ sở dữ liệu
                return true;
            }
            else
            {
                return false;
            }
        }
        public bool CapNhatBanCuaHoaDon(HOADON hd, string maBan)
        {
            if (hd != null)
            {
                // Cập nhật trạng thái của bàn
                hd.MaBan = maBan;

                // Lưu thay đổi vào cơ sở dữ liệu
                try
                {
                    qlbd.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool CapNhatHoaDon(HOADON hdCu, HOADON hdMoi)
        {
            if (hdCu != null)
            {
                hdCu = hdMoi;

                // Lưu thay đổi vào cơ sở dữ liệu
                try
                {
                    qlbd.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public HOADON LayHoaDonMoiNhat(string maBan)
        {

            var hoaDonMoiNhat = qlbd.HOADONs
                        .Where(hd => hd.MaBan == maBan && hd.BAN.TrangThai == "Đang chơi") // Lọc theo MaBan và TrangThai của BAN
                        .OrderByDescending(hd => hd.ThoiGianVao)  // Sắp xếp theo ThoiGianVao giảm dần
                        .FirstOrDefault(); // Lấy hóa đơn mới nhất
                                           // Lấy phần tử đầu tiên (hoặc null nếu không có hóa đơn)

            // Trả về hóa đơn mới nhất hoặc null nếu không tìm thấy
            return hoaDonMoiNhat;
        }

        public int TaoMaHoaDon()
        {
            int maHoaDon = 0;

            // Khởi tạo DataContext (kết nối với cơ sở dữ liệu)
            // Lấy mã hóa đơn lớn nhất (sắp xếp theo MaHDBH giảm dần và lấy 1 hóa đơn đầu tiên)
            var lastInvoice = qlbd.HOADONs.OrderByDescending(hd => hd.MaHDBH).FirstOrDefault();

            if (lastInvoice != null)
            {
                // Nếu có hóa đơn, lấy mã và cộng thêm 1
                maHoaDon = lastInvoice.MaHDBH + 1;
            }
            else
            {
                // Nếu không có hóa đơn nào, trả về mã hóa đơn đầu tiên là 1
                maHoaDon = 1;
            }

            return maHoaDon;
        }

        //Cập nhật trạng thái bàn
        public BAN LayMotBan(string maBan)
        {
            var ban = qlbd.BANs
                          .FirstOrDefault(b => b.MaBan == maBan);  // Tìm phần tử đầu tiên hoặc null nếu không tìm thấy

            if (ban != null)
            {
                return ban;  // Trả về đối tượng BAN nếu tìm thấy
            }
            else
            {
                // Xử lý khi không tìm thấy bàn (có thể trả về null hoặc ném lỗi, tùy nhu cầu)
                return null;  // Hoặc có thể ném một ngoại lệ nếu cần
            }
        }

        public bool CapNhatTrangThaiBan(BAN ban, string trangThai)
        {
            if (ban != null)
            {
                // Cập nhật trạng thái của bàn
                ban.TrangThai = trangThai;

                // Lưu thay đổi vào cơ sở dữ liệu
                try
                {
                    qlbd.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Cộng điểm cho khách hàng
        public bool CongDiemKhachHang(KHACHHANG kh, int diemCong)
        {
            if (kh != null)
            {
                // Cập nhật trạng thái của bàn
                kh.DiemTichLuy += diemCong;

                // Lưu thay đổi vào cơ sở dữ liệu
                try
                {
                    qlbd.SubmitChanges();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        //Lấy một nhân viên
        public NHANVIEN LayMotNhanVien(string tk, string matkhau)
        {
            var nv = qlbd.NHANVIENs.Where(t => t.MaNV == tk && t.MatKhau == matkhau).FirstOrDefault();
            return nv;
        }
        public NHANVIEN LayMotNhanVien(string tk)
        {
            var nv = qlbd.NHANVIENs.Where(t => t.MaNV == tk).FirstOrDefault();
            return nv;
        }
        public DataTable GetTongTienTheoNgayHoanThanhDataTable(string ngay_bat_dau, string ngay_ket_thuc)
        {
            // Chuyển đổi chuỗi ngày sang DateTime
            DateTime startDate = DateTime.Parse(ngay_bat_dau);
            DateTime endDate = DateTime.Parse(ngay_ket_thuc);

            // Sử dụng LINQ để tính tổng doanh thu theo ngày
            var groupedData = qlbd.HOADONs
                .Where(invoice => invoice.NgayXuatHD >= startDate && invoice.NgayXuatHD <= endDate)
                .GroupBy(invoice => invoice.NgayXuatHD.Value.Date) // Nhóm theo ngày
                .Select(group => new
                {
                    Date = group.Key,
                    TotalRevenue = group.Sum(invoice => invoice.TongTien)
                })
                .ToList();

            // Tạo DataTable để trả về kết quả
            DataTable dt = new DataTable();
            dt.Columns.Add("Ngày", typeof(DateTime));
            dt.Columns.Add("Tổng Tiền", typeof(decimal));

            // Đổ dữ liệu từ groupedData vào DataTable
            foreach (var item in groupedData)
            {
                dt.Rows.Add(item.Date, item.TotalRevenue);
            }

            return dt;
        }
    }
}