using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace QUANLY_HS_GV
{
    public partial class GiaoVien : Form
    {

        bool check = true;

        public GiaoVien()
        {
            InitializeComponent();
        }

        private void GiaoVien_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'qUANLY_HS_GVDataSet1.GiaoVien' table. You can move, or remove it, as needed.
            //this.giaoVienTableAdapter.Fill(this.qUANLY_HS_GVDataSet1.GiaoVien);
            // TODO: This line of code loads data into the 'qUANLY_HS_GVDataSet1.GiaoVien' table. You can move, or remove it, as needed.
            //this.giaoVienTableAdapter.Fill(this.qUANLY_HS_GVDataSet1.GiaoVien);
        }

        private int KTTrung(string a)
        {
            for (int i = 0; i < dgvGiaovien.Rows.Count; i++)
            {
                if (Convert.ToString(dgvGiaovien.Rows[i].Cells[0].Value) == a)
                {
                    return 1;
                }
            }
            return 2;
        }

        void Reset(object sender, EventArgs e)
        {
            txtIDGv.Text = "";
            txtTenGV.Text = "";
            txtQueQuan.Text = "";
            cboGioitinh.Text = "";
            txtCMND.Text = "";
            dtNgaysinh.Text = "";
            txtChucvu.Text = "";
            cbo_Monhoc.Text = "";
            cbo_Lop.Text = "";
        }


        private void btnShow_Click(object sender, EventArgs e)
        {
            //SqlConnection con = new SqlConnection("Data Source=(local);Initial Catalog=QUANLY_HS_GV;Integrated Security=True");
            SqlConnection con = new SqlConnection(Connect.getconnect());
            try
            {
                con.Open();
                if (con.State == ConnectionState.Open)
                {
                    if (check) MessageBox.Show("Load data success!");
                    else MessageBox.Show("Save DataBase success!");
                    SqlCommand com = new SqlCommand();
                    com.CommandText = "LoadGV";
                    com.CommandType = CommandType.StoredProcedure;
                    com.Connection = con;
                    SqlDataAdapter adap = new SqlDataAdapter(com);
                    DataTable dt = new DataTable();
                    adap.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        dgvGiaovien.DataSource = dt;
                    }
                    else
                    {
                        MessageBox.Show("Data is empty!");
                        dgvGiaovien.Visible = false;
                    }
                }
                else
                {
                    throw new Exception("Connection crashed!");
                }
            }
            catch
            {

            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (KTTrung(txtTenGV.Text) == 1 && check)
            {
                MessageBox.Show("Dữ Liệu nhập thiếu Hoặc Mã Nhập Đã Bị Trùng! Vui Lòng Nhập Lại...");
            }
            else
            {                
                SqlConnection con = new SqlConnection(Connect.getconnect());
                con.Open();
                SqlCommand com = new SqlCommand("Add_GV", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@Id_gv", txtIDGv.Text.Trim());
                com.Parameters.AddWithValue("@Hoten", txtTenGV.Text.Trim());
                com.Parameters.AddWithValue("@quequan", txtQueQuan.Text.Trim());
                com.Parameters.AddWithValue("@Gt", cboGioitinh.Text.Trim());
                com.Parameters.AddWithValue("@cmnd", Convert.ToString(txtCMND.Text.Trim()));
                com.Parameters.AddWithValue("@Ngaysinh", Convert.ToDateTime(dtNgaysinh.Text.Trim()));
                com.Parameters.AddWithValue("@chucvu", txtChucvu.Text.Trim());
                com.Parameters.AddWithValue("@Id_lop", cbo_Lop.Text.Trim());
                com.Parameters.AddWithValue("@Id_monhoc", cbo_Monhoc.Text.Trim());
                com.ExecuteNonQuery();
                com.Dispose();
                btnShow_Click(sender, e);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvGiaovien.SelectedRows.Count == 0)
            {
                MessageBox.Show("Chọn Dòng Cần Sửa!...", "Thông Báo");
            }

            else
            {

                //SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=QUANLY_HS_GV;Integrated Security=True");
                SqlConnection con = new SqlConnection(Connect.getconnect());
                con.Open();
                SqlCommand com = new SqlCommand("dbo.Edit_GV", con);
                com.CommandType = CommandType.StoredProcedure;
                com.Parameters.AddWithValue("@ID_gv", txtIDGv.Text.Trim());
                com.Parameters.AddWithValue("@Hoten", txtTenGV.Text.Trim());
                com.Parameters.AddWithValue("@Quequan", txtQueQuan.Text.Trim());
                com.Parameters.AddWithValue("@Gt", cboGioitinh.Text.Trim());
                com.Parameters.AddWithValue("@CMND", txtCMND.Text.Trim());
                com.Parameters.AddWithValue("@Ngaysinh", Convert.ToDateTime(dtNgaysinh.Text.Trim()));
                com.Parameters.AddWithValue("@Chucvu", txtChucvu.Text.Trim());
                com.Parameters.AddWithValue("@Id_monhoc", cbo_Lop.Text.Trim());
                com.Parameters.AddWithValue("@Id_lop", cbo_Monhoc.Text.Trim());
                com.Parameters.AddWithValue("@kq", 1);
                //com.Parameters.Add("@kq",SqlDbType.Int).Direction = ParameterDirection.Output;
                com.ExecuteNonQuery();
                //int check = Convert.ToInt16(com.Parameters["@kq"].Value);
                com.Dispose();
                btnShow_Click(sender, e);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = 1;
            string xoa;
            if (dgvGiaovien.SelectedRows.Count == 0) MessageBox.Show("Chọn ít nhất 1 dòng để xóa!...");
            else for (int i = 0; i < dgvGiaovien.Rows.Count; i++) if (dgvGiaovien.Rows[i].Selected)
                    {
                        //SqlConnection con1 = new SqlConnection(@"Data Source=(local);Initial Catalog=QUANLY_HS_GV;Integrated Security=True");
                        SqlConnection con1 = new SqlConnection(Connect.getconnect());
                        try
                        {
                            con1.Open();
                            if (con1.State == ConnectionState.Open)
                            {
                                for (int j = 0; j < dgvGiaovien.RowCount; j++)
                                {
                                    if (dgvGiaovien.Rows[j].Selected == true)
                                    {
                                        if (id > 0)
                                        {
                                            DialogResult r = MessageBox.Show("Are you sure?", "Confirm!!!", MessageBoxButtons.YesNo);
                                            if (r == System.Windows.Forms.DialogResult.Yes)
                                            {
                                                xoa = dgvGiaovien.Rows[j].Cells[0].Value.ToString();
                                                SqlCommand com1 = new SqlCommand();
                                                com1.Connection = con1;
                                                com1.CommandText = "Delete_GV";
                                                com1.CommandType = CommandType.StoredProcedure;
                                                com1.Parameters.AddWithValue("@ID_GV", xoa);
                                                com1.ExecuteNonQuery();
                                                dgvGiaovien.Rows.RemoveAt(j);
                                                j--;
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                throw new Exception("Connection crashed!");
                            }
                        }
                        catch
                        {

                        }
                    }
        }

        private void bntThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvGiaovien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (!dgvGiaovien.CurrentRow.IsNewRow)
            {
                txtIDGv.Text = dgvGiaovien.CurrentRow.Cells[0].Value.ToString();
                txtTenGV.Text = dgvGiaovien.CurrentRow.Cells[1].Value.ToString();
                txtQueQuan.Text = dgvGiaovien.CurrentRow.Cells[2].Value.ToString();
                cboGioitinh.Text = dgvGiaovien.CurrentRow.Cells[3].Value.ToString();
                txtCMND.Text = dgvGiaovien.CurrentRow.Cells[4].Value.ToString();
                dtNgaysinh.Text = dgvGiaovien.CurrentRow.Cells[5].Value.ToString();
                txtChucvu.Text = dgvGiaovien.CurrentRow.Cells[6].Value.ToString();
                cbo_Monhoc.Text = dgvGiaovien.CurrentRow.Cells[7].Value.ToString();
                cbo_Lop.Text = dgvGiaovien.CurrentRow.Cells[8].Value.ToString();
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (cboSearch.Text == "Mã giáo viên")
            {
                //SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=QUANLY_HS_GV;Integrated Security=True");
                SqlConnection con = new SqlConnection(Connect.getconnect());
                SqlDataAdapter sda = new SqlDataAdapter("select *from GiaoVien where ID_Gv like '" + txtSearch.Text + "%'", con);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                dgvGiaovien.DataSource = dt;
            }
            else
                if (cboSearch.Text == "Họ tên giáo viên")
                {
                    //SqlConnection con = new SqlConnection(@"Data Source=(local);Initial Catalog=QUANLY_HS_GV;Integrated Security=True");
                    SqlConnection con = new SqlConnection(Connect.getconnect());
                    SqlDataAdapter sdap = new SqlDataAdapter("select *from GiaoVien where HoTen like '" + txtSearch.Text + "%'", con);
                    DataTable data = new DataTable();
                    sdap.Fill(data);
                    dgvGiaovien.DataSource = data;
                }
        }

    }
}
