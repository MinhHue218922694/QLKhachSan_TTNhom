namespace QLMuonTraSachTV
{
    partial class frmTraSach
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtGidTraS = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.groupPanel2 = new DevComponents.DotNetBar.Controls.GroupPanel();
            this.txtTK_SOTHE = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX6 = new DevComponents.DotNetBar.LabelX();
            this.txtTk_Tra = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.labelX5 = new DevComponents.DotNetBar.LabelX();
            this.buttonX1 = new DevComponents.DotNetBar.ButtonX();
            ((System.ComponentModel.ISupportInitialize)(this.dtGidTraS)).BeginInit();
            this.groupPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGidTraS
            // 
            this.dtGidTraS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGidTraS.DefaultCellStyle = dataGridViewCellStyle1;
            this.dtGidTraS.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(208)))), ((int)(((byte)(215)))), ((int)(((byte)(229)))));
            this.dtGidTraS.Location = new System.Drawing.Point(0, 134);
            this.dtGidTraS.Name = "dtGidTraS";
            this.dtGidTraS.ReadOnly = true;
            this.dtGidTraS.Size = new System.Drawing.Size(503, 165);
            this.dtGidTraS.TabIndex = 0;
            // 
            // groupPanel2
            // 
            this.groupPanel2.CanvasColor = System.Drawing.SystemColors.Control;
            this.groupPanel2.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.Office2007;
            this.groupPanel2.Controls.Add(this.txtTK_SOTHE);
            this.groupPanel2.Controls.Add(this.labelX6);
            this.groupPanel2.Controls.Add(this.txtTk_Tra);
            this.groupPanel2.Controls.Add(this.labelX5);
            this.groupPanel2.DisabledBackColor = System.Drawing.Color.Empty;
            this.groupPanel2.Location = new System.Drawing.Point(0, 0);
            this.groupPanel2.Name = "groupPanel2";
            this.groupPanel2.Size = new System.Drawing.Size(212, 128);
            // 
            // 
            // 
            this.groupPanel2.Style.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.groupPanel2.Style.BackColorGradientAngle = 90;
            this.groupPanel2.Style.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.groupPanel2.Style.BorderBottom = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderBottomWidth = 1;
            this.groupPanel2.Style.BorderColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.groupPanel2.Style.BorderLeft = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderLeftWidth = 1;
            this.groupPanel2.Style.BorderRight = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderRightWidth = 1;
            this.groupPanel2.Style.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.groupPanel2.Style.BorderTopWidth = 1;
            this.groupPanel2.Style.CornerDiameter = 4;
            this.groupPanel2.Style.CornerType = DevComponents.DotNetBar.eCornerType.Rounded;
            this.groupPanel2.Style.TextAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Center;
            this.groupPanel2.Style.TextColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.groupPanel2.Style.TextLineAlignment = DevComponents.DotNetBar.eStyleTextAlignment.Near;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.groupPanel2.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.groupPanel2.TabIndex = 1;
            this.groupPanel2.Text = "Tìm Kiếm";
            // 
            // txtTK_SOTHE
            // 
            // 
            // 
            // 
            this.txtTK_SOTHE.Border.Class = "TextBoxBorder";
            this.txtTK_SOTHE.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTK_SOTHE.Location = new System.Drawing.Point(91, 60);
            this.txtTK_SOTHE.Name = "txtTK_SOTHE";
            this.txtTK_SOTHE.PreventEnterBeep = true;
            this.txtTK_SOTHE.Size = new System.Drawing.Size(100, 20);
            this.txtTK_SOTHE.TabIndex = 3;
            this.txtTK_SOTHE.TextChanged += new System.EventHandler(this.txtTK_SOTHE_TextChanged);
            // 
            // labelX6
            // 
            // 
            // 
            // 
            this.labelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX6.Location = new System.Drawing.Point(3, 60);
            this.labelX6.Name = "labelX6";
            this.labelX6.Size = new System.Drawing.Size(75, 23);
            this.labelX6.TabIndex = 2;
            this.labelX6.Text = "Số Thẻ";
            // 
            // txtTk_Tra
            // 
            // 
            // 
            // 
            this.txtTk_Tra.Border.Class = "TextBoxBorder";
            this.txtTk_Tra.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.txtTk_Tra.Location = new System.Drawing.Point(91, 17);
            this.txtTk_Tra.Name = "txtTk_Tra";
            this.txtTk_Tra.PreventEnterBeep = true;
            this.txtTk_Tra.Size = new System.Drawing.Size(100, 20);
            this.txtTk_Tra.TabIndex = 1;
            this.txtTk_Tra.TextChanged += new System.EventHandler(this.txtTk_Tra_TextChanged);
            // 
            // labelX5
            // 
            // 
            // 
            // 
            this.labelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX5.Location = new System.Drawing.Point(3, 14);
            this.labelX5.Name = "labelX5";
            this.labelX5.Size = new System.Drawing.Size(75, 23);
            this.labelX5.TabIndex = 0;
            this.labelX5.Text = "Mã Sách";
            // 
            // buttonX1
            // 
            this.buttonX1.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.buttonX1.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.buttonX1.Location = new System.Drawing.Point(261, 12);
            this.buttonX1.Name = "buttonX1";
            this.buttonX1.Size = new System.Drawing.Size(75, 23);
            this.buttonX1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.buttonX1.TabIndex = 2;
            this.buttonX1.Text = "Thoát";
            this.buttonX1.Click += new System.EventHandler(this.buttonX1_Click);
            // 
            // frmTraSach
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(508, 302);
            this.Controls.Add(this.buttonX1);
            this.Controls.Add(this.groupPanel2);
            this.Controls.Add(this.dtGidTraS);
            this.Name = "frmTraSach";
            this.Text = "frmTraSach";
            this.Load += new System.EventHandler(this.frmTraSach_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGidTraS)).EndInit();
            this.groupPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.Controls.DataGridViewX dtGidTraS;
        private DevComponents.DotNetBar.Controls.GroupPanel groupPanel2;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTK_SOTHE;
        private DevComponents.DotNetBar.LabelX labelX6;
        private DevComponents.DotNetBar.Controls.TextBoxX txtTk_Tra;
        private DevComponents.DotNetBar.LabelX labelX5;
        private DevComponents.DotNetBar.ButtonX buttonX1;
    }
}