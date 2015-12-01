using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;


using QUANLYQN.Data;
using QUANLYQN.Entities;
using QUANLYQN.Data.SqlClient;

using Microsoft.ApplicationBlocks.Data;

using System.Configuration;
using System.Diagnostics;

namespace QUANLYQN.Forms.Phan_he.Theo_doi_thong_tin
{
    public partial class frmTheoDoiThongTin : Form
    {
        public frmTheoDoiThongTin()
        {
            InitializeComponent();
        }

        #region  Member

        private string connectstring = ConfigurationManager.ConnectionStrings["netTiersConnectionString"].ConnectionString;
        private int total;

        public static Quannhan _Quannhan;
        public static int intNeworUpdate = 0;
        public static Lscapbac _Lscapbac;
        public static Lschucvu _Lschucvu;
        public static Lskhenthuong _Lskhenthuong;
        public static Lskyluat _Lskyluat;
        public static Lstruonglop _Lstruonglop;

        #endregion

        #region Private Method

        private void LoadCheckBoxTodgvDanhSach(DataGridView dgv)
        {

            Rectangle rect = dgv.GetCellDisplayRectangle(0, -1, true);
      
            CheckBox checkboxheader = new CheckBox();
            checkboxheader.Name = "checkboxheader";
            checkboxheader.Text = "";
            checkboxheader.CheckAlign = System.Drawing.ContentAlignment.MiddleCenter;
            checkboxheader.Size = new Size(20,24);
            checkboxheader.BackColor = Color.Transparent;
            checkboxheader.Location = rect.Location;
            checkboxheader.CheckedChanged +=new EventHandler(checkboxheader_CheckedChanged);

            dgv.Controls.Add(checkboxheader);

        }

        private void LoadComboxKhoaHoc(ComboBox cbo)
        {
            cbo.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select* from DMDONVI where MA_DONVI like 'c%'").Tables[0];
            cbo.DisplayMember = "TEN_DONVI";

        }

        private void LoadToComboBoxDaiDoi(ComboBox cbo)
        {
            cbo.DisplayMember = "TEN_DONVI";
            cbo.ValueMember = "ID_DONVI";
            cbo.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select* from DMDONVI where MA_DONVI like 'c%'").Tables[0];
        }

        private void LoadToComboBoxLop(ComboBox cbo_Lop, int IDDAIDOI)
        {
            cbo_Lop.DisplayMember = "TENLOP";
            cbo_Lop.ValueMember = "ID_LOP";
            cbo_Lop.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select * from DMLOP where ID_DAIDOI = '"+IDDAIDOI+"'").Tables[0];
        }

        private void LoadTodgvDanhSach(int ID_DAIDOI, int ID_LOP)
        {
            DataSet dataset = SqlHelper.ExecuteDataset(connectstring, CommandType.Text,
                "select HOTEN_KHAISINH, ID_QUANNHAN from QUANNHAN where ID_DONVI = " + ID_DAIDOI + " and ID_LOP = " + ID_LOP + "");
            dgvDanhSach.Columns[2].DataPropertyName = "HOTEN_KHAISINH";
            dgvDanhSach.Columns[3].DataPropertyName = "ID_QUANNHAN";
            dgvDanhSach.DataSource = dataset.Tables[0];
            if (dgvDanhSach.RowCount > 1)
            {
                _Quannhan = DataRepository.QuannhanProvider.GetByIdQuannhan(Convert.ToInt32(dgvDanhSach.Rows[0].Cells["ID"].Value));
            }
            VoidGetQuannhan(_Quannhan);
        }

        private void LoadTodgvCapBac(int ID_QUANNHAN)
        {
            dgvCapBac.Columns[0].DataPropertyName = "ID_LICHSUCAPBAC";
            dgvCapBac.Columns["CAPBAC"].DataPropertyName = "CAPBAC";
            dgvCapBac.Columns["NGAYNHAN_CB"].DataPropertyName = "NGAYNHAN";
            dgvCapBac.Columns["GHICHU_CB"].DataPropertyName = "GHICHU";
            dgvCapBac.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text,
                "select ID_LICHSUCAPBAC,CAPBAC,NGAYNHAN,LSCAPBAC.GHICHU as GHICHU from LSCAPBAC inner join DMCAPBAC on LSCAPBAC.ID_CAPBAC = DMCAPBAC.ID_CAPBAC where ID_QUANNHAN = " + ID_QUANNHAN + " ").Tables[0];
        }

