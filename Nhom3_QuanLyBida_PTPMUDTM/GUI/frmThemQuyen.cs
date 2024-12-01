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
    public partial class frmThemQuyen : Form
    {
        public string TenQuyen { get; set; }
        public string MoTa { get; set; }
        public event EventHandler Luu;
        public frmThemQuyen()
        {
            InitializeComponent();
            this.btnLuu.Click += BtnLuu_Click;
            btnDong.Click += btnDong_Click;
        }

        private void BtnLuu_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu
            if (txtTenQuyen.Text == "")
            {
                MessageBox.Show("Tên quyền không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txtMoTa.Text == "")
            {
                MessageBox.Show("Mô tả không được để trống", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Hiển thị thông báo xác nhận
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thêm quyền này không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.TenQuyen = txtTenQuyen.Text;
                this.MoTa = txtMoTa.Text;
                Luu?.Invoke(this, EventArgs.Empty);
                this.Close();
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frm_ThemQuyen_Load(object sender, EventArgs e)
        {

        }
    }
}
