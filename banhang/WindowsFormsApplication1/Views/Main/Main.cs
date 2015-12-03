using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLBanHang.Controllers;
using QLBanHang.Models;
namespace QLBanHang.Views.Main
{
    public partial class Main : Form
    {
        Banhang bh = new Banhang();
        QuanLySanPham.Quanly ql = new QuanLySanPham.Quanly();
        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            tabPage1.Controls.Clear();
            tabPage1.Controls.Add(bh);
            bh.Dock = DockStyle.Fill;
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            TabControl tc = sender as TabControl;
            switch (tc.SelectedIndex)
            {
                case 0:
                    tabPage1.Controls.Clear();
                    tabPage1.Controls.Add(bh);
                    bh.Dock = DockStyle.Fill;
                    break;
                case 1:
                    tabPage2.Controls.Clear();
                    tabPage2.Controls.Add(ql);
                    ql.Dock = DockStyle.Fill;
                    break;
            }
        }
    }
}
