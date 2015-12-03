namespace QuanLiNhanSu
{
    partial class frmMenu
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
            this.MenuMain = new System.Windows.Forms.MenuStrip();
            this.HoSo = new System.Windows.Forms.ToolStripMenuItem();
            this.ChiDan = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // MenuMain
            // 
            this.MenuMain.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HoSo,
            this.ChiDan});
            this.MenuMain.Location = new System.Drawing.Point(0, 0);
            this.MenuMain.Name = "MenuMain";
            this.MenuMain.Size = new System.Drawing.Size(471, 24);
            this.MenuMain.TabIndex = 0;
            this.MenuMain.Text = "Menuchinh";
            // 
            // HoSo
            // 
            this.HoSo.Name = "HoSo";
            this.HoSo.Size = new System.Drawing.Size(50, 20);
            this.HoSo.Text = "Hồ sơ";
            this.HoSo.Click += new System.EventHandler(this.HoSo_Click);
            // 
            // ChiDan
            // 
            this.ChiDan.Name = "ChiDan";
            this.ChiDan.Size = new System.Drawing.Size(61, 20);
            this.ChiDan.Text = "Chỉ dẫn";
            this.ChiDan.Click += new System.EventHandler(this.ChiDan_Click);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::QuanLiNhanSu.Properties.Resources.marketshare;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(471, 262);
            this.Controls.Add(this.MenuMain);
            this.MainMenuStrip = this.MenuMain;
            this.Name = "frmMenu";
            this.Text = "Menu";
            this.MenuMain.ResumeLayout(false);
            this.MenuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuMain;
        private System.Windows.Forms.ToolStripMenuItem HoSo;
        private System.Windows.Forms.ToolStripMenuItem ChiDan;
    }
}