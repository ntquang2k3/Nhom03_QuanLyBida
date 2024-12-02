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
using DAL;
namespace GUI
{
    public partial class frmNhomNguoiDung_ManHinh : Form
    {
        DanhMucManHinhBLL_Quang dmmhBLL = new DanhMucManHinhBLL_Quang();
        NhomNguoiDungBLL_Quang nhomNguoiDungBLL = new NhomNguoiDungBLL_Quang();
        List<DanhMucManHinh> lstDMMH = new List<DanhMucManHinh>();
        List<QL_NhomNguoiDung> lstNhomNguoiDung = new List<QL_NhomNguoiDung>();
        public frmNhomNguoiDung_ManHinh()
        {
            InitializeComponent();
            this.Load += FrmNhomNguoiDung_ManHinh_Load;
            btnThemNND.Click += BtnThemNND_Click;
            btnXoaNND.Click += BtnXoaNND_Click;
            btnSuaNND.Click += BtnSuaNND_Click;
            btnLamMoi.Click += BtnLamMoi_Click;
            btnThemManHinh.Click += BtnThemManHinh_Click;
            btnXoaManHinh.Click += BtnXoaManHinh_Click;
        }

        private void BtnXoaManHinh_Click(object sender, EventArgs e)
        {
            //Xóa QL_PhanQuyen được chọn trong dgv_DanhSachManHinh
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa màn hình này không ?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Xóa màn hình khỏi nhóm người dùng
                string maManHinh = dgvManHinhNhomNguoiDung.CurrentRow.Cells["MaManHinh"].Value.ToString();
                bool kq = dmmhBLL.XoaManHinhKhoiNhomNguoiDung(txtMaNhomNguoiDung.Text, maManHinh);
                if (kq == true)
                {
                    MessageBox.Show("Xóa thành công !!!");
                    //Load lại datagridview 
                    LoadDataGridViewManHinh();
                    LoadComboboxDanhSachManHinhChuaCo();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !!!");
                }
            }
        }

        private void BtnThemManHinh_Click(object sender, EventArgs e)
        {
            try
            {
                //Thêm màn hình từ cbbDanhSachManHinh vào nhóm người dùng
                if (cbbDanhSachManHinh.SelectedValue == null)
                {
                    MessageBox.Show("Không có gì để thêm !!!");
                    return;
                }
                string maManHinh = cbbDanhSachManHinh.SelectedValue.ToString();
                bool kq = dmmhBLL.ThemManHinhVaoNhomNguoiDung(txtMaNhomNguoiDung.Text, maManHinh);
                if (kq == true)
                {
                    MessageBox.Show("Thêm thành công !!!");
                    //Load lại datagridview 
                    LoadDataGridViewManHinh();
                    LoadComboboxDanhSachManHinhChuaCo();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại !!!");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
           
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
            //Xóa hết text box 
            txtMaNhomNguoiDung.Text = "";
            txtTenNhomNguoiDung.Text = "";
            txtGhiChu.Text = "";
        }

        private void BtnSuaNND_Click(object sender, EventArgs e)
        {
            //Sửa QL_NhomNguoiDung có hiện dialog xác nhận
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn sửa nhóm người dùng này không ?", "Xác nhận sửa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Sửa nhóm người dùng
                QL_NhomNguoiDung nhomNguoiDung = new QL_NhomNguoiDung();
                nhomNguoiDung.MaNhomNguoiDung = txtMaNhomNguoiDung.Text;
                nhomNguoiDung.TenNhomNguoiDung = txtTenNhomNguoiDung.Text;
                nhomNguoiDung.GhiChu = txtGhiChu.Text;
                bool kq = nhomNguoiDungBLL.SuaNhomNguoiDung(nhomNguoiDung);
                if (kq == true)
                {
                    MessageBox.Show("Sửa thành công !!!");
                    LoadDataGridViewNhomNguoiDung();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại !!!");
                }
            }

        }

        private void BtnXoaNND_Click(object sender, EventArgs e)
        {
            //Xóa QL_NhomNguoiDung có hiện dialog xác nhận
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa nhóm người dùng này không ?", "Xác nhận xóa", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //Xóa nhóm người dùng
                string maNhomNguoiDung = txtMaNhomNguoiDung.Text;
                bool kq = nhomNguoiDungBLL.XoaNhomNguoiDung(maNhomNguoiDung);
                if (kq == true)
                {
                    MessageBox.Show("Xóa thành công !!!");
                    LoadDataGridViewNhomNguoiDung();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại !!!");
                }
            }
        }

