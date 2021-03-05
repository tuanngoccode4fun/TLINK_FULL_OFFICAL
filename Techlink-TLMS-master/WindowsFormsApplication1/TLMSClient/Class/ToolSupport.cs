using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace TLMSClient
{
    public  class ToolSupport
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
                xlworsheet.Cells[1, k+ 1] = cell;
            }



            for (int i = 0; i <= dataGrid.RowCount-1 ; i++)
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
            MessageBox.Show("Export to excel sucessful !" , "Information",MessageBoxButtons.OK,MessageBoxIcon.Information);
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
