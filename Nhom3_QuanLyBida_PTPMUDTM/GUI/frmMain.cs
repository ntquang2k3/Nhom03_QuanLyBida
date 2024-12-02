using BLL;
using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DAL;
using DevExpress.XtraBars.Navigation;

namespace GUI
{
    public partial class frmMain : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        DanhMucManHinhBLL danhMucManHinhBLL = new DanhMucManHinhBLL();
        public string MaNV {  get; set; }
        public frmMain()
        {
            InitializeComponent();
            this.Load += FrmMain_Load;
            AddEvents();
        }

        private void AddEvents()
        {
            menuItemQLBan_KV_LB.Click += MenuItemQLBan_KV_LB_Click;
            menuItemQLHoaDon.Click += MenuItemQLHoaDon_Click;
            menuItemQLKhachHang.Click += MenuItemQLKhachHang_Click;
            menuItemQLLoaiHangHangHoa.Click += MenuItemQLLoaiHangHangHoa_Click;
            menuItemThongKe.Click += MenuItemThongKe_Click;
            menuItemChoiBida.Click += MenuItemChoiBida_Click;
            menuItemQLNhanVien.Click += MenuItemQLNhanVien_Click;
            btnDangXuat.ItemClick += BtnDangXuat_ItemClick;
            btnThietLapTaiKhoan.ItemClick += BtnThietLapTaiKhoan_ItemClick;
            this.FormClosed += FrmMain_FormClosed;
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void BtnThietLapTaiKhoan_ItemClick(object sender, ItemClickEventArgs e)
        {
            frmDoiMatKhau frm = new frmDoiMatKhau(MaNV);
            frm.ShowDialog();
        }

        private void BtnDangXuat_ItemClick(object sender, ItemClickEventArgs e)
        {
            Application.Exit();
        }

        private void MenuItemQLNhanVien_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frmQuanLyNhanVien());
        }

        private void OpenChildForm(Form childForm)
        {
            // Xóa các form con hiện tại trong container
            fluentDesignFormContainer1.Controls.Clear();

            // Thiết lập các thuộc tính của form con
            childForm.TopLevel = false; // Form con sẽ là một control của container
            childForm.FormBorderStyle = FormBorderStyle.None; // Loại bỏ viền của form con
            childForm.Dock = DockStyle.Fill; // Form con sẽ chiếm toàn bộ không gian container

            // Thêm form con vào container
            fluentDesignFormContainer1.Controls.Add(childForm);
            childForm.Show();
        }

        private void MenuItemChoiBida_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmChoiBida(MaNV));
        }

        private void MenuItemThongKe_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frmThongKe());
        }

        private void MenuItemQLLoaiHangHangHoa_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frmQuanLyLoaiHangHoa());
        }

        private void MenuItemQLKhachHang_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frmQuanLyKhachHang());
        }

        private void MenuItemQLHoaDon_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frmQuanLyHoaDon());
        }

        private void MenuItemQLBan_KV_LB_Click(object sender, EventArgs e)
        {
            //OpenChildForm(new frmQuanLyLoaiBan_KhuVuc_Ban());
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            DB_BLL bLL = new DB_BLL();
            NHANVIEN nv = bLL.LayMotNhanVien(MaNV);
            //Load nhân viên lên txtTenNhanVien
            txtTenNhanVien.Caption = nv.TenNV;
            //Kiểm tra nhóm quyền của nhân viên và hiển thị các chức năng tương ứng
            PhanQuyen();
            FullScreenForm();
            OpenChildForm(new frmChoiBida(MaNV));
        }
        private void PhanQuyen()
        {
            // Lấy danh sách quyền của nhân viên từ PhanQuyenBLL
            List<DanhMucManHinh> danhSachQuyen = danhMucManHinhBLL.LayDanhSachManHinh(MaNV);
            // Kiểm tra danh sách quyền
            Console.WriteLine("Danh sách quyền:");
            foreach (var item in danhSachQuyen)
            {
                Console.WriteLine($"MaManHinh: {item.MaManHinh}");
            }

            // Lặp qua tất cả các control trong accordionControl1
            foreach (AccordionControlElement control in accordionControl1.Elements)
            {
                // Gọi phương thức phân quyền đệ quy cho các phần tử cha và phần tử con
                PhanQuyenChoElement(control, danhSachQuyen);
            }
        }

        private void PhanQuyenChoElement(AccordionControlElement element, List<DanhMucManHinh> danhSachQuyen)
        {
            bool hasPermission = false;

            // Kiểm tra nếu element có Tag (có thể là danh sách quyền yêu cầu)
            if (element.Tag != null)
            {
                Console.WriteLine($"Tag của element: {element.Tag}");
                var kq = danhSachQuyen.FirstOrDefault(t => t.MaManHinh == element.Tag.ToString());
                // Kiểm tra nếu nhân viên có ít nhất một quyền trong danh sách quyền yêu cầu
                if (kq != null)
                {
                    hasPermission = true;
                }
            }

            // Nếu element có quyền, hiển thị và cho phép tương tác với element
            if (hasPermission)
            {
                element.Visible = true;
                element.Enabled = true;
            }
            else
            {
                // Nếu không có quyền, ẩn element và vô hiệu hóa
                element.Visible = false;
                element.Enabled = false;
            }

            // Tiếp tục phân quyền cho các phần tử con của element (nếu có)
            foreach (AccordionControlElement childElement in element.Elements)
            {
                PhanQuyenChoElement(childElement, danhSachQuyen);

                // Nếu phần tử con có quyền, cho phép phần tử cha cũng được hiển thị
                if (childElement.Visible)
                {
                    element.Visible = true;
                    element.Enabled = true;
                }
            }
        }
        public void FullScreenForm()
        {
            // Đặt trạng thái của form thành toàn màn hình
            this.WindowState = FormWindowState.Maximized;

            // Loại bỏ đường viền của form
            //this.FormBorderStyle = FormBorderStyle.None;

            // Ẩn nút Phóng to và Thu nhỏ
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            // Thêm sự kiện phím ESC để thoát (nếu cần thiết)
            this.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Escape) // Nhấn ESC để thoát
                {
                    this.Close();
                }
            };
        }

        private void btnNhomNguoiDung_ManHinh_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhomNguoiDung_ManHinh());
        }

        private void btnNhanVien_NhomNguoiDung_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmNhanVien_NhomNguoiDung());
        }
    }
}
