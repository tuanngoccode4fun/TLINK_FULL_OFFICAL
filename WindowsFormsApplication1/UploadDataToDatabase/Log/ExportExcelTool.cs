using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UploadDataToDatabase.MQC;
using UploadDataToDatabase.BackLogReport;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace UploadDataToDatabase.Log
{
    class ExportExcelTool
    {
        public void Datagridview2Excel(DataGridView dataGrid, string pathSaveExcel)

        {
            string stOutput = "";
            // Export titles:
            string sHeaders = "";

            for (int j = 0; j < dataGrid.Columns.Count; j++)
                sHeaders = sHeaders.ToString() + Convert.ToString(dataGrid.Columns[j].HeaderText) + "\t";
            stOutput += sHeaders + "\r\n";
            // Export data.
            for (int i = 0; i < dataGrid.RowCount - 1; i++)
            {
                string stLine = "";
                for (int j = 0; j < dataGrid.Rows[i].Cells.Count; j++)
                    stLine = stLine.ToString() + Convert.ToString(dataGrid.Rows[i].Cells[j].Value) + "\t";
                stOutput += stLine + "\r\n";
            }
            Encoding utf16 = Encoding.GetEncoding(1254);
            byte[] output = utf16.GetBytes(stOutput);
            FileStream fs = new FileStream(pathSaveExcel, FileMode.Create);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(output, 0, output.Length); //write the encoded file
            bw.Flush();
            bw.Close();
            fs.Close();

        }
        public void DatagridviewToExcel(DataGridView dataGrid, string pathSaveExcel)
        {
            try
            {
                Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();
                excel.Visible = true;
                Microsoft.Office.Interop.Excel.Workbook workbook = excel.Workbooks.Add(System.Reflection.Missing.Value);
                Microsoft.Office.Interop.Excel.Worksheet sheet1 = (Microsoft.Office.Interop.Excel.Worksheet)workbook.Sheets[1];
                int StartCol = 1;
                int StartRow = 1;
                int j = 0, i = 0;

                //Write Headers
                for (j = 0; j < dataGrid.Columns.Count; j++)
                {
                    Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow, StartCol + j];
                    myRange.Value2 = dataGrid.Columns[j].HeaderText;
                }

                StartRow++;

                //Write datagridview content
                for (i = 0; i < dataGrid.Rows.Count; i++)
                {
                    for (j = 0; j < dataGrid.Columns.Count; j++)
                    {
                        try
                        {
                            Microsoft.Office.Interop.Excel.Range myRange = (Microsoft.Office.Interop.Excel.Range)sheet1.Cells[StartRow + i, StartCol + j];
                            myRange.Value2 = dataGrid[j, i].Value == null ? "" : dataGrid[j, i].Value;
                        }
                        catch
                        {
                            ;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "DatagridviewToExcel(DataGridView dataGrid, string pathSaveExcel)", ex.Message);
               
            }

        }
        public bool ExportToTemplate( string PathTemplate, DataGridView dgvBackLog ,string dateupdate, string usersend, string version, string year)
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
                xlWorkSheet.Cells[6, 1] = "BackLog Report on "+ DateTime.Now.ToString("MMM/dd/yyyy"); //Line
                xlWorkSheet.Cells[1, 11] = dateupdate; //Line
                xlWorkSheet.Cells[2, 11] = usersend; //Model
                xlWorkSheet.Cells[3, 11] = version; //User  
                xlWorkSheet.Cells[4, 11] = year; //User   
                
                //datagridw
                for (int i = 0; i <= dgvBackLog.Rows.Count - 1; i++) //dong
                {
                    for (int j = 0; j <= dgvBackLog.Columns.Count - 1; j++) //cot
                    {
                        DataGridViewCell cell = dgvBackLog[j, i]; //cot roi dong
                        xlWorkSheet.Cells[i + 11, j + 1] = cell.Value; // dong roi cot
                    }
                }
                string filename = @"C:\ERP_Temp\BackLogReport" + "" + "-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + ".xlsx";
                #endregion

                xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();



                return true;
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "ExportToTemplate error", ex.Message);
                return false;
              
            }
        }
  
   
        public void dtgvExport2Excel(DataGridView dataGrid, string pathSaveExcel)
        {
            try
            {


                Excel.Application xlapp;
                Excel.Workbook xlworkbook;
                Excel.Worksheet xlworsheet;
                object misValue = System.Reflection.Missing.Value;

                xlapp = new Excel.Application();
                xlworkbook = xlapp.Workbooks.Add(misValue);
                xlworsheet = (Excel.Worksheet)xlworkbook.Worksheets.get_Item(1);
                // int i = 0;
                // int j = 0;


                for (int k = 0; k <= dataGrid.ColumnCount - 1; k++)
                {
                    string cell = dataGrid.Columns[k].HeaderText;
                    xlworsheet.Cells[1, k + 1] = cell;
                }



                for (int i = 0; i <= dataGrid.RowCount - 1; i++)
                {
                    for (int j = 0; j <= dataGrid.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dataGrid[j, i];
                        xlworsheet.Cells[i + 2, j + 1] = cell.Value;
                    }
                }
                xlworkbook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlworkbook.Close(true, misValue, misValue);
                xlapp.Quit();
                reOject(xlworsheet);
                reOject(xlworkbook);
                reOject(xlapp);
                Logfile.Output(StatusLog.Normal, "Export to excel sucessful!", "Information" );
               
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Export to excel fail: " , ex.Message);
               
            }
        }
        public void ExportToTemplateMQCDefect(string PathTemplate, string pathSaveExcel, DefectRateData defectRate)
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

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2); //add data sheet1  
                                                                                  //xlWorkSheet.Cells[6, 1] = "BackLog Report on " + DateTime.Now.ToString("MMM/dd/yyyy"); //Line
                string strWorksheetName = xlWorkSheet.Name;//Get the name of worksheet.                                                               //xlWorkSheet.Cells[1, 11] = dateupdate; //Line
                if (strWorksheetName == "优減")
                {//Fill ngay thang nam                                                                //xlWorkSheet.Cells[2, 11] = usersend; //Model
                    string date = DateTime.Now.ToString("yyyy.MM.dd");
                    xlWorkSheet.Cells[3, 10] = date;//xlWorkSheet.Cells[3, 11] = version; //User  
                    xlWorkSheet.Cells[4, 2] = defectRate.TotalQuantity;
                    xlWorkSheet.Cells[4, 6] = defectRate.DefectQuantity;
                    xlWorkSheet.Cells[17, 2] = date;
                    double countDefect = 0;
                    //   xlWorkSheet.Cells[2, 31] = DateTime.Now.ToString("MM");
                    for (int i = 0; i < defectRate.defectItems.Count; i++)
                    {
                        if (defectRate.defectItems[i].Note == (i + 1))
                        {
                            xlWorkSheet.Cells[7, 2 + i] = defectRate.defectItems[i].Quantity;
                            countDefect += defectRate.defectItems[i].Quantity;
                        }
                    }
                    xlWorkSheet.Cells[7, 7] = defectRate.DefectQuantity - countDefect;
                }
                #endregion

                xlWorkBook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();



             
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "An error happened in the process.", ex.Message);
               
            }
        }
        public void ExportToTemplateMQCDefectDaily(string PathTemplate, string pathSaveExcel, List<DefectRateData> defectRates)
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

                if (strWorksheetName == "Daily")
                {//Fill ngay thang nam                                                                //xlWorkSheet.Cells[2, 11] = usersend; //Model
                 //xlWorkSheet.Cells[1, 11] = dateupdate; //Line
                    string date = DateTime.Now.ToString("dd-MM-yyyy");
                    for (int i = 0; i < defectRates.Count; i++)
                {
                        double countDefect = 0;
                        xlWorkSheet.Cells[4 + i, 1] = defectRates[i].DateTime_from + "-" + defectRates[i].DateTime_to;//xlWorkSheet.Cells[3, 11] = version; //User  
                        xlWorkSheet.Cells[4+i, 2] = defectRates[i].Product;//xlWorkSheet.Cells[3, 11] = version; //User  
                        xlWorkSheet.Cells[4 + i, 3] = defectRates[i].Lot;
                        xlWorkSheet.Cells[4 + i, 5] = defectRates[i].TargetMQC.TargetOutput;
                        xlWorkSheet.Cells[4 + i, 6] = defectRates[i].TotalQuantity;
                       xlWorkSheet.Cells[4 + i, 7] = defectRates[i].OutputQuantity;
                        xlWorkSheet.Cells[4 + i, 31] = defectRates[i].DefectQuantity;

                        //   xlWorkSheet.Cells[2, 31] = DateTime.Now.ToString("MM");
                        for (int j = 0; j < defectRates[i].defectItems.Count; j++)
                        {
                            if (defectRates[i].defectItems[j].Note == (j + 1))
                            {
                                xlWorkSheet.Cells[4+i, 17 + j] = defectRates[i].defectItems[j].Quantity;
                                countDefect += defectRates[i].defectItems[j].Quantity;
                            }
                        }
                        xlWorkSheet.Cells[4 + i, 30] = defectRates[i].DefectQuantity - countDefect;
                        xlWorkSheet.Name = date;
                    }
                }
                #endregion

                xlWorkBook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();



              
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "ExportToTemplateMQCDefectDaily : An error happened in the process.", ex.Message);
            
            }
        }
        public void ExportToReliabilityReport(string PathTemplate, string pathSaveExcel,List<ReliabilitySummary> summaries, List<ReliabilitySummary> summariesDept, DateTime from, DateTime to)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet; //sheet 2
            Excel.Worksheet xlWorkSheet2; //sheet 2
            Excel.Range range;
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

                if (strWorksheetName == "Client")
                {//Fill ngay thang nam                                                                //xlWorkSheet.Cells[2, 11] = usersend; //Model
                 //xlWorkSheet.Cells[1, 11] = dateupdate; //Line
                    string date = DateTime.Now.ToString("dd-MM-yyyy");
                    int startGroup = 0; 
                    for (int i = 0; i < summaries.Count; i++)
                    {
                        if (summaries[i].DepartmentCode == "Total")
                        {

                            range = xlWorkSheet.Range[xlWorkSheet.Cells[14 + i - startGroup, "A"], xlWorkSheet.Cells[14 + i, "A"]];

                            range.Merge();
                         
                            xlWorkSheet.Cells[14 + i- startGroup, "A"] = summaries[i].Clients;
                            xlWorkSheet.Cells[14 + i, "B"] = summaries[i].DepartmentCode;
                            xlWorkSheet.Cells[14 + i, "E"] = Math.Round(summaries[i].Reliability, 2);
                            xlWorkSheet.Cells[14 + i, "G"] = summaries[i].Orders;
                            xlWorkSheet.Cells[14 + i, "I"] = summaries[i].OrdersOT;
                            xlWorkSheet.Cells[14 + i, "K"] = summaries[i].OrdesEarly;
                            xlWorkSheet.Cells[14 + i, "M"] = summaries[i].OrdesLate;
                            xlWorkSheet.Cells[14 + i, "O"] = summaries[i].OTS;
                            xlWorkSheet.Cells[14 + i, "Q"] = summaries[i].SOMO;
                            xlWorkSheet.Cells[14 + i, "S"] = summaries[i].DeliveryQuantity;
                         
                            range = xlWorkSheet.Range[xlWorkSheet.Cells[14 + i - startGroup, "A"], xlWorkSheet.Cells[14 + i-1, "V"]];
                            range.Rows.OutlineLevel = 2;
                            range.Rows.Group(misValue, misValue, misValue, misValue);
                            range.Rows.Hidden = true;
                          
                           startGroup = 0;
                            //   range.Rows.OutlineLevel = 1;
                            //       xlWorkSheet.(xlWorkSheet.Cells[14 + i, "A"], xlWorkSheet.Cells[14 + i+startGroup, "A"]);
                            //   rng1.Merge(misValue);
                        }
                        else
                        {


                           
                            xlWorkSheet.Cells[14 + i, "B"] = summaries[i].DepartmentCode;
                            xlWorkSheet.Cells[14 + i, "E"] = Math.Round(summaries[i].Reliability, 2);
                            xlWorkSheet.Cells[14 + i, "G"] = summaries[i].Orders;
                            xlWorkSheet.Cells[14 + i, "I"] = summaries[i].OrdersOT;
                            xlWorkSheet.Cells[14 + i, "K"] = summaries[i].OrdesEarly;
                            xlWorkSheet.Cells[14 + i, "M"] = summaries[i].OrdesLate;
                            xlWorkSheet.Cells[14 + i, "O"] = summaries[i].OTS;
                            xlWorkSheet.Cells[14 + i, "Q"] = summaries[i].SOMO;
                            xlWorkSheet.Cells[14 + i, "S"] = summaries[i].DeliveryQuantity;

                            startGroup++;
                        }
                    }

                    double countOrder = summaries.Select(d => d.Orders).Sum();
                    double countEarly = summaries.Select(d => d.OrdesEarly).Sum();
                    double countOntime = summaries.Select(d => d.OrdersOT).Sum();
                    double countLate = summaries.Select(d => d.OrdesLate).Sum();
                    double Reliability = (countEarly + countOntime) / countOrder;
                    double Flexibility = summaries.Select(d => d.Flexibility).Average();
                    double OTS = summaries.Select(d => d.OTS).Average();
                    double reqOTS = summaries.Select(d => d.ReqOTS).Average();
                    double SOMO = summaries.Select(d => d.SOMO).Average();
                    double Quantity =  summaries.Select(d => d.DeliveryQuantity).Sum();
                    xlWorkSheet.Cells[8, "B"] = Reliability;
                    xlWorkSheet.Cells[8, "D"] = countOrder;
                    xlWorkSheet.Cells[8, "F"] = countOntime;
                    xlWorkSheet.Cells[8, "H"] = countEarly;
                    xlWorkSheet.Cells[8, "J"] = countLate;
                    xlWorkSheet.Cells[8, "L"] = OTS;
                    xlWorkSheet.Cells[8, "N"] = SOMO;
                    xlWorkSheet.Cells[8, "P"] = Quantity;
                    xlWorkSheet.Cells[4, "B"] = from.ToString("dd-MM-yyyy");
                    xlWorkSheet.Cells[4, "G"] = to.ToString("dd-MM-yyyy");

                    //         xlWorkSheet.Name = date;


                }
                
                #endregion


                #region Sheet 2
                //Add data in Sheet 1

                xlWorkSheet2 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2); //add data sheet1  
                                                                                  //xlWorkSheet2.Cells[6, 1] = "BackLog Report on " + DateTime.Now.ToString("MMM/dd/yyyy"); //Line
                string strWorksheetName2 = xlWorkSheet2.Name;//Get the name of worksheet.

                if (strWorksheetName2 == "Dept")
                {//Fill ngay thang nam                                                                //xlWorkSheet22.Cells[2, 11] = usersend; //Model
                 //xlWorkSheet22.Cells[1, 11] = dateupdate; //Line
                    int startGroup = 0;
                    string date = DateTime.Now.ToString("dd-MM-yyyy");
                    for (int i = 0; i < summariesDept.Count; i++)
                    {
                        if (summariesDept[i].Clients == "Total")
                        {
                            range = xlWorkSheet2.Range[xlWorkSheet2.Cells[14 + i - startGroup, "A"], xlWorkSheet2.Cells[14 + i, "A"]];
                            range.Merge();
                           // range.Group();
                            xlWorkSheet2.Cells[14 + i - startGroup, "A"] = summariesDept[i].DepartmentCode;
                            xlWorkSheet2.Cells[14 + i, "B"] = summariesDept[i].Clients;
                            xlWorkSheet2.Cells[14 + i, "E"] = Math.Round(summariesDept[i].Reliability, 2);
                            xlWorkSheet2.Cells[14 + i, "G"] = summariesDept[i].Orders;
                            xlWorkSheet2.Cells[14 + i, "I"] = summariesDept[i].OrdersOT;
                            xlWorkSheet2.Cells[14 + i, "K"] = summariesDept[i].OrdesEarly;
                            xlWorkSheet2.Cells[14 + i, "M"] = summariesDept[i].OrdesLate;
                            xlWorkSheet2.Cells[14 + i, "O"] = summariesDept[i].OTS;
                            xlWorkSheet2.Cells[14 + i, "Q"] = summariesDept[i].SOMO;
                            xlWorkSheet2.Cells[14 + i, "S"] = summariesDept[i].DeliveryQuantity;
    
                            range = xlWorkSheet2.Range[xlWorkSheet2.Cells[14 + i - startGroup, "A"], xlWorkSheet2.Cells[14 + i - 1, "V"]];
                            range.Rows.OutlineLevel = 1;
                            range.Rows.Group(misValue, misValue, misValue, misValue);
                            range.Rows.Hidden = true;
                            startGroup = 0;
                        }
                        else
                        {
                            xlWorkSheet2.Cells[14 + i, "B"] = summariesDept[i].Clients;
                       //     xlWorkSheet2.Cells[14 + i, "A"] = summariesDept[i].DepartmentCode;
                            xlWorkSheet2.Cells[14 + i, "E"] = Math.Round(summariesDept[i].Reliability, 2);
                            xlWorkSheet2.Cells[14 + i, "G"] = summariesDept[i].Orders;
                            xlWorkSheet2.Cells[14 + i, "I"] = summariesDept[i].OrdersOT;
                            xlWorkSheet2.Cells[14 + i, "K"] = summariesDept[i].OrdesEarly;
                            xlWorkSheet2.Cells[14 + i, "M"] = summariesDept[i].OrdesLate;
                            xlWorkSheet2.Cells[14 + i, "O"] = summariesDept[i].OTS;
                            xlWorkSheet2.Cells[14 + i, "Q"] = summariesDept[i].SOMO;
                            xlWorkSheet2.Cells[14 + i, "S"] = summariesDept[i].DeliveryQuantity;
                            startGroup++;
                        }
                    }
                    double countOrder = summariesDept.Select(d => d.Orders).Sum();
                    double countEarly = summariesDept.Select(d => d.OrdesEarly).Sum();
                    double countOntime = summariesDept.Select(d => d.OrdersOT).Sum();
                    double countLate = summariesDept.Select(d => d.OrdesLate).Sum();
                    double Reliability = (countEarly + countOntime) / countOrder;
                    double Flexibility = summariesDept.Select(d => d.Flexibility).Average();
                    double OTS = summariesDept.Select(d => d.OTS).Average();
                    double reqOTS = summariesDept.Select(d => d.ReqOTS).Average();
                    double SOMO = summariesDept.Select(d => d.SOMO).Average();
                    double Quantity = summariesDept.Select(d => d.DeliveryQuantity).Sum();
                    xlWorkSheet2.Cells[8, "B"] = Reliability;
                    xlWorkSheet2.Cells[8, "D"] = countOrder;
                    xlWorkSheet2.Cells[8, "F"] = countOntime;
                    xlWorkSheet2.Cells[8, "H"] = countEarly;
                    xlWorkSheet2.Cells[8, "J"] = countLate;
                    xlWorkSheet2.Cells[8, "L"] = OTS;
                    xlWorkSheet2.Cells[8, "N"] = SOMO;
                    xlWorkSheet2.Cells[8, "P"] = Quantity;
                    xlWorkSheet2.Cells[4, "B"] = from.ToString("dd-MM-yyyy");
                    xlWorkSheet2.Cells[4, "G"] = to.ToString("dd-MM-yyyy");

                    // xlWorkSheet22.Name = date;
                }
                #endregion


                xlWorkBook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();



             
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "ExportToReliabilityReport : An error happened in the process.", ex.Message);
               
            }
        }
        public void ExportToTemplateMQCDefectAmountOfTime(DateTime from, DateTime to,string PathTemplate, string pathSaveExcel, DefectRateData defectRate)
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

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2); //add data sheet1  
                                                                                  //xlWorkSheet.Cells[6, 1] = "BackLog Report on " + DateTime.Now.ToString("MMM/dd/yyyy"); //Line
                string strWorksheetName = xlWorkSheet.Name;//Get the name of worksheet.                                                               //xlWorkSheet.Cells[1, 11] = dateupdate; //Line
                if (strWorksheetName == "优減")
                {//Fill ngay thang nam                                                                //xlWorkSheet.Cells[2, 11] = usersend; //Model
                    string date = DateTime.Now.ToString("yyyy.MM.dd");
                    xlWorkSheet.Cells[3, 10] = date;//xlWorkSheet.Cells[3, 11] = version; //User  
                    xlWorkSheet.Cells[4, 2] = defectRate.TotalQuantity;
                    xlWorkSheet.Cells[4, 6] = defectRate.DefectQuantity;
                    xlWorkSheet.Cells[17, 2] = from.ToString("yyyy.MM.dd") +" - " + to.ToString("yyyy.MM.dd");
                    double countDefect = 0;
                    //   xlWorkSheet.Cells[2, 31] = DateTime.Now.ToString("MM");
                    for (int i = 0; i < defectRate.defectItems.Count; i++)
                    {
                        if (defectRate.defectItems[i].Note == (i + 1))
                        {
                            xlWorkSheet.Cells[7, 2 + i] = defectRate.defectItems[i].Quantity;
                            countDefect += defectRate.defectItems[i].Quantity;
                        }
                    }
                    xlWorkSheet.Cells[7, 7] = defectRate.DefectQuantity - countDefect;
                }
                #endregion

                xlWorkBook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();



            
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "ExportToTemplateMQCDefectAmountOfTime : An error happened in the process.", ex.Message);
              
            }
        }
        public void ExportToTemplateMQCDefectTop16(string PathTemplate, string pathSaveExcel, DefectRateData defectRate)
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
                string strWorksheetName = xlWorkSheet.Name;//Get the name of worksheet.                                                               //xlWorkSheet.Cells[1, 11] = dateupdate; //Line
                if (strWorksheetName == "报表")
                {//Fill ngay thang nam                                                                //xlWorkSheet.Cells[2, 11] = usersend; //Model
                    string date = DateTime.Now.ToString("yyyy.MM.dd");
                    xlWorkSheet.Cells[2, 11] = DateTime.Now.ToString("dd");
                    xlWorkSheet.Cells[2, 13] = DateTime.Now.ToString("MM");
                    xlWorkSheet.Cells[2, 15] = DateTime.Now.ToString("yyyy");
                    xlWorkSheet.Cells[6, 1] = defectRate.Product;//xlWorkSheet.Cells[3, 11] = version; //User  
                    xlWorkSheet.Cells[6, 2] = defectRate.Lot;
                    xlWorkSheet.Cells[6, 3] = defectRate.DateTime_from + "-" + defectRate.DateTime_to;
                    xlWorkSheet.Cells[6, 4] = defectRate.TotalQuantity;
                    xlWorkSheet.Cells[6, 23] = defectRate.OutputQuantity;
                    xlWorkSheet.Cells[6, 24] = defectRate.DefectQuantity;
                    xlWorkSheet.Cells[6, 25] = defectRate.DefectRate;
                    double countDefect = 0;
                    //   xlWorkSheet.Cells[2, 31] = DateTime.Now.ToString("MM");
                    for (int i = 0; i < defectRate.defectItems.Count; i++)
                    {
                        if (defectRate.defectItems[i].Note == (i + 1))
                        {
                            xlWorkSheet.Cells[6, 5 + i] = defectRate.defectItems[i].Quantity;
                            countDefect += defectRate.defectItems[i].Quantity;
                        }
                    }
                    xlWorkSheet.Cells[6, 21] = defectRate.DefectQuantity - countDefect;
                }
                #endregion

                xlWorkBook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();

            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "ExportToTemplateMQCDefectTop16 : An error happened in the process.", ex.Message);

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
                Logfile.Output(StatusLog.Error, "Export to excel fail: ", ex.Message);
                
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
