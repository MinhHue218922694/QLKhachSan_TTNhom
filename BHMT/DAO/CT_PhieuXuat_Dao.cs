using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLBMT_TTNhom.DAO
{
    public class CT_PhieuXuat_Dao
    {
        DataConnect dc = new DataConnect();
        public DataTable GetAllCTPhieuXuat()
        {
            return dc.ExecuteQuery("select * from tblCTPhieuXuat");
        }
        //thêm, sửa xóa
        public void themct_xuat(string maphieux,string mahang,int soluong,float dongia,float thanhtien)
        {
            SqlParameter[] mang = new SqlParameter[5];
            mang[0] = new SqlParameter("@MaPX", maphieux);
            mang[1] = new SqlParameter("@MaHang", mahang);
            mang[2] = new SqlParameter("@Soluong", soluong);
            mang[3] = new SqlParameter("@DonGian", dongia);
            mang[4] = new SqlParameter("@ThanhTien", thanhtien);
            dc.ExecuteNonQuery("ThemCT_PX", mang);
        }
        public void suact_xuat(string maphieux, string mahang, int soluong, float dongia, float thanhtien)
        {
            SqlParameter[] mang = new SqlParameter[5];
            mang[0] = new SqlParameter("@MaPX", maphieux);
            mang[1] = new SqlParameter("@MaHang", mahang);
            mang[2] = new SqlParameter("@Soluong", soluong);
            mang[3] = new SqlParameter("@DonGian", dongia);
            mang[4] = new SqlParameter("@ThanhTien", thanhtien);
            dc.ExecuteNonQuery("SuaCT_PX", mang);
        }
        public void xoact_xuat(string maphieux, string mahang)
        {
            SqlParameter[] mang = new SqlParameter[2];
            mang[0] = new SqlParameter("@MaPX", maphieux);
            mang[1] = new SqlParameter("@MaHang", mahang);
            dc.ExecuteNonQuery("XoaCT_PX", mang);
        }
    }
}
