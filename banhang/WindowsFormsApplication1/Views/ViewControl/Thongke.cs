using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanHang.Controllers;
//using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace QLBanHang.Views.ViewControl
{
    public partial class Thongke : UserControl
    {
        //private void LoadChart(int x)
        //{
        //    chart1.Series["Series1"].Points.Clear();
        //    DataTable dt = DataAccess.ViewForGridView("Sanpham_ViewDetaibyYear", new SqlParameter("@SanphamID", x));
        //    foreach (DataRow dr in dt.Rows)
        //    {
        //        DataPoint p = new DataPoint();
        //        p.XValue = int.Parse(dr["Thang"].ToString());
        //        p.YValues = new double[] { double.Parse(dr["Tong"].ToString()) };
        //        chart1.Series["Series1"].Points.Add(p);
        //    }
        //}
        private void LoadDanhsach()
        {
            listView1.Items.Clear();
            DataTable dt = DataAccess.ViewForGridView("Sanpham_ViewAll");
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ListViewItem item = new ListViewItem();
                    item.Text = dr["SanphamID"].ToString();
                    item.SubItems.Add(dr["Tensanpham"].ToString());
                    listView1.Items.Add(item);
                }
            }
        }
        public Thongke()
        {
            InitializeComponent();
            LoadDanhsach();
        }
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                int x = int.Parse(listView1.SelectedItems[0].Text);
                //LoadChart(x);
            }
        }
    }
}