        private void LoadTodgvChucVu(int ID_QUANNHAN)
        {
            dgvChucVu.Columns["ID_LSCV"].DataPropertyName = "ID_LICHSUCHUCVU";
            dgvChucVu.Columns["CHUCVU"].DataPropertyName = "CHUCVU";
            dgvChucVu.Columns["NGAYNHAN_CV"].DataPropertyName = "NGAYNHAN";
            dgvChucVu.Columns["GHICHU_CV"].DataPropertyName = "GHICHU";
            dgvChucVu.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text,
                "select ID_LICHSUCHUCVU,CHUCVU,NGAYNHAN,LSCHUCVU.GHICHU as GHICHU from LSCHUCVU inner join DMCHUCVU on LSCHUCVU.ID_CHUCVU = DMCHUCVU.ID_CHUCVU where ID_QUANNHAN = " + ID_QUANNHAN + " ").Tables[0];
        }

        private void LoadTodgvKhenThuong(int ID_QUANNHAN)
        {
            dgvKhenThuong.Columns[0].DataPropertyName = "ID_LICHSUKHENTHUONG";
            dgvKhenThuong.Columns["HT_KHENTHUONG"].DataPropertyName = "HINHTHUC_KHENTHUONG";
            dgvKhenThuong.Columns["CAP_KHENTHUONG"].DataPropertyName = "CAP_KHENTHUONG";
            dgvKhenThuong.Columns["NGAYNHAN_KHENTHUONG"].DataPropertyName = "NGAYNHAN";
            dgvKhenThuong.Columns["GHICHU_KHENTHUONG"].DataPropertyName = "GHICHU";
            dgvKhenThuong.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text,
                "select ID_LICHSUKHENTHUONG,HINHTHUC_KHENTHUONG,CAP_KHENTHUONG,NGAYNHAN,LSKHENTHUONG.GHICHU as GHICHU from LSKHENTHUONG inner join DMHINHTHUCKHENTHUONG on LSKHENTHUONG.ID_HINHTHUC_KHENTHUONG = DMHINHTHUCKHENTHUONG.ID_HINHTHUC_KHENTHUONG where ID_QUANNHAN = " + ID_QUANNHAN + " ").Tables[0];
        }

        private void LoadTodgvKyLuat(int ID_QUANNHAN)
        {
            dgvKyLuat.Columns[0].DataPropertyName = "ID_LICHSUKYLUAT";
            dgvKyLuat.Columns["HT_KYLUAT"].DataPropertyName = "HINHTHUC_KYLUAT";
            dgvKyLuat.Columns["CAP_KYLUAT"].DataPropertyName = "CAP_KYLUAT";
            dgvKyLuat.Columns["NGAY_KYLUAT"].DataPropertyName = "NGAY_QUYETDINH";
            dgvKyLuat.Columns["GHICHU_KYLUAT"].DataPropertyName = "GHICHU";
            dgvKyLuat.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text,
                "select ID_LICHSUKYLUAT,HINHTHUC_KYLUAT,CAP_KYLUAT,NGAY_QUYETDINH,LSKYLUAT.GHICHU as GHICHU from LSKYLUAT inner join DMHINHTHUCKYLUAT on LSKYLUAT.ID_HINHTHUC_KYLUAT = DMHINHTHUCKYLUAT.ID_HINHTHUC_KYLUAT where ID_QUANNHAN = " + ID_QUANNHAN + " ").Tables[0];
        }

        private void LoadTodgvTruongLop(int ID_QUANNHAN)
        {
            dgvTruongLop.Columns[0].DataPropertyName = "ID_LICHSUTRUONGLOP";
            dgvTruongLop.Columns[1].DataPropertyName = "TENTRUONG";
            dgvTruongLop.Columns[2].DataPropertyName = "CAPHOC";
            dgvTruongLop.Columns[3].DataPropertyName = "NGANHHOC";
            dgvTruongLop.Columns[4].DataPropertyName = "THOIGIAN_BATDAU";
            dgvTruongLop.Columns[5].DataPropertyName = "THOIGIAN_KETTHUC";
            dgvTruongLop.Columns[6].DataPropertyName = "GHICHU";
            dgvTruongLop.DataSource = SqlHelper.ExecuteDataset(connectstring,CommandType.Text,
                "select ID_LICHSUTRUONGLOP,TENTRUONG, CAPHOC,NGANHHOC,THOIGIAN_BATDAU,THOIGIAN_KETTHUC,LSTL.GHICHU from LSTRUONGLOP as LSTL, DMCAPHOC as DMCH, DMTRUONG as DMT where LSTL.ID_TRUONG = DMT.ID_TRUONG and LSTL.ID_CAPHOC = DMCH.ID_CAPHOC and ID_QUANNHAN = " + ID_QUANNHAN).Tables[0];
 
        }

        private void VoidGetQuannhan(Quannhan obj)
        {
            if (obj != null)
            {
                picAnh.Image = null;
                if (obj.AnhQuannhan != null)
                    picAnh.Image = ConvertByteToImage(obj.AnhQuannhan);

                txtCMTQN.Text = obj.CmtQuannhan.ToString();
                txtDiaChi_BaoTin.Text = obj.DcBaotin;
                txtHoTen.Text = obj.HotenThuongdung;
                txtHoTenCha.Text = obj.HotenCha;
                txtHoTenMe.Text = obj.HotenMe;
                txtMaQuanNhan.Text = obj.MaQuannhan;
                txtNgayNhapNgu.Text = obj.NgayNhapngu.ToShortDateString();
                txtNgayTaiNgu.Text = obj.NgayTaingu.ToString();
                txtNgayVaoDang.Text = obj.NgayVaodang.ToString();
                txtNgayVaoDang_CT.Text = obj.NgayvaodangChinhthuc.ToString();
                txtNgayVaoDoan.Text = obj.NgayVaodoan.ToString();
                txtNgayXuatNgu.Text = obj.NgayXuatngu.ToString();
                txtNguyenQuan.Text = obj.Nguyenquan;
                txtTruQuan.Text = obj.Truquan;
                txtNgaySinh.Text = obj.Ngaysinh.ToString();
                txtSoHieuQN.Text = obj.SotheQuannhan.ToString();
                txtHoTenVo_Chong.Text = obj.SafeNameHotenVoChong;


                Dmcapbac _Dmcapbac = DataRepository.DmcapbacProvider.GetByIdCapbac(obj.IdCapbac);
                txtCapBac.Text = _Dmcapbac.Capbac;

                Dmchucvu _Dmchucvu = DataRepository.DmchucvuProvider.GetByIdChucvu(obj.IdChucvu);
                txtChucVu.Text = _Dmchucvu.Chucvu;

                Dmdonvi _Dmdonvi = DataRepository.DmdonviProvider.GetByIdDonvi(obj.IdDonvi);
                txtDaiDoi.Text = _Dmdonvi.TenDonvi;

                Dmlop _Dmlop = DataRepository.DmlopProvider.GetByIdLop(obj.IdLop);
                txtLop.Text = _Dmlop.Tenlop;

                Dmgioitinh _Dmgioitinh = DataRepository.DmgioitinhProvider.GetByIdGioitinh(obj.IdGioitinh);
                txtGioiTinh.Text = _Dmgioitinh.Gioitinh;

                Dmdantoc _Dmdantoc = DataRepository.DmdantocProvider.GetByIdDantoc(obj.IdDantoc);
                txtDanToc.Text = _Dmdantoc.Dantoc;

                Dmtongiao _Dmtongiao = DataRepository.DmtongiaoProvider.GetByIdTongiao(obj.IdTongiao);
                txtTonGiao.Text = _Dmtongiao.Tongiao;

                switch (tabCLichSu.SelectedIndex)
                {
                    case 0:
                        {
                            LoadTodgvCapBac(obj.IdQuannhan);
                            break;
                        }
                    case 1:
                        {
                            LoadTodgvChucVu(obj.IdQuannhan);
                            break;
                        }
                    case 2:
                        {
                            LoadTodgvKhenThuong(obj.IdQuannhan);
                            break;
                        }
                    case 3:
                        {
                            LoadTodgvKyLuat(obj.IdQuannhan);
                            break;
                        }
                    case 4:
                        {
                            break;
                        }
                    case 5:
                        {
                            break;
                        }
                    case 6:
                        {
                            break;
                        }
                }

            }
        }

        private void SearchByMA_QUANNHAN(string strMa)
        {
            _Quannhan = DataRepository.QuannhanProvider.GetPaged("MA_QUANNHAN = '" + strMa + "'", "", 0, 100, out total)[0];
            VoidGetQuannhan(_Quannhan);
     
        }

        private void SearchBySOHIEU_QUANNHAN(int intSoHieu_QuanNhan)
        {
            _Quannhan = DataRepository.QuannhanProvider.GetPaged("SOTHE_QUANNHAN = '" + intSoHieu_QuanNhan + "'", "", 0, 100, out total)[0];
            VoidGetQuannhan(_Quannhan);
        }

        private void SearchBySO_CMTQN(int intCMT_QUANNHAN)
        {
            _Quannhan = DataRepository.QuannhanProvider.GetPaged("CMT_QUANNHAN = '" + intCMT_QUANNHAN + "'", "", 0, 100, out total)[0];
            VoidGetQuannhan(_Quannhan);    
        }

        private Image ConvertByteToImage(byte[] _byte)
        {
            MemoryStream ms = new MemoryStream(_byte);
            return Image.FromStream(ms);
        }

        #endregion

        #region Private Events

        private void frmTheoDoiThongTin_Load(object sender, EventArgs e)
        {
            LoadCheckBoxTodgvDanhSach(dgvDanhSach);
            LoadToComboBoxDaiDoi(cboTimKiem_DaiDoi);
        }

        private void checkboxheader_CheckedChanged(object obj, EventArgs e)
        {
            for (int i = 0; i < dgvDanhSach.RowCount - 1; i++)
            {
                dgvDanhSach[0, i].Value = ((CheckBox)dgvDanhSach.Controls.Find("checkboxheader", true)[0]).Checked;
            }

        }

        private void cboTimKiem_DaiDoi_SelectedIndexChanged(object sender, EventArgs e)
        {
                int index = Convert.ToInt32(cboTimKiem_DaiDoi.SelectedValue);
                LoadToComboBoxLop(cboTimKiem_Lop, index);
        }

        private void cboTimKiem_Lop_SelectedIndexChanged(object sender, EventArgs e)
        {
                int intID_Donvi = Convert.ToInt32(cboTimKiem_DaiDoi.SelectedValue);
                int intID_Lop = Convert.ToInt32(cboTimKiem_Lop.SelectedValue);
                LoadTodgvDanhSach(intID_Donvi, intID_Lop);
        }

        private void txtTimKiem_MaHV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtTimKiem_MaHV.Text != "")
                {
                    try
                    {
                        SearchByMA_QUANNHAN(txtTimKiem_MaHV.Text);
                        txtTimKiem_MaHV.Text = "";
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
            }
        }

        private void txtTimKiem_SoHieuQN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtTimKiem_SoHieuQN.Text != "")
                {
                    try
                    {
                        SearchBySOHIEU_QUANNHAN(Convert.ToInt32(txtTimKiem_SoHieuQN.Text));
                        txtTimKiem_SoHieuQN.Text = "";
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
            }
        }

        private void txtTimKiem_SoCMTQN_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                if (txtTimKiem_SoCMTQN.Text != "")
                {
                    try
                    {
                        SearchBySO_CMTQN(Convert.ToInt32(txtTimKiem_SoCMTQN.Text));
                        txtTimKiem_SoCMTQN.Text = "";
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
            }

        }

        private void tabCLichSu_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabCLichSu.SelectedIndex)
            {
                case 0:
                    {
                        LoadTodgvCapBac(_Quannhan.IdQuannhan);
                        break;
                    }
                case 1:
                    {
                        LoadTodgvChucVu(_Quannhan.IdQuannhan);
                        break;
                    }
                case 2:
                    {
                        LoadTodgvKhenThuong(_Quannhan.IdQuannhan);
                        break;
                    }
                case 3:
                    {
                        LoadTodgvKyLuat(_Quannhan.IdQuannhan);
                        break;
                    }
            }

        }

        //Cac su kien cho ContextMenuStrip1
        private void mnuThem_Click(object sender, EventArgs e)
        {
            _Lscapbac = new Lscapbac();
            _Lscapbac.IdQuannhan = _Quannhan.IdQuannhan;
            intNeworUpdate = 1;
            switch (tabCLichSu.SelectedIndex)
            {
                case 0:
                    {
                        frmCapBac frm = new frmCapBac();
                        frm.ShowDialog();
                        LoadTodgvCapBac(_Quannhan.IdQuannhan);
                        break;
                    }
                case 1:
                    {
                        frmChucVu frm = new frmChucVu();
                        frm.ShowDialog();
                        LoadTodgvChucVu(_Quannhan.IdQuannhan);
                        break;
                    }
                case 2:
                    {
                        frmKhenThuong frm = new frmKhenThuong();
                        frm.ShowDialog();
                        LoadTodgvKhenThuong(_Quannhan.IdQuannhan);
                        break;
                    }
                case 3:
                    {
                        frmKyLuat frm = new frmKyLuat();
                        frm.ShowDialog();
                        LoadTodgvKyLuat(_Quannhan.IdQuannhan);
                        break;
                    }
                case 4:
                    {
                        frmTruongLop frm = new frmTruongLop();
                        frm.ShowDialog();
                        LoadTodgvTruongLop(_Quannhan.IdQuannhan);
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 6:
                    {
                        break;
                    }
            }
        }

        private void mnuXoa_Click(object sender, EventArgs e)
        {
            DialogResult _DialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (_DialogResult == DialogResult.OK)
            {
                try
                {
                    switch (tabCLichSu.SelectedIndex)
                    {
                        case 0:
                            {
                                DataRepository.LscapbacProvider.Delete(_Lscapbac);
                                LoadTodgvCapBac(_Quannhan.IdQuannhan);
                                break;
                            }
                        case 1:
                            {
                                DataRepository.LschucvuProvider.Delete(_Lschucvu);
                                LoadTodgvChucVu(_Quannhan.IdQuannhan);
                                break;
                            }
                        case 2:
                            {
                                DataRepository.LskhenthuongProvider.Delete(_Lskhenthuong);
                                LoadTodgvKhenThuong(_Quannhan.IdQuannhan);
                                break;
                            }
                        case 3:
                            {
                                DataRepository.LskyluatProvider.Delete(_Lskyluat);
                                LoadTodgvKyLuat(_Quannhan.IdQuannhan);
                                break;
                            }
                        case 4:
                            {
                                DataRepository.LstruonglopProvider.Delete(_Lstruonglop);
                                LoadTodgvTruongLop(_Quannhan.IdQuannhan);
                                break;
                            }
                        case 5:
                            {
                                break;
                            }
                        case 6:
                            {
                                break;
                            }
                    }
                }
                catch
                { }
            }
        }

        private void mnuSua_Click(object sender, EventArgs e)
        {
            intNeworUpdate = 2;

            switch (tabCLichSu.SelectedIndex)
            {
                case 0:
                    {
                        if (_Lscapbac != null)
                        {
                            frmCapBac frm = new frmCapBac();
                            frm.ShowDialog();
                            LoadTodgvCapBac(_Quannhan.IdQuannhan);
                        }
                        break;
                    }
                case 1:
                    {
                        if (_Lschucvu != null)
                        {
                            frmChucVu frm = new frmChucVu();
                            frm.ShowDialog();
                            LoadTodgvChucVu(_Quannhan.IdQuannhan);
                        }
                        break;
                    }
                case 2:
                    {
                        if (_Lskhenthuong != null)
                        {
                            frmKhenThuong frm = new frmKhenThuong();
                            frm.ShowDialog();
                            LoadTodgvKhenThuong(_Quannhan.IdQuannhan);
                        }
                        break;
                    }
                case 3:
                    {
                        if (_Lskyluat != null)
                        {
                            frmKyLuat frm = new frmKyLuat();
                            frm.ShowDialog();
                            LoadTodgvKyLuat(_Quannhan.IdQuannhan);
                        }
                        break;
                    }
                case 4:
                    {
                        if (_Lstruonglop != null)
                        {
                            frmTruongLop frm = new frmTruongLop();
                            frm.ShowDialog();
                            LoadTodgvTruongLop(_Quannhan.IdQuannhan);
                        }
                        break;
                    }
                case 5:
                    {
                        break;
                    }
                case 6:
                    {
                        break;
                    }
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            intNeworUpdate = 2;
            QUANLYQN.Forms.Phan_he.Nhap_Thong_Tin.frmNhapthongtin frm = new QUANLYQN.Forms.Phan_he.Nhap_Thong_Tin.frmNhapthongtin();
            frm.MdiParent = this.MdiParent;
            frm.Dock = DockStyle.Fill;
            this.Close();
            frm.Show();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            intNeworUpdate = 1;
            QUANLYQN.Forms.Phan_he.Nhap_Thong_Tin.frmNhapthongtin frm = new QUANLYQN.Forms.Phan_he.Nhap_Thong_Tin.frmNhapthongtin();
            frm.MdiParent = this.MdiParent;
            frm.Dock = DockStyle.Fill;
            this.Close();
            frm.Show();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult _DialogResult = MessageBox.Show("Bạn có chắc chắn muốn xóa không?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (_DialogResult == DialogResult.Yes)
            {
                try
                {
                    DataRepository.QuannhanProvider.Delete(_Quannhan);

                    int intID_Donvi = Convert.ToInt32(cboTimKiem_DaiDoi.SelectedValue);
                    int intID_Lop = Convert.ToInt32(cboTimKiem_Lop.SelectedValue);
                    LoadTodgvDanhSach(intID_Donvi, intID_Lop);
                }
                catch { }
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            QUANLYQN.Forms.Phan_he.Nhap_Thong_Tin.frmTimkiem frm = new QUANLYQN.Forms.Phan_he.Nhap_Thong_Tin.frmTimkiem();
            frm.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dgvDanhSach_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dgvDanhSach.Rows[e.RowIndex].Cells[3].Value != null)
                {
                    int id_quannhan = Convert.ToInt32(dgvDanhSach.Rows[e.RowIndex].Cells["ID"].Value);
                    _Quannhan = DataRepository.QuannhanProvider.GetByIdQuannhan(id_quannhan);
                    VoidGetQuannhan(_Quannhan);
                }
            }
            catch
            { }
        }

        private void dgvDanhSach_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            for (int i = 0; i < dgvDanhSach.RowCount - 1; i++)
            {
                dgvDanhSach[1, i].Value = i + 1;
            }
        }

        private void dgvCapBac_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _Lscapbac = DataRepository.LscapbacProvider.GetByIdLichsucapbac(Convert.ToInt64(dgvKyLuat[0, e.RowIndex].Value));
            }
            catch
            {
            }
        }

        private void dgvChucVu_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _Lschucvu = DataRepository.LschucvuProvider.GetByIdLichsuchucvu(Convert.ToInt64(dgvKyLuat[0, e.RowIndex].Value));
            }
            catch
            { }
        }

        private void dgvKhenThuong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _Lskhenthuong = DataRepository.LskhenthuongProvider.GetByIdLichsukhenthuong(Convert.ToInt64(dgvKhenThuong[0, e.RowIndex].Value));
            }
            catch
            { }
        }

        private void dgvKyLuat_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _Lskyluat = DataRepository.LskyluatProvider.GetByIdLichsukyluat(Convert.ToInt64(dgvKyLuat[0, e.RowIndex].Value));
            }
            catch
            { }

        }

        private void dgvTruongLop_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                _Lstruonglop = DataRepository.LstruonglopProvider.GetByIdLichsutruonglop(Convert.ToInt64(dgvTruongLop[0, e.RowIndex].Value));
            }
            catch { }

        }
        
        #endregion

    }
}
