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
    public partial class frmNhanVien_NhomNguoiDung : Form
    {
        List<NHANVIEN> lstNhanVien = new List<NHANVIEN>();
        List<QL_NhomNguoiDung> lstNhomNguoiDung = new List<QL_NhomNguoiDung>();
        NhomNguoiDungBLL nhomNguoiDungBLL = new NhomNguoiDungBLL();
        public frmNhanVien_NhomNguoiDung()
        {
            InitializeComponent();
            btnThemNhomNguoiDung.Click += BtnThemNhomNguoiDung_Click;
            btnXoaNhomNguoiDung.Click += BtnXoaNhomNguoiDung_Click;
            this.Load += FrmNhanVien_NhomNguoiDung_Load;
        }

        private void FrmNhanVien_NhomNguoiDung_Load(object sender, EventArgs e)
        {
            //Load danh sách nhân viên lên grid view nhân viên
            NhanVienBLL nhanVienBLL = new NhanVienBLL();
            lstNhanVien = nhanVienBLL.LayDanhSachNhanVien();
            if (lstNhanVien.Count > 0 && lstNhanVien !=null)
            {
                dgv_NhanVien.DataSource = lstNhanVien;
                dgv_NhanVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                dgv_NhanVien.Columns["MaNV"].HeaderText = "Mã nhân viên";
                dgv_NhanVien.Columns["TenNV"].HeaderText = "Tên nhân viên";
                dgv_NhanVien.Columns[2].Visible = false;
                dgv_NhanVien.Columns[3].Visible = false;
                dgv_NhanVien.Columns[4].Visible = false;
                dgv_NhanVien.Columns[5].Visible = false;
                dgv_NhanVien.Columns["MatKhau"].Visible = false;
                dgv_NhanVien.Columns["HoatDong"].Visible = false;
                dgv_NhanVien.Columns["PhanQuyen"].Visible = true;
                dgv_NhanVien.Columns["PhanQuyen"].HeaderText = "Phân quyền";
                dgv_NhanVien.MultiSelect = false;
                dgv_NhanVien.SelectionChanged += Dgv_NhanVien_SelectionChanged;
                dgv_NhanVien.Rows[0].Selected = true;
                LoadNguoiDungChuaCoLenCombobox();
                LoadDanhSachNhomNguoiDungLenGridView();
            }
            else
            {
                dgv_NhanVien.DataSource = null;
            }
            
        }

        private void LoadNguoiDungChuaCoLenCombobox()
        {
            //Loadanh sách nhóm người dùng chưa có của txtMaNV lên combobox
            lstNhomNguoiDung = new NhomNguoiDungBLL().LayDanhSachNhomNguoiDungChuaCoTheoMaNV(txtMaNV.Text);
            if (lstNhomNguoiDung.Count > 0 && lstNhomNguoiDung != null)
            {
                cbbDanhSachNhomNguoiDung.DataSource = lstNhomNguoiDung;
                cbbDanhSachNhomNguoiDung.DisplayMember = "TenNhomNguoiDung";
                cbbDanhSachNhomNguoiDung.ValueMember = "MaNhomNguoiDung";
            }
            else
            {
                cbbDanhSachNhomNguoiDung.DataSource = null;
            }
        }

        private void LoadDanhSachNhomNguoiDungLenGridView()
        {
            try
            {
                lstNhomNguoiDung = nhomNguoiDungBLL.LayDanhSachNhomNguoiDungTheoMaNV(txtMaNV.Text);
                if (lstNhomNguoiDung.Count > 0 && lstNhomNguoiDung != null)
                {
                    dgv_NND_NV.DataSource = lstNhomNguoiDung;
                    dgv_NND_NV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                    dgv_NND_NV.Columns["MaNhomNguoiDung"].HeaderText = "Mã nhóm người dùng";
                    dgv_NND_NV.Columns["TenNhomNguoiDung"].HeaderText = "Tên nhóm người dùng";
                    dgv_NND_NV.Columns["GhiChu"].HeaderText = "Ghi chú";
                    dgv_NND_NV.MultiSelect = false;
                }
                else
                {
                    dgv_NND_NV.DataSource = null;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
            
        }

        private void Dgv_NhanVien_SelectionChanged(object sender, EventArgs e)
        {
            //Lấy dòng đang chọn trong datagridview nhân viên gắn lên các text box
            if (dgv_NhanVien.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv_NhanVien.SelectedRows[0];
                txtMaNV.Text = row.Cells["MaNV"].Value.ToString();
                txtTenNV.Text = row.Cells["TenNV"].Value.ToString();
                //Load danh sách nhóm người dùng lên grid view nhóm người dùng
                LoadNguoiDungChuaCoLenCombobox();

                LoadDanhSachNhomNguoiDungLenGridView();
            }
        }

        private void BtnThemNhomNguoiDung_Click(object sender, EventArgs e)
        {
            try
            {
                //Hiển thị dialog xác nhận trước khi thêm
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn thêm không ?", "Xác nhận thêm", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                //Thêm màn hình từ cbbDanhSachManHinh vào nhóm người dùng
                if (cbbDanhSachNhomNguoiDung.SelectedValue == null)
                {
                    MessageBox.Show("Không có gì để thêm !!!");
                    return;
                }
                string maNhomNguoiDung = cbbDanhSachNhomNguoiDung.SelectedValue.ToString();
                //Thêm nhóm người dùng vào nhân viên QL_NhanVien_NhomNguoiDung
                bool kq = nhomNguoiDungBLL.ThemNhomNguoiDungVaoNhanVien(txtMaNV.Text, maNhomNguoiDung);
                if (kq == true)
                {
                    MessageBox.Show("Thêm thành công !!!");
                    //Load lại datagridview 
                    LoadDanhSachNhomNguoiDungLenGridView();
                    LoadNguoiDungChuaCoLenCombobox();
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

        private void BtnXoaNhomNguoiDung_Click(object sender, EventArgs e)
        {
            try
            {
                //Hiển thị dialog xác nhận trước khi xóa
                DialogResult dialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa không ?", "Xác nhận xóa", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return;
                }
                //Xóa nhóm người dùng đang được chọn trong dataGridView
                if (dgv_NND_NV.SelectedRows.Count > 0)
                {
                    DataGridViewRow row = dgv_NND_NV.SelectedRows[0];
                    string maNhomNguoiDung = row.Cells["MaNhomNguoiDung"].Value.ToString();
                    bool kq = nhomNguoiDungBLL.XoaNhomNguoiDungTheoMaNhanVien(txtMaNV.Text, maNhomNguoiDung);
                    if (kq == true)
                    {
                        MessageBox.Show("Xóa thành công !!!");
                        //Load lại datagridview 
                        LoadDanhSachNhomNguoiDungLenGridView();
                        LoadNguoiDungChuaCoLenCombobox();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại !!!");
                    }
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }
    }
}
