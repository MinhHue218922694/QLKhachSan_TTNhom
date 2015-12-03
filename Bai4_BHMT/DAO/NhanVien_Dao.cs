using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace QLBMT_TTNhom.DAO
{
    public class NhanVien_Dao
    {
        DataConnect dc = new DataConnect();
        public DataTable GetAllNhanVien()
        {
            return dc.ExecuteQuery("select * from tblNhanVien");
        }
        public DataTable GetMaNV()
        {
            return dc.ExecuteQuery("select MaNV from tblNhanVien");
        }
        public void themnv(string manv, string tennv, DateTime ngaysinh, string bophan, string chucvu, string diachi, string dienthoai)
        {
            SqlParameter[] mang = new SqlParameter[7];
            mang[0] = new SqlParameter("@MaNV", manv);
            mang[1] = new SqlParameter("@TenNV", tennv);
            mang[2] = new SqlParameter("@NgaySinh", ngaysinh);
            mang[3] = new SqlParameter("@BoPhan", bophan);
            mang[4] = new SqlParameter("@ChucVu", chucvu);
            mang[5] = new SqlParameter("@DiaChi", diachi);
            mang[6] = new SqlParameter("@DienThoai", dienthoai);
            dc.ExecuteQuery("ThemNVien", mang);
        }
        public void suanv(string manv, string tennv, DateTime ngaysinh, string bophan, string chucvu, string diachi, string dienthoai)
        {
            SqlParameter[] mang = new SqlParameter[7];
            mang[0] = new SqlParameter("@MaNV", manv);
            mang[1] = new SqlParameter("@TenNV", tennv);
            mang[2] = new SqlParameter("@NgaySinh", ngaysinh);
            mang[3] = new SqlParameter("@BoPhan", bophan);
            mang[4] = new SqlParameter("@ChucVu", chucvu);
            mang[5] = new SqlParameter("@DiaChi", diachi);
            mang[6] = new SqlParameter("@DienThoai", dienthoai);
            dc.ExecuteQuery("SuaNV", mang);
        }
        public void xoanv(string manv)
        {
            SqlParameter[] mang = new SqlParameter[1];
            mang[0] = new SqlParameter("@MaNV", manv);
            dc.ExecuteNonQuery("XoaNV", mang);
        }
        //tìm kiếm thống kê
        public DataTable timkiemten(string ten)
        {
            SqlParameter[] ma = new SqlParameter[1];
            ma[0] = new SqlParameter("@TenNV", ten);
            return dc.ExecuteQuery("TimKiemNV_Ten", ma);
        }
    }
}
