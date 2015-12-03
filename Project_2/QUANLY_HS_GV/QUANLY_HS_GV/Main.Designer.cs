namespace QUANLY_HS_GV
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
            this.mnuHocsinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuGiaovien = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.btnthoat = new System.Windows.Forms.Button();
            this.btngiaovien = new System.Windows.Forms.Button();
            this.btnhuongdan = new System.Windows.Forms.Button();
            this.btnhocsinh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // mnuHocsinh
            // 
            this.mnuHocsinh.Name = "mnuHocsinh";
            this.mnuHocsinh.Size = new System.Drawing.Size(32, 19);
            // 
            // mnuGiaovien
            // 
            this.mnuGiaovien.Name = "mnuGiaovien";
            this.mnuGiaovien.Size = new System.Drawing.Size(32, 19);
            // 
            // mnuThoat
            // 
            this.mnuThoat.Name = "mnuThoat";
            this.mnuThoat.Size = new System.Drawing.Size(32, 19);
            // 
            // btnthoat
            // 
            this.btnthoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnthoat.ForeColor = System.Drawing.Color.Red;
            this.btnthoat.Location = new System.Drawing.Point(413, 239);
            this.btnthoat.Name = "btnthoat";
            this.btnthoat.Size = new System.Drawing.Size(84, 57);
            this.btnthoat.TabIndex = 1;
            this.btnthoat.Text = "Thoát";
            this.btnthoat.UseVisualStyleBackColor = true;
            this.btnthoat.Click += new System.EventHandler(this.btnthoat_Click);
            // 
            // btngiaovien
            // 
            this.btngiaovien.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btngiaovien.ForeColor = System.Drawing.Color.Blue;
            this.btngiaovien.Location = new System.Drawing.Point(413, 92);
            this.btngiaovien.Name = "btngiaovien";
            this.btngiaovien.Size = new System.Drawing.Size(84, 57);
            this.btngiaovien.TabIndex = 2;
            this.btngiaovien.Text = "Giáo Viên";
            this.btngiaovien.UseVisualStyleBackColor = true;
            this.btngiaovien.Click += new System.EventHandler(this.btngiaovien_Click);
            // 
            // btnhuongdan
            // 
            this.btnhuongdan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhuongdan.ForeColor = System.Drawing.Color.Blue;
            this.btnhuongdan.Location = new System.Drawing.Point(413, 167);
            this.btnhuongdan.Name = "btnhuongdan";
            this.btnhuongdan.Size = new System.Drawing.Size(84, 57);
            this.btnhuongdan.TabIndex = 3;
            this.btnhuongdan.Text = "Hướng dẫn";
            this.btnhuongdan.UseVisualStyleBackColor = true;
            this.btnhuongdan.Click += new System.EventHandler(this.btnhuongdan_Click);
            // 
            // btnhocsinh
            // 
            this.btnhocsinh.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnhocsinh.ForeColor = System.Drawing.Color.Blue;
            this.btnhocsinh.Location = new System.Drawing.Point(413, 12);
            this.btnhocsinh.Name = "btnhocsinh";
            this.btnhocsinh.Size = new System.Drawing.Size(84, 57);
            this.btnhocsinh.TabIndex = 4;
            this.btnhocsinh.Text = "Học Sinh";
            this.btnhocsinh.UseVisualStyleBackColor = true;
            this.btnhocsinh.Click += new System.EventHandler(this.btnhocsinh_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QUANLY_HS_GV.Properties.Resources.GD;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(509, 308);
            this.Controls.Add(this.btnhocsinh);
            this.Controls.Add(this.btnhuongdan);
            this.Controls.Add(this.btngiaovien);
            this.Controls.Add(this.btnthoat);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Phần mềm quản lý học sinh, giáo viên THPT";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripMenuItem mnuHocsinh;
        private System.Windows.Forms.ToolStripMenuItem mnuGiaovien;
        private System.Windows.Forms.ToolStripMenuItem mnuThoat;
        private System.Windows.Forms.Button btnthoat;
        private System.Windows.Forms.Button btngiaovien;
        private System.Windows.Forms.Button btnhuongdan;
        private System.Windows.Forms.Button btnhocsinh;
    }
}

