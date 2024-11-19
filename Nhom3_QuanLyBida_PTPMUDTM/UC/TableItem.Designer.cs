namespace UC
{
    partial class TableItem
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

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label_tenBan = new System.Windows.Forms.Label();
            this.anhBanBida = new System.Windows.Forms.PictureBox();
            this.labelLoaiBan = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.anhBanBida)).BeginInit();
            this.SuspendLayout();
            // 
            // label_tenBan
            // 
            this.label_tenBan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label_tenBan.AutoSize = true;
            this.label_tenBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_tenBan.ForeColor = System.Drawing.Color.Navy;
            this.label_tenBan.Location = new System.Drawing.Point(31, 178);
            this.label_tenBan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label_tenBan.Name = "label_tenBan";
            this.label_tenBan.Size = new System.Drawing.Size(82, 13);
            this.label_tenBan.TabIndex = 3;
            this.label_tenBan.Text = "Tên bàn chơi";
            // 
            // anhBanBida
            // 
            this.anhBanBida.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.anhBanBida.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.anhBanBida.Image = global::UC.Properties.Resources.banBidaTrong;
            this.anhBanBida.Location = new System.Drawing.Point(17, 9);
            this.anhBanBida.Margin = new System.Windows.Forms.Padding(2);
            this.anhBanBida.Name = "anhBanBida";
            this.anhBanBida.Size = new System.Drawing.Size(115, 157);
            this.anhBanBida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.anhBanBida.TabIndex = 2;
            this.anhBanBida.TabStop = false;
            // 
            // labelLoaiBan
            // 
            this.labelLoaiBan.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelLoaiBan.AutoSize = true;
            this.labelLoaiBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLoaiBan.ForeColor = System.Drawing.Color.Navy;
            this.labelLoaiBan.Location = new System.Drawing.Point(31, 197);
            this.labelLoaiBan.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelLoaiBan.Name = "labelLoaiBan";
            this.labelLoaiBan.Size = new System.Drawing.Size(56, 13);
            this.labelLoaiBan.TabIndex = 3;
            this.labelLoaiBan.Text = "Loại bàn";
            // 
            // TableItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelLoaiBan);
            this.Controls.Add(this.label_tenBan);
            this.Controls.Add(this.anhBanBida);
            this.Name = "TableItem";
            this.Size = new System.Drawing.Size(149, 217);
            ((System.ComponentModel.ISupportInitialize)(this.anhBanBida)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_tenBan;
        private System.Windows.Forms.PictureBox anhBanBida;
        private System.Windows.Forms.Label labelLoaiBan;
    }
}
