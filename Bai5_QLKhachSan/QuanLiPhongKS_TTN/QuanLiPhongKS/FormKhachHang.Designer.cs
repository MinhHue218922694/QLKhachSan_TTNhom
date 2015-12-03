namespace QLPhongKS
{
    partial class frmKhachHang
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbxGT = new System.Windows.Forms.ComboBox();
            this.txtQuocTich = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtCMND = new System.Windows.Forms.TextBox();
            this.lblQuocTich = new System.Windows.Forms.Label();
            this.lblSDT = new System.Windows.Forms.Label();
            this.lblCMND = new System.Windows.Forms.Label();
            this.txtQueQuan = new System.Windows.Forms.TextBox();
            this.txtTenKH = new System.Windows.Forms.TextBox();
            this.lblGT = new System.Windows.Forms.Label();
            this.lblQueQuan = new System.Windows.Forms.Label();
            this.lblTenKH = new System.Windows.Forms.Label();
            this.lblIDKHang = new System.Windows.Forms.Label();
            this.grbTK = new System.Windows.Forms.GroupBox();
            this.rBTKCMND = new System.Windows.Forms.RadioButton();
            this.rBTKTen = new System.Windows.Forms.RadioButton();
            this.rBTKMa = new System.Windows.Forms.RadioButton();
            this.dgvKhachHang = new System.Windows.Forms.DataGridView();
            this.lblNgaySinh = new System.Windows.Forms.Label();
            this.dtpNgaySinh = new System.Windows.Forms.DateTimePicker();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tblKhachHangBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.quanLiPhongKSDataSet = new QLPhongKS.QuanLiPhongKSDataSet();
            this.bntSua = new System.Windows.Forms.Button();
            this.bntSave = new System.Windows.Forms.Button();
            this.bntTimKiem = new System.Windows.Forms.Button();
            this.tblKhachHangTableAdapter = new QLPhongKS.QuanLiPhongKSDataSetTableAdapters.tblKhachHangTableAdapter();
            this.lblCanhBao = new System.Windows.Forms.Label();
            this.grbTK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKhachHangBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiPhongKSDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // cbxGT
            // 
            this.cbxGT.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxGT.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxGT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxGT.FormattingEnabled = true;
            this.cbxGT.Items.AddRange(new object[] {
            "Nam",
            "Nữ"});
            this.cbxGT.Location = new System.Drawing.Point(115, 112);
            this.cbxGT.Name = "cbxGT";
            this.cbxGT.Size = new System.Drawing.Size(105, 23);
            this.cbxGT.TabIndex = 53;
            // 
            // txtQuocTich
            // 
            this.txtQuocTich.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuocTich.Location = new System.Drawing.Point(429, 110);
            this.txtQuocTich.Name = "txtQuocTich";
            this.txtQuocTich.Size = new System.Drawing.Size(175, 22);
            this.txtQuocTich.TabIndex = 51;
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(429, 78);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(175, 22);
            this.txtSDT.TabIndex = 50;
            this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
            // 
            // txtCMND
            // 
            this.txtCMND.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCMND.Location = new System.Drawing.Point(429, 44);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(175, 22);
            this.txtCMND.TabIndex = 49;
            this.txtCMND.TextChanged += new System.EventHandler(this.txtCMND_TextChanged);
            this.txtCMND.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCMND_KeyDown);
            // 
            // lblQuocTich
            // 
            this.lblQuocTich.AutoSize = true;
            this.lblQuocTich.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuocTich.Location = new System.Drawing.Point(330, 113);
            this.lblQuocTich.Name = "lblQuocTich";
            this.lblQuocTich.Size = new System.Drawing.Size(64, 15);
            this.lblQuocTich.TabIndex = 48;
            this.lblQuocTich.Text = "Quốc Tịch";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(330, 81);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(77, 15);
            this.lblSDT.TabIndex = 47;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // lblCMND
            // 
            this.lblCMND.AutoSize = true;
            this.lblCMND.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCMND.Location = new System.Drawing.Point(330, 47);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(45, 15);
            this.lblCMND.TabIndex = 46;
            this.lblCMND.Text = "CMND";
            // 
            // txtQueQuan
            // 
            this.txtQueQuan.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQueQuan.Location = new System.Drawing.Point(429, 12);
            this.txtQueQuan.Name = "txtQueQuan";
            this.txtQueQuan.Size = new System.Drawing.Size(175, 22);
            this.txtQueQuan.TabIndex = 45;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKH.Location = new System.Drawing.Point(115, 45);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(175, 22);
            this.txtTenKH.TabIndex = 44;
            this.txtTenKH.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTenKH_KeyDown);
            // 
            // lblGT
            // 
            this.lblGT.AutoSize = true;
            this.lblGT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGT.Location = new System.Drawing.Point(16, 117);
            this.lblGT.Name = "lblGT";
            this.lblGT.Size = new System.Drawing.Size(60, 15);
            this.lblGT.TabIndex = 43;
            this.lblGT.Text = "Giới Tính";
            // 
            // lblQueQuan
            // 
            this.lblQueQuan.AutoSize = true;
            this.lblQueQuan.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueQuan.Location = new System.Drawing.Point(330, 15);
            this.lblQueQuan.Name = "lblQueQuan";
            this.lblQueQuan.Size = new System.Drawing.Size(63, 15);
            this.lblQueQuan.TabIndex = 42;
            this.lblQueQuan.Text = "Quê Quán";
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKH.Location = new System.Drawing.Point(11, 48);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(98, 15);
            this.lblTenKH.TabIndex = 41;
            this.lblTenKH.Text = "Tên Khách Hàng";
            // 
            // lblIDKHang
            // 
            this.lblIDKHang.AutoSize = true;
            this.lblIDKHang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDKHang.Location = new System.Drawing.Point(11, 15);
            this.lblIDKHang.Name = "lblIDKHang";
            this.lblIDKHang.Size = new System.Drawing.Size(94, 15);
            this.lblIDKHang.TabIndex = 40;
            this.lblIDKHang.Text = "Mã Khách Hàng";
            // 
            // grbTK
            // 
            this.grbTK.Controls.Add(this.rBTKCMND);
            this.grbTK.Controls.Add(this.rBTKTen);
            this.grbTK.Controls.Add(this.rBTKMa);
            this.grbTK.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbTK.Location = new System.Drawing.Point(620, 12);
            this.grbTK.Name = "grbTK";
            this.grbTK.Size = new System.Drawing.Size(200, 91);
            this.grbTK.TabIndex = 55;
            this.grbTK.TabStop = false;
            this.grbTK.Text = "Tìm Kiếm";
            this.grbTK.Visible = false;
            // 
            // rBTKCMND
            // 
            this.rBTKCMND.AutoSize = true;
            this.rBTKCMND.Location = new System.Drawing.Point(6, 65);
            this.rBTKCMND.Name = "rBTKCMND";
            this.rBTKCMND.Size = new System.Drawing.Size(93, 19);
            this.rBTKCMND.TabIndex = 4;
            this.rBTKCMND.TabStop = true;
            this.rBTKCMND.Text = "Theo CMND";
            this.rBTKCMND.UseVisualStyleBackColor = true;
            this.rBTKCMND.CheckedChanged += new System.EventHandler(this.rBTKCMND_CheckedChanged);
            // 
            // rBTKTen
            // 
            this.rBTKTen.AutoSize = true;
            this.rBTKTen.Location = new System.Drawing.Point(6, 43);
            this.rBTKTen.Name = "rBTKTen";
            this.rBTKTen.Size = new System.Drawing.Size(143, 19);
            this.rBTKTen.TabIndex = 2;
            this.rBTKTen.TabStop = true;
            this.rBTKTen.Text = "Theo Tên khách hàng";
            this.rBTKTen.UseVisualStyleBackColor = true;
            this.rBTKTen.CheckedChanged += new System.EventHandler(this.rBTKTen_CheckedChanged);
            // 
            // rBTKMa
            // 
            this.rBTKMa.AutoSize = true;
            this.rBTKMa.Location = new System.Drawing.Point(6, 21);
            this.rBTKMa.Name = "rBTKMa";
            this.rBTKMa.Size = new System.Drawing.Size(139, 19);
            this.rBTKMa.TabIndex = 0;
            this.rBTKMa.TabStop = true;
            this.rBTKMa.Text = "Theo Mã khách hàng";
            this.rBTKMa.UseVisualStyleBackColor = true;
            this.rBTKMa.CheckedChanged += new System.EventHandler(this.rBTKMa_CheckedChanged);
            // 
            // dgvKhachHang
            // 
            this.dgvKhachHang.AllowUserToAddRows = false;
            this.dgvKhachHang.AllowUserToDeleteRows = false;
            this.dgvKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKhachHang.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKhachHang.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvKhachHang.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvKhachHang.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvKhachHang.Location = new System.Drawing.Point(0, 185);
            this.dgvKhachHang.Name = "dgvKhachHang";
            this.dgvKhachHang.RowHeadersVisible = false;
            this.dgvKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvKhachHang.Size = new System.Drawing.Size(832, 224);
            this.dgvKhachHang.TabIndex = 56;
            this.dgvKhachHang.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvKhachHang_RowEnter);
            // 
            // lblNgaySinh
            // 
            this.lblNgaySinh.AutoSize = true;
            this.lblNgaySinh.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySinh.Location = new System.Drawing.Point(12, 82);
            this.lblNgaySinh.Name = "lblNgaySinh";
            this.lblNgaySinh.Size = new System.Drawing.Size(62, 15);
            this.lblNgaySinh.TabIndex = 57;
            this.lblNgaySinh.Text = "Ngày sinh";
            // 
            // dtpNgaySinh
            // 
            this.dtpNgaySinh.Location = new System.Drawing.Point(115, 79);
            this.dtpNgaySinh.Name = "dtpNgaySinh";
            this.dtpNgaySinh.Size = new System.Drawing.Size(200, 20);
            this.dtpNgaySinh.TabIndex = 58;
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.FileSystem;
            this.comboBox1.DataSource = this.tblKhachHangBindingSource;
            this.comboBox1.DisplayMember = "MaKH";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(115, 13);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 59;
            this.comboBox1.ValueMember = "MaKH";
            this.comboBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.comboBox1_KeyDown);
            // 
            // tblKhachHangBindingSource
            // 
            this.tblKhachHangBindingSource.DataMember = "tblKhachHang";
            this.tblKhachHangBindingSource.DataSource = this.quanLiPhongKSDataSet;
            // 
            // quanLiPhongKSDataSet
            // 
            this.quanLiPhongKSDataSet.DataSetName = "QuanLiPhongKSDataSet";
            this.quanLiPhongKSDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bntSua
            // 
            this.bntSua.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.bntSua.Location = new System.Drawing.Point(626, 109);
            this.bntSua.Name = "bntSua";
            this.bntSua.Size = new System.Drawing.Size(75, 23);
            this.bntSua.TabIndex = 60;
            this.bntSua.Text = "Sửa";
            this.bntSua.UseVisualStyleBackColor = true;
            this.bntSua.Click += new System.EventHandler(this.bntSua_Click);
            // 
            // bntSave
            // 
            this.bntSave.Enabled = false;
            this.bntSave.Location = new System.Drawing.Point(745, 109);
            this.bntSave.Name = "bntSave";
            this.bntSave.Size = new System.Drawing.Size(75, 23);
            this.bntSave.TabIndex = 61;
            this.bntSave.Text = "Save";
            this.bntSave.UseVisualStyleBackColor = true;
            this.bntSave.Visible = false;
            this.bntSave.Click += new System.EventHandler(this.bntSave_Click);
            // 
            // bntTimKiem
            // 
            this.bntTimKiem.Location = new System.Drawing.Point(626, 152);
            this.bntTimKiem.Name = "bntTimKiem";
            this.bntTimKiem.Size = new System.Drawing.Size(75, 23);
            this.bntTimKiem.TabIndex = 62;
            this.bntTimKiem.Text = "Tìm kiếm";
            this.bntTimKiem.UseVisualStyleBackColor = true;
            this.bntTimKiem.Click += new System.EventHandler(this.bntTimKiem_Click);
            // 
            // tblKhachHangTableAdapter
            // 
            this.tblKhachHangTableAdapter.ClearBeforeFill = true;
            // 
            // lblCanhBao
            // 
            this.lblCanhBao.AutoSize = true;
            this.lblCanhBao.BackColor = System.Drawing.Color.White;
            this.lblCanhBao.ForeColor = System.Drawing.Color.Red;
            this.lblCanhBao.Location = new System.Drawing.Point(340, 146);
            this.lblCanhBao.Name = "lblCanhBao";
            this.lblCanhBao.Size = new System.Drawing.Size(53, 13);
            this.lblCanhBao.TabIndex = 63;
            this.lblCanhBao.Text = "Cảnh báo";
            this.lblCanhBao.Visible = false;
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 409);
            this.Controls.Add(this.lblCanhBao);
            this.Controls.Add(this.bntTimKiem);
            this.Controls.Add(this.bntSave);
            this.Controls.Add(this.bntSua);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.dtpNgaySinh);
            this.Controls.Add(this.lblNgaySinh);
            this.Controls.Add(this.dgvKhachHang);
            this.Controls.Add(this.grbTK);
            this.Controls.Add(this.cbxGT);
            this.Controls.Add(this.txtQuocTich);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtCMND);
            this.Controls.Add(this.lblQuocTich);
            this.Controls.Add(this.lblSDT);
            this.Controls.Add(this.lblCMND);
            this.Controls.Add(this.txtQueQuan);
            this.Controls.Add(this.txtTenKH);
            this.Controls.Add(this.lblGT);
            this.Controls.Add(this.lblQueQuan);
            this.Controls.Add(this.lblTenKH);
            this.Controls.Add(this.lblIDKHang);
            this.Name = "frmKhachHang";
            this.Text = "Khách Hàng";
            this.Load += new System.EventHandler(this.FormKhachHang_Load);
            this.grbTK.ResumeLayout(false);
            this.grbTK.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKhachHang)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblKhachHangBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.quanLiPhongKSDataSet)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxGT;
        private System.Windows.Forms.TextBox txtQuocTich;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtCMND;
        private System.Windows.Forms.Label lblQuocTich;
        private System.Windows.Forms.Label lblSDT;
        private System.Windows.Forms.Label lblCMND;
        private System.Windows.Forms.TextBox txtQueQuan;
        private System.Windows.Forms.TextBox txtTenKH;
        private System.Windows.Forms.Label lblGT;
        private System.Windows.Forms.Label lblQueQuan;
        private System.Windows.Forms.Label lblTenKH;
        private System.Windows.Forms.Label lblIDKHang;
        private System.Windows.Forms.GroupBox grbTK;
        private System.Windows.Forms.DataGridView dgvKhachHang;
        private System.Windows.Forms.Label lblNgaySinh;
        private System.Windows.Forms.DateTimePicker dtpNgaySinh;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button bntSua;
        private System.Windows.Forms.Button bntSave;
        private System.Windows.Forms.Button bntTimKiem;
        private QuanLiPhongKSDataSet quanLiPhongKSDataSet;
        private System.Windows.Forms.BindingSource tblKhachHangBindingSource;
        private QuanLiPhongKSDataSetTableAdapters.tblKhachHangTableAdapter tblKhachHangTableAdapter;
        private System.Windows.Forms.Label lblCanhBao;
        private System.Windows.Forms.RadioButton rBTKCMND;
        private System.Windows.Forms.RadioButton rBTKTen;
        private System.Windows.Forms.RadioButton rBTKMa;
    }
}