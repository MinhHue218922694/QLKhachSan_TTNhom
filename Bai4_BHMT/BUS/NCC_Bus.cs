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
    public class NCC_Bus
    {
        NCC_Dao ncc = new NCC_Dao();
        public DataTable getAllNCC()
        {
            return ncc.GetAllNCC();
        }
        public DataTable getMaNCC()
        {
            return ncc.GetMaNCC();
        }
        public void Themncc(string mancc, string tenncc, string sdt, string diachi)
        {
            ncc.themncc(mancc, tenncc, sdt, diachi);
        }
        public void Suancc(string mancc, string tenncc, string sdt, string diachi)
        {
            ncc.suancc(mancc, tenncc, sdt, diachi);
        }
        public void xoancc(string mancc)
        {
            ncc.xoancc(mancc);
        }
    }
}
