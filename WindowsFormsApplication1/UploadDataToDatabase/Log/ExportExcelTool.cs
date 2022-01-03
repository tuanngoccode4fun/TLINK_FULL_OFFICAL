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

namespace UploadDataToDatabase
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
        public bool ExportToTemplate( string PathTemplate, DataGridView dgvBackLog ,string pathSave, string dateupdate, string usersend, string version, string year)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet; //sheet 2
            //Excel.Worksheet xlWorkSheet1; //sheet 1
            object misValue = System.Reflection.Missing.Value;
            string filename = pathSave + @"\BackLogReport" + "" + "-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + ".xlsx";
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(PathTemplate, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                #region Sheet 1
                //Add data in Sheet 1
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //add data sheet1  
                xlWorkSheet.Cells[6, 1] = "BackLog Report on "+ DateTime.Now.ToString("MMM/dd/yyyy"); //Line
                xlWorkSheet.Cells[1, "L"] = dateupdate; //Line
                xlWorkSheet.Cells[2, "L"] = usersend; //Model
                xlWorkSheet.Cells[3, "L"] = version; //User  
                xlWorkSheet.Cells[4, "L"] = year; //User   
                
                //datagridw
                for (int i = 0; i <= dgvBackLog.Rows.Count - 1; i++) //dong
                {
                    for (int j = 0; j <= dgvBackLog.Columns.Count - 1; j++) //cot
                    {
                        DataGridViewCell cell = dgvBackLog[j, i]; //cot roi dong
                        xlWorkSheet.Cells[i + 11, j + 1] = cell.Value; // dong roi cot
                    }
                }
                
                Logfile.Output(StatusLog.Normal, filename);
                #endregion

                xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();
                

                Logfile.Output(StatusLog.Normal, "Xuat file OK");
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
            //    Excel.Worksheet xlworsheet2;
                object misValue = System.Reflection.Missing.Value;

                xlapp = new Excel.Application();
                xlworkbook = xlapp.Workbooks.Add(misValue);
                #region Sheet1
                xlworsheet = (Excel.Worksheet)xlworkbook.Worksheets.get_Item(1);
                // int i = 0;
                // int j = 0;
                xlworsheet.Name = "Raw Data";

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
                #endregion

            

                xlworkbook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlworkbook.Close(true, misValue, misValue);
                xlapp.Quit();
              //  reOject(xlworsheet2);
                reOject(xlworsheet);
                reOject(xlworkbook);
                reOject(xlapp);
                Logfile.Output(StatusLog.Normal, "Export to excel sucessful!", "Information");

            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Export to excel fail: ", ex.Message);

            }
        }

        public void dtgvExport2Excel(DataGridView dataGrid, DataGridView dataGrid2, string pathSaveExcel)
        {
            try
            {


                Excel.Application xlapp;
                Excel.Workbook xlworkbook;
                Excel.Worksheet xlworsheet;
                Excel.Worksheet xlworsheet2;
                object misValue = System.Reflection.Missing.Value;

                xlapp = new Excel.Application();
                xlworkbook = xlapp.Workbooks.Add(misValue);
                #region Sheet1
                xlworsheet = (Excel.Worksheet)xlworkbook.Worksheets.get_Item(1);
                // int i = 0;
                // int j = 0;
                xlworsheet.Name = "Raw Data";

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
                #endregion

                #region Sheet2
                xlworsheet2 = (Excel.Worksheet)xlworkbook.Worksheets.Add();
                xlworsheet2.Name = "Raw data (Adding 7 days)";
                // int i = 0;
                // int j = 0;


                for (int k = 0; k <= dataGrid2.ColumnCount - 1; k++)
                {
                    string cell = dataGrid2.Columns[k].HeaderText;
                    xlworsheet2.Cells[1, k + 1] = cell;
                }



                for (int i = 0; i <= dataGrid2.RowCount - 1; i++)
                {
                    for (int j = 0; j <= dataGrid2.ColumnCount - 1; j++)
                    {
                        DataGridViewCell cell = dataGrid2[j, i];
                        xlworsheet2.Cells[i + 2, j + 1] = cell.Value;
                    }
                }
                #endregion

                xlworkbook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlworkbook.Close(true, misValue, misValue);
                xlapp.Quit();
                reOject(xlworsheet2);
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
                        xlWorkSheet.Cells[4 + i, "A"] = defectRates[i].Line;//xlWorkSheet.Cells[3, 11] = version; //User  
                        xlWorkSheet.Cells[4 + i, "B"] = defectRates[i].DateTime_from + "-" + defectRates[i].DateTime_to;//xlWorkSheet.Cells[3, 11] = version; //User  
                        xlWorkSheet.Cells[4+i, "C"] = defectRates[i].Product;//xlWorkSheet.Cells[3, 11] = version; //User  
                        xlWorkSheet.Cells[4 + i, "D"] = defectRates[i].Lot;
                        xlWorkSheet.Cells[4 + i, "F"] = defectRates[i].TargetMQC.TargetOutput;
                        xlWorkSheet.Cells[4 + i, "G"] = defectRates[i].TotalQuantity;
                       xlWorkSheet.Cells[4 + i, "H"] = defectRates[i].OutputQuantity;
                        xlWorkSheet.Cells[4 + i, "AF"] = defectRates[i].DefectQuantity;

                        //   xlWorkSheet.Cells[2, 31] = DateTime.Now.ToString("MM");
                        for (int j = 0; j < defectRates[i].defectItems.Count; j++)
                        {
                            if (defectRates[i].defectItems[j].Note == (j + 1))
                            {
                                xlWorkSheet.Cells[4+i, 18 + j] = defectRates[i].defectItems[j].Quantity;
                                countDefect += defectRates[i].defectItems[j].Quantity;
                            }
                        }
                        xlWorkSheet.Cells[4 + i, 31] = defectRates[i].DefectQuantity - countDefect;
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

                    double countOrder = summaries.Where(d=>d.DepartmentCode != "Total" ).Select(d => d.Orders).Sum();
                    double countEarly = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdesEarly).Sum();
                    double countOntime = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdersOT).Sum();
                    double countLate = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdesLate).Sum();
                    double Reliability = (countEarly + countOntime) / countOrder;
                    double Flexibility = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.Flexibility).Average();
                    double OTS = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.OTS).Average();
                    double reqOTS = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.ReqOTS).Average();
                    double SOMO = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.SOMO).Average();
                    double Quantity =  summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.DeliveryQuantity).Sum();
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
                    double countOrder = summariesDept.Where(d => d.Clients != "Total").Select(d => d.Orders).Sum();
                    double countEarly = summariesDept.Where(d => d.Clients != "Total").Select(d => d.OrdesEarly).Sum();
                    double countOntime = summariesDept.Where(d => d.Clients != "Total").Select(d => d.OrdersOT).Sum();
                    double countLate = summariesDept.Where(d => d.Clients != "Total").Select(d => d.OrdesLate).Sum();
                    double Reliability = (countEarly + countOntime) / countOrder;
                    double Flexibility = summariesDept.Where(d => d.Clients != "Total").Select(d => d.Flexibility).Average();
                    double OTS = summariesDept.Where(d => d.Clients != "Total").Select(d => d.OTS).Average();
                    double reqOTS = summariesDept.Where(d => d.Clients != "Total").Select(d => d.ReqOTS).Average();
                    double SOMO = summariesDept.Where(d => d.Clients != "Total").Select(d => d.SOMO).Average();
                    double Quantity = summariesDept.Where(d => d.Clients != "Total").Select(d => d.DeliveryQuantity).Sum();
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


        public void ExportToReliabilityReportAdding7Days(string PathTemplate, string pathSaveExcel, List<ReliabilitySummary> summaries, List<ReliabilitySummary> summariesDept, List<ReliabilitySummary> summariesAdding7Days, List<ReliabilitySummary> summariesDeptAdding7Days, DateTime from, DateTime to)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet; //sheet 2
            Excel.Worksheet xlWorkSheet2; //sheet 2
            Excel.Worksheet xlWorkSheet3; //sheet 2
            Excel.Worksheet xlWorkSheet4; //sheet 2
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

                            xlWorkSheet.Cells[14 + i - startGroup, "A"] = summaries[i].Clients;
                            xlWorkSheet.Cells[14 + i, "B"] = summaries[i].DepartmentCode;
                            xlWorkSheet.Cells[14 + i, "E"] = Math.Round(summaries[i].Reliability, 2);
                            xlWorkSheet.Cells[14 + i, "G"] = summaries[i].Orders;
                            xlWorkSheet.Cells[14 + i, "I"] = summaries[i].OrdersOT;
                            xlWorkSheet.Cells[14 + i, "K"] = summaries[i].OrdesEarly;
                            xlWorkSheet.Cells[14 + i, "M"] = summaries[i].OrdesLate;
                            xlWorkSheet.Cells[14 + i, "O"] = summaries[i].OTS;
                            xlWorkSheet.Cells[14 + i, "Q"] = summaries[i].SOMO;
                            xlWorkSheet.Cells[14 + i, "S"] = summaries[i].DeliveryQuantity;

                            range = xlWorkSheet.Range[xlWorkSheet.Cells[14 + i - startGroup, "A"], xlWorkSheet.Cells[14 + i - 1, "V"]];
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

                    double countOrder = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.Orders).Sum();
                    double countEarly = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdesEarly).Sum();
                    double countOntime = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdersOT).Sum();
                    double countLate = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdesLate).Sum();
                    double Reliability = (countEarly + countOntime) / countOrder;
                    double Flexibility = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.Flexibility).Average();
                    double OTS = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.OTS).Average();
                    double reqOTS = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.ReqOTS).Average();
                    double SOMO = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.SOMO).Average();
                    double Quantity = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.DeliveryQuantity).Sum();
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
                    double countOrder = summariesDept.Where(d => d.Clients != "Total").Select(d => d.Orders).Sum();
                    double countEarly = summariesDept.Where(d => d.Clients != "Total").Select(d => d.OrdesEarly).Sum();
                    double countOntime = summariesDept.Where(d => d.Clients != "Total").Select(d => d.OrdersOT).Sum();
                    double countLate = summariesDept.Where(d => d.Clients != "Total").Select(d => d.OrdesLate).Sum();
                    double Reliability = (countEarly + countOntime) / countOrder;
                    double Flexibility = summariesDept.Where(d => d.Clients != "Total").Select(d => d.Flexibility).Average();
                    double OTS = summariesDept.Where(d => d.Clients != "Total").Select(d => d.OTS).Average();
                    double reqOTS = summariesDept.Where(d => d.Clients != "Total").Select(d => d.ReqOTS).Average();
                    double SOMO = summariesDept.Where(d => d.Clients != "Total").Select(d => d.SOMO).Average();
                    double Quantity = summariesDept.Where(d => d.Clients != "Total").Select(d => d.DeliveryQuantity).Sum();
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


                #region Sheet 3
                //Add data in Sheet 1

                xlWorkSheet3 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(3); //add data sheet1  
                                                                                  //xlWorkSheet.Cells[6, 1] = "BackLog Report on " + DateTime.Now.ToString("MMM/dd/yyyy"); //Line
                string strWorksheetName3 = xlWorkSheet3.Name;//Get the name of worksheet.

                if (strWorksheetName3 == "Client (+7Days)")
                {//Fill ngay thang nam                                                                //xlWorkSheet.Cells[2, 11] = usersend; //Model
                 //xlWorkSheet.Cells[1, 11] = dateupdate; //Line
                    string date = DateTime.Now.ToString("dd-MM-yyyy");
                    int startGroup = 0;
                    for (int i = 0; i < summariesAdding7Days.Count; i++)
                    {
                        if (summariesAdding7Days[i].DepartmentCode == "Total")
                        {

                            range = xlWorkSheet3.Range[xlWorkSheet3.Cells[14 + i - startGroup, "A"], xlWorkSheet3.Cells[14 + i, "A"]];

                            range.Merge();

                            xlWorkSheet3.Cells[14 + i - startGroup, "A"] = summariesAdding7Days[i].Clients;
                            xlWorkSheet3.Cells[14 + i, "B"] = summariesAdding7Days[i].DepartmentCode;
                            xlWorkSheet3.Cells[14 + i, "E"] = Math.Round(summariesAdding7Days[i].Reliability, 2);
                            xlWorkSheet3.Cells[14 + i, "G"] = summariesAdding7Days[i].Orders;
                            xlWorkSheet3.Cells[14 + i, "I"] = summariesAdding7Days[i].OrdersOT;
                            xlWorkSheet3.Cells[14 + i, "K"] = summariesAdding7Days[i].OrdesEarly;
                            xlWorkSheet3.Cells[14 + i, "M"] = summariesAdding7Days[i].OrdesLate;
                            xlWorkSheet3.Cells[14 + i, "O"] = summariesAdding7Days[i].OTS;
                            xlWorkSheet3.Cells[14 + i, "Q"] = summariesAdding7Days[i].SOMO;
                            xlWorkSheet3.Cells[14 + i, "S"] = summariesAdding7Days[i].DeliveryQuantity;

                            range = xlWorkSheet3.Range[xlWorkSheet3.Cells[14 + i - startGroup, "A"], xlWorkSheet3.Cells[14 + i - 1, "V"]];
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



                            xlWorkSheet3.Cells[14 + i, "B"] = summariesAdding7Days[i].DepartmentCode;
                            xlWorkSheet3.Cells[14 + i, "E"] = Math.Round(summariesAdding7Days[i].Reliability, 2);
                            xlWorkSheet3.Cells[14 + i, "G"] = summariesAdding7Days[i].Orders;
                            xlWorkSheet3.Cells[14 + i, "I"] = summariesAdding7Days[i].OrdersOT;
                            xlWorkSheet3.Cells[14 + i, "K"] = summariesAdding7Days[i].OrdesEarly;
                            xlWorkSheet3.Cells[14 + i, "M"] = summariesAdding7Days[i].OrdesLate;
                            xlWorkSheet3.Cells[14 + i, "O"] = summariesAdding7Days[i].OTS;
                            xlWorkSheet3.Cells[14 + i, "Q"] = summariesAdding7Days[i].SOMO;
                            xlWorkSheet3.Cells[14 + i, "S"] = summariesAdding7Days[i].DeliveryQuantity;

                            startGroup++;
                        }
                    }

                    double countOrder = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.Orders).Sum();
                    double countEarly = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdesEarly).Sum();
                    double countOntime = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdersOT).Sum();
                    double countLate = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdesLate).Sum();
                    double Reliability = (countEarly + countOntime) / countOrder;
                    double Flexibility = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.Flexibility).Average();
                    double OTS = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.OTS).Average();
                    double reqOTS = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.ReqOTS).Average();
                    double SOMO = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.SOMO).Average();
                    double Quantity = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.DeliveryQuantity).Sum();
                    xlWorkSheet3.Cells[8, "B"] = Reliability;
                    xlWorkSheet3.Cells[8, "D"] = countOrder;
                    xlWorkSheet3.Cells[8, "F"] = countOntime;
                    xlWorkSheet3.Cells[8, "H"] = countEarly;
                    xlWorkSheet3.Cells[8, "J"] = countLate;
                    xlWorkSheet3.Cells[8, "L"] = OTS;
                    xlWorkSheet3.Cells[8, "N"] = SOMO;
                    xlWorkSheet3.Cells[8, "P"] = Quantity;
                    xlWorkSheet3.Cells[4, "B"] = from.ToString("dd-MM-yyyy");
                    xlWorkSheet3.Cells[4, "G"] = to.ToString("dd-MM-yyyy");

                    //         xlWorkSheet.Name = date;


                }

                #endregion

                #region Sheet 4
                //Add data in Sheet 1

                xlWorkSheet4 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(4); //add data sheet1  
                                                                                   //xlWorkSheet4.Cells[6, 1] = "BackLog Report on " + DateTime.Now.ToString("MMM/dd/yyyy"); //Line
                string strWorksheetName4 = xlWorkSheet4.Name;//Get the name of worksheet.

                if (strWorksheetName4 == "Dept (+7days)")
                {//Fill ngay thang nam                                                                //xlWorkSheet22.Cells[2, 11] = usersend; //Model
                 //xlWorkSheet22.Cells[1, 11] = dateupdate; //Line
                    int startGroup = 0;
                    string date = DateTime.Now.ToString("dd-MM-yyyy");
                    for (int i = 0; i < summariesDept.Count; i++)
                    {
                        if (summariesDeptAdding7Days[i].Clients == "Total")
                        {
                            range = xlWorkSheet4.Range[xlWorkSheet4.Cells[14 + i - startGroup, "A"], xlWorkSheet4.Cells[14 + i, "A"]];
                            range.Merge();
                            // range.Group();
                            xlWorkSheet4.Cells[14 + i - startGroup, "A"] = summariesDeptAdding7Days[i].DepartmentCode;
                            xlWorkSheet4.Cells[14 + i, "B"] = summariesDeptAdding7Days[i].Clients;
                            xlWorkSheet4.Cells[14 + i, "E"] = Math.Round(summariesDeptAdding7Days[i].Reliability, 2);
                            xlWorkSheet4.Cells[14 + i, "G"] = summariesDeptAdding7Days[i].Orders;
                            xlWorkSheet4.Cells[14 + i, "I"] = summariesDeptAdding7Days[i].OrdersOT;
                            xlWorkSheet4.Cells[14 + i, "K"] = summariesDeptAdding7Days[i].OrdesEarly;
                            xlWorkSheet4.Cells[14 + i, "M"] = summariesDeptAdding7Days[i].OrdesLate;
                            xlWorkSheet4.Cells[14 + i, "O"] = summariesDeptAdding7Days[i].OTS;
                            xlWorkSheet4.Cells[14 + i, "Q"] = summariesDeptAdding7Days[i].SOMO;
                            xlWorkSheet4.Cells[14 + i, "S"] = summariesDeptAdding7Days[i].DeliveryQuantity;

                            range = xlWorkSheet4.Range[xlWorkSheet4.Cells[14 + i - startGroup, "A"], xlWorkSheet4.Cells[14 + i - 1, "V"]];
                            range.Rows.OutlineLevel = 1;
                            range.Rows.Group(misValue, misValue, misValue, misValue);
                            range.Rows.Hidden = true;
                            startGroup = 0;
                        }
                        else
                        {
                            xlWorkSheet4.Cells[14 + i, "B"] = summariesDeptAdding7Days[i].Clients;
                            //     xlWorkSheet4.Cells[14 + i, "A"] = summariesDeptAdding7Days[i].DepartmentCode;
                            xlWorkSheet4.Cells[14 + i, "E"] = Math.Round(summariesDeptAdding7Days[i].Reliability, 2);
                            xlWorkSheet4.Cells[14 + i, "G"] = summariesDeptAdding7Days[i].Orders;
                            xlWorkSheet4.Cells[14 + i, "I"] = summariesDeptAdding7Days[i].OrdersOT;
                            xlWorkSheet4.Cells[14 + i, "K"] = summariesDeptAdding7Days[i].OrdesEarly;
                            xlWorkSheet4.Cells[14 + i, "M"] = summariesDeptAdding7Days[i].OrdesLate;
                            xlWorkSheet4.Cells[14 + i, "O"] = summariesDeptAdding7Days[i].OTS;
                            xlWorkSheet4.Cells[14 + i, "Q"] = summariesDeptAdding7Days[i].SOMO;
                            xlWorkSheet4.Cells[14 + i, "S"] = summariesDeptAdding7Days[i].DeliveryQuantity;
                            startGroup++;
                        }
                    }
                    double countOrder = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.Orders).Sum();
                    double countEarly = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.OrdesEarly).Sum();
                    double countOntime = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.OrdersOT).Sum();
                    double countLate = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.OrdesLate).Sum();
                    double Reliability = (countEarly + countOntime) / countOrder;
                    double Flexibility = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.Flexibility).Average();
                    double OTS = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.OTS).Average();
                    double reqOTS = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.ReqOTS).Average();
                    double SOMO = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.SOMO).Average();
                    double Quantity = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.DeliveryQuantity).Sum();
                    xlWorkSheet4.Cells[8, "B"] = Reliability;
                    xlWorkSheet4.Cells[8, "D"] = countOrder;
                    xlWorkSheet4.Cells[8, "F"] = countOntime;
                    xlWorkSheet4.Cells[8, "H"] = countEarly;
                    xlWorkSheet4.Cells[8, "J"] = countLate;
                    xlWorkSheet4.Cells[8, "L"] = OTS;
                    xlWorkSheet4.Cells[8, "N"] = SOMO;
                    xlWorkSheet4.Cells[8, "P"] = Quantity;
                    xlWorkSheet4.Cells[4, "B"] = from.ToString("dd-MM-yyyy");
                    xlWorkSheet4.Cells[4, "G"] = to.ToString("dd-MM-yyyy");

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

        public void ExportToReliabilityReportAdding7DaysAddingRawData(string PathTemplate, string pathSaveExcel, List<ReliabilitySummary> summaries, List<ReliabilitySummary> summariesDept, List<ReliabilitySummary> summariesAdding7Days, List<ReliabilitySummary> summariesDeptAdding7Days, List<RawReliability> rawReliabilities, DateTime from, DateTime to)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet; //sheet 2
            Excel.Worksheet xlWorkSheet2; //sheet 2
            Excel.Worksheet xlWorkSheet3; //sheet 2
            Excel.Worksheet xlWorkSheet4; //sheet 2
            Excel.Worksheet xlWorkSheet5; //sheet 2
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

                            xlWorkSheet.Cells[14 + i - startGroup, "A"] = summaries[i].Clients;
                            xlWorkSheet.Cells[14 + i, "B"] = summaries[i].DepartmentCode;
                            xlWorkSheet.Cells[14 + i, "E"] = Math.Round(summaries[i].Reliability, 2);
                            xlWorkSheet.Cells[14 + i, "G"] = summaries[i].Orders;
                            xlWorkSheet.Cells[14 + i, "I"] = summaries[i].OrdersOT;
                            xlWorkSheet.Cells[14 + i, "K"] = summaries[i].OrdesLate;
                            xlWorkSheet.Cells[14 + i, "M"] = summaries[i].OTS;
                            xlWorkSheet.Cells[14 + i, "O"] = summaries[i].SOMO;
                            xlWorkSheet.Cells[14 + i, "Q"] = summaries[i].DeliveryQuantity;
                            xlWorkSheet.Cells[14 + i, "R"] = summaries[i].DeliveryQtyKg;
                            //    xlWorkSheet.Cells[14 + i, "T"] = summaries[i].DeliveryQtyKg;

                            range = xlWorkSheet.Range[xlWorkSheet.Cells[14 + i - startGroup, "A"], xlWorkSheet.Cells[14 + i - 1, "V"]];
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
                            xlWorkSheet.Cells[14 + i, "K"] = summaries[i].OrdesLate;
                            xlWorkSheet.Cells[14 + i, "M"] = summaries[i].OTS;
                            xlWorkSheet.Cells[14 + i, "O"] = summaries[i].SOMO;
                            xlWorkSheet.Cells[14 + i, "Q"] = summaries[i].DeliveryQuantity;
                            xlWorkSheet.Cells[14 + i, "R"] = summaries[i].DeliveryQtyKg;
                            //  xlWorkSheet.Cells[14 + i, "T"] = summaries[i].DeliveryQtyKg;

                            startGroup++;
                        }
                    }

                    double countOrder = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.Orders).Sum();
                    //  double countEarly = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdesEarly).Sum();
                    double countOntime = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdersOT).Sum();
                    double countLate = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdesLate).Sum();
                    double Reliability = (countOntime) / countOrder;
                    double Flexibility = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.Flexibility).Average();
                    double OTS = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.OTS).Average();
                    double reqOTS = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.ReqOTS).Average();
                    double SOMO = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.SOMO).Average();
                    double Quantity = summaries.Where(d => d.DepartmentCode != "Total").Select(d => d.DeliveryQtyKg).Sum();
                    xlWorkSheet.Cells[8, "B"] = Reliability;
                    xlWorkSheet.Cells[8, "D"] = countOrder;
                    xlWorkSheet.Cells[8, "F"] = countOntime;
                    xlWorkSheet.Cells[8, "H"] = countLate;
                    xlWorkSheet.Cells[8, "J"] = OTS;
                    xlWorkSheet.Cells[8, "L"] = SOMO;
                    xlWorkSheet.Cells[8, "N"] = Quantity;
                    // xlWorkSheet.Cells[8, "P"] = Quantity;
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
                            xlWorkSheet2.Cells[14 + i, "K"] = summariesDept[i].OrdesLate;
                            xlWorkSheet2.Cells[14 + i, "M"] = summariesDept[i].OTS;
                            xlWorkSheet2.Cells[14 + i, "O"] = summariesDept[i].SOMO;
                            xlWorkSheet2.Cells[14 + i, "Q"] = summariesDept[i].DeliveryQuantity;
                            xlWorkSheet2.Cells[14 + i, "R"] = summariesDept[i].DeliveryQtyKg;


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
                            xlWorkSheet2.Cells[14 + i, "K"] = summariesDept[i].OrdesLate;
                            xlWorkSheet2.Cells[14 + i, "M"] = summariesDept[i].OTS;
                            xlWorkSheet2.Cells[14 + i, "O"] = summariesDept[i].SOMO;
                            xlWorkSheet2.Cells[14 + i, "Q"] = summariesDept[i].DeliveryQuantity;
                            xlWorkSheet2.Cells[14 + i, "R"] = summariesDept[i].DeliveryQtyKg;

                            startGroup++;
                        }
                    }
                    double countOrder = summariesDept.Where(d => d.Clients != "Total").Select(d => d.Orders).Sum();
                    //   double countEarly = summariesDept.Where(d => d.Clients != "Total").Select(d => d.OrdesEarly).Sum();
                    double countOntime = summariesDept.Where(d => d.Clients != "Total").Select(d => d.OrdersOT).Sum();
                    double countLate = summariesDept.Where(d => d.Clients != "Total").Select(d => d.OrdesLate).Sum();
                    double Reliability = (countOntime) / countOrder;
                    double Flexibility = summariesDept.Where(d => d.Clients != "Total").Select(d => d.Flexibility).Average();
                    double OTS = summariesDept.Where(d => d.Clients != "Total").Select(d => d.OTS).Average();
                    double reqOTS = summariesDept.Where(d => d.Clients != "Total").Select(d => d.ReqOTS).Average();
                    double SOMO = summariesDept.Where(d => d.Clients != "Total").Select(d => d.SOMO).Average();
                    double Quantity = summariesDept.Where(d => d.Clients != "Total").Select(d => d.DeliveryQtyKg).Sum();
                    xlWorkSheet2.Cells[8, "B"] = Reliability;
                    xlWorkSheet2.Cells[8, "D"] = countOrder;
                    xlWorkSheet2.Cells[8, "F"] = countOntime;
                    xlWorkSheet2.Cells[8, "H"] = countLate;
                    xlWorkSheet2.Cells[8, "J"] = OTS;
                    xlWorkSheet2.Cells[8, "L"] = SOMO;
                    xlWorkSheet2.Cells[8, "N"] = Quantity;
                    //  xlWorkSheet2.Cells[8, "P"] = Quantity;
                    xlWorkSheet2.Cells[4, "B"] = from.ToString("dd-MM-yyyy");
                    xlWorkSheet2.Cells[4, "G"] = to.ToString("dd-MM-yyyy");

                    // xlWorkSheet22.Name = date;
                }
                #endregion


                #region Sheet 3
                //Add data in Sheet 1

                xlWorkSheet3 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(3); //add data sheet1  
                                                                                   //xlWorkSheet.Cells[6, 1] = "BackLog Report on " + DateTime.Now.ToString("MMM/dd/yyyy"); //Line
                string strWorksheetName3 = xlWorkSheet3.Name;//Get the name of worksheet.

                if (strWorksheetName3 == "Client (+7Days)")
                {//Fill ngay thang nam                                                                //xlWorkSheet.Cells[2, 11] = usersend; //Model
                 //xlWorkSheet.Cells[1, 11] = dateupdate; //Line
                    string date = DateTime.Now.ToString("dd-MM-yyyy");
                    int startGroup = 0;
                    for (int i = 0; i < summariesAdding7Days.Count; i++)
                    {
                        if (summariesAdding7Days[i].DepartmentCode == "Total")
                        {

                            range = xlWorkSheet3.Range[xlWorkSheet3.Cells[14 + i - startGroup, "A"], xlWorkSheet3.Cells[14 + i, "A"]];

                            range.Merge();

                            xlWorkSheet3.Cells[14 + i - startGroup, "A"] = summariesAdding7Days[i].Clients;
                            xlWorkSheet3.Cells[14 + i, "B"] = summariesAdding7Days[i].DepartmentCode;
                            xlWorkSheet3.Cells[14 + i, "E"] = Math.Round(summariesAdding7Days[i].Reliability, 2);
                            xlWorkSheet3.Cells[14 + i, "G"] = summariesAdding7Days[i].Orders;
                            xlWorkSheet3.Cells[14 + i, "I"] = summariesAdding7Days[i].OrdersOT;
                            xlWorkSheet3.Cells[14 + i, "K"] = summariesAdding7Days[i].OrdesLate;
                            xlWorkSheet3.Cells[14 + i, "M"] = summariesAdding7Days[i].OTS;
                            xlWorkSheet3.Cells[14 + i, "O"] = summariesAdding7Days[i].SOMO;
                            xlWorkSheet3.Cells[14 + i, "Q"] = summariesAdding7Days[i].DeliveryQuantity;
                            xlWorkSheet3.Cells[14 + i, "R"] = summariesAdding7Days[i].DeliveryQtyKg;


                            range = xlWorkSheet3.Range[xlWorkSheet3.Cells[14 + i - startGroup, "A"], xlWorkSheet3.Cells[14 + i - 1, "V"]];
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



                            xlWorkSheet3.Cells[14 + i, "B"] = summariesAdding7Days[i].DepartmentCode;
                            xlWorkSheet3.Cells[14 + i, "E"] = Math.Round(summariesAdding7Days[i].Reliability, 2);
                            xlWorkSheet3.Cells[14 + i, "G"] = summariesAdding7Days[i].Orders;
                            xlWorkSheet3.Cells[14 + i, "I"] = summariesAdding7Days[i].OrdersOT;
                            xlWorkSheet3.Cells[14 + i, "K"] = summariesAdding7Days[i].OrdesLate;
                            xlWorkSheet3.Cells[14 + i, "M"] = summariesAdding7Days[i].OTS;
                            xlWorkSheet3.Cells[14 + i, "O"] = summariesAdding7Days[i].SOMO;
                            xlWorkSheet3.Cells[14 + i, "Q"] = summariesAdding7Days[i].DeliveryQuantity;
                            xlWorkSheet3.Cells[14 + i, "R"] = summariesAdding7Days[i].DeliveryQtyKg;


                            startGroup++;
                        }
                    }

                    double countOrder = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.Orders).Sum();
                    //   double countEarly = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdesEarly).Sum();
                    double countOntime = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdersOT).Sum();
                    double countLate = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.OrdesLate).Sum();
                    double Reliability = (countOntime) / countOrder;
                    double Flexibility = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.Flexibility).Average();
                    double OTS = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.OTS).Average();
                    double reqOTS = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.ReqOTS).Average();
                    double SOMO = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.SOMO).Average();
                    double Quantity = summariesAdding7Days.Where(d => d.DepartmentCode != "Total").Select(d => d.DeliveryQtyKg).Sum();
                    xlWorkSheet3.Cells[8, "B"] = Reliability;
                    xlWorkSheet3.Cells[8, "D"] = countOrder;
                    xlWorkSheet3.Cells[8, "F"] = countOntime;
                    xlWorkSheet3.Cells[8, "H"] = countLate;
                    xlWorkSheet3.Cells[8, "J"] = OTS;
                    xlWorkSheet3.Cells[8, "L"] = SOMO;
                    xlWorkSheet3.Cells[8, "N"] = Quantity;

                    xlWorkSheet3.Cells[4, "B"] = from.ToString("dd-MM-yyyy");
                    xlWorkSheet3.Cells[4, "G"] = to.ToString("dd-MM-yyyy");

                    //         xlWorkSheet.Name = date;


                }

                #endregion

                #region Sheet 4
                //Add data in Sheet 1

                xlWorkSheet4 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(4); //add data sheet1  
                                                                                   //xlWorkSheet4.Cells[6, 1] = "BackLog Report on " + DateTime.Now.ToString("MMM/dd/yyyy"); //Line
                string strWorksheetName4 = xlWorkSheet4.Name;//Get the name of worksheet.

                if (strWorksheetName4 == "Dept (+7days)")
                {//Fill ngay thang nam                                                                //xlWorkSheet22.Cells[2, 11] = usersend; //Model
                 //xlWorkSheet22.Cells[1, 11] = dateupdate; //Line
                    int startGroup = 0;
                    string date = DateTime.Now.ToString("dd-MM-yyyy");
                    for (int i = 0; i < summariesDept.Count; i++)
                    {
                        if (summariesDeptAdding7Days[i].Clients == "Total")
                        {
                            range = xlWorkSheet4.Range[xlWorkSheet4.Cells[14 + i - startGroup, "A"], xlWorkSheet4.Cells[14 + i, "A"]];
                            range.Merge();
                            // range.Group();
                            xlWorkSheet4.Cells[14 + i - startGroup, "A"] = summariesDeptAdding7Days[i].DepartmentCode;
                            xlWorkSheet4.Cells[14 + i, "B"] = summariesDeptAdding7Days[i].Clients;
                            xlWorkSheet4.Cells[14 + i, "E"] = Math.Round(summariesDeptAdding7Days[i].Reliability, 2);
                            xlWorkSheet4.Cells[14 + i, "G"] = summariesDeptAdding7Days[i].Orders;
                            xlWorkSheet4.Cells[14 + i, "I"] = summariesDeptAdding7Days[i].OrdersOT;
                            xlWorkSheet4.Cells[14 + i, "K"] = summariesDeptAdding7Days[i].OrdesLate;
                            xlWorkSheet4.Cells[14 + i, "M"] = summariesDeptAdding7Days[i].OTS;
                            xlWorkSheet4.Cells[14 + i, "O"] = summariesDeptAdding7Days[i].SOMO;
                            xlWorkSheet4.Cells[14 + i, "Q"] = summariesDeptAdding7Days[i].DeliveryQuantity;
                            xlWorkSheet4.Cells[14 + i, "R"] = summariesDeptAdding7Days[i].DeliveryQtyKg;


                            range = xlWorkSheet4.Range[xlWorkSheet4.Cells[14 + i - startGroup, "A"], xlWorkSheet4.Cells[14 + i - 1, "V"]];
                            range.Rows.OutlineLevel = 1;
                            range.Rows.Group(misValue, misValue, misValue, misValue);
                            range.Rows.Hidden = true;
                            startGroup = 0;
                        }
                        else
                        {
                            xlWorkSheet4.Cells[14 + i, "B"] = summariesDeptAdding7Days[i].Clients;
                            //     xlWorkSheet4.Cells[14 + i, "A"] = summariesDeptAdding7Days[i].DepartmentCode;
                            xlWorkSheet4.Cells[14 + i, "E"] = Math.Round(summariesDeptAdding7Days[i].Reliability, 2);
                            xlWorkSheet4.Cells[14 + i, "G"] = summariesDeptAdding7Days[i].Orders;
                            xlWorkSheet4.Cells[14 + i, "I"] = summariesDeptAdding7Days[i].OrdersOT;
                            xlWorkSheet4.Cells[14 + i, "K"] = summariesDeptAdding7Days[i].OrdesLate;
                            xlWorkSheet4.Cells[14 + i, "M"] = summariesDeptAdding7Days[i].OTS;
                            xlWorkSheet4.Cells[14 + i, "O"] = summariesDeptAdding7Days[i].SOMO;
                            xlWorkSheet4.Cells[14 + i, "Q"] = summariesDeptAdding7Days[i].DeliveryQuantity;
                            xlWorkSheet4.Cells[14 + i, "R"] = summariesDeptAdding7Days[i].DeliveryQtyKg;

                            startGroup++;
                        }
                    }
                    double countOrder = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.Orders).Sum();
                    //   double countEarly = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.OrdesEarly).Sum();
                    double countOntime = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.OrdersOT).Sum();
                    double countLate = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.OrdesLate).Sum();
                    double Reliability = (countOntime) / countOrder;
                    double Flexibility = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.Flexibility).Average();
                    double OTS = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.OTS).Average();
                    double reqOTS = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.ReqOTS).Average();
                    double SOMO = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.SOMO).Average();
                    double Quantity = summariesDeptAdding7Days.Where(d => d.Clients != "Total").Select(d => d.DeliveryQtyKg).Sum();
                    xlWorkSheet4.Cells[8, "B"] = Reliability;
                    xlWorkSheet4.Cells[8, "D"] = countOrder;
                    xlWorkSheet4.Cells[8, "F"] = countOntime;
                    xlWorkSheet4.Cells[8, "H"] = countLate;
                    xlWorkSheet4.Cells[8, "J"] = OTS;
                    xlWorkSheet4.Cells[8, "L"] = SOMO;
                    xlWorkSheet4.Cells[8, "N"] = Quantity;

                    xlWorkSheet4.Cells[4, "B"] = from.ToString("dd-MM-yyyy");
                    xlWorkSheet4.Cells[4, "G"] = to.ToString("dd-MM-yyyy");

                    // xlWorkSheet22.Name = date;
                }
                #endregion

                #region Sheet 5
                //Add data in Sheet 1

                xlWorkSheet5 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(5); //add data sheet1  
                                                                                   //xlWorkSheet4.Cells[6, 1] = "BackLog Report on " + DateTime.Now.ToString("MMM/dd/yyyy"); //Line
                string strWorksheetName5 = xlWorkSheet5.Name;//Get the name of worksheet.

                if (strWorksheetName5 == "Raw Data")
                {//Fill ngay thang nam 


                    xlWorkSheet5.Cells[1, 1] = "Order No";
                    //   xlWorkSheet5.Cells.Width = 100;
                    xlWorkSheet5.Cells[1, 2] = "Department";
                    xlWorkSheet5.Cells[1, 3] = "Clients";
                    xlWorkSheet5.Cells[1, 4] = "Clients-End";
                    xlWorkSheet5.Cells[1, 5] = "Clients Code";
                    xlWorkSheet5.Cells[1, 6] = "Production Code";
                    xlWorkSheet5.Cells[1, 7] = "Order Status";
                    xlWorkSheet5.Cells[1, 8] = "Order Quantity (pcs)";
                    xlWorkSheet5.Cells[1, 9] = "Delivery Quantity (pcs)";
                    xlWorkSheet5.Cells[1, 10] = "Delivery Quantity (Kg)";
                    xlWorkSheet5.Cells[1, 11] = "Date of Order";
                    xlWorkSheet5.Cells[1, 12] = "Client Request Date";
                    xlWorkSheet5.Cells[1, 13] = "Delivery Date";
                    xlWorkSheet5.Cells[1, 14] = "Manufacture Order";
                    xlWorkSheet5.Cells[1, 15] = "Production Completed";
                    xlWorkSheet5.Cells[1, 16] = "Evaluation";
                    xlWorkSheet5.Cells[1, 17] = "Evaluation(+7 Days)";
                    xlWorkSheet5.Cells[1, 18] = "OTS";
                    xlWorkSheet5.Cells[1, 19] = "ReqOTS";
                    xlWorkSheet5.Cells[1, 20] = "SOMO";

                    for (int i = 0; i <= rawReliabilities.Count - 1; i++)
                    {

                        xlWorkSheet5.Cells[i + 2, 1] = rawReliabilities[i].orderCode + "-" + rawReliabilities[i].orderNo;
                        xlWorkSheet5.Cells[i + 2, 2] = rawReliabilities[i].DepartmentCode;
                        xlWorkSheet5.Cells[i + 2, 3] = rawReliabilities[i].Clients;
                        xlWorkSheet5.Cells[i + 2, 4] = rawReliabilities[i].ClientsEnd;
                        xlWorkSheet5.Cells[i + 2, 5] = rawReliabilities[i].ClientsCode;
                        xlWorkSheet5.Cells[i + 2, 6] = rawReliabilities[i].ProductionCode;
                        xlWorkSheet5.Cells[i + 2, 7] = rawReliabilities[i].OrderSatus;
                        xlWorkSheet5.Cells[i + 2, 8] = rawReliabilities[i].OrderQuantity;
                        xlWorkSheet5.Cells[i + 2, 9] = rawReliabilities[i].DeliveryQuantity;
                        xlWorkSheet5.Cells[i + 2, 10] = rawReliabilities[i].QtyToWeight;
                        xlWorkSheet5.Cells[i + 2, 11] = rawReliabilities[i].DateofOrder;
                        xlWorkSheet5.Cells[i + 2, 12] = rawReliabilities[i].ClientRequestDate;
                        xlWorkSheet5.Cells[i + 2, 13] = rawReliabilities[i].DeliveryDate;
                        xlWorkSheet5.Cells[i + 2, 14] = rawReliabilities[i].ManufactureOrder;
                        xlWorkSheet5.Cells[i + 2, 15] = rawReliabilities[i].ProductionCompleted;
                        xlWorkSheet5.Cells[i + 2, 16] = rawReliabilities[i].Evaluation;
                        xlWorkSheet5.Cells[i + 2, 17] = rawReliabilities[i].Evaluation7Days;
                        xlWorkSheet5.Cells[i + 2, 18] = rawReliabilities[i].OTS;
                        xlWorkSheet5.Cells[i + 2, 19] = rawReliabilities[i].ReqOTS;
                        xlWorkSheet5.Cells[i + 2, 20] = rawReliabilities[i].SOMO;


                    }
                }

                #endregion


                xlWorkBook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();
                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkSheet2);
                reOject(xlWorkSheet3);
                reOject(xlWorkSheet4);
                reOject(xlWorkSheet5);
                reOject(xlApp);

            }
            catch (Exception ex)
            {
                // Logfile.Output(StatusLog.Error, "ExportToReliabilityReport : An error happened in the process.", ex.Message);

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
        public void ExportToTemplateMQCDefectDaily(string PathTemplate, string pathSaveExcel,List<string> listHeaderRw25, List<DefectRateData> defectRates, DateTime From, DateTime To)
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

                    for (int j = 0; j <defectRates[i].ReworkItems.Count ; j++)
                    {
                        for (int k = 0; k < 16; k++)
                        {
                            if (defectRates[i].ReworkItems[j].DefectSFTName ==(string) xlWorkSheet.Cells[3, 47 + k].Value2.ToString())
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
                  Logfile.Output(StatusLog.Error, "ExportToTemplateMQCDefectDaily : An error happened in the process.", ex.Message);

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
                    xlWorkSheet.Cells[6, 25] = defectRate.ReworkQuantity;
                    xlWorkSheet.Cells[6, 26] = defectRate.DefectRate;
                    xlWorkSheet.Cells[6, 27] = defectRate.ReworkRate;
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
