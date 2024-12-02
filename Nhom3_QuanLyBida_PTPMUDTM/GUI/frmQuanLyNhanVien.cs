﻿using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace GUI
{
    public partial class frmQuanLyNhanVien : Form
    {
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        public frmQuanLyNhanVien()
        {
            InitializeComponent();
            this.Load += FrmQuanLyNhanVien_Load;
            dgvNhanVien.SelectionChanged += DgvNhanVien_SelectionChanged;
            this.btnLamMoi.Click += BtnLamMoi_Click;
            this.btnThem.Click += BtnThem_Click;
            this.btnXoa.Click += BtnXoa_Click;
            this.btnSua.Click += BtnSua_Click;
            this.btnLuu.Click += BtnLuu_Click;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text;
                string tenNV = txtTenNV.Text;
                string gioiTinh = cbbGioiTinh.SelectedValue.ToString();
                string diaChi = txtDiaChi.Text;
                string soDienThoai = txtSDT.Text;
                string phanQuyen = txtPhanQuyen.Text;
                string matKhau = txtMatKhau.Text;



                if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(gioiTinh) ||
                    string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(phanQuyen) ||
                    string.IsNullOrEmpty(matKhau))

                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hàng hóa.");
                    return;
                }
                int hoatDong = int.Parse(cbbHoatDong.SelectedValue.ToString());


                NHANVIEN newNhanVien = new NHANVIEN

                {
                    MaNV = maNV,
                    TenNV = tenNV,
                    GioiTinh = gioiTinh,
                    DiaChi = diaChi,
                    SoDienThoai = soDienThoai,
                    PhanQuyen = phanQuyen,
                    MatKhau = matKhau,
                    HoatDong = hoatDong

                };
                bool isSuccess = nhanVienBLL.UpdateNhanVien(newNhanVien);
                if (isSuccess)
                {
                    MessageBox.Show("Cập nhật nhân viên thành công!");
                    loadDSNhanVien();
                    txtMaNV.Enabled = true; 
                    btnLuu.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Có lỗi khi cập nhật nhân viên.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnSua_Click(object sender, EventArgs e)
        {
            txtMaNV.Enabled = false;
            btnLuu.Enabled = true;

        }

        private void BtnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text;
                DialogResult dialogResult = MessageBox.Show(
                    $"Bạn có chắc chắn muốn xóa nhân viên với mã '{maNV}' không?",
                    "Xác nhận xóa",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question
                );

                if (dialogResult == DialogResult.Yes)
                {

                    bool isSuccess = nhanVienBLL.DeleteNhanVien(maNV);
                    if (isSuccess)
                    {
                        MessageBox.Show("Xóa nhân viên thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDSNhanVien();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi xóa nhân viên này: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string maNV = txtMaNV.Text;
                string tenNV = txtTenNV.Text;
                string gioiTinh = cbbGioiTinh.SelectedValue.ToString();
                string diaChi = txtDiaChi.Text;
                string soDienThoai = txtSDT.Text;
                string phanQuyen = txtPhanQuyen.Text;
                string matKhau = txtMatKhau.Text;
               


                if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(tenNV) || string.IsNullOrEmpty(gioiTinh) ||
                    string.IsNullOrEmpty(diaChi) || string.IsNullOrEmpty(soDienThoai) || string.IsNullOrEmpty(phanQuyen)||
                    string.IsNullOrEmpty(matKhau))

                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hàng hóa.");
                    return;
                }
                //if (txtHoatDong.Text == "Không hoạt động") // Phân biệt hoa/thường
                //{
                //    txtHoatDong.Text = "0";
                //}
                //else
                //{
                //    txtHoatDong.Text = "1";
                //}

                int hoatDong = int.Parse(cbbHoatDong.SelectedValue.ToString());
                NHANVIEN newNhanVien = new NHANVIEN

                {
                    MaNV = maNV,
                    TenNV = tenNV,
                    GioiTinh = gioiTinh,
                    DiaChi = diaChi,
                    SoDienThoai = soDienThoai,
                    PhanQuyen = phanQuyen,
                    MatKhau = matKhau,
                    HoatDong = hoatDong

                };


                bool isSuccess = nhanVienBLL.AddNhanVien(newNhanVien);

                if (isSuccess)
                {
                    MessageBox.Show("Nhân viên đã được thêm thành công!");
                    loadDSNhanVien();
                }
                else
                {
                    MessageBox.Show("Có lỗi khi thêm nhân viên");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void BtnLamMoi_Click(object sender, EventArgs e)
        {
           txtMaNV.Clear();
           txtTenNV.Clear();
           txtSDT.Clear();
           loadCbbGioiTinh();
            txtDiaChi.Clear();
            txtPhanQuyen.Clear();
            txtMatKhau.Clear();
            loadCbbHoatDong();
        }

        private void DgvNhanVien_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvNhanVien.CurrentRow != null)
            {
                DataGridViewRow currentRow = dgvNhanVien.CurrentRow;
                txtMaNV.Text = currentRow.Cells["MaNV"].Value?.ToString();
                txtTenNV.Text = currentRow.Cells["TenNV"].Value?.ToString();
                //cbbGioiTinh.SelectedItem = currentRow.Cells["GioiTinh"].Value?.ToString();


                string gioiTinh = currentRow.Cells["GioiTinh"].Value?.ToString();

                if(gioiTinh == "Nam")
                {
                    cbbGioiTinh.SelectedValue = "Nam";
                }
                else
                {
                    cbbGioiTinh.SelectedValue = "Nữ";
                }
                
                txtDiaChi.Text = currentRow.Cells["DiaChi"].Value?.ToString();
                txtSDT.Text = currentRow.Cells["SoDienThoai"].Value?.ToString();
                txtPhanQuyen.Text = currentRow.Cells["PhanQuyen"].Value?.ToString();
                txtMatKhau.Text = currentRow.Cells["MatKhau"].Value?.ToString();

                //cbbHoatDong.SelectedValue = currentRow.Cells["HoatDong"].Value?.ToString();
                string hoatDong = currentRow.Cells["HoatDong"].Value?.ToString();
                if (hoatDong == "1")
                {
                    cbbHoatDong.SelectedValue = 1;
                }
                else
                {
                    cbbHoatDong.SelectedValue = 0;
                }

            }
            else
            {
                Console.WriteLine("Không có dòng nào được chọn.");
            }
        }

        private void FrmQuanLyNhanVien_Load(object sender, EventArgs e)
        {
            loadCbbGioiTinh();
            cbbGioiTinh.SelectedIndex = 0;

            loadCbbHoatDong();
            loadDSNhanVien();
            btnLuu.Enabled = false;
            
        }

        private void loadCbbGioiTinh()
        {
            try
            {
                var dsGioiTinh = new List<object>
                {
                    new { MaGioiTinh = "Nam", TenGioiTinh = "Nam" },
                    new { MaGioiTinh = "Nữ", TenGioiTinh = "Nữ" }
                };

                cbbGioiTinh.DataSource = dsGioiTinh;
                cbbGioiTinh.ValueMember = "MaGioiTinh";
                cbbGioiTinh.DisplayMember = "TenGioiTinh";
                cbbGioiTinh.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách Bàn: " + ex.Message);
            }
        }

        private void loadCbbHoatDong()
        {
            try
            {

                var danhSachTrangThai = new List<object>
                {
                    new { MaHoatDong = 1, TenHoatDong = "Hoạt động" },
                    new { MaHoatDong = 0, TenHoatDong = "Không hoạt động" }
                };

                cbbHoatDong.DataSource = danhSachTrangThai;
                cbbHoatDong.ValueMember = "MaHoatDong";
                cbbHoatDong.DisplayMember = "TenHoatDong";
                cbbHoatDong.DropDownStyle = ComboBoxStyle.DropDownList;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách Bàn: " + ex.Message);
            }
        }

        private void loadDSNhanVien()
        {
            dgvNhanVien.DataSource = null;
            try
            {
                List<NHANVIEN> dsNhanVien = nhanVienBLL.LayDanhSachNhanVien();
                dgvNhanVien.DataSource = dsNhanVien;
                dgvNhanVien.Columns["MaNV"].HeaderText = "Mã nhân viên";
                dgvNhanVien.Columns["TenNV"].HeaderText = "Tên nhân viên";
                dgvNhanVien.Columns["GioiTinh"].HeaderText = "Giới tính";
                dgvNhanVien.Columns["DiaChi"].HeaderText = "Địa chỉ";
                dgvNhanVien.Columns["SoDienThoai"].HeaderText = "Số điện thoại";
                dgvNhanVien.Columns["PhanQuyen"].HeaderText = "Phân quyền";
                dgvNhanVien.Columns["MatKhau"].HeaderText = "Mật khẩu";
                dgvNhanVien.Columns["HoatDong"].HeaderText = "Hoạt động";
               
              
           
                foreach (DataGridViewColumn column in dgvNhanVien.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    column.HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                }
                foreach (DataGridViewRow row in dgvNhanVien.Rows)
                {
                  
                    var cellValue = row.Cells["HoatDong"].Value;
                    if (cellValue != null && int.TryParse(cellValue.ToString(), out int hoatDong))
                    {
                        if (hoatDong == 0)
                        {
                            row.DefaultCellStyle.BackColor = Color.LightPink;
                        }
                    }
                }

                foreach (DataGridViewRow row in dgvNhanVien.Rows)
                {

                    row.Height = 35;
                }
                dgvNhanVien.RowPostPaint += dgv_RowPostPaint;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
            }
        }
        private void dgv_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            string rowIdx = (e.RowIndex + 1).ToString();

            System.Drawing.Font rowFont = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);

            var leftFormat = new System.Drawing.StringFormat()
            {
                Alignment = System.Drawing.StringAlignment.Near,
                LineAlignment = System.Drawing.StringAlignment.Center
            };

            System.Drawing.Rectangle headerBounds = new System.Drawing.Rectangle(e.RowBounds.Left, e.RowBounds.Top, dgv.Columns[0].Width, e.RowBounds.Height);

            e.Graphics.DrawString(rowIdx, rowFont, System.Drawing.SystemBrushes.ControlText, headerBounds, leftFormat);
        }

        private void txtHoatDong_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
