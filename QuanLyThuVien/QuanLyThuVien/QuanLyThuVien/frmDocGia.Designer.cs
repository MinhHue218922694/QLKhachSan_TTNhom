namespace QuanLyThuVien
{
    partial class frmDocGia
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
            this.dtgView = new System.Windows.Forms.DataGridView();
            this.DocGiaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpNs = new System.Windows.Forms.DateTimePicker();
            this.btTK = new System.Windows.Forms.Button();
            this.txtTK = new System.Windows.Forms.TextBox();
            this.txtDC = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTenDG = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.ID = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btXoa = new System.Windows.Forms.Button();
            this.btSua = new System.Windows.Forms.Button();
            this.btThem = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtgView
            // 
            this.dtgView.AllowUserToAddRows = false;
            this.dtgView.AllowUserToDeleteRows = false;
            this.dtgView.AllowUserToOrderColumns = true;
            this.dtgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocGiaID,
            this.TenDocGia,
            this.NgaySinh,
            this.DiaChi});
            this.dtgView.Location = new System.Drawing.Point(12, 209);
            this.dtgView.Name = "dtgView";
            this.dtgView.ReadOnly = true;
            this.dtgView.Size = new System.Drawing.Size(710, 209);
            this.dtgView.TabIndex = 0;
            this.dtgView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgView_CellClick);
            // 
            // DocGiaID
            // 
            this.DocGiaID.DataPropertyName = "DocGiaID";
            this.DocGiaID.HeaderText = "Mã Độc Giả";
            this.DocGiaID.Name = "DocGiaID";
            this.DocGiaID.ReadOnly = true;
            // 
            // TenDocGia
            // 
            this.TenDocGia.DataPropertyName = "TenDocGia";
            this.TenDocGia.HeaderText = "Tên Độc Giả";
            this.TenDocGia.Name = "TenDocGia";
            this.TenDocGia.ReadOnly = true;
            this.TenDocGia.Width = 200;
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày Sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.ReadOnly = true;
            this.NgaySinh.Width = 140;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa Chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            this.DiaChi.Width = 223;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dtpNs);
            this.groupBox1.Controls.Add(this.btTK);
            this.groupBox1.Controls.Add(this.txtTK);
            this.groupBox1.Controls.Add(this.txtDC);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtTenDG);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtID);
            this.groupBox1.Controls.Add(this.ID);
            this.groupBox1.Location = new System.Drawing.Point(12, 51);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(710, 143);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // dtpNs
            // 
            this.dtpNs.CustomFormat = "dd/MM/yyyy";
            this.dtpNs.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpNs.Location = new System.Drawing.Point(459, 59);
            this.dtpNs.Name = "dtpNs";
            this.dtpNs.Size = new System.Drawing.Size(102, 20);
            this.dtpNs.TabIndex = 3;
            // 
            // btTK
            // 
            this.btTK.Location = new System.Drawing.Point(19, 98);
            this.btTK.Name = "btTK";
            this.btTK.Size = new System.Drawing.Size(75, 23);
            this.btTK.TabIndex = 25;
            this.btTK.Text = "Tìm Kiếm";
            this.btTK.UseVisualStyleBackColor = true;
            // 
            // txtTK
            // 
            this.txtTK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTK.Location = new System.Drawing.Point(109, 100);
            this.txtTK.Name = "txtTK";
            this.txtTK.Size = new System.Drawing.Size(176, 20);
            this.txtTK.TabIndex = 24;
            this.txtTK.TextChanged += new System.EventHandler(this.txtTK_TextChanged);
            // 
            // txtDC
            // 
            this.txtDC.Location = new System.Drawing.Point(459, 26);
            this.txtDC.Name = "txtDC";
            this.txtDC.Size = new System.Drawing.Size(176, 20);
            this.txtDC.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(412, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Địa Chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(397, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Ngày Sinh";
            // 
            // txtTenDG
            // 
            this.txtTenDG.Location = new System.Drawing.Point(109, 62);
            this.txtTenDG.Name = "txtTenDG";
            this.txtTenDG.Size = new System.Drawing.Size(176, 20);
            this.txtTenDG.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Tên Độc Giả";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(109, 26);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(176, 20);
            this.txtID.TabIndex = 1;
            // 
            // ID
            // 
            this.ID.AutoSize = true;
            this.ID.Location = new System.Drawing.Point(76, 29);
            this.ID.Name = "ID";
            this.ID.Size = new System.Drawing.Size(18, 13);
            this.ID.TabIndex = 11;
            this.ID.Text = "ID";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btXoa);
            this.groupBox2.Controls.Add(this.btSua);
            this.groupBox2.Controls.Add(this.btThem);
            this.groupBox2.Location = new System.Drawing.Point(12, 424);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(710, 66);
            this.groupBox2.TabIndex = 15;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức Năng";
            // 
            // btXoa
            // 
            this.btXoa.Location = new System.Drawing.Point(497, 19);
            this.btXoa.Name = "btXoa";
            this.btXoa.Size = new System.Drawing.Size(116, 29);
            this.btXoa.TabIndex = 16;
            this.btXoa.Text = "Xóa";
            this.btXoa.UseVisualStyleBackColor = true;
            this.btXoa.Click += new System.EventHandler(this.btXoa_Click);
            // 
            // btSua
            // 
            this.btSua.Location = new System.Drawing.Point(313, 19);
            this.btSua.Name = "btSua";
            this.btSua.Size = new System.Drawing.Size(116, 29);
            this.btSua.TabIndex = 15;
            this.btSua.Text = "Sửa";
            this.btSua.UseVisualStyleBackColor = true;
            this.btSua.Click += new System.EventHandler(this.btSua_Click);
            // 
            // btThem
            // 
            this.btThem.Location = new System.Drawing.Point(118, 19);
            this.btThem.Name = "btThem";
            this.btThem.Size = new System.Drawing.Size(116, 29);
            this.btThem.TabIndex = 14;
            this.btThem.Text = "Thêm";
            this.btThem.UseVisualStyleBackColor = true;
            this.btThem.Click += new System.EventHandler(this.btThem_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(259, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(213, 24);
            this.label6.TabIndex = 16;
            this.label6.Text = "THÔNG TIN ĐỘC GIẢ";
            // 
            // frmDocGia
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(734, 502);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgView);
            this.Name = "frmDocGia";
            this.Text = "Thông Tin Độc Giả";
            this.Load += new System.EventHandler(this.frmDocGia_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtgView;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtDC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTenDG;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label ID;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btXoa;
        private System.Windows.Forms.Button btSua;
        private System.Windows.Forms.Button btThem;
        private System.Windows.Forms.TextBox txtTK;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpNs;
        private System.Windows.Forms.Button btTK;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocGiaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
    }
}