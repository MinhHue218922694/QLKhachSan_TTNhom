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
    public partial class HangHoa : Form
    {
        public HangHoa()
        {
            InitializeComponent();
        }
        Database db = new Database();


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = db.GetTable("select * from MAT_HANG where TenMH like '%" + txtT.Text + "%' or MaMH like '%" + txtT.Text + "%'");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlParameter pCheck = new SqlParameter("@check", "1");
            pCheck.Direction = ParameterDirection.Output;
            pCheck.SqlDbType = SqlDbType.Bit;

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@maMH", txtma.Text));
            list.Add(pCheck);

            db.Execute("checkMaMH", list.ToArray());

            if (!bool.Parse(pCheck.Value.ToString()))
            {
                list.Clear();
                list.Add(new SqlParameter("@mmh", txtma.Text));
                list.Add(new SqlParameter("@ten", txtten.Text));
                list.Add(new SqlParameter("@giamua", txtgia1.Text));
                list.Add(new SqlParameter("@giaban", txtgia2.Text));
                list.Add(new SqlParameter("@dv", txtdv.Text));
                list.Add(new SqlParameter("@sl", txtsoluong.Text));
                db.Execute("Insert_MH", list.ToArray());

                MessageBox.Show("Added!");
                Reload();
            }
            else
            {
                MessageBox.Show("Existed!");
            }


        }



        private void btup_Click(object sender, EventArgs e)
        {
            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@MaMH", txtma.Text));
            list.Add(new SqlParameter("@TenMH", txtten.Text));
            list.Add(new SqlParameter("@GiaMua", txtgia1.Text));
            list.Add(new SqlParameter("@GiaBan", txtgia2.Text));
            list.Add(new SqlParameter("@DonViTinh", txtdv.Text));
            list.Add(new SqlParameter("@SoLuong", txtsoluong.Text));
            db.Execute("Update_MH", list.ToArray());

            Reload();
            MessageBox.Show("OK");
        }

        private void btd_Click(object sender, EventArgs e)
        {
            //Xóa mặt hàng cần hóa các bản ghi trong chi tiết hóa đơn có chứa mặt hàng đó
            try
            {
                List<SqlParameter> list = new List<SqlParameter>();
                list.Clear();
                list.Add(new SqlParameter("@MaMH", txtma.Text));
                db.Execute("Delete_MH", list.ToArray());
            }
            catch (Exception)
            {

                throw;
            }

            Reload();
            MessageBox.Show("OK!");
        }

        private void HangHoa_Load(object sender, EventArgs e)
        {
            Reload();
        }

        public void Reload()
        {
            dataGridView1.DataSource = db.GetTable("select * from MAT_HANG");
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                txtma.Text = dataGridView1.Rows[e.RowIndex].Cells["maMH"].Value.ToString();
                txtten.Text = dataGridView1.Rows[e.RowIndex].Cells["tenMH"].Value.ToString();
                txtgia1.Text = dataGridView1.Rows[e.RowIndex].Cells["giaMua"].Value.ToString();
                txtgia2.Text = dataGridView1.Rows[e.RowIndex].Cells["giaBan"].Value.ToString();
                txtsoluong.Text = dataGridView1.Rows[e.RowIndex].Cells["soluong"].Value.ToString();
                txtdv.Text = dataGridView1.Rows[e.RowIndex].Cells["donvi"].Value.ToString();
            }
        }
    }
}
