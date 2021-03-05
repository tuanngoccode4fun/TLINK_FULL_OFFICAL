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
using WindowsFormsApplication1.HRProject.InOutData.Model;

using WindowsFormsApplication1.MQC;
using WindowsFormsApplication1.Planning;
using WindowsFormsApplication1.Report.Backlog;
using WindowsFormsApplication1.Report.Reliability;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1.Class
{
    public class ToolSupport
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
                MessageBox.Show(ex.ToString());
            }

        }
        public void editexcelshipping(string dateupdate, string usersend, string version, string year, DataGridView dgv, string pathSaveExcel, string PathTemplate)
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

                xlWorkSheet.Cells[1, 10] = dateupdate; //Line
                xlWorkSheet.Cells[2, 10] = usersend; //Model
                xlWorkSheet.Cells[3, 10] = version; //User  
                xlWorkSheet.Cells[4, 10] = year; //User   

                //datagridw
                for (int i = 0; i <= dgv.Rows.Count - 1; i++) //dong
                {
                    for (int j = 0; j <= dgv.Columns.Count - 1; j++) //cot
                    {
                        DataGridViewCell cell = dgv[j, i]; //cot roi dong
                        xlWorkSheet.Cells[i + 11, j + 1] = cell.Value; // dong roi cot
                    }
                }
                #endregion

                xlWorkBook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                MessageBox.Show("Excel file created, you can find in the folder " + pathSaveExcel, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Workbooks.Open(pathSaveExcel);
                xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error happened in the process.");
                throw new Exception("ExportToExcel: \n" + ex.Message);
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
                        xlworsheet.Cells[i + 2, j + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Gray);
                    }
                }
                xlworkbook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlworkbook.Close(true, misValue, misValue);
                xlapp.Quit();
                reOject(xlworsheet);
                reOject(xlworkbook);
                reOject(xlapp);
                MessageBox.Show("Export to excel sucessful !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Export to excel fail: " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void ExportToTemplate(string PathTemplate, string pathSaveExcel, DataGridView dgvBackLog)
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
                                                                                  //xlWorkSheet.Cells[1, 11] = dateupdate; //Line
                                                                                  //Fill ngay thang nam                                                                //xlWorkSheet.Cells[2, 11] = usersend; //Model
                string date = DateTime.Now.ToString("dd");                                                            //xlWorkSheet.Cells[3, 11] = version; //User  
                xlWorkSheet.Cells[2, 27] = DateTime.Now.ToString("dd");
                xlWorkSheet.Cells[2, 29] = DateTime.Now.ToString("MM");
                xlWorkSheet.Cells[2, 31] = DateTime.Now.ToString("MM");
                //for (int i = 3; i < dgvBackLog.Columns.Count-4; i++)
                //{

                //    xlWorkSheet.Cells[3, i+1] = dgvBackLog.Columns[i].HeaderText;

                //}

                //datagridw

                for (int i = 0; i <= dgvBackLog.Rows.Count - 1; i++) //dong
                {
                    for (int j = 0; j <= dgvBackLog.Columns.Count - 1; j++) //cot
                    {
                        DataGridViewCell cell = dgvBackLog[j, i]; //cot roi dong
                        xlWorkSheet.Cells[i + 5, j + 1] = cell.Value; // dong roi cot
                    }
                }

                #endregion

                xlWorkBook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();
                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkBook);
                reOject(xlApp);


                //   MessageBox.Show("Excel file created, you can find in the folder " + pathSaveExcel, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //xlWorkBook.Close(true, misValue, misValue);
                //xlApp.Workbooks.Open(pathSaveExcel);
                //xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error happened in the process.");
                throw new Exception("ExportToExcel: \n" + ex.Message);
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
                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkBook);
                reOject(xlApp);


                //   MessageBox.Show("Excel file created, you can find in the folder " + pathSaveExcel, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //xlWorkBook.Close(true, misValue, misValue);
                //xlApp.Workbooks.Open(pathSaveExcel);
                //xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error happened in the process.");
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
        public void ExportToTemplateTop5Defect(string PathTemplate, string pathSaveExcel, MQCItemSummary qCItemSummary)
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
                    string date =  qCItemSummary.Time_from;
                    xlWorkSheet.Cells[3, 10] = date;//xlWorkSheet.Cells[3, 11] = version; //User  
                    xlWorkSheet.Cells[4, 2] = qCItemSummary.QuantityTotal;
                    xlWorkSheet.Cells[4, 6] = qCItemSummary.NGQty;
                    xlWorkSheet.Cells[17, 2] = date;
                    double countDefect = 0;
                    var defectOrder = qCItemSummary.defectItems.Where(d=>d.DefectCode != "NG31").OrderByDescending(d => d.Quantity).ToList();
                    //   xlWorkSheet.Cells[2, 31] = DateTime.Now.ToString("MM");
                    for (int i = 0; i < 5; i++)
                    {
                           xlWorkSheet.Cells[5, 2 + i] = defectOrder[i].DefectSFTName;
                           xlWorkSheet.Cells[7, 2 + i] = defectOrder[i].Quantity;
                            countDefect += defectOrder[i].Quantity;
                        
                    }
                    xlWorkSheet.Cells[7, 7] = qCItemSummary.NGQty - countDefect;
                }
                #endregion

                xlWorkBook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();



                //   MessageBox.Show("Excel file created, you can find in the folder " + pathSaveExcel, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //xlWorkBook.Close(true, misValue, misValue);
                //xlApp.Workbooks.Open(pathSaveExcel);
                //xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error happened in the process.");
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
        public void ExportToTemplateMQCDefectDaily(string PathTemplate, string pathSaveExcel, List<DefectRateData> defectRates, DateTime From, DateTime To)
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
                xlWorkSheet.Cells[1, "C"] = "MQC Report from [" + From.ToString("dd/MMM/yyyy HH:mm") + "] To [" + To.ToString("dd/MMM/yyyy HH:mm")+ "]";

                if (strWorksheetName == "Daily")
                {//Fill ngay thang nam                                                                //xlWorkSheet.Cells[2, 11] = usersend; //Model
                 //xlWorkSheet.Cells[1, 11] = dateupdate; //Line
                    string date = DateTime.Now.ToString("dd-MM-yyyy");
                    for (int i = 0; i < defectRates.Count; i++)
                    {
                        double countDefect = 0;
                        xlWorkSheet.Cells[4 + i, "A"] = defectRates[i].Line;//xlWorkSheet.Cells[3, 11] = version; //User  
                        xlWorkSheet.Cells[4 + i, "B"] = defectRates[i].DateTime_from + "-" + defectRates[i].DateTime_to;//xlWorkSheet.Cells[3, 11] = version; //User  
                        xlWorkSheet.Cells[4 + i, "C"] = defectRates[i].Product;//xlWorkSheet.Cells[3, 11] = version; //User  
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
                                xlWorkSheet.Cells[4 + i, 18 + j] = defectRates[i].defectItems[j].Quantity;
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
                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkBook);
                reOject(xlApp);



            }
            catch (Exception ex)
            {
              //  SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportToTemplateMQCDefectDaily : An error happened in the process.", ex.Message);

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
                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkBook);
                reOject(xlApp);


                //   MessageBox.Show("Excel file created, you can find in the folder " + pathSaveExcel, "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //xlWorkBook.Close(true, misValue, misValue);
                //xlApp.Workbooks.Open(pathSaveExcel);
                //xlApp.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error happened in the process.");
                throw new Exception("ExportToExcel: \n" + ex.Message);
            }
        }
        public void ExportProductionPlan(DataGridView dataGrid,Dictionary<string, PlanningItem> keyValuePairs, string PathSave)
        {
            string Template = Environment.CurrentDirectory + @"\Resources\productionPlan_form_ver1.xlsx";
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(Template, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                #region Sheet 1
                //Add data in Sheet 1

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                string strWorksheetName = xlWorkSheet.Name;//Get the name of worksheet.   
                List<ShipmentPlan> listShipmentPlan = new List<ShipmentPlan>();
                xlWorkSheet.Cells[1, 1] = "PRODUCTION PLANNING ON " + DateTime.Now.ToString("dd-MMM-yyyy");

                foreach (var productItems in keyValuePairs)
                {
                    foreach (var Request in productItems.Value.shipmentPlans)
                    {
                        listShipmentPlan.Add(Request);
                    }
                }
                var listDate = listShipmentPlan.OrderBy(d => d.ClientRequestDate).Select(d => d.ClientRequestDate).ToList().Distinct();
                int CountRow = 0;
                Dictionary<DateTime, int> DicDateTimePosition = new Dictionary<DateTime, int>();
                foreach (var item in listDate)
                {
                    range = xlWorkSheet.Range[xlWorkSheet.Cells[3, 22 + CountRow], xlWorkSheet.Cells[3, 22 + CountRow + 3]];
                    DicDateTimePosition.Add(item, 22 + CountRow);
                    range.Merge();

                    xlWorkSheet.Cells[3, 22 + CountRow] = item.ToString("dd-MM-yyyy");
                    xlWorkSheet.Cells[4, 22 + CountRow] = "Order Quantity";
                    xlWorkSheet.Cells[4, 22 + CountRow + 1] = "Shortage Quantity";
                    xlWorkSheet.Cells[4, 22 + CountRow + 2] = "Days Remain";
                    xlWorkSheet.Cells[4, 22 + CountRow + 3] = "PRODUCTION PER DAY";
                    CountRow = CountRow + 4;
                }
                {//Fill ngay thang nam                                                            
                    int count = 5;
                    foreach (var product in keyValuePairs)
                    {
                        xlWorkSheet.Cells[count, "A"] = product.Value.KeyProduct;
                        xlWorkSheet.Cells[count, "B"] = product.Value.Client;
                        xlWorkSheet.Cells[count, "C"] = product.Value.shipmentPlans.Count();
                        xlWorkSheet.Cells[count, "D"] = product.Value.shipmentPlans.Select(d => d.DeliveryPlanQty).Sum();
                        xlWorkSheet.Cells[count, "E"] = product.Value.wip.Warehouse;
                        xlWorkSheet.Cells[count, "F"] = product.Value.wip.TotalInWip;
                        xlWorkSheet.Cells[count, "G"] = product.Value.TotalShortage;
                        xlWorkSheet.Cells[count, "H"] = product.Value.wip.MQCQty;
                        xlWorkSheet.Cells[count, "I"] = product.Value.wip.PQCQty;
                        xlWorkSheet.Cells[count, "J"] = product.Value.wip.StockInWHQTy;
                        xlWorkSheet.Cells[count, "K"] = product.Value.wip.SemiFinished;
                        xlWorkSheet.Cells[count, "L"] = product.Value._bom.HEN;
                        xlWorkSheet.Cells[count, "M"] = product.Value._bom.HENStock;
                        xlWorkSheet.Cells[count, "N"] = product.Value._bom.QtyUnit;
                        xlWorkSheet.Cells[count, "O"] = product.Value._bom.ToolQty;
                        xlWorkSheet.Cells[count, "P"] = product.Value.production.targetShiftA;
                        xlWorkSheet.Cells[count, "Q"] = product.Value.production.targetShiftB;
                        xlWorkSheet.Cells[count, "R"] = product.Value.production.QtyOld;
                        xlWorkSheet.Cells[count, "S"] = product.Value.production.ProductionQty;
                        xlWorkSheet.Cells[count, "T"] = product.Value.production.PeopleQty;
                        xlWorkSheet.Cells[count, "U"] = product.Value.production.targetPeople;

                        foreach (var item in product.Value.shipmentPlans)
                        {
                            int beginWrite = DicDateTimePosition[item.ClientRequestDate];
                            xlWorkSheet.Cells[count, beginWrite] = item.DeliveryPlanQty;
                            xlWorkSheet.Cells[count, beginWrite + 1] = item.NeedQty;
                            xlWorkSheet.Cells[count, beginWrite + 2] = item.RemainDay;
                            xlWorkSheet.Cells[count, beginWrite + 3] = item.NeedQtyPerDay;

                        }
                        count++;
                    }

                    range = xlWorkSheet.Range[xlWorkSheet.Cells[3, 1], xlWorkSheet.Cells[count - 1, 22 + CountRow - 1]];
                    range.Cells.BorderAround2(Missing.Value, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, ColorTranslator.ToOle(Color.FromArgb(255, 192, 0)));
                    range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    range.Borders.Weight = Excel.XlBorderWeight.xlMedium;

                }
                #endregion

                xlWorkBook.SaveAs(PathSave, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();
                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkBook);
                reOject(xlApp);
            }
            catch (Exception)
            {

                throw;
            }

        }
        public void ExportProductionPlan(string language ,Dictionary<string, PlanningItem> keyValuePairs, string PathSave )
        {
            string Template = "";
            if (language =="TiengViet")
           Template =   Environment.CurrentDirectory + @"\Resources\productionPlan_TiengViet.xlsx";
                                                                    
            else if (language =="English")
                Template = Environment.CurrentDirectory + @"\Resources\productionPlan_form_ver1.xlsx";
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(Template, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                #region Sheet 1
                //Add data in Sheet 1

                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);  
                                                                                 
                string strWorksheetName = xlWorkSheet.Name;//Get the name of worksheet.   
                List<ShipmentPlan> listShipmentPlan= new List<ShipmentPlan>();
                if (language == "TiengViet")
                    xlWorkSheet.Cells[1, 1] = "KE HOACH SAN XUAT NGAY " + DateTime.Now.ToString("dd-MMM-yyyy");
                else if (language == "English")
                    xlWorkSheet.Cells[1, 1] = "PRODUCTION PLANNING ON " + DateTime.Now.ToString("dd-MMM-yyyy");
                foreach (var productItems in keyValuePairs)
                {
                    foreach (var Request in productItems.Value.shipmentPlans)
                    {
                        listShipmentPlan.Add(Request);
                    }
                }
                var listDate = listShipmentPlan.OrderBy(d=>d.ClientRequestDate).Select(d => d.ClientRequestDate).ToList().Distinct();
                int CountRow = 0;
                Dictionary<DateTime, int> DicDateTimePosition = new Dictionary<DateTime, int>();
                foreach (var item in listDate)
                {
                    range = xlWorkSheet.Range[xlWorkSheet.Cells[3, 22 + CountRow], xlWorkSheet.Cells[3, 22 + CountRow + 3]];
                    DicDateTimePosition.Add(item, 22 + CountRow);
                    range.Merge();
                  
                    xlWorkSheet.Cells[3, 22 + CountRow] = item.ToString("dd-MM-yyyy");
                    if (language == "TiengViet")
                    {
                        xlWorkSheet.Cells[4, 22 + CountRow] = "SL DAT HANG";
                        xlWorkSheet.Cells[4, 22 + CountRow + 1] = "SL THIEU HUT";
                        xlWorkSheet.Cells[4, 22 + CountRow + 2] = "SO NGAY CON LAI";
                        xlWorkSheet.Cells[4, 22 + CountRow + 3] = "SAN LUONG MOI NGAY";
                    }
                    else if ( language == "English")
                    {
                        xlWorkSheet.Cells[4, 22 + CountRow] = "Order Quantity";
                        xlWorkSheet.Cells[4, 22 + CountRow + 1] = "Shortage Quantity";
                        xlWorkSheet.Cells[4, 22 + CountRow + 2] = "Days Remain";
                        xlWorkSheet.Cells[4, 22 + CountRow + 3] = "PRODUCTION PER DAY";
                    }
                    CountRow = CountRow + 4;
                }
                {//Fill ngay thang nam                                                            
                    int count = 5;
                    foreach (var product in keyValuePairs)
                    {
                        xlWorkSheet.Cells[count, "A"] = product.Value.KeyProduct;
                        xlWorkSheet.Cells[count, "B"] = product.Value.Client;
                        xlWorkSheet.Cells[count, "C"] = product.Value.shipmentPlans.Count();
                        xlWorkSheet.Cells[count, "D"] = product.Value.shipmentPlans.Select(d=>d.DeliveryPlanQty).Sum();
                        xlWorkSheet.Cells[count, "E"] = product.Value.wip.Warehouse;
                        xlWorkSheet.Cells[count, "F"] = product.Value.wip.TotalInWip;
                        xlWorkSheet.Cells[count, "G"] = product.Value.TotalShortage;
                        xlWorkSheet.Cells[count, "H"] = product.Value.wip.MQCQty;
                        xlWorkSheet.Cells[count, "I"] = product.Value.wip.PQCQty;
                        xlWorkSheet.Cells[count, "J"] = product.Value.wip.StockInWHQTy;
                        xlWorkSheet.Cells[count, "K"] = product.Value.wip.SemiFinished;
                        xlWorkSheet.Cells[count, "L"] = product.Value._bom.HEN;
                        xlWorkSheet.Cells[count, "M"] = product.Value._bom.HENStock;
                        xlWorkSheet.Cells[count, "N"] = product.Value._bom.QtyUnit;
                        xlWorkSheet.Cells[count, "O"] = product.Value._bom.ToolQty;
                        xlWorkSheet.Cells[count, "P"] = product.Value.production.targetShiftA;
                        xlWorkSheet.Cells[count, "Q"] = product.Value.production.targetShiftB;                     
                        xlWorkSheet.Cells[count, "R"] = product.Value.production.QtyOld;
                        xlWorkSheet.Cells[count, "S"] = product.Value.production.ProductionQty;
                        xlWorkSheet.Cells[count, "T"] = product.Value.production.PeopleQty;
                        xlWorkSheet.Cells[count, "U"] = product.Value.production.targetPeople;
                       
                        foreach (var item in product.Value.shipmentPlans)
                        {
                            int beginWrite = DicDateTimePosition[item.ClientRequestDate];
                            xlWorkSheet.Cells[count, beginWrite] = item.DeliveryPlanQty;
                            xlWorkSheet.Cells[count, beginWrite+1] = item.NeedQty;
                            xlWorkSheet.Cells[count, beginWrite+2] = item.RemainDay;
                            xlWorkSheet.Cells[count, beginWrite+3] = item.NeedQtyPerDay;

                        }
                        count++;
                    }

                    range = xlWorkSheet.Range[xlWorkSheet.Cells[3, 1], xlWorkSheet.Cells[count-1, 22 + CountRow-1 ]];
                    range.Cells.BorderAround2(Missing.Value, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, ColorTranslator.ToOle(Color.FromArgb(255, 192, 0)));
                    range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    range.Borders.Weight = Excel.XlBorderWeight.xlMedium;
                   
                }
                #endregion

                xlWorkBook.SaveAs(PathSave, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();
                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkBook);
                reOject(xlApp);


            }
            catch (Exception)
            {

                throw;
            }

        }
        public DataTable ReadExcel(string fileName, string fileExt)
        {
            string conn = string.Empty;
            DataTable dtexcel = new DataTable();
            if (fileExt.CompareTo(".xls") == 0)
                conn = @"provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + fileName + ";Extended Properties='Excel 8.0;HRD=Yes;IMEX=1';"; //for below excel 2007  
            else
                conn = @"Provider = Microsoft.ACE.OLEDB.12.0; Data Source = " + fileName + "; Extended Properties = 'Excel 12.0 XML;HDR=YES;'; "; //for above excel 2007  
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                try
                {
                    OleDbDataAdapter oleAdpt = new OleDbDataAdapter("select * from [Sheet1$]", con); //here we read data from sheet1  
                    oleAdpt.Fill(dtexcel); //fill excel data into dataTable  
                }
                catch { }
            }
            return dtexcel;
        }

        public DataTable ReadexcelToDatatable (string fileName, string filelink)
        {
            DataTable dt = new DataTable();
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                Excel.Range range;

                object misValue = System.Reflection.Missing.Value;
                try
                {
                    xlApp = new Excel.Application();
                    xlWorkBook = xlApp.Workbooks.Open(filelink, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                    
                    //Add data in Sheet 1

                    xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

                    string strWorksheetName = xlWorkSheet.Name;//Get the name of worksheet.  
                    string test =(string) xlWorkSheet.Cells[1, "A"].Value.ToString();
                  
                    dt.Columns.Add(xlWorkSheet.Cells[1, "A"].Value.ToString());
                    dt.Columns.Add(xlWorkSheet.Cells[1, "B"].Value.ToString());
                    dt.Columns.Add(xlWorkSheet.Cells[1, "C"].Value.ToString());
                    dt.Columns.Add(xlWorkSheet.Cells[1, "D"].Value.ToString());
                    dt.Columns.Add(xlWorkSheet.Cells[1, "E"].Value.ToString());
                    DataRow dr = null;
                    Excel.Range lastCell = xlWorkSheet.Cells.SpecialCells(Excel.XlCellType.xlCellTypeLastCell, Type.Missing);
                    for (int i = 2; i <= lastCell.Row; i++)
                    {
                        dr = dt.NewRow();
                        if (xlWorkSheet.Cells[i, "A"].Value.ToString() != "")
                        {
                            dr[xlWorkSheet.Cells[1, "A"].Value.ToString()] = xlWorkSheet.Cells[i, "A"].Value.ToString();
                            dr[xlWorkSheet.Cells[1, "B"].Value.ToString()] = xlWorkSheet.Cells[i, "B"].Value.ToString();
                            dr[xlWorkSheet.Cells[1, "C"].Value.ToString()] = xlWorkSheet.Cells[i, "C"].Value.ToString();
                            dr[xlWorkSheet.Cells[1, "D"].Value.ToString()] = xlWorkSheet.Cells[i, "D"].Value.ToString();
                            dr[xlWorkSheet.Cells[1, "E"].Value.ToString()] = xlWorkSheet.Cells[i, "E"].Value.ToString();
                            //   dt.Rows.Add(new DataRow[xlWorkSheet.Cells[i, "A"].Value.ToString(), xlWorkSheet.Cells[i, "B"].Value.ToString(), xlWorkSheet.Cells[i, "C"].Value.ToString(), xlWorkSheet.Cells[i, "D"].Value.ToString()]);
                            dt.Rows.Add(dr);
                        }
                    }
                    //xlWorkBook.SaveAs(filelink, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                    //                      misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                    xlWorkBook.Close();
                   // xlWorkBook.Close();
                    xlApp.Quit();


                }
                catch (Exception ex)
                {

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "ReadexcelToDatatable (string fileName, string filelink)", ex.Message);
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ReadexcelToDatatable (string fileName, string filelink)", ex.Message);
            }
            return dt;
        }

        public void ExportAttendanceDaily(List<AttendanceDept> attendanceDepts, string pathSave, string pathForm, DateTime date)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;
          
            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(pathForm, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
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
                        range = xlWorkSheet.Range[xlWorkSheet.Cells[5 + i + countGroup - startGroup, "A"], xlWorkSheet.Cells[5 + i + countGroup , "A"]];

                        range.Merge();
                        xlWorkSheet.Cells[5 + i + countGroup - startGroup, "A"] = attendanceDepts[i-1].BigDeptName;

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
                        countGroup = countGroup+2;


                    }
                    else if (CurrentDep != attendanceDepts[i].BigDeptCode && countGroup > 0)
                    {
                        range = xlWorkSheet.Range[xlWorkSheet.Cells[5 + i + countGroup-1 - startGroup, "A"], xlWorkSheet.Cells[5 + i + countGroup, "A"]];

                        range.Merge();
                        xlWorkSheet.Cells[5 + i + countGroup-1 - startGroup, "A"] = attendanceDepts[i-1].BigDeptName;

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
                 else   if (i == attendanceDepts.Count - 1)
                    {
                        range = xlWorkSheet.Range[xlWorkSheet.Cells[5 + i + countGroup - 1 - startGroup, "A"], xlWorkSheet.Cells[5 + i + countGroup+1, "A"]];

                        range.Merge();
                        xlWorkSheet.Cells[5 + i + countGroup - 1 - startGroup, "A"] = attendanceDepts[i].BigDeptName;

                        xlWorkSheet.Cells[5 + i + countGroup+1, "B"] = "总合计:in total:";
                        double Total = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.LocalWorker.TotalWorker).Sum();
                        double Indirect = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.LocalWorker.WorkerIndirect).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup+1, "K"] = Total;
                        xlWorkSheet.Cells[5 + i + countGroup+1, "L"] = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.LocalWorker.WorkerDirect).Sum();
                        xlWorkSheet.Cells[5 + i + countGroup+1, "M"] = Indirect;
                        xlWorkSheet.Cells[5 + i + countGroup+1, "N"] = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.DayShift.absence).Sum() + attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.NightShift.absence).Sum();                    
                        xlWorkSheet.Cells[5 + i + countGroup+1, "O"] = attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.DayShift.attendanceActual).Sum() + attendanceDepts.Where(d => d.BigDeptCode == CurrentDep).Select(d => d.NightShift.attendanceActual).Sum();
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
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        public void ExportAbsenceDaily(List<EmployeeAbsence> employeeAbsences, string pathSave, string pathForm, DateTime date)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Range range;

            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(pathForm, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
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

        public  void openExcelList(string fileName, string LinkFile, ref DataTable dt)
        {
            try
            {
                // string fileNamel = @"D:\GITCODE\Libary\SettingRunServer\SettingRunServer.xlsx";
                string fileNamel = LinkFile;
                // string fileNamel = @"D:\GITCODE\Libary\SettingRunServer\SettingRunServer.xlsx";
                String name = "List1";
                String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + fileNamel + ";Extended Properties='Excel 12.0 XML;HDR=YES;';";

                OleDbConnection con = new OleDbConnection(constr);
                OleDbCommand oconn = new OleDbCommand("Select * From [" + fileName + "$]", con);
                con.Open();
                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                dt = new DataTable();
                sda.Fill(dt);
                con.Close();
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "openExcelList(string fileName, string LinkFile, ref DataTable dt)", ex.Message);
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
        public void ExportToReliabilityReport(string PathTemplate, string pathSaveExcel, List<ReliabilitySummary> summaries, List<ReliabilitySummary> summariesDept, DateTime from, DateTime to)
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

                            xlWorkSheet.Cells[14 + i - startGroup, "A"] = summaries[i].Clients;
                            xlWorkSheet.Cells[14 + i, "B"] = summaries[i].DepartmentCode;
                            xlWorkSheet.Cells[14 + i, "E"] = Math.Round(summaries[i].Reliability, 2);
                            xlWorkSheet.Cells[14 + i, "G"] = summaries[i].Orders;
                            xlWorkSheet.Cells[14 + i, "I"] = summaries[i].OrdersOT;
                            xlWorkSheet.Cells[14 + i, "K"] = summaries[i].OrdesLate;
                            xlWorkSheet.Cells[14 + i, "M"] = summaries[i].OTS;
                            xlWorkSheet.Cells[14 + i, "O"] = summaries[i].SOMO;
                            xlWorkSheet.Cells[14 + i, "Q"] = summaries[i].DeliveryQuantity;
                         //   xlWorkSheet.Cells[14 + i, "S"] = summaries[i].DeliveryQuantity;

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


                xlWorkBook.SaveAs(pathSaveExcel, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();




            }
            catch (Exception ex)
            {
               // SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportToReliabilityReport : An error happened in the process.", ex.Message);

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
              //  SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportToReliabilityReport : An error happened in the process.", ex.Message);

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
                    double Reliability = ( countOntime) / countOrder;
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
                    double Reliability = ( countOntime) / countOrder;
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
                    double Reliability = ( countOntime) / countOrder;
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
               // SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportToReliabilityReport : An error happened in the process.", ex.Message);

            }
        }
        public bool ExportToTemplate(string PathTemplate, DataGridView dgvBackLog, string dateupdate, string usersend, string version, string year)
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
                xlWorkSheet.Cells[6, 1] = "BackLog Report on " + DateTime.Now.ToString("MMM/dd/yyyy"); //Line
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
                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "ExportToTemplate]", filename);
                #endregion

                xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();


                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "ExportToTemplate]", "Xuat file OK");
                return true;
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportToTemplate error", ex.Message);
                return false;

            }
        }
        public bool ExportToTemplate(string pathSave, string PathTemplate, List<FinalItemsReport> dgvBackLog, string dateupdate, string usersend, string version, string year)
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
                xlWorkSheet.Cells[6, 1] = "BackLog Report on " + DateTime.Now.ToString("MMM/dd/yyyy"); //Line
                xlWorkSheet.Cells[1, 11] = dateupdate; //Line
                xlWorkSheet.Cells[2, 11] = usersend; //Model
                xlWorkSheet.Cells[3, 11] = version; //User  
                xlWorkSheet.Cells[4, 11] = year; //User   

                //datagridw
                for (int i = 0; i < dgvBackLog.Count; i++) //dong
                {
                    
                        xlWorkSheet.Cells[i + 11, "A"] = dgvBackLog[i].Department; // dong roi cot
                    xlWorkSheet.Cells[i + 11, "B"] = dgvBackLog[i].OrderCode;
                   xlWorkSheet.Cells[i + 11, "C"] = dgvBackLog[i].Clients;
                    xlWorkSheet.Cells[i + 11, "D"] = dgvBackLog[i].Clients_OrderCode;
                    xlWorkSheet.Cells[i + 11, "E"] = dgvBackLog[i].Product;
                    xlWorkSheet.Cells[i + 11, "F"] = dgvBackLog[i].Quantity;
                    xlWorkSheet.Cells[i + 11, "G"] = dgvBackLog[i].ClientsRequestDate;
                    xlWorkSheet.Cells[i + 11, "H"] = dgvBackLog[i].Shipped_Quantity;
                    xlWorkSheet.Cells[i + 11, "I"] = dgvBackLog[i].DeliveryDate;
                    xlWorkSheet.Cells[i + 11, "J"] = dgvBackLog[i].Remain_Quantity;
                    xlWorkSheet.Cells[i + 11, "K"] = dgvBackLog[i].Stock_Quantity;
                    xlWorkSheet.Cells[i + 11, "L"] = dgvBackLog[i].Semi_FinishedGoods;
                    xlWorkSheet.Cells[i + 11, "M"] = dgvBackLog[i].Semi_FinishedGoods_avaiable;
                    xlWorkSheet.Cells[i + 11, "N"] = dgvBackLog[i].Semi_Quantity;
                    xlWorkSheet.Cells[i + 11, "O"] = dgvBackLog[i].ShippingPercents;
                    xlWorkSheet.Cells[i + 11, "P"] = dgvBackLog[i].OverDueDate;
                    xlWorkSheet.Cells[i + 11, "Q"] = dgvBackLog[i].Status;

                }
                //string filename = @"C:\ERP_Temp\BackLogReport" + "" + "-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + ".xlsx";
                //SystemLog.Output(SystemLog.MSG_TYPE.Nor, filename);
                #endregion

                xlWorkBook.SaveAs(pathSave, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();
                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlApp);

                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "[ExportToTemplate]", "Xuat file OK");
                return true;
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportToTemplate error", ex.Message);
                return false;

            }
        }

     
    }
}
