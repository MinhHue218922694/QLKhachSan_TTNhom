namespace QLMuonTraSachTV
{
    partial class frmDangNhap
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
            this.btnThoat = new DevComponents.DotNetBar.ButtonX();
            this.btnDangNhat = new DevComponents.DotNetBar.ButtonX();
            this.txtPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.txtUser = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnThoat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnThoat.Location = new System.Drawing.Point(168, 158);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(111, 41);
            this.btnThoat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnThoat.TabIndex = 11;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // btnDangNhat
            // 
            this.btnDangNhat.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnDangNhat.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnDangNhat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.btnDangNhat.Location = new System.Drawing.Point(45, 158);
            this.btnDangNhat.Name = "btnDangNhat";
            this.btnDangNhat.Size = new System.Drawing.Size(105, 41);
            this.btnDangNhat.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnDangNhat.TabIndex = 10;
            this.btnDangNhat.Text = "Đăng Nhập";
            this.btnDangNhat.Click += new System.EventHandler(this.btnDangNhat_Click);
            // 
            // txtPass
            // 
            // 
            // 
            // 
            this.txtPass.Border.Class = "TextBoxBorder";
            this.txtPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtPass.Location = new System.Drawing.Point(112, 76);
            this.txtPass.Name = "txtPass";
            this.txtPass.PreventEnterBeep = true;
            this.txtPass.Size = new System.Drawing.Size(167, 20);
            this.txtPass.TabIndex = 9;
            this.txtPass.UseSystemPasswordChar = true;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelX2.Location = new System.Drawing.Point(12, 76);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(94, 23);
            this.labelX2.TabIndex = 8;
            this.labelX2.Text = "PassWord";
            // 
            // txtUser
            // 
            // 
            // 
            // 
            this.txtUser.Border.Class = "TextBoxBorder";
            this.txtUser.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtUser.Location = new System.Drawing.Point(112, 29);
            this.txtUser.Name = "txtUser";
            this.txtUser.PreventEnterBeep = true;
            this.txtUser.Size = new System.Drawing.Size(167, 20);
            this.txtUser.TabIndex = 7;
//            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
//            this.txtUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtUser_KeyPress);
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.labelX1.Location = new System.Drawing.Point(31, 29);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(75, 23);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "User";
            // 
            // frmDangNhap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 237);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.btnDangNhat);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.txtUser);
            this.Controls.Add(this.labelX1);
            this.DoubleBuffered = true;
            this.Name = "frmDangNhap";
            this.Text = "frmDangNhap";
            this.Load += new System.EventHandler(this.frmDangNhap_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX btnThoat;
        private DevComponents.DotNetBar.ButtonX btnDangNhat;
        private DevComponents.DotNetBar.Controls.TextBoxX txtPass;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtUser;
        private DevComponents.DotNetBar.LabelX labelX1;
    }
}