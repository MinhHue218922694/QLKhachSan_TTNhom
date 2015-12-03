using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HTDFramework.Data;
using QLBanHang.Controllers;
using System.Data.SqlClient;

namespace QLBanHang.Views.QuanLySanPham
{
    public partial class Nhapkho : Form
    {
        private int KhoID{get;set;}
        SanPhamCollection lstSanpham;
        DataManager<Models.Kho> dm = new DataManager<Models.Kho>();
        DataManager<Models.Luutru> dmll = new DataManager<Models.Luutru>();
        Models.Kho kho = new Models.Kho();
        DataTable sp = new DataTable();

        private void LoadParent()
        {
            Views.ViewControl.Khohang kh = new ViewControl.Khohang();
            kh.Refresh();
        }
        public void LoadSanpham()
        {
            lstSanpham = new SanPhamCollection(1);
            listView1.Items.Clear();
            foreach (Models.SanPham x in lstSanpham.Items)
            {
                ListViewItem item = new ListViewItem();
                item.Text = x.SanphamID.ToString();
                item.SubItems.Add(x.Tensanpham);
                item.SubItems.Add(x.Soluong.ToString());
                listView1.Items.Add(item);
            }
        }
        public void ViewData(int _SanphamID)
        {
            kho = dm.GetDataByID(KhoID);
            sp = DataAccess.GetsingleData("Sanpham_ViewbyLuutru", new SqlParameter("@KhoID", KhoID), new SqlParameter("@SanphamID", _SanphamID));
            if (sp.Rows.Count > 0)
            {
                DataRow dr = sp.Rows[0];
                textBox1.Text = dr["Tensanpham"].ToString();
                textBox3.Text = dr["Soluong"].ToString();
                textBox5.Text = _SanphamID.ToString();
            }
            else
            {
                textBox1.Text =(listView1.FindItemWithText(_SanphamID.ToString())!=null)?listView1.FindItemWithText(_SanphamID.ToString()).SubItems[1].Text:"" ;
                textBox3.Text = "0";
                textBox5.Text = _SanphamID.ToString();
            }
            textBox2.Text = kho.Tenkho;
        }
        public string CheckValues(string _SanphamID)
        {
            string msg = "Error";
            int x = int.Parse(listView1.FindItemWithText(_SanphamID).SubItems[2].Text);
            int y;
            if(int.TryParse(textBox4.Text,out y)){
                if (KhoID != 1)
                {
                    msg = (x >= y) ? "OK" : "NO";
                }
                else { msg = "OK"; }
                return msg;
            }
            else
            {
                return msg;
            }
        }
        public Nhapkho()
        {
            InitializeComponent();
        }
        public Nhapkho(int _KhoID,int _SanphamID)
        {
            KhoID = _KhoID;
            InitializeComponent();
            LoadSanpham();
            ViewData(_SanphamID);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count != 0)
            {
                ViewData(int.Parse(listView1.SelectedItems[0].Text));
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox5.Text != "")
            {
                if (textBox4.Text != "") {
                    string s = CheckValues(textBox5.Text);
                    if (s.Equals("Error"))
                    {
                        MessageBox.Show("Số lượng không phù hợp");
                    }
                    else
                    {
                        if (s.Equals("OK"))
                        {
                            DialogResult dr = MessageBox.Show("Bạn có chắc muốn thêm!", "Thông báo", MessageBoxButtons.YesNo);
                            if (dr == System.Windows.Forms.DialogResult.Yes)
                            {
                                DataAccess.ExecuteNonQuery("Luutru_Insert-Update", new SqlParameter("@KhoID", kho.KhoID),
                                                                                new SqlParameter("@SanphamID", int.Parse(textBox5.Text)),
                                                                                new SqlParameter("@Soluong", int.Parse(textBox4.Text))
                                                                                );
                                LoadSanpham();
                                
                                //ViewData(int.Parse(listView1.SelectedItems[0].Text));
                            }
                        }
                        else
                        {
                            MessageBox.Show("Số lượng trong kho chính không đủ");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Chọn sản phẩm");
            }
        }

        private void Nhapkho_Load(object sender, EventArgs e)
        {

        }
    }
}
