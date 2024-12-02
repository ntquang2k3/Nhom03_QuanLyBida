using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DevExpress.Office.Utils;
using DAL;
using UC;
using static DevExpress.Utils.Svg.CommonSvgImages;
namespace GUI
{
    public partial class frmChoiBida : Form
    {
        private string manv;
        DB_BLL bll = new DB_BLL();
        public frmChoiBida()
        {
            InitializeComponent();
            AddEvents();
        }
        public frmChoiBida(string manvtruyen)
        {
            InitializeComponent();
            AddEvents();
            this.manv = manvtruyen;
        }

        private void AddEvents()
        {
            this.Load += FrmChoiBida_Load;
            this.cbbLoaiBan.SelectedIndexChanged += CbbLoaiBan_SelectedIndexChanged;
            btnLoadDSBan.Click += BtnLoadDSBan_Click;
            this.cbbLoaiHang.SelectedIndexChanged += CbbLoaiHang_SelectedIndexChanged;
            //Thêm sự kiện cho các nút
            btnMoBan.Click += BtnMoBan_Click;
            btnDongBan.Click += BtnDongBan_Click;
            btnChuyenBan.Click += BtnChuyenBan_Click;
            btnTinhTien.Click += BtnTinhTien_Click;
            //Nút ở hóa đơn
            btnThem.Click += BtnThem_Click;
            btnXoaMon.Click += BtnXoaMon_Click;
            btnSua.Click += BtnSua_Click;
            dataGridViewGoiMon.SelectionChanged += DataGridViewGoiMon_SelectionChanged;
        }

        private void DataGridViewGoiMon_SelectionChanged(object sender, EventArgs e)
        {
            string soluong = dataGridViewGoiMon.SelectedRows[0].Cells["SoLuong"].Value.ToString();
            numUpDownSL.Value = decimal.Parse(soluong);
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            string maHH = dataGridViewGoiMon.SelectedRows[0].Cells["MaHH"].Value.ToString();
            CHITIETHOADON cthd = new CHITIETHOADON();
            cthd = bll.LayChiTietHoaDonVoiMaHH(tableItemSelected.MaHoaDon, maHH);
            if (cthd != null) //Đã có trong hóa đơn
            {
                cthd.SoLuong = (int)numUpDownSL.Value;
                //Cập nhật hóa dơn
                bool kq = bll.CapNhatSoLuongCTHD(tableItemSelected.MaHoaDon, maHH, cthd);
                if (kq == true)
                {
                    MessageBox.Show("Sửa số lượng thành công !!!");
                    LoadDataGridViewHoaDon(tableItemSelected.MaHoaDon);
                }
                else
                {
                    MessageBox.Show("Sửa số lượng không thành công !!!");
                }

            }
        }

