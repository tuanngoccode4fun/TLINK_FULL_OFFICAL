using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace WindowsFormsApplication1.MQC
{
    class MQCExportData
    {
        public void ExportToTemplateMQCDefectDaily(string PathTemplate, string pathSaveExcel, List<string> listHeaderRw25, List<DefectRateData> defectRates, DateTime From, DateTime To)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet; //sheet 2
            //Excel.Worksheet xlWorkSheet1; //sheet 1
            object misValue = System.Reflection.Missing.Value;

            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(PathTemplate, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                #region Sheet 1
                //Add data in Sheet 1

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //add data sheet1  
                                                                                  //xlWorkSheet.Cells[6, 1] = "BackLog Report on " + DateTime.Now.ToString("MMM/dd/yyyy"); //Line
                string strWorksheetName = xlWorkSheet.Name;//Get the name of worksheet.
                xlWorkSheet.Cells[1, "A"] = "MQC Report from [" + From.ToString("dd/MMM/yyyy HH:mm") + "] to [" + To.ToString("dd/MMM/yyyy HH:mm") + "]";

                //Fill ngay thang nam                                                                //xlWorkSheet.Cells[2, 11] = usersend; //Model
                //xlWorkSheet.Cells[1, 11] = dateupdate; //Line
                string date = DateTime.Now.ToString("dd-MM-yyyy");
                for (int j = 0; j < 16; j++)
                {

                    xlWorkSheet.Cells[3, 47 + j] = listHeaderRw25[j];
                    // countDefect += defectRates[i].defectItems[j].Quantity;

                }
                for (int i = 0; i < defectRates.Count; i++)
                {
                    double countDefect = 0;
                    double countRework = 0;
                    xlWorkSheet.Cells[4 + i, "A"] = defectRates[i].Product;//xlWorkSheet.Cells[3, 11] = version; //User  
                                                                           // xlWorkSheet.Cells[4 + i, "B"] = defectRates[i].DateTime_from + "-" + defectRates[i].DateTime_to;//xlWorkSheet.Cells[3, 11] = version; //User  
                                                                           //  xlWorkSheet.Cells[4 + i, "C"] = defectRates[i].Product;//xlWorkSheet.Cells[3, 11] = version; //User  
                                                                           //  xlWorkSheet.Cells[4 + i, "D"] = defectRates[i].Lot;
                    xlWorkSheet.Cells[4 + i, "E"] = defectRates[i].TargetMQC.TargetOutput;
                    // xlWorkSheet.Cells[4 + i, "F"] = defectRates[i].TotalQuantity;
                    xlWorkSheet.Cells[4 + i, "F"] = defectRates[i].OutputQuantity;
                    xlWorkSheet.Cells[4 + i, "AF"] = defectRates[i].DefectQuantity;
                    xlWorkSheet.Cells[4 + i, "BL"] = defectRates[i].ReworkQuantity;
                    //   xlWorkSheet.Cells[2, 31] = DateTime.Now.ToString("MM");
                    for (int j = 0; j < defectRates[i].defectItems.Count; j++)
                    {
                        if (defectRates[i].defectItems[j].Note == (j + 1))
                        {
                            xlWorkSheet.Cells[4 + i, 18 + j] = defectRates[i].defectItems[j].Quantity;
                            countDefect += defectRates[i].defectItems[j].Quantity;
                        }
                    }

                    xlWorkSheet.Cells[4 + i, 31] = defectRates[i].DefectQuantity - countDefect;

                    for (int j = 0; j < defectRates[i].ReworkItems.Count; j++)
                    {
                        for (int k = 0; k < 16; k++)
                        {
                            if (defectRates[i].ReworkItems[j].DefectSFTName == (string)xlWorkSheet.Cells[3, 47 + k].Value2.ToString())
                            {
                                xlWorkSheet.Cells[4 + i, 47 + k] = defectRates[i].ReworkItems[j].Quantity;
                                countRework += defectRates[i].ReworkItems[j].Quantity;
                            }
                        }
                    }

                    xlWorkSheet.Cells[4 + i, 31] = defectRates[i].DefectQuantity - countDefect;
                    xlWorkSheet.Cells[4 + i, 62] = defectRates[i].ReworkQuantity - countRework;
                }
                xlWorkSheet.Name = date;

                #endregion

                xlWorkBook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();
                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkBook);
                reOject(xlApp);



            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportToTemplateMQCDefectDaily : An error happened in the process.", ex.Message);

            }
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
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Export to excel fail: ", ex.Message);

            }
            finally
            {
                GC.Collect();
            }
        }
    }
}

