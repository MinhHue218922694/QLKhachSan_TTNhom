using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QUANLY_HS_GV
{
    public partial class huongdan : Form
    {
        public huongdan()
        {
            InitializeComponent();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string str;
            if (treeView1.SelectedNode.Name == "nhomthuchien")
            {
                str = Application.StartupPath + "\\Huong Dan\\Nhom.mht";
                webBrowser1.Navigate(str);
            }
            if (treeView1.SelectedNode.Name == "gioithieusanpham")
            {
                str = Application.StartupPath + "\\Huong Dan\\Gioi Thieu.mht";
                webBrowser1.Navigate(str);
            }
            if (treeView1.SelectedNode.Name == "hdchinh")
            {
                str = Application.StartupPath + "\\Huong Dan\\Hocsinh_Giaovien.mht";
                webBrowser1.Navigate(str);
            }           
        }
    }
}
