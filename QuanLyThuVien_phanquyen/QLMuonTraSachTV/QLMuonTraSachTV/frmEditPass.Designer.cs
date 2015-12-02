namespace QLMuonTraSachTV
{
    partial class frmEditPass
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
            this.buttonX2 = new DevComponents.DotNetBar.ButtonX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            this.labelX3 = new DevComponents.DotNetBar.LabelX();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.txtRenewPas = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtNewPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.txtOldPass = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.SuspendLayout();
            // 
            // buttonX2
            // 
            this.buttonX2.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX2.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX2.Location = new System.Drawing.Point(180, 166);
            this.buttonX2.Name = "buttonX2";
            this.buttonX2.Size = new System.Drawing.Size(83, 45);
            this.buttonX2.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX2.TabIndex = 8;
            this.buttonX2.Text = "Thoát";
            this.buttonX2.Click += new System.EventHandler(this.buttonX2_Click);
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(52, 166);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(92, 45);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 9;
            this.buttonX1.Text = "Lưu";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // labelX3
            // 
            // 
            // 
            // 
            this.labelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelX3.Location = new System.Drawing.Point(12, 120);
            this.labelX3.Name = "labelX3";
            this.labelX3.Size = new System.Drawing.Size(114, 23);
            this.labelX3.TabIndex = 4;
            this.labelX3.Text = "Nhập lại MK Mới";
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.labelX2.Location = new System.Drawing.Point(12, 73);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(97, 23);
            this.labelX2.TabIndex = 5;
            this.labelX2.Text = "Mật Khẩu Mới";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.labelX1.Location = new System.Drawing.Point(12, 17);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(97, 23);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "Mật Khẩu Cũ";
            // 
            // txtRenewPas
            // 
            // 
            // 
            // 
            this.txtRenewPas.Border.Class = "TextBoxBorder";
            this.txtRenewPas.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtRenewPas.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtRenewPas.Location = new System.Drawing.Point(132, 120);
            this.txtRenewPas.Name = "txtRenewPas";
            this.txtRenewPas.PreventEnterBeep = true;
            this.txtRenewPas.Size = new System.Drawing.Size(156, 23);
            this.txtRenewPas.TabIndex = 10;
            this.txtRenewPas.UseSystemPasswordChar = true;
            // 
            // txtNewPass
            // 
            // 
            // 
            // 
            this.txtNewPass.Border.Class = "TextBoxBorder";
            this.txtNewPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtNewPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtNewPass.Location = new System.Drawing.Point(132, 73);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.PreventEnterBeep = true;
            this.txtNewPass.Size = new System.Drawing.Size(156, 23);
            this.txtNewPass.TabIndex = 7;
            this.txtNewPass.UseSystemPasswordChar = true;
            // 
            // txtOldPass
            // 
            // 
            // 
            // 
            this.txtOldPass.Border.Class = "TextBoxBorder";
            this.txtOldPass.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtOldPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.txtOldPass.Location = new System.Drawing.Point(132, 17);
            this.txtOldPass.Name = "txtOldPass";
            this.txtOldPass.PreventEnterBeep = true;
            this.txtOldPass.Size = new System.Drawing.Size(156, 23);
            this.txtOldPass.TabIndex = 3;
            this.txtOldPass.UseSystemPasswordChar = true;
            // 
            // frmEditPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 223);
            this.Controls.Add(this.buttonX2);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.labelX3);
            this.Controls.Add(this.labelX2);
            this.Controls.Add(this.labelX1);
            this.Controls.Add(this.txtRenewPas);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.txtOldPass);
            this.DoubleBuffered = true;
            this.Name = "frmEditPass";
            this.Text = "frmEditPass";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.ButtonX buttonX2;
        private DevComponents.DotNetBar.ButtonX buttonX1;
        private DevComponents.DotNetBar.LabelX labelX3;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.DotNetBar.Controls.TextBoxX txtRenewPas;
        private DevComponents.DotNetBar.Controls.TextBoxX txtNewPass;
        private DevComponents.DotNetBar.Controls.TextBoxX txtOldPass;
    }
}