using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KETNOI_MUONTRA;
using System.Data.SqlClient;
using DAL;

namespace QLMuonTraSachTV
{
    public partial class frmSach_DG : DevComponents.DotNetBar.Office2007Form
    {
        
        
        public frmSach_DG()
        {
            InitializeComponent();
        }
        Sach_DG s = new Sach_DG();
        TimKiem tk = new TimKiem();

        public void frmSach_DG_Load(object sender, EventArgs e)
        {
            dtGrigSach_DG.DataSource = s.HienThi();
        }

        private void btnTTCN_Click(object sender, EventArgs e)
        {
            frmChiTietDG fd = new frmChiTietDG();
            fd.Show();
            this.Hide();
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            frmDangNhap fn = new frmDangNhap();
            fn.Show();
            this.Hide();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void txtTk_TacGia_TextChanged(object sender, EventArgs e)
        {
            dtGrigSach_DG.DataSource = tk.TKTen_TacGia(txtTk_TacGia.Text);
        }

        private void txtTK_TheLoai_TextChanged(object sender, EventArgs e)
        {
            dtGrigSach_DG.DataSource = tk.TKTen_TheLoai(txtTK_TheLoai.Text);
        }

        private void txtTK_TenSach_TextChanged(object sender, EventArgs e)
        {
            dtGrigSach_DG.DataSource = tk.TKTen_DauSach(txtTK_TenSach.Text);
        }

       




    }
}
