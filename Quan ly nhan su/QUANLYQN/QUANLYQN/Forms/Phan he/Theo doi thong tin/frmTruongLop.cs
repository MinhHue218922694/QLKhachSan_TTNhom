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
    public partial class frmTruongLop : Form
    {
        public frmTruongLop()
        {
            InitializeComponent();
        }

        // Private Member
        private Lstruonglop _Lstruonglop;
        private string connectstring = ConfigurationManager.ConnectionStrings["netTiersConnectionString"].ConnectionString;
        
        // Private Method
        private void VoidLoadToComboBoxTenTruong()
        {
            cboTenTruong.DisplayMember = "TENTRUONG";
            cboTenTruong.ValueMember = "ID_TRUONG";
            cboTenTruong.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "SELECT * FROM DMTRUONG").Tables[0];
        }
        private void VoidLoadToComboBoxCapHoc()
        {
            cboCapHoc.DisplayMember = "CAPHOC";
            cboCapHoc.ValueMember = "ID_CAPHOC";
            cboCapHoc.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "SELECT * FROM DMCAPHOC").Tables[0];
        }

        private void VoidSetLsTruongLop()
        {
            if (_Lstruonglop == null)
            {
                _Lstruonglop = new Lstruonglop();
                _Lstruonglop.IdQuannhan = frmTheoDoiThongTin._Quannhan.IdQuannhan;
            }
            _Lstruonglop.IdTruong = Convert.ToInt32(cboTenTruong.SelectedValue);
            _Lstruonglop.IdCaphoc = Convert.ToInt32(cboCapHoc.SelectedValue);
            if (txtGhiChu.Text != "")
                _Lstruonglop.Ghichu = txtGhiChu.Text;
            if (txtNganhHoc.Text != "")
                _Lstruonglop.Nganhhoc = txtNganhHoc.Text;
            if (txtThoiGianBD.Text != "")
                _Lstruonglop.ThoigianBatdau = Convert.ToDateTime(txtThoiGianBD.Text);
            if (txtThoiGianKT.Text != "")
                _Lstruonglop.ThoigianKetthuc = Convert.ToDateTime(txtThoiGianKT.Text);
        }

        private void VoidGetLstruonglop(Lstruonglop obj)
        {
            if (obj != null)
            {
                cboCapHoc.SelectedValue = obj.IdCaphoc;
                cboTenTruong.SelectedValue = obj.IdTruong;
                txtGhiChu.Text = obj.Ghichu;
                txtNganhHoc.Text = obj.Nganhhoc;
                txtThoiGianBD.Text = obj.ThoigianBatdau.ToString();
                txtThoiGianKT.Text = obj.ThoigianKetthuc.ToString();
            }
        }

        private void VoidBankControl()
        {
            txtThoiGianKT.Text = "";
            txtThoiGianBD.Text = "";
            txtNganhHoc.Text = "";
            txtGhiChu.Text = "";
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            VoidSetLsTruongLop();
            try
            {
                if (frmTheoDoiThongTin.intNeworUpdate == 1)
                    DataRepository.LstruonglopProvider.Insert(_Lstruonglop);
                if (frmTheoDoiThongTin.intNeworUpdate == 2)
                    DataRepository.LstruonglopProvider.Update(_Lstruonglop);
                this.Close();
            }
            catch
            { }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            VoidBankControl();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmTruongLop_Load(object sender, EventArgs e)
        {
            VoidLoadToComboBoxCapHoc();
            VoidLoadToComboBoxTenTruong();
            _Lstruonglop = frmTheoDoiThongTin._Lstruonglop;
            if(frmTheoDoiThongTin.intNeworUpdate==1)
                VoidBankControl();
            if (frmTheoDoiThongTin.intNeworUpdate == 2)
                VoidGetLstruonglop(_Lstruonglop);
        }
        //Private Events
    }
}
