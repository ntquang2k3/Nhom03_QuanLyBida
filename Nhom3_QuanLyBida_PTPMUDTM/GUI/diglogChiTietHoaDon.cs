using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using BLL;
using DTO;
namespace GUI
{
    public partial class diglogChiTietHoaDon : Form
    {
        private int mahoadon;
        private HoaDonBLL hoaDonBLL;
        public diglogChiTietHoaDon(int madon)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            mahoadon = madon;
            hoaDonBLL = new HoaDonBLL();

            LoadChiTietHoaDon();
        }
        private void LoadChiTietHoaDon()
        {
            var chiTietHoaDon = hoaDonBLL.LayChiTietHoaDon(mahoadon);
            dataGridViewChiTietHoaDon.DataSource = chiTietHoaDon.ToList();

            dataGridViewChiTietHoaDon.Columns["ID"].HeaderText = "Mã Hóa Đơn";
            dataGridViewChiTietHoaDon.Columns["TenDichVu"].HeaderText = "Tên Dịch Vụ";
            dataGridViewChiTietHoaDon.Columns["Gia"].HeaderText = "Đơn Giá";
            dataGridViewChiTietHoaDon.Columns["SoLuong"].HeaderText = "Số Lượng";
            dataGridViewChiTietHoaDon.Columns["ThanhTien"].HeaderText = "Thành Tiền";
        }

    }
}
