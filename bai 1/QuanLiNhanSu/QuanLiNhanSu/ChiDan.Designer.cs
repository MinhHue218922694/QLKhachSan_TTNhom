namespace QuanLiNhanSu
{
    partial class frmChiDan
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
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Giới thiệu chung");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Đăng Nhập");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Giao diện chính");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Quản lí nhân viên");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Giới thiệu chi tiết", new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode8,
            treeNode9});
            this.trViewGioiThieu = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtGioiThieu = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // trViewGioiThieu
            // 
            this.trViewGioiThieu.Location = new System.Drawing.Point(12, 12);
            this.trViewGioiThieu.Name = "trViewGioiThieu";
            treeNode6.Name = "gtChung";
            treeNode6.Text = "Giới thiệu chung";
            treeNode7.Name = "gtFrmDangNhap";
            treeNode7.Text = "Đăng Nhập";
            treeNode8.Name = "gtfrmMain";
            treeNode8.Text = "Giao diện chính";
            treeNode9.Name = "gtfrmForm1";
            treeNode9.Text = "Quản lí nhân viên";
            treeNode10.Name = "gtChiTiet";
            treeNode10.Text = "Giới thiệu chi tiết";
            this.trViewGioiThieu.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6,
            treeNode10});
            this.trViewGioiThieu.Size = new System.Drawing.Size(142, 482);
            this.trViewGioiThieu.TabIndex = 0;
            this.trViewGioiThieu.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.trViewGioiThieu_AfterSelect);
            this.trViewGioiThieu.Click += new System.EventHandler(this.trViewGioiThieu_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.txtGioiThieu);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(157, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(627, 482);
            this.panel1.TabIndex = 1;
            // 
            // txtGioiThieu
            // 
            this.txtGioiThieu.Location = new System.Drawing.Point(3, 303);
            this.txtGioiThieu.Multiline = true;
            this.txtGioiThieu.Name = "txtGioiThieu";
            this.txtGioiThieu.Size = new System.Drawing.Size(622, 176);
            this.txtGioiThieu.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(3, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(622, 294);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // frmChiDan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(796, 506);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.trViewGioiThieu);
            this.Name = "frmChiDan";
            this.Text = "ChiDan";
            this.Load += new System.EventHandler(this.ChiDan_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView trViewGioiThieu;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtGioiThieu;
    }
}