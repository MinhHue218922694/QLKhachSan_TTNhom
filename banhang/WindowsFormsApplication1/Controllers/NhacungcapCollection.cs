using QLBanHang.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLBanHang.Controllers
{
    class NhacungcapCollection
    {
        List<Nhacungcap> lst = new List<Nhacungcap>();

        public List<Nhacungcap> Items
        {
            get { return lst; }
            set { lst = value; }
        }
        public Nhacungcap this[int index]
        {
            get
            {
                return lst[index];
            }
        }
        public NhacungcapCollection()
        {
            DataTable dt = DataAccess.ViewForGridView("Nhacungcap_ViewAll");
            foreach (DataRow dr in dt.Rows)
            {
                Nhacungcap ncc = new Nhacungcap();
                ncc.NhacungcapID = int.Parse(dr["NhacungcapID"].ToString());
                ncc.Tennhacungcap = dr["Tennhacungcap"].ToString();
                ncc.Diachi = dr["Diachi"].ToString();
                ncc.Dienthoai =dr["Dienthoai"].ToString();
                lst.Add(ncc);
            }

        }
        
    }
}
