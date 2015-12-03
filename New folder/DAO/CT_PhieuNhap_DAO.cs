using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLBMT_TTNhom.DAO
{
    public class CT_PhieuNhap_DAO
    {
        DataConnect dc = new DataConnect();
        public DataTable GetAllCT_PhieuNhap()
        {
            return dc.ExecuteQuery("select * from tblCTPhieuNhap");
        }
        public DataTable GetMaPhieuMaHang()
        {
            return dc.ExecuteQuery("select MaPhieuNhap,MaHang from tblCTPhieuNhap");
        }
        public void themct_nhap(string mapn, string mahang, int soluong, float dongia, float thanhtien)
        {
            SqlParameter[] mang = new SqlParameter[5];
            mang[0] = new SqlParameter("@MaPN", mapn);
            mang[1] = new SqlParameter("@MaHang", mahang);
            mang[2] = new SqlParameter("@Soluong", soluong);
            mang[3] = new SqlParameter("@DonGia", dongia);
            mang[4] = new SqlParameter("@ThanhTien", thanhtien);
            dc.ExecuteNonQuery("ThemCT_PN", mang);
        }
        public void suact_nhap(string mapn, string mahang, int soluong, float dongia, float thanhtien)
        {
            SqlParameter[] mang = new SqlParameter[5];
            mang[0] = new SqlParameter("@MaPN", mapn);
            mang[1] = new SqlParameter("@MaHang", mahang);
            mang[2] = new SqlParameter("@Soluong", soluong);
            mang[3] = new SqlParameter("@DonGia", dongia);
            mang[4] = new SqlParameter("@ThanhTien", thanhtien);
            dc.ExecuteNonQuery("SuaCT_PN", mang);
        }
        public void xoact_nhap(string mapn, string mahang)
        {
            SqlParameter[] mang = new SqlParameter[2];
            mang[0] = new SqlParameter("@MaPN", mapn);
            mang[1] = new SqlParameter("@MaHang", mahang);
            dc.ExecuteNonQuery("XoaCT_PN", mang);
        }
    }
}
