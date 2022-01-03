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
using UploadDataToDatabase.AttendancReport.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace UploadDataToDatabase.AttendancReport.Controller
{
    public class HRReport
    {
        public string PathAttendanceDaily = Environment.CurrentDirectory + @"\Resources\AttendanceDaily.xlsx";
        public string PathAbsenceDaily = Environment.CurrentDirectory + @"\Resources\AbsenceForm_v1.xlsx";
        public bool ExportAttendanceDaily(List<AttendanceDept> attendanceDepts, string pathSave, DateTime date)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(PathAttendanceDaily, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                string strWorksheetName = xlWorkSheet.Name;//Get the name of worksheet.   
                int startGroup = 0;
                string CurrentDep = attendanceDepts[0].BigDeptCode;
                int countGroup = 0;
                xlWorkSheet.Cells[2, "N"] = "Date: " + date.ToString("dd.MM.yyyy");
                for (int i = 0; i < attendanceDepts.Count; i++)
                {
                    if (CurrentDep != attendanceDepts[i].BigDeptCode && countGroup == 0)
                    {
                        range = xlWorkSheet.Range[xlWorkSheet.Cells[5 + i + countGroup - startGroup, "A"], xlWorkSheet.Cells[5 + i + countGroup, "A"]];

                        range.Merge();
                        xlWorkSheet.Cells[5 + i + countGroup - startGroup, "A"] = attendanceDepts[i - 1].BigDeptName;

                        xlWorkSheet.Cells[5 + i + countGroup, "B"] = "总合计:in total:";
                        double Total = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.LocalWorker.TotalWorker).Sum();
                        double Indirect = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.LocalWorker.WorkerIndirect).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup, "K"] = Total;
                        xlWorkSheet.Cells[5 + i + countGroup, "L"] = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.LocalWorker.WorkerDirect).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup, "M"] = Indirect;
                        xlWorkSheet.Cells[5 + i + countGroup, "N"] = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.DayShift.absence).Sum() + attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.NightShift.absence).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup, "O"] = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.DayShift.attendanceActual).Sum() + attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.NightShift.attendanceActual).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup + 1, "J"] = ((double)(Indirect / Total)).ToString("P1");
                        range = xlWorkSheet.Range[xlWorkSheet.Cells[5 + i + countGroup + 1, "A"], xlWorkSheet.Cells[5 + i + countGroup + 1, "I"]];
                        range.Merge();
                        xlWorkSheet.Cells[5 + i + countGroup + 1, "A"] = "(INDIRECT/Total )*100%";
                        startGroup = 0;
                        countGroup = countGroup + 2;


                    }
                    else if (CurrentDep != attendanceDepts[i].BigDeptCode && countGroup > 0)
                    {
                        range = xlWorkSheet.Range[xlWorkSheet.Cells[5 + i + countGroup - 1 - startGroup, "A"], xlWorkSheet.Cells[5 + i + countGroup, "A"]];

                        range.Merge();
                        xlWorkSheet.Cells[5 + i + countGroup - 1 - startGroup, "A"] = attendanceDepts[i - 1].BigDeptName;

                        xlWorkSheet.Cells[5 + i + countGroup, "B"] = "总合计:in total:";
                        double Total = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.LocalWorker.TotalWorker).Sum();
                        double Indirect = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.LocalWorker.WorkerIndirect).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup, "K"] = Total;
                        xlWorkSheet.Cells[5 + i + countGroup, "L"] = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.LocalWorker.WorkerDirect).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup, "M"] = Indirect;
                        xlWorkSheet.Cells[5 + i + countGroup, "N"] = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.DayShift.absence).Sum() + attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.NightShift.absence).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup, "O"] = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.DayShift.attendanceActual).Sum() + attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.NightShift.attendanceActual).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup + 1, "J"] = ((double)(Indirect / Total)).ToString("P1");
                        range = xlWorkSheet.Range[xlWorkSheet.Cells[5 + i + countGroup + 1, "A"], xlWorkSheet.Cells[5 + i + countGroup + 1, "I"]];

                        range.Merge();
                        xlWorkSheet.Cells[5 + i + countGroup + 1, "A"] = "(INDIRECT/Total )*100%";

                        startGroup = 0;
                        countGroup = countGroup + 2;


                    }
                    else if (i == attendanceDepts.Count - 1)
                    {
                        range = xlWorkSheet.Range[xlWorkSheet.Cells[5 + i + countGroup - 1 - startGroup, "A"], xlWorkSheet.Cells[5 + i + countGroup + 1, "A"]];

                        range.Merge();
                        xlWorkSheet.Cells[5 + i + countGroup - 1 - startGroup, "A"] = attendanceDepts[i].BigDeptName;

                        xlWorkSheet.Cells[5 + i + countGroup + 1, "B"] = "总合计:in total:";
                        double Total = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.LocalWorker.TotalWorker).Sum();
                        double Indirect = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.LocalWorker.WorkerIndirect).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup + 1, "K"] = Total;
                        xlWorkSheet.Cells[5 + i + countGroup + 1, "L"] = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.LocalWorker.WorkerDirect).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup + 1, "M"] = Indirect;
                        xlWorkSheet.Cells[5 + i + countGroup + 1, "N"] = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.DayShift.absence).Sum() + attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.NightShift.absence).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup + 1, "O"] = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.DayShift.attendanceActual).Sum() + attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.NightShift.attendanceActual).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup + 2, "J"] = ((double)(Indirect / Total)).ToString("P1");
                        range = xlWorkSheet.Range[xlWorkSheet.Cells[5 + i + countGroup + 2, "A"], xlWorkSheet.Cells[5 + i + countGroup + 2, "I"]];

                        range.Merge();
                        xlWorkSheet.Cells[5 + i + countGroup + 2, "A"] = "(INDIRECT/Total )*100%";

                    }
                    else
                    {

                        //      xlWorkSheet.Cells[5 + i - startGroup, "A"] = attendanceDepts[i].BigDeptName;
                        startGroup++;

                    }

                    xlWorkSheet.Cells[5 + i + countGroup, "B"] = attendanceDepts[i].DetailDeptName;
                    xlWorkSheet.Cells[5 + i + countGroup, "D"] = attendanceDepts[i].HeadDept;
                    xlWorkSheet.Cells[5 + i + countGroup, "F"] = attendanceDepts[i].DayShift.attendanceActual;
                    xlWorkSheet.Cells[5 + i + countGroup, "G"] = attendanceDepts[i].DayShift.absence;
                    xlWorkSheet.Cells[5 + i + countGroup, "H"] = attendanceDepts[i].NightShift.attendanceActual;
                    xlWorkSheet.Cells[5 + i + countGroup, "I"] = attendanceDepts[i].NightShift.absence;
                    xlWorkSheet.Cells[5 + i + countGroup, "L"] = attendanceDepts[i].LocalWorker.WorkerDirect;
                    xlWorkSheet.Cells[5 + i + countGroup, "M"] = attendanceDepts[i].LocalWorker.WorkerIndirect;
                    xlWorkSheet.Cells[5 + i + countGroup, "K"] = attendanceDepts[i].LocalWorker.TotalWorker;
                    //   xlWorkSheet.Cells[5 + i + countGroup, "P"] =  attendanceDepts[i].SeannWorkerDayNotID+ attendanceDepts[i].SeannWorkerNightNotID;
                    double SeasonDay = attendanceDepts.Select(d => d.SeasonWorkerDay.attendanceActual).Sum() + attendanceDepts[0].SeannWorkerDayNotID;
                    double SeasonNight = attendanceDepts.Select(d => d.SeasonWorkerNight.attendanceActual).Sum() + attendanceDepts[0].SeannWorkerNightNotID;
                    xlWorkSheet.Cells[92, "P"] = SeasonDay + SeasonNight;
                    //xlWorkSheet.Cells[91, "Q"] = SeasonDay;
                    //xlWorkSheet.Cells[91, "R"] =  SeasonNight;
                    CurrentDep = attendanceDepts[i].BigDeptCode;

                }

                xlWorkBook.SaveAs(pathSave, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                      misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();

                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkBook);
                reOject(xlApp);
                return true;
                     
            }
            catch (Exception ex)
            {

                return false;
            }

        }

        public void ExportAbsenceDaily(List<EmployeeAbsence> employeeAbsences, string pathSave,  DateTime date)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(PathAbsenceDaily, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                string strWorksheetName = xlWorkSheet.Name;//Get the name of worksheet.   
                int startGroup = 0;
                //   string CurrentDep = attendanceDepts[0].BigDeptCode;
                int countGroup = 0;
                xlWorkSheet.Cells[4, "A"] = "ABSENCE DAILY REPORT ON " + date.ToString("dd-MM-yyyy");
                for (int i = 0; i < employeeAbsences.Count; i++)
                {
                    xlWorkSheet.Cells[7 + i, "A"] = (i + 1).ToString();
                    xlWorkSheet.Cells[7 + i, "B"] = employeeAbsences[i].Dept;
                    xlWorkSheet.Cells[7 + i, "C"] = employeeAbsences[i].DeptCode;
                    xlWorkSheet.Cells[7 + i, "D"] = employeeAbsences[i].Manager;
                    xlWorkSheet.Cells[7 + i, "E"] = employeeAbsences[i].Date;
                    xlWorkSheet.Cells[7 + i, "F"] = employeeAbsences[i].Shift;
                    xlWorkSheet.Cells[7 + i, "G"] = employeeAbsences[i].EmpCode;
                    xlWorkSheet.Cells[7 + i, "H"] = employeeAbsences[i].EmpName;


                }

                xlWorkBook.SaveAs(pathSave, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                      misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();

                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkBook);
                reOject(xlApp);
            }
            catch (Exception ex)
            {

                throw;
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
                MessageBox.Show("Export to excel fail: " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
