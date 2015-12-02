namespace QLMuonTraSachTV
{
    partial class frmSach_DG
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
            this.dtGrigSach_DG = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupPanel1 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtTK_TheLoai = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX4 = new DevComponents.DotNetBar.LabelX();
            this.txtTK_TenSach = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtTk_TacGia = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.btnTTCN = new DevComponents.DotNetBar.ButtonX();
            this.btnLogout = new DevComponents.DotNetBar.ButtonX();
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            ((System.ComponentModel.ISupportInitialize)(this.dtGrigSach_DG)).BeginInit();
            this.groupPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGrigSach_DG
            // 
            this.dtGrigSach_DG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGrigSach_DG.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGrigSach_DG.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtGrigSach_DG.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dtGrigSach_DG.Location = new System.Drawing.Point(40, 185);
            this.dtGrigSach_DG.Name = "dtGrigSach_DG";
            this.dtGrigSach_DG.ReadOnly = true;
            this.dtGrigSach_DG.Size = new System.Drawing.Size(663, 192);
            this.dtGrigSach_DG.TabIndex = 0;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "TenDauSach";
            this.Column1.HeaderText = "Tên Đầu Sách";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "MaSach";
            this.Column2.HeaderText = "Mã Sách";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "TenTg";
            this.Column3.HeaderText = "Tên Tác Giả";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "TenTl";
            this.Column4.HeaderText = "Tên Thể Loại";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TenNXB";
            this.Column5.HeaderText = "Tên NXB";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "TrangThai";
            this.Column6.HeaderText = "Trạng Thái";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // groupPanel1
            // 
            this.groupPanel1.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel1.Controls.Add(this.txtTK_TheLoai);
            this.groupPanel1.Controls.Add(this.labelX4);
            this.groupPanel1.Controls.Add(this.txtTK_TenSach);
            this.groupPanel1.Controls.Add(this.txtTk_TacGia);
            this.groupPanel1.Controls.Add(this.labelX2);
            this.groupPanel1.Controls.Add(this.labelX3);
            this.groupPanel1.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel1.Location = new System.Drawing.Point(12, 51);
            this.groupPanel1.Name = "groupPanel1";
            this.groupPanel1.Size = new System.Drawing.Size(598, 128);
            // 
            // 
            // 
            this.groupPanel1.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel1.Style.BackColorGradientAngle = 90;
            this.groupPanel1.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel1.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderBottomWidth = 1;
            this.groupPanel1.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel1.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderLeftWidth = 1;
            this.groupPanel1.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderRightWidth = 1;
            this.groupPanel1.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel1.Style.BorderTopWidth = 1;
            this.groupPanel1.Style.CornerDiameter = 4;
            this.groupPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel1.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel1.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel1.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel1.TabIndex = 1;
            this.groupPanel1.Text = "Tìm Kiếm";
            // 
            // txtTK_TheLoai
            // 
            // 
            // 
            // 
            this.txtTK_TheLoai.Border.Class = "TextBoxBorder";
            this.txtTK_TheLoai.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTK_TheLoai.Location = new System.Drawing.Point(389, 24);
            this.txtTK_TheLoai.Name = "txtTK_TheLoai";
            this.txtTK_TheLoai.PreventEnterBeep = true;
            this.txtTK_TheLoai.Size = new System.Drawing.Size(147, 20);
            this.txtTK_TheLoai.TabIndex = 4;
            this.txtTK_TheLoai.TextChanged += new System.EventHandler(this.txtTK_TheLoai_TextChanged);
            // 
            // labelX4
            // 
            // 
            // 
            // 
            this.labelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX4.Location = new System.Drawing.Point(311, 21);
            this.labelX4.Name = "labelX4";
            this.labelX4.Size = new System.Drawing.Size(63, 23);
            this.labelX4.TabIndex = 7;
            this.labelX4.Text = "Thể Loại";
            // 
            // txtTK_TenSach
            // 
            // 
            // 
            // 
            this.txtTK_TenSach.Border.Class = "TextBoxBorder";
            this.txtTK_TenSach.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTK_TenSach.Location = new System.Drawing.Point(214, 65);
            this.txtTK_TenSach.Name = "txtTK_TenSach";
            this.txtTK_TenSach.PreventEnterBeep = true;
            this.txtTK_TenSach.Size = new System.Drawing.Size(210, 20);
            this.txtTK_TenSach.TabIndex = 5;
            this.txtTK_TenSach.TextChanged += new System.EventHandler(this.txtTK_TenSach_TextChanged);
            // 
            // txtTk_TacGia
            // 
            // 
            // 
            // 
            this.txtTk_TacGia.Border.Class = "TextBoxBorder";
            this.txtTk_TacGia.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTk_TacGia.Location = new System.Drawing.Point(137, 21);
            this.txtTk_TacGia.Name = "txtTk_TacGia";
            this.txtTk_TacGia.PreventEnterBeep = true;
            this.txtTk_TacGia.Size = new System.Drawing.Size(142, 20);
            this.txtTk_TacGia.TabIndex = 6;
            this.txtTk_TacGia.TextChanged += new System.EventHandler(this.txtTk_TacGia_TextChanged);
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Location = new System.Drawing.Point(56, 18);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(75, 23);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "Tên Tác Giả";
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Location = new System.Drawing.Point(56, 65);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(152, 23);
            this.labelX3.TabIndex = 9;
            this.labelX3.Text = "Tên đầu sách ";
            // 
            // btnTTCN
            // 
            this.btnTTCN.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnTTCN.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnTTCN.Location = new System.Drawing.Point(628, 60);
            this.btnTTCN.Name = "btnTTCN";
            this.btnTTCN.Size = new System.Drawing.Size(75, 23);
            this.btnTTCN.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnTTCN.TabIndex = 12;
            this.btnTTCN.Text = "TT. Cá Nhân";
            this.btnTTCN.TextColor = System.Drawing.Color.Black;
            this.btnTTCN.Click += new System.EventHandler(this.btnTTCN_Click);
            // 
            // btnLogout
            // 
            this.btnLogout.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnLogout.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnLogout.Location = new System.Drawing.Point(628, 105);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnLogout.TabIndex = 11;
            this.btnLogout.Text = "Đăng Xuất";
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Location = new System.Drawing.Point(628, 145);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(75, 23);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 10;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelX1.ForeColor = System.Drawing.Color.Red;
            this.labelX1.Location = new System.Drawing.Point(98, 12);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(471, 30);
            this.labelX1.TabIndex = 13;
            this.labelX1.Text = "Danh Sách Những Cuốn Sách Còn Trong Thư Viện";
            // 
            // frmSach_DG
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(715, 389);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.btnTTCN);
            this.Controls.Add(this.btnLogout);
            this.Controls.Add(this.groupPanel1);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.dtGrigSach_DG);
            this.DoubleBuffered = true;
            this.Name = "frmSach_DG";
            this.Text = "Sách_ĐộcGiả";
            this.Load += new System.EventHandler(this.frmSach_DG_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGrigSach_DG)).EndInit();
            this.groupPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dtGrigSach_DG;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTK_TheLoai;
        private DevComponents.DotNetBar.LabelX labelX4;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTK_TenSach;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTk_TacGia;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.ButtonX btnTTCN;
        private DevComponents.DotNetBar.ButtonX btnLogout;
        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.LabelX labelX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}

