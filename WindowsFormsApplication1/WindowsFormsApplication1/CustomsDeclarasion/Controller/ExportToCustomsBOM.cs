using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows;
using System.Drawing;
using Microsoft.Office.Core;
using NumberConverterToText;


namespace WindowsFormsApplication1.CustomsDeclarasion.Controller
{
   public class ExportToCustomsBOM
    {
        public string Template = Environment.CurrentDirectory + @"\Resources\CustomsBOM.xls";
        public bool ExportCustomsBOMToexcel(List<Model.BOMCustomsDeclar> bOMCustoms)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(Template, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                string strWorksheetName = xlWorkSheet.Name;
                xlWorkSheet.Cells[7, "K"] = "Tên hàng hóa: " + bOMCustoms[0].Product;
                xlWorkSheet.Cells[9, "L"] = "Tên hàng hóa: " + bOMCustoms[0].SLSanpham;


            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportCustomsBOMToexcel(List < Model.BOMCustomsDeclar > bOMCustoms))", ex.Message);
            }


            return false;
        }
    }
}
