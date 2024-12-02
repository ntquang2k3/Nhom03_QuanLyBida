using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UC
{
    public partial class ThemXoaSua : UserControl
    {
        // Khai báo các sự kiện
        public event EventHandler ThemClicked;
        public event EventHandler XoaClicked;
        public event EventHandler SuaClicked;
        public event EventHandler LuuClicked;
        public event EventHandler HuyThemClicked;
        public Button BtnThem {  get { return this.btnThem;  } set { btnThem = value; } }
        public Button BtnHuyThem { get { return this.btnHuyThem; } set { btnHuyThem = value; } }
        public Button BtnXoa { get { return this.btnXoa; } set { btnXoa = value; } }
        public Button BtnSua { get { return this.btnSua; } set { btnSua = value; } }
        public Button BtnLuu { get { return this.btnLuu; } set { btnLuu = value; } }
        public ThemXoaSua()
        {
            InitializeComponent();
            btnThem.Click += btnThem_Click;
            btnXoa.Click += btnXoa_Click;
            btnSua.Click += btnSua_Click;
            btnLuu.Click += btnLuu_Click;
            btnHuyThem.Click += BtnHuyThem_Click;
            btnHuyThem.Enabled = false;
        }

        private void BtnHuyThem_Click(object sender, EventArgs e)
        {
            HuyThemClicked?.Invoke(this, EventArgs.Empty);
            btnHuyThem.Enabled = false;
            btnXoa.Enabled = true;
            btnSua.Enabled = true;
            btnLuu.Enabled = true;
            btnThem.Image = Properties.Resources.icons8_add_35;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            LuuClicked?.Invoke(this, EventArgs.Empty);
        }

        // Xử lý sự kiện Click và gọi các sự kiện tương ứng
        private void btnThem_Click(object sender, EventArgs e)
        {
            ThemClicked?.Invoke(this, EventArgs.Empty);
            
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            XoaClicked?.Invoke(this, EventArgs.Empty);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            SuaClicked?.Invoke(this, EventArgs.Empty);
        }
    }
}
