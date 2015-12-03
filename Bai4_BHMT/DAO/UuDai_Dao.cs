using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLBMT_TTNhom.DAO
{
    public class UuDai_Dao
    {
        DataConnect dc = new DataConnect();
        public DataTable getAllUuDai()
        {
            return dc.ExecuteQuery("select *from tblUuDai");
        }
        
        public DataTable getMucUd()
        {
            return dc.ExecuteQuery("select MucUD from tblUuDai");
        }
        //thêm
        public void themud(string makh, string mucud, int tongmua)
        {
            SqlParameter[] mang = new SqlParameter[3];
            mang[0] = new SqlParameter("@MaKH", makh);
            mang[1] = new SqlParameter("@MucUD", mucud);
            mang[2] = new SqlParameter("@TongMua", tongmua);
            dc.ExecuteNonQuery("ThemUD", mang);
        }
        public void suaud(string makh, string mucud, int tongmua)
        {
            SqlParameter[] mang = new SqlParameter[3];
            mang[0] = new SqlParameter("@MaKH", makh);
            mang[1] = new SqlParameter("@MucUD", mucud);
            mang[2] = new SqlParameter("@TongMua", tongmua);
            dc.ExecuteNonQuery("SuaUD", mang);
        }
        public void xoaud(string mucud)
        {
            SqlParameter[] mang = new SqlParameter[1];
            mang[0] = new SqlParameter("@MucUD", mucud);
            dc.ExecuteNonQuery("XoaUD", mang);
        }
    }
}
