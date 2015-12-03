namespace sieuthi
{
    partial class HangHoa
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtsoluong = new System.Windows.Forms.TextBox();
            this.txtdv = new System.Windows.Forms.TextBox();
            this.txtgia2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtT = new System.Windows.Forms.TextBox();
            this.btadd = new System.Windows.Forms.Button();
            this.btup = new System.Windows.Forms.Button();
            this.btd = new System.Windows.Forms.Button();
            this.txtgia1 = new System.Windows.Forms.TextBox();
            this.txtten = new System.Windows.Forms.TextBox();
            this.txtma = new System.Windows.Forms.TextBox();
            this.maMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tenMH = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaMua = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giaBan = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.soluong = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.donvi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.maMH,
            this.tenMH,
            this.giaMua,
            this.giaBan,
            this.soluong,
            this.donvi});
            this.dataGridView1.Location = new System.Drawing.Point(12, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(749, 313);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txtsoluong);
            this.groupBox1.Controls.Add(this.txtdv);
            this.groupBox1.Controls.Add(this.txtgia2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtT);
            this.groupBox1.Controls.Add(this.btadd);
            this.groupBox1.Controls.Add(this.btup);
            this.groupBox1.Controls.Add(this.btd);
            this.groupBox1.Controls.Add(this.txtgia1);
            this.groupBox1.Controls.Add(this.txtten);
            this.groupBox1.Controls.Add(this.txtma);
            this.groupBox1.Location = new System.Drawing.Point(11, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(749, 126);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Thông Tin";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(515, 107);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 16);
            this.label7.TabIndex = 16;
            this.label7.Text = "Search...";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(306, 86);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Số Lượng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(294, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Đơn Vị Tính";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(314, 33);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "Giá Bán";
            // 
            // txtsoluong
            // 
            this.txtsoluong.Location = new System.Drawing.Point(371, 79);
            this.txtsoluong.Name = "txtsoluong";
            this.txtsoluong.Size = new System.Drawing.Size(162, 20);
            this.txtsoluong.TabIndex = 12;
            // 
            // txtdv
            // 
            this.txtdv.Location = new System.Drawing.Point(371, 53);
            this.txtdv.Name = "txtdv";
            this.txtdv.Size = new System.Drawing.Size(162, 20);
            this.txtdv.TabIndex = 11;
            // 
            // txtgia2
            // 
            this.txtgia2.Location = new System.Drawing.Point(371, 27);
            this.txtgia2.Name = "txtgia2";
            this.txtgia2.Size = new System.Drawing.Size(162, 20);
            this.txtgia2.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Giá Mua";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Tên Mặt Hàng";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Mã Mặt Hàng";
            // 
            // txtT
            // 
            this.txtT.Location = new System.Drawing.Point(590, 106);
            this.txtT.Name = "txtT";
            this.txtT.Size = new System.Drawing.Size(159, 20);
            this.txtT.TabIndex = 6;
            this.txtT.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // btadd
            // 
            this.btadd.Location = new System.Drawing.Point(657, 19);
            this.btadd.Name = "btadd";
            this.btadd.Size = new System.Drawing.Size(75, 23);
            this.btadd.TabIndex = 5;
            this.btadd.Text = "Thêm";
            this.btadd.UseVisualStyleBackColor = true;
            this.btadd.Click += new System.EventHandler(this.button3_Click);
            // 
            // btup
            // 
            this.btup.Location = new System.Drawing.Point(657, 47);
            this.btup.Name = "btup";
            this.btup.Size = new System.Drawing.Size(75, 23);
            this.btup.TabIndex = 4;
            this.btup.Text = "Sửa";
            this.btup.UseVisualStyleBackColor = true;
            this.btup.Click += new System.EventHandler(this.btup_Click);
            // 
            // btd
            // 
            this.btd.Location = new System.Drawing.Point(657, 76);
            this.btd.Name = "btd";
            this.btd.Size = new System.Drawing.Size(75, 23);
            this.btd.TabIndex = 3;
            this.btd.Text = "Xóa";
            this.btd.UseVisualStyleBackColor = true;
            this.btd.Click += new System.EventHandler(this.btd_Click);
            // 
            // txtgia1
            // 
            this.txtgia1.Location = new System.Drawing.Point(97, 83);
            this.txtgia1.Name = "txtgia1";
            this.txtgia1.Size = new System.Drawing.Size(163, 20);
            this.txtgia1.TabIndex = 2;
            // 
            // txtten
            // 
            this.txtten.Location = new System.Drawing.Point(97, 57);
            this.txtten.Name = "txtten";
            this.txtten.Size = new System.Drawing.Size(163, 20);
            this.txtten.TabIndex = 1;
            // 
            // txtma
            // 
            this.txtma.Location = new System.Drawing.Point(97, 31);
            this.txtma.Name = "txtma";
            this.txtma.Size = new System.Drawing.Size(163, 20);
            this.txtma.TabIndex = 0;
            // 
            // maMH
            // 
            this.maMH.DataPropertyName = "MaMH";
            this.maMH.HeaderText = "Mã mặt hàng";
            this.maMH.Name = "maMH";
            this.maMH.ReadOnly = true;
            // 
            // tenMH
            // 
            this.tenMH.DataPropertyName = "TenMH";
            this.tenMH.HeaderText = "Tên mặt hàng";
            this.tenMH.Name = "tenMH";
            this.tenMH.ReadOnly = true;
            // 
            // giaMua
            // 
            this.giaMua.DataPropertyName = "GiaMua";
            this.giaMua.HeaderText = "Giá mua";
            this.giaMua.Name = "giaMua";
            this.giaMua.ReadOnly = true;
            // 
            // giaBan
            // 
            this.giaBan.DataPropertyName = "GiaBan";
            this.giaBan.HeaderText = "Giá bán";
            this.giaBan.Name = "giaBan";
            this.giaBan.ReadOnly = true;
            // 
            // soluong
            // 
            this.soluong.DataPropertyName = "SoLuong";
            this.soluong.HeaderText = "Số lượng";
            this.soluong.Name = "soluong";
            this.soluong.ReadOnly = true;
            // 
            // donvi
            // 
            this.donvi.DataPropertyName = "DonViTinh";
            this.donvi.HeaderText = "Đơn vị";
            this.donvi.Name = "donvi";
            this.donvi.ReadOnly = true;
            // 
            // HangHoa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 469);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "HangHoa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Danh mục Hàng Hóa";
            this.Load += new System.EventHandler(this.HangHoa_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtT;
        private System.Windows.Forms.Button btadd;
        private System.Windows.Forms.Button btup;
        private System.Windows.Forms.Button btd;
        private System.Windows.Forms.TextBox txtgia1;
        private System.Windows.Forms.TextBox txtten;
        private System.Windows.Forms.TextBox txtma;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtsoluong;
        private System.Windows.Forms.TextBox txtdv;
        private System.Windows.Forms.TextBox txtgia2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn maMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn tenMH;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaMua;
        private System.Windows.Forms.DataGridViewTextBoxColumn giaBan;
        private System.Windows.Forms.DataGridViewTextBoxColumn soluong;
        private System.Windows.Forms.DataGridViewTextBoxColumn donvi;
    }
}