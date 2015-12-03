using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLBMT_TTNhom.DAO
{
    public class KhachHang_Dao
    {
        DataConnect dc = new DataConnect();
        public DataTable getAllKH()
        {
            return dc.ExecuteQuery("select *from tblKhachHang");
        }
        public DataTable getMaKH()
        {
            return dc.ExecuteQuery("select MaKH,TenKH from tblKhachHang");
        }
        public void themkh(string makh,string tenkh,string diachi,string dienthoai,string email)
        {
            SqlParameter[] mang = new SqlParameter[5];
            mang[0] = new SqlParameter("@MaKH", makh);
            mang[1] = new SqlParameter("@TenKH", tenkh);
            mang[2] = new SqlParameter("@DiaChi", diachi);
            mang[3] = new SqlParameter("@DienThoai", dienthoai);
            mang[4] = new SqlParameter("@Email", email);
            dc.ExecuteNonQuery("ThemKH", mang);
        }
        public void suakh(string makh, string tenkh, string diachi, string dienthoai, string email)
        {
            SqlParameter[] mang = new SqlParameter[5];
            mang[0] = new SqlParameter("@MaKH", makh);
            mang[1] = new SqlParameter("@TenKH", tenkh);
            mang[2] = new SqlParameter("@DiaChi", diachi);
            mang[3] = new SqlParameter("@DienThoai", dienthoai);
            mang[4] = new SqlParameter("@Email", email);
            dc.ExecuteNonQuery("SuaKH", mang);
        }
        public void xoakh(string makh)
        {
            SqlParameter[] mang = new SqlParameter[1];
            mang[0] = new SqlParameter("@MaKH", makh);
            dc.ExecuteNonQuery("XoaKH", mang);
        }
        //tìm kiếm theo một số tiêu chí
    }
}