        private void BtnXoaMon_Click(object sender, EventArgs e)
        {
            string maHH = dataGridViewGoiMon.SelectedRows[0].Cells["MaHH"].Value.ToString();
            int hdbh = int.Parse(dataGridViewGoiMon.SelectedRows[0].Cells["MaHDBH"].Value.ToString());
            bool kq = bll.XoaChiTietHoaDon(hdbh, maHH);
            if (kq == true)
            {
                MessageBox.Show("Đã xóa thành công !!!");
                //Load lại chi tiết hóa đơn
                LoadDataGridViewHoaDon(tableItemSelected.MaHoaDon);
            }
            else
            {
                MessageBox.Show("Xóa không thành công !!!");
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            string maHH = dataGridViewThucDon.SelectedRows[0].Cells["MaHH"].Value.ToString();
            int giaSP = int.Parse(dataGridViewThucDon.SelectedRows[0].Cells["GiaSP"].Value.ToString());
            CHITIETHOADON cthd = new CHITIETHOADON();
            cthd = bll.LayChiTietHoaDonVoiMaHH(tableItemSelected.MaHoaDon, maHH);
            if (cthd != null) //Đã có trong hóa đơn
            {
                cthd.SoLuong++;
                cthd.ThanhTien = cthd.SoLuong * giaSP;
                //Cập nhật hóa dơn
                bll.CapNhatSoLuongCTHD(tableItemSelected.MaHoaDon, maHH, cthd);
            }
            else
            {
                cthd = new CHITIETHOADON();
                cthd.MaHDBH = tableItemSelected.MaHoaDon;
                cthd.MaHH = maHH;
                cthd.SoLuong = 1;
                cthd.ThanhTien = giaSP * cthd.SoLuong;
                //Sau đó thêm cthd vào hóa đơn
                bll.ThemChiTietHoaDon(tableItemSelected.MaHoaDon, cthd);
                btnXoaMon.Enabled = true;
                btnXoaMon.BackColor = Color.Navy;
            }
            //Load lại chi tiết hóa đơn
            LoadDataGridViewHoaDon(tableItemSelected.MaHoaDon);

        }

        private void BtnTinhTien_Click(object sender, EventArgs e)
        {
            frmTinhTien frm = new frmTinhTien();
            frm.maHDBH = tableItemSelected.MaHoaDon;
            // Đăng ký sự kiện BtnInClicked từ frmTinhTien
            frm.BtnInClicked += Frm_BtnInClicked;
            frm.Show();
        }

        private void Frm_BtnInClicked(object sender, EventArgs e)
        {
            LoadComboboxLoaiBan();
            LoadComboboxKhuVuc();
            LoadComboboxTrangThaiBan();
            LoadButton();
            LoadComboboxLoaiHH();
            LoadDataGridViewMenu("All");
            //Load danh sách bàn
            LoadDanhSachBanChoi(int.Parse(cbbLoaiBan.SelectedValue.ToString()), "All", "All");
            dataGridViewGoiMon.SelectionChanged -= DataGridViewGoiMon_SelectionChanged;
            dataGridViewGoiMon.DataSource = null;

        }

        private void BtnDongBan_Click(object sender, EventArgs e)
        {
            // Hiển thị hộp thoại xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đóng bàn ?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                if (tableItemSelected != null)
                {
                    //Xóa hóa đơn và đổ lên grid view
                    if (tableItemSelected.TrangThai == "Đang chơi")
                    {
                        bool kq = bll.XoaMotHoaDon(tableItemSelected.MaHoaDon);
                        if (kq == true)
                        {
                            BAN b = bll.LayMotBan(tableItemSelected.MaBan);
                            bll.CapNhatTrangThaiBan(b, "Trống");
                            MessageBox.Show("Đóng bàn thành công !!!");
                        }
                        else
                        {
                            MessageBox.Show("Đóng bàn không thành công !!!");
                        }
                        //Sau khi đóng bàn cập nhật lại form
                        labelMaHoaDon.Text = String.Empty;
                        labelManhanvien.Text = String.Empty;
                        labelNgayHoaDon.Text = String.Empty;
                        LoadButton();
                        LoadDanhSachBanChoi(int.Parse(cbbLoaiBan.SelectedValue.ToString()), cbbKhuVuc.SelectedValue.ToString(), cbbTrangThaiBan.SelectedValue.ToString());
                    }
                }
            }

        }

