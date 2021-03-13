using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Excel = Microsoft.Office.Interop.Excel;
using System.Windows;
using System.Drawing;
using Microsoft.Office.Core;


namespace WindowsFormsApplication1.WMS.Controller
{
  public  class ExportFGsToExcel
    {
        public string PathFormExportFGs = Environment.CurrentDirectory + @"\Resources\ExportFGsForm.xls";
        public bool ExportToPackingList(DataTable dtPickingList, string PathSave,string PathQRCode )
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Worksheet xlWorkSheet1;


            object misValue = System.Reflection.Missing.Value;
       
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(PathFormExportFGs, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                #region Packing List
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                string strWorksheetName = xlWorkSheet.Name;//Get the name of worksheet. 
                xlWorkSheet.Cells[7, "I"] = DateTime.Now.ToString("dd.MM.yyyy");
                xlWorkSheet.Cells[9, "I"] = dtPickingList.Rows[0]["Invoice"];
                xlWorkSheet.Cells[8, "D"] = dtPickingList.Rows[0]["Client"];
                xlWorkSheet.Cells[9, "D"] = dtPickingList.Rows[0]["KeyID"].ToString() + "-" + dtPickingList.Rows[0]["KeyNo"].ToString();
                try
                {
                    string shippingType = dtPickingList.Rows[0]["TL203"].ToString();
                    Database.ERPSOFT.t_TL_Shipment t_TL_Shipment = new Database.ERPSOFT.t_TL_Shipment();
                    DataTable dtShipment = t_TL_Shipment.GetdatabyTextSearch(shippingType);
                    if (dtShipment.Rows.Count > 0)
                    {
                        xlWorkSheet.Cells[10, "C"] = dtShipment.Rows[0]["ShipmentType"];
                    }
                }
                catch (Exception ex)
                {

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Can't get shipment Type", ex.Message);
                }
            
                // xlWorkSheet.Cells[9, "D"] = dtPickingList.Rows[0]["CustomerOrder"];
                xlWorkSheet.Shapes.AddPicture(PathQRCode, MsoTriState.msoFalse, MsoTriState.msoCTrue, 30, 10, 100, 100);
                for (int i = 0; i < dtPickingList.Rows.Count; i++)
                {
                    xlWorkSheet.Cells[14 + 2 * i, "A"] = (i + 1).ToString("000");
                    xlWorkSheet.Cells[14 + 2 * i, "B"] = dtPickingList.Rows[i]["CustomerOrder"];
                    xlWorkSheet.Cells[14 + 2 * i, "C"] = dtPickingList.Rows[i]["Product"];
                    xlWorkSheet.Cells[14 + 2 * i, "E"] = dtPickingList.Rows[i]["Quantity"];
                    string Product = dtPickingList.Rows[i]["Product"].ToString();
                    Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
                    DataTable dt = new DataTable();
                    dt = t_TL_Product.GetdataExactllyProduct(Product);
                    if (dt.Rows.Count == 1)
                    {
                        try
                        {

                       
                        xlWorkSheet.Cells[14 + 2 * i, "D"] = dt.Rows[0]["MB004"];
                        xlWorkSheet.Cells[14 + 2 * i, "F"] = dt.Rows[0]["MB005"];
                        
                            if (dtPickingList.Rows[i]["TL201"].ToString().Trim() == "Package")
                            {
                                xlWorkSheet.Cells[14 + 2 * i, "J"] = dt.Rows[0]["MB006"];
                                var Vsplit = dt.Rows[0]["MB006"].ToString().Split('*');
                                double SoThung = Math.Ceiling(double.Parse(dtPickingList.Rows[i]["Quantity"].ToString()) / double.Parse(dt.Rows[0]["MB005"].ToString()));
                                xlWorkSheet.Cells[14 + 2 * i, "G"] = SoThung;
                                double NetPacking = Database.INV.INVMD.ConvertToWeightKg(Product, double.Parse(dtPickingList.Rows[i]["Quantity"].ToString()));
                                xlWorkSheet.Cells[14 + 2 * i, "H"] = NetPacking;
                                double KhoiLuongThung = SoThung * (double.Parse(dt.Rows[0]["MB007"].ToString()));
                                xlWorkSheet.Cells[14 + 2 * i, "I"] = NetPacking + KhoiLuongThung;
                                double TheTich = double.Parse(Vsplit[0].Trim()) * double.Parse(Vsplit[1].Trim()) * double.Parse(Vsplit[2].Trim()) * SoThung;
                                xlWorkSheet.Cells[14 + 2 * i, "K"] = TheTich;
                            }
                            else if (dtPickingList.Rows[i]["TL201"].ToString().Trim() == "Pallet")
                            {
                                xlWorkSheet.Cells[14 + 2 * i, "J"] = dt.Rows[0]["MB008"];
                                var Vsplit = dt.Rows[0]["MB008"].ToString().Split('*');
                                double SoThung = Math.Ceiling(double.Parse(dtPickingList.Rows[i]["Quantity"].ToString()) / double.Parse(dt.Rows[0]["MB005"].ToString()));
                                xlWorkSheet.Cells[14 + 2 * i, "G"] = SoThung;
                                double NetPacking = Database.INV.INVMD.ConvertToWeightKg(Product, double.Parse(dtPickingList.Rows[i]["Quantity"].ToString()));
                                xlWorkSheet.Cells[14 + 2 * i, "H"] = NetPacking;
                                double KhoiLuongThung = SoThung * (double.Parse(dt.Rows[0]["MB007"].ToString()));
                              
                                double KLPallet = double.Parse(dt.Rows[0]["MB009"].ToString());
                                double KLNep = double.Parse(dt.Rows[0]["MB010"].ToString());
                                xlWorkSheet.Cells[14 + 2 * i, "I"] = NetPacking + KhoiLuongThung + KLPallet + KLNep;
                                double TheTich = double.Parse(Vsplit[0].Trim()) * double.Parse(Vsplit[1].Trim()) * double.Parse(Vsplit[2].Trim()) * SoThung;
                                xlWorkSheet.Cells[14 + 2 * i, "K"] = TheTich;
                            }
                        }
                        catch (Exception ex)
                        {
                            
                            SystemLog.Output(SystemLog.MSG_TYPE.Err, "fill values into form fail ", ex.Message);
                        }
                    }
                    //xlWorkSheet.Cells[9, "I"] = dtPickingList.Rows[0]["Invoice"];
                    //xlWorkSheet.Cells[8, "D"] = dtPickingList.Rows[0]["Client"];
                    //xlWorkSheet.Cells[9, "D"] = dtPickingList.Rows[0]["CustomerOrder"];
                }
                #endregion

                xlWorkSheet1 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
                string strWorksheet1Name = xlWorkSheet1.Name;//Get the name of worksheet. 
                xlWorkSheet1.Cells[7, "F"] = DateTime.Now.ToString("dd.MM.yyyy");
                xlWorkSheet1.Cells[9, "F"] = dtPickingList.Rows[0]["Warehouse"];
                xlWorkSheet1.Cells[7, "C"] = dtPickingList.Rows[0]["KeyID"].ToString()+"-"+ dtPickingList.Rows[0]["KeyNo"].ToString();
                xlWorkSheet1.Cells[9, "C"] = Class.valiballecommon.GetStorage().UserName;
                xlWorkSheet1.Shapes.AddPicture(PathQRCode, MsoTriState.msoFalse, MsoTriState.msoCTrue, 30, 10, 100, 100);
                for (int i = 0; i < dtPickingList.Rows.Count; i++)
                {
                    xlWorkSheet1.Cells[14 + 2 * i, "A"] = (i + 1).ToString("000");
                    xlWorkSheet1.Cells[14 + 2 * i, "B"] = dtPickingList.Rows[i]["CustomerOrder"];
                    xlWorkSheet1.Cells[14 + 2 * i, "C"] = dtPickingList.Rows[i]["Product"];                  
                    xlWorkSheet1.Cells[14 + 2 * i, "E"] = dtPickingList.Rows[i]["Quantity"];
                    xlWorkSheet1.Cells[14 + 2 * i, "F"] = dtPickingList.Rows[i]["LotNo"];
                    xlWorkSheet1.Cells[14 + 2 * i, "G"] = dtPickingList.Rows[i]["Location"];
                    string Product = dtPickingList.Rows[i]["Product"].ToString();
                    Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
                    DataTable dt = new DataTable();
                    dt = t_TL_Product.GetdataExactllyProduct(Product);
                    if (dt.Rows.Count == 1)
                    {
                        xlWorkSheet1.Cells[14 + 2 * i, "D"] = dt.Rows[0]["MB004"];
                    }
                }
                
                xlWorkBook.SaveAs(PathSave, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkSheet1);
                reOject(xlWorkBook);
                reOject(xlApp);
                return true;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Export packing list and picking list", ex.Message);
                
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
                System.Windows.Forms.MessageBox.Show("Export to excel fail: " + ex.Message, "Information", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
            }
            finally
            {
                GC.Collect();
            }
        }
    }
}
