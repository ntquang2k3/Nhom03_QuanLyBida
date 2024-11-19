using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.CompilerServices;
namespace UC
{
    public partial class TableItem : UserControl
    {

        private Color originalBackColor; // Màu nền ban đầu
        private Color hoverBackColor = Color.LightSkyBlue; // Màu nền khi hover
        private bool isSelected;
        private string tenBan;
        private string maLoaiBan;
        private string loaiBan;
        private string maBan;
        private int maHoaDon;
        private string trangThai;
        public bool IsSelected // Thuộc tính để kiểm tra trạng thái được chọn
        {
            get { return isSelected; }
            set
            {
                isSelected = value;
                if (IsSelected == true)
                {
                    this.anhBanBida.Image = Properties.Resources.banBidaDangChon;
                }
                else
                {
                    if (trangThai == "Trống")
                    {
                        this.anhBanBida.Image = Properties.Resources.banBidaTrong;
                    }
                    if (trangThai == "Đang chơi")
                    {
                        this.anhBanBida.Image = Properties.Resources.banBidaDangChoi;
                    }
                    if (trangThai == "Đặt cọc")
                    {
                        this.anhBanBida.Image = Properties.Resources.banBidaDatCoc;
                    }
                }
                this.BackColor = isSelected ? Color.LightBlue : Color.White; // Thay đổi màu nền theo trạng thái
            }
        }

        public string TenBan { get => tenBan;
            set
            {
                this.label_tenBan.Text = value;
                tenBan = value;
            }
        }
        public string MaBan { get => maBan; set => maBan = value; }
        public string TrangThai
        {
            get => trangThai; set
            {
                trangThai = value;
                if (trangThai == "Trống")
                {
                    this.anhBanBida.Image = Properties.Resources.banBidaTrong;
                }
                if (trangThai == "Đang chơi")
                {
                    this.anhBanBida.Image = Properties.Resources.banBidaDangChoi;
                }
                if (trangThai == "Đặt cọc")
                {
                    this.anhBanBida.Image = Properties.Resources.banBidaDatCoc;
                }
            }
        }

        public string LoaiBan { get => loaiBan; set { this.labelLoaiBan.Text = value; loaiBan = value; } }

        public int MaHoaDon { get => maHoaDon; set => maHoaDon = value; }
        public string MaLoaiBan { get => maLoaiBan; set => maLoaiBan = value; }

        //public event EventHandler hover;
        public TableItem()
        {
            InitializeComponent();
            //this.Paint += TableItem_Paint;

            originalBackColor = this.BackColor; // Lưu màu nền ban đầu
            //this.MouseEnter += ProductItem_MouseEnter;
            //this.MouseLeave += ProductItem_MouseLeave;

            // Đảm bảo rằng tất cả các điều khiển con không ngăn chặn sự kiện chuột
            foreach (Control control in this.Controls)
            {
                control.MouseEnter += (s, e) => this.OnMouseEnter(e);
                control.MouseLeave += (s, e) => this.OnMouseLeave(e);
            }
            this.label_tenBan.Text = TenBan;

        }
        public TableItem(string trangThai)
        {
            InitializeComponent();
            // Đảm bảo rằng tất cả các điều khiển con không ngăn chặn sự kiện chuột
            foreach (Control control in this.Controls)
            {
                control.MouseEnter += (s, e) => this.OnMouseEnter(e);
                control.MouseLeave += (s, e) => this.OnMouseLeave(e);
            }
            if (trangThai == "Trống")
            {
                this.anhBanBida.Image = Properties.Resources.banBidaTrong;
            }
            if (trangThai == "Đang chơi")
            {
                this.anhBanBida.Image = Properties.Resources.banBidaDangChoi;
            }
            if (trangThai == "Đặt cọc")
            {
                this.anhBanBida.Image = Properties.Resources.banBidaDatCoc;
            }
            this.trangThai = trangThai;
            // Gán sự kiện
            this.anhBanBida.Click += ItemControl_Click;
            this.labelLoaiBan.Click += ItemControl_Click;
            this.label_tenBan.Click += ItemControl_Click;
        }

        private void ItemControl_Click(object sender, EventArgs e)
        {
            this.OnClick(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Tạo đối tượng Pen để vẽ viền (màu sắc và độ dày)
            using (Pen pen = new Pen(Color.Black, 2))  // Chọn màu xanh và độ dày là 2
            {
                // Vẽ một hình chữ nhật xung quanh UserControl
                e.Graphics.DrawRectangle(pen, 0, 0, this.Width - 0, this.Height - 0);
            }
        }

    }
}