        private void BtnChuyenBan_Click(object sender, EventArgs e)
        {
            frmChuyenBan frm = new frmChuyenBan();
            frm.MaLoaiBan = int.Parse(cbbLoaiBan.SelectedValue.ToString());
            frm.MaKhuVuc = tableItemSelected.MaLoaiBan;
            frm.ShowDialog(); // Hiển thị Form nhập mã bàn

            string maBanCanChuyen = frm.MaChuyenDen; // Lấy mã bàn từ Form nhập mã bàn

            if (!string.IsNullOrEmpty(maBanCanChuyen))
            {
                BAN b1 = bll.LayMotBan(tableItemSelected.MaBan);
                bll.CapNhatTrangThaiBan(b1, "Trống");
                //Sau đó cập nhật bàn cần chuyển
                BAN b2 = bll.LayMotBan(maBanCanChuyen);
                bll.CapNhatTrangThaiBan(b2, "Đang chơi");
                //Cập nhật hóa đơn của bàn 1 cho bàn chuyển đến
                HOADON hd = bll.LayMotHoaDon(tableItemSelected.MaHoaDon);
                bll.CapNhatBanCuaHoaDon(hd, maBanCanChuyen);
                //Sau khi chạy xong thì load lại danh sách bàn
                labelMaHoaDon.Text = String.Empty;
                labelManhanvien.Text = String.Empty;
                labelNgayHoaDon.Text = String.Empty;
                dataGridViewGoiMon.SelectionChanged -= DataGridViewGoiMon_SelectionChanged;
                dataGridViewGoiMon.DataSource = null;
                LoadButton();
                LoadDanhSachBanChoi(int.Parse(cbbLoaiBan.SelectedValue.ToString()), cbbKhuVuc.SelectedValue.ToString(), cbbTrangThaiBan.SelectedValue.ToString());
            }
        }

        private void BtnMoBan_Click(object sender, EventArgs e)
        {
            if (tableItemSelected != null)
            {
                //DBConnect db = new DBConnect();
                //Tạo mới hóa đơn và đổ lên grid view
                if (tableItemSelected.TrangThai == "Trống")
                {
                    int maHD = bll.TaoMaHoaDon();
                    DateTime thoiGianVao = DateTime.Now;
                    string MABAN = tableItemSelected.MaBan.ToString();
                    //Lấy mã nhân viên từ formMain
                    string MANV = this.manv;
                    //Tạo mới hóa đơn
                    HOADON hd = new HOADON();
                    hd.MaHDBH = bll.TaoMaHoaDon();
                    hd.MaBan = MABAN;
                    hd.ThoiGianVao = thoiGianVao;
                    hd.MaNV = MANV;
                    bool kq = bll.ThemMotHoaDon(hd);
                    if (kq == true)
                    {
                        MessageBox.Show("Mở bàn thành công !!!");
                        tableItemSelected.MaHoaDon = maHD;
                    }
                    else
                    {
                        MessageBox.Show("Lỗi Mở bàn không thành công !!!");
                    }
                    //string ctv2 = "Insert into HoaDon values(" + labelMaHoaDon.Text + ",'" + MANV + "','" + MABAN + "','" + ngayXHD + "',0,0,0,'KH001',0)";
                    //db.getNonQuery(ctv2);
                    //LoadDataGridViewHoaDon(ta);
                    //Cạp nhật trạng thái bàn vào Database
                    BAN b = bll.LayMotBan(MABAN);
                    bll.CapNhatTrangThaiBan(b, "Đang chơi");
                    //Sau khi chạy xong thì load lại danh sách bàn
                    LoadButton();
                    LoadDanhSachBanChoi(int.Parse(cbbLoaiBan.SelectedValue.ToString()), cbbKhuVuc.SelectedValue.ToString(), cbbTrangThaiBan.SelectedValue.ToString());
                }

            }
        }

        private void LoadDataGridViewHoaDon(int maHoaDon)
        {
            dataGridViewGoiMon.AllowUserToAddRows = false;
            dataGridViewGoiMon.ReadOnly = true;
            dataGridViewGoiMon.MultiSelect = false;
            dataGridViewGoiMon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewGoiMon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewGoiMon.SelectionChanged -= DataGridViewGoiMon_SelectionChanged;
            dataGridViewGoiMon.DataSource = null;
            DataTable dt = bll.LayChiTietHoaDon(maHoaDon);
            if (dt.Rows.Count > 0)
            {
                btnDongBan.Enabled = false;
                btnDongBan.BackColor = Color.Gray;
                btnSua.Enabled = true;
                btnSua.BackColor = Color.Navy;
            }
            else
            {
                dataGridViewGoiMon.DataSource = null;
                btnDongBan.BackColor = Color.Navy;
                btnDongBan.Enabled = true;
                btnXoaMon.Enabled = false;
                btnXoaMon.BackColor = Color.Gray;
                btnSua.Enabled = false;
                btnSua.BackColor = Color.Gray;
                numUpDownSL.Value = 1;
            }
            dataGridViewGoiMon.SelectionChanged += DataGridViewGoiMon_SelectionChanged;
            dataGridViewGoiMon.DataSource = dt;
        }

