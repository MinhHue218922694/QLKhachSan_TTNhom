namespace QLPhongKS
{
    partial class frmMenu
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.phòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửDụngDịchVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thêmDịchVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaThôngTinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thuêPhòngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quảnLíThiếtBịToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.phòngToolStripMenuItem,
            this.sửDụngDịchVụToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.thuêPhòngToolStripMenuItem,
            this.quảnLíThiếtBịToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(634, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // phòngToolStripMenuItem
            // 
            this.phòngToolStripMenuItem.Name = "phòngToolStripMenuItem";
            this.phòngToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.phòngToolStripMenuItem.Text = "Phòng";
            this.phòngToolStripMenuItem.Click += new System.EventHandler(this.phòngToolStripMenuItem_Click);
            // 
            // sửDụngDịchVụToolStripMenuItem
            // 
            this.sửDụngDịchVụToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.thêmDịchVụToolStripMenuItem});
            this.sửDụngDịchVụToolStripMenuItem.Name = "sửDụngDịchVụToolStripMenuItem";
            this.sửDụngDịchVụToolStripMenuItem.Size = new System.Drawing.Size(105, 20);
            this.sửDụngDịchVụToolStripMenuItem.Text = "Sử dụng dịch vụ";
            this.sửDụngDịchVụToolStripMenuItem.Click += new System.EventHandler(this.sửDụngDịchVụToolStripMenuItem_Click);
            // 
            // thêmDịchVụToolStripMenuItem
            // 
            this.thêmDịchVụToolStripMenuItem.Name = "thêmDịchVụToolStripMenuItem";
            this.thêmDịchVụToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.thêmDịchVụToolStripMenuItem.Text = "Thêm dịch vụ";
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sửaThôngTinToolStripMenuItem});
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(82, 20);
            this.kháchHàngToolStripMenuItem.Text = "Khách hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // sửaThôngTinToolStripMenuItem
            // 
            this.sửaThôngTinToolStripMenuItem.Name = "sửaThôngTinToolStripMenuItem";
            this.sửaThôngTinToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.sửaThôngTinToolStripMenuItem.Text = "Sửa thông tin";
            // 
            // thuêPhòngToolStripMenuItem
            // 
            this.thuêPhòngToolStripMenuItem.Name = "thuêPhòngToolStripMenuItem";
            this.thuêPhòngToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.thuêPhòngToolStripMenuItem.Text = "Thuê Phòng";
            this.thuêPhòngToolStripMenuItem.Click += new System.EventHandler(this.thuêPhòngToolStripMenuItem_Click);
            // 
            // quảnLíThiếtBịToolStripMenuItem
            // 
            this.quảnLíThiếtBịToolStripMenuItem.Name = "quảnLíThiếtBịToolStripMenuItem";
            this.quảnLíThiếtBịToolStripMenuItem.Size = new System.Drawing.Size(97, 20);
            this.quảnLíThiếtBịToolStripMenuItem.Text = "Quản lí thiết bị";
            this.quảnLíThiếtBịToolStripMenuItem.Click += new System.EventHandler(this.quảnLíThiếtBịToolStripMenuItem_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(634, 320);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmMenu";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem phòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửDụngDịchVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thêmDịchVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaThôngTinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thuêPhòngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quảnLíThiếtBịToolStripMenuItem;
    }
}

