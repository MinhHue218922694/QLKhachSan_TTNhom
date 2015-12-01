using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using QUANLYQN.Data;
using QUANLYQN.Entities;
using QUANLYQN.Data.SqlClient;
using Microsoft.ApplicationBlocks.Data;
using System.Configuration;

namespace QUANLYQN.Forms.Phan_he.Theo_doi_thong_tin
{
    public partial class frmChucVu : Form
    {
        public frmChucVu()
        {
            InitializeComponent();
        }

        private Lschucvu _Lschucvu;
        private string connectstring = ConfigurationManager.ConnectionStrings["netTiersConnectionString"].ConnectionString;
        private void VoidLoadToComboBoxChucVu(ComboBox cbo)
        {
            cbo.DisplayMember = "CHUCVU";
            cbo.ValueMember = "ID_CHUCVU";
            cbo.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select * from DMCHUCVU").Tables[0];
        }
        private void VoidBankControl()
        {
            txtGhiChu.Text = "";
            txtNgayNhan.Text = "";
        }
        private void VoidGetLschucvu(Lschucvu obj)
        {
            if (obj != null)
            {
                txtNgayNhan.Text = obj.Ngaynhan.ToString();
                txtGhiChu.Text = obj.Ghichu;
                cboChucVu.SelectedValue = obj.IdChucvu;
            }
        }
        private void VoidSetLschucvu()
        {
            if (_Lschucvu == null)
            {
                _Lschucvu = new Lschucvu();
                _Lschucvu.IdQuannhan = frmTheoDoiThongTin._Quannhan.IdQuannhan;
            }
            _Lschucvu.IdChucvu = Convert.ToInt32(cboChucVu.SelectedValue);
            if (txtGhiChu.Text != "")
                _Lschucvu.Ghichu = txtGhiChu.Text;
            if (txtNgayNhan.Text != "")
                _Lschucvu.Ngaynhan = Convert.ToDateTime(txtNgayNhan.Text);
        }

        private void frmChucVu_Load(object sender, EventArgs e)
        {
            VoidLoadToComboBoxChucVu(cboChucVu);
            _Lschucvu = frmTheoDoiThongTin._Lschucvu;
            if (frmTheoDoiThongTin.intNeworUpdate == 1)
                VoidBankControl();
            if (frmTheoDoiThongTin.intNeworUpdate == 2)
                VoidGetLschucvu(_Lschucvu);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            VoidBankControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            VoidSetLschucvu();
            try
            {
                if (frmTheoDoiThongTin.intNeworUpdate == 1)
                    DataRepository.LschucvuProvider.Insert(_Lschucvu);
                if (frmTheoDoiThongTin.intNeworUpdate == 2)
                    DataRepository.LschucvuProvider.Update(_Lschucvu);
                this.Close();
            }
            catch
            {
 
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