        private void CbbLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDataGridViewMenu(cbbLoaiHang.SelectedValue.ToString());
        }

        private void CbbLoaiBan_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadComboboxKhuVuc();
        }

        private void FrmChoiBida_Load(object sender, EventArgs e)
        {
            LoadComboboxLoaiBan();
            LoadComboboxKhuVuc();
            LoadComboboxTrangThaiBan();
            LoadButton();
            LoadComboboxLoaiHH();
            LoadDataGridViewMenu("All");
            //Load danh sách bàn
            LoadDanhSachBanChoi(int.Parse(cbbLoaiBan.SelectedValue.ToString()), "All", "All");
        }

        private void LoadDataGridViewMenu(string maLH)
        {
            //string selectedMaLH = cbbLoaiHang.SelectedValue.ToString();
            DataTable dt = bll.LayDanhSachHangHoa(maLH);
            dataGridViewThucDon.AllowUserToAddRows = false;
            dataGridViewThucDon.MultiSelect = false;
            dataGridViewThucDon.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewThucDon.DataSource = dt;
            dataGridViewThucDon.Columns["MaHH"].Visible = false;
            dataGridViewThucDon.Columns["MaLH"].Visible = false;
            dataGridViewThucDon.Columns["TenHH"].HeaderText = "Tên món ăn";
            dataGridViewThucDon.Columns["HinhAnh"].HeaderText = "Hình ảnh";
            dataGridViewThucDon.Columns["GiaSP"].HeaderText = "Giá món ăn";
            //dataGridViewThucDon.Columns["hinh_anh"].HeaderText = "Hình ảnh";
        }

        private void LoadComboboxLoaiHH()
        {
            //Thuc thi
            DataTable dt = bll.LayDanhSachLoaiHangHoa();


            DataRow dr = dt.NewRow();
            dr["MaLH"] = "All";
            dr["TenLH"] = "Tất cả các loại";
            dt.Rows.InsertAt(dr, 0);
            cbbLoaiHang.DataSource = dt;
            cbbLoaiHang.DisplayMember = "TenLH";
            cbbLoaiHang.ValueMember = "MaLH";

            //cbbLoaiHang.SelectedIndex = -1;
            cbbLoaiHang.SelectedIndex = 0;
        }

        private void LoadButton()
        {
            btnMoBan.Enabled = false;
            btnChuyenBan.Enabled = false;
            btnDongBan.Enabled = false;
            btnTinhTien.Enabled = false;
            //HoaDon
            btnThem.Enabled = false;
            btnXoaMon.Enabled = false;
            btnSua.Enabled = false;
            //Chỉnh màu
            btnMoBan.BackColor = Color.Gray;
            btnChuyenBan.BackColor = Color.Gray;
            btnDongBan.BackColor = Color.Gray;
            btnTinhTien.BackColor = Color.Gray;
            //
            btnXoaMon.BackColor = Color.Gray;
            btnThem.BackColor = Color.Gray;
            btnSua.BackColor = Color.Gray;
        }

        void LoadComboboxLoaiBan()
        {
            // Tạm thời ngừng sự kiện SelectedIndexChanged
            cbbLoaiBan.SelectedIndexChanged -= CbbLoaiBan_SelectedIndexChanged;
            DataTable dt = new DataTable();
            dt = bll.LayDanhSachLoaiBan();
            if (dt == null)
            {
                MessageBox.Show("Danh sách loại Bàn trống hoặc lỗi Load dữ liệu");
                return;
            }
            cbbLoaiBan.DataSource = dt;
            // Thiết lập thuộc tính DisplayMember và ValueMember của ComboBox
            cbbLoaiBan.DisplayMember = "tenloaiban";  // Hiển thị tên loại bàn
            cbbLoaiBan.ValueMember = "maban";
            cbbLoaiBan.SelectedIndex = 0;
            // Tạm thời ngừng sự kiện SelectedIndexChanged
            cbbLoaiBan.SelectedIndexChanged += CbbLoaiBan_SelectedIndexChanged;
        }
        void LoadComboboxKhuVuc()
        {
            int selectedValue;
            if (cbbLoaiBan.SelectedValue == null)
            {
                return;
            }
            else
            {
                selectedValue = (int)cbbLoaiBan.SelectedValue;
            }
            DataTable dt = new DataTable();
            if (selectedValue == 99)
            {
                dt = bll.LayTatCaDanhSachKhuVuc();
            }
            else
            {
                dt = bll.LayDanhSachKhuVuc(selectedValue);
            }
            if (dt == null)
            {
                MessageBox.Show("Danh sách khu vực trống hoặc lỗi Load dữ liệu");
                return;
            }
            DataRow dataRow = dt.NewRow();
            dataRow["MaKV"] = "All";
            dataRow["TenKV"] = "Tất cả";
            dt.Rows.InsertAt(dataRow, 0);
            cbbKhuVuc.DataSource = dt;
            cbbKhuVuc.ValueMember = "MaKV";
            cbbKhuVuc.DisplayMember = "TenKV";
            cbbKhuVuc.SelectedIndex = 0;
        }
        void LoadComboboxTrangThaiBan()
        {
            DataTable dt = bll.LayDanhSachTrangThaiBan();
            cbbTrangThaiBan.DataSource = dt;
            cbbTrangThaiBan.ValueMember = "MaTrangThai";
            cbbTrangThaiBan.DisplayMember = "TenTrangThai";
            cbbTrangThaiBan.SelectedIndex = 0;
        }

        private void LoadDanhSachBanChoi(int maLoaiBan, string maKhuVuc, string trangThai)
        {
            panelDsBanChoi.Controls.Clear();
            panelDsBanChoi.AutoScroll = true;
            DataTable dt = bll.LayDanhSachBan(maLoaiBan, maKhuVuc, trangThai);
            int topPosition = 20;
            int leftPosition = 20;
            //int distanceTop = 10;
            //int distanceLeft = 10;
            int soHang = 0;
            int soLuongMotHang = 3;
            int soLuongBan = dt.Rows.Count;
            soHang = soLuongBan / soLuongMotHang + 1;
            for (int i = 1; i <= soHang; i++)
            {
                for (int j = 1; j <= soLuongMotHang; j++)
                {
                    int viTriPhanTu = (i - 1) * soLuongMotHang + j;
                    if (viTriPhanTu > soLuongBan)
                    {
                        return;
                    }
                    trangThai = dt.Rows[viTriPhanTu - 1]["TrangThai"].ToString();
                    TableItem item = new TableItem(trangThai);
                    item.Name = dt.Rows[viTriPhanTu - 1]["MaBan"].ToString();
                    item.MaBan = dt.Rows[viTriPhanTu - 1]["MaBan"].ToString();
                    HOADON hdmoinhat = bll.LayHoaDonMoiNhat(item.MaBan);
                    if (hdmoinhat != null)
                    {
                        item.MaHoaDon = hdmoinhat.MaHDBH;
                    }
                    item.TenBan = dt.Rows[viTriPhanTu - 1]["TenBan"].ToString();
                    item.MaLoaiBan = dt.Rows[viTriPhanTu - 1]["MaLoaiBan"].ToString();
                    item.LoaiBan = dt.Rows[viTriPhanTu - 1]["TenLoaiBan"].ToString();
                    item.Top = (i - 1) * topPosition + (i - 1) * item.Height;
                    item.Left = (j - 1) * item.Width + (j - 1) * leftPosition;
                    item.Click += Item_Click;
                    panelDsBanChoi.Controls.Add(item);
                }
            }
        }
        TableItem tableItemSelected = null;
        private void Item_Click(object sender, EventArgs e)
        {
            var clickItem = sender as TableItem;
            if (clickItem != null)
            {
                if (tableItemSelected != null && tableItemSelected != clickItem)
                {
                    tableItemSelected.IsSelected = false;
                }
                if (tableItemSelected != null)
                {
                    tableItemSelected.IsSelected = false;
                }
                tableItemSelected = clickItem;
                tableItemSelected.IsSelected = true;
            }
            //Thực hiện xử lí sự kiện cho từng bàn
            if (clickItem.IsSelected)
            {
                if (clickItem.TrangThai == "Đang chơi")
                {
                    btnMoBan.Enabled = false;
                    btnMoBan.BackColor = Color.DarkGray;
                    btnChuyenBan.Enabled = true;
                    btnChuyenBan.BackColor = Color.Navy;
                    btnDongBan.Enabled = true;
                    btnDongBan.BackColor = Color.Navy;
                    btnTinhTien.Enabled = true;
                    btnTinhTien.BackColor = Color.Navy;
                    //Mở nút Thêm, Lưu, Xóa
                    btnThem.Enabled = true;
                    btnXoaMon.Enabled = true;
                    btnThem.BackColor = Color.Navy;
                    btnXoaMon.BackColor = Color.Navy;
                    LoadThongTinHoaDon(clickItem.MaHoaDon);

                }
                else //if (clickItem.TrangThai == "Trống")
                {
                    btnMoBan.Enabled = true;
                    btnMoBan.BackColor = Color.Navy;
                    btnChuyenBan.Enabled = false;
                    btnChuyenBan.BackColor = Color.Gray;
                    btnDongBan.Enabled = false;
                    btnDongBan.BackColor = Color.Gray;
                    btnTinhTien.Enabled = false;
                    btnTinhTien.BackColor = Color.Gray;
                    //Tắt nút Thêm lưu xóa sửa
                    btnThem.Enabled = false;
                    btnXoaMon.Enabled = false;
                    btnSua.Enabled = false;
                    btnSua.BackColor = Color.Gray;
                    btnThem.BackColor = Color.Gray;
                    btnXoaMon.BackColor = Color.Gray;
                    dataGridViewGoiMon.SelectionChanged -= DataGridViewGoiMon_SelectionChanged;
                    dataGridViewGoiMon.DataSource = null;
                    LoadThongTinHoaDon(clickItem.MaHoaDon);
                }
            }


        }

        private void LoadThongTinHoaDon(int maHoaDon)
        {
            HOADON hd = bll.LayMotHoaDon(maHoaDon);
            //Load thông tin label
            if (hd != null)
            {
                labelMaHoaDon.Text = hd.MaHDBH.ToString();
                labelManhanvien.Text = hd.MaNV;
                labelNgayHoaDon.Text = hd.ThoiGianVao.ToString();
                //Load thông tin trên gridview
                LoadDataGridViewHoaDon(maHoaDon);
            }
            else
            {
                labelMaHoaDon.Text = String.Empty;
                labelManhanvien.Text = String.Empty;
                labelNgayHoaDon.Text = String.Empty;
                //LoadDataGridViewHoaDon(maHoaDon);
            }
        }

        private void BtnLoadDSBan_Click(object sender, EventArgs e)
        {
            LoadDanhSachBanChoi(int.Parse(cbbLoaiBan.SelectedValue.ToString()), cbbKhuVuc.SelectedValue.ToString(), cbbTrangThaiBan.SelectedValue.ToString());
        }
    }
}
