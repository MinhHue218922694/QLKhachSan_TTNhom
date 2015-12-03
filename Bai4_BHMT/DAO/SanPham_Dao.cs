using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLBMT_TTNhom.DAO
{
    public class SanPham_Dao
    {
        DataConnect dc = new DataConnect();
        public DataTable GetAllSanPham()
        {
            return dc.ExecuteQuery("select *from tblSanPham");
        }
        public DataTable GetMaSP()
        {
            return dc.ExecuteQuery("select MaHang from tblSanPham");
        }
        public void themsp(string mahang, string tenhang, float gianhap, float giaban, int soluong, float vat, string ncc)
        {
            SqlParameter[] mang = new SqlParameter[7];
            mang[0] = new SqlParameter("@MaHang", mahang);
            mang[1] = new SqlParameter("@TenHang", tenhang);
            mang[2] = new SqlParameter("@GiaNhap", gianhap);
            mang[3] = new SqlParameter("@GiaBan", giaban);
            mang[4] = new SqlParameter("@SoLuong", soluong);
            mang[5] = new SqlParameter("@VAT", vat);
            mang[6] = new SqlParameter("@NCC", ncc);
            dc.ExecuteNonQuery("ThemSP", mang);
        }
        public void suasp(string mahang, string tenhang, float gianhap, float giaban, int soluong, float vat, string ncc)
        {
            SqlParameter[] mang = new SqlParameter[7];
            mang[0] = new SqlParameter("@MaHang", mahang);
            mang[1] = new SqlParameter("@TenHang", tenhang);
            mang[2] = new SqlParameter("@GiaNhap", gianhap);
            mang[3] = new SqlParameter("@GiaBan", giaban);
            mang[4] = new SqlParameter("@SoLuong", soluong);
            mang[5] = new SqlParameter("@VAT", vat);
            mang[6] = new SqlParameter("@NCC", ncc);
            dc.ExecuteNonQuery("SuaSP", mang);
        }
        public void xoasp(string mahang)
        {
            SqlParameter[] mang = new SqlParameter[1];
            mang[0] = new SqlParameter("@MaHang", mahang);
            dc.ExecuteNonQuery("XoaSP", mang);
        }
        public DataTable timkiemma(string ma)
        {
            SqlParameter[] mang = new SqlParameter[1];
            mang[0] = new SqlParameter("@MaHang", ma);
            return dc.ExecuteQuery("TimKiemSanPham_MaHang", mang);
        }
        public DataTable timkiemten(string ten)
        {
            SqlParameter[] ma = new SqlParameter[1];
            ma[0] = new SqlParameter("@TenHang",ten);
            return dc.ExecuteQuery("TimKiemSanPham_TenHang", ma);
        }
    }
}
