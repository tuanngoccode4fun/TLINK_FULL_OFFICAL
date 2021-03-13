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

namespace WindowsFormsApplication1.Planning.Controler
{
    public class ExportExcelPlanning
    {
        public string PathTemplateFormHouseHoldENG = Environment.CurrentDirectory + @"\Resources\ProductionPLan_HouseHold_Form.xlsx";
        public bool ExportListPlanningItemToExcelForm(string dept, string layout, string PathSave, DateTime fromDate, DateTime todate,
            List<DataHeaderPlanning> listDataPlanning, Dictionary<string, List<dataContent>> DicDataContent, List<SemiFinishedGoods> listSemiFGs)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet; //sheet 1
            Excel.Worksheet xlWorkSheet2; //sheet 1
            Excel.Range range;
            //Excel.Worksheet xlWorkSheet1; //sheet 1
            object misValue = System.Reflection.Missing.Value;
            try
            {

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(PathTemplateFormHouseHoldENG, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                #region Sheet product
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1); //add data sheet1  

                var ListShipmentPlan = DicDataContent.Values.AsEnumerable().ToList().SelectMany(d => d).ToList();
                var listDate = ListShipmentPlan.OrderBy(d => d.ClientOrderDate).Select(d => d.ClientOrderDate).ToList().Distinct();
                var listWeek = ListShipmentPlan.OrderBy(d => d.ClientOrderDate).Select(d => d.WeekRequestDate).ToList().Distinct();
                var listMonth = ListShipmentPlan.OrderBy(d => d.ClientOrderDate).Select(d => d.MonthRequest).ToList().Distinct();
                int CountRow = 0;
                Dictionary<string, int> DicDateTimePosition = new Dictionary<string, int>();

                xlWorkSheet.Cells[1, "C"] = "PRODUCTION PLANNING FROM " + fromDate.ToString("dd-MM-yyyy") + " TO " + todate.ToString("dd-MM-yyyy");
                if (layout == "Date")
                {
                    foreach (var item in listDate)
                    {
                        range = xlWorkSheet.Range[xlWorkSheet.Cells[3, 16 + CountRow], xlWorkSheet.Cells[3, 16 + CountRow + 3]];
                        DicDateTimePosition.Add(item.ToString("dd-MM-yyyy"), 16 + CountRow);
                        range.Merge();

                        xlWorkSheet.Cells[3, 16 + CountRow] = item.ToString("dd-MM-yyyy");

                        xlWorkSheet.Cells[4, 16 + CountRow] = "Order Quantity";
                        xlWorkSheet.Cells[4, 16 + CountRow + 1] = "Shortage Qty (pcs)";
                        xlWorkSheet.Cells[4, 16 + CountRow + 2] = "Days Countdown";
                        xlWorkSheet.Cells[4, 16 + CountRow + 3] = "Target/day";

                        CountRow = CountRow + 4;
                    }
                }
                else if (layout == "Week")
                {
                    foreach (var item in listWeek)
                    {
                        range = xlWorkSheet.Range[xlWorkSheet.Cells[3, 16 + CountRow], xlWorkSheet.Cells[3, 16 + CountRow + 3]];
                        DicDateTimePosition.Add(item, 16 + CountRow);
                        range.Merge();

                        xlWorkSheet.Cells[3, 16 + CountRow] = item.ToString();

                        xlWorkSheet.Cells[4, 16 + CountRow] = "Order Quantity";
                        xlWorkSheet.Cells[4, 16 + CountRow + 1] = "Shortage Qty (pcs)";
                        xlWorkSheet.Cells[4, 16 + CountRow + 2] = "Days Countdown";
                        xlWorkSheet.Cells[4, 16 + CountRow + 3] = "Target/day";

                        CountRow = CountRow + 4;
                    }
                }
                else if (layout == "Month")
                {
                    foreach (var item in listMonth)
                    {
                        range = xlWorkSheet.Range[xlWorkSheet.Cells[3, 16 + CountRow], xlWorkSheet.Cells[3, 16 + CountRow + 3]];
                        DicDateTimePosition.Add(item, 16 + CountRow);
                        range.Merge();

                        xlWorkSheet.Cells[3, 16 + CountRow] = item.ToString();

                        xlWorkSheet.Cells[4, 16 + CountRow] = "Order Quantity";
                        xlWorkSheet.Cells[4, 16 + CountRow + 1] = "Shortage Qty (pcs)";
                        xlWorkSheet.Cells[4, 16 + CountRow + 2] = "Days Countdown";
                        xlWorkSheet.Cells[4, 16 + CountRow + 3] = "Target/day";

                        CountRow = CountRow + 4;
                    }
                }
                int count = 5;
                for (int i = 0; i < listDataPlanning.Count; i++) //dong
                {
                    double WipQty = 0;
                    if (dept == "B01-MH" || dept == "B01-FF")
                    {
                        WipQty = double.Parse(listDataPlanning[i].MQCStock.Trim()) + double.Parse(listDataPlanning[i].PQCStock.Trim()) + double.Parse(listDataPlanning[i].PendingWarehouse.Trim());
                    }

                    double FinishedGoodsQty = (listDataPlanning[i].StockInWarehouse != null) ? double.Parse(listDataPlanning[i].StockInWarehouse.Trim()) : 0;
                    xlWorkSheet.Cells[i + 5, "A"] = listDataPlanning[i].product; // dong roi cot
                    xlWorkSheet.Cells[i + 5, "B"] = listDataPlanning[i].client;
                    xlWorkSheet.Cells[i + 5, "C"] = listDataPlanning[i].Amount_Of_Order;
                    xlWorkSheet.Cells[i + 5, "D"] = listDataPlanning[i].Total_Order_Qty;
                    xlWorkSheet.Cells[i + 5, "E"] = listDataPlanning[i].StockInWarehouse;
                    xlWorkSheet.Cells[i + 5, "F"] = listDataPlanning[i].SemiFinishedGoods;
                    xlWorkSheet.Cells[i + 5, "G"] = listDataPlanning[i].Semi_FGs_Needed_Qty;
                    xlWorkSheet.Cells[i + 5, "H"] = listDataPlanning[i].StockSemiFinished;
                    xlWorkSheet.Cells[i + 5, "I"] = WipQty;
                    xlWorkSheet.Cells[i + 5, "J"] = listDataPlanning[i].Total_Order_Qty - WipQty - FinishedGoodsQty;
                    xlWorkSheet.Cells[i + 5, "K"] = listDataPlanning[i].MQCStock;
                    xlWorkSheet.Cells[i + 5, "L"] = listDataPlanning[i].PQCStock;
                    xlWorkSheet.Cells[i + 5, "M"] = listDataPlanning[i].PendingWarehouse;
                    xlWorkSheet.Cells[i + 5, "N"] = listDataPlanning[i].Accessories;
                    xlWorkSheet.Cells[i + 5, "O"] = listDataPlanning[i].StockAccessory;
                    var ListShiptmentPLan = DicDataContent[listDataPlanning[i].product];
                    if (layout == "Date")
                    {
                        foreach (var item in listDate)
                        {
                            int beginWrite = DicDateTimePosition[item.ToString("dd-MM-yyyy")];
                            double OrderQty = ListShiptmentPLan.Where(d => d.ClientOrderDate.ToString("dd-MM-yyyy") == item.ToString("dd-MM-yyyy"))
                                .Select(d => d.OrderQty).Sum();
                            double Shortage = ListShiptmentPLan.Where(d => d.ClientOrderDate.ToString("dd-MM-yyyy") == item.ToString("dd-MM-yyyy"))
                             .Select(d => d.ShortageQty).Sum();
                            double RemainDay = ListShiptmentPLan.Where(d => d.ClientOrderDate.ToString("dd-MM-yyyy") == item.ToString("dd-MM-yyyy"))
                            .Select(d => d.RemainDay).Sum();
                            double TargetQtyDay = ListShiptmentPLan.Where(d => d.ClientOrderDate.ToString("dd-MM-yyyy") == item.ToString("dd-MM-yyyy"))
                             .Select(d => d.TargetQtyDay).Sum();

                            xlWorkSheet.Cells[count, beginWrite] = OrderQty;
                            xlWorkSheet.Cells[count, beginWrite + 1] = Shortage;
                            xlWorkSheet.Cells[count, beginWrite + 2] = RemainDay;
                            xlWorkSheet.Cells[count, beginWrite + 3] = TargetQtyDay;

                        }
                    }
                    else if (layout == "Week")
                    {
                        foreach (var item in listWeek)
                        {

                            int beginWrite = DicDateTimePosition[item];
                            double OrderQty = 0;
                            double Shortage = 0;
                            double RemainDay = 0;
                            double TargetQtyDay = 0;
                            if (ListShiptmentPLan.Where(d => d.WeekRequestDate == item)
                             .Select(d => d.ShortageQty).ToList().Count() > 0)
                            {
                                OrderQty = ListShiptmentPLan.Where(d => d.WeekRequestDate == item)
                                .Select(d => d.OrderQty).Sum();

                                Shortage = ListShiptmentPLan.Where(d => d.WeekRequestDate == item)
                                .Select(d => d.ShortageQty).Max();


                                RemainDay = ListShiptmentPLan.Where(d => d.WeekRequestDate == item)
                                .Select(d => d.RemainDay).Max();
                                TargetQtyDay = ListShiptmentPLan.Where(d => d.WeekRequestDate == item)
                                 .Select(d => d.TargetQtyDay).Max();
                            }

                            xlWorkSheet.Cells[count, beginWrite] = OrderQty;
                            xlWorkSheet.Cells[count, beginWrite + 1] = Shortage;
                            xlWorkSheet.Cells[count, beginWrite + 2] = RemainDay;
                            xlWorkSheet.Cells[count, beginWrite + 3] = TargetQtyDay;


                        }
                    }
                    else if (layout == "Month")
                    {
                        foreach (var item in listMonth)
                        {

                            int beginWrite = DicDateTimePosition[item];
                            double OrderQty = 0;
                            double Shortage = 0;
                            double RemainDay = 0;
                            double TargetQtyDay = 0;
                            if (ListShiptmentPLan.Where(d => d.MonthRequest == item)
                             .Select(d => d.ShortageQty).ToList().Count() > 0)
                            {
                                OrderQty = ListShiptmentPLan.Where(d => d.MonthRequest == item)
                                .Select(d => d.OrderQty).Sum();

                                Shortage = ListShiptmentPLan.Where(d => d.MonthRequest == item)
                                .Select(d => d.ShortageQty).Max();


                                RemainDay = ListShiptmentPLan.Where(d => d.MonthRequest == item)
                                .Select(d => d.RemainDay).Max();
                                TargetQtyDay = ListShiptmentPLan.Where(d => d.MonthRequest == item)
                                 .Select(d => d.TargetQtyDay).Max();
                            }

                            xlWorkSheet.Cells[count, beginWrite] = OrderQty;
                            xlWorkSheet.Cells[count, beginWrite + 1] = Shortage;
                            xlWorkSheet.Cells[count, beginWrite + 2] = RemainDay;
                            xlWorkSheet.Cells[count, beginWrite + 3] = TargetQtyDay;


                        }
                    }
                    count++;
                }
                range = xlWorkSheet.Range[xlWorkSheet.Cells[3, 1], xlWorkSheet.Cells[count - 1, 16 + CountRow - 1]];
                range.Cells.BorderAround2(Missing.Value, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, ColorTranslator.ToOle(Color.FromArgb(255, 192, 0)));
                range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                range.Borders.Weight = Excel.XlBorderWeight.xlMedium;

                #endregion

                #region Sheet Semi-FinishedGoods
               
                if (listSemiFGs != null && listSemiFGs.Count > 0)
                {//   int count2 = 5;
                    xlWorkSheet2 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2); //add data sheet1  
                    for (int i = 0; i < listSemiFGs.Count; i++) //dong
                    {

                        xlWorkSheet2.Cells[i + 5, "A"] = listSemiFGs[i].Item; // dong roi cot
                                                                              //xlWorkSheet2.Cells[i + 5, "B"] = listDataPlanning[i].client;
                                                                              //xlWorkSheet2.Cells[i + 5, "C"] = listDataPlanning[i].Amount_Of_Order;
                                                                              //xlWorkSheet2.Cells[i + 5, "D"] = listDataPlanning[i].Total_Order_Qty;
                                                                              //xlWorkSheet2.Cells[i + 5, "E"] = listDataPlanning[i].StockInWarehouse;
                                                                              //xlWorkSheet2.Cells[i + 5, "F"] = listDataPlanning[i].SemiFinishedGoods;
                        xlWorkSheet2.Cells[i + 5, "G"] = listSemiFGs[i].QtyNeed;
                        xlWorkSheet2.Cells[i + 5, "H"] = listSemiFGs[i].QtyWarehouse;
                        xlWorkSheet2.Cells[i + 5, "I"] = listSemiFGs[i].QtyWip;
                        xlWorkSheet2.Cells[i + 5, "J"] = listSemiFGs[i].QtyNeed - listSemiFGs[i].QtyWarehouse - listSemiFGs[i].QtyWip;
                        xlWorkSheet2.Cells[i + 5, "K"] = listSemiFGs[i].QTyAtMQC;
                        xlWorkSheet2.Cells[i + 5, "L"] = listSemiFGs[i].QTyAtPQC;
                        xlWorkSheet2.Cells[i + 5, "M"] = listSemiFGs[i].QtyPendingWarehouse;

                    }

                    range = xlWorkSheet2.Range[xlWorkSheet2.Cells[3, 1], xlWorkSheet2.Cells[3 + listSemiFGs.Count + 1, 15]];
                    range.Cells.BorderAround2(Missing.Value, Excel.XlBorderWeight.xlMedium, Excel.XlColorIndex.xlColorIndexAutomatic, ColorTranslator.ToOle(Color.FromArgb(255, 192, 0)));
                    range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
                    range.Borders.Weight = Excel.XlBorderWeight.xlMedium;
                }

                #endregion
                xlWorkBook.SaveAs(PathSave, Excel.XlFileFormat.xlWorkbookDefault, misValue, misValue, misValue,
                        misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close();

                xlApp.Quit();
                reOject(xlWorkBook);
                reOject(xlWorkSheet);
                reOject(xlApp);
                return true;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportListPlanningItemToExcelForm", ex.Message);
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
