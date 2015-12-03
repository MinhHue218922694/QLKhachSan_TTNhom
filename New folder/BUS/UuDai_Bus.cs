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
    public class UuDai_Bus
    {
        UuDai_Dao udai = new UuDai_Dao();
        public DataTable GetAllUuDai()
        {
            return udai.getAllUuDai();
        }
        public DataTable GetMucUd()
        {
            return udai.getMucUd();
        }
        
        //thêm
        public void Themud(string makh, string mucud, int tongmua)
        {
            udai.themud(makh, mucud, tongmua);
        }
        public void Suaud(string makh, string mucud, int tongmua)
        {
            udai.suaud(makh, mucud, tongmua);
        }
        public void xoaud(string mucud)
        {
            udai.xoaud(mucud);
        }
    }
}
