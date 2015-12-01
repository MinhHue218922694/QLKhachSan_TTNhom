namespace QUANLYQN
{
    partial class frmMainForm
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
            this.mnuHeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDangNhap = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThayDoiMatKhau = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPhanHe = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuNhapThongTinQN = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTheoDoiThongTin = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTheoDoiQuanNhan = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.lịchSửCấpBậcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửChứcVụToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửKhenThưởngToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửKỷLuậtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lịchSửTrườngLớpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuDanhMuc = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuThongKeBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuCauHinh = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuQuanTri = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTroGiup = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuHeThong,
            this.mnuPhanHe,
            this.mnuDanhMuc,
            this.mnuThongKeBaoCao,
            this.mnuCauHinh,
            this.mnuQuanTri,
            this.mnuTroGiup});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(955, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            this.mnuHeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuDangNhap,
            this.mnuThayDoiMatKhau});
            this.mnuHeThong.Name = "mnuHeThong";
            this.mnuHeThong.Size = new System.Drawing.Size(72, 20);
            this.mnuHeThong.Text = "Hệ thống";
            // 
            // mnuDangNhap
            // 
            this.mnuDangNhap.Name = "mnuDangNhap";
            this.mnuDangNhap.Size = new System.Drawing.Size(183, 22);
            this.mnuDangNhap.Text = "Đăng nhập";
            // 
            // mnuThayDoiMatKhau
            // 
            this.mnuThayDoiMatKhau.Name = "mnuThayDoiMatKhau";
            this.mnuThayDoiMatKhau.Size = new System.Drawing.Size(183, 22);
            this.mnuThayDoiMatKhau.Text = "Thay đổi mật khẩu";
            // 
            // mnuPhanHe
            // 
            this.mnuPhanHe.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNhapThongTin,
            this.mnuTheoDoiThongTin});
            this.mnuPhanHe.Name = "mnuPhanHe";
            this.mnuPhanHe.Size = new System.Drawing.Size(68, 20);
            this.mnuPhanHe.Text = "Phân hệ";
            // 
            // mnuNhapThongTin
            // 
            this.mnuNhapThongTin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuNhapThongTinQN,
            this.tìmKiếmToolStripMenuItem});
            this.mnuNhapThongTin.Name = "mnuNhapThongTin";
            this.mnuNhapThongTin.Size = new System.Drawing.Size(179, 22);
            this.mnuNhapThongTin.Text = "Nhập thông tin";
            this.mnuNhapThongTin.Click += new System.EventHandler(this.mnuNhapThongTin_Click);
            // 
            // mnuNhapThongTinQN
            // 
            this.mnuNhapThongTinQN.Name = "mnuNhapThongTinQN";
            this.mnuNhapThongTinQN.Size = new System.Drawing.Size(227, 22);
            this.mnuNhapThongTinQN.Text = "Nhập thông tin Quân nhân";
            this.mnuNhapThongTinQN.Click += new System.EventHandler(this.mnuNhapThongTinQN_Click);
            // 
            // tìmKiếmToolStripMenuItem
            // 
            this.tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            this.tìmKiếmToolStripMenuItem.Size = new System.Drawing.Size(227, 22);
            this.tìmKiếmToolStripMenuItem.Text = "Tìm kiếm";
            this.tìmKiếmToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmToolStripMenuItem_Click);
            // 
            // mnuTheoDoiThongTin
            // 
            this.mnuTheoDoiThongTin.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTheoDoiQuanNhan,
            this.toolStripSeparator1,
            this.lịchSửCấpBậcToolStripMenuItem,
            this.lịchSửChứcVụToolStripMenuItem,
            this.lịchSửKhenThưởngToolStripMenuItem,
            this.lịchSửKỷLuậtToolStripMenuItem,
            this.lịchSửTrườngLớpToolStripMenuItem});
            this.mnuTheoDoiThongTin.Name = "mnuTheoDoiThongTin";
            this.mnuTheoDoiThongTin.Size = new System.Drawing.Size(179, 22);
            this.mnuTheoDoiThongTin.Text = "Theo dõi thông tin";
            // 
            // mnuTheoDoiQuanNhan
            // 
            this.mnuTheoDoiQuanNhan.Name = "mnuTheoDoiQuanNhan";
            this.mnuTheoDoiQuanNhan.Size = new System.Drawing.Size(199, 22);
            this.mnuTheoDoiQuanNhan.Text = "Theo dõi Quân nhân";
            this.mnuTheoDoiQuanNhan.Click += new System.EventHandler(this.mnuTheoDoiQuanNhan_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(196, 6);
            // 
            // lịchSửCấpBậcToolStripMenuItem
            // 
            this.lịchSửCấpBậcToolStripMenuItem.Name = "lịchSửCấpBậcToolStripMenuItem";
            this.lịchSửCấpBậcToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.lịchSửCấpBậcToolStripMenuItem.Text = "Lịch sử cấp bậc";
            // 
            // lịchSửChứcVụToolStripMenuItem
            // 
            this.lịchSửChứcVụToolStripMenuItem.Name = "lịchSửChứcVụToolStripMenuItem";
            this.lịchSửChứcVụToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.lịchSửChứcVụToolStripMenuItem.Text = "Lịch sử chức vụ";
            // 
            // lịchSửKhenThưởngToolStripMenuItem
            // 
            this.lịchSửKhenThưởngToolStripMenuItem.Name = "lịchSửKhenThưởngToolStripMenuItem";
            this.lịchSửKhenThưởngToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.lịchSửKhenThưởngToolStripMenuItem.Text = "Lịch sử khen thưởng";
            // 
            // lịchSửKỷLuậtToolStripMenuItem
            // 
            this.lịchSửKỷLuậtToolStripMenuItem.Name = "lịchSửKỷLuậtToolStripMenuItem";
            this.lịchSửKỷLuậtToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.lịchSửKỷLuậtToolStripMenuItem.Text = "Lịch sử kỷ luật";
            // 
            // lịchSửTrườngLớpToolStripMenuItem
            // 
            this.lịchSửTrườngLớpToolStripMenuItem.Name = "lịchSửTrườngLớpToolStripMenuItem";
            this.lịchSửTrườngLớpToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.lịchSửTrườngLớpToolStripMenuItem.Text = "Lịch sử trường lớp";
            // 
            // mnuDanhMuc
            // 
            this.mnuDanhMuc.Name = "mnuDanhMuc";
            this.mnuDanhMuc.Size = new System.Drawing.Size(79, 20);
            this.mnuDanhMuc.Text = "Danh mục";
            // 
            // mnuThongKeBaoCao
            // 
            this.mnuThongKeBaoCao.Name = "mnuThongKeBaoCao";
            this.mnuThongKeBaoCao.Size = new System.Drawing.Size(128, 20);
            this.mnuThongKeBaoCao.Text = "Thống kê_Báo cáo";
            // 
            // mnuCauHinh
            // 
            this.mnuCauHinh.Name = "mnuCauHinh";
            this.mnuCauHinh.Size = new System.Drawing.Size(71, 20);
            this.mnuCauHinh.Text = "Cấu hình";
            // 
            // mnuQuanTri
            // 
            this.mnuQuanTri.Name = "mnuQuanTri";
            this.mnuQuanTri.Size = new System.Drawing.Size(66, 20);
            this.mnuQuanTri.Text = "Quản trị";
            // 
            // mnuTroGiup
            // 
            this.mnuTroGiup.Name = "mnuTroGiup";
            this.mnuTroGiup.Size = new System.Drawing.Size(68, 20);
            this.mnuTroGiup.Text = "Trợ giúp";
            // 
            // frmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(955, 417);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmMainForm";
            this.Text = "Quản lý học viên Quân sự";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mnuHeThong;
        private System.Windows.Forms.ToolStripMenuItem mnuDangNhap;
        private System.Windows.Forms.ToolStripMenuItem mnuThayDoiMatKhau;
        private System.Windows.Forms.ToolStripMenuItem mnuPhanHe;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapThongTin;
        private System.Windows.Forms.ToolStripMenuItem mnuNhapThongTinQN;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuTheoDoiThongTin;
        private System.Windows.Forms.ToolStripMenuItem mnuTheoDoiQuanNhan;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem lịchSửCấpBậcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửChứcVụToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửKhenThưởngToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửKỷLuậtToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lịchSửTrườngLớpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuDanhMuc;
        private System.Windows.Forms.ToolStripMenuItem mnuThongKeBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mnuCauHinh;
        private System.Windows.Forms.ToolStripMenuItem mnuQuanTri;
        private System.Windows.Forms.ToolStripMenuItem mnuTroGiup;

    }
}