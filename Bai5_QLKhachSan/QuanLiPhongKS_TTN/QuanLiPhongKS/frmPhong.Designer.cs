namespace QLPhongKS
{
    partial class frmPhong
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.themToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sửaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.xóaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tìmKiếmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.backToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cbxHienTrang = new System.Windows.Forms.ComboBox();
            this.cbxTinhTrang = new System.Windows.Forms.ComboBox();
            this.cbxMaLPhong = new System.Windows.Forms.ComboBox();
            this.cbxIDPhong = new System.Windows.Forms.ComboBox();
            this.txtSoDT = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblHienTrang = new System.Windows.Forms.Label();
            this.lblTinhTrang = new System.Windows.Forms.Label();
            this.lblMaPLoai = new System.Windows.Forms.Label();
            this.lblIDPhong = new System.Windows.Forms.Label();
            this.dgvPhong = new System.Windows.Forms.DataGridView();
            this.grbChon = new System.Windows.Forms.GroupBox();
            this.bntSearch = new System.Windows.Forms.Button();
            this.rdbHientrang = new System.Windows.Forms.RadioButton();
            this.rdbtinhtrang = new System.Windows.Forms.RadioButton();
            this.rdbLPhong = new System.Windows.Forms.RadioButton();
            this.rdbPhong = new System.Windows.Forms.RadioButton();
            this.bntSave = new System.Windows.Forms.Button();
            this.lblBaoLoi = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).BeginInit();
            this.grbChon.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.themToolStripMenuItem,
            this.sửaToolStripMenuItem,
            this.xóaToolStripMenuItem,
            this.tìmKiếmToolStripMenuItem,
            this.backToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(728, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // themToolStripMenuItem
            // 
            this.themToolStripMenuItem.Name = "themToolStripMenuItem";
            this.themToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.themToolStripMenuItem.Text = "Thêm";
            // 
            // sửaToolStripMenuItem
            // 
            this.sửaToolStripMenuItem.Name = "sửaToolStripMenuItem";
            this.sửaToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
            this.sửaToolStripMenuItem.Text = "Sửa";
            this.sửaToolStripMenuItem.Click += new System.EventHandler(this.sửaToolStripMenuItem_Click);
            // 
            // xóaToolStripMenuItem
            // 
            this.xóaToolStripMenuItem.Name = "xóaToolStripMenuItem";
            this.xóaToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.xóaToolStripMenuItem.Text = "Xóa";
            this.xóaToolStripMenuItem.Click += new System.EventHandler(this.xóaToolStripMenuItem_Click);
            // 
            // tìmKiếmToolStripMenuItem
            // 
            this.tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            this.tìmKiếmToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.tìmKiếmToolStripMenuItem.Text = "Tìm Kiếm";
            this.tìmKiếmToolStripMenuItem.Click += new System.EventHandler(this.tìmKiếmToolStripMenuItem_Click);
            // 
            // backToolStripMenuItem
            // 
            this.backToolStripMenuItem.Name = "backToolStripMenuItem";
            this.backToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.backToolStripMenuItem.Text = "Back";
            this.backToolStripMenuItem.Click += new System.EventHandler(this.backToolStripMenuItem_Click);
            // 
            // cbxHienTrang
            // 
            this.cbxHienTrang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxHienTrang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxHienTrang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxHienTrang.FormattingEnabled = true;
            this.cbxHienTrang.Items.AddRange(new object[] {
            "Đã thuê",
            "Chưa thuê"});
            this.cbxHienTrang.Location = new System.Drawing.Point(351, 43);
            this.cbxHienTrang.Name = "cbxHienTrang";
            this.cbxHienTrang.Size = new System.Drawing.Size(121, 23);
            this.cbxHienTrang.TabIndex = 40;
            // 
            // cbxTinhTrang
            // 
            this.cbxTinhTrang.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxTinhTrang.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxTinhTrang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxTinhTrang.FormattingEnabled = true;
            this.cbxTinhTrang.Items.AddRange(new object[] {
            "Tốt",
            "Không đảm bảo"});
            this.cbxTinhTrang.Location = new System.Drawing.Point(351, 76);
            this.cbxTinhTrang.Name = "cbxTinhTrang";
            this.cbxTinhTrang.Size = new System.Drawing.Size(121, 23);
            this.cbxTinhTrang.TabIndex = 39;
            // 
            // cbxMaLPhong
            // 
            this.cbxMaLPhong.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxMaLPhong.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMaLPhong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMaLPhong.FormattingEnabled = true;
            this.cbxMaLPhong.Location = new System.Drawing.Point(111, 73);
            this.cbxMaLPhong.Name = "cbxMaLPhong";
            this.cbxMaLPhong.Size = new System.Drawing.Size(121, 23);
            this.cbxMaLPhong.TabIndex = 38;
            // 
            // cbxIDPhong
            // 
            this.cbxIDPhong.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxIDPhong.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxIDPhong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxIDPhong.FormattingEnabled = true;
            this.cbxIDPhong.Location = new System.Drawing.Point(111, 43);
            this.cbxIDPhong.Name = "cbxIDPhong";
            this.cbxIDPhong.Size = new System.Drawing.Size(121, 23);
            this.cbxIDPhong.TabIndex = 37;
            // 
            // txtSoDT
            // 
            this.txtSoDT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSoDT.Location = new System.Drawing.Point(111, 102);
            this.txtSoDT.Name = "txtSoDT";
            this.txtSoDT.Size = new System.Drawing.Size(128, 22);
            this.txtSoDT.TabIndex = 31;
            this.txtSoDT.TextChanged += new System.EventHandler(this.txtSoDT_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 15);
            this.label1.TabIndex = 36;
            this.label1.Text = "Số Điện Thoại";
            // 
            // lblHienTrang
            // 
            this.lblHienTrang.AutoSize = true;
            this.lblHienTrang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHienTrang.Location = new System.Drawing.Point(264, 48);
            this.lblHienTrang.Name = "lblHienTrang";
            this.lblHienTrang.Size = new System.Drawing.Size(69, 15);
            this.lblHienTrang.TabIndex = 35;
            this.lblHienTrang.Text = "Hiện Trạng";
            // 
            // lblTinhTrang
            // 
            this.lblTinhTrang.AutoSize = true;
            this.lblTinhTrang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTinhTrang.Location = new System.Drawing.Point(264, 79);
            this.lblTinhTrang.Name = "lblTinhTrang";
            this.lblTinhTrang.Size = new System.Drawing.Size(69, 15);
            this.lblTinhTrang.TabIndex = 34;
            this.lblTinhTrang.Text = "Tình Trạng";
            // 
            // lblMaPLoai
            // 
            this.lblMaPLoai.AutoSize = true;
            this.lblMaPLoai.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaPLoai.Location = new System.Drawing.Point(12, 76);
            this.lblMaPLoai.Name = "lblMaPLoai";
            this.lblMaPLoai.Size = new System.Drawing.Size(89, 15);
            this.lblMaPLoai.TabIndex = 33;
            this.lblMaPLoai.Text = "Mã Loại Phòng";
            // 
            // lblIDPhong
            // 
            this.lblIDPhong.AutoSize = true;
            this.lblIDPhong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDPhong.Location = new System.Drawing.Point(12, 46);
            this.lblIDPhong.Name = "lblIDPhong";
            this.lblIDPhong.Size = new System.Drawing.Size(62, 15);
            this.lblIDPhong.TabIndex = 32;
            this.lblIDPhong.Text = "ID_Phòng";
            // 
            // dgvPhong
            // 
            this.dgvPhong.AllowUserToAddRows = false;
            this.dgvPhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPhong.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPhong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvPhong.Location = new System.Drawing.Point(0, 192);
            this.dgvPhong.Name = "dgvPhong";
            this.dgvPhong.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPhong.Size = new System.Drawing.Size(728, 201);
            this.dgvPhong.TabIndex = 41;
            this.dgvPhong.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPhong_RowEnter);
            // 
            // grbChon
            // 
            this.grbChon.Controls.Add(this.bntSearch);
            this.grbChon.Controls.Add(this.rdbHientrang);
            this.grbChon.Controls.Add(this.rdbtinhtrang);
            this.grbChon.Controls.Add(this.rdbLPhong);
            this.grbChon.Controls.Add(this.rdbPhong);
            this.grbChon.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbChon.Location = new System.Drawing.Point(523, 27);
            this.grbChon.Name = "grbChon";
            this.grbChon.Size = new System.Drawing.Size(171, 159);
            this.grbChon.TabIndex = 42;
            this.grbChon.TabStop = false;
            this.grbChon.Text = "Tìm kiếm";
            this.grbChon.Visible = false;
            // 
            // bntSearch
            // 
            this.bntSearch.Location = new System.Drawing.Point(34, 122);
            this.bntSearch.Name = "bntSearch";
            this.bntSearch.Size = new System.Drawing.Size(75, 23);
            this.bntSearch.TabIndex = 29;
            this.bntSearch.Text = "Search";
            this.bntSearch.UseVisualStyleBackColor = true;
            this.bntSearch.Click += new System.EventHandler(this.bntSearch_Click);
            // 
            // rdbHientrang
            // 
            this.rdbHientrang.AutoSize = true;
            this.rdbHientrang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbHientrang.Location = new System.Drawing.Point(11, 97);
            this.rdbHientrang.Name = "rdbHientrang";
            this.rdbHientrang.Size = new System.Drawing.Size(117, 19);
            this.rdbHientrang.TabIndex = 28;
            this.rdbHientrang.TabStop = true;
            this.rdbHientrang.Text = "Theo Hiện Trạng";
            this.rdbHientrang.UseVisualStyleBackColor = true;
            this.rdbHientrang.CheckedChanged += new System.EventHandler(this.rdbHientrang_CheckedChanged);
            // 
            // rdbtinhtrang
            // 
            this.rdbtinhtrang.AutoSize = true;
            this.rdbtinhtrang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtinhtrang.Location = new System.Drawing.Point(11, 72);
            this.rdbtinhtrang.Name = "rdbtinhtrang";
            this.rdbtinhtrang.Size = new System.Drawing.Size(117, 19);
            this.rdbtinhtrang.TabIndex = 27;
            this.rdbtinhtrang.TabStop = true;
            this.rdbtinhtrang.Text = "Theo Tình Trạng";
            this.rdbtinhtrang.UseVisualStyleBackColor = true;
            this.rdbtinhtrang.CheckedChanged += new System.EventHandler(this.rdbtinhtrang_CheckedChanged);
            // 
            // rdbLPhong
            // 
            this.rdbLPhong.AutoSize = true;
            this.rdbLPhong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbLPhong.Location = new System.Drawing.Point(11, 45);
            this.rdbLPhong.Name = "rdbLPhong";
            this.rdbLPhong.Size = new System.Drawing.Size(98, 19);
            this.rdbLPhong.TabIndex = 1;
            this.rdbLPhong.TabStop = true;
            this.rdbLPhong.Text = "Theo LPhong";
            this.rdbLPhong.UseVisualStyleBackColor = true;
            this.rdbLPhong.CheckedChanged += new System.EventHandler(this.rdbLPhong_CheckedChanged);
            // 
            // rdbPhong
            // 
            this.rdbPhong.AutoSize = true;
            this.rdbPhong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPhong.Location = new System.Drawing.Point(11, 20);
            this.rdbPhong.Name = "rdbPhong";
            this.rdbPhong.Size = new System.Drawing.Size(90, 19);
            this.rdbPhong.TabIndex = 0;
            this.rdbPhong.TabStop = true;
            this.rdbPhong.Text = "Theo Phòng";
            this.rdbPhong.UseVisualStyleBackColor = true;
            this.rdbPhong.CheckedChanged += new System.EventHandler(this.rdbPhong_CheckedChanged);
            // 
            // bntSave
            // 
            this.bntSave.Location = new System.Drawing.Point(267, 114);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(75, 38);
            this.bntSave.TabIndex = 43;
            this.bntSave.Text = "Save";
            this.bntSave.UseVisualStyleBackColor = true;
            this.bntSave.Click += new System.EventHandler(this.bntSave_Click_1);
            // 
            // lblBaoLoi
            // 
            this.lblBaoLoi.AutoSize = true;
            this.lblBaoLoi.BackColor = System.Drawing.Color.White;
            this.lblBaoLoi.ForeColor = System.Drawing.Color.Red;
            this.lblBaoLoi.Location = new System.Drawing.Point(21, 139);
            this.lblBaoLoi.Name = "lblBaoLoi";
            this.lblBaoLoi.Size = new System.Drawing.Size(38, 13);
            this.lblBaoLoi.TabIndex = 44;
            this.lblBaoLoi.Text = "báo lỗi";
            this.lblBaoLoi.Visible = false;
            // 
            // frmPhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(728, 393);
            this.Controls.Add(this.lblBaoLoi);
            this.Controls.Add(this.bntSave);
            this.Controls.Add(this.grbChon);
            this.Controls.Add(this.dgvPhong);
            this.Controls.Add(this.cbxHienTrang);
            this.Controls.Add(this.cbxTinhTrang);
            this.Controls.Add(this.cbxMaLPhong);
            this.Controls.Add(this.cbxIDPhong);
            this.Controls.Add(this.txtSoDT);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblHienTrang);
            this.Controls.Add(this.lblTinhTrang);
            this.Controls.Add(this.lblMaPLoai);
            this.Controls.Add(this.lblIDPhong);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmPhong";
            this.Text = "Phòng Khách Sạn";
            this.Load += new System.EventHandler(this.frmPhong_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPhong)).EndInit();
            this.grbChon.ResumeLayout(false);
            this.grbChon.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem themToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sửaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem xóaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tìmKiếmToolStripMenuItem;
        private System.Windows.Forms.ComboBox cbxHienTrang;
        private System.Windows.Forms.ComboBox cbxTinhTrang;
        private System.Windows.Forms.ComboBox cbxMaLPhong;
        private System.Windows.Forms.ComboBox cbxIDPhong;
        private System.Windows.Forms.TextBox txtSoDT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblHienTrang;
        private System.Windows.Forms.Label lblTinhTrang;
        private System.Windows.Forms.Label lblMaPLoai;
        private System.Windows.Forms.Label lblIDPhong;
        private System.Windows.Forms.DataGridView dgvPhong;
        private System.Windows.Forms.GroupBox grbChon;
        private System.Windows.Forms.RadioButton rdbHientrang;
        private System.Windows.Forms.RadioButton rdbtinhtrang;
        private System.Windows.Forms.RadioButton rdbLPhong;
        private System.Windows.Forms.RadioButton rdbPhong;
        private System.Windows.Forms.ToolStripMenuItem backToolStripMenuItem;
        private System.Windows.Forms.Button bntSearch;
        private System.Windows.Forms.Button bntSave;
        private System.Windows.Forms.Label lblBaoLoi;
    }
}