        private void BtnThemNND_Click(object sender, EventArgs e)
        {
            //Nếu tất cả text box có giá trị thì tiếp tục
            if (txtMaNhomNguoiDung.Text == "" || txtTenNhomNguoiDung.Text == "" || txtGhiChu.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin !!!");
                return;
            }
            //Thêm QL_NhomNguoiDung hỏi dialog xác nhận
            DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm nhóm người dùng này không ?", "Xác nhận thêm", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.No)
            {
                return;
            }
            dgv_NhomNguoiDung.SelectionChanged -= Dgv_NhomNguoiDung_SelectionChanged;
            //Thêm QL_NhomNguoiDung
            QL_NhomNguoiDung nhomNguoiDung = new QL_NhomNguoiDung();
            nhomNguoiDung.MaNhomNguoiDung = txtMaNhomNguoiDung.Text;
            nhomNguoiDung.TenNhomNguoiDung = txtTenNhomNguoiDung.Text;
            nhomNguoiDung.GhiChu = txtGhiChu.Text;
            bool kq = nhomNguoiDungBLL.ThemNhomNguoiDung(nhomNguoiDung);
            if (kq == true)
            {
                MessageBox.Show("Thêm thành công !!!");
                LoadDataGridViewNhomNguoiDung();
            }
            else
            {
                MessageBox.Show("Thêm thất bại !!!");
            }
            
        }

        private void FrmNhomNguoiDung_ManHinh_Load(object sender, EventArgs e)
        {
            //Load datagridview nhóm người dùng
            LoadDataGridViewNhomNguoiDung();
            LoadComboboxDanhSachManHinh();
        }

        private void LoadComboboxDanhSachManHinh()
        {
            //Load combobox danh sách màn hình
            lstDMMH = dmmhBLL.LayDanhSachManHinh();
            if (lstDMMH.Count > 0 && lstDMMH != null)
            {
                cbbDanhSachManHinh.DataSource = lstDMMH;
                cbbDanhSachManHinh.DisplayMember = "TenManHinh";
                cbbDanhSachManHinh.ValueMember = "MaManHinh";
                cbbDanhSachManHinh.SelectedIndex = 0;
            }
            else
            {
                cbbDanhSachManHinh.DataSource = null;
            }
        }

        private void LoadDataGridViewNhomNguoiDung()
        {
            //Load data grid view nhóm người dùng
            lstNhomNguoiDung = nhomNguoiDungBLL.LayDanhSachNhomNguoiDung();
            if (lstNhomNguoiDung.Count > 0 && lstNhomNguoiDung != null)
            {
                dgv_NhomNguoiDung.DataSource = lstNhomNguoiDung;
                dgv_NhomNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_NhomNguoiDung.Columns["MaNhomNguoiDung"].HeaderText = "Mã nhóm người dùng";
                dgv_NhomNguoiDung.Columns["TenNhomNguoiDung"].HeaderText = "Tên nhóm người dùng";
                dgv_NhomNguoiDung.Columns["GhiChu"].HeaderText = "Ghi chú";
                dgv_NhomNguoiDung.SelectionChanged += Dgv_NhomNguoiDung_SelectionChanged;
                dgv_NhomNguoiDung.Rows[0].Selected = true;
                dgv_NhomNguoiDung.MultiSelect = false;
                
            }
            else
            {
                dgv_NhomNguoiDung.DataSource = null;
            }

        }

        private void Dgv_NhomNguoiDung_SelectionChanged(object sender, EventArgs e)
        {
            //Gắn dữ liệu lên các textbox
            //Lấy dòng đang chọn trên datagridview
            txtMaNhomNguoiDung.Text = dgv_NhomNguoiDung.CurrentRow.Cells["MaNhomNguoiDung"].Value.ToString();
            txtTenNhomNguoiDung.Text = dgv_NhomNguoiDung.CurrentRow.Cells["TenNhomNguoiDung"].Value.ToString();
            txtGhiChu.Text = dgv_NhomNguoiDung.CurrentRow.Cells["GhiChu"].Value.ToString();
            //Load danh sách màn hình lên dgvManHinhNhomNguoiDung
            LoadDataGridViewManHinh();
        }

        private void LoadDataGridViewManHinh()
        {
            //Load danh sách màn hình lên datagridview
            lstDMMH = dmmhBLL.LayDanhSachManHinhTheoNhomNguoiDung(txtMaNhomNguoiDung.Text);
            if (lstDMMH.Count > 0 && lstDMMH != null)
            {
                dgvManHinhNhomNguoiDung.DataSource = lstDMMH;
                dgvManHinhNhomNguoiDung.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgvManHinhNhomNguoiDung.Columns["MaManHinh"].HeaderText = "Mã màn hình";
                dgvManHinhNhomNguoiDung.Columns["TenManHinh"].HeaderText = "Tên màn hình";
            }
            else
            {
                dgvManHinhNhomNguoiDung.DataSource = null;
            }
            //Load những màn hình mà nhóm người dùng chưa có lên combobox
            LoadComboboxDanhSachManHinhChuaCo();
        }

        private void LoadComboboxDanhSachManHinhChuaCo()
        {
            List<DanhMucManHinh> lstDMMHChuaCo = dmmhBLL.LayDanhSachManHinhChuaCo(txtMaNhomNguoiDung.Text);
            if (lstDMMHChuaCo.Count > 0 && lstDMMHChuaCo != null)
            {
                cbbDanhSachManHinh.DataSource = lstDMMHChuaCo;
                cbbDanhSachManHinh.DisplayMember = "TenManHinh";
                cbbDanhSachManHinh.ValueMember = "MaManHinh";
            }
            else
            {
                cbbDanhSachManHinh.DataSource = null;
            }
        }
    }
}
