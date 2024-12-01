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
        DanhMucManHinhBLL dmmhBLL = new DanhMucManHinhBLL();
        List<DanhMucManHinh> lstDMMH = new List<DanhMucManHinh>();
        public frmNhomNguoiDung_ManHinh()
        {
            InitializeComponent();
            this.Load += FrmNhomNguoiDung_ManHinh_Load;
        }

        private void FrmNhomNguoiDung_ManHinh_Load(object sender, EventArgs e)
        {
            LoadDataGridViewManHinh();
        }

        private void LoadDataGridViewManHinh()
        {
            //Load danh sách màn hình lên datagridview
            lstDMMH = dmmhBLL.LayDanhSachManHinh();
            if (lstDMMH.Count > 0 && lstDMMH != null)
            {
                dgvDanhSachManHinh.DataSource = lstDMMH;
                dgvDanhSachManHinh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            }
        }
    }
}
