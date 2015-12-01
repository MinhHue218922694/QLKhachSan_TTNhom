namespace QUANLYQN.Forms.Phan_he.Theo_doi_thong_tin
{
    partial class frmKyLuat
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
            this.txtNgayQD = new AMS.TextBox.DateTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.gbThongTinSuaDoi = new System.Windows.Forms.GroupBox();
            this.cboHTKyLuat = new System.Windows.Forms.ComboBox();
            this.txtCapKyLuat = new System.Windows.Forms.TextBox();
            this.txtGhiChu = new System.Windows.Forms.TextBox();
            this.btnHuy = new System.Windows.Forms.Button();
            this.btnLuu = new System.Windows.Forms.Button();
            this.btnThoat = new System.Windows.Forms.Button();
            this.gbThongTinSuaDoi.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNgayQD
            // 
            this.txtNgayQD.Flags = 65536;
            this.txtNgayQD.Location = new System.Drawing.Point(129, 85);
            this.txtNgayQD.Name = "txtNgayQD";
            this.txtNgayQD.RangeMax = new System.DateTime(9998, 12, 31, 0, 0, 0, 0);
            this.txtNgayQD.RangeMin = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
            this.txtNgayQD.Size = new System.Drawing.Size(228, 22);
            this.txtNgayQD.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 16);
            this.label4.TabIndex = 11;
            this.label4.Text = "Ghi chú";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Ngày quyết định";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Hình thức kỷ luật";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Cấp kỷ luật";
            // 
            // gbThongTinSuaDoi
            // 
            this.gbThongTinSuaDoi.Controls.Add(this.txtNgayQD);
            this.gbThongTinSuaDoi.Controls.Add(this.label4);
            this.gbThongTinSuaDoi.Controls.Add(this.label3);
            this.gbThongTinSuaDoi.Controls.Add(this.label1);
            this.gbThongTinSuaDoi.Controls.Add(this.label2);
            this.gbThongTinSuaDoi.Controls.Add(this.cboHTKyLuat);
            this.gbThongTinSuaDoi.Controls.Add(this.txtCapKyLuat);
            this.gbThongTinSuaDoi.Controls.Add(this.txtGhiChu);
            this.gbThongTinSuaDoi.Location = new System.Drawing.Point(21, 12);
            this.gbThongTinSuaDoi.Name = "gbThongTinSuaDoi";
            this.gbThongTinSuaDoi.Size = new System.Drawing.Size(372, 176);
            this.gbThongTinSuaDoi.TabIndex = 6;
            this.gbThongTinSuaDoi.TabStop = false;
            this.gbThongTinSuaDoi.Text = "Thông tin sửa đổi";
            // 
            // cboHTKyLuat
            // 
            this.cboHTKyLuat.FormattingEnabled = true;
            this.cboHTKyLuat.Location = new System.Drawing.Point(129, 18);
            this.cboHTKyLuat.Name = "cboHTKyLuat";
            this.cboHTKyLuat.Size = new System.Drawing.Size(228, 24);
            this.cboHTKyLuat.TabIndex = 5;
            // 
            // txtCapKyLuat
            // 
            this.txtCapKyLuat.Location = new System.Drawing.Point(129, 53);
            this.txtCapKyLuat.Name = "txtCapKyLuat";
            this.txtCapKyLuat.Size = new System.Drawing.Size(228, 22);
            this.txtCapKyLuat.TabIndex = 7;
            // 
            // txtGhiChu
            // 
            this.txtGhiChu.Location = new System.Drawing.Point(129, 119);
            this.txtGhiChu.Multiline = true;
            this.txtGhiChu.Name = "txtGhiChu";
            this.txtGhiChu.Size = new System.Drawing.Size(228, 41);
            this.txtGhiChu.TabIndex = 10;
            // 
            // btnHuy
            // 
            this.btnHuy.Location = new System.Drawing.Point(51, 197);
            this.btnHuy.Name = "btnHuy";
            this.btnHuy.Size = new System.Drawing.Size(86, 26);
            this.btnHuy.TabIndex = 15;
            this.btnHuy.Text = "Hủy";
            this.btnHuy.UseVisualStyleBackColor = true;
            this.btnHuy.Click += new System.EventHandler(this.btnHuy_Click);
            // 
            // btnLuu
            // 
            this.btnLuu.Location = new System.Drawing.Point(165, 197);
            this.btnLuu.Name = "btnLuu";
            this.btnLuu.Size = new System.Drawing.Size(86, 26);
            this.btnLuu.TabIndex = 13;
            this.btnLuu.Text = "Lưu";
            this.btnLuu.UseVisualStyleBackColor = true;
            this.btnLuu.Click += new System.EventHandler(this.btnLuu_Click);
            // 
            // btnThoat
            // 
            this.btnThoat.Location = new System.Drawing.Point(279, 197);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 26);
            this.btnThoat.TabIndex = 14;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // frmKyLuat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 242);
            this.Controls.Add(this.btnHuy);
            this.Controls.Add(this.btnLuu);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.gbThongTinSuaDoi);
            this.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "frmKyLuat";
            this.Text = "frmKyLuat";
            this.Load += new System.EventHandler(this.frmKyLuat_Load);
            this.gbThongTinSuaDoi.ResumeLayout(false);
            this.gbThongTinSuaDoi.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private AMS.TextBox.DateTextBox txtNgayQD;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox gbThongTinSuaDoi;
        private System.Windows.Forms.ComboBox cboHTKyLuat;
        private System.Windows.Forms.TextBox txtCapKyLuat;
        private System.Windows.Forms.TextBox txtGhiChu;
        private System.Windows.Forms.Button btnHuy;
        private System.Windows.Forms.Button btnLuu;
        private System.Windows.Forms.Button btnThoat;
    }
}