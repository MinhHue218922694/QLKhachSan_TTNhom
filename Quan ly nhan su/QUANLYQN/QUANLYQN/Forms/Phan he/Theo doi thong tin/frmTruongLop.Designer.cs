namespace QUANLYQN.Forms.Phan_he.Theo_doi_thong_tin
{
    partial class frmTruongLop
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
            this.gbThongTinSuaDoi = new System.Windows.Forms.GroupBox();
            this.txtThoiGianKT = new AMS.TextBox.DateTextBox();
            this.txtThoiGianBD = new AMS.TextBox.DateTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNganhHoc = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cboTenTruong = new System.Windows.Forms.ComboBox();
            this.cboCapHoc = new System.Windows.Forms.ComboBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gbThongTinSuaDoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbThongTinSuaDoi
            // 
            this.gbThongTinSuaDoi.Controls.Add(this.txtThoiGianKT);
            this.gbThongTinSuaDoi.Controls.Add(this.txtThoiGianBD);
            this.gbThongTinSuaDoi.Controls.Add(this.label1);
            this.gbThongTinSuaDoi.Controls.Add(this.label2);
            this.gbThongTinSuaDoi.Controls.Add(this.label3);
            this.gbThongTinSuaDoi.Controls.Add(this.label4);
            this.gbThongTinSuaDoi.Controls.Add(this.label5);
            this.gbThongTinSuaDoi.Controls.Add(this.txtNganhHoc);
            this.gbThongTinSuaDoi.Controls.Add(this.txtGhiChu);
            this.gbThongTinSuaDoi.Controls.Add(this.label6);
            this.gbThongTinSuaDoi.Controls.Add(this.cboTenTruong);
            this.gbThongTinSuaDoi.Controls.Add(this.cboCapHoc);
            this.gbThongTinSuaDoi.Location = new System.Drawing.Point(20, 10);
            this.gbThongTinSuaDoi.Name = "gbThongTinSuaDoi";
            this.gbThongTinSuaDoi.Size = new System.Drawing.Size(375, 252);
            this.gbThongTinSuaDoi.TabIndex = 6;
            this.gbThongTinSuaDoi.TabStop = false;
            this.gbThongTinSuaDoi.Text = "Thông tin sửa đổi";
            // 
            // txtThoiGianKT
            // 
            this.txtThoiGianKT.Flags = 65536;
            this.txtThoiGianKT.Location = new System.Drawing.Point(132, 151);
            this.txtThoiGianKT.Name = "txtThoiGianKT";
            this.txtThoiGianKT.RangeMax = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtThoiGianKT.RangeMin = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtThoiGianKT.Size = new System.Drawing.Size(234, 22);
            this.txtThoiGianKT.TabIndex = 18;
            // 
            // txtThoiGianBD
            // 
            this.txtThoiGianBD.Flags = 65536;
            this.txtThoiGianBD.Location = new System.Drawing.Point(132, 120);
            this.txtThoiGianBD.Name = "txtThoiGianBD";
            this.txtThoiGianBD.RangeMax = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtThoiGianBD.RangeMin = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtThoiGianBD.Size = new System.Drawing.Size(234, 22);
            this.txtThoiGianBD.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "Tên trường";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 9;
            this.label2.Text = "Cấp học";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Ngành học";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Thời gian bắt đầu";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(113, 16);
            this.label5.TabIndex = 14;
            this.label5.Text = "Thời gian kết thúc";
            // 
            // txtNganhHoc
            // 
            this.txtNganhHoc.Location = new System.Drawing.Point(132, 88);
            this.txtNganhHoc.Name = "txtNganhHoc";
            this.txtNganhHoc.Size = new System.Drawing.Size(234, 22);
            this.txtNganhHoc.TabIndex = 11;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(132, 187);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(234, 49);
            this.txtGhiChu.TabIndex = 17;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 189);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 16);
            this.label6.TabIndex = 16;
            this.label6.Text = "Ghi chú";
            // 
            // cboTenTruong
            // 
            this.cboTenTruong.FormattingEnabled = true;
            this.cboTenTruong.Location = new System.Drawing.Point(132, 18);
            this.cboTenTruong.Name = "cboTenTruong";
            this.cboTenTruong.Size = new System.Drawing.Size(234, 24);
            this.cboTenTruong.TabIndex = 6;
            // 
            // cboCapHoc
            // 
            this.cboCapHoc.FormattingEnabled = true;
            this.cboCapHoc.Location = new System.Drawing.Point(132, 53);
            this.cboCapHoc.Name = "cboCapHoc";
            this.cboCapHoc.Size = new System.Drawing.Size(234, 24);
            this.cboCapHoc.TabIndex = 8;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(49, 269);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(86, 26);
            this.btnHuy.TabIndex = 15;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(163, 269);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(86, 26);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(277, 269);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 26);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmTruongLop
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 307);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.gbThongTinSuaDoi);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmTruongLop";
            this.Text = "frmTruongLop";
            this.Load += new System.EventHandler(this.frmTruongLop_Load);
            this.gbThongTinSuaDoi.ResumeLayout(false);
            this.gbThongTinSuaDoi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbThongTinSuaDoi;
        private AMS.TextBox.DateTextBox txtThoiGianKT;
        private AMS.TextBox.DateTextBox txtThoiGianBD;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNganhHoc;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboTenTruong;
        private System.Windows.Forms.ComboBox cboCapHoc;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThoat;
    }
}