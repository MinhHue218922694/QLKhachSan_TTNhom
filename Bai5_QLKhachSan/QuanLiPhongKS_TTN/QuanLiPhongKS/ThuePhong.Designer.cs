namespace QLPhongKS
{
    partial class frmThuePhong
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
            this.bntThêmKH = new System.Windows.Forms.Button();
            this.bntThue = new System.Windows.Forms.Button();
            this.bntLayPhong = new System.Windows.Forms.Button();
            this.dtgThuePhong = new System.Windows.Forms.DataGridView();
            this.Chon = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblTiendc = new System.Windows.Forms.Label();
            this.txtTienThue = new System.Windows.Forms.TextBox();
            this.lblBaoLoi = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dTPTGKT = new System.Windows.Forms.DateTimePicker();
            this.dTPTGBD = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.dTPNS = new System.Windows.Forms.DateTimePicker();
            this.lblBaoLoicmnd = new System.Windows.Forms.Label();
            this.lblBaoLoiSDT = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtgThuePhong)).BeginInit();
            this.groupBox1.SuspendLayout();
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
            this.cbxGT.Location = new System.Drawing.Point(115, 77);
            this.cbxGT.Name = "cbxGT";
            this.cbxGT.Size = new System.Drawing.Size(121, 23);
            this.cbxGT.TabIndex = 67;
            // 
            // txtQuocTich
            // 
            this.txtQuocTich.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuocTich.Location = new System.Drawing.Point(115, 139);
            this.txtQuocTich.Name = "txtQuocTich";
            this.txtQuocTich.Size = new System.Drawing.Size(175, 22);
            this.txtQuocTich.TabIndex = 65;
            // 
            // txtSDT
            // 
            this.txtSDT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSDT.Location = new System.Drawing.Point(115, 196);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(175, 22);
            this.txtSDT.TabIndex = 64;
            this.txtSDT.TextChanged += new System.EventHandler(this.txtSDT_TextChanged);
            // 
            // txtCMND
            // 
            this.txtCMND.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCMND.Location = new System.Drawing.Point(115, 168);
            this.txtCMND.Name = "txtCMND";
            this.txtCMND.Size = new System.Drawing.Size(175, 22);
            this.txtCMND.TabIndex = 63;
            this.txtCMND.TextChanged += new System.EventHandler(this.txtCMND_TextChanged);
            // 
            // lblQuocTich
            // 
            this.lblQuocTich.AutoSize = true;
            this.lblQuocTich.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuocTich.Location = new System.Drawing.Point(10, 142);
            this.lblQuocTich.Name = "lblQuocTich";
            this.lblQuocTich.Size = new System.Drawing.Size(64, 15);
            this.lblQuocTich.TabIndex = 62;
            this.lblQuocTich.Text = "Quốc Tịch";
            // 
            // lblSDT
            // 
            this.lblSDT.AutoSize = true;
            this.lblSDT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSDT.Location = new System.Drawing.Point(12, 197);
            this.lblSDT.Name = "lblSDT";
            this.lblSDT.Size = new System.Drawing.Size(77, 15);
            this.lblSDT.TabIndex = 61;
            this.lblSDT.Text = "Số điện thoại";
            // 
            // lblCMND
            // 
            this.lblCMND.AutoSize = true;
            this.lblCMND.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCMND.Location = new System.Drawing.Point(12, 169);
            this.lblCMND.Name = "lblCMND";
            this.lblCMND.Size = new System.Drawing.Size(45, 15);
            this.lblCMND.TabIndex = 60;
            this.lblCMND.Text = "CMND";
            // 
            // txtQueQuan
            // 
            this.txtQueQuan.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQueQuan.Location = new System.Drawing.Point(115, 106);
            this.txtQueQuan.Name = "txtQueQuan";
            this.txtQueQuan.Size = new System.Drawing.Size(175, 22);
            this.txtQueQuan.TabIndex = 59;
            // 
            // txtTenKH
            // 
            this.txtTenKH.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTenKH.Location = new System.Drawing.Point(115, 18);
            this.txtTenKH.Name = "txtTenKH";
            this.txtTenKH.Size = new System.Drawing.Size(175, 22);
            this.txtTenKH.TabIndex = 58;
            // 
            // lblGT
            // 
            this.lblGT.AutoSize = true;
            this.lblGT.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGT.Location = new System.Drawing.Point(12, 79);
            this.lblGT.Name = "lblGT";
            this.lblGT.Size = new System.Drawing.Size(60, 15);
            this.lblGT.TabIndex = 57;
            this.lblGT.Text = "Giới Tính";
            // 
            // lblQueQuan
            // 
            this.lblQueQuan.AutoSize = true;
            this.lblQueQuan.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQueQuan.Location = new System.Drawing.Point(10, 109);
            this.lblQueQuan.Name = "lblQueQuan";
            this.lblQueQuan.Size = new System.Drawing.Size(63, 15);
            this.lblQueQuan.TabIndex = 56;
            this.lblQueQuan.Text = "Quê Quán";
            // 
            // lblTenKH
            // 
            this.lblTenKH.AutoSize = true;
            this.lblTenKH.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTenKH.Location = new System.Drawing.Point(10, 21);
            this.lblTenKH.Name = "lblTenKH";
            this.lblTenKH.Size = new System.Drawing.Size(98, 15);
            this.lblTenKH.TabIndex = 55;
            this.lblTenKH.Text = "Tên Khách Hàng";
            // 
            // bntThêmKH
            // 
            this.bntThêmKH.Enabled = false;
            this.bntThêmKH.Location = new System.Drawing.Point(310, 17);
            this.bntThêmKH.Name = "bntThêmKH";
            this.bntThêmKH.Size = new System.Drawing.Size(117, 23);
            this.bntThêmKH.TabIndex = 68;
            this.bntThêmKH.Text = "Thêm Khách Hàng";
            this.bntThêmKH.UseVisualStyleBackColor = true;
            this.bntThêmKH.Click += new System.EventHandler(this.bntThêmKH_Click);
            // 
            // bntThue
            // 
            this.bntThue.Enabled = false;
            this.bntThue.Location = new System.Drawing.Point(323, 85);
            this.bntThue.Name = "bntThue";
            this.bntThue.Size = new System.Drawing.Size(75, 63);
            this.bntThue.TabIndex = 69;
            this.bntThue.Text = "Thuê";
            this.bntThue.UseVisualStyleBackColor = true;
            this.bntThue.Click += new System.EventHandler(this.bntThue_Click);
            // 
            // bntLayPhong
            // 
            this.bntLayPhong.Enabled = false;
            this.bntLayPhong.Location = new System.Drawing.Point(323, 52);
            this.bntLayPhong.Name = "bntLayPhong";
            this.bntLayPhong.Size = new System.Drawing.Size(75, 23);
            this.bntLayPhong.TabIndex = 70;
            this.bntLayPhong.Text = "Lấy phòng";
            this.bntLayPhong.UseVisualStyleBackColor = true;
            this.bntLayPhong.Click += new System.EventHandler(this.bntLayPhong_Click);
            // 
            // dtgThuePhong
            // 
            this.dtgThuePhong.AllowUserToAddRows = false;
            this.dtgThuePhong.AllowUserToDeleteRows = false;
            this.dtgThuePhong.AllowUserToResizeColumns = false;
            this.dtgThuePhong.AllowUserToResizeRows = false;
            this.dtgThuePhong.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dtgThuePhong.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgThuePhong.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Chon});
            this.dtgThuePhong.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.dtgThuePhong.Location = new System.Drawing.Point(0, 256);
            this.dtgThuePhong.Name = "dtgThuePhong";
            this.dtgThuePhong.Size = new System.Drawing.Size(828, 204);
            this.dtgThuePhong.TabIndex = 71;
            // 
            // Chon
            // 
            this.Chon.HeaderText = "Chọn";
            this.Chon.Name = "Chon";
            this.Chon.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Chon.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblTiendc);
            this.groupBox1.Controls.Add(this.txtTienThue);
            this.groupBox1.Controls.Add(this.lblBaoLoi);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dTPTGKT);
            this.groupBox1.Controls.Add(this.dTPTGBD);
            this.groupBox1.Location = new System.Drawing.Point(508, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(308, 149);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lấy thời gian thuê";
            // 
            // lblTiendc
            // 
            this.lblTiendc.AutoSize = true;
            this.lblTiendc.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTiendc.Location = new System.Drawing.Point(6, 98);
            this.lblTiendc.Name = "lblTiendc";
            this.lblTiendc.Size = new System.Drawing.Size(72, 15);
            this.lblTiendc.TabIndex = 80;
            this.lblTiendc.Text = "Tiền đặt cọc";
            // 
            // txtTienThue
            // 
            this.txtTienThue.Location = new System.Drawing.Point(102, 96);
            this.txtTienThue.Name = "txtTienThue";
            this.txtTienThue.Size = new System.Drawing.Size(175, 20);
            this.txtTienThue.TabIndex = 79;
            this.txtTienThue.TextChanged += new System.EventHandler(this.txtTienThue_TextChanged);
            // 
            // lblBaoLoi
            // 
            this.lblBaoLoi.AutoSize = true;
            this.lblBaoLoi.Location = new System.Drawing.Point(15, 124);
            this.lblBaoLoi.Name = "lblBaoLoi";
            this.lblBaoLoi.Size = new System.Drawing.Size(55, 13);
            this.lblBaoLoi.TabIndex = 74;
            this.lblBaoLoi.Text = "thong bao";
            this.lblBaoLoi.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(93, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Thời gian kết thúc";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Thời gian bắt đầu";
            // 
            // dTPTGKT
            // 
            this.dTPTGKT.Location = new System.Drawing.Point(102, 58);
            this.dTPTGKT.Name = "dTPTGKT";
            this.dTPTGKT.Size = new System.Drawing.Size(200, 20);
            this.dTPTGKT.TabIndex = 2;
            // 
            // dTPTGBD
            // 
            this.dTPTGBD.Location = new System.Drawing.Point(102, 19);
            this.dTPTGBD.Name = "dTPTGBD";
            this.dTPTGBD.Size = new System.Drawing.Size(200, 20);
            this.dTPTGBD.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 15);
            this.label4.TabIndex = 75;
            this.label4.Text = "Ngày sinh";
            // 
            // dTPNS
            // 
            this.dTPNS.Location = new System.Drawing.Point(115, 51);
            this.dTPNS.Name = "dTPNS";
            this.dTPNS.Size = new System.Drawing.Size(175, 20);
            this.dTPNS.TabIndex = 76;
            // 
            // lblBaoLoicmnd
            // 
            this.lblBaoLoicmnd.AutoSize = true;
            this.lblBaoLoicmnd.Location = new System.Drawing.Point(320, 172);
            this.lblBaoLoicmnd.Name = "lblBaoLoicmnd";
            this.lblBaoLoicmnd.Size = new System.Drawing.Size(55, 13);
            this.lblBaoLoicmnd.TabIndex = 77;
            this.lblBaoLoicmnd.Text = "thong bao";
            this.lblBaoLoicmnd.Visible = false;
            // 
            // lblBaoLoiSDT
            // 
            this.lblBaoLoiSDT.AutoSize = true;
            this.lblBaoLoiSDT.Location = new System.Drawing.Point(320, 200);
            this.lblBaoLoiSDT.Name = "lblBaoLoiSDT";
            this.lblBaoLoiSDT.Size = new System.Drawing.Size(55, 13);
            this.lblBaoLoiSDT.TabIndex = 78;
            this.lblBaoLoiSDT.Text = "thong bao";
            this.lblBaoLoiSDT.Visible = false;
            // 
            // frmThuePhong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(828, 460);
            this.Controls.Add(this.lblBaoLoiSDT);
            this.Controls.Add(this.lblBaoLoicmnd);
            this.Controls.Add(this.dTPNS);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dtgThuePhong);
            this.Controls.Add(this.bntLayPhong);
            this.Controls.Add(this.bntThue);
            this.Controls.Add(this.bntThêmKH);
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
            this.Name = "frmThuePhong";
            this.Text = "ThuePhong";
            this.Load += new System.EventHandler(this.ThuePhong_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtgThuePhong)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
        private System.Windows.Forms.Button bntThêmKH;
        private System.Windows.Forms.Button bntThue;
        private System.Windows.Forms.Button bntLayPhong;
        private System.Windows.Forms.DataGridView dtgThuePhong;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Chon;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dTPTGKT;
        private System.Windows.Forms.DateTimePicker dTPTGBD;
        private System.Windows.Forms.Label lblBaoLoi;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dTPNS;
        private System.Windows.Forms.Label lblTiendc;
        private System.Windows.Forms.TextBox txtTienThue;
        private System.Windows.Forms.Label lblBaoLoicmnd;
        private System.Windows.Forms.Label lblBaoLoiSDT;
    }
}