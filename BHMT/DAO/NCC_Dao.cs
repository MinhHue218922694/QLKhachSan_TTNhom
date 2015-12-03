using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLBMT_TTNhom.DAO
{
    public class NCC_Dao
    {
        DataConnect dc = new DataConnect();
        public DataTable GetAllNCC()
        {
            return dc.ExecuteQuery("select * from tblNCC");
        }
        public DataTable GetMaNCC()
        {
            return dc.ExecuteQuery("select MaNCC from tblNCC");
        }
        public void themncc(string mancc, string tenncc, string sdt, string diachi)
        {
            SqlParameter[] mang = new SqlParameter[4];
            mang[0] = new SqlParameter("@MaNCC", mancc);
            mang[1] = new SqlParameter("@TenNCC", tenncc);
            mang[2] = new SqlParameter("@SDT", sdt);
            mang[3] = new SqlParameter("@DiaChi", diachi);
            dc.ExecuteNonQuery("ThemNCC", mang);
        }
        public void suancc(string mancc, string tenncc, string sdt, string diachi)
        {
            SqlParameter[] mang = new SqlParameter[4];
            mang[0] = new SqlParameter("@MaNCC", mancc);
            mang[1] = new SqlParameter("@TenNCC", tenncc);
            mang[2] = new SqlParameter("@SDT", sdt);
            mang[3] = new SqlParameter("@DiaChi", diachi);
            dc.ExecuteNonQuery("SuaNCC", mang);
        }
        public void xoancc(string mancc)
        {
            SqlParameter[] mang = new SqlParameter[1];
            mang[0] = new SqlParameter("@MaNCC", mancc);
            dc.ExecuteNonQuery("XoaNCC", mang);
        }
    }
}
