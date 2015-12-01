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

namespace QUANLYQN.Forms.Phan_he.Nhap_Thong_Tin
{
    public partial class frmNhapthongtin : Form
    {
        public frmNhapthongtin()
        {
            InitializeComponent();
        }

        #region Private Member
        private int total;
        private int intID_Daidoi;
        private int intID_Lop;
        private Quannhan _Quannhan;
        private int intNewOrUpdate = 0;
        private string connectstring = ConfigurationManager.ConnectionStrings["netTiersConnectionString"].ConnectionString;
        #endregion

        #region Private Method
        private byte[] ConvertImageToBinary(Image image)
        {
            MemoryStream ms = new MemoryStream();
            image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
            return ms.ToArray();
        }

        private Image ConvertByteToImage(byte[] _byte)
        {
            MemoryStream ms = new MemoryStream(_byte);
            return Image.FromStream(ms);
        }

        private void VoidUpdateImage(int idQuannhan, byte[] byte_image)
        {
            string strCommand = "Update QUANNHAN Set ANH_QUANNHAN = @Image where ID_QUANNHAN = " + idQuannhan;
            SqlConnection sqlcon = new SqlConnection(connectstring);
            SqlCommand sqlcom = new SqlCommand(strCommand, sqlcon);
            sqlcom.CommandType = CommandType.Text;
            sqlcom.Parameters.Add("@Image", SqlDbType.Binary).Value = byte_image;
            sqlcon.Open();
            sqlcom.ExecuteNonQuery();
            sqlcon.Close();
        }

        private void LoadToComboBoxDaiDoi(ComboBox _cboDaiDoi)
        {
            _cboDaiDoi.DisplayMember = "TEN_DONVI";
            _cboDaiDoi.ValueMember = "ID_DONVI";
            _cboDaiDoi.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select* from DMDONVI where MA_DONVI like 'c%'").Tables[0];
            _cboDaiDoi.SelectedIndex = 0;
        }

        private void LoadToComboBoxLop(ComboBox _cboLop, int IDDAIDOI)
        {
            _cboLop.DisplayMember = "TENLOP";
            _cboLop.ValueMember = "ID_LOP";
            _cboLop.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select * from DMLOP where ID_DAIDOI = '" + IDDAIDOI + "'").Tables[0];
            _cboLop.SelectedIndex = 0;
        }

        private void LoadToComboBoxDantoc(ComboBox cbo)
        {
            cbo.DisplayMember = "DANTOC";
            cbo.ValueMember = "ID_DANTOC";
            cbo.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select * from DMDANTOC").Tables[0];
            cbo.SelectedIndex = 0;

        }

        private void LoadToComboBoxGioiTinh(ComboBox cbo)
        {
            cbo.DisplayMember = "GIOITINH";
            cbo.ValueMember = "ID_GIOITINH";
            cbo.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select * from DMGIOITINH").Tables[0];
            cbo.SelectedIndex = 0;
        }

        private void LoadToComboxTonGiao(ComboBox cbo)
        {
            cbo.DisplayMember = "TONGIAO";
            cbo.ValueMember = "ID_TONGIAO";
            cbo.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select * from DMTONGIAO").Tables[0];
            cbo.SelectedIndex = 0;
        }

        private void LoadToComboBoxCapBac(ComboBox cbo)
        {
            cbo.DisplayMember = "CAPBAC";
            cbo.ValueMember = "ID_CAPBAC";
            cbo.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select * from DMCAPBAC").Tables[0];
            cbo.SelectedIndex = 0;
        }

        private void LoadToComboBoxChucVu(ComboBox cbo)
        {
            cbo.DisplayMember = "CHUCVU";
            cbo.ValueMember = "ID_CHUCVU";
            cbo.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select * from DMCHUCVU").Tables[0];
            cbo.SelectedIndex = 0;
        }

