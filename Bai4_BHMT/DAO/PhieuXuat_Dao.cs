using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using QLBMT_TTNhom.VO;

namespace QLBMT_TTNhom.DAO
{
    public class PhieuXuat_Dao
    {
      
        DataConnect dc = new DataConnect();
        public DataTable GetAllPhieuXuat()
        {
            return dc.ExecuteQuery("select *from tblPhieuXuat");
        }
        public DataTable GetMaPhieuX()
        {
            return dc.ExecuteQuery("select MaPhieu from tblPhieuXuat");
        }
        public void thempx(string maphieu, string makh, string manv, DateTime ngaylap, float chietkhau, float tongtien)
        {
            SqlParameter[] mang = new SqlParameter[6];
            mang[0] = new SqlParameter("@MaPhieu", maphieu);
            mang[1] = new SqlParameter("@MaKH", makh);
            mang[2] = new SqlParameter("@MaNV", manv);
            mang[3] = new SqlParameter("@NgayLap", ngaylap);
            mang[4] = new SqlParameter("@ChietKhau", chietkhau);
            mang[5] = new SqlParameter("@TongTien", tongtien);
            dc.ExecuteNonQuery("ThemPX", mang);
        }
        public void suapx(string maphieu, string makh, string manv, DateTime ngaylap, float chietkhau, float tongtien)
        {
            SqlParameter[] mang = new SqlParameter[6];
            mang[0] = new SqlParameter("@MaPhieu", maphieu);
            mang[1] = new SqlParameter("@MaKH", makh);
            mang[2] = new SqlParameter("@MaNV", manv);
            mang[3] = new SqlParameter("@NgayLap", ngaylap);
            mang[4] = new SqlParameter("@ChietKhau", chietkhau);
            mang[5] = new SqlParameter("@TongTien", tongtien);
            dc.ExecuteNonQuery("SuaPX", mang);
        }
        public void xoapx(string maphieux)
        {
            SqlParameter[] mang = new SqlParameter[1];
            mang[0] = new SqlParameter("@MaPhieu", maphieux);
            dc.ExecuteNonQuery("XoaPX", mang);
        }
        public DataTable thongke_spban(DateTime ngay)
        {
            SqlParameter[] mang = new SqlParameter[1];
            mang[0] = new SqlParameter("@NgayLap", ngay);
            return dc.ExecuteQuery("TongSanPham_TrongNgay", mang);
        }
        public DataTable thongke_tienban(DateTime ngay)
        {
            SqlParameter[] mang = new SqlParameter[1];
            mang[0] = new SqlParameter("@NgayLap", ngay);
            return dc.ExecuteQuery("TongTien_TrongNgay", mang);
        }
    }
}
