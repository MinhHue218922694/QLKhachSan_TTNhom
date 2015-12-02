using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using KETNOI_MUONTRA;
using System.Data.SqlClient;

namespace QLMuonTraSachTV
{
    public partial class frmChiTietDG : DevComponents.DotNetBar.Office2007Form
    {
        public frmChiTietDG()
        {
            InitializeComponent();
        }
        private SqlConnection con;
        private DataTable dt = new DataTable();
        private SqlDataAdapter da;       
      
       private void connect()
       {
           string cn = "Data Source=NGUYENHUE-PC\\SQLEXPRESS;Initial Catalog=LAMLAI;Integrated Security=True";
           try
           {
               con = new SqlConnection(cn);
               con.Open();
           }
           catch
           {
               MessageBox.Show("Khong The Ket Noi", "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
           }
       }
       DataView dv = new DataView();
       private void Getdata()
       {
           SqlCommand cmd = new SqlCommand();
           cmd.Connection = con;
           cmd.CommandType = CommandType.StoredProcedure;
           cmd.CommandText = "sp_TTDocGia_TheoMa";
           cmd.Parameters.Add(new SqlParameter("@madg", SqlDbType.VarChar, 10)).Value = frmDangNhap.id;
           da = new SqlDataAdapter(cmd);
           dt = new DataTable();
           da.Fill(dt);
           dv = new DataView(dt);
           dtGridCHiTietDG.DataSource = dv;
       }
       public void SetNull(bool bl)
       {
           txtChucVu.Enabled = txtGioiTinh.Enabled = txtHoTen.Enabled = txtLop.Enabled = txtNgaySinh.Enabled = txtSdt.Enabled = bl;
       }
       private void frmChiTietDG_Load(object sender, EventArgs e)
       {
           SetNull(false);
           connect();
           Getdata();         
       }

       private void dtGridCHiTietDG_CellClick(object sender, DataGridViewCellEventArgs e)
       {
           try
           {
               txtHoTen.Text = dtGridCHiTietDG.Rows[e.RowIndex].Cells[0].Value.ToString();
               txtNgaySinh.Text = dtGridCHiTietDG.Rows[e.RowIndex].Cells[1].Value.ToString();
               txtLop.Text = dtGridCHiTietDG.Rows[e.RowIndex].Cells[2].Value.ToString();
               txtChucVu.Text = dtGridCHiTietDG.Rows[e.RowIndex].Cells[3].Value.ToString();
               txtSdt.Text = dtGridCHiTietDG.Rows[e.RowIndex].Cells[4].Value.ToString();
               txtGioiTinh.Text = dtGridCHiTietDG.Rows[e.RowIndex].Cells[5].Value.ToString();

           }
           catch { return; }
       }
        

       private void buttonX4_Click(object sender, EventArgs e)
       {
           if (MessageBox.Show("Bạn có chắc muốn Sửa thông tin khach hang này?", "Cảnh báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
           {
               txtSdt.Enabled = txtNgaySinh.Enabled = txtLop.Enabled = txtHoTen.Enabled = txtGioiTinh.Enabled = txtChucVu.Enabled = true;              
               btnLuu.Enabled = true;               
           }
       }

       private void btnLuu_Click(object sender, EventArgs e)
       {
           try
           {
                SqlCommand cmd = new SqlCommand("sp_UpdateDocGia_QL", con);//[sp_UpdateDocGia_QL]
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter[] p = new SqlParameter[7];
                p[0] = new SqlParameter("@TenDG", txtHoTen.Text);
                p[1] = new SqlParameter("@NgaySinh", txtNgaySinh.Text.ToString());
                p[2] = new SqlParameter("@Lop", txtLop.Text);
                p[3] = new SqlParameter("@ChucVu", txtChucVu.Text);
                p[4] = new SqlParameter("@GioiTinh", txtGioiTinh.Text);
                p[5] = new SqlParameter("@Sdt",txtSdt.Text);
                p[6] = new SqlParameter("@MaDG", frmDangNhap.id);
                cmd.Parameters.AddRange(p);
                int i = cmd.ExecuteNonQuery();
                if (i > 0)
                {
                    MessageBox.Show("bạn đã update thành công!");
                    Getdata();
                    frmChiTietDG_Load(sender, e);
                    btnSua.Enabled = true;
                }
                else
                    MessageBox.Show("sửa thất bại");                       
           }
           catch { MessageBox.Show("Lưu Bị lỗi"); }
       }

       private void buttonX3_Click(object sender, EventArgs e)
       {
           frmSach_DG g = new frmSach_DG();
           g.Show();
           this.Hide();
       }

       private void buttonX1_Click(object sender, EventArgs e)
       {
           frmEditPass ft = new frmEditPass();
           ft.Show();
           //this.Hide();
       }

       private void txtSdt_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
       {
           if (!Char.IsDigit(e.KeyChar) && !Char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
       }
        
    }
}
