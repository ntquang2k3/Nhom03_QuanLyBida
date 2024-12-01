using BLL;
using DAL;
using DevExpress.ClipboardSource.SpreadsheetML;
using DevExpress.SpreadsheetSource;
using DevExpress.XtraReports.Parameters.Native;
using DTO;
using Syncfusion.XlsIO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using IRange = Syncfusion.XlsIO.IRange;
using IWorksheet = Syncfusion.XlsIO.IWorksheet;

namespace GUI
{
    public partial class frmTinhTien : Form
    {
        DB_BLL bll = new DB_BLL();
        LoaiKhachHangBLL lkhBLL = new LoaiKhachHangBLL();
        KhachHangBLL khBLL = new KhachHangBLL();
        public int maHDBH { get; set; }
        private double tongTien;
        private double tienThanhToan;
        private DateTime tgRaVe;
        public event EventHandler BtnInClicked;  // Định nghĩa sự kiện để form cha có thể đăng ký
        public frmTinhTien()
        {
            InitializeComponent();
            this.Load += FrmTinhTien_Load;
            btnLayThongTinKH.Click += BtnLayThongTinKH_Click;
            numericDungDiem.ValueChanged += NumericDungDiem_ValueChanged;
            numericTienKhachDua.ValueChanged += NumericTienKhachDua_ValueChanged;
            btnInHoaDon.Click += BtnInHoaDon_Click;
        }

        private void BtnInHoaDon_Click(object sender, EventArgs e)
        {
            XuatHoaDonExcel();
            CapNhatTinhTienChoHoaDon();
            CongDiemTichLuyChoKhachHang();
            CapNhatBanTrong();
            // Gọi sự kiện BtnInClicked khi nút btnIn được nhấn
            BtnInClicked?.Invoke(this, EventArgs.Empty);
            //Đóng form
            this.Close();
        }

        private void CapNhatBanTrong()
        {
            HOADON hd = bll.LayMotHoaDon(maHDBH);
            BAN kh = hd.BAN;
            bool kq = bll.CapNhatTrangThaiBan(kh, "Trống");
            if (kq == true)
            {
                MessageBox.Show("Cập nhật trạng thái bàn thành công");
            }
            else
            {
                MessageBox.Show("Cập nhật trạng thái bàn không thành công");
            }
        }

        private void CongDiemTichLuyChoKhachHang()
        {
            HOADON hd = bll.LayMotHoaDon(maHDBH);
            KHACHHANG kh = hd.KHACHHANG;
            int diemCong = int.Parse(lblDiemDuocCong.Text);
            diemCong -= (int)numericDungDiem.Value;
            bool kq = bll.CongDiemKhachHang(kh, diemCong);
            if (kq == true)
            {
                MessageBox.Show("Cộng điểm tích lũy thành công");
            }
            else
            {
                MessageBox.Show("Cộng điểm tích lũy không thành công");
            }
        }

        private void CapNhatTinhTienChoHoaDon()
        {
            HOADON hdcu = bll.LayMotHoaDon(maHDBH);
            HOADON hdmoi = bll.LayMotHoaDon(maHDBH);
            hdmoi.NgayXuatHD = tgRaVe;
            hdmoi.ThoiGianRa = tgRaVe;
            hdmoi.TongTien = (int)tongTien;
            hdmoi.DiemTL = (int)(tongTien / 100);
            hdmoi.GiamGia = (int)numericDungDiem.Value;
            hdmoi.MaKH = lblMaKH.Text;
            hdmoi.SoTienThanhToan = (int)tienThanhToan;
            bool kq = bll.CapNhatHoaDon(hdcu, hdmoi);
            if (kq == true)
            {
                MessageBox.Show("Cập nhật hóa đơn thành công !!!");
            }
            else
            {
                MessageBox.Show("Cập nhật hóa đơn không thành công !!!");
            }
        }

