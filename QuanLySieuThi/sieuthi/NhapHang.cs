using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace sieuthi
{
    public partial class NhapHang : Form
    {
        public NhapHang()
        {
            InitializeComponent();
        }
        bool landautien = true;
        Database db = new Database();
        private void button1_Click(object sender, EventArgs e)
        {
            List<SqlParameter> list = new List<SqlParameter>();  //luu danh sach cac bien tham so

            //lần đâu tiên thì thêm phiếu nhập vào
            if (landautien == true)
            {
                landautien = false;
                list.Add(new SqlParameter("@mhd", txtmahd.Text));
                list.Add(new SqlParameter("@mnv", txtmanv.Text));
                list.Add(new SqlParameter("@time", txttime.Value));
                list.Add(new SqlParameter("@ncc", txtncc.Text));

                db.Execute("Insert_HDN", list.ToArray());
            }

            //mỗi lần thêm là 1 lần thêm chi tiết phiếu nhập và cập nhật mặt hàng
            //Phai them mat hang truoc khi them hoa don chi tiet
            list.Clear();
            list.Add(new SqlParameter("@mmh", txtmmh.Text));
            list.Add(new SqlParameter("@ten", txttenmh.Text));
            list.Add(new SqlParameter("@giamua", txtGia.Text));
            list.Add(new SqlParameter("@giaban", 10));
            list.Add(new SqlParameter("@dv", txtdonvi.Text));
            list.Add(new SqlParameter("@sl", txtsoluong.Text));
            db.Execute("Insert_MH", list.ToArray());


            list.Clear();
            list.Add(new SqlParameter("@mhd", txtmahd.Text));
            list.Add(new SqlParameter("@mmh", txtmmh.Text));
            list.Add(new SqlParameter("@soluong", txtsoluong.Text));
            list.Add(new SqlParameter("@gia", txtGia.Text));
            db.Execute("Insert_CTHDN", list.ToArray());

            dataGridView1.DataSource = db.GetTable("select * from HOA_DON_CHI_TIET_NHAP where MaHDN = "+txtmahd.Text);
        }

  

        private void NhapHang_Load(object sender, EventArgs e)
        {
            txtmahd.Text = string.Format("{0}{1}{2}{3}",DateTime.Now.DayOfYear,DateTime.Now.Hour,DateTime.Now.Minute,DateTime.Now.Second);
        }
    }
}
