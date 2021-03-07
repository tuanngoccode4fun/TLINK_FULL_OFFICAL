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
using WindowsFormsApplication1.Planning.Model;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1.Report.Backlog
{
  public  class ExportExelBacklogOverview
    {
        public string BackLogOverviewTemplate = Environment.CurrentDirectory + @"\Resources\BackLogOverview.xlsx";
    
    public bool ExportBacklogOverview(string PathSave,DataTable dtOrder, Dictionary<string,Planning.SemiFinishedGoods> dicSemis, 
        Dictionary<string, List<Planning.SemiFinishedGoods>> DicListSemiFGs, Dictionary<string, DataTable> dicDataTable)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Range range;
            Excel.Worksheet xlWorkSheet; //sheet 1
            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(BackLogOverviewTemplate, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //add data sheet1  

                for (int i = 0; i < dtOrder.Rows.Count; i++)
                {
                    xlWorkSheet.Cells[11 + i, "A"] = dtOrder.Rows[i]["Department_code"].ToString().Trim();
                    xlWorkSheet.Cells[11 + i, "B"] = dtOrder.Rows[i]["Clients_Order_Code"];
                    xlWorkSheet.Cells[11 + i, "C"] = dtOrder.Rows[i]["Code_Type"].ToString()+ "-"+ dtOrder.Rows[i]["Code_No"].ToString();
                    xlWorkSheet.Cells[11 + i, "D"] = dtOrder.Rows[i]["STT"].ToString();
                    xlWorkSheet.Cells[11 + i, "E"] = dtOrder.Rows[i]["Product_Code"].ToString().Trim();
                    string Product = dtOrder.Rows[i]["Product_Code"].ToString().Trim();
                  
                    xlWorkSheet.Cells[11 + i, "F"] = dtOrder.Rows[i]["Order_Quantity"];
                    xlWorkSheet.Cells[11 + i, "G"] = dtOrder.Rows[i]["Shipped_Quantity"];
                    xlWorkSheet.Cells[11 + i, "H"] = dtOrder.Rows[i]["Client_Request_Date"].ToString().Insert(4, "-").Insert(7,"-") ;
                    string STT = dtOrder.Rows[i]["STT"].ToString(); ;
                    string KeyDic = dtOrder.Rows[i]["Code_Type"].ToString().Trim() + "-" + dtOrder.Rows[i]["Code_No"].ToString().Trim()+"-"+ dtOrder.Rows[i]["STT"].ToString().Trim();
                    var semiValues = dicSemis[KeyDic];

                    xlWorkSheet.Cells[11 + i, "J"] = semiValues.QtyWarehouse;
                    xlWorkSheet.Cells[11 + i, "M"] = semiValues.QTyAtMQC;
                    xlWorkSheet.Cells[11 + i, "N"] = semiValues.QTyAtPQC;
                    var listSemiFGs = DicListSemiFGs[KeyDic];
                    string SemiFGSName = "";
                    string StockFGsWH = "";
                    if (listSemiFGs.Count > 0)
                    {
                        for (int j = 0; j < listSemiFGs.Count; j++)
                        {
                            SemiFGSName += listSemiFGs[j].Item.Trim() + Environment.NewLine;
                            StockFGsWH += listSemiFGs[j].QtyInWarehouse.ToString("N0") + Environment.NewLine;
                        }
                        xlWorkSheet.Cells[11 + i, "K"] = SemiFGSName;
                        xlWorkSheet.Cells[11 + i, "L"] = StockFGsWH;

                    }
                    var dtPO = dicDataTable[KeyDic];
                    if(dtPO.Rows.Count == 1)
                    {
                        xlWorkSheet.Cells[11 + i, "O"] = dtPO.Rows[0]["TA001"].ToString()+"-"+ dtPO.Rows[0]["TA002"].ToString();
                        xlWorkSheet.Cells[11 + i, "P"] = dtPO.Rows[0]["TA015"].ToString();
                        if (dtPO.Rows[0]["TA011"].ToString().Trim() == "1")
                        {
                            xlWorkSheet.Cells[11 + i, "Q"] = "Not yet Production";
                        }
                        else if (dtPO.Rows[0]["TA011"].ToString().Trim() == "2")
                        {
                            xlWorkSheet.Cells[11 + i, "Q"] = "Ready material";
                        }
                        else if (dtPO.Rows[0]["TA011"].ToString().Trim() == "3")
                        {
                            xlWorkSheet.Cells[11 + i, "Q"] = "Doing Prodution";
                        }
                        else if (dtPO.Rows[0]["TA011"].ToString().Trim() == "Y")
                        {
                            xlWorkSheet.Cells[11 + i, "Q"] = "Completed";
                        }
                        else if (dtPO.Rows[0]["TA011"].ToString().Trim() == "y")
                        {
                            xlWorkSheet.Cells[11 + i, "Q"] = "Completed-by user";
                        }
                        xlWorkSheet.Cells[11 + i, "R"] = dtPO.Rows[0]["TA017"].ToString();
                        xlWorkSheet.Cells[11 + i, "S"] = dtPO.Rows[0]["TA007"].ToString();
                    }
                    else
                    {
                        xlWorkSheet.Cells[11 + i, "O"] = "Not yet/Not define";
                    }

                }
                xlWorkBook.SaveAs(PathSave, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                     misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();

                xlApp.Quit();
                ClearObject.reOject(xlWorkBook);
                ClearObject.reOject(xlWorkSheet);
                ClearObject.reOject(xlApp);
                return true;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportListPlanningItemToExcelForm", ex.Message);
            }
            return false;
           
        }
    
    
    
    
    
    }
}