        private void XuatHoaDonExcel()
        {
            //HOADON hdreport = bll.LayMotHoaDon(maHDBH);
            HoaDonBLL hdbll = new HoaDonBLL();
            List<HoaDonReport> dsCTHoaDonReport = hdbll.LayChiTietHoaDonReport(maHDBH);
            //Create replacer
            Dictionary<string, string> replacer = new Dictionary<string, string>();
            replacer.Add("%MaHoaDon", lblMaHoaDon.Text);
            replacer.Add("%MaNhanVien", lblMaNhanVien.Text);
            replacer.Add("%LoaiBan", lblLoaiBan.Text);
            replacer.Add("%KhuVuc", lblKhuVuc.Text);
            replacer.Add("%MaBan", lblMaBan.Text);
            replacer.Add("%GiaLoaiBan", lblGiaLoaiBan.Text);
            replacer.Add("%GiaKhuVuc", lblGiaKhuVuc.Text);
            replacer.Add("%GiaBan", lblGiaBanChoi.Text);
            replacer.Add("%ThoiGianVao", lblThoiGianVaoChoi.Text);
            replacer.Add("%ThoiGianRaVe", lblThoiGianRaVe.Text);
            replacer.Add("%TongThoiGianChoi", lblThoiGianChoi.Text);
            replacer.Add("%TienBida", lblTienBida.Text);
            replacer.Add("%TienDichVu", lblTienDichVu.Text);
            replacer.Add("%TongTien", lblTongTien.Text);
            replacer.Add("%HoTenKhachHang", lblHoTenKH.Text);
            replacer.Add("%DTLDuocCong", lblDiemDuocCong.Text);
            replacer.Add("%DungDiem", numericDungDiem.Value.ToString());
            replacer.Add("%SoTienThanhToan", lblSoTienThanhToan.Text);
            replacer.Add("%SoTienKhachDua", numericTienKhachDua.Value.ToString());
            replacer.Add("%TienThoi", lblTienThoi.Text);

            MemoryStream stream = null;
            byte[] arrByte = new byte[0];
            arrByte = File.ReadAllBytes("HoaDon.xlsx").ToArray();
            //Get stream
            if (arrByte.Count() > 0)
            {
                stream = new MemoryStream(arrByte);
            }
            //Create Excel Engine
            ExcelEngine engine = new ExcelEngine();
            IWorkbook workBook = engine.Excel.Workbooks.Open(stream);
            IWorksheet workSheet = workBook.Worksheets[0];
            ITemplateMarkersProcessor markProcessor = workSheet.CreateTemplateMarkersProcessor();
            //Replace value
            if (replacer != null && replacer.Count > 0)
            {
                foreach (KeyValuePair<string, string> repl in replacer)
                {
                    Replace(workSheet, repl.Key, repl.Value);
                }
            }
            //Lấp đầy đủ thông tin cần xuất theo Excel
            //List<CHITIETPHIEUNHAP> ctpns = pn.CHITIETPHIEUNHAPs.Where(t => t.MAPHIEUNHAP == pn.MAPHIEUNHAP).ToList();
            //List<ChiTietPN> ctpnSTT = new List<ChiTietPN>();
            //int stt = 1;
            //foreach (CHITIETPHIEUNHAP ct in ctpns)
            //{
            //    ChiTietPN ctstt = new ChiTietPN(ct, stt++);
            //    ctstt.TenSP = qlhh.SANPHAMs.Where(t => t.MASANPHAM == ct.MASANPHAM).FirstOrDefault().TENSANPHAM;
            //    ctpnSTT.Add(ctstt);
            //}
            string viewName = "HoaDon";
            markProcessor.AddVariable(viewName, dsCTHoaDonReport);
            markProcessor.ApplyMarkers(UnknownVariableAction.ReplaceBlank);
            ////Xóa bỏ dòng đánh dấu [TMP]
            IRange range = workSheet.FindFirst("[TMP]", ExcelFindType.Text);
            if (range != null)
            {
                workSheet.DeleteRow(range.Row);
            }
            //Lưu file
            //string fileName = "";
            //string file = Path.Combine(Path.GetTempPath(), "PhieuNhapHang_" + Guid.NewGuid() + "xlsx");
            //fileName = file;
            //Output file
            string fileName = "HoaDon_HoanTat.xlsx";
            try
            {
                workBook.SaveAs(fileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi lưu tệp : ", ex.Message);
            }


            //Close
            workBook.Close();
            engine.Dispose();
            MessageBox.Show("Xuất xong");
            if (!string.IsNullOrEmpty(fileName) && MessageBox.Show("Bạn có muốn mở file không  ?", "Thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
            {
                System.Diagnostics.Process.Start(fileName);
            }
        }

        private void Replace(IWorksheet workSheet, string p1, string p2)
        {
            workSheet.Replace(p1, p2);
        }

        private void NumericTienKhachDua_ValueChanged(object sender, EventArgs e)
        {
            double tienKhachDua;
            tienKhachDua = (double)numericTienKhachDua.Value;
            if (tienKhachDua >= tienThanhToan)
            {
                lblTienThoi.Text = (tienKhachDua - tienThanhToan).ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            }
            else
            {
                MessageBox.Show("Tiền không đủ !!!");
                numericTienKhachDua.ValueChanged -= NumericTienKhachDua_ValueChanged;
                numericTienKhachDua.Value = 0;
                numericTienKhachDua.ValueChanged += NumericTienKhachDua_ValueChanged;
            }
        }

        private void NumericDungDiem_ValueChanged(object sender, EventArgs e)
        {
            double tienDungDiem;
            tienDungDiem = (double)numericDungDiem.Value;
            int diemHienCo = int.Parse(lblDiemTichLuyDangCo.Text);
            if (diemHienCo >= tienDungDiem)
            {
                tienThanhToan = tongTien - tienDungDiem;
                lblSoTienThanhToan.Text = tienThanhToan.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            }
            else
            {
                MessageBox.Show("Vượt quá điểm tích lũy hiện có !!!");
                numericDungDiem.Value = 0;
            }
        }

        private void BtnLayThongTinKH_Click(object sender, EventArgs e)
        {
            LoadThongTinKhachHang();
        }

        private void LoadThongTinKhachHang()
        {
            if (cbbLoaiKhachHang.SelectedValue.ToString() == "LKH001")
            {
                KHACHHANG khvanglai = khBLL.GetKHACHHANG("KH001");
                lblMaKH.Text = khvanglai.MaKH.ToString();
                lblHoTenKH.Text = khvanglai.TenKH.ToString();
                lblDiemTichLuyDangCo.Text = khvanglai.DiemTichLuy.ToString();
            }
            else //Khách hàng thường
            {
                if (String.IsNullOrEmpty(txtTimKiem.Text.Trim()))
                {
                    MessageBox.Show("Thông tin trống !!!");
                }
                else
                {
                    KHACHHANG khvanglai = khBLL.GetKHACHHANGBySDT(txtTimKiem.Text);
                    if (khvanglai == null)
                    {
                        MessageBox.Show("Tìm không thấy khách hàng !!!");
                        return;
                    }
                    lblMaKH.Text = khvanglai.MaKH.ToString();
                    lblHoTenKH.Text = khvanglai.TenKH.ToString();
                    lblDiemTichLuyDangCo.Text = khvanglai.DiemTichLuy.ToString();
                }
            }
        }

        private void FrmTinhTien_Load(object sender, EventArgs e)
        {
            LoadBida();
            LoadGridViewHoaDon(maHDBH);
            LoadCbbLoaiKhachHang();
        }

        private void LoadCbbLoaiKhachHang()
        {
            List<LOAIKH> lOAIKHs = lkhBLL.LayDanhSachLoaiKhachHang();
            cbbLoaiKhachHang.DataSource = lOAIKHs;
            cbbLoaiKhachHang.DisplayMember = "TenLKH";
            cbbLoaiKhachHang.ValueMember = "MaLKH";
            cbbLoaiKhachHang.SelectedIndex = 0;
        }

        private void LoadGridViewHoaDon(int maHD)
        {
            dtgvCTHD.AllowUserToAddRows = false;
            dtgvCTHD.MultiSelect = false;
            dtgvCTHD.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvCTHD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvCTHD.DataSource = null;
            DataTable dt = bll.LayChiTietHoaDon(maHD);
            dtgvCTHD.DataSource = dt;
            dtgvCTHD.ReadOnly = true;
        }

        private void LoadBida()
        {
            lblMaHoaDon.Text = maHDBH.ToString();
            HOADON hd = bll.LayMotHoaDon(maHDBH);
            lblMaNhanVien.Text = hd.MaNV;
            lblLoaiBan.Text = hd.BAN.KHUVUC.LoaiBan.tenloaiban.ToString();
            lblKhuVuc.Text = hd.BAN.KHUVUC.TenKV.ToString();
            lblMaBan.Text = hd.MaBan;
            int giaLoaiBan = hd.BAN.KHUVUC.LoaiBan.GiaGioChoi.Value;
            int giaKhuVuc = hd.BAN.KHUVUC.GiaTien;
            lblGiaLoaiBan.Text = giaLoaiBan.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            lblGiaKhuVuc.Text = giaKhuVuc.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            int giaBanChoi = giaLoaiBan + giaKhuVuc;
            lblGiaBanChoi.Text = giaBanChoi.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            //lblThoiGianDatCoc.Text = hd.ThoiGianDatCoc.ToString();
            //lblThoiGianTraBan.Text = hd.ThoiGianKTDatCoc.ToString();
            lblThoiGianVaoChoi.Text = hd.ThoiGianVao.ToString();
            tgRaVe = DateTime.Now;
            lblThoiGianRaVe.Text = tgRaVe.ToString();
            int tongTGChoi = (int)(tgRaVe - hd.ThoiGianVao).Value.TotalMinutes;
            int soTiengChoi = tongTGChoi / 60;
            int soPhutDu = tongTGChoi - (soTiengChoi * 60);
            float soTiengTinhTien = (float)tongTGChoi / 60;
            lblThoiGianChoi.Text = soTiengChoi.ToString() + " Tiếng " + soPhutDu.ToString() + " Phút";
            double tienbida = (double)(soTiengTinhTien * giaBanChoi);
            // Làm tròn số tiền đến hàng nghìn gần nhất
            tienbida = Math.Round(tienbida / 1000) * 1000;

            // Định dạng số tiền và hiển thị với định dạng VNĐ
            lblTienBida.Text = tienbida.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";

            lblTienBida.Text = tienbida.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            double tienDichVu = bll.TinhTienDichVuHoaDon(hd.MaHDBH);
            lblTienDichVu.Text = tienDichVu.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            tongTien = tienDichVu + tienbida;
            lblDiemDuocCong.Text = (tongTien / 100).ToString();
            lblTongTien.Text = tongTien.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            lblTongTien2.Text = lblTongTien.Text;
            double tienDungDiem;
            tienDungDiem = (double)numericDungDiem.Value;
            tienThanhToan = (tongTien - tienDungDiem);
            lblSoTienThanhToan.Text = tienThanhToan.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
        }
    }
}