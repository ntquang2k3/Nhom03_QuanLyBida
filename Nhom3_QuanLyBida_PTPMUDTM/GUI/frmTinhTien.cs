using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmTinhTien : Form
    {
        DB_BLL bll = new DB_BLL();
        public int maHDBH {  get; set; }
        public frmTinhTien()
        {
            InitializeComponent();
            this.Load += FrmTinhTien_Load;
        }

        private void FrmTinhTien_Load(object sender, EventArgs e)
        {
            LoadBida();
            LoadGridViewHoaDon(maHDBH);
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
            lblGiaLoaiBan.Text = hd.BAN.KHUVUC.LoaiBan.GiaGioChoi.ToString();
            lblGiaKhuVuc.Text = hd.BAN.KHUVUC.GiaTien.ToString();
            int giaLoaiBan = int.Parse(lblGiaLoaiBan.Text);
            int giaKhuVuc = int.Parse(lblGiaKhuVuc.Text);
            int giaBanChoi = giaLoaiBan + giaKhuVuc;
            lblGiaBanChoi.Text = giaBanChoi.ToString();
            lblThoiGianDatCoc.Text = hd.ThoiGianDatCoc.ToString();
            lblThoiGianTraBan.Text = hd.ThoiGianKTDatCoc.ToString();
            lblThoiGianVaoChoi.Text = hd.ThoiGianVao.ToString();
            DateTime tgRaVe = DateTime.Now;
            lblThoiGianRaVe.Text = tgRaVe.ToString();
            int tongTGChoi = (int)(tgRaVe - hd.ThoiGianVao).Value.TotalMinutes;
            int soTiengChoi = tongTGChoi / 60;
            int soPhutDu = tongTGChoi - (soTiengChoi * 60);
            float soTiengTinhTien = (float)tongTGChoi / 60;
            lblThoiGianChoi.Text = soTiengChoi.ToString() + " Tiếng " + soPhutDu.ToString() + " Phút";
            double tienbida = (double) (soTiengTinhTien * giaBanChoi);
            // Làm tròn số tiền đến hàng nghìn gần nhất
            tienbida = Math.Round(tienbida / 1000) * 1000;
            // Định dạng số tiền và hiển thị với định dạng VNĐ
            lblTienBida.Text = tienbida.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";

            lblTienBida.Text = tienbida.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            double tienDichVu = bll.TinhTienDichVuHoaDon(hd.MaHDBH);
            lblTienDichVu.Text = tienDichVu.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            double tongTien = tienDichVu + tienbida;
            lblTongTien.Text = tongTien.ToString("#,0", CultureInfo.GetCultureInfo("vi-VN")) + " VNĐ";
            lblTongTien2.Text = lblTongTien.Text;
        }
    }
}
