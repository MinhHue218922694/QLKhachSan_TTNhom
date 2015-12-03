using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace QLBMT_TTNhom.DAO
{
    class In_Xuat
    {
        public void InDataGridView(DataGridView datagrid)
        {
            Excel.Application oExcel = null;
            Excel.Workbook oBook = null;
            Excel.Sheets oSheetsColl = null;
            Excel.Worksheet oSheet = null;
            Excel.Range oRange = null;

            Object oMissing = System.Reflection.Missing.Value;

            oExcel = new Excel.Application();
            oExcel.Visible = true;
            oExcel.UserControl = true;
            oBook = oExcel.Workbooks.Add(oMissing);

            oSheetsColl = oExcel.Worksheets;
            oSheet = (Excel.Worksheet)oSheetsColl.get_Item("Sheet1");
            oSheet.Columns.ColumnWidth = 30;

            for (int j = 0; j < datagrid.Columns.Count; j++)
            {
                oRange = (Excel.Range)oSheet.Cells[1, j + 1];
                oRange.Value2 = datagrid.Columns[j].HeaderText;
            }

            for (int i = 0; i < datagrid.Rows.Count; i++)
            {
                for (int j = 0; j < datagrid.Columns.Count; j++)
                {
                    oRange = (Excel.Range)oSheet.Cells[i + 2, j + 1];
                    oRange.Value2 = datagrid[j, i].Value;
                }
            }

            oBook = null;
            oExcel.Quit();
            oExcel = null;
            GC.Collect();
        }
    }
}
