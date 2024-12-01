namespace GUI
{
    partial class frmChuyenBan
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
            this.btnChuyenDen = new System.Windows.Forms.Button();
            this.dtgvChuyenBan = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChuyenBan)).BeginInit();
            this.SuspendLayout();
            // 
            // btnChuyenDen
            // 
            this.btnChuyenDen.BackColor = System.Drawing.Color.Navy;
            this.btnChuyenDen.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnChuyenDen.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnChuyenDen.ForeColor = System.Drawing.Color.White;
            this.btnChuyenDen.Location = new System.Drawing.Point(0, 377);
            this.btnChuyenDen.Name = "btnChuyenDen";
            this.btnChuyenDen.Size = new System.Drawing.Size(800, 73);
            this.btnChuyenDen.TabIndex = 3;
            this.btnChuyenDen.Text = "Chuyển Đến";
            this.btnChuyenDen.UseVisualStyleBackColor = false;
            // 
            // dtgvChuyenBan
            // 
            this.dtgvChuyenBan.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgvChuyenBan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgvChuyenBan.Location = new System.Drawing.Point(0, 0);
            this.dtgvChuyenBan.Name = "dtgvChuyenBan";
            this.dtgvChuyenBan.Size = new System.Drawing.Size(800, 450);
            this.dtgvChuyenBan.TabIndex = 2;
            // 
            // frmChuyenBan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnChuyenDen);
            this.Controls.Add(this.dtgvChuyenBan);
            this.Name = "frmChuyenBan";
            this.Text = "frmChuyenBan";
            ((System.ComponentModel.ISupportInitialize)(this.dtgvChuyenBan)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnChuyenDen;
        private System.Windows.Forms.DataGridView dtgvChuyenBan;
    }
}