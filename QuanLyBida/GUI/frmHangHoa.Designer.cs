
namespace GUI
{
    partial class frmHangHoa
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
            this.txtGIASP = new System.Windows.Forms.TextBox();
            this.txtTENHH = new System.Windows.Forms.TextBox();
            this.txtMAHH = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbTenLH = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.dtgvTTHH = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnHuyThem = new System.Windows.Forms.Button();
            this.btnLuuDuLieu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTTHH)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnHuyThem);
            this.groupBox1.Controls.Add(this.txtGIASP);
            this.groupBox1.Controls.Add(this.btnLuuDuLieu);
            this.groupBox1.Controls.Add(this.txtTENHH);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.txtMAHH);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.cbTenLH);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Location = new System.Drawing.Point(97, 64);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1322, 275);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN";
            // 
            // txtGIASP
            // 
            this.txtGIASP.Location = new System.Drawing.Point(920, 125);
            this.txtGIASP.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtGIASP.Name = "txtGIASP";
            this.txtGIASP.Size = new System.Drawing.Size(206, 26);
            this.txtGIASP.TabIndex = 19;
            // 
            // txtTENHH
            // 
            this.txtTENHH.Location = new System.Drawing.Point(920, 55);
            this.txtTENHH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTENHH.Name = "txtTENHH";
            this.txtTENHH.Size = new System.Drawing.Size(206, 26);
            this.txtTENHH.TabIndex = 18;
            // 
            // txtMAHH
            // 
            this.txtMAHH.Location = new System.Drawing.Point(331, 50);
            this.txtMAHH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMAHH.Name = "txtMAHH";
            this.txtMAHH.Size = new System.Drawing.Size(206, 26);
            this.txtMAHH.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(763, 60);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(145, 25);
            this.label14.TabIndex = 4;
            this.label14.Text = "Tên hàng hóa :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(846, 128);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(53, 25);
            this.label13.TabIndex = 3;
            this.label13.Text = "Giá :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(178, 55);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = "Mã hàng hóa :";
            // 
            // cbTenLH
            // 
            this.cbTenLH.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTenLH.FormattingEnabled = true;
            this.cbTenLH.Location = new System.Drawing.Point(331, 125);
            this.cbTenLH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbTenLH.Name = "cbTenLH";
            this.cbTenLH.Size = new System.Drawing.Size(206, 33);
            this.cbTenLH.TabIndex = 1;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(178, 129);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(142, 25);
            this.label11.TabIndex = 0;
            this.label11.Text = "Tên loại hàng :";
            // 
            // dtgvTTHH
            // 
            this.dtgvTTHH.AllowUserToAddRows = false;
            this.dtgvTTHH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvTTHH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvTTHH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTTHH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4});
            this.dtgvTTHH.Location = new System.Drawing.Point(97, 374);
            this.dtgvTTHH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgvTTHH.Name = "dtgvTTHH";
            this.dtgvTTHH.RowHeadersWidth = 51;
            this.dtgvTTHH.RowTemplate.Height = 24;
            this.dtgvTTHH.Size = new System.Drawing.Size(1322, 390);
            this.dtgvTTHH.TabIndex = 13;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MALH";
            this.Column1.HeaderText = "Mã Loại Hàng";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MAHH";
            this.Column2.HeaderText = "Mã Hàng Hóa";
            this.Column2.MinimumWidth = 6;
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TENHH";
            this.Column3.HeaderText = "Tên Hàng Hóa";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "GIASP";
            this.Column4.HeaderText = "Giá Sản Phẩm";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // btnHuyThem
            // 
            this.btnHuyThem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnHuyThem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHuyThem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyThem.ForeColor = System.Drawing.Color.White;
            this.btnHuyThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuyThem.Location = new System.Drawing.Point(991, 200);
            this.btnHuyThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuyThem.Name = "btnHuyThem";
            this.btnHuyThem.Size = new System.Drawing.Size(175, 49);
            this.btnHuyThem.TabIndex = 24;
            this.btnHuyThem.Text = "Hủy Thêm";
            this.btnHuyThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHuyThem.UseVisualStyleBackColor = false;
            // 
            // btnLuuDuLieu
            // 
            this.btnLuuDuLieu.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnLuuDuLieu.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLuuDuLieu.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLuuDuLieu.ForeColor = System.Drawing.Color.White;
            this.btnLuuDuLieu.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLuuDuLieu.Location = new System.Drawing.Point(674, 200);
            this.btnLuuDuLieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuuDuLieu.Name = "btnLuuDuLieu";
            this.btnLuuDuLieu.Size = new System.Drawing.Size(175, 49);
            this.btnLuuDuLieu.TabIndex = 25;
            this.btnLuuDuLieu.Text = "Lưu dữ liệu";
            this.btnLuuDuLieu.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnLuuDuLieu.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            this.btnXoa.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnXoa.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnXoa.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoa.ForeColor = System.Drawing.Color.White;
            this.btnXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnXoa.Location = new System.Drawing.Point(357, 200);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(40, 0, 40, 0);
            this.btnXoa.Size = new System.Drawing.Size(175, 49);
            this.btnXoa.TabIndex = 23;
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
            this.btnThem.Location = new System.Drawing.Point(40, 200);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Padding = new System.Windows.Forms.Padding(40, 0, 25, 0);
            this.btnThem.Size = new System.Drawing.Size(175, 49);
            this.btnThem.TabIndex = 22;
            this.btnThem.Tag = "Chưa Click";
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // FormQLHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1502, 872);
            this.Controls.Add(this.dtgvTTHH);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormQLHH";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormQL_HH";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTTHH)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtGIASP;
        private System.Windows.Forms.TextBox txtTENHH;
        private System.Windows.Forms.TextBox txtMAHH;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbTenLH;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dtgvTTHH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Button btnHuyThem;
        private System.Windows.Forms.Button btnLuuDuLieu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
    }
}