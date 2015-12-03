using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace QuanLiNhanSu
{
    public class NhanVien
    {
        public DataTable ShowNhanVien()
        {
            string str = @"select MaNV as [Mã Nhân Viên],TenNV as [Tên Nhân Viên],NgaySinh as [Ngày Sinh],
            GioiTinh as [Giới tính],QueQuan as [Quê Quán],Luong as [Lương],MaCV as [Mã Chức Vụ],
            MaPB as [Mã Phòng Ban] from tblNhanVien";
            SqlConnection con = new SqlConnection(ConnectDATA.getconnect());
            SqlDataAdapter ad = new SqlDataAdapter(str, con);
            DataTable dt = new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public DataTable ShowChucVu()
        {
            string str = @"select MaCV as [Mã Chức Vụ] from tblChucVu";
            SqlConnection con = new SqlConnection(ConnectDATA.getconnect());
            SqlDataAdapter ad = new SqlDataAdapter(str, con);
            DataTable dt= new DataTable();
            ad.Fill(dt);
            return dt;
        }
        public DataTable ShowPhongBan()
        {
            string str = @"select MaPB as [Mã Phòng Ban] from tblPhongBan";
            SqlConnection con = new SqlConnection(ConnectDATA.getconnect());
            SqlDataAdapter ad = new SqlDataAdapter(str, con);
            DataTable dt=new DataTable();
            ad.Fill(dt);
            return dt;
        }
    }
}
