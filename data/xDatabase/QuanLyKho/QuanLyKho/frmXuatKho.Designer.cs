namespace QuanLyKho
{
    partial class frmXuatKho
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btthem = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.txttenmh = new System.Windows.Forms.TextBox();
            this.txtmamh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.txtngayxuat = new System.Windows.Forms.DateTimePicker();
            this.txtmaphieu = new System.Windows.Forms.TextBox();
            this.txtkhachhang = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btxuat = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.MaPhieu = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Makhachhang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayThang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaHH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenHH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btthem);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(587, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // btthem
            // 
            this.btthem.Location = new System.Drawing.Point(226, 151);
            this.btthem.Name = "btthem";
            this.btthem.Size = new System.Drawing.Size(119, 27);
            this.btthem.TabIndex = 4;
            this.btthem.Text = "Thêm vào danh sách";
            this.btthem.UseVisualStyleBackColor = true;
            this.btthem.Click += new System.EventHandler(this.btthem_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.txtsoluong);
            this.groupBox4.Controls.Add(this.txttenmh);
            this.groupBox4.Controls.Add(this.txtmamh);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Location = new System.Drawing.Point(284, 28);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(307, 110);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sản phẩm";
            // 
            // txtsoluong
            // 
            this.txtsoluong.Location = new System.Drawing.Point(83, 73);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(100, 20);
            this.txtsoluong.TabIndex = 5;
            // 
            // txttenmh
            // 
            this.txttenmh.Location = new System.Drawing.Point(83, 49);
            this.txttenmh.Name = "txttenmh";
            this.txttenmh.Size = new System.Drawing.Size(100, 20);
            this.txttenmh.TabIndex = 4;
            // 
            // txtmamh
            // 
            this.txtmamh.Location = new System.Drawing.Point(83, 24);
            this.txtmamh.Name = "txtmamh";
            this.txtmamh.Size = new System.Drawing.Size(100, 20);
            this.txtmamh.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Số lượng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 52);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Tên mặt hàng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Mã Mặt hàng";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.txtngayxuat);
            this.groupBox3.Controls.Add(this.txtmaphieu);
            this.groupBox3.Controls.Add(this.txtkhachhang);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Location = new System.Drawing.Point(12, 27);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(266, 111);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Khách hàng";
            // 
            // txtngayxuat
            // 
            this.txtngayxuat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.txtngayxuat.Location = new System.Drawing.Point(111, 76);
            this.txtngayxuat.Name = "txtngayxuat";
            this.txtngayxuat.Size = new System.Drawing.Size(100, 20);
            this.txtngayxuat.TabIndex = 6;
            // 
            // txtmaphieu
            // 
            this.txtmaphieu.Location = new System.Drawing.Point(111, 19);
            this.txtmaphieu.Name = "txtmaphieu";
            this.txtmaphieu.Size = new System.Drawing.Size(100, 20);
            this.txtmaphieu.TabIndex = 4;
            // 
            // txtkhachhang
            // 
            this.txtkhachhang.Location = new System.Drawing.Point(111, 47);
            this.txtkhachhang.Name = "txtkhachhang";
            this.txtkhachhang.Size = new System.Drawing.Size(100, 20);
            this.txtkhachhang.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày xuất";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Mã phiếu xuất";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 50);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tên:";
            // 
            // btxuat
            // 
            this.btxuat.Location = new System.Drawing.Point(238, 382);
            this.btxuat.Name = "btxuat";
            this.btxuat.Size = new System.Drawing.Size(119, 23);
            this.btxuat.TabIndex = 3;
            this.btxuat.Text = "Xuất kho";
            this.btxuat.UseVisualStyleBackColor = true;
            this.btxuat.Click += new System.EventHandler(this.btxuat_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dataGridView2);
            this.groupBox2.Location = new System.Drawing.Point(12, 189);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(587, 187);
            this.groupBox2.TabIndex = 4;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Danh sách mặt hàng";
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaPhieu,
            this.Makhachhang,
            this.NgayThang,
            this.MaHH,
            this.TenHH,
            this.SoLuong});
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 16);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.Size = new System.Drawing.Size(581, 168);
            this.dataGridView2.TabIndex = 0;
            // 
            // MaPhieu
            // 
            this.MaPhieu.HeaderText = "Mã Phiếu";
            this.MaPhieu.Name = "MaPhieu";
            this.MaPhieu.ReadOnly = true;
            // 
            // Makhachhang
            // 
            this.Makhachhang.HeaderText = "Khách hàng";
            this.Makhachhang.Name = "Makhachhang";
            this.Makhachhang.ReadOnly = true;
            // 
            // NgayThang
            // 
            this.NgayThang.HeaderText = "Ngày Tháng";
            this.NgayThang.Name = "NgayThang";
            this.NgayThang.ReadOnly = true;
            // 
            // MaHH
            // 
            this.MaHH.HeaderText = "Mã Hàng Hóa";
            this.MaHH.Name = "MaHH";
            this.MaHH.ReadOnly = true;
            // 
            // TenHH
            // 
            this.TenHH.HeaderText = "Tên Hàng hóa";
            this.TenHH.Name = "TenHH";
            this.TenHH.ReadOnly = true;
            // 
            // SoLuong
            // 
            this.SoLuong.HeaderText = "Số lượng";
            this.SoLuong.Name = "SoLuong";
            this.SoLuong.ReadOnly = true;
            // 
            // frmXuatKho
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 417);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btxuat);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmXuatKho";
            this.Text = "Form2";
            this.groupBox1.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker txtngayxuat;
        private System.Windows.Forms.TextBox txtmaphieu;
        private System.Windows.Forms.TextBox txtkhachhang;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.TextBox txttenmh;
        private System.Windows.Forms.TextBox txtmamh;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btthem;
        private System.Windows.Forms.Button btxuat;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaPhieu;
        private System.Windows.Forms.DataGridViewTextBoxColumn Makhachhang;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayThang;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaHH;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenHH;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuong;

    }
}