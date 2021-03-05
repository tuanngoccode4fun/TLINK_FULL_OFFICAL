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
using NumberConverterToText;
using WindowsFormsApplication1.CustomsDeclarasion.Model;

namespace WindowsFormsApplication1.CustomsDeclarasion.Controller
{
  public  class ExportCustomsDeclaration
    {
        public string PathFormExportFGs = Environment.CurrentDirectory + @"\Resources\Declaration_Form.xls";
        public string PathCompareBOM = Environment.CurrentDirectory + @"\Resources\ERP_HQ_BOM.xls";
        public bool ExportCustomsDecalaration(string PathSave,DataTable dtexport, string buyerCode, string shipmentCode)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Worksheet xlWorkSheet2;
            Excel.Worksheet xlWorkSheet3;

            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(PathFormExportFGs, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                #region Sales Invoice
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                string strWorksheetName = xlWorkSheet.Name;
                xlWorkSheet.Cells[11, "K"] = dtexport.Rows[0]["Invoice"];
                xlWorkSheet.Cells[12, "K"] = DateTime.Now.ToString("dd-MM-yyyy");
                
                int TotalMoney = 0;
                double douTotalMonney = 0;

                //Thong tin buyer
                Database.ERPSOFT.t_TL_BuyerInfor t_TL_BuyerInfor = new Database.ERPSOFT.t_TL_BuyerInfor();
                DataTable dtBuyer = t_TL_BuyerInfor.GetdatabyTextSearch(buyerCode);
                Database.ERPSOFT.t_TL_Shipment t_TL_Shipment = new Database.ERPSOFT.t_TL_Shipment();
                DataTable dtShipment = t_TL_Shipment.GetdatabyTextSearch(shipmentCode);
                xlWorkSheet.Cells[11, "C"] = dtBuyer.Rows[0]["Buyer_Infor"].ToString();
                xlWorkSheet.Cells[91, "B"] = dtBuyer.Rows[0]["Buyer_Consignee"].ToString();
                //Thong tin transportation



                for (int i = 0; i < dtexport.Rows.Count; i++)
                {
                    xlWorkSheet.Cells[23+i, "A"] = dtexport.Rows[i]["STT"];
                   // xlWorkSheet.Cells[23 + i, "C"] = dtexport.Rows[i]["Product"];
                    xlWorkSheet.Cells[23 + i, "D"] = dtexport.Rows[i]["Product"];
                    xlWorkSheet.Cells[23 + i, "G"] = dtexport.Rows[i]["Quantity"];
                    xlWorkSheet.Cells[23 + i, "H"] = dtexport.Rows[i]["Unit"];
                    if (dtexport.Rows[i]["Currency"].ToString().Trim() == "USD")
                    {
                        xlWorkSheet.Cells[23 + i, "I"] = "$ " + dtexport.Rows[i]["PriceUnit"].ToString();
                    }
                    else if (dtexport.Rows[i]["Currency"].ToString().Trim() == "EUR")
                    {
                       
                         xlWorkSheet.Cells[23 + i, "I"] = "€ " + dtexport.Rows[i]["PriceUnit"].ToString();
                    }

                    xlWorkSheet.Cells[23 + i, "K"] =  double.Parse(dtexport.Rows[i]["PriceUnit"].ToString())* double.Parse(dtexport.Rows[i]["Quantity"].ToString());
                    douTotalMonney += double.Parse(dtexport.Rows[i]["PriceUnit"].ToString()) * double.Parse(dtexport.Rows[i]["Quantity"].ToString());
                  
                    xlWorkSheet.Cells[23 + i, "E"] = "Vietnam";


                    string Product = dtexport.Rows[i]["Product"].ToString().Trim();
                    Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
                    DataTable dt = new DataTable();
                    dt = t_TL_Product.GetdataExactllyProduct(Product);
                    if (dt.Rows.Count == 1)
                    {
                        try
                        {
                            xlWorkSheet.Cells[23 + i, "C"] = dt.Rows[0]["MB004"].ToString().Trim();
                        }

                        catch (Exception ex)
                        {

                            SystemLog.Output(SystemLog.MSG_TYPE.Err, "Error", ex.Message);
                        }
                    }

                }

                TotalMoney = (int)(douTotalMonney);
                var test = douTotalMonney - TotalMoney;
               
                int numberCent = (int)(Math.Round((douTotalMonney - TotalMoney) * 100,2));
                string ConvertToText = NumberConverterToText.Converter.ConvertNumberToString(TotalMoney);
                string convertToCentText = NumberConverterToText.Converter.ConvertNumberToString(numberCent);
                if (dtexport.Rows[0]["Currency"].ToString().Trim() == "USD")
                {
                    xlWorkSheet.Cells[89, "A"] = "SAY TOTAL US DOLLAR " + ConvertToText.ToUpper() + " AND CENTS " + convertToCentText.ToUpper() + " ONLY";
                    xlWorkSheet.Cells[22, "I"] = "USD";
                    xlWorkSheet.Cells[22, "K"] = "USD";
                    xlWorkSheet.Cells[86, "I"] = "USD";


                }
                else if (dtexport.Rows[0]["Currency"].ToString().Trim() == "EUR")
                {
                    xlWorkSheet.Cells[89, "A"] = "SAY TOTAL EU DOLLAR " + ConvertToText.ToUpper() + " AND CENTS " + convertToCentText.ToUpper() + " ONLY";
                    xlWorkSheet.Cells[22, "I"] = "EUR";
                    xlWorkSheet.Cells[22, "K"] = "EUR";
                    xlWorkSheet.Cells[86, "I"] = "EUR";
                }
                #endregion
                #region Delivery Notes

                xlWorkSheet2 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
                string strWorksheet2Name = xlWorkSheet2.Name;
                xlWorkSheet2.Cells[11, "K"] = dtexport.Rows[0]["Invoice"];
                xlWorkSheet2.Cells[12, "K"] = DateTime.Now.ToString("dd-MM-yyyy");
                xlWorkSheet2.Cells[11, "C"] = dtBuyer.Rows[0]["Buyer_Infor"].ToString();
                xlWorkSheet2.Cells[15, "C"] = dtShipment.Rows[0]["ShipmentType"].ToString();



                for (int i = 0; i < dtexport.Rows.Count; i++)
                {
                    xlWorkSheet2.Cells[23 + i, "A"] = dtexport.Rows[i]["STT"];
                    // xlWorkSheet.Cells[23 + i, "C"] = dtexport.Rows[i]["Product"];
                    xlWorkSheet2.Cells[23 + i, "D"] = dtexport.Rows[i]["Product"];
                    xlWorkSheet2.Cells[23 + i, "G"] = dtexport.Rows[i]["Quantity"];
                    xlWorkSheet2.Cells[23 + i, "H"] = dtexport.Rows[i]["Unit"];

                    if (dtexport.Rows[i]["Currency"].ToString().Trim() == "USD")
                    {
                        xlWorkSheet2.Cells[23 + i, "I"] = "$ " + dtexport.Rows[i]["PriceUnit"].ToString();
                    }
                    else if (dtexport.Rows[i]["Currency"].ToString().Trim() == "EUR")
                    {

                        xlWorkSheet2.Cells[23 + i, "I"] = "€ " + dtexport.Rows[i]["PriceUnit"].ToString();
                    }

                    xlWorkSheet2.Cells[23 + i, "K"] = double.Parse(dtexport.Rows[i]["PriceUnit"].ToString()) * double.Parse(dtexport.Rows[i]["Quantity"].ToString());
                    //   TotalMoney += (int)(double.Parse(dtexport.Rows[i]["PriceUnit"].ToString()) * double.Parse(dtexport.Rows[i]["Quantity"].ToString()));
                    xlWorkSheet2.Cells[23 + i, "E"] = "Vietnam";



                    string Product = dtexport.Rows[i]["Product"].ToString().Trim();
                    Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
                    DataTable dt = new DataTable();
                    dt = t_TL_Product.GetdataExactllyProduct(Product);
                    if (dt.Rows.Count == 1)
                    {
                        try
                        {
                            xlWorkSheet2.Cells[23 + i, "C"] = dt.Rows[0]["MB004"].ToString().Trim();
                        }
                        catch (Exception ex)
                        {

                            SystemLog.Output(SystemLog.MSG_TYPE.Err, "Error", ex.Message);
                        }
                    }

                }

                if (dtexport.Rows[0]["Currency"].ToString().Trim() == "USD")
                {
                   
                    xlWorkSheet2.Cells[22, "I"] = "USD";
                    xlWorkSheet2.Cells[22, "K"] = "USD";
                    


                }
                else if (dtexport.Rows[0]["Currency"].ToString().Trim() == "EUR")
                {
                   
                    xlWorkSheet2.Cells[22, "I"] = "EUR";
                    xlWorkSheet2.Cells[22, "K"] = "EUR";
                }



                #endregion

                #region Sales Contract
                xlWorkSheet3 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(3);
                string strWorksheet3Name = xlWorkSheet3.Name;
                xlWorkSheet3.Cells[25, "K"] = DateTime.Now.ToString("dd-MM-yyyy");
                // xlWorkSheet3.Cells[12, "K"] = DateTime.Now.ToString("dd-MM-yyyy");
                xlWorkSheet3.Cells[15, "C"] = dtBuyer.Rows[0]["Buyer_Infor"].ToString();
                xlWorkSheet3.Cells[20, "B"] = dtBuyer.Rows[0]["Buyer_Consignee"].ToString();
                xlWorkSheet3.Cells[109, "D"] = dtShipment.Rows[0]["ShipmentType"].ToString();
                xlWorkSheet3.Cells[111, "D"] = dtShipment.Rows[0]["ShipmentInfor1"].ToString();
                xlWorkSheet3.Cells[112, "D"] = dtShipment.Rows[0]["ShipmentInfor2"].ToString();



                for (int i = 0; i < dtexport.Rows.Count; i++)
                {
                    xlWorkSheet3.Cells[33 + i, "A"] = dtexport.Rows[i]["STT"];
                    // xlWorkSheet.Cells[23 + i, "C"] = dtexport.Rows[i]["Product"];
                    xlWorkSheet3.Cells[33 + i, "D"] = dtexport.Rows[i]["Product"];
                    xlWorkSheet3.Cells[33 + i, "G"] = dtexport.Rows[i]["Quantity"];
                    xlWorkSheet3.Cells[33 + i, "H"] = dtexport.Rows[i]["Unit"];

                    if (dtexport.Rows[i]["Currency"].ToString().Trim() == "USD")
                    {
                        xlWorkSheet3.Cells[33 + i, "I"] = "$ " + dtexport.Rows[i]["PriceUnit"].ToString();
                    }
                    else if (dtexport.Rows[i]["Currency"].ToString().Trim() == "EUR")
                    {

                        xlWorkSheet3.Cells[33 + i, "I"] = "€ " + dtexport.Rows[i]["PriceUnit"].ToString();
                    }

                    xlWorkSheet3.Cells[33 + i, "K"] = double.Parse(dtexport.Rows[i]["PriceUnit"].ToString()) * double.Parse(dtexport.Rows[i]["Quantity"].ToString());
                    //  TotalMoney += (int)(double.Parse(dtexport.Rows[i]["PriceUnit"].ToString()) * double.Parse(dtexport.Rows[i]["Quantity"].ToString()));



                    xlWorkSheet3.Cells[33 + i, "F"] = "Vietnam";
                    string Product = dtexport.Rows[i]["Product"].ToString().Trim();
                    Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
                    DataTable dt = new DataTable();
                    dt = t_TL_Product.GetdataExactllyProduct(Product);
                    if (dt.Rows.Count == 1)
                    {
                        try
                        {
                            xlWorkSheet3.Cells[33 + i, "C"] = dt.Rows[0]["MB004"].ToString().Trim();
                        }
                        catch (Exception ex)
                        {

                            SystemLog.Output(SystemLog.MSG_TYPE.Err, "Error", ex.Message);
                        }
                    }

                }

                if (dtexport.Rows[0]["Currency"].ToString().Trim() == "USD")
                {
                    xlWorkSheet3.Cells[99, "A"] = "SAY TOTAL US DOLLAR " + ConvertToText.ToUpper() + " AND CENTS " + convertToCentText.ToUpper() + " ONLY";
                    xlWorkSheet3.Cells[32, "I"] = "USD";
                    xlWorkSheet3.Cells[32, "K"] = "USD";
                    xlWorkSheet3.Cells[97, "I"] = "USD";

                }
                else if (dtexport.Rows[0]["Currency"].ToString().Trim() == "EUR")
                {
                    xlWorkSheet3.Cells[99, "A"] = "SAY TOTAL EU DOLLAR " + ConvertToText.ToUpper() + " AND CENTS " + convertToCentText.ToUpper() + " ONLY";
                    xlWorkSheet3.Cells[32, "I"] = "EUR";
                    xlWorkSheet3.Cells[32, "J"] = "EUR";
                    xlWorkSheet3.Cells[97, "I"] = "EUR";
                }


                    #endregion


                    xlWorkBook.SaveAs(PathSave, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);

                xlApp.Quit();
                reOject(xlWorkSheet);
               reOject(xlWorkSheet2);
                reOject(xlWorkSheet3);
                reOject(xlWorkBook);
                reOject(xlApp);
                
            }
            catch (Exception EX)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportCustomsDecalaration(string PathSave,DataTable dtexport)", "export fail");
                return false;
            }
            return true;
        }

        public bool ExportCustomsDecalarationsGroupByProduct(string PathSave, DataTable dtexport, List<SummaryDelivery> summaries, string buyerCode, string shipmentCode)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            Excel.Worksheet xlWorkSheet2;
            Excel.Worksheet xlWorkSheet3;

            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(PathFormExportFGs, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                #region Sales Invoice
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                string strWorksheetName = xlWorkSheet.Name;
                xlWorkSheet.Cells[11, "K"] = dtexport.Rows[0]["Invoice"];
                xlWorkSheet.Cells[12, "K"] = DateTime.Now.ToString("dd-MM-yyyy");

                int TotalMoney = 0;
                double douTotalMonney = 0;

                //Thong tin buyer
                Database.ERPSOFT.t_TL_BuyerInfor t_TL_BuyerInfor = new Database.ERPSOFT.t_TL_BuyerInfor();
                DataTable dtBuyer = t_TL_BuyerInfor.GetdatabyTextSearch(buyerCode);
                Database.ERPSOFT.t_TL_Shipment t_TL_Shipment = new Database.ERPSOFT.t_TL_Shipment();
                DataTable dtShipment = t_TL_Shipment.GetdatabyTextSearch(shipmentCode);
                xlWorkSheet.Cells[11, "C"] = dtBuyer.Rows[0]["Buyer_Infor"].ToString();
                xlWorkSheet.Cells[91, "B"] = dtBuyer.Rows[0]["Buyer_Consignee"].ToString();
                //Thong tin transportation



                for (int i = 0; i < summaries.Count; i++)
                {
                    xlWorkSheet.Cells[23 + i, "A"] = (i+1).ToString("0000");
                    // xlWorkSheet.Cells[23 + i, "C"] = dtexport.Rows[i]["Product"];
                    xlWorkSheet.Cells[23 + i, "D"] = summaries[i].Product;
                    xlWorkSheet.Cells[23 + i, "G"] = summaries[i].TotalQuantity;
                    xlWorkSheet.Cells[23 + i, "H"] = summaries[i].Unit;
                    if (summaries[i].Currency.Trim() == "USD")
                    {
                        xlWorkSheet.Cells[23 + i, "I"] = "$ " + summaries[i].PriceUnit;
                    }
                    else if (summaries[i].Currency.Trim() == "EUR")
                    {

                        xlWorkSheet.Cells[23 + i, "I"] = "€ " + summaries[i].PriceUnit;
                    }

                    xlWorkSheet.Cells[23 + i, "K"] = double.Parse(summaries[i].PriceUnit.ToString()) * double.Parse(summaries[i].TotalQuantity.ToString());
                    douTotalMonney += double.Parse(summaries[i].PriceUnit.ToString()) * double.Parse(summaries[i].TotalQuantity.ToString());

                    xlWorkSheet.Cells[23 + i, "E"] = "Vietnam";


                    string Product = summaries[i].Product.Trim();
                    Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
                    DataTable dt = new DataTable();
                    dt = t_TL_Product.GetdataExactllyProduct(Product);
                    if (dt.Rows.Count == 1)
                    {
                        try
                        {
                            xlWorkSheet.Cells[23 + i, "C"] = dt.Rows[0]["MB004"].ToString().Trim();
                        }

                        catch (Exception ex)
                        {

                            SystemLog.Output(SystemLog.MSG_TYPE.Err, "Error", ex.Message);
                        }
                    }

                }

                TotalMoney = (int)(douTotalMonney);
                var test = douTotalMonney - TotalMoney;

                int numberCent = (int)(Math.Round((douTotalMonney - TotalMoney) * 100, 2));
                string ConvertToText = NumberConverterToText.Converter.ConvertNumberToString(TotalMoney);
                string convertToCentText = NumberConverterToText.Converter.ConvertNumberToString(numberCent);
                if (dtexport.Rows[0]["Currency"].ToString().Trim() == "USD")
                {
                    xlWorkSheet.Cells[89, "A"] = "SAY TOTAL US DOLLAR " + ConvertToText.ToUpper() + " AND CENTS " + convertToCentText.ToUpper() + " ONLY";
                    xlWorkSheet.Cells[22, "I"] = "USD";
                    xlWorkSheet.Cells[22, "K"] = "USD";
                    xlWorkSheet.Cells[86, "I"] = "USD";


                }
                else if (dtexport.Rows[0]["Currency"].ToString().Trim() == "EUR")
                {
                    xlWorkSheet.Cells[89, "A"] = "SAY TOTAL EU DOLLAR " + ConvertToText.ToUpper() + " AND CENTS " + convertToCentText.ToUpper() + " ONLY";
                    xlWorkSheet.Cells[22, "I"] = "EUR";
                    xlWorkSheet.Cells[22, "K"] = "EUR";
                    xlWorkSheet.Cells[86, "I"] = "EUR";
                }
                #endregion
                #region Delivery Notes

                xlWorkSheet2 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(2);
                string strWorksheet2Name = xlWorkSheet2.Name;
                xlWorkSheet2.Cells[11, "K"] = dtexport.Rows[0]["Invoice"];
                xlWorkSheet2.Cells[12, "K"] = DateTime.Now.ToString("dd-MM-yyyy");
                xlWorkSheet2.Cells[11, "C"] = dtBuyer.Rows[0]["Buyer_Infor"].ToString();
                xlWorkSheet2.Cells[15, "C"] = dtShipment.Rows[0]["ShipmentType"].ToString();



                for (int i = 0; i < summaries.Count; i++)
                {
                    xlWorkSheet2.Cells[23 + i, "A"] = (i+1).ToString("0000");
                    // xlWorkSheet.Cells[23 + i, "C"] = dtexport.Rows[i]["Product"];
                    xlWorkSheet2.Cells[23 + i, "D"] = summaries[i].Product;
                    xlWorkSheet2.Cells[23 + i, "G"] = summaries[i].TotalQuantity;
                    xlWorkSheet2.Cells[23 + i, "H"] = summaries[i].Unit;

                    if (summaries[i].Currency.ToString().Trim() == "USD")
                    {
                        xlWorkSheet2.Cells[23 + i, "I"] = "$ " + summaries[i].PriceUnit;
                    }
                    else if (summaries[i].Currency.ToString().Trim() == "EUR")
                    {

                        xlWorkSheet2.Cells[23 + i, "I"] = "€ " + summaries[i].PriceUnit;
                    }

                    xlWorkSheet2.Cells[23 + i, "K"] = double.Parse(summaries[i].PriceUnit.ToString()) * double.Parse(summaries[i].TotalQuantity.ToString());
                    //   TotalMoney += (int)(double.Parse(dtexport.Rows[i]["PriceUnit"].ToString()) * double.Parse(dtexport.Rows[i]["Quantity"].ToString()));
                    xlWorkSheet2.Cells[23 + i, "E"] = "Vietnam";



                    string Product = summaries[i].Product.Trim();
                    Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
                    DataTable dt = new DataTable();
                    dt = t_TL_Product.GetdataExactllyProduct(Product);
                    if (dt.Rows.Count == 1)
                    {
                        try
                        {
                            xlWorkSheet2.Cells[23 + i, "C"] = dt.Rows[0]["MB004"].ToString().Trim();
                        }
                        catch (Exception ex)
                        {

                            SystemLog.Output(SystemLog.MSG_TYPE.Err, "Error", ex.Message);
                        }
                    }

                }

                if (dtexport.Rows[0]["Currency"].ToString().Trim() == "USD")
                {

                    xlWorkSheet2.Cells[22, "I"] = "USD";
                    xlWorkSheet2.Cells[22, "K"] = "USD";



                }
                else if (dtexport.Rows[0]["Currency"].ToString().Trim() == "EUR")
                {

                    xlWorkSheet2.Cells[22, "I"] = "EUR";
                    xlWorkSheet2.Cells[22, "K"] = "EUR";
                }



                #endregion

                #region Sales Contract
                xlWorkSheet3 = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(3);
                string strWorksheet3Name = xlWorkSheet3.Name;
                xlWorkSheet3.Cells[25, "K"] = DateTime.Now.ToString("dd-MM-yyyy");
                // xlWorkSheet3.Cells[12, "K"] = DateTime.Now.ToString("dd-MM-yyyy");
                xlWorkSheet3.Cells[15, "C"] = dtBuyer.Rows[0]["Buyer_Infor"].ToString();
                xlWorkSheet3.Cells[20, "B"] = dtBuyer.Rows[0]["Buyer_Consignee"].ToString();
                xlWorkSheet3.Cells[109, "D"] = dtShipment.Rows[0]["ShipmentType"].ToString();
                xlWorkSheet3.Cells[111, "D"] = dtShipment.Rows[0]["ShipmentInfor1"].ToString();
                xlWorkSheet3.Cells[112, "D"] = dtShipment.Rows[0]["ShipmentInfor2"].ToString();



                for (int i = 0; i < summaries.Count; i++)
                {
                    xlWorkSheet3.Cells[33 + i, "A"] = (i+1).ToString("0000");
                    // xlWorkSheet.Cells[23 + i, "C"] = dtexport.Rows[i]["Product"];
                    xlWorkSheet3.Cells[33 + i, "D"] =summaries[i].Product;
                    xlWorkSheet3.Cells[33 + i, "G"] = summaries[i].TotalQuantity;
                    xlWorkSheet3.Cells[33 + i, "H"] = summaries[i].Unit;

                    if (summaries[i].Currency.Trim() == "USD")
                    {
                        xlWorkSheet3.Cells[33 + i, "I"] = "$ " + summaries[i].PriceUnit;
                    }
                    else if (summaries[i].Currency.Trim().Trim() == "EUR")
                    {

                        xlWorkSheet3.Cells[33 + i, "I"] = "€ " + summaries[i].PriceUnit;
                    }

                    xlWorkSheet3.Cells[33 + i, "K"] = double.Parse(summaries[i].PriceUnit.ToString()) * double.Parse(summaries[i].TotalQuantity.ToString());
                    //  TotalMoney += (int)(double.Parse(dtexport.Rows[i]["PriceUnit"].ToString()) * double.Parse(dtexport.Rows[i]["Quantity"].ToString()));



                    xlWorkSheet3.Cells[33 + i, "F"] = "Vietnam";
                    string Product = summaries[i].Product.Trim();
                    Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
                    DataTable dt = new DataTable();
                    dt = t_TL_Product.GetdataExactllyProduct(Product);
                    if (dt.Rows.Count == 1)
                    {
                        try
                        {
                            xlWorkSheet3.Cells[33 + i, "C"] = dt.Rows[0]["MB004"].ToString().Trim();
                        }
                        catch (Exception ex)
                        {

                            SystemLog.Output(SystemLog.MSG_TYPE.Err, "Error", ex.Message);
                        }
                    }

                }

                if (dtexport.Rows[0]["Currency"].ToString().Trim() == "USD")
                {
                    xlWorkSheet3.Cells[99, "A"] = "SAY TOTAL US DOLLAR " + ConvertToText.ToUpper() + " AND CENTS " + convertToCentText.ToUpper() + " ONLY";
                    xlWorkSheet3.Cells[32, "I"] = "USD";
                    xlWorkSheet3.Cells[32, "K"] = "USD";
                    xlWorkSheet3.Cells[97, "I"] = "USD";

                }
                else if (dtexport.Rows[0]["Currency"].ToString().Trim() == "EUR")
                {
                    xlWorkSheet3.Cells[99, "A"] = "SAY TOTAL EU DOLLAR " + ConvertToText.ToUpper() + " AND CENTS " + convertToCentText.ToUpper() + " ONLY";
                    xlWorkSheet3.Cells[32, "I"] = "EUR";
                    xlWorkSheet3.Cells[32, "J"] = "EUR";
                    xlWorkSheet3.Cells[97, "I"] = "EUR";
                }


                #endregion


                xlWorkBook.SaveAs(PathSave, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);

                xlApp.Quit();
                reOject(xlWorkSheet);
                reOject(xlWorkSheet2);
                reOject(xlWorkSheet3);
                reOject(xlWorkBook);
                reOject(xlApp);

            }
            catch (Exception EX)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportCustomsDecalaration(string PathSave,DataTable dtexport)", "export fail");
                return false;
            }
            return true;
        }



        public bool ExportCompareasionBOM(string PathSave,List<Model.HQERPBOM> hQERPBOMs)
        {
            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;


            object misValue = System.Reflection.Missing.Value;
            try
            {
                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Open(PathCompareBOM, 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                #region Comparasion BOM
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                string strWorksheetName = xlWorkSheet.Name;
                xlWorkSheet.Cells[6, "C"] = DateTime.Now.ToString("dd-MM-yyyy");

                for (int i = 0; i < hQERPBOMs.Count; i++)
                {
                    xlWorkSheet.Cells[9 + i, "A"] = (i + 1).ToString();
                    xlWorkSheet.Cells[9 + i, "B"] = hQERPBOMs[i].MA_SP_HQ;
                    xlWorkSheet.Cells[9 + i, "C"] = hQERPBOMs[i].MA_SP_HS ;
                    xlWorkSheet.Cells[9 + i, "D"] = hQERPBOMs[i].MA_SP_ERP;
                    xlWorkSheet.Cells[9 + i, "E"] = hQERPBOMs[i].MA_NVL_HQ;
                    xlWorkSheet.Cells[9 + i, "F"] = hQERPBOMs[i].MA_NVL_HS;
                    xlWorkSheet.Cells[9 + i, "G"] = hQERPBOMs[i].MA_NVL_ERP;
                    xlWorkSheet.Cells[9 + i, "H"] = hQERPBOMs[i].DM_HQ;
                    xlWorkSheet.Cells[9 + i, "I"] = hQERPBOMs[i].DVT_HQ;
                    xlWorkSheet.Cells[9 + i, "J"] = hQERPBOMs[i].DM_ERP;
                    xlWorkSheet.Cells[9 + i, "K"] = hQERPBOMs[i].DVT_ERP;
                    xlWorkSheet.Cells[9 + i, "L"] = hQERPBOMs[i].Issue;

                }
               
                #endregion
              


                xlWorkBook.SaveAs(PathSave, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);

                xlApp.Quit();
                reOject(xlWorkSheet);
        
                reOject(xlWorkBook);
                reOject(xlApp);

            }
            catch (Exception EX)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportCustomsDecalaration(string PathSave,DataTable dtexport)", "export fail");
                return false;
            }
            return true;
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
