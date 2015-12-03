using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLBMT_TTNhom.DAO;
using System.Windows.Forms;

namespace QLBMT_TTNhom.BUS
{
    class In_Bus
    {
        In_Xuat xuat = new In_Xuat();
        public void ExportDataGridViewTo_Excel(DataGridView datagrid)
        {
            xuat.InDataGridView(datagrid);
        }
    }
}
