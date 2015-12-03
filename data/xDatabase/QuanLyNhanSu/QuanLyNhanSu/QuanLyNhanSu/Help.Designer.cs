namespace QuanLyNhanSu
{
    partial class Help
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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Thêm");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Sửa");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Xóa");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Nhân Viên", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3});
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Thêm");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Sửa");
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Xóa");
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("Phòng Ban", new System.Windows.Forms.TreeNode[] {
            treeNode5,
            treeNode6,
            treeNode7});
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Thêm");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Thân Nhân", new System.Windows.Forms.TreeNode[] {
            treeNode9});
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(12, 12);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "ThemNhanVien";
            treeNode1.Text = "Thêm";
            treeNode2.Name = "SuaNhanVien";
            treeNode2.Text = "Sửa";
            treeNode3.Name = "XoaNhanVien";
            treeNode3.Text = "Xóa";
            treeNode4.Name = "Node0";
            treeNode4.Text = "Nhân Viên";
            treeNode5.Name = "ThemPhongBan";
            treeNode5.Text = "Thêm";
            treeNode6.Name = "SuaPhongBan";
            treeNode6.Text = "Sửa";
            treeNode7.Name = "XoaPhongBan";
            treeNode7.Text = "Xóa";
            treeNode8.Name = "Node1";
            treeNode8.Text = "Phòng Ban";
            treeNode9.Name = "ThemThanNhan";
            treeNode9.Text = "Thêm";
            treeNode10.Name = "Node2";
            treeNode10.Text = "Thân Nhân";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode8,
            treeNode10});
            this.treeView1.Size = new System.Drawing.Size(130, 300);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(148, 12);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(404, 300);
            this.webBrowser1.TabIndex = 1;
            // 
            // Help
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(593, 394);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.treeView1);
            this.Name = "Help";
            this.Text = "Help";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.WebBrowser webBrowser1;
    }
}