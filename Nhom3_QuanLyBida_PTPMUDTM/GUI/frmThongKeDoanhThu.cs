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
using GUI.Excel;
using DTO;
namespace GUI
{
    public partial class frmThongKeDoanhThu : Form
    {
        private BangThongKeBLL bangThongKeBLL;
        private BanBLL banBLL;
        private HangHoaBLL hangHoaBLL;
        public frmThongKeDoanhThu()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            bangThongKeBLL = new BangThongKeBLL();
            banBLL = new BanBLL();
            hangHoaBLL = new HangHoaBLL();
            loadCombobox();
            LoadDataToDataGridView();

            dataGridViewBangThongKe.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dataGridViewBangThongKe_RowPostPaint);
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);



            LoadDataToDataGridViewBanChoiNhieu();

            //Tab mon an ban nhieu
            LoadDataToDataGridViewThongKeMon();
        }

        //Tab Thong ke
        private void button3_Click(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePickerNgayThongKe.Value.Date;
            LoadDataToDataGridViewTheoNgay(selectedDate);
        }
        public void loadCombobox()
        {

            comboBox1.Items.Add("All");
            for (int month = 1; month <= 12; month++)
            {
                comboBox1.Items.Add("Tháng " + month);
            }
            comboBox1.SelectedIndex = 0;
        }
        private void LoadDataToDataGridView(int month = 0)
        {
            if (!dataGridViewBangThongKe.Columns.Contains("STT"))
            {
                dataGridViewBangThongKe.Columns.Insert(0, new DataGridViewTextBoxColumn
                {
                    Name = "STT",
                    HeaderText = "STT",
                    Width = 50
                });
            }

            List<bangthongke> danhSachBangThongKe;

            if (month == 0)
            {

                danhSachBangThongKe = bangThongKeBLL.LayDanhSachBangThongKe();
            }
            else
            {

                danhSachBangThongKe = bangThongKeBLL.LayBangThongKeTheoThang(month);
            }

            dataGridViewBangThongKe.DataSource = danhSachBangThongKe;
            dataGridViewBangThongKe.Columns["STT"].HeaderText = "STT";
            dataGridViewBangThongKe.Columns["NgayXuatHD"].HeaderText = "Ngày thống kê";
            dataGridViewBangThongKe.Columns["DoanhThu"].HeaderText = "Tổng doanh thu";
            dataGridViewBangThongKe.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
        }

        private void LoadDataToDataGridViewTheoNgay(DateTime ngay)
        {
            List<bangthongke> danhSachBangThongKe = bangThongKeBLL.LayBangThongKeTheoNgay(ngay);

            if (!dataGridViewBangThongKe.Columns.Contains("STT"))
            {
                dataGridViewBangThongKe.Columns.Insert(0, new DataGridViewTextBoxColumn
                {
                    Name = "STT",
                    HeaderText = "STT",
                    Width = 50
                });
            }

            dataGridViewBangThongKe.DataSource = danhSachBangThongKe;
            dataGridViewBangThongKe.Columns["STT"].HeaderText = "STT";
            dataGridViewBangThongKe.Columns["NgayXuatHD"].HeaderText = "Ngày thống kê";
            dataGridViewBangThongKe.Columns["DoanhThu"].HeaderText = "Tổng doanh thu";
            dataGridViewBangThongKe.Columns["DoanhThu"].DefaultCellStyle.Format = "N0";
        }

        private void dataGridViewBangThongKe_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            dataGridViewBangThongKe.Rows[e.RowIndex].Cells["STT"].Value = (e.RowIndex + 1).ToString();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                LoadDataToDataGridView();
            }
            else
            {
                int selectedMonth = comboBox1.SelectedIndex;
                LoadDataToDataGridView(selectedMonth);
            }
        }

        private void btnDeleteThongKe_Click(object sender, EventArgs e)
        {
            if (dataGridViewBangThongKe.SelectedRows.Count > 0)
            {

                DateTime ngayXuatHD = Convert.ToDateTime(dataGridViewBangThongKe.SelectedRows[0].Cells["NgayXuatHD"].Value);
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa bản ghi này?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    bool result = bangThongKeBLL.XoaThongKe(ngayXuatHD);
                    if (result)
                    {
                        MessageBox.Show("Xóa thành công!");
                        LoadDataToDataGridView();
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa bản ghi này.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn bản ghi cần xóa.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (dataGridViewBangThongKe.SelectedRows.Count > 0)
            //{

            //    DateTime ngayXuatHD = Convert.ToDateTime(dataGridViewBangThongKe.SelectedRows[0].Cells["NgayXuatHD"].Value);
            //    int doanhThu = Convert.ToInt32(dataGridViewBangThongKe.SelectedRows[0].Cells["DoanhThu"].Value);


            //    using (frmEditThongKe formEdit = new frmEditThongKe(ngayXuatHD, doanhThu))
            //    {
            //        if (formEdit.ShowDialog() == DialogResult.OK)
            //        {

            //            LoadDataToDataGridView();
            //        }
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("Vui lòng chọn bản ghi cần sửa.");
            //}
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExcelExport exel = new ExcelExport();
            DbConnectDataContext ct = new DbConnectDataContext();

            string templatePath = Application.StartupPath + @"\DoanhThuThang.xlsx";

            int selectedMonth = comboBox1.SelectedIndex;
            exel.ExportPhieuNhap(selectedMonth, ref templatePath, false);
        }


        //Tab Ban choi nhieu
        private void LoadDataToDataGridViewBanChoiNhieu(DateTime? selectedDate = null)
        {
            List<BanChoiNhieuDTO> danhSachBan = banBLL.LayDanhSachBanVaSoGioChoi(selectedDate);
            dataGridViewThongKeSoGioChoi.DataSource = danhSachBan;

            dataGridViewThongKeSoGioChoi.Columns["IDBan"].HeaderText = "ID Bàn";
            dataGridViewThongKeSoGioChoi.Columns["TenBan"].HeaderText = "Tên Bàn";
            dataGridViewThongKeSoGioChoi.Columns["SoGioChoi"].HeaderText = "Số Giờ Chơi";
        }
        private void btnResetBanChoiNhieu_Click(object sender, EventArgs e)
        {
            dateTimeBanChoiNhieu.Value = DateTime.Now;
            LoadDataToDataGridViewBanChoiNhieu();
        }

        private void dateTimeBanChoiNhieu_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimeBanChoiNhieu.Value.Date;
            LoadDataToDataGridViewBanChoiNhieu(selectedDate);
        }


        //Tab Mon an ban nhieu
        private void LoadDataToDataGridViewThongKeMon(DateTime? selectedDate = null)
        {
            List<ThongKeMonDTO> danhSachThongKeMon = hangHoaBLL.LayThongKeMon(selectedDate);

            dataGridViewThongKeMon.DataSource = danhSachThongKeMon;

            dataGridViewThongKeMon.Columns["IDMon"].HeaderText = "ID Món";
            dataGridViewThongKeMon.Columns["TenMon"].HeaderText = "Tên Món";
            dataGridViewThongKeMon.Columns["SoLuongBanDuoc"].HeaderText = "Số Lượng Bán Được";
            dataGridViewThongKeMon.Columns["GiaTien"].HeaderText = "Giá Tiền";
            dataGridViewThongKeMon.Columns["GiaTien"].DefaultCellStyle.Format = "N0";

            dataGridViewThongKeMon.Columns["ThanhTien"].HeaderText = "Thành Tiền";
            dataGridViewThongKeMon.Columns["ThanhTien"].DefaultCellStyle.Format = "N0";
            dataGridViewThongKeMon.Columns["NgayXuatHD"].Visible = false;

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = dateTimePicker3.Value.Date;
            LoadDataToDataGridViewThongKeMon(selectedDate);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            LoadDataToDataGridViewThongKeMon();
        }

        private void btnExcelMonAn_Click(object sender, EventArgs e)
        {
            ExcelExportMonAn exel = new ExcelExportMonAn();
            string templatePath = Application.StartupPath + @"\BaoCaoMonAn.xlsx";
            DateTime selectedDate = dateTimePicker3.Value.Date;

            List<ThongKeMonDTO> danhSachThongKeMon = hangHoaBLL.LayThongKeMon(selectedDate);
            if (danhSachThongKeMon != null && danhSachThongKeMon.Any())
            {
                exel.ExportPhieuNhap(selectedDate, ref templatePath, false);
            }
            else
            {
                exel.ExportPhieuNhapNoDate(ref templatePath, false);
                //MessageBox.Show("Chưa có dữ liệu!", "Thông báo");
            }

        }

    }
}
