using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLBMT_TTNhom.DAO
{
    public class PhieuNhap_Dao
    {
        DataConnect dc = new DataConnect();
        public DataTable GetPhieuNhap()
        {
            return dc.ExecuteQuery("select *from tblPhieuNhap");
        }
        public DataTable GetMaPhieuN()
        {
            return dc.ExecuteQuery("select MaPhieuNhap from tblPhieuNhap");
        }
        public void thempn(string maphieun, string manv, string mancc, DateTime ngaynhap, float tongtiennhap)
        {
            SqlParameter[] mang = new SqlParameter[5];
            mang[0] = new SqlParameter("@MaPhieuNhap", maphieun);
            mang[1] = new SqlParameter("@MaNV", manv);
            mang[2] = new SqlParameter("@MaNCC", mancc);
            mang[3] = new SqlParameter("@NgayNhap", ngaynhap);
            mang[4] = new SqlParameter("@TongTienNhap", tongtiennhap);
            dc.ExecuteNonQuery("ThemPN", mang);
        }
        public void suapn(string maphieun, string manv, string mancc, DateTime ngaynhap, float tongtiennhap)
        {
            SqlParameter[] mang = new SqlParameter[5];
            mang[0] = new SqlParameter("@MaPhieuNhap", maphieun);
            mang[1] = new SqlParameter("@MaNV", manv);
            mang[2] = new SqlParameter("@MaNCC", mancc);
            mang[3] = new SqlParameter("@NgayNhap", ngaynhap);
            mang[4] = new SqlParameter("@TongTienNhap", tongtiennhap);
            dc.ExecuteNonQuery("SuaPN", mang);
        }
        public void xoapn(string maphieunhap,string manv,string mancc)
        {
            SqlParameter[] mang = new SqlParameter[3];
            mang[0] = new SqlParameter("@MaPhieuNhap", maphieunhap);
            mang[1] = new SqlParameter("@MaNV", manv);
            mang[2] = new SqlParameter("@MaNCC", mancc);
            dc.ExecuteNonQuery("XoaPN", mang);
        }
        public DataTable thongkenhapsp(DateTime ngay)
        {
            SqlParameter[] mang = new SqlParameter[1];
            mang[0] = new SqlParameter("@NgayNhap", ngay);
            return dc.ExecuteQuery("TongSanPhamNhap_TrongNgay", mang);
        }
        public DataTable thongketiennhap(DateTime ngay)
        {
            SqlParameter[] mang = new SqlParameter[1];
            mang[0] = new SqlParameter("@NgayNhap", ngay);
            return dc.ExecuteQuery("TongTienNhap_TrongNgay", mang);
        }
    }
}