        private void LoadToComboBoxLoaiQuanNhan(ComboBox cbo)
        {
            cbo.DisplayMember = "LOAI_QUANNHAN";
            cbo.ValueMember = "ID_LOAIQN";
            cbo.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text, "select * from DMLOAIQUANNHAN").Tables[0];
            cbo.SelectedIndex = 0;
        }

        private void LoadTodgvDanhSach(int ID_DAIDOI, int ID_LOP)
        {
            DataSet dataset = SqlHelper.ExecuteDataset(connectstring, CommandType.Text,
                "select HOTEN_KHAISINH, ID_QUANNHAN from QUANNHAN where ID_DONVI = " + ID_DAIDOI + " and ID_LOP = " + ID_LOP + "");
            dgvDanhSachHV.Columns[1].DataPropertyName = "HOTEN_KHAISINH";
            dgvDanhSachHV.Columns[2].DataPropertyName = "ID_QUANNHAN";
            dgvDanhSachHV.DataSource = dataset.Tables[0];
            btnXoa.Enabled = true;
        }

        private void LoadTodgvQuanSoDaiDoi()
        {
            try
            {
                dgvQuanSoDaiDoi.Columns[1].DataPropertyName = "TEN_DONVI";
                dgvQuanSoDaiDoi.Columns[2].DataPropertyName = "QUANSO";
                dgvQuanSoDaiDoi.Columns[3].DataPropertyName = "ID_DONVI";
                dgvQuanSoDaiDoi.DataSource = SqlHelper.ExecuteDataset(connectstring, CommandType.Text,
                    "SELECT TEN_DONVI, COUNT(*) AS QUANSO, QN.ID_DONVI FROM DMDONVI AS DV, QUANNHAN AS QN WHERE QN.ID_DONVI = DV.ID_DONVI GROUP BY TEN_DONVI, QN.ID_DONVI").Tables[0];
            }
            catch
            { }
            
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

        private void VoidGetQuannhan(Quannhan obj)
        {
            if (obj != null)
            {

                //Hien thi thong tin co ban
                txtHoTen_KhaiSinh.Text = obj.HotenKhaisinh;
                txtHoTen_ThuongDung.Text = obj.HotenThuongdung;
                txtMaHocVien.Text = obj.MaQuannhan;
                txtNgaySinh.Text = obj.Ngaysinh.ToString();
                txtSoTheQN.Text = obj.SotheQuannhan.ToString();
                txtCMTQN.Text = obj.CmtQuannhan.ToString();
                txtTrinhDoVanHoa.Text = obj.TrinhdoVanhoa;
                cboDanToc.SelectedValue = obj.IdDantoc;
                cboGioiTinh.SelectedValue = obj.IdGioitinh;
                cboTonGiao.SelectedValue = obj.IdTongiao;

                //Hien thi thong tin quan
                txtNgayNhapNgu.Text = obj.NgayNhapngu.ToShortDateString();
                txtNgayTaiNgu.Text = obj.NgayTaingu.ToString();
                txtNgayXuatNgu.Text = obj.NgayXuatngu.ToString();
                txtNgayChuyenQNCN.Text = obj.NgaychuyenQncn.ToString();
                cboCapBac.SelectedValue = obj.IdCapbac;
                cboChucVu.SelectedValue = obj.IdChucvu;
                cboDaiDoi.SelectedValue = obj.IdDonvi;
                cboLop.SelectedValue = obj.IdLop;

                //Hien thi thong tin gia dinh
                txtHoTenCha.Text = obj.HotenCha;
                txtHoTenMe.Text = obj.HotenMe;
                txtHoTenVo_Chong.Text = obj.SafeNameHotenVoChong;
                txtSoCon.Text = obj.Socon.ToString();
                txtSoAnhChiEm.Text = obj.SoAnhchiem.ToString();
                txtTP_GiaDinh.Text = obj.TpGiadinh;

                //Hien thi thong tin khac
                txtTP_BanThan.Text = obj.TpBanthan;
                txtSinhQuan.Text = obj.Sinhquan;
                txtNguyenQuan.Text = obj.Nguyenquan;
                txtSucKhoe.Text = obj.Suckhoe;
                txtTruQuan.Text = obj.Truquan;
                txtNgayVaoDang.Text = obj.NgayVaodang.ToString();
                txtNgayVaoDangCT.Text = obj.NgayvaodangChinhthuc.ToString();
                txtNgayVaoDoan.Text = obj.NgayVaodoan.ToString();
                txtGhiChu.Text = obj.Ghichu;
                txtHangThuongTat.Text = obj.HangThuongtat;
                txtDiaChi_BaoTin.Text = obj.DcBaotin;
                txtBacKyThuat.Text = obj.Backythuat;
                txtCNQS.Text = obj.Cnqs;

                //Hien thi anh
                picAnh.Image = null;
                byte[] _byte = obj.AnhQuannhan;
                if (_byte != null)
                {
                    picAnh.Image = ConvertByteToImage(_byte);
                }
                //Cho phep sua thong tin
                btnSua.Enabled = true;
            }
        }

        private void VoidSetQuannhan()
        {
            //Lay thong tin co ban
            if (_Quannhan == null)
            {
                _Quannhan = new Quannhan();
            }
            _Quannhan.HotenKhaisinh = txtHoTen_KhaiSinh.Text.Trim();
            _Quannhan.HotenThuongdung = txtHoTen_ThuongDung.Text.Trim();
            _Quannhan.SotheQuannhan = Convert.ToInt32(txtSoTheQN.Text.Trim());
            _Quannhan.CmtQuannhan = Convert.ToInt32(txtCMTQN.Text.Trim());
            _Quannhan.Ngaysinh = Convert.ToDateTime(txtNgaySinh.Text.Trim());
            _Quannhan.MaQuannhan = txtMaHocVien.Text.Trim();
            _Quannhan.TrinhdoVanhoa = txtTrinhDoVanHoa.Text.Trim();
            _Quannhan.IdDantoc = Convert.ToInt32(cboDanToc.SelectedValue);
            _Quannhan.IdGioitinh = Convert.ToInt32(cboGioiTinh.SelectedValue);
            _Quannhan.IdTongiao = Convert.ToInt32(cboTonGiao.SelectedValue);

            //Lay thong tin quan
            if (txtNgayTaiNgu.Text != "")
            {
                _Quannhan.NgayTaingu = Convert.ToDateTime(txtNgayTaiNgu.Text.Trim());
            }
            if (txtNgayXuatNgu.Text != "")
            {
                _Quannhan.NgayXuatngu = Convert.ToDateTime(txtNgayXuatNgu.Text.Trim());
            }
            if (txtNgayChuyenQNCN.Text != "")
            {
                _Quannhan.NgaychuyenQncn = Convert.ToDateTime(txtNgayChuyenQNCN.Text.Trim());
            }
            _Quannhan.NgayNhapngu = Convert.ToDateTime(txtNgayNhapNgu.Text.Trim());
            _Quannhan.IdCapbac = Convert.ToInt32(cboCapBac.SelectedValue);
            _Quannhan.IdChucvu = Convert.ToInt32(cboChucVu.SelectedValue);
            _Quannhan.IdDonvi = Convert.ToInt32(cboDaiDoi.SelectedValue);
            _Quannhan.IdLop = Convert.ToInt32(cboLop.SelectedValue);
            _Quannhan.IdLoaiquannhan = Convert.ToInt32(cboLoaiQN.SelectedValue);

            //Lay thong tin gia dinh
            _Quannhan.Socon = Convert.ToInt32(txtSoCon.Text.Trim());
            _Quannhan.SoAnhchiem = Convert.ToInt32(txtSoAnhChiEm.Text.Trim());
            if (txtHoTenCha.Text != "")
            {
                _Quannhan.HotenCha = txtHoTenCha.Text.Trim();
            }
            if (txtHoTenMe.Text != "")
            {
                _Quannhan.HotenMe = txtHoTenMe.Text.Trim();
            }
            if (txtHoTenVo_Chong.Text != "")
            {
                _Quannhan.SafeNameHotenVoChong = txtHoTenVo_Chong.Text.Trim();
            }
            if (txtTP_GiaDinh.Text != "")
            {
                _Quannhan.TpGiadinh = txtTP_GiaDinh.Text.Trim();
            }

            
            //Lay ra thong tin khac
            _Quannhan.Sinhquan = txtSinhQuan.Text.Trim();
            _Quannhan.Nguyenquan = txtNguyenQuan.Text.Trim();
            if (txtTP_BanThan.Text != "")
            {
                _Quannhan.TpBanthan = txtTP_BanThan.Text.Trim();
            }
            if (txtSucKhoe.Text != "")
            {
                _Quannhan.Suckhoe = txtSucKhoe.Text.Trim();
            }
            if (txtTruQuan.Text != "")
            {
                _Quannhan.Truquan = txtTruQuan.Text.Trim();
            }
            if (txtNgayVaoDang.Text != "")
            {
                _Quannhan.NgayVaodang = Convert.ToDateTime(txtNgayVaoDang.Text.Trim());
            }
            if (txtNgayVaoDangCT.Text != "")
            {
                _Quannhan.NgayvaodangChinhthuc = Convert.ToDateTime(txtNgayVaoDangCT.Text.Trim());
            }
            if (txtNgayVaoDoan.Text != "")
            {
                _Quannhan.NgayVaodoan = Convert.ToDateTime(txtNgayVaoDoan.Text.Trim());
            }
            if (txtGhiChu.Text != "")
            {
                _Quannhan.Ghichu = txtGhiChu.Text.Trim();
            }
            if (txtHangThuongTat.Text != "")
            {
                _Quannhan.HangThuongtat = txtHangThuongTat.Text.Trim();
            }
            if (txtDiaChi_BaoTin.Text != "")
            {
                _Quannhan.DcBaotin = txtDiaChi_BaoTin.Text.Trim();
            }
            if (txtBacKyThuat.Text != "")
            {
                _Quannhan.Backythuat = txtBacKyThuat.Text.Trim();
            }
            if (txtCNQS.Text != "")
            {
                _Quannhan.Cnqs = txtCNQS.Text.Trim();
            }

            if (picAnh.Image != null)
            {
                _Quannhan.AnhQuannhan = ConvertImageToBinary(picAnh.Image);
            }

        }

        private void VoidBankControls()
        {
            foreach (Control c in gbThongTinCoBan.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
            foreach (Control c in gbThongTinGiaDinh.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
            foreach (Control c in gbThongTinQuan.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
            foreach (Control c in gbThongTinKhac.Controls)
            {
                if (c is TextBox)
                    c.Text = "";
            }
 
        }

        private void EnabelAndDisableControls(bool status)
        {
            foreach (Control c in gbThongTinCoBan.Controls)
            {
                if (c is TextBox || c is ComboBox)
                    c.Enabled = status;
            }
            foreach (Control c in gbThongTinGiaDinh.Controls)
            {
                if (c is TextBox || c is ComboBox)
                    c.Enabled = status;
            }
            foreach (Control c in gbThongTinQuan.Controls)
            {
                if (c is TextBox || c is ComboBox)
                    c.Enabled = status;
            }
            foreach (Control c in gbThongTinKhac.Controls)
            {
                if (c is TextBox || c is ComboBox)
                    c.Enabled = status;
            }
            btnChonAnh.Enabled = status;
            contextMenuStrip1.Enabled = status;

        }

        #endregion

        #region Private Event
        private void frmNhapthongtin_Load(object sender, EventArgs e)
        {
            LoadToComboBoxDaiDoi(cboTimKiem_DaiDoi);
            LoadTodgvQuanSoDaiDoi();

            LoadToComboBoxCapBac(cboCapBac);
            LoadToComboBoxChucVu(cboChucVu);
            LoadToComboBoxDantoc(cboDanToc);
            LoadToComboxTonGiao(cboTonGiao);
            LoadToComboBoxGioiTinh(cboGioiTinh);
            LoadToComboBoxLoaiQuanNhan(cboLoaiQN);
            LoadToComboBoxDaiDoi(cboDaiDoi);
            try
            {
                _Quannhan = QUANLYQN.Forms.Phan_he.Theo_doi_thong_tin.frmTheoDoiThongTin._Quannhan;
                intID_Daidoi = _Quannhan.IdDonvi;
                intID_Lop = _Quannhan.IdLop;
                cboTimKiem_DaiDoi.SelectedValue = intID_Daidoi;
                cboTimKiem_Lop.SelectedValue = intID_Lop;
                intNewOrUpdate = QUANLYQN.Forms.Phan_he.Theo_doi_thong_tin.frmTheoDoiThongTin.intNeworUpdate;
                LoadTodgvDanhSach(intID_Daidoi, intID_Lop);
                if (intNewOrUpdate == 1)
                    VoidBankControls();
                else if (intNewOrUpdate == 2)
                    VoidGetQuannhan(_Quannhan);

                EnabelAndDisableControls(true);
                btnLuu.Enabled = true;
                btnSua.Enabled = true;
            }
            catch
            {
 
            }
        }

        private void cboTimKiem_DaiDoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            intID_Daidoi = Convert.ToInt32(cboTimKiem_DaiDoi.SelectedValue);
            LoadToComboBoxLop(cboTimKiem_Lop, intID_Daidoi);
        }

        private void cboTimKiem_Lop_SelectedIndexChanged(object sender, EventArgs e)
        {
            intID_Lop = Convert.ToInt32(cboTimKiem_Lop.SelectedValue);
            LoadTodgvDanhSach(intID_Daidoi, intID_Lop);
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
                if (txtTimKiem_CMTQN.Text != "")
                {
                    try
                    {
                        SearchBySO_CMTQN(Convert.ToInt32(txtTimKiem_CMTQN.Text));
                        txtTimKiem_CMTQN.Text = "";
                    }
                    catch (Exception ex)
                    {
                        throw (ex);
                    }
                }
            }

        }

        private void cboDaiDoi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = Convert.ToInt32(cboDaiDoi.SelectedValue);
            LoadToComboBoxLop(cboLop, index);
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            intNewOrUpdate = 1;
            VoidBankControls();
            btnLuu.Enabled = true;
            EnabelAndDisableControls(true);
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            intNewOrUpdate = 2;
            btnLuu.Enabled = true;
            EnabelAndDisableControls(true);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult _DialogResult = MessageBox.Show("Bạn chắc chắn muốn xóa quân nhân này khỏi danh sách?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2);
            if (_DialogResult == DialogResult.Yes)
            {
                try
                {
                    DataRepository.QuannhanProvider.Delete(_Quannhan);
                    LoadTodgvDanhSach(intID_Daidoi, intID_Lop);
                }
                catch { }
            }
        }
        
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtHoTen_KhaiSinh.Text == "")
            {
                txtHoTen_KhaiSinh.Focus();
                MessageBox.Show("Chưa nhập Họ tên khai sinh!", "Thông báo");
                return;
            }
            if (txtHoTen_ThuongDung.Text == "")
            {
                txtHoTen_ThuongDung.Focus();
                MessageBox.Show("Chưa nhập Họ tên thường dùng!", "Thông báo");
                return;
            }
            if (txtMaHocVien.Text == "")
            {
                txtMaHocVien.Focus();
                MessageBox.Show("Chưa nhập mã học viên!", "Thông báo");
                return;
            }
            if (txtCMTQN.Text == "")
            {
                txtCMTQN.Focus();
                MessageBox.Show("Chưa nhập số CMT Quân nhân!", "Thông báo");
                return;
            }
            if (txtSoTheQN.Text == "")
            {
                txtSoTheQN.Focus();
                MessageBox.Show("Chưa nhập số thẻ Quân nhân!", "Thông báo");
                return;
            }
            if (txtTrinhDoVanHoa.Text == "")
            {
                txtTrinhDoVanHoa.Focus();
                MessageBox.Show("Chưa nhập trình độ văn hóa!", "Thông báo");
                return;
            }
            if (txtNgaySinh.Text == "")
            {
                txtNgaySinh.Focus();
                MessageBox.Show("Chưa nhập ngày sinh!", "Thông báo");
                return;
            }
            if (txtNgayNhapNgu.Text == "")
            {
                txtNgayNhapNgu.Focus();
                MessageBox.Show("Chưa nhập ngày nhập ngũ!", "Thông báo");
                return;
            }
            if (txtSoAnhChiEm.Text == "")
            {
                txtSoAnhChiEm.Focus();
                MessageBox.Show("Chưa nhập số anh chị em!", "Thông báo");
                return;
            }
            if (txtSoCon.Text == "")
            {
                txtSoCon.Focus();
                MessageBox.Show("Chưa nhập số con!", "Thông báo");
                return;
            }
            if (txtSinhQuan.Text == "")
            {
                txtSinhQuan.Focus();
                MessageBox.Show("Chưa nhập sinh quán!", "Thông báo");
                return;
            }
            if (txtNguyenQuan.Text == "")
            {
                txtNguyenQuan.Focus();
                MessageBox.Show("Chưa nhập nguyên quán!", "Thông báo");
                return;
            }

            try
            {
                VoidSetQuannhan();
                if (intNewOrUpdate ==1)
                {
                    DataRepository.QuannhanProvider.Insert(_Quannhan);

                }
                if(intNewOrUpdate == 2)
                {
                    DataRepository.QuannhanProvider.Update(_Quannhan);

                }
                MessageBox.Show("Lưu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Lưu không thành công, hãy thử lại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            EnabelAndDisableControls(false);
            intNewOrUpdate = 0;
            LoadTodgvDanhSach(intID_Daidoi, intID_Lop);
            LoadTodgvQuanSoDaiDoi();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (intNewOrUpdate==1)
                VoidBankControls();
            if (intNewOrUpdate == 2)
                VoidGetQuannhan(_Quannhan);
            EnabelAndDisableControls(false);
        }

        private void dgvDanhSachHV_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            for (int i = 0; i < dgvDanhSachHV.RowCount - 1; i++)
            {
                dgvDanhSachHV[0, i].Value = i + 1;
            }
        }

        private void dgvDanhSachHV_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int id_quannhan = Convert.ToInt32(dgvDanhSachHV.Rows[e.RowIndex].Cells["ID"].Value);
                _Quannhan = DataRepository.QuannhanProvider.GetByIdQuannhan(id_quannhan);
                VoidGetQuannhan(_Quannhan);
                EnabelAndDisableControls(false);
            }
            catch
            { }
        }

        private void btnChonAnh_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = @"D:\";
            ofd.Filter = "Jpg File (*.jpg)|*.jpg";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                picAnh.Image = Image.FromFile(ofd.FileName);
            }
        }

        private void dgvQuanSoDaiDoi_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            for (int i = 0; i < dgvQuanSoDaiDoi.RowCount - 1; i++)
            {
                dgvQuanSoDaiDoi[0, i].Value = i + 1;
            }
        }

        #endregion

        private void btnTimKiem_Click(object sender, EventArgs e)
        {

        }
   
    }
}
