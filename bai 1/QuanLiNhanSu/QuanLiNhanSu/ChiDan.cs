using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace QuanLiNhanSu
{
    public partial class frmChiDan : Form
    {
        public frmChiDan()
        {
            InitializeComponent();
        }
        private void GetFileAll(string tenfile)
        {
            StreamReader doc = File.OpenText(tenfile);
            string s = doc.ReadToEnd();
            txtGioiThieu.Text = s;
        }

        private void trViewGioiThieu_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Name == "gtChung")
            {
                GetFileAll("GioiThieuChung.txt");
                Image img = Image.FromFile(@"marketshare.jpg");
                pictureBox1.BackgroundImage=img;
            }
            else
                if (e.Node.Name == "gtFrmDangNhap")
                { 
                    GetFileAll("PhanDangNhap.txt");
                    Image img = Image.FromFile(@"DangNhap.jpg");
                    pictureBox1.BackgroundImage = img;
                }
                else
                    if (e.Node.Name == "gtfrmMain")
                    {
                        GetFileAll("PhanMenu.txt");
                        Image img = Image.FromFile(@"Menu.jpg");
                        pictureBox1.BackgroundImage = img;
                    }
                    else
                        if (e.Node.Name == "gtfrmForm1")
                        {
                            GetFileAll("PhanQuanLi.txt");
                            Image img = Image.FromFile(@"QuanLi.jpg");
                            pictureBox1.BackgroundImage = img;
                        }
        }

        private void ChiDan_Load(object sender, EventArgs e)
        {
           
        }

        private void trViewGioiThieu_Click(object sender, EventArgs e)
        {
           
        }
    }
}
