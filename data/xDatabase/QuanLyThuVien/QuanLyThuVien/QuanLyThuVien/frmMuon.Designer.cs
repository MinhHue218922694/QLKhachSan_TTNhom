namespace QuanLyThuVien
{
    partial class frmMuon
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
            this.dgvSach = new System.Windows.Forms.DataGridView();
            this.dgvDocGia = new System.Windows.Forms.DataGridView();
            this.txtSearchSach = new System.Windows.Forms.TextBox();
            this.txtSearchDG = new System.Windows.Forms.TextBox();
            this.txtMaSach = new System.Windows.Forms.TextBox();
            this.txtMaThe = new System.Windows.Forms.TextBox();
            this.txtTenSach = new System.Windows.Forms.TextBox();
            this.txtTenDocGia = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvSach
            // 
            this.dgvSach.AllowUserToAddRows = false;
            this.dgvSach.AllowUserToDeleteRows = false;
            this.dgvSach.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvSach.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSach.Location = new System.Drawing.Point(12, 98);
            this.dgvSach.Name = "dgvSach";
            this.dgvSach.ReadOnly = true;
            this.dgvSach.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvSach.Size = new System.Drawing.Size(300, 208);
            this.dgvSach.TabIndex = 0;
            this.dgvSach.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickSach);
            this.dgvSach.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.ClickSach);
            // 
            // dgvDocGia
            // 
            this.dgvDocGia.AllowUserToAddRows = false;
            this.dgvDocGia.AllowUserToDeleteRows = false;
            this.dgvDocGia.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDocGia.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocGia.Location = new System.Drawing.Point(345, 98);
            this.dgvDocGia.Name = "dgvDocGia";
            this.dgvDocGia.ReadOnly = true;
            this.dgvDocGia.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvDocGia.Size = new System.Drawing.Size(301, 208);
            this.dgvDocGia.TabIndex = 1;
            this.dgvDocGia.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.ClickDocGia);
            this.dgvDocGia.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvDocGia_CellMouseClick);
            // 
            // txtSearchSach
            // 
            this.txtSearchSach.Location = new System.Drawing.Point(68, 312);
            this.txtSearchSach.Name = "txtSearchSach";
            this.txtSearchSach.Size = new System.Drawing.Size(244, 20);
            this.txtSearchSach.TabIndex = 2;
            this.txtSearchSach.TextChanged += new System.EventHandler(this.txtSearchSach_TextChanged);
            // 
            // txtSearchDG
            // 
            this.txtSearchDG.Location = new System.Drawing.Point(392, 312);
            this.txtSearchDG.Name = "txtSearchDG";
            this.txtSearchDG.Size = new System.Drawing.Size(254, 20);
            this.txtSearchDG.TabIndex = 3;
            this.txtSearchDG.TextChanged += new System.EventHandler(this.txtSearchDG_TextChanged);
            // 
            // txtMaSach
            // 
            this.txtMaSach.Enabled = false;
            this.txtMaSach.Location = new System.Drawing.Point(93, 21);
            this.txtMaSach.Name = "txtMaSach";
            this.txtMaSach.Size = new System.Drawing.Size(100, 20);
            this.txtMaSach.TabIndex = 4;
            // 
            // txtMaThe
            // 
            this.txtMaThe.Enabled = false;
            this.txtMaThe.Location = new System.Drawing.Point(455, 24);
            this.txtMaThe.Name = "txtMaThe";
            this.txtMaThe.Size = new System.Drawing.Size(100, 20);
            this.txtMaThe.TabIndex = 5;
            // 
            // txtTenSach
            // 
            this.txtTenSach.Enabled = false;
            this.txtTenSach.Location = new System.Drawing.Point(93, 57);
            this.txtTenSach.Name = "txtTenSach";
            this.txtTenSach.Size = new System.Drawing.Size(154, 20);
            this.txtTenSach.TabIndex = 6;
            // 
            // txtTenDocGia
            // 
            this.txtTenDocGia.Enabled = false;
            this.txtTenDocGia.Location = new System.Drawing.Point(455, 57);
            this.txtTenDocGia.Name = "txtTenDocGia";
            this.txtTenDocGia.Size = new System.Drawing.Size(159, 20);
            this.txtTenDocGia.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(283, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(105, 49);
            this.button1.TabIndex = 8;
            this.button1.Text = "Mượn";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Mã Sách";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Tên sách";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(406, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Mã thẻ:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(380, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tên Độc giả:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 315);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Search:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(342, 315);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Search:";
            // 
            // frmMuon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 420);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtTenDocGia);
            this.Controls.Add(this.txtTenSach);
            this.Controls.Add(this.txtMaThe);
            this.Controls.Add(this.txtMaSach);
            this.Controls.Add(this.txtSearchDG);
            this.Controls.Add(this.txtSearchSach);
            this.Controls.Add(this.dgvDocGia);
            this.Controls.Add(this.dgvSach);
            this.Name = "frmMuon";
            this.Text = "Mượn sách";
            this.Load += new System.EventHandler(this.frmMuon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvSach)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocGia)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvSach;
        private System.Windows.Forms.DataGridView dgvDocGia;
        private System.Windows.Forms.TextBox txtSearchSach;
        private System.Windows.Forms.TextBox txtSearchDG;
        private System.Windows.Forms.TextBox txtMaSach;
        private System.Windows.Forms.TextBox txtMaThe;
        private System.Windows.Forms.TextBox txtTenSach;
        private System.Windows.Forms.TextBox txtTenDocGia;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}