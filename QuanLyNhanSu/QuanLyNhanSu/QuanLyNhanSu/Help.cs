using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyNhanSu
{
    public partial class Help : Form
    {
       
        public Help()
        {
            InitializeComponent();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //string s = System.IO.Directory.GetCurrentDirectory() + @"\Resources\themnhanvien.mht";
            //Debug.WriteLine(s);
            switch (e.Node.Name)
            {
                //case "ThemNhanVien":
                //    webBrowser1.Navigate(new Uri(s));
                //    break;
                    
            }
        }

        //public enum help { ThemNhanVien, SuaNhanVien,XoaNhanVien, ThemPhongBan,SuaPhongBan, XoaPhongBan, ThemThanNhan }
    }
}
