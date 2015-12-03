using System;
using System.Data;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace qlks
{
	/// <summary>
	/// Summary description for frmSearch.
	/// </summary>
	public class frmSearch : System.Windows.Forms.Form
	{
		private System.Windows.Forms.DataGrid dataGrid1;
		private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		DataTable dtSV;
		private System.Windows.Forms.TextBox txtCMND;
		private System.Windows.Forms.TextBox txtKH;
		DataView dv;

		public frmSearch()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
			dtSV=SqlHelper.ExecuteQuery(
				"pr_list_KH",
				CommandType.StoredProcedure);

			dv=dtSV.DefaultView;

		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.dataGrid1 = new System.Windows.Forms.DataGrid();
			this.txtCMND = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.txtKH = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).BeginInit();
			this.SuspendLayout();
			// 
			// dataGrid1
			// 
			this.dataGrid1.DataMember = "";
			this.dataGrid1.HeaderForeColor = System.Drawing.SystemColors.ControlText;
			this.dataGrid1.Location = new System.Drawing.Point(16, 88);
			this.dataGrid1.Name = "dataGrid1";
			this.dataGrid1.Size = new System.Drawing.Size(552, 248);
			this.dataGrid1.TabIndex = 1;
			// 
			// txtCMND
			// 
			this.txtCMND.Location = new System.Drawing.Point(24, 56);
			this.txtCMND.Name = "txtCMND";
			this.txtCMND.TabIndex = 2;
			this.txtCMND.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(136, 8);
			this.button1.Name = "button1";
			this.button1.TabIndex = 3;
			this.button1.Text = "Search";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtKH
			// 
			this.txtKH.Location = new System.Drawing.Point(24, 24);
			this.txtKH.Name = "txtKH";
			this.txtKH.TabIndex = 2;
			this.txtKH.Text = "";
			// 
			// frmSearch
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(576, 342);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.txtCMND);
			this.Controls.Add(this.dataGrid1);
			this.Controls.Add(this.txtKH);
			this.Name = "frmSearch";
			this.Text = "frmSearch";
			((System.ComponentModel.ISupportInitialize)(this.dataGrid1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			dv.RowFilter=String.Format("hotenkh like '%{0}%'",
				txtKH.Text);

			dataGrid1.DataSource=dv;

		}
	}
}
