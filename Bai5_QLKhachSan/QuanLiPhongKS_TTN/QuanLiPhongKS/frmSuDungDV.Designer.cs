namespace QLPhongKS
{
    partial class frmSuDungDV
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtPtgdung = new System.Windows.Forms.DateTimePicker();
            this.cbxIDDV = new System.Windows.Forms.ComboBox();
            this.cbxIDPhong = new System.Windows.Forms.ComboBox();
            this.lblIDPhong = new System.Windows.Forms.Label();
            this.lblNgaySD = new System.Windows.Forms.Label();
            this.txtSoluongSD = new System.Windows.Forms.TextBox();
            this.lblSLTB = new System.Windows.Forms.Label();
            this.lblMaTB = new System.Windows.Forms.Label();
            this.grbChon = new System.Windows.Forms.GroupBox();
            this.rdbNgaySD = new System.Windows.Forms.RadioButton();
            this.rdbDichVu = new System.Windows.Forms.RadioButton();
            this.rbrPhong = new System.Windows.Forms.RadioButton();
            this.bntTimKiem = new System.Windows.Forms.Button();
            this.bntCapNhat = new System.Windows.Forms.Button();
            this.bntThoatPhong = new System.Windows.Forms.Button();
            this.bntXoaDV = new System.Windows.Forms.Button();
            this.bntLuuDV = new System.Windows.Forms.Button();
            this.bntThemDV = new System.Windows.Forms.Button();
            this.dgvSDungDV = new System.Windows.Forms.DataGridView();
            this.grbChon.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSDungDV)).BeginInit();
            this.SuspendLayout();
            // 
            // dtPtgdung
            // 
            this.dtPtgdung.CalendarFont = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPtgdung.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtPtgdung.Location = new System.Drawing.Point(105, 122);
            this.dtPtgdung.Name = "dtPtgdung";
            this.dtPtgdung.Size = new System.Drawing.Size(200, 22);
            this.dtPtgdung.TabIndex = 47;
            // 
            // cbxIDDV
            // 
            this.cbxIDDV.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxIDDV.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxIDDV.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxIDDV.FormattingEnabled = true;
            this.cbxIDDV.Items.AddRange(new object[] {
            "TB01",
            "TB02",
            "TB03",
            "TB04",
            "TB05",
            "TB06",
            "TB07",
            "TB08",
            "TB09",
            "TB10",
            "TB11",
            "TB12",
            "TB13",
            "TB14",
            "TB15",
            "TB16",
            "TB17",
            "TB18",
            "TB19"});
            this.cbxIDDV.Location = new System.Drawing.Point(104, 42);
            this.cbxIDDV.Name = "cbxIDDV";
            this.cbxIDDV.Size = new System.Drawing.Size(121, 23);
            this.cbxIDDV.TabIndex = 46;
            // 
            // cbxIDPhong
            // 
            this.cbxIDPhong.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxIDPhong.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxIDPhong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxIDPhong.FormattingEnabled = true;
            this.cbxIDPhong.Location = new System.Drawing.Point(104, 6);
            this.cbxIDPhong.Name = "cbxIDPhong";
            this.cbxIDPhong.Size = new System.Drawing.Size(121, 23);
            this.cbxIDPhong.TabIndex = 45;
            // 
            // lblIDPhong
            // 
            this.lblIDPhong.AutoSize = true;
            this.lblIDPhong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDPhong.Location = new System.Drawing.Point(12, 9);
            this.lblIDPhong.Name = "lblIDPhong";
            this.lblIDPhong.Size = new System.Drawing.Size(62, 15);
            this.lblIDPhong.TabIndex = 44;
            this.lblIDPhong.Text = "ID_Phòng";
            // 
            // lblNgaySD
            // 
            this.lblNgaySD.AutoSize = true;
            this.lblNgaySD.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNgaySD.Location = new System.Drawing.Point(12, 122);
            this.lblNgaySD.Name = "lblNgaySD";
            this.lblNgaySD.Size = new System.Drawing.Size(87, 15);
            this.lblNgaySD.TabIndex = 43;
            this.lblNgaySD.Text = "Ngày Sử Dụng";
            // 
            // txtSoluongSD
            // 
            this.txtSoluongSD.Location = new System.Drawing.Point(104, 83);
            this.txtSoluongSD.Name = "txtSoluongSD";
            this.txtSoluongSD.Size = new System.Drawing.Size(121, 20);
            this.txtSoluongSD.TabIndex = 42;
            // 
            // lblSLTB
            // 
            this.lblSLTB.AutoSize = true;
            this.lblSLTB.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLTB.Location = new System.Drawing.Point(12, 86);
            this.lblSLTB.Name = "lblSLTB";
            this.lblSLTB.Size = new System.Drawing.Size(61, 15);
            this.lblSLTB.TabIndex = 41;
            this.lblSLTB.Text = "Số Lượng";
            // 
            // lblMaTB
            // 
            this.lblMaTB.AutoSize = true;
            this.lblMaTB.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaTB.Location = new System.Drawing.Point(12, 45);
            this.lblMaTB.Name = "lblMaTB";
            this.lblMaTB.Size = new System.Drawing.Size(68, 15);
            this.lblMaTB.TabIndex = 40;
            this.lblMaTB.Text = "ID_DichVu";
            // 
            // grbChon
            // 
            this.grbChon.Controls.Add(this.rdbNgaySD);
            this.grbChon.Controls.Add(this.rdbDichVu);
            this.grbChon.Controls.Add(this.rbrPhong);
            this.grbChon.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbChon.Location = new System.Drawing.Point(265, 12);
            this.grbChon.Name = "grbChon";
            this.grbChon.Size = new System.Drawing.Size(138, 98);
            this.grbChon.TabIndex = 54;
            this.grbChon.TabStop = false;
            this.grbChon.Text = "Tìm kiếm";
            this.grbChon.Visible = false;
            // 
            // rdbNgaySD
            // 
            this.rdbNgaySD.AutoSize = true;
            this.rdbNgaySD.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbNgaySD.Location = new System.Drawing.Point(11, 72);
            this.rdbNgaySD.Name = "rdbNgaySD";
            this.rdbNgaySD.Size = new System.Drawing.Size(103, 19);
            this.rdbNgaySD.TabIndex = 27;
            this.rdbNgaySD.TabStop = true;
            this.rdbNgaySD.Text = "Theo Ngày SD";
            this.rdbNgaySD.UseVisualStyleBackColor = true;
            this.rdbNgaySD.CheckedChanged += new System.EventHandler(this.rdbNgaySD_CheckedChanged);
            // 
            // rdbDichVu
            // 
            this.rdbDichVu.AutoSize = true;
            this.rdbDichVu.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbDichVu.Location = new System.Drawing.Point(11, 45);
            this.rdbDichVu.Name = "rdbDichVu";
            this.rdbDichVu.Size = new System.Drawing.Size(120, 19);
            this.rdbDichVu.TabIndex = 1;
            this.rdbDichVu.TabStop = true;
            this.rdbDichVu.Text = "Theo Mã Dịch Vụ";
            this.rdbDichVu.UseVisualStyleBackColor = true;
            this.rdbDichVu.CheckedChanged += new System.EventHandler(this.rdbDichVu_CheckedChanged);
            // 
            // rbrPhong
            // 
            this.rbrPhong.AutoSize = true;
            this.rbrPhong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rbrPhong.Location = new System.Drawing.Point(11, 20);
            this.rbrPhong.Name = "rbrPhong";
            this.rbrPhong.Size = new System.Drawing.Size(90, 19);
            this.rbrPhong.TabIndex = 0;
            this.rbrPhong.TabStop = true;
            this.rbrPhong.Text = "Theo Phòng";
            this.rbrPhong.UseVisualStyleBackColor = true;
            this.rbrPhong.CheckedChanged += new System.EventHandler(this.rbrPhong_CheckedChanged);
            // 
            // bntTimKiem
            // 
            this.bntTimKiem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntTimKiem.Location = new System.Drawing.Point(536, 85);
            this.bntTimKiem.Name = "bntTimKiem";
            this.bntTimKiem.Size = new System.Drawing.Size(75, 23);
            this.bntTimKiem.TabIndex = 53;
            this.bntTimKiem.Text = "Tìm Kiếm";
            this.bntTimKiem.UseVisualStyleBackColor = true;
            this.bntTimKiem.Click += new System.EventHandler(this.bntTimKiem_Click);
            // 
            // bntCapNhat
            // 
            this.bntCapNhat.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntCapNhat.Location = new System.Drawing.Point(439, 52);
            this.bntCapNhat.Name = "bntCapNhat";
            this.bntCapNhat.Size = new System.Drawing.Size(75, 23);
            this.bntCapNhat.TabIndex = 52;
            this.bntCapNhat.Text = "Cập nhật";
            this.bntCapNhat.UseVisualStyleBackColor = true;
            this.bntCapNhat.Click += new System.EventHandler(this.bntCapNhat_Click);
            // 
            // bntThoatPhong
            // 
            this.bntThoatPhong.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.bntThoatPhong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntThoatPhong.Location = new System.Drawing.Point(536, 115);
            this.bntThoatPhong.Name = "bntThoatPhong";
            this.bntThoatPhong.Size = new System.Drawing.Size(77, 40);
            this.bntThoatPhong.TabIndex = 51;
            this.bntThoatPhong.Text = "Thoát";
            this.bntThoatPhong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bntThoatPhong.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.bntThoatPhong.UseVisualStyleBackColor = true;
            this.bntThoatPhong.Click += new System.EventHandler(this.bntThoatPhong_Click);
            // 
            // bntXoaDV
            // 
            this.bntXoaDV.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntXoaDV.Location = new System.Drawing.Point(536, 13);
            this.bntXoaDV.Name = "bntXoaDV";
            this.bntXoaDV.Size = new System.Drawing.Size(75, 23);
            this.bntXoaDV.TabIndex = 50;
            this.bntXoaDV.Text = "Xóa";
            this.bntXoaDV.UseVisualStyleBackColor = true;
            this.bntXoaDV.Click += new System.EventHandler(this.bntXoaDV_Click);
            // 
            // bntLuuDV
            // 
            this.bntLuuDV.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntLuuDV.Location = new System.Drawing.Point(536, 52);
            this.bntLuuDV.Name = "bntLuuDV";
            this.bntLuuDV.Size = new System.Drawing.Size(75, 23);
            this.bntLuuDV.TabIndex = 49;
            this.bntLuuDV.Text = "Lưu";
            this.bntLuuDV.UseVisualStyleBackColor = true;
            this.bntLuuDV.Click += new System.EventHandler(this.bntLuuDV_Click);
            // 
            // bntThemDV
            // 
            this.bntThemDV.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntThemDV.Location = new System.Drawing.Point(439, 12);
            this.bntThemDV.Name = "bntThemDV";
            this.bntThemDV.Size = new System.Drawing.Size(75, 23);
            this.bntThemDV.TabIndex = 48;
            this.bntThemDV.Text = "Thêm";
            this.bntThemDV.UseVisualStyleBackColor = true;
            this.bntThemDV.Click += new System.EventHandler(this.bntThemDV_Click);
            // 
            // dgvSDungDV
            // 
            this.dgvSDungDV.AllowUserToAddRows = false;
            this.dgvSDungDV.AllowUserToDeleteRows = false;
            this.dgvSDungDV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvSDungDV.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgvSDungDV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSDungDV.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvSDungDV.Location = new System.Drawing.Point(0, 199);
            this.dgvSDungDV.Name = "dgvSDungDV";
            this.dgvSDungDV.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSDungDV.Size = new System.Drawing.Size(626, 182);
            this.dgvSDungDV.TabIndex = 55;
            this.dgvSDungDV.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSDungDV_RowEnter);
            // 
            // frmSuDungDV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 381);
            this.Controls.Add(this.dgvSDungDV);
            this.Controls.Add(this.grbChon);
            this.Controls.Add(this.bntTimKiem);
            this.Controls.Add(this.bntCapNhat);
            this.Controls.Add(this.bntThoatPhong);
            this.Controls.Add(this.bntXoaDV);
            this.Controls.Add(this.bntLuuDV);
            this.Controls.Add(this.bntThemDV);
            this.Controls.Add(this.dtPtgdung);
            this.Controls.Add(this.cbxIDDV);
            this.Controls.Add(this.cbxIDPhong);
            this.Controls.Add(this.lblIDPhong);
            this.Controls.Add(this.lblNgaySD);
            this.Controls.Add(this.txtSoluongSD);
            this.Controls.Add(this.lblSLTB);
            this.Controls.Add(this.lblMaTB);
            this.Name = "frmSuDungDV";
            this.Text = "frmSuDungDV";
            this.Load += new System.EventHandler(this.frmSuDungDV_Load);
            this.grbChon.ResumeLayout(false);
            this.grbChon.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSDungDV)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtPtgdung;
        private System.Windows.Forms.ComboBox cbxIDDV;
        private System.Windows.Forms.ComboBox cbxIDPhong;
        private System.Windows.Forms.Label lblIDPhong;
        private System.Windows.Forms.Label lblNgaySD;
        private System.Windows.Forms.TextBox txtSoluongSD;
        private System.Windows.Forms.Label lblSLTB;
        private System.Windows.Forms.Label lblMaTB;
        private System.Windows.Forms.GroupBox grbChon;
        private System.Windows.Forms.RadioButton rdbNgaySD;
        private System.Windows.Forms.RadioButton rdbDichVu;
        private System.Windows.Forms.RadioButton rbrPhong;
        private System.Windows.Forms.Button bntTimKiem;
        private System.Windows.Forms.Button bntCapNhat;
        private System.Windows.Forms.Button bntThoatPhong;
        private System.Windows.Forms.Button bntXoaDV;
        private System.Windows.Forms.Button bntLuuDV;
        private System.Windows.Forms.Button bntThemDV;
        private System.Windows.Forms.DataGridView dgvSDungDV;
    }
}