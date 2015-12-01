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
    public partial class frmCapBac : Form
    {
        public frmCapBac()
        {
            InitializeComponent();
        }

        private Lscapbac _Lscapbac;
        private string connectstring = ConfigurationManager.ConnectionStrings["netTiersConnectionString"].ConnectionString;

        #region Private Method
        private void VoidLoadToComboBoxCapBac()
        {
            DataSet dataset = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select * from DMCAPBAC");
            cboCapBac.DisplayMember = "CAPBAC";
            cboCapBac.ValueMember = "ID_CAPBAC";
            cboCapBac.DataSource = dataset.Tables[0];
        }
        private void VoidBankControls()
        {
            txtGhiChu.Text = "";
            txtNgayNhan.Text = "";
        }

        private void VoidGetLsCapbac(Lscapbac obj)
        {
            if (obj != null)
            {
                cboCapBac.SelectedValue = obj.IdCapbac;
                txtNgayNhan.Text = obj.Ngaynhan.ToString();
                txtGhiChu.Text = obj.Ghichu;
            }
        }

        private void VoidSetLscapbac()
        {
            if (_Lscapbac == null)
            {
                _Lscapbac = new Lscapbac();
                _Lscapbac.IdQuannhan = frmTheoDoiThongTin._Quannhan.IdQuannhan;
            }
            _Lscapbac.IdCapbac = Convert.ToInt32(cboCapBac.SelectedValue);
            if (txtGhiChu.Text != "")
                _Lscapbac.Ghichu = txtGhiChu.Text;
            if (txtNgayNhan.Text != "")
                _Lscapbac.Ngaynhan = Convert.ToDateTime(txtNgayNhan.Text);
        }
        #endregion


        #region Private Event

        private void frmCapBac_Load(object sender, EventArgs e)
        {
            VoidLoadToComboBoxCapBac();
            _Lscapbac = frmTheoDoiThongTin._Lscapbac;
            if (frmTheoDoiThongTin.intNeworUpdate==1)
                VoidBankControls();
            if (frmTheoDoiThongTin.intNeworUpdate == 2)
                VoidGetLsCapbac(_Lscapbac);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (frmTheoDoiThongTin.intNeworUpdate == 1)
                VoidBankControls();
            if (frmTheoDoiThongTin.intNeworUpdate == 2)
                VoidGetLsCapbac(_Lscapbac);
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            VoidSetLscapbac();
            try
            {
                if (frmTheoDoiThongTin.intNeworUpdate == 1)
                    DataRepository.LscapbacProvider.Insert(_Lscapbac);
                if (frmTheoDoiThongTin.intNeworUpdate == 2)
                    DataRepository.LscapbacProvider.Update(_Lscapbac);
                this.Close();
            }
            catch
            { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

    }
}
