namespace GUI
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.fluentDesignFormContainer1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.menuItemMenu = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.menuItemChoiBida = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.menuItemQuanLy = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.menuItemQLLoaiHangHangHoa = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.menuItemQLBan_KV_LB = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.menuItemQLNhanVien = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.menuItemQLKhachHang = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.menuItemQLHoaDon = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.menuItemThongKeRoot = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.menuItemThongKe = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement1 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnNhomNguoiDung_ManHinh = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.btnNhanVien_NhomNguoiDung = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.fluentDesignFormControl1 = new DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl();
            this.btnThietLapTaiKhoan = new DevExpress.XtraBars.BarButtonItem();
            this.txtTenNhanVien = new DevExpress.XtraBars.BarStaticItem();
            this.btnDangXuat = new DevExpress.XtraBars.BarButtonItem();
            this.fluentFormDefaultManager1 = new DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager(this.components);
            this.fluentDesignFormContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // fluentDesignFormContainer1
            // 
            this.fluentDesignFormContainer1.Controls.Add(this.pictureBox1);
            this.fluentDesignFormContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.fluentDesignFormContainer1.Location = new System.Drawing.Point(260, 31);
            this.fluentDesignFormContainer1.Name = "fluentDesignFormContainer1";
            this.fluentDesignFormContainer1.Size = new System.Drawing.Size(1277, 920);
            this.fluentDesignFormContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 920);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.menuItemMenu,
            this.menuItemQuanLy,
            this.menuItemThongKeRoot,
            this.accordionControlElement1});
            this.accordionControl1.Location = new System.Drawing.Point(0, 31);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Touch;
            this.accordionControl1.Size = new System.Drawing.Size(260, 920);
            this.accordionControl1.TabIndex = 1;
            this.accordionControl1.ViewType = DevExpress.XtraBars.Navigation.AccordionControlViewType.HamburgerMenu;
            // 
            // menuItemMenu
            // 
            this.menuItemMenu.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.menuItemChoiBida});
            this.menuItemMenu.Expanded = true;
            this.menuItemMenu.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl, DevExpress.XtraBars.Navigation.HeaderElementAlignment.Left),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons, DevExpress.XtraBars.Navigation.HeaderElementAlignment.Left)});
            this.menuItemMenu.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuItemMenu.ImageOptions.Image")));
            this.menuItemMenu.Name = "menuItemMenu";
            this.menuItemMenu.Tag = "1";
            this.menuItemMenu.Text = "Menu";
            // 
            // menuItemChoiBida
            // 
            this.menuItemChoiBida.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuItemChoiBida.ImageOptions.Image")));
            this.menuItemChoiBida.Name = "menuItemChoiBida";
            this.menuItemChoiBida.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.menuItemChoiBida.Tag = "MH001";
            this.menuItemChoiBida.Text = "Chơi Bida";
            // 
            // menuItemQuanLy
            // 
            this.menuItemQuanLy.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.menuItemQLLoaiHangHangHoa,
            this.menuItemQLBan_KV_LB,
            this.menuItemQLNhanVien,
            this.menuItemQLKhachHang,
            this.menuItemQLHoaDon});
            this.menuItemQuanLy.Expanded = true;
            this.menuItemQuanLy.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuItemQuanLy.ImageOptions.Image")));
            this.menuItemQuanLy.Name = "menuItemQuanLy";
            this.menuItemQuanLy.Tag = "1";
            this.menuItemQuanLy.Text = "Quản lý";
            // 
            // menuItemQLLoaiHangHangHoa
            // 
            this.menuItemQLLoaiHangHangHoa.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuItemQLLoaiHangHangHoa.ImageOptions.Image")));
            this.menuItemQLLoaiHangHangHoa.Name = "menuItemQLLoaiHangHangHoa";
            this.menuItemQLLoaiHangHangHoa.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.menuItemQLLoaiHangHangHoa.Tag = "MH002";
            this.menuItemQLLoaiHangHangHoa.Text = "Quản lý Hàng Hóa - Loại Hàng Hóa";
            // 
            // menuItemQLBan_KV_LB
            // 
            this.menuItemQLBan_KV_LB.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuItemQLBan_KV_LB.ImageOptions.Image")));
            this.menuItemQLBan_KV_LB.Name = "menuItemQLBan_KV_LB";
            this.menuItemQLBan_KV_LB.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.menuItemQLBan_KV_LB.Tag = "MH003";
            this.menuItemQLBan_KV_LB.Text = "Quản lý Loại Bàn - Bàn - Khu Vực";
            // 
            // menuItemQLNhanVien
            // 
            this.menuItemQLNhanVien.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuItemQLNhanVien.ImageOptions.Image")));
            this.menuItemQLNhanVien.Name = "menuItemQLNhanVien";
            this.menuItemQLNhanVien.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.menuItemQLNhanVien.Tag = "MH004";
            this.menuItemQLNhanVien.Text = "Quản Lý Nhân Viên";
            // 
            // menuItemQLKhachHang
            // 
            this.menuItemQLKhachHang.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuItemQLKhachHang.ImageOptions.Image")));
            this.menuItemQLKhachHang.Name = "menuItemQLKhachHang";
            this.menuItemQLKhachHang.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.menuItemQLKhachHang.Tag = "MH005";
            this.menuItemQLKhachHang.Text = "Quản lý khách hàng";
            // 
            // menuItemQLHoaDon
            // 
            this.menuItemQLHoaDon.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuItemQLHoaDon.ImageOptions.Image")));
            this.menuItemQLHoaDon.Name = "menuItemQLHoaDon";
            this.menuItemQLHoaDon.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.menuItemQLHoaDon.Tag = "MH006";
            this.menuItemQLHoaDon.Text = "Quản Lý Hóa Đơn";
            // 
            // menuItemThongKeRoot
            // 
            this.menuItemThongKeRoot.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.menuItemThongKe});
            this.menuItemThongKeRoot.Expanded = true;
            this.menuItemThongKeRoot.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuItemThongKeRoot.ImageOptions.Image")));
            this.menuItemThongKeRoot.Name = "menuItemThongKeRoot";
            this.menuItemThongKeRoot.Tag = "1";
            this.menuItemThongKeRoot.Text = "Thống kê";
            // 
            // menuItemThongKe
            // 
            this.menuItemThongKe.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("menuItemThongKe.ImageOptions.Image")));
            this.menuItemThongKe.Name = "menuItemThongKe";
            this.menuItemThongKe.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.menuItemThongKe.Tag = "MH007";
            this.menuItemThongKe.Text = "Thống kê";
            // 
            // accordionControlElement1
            // 
            this.accordionControlElement1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.btnNhomNguoiDung_ManHinh,
            this.btnNhanVien_NhomNguoiDung});
            this.accordionControlElement1.Expanded = true;
            this.accordionControlElement1.ImageOptions.Image = global::GUI.Properties.Resources.team_32x32;
            this.accordionControlElement1.Name = "accordionControlElement1";
            this.accordionControlElement1.Tag = "1";
            this.accordionControlElement1.Text = "Phân Quyền";
            // 
            // btnNhomNguoiDung_ManHinh
            // 
            this.btnNhomNguoiDung_ManHinh.ImageOptions.Image = global::GUI.Properties.Resources.boperson_32x32;
            this.btnNhomNguoiDung_ManHinh.Name = "btnNhomNguoiDung_ManHinh";
            this.btnNhomNguoiDung_ManHinh.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnNhomNguoiDung_ManHinh.Tag = "MH008";
            this.btnNhomNguoiDung_ManHinh.Text = "Nhóm người dùng - Màn hình";
            this.btnNhomNguoiDung_ManHinh.Click += new System.EventHandler(this.btnNhomNguoiDung_ManHinh_Click);
            // 
            // btnNhanVien_NhomNguoiDung
            // 
            this.btnNhanVien_NhomNguoiDung.ImageOptions.Image = global::GUI.Properties.Resources.boemployee_32x321;
            this.btnNhanVien_NhomNguoiDung.Name = "btnNhanVien_NhomNguoiDung";
            this.btnNhanVien_NhomNguoiDung.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.btnNhanVien_NhomNguoiDung.Tag = "MH009";
            this.btnNhanVien_NhomNguoiDung.Text = "Nhân viên - Nhóm người dùng";
            this.btnNhanVien_NhomNguoiDung.Click += new System.EventHandler(this.btnNhanVien_NhomNguoiDung_Click);
            // 
            // fluentDesignFormControl1
            // 
            this.fluentDesignFormControl1.FluentDesignForm = this;
            this.fluentDesignFormControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThietLapTaiKhoan,
            this.txtTenNhanVien,
            this.btnDangXuat});
            this.fluentDesignFormControl1.Location = new System.Drawing.Point(0, 0);
            this.fluentDesignFormControl1.Manager = this.fluentFormDefaultManager1;
            this.fluentDesignFormControl1.Name = "fluentDesignFormControl1";
            this.fluentDesignFormControl1.Size = new System.Drawing.Size(1537, 31);
            this.fluentDesignFormControl1.TabIndex = 2;
            this.fluentDesignFormControl1.TabStop = false;
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.btnDangXuat);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.btnThietLapTaiKhoan);
            this.fluentDesignFormControl1.TitleItemLinks.Add(this.txtTenNhanVien);
            // 
            // btnThietLapTaiKhoan
            // 
            this.btnThietLapTaiKhoan.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnThietLapTaiKhoan.Id = 0;
            this.btnThietLapTaiKhoan.ImageOptions.Image = global::GUI.Properties.Resources.bouser_16x16;
            this.btnThietLapTaiKhoan.ImageOptions.LargeImage = global::GUI.Properties.Resources.bouser_32x32;
            this.btnThietLapTaiKhoan.Name = "btnThietLapTaiKhoan";
            // 
            // txtTenNhanVien
            // 
            this.txtTenNhanVien.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.txtTenNhanVien.Caption = "Ngô Thành Quang";
            this.txtTenNhanVien.Id = 1;
            this.txtTenNhanVien.Name = "txtTenNhanVien";
            // 
            // btnDangXuat
            // 
            this.btnDangXuat.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.btnDangXuat.Caption = "Đăng xuất";
            this.btnDangXuat.Id = 2;
            this.btnDangXuat.ImageOptions.Image = global::GUI.Properties.Resources.right_16x16;
            this.btnDangXuat.ImageOptions.LargeImage = global::GUI.Properties.Resources.right_32x32;
            this.btnDangXuat.Name = "btnDangXuat";
            // 
            // fluentFormDefaultManager1
            // 
            this.fluentFormDefaultManager1.Form = this;
            this.fluentFormDefaultManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.btnThietLapTaiKhoan,
            this.txtTenNhanVien,
            this.btnDangXuat});
            this.fluentFormDefaultManager1.MaxItemId = 3;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1537, 951);
            this.ControlContainer = this.fluentDesignFormContainer1;
            this.Controls.Add(this.fluentDesignFormContainer1);
            this.Controls.Add(this.accordionControl1);
            this.Controls.Add(this.fluentDesignFormControl1);
            this.FluentDesignFormControl = this.fluentDesignFormControl1;
            this.Name = "frmMain";
            this.NavigationControl = this.accordionControl1;
            this.Text = "frmMain";
            this.fluentDesignFormContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentDesignFormControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fluentFormDefaultManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormContainer fluentDesignFormContainer1;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl fluentDesignFormControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement menuItemMenu;
        private DevExpress.XtraBars.FluentDesignSystem.FluentFormDefaultManager fluentFormDefaultManager1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement menuItemQuanLy;
        private DevExpress.XtraBars.Navigation.AccordionControlElement menuItemChoiBida;
        private DevExpress.XtraBars.Navigation.AccordionControlElement menuItemQLLoaiHangHangHoa;
        private System.Windows.Forms.PictureBox pictureBox1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement menuItemThongKeRoot;
        private DevExpress.XtraBars.Navigation.AccordionControlElement menuItemQLBan_KV_LB;
        private DevExpress.XtraBars.Navigation.AccordionControlElement menuItemQLNhanVien;
        private DevExpress.XtraBars.Navigation.AccordionControlElement menuItemQLKhachHang;
        private DevExpress.XtraBars.Navigation.AccordionControlElement menuItemQLHoaDon;
        private DevExpress.XtraBars.Navigation.AccordionControlElement menuItemThongKe;
        private DevExpress.XtraBars.BarButtonItem btnThietLapTaiKhoan;
        private DevExpress.XtraBars.BarStaticItem txtTenNhanVien;
        private DevExpress.XtraBars.BarButtonItem btnDangXuat;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnNhomNguoiDung_ManHinh;
        private DevExpress.XtraBars.Navigation.AccordionControlElement btnNhanVien_NhomNguoiDung;
    }
}