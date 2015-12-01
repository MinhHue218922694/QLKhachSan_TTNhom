using System;
using System.Collections;
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
    public partial class frmKhenThuong : Form
    {
        public frmKhenThuong()
        {
            InitializeComponent();
        }

        // Private Member
        Lskhenthuong _Lskhenthuong;
        private string connectstring = ConfigurationManager.ConnectionStrings["netTiersConnectionString"].ConnectionString;

        //Private Method
        private void VoidSetLskhenthuong()
        {
            if (_Lskhenthuong == null)
            {
                _Lskhenthuong = new Lskhenthuong();
                _Lskhenthuong.IdQuannhan = frmTheoDoiThongTin._Quannhan.IdQuannhan;
            }
            _Lskhenthuong.IdHinhthucKhenthuong = Convert.ToInt32(cboHTkhenThuong.SelectedValue);
            if (txtCapKhenThuong.Text != "")
                _Lskhenthuong.CapKhenthuong = txtCapKhenThuong.Text;
            if (txtNgayQD.Text != "")
                _Lskhenthuong.Ngaynhan = Convert.ToDateTime(txtNgayQD.Text);
            if (txtGhiChu.Text != "")
                _Lskhenthuong.Ghichu = txtGhiChu.Text;
        }
        private void VoidGetLskhenthuong(Lskhenthuong obj)
        {
            if (obj != null)
            {
                cboHTkhenThuong.SelectedValue = _Lskhenthuong.IdHinhthucKhenthuong;
                txtNgayQD.Text = _Lskhenthuong.Ngaynhan.ToString();
                txtCapKhenThuong.Text = _Lskhenthuong.CapKhenthuong;
                txtGhiChu.Text = _Lskhenthuong.Ghichu;
            }
        }
        private void VoidLoadToComboBoxKhenThuong()
        {
            cboHTkhenThuong.DisplayMember = "HINHTHUC_KHENTHUONG";
            cboHTkhenThuong.ValueMember = "ID_HINHTHUC_KHENTHUONG";
            cboHTkhenThuong.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text,
                "select * from DMHINHTHUCKHENTHUONG").Tables[0];            
        }
        private void VoidBankControl()
        {
            txtCapKhenThuong.Text = "";
            txtGhiChu.Text = "";
            txtNgayQD.Text = "";
        }
        //Private Events
        private void frmKhenThuong_Load(object sender, EventArgs e)
        {
            VoidLoadToComboBoxKhenThuong();
            _Lskhenthuong = frmTheoDoiThongTin._Lskhenthuong;
            if (frmTheoDoiThongTin.intNeworUpdate == 1)
                VoidBankControl();
            if (frmTheoDoiThongTin.intNeworUpdate == 2)
                VoidGetLskhenthuong(_Lskhenthuong);
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            VoidBankControl();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            VoidSetLskhenthuong();
            try
            {
                if (frmTheoDoiThongTin.intNeworUpdate == 1)
                    DataRepository.LskhenthuongProvider.Insert(_Lskhenthuong);
                if (frmTheoDoiThongTin.intNeworUpdate == 2)
                    DataRepository.LskhenthuongProvider.Update(_Lskhenthuong);
                this.Close();
            }
            catch
            { }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
