using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLBanHang.Views.Main
{
    public partial class Form1 : Form
    {
        string _tenkho;
        public string TenKho { get { return _tenkho; } }
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _tenkho = listBox1.SelectedItem.ToString();
            this.Close();
        }
    }
}
