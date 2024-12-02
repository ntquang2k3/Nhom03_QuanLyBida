using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class frmDoiMatKhau : Form
    {
        NhanVienBLL nhanVienBLL = new NhanVienBLL();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        private string taiKhoan;
        public frmDoiMatKhau(string taiKhoan)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.taiKhoan = taiKhoan;
            btnCapNhat.Click += btnCapNhat_Click;
            txtNhapLai.KeyDown += txtNhapLai_KeyDown;
            this.Load += FrmDoiMatKhau_Load;
        }

        private void FrmDoiMatKhau_Load(object sender, EventArgs e)
        {
            txtMaNhanVien.Text = taiKhoan;
            txtMaNhanVien.Enabled = false;
            txtMatKhauCu.Focus();
            txtMatKhauCu.UseSystemPasswordChar = true;
            txtMatKhauMoi.UseSystemPasswordChar = true;
            txtNhapLai.UseSystemPasswordChar = true;
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtMaNhanVien.Text) || string.IsNullOrEmpty(txtMatKhauCu.Text) || string.IsNullOrEmpty(txtMatKhauMoi.Text) || string.IsNullOrEmpty(txtNhapLai.Text))
                {
                    throw new Exception("Vui lòng nhập đầy đủ dữ liệu");
                }
                else
                if (txtMatKhauMoi.Text.Length < 5)
                {
                    throw new Exception("Mật khẩu mới phải trên từ 5 đến 18 kí tự");
                }
                if (txtNhapLai.Text != txtMatKhauMoi.Text)
                {
                    throw new Exception("Mật khẩu xác nhận không khớp");
                }
                //Cập nhật mật khẩu mới cho nhân viên vào database
                if (nhanVienBLL.DoiMatKhau(taiKhoan, txtMatKhauCu.Text, txtMatKhauMoi.Text))
                {
                    MessageBox.Show("Đổi mật khẩu thành công");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Đổi mật khẩu thất bại");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtNhapLai_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Kích hoạt sự kiện Click của button
                btnCapNhat.PerformClick();
            }
        }
    }
}
