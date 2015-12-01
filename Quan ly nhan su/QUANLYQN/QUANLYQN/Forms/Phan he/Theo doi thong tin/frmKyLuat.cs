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
    public partial class frmKyLuat : Form
    {
        public frmKyLuat()
        {
            InitializeComponent();
        }
        private Lskyluat _Lskyluat;
        private string connectstring = ConfigurationManager.ConnectionStrings["netTiersConnectionString"].ConnectionString;

        private void VoidLoadToComboBoxHinhThucKyLuat()
        {
            DataSet dataset = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select * from DMHINHTHUCKYLUAT");
            cboHTKyLuat.DisplayMember = "HINHTHUC_KYLUAT";
            cboHTKyLuat.ValueMember = "ID_HINHTHUC_KYLUAT";
            cboHTKyLuat.DataSource = dataset.Tables[0];
        }
        private void VoidBankControl()
        {
            txtGhiChu.Text = "";
            txtNgayQD.Text = "";
            txtCapKyLuat.Text = "";
        }
        private void VoidGetLskyluat(Lskyluat obj)
        {
            if (obj != null)
            {
                cboHTKyLuat.SelectedValue = obj.IdHinhthucKyluat;
                txtCapKyLuat.Text = obj.CapKyluat;
                txtNgayQD.Text = obj.NgayQuyetdinh.ToString();
                txtGhiChu.Text = obj.Ghichu;
            }
        }
        private void VoidSetLskyluat()
        {
            if (_Lskyluat == null)
            {
                _Lskyluat = new Lskyluat();
                _Lskyluat.IdQuannhan = frmTheoDoiThongTin._Quannhan.IdQuannhan;
            }
            _Lskyluat.IdHinhthucKyluat = Convert.ToInt32(cboHTKyLuat.SelectedValue);
            _Lskyluat.NgayQuyetdinh = Convert.ToDateTime(txtNgayQD.Text);
            _Lskyluat.CapKyluat = txtCapKyLuat.Text;
            _Lskyluat.Ghichu = txtGhiChu.Text;
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            VoidBankControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            VoidSetLskyluat();
            try
            {
                if (frmTheoDoiThongTin.intNeworUpdate == 1)
                    DataRepository.LskyluatProvider.Insert(_Lskyluat);
                if (frmTheoDoiThongTin.intNeworUpdate == 2)
                    DataRepository.LskyluatProvider.Update(_Lskyluat);
                this.Close();
            }
            catch { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmKyLuat_Load(object sender, EventArgs e)
        {
            VoidLoadToComboBoxHinhThucKyLuat();
            _Lskyluat = frmTheoDoiThongTin._Lskyluat;
            if (frmTheoDoiThongTin.intNeworUpdate == 1)
                VoidBankControl();
            if (frmTheoDoiThongTin.intNeworUpdate == 2)
                VoidGetLskyluat(_Lskyluat);
        }
    }
}
