using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBMT_TTNhom.DAO;
using System.Data;
using System.Data.SqlClient;

namespace QLBMT_TTNhom.BUS
{
    public class NhanVien_Bus
    {
        NhanVien_Dao nvien = new NhanVien_Dao();
        public DataTable getAllNhanVien()
        {
            return nvien.GetAllNhanVien();
        }
        public DataTable getMaNV()
        {
            return nvien.GetMaNV();
        }
        public void Themnv(string manv, string tennv, DateTime ngaysinh, string bophan, string chucvu, string diachi, string dienthoai)
        {
            nvien.themnv(manv, tennv, ngaysinh, bophan, chucvu, diachi, dienthoai);
        }
        public void suanv(string manv, string tennv, DateTime ngaysinh, string bophan, string chucvu, string diachi, string dienthoai)
        {
            nvien.suanv(manv, tennv, ngaysinh, bophan, chucvu, diachi, dienthoai);
        }
        public void xoanv(string manv)
        {
            nvien.xoanv(manv);
        }

        //tìm kiếm
        public DataTable TimKiemTen(string ten)
        {
            return nvien.timkiemten(ten);
        }
    }
}
