namespace GUI
{
    partial class frmQuanLyKhachHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDSKhachHang = new System.Windows.Forms.DataGridView();
            this.MaKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DCHI = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MALKH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grbThongTin = new System.Windows.Forms.GroupBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtDiemTichLuy = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLoaiKh = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaKH = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.grbLichSu = new System.Windows.Forms.GroupBox();
            this.dtvLichSuGiaoDich = new System.Windows.Forms.DataGridView();
            this.MAHDBH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MANV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MABAN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NGAYXUATHD = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MAKHACHHANG = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TONGTIEN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DIEMTL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GIAMGIA = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtTim = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.btnTim = new System.Windows.Forms.Button();
            this.btnHuyThem = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKhachHang)).BeginInit();
            this.grbThongTin.SuspendLayout();
            this.grbLichSu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtvLichSuGiaoDich)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDSKhachHang
            // 
            this.dgvDSKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDSKhachHang.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDSKhachHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDSKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDSKhachHang.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaKH,
            this.TenKH,
            this.SDT,
            this.DCHI,
            this.DTL,
            this.MALKH});
            this.dgvDSKhachHang.Location = new System.Drawing.Point(594, 51);
            this.dgvDSKhachHang.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDSKhachHang.Name = "dgvDSKhachHang";
            this.dgvDSKhachHang.RowHeadersWidth = 51;
            this.dgvDSKhachHang.RowTemplate.Height = 24;
            this.dgvDSKhachHang.Size = new System.Drawing.Size(753, 289);
            this.dgvDSKhachHang.TabIndex = 82;
            // 
            // MaKH
            // 
            this.MaKH.DataPropertyName = "MaKH";
            this.MaKH.HeaderText = "Mã khách hàng";
            this.MaKH.MinimumWidth = 6;
            this.MaKH.Name = "MaKH";
            // 
            // TenKH
            // 
            this.TenKH.DataPropertyName = "TenKH";
            this.TenKH.HeaderText = "Tên khách hàng";
            this.TenKH.MinimumWidth = 6;
            this.TenKH.Name = "TenKH";
            // 
            // SDT
            // 
            this.SDT.DataPropertyName = "SDT";
            this.SDT.HeaderText = "Số điện thoại";
            this.SDT.MinimumWidth = 6;
            this.SDT.Name = "SDT";
            // 
            // DCHI
            // 
            this.DCHI.DataPropertyName = "DiaChi";
            this.DCHI.HeaderText = "Địa chỉ";
            this.DCHI.MinimumWidth = 6;
            this.DCHI.Name = "DCHI";
            // 
            // DTL
            // 
            this.DTL.DataPropertyName = "DiemTichLuy";
            this.DTL.HeaderText = "Điểm tích lũy";
            this.DTL.MinimumWidth = 6;
            this.DTL.Name = "DTL";
            // 
            // MALKH
            // 
            this.MALKH.DataPropertyName = "MaLKH";
            this.MALKH.HeaderText = "Mã loại khách hàng";
            this.MALKH.MinimumWidth = 6;
            this.MALKH.Name = "MALKH";
            // 
            // grbThongTin
            // 
            this.grbThongTin.Controls.Add(this.btnHuyThem);
            this.grbThongTin.Controls.Add(this.btnLuu);
            this.grbThongTin.Controls.Add(this.btnXoa);
            this.grbThongTin.Controls.Add(this.btnThem);
            this.grbThongTin.Controls.Add(this.txtDiaChi);
            this.grbThongTin.Controls.Add(this.txtDiemTichLuy);
            this.grbThongTin.Controls.Add(this.label1);
            this.grbThongTin.Controls.Add(this.cboLoaiKh);
            this.grbThongTin.Controls.Add(this.label6);
            this.grbThongTin.Controls.Add(this.label5);
            this.grbThongTin.Controls.Add(this.txtSDT);
            this.grbThongTin.Controls.Add(this.label4);
            this.grbThongTin.Controls.Add(this.txtTenKH);
            this.grbThongTin.Controls.Add(this.label3);
            this.grbThongTin.Controls.Add(this.txtMaKH);
            this.grbThongTin.Controls.Add(this.label2);
            this.grbThongTin.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbThongTin.Location = new System.Drawing.Point(33, 148);
            this.grbThongTin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbThongTin.Name = "grbThongTin";
            this.grbThongTin.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbThongTin.Size = new System.Drawing.Size(532, 554);
            this.grbThongTin.TabIndex = 81;
            this.grbThongTin.TabStop = false;
            this.grbThongTin.Text = "Thông tin";
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(195, 196);
            this.txtDiaChi.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(303, 30);
            this.txtDiaChi.TabIndex = 7;
            // 
            // txtDiemTichLuy
            // 
            this.txtDiemTichLuy.Location = new System.Drawing.Point(195, 241);
            this.txtDiemTichLuy.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtDiemTichLuy.Name = "txtDiemTichLuy";
            this.txtDiemTichLuy.Size = new System.Drawing.Size(303, 30);
            this.txtDiemTichLuy.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(32, 302);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 68;
            this.label1.Text = "Loại khách hàng";
            // 
            // cboLoaiKh
            // 
            this.cboLoaiKh.FormattingEnabled = true;
            this.cboLoaiKh.Location = new System.Drawing.Point(195, 294);
            this.cboLoaiKh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboLoaiKh.Name = "cboLoaiKh";
            this.cboLoaiKh.Size = new System.Drawing.Size(303, 33);
            this.cboLoaiKh.TabIndex = 69;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(122, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Điểm tích lũy";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(32, 196);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 25);
            this.label5.TabIndex = 6;
            this.label5.Text = "Địa chỉ";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(195, 145);
            this.txtSDT.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(303, 30);
            this.txtSDT.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 25);
            this.label4.TabIndex = 4;
            this.label4.Text = "SDT";
            // 
            // txtTenKH
            // 
            this.txtTenKH.Location = new System.Drawing.Point(195, 96);
            this.txtTenKH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(303, 30);
            this.txtTenKH.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(32, 100);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Tên khách hàng";
            // 
            // txtMaKH
            // 
            this.txtMaKH.Location = new System.Drawing.Point(195, 42);
            this.txtMaKH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMaKH.Name = "txtMaKH";
            this.txtMaKH.Size = new System.Drawing.Size(303, 30);
            this.txtMaKH.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(32, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 25);
            this.label2.TabIndex = 0;
            this.label2.Text = "Mã khách hàng";
            // 
            // grbLichSu
            // 
            this.grbLichSu.Controls.Add(this.dtvLichSuGiaoDich);
            this.grbLichSu.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbLichSu.Location = new System.Drawing.Point(594, 370);
            this.grbLichSu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbLichSu.Name = "grbLichSu";
            this.grbLichSu.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.grbLichSu.Size = new System.Drawing.Size(1010, 501);
            this.grbLichSu.TabIndex = 84;
            this.grbLichSu.TabStop = false;
            this.grbLichSu.Text = "Lịch sử giao dịch";
            // 
            // dtvLichSuGiaoDich
            // 
            this.dtvLichSuGiaoDich.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtvLichSuGiaoDich.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dtvLichSuGiaoDich.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtvLichSuGiaoDich.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MAHDBH,
            this.MANV,
            this.MABAN,
            this.NGAYXUATHD,
            this.MAKHACHHANG,
            this.TONGTIEN,
            this.DIEMTL,
            this.GIAMGIA});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtvLichSuGiaoDich.DefaultCellStyle = dataGridViewCellStyle3;
            this.dtvLichSuGiaoDich.Location = new System.Drawing.Point(18, 48);
            this.dtvLichSuGiaoDich.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtvLichSuGiaoDich.Name = "dtvLichSuGiaoDich";
            this.dtvLichSuGiaoDich.RowHeadersWidth = 51;
            this.dtvLichSuGiaoDich.RowTemplate.Height = 24;
            this.dtvLichSuGiaoDich.Size = new System.Drawing.Size(969, 429);
            this.dtvLichSuGiaoDich.TabIndex = 0;
            // 
            // MAHDBH
            // 
            this.MAHDBH.DataPropertyName = "MaHDBH";
            this.MAHDBH.HeaderText = "Mã hóa đơn";
            this.MAHDBH.MinimumWidth = 6;
            this.MAHDBH.Name = "MAHDBH";
            this.MAHDBH.Width = 125;
            // 
            // MANV
            // 
            this.MANV.DataPropertyName = "MaNV";
            this.MANV.HeaderText = "Mã nhân viên";
            this.MANV.MinimumWidth = 6;
            this.MANV.Name = "MANV";
            this.MANV.Width = 125;
            // 
            // MABAN
            // 
            this.MABAN.DataPropertyName = "MaBan";
            this.MABAN.HeaderText = "Mã bàn";
            this.MABAN.MinimumWidth = 6;
            this.MABAN.Name = "MABAN";
            this.MABAN.Width = 125;
            // 
            // NGAYXUATHD
            // 
            this.NGAYXUATHD.DataPropertyName = "NgayXuatHD";
            this.NGAYXUATHD.HeaderText = "Ngày xuất hóa đơn";
            this.NGAYXUATHD.MinimumWidth = 6;
            this.NGAYXUATHD.Name = "NGAYXUATHD";
            this.NGAYXUATHD.Width = 125;
            // 
            // MAKHACHHANG
            // 
            this.MAKHACHHANG.DataPropertyName = "MaKH";
            this.MAKHACHHANG.HeaderText = "Mã khách hàng";
            this.MAKHACHHANG.MinimumWidth = 6;
            this.MAKHACHHANG.Name = "MAKHACHHANG";
            this.MAKHACHHANG.Width = 125;
            // 
            // TONGTIEN
            // 
            this.TONGTIEN.DataPropertyName = "TongTien";
            this.TONGTIEN.HeaderText = "Tổng tiền";
            this.TONGTIEN.MinimumWidth = 6;
            this.TONGTIEN.Name = "TONGTIEN";
            this.TONGTIEN.Width = 125;
            // 
            // DIEMTL
            // 
            this.DIEMTL.DataPropertyName = "DiemTL";
            this.DIEMTL.HeaderText = "Điểm tích lũy";
            this.DIEMTL.MinimumWidth = 6;
            this.DIEMTL.Name = "DIEMTL";
            this.DIEMTL.Width = 125;
            // 
            // GIAMGIA
            // 
            this.GIAMGIA.DataPropertyName = "GiamGia";
            this.GIAMGIA.HeaderText = "Giảm giá";
            this.GIAMGIA.MinimumWidth = 6;
            this.GIAMGIA.Name = "GIAMGIA";
            this.GIAMGIA.Width = 125;
            // 
            // txtTim
            // 
            this.txtTim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTim.Location = new System.Drawing.Point(96, 95);
            this.txtTim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTim.Name = "txtTim";
            this.txtTim.Size = new System.Drawing.Size(262, 28);
            this.txtTim.TabIndex = 90;
            this.txtTim.Text = "Nhập mã khách hàng hoặc SĐT";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.grbLichSu);
            this.panel1.Controls.Add(this.dgvDSKhachHang);
            this.panel1.Controls.Add(this.btnTim);
            this.panel1.Controls.Add(this.grbThongTin);
            this.panel1.Controls.Add(this.txtTim);
            this.panel1.Location = new System.Drawing.Point(28, 34);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1619, 922);
            this.panel1.TabIndex = 92;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(96, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(262, 31);
            this.label7.TabIndex = 93;
            this.label7.Text = "Tìm kiếm khách hàng";
            // 
            // btnTim
            // 
            this.btnTim.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnTim.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTim.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTim.ForeColor = System.Drawing.Color.White;
            this.btnTim.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTim.Location = new System.Drawing.Point(385, 73);
            this.btnTim.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnTim.Name = "btnTim";
            this.btnTim.Size = new System.Drawing.Size(114, 50);
            this.btnTim.TabIndex = 91;
            this.btnTim.Text = "Tìm";
            this.btnTim.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnTim.UseVisualStyleBackColor = false;
            // 
            // btnHuyThem
            // 
            this.btnHuyThem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnHuyThem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHuyThem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyThem.ForeColor = System.Drawing.Color.White;
            this.btnHuyThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuyThem.Location = new System.Drawing.Point(405, 455);
            this.btnHuyThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnHuyThem.Name = "btnHuyThem";
            this.btnHuyThem.Size = new System.Drawing.Size(109, 53);
            this.btnHuyThem.TabIndex = 13;
            this.btnHuyThem.Text = "Hủy";
            this.btnHuyThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuyThem.UseVisualStyleBackColor = false;
            // 
            // btnLuu
            // 
            this.btnLuu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLuu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLuu.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuu.ForeColor = System.Drawing.Color.White;
            this.btnLuu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuu.Location = new System.Drawing.Point(282, 455);
            this.btnLuu.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(100, 53);
            this.btnLuu.TabIndex = 12;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoa.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(150, 455);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Size = new System.Drawing.Size(115, 53);
            this.btnXoa.TabIndex = 11;
            this.btnXoa.Text = "Xóa";
            this.btnXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoa.UseVisualStyleBackColor = false;
            // 
            // btnThem
            // 
            this.btnThem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnThem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThem.ForeColor = System.Drawing.Color.White;
            this.btnThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThem.Location = new System.Drawing.Point(18, 455);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnThem.Name = "btnThem";
            this.btnThem.Size = new System.Drawing.Size(111, 53);
            this.btnThem.TabIndex = 10;
            this.btnThem.Tag = "Chưa Click";
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // FormQLKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1659, 1000);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormQLKhachHang";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDSKhachHang)).EndInit();
            this.grbThongTin.ResumeLayout(false);
            this.grbThongTin.PerformLayout();
            this.grbLichSu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtvLichSuGiaoDich)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDSKhachHang;
        private System.Windows.Forms.GroupBox grbThongTin;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtDiemTichLuy;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboLoaiKh;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbLichSu;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
        private System.Windows.Forms.TextBox txtTim;
        private System.Windows.Forms.Button btnTim;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnHuyThem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenKH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn DCHI;
        private System.Windows.Forms.DataGridViewTextBoxColumn DTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn MALKH;
        private System.Windows.Forms.DataGridView dtvLichSuGiaoDich;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAHDBH;
        private System.Windows.Forms.DataGridViewTextBoxColumn MANV;
        private System.Windows.Forms.DataGridViewTextBoxColumn MABAN;
        private System.Windows.Forms.DataGridViewTextBoxColumn NGAYXUATHD;
        private System.Windows.Forms.DataGridViewTextBoxColumn MAKHACHHANG;
        private System.Windows.Forms.DataGridViewTextBoxColumn TONGTIEN;
        private System.Windows.Forms.DataGridViewTextBoxColumn DIEMTL;
        private System.Windows.Forms.DataGridViewTextBoxColumn GIAMGIA;
        private System.Windows.Forms.Label label7;
    }
}

