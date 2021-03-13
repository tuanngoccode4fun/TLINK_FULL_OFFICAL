using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows.Forms;

namespace WindowsFormsApplication1.CustomsDeclarasion.Controller
{
  public  class ReadExcelFile
    {
        public DataTable GetDataFromExcel(string filelink)
        {
            DataTable dt = new DataTable();
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;

                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(filelink, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                string strWorksheetName = xlWorkSheet.Name;//Get the name of worksheet.

                dt.Columns.Add(xlWorkSheet.Cells[1, "A"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[1, "B"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[1, "C"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[1, "D"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[1, "E"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[1, "F"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[1, "G"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[1, "H"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[1, "I"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[1, "J"].Value.ToString());
                DataRow dr = null;
                Excel.Range lastCell = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                for (int i = 2; i <= lastCell.Row; i++)
                {
                    dr = dt.NewRow();
                    if (xlWorkSheet.Cells[i, "A"].Value.ToString() != "")
                    {
                        dr[xlWorkSheet.Cells[1, "A"].Value.ToString()] = (xlWorkSheet.Cells[i, "A"].Value != null) ? xlWorkSheet.Cells[i, "A"].Value : null;
                        dr[xlWorkSheet.Cells[1, "B"].Value.ToString()] = (xlWorkSheet.Cells[i, "B"].Value != null) ? xlWorkSheet.Cells[i, "B"].Value : null;
                        dr[xlWorkSheet.Cells[1, "C"].Value.ToString()] = (xlWorkSheet.Cells[i, "C"].Value != null) ? xlWorkSheet.Cells[i, "C"].Value : null;
                        dr[xlWorkSheet.Cells[1, "D"].Value.ToString()] = (xlWorkSheet.Cells[i, "D"].Value != null) ? xlWorkSheet.Cells[i, "D"].Value : null;
                        dr[xlWorkSheet.Cells[1, "E"].Value.ToString()] = (xlWorkSheet.Cells[i, "E"].Value != null) ? xlWorkSheet.Cells[i, "E"].Value : null;
                        dr[xlWorkSheet.Cells[1, "F"].Value.ToString()] = (xlWorkSheet.Cells[i, "F"].Value != null)? xlWorkSheet.Cells[i, "F"].Value: null;
                        dr[xlWorkSheet.Cells[1, "G"].Value.ToString()] = (xlWorkSheet.Cells[i, "G"].Value != null) ? xlWorkSheet.Cells[i, "G"].Value : null;
                        dr[xlWorkSheet.Cells[1, "H"].Value.ToString()] = (xlWorkSheet.Cells[i, "H"].Value != null) ? xlWorkSheet.Cells[i, "H"].Value : null;
                        dr[xlWorkSheet.Cells[1, "I"].Value.ToString()] = (xlWorkSheet.Cells[i, "I"].Value != null) ? xlWorkSheet.Cells[i, "I"].Value : null;
                        dr[xlWorkSheet.Cells[1, "J"].Value.ToString()] = (xlWorkSheet.Cells[i, "J"].Value != null) ? xlWorkSheet.Cells[i, "J"].Value : null;
                        //   dt.Rows.Add(new DataRow[xlWorkSheet.Cells[i, "A"].Value.ToString(), xlWorkSheet.Cells[i, "B"].Value.ToString(), xlWorkSheet.Cells[i, "C"].Value.ToString(), xlWorkSheet.Cells[i, "D"].Value.ToString()]);
                        dt.Rows.Add(dr);
                    }
                }
                xlWorkBook.Close();

                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkBook);
                reOject(xlApp);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Read file import ", ex.Message);
            }
            return dt;
        }
        public DataTable GetDataFromExcelWarehouseStock(string filelink)
        {
            DataTable dt = new DataTable();
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;

                object misValue = System.Reflection.Missing.Value;
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(filelink, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                string strWorksheetName = xlWorkSheet.Name;//Get the name of worksheet.

                dt.Columns.Add(xlWorkSheet.Cells[4, "A"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[4, "B"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[4, "C"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[4, "D"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[4, "E"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[4, "F"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[4, "G"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[4, "H"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[4, "I"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[4, "J"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[4, "K"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[4, "L"].Value.ToString());
                dt.Columns.Add(xlWorkSheet.Cells[4, "M"].Value.ToString());
                DataRow dr = null;
                Excel.Range lastCell = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                for (int i = 5; i <= lastCell.Row; i++)
                {
                    dr = dt.NewRow();
                    if (xlWorkSheet.Cells[i, "A"].Value.ToString() != "")
                    {
                        dr[xlWorkSheet.Cells[4, "A"].Value.ToString()] = (xlWorkSheet.Cells[i, "A"].Value != null) ? xlWorkSheet.Cells[i, "A"].Value : null;
                        dr[xlWorkSheet.Cells[4, "B"].Value.ToString()] = (xlWorkSheet.Cells[i, "B"].Value != null) ? xlWorkSheet.Cells[i, "B"].Value : null;
                        dr[xlWorkSheet.Cells[4, "C"].Value.ToString()] = (xlWorkSheet.Cells[i, "C"].Value != null) ? xlWorkSheet.Cells[i, "C"].Value : null;
                        dr[xlWorkSheet.Cells[4, "D"].Value.ToString()] = (xlWorkSheet.Cells[i, "D"].Value != null) ? xlWorkSheet.Cells[i, "D"].Value : null;
                        dr[xlWorkSheet.Cells[4, "E"].Value.ToString()] = (xlWorkSheet.Cells[i, "E"].Value != null) ? xlWorkSheet.Cells[i, "E"].Value : null;
                        dr[xlWorkSheet.Cells[4, "F"].Value.ToString()] = (xlWorkSheet.Cells[i, "F"].Value != null) ? xlWorkSheet.Cells[i, "F"].Value : null;
                        dr[xlWorkSheet.Cells[4, "G"].Value.ToString()] = (xlWorkSheet.Cells[i, "G"].Value != null) ? xlWorkSheet.Cells[i, "G"].Value : null;
                        dr[xlWorkSheet.Cells[4, "H"].Value.ToString()] = (xlWorkSheet.Cells[i, "H"].Value != null) ? xlWorkSheet.Cells[i, "H"].Value : null;
                        dr[xlWorkSheet.Cells[4, "I"].Value.ToString()] = (xlWorkSheet.Cells[i, "I"].Value != null) ? xlWorkSheet.Cells[i, "I"].Value : null;
                        dr[xlWorkSheet.Cells[4, "J"].Value.ToString()] = (xlWorkSheet.Cells[i, "J"].Value != null) ? xlWorkSheet.Cells[i, "J"].Value : null;
                        dr[xlWorkSheet.Cells[4, "K"].Value.ToString()] = (xlWorkSheet.Cells[i, "K"].Value != null) ? xlWorkSheet.Cells[i, "K"].Value : null;
                        dr[xlWorkSheet.Cells[4, "L"].Value.ToString()] = (xlWorkSheet.Cells[i, "L"].Value != null) ? xlWorkSheet.Cells[i, "L"].Value : null;
                        dr[xlWorkSheet.Cells[4, "M"].Value.ToString()] = (xlWorkSheet.Cells[i, "M"].Value != null) ? xlWorkSheet.Cells[i, "M"].Value : null;
                        //   dt.Rows.Add(new DataRow[xlWorkSheet.Cells[i, "A"].Value.ToString(), xlWorkSheet.Cells[i, "B"].Value.ToString(), xlWorkSheet.Cells[i, "C"].Value.ToString(), xlWorkSheet.Cells[i, "D"].Value.ToString()]);
                        dt.Rows.Add(dr);
                    }
                }
                xlWorkBook.Close();

                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkBook);
                reOject(xlApp);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Read file import ", ex.Message);
            }
            return dt;
        }
        private void reOject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Export to excel fail: " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
