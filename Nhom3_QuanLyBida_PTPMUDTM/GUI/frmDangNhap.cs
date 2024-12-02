using BLL;
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

namespace GUI
{
    public partial class frmDangNhap : Form
    {
        DB_BLL_Quang bll = new DB_BLL_Quang();
        bool hienMatKhau = false;
        public frmDangNhap()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += DangNhap_Load;
            btn_hienmatkhau.Click += Btn_hienmatkhau_Click;
            btnThoat.Click += btnThoat_Click;
            this.FormClosing += DangNhap_FormClosing;
            txtMatKhau.KeyDown += txtMatKhau_KeyDown;
            btnDangNhap.Click += btnDangNhap_Click;
        }

        private void Btn_hienmatkhau_Click(object sender, EventArgs e)
        {
            hienMatKhau = !hienMatKhau;
            if (hienMatKhau == true)
            {
                txtMatKhau.UseSystemPasswordChar = false;
            }
            else
            {
                txtMatKhau.UseSystemPasswordChar = true;
            }
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string tk = txtTenDangNhap.Text;
            string mk = txtMatKhau.Text;
            NHANVIEN nv = bll.LayMotNhanVien(tk, mk);

            //DBConnect db = new DBConnect();
            //string cauTruyVan = "select * from NHANVIEN where MaNV = '"+txtTenDangNhap.Text+"' and MatKhau = '"+txtMatKhau.Text+"' ";
            //DataTable dt = db.getDataTable(cauTruyVan);
            if (nv != null) // Có đăng nhập được
            {
                if (nv.HoatDong != 1)
                {
                    MessageBox.Show("Tài khoản đã bị khóa !!!. Vui lòng liên hệ chủ quản lý");
                    return;
                }
                frmMain giaodien = new frmMain();
                giaodien.MaNV = nv.MaNV;
                giaodien.Show();
                this.Hide();
            }
            else //Đăng nhập không được
                MessageBox.Show("Thông tin đăng nhập không chính xác \n Vui lòng đăng nhập lại", "Sai thông tin đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult r;
            r = MessageBox.Show("Bạn có muốn thoát ?", "Thoát", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (r == DialogResult.No)
                e.Cancel = true;
        }

        private void txtMatKhau_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // Kích hoạt sự kiện Click của button
                btnDangNhap.PerformClick();
            }
        }

        private void DangNhap_Load(object sender, EventArgs e)
        {
            txtMatKhau.UseSystemPasswordChar = true;
            
        }
    }
}
