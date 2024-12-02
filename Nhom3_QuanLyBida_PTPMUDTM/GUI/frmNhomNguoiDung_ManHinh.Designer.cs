namespace GUI
{
    partial class frmNhomNguoiDung_ManHinh
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvManHinhNhomNguoiDung = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMaNhomNguoiDung = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTenNhomNguoiDung = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_NhomNguoiDung = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.cbbDanhSachManHinh = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.btnSuaNND = new System.Windows.Forms.Button();
            this.btnXoaManHinh = new System.Windows.Forms.Button();
            this.btnThemManHinh = new System.Windows.Forms.Button();
            this.btnXoaNND = new System.Windows.Forms.Button();
            this.btnThemNND = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvManHinhNhomNguoiDung)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhomNguoiDung)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvManHinhNhomNguoiDung);
            this.groupBox1.Location = new System.Drawing.Point(626, 318);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 474);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Màn hình của nhóm";
            // 
            // dgvManHinhNhomNguoiDung
            // 
            this.dgvManHinhNhomNguoiDung.BackgroundColor = System.Drawing.Color.White;
            this.dgvManHinhNhomNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvManHinhNhomNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvManHinhNhomNguoiDung.Location = new System.Drawing.Point(3, 22);
            this.dgvManHinhNhomNguoiDung.Name = "dgvManHinhNhomNguoiDung";
            this.dgvManHinhNhomNguoiDung.Size = new System.Drawing.Size(568, 449);
            this.dgvManHinhNhomNguoiDung.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(14, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(178, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã Nhóm người dùng";
            // 
            // txtMaNhomNguoiDung
            // 
            this.txtMaNhomNguoiDung.Location = new System.Drawing.Point(212, 34);
            this.txtMaNhomNguoiDung.Name = "txtMaNhomNguoiDung";
            this.txtMaNhomNguoiDung.Size = new System.Drawing.Size(269, 26);
            this.txtMaNhomNguoiDung.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(14, 82);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(184, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Tên Nhóm người dùng";
            // 
            // txtTenNhomNguoiDung
            // 
            this.txtTenNhomNguoiDung.Location = new System.Drawing.Point(212, 79);
            this.txtTenNhomNguoiDung.Multiline = true;
            this.txtTenNhomNguoiDung.Name = "txtTenNhomNguoiDung";
            this.txtTenNhomNguoiDung.Size = new System.Drawing.Size(269, 60);
            this.txtTenNhomNguoiDung.TabIndex = 7;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_NhomNguoiDung);
            this.groupBox2.Location = new System.Drawing.Point(12, 357);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 435);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách nhóm người dùng";
            // 
            // dgv_NhomNguoiDung
            // 
            this.dgv_NhomNguoiDung.BackgroundColor = System.Drawing.Color.White;
            this.dgv_NhomNguoiDung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NhomNguoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_NhomNguoiDung.Location = new System.Drawing.Point(3, 22);
            this.dgv_NhomNguoiDung.Name = "dgv_NhomNguoiDung";
            this.dgv_NhomNguoiDung.Size = new System.Drawing.Size(568, 410);
            this.dgv_NhomNguoiDung.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 161);
            this.label5.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Ghi chú";
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(123, 145);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(358, 111);
            this.txtGhiChu.TabIndex = 5;
            // 
            // cbbDanhSachManHinh
            // 
            this.cbbDanhSachManHinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDanhSachManHinh.FormattingEnabled = true;
            this.cbbDanhSachManHinh.Location = new System.Drawing.Point(810, 161);
            this.cbbDanhSachManHinh.Margin = new System.Windows.Forms.Padding(5);
            this.cbbDanhSachManHinh.Name = "cbbDanhSachManHinh";
            this.cbbDanhSachManHinh.Size = new System.Drawing.Size(330, 28);
            this.cbbDanhSachManHinh.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(628, 164);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(173, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Danh sách màn hình";
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.BackColor = System.Drawing.Color.Navy;
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLamMoi.ForeColor = System.Drawing.Color.White;
            this.btnLamMoi.Image = global::GUI.Properties.Resources.icons8_cancel_35;
            this.btnLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLamMoi.Location = new System.Drawing.Point(391, 298);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(118, 31);
            this.btnLamMoi.TabIndex = 8;
            this.btnLamMoi.Text = "Làm mới";
            this.btnLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnSuaNND
            // 
            this.btnSuaNND.BackColor = System.Drawing.Color.Navy;
            this.btnSuaNND.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSuaNND.ForeColor = System.Drawing.Color.White;
            this.btnSuaNND.Image = global::GUI.Properties.Resources._307_3071402_reset_button_png_transparent;
            this.btnSuaNND.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSuaNND.Location = new System.Drawing.Point(262, 298);
            this.btnSuaNND.Name = "btnSuaNND";
            this.btnSuaNND.Size = new System.Drawing.Size(104, 31);
            this.btnSuaNND.TabIndex = 8;
            this.btnSuaNND.Text = "Sửa";
            this.btnSuaNND.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSuaNND.UseVisualStyleBackColor = false;
            // 
            // btnXoaManHinh
            // 
            this.btnXoaManHinh.BackColor = System.Drawing.Color.Navy;
            this.btnXoaManHinh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoaManHinh.ForeColor = System.Drawing.Color.White;
            this.btnXoaManHinh.Image = global::GUI.Properties.Resources.icons8_delete_35;
            this.btnXoaManHinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaManHinh.Location = new System.Drawing.Point(756, 248);
            this.btnXoaManHinh.Name = "btnXoaManHinh";
            this.btnXoaManHinh.Size = new System.Drawing.Size(104, 31);
            this.btnXoaManHinh.TabIndex = 8;
            this.btnXoaManHinh.Text = "Xóa";
            this.btnXoaManHinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaManHinh.UseVisualStyleBackColor = false;
            // 
            // btnThemManHinh
            // 
            this.btnThemManHinh.BackColor = System.Drawing.Color.Navy;
            this.btnThemManHinh.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThemManHinh.ForeColor = System.Drawing.Color.White;
            this.btnThemManHinh.Image = global::GUI.Properties.Resources.icons8_add_35;
            this.btnThemManHinh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemManHinh.Location = new System.Drawing.Point(634, 248);
            this.btnThemManHinh.Name = "btnThemManHinh";
            this.btnThemManHinh.Size = new System.Drawing.Size(104, 31);
            this.btnThemManHinh.TabIndex = 8;
            this.btnThemManHinh.Text = "Thêm";
            this.btnThemManHinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemManHinh.UseVisualStyleBackColor = false;
            // 
            // btnXoaNND
            // 
            this.btnXoaNND.BackColor = System.Drawing.Color.Navy;
            this.btnXoaNND.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoaNND.ForeColor = System.Drawing.Color.White;
            this.btnXoaNND.Image = global::GUI.Properties.Resources.icons8_delete_35;
            this.btnXoaNND.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaNND.Location = new System.Drawing.Point(140, 298);
            this.btnXoaNND.Name = "btnXoaNND";
            this.btnXoaNND.Size = new System.Drawing.Size(104, 31);
            this.btnXoaNND.TabIndex = 8;
            this.btnXoaNND.Text = "Xóa";
            this.btnXoaNND.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaNND.UseVisualStyleBackColor = false;
            // 
            // btnThemNND
            // 
            this.btnThemNND.BackColor = System.Drawing.Color.Navy;
            this.btnThemNND.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThemNND.ForeColor = System.Drawing.Color.White;
            this.btnThemNND.Image = global::GUI.Properties.Resources.icons8_add_35;
            this.btnThemNND.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemNND.Location = new System.Drawing.Point(18, 298);
            this.btnThemNND.Name = "btnThemNND";
            this.btnThemNND.Size = new System.Drawing.Size(104, 31);
            this.btnThemNND.TabIndex = 8;
            this.btnThemNND.Text = "Thêm";
            this.btnThemNND.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemNND.UseVisualStyleBackColor = false;
            // 
            // frmNhomNguoiDung_ManHinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 868);
            this.Controls.Add(this.btnLamMoi);
            this.Controls.Add(this.btnSuaNND);
            this.Controls.Add(this.btnXoaManHinh);
            this.Controls.Add(this.btnThemManHinh);
            this.Controls.Add(this.btnXoaNND);
            this.Controls.Add(this.btnThemNND);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtTenNhomNguoiDung);
            this.Controls.Add(this.txtMaNhomNguoiDung);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtGhiChu);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbbDanhSachManHinh);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmNhomNguoiDung_ManHinh";
            this.Text = "Phân màn hình cho nhóm người dùng";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvManHinhNhomNguoiDung)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhomNguoiDung)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvManHinhNhomNguoiDung;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtMaNhomNguoiDung;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTenNhomNguoiDung;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_NhomNguoiDung;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnThemNND;
        private System.Windows.Forms.Button btnXoaNND;
        private System.Windows.Forms.Button btnSuaNND;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.ComboBox cbbDanhSachManHinh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnThemManHinh;
        private System.Windows.Forms.Button btnXoaManHinh;
    }
}