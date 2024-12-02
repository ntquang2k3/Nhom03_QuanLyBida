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
namespace GUI
{
    public partial class frmChuyenBan : Form
    {
        DB_BLL_Quang bll = new DB_BLL_Quang();
        public string MaChuyenDen { get; set; }
        public int MaLoaiBan { get; set; }
        public string MaKhuVuc { get; set; }

        public frmChuyenBan()
        {
            InitializeComponent();
            btnChuyenDen.Click += BtnChuyenDen_Click;
            this.Load += FrmChuyenBan_Load;
        }

        private void FrmChuyenBan_Load(object sender, EventArgs e)
        {
            dtgvChuyenBan.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dtgvChuyenBan.AllowUserToAddRows = false;
            dtgvChuyenBan.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dtgvChuyenBan.MultiSelect = false;
            DataTable dt = bll.LayDanhSachBan(MaLoaiBan, MaKhuVuc, "Empty");
            dtgvChuyenBan.DataSource = dt;
        }

        private void BtnChuyenDen_Click(object sender, EventArgs e)
        {
            MaChuyenDen = dtgvChuyenBan.SelectedRows[0].Cells["MaBan"].Value.ToString();
            this.Close(); // Đóng Form nhập mã bàn sau khi lấy giá trị mã bàn
        }
    }
}
