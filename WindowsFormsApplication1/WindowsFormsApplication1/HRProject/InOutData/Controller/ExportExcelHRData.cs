using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.HRProject.InOutData.Model.TimeWorking;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1.HRProject.InOutData.Controller
{

    public class ExportExcelHRData
    {
        public string PathTemplateForm5Common = Environment.CurrentDirectory + @"\Resources\Form5Common2.xlsx";
        public string PathTemplateFormTDP = Environment.CurrentDirectory + @"\Resources\FormTDP.xlsx";

        public bool ExportListSeasonalEmployee(string pathSave, Dictionary<string, Model.MonthInOut> DicSeasonalEmp)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet; //sheet 2
                                         //Excel.Worksheet xlWorkSheet1; //sheet 1
            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(PathTemplateForm5Common, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //add data sheet1  
                xlWorkSheet.Name = DicSeasonalEmp.Values.ToList()[0].dept;
                for (int i = 0; i < DicSeasonalEmp.Count; i++)
                {
                    var EmpFinger = DicSeasonalEmp.Keys.ToList()[i];
                    xlWorkSheet.Cells[2*i + 7, "A"] = i+1;
                    xlWorkSheet.Cells[2*i + 7, "B"] = DicSeasonalEmp[EmpFinger].EmpCode;
                    xlWorkSheet.Cells[2 * i + 7, "C"] = DicSeasonalEmp[EmpFinger].Name;
                    for (int k = 0; k < 31; k++)
                    {
                        if(DicSeasonalEmp[EmpFinger].InOutEvaluation[k] != null)
                        {
                            if (DicSeasonalEmp[EmpFinger].Shift[k].Contains("Day"))
                            {
                                xlWorkSheet.Cells[2*i + 7, 7+k] = DicSeasonalEmp[EmpFinger].WorkingTime[k];
                            }
                            else if (DicSeasonalEmp[EmpFinger].Shift[k].Contains("Night"))
                            {
                                xlWorkSheet.Cells[2*i + 7+1, 7+k] = DicSeasonalEmp[EmpFinger].WorkingTime[k];
                            }
                        }

                    }
               //     CountPlusRow = CountPlusRow + 2;


                }
                xlWorkBook.SaveAs(pathSave, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                     misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();
                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlApp);
                return true;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, " ExportListSeasonalEmployee(string pathSave, Dictionary<string, Model.MonthInOut> DicSeasonalEmp)", ex.Message);
            }
            return false;
        }
        public bool ExportListSeasonalEmployeeTDP(string pathSave,DateTime from, DateTime to, Dictionary<string, Model.MonthInOut> DicSeasonalEmp)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet; //sheet 2
                                         //Excel.Worksheet xlWorkSheet1; //sheet 1
            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(PathTemplateFormTDP, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //add data sheet1  

                xlWorkSheet.Name = DicSeasonalEmp.Values.ToList()[0].dept;
                for (int i = 0; i < DicSeasonalEmp.Count; i++)
                {
                    var EmpFinger = DicSeasonalEmp.Keys.ToList()[i];
                    xlWorkSheet.Cells[i + 7, "A"] = i+1;
                    xlWorkSheet.Cells[ i + 7, "B"] = DicSeasonalEmp[EmpFinger].EmpCode;
                    xlWorkSheet.Cells[ i + 7, "C"] = DicSeasonalEmp[EmpFinger].Name;
                    for (int k = 0; k < 31; k++)
                    {
                      
                        var lastDayOfMonth = DateTime.DaysInMonth(from.Year, from.Month);
                        if (k < lastDayOfMonth)
                        {
                            DateTime dateTime = new DateTime(from.Year, from.Month, k + 1);
                            if (i == 0)
                        { 
                                xlWorkSheet.Cells[4, 11 + 3 * k] = dateTime;
                                if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                                {
                                    xlWorkSheet.Cells[5, 11 + 3 * k] = 1;
                                    xlWorkSheet.Cells[5, 11 + 3 * k + 1] = 2;
                                    xlWorkSheet.Cells[5, 11 + 3 * k + 2] = 0.3;
                                }
                                else
                                {
                                    xlWorkSheet.Cells[5, 11 + 3 * k] = 1;
                                    xlWorkSheet.Cells[5, 11 + 3 * k + 1] = 1.5;
                                    xlWorkSheet.Cells[5, 11 + 3 * k + 2] = 0.3;
                                }
                            }

                            if (DicSeasonalEmp[EmpFinger].InOutEvaluation[k] != null)
                            {
                                if (DicSeasonalEmp[EmpFinger].Shift[k].Contains("Day"))
                                {
                                    if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                                    {
                                        if (DicSeasonalEmp[EmpFinger].WorkingTime[k] <= 8)
                                            xlWorkSheet.Cells[7 + i, 11 + 3 * k+1] = DicSeasonalEmp[EmpFinger].WorkingTime[k];
                                        else
                                        {
                                            xlWorkSheet.Cells[7 + i, 11 + 3 * k+1] = DicSeasonalEmp[EmpFinger].WorkingTime[k];
                                          //  xlWorkSheet.Cells[7 + i, 11 + 3 * k + 1] = DicSeasonalEmp[EmpFinger].WorkingTime[k] - 8;
                                        }
                                    }
                                    else
                                    {
                                        if (DicSeasonalEmp[EmpFinger].WorkingTime[k] <= 8)
                                            xlWorkSheet.Cells[7 + i, 11 + 3 * k] = DicSeasonalEmp[EmpFinger].WorkingTime[k];
                                        else
                                        {
                                            xlWorkSheet.Cells[7 + i, 11 + 3 * k] = 8;
                                            xlWorkSheet.Cells[7 + i, 11 + 3 * k + 1] = DicSeasonalEmp[EmpFinger].WorkingTime[k] - 8;
                                        }
                                    }
                                }
                                else if (DicSeasonalEmp[EmpFinger].Shift[k].Contains("Night"))
                                {
                                    if (dateTime.DayOfWeek == DayOfWeek.Sunday)
                                    {
                                        if (DicSeasonalEmp[EmpFinger].WorkingTime[k] <= 8)
                                        {
                                            xlWorkSheet.Cells[i + 7, 11 + 3 * k+1] = DicSeasonalEmp[EmpFinger].WorkingTime[k];
                                            //xlWorkSheet.Cells[i + 7, 11 + 3 * k + 2] = DicSeasonalEmp[EmpFinger].WorkingTime[k];
                                        }
                                        else
                                        {
                                            xlWorkSheet.Cells[7 + i, 11 + 3 * k + 1] = DicSeasonalEmp[EmpFinger].WorkingTime[k];
                                            //xlWorkSheet.Cells[i + 7, 11 + 3 * k + 2] = 8;
                                            //xlWorkSheet.Cells[7 + i, 11 + 3 * k + 1] = DicSeasonalEmp[EmpFinger].WorkingTime[k] - 8;
                                        }
                                    }
                                    else
                                    {
                                        if (DicSeasonalEmp[EmpFinger].WorkingTime[k] <= 8)
                                        {
                                            xlWorkSheet.Cells[i + 7, 11 + 3 * k] = DicSeasonalEmp[EmpFinger].WorkingTime[k];
                                            xlWorkSheet.Cells[i + 7, 11 + 3 * k + 2] = DicSeasonalEmp[EmpFinger].WorkingTime[k];
                                        }
                                        else
                                        {
                                            xlWorkSheet.Cells[7 + i, 11 + 3 * k] = 8;
                                            xlWorkSheet.Cells[i + 7, 11 + 3 * k + 2] = 8;
                                            xlWorkSheet.Cells[7 + i, 11 + 3 * k + 1] = DicSeasonalEmp[EmpFinger].WorkingTime[k] - 8;
                                        }
                                    }

                                }
                            }
                        }

                    }
                    //     CountPlusRow = CountPlusRow + 2;


                }
                xlWorkBook.SaveAs(pathSave, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                     misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();
                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlApp);
                return true;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, " ExportListSeasonalEmployee(string pathSave, Dictionary<string, Model.MonthInOut> DicSeasonalEmp)", ex.Message);
            }
            return false;
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
