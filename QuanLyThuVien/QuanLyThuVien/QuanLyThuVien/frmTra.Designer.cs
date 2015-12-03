namespace QuanLyThuVien
{
    partial class frmTra
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
            this.gvDocGia = new System.Windows.Forms.DataGridView();
            this.gvSachMuon = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.DocGiaID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDocGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SachID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocGiaids = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSach = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgayMuon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HanTra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gvDocGia)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSachMuon)).BeginInit();
            this.SuspendLayout();
            // 
            // gvDocGia
            // 
            this.gvDocGia.AllowUserToAddRows = false;
            this.gvDocGia.AllowUserToDeleteRows = false;
            this.gvDocGia.AllowUserToOrderColumns = true;
            this.gvDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvDocGia.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DocGiaID,
            this.TenDocGia,
            this.NgaySinh,
            this.DiaChi});
            this.gvDocGia.Location = new System.Drawing.Point(12, 70);
            this.gvDocGia.Name = "gvDocGia";
            this.gvDocGia.ReadOnly = true;
            this.gvDocGia.Size = new System.Drawing.Size(397, 355);
            this.gvDocGia.TabIndex = 0;
            this.gvDocGia.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // gvSachMuon
            // 
            this.gvSachMuon.AllowUserToAddRows = false;
            this.gvSachMuon.AllowUserToDeleteRows = false;
            this.gvSachMuon.AllowUserToOrderColumns = true;
            this.gvSachMuon.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvSachMuon.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SachID,
            this.DocGiaids,
            this.TenSach,
            this.NgayMuon,
            this.HanTra});
            this.gvSachMuon.Location = new System.Drawing.Point(415, 70);
            this.gvSachMuon.Name = "gvSachMuon";
            this.gvSachMuon.ReadOnly = true;
            this.gvSachMuon.Size = new System.Drawing.Size(421, 300);
            this.gvSachMuon.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(586, 388);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Trả sách";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(97, 34);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(312, 20);
            this.textBox1.TabIndex = 3;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(530, 34);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(257, 20);
            this.textBox2.TabIndex = 4;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Tìm kiếm:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(470, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tìm kiếm:";
            // 
            // DocGiaID
            // 
            this.DocGiaID.DataPropertyName = "DocGiaID";
            this.DocGiaID.HeaderText = "ID";
            this.DocGiaID.Name = "DocGiaID";
            this.DocGiaID.ReadOnly = true;
            this.DocGiaID.Width = 50;
            // 
            // TenDocGia
            // 
            this.TenDocGia.DataPropertyName = "TenDocGia";
            this.TenDocGia.HeaderText = "Họ và tên";
            this.TenDocGia.Name = "TenDocGia";
            this.TenDocGia.ReadOnly = true;
            // 
            // NgaySinh
            // 
            this.NgaySinh.DataPropertyName = "NgaySinh";
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.Name = "NgaySinh";
            this.NgaySinh.ReadOnly = true;
            // 
            // DiaChi
            // 
            this.DiaChi.DataPropertyName = "DiaChi";
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.Name = "DiaChi";
            this.DiaChi.ReadOnly = true;
            // 
            // SachID
            // 
            this.SachID.DataPropertyName = "SachID";
            this.SachID.HeaderText = "SachID";
            this.SachID.Name = "SachID";
            this.SachID.ReadOnly = true;
            this.SachID.Width = 50;
            // 
            // DocGiaids
            // 
            this.DocGiaids.DataPropertyName = "DocGiaID";
            this.DocGiaids.HeaderText = "Độc giả";
            this.DocGiaids.Name = "DocGiaids";
            this.DocGiaids.ReadOnly = true;
            this.DocGiaids.Width = 50;
            // 
            // TenSach
            // 
            this.TenSach.DataPropertyName = "TenSach";
            this.TenSach.HeaderText = "Sách";
            this.TenSach.Name = "TenSach";
            this.TenSach.ReadOnly = true;
            // 
            // NgayMuon
            // 
            this.NgayMuon.DataPropertyName = "NgayMuon";
            this.NgayMuon.HeaderText = "Ngày Mượn";
            this.NgayMuon.Name = "NgayMuon";
            this.NgayMuon.ReadOnly = true;
            // 
            // HanTra
            // 
            this.HanTra.DataPropertyName = "HanTra";
            this.HanTra.HeaderText = "Hạn trả";
            this.HanTra.Name = "HanTra";
            this.HanTra.ReadOnly = true;
            // 
            // frmTra
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 437);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.gvSachMuon);
            this.Controls.Add(this.gvDocGia);
            this.Name = "frmTra";
            this.Text = "Thông tin trả sách";
            this.Load += new System.EventHandler(this.frmTra_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvDocGia)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gvSachMuon)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView gvDocGia;
        private System.Windows.Forms.DataGridView gvSachMuon;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocGiaID;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDocGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.DataGridViewTextBoxColumn SachID;
        private System.Windows.Forms.DataGridViewTextBoxColumn DocGiaids;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSach;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgayMuon;
        private System.Windows.Forms.DataGridViewTextBoxColumn HanTra;
    }
}