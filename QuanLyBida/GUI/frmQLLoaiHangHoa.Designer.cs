
namespace GUI
{
    partial class frmQLLoaiHangHoa
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
            this.dtgvTTLH = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtMoTa = new System.Windows.Forms.TextBox();
            this.txtTENLH = new System.Windows.Forms.TextBox();
            this.txtMALH = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnHuyThem = new System.Windows.Forms.Button();
            this.btnLuuDuLieu = new System.Windows.Forms.Button();
            this.btnXoa = new System.Windows.Forms.Button();
            this.btnThem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTTLH)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgvTTLH
            // 
            this.dtgvTTLH.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgvTTLH.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dtgvTTLH.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvTTLH.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column3,
            this.Column4});
            this.dtgvTTLH.Location = new System.Drawing.Point(73, 344);
            this.dtgvTTLH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dtgvTTLH.Name = "dtgvTTLH";
            this.dtgvTTLH.RowHeadersWidth = 51;
            this.dtgvTTLH.RowTemplate.Height = 24;
            this.dtgvTTLH.Size = new System.Drawing.Size(1322, 390);
            this.dtgvTTLH.TabIndex = 21;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "MALH";
            this.Column1.HeaderText = "Mã Loại Hàng";
            this.Column1.MinimumWidth = 6;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TENLH";
            this.Column3.HeaderText = "Tên Loại Hàng";
            this.Column3.MinimumWidth = 6;
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "MOTA";
            this.Column4.HeaderText = "Mô tả";
            this.Column4.MinimumWidth = 6;
            this.Column4.Name = "Column4";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnHuyThem);
            this.groupBox1.Controls.Add(this.btnLuuDuLieu);
            this.groupBox1.Controls.Add(this.btnXoa);
            this.groupBox1.Controls.Add(this.btnThem);
            this.groupBox1.Controls.Add(this.txtMoTa);
            this.groupBox1.Controls.Add(this.txtTENLH);
            this.groupBox1.Controls.Add(this.txtMALH);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(73, 62);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox1.Size = new System.Drawing.Size(1322, 260);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "THÔNG TIN";
            // 
            // txtMoTa
            // 
            this.txtMoTa.Location = new System.Drawing.Point(357, 122);
            this.txtMoTa.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMoTa.Name = "txtMoTa";
            this.txtMoTa.Size = new System.Drawing.Size(537, 26);
            this.txtMoTa.TabIndex = 19;
            // 
            // txtTENLH
            // 
            this.txtTENLH.Location = new System.Drawing.Point(885, 52);
            this.txtTENLH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtTENLH.Name = "txtTENLH";
            this.txtTENLH.Size = new System.Drawing.Size(206, 26);
            this.txtTENLH.TabIndex = 18;
            // 
            // txtMALH
            // 
            this.txtMALH.Location = new System.Drawing.Point(357, 50);
            this.txtMALH.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtMALH.Name = "txtMALH";
            this.txtMALH.Size = new System.Drawing.Size(206, 26);
            this.txtMALH.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(728, 58);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(142, 25);
            this.label14.TabIndex = 4;
            this.label14.Text = "Tên loại hàng :";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(264, 125);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(72, 25);
            this.label13.TabIndex = 3;
            this.label13.Text = "Mô tả :";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(199, 52);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(140, 25);
            this.label12.TabIndex = 2;
            this.label12.Text = "Mã loại hàng  :";
            // 
            // btnHuyThem
            // 
            this.btnHuyThem.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.btnHuyThem.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnHuyThem.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyThem.ForeColor = System.Drawing.Color.White;
            this.btnHuyThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnHuyThem.Location = new System.Drawing.Point(1049, 180);
            this.btnHuyThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnHuyThem.Name = "btnHuyThem";
            this.btnHuyThem.Size = new System.Drawing.Size(175, 49);
            this.btnHuyThem.TabIndex = 28;
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
            this.btnLuuDuLieu.Location = new System.Drawing.Point(732, 180);
            this.btnLuuDuLieu.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnLuuDuLieu.Name = "btnLuuDuLieu";
            this.btnLuuDuLieu.Size = new System.Drawing.Size(175, 49);
            this.btnLuuDuLieu.TabIndex = 29;
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
            this.btnXoa.Location = new System.Drawing.Point(415, 180);
            this.btnXoa.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnXoa.Name = "btnXoa";
            this.btnXoa.Padding = new System.Windows.Forms.Padding(40, 0, 40, 0);
            this.btnXoa.Size = new System.Drawing.Size(175, 49);
            this.btnXoa.TabIndex = 27;
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
            this.btnThem.Location = new System.Drawing.Point(98, 180);
            this.btnThem.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnThem.Name = "btnThem";
            this.btnThem.Padding = new System.Windows.Forms.Padding(40, 0, 25, 0);
            this.btnThem.Size = new System.Drawing.Size(175, 49);
            this.btnThem.TabIndex = 26;
            this.btnThem.Tag = "Chưa Click";
            this.btnThem.Text = "Thêm";
            this.btnThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnThem.UseVisualStyleBackColor = false;
            // 
            // FormQLLLOAIHH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(1467, 768);
            this.Controls.Add(this.dtgvTTLH);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormQLLLOAIHH";
            this.Text = "FormQLLLOAIHH";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvTTLH)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgvTTLH;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtMoTa;
        private System.Windows.Forms.TextBox txtTENLH;
        private System.Windows.Forms.TextBox txtMALH;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnHuyThem;
        private System.Windows.Forms.Button btnLuuDuLieu;
        private System.Windows.Forms.Button btnXoa;
        private System.Windows.Forms.Button btnThem;
    }
}