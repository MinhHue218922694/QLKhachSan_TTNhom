namespace QLPhongKS
{
    partial class frmTBThietBi
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.cbxMaTB = new System.Windows.Forms.ComboBox();
            this.cbxSoPhong = new System.Windows.Forms.ComboBox();
            this.lblIDPhong = new System.Windows.Forms.Label();
            this.txtSoluongTB = new System.Windows.Forms.TextBox();
            this.lblSLTB = new System.Windows.Forms.Label();
            this.lblMaTB = new System.Windows.Forms.Label();
            this.dgvTBTB = new System.Windows.Forms.DataGridView();
            this.grbChonTBTB = new System.Windows.Forms.GroupBox();
            this.bntSearch = new System.Windows.Forms.Button();
            this.rdbtinhtrang = new System.Windows.Forms.RadioButton();
            this.rdbPhong = new System.Windows.Forms.RadioButton();
            this.bntLuuTBTB = new System.Windows.Forms.Button();
            this.bntThem = new System.Windows.Forms.Button();
            this.bntXoa = new System.Windows.Forms.Button();
            this.bntSua = new System.Windows.Forms.Button();
            this.bntTimKiem = new System.Windows.Forms.Button();
            this.bntBack = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTBTB)).BeginInit();
            this.grbChonTBTB.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbxMaTB
            // 
            this.cbxMaTB.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxMaTB.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxMaTB.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxMaTB.FormattingEnabled = true;
            this.cbxMaTB.Location = new System.Drawing.Point(101, 48);
            this.cbxMaTB.Name = "cbxMaTB";
            this.cbxMaTB.Size = new System.Drawing.Size(121, 23);
            this.cbxMaTB.TabIndex = 50;
            // 
            // cbxSoPhong
            // 
            this.cbxSoPhong.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxSoPhong.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxSoPhong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbxSoPhong.FormattingEnabled = true;
            this.cbxSoPhong.Location = new System.Drawing.Point(101, 12);
            this.cbxSoPhong.Name = "cbxSoPhong";
            this.cbxSoPhong.Size = new System.Drawing.Size(121, 23);
            this.cbxSoPhong.TabIndex = 49;
            // 
            // lblIDPhong
            // 
            this.lblIDPhong.AutoSize = true;
            this.lblIDPhong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIDPhong.Location = new System.Drawing.Point(9, 15);
            this.lblIDPhong.Name = "lblIDPhong";
            this.lblIDPhong.Size = new System.Drawing.Size(57, 15);
            this.lblIDPhong.TabIndex = 48;
            this.lblIDPhong.Text = "Số phòng";
            // 
            // txtSoluongTB
            // 
            this.txtSoluongTB.Location = new System.Drawing.Point(101, 90);
            this.txtSoluongTB.Multiline = true;
            this.txtSoluongTB.Name = "txtSoluongTB";
            this.txtSoluongTB.Size = new System.Drawing.Size(121, 24);
            this.txtSoluongTB.TabIndex = 47;
            // 
            // lblSLTB
            // 
            this.lblSLTB.AutoSize = true;
            this.lblSLTB.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSLTB.Location = new System.Drawing.Point(9, 92);
            this.lblSLTB.Name = "lblSLTB";
            this.lblSLTB.Size = new System.Drawing.Size(61, 15);
            this.lblSLTB.TabIndex = 46;
            this.lblSLTB.Text = "Số Lượng";
            // 
            // lblMaTB
            // 
            this.lblMaTB.AutoSize = true;
            this.lblMaTB.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMaTB.Location = new System.Drawing.Point(9, 51);
            this.lblMaTB.Name = "lblMaTB";
            this.lblMaTB.Size = new System.Drawing.Size(65, 15);
            this.lblMaTB.TabIndex = 45;
            this.lblMaTB.Text = "Mã thiết bị";
            // 
            // dgvTBTB
            // 
            this.dgvTBTB.AllowUserToAddRows = false;
            this.dgvTBTB.AllowUserToDeleteRows = false;
            this.dgvTBTB.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTBTB.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvTBTB.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTBTB.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dgvTBTB.Location = new System.Drawing.Point(0, 148);
            this.dgvTBTB.Name = "dgvTBTB";
            this.dgvTBTB.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTBTB.Size = new System.Drawing.Size(693, 191);
            this.dgvTBTB.TabIndex = 51;
            this.dgvTBTB.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTBTB_RowEnter);
            // 
            // grbChonTBTB
            // 
            this.grbChonTBTB.Controls.Add(this.bntSearch);
            this.grbChonTBTB.Controls.Add(this.rdbtinhtrang);
            this.grbChonTBTB.Controls.Add(this.rdbPhong);
            this.grbChonTBTB.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbChonTBTB.Location = new System.Drawing.Point(246, 12);
            this.grbChonTBTB.Name = "grbChonTBTB";
            this.grbChonTBTB.Size = new System.Drawing.Size(138, 115);
            this.grbChonTBTB.TabIndex = 53;
            this.grbChonTBTB.TabStop = false;
            this.grbChonTBTB.Text = "Tìm kiếm";
            this.grbChonTBTB.Visible = false;
            // 
            // bntSearch
            // 
            this.bntSearch.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntSearch.Location = new System.Drawing.Point(30, 80);
            this.bntSearch.Name = "bntSearch";
            this.bntSearch.Size = new System.Drawing.Size(75, 23);
            this.bntSearch.TabIndex = 59;
            this.bntSearch.Text = "Search";
            this.bntSearch.UseVisualStyleBackColor = true;
            this.bntSearch.Click += new System.EventHandler(this.bntSearch_Click);
            // 
            // rdbtinhtrang
            // 
            this.rdbtinhtrang.AutoSize = true;
            this.rdbtinhtrang.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbtinhtrang.Location = new System.Drawing.Point(11, 54);
            this.rdbtinhtrang.Name = "rdbtinhtrang";
            this.rdbtinhtrang.Size = new System.Drawing.Size(120, 19);
            this.rdbtinhtrang.TabIndex = 27;
            this.rdbtinhtrang.TabStop = true;
            this.rdbtinhtrang.Text = "Theo Mã Thiết Bị";
            this.rdbtinhtrang.UseVisualStyleBackColor = true;
            this.rdbtinhtrang.CheckedChanged += new System.EventHandler(this.rdbtinhtrang_CheckedChanged);
            // 
            // rdbPhong
            // 
            this.rdbPhong.AutoSize = true;
            this.rdbPhong.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdbPhong.Location = new System.Drawing.Point(11, 20);
            this.rdbPhong.Name = "rdbPhong";
            this.rdbPhong.Size = new System.Drawing.Size(107, 19);
            this.rdbPhong.TabIndex = 0;
            this.rdbPhong.TabStop = true;
            this.rdbPhong.Text = "Theo Số Phòng";
            this.rdbPhong.UseVisualStyleBackColor = true;
            this.rdbPhong.CheckedChanged += new System.EventHandler(this.rdbPhong_CheckedChanged);
            // 
            // bntLuuTBTB
            // 
            this.bntLuuTBTB.Enabled = false;
            this.bntLuuTBTB.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntLuuTBTB.Location = new System.Drawing.Point(606, 15);
            this.bntLuuTBTB.Name = "bntLuuTBTB";
            this.bntLuuTBTB.Size = new System.Drawing.Size(75, 36);
            this.bntLuuTBTB.TabIndex = 54;
            this.bntLuuTBTB.Text = "Lưu";
            this.bntLuuTBTB.UseVisualStyleBackColor = true;
            this.bntLuuTBTB.Click += new System.EventHandler(this.bntLuuTBTB_Click);
            // 
            // bntThem
            // 
            this.bntThem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntThem.Location = new System.Drawing.Point(399, 15);
            this.bntThem.Name = "bntThem";
            this.bntThem.Size = new System.Drawing.Size(75, 23);
            this.bntThem.TabIndex = 55;
            this.bntThem.Text = "Thêm";
            this.bntThem.UseVisualStyleBackColor = true;
            this.bntThem.Click += new System.EventHandler(this.bntThem_Click);
            // 
            // bntXoa
            // 
            this.bntXoa.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntXoa.Location = new System.Drawing.Point(399, 48);
            this.bntXoa.Name = "bntXoa";
            this.bntXoa.Size = new System.Drawing.Size(75, 23);
            this.bntXoa.TabIndex = 56;
            this.bntXoa.Text = "Xóa";
            this.bntXoa.UseVisualStyleBackColor = true;
            this.bntXoa.Click += new System.EventHandler(this.bntXoa_Click);
            // 
            // bntSua
            // 
            this.bntSua.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntSua.Location = new System.Drawing.Point(499, 15);
            this.bntSua.Name = "bntSua";
            this.bntSua.Size = new System.Drawing.Size(75, 23);
            this.bntSua.TabIndex = 57;
            this.bntSua.Text = "Sửa";
            this.bntSua.UseVisualStyleBackColor = true;
            this.bntSua.Click += new System.EventHandler(this.bntSua_Click);
            // 
            // bntTimKiem
            // 
            this.bntTimKiem.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntTimKiem.Location = new System.Drawing.Point(499, 48);
            this.bntTimKiem.Name = "bntTimKiem";
            this.bntTimKiem.Size = new System.Drawing.Size(75, 23);
            this.bntTimKiem.TabIndex = 58;
            this.bntTimKiem.Text = "Tìm kiếm";
            this.bntTimKiem.UseVisualStyleBackColor = true;
            this.bntTimKiem.Click += new System.EventHandler(this.bntTimKiem_Click);
            // 
            // bntBack
            // 
            this.bntBack.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bntBack.Location = new System.Drawing.Point(606, 66);
            this.bntBack.Name = "bntBack";
            this.bntBack.Size = new System.Drawing.Size(75, 41);
            this.bntBack.TabIndex = 59;
            this.bntBack.Text = "Thoát";
            this.bntBack.UseVisualStyleBackColor = true;
            this.bntBack.Click += new System.EventHandler(this.bntBack_Click);
            // 
            // frmTBThietBi
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(693, 339);
            this.Controls.Add(this.bntBack);
            this.Controls.Add(this.bntTimKiem);
            this.Controls.Add(this.bntSua);
            this.Controls.Add(this.bntXoa);
            this.Controls.Add(this.bntThem);
            this.Controls.Add(this.bntLuuTBTB);
            this.Controls.Add(this.grbChonTBTB);
            this.Controls.Add(this.dgvTBTB);
            this.Controls.Add(this.cbxMaTB);
            this.Controls.Add(this.cbxSoPhong);
            this.Controls.Add(this.lblIDPhong);
            this.Controls.Add(this.txtSoluongTB);
            this.Controls.Add(this.lblSLTB);
            this.Controls.Add(this.lblMaTB);
            this.Name = "frmTBThietBi";
            this.Text = "FormTBThietBi";
            this.Load += new System.EventHandler(this.FormTBThietBi_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTBTB)).EndInit();
            this.grbChonTBTB.ResumeLayout(false);
            this.grbChonTBTB.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxMaTB;
        private System.Windows.Forms.ComboBox cbxSoPhong;
        private System.Windows.Forms.Label lblIDPhong;
        private System.Windows.Forms.TextBox txtSoluongTB;
        private System.Windows.Forms.Label lblSLTB;
        private System.Windows.Forms.Label lblMaTB;
        private System.Windows.Forms.DataGridView dgvTBTB;
        private System.Windows.Forms.GroupBox grbChonTBTB;
        private System.Windows.Forms.RadioButton rdbtinhtrang;
        private System.Windows.Forms.RadioButton rdbPhong;
        private System.Windows.Forms.Button bntLuuTBTB;
        private System.Windows.Forms.Button bntThem;
        private System.Windows.Forms.Button bntXoa;
        private System.Windows.Forms.Button bntSua;
        private System.Windows.Forms.Button bntTimKiem;
        private System.Windows.Forms.Button bntSearch;
        private System.Windows.Forms.Button bntBack;
    }
}