namespace GUI
{
    partial class frmNhanVien_NhomNguoiDung
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
            this.btnXoaNhomNguoiDung = new System.Windows.Forms.Button();
            this.btnThemNhomNguoiDung = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_NhanVien = new System.Windows.Forms.DataGridView();
            this.txtTenNV = new System.Windows.Forms.TextBox();
            this.txtMaNV = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_NND_NV = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbbDanhSachNhomNguoiDung = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhanVien)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NND_NV)).BeginInit();
            this.SuspendLayout();
            // 
            // btnXoaNhomNguoiDung
            // 
            this.btnXoaNhomNguoiDung.BackColor = System.Drawing.Color.Navy;
            this.btnXoaNhomNguoiDung.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoaNhomNguoiDung.ForeColor = System.Drawing.Color.White;
            this.btnXoaNhomNguoiDung.Image = global::GUI.Properties.Resources.icons8_delete_35;
            this.btnXoaNhomNguoiDung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoaNhomNguoiDung.Location = new System.Drawing.Point(833, 269);
            this.btnXoaNhomNguoiDung.Name = "btnXoaNhomNguoiDung";
            this.btnXoaNhomNguoiDung.Size = new System.Drawing.Size(104, 31);
            this.btnXoaNhomNguoiDung.TabIndex = 23;
            this.btnXoaNhomNguoiDung.Text = "Xóa";
            this.btnXoaNhomNguoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnXoaNhomNguoiDung.UseVisualStyleBackColor = false;
            // 
            // btnThemNhomNguoiDung
            // 
            this.btnThemNhomNguoiDung.BackColor = System.Drawing.Color.Navy;
            this.btnThemNhomNguoiDung.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnThemNhomNguoiDung.ForeColor = System.Drawing.Color.White;
            this.btnThemNhomNguoiDung.Image = global::GUI.Properties.Resources.icons8_add_35;
            this.btnThemNhomNguoiDung.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThemNhomNguoiDung.Location = new System.Drawing.Point(711, 269);
            this.btnThemNhomNguoiDung.Name = "btnThemNhomNguoiDung";
            this.btnThemNhomNguoiDung.Size = new System.Drawing.Size(104, 31);
            this.btnThemNhomNguoiDung.TabIndex = 22;
            this.btnThemNhomNguoiDung.Text = "Thêm";
            this.btnThemNhomNguoiDung.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThemNhomNguoiDung.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_NhanVien);
            this.groupBox2.Location = new System.Drawing.Point(89, 240);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(574, 573);
            this.groupBox2.TabIndex = 18;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách nhân viên";
            // 
            // dgv_NhanVien
            // 
            this.dgv_NhanVien.BackgroundColor = System.Drawing.Color.White;
            this.dgv_NhanVien.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NhanVien.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_NhanVien.Location = new System.Drawing.Point(3, 22);
            this.dgv_NhanVien.Name = "dgv_NhanVien";
            this.dgv_NhanVien.Size = new System.Drawing.Size(568, 548);
            this.dgv_NhanVien.TabIndex = 0;
            // 
            // txtTenNV
            // 
            this.txtTenNV.Enabled = false;
            this.txtTenNV.Location = new System.Drawing.Point(283, 145);
            this.txtTenNV.Multiline = true;
            this.txtTenNV.Name = "txtTenNV";
            this.txtTenNV.Size = new System.Drawing.Size(269, 60);
            this.txtTenNV.TabIndex = 17;
            // 
            // txtMaNV
            // 
            this.txtMaNV.Enabled = false;
            this.txtMaNV.Location = new System.Drawing.Point(283, 100);
            this.txtMaNV.Name = "txtMaNV";
            this.txtMaNV.Size = new System.Drawing.Size(269, 26);
            this.txtMaNV.TabIndex = 16;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_NND_NV);
            this.groupBox1.Location = new System.Drawing.Point(703, 339);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(574, 474);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Nhóm người dùng của nhân viên";
            // 
            // dgv_NND_NV
            // 
            this.dgv_NND_NV.BackgroundColor = System.Drawing.Color.White;
            this.dgv_NND_NV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_NND_NV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_NND_NV.Location = new System.Drawing.Point(3, 22);
            this.dgv_NND_NV.Name = "dgv_NND_NV";
            this.dgv_NND_NV.Size = new System.Drawing.Size(568, 449);
            this.dgv_NND_NV.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(707, 130);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(238, 20);
            this.label2.TabIndex = 12;
            this.label2.Text = "Danh sách nhóm người dùng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(85, 148);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(127, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Tên Nhân Viên";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(85, 103);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(121, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Mã Nhân Viên";
            // 
            // cbbDanhSachNhomNguoiDung
            // 
            this.cbbDanhSachNhomNguoiDung.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbbDanhSachNhomNguoiDung.FormattingEnabled = true;
            this.cbbDanhSachNhomNguoiDung.Location = new System.Drawing.Point(711, 177);
            this.cbbDanhSachNhomNguoiDung.Margin = new System.Windows.Forms.Padding(5);
            this.cbbDanhSachNhomNguoiDung.Name = "cbbDanhSachNhomNguoiDung";
            this.cbbDanhSachNhomNguoiDung.Size = new System.Drawing.Size(407, 28);
            this.cbbDanhSachNhomNguoiDung.TabIndex = 9;
            // 
            // frmNhanVien_NhomNguoiDung
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1366, 868);
            this.Controls.Add(this.btnXoaNhomNguoiDung);
            this.Controls.Add(this.btnThemNhomNguoiDung);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtTenNV);
            this.Controls.Add(this.txtMaNV);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbbDanhSachNhomNguoiDung);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 5, 5, 5);
            this.Name = "frmNhanVien_NhomNguoiDung";
            this.Text = "frmNhanVien_NhomNguoiDung";
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NhanVien)).EndInit();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_NND_NV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnXoaNhomNguoiDung;
        private System.Windows.Forms.Button btnThemNhomNguoiDung;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_NhanVien;
        private System.Windows.Forms.TextBox txtTenNV;
        private System.Windows.Forms.TextBox txtMaNV;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_NND_NV;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbbDanhSachNhomNguoiDung;
    }
}