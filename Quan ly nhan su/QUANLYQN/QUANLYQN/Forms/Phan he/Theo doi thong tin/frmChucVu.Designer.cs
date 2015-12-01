namespace QUANLYQN.Forms.Phan_he.Theo_doi_thong_tin
{
    partial class frmChucVu
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
            this.txtNgayNhan = new AMS.TextBox.DateTextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gbThongTinSuaDoi = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cboChucVu = new System.Windows.Forms.ComboBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gbThongTinSuaDoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNgayNhan
            // 
            this.txtNgayNhan.Flags = 65536;
            this.txtNgayNhan.Location = new System.Drawing.Point(109, 59);
            this.txtNgayNhan.Name = "txtNgayNhan";
            this.txtNgayNhan.RangeMax = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtNgayNhan.RangeMin = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtNgayNhan.Size = new System.Drawing.Size(131, 22);
            this.txtNgayNhan.TabIndex = 13;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(109, 91);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(245, 41);
            this.txtGhiChu.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Chức vụ";
            // 
            // gbThongTinSuaDoi
            // 
            this.gbThongTinSuaDoi.Controls.Add(this.txtNgayNhan);
            this.gbThongTinSuaDoi.Controls.Add(this.txtGhiChu);
            this.gbThongTinSuaDoi.Controls.Add(this.label2);
            this.gbThongTinSuaDoi.Controls.Add(this.label3);
            this.gbThongTinSuaDoi.Controls.Add(this.label4);
            this.gbThongTinSuaDoi.Controls.Add(this.cboChucVu);
            this.gbThongTinSuaDoi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbThongTinSuaDoi.Location = new System.Drawing.Point(21, 13);
            this.gbThongTinSuaDoi.Name = "gbThongTinSuaDoi";
            this.gbThongTinSuaDoi.Size = new System.Drawing.Size(372, 158);
            this.gbThongTinSuaDoi.TabIndex = 6;
            this.gbThongTinSuaDoi.TabStop = false;
            this.gbThongTinSuaDoi.Text = "Thông tin sửa đổi";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 16);
            this.label3.TabIndex = 9;
            this.label3.Text = "Ngày nhận";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ghi chú";
            // 
            // cboChucVu
            // 
            this.cboChucVu.FormattingEnabled = true;
            this.cboChucVu.Location = new System.Drawing.Point(109, 25);
            this.cboChucVu.Name = "cboChucVu";
            this.cboChucVu.Size = new System.Drawing.Size(132, 24);
            this.cboChucVu.TabIndex = 6;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(46, 179);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(86, 26);
            this.btnHuy.TabIndex = 12;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(160, 179);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(86, 26);
            this.btnLuu.TabIndex = 10;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(274, 179);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 26);
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmChucVu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 217);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.gbThongTinSuaDoi);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmChucVu";
            this.Text = "frmChucVu";
            this.Load += new System.EventHandler(this.frmChucVu_Load);
            this.gbThongTinSuaDoi.ResumeLayout(false);
            this.gbThongTinSuaDoi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AMS.TextBox.DateTextBox txtNgayNhan;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbThongTinSuaDoi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboChucVu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThoat;
    }
}