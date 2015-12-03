namespace QLBMT_TTNhom
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmdangnhap = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmdangxuat = new System.Windows.Forms.ToolStripMenuItem();
            this.thoátToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kếtNốiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmQuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.ngườiDùngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kháchHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhàCungCấpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sảnPhẩmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmThaotac = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.thốngKêToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nhậpHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chiTiếtNhậpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xuấtHàngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chiTiếtXuấtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmhelp = new System.Windows.Forms.ToolStripMenuItem();
            this.hướngDẫnToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.liênHệToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmHeThong,
            this.tsmQuanLy,
            this.tsmThaotac,
            this.tsmhelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(792, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmHeThong
            // 
            this.tsmHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmdangnhap,
            this.tsmdangxuat,
            this.thoátToolStripMenuItem,
            this.kếtNốiToolStripMenuItem});
            this.tsmHeThong.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tsmHeThong.Image = global::QLBMT_TTNhom.Properties.Resources._5946_;
            this.tsmHeThong.Name = "tsmHeThong";
            this.tsmHeThong.Size = new System.Drawing.Size(89, 20);
            this.tsmHeThong.Text = "Hệ Thống";
            // 
            // tsmdangnhap
            // 
            this.tsmdangnhap.Image = global::QLBMT_TTNhom.Properties.Resources._1369568547_103883;
            this.tsmdangnhap.Name = "tsmdangnhap";
            this.tsmdangnhap.Size = new System.Drawing.Size(152, 22);
            this.tsmdangnhap.Text = "Đăng Nhập";
            this.tsmdangnhap.Click += new System.EventHandler(this.đăngNhậpToolStripMenuItem_Click);
            // 
            // tsmdangxuat
            // 
            this.tsmdangxuat.Image = global::QLBMT_TTNhom.Properties.Resources._5649_;
            this.tsmdangxuat.Name = "tsmdangxuat";
            this.tsmdangxuat.Size = new System.Drawing.Size(152, 22);
            this.tsmdangxuat.Text = "Đăng Xuất";
            this.tsmdangxuat.Click += new System.EventHandler(this.đăngXuấtToolStripMenuItem_Click);
            // 
            // thoátToolStripMenuItem
            // 
            this.thoátToolStripMenuItem.Image = global::QLBMT_TTNhom.Properties.Resources.Copy_of_shutdown;
            this.thoátToolStripMenuItem.Name = "thoátToolStripMenuItem";
            this.thoátToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.thoátToolStripMenuItem.Text = "Thoát";
            this.thoátToolStripMenuItem.Click += new System.EventHandler(this.thoátToolStripMenuItem_Click);
            // 
            // kếtNốiToolStripMenuItem
            // 
            this.kếtNốiToolStripMenuItem.Image = global::QLBMT_TTNhom.Properties.Resources.l;
            this.kếtNốiToolStripMenuItem.Name = "kếtNốiToolStripMenuItem";
            this.kếtNốiToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kếtNốiToolStripMenuItem.Text = "Kết Nối";
            this.kếtNốiToolStripMenuItem.Click += new System.EventHandler(this.kếtNốiToolStripMenuItem_Click);
            // 
            // tsmQuanLy
            // 
            this.tsmQuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ngườiDùngToolStripMenuItem,
            this.kháchHàngToolStripMenuItem,
            this.nhàCungCấpToolStripMenuItem,
            this.sảnPhẩmToolStripMenuItem});
            this.tsmQuanLy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tsmQuanLy.Image = global::QLBMT_TTNhom.Properties.Resources.li;
            this.tsmQuanLy.Name = "tsmQuanLy";
            this.tsmQuanLy.Size = new System.Drawing.Size(79, 20);
            this.tsmQuanLy.Text = "Quản Lý";
            // 
            // ngườiDùngToolStripMenuItem
            // 
            this.ngườiDùngToolStripMenuItem.Image = global::QLBMT_TTNhom.Properties.Resources.question;
            this.ngườiDùngToolStripMenuItem.Name = "ngườiDùngToolStripMenuItem";
            this.ngườiDùngToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.ngườiDùngToolStripMenuItem.Text = "Nhân Viên";
            this.ngườiDùngToolStripMenuItem.Click += new System.EventHandler(this.ngườiDùngToolStripMenuItem_Click);
            // 
            // kháchHàngToolStripMenuItem
            // 
            this.kháchHàngToolStripMenuItem.Image = global::QLBMT_TTNhom.Properties.Resources._5839_;
            this.kháchHàngToolStripMenuItem.Name = "kháchHàngToolStripMenuItem";
            this.kháchHàngToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.kháchHàngToolStripMenuItem.Text = "Khách Hàng";
            this.kháchHàngToolStripMenuItem.Click += new System.EventHandler(this.kháchHàngToolStripMenuItem_Click);
            // 
            // nhàCungCấpToolStripMenuItem
            // 
            this.nhàCungCấpToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("nhàCungCấpToolStripMenuItem.Image")));
            this.nhàCungCấpToolStripMenuItem.Name = "nhàCungCấpToolStripMenuItem";
            this.nhàCungCấpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nhàCungCấpToolStripMenuItem.Text = "Nhà Cung Cấp";
            this.nhàCungCấpToolStripMenuItem.Click += new System.EventHandler(this.nhàCungCấpToolStripMenuItem_Click);
            // 
            // sảnPhẩmToolStripMenuItem
            // 
            this.sảnPhẩmToolStripMenuItem.Image = global::QLBMT_TTNhom.Properties.Resources.computerroom1;
            this.sảnPhẩmToolStripMenuItem.Name = "sảnPhẩmToolStripMenuItem";
            this.sảnPhẩmToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.sảnPhẩmToolStripMenuItem.Text = "Sản Phẩm";
            this.sảnPhẩmToolStripMenuItem.Click += new System.EventHandler(this.sảnPhẩmToolStripMenuItem_Click);
            // 
            // tsmThaotac
            // 
            this.tsmThaotac.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tìmKiếmToolStripMenuItem,
            this.thốngKêToolStripMenuItem,
            this.nhậpHàngToolStripMenuItem,
            this.xuấtHàngToolStripMenuItem});
            this.tsmThaotac.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tsmThaotac.Image = global::QLBMT_TTNhom.Properties.Resources._1369568849_17814;
            this.tsmThaotac.Name = "tsmThaotac";
            this.tsmThaotac.Size = new System.Drawing.Size(84, 20);
            this.tsmThaotac.Text = "Thao Tác";
            // 
            // tìmKiếmToolStripMenuItem
            // 
            this.tìmKiếmToolStripMenuItem.Image = global::QLBMT_TTNhom.Properties.Resources.Search1;
            this.tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            this.tìmKiếmToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.tìmKiếmToolStripMenuItem.Text = "Tìm Kiếm";
            this.tìmKiếmToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmToolStripMenuItem_Click);
            // 
            // thốngKêToolStripMenuItem
            // 
            this.thốngKêToolStripMenuItem.Image = global::QLBMT_TTNhom.Properties.Resources._5833_;
            this.thốngKêToolStripMenuItem.Name = "thốngKêToolStripMenuItem";
            this.thốngKêToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.thốngKêToolStripMenuItem.Text = "Thống Kê";
            this.thốngKêToolStripMenuItem.Click += new System.EventHandler(this.thốngKêToolStripMenuItem_Click);
            // 
            // nhậpHàngToolStripMenuItem
            // 
            this.nhậpHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chiTiếtNhậpToolStripMenuItem});
            this.nhậpHàngToolStripMenuItem.Image = global::QLBMT_TTNhom.Properties.Resources.Database_Active;
            this.nhậpHàngToolStripMenuItem.Name = "nhậpHàngToolStripMenuItem";
            this.nhậpHàngToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.nhậpHàngToolStripMenuItem.Text = "Nhập Hàng";
            this.nhậpHàngToolStripMenuItem.Click += new System.EventHandler(this.nhậpHàngToolStripMenuItem_Click);
            // 
            // chiTiếtNhậpToolStripMenuItem
            // 
            this.chiTiếtNhậpToolStripMenuItem.Image = global::QLBMT_TTNhom.Properties.Resources.Database_Active1;
            this.chiTiếtNhậpToolStripMenuItem.Name = "chiTiếtNhậpToolStripMenuItem";
            this.chiTiếtNhậpToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.chiTiếtNhậpToolStripMenuItem.Text = "Chi Tiết Nhập";
            this.chiTiếtNhậpToolStripMenuItem.Click += new System.EventHandler(this.chiTiếtNhậpToolStripMenuItem_Click);
            // 
            // xuấtHàngToolStripMenuItem
            // 
            this.xuấtHàngToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.chiTiếtXuấtToolStripMenuItem});
            this.xuấtHàngToolStripMenuItem.Image = global::QLBMT_TTNhom.Properties.Resources.Database_Inactive;
            this.xuấtHàngToolStripMenuItem.Name = "xuấtHàngToolStripMenuItem";
            this.xuấtHàngToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.xuấtHàngToolStripMenuItem.Text = "Xuất Hàng";
            this.xuấtHàngToolStripMenuItem.Click += new System.EventHandler(this.xuấtHàngToolStripMenuItem_Click);
            // 
            // chiTiếtXuấtToolStripMenuItem
            // 
            this.chiTiếtXuấtToolStripMenuItem.Image = global::QLBMT_TTNhom.Properties.Resources.Database_Inactive;
            this.chiTiếtXuấtToolStripMenuItem.Name = "chiTiếtXuấtToolStripMenuItem";
            this.chiTiếtXuấtToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.chiTiếtXuấtToolStripMenuItem.Text = "Chi Tiết Xuất";
            this.chiTiếtXuấtToolStripMenuItem.Click += new System.EventHandler(this.chiTiếtXuấtToolStripMenuItem_Click);
            // 
            // tsmhelp
            // 
            this.tsmhelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.hướngDẫnToolStripMenuItem,
            this.liênHệToolStripMenuItem});
            this.tsmhelp.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.tsmhelp.Image = global::QLBMT_TTNhom.Properties.Resources.Help;
            this.tsmhelp.Name = "tsmhelp";
            this.tsmhelp.Size = new System.Drawing.Size(61, 20);
            this.tsmhelp.Text = "Help";
            // 
            // hướngDẫnToolStripMenuItem
            // 
            this.hướngDẫnToolStripMenuItem.Image = global::QLBMT_TTNhom.Properties.Resources._1352803981_todo_list_add;
            this.hướngDẫnToolStripMenuItem.Name = "hướngDẫnToolStripMenuItem";
            this.hướngDẫnToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.hướngDẫnToolStripMenuItem.Text = "Hướng Dẫn ";
            // 
            // liênHệToolStripMenuItem
            // 
            this.liênHệToolStripMenuItem.Image = global::QLBMT_TTNhom.Properties.Resources.lienhe;
            this.liênHệToolStripMenuItem.Name = "liênHệToolStripMenuItem";
            this.liênHệToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.liênHệToolStripMenuItem.Text = "Liên Hệ";
            this.liênHệToolStripMenuItem.Click += new System.EventHandler(this.liênHệToolStripMenuItem_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Handwriting", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(212, 406);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(580, 45);
            this.label1.TabIndex = 1;
            this.label1.Text = "WELCOM TO PC 6TEEN SHOP";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(792, 449);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Cửa Hàng Bán Máy Tính_6Teen";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem tsmHeThong;
        private System.Windows.Forms.ToolStripMenuItem tsmdangnhap;
        private System.Windows.Forms.ToolStripMenuItem tsmdangxuat;
        private System.Windows.Forms.ToolStripMenuItem thoátToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kếtNốiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmQuanLy;
        private System.Windows.Forms.ToolStripMenuItem ngườiDùngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kháchHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhàCungCấpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sảnPhẩmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmThaotac;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem thốngKêToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nhậpHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xuấtHàngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmhelp;
        private System.Windows.Forms.ToolStripMenuItem hướngDẫnToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem liênHệToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chiTiếtNhậpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chiTiếtXuấtToolStripMenuItem;
    }
}

