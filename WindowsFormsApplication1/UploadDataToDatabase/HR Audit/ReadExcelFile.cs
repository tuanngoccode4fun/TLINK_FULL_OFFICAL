using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Excel = Microsoft.Office.Interop.Excel;       //microsoft Excel 14 object in references-> COM tab

namespace UploadDataToDatabase.HR_Audit
{
    class ReadExcelFile
    {
        public static void getExcelFile(string pathExcel)
        {

            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(pathExcel);
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            int rowCount = xlRange.Rows.Count;
            int colCount = xlRange.Columns.Count;

            //iterate over the rows and columns and print to the console as it appears in the file
            //excel is not zero based!!
            for (int i = 1; i <= rowCount; i++)
            {
                for (int j = 1; j <= colCount; j++)
                {
                    //new line
                    if (j == 1)
                        Console.Write("\r\n");

                    //write the value to the console
                    if (xlRange.Cells[i, j] != null && xlRange.Cells[i, j].Value2 != null)
                        Logfile.Output(StatusLog.Normal,xlRange.Cells[i, j].Value2.ToString() + "\t");
                }
            }

            //cleanup
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //rule of thumb for releasing com objects:
            //  never use two dots, all COM objects must be referenced and released individually
            //  ex: [somthing].[something].[something] is bad

            //release com objects to fully kill excel process from running in the background
            Marshal.ReleaseComObject(xlRange);
            Marshal.ReleaseComObject(xlWorksheet);

            //close and release
            xlWorkbook.Close();
            Marshal.ReleaseComObject(xlWorkbook);

            //quit and release
            xlApp.Quit();
            Marshal.ReleaseComObject(xlApp);
        }
        public List<SpecialList> GetSpecialLists(string pathExcelFile)
        {
            List<SpecialList> specialLists = new List<SpecialList>();
            try
            {

                //Create COM Objects. Create a COM object for everything that is referenced
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(pathExcelFile);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                //iterate over the rows and columns and print to the console as it appears in the file
                //excel is not zero based!!
                for (int i = 4; i <= 100; i++)
                {
                
                        SpecialList special = new SpecialList();
                        special.No = (xlRange.Cells[i, 1].Value != null) ? xlRange.Cells[i, 1].Value.ToString() : "";
                    special.ID = (xlRange.Cells[i, 2].Value != null) ? xlRange.Cells[i, 2].Value.ToString() : "";
                    special.Name = (xlRange.Cells[i, 3].Value != null) ? xlRange.Cells[i, 3].Value.ToString() : "";
                    special.Department = (xlRange.Cells[i, 4].Value != null) ? xlRange.Cells[i, 4].Value.ToString() : "";
                    special.from = (xlRange.Cells[i, 5].Value != null) ? xlRange.Cells[i, 5].Value.ToString() : "";
                    special.to = (xlRange.Cells[i, 6].Value != null) ? xlRange.Cells[i, 6].Value.ToString() : "";
                    special.status = (xlRange.Cells[i, 7].Value != null) ? xlRange.Cells[i, 7].Value.ToString() : "";
                  
                    if (special.ID.Trim() != "")
                    {
                        DataControl dataControl = new DataControl();
                        dataControl.InsertRowofSpecialList(special);
                        specialLists.Add(special);
                    }
                }

                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "List<SpecialList> GetSpecialLists(string pathExcelFile)", ex.Message);
            }
            return specialLists;
        }
        public List<FingerData> GetFingerDatas(string pathExcelFile)
        {
            List<FingerData> specialLists = new List<FingerData>();
            try
            {

                //Create COM Objects. Create a COM object for everything that is referenced
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(pathExcelFile);
                Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
                Excel.Range xlRange = xlWorksheet.UsedRange;

                int rowCount = xlRange.Rows.Count;
                int colCount = xlRange.Columns.Count;

                //iterate over the rows and columns and print to the console as it appears in the file
                //excel is not zero based!!
                for (int i = 5; i <= rowCount; i++)
                {

                    FingerData data = new FingerData();
                    data.Dept =( xlRange.Cells[i, 3].Value != null) ? xlRange.Cells[i, 3].Value.ToString() :"";
                    data.ID = (xlRange.Cells[i, 4].Value != null) ? xlRange.Cells[i, 4].Value.ToString():"";
                    data.Name = (xlRange.Cells[i, 5].Value != null) ? xlRange.Cells[i, 5].Value.ToString():"";
                    try
                    {
                        data.DateTime = (xlRange.Cells[i, 6].Value != null) ? xlRange.Cells[i, 6].Value.ToString() : "";
                    }
                    catch (Exception)
                    {

                        data.DateTime = "";
                    }
                 //  data.DateTime = (xlRange.Cells[i, 6].Value != null) ?(DateTime) xlRange.Cells[i, 6].Value: DateTime.MinValue;
                    data.TimeIn = (xlRange.Cells[i, 9].Value != null) ? xlRange.Cells[i, 9].Value.ToString():"";
                    data.TimeOut = (xlRange.Cells[i, 10].Value != null) ? xlRange.Cells[i, 10].Value.ToString():"";
                    data.DayWorkingTime = (xlRange.Cells[i, 13].Value != null) ? xlRange.Cells[i, 13].Value.ToString():"";
                    data.NightWorkingTime = (xlRange.Cells[i, 14].Value != null) ? xlRange.Cells[i, 14].Value.ToString():"";
                    data.AproveTimeabsent = (xlRange.Cells[i, 17].Value != null) ? xlRange.Cells[i, 17].Value.ToString():"";
                 
                    if (data.ID.Trim() != "")
                    {
                        DataControl dataControl = new DataControl();
                        dataControl.InsertRowofManufacture(data);
                        specialLists.Add(data);
                    }
                    else
                    {
                        ;
                    }

                }

                //cleanup
                GC.Collect();
                GC.WaitForPendingFinalizers();

                //rule of thumb for releasing com objects:
                //  never use two dots, all COM objects must be referenced and released individually
                //  ex: [somthing].[something].[something] is bad

                //release com objects to fully kill excel process from running in the background
                Marshal.ReleaseComObject(xlRange);
                Marshal.ReleaseComObject(xlWorksheet);

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "List<FingerData> GetFingerDatas(string pathExcelFile)", ex.Message);
            }
            return specialLists;
        }

        public List<WorkingDateData> GetWorkingDateDatas(string pathExcelFile, int month)
        {
            List<WorkingDateData> getworkingDateDatas = new List<WorkingDateData>();
            try
            {

                //Create COM Objects. Create a COM object for everything that is referenced
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(pathExcelFile);
                for (int k = 1; k < 37; k++)
                {
                    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[k];
                    Excel.Range xlRange = xlWorksheet.UsedRange;

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;

                    //iterate over the rows and columns and print to the console as it appears in the file
                    //excel is not zero based!!
                    for (int i = 6; i <= rowCount; i = i + 3)
                    {

                        WorkingDateData data = new WorkingDateData();
                        data.dept = (xlRange.Cells[i, 2].Value != null) ? xlRange.Cells[i, 2].Value.ToString() : "";
                        data.ID = (xlRange.Cells[i, 4].Value != null) ? xlRange.Cells[i, 4].Value.ToString() : "";
                        data.Name = (xlRange.Cells[i, 5].Value != null) ? xlRange.Cells[i, 5].Value.ToString() : "";
                        data.col_Dept = (xlRange.Cells[i, 6].Value != null) ? xlRange.Cells[i, 6].Value.ToString() : "";
                        data.col_date = (xlRange.Cells[i, 7].Value != null) ? xlRange.Cells[i, 7].Value.ToString() : "";
                        data.WorkingTimeDatas = new List<WorkingTimeData>();
                        for (int j = 1; j < 32; j++)
                        {
                            data.WorkingTimeDatas.Add(new WorkingTimeData { month = month.ToString(), ngay = j.ToString(), Shift = "day", workingHour = (xlRange.Cells[i, 9 + j].Value != null) ? xlRange.Cells[i, 9 + j].Value.ToString() : "" });
                            data.WorkingTimeDatas.Add(new WorkingTimeData { month = month.ToString(), ngay = j.ToString(), Shift = "night", workingHour = (xlRange.Cells[i + 1, 9 + j].Value != null) ? xlRange.Cells[i + 1, 9 + j].Value.ToString() : "" });
                        }
                        if (data.ID != "")
                        {
                            DataControl dataControl = new DataControl();
                            dataControl.InsertRowofWorkingDate(data);
                            getworkingDateDatas.Add(data);
                        }
                    }
                    //cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    //rule of thumb for releasing com objects:
                    //  never use two dots, all COM objects must be referenced and released individually
                    //  ex: [somthing].[something].[something] is bad

                    //release com objects to fully kill excel process from running in the background
                    Marshal.ReleaseComObject(xlRange);
                    Marshal.ReleaseComObject(xlWorksheet);
                }
                

           

                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "List<WorkingDateData> GetWorkingDateDatas(string pathExcelFile, int month)", ex.Message);
            }
            return getworkingDateDatas;
        }

        public List<WorkingDateData> GetWorkingDateDatasVanPhong(string pathExcelFile, int month)
        {
            List<WorkingDateData> getworkingDateDatas = new List<WorkingDateData>();
            try
            {

                //Create COM Objects. Create a COM object for everything that is referenced
                Excel.Application xlApp = new Excel.Application();
                Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(pathExcelFile);
                for (int k = 1; k < 37; k++)
                {
                    Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[k];
                    Excel.Range xlRange = xlWorksheet.UsedRange;

                    int rowCount = xlRange.Rows.Count;
                    int colCount = xlRange.Columns.Count;

                    //iterate over the rows and columns and print to the console as it appears in the file
                    //excel is not zero based!!
                    for (int i = 6; i <= rowCount; i = i + 1)
                    {

                        WorkingDateData data = new WorkingDateData();
                        data.dept = (xlRange.Cells[i, 2].Value != null) ? xlRange.Cells[i, 2].Value.ToString() : "";
                        data.ID = (xlRange.Cells[i, 4].Value != null) ? xlRange.Cells[i, 4].Value.ToString() : "";
                        data.Name = (xlRange.Cells[i, 5].Value != null) ? xlRange.Cells[i, 5].Value.ToString() : "";
                        data.col_Dept = (xlRange.Cells[i, 6].Value != null) ? xlRange.Cells[i, 6].Value.ToString() : "";
                        data.col_date = (xlRange.Cells[i, 7].Value != null) ? xlRange.Cells[i, 7].Value.ToString() : "";
                        data.WorkingTimeDatas = new List<WorkingTimeData>();
                        for (int j = 1; j < 32; j++)
                        {
                            data.WorkingTimeDatas.Add(new WorkingTimeData { month = month.ToString(), ngay = j.ToString(), Shift = "day", workingHour = (xlRange.Cells[i, 9 + j].Value != null) ? xlRange.Cells[i, 9 + j].Value.ToString() : "" });
                        //    data.WorkingTimeDatas.Add(new WorkingTimeData { month = month.ToString(), ngay = j.ToString(), Shift = "night", workingHour = (xlRange.Cells[i + 1, 9 + j].Value != null) ? xlRange.Cells[i + 1, 9 + j].Value.ToString() : "" });
                        }
                        if (data.ID != "")
                        {
                            DataControl dataControl = new DataControl();
                            dataControl.InsertRowofWorkingDate(data);
                            getworkingDateDatas.Add(data);
                        }
                    }
                    //cleanup
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    //rule of thumb for releasing com objects:
                    //  never use two dots, all COM objects must be referenced and released individually
                    //  ex: [somthing].[something].[something] is bad

                    //release com objects to fully kill excel process from running in the background
                    Marshal.ReleaseComObject(xlRange);
                    Marshal.ReleaseComObject(xlWorksheet);
                }




                //close and release
                xlWorkbook.Close();
                Marshal.ReleaseComObject(xlWorkbook);

                //quit and release
                xlApp.Quit();
                Marshal.ReleaseComObject(xlApp);

            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "List<WorkingDateData> GetWorkingDateDatas(string pathExcelFile, int month)", ex.Message);
            }
            return getworkingDateDatas;
        }
    }
}
