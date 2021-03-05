using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Class;

namespace WindowsFormsApplication1.Report.Reliability
{
  public  class ReliabilityClass
    {
        string pathTemplate = Environment.CurrentDirectory + @"\Resources\Reliability.xlsx";
        private DateTime dateFrom = DateTime.MinValue;
        private DateTime dateTo = DateTime.MinValue;
        public bool SendMailReliabilityReportWeekly(string path)
        {
            try
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar cal = dfi.Calendar;
                int WeekNo = cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                DateTimeControl.ReturnDateTimeFirstMonthToNow(ref dateFrom, ref dateTo);
                ReliabilityClass realabilityReport = new ReliabilityClass();
                List<ReliabilitySummary> ListReliability = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityDept = new List<ReliabilitySummary>();

                List<ReliabilitySummary> ListReliabilityClient7Days = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityDept7Days = new List<ReliabilitySummary>();
                List<RawReliability> rawReliabilities = GetDataRawReliability(dateFrom, dateTo);
                ListReliability = realabilityReport.GetDataForReliability(dateFrom, dateTo, rawReliabilities, out ListReliabilityDept, out ListReliabilityClient7Days, out ListReliabilityDept7Days);
                ToolSupport exportExcelTool = new ToolSupport();
               // string path = @"C:\ERP_Temp\Reliability_Report_W" + WeekNo.ToString() + "_" + DateTime.Now.ToString("ddMMMyyyy") + ".xlsx";
                exportExcelTool.ExportToReliabilityReport(pathTemplate, path, ListReliability, ListReliabilityDept, dateFrom, dateTo);
            }

            catch (Exception ex)
            {

              //  SystemLog.Output(SystemLog.MSG_TYPE.Err, "SendMailReliabilityReportWeekly()", ex.Message);
                return false;
            }
            return true;
        }
        public bool SendMailReliabilityReportAdding7Days(string PathSave)
        {

            try
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar cal = dfi.Calendar;
                int WeekNo = cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                DateTimeControl.ReturnDateTimeFirstMonthToNow(ref dateFrom, ref dateTo);
                ReliabilityClass realabilityReport = new ReliabilityClass();
                List<ReliabilitySummary> ListReliability = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityDept = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityClient7Days = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityDept7Days = new List<ReliabilitySummary>();
                List<RawReliability> rawReliabilities = GetDataRawReliability(dateFrom, dateTo);
                ListReliability = realabilityReport.GetDataForReliability(dateFrom, dateTo, rawReliabilities, out ListReliabilityDept, out ListReliabilityClient7Days, out ListReliabilityDept7Days);
                ToolSupport exportExcelTool = new ToolSupport();
              //  string path = @"C:\ERP_Temp\Reliability_Report_W" + WeekNo.ToString() + "_" + DateTime.Now.ToString("ddMMMyyyy") + ".xlsx";
                exportExcelTool.ExportToReliabilityReportAdding7DaysAddingRawData(pathTemplate, PathSave, ListReliability, ListReliabilityDept, ListReliabilityClient7Days, ListReliabilityDept7Days, rawReliabilities, dateFrom, dateTo);
            }

            catch (Exception ex)
            {

               // SystemLog.Output(SystemLog.MSG_TYPE.Err, "SendMailReliabilityReportWeekly()", ex.Message);
                return false;
            }
            return true;
        }
        public bool SendMailReliabilityReporAdding7DaystMonthly(string PathSave)
        {
            try
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar cal = dfi.Calendar;
                int WeekNo = cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                DateTimeControl.ReturnDateTimeForMonthly(ref dateFrom, ref dateTo);
                ReliabilityClass realabilityReport = new ReliabilityClass();
                List<ReliabilitySummary> ListReliability = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityDept = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityClient7Days = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityDept7Days = new List<ReliabilitySummary>();
                List<RawReliability> rawReliabilities = GetDataRawReliability(dateFrom, dateTo);
                ListReliability = realabilityReport.GetDataForReliability(dateFrom, dateTo, rawReliabilities, out ListReliabilityDept, out ListReliabilityClient7Days, out ListReliabilityDept7Days);
                ToolSupport exportExcelTool = new ToolSupport();
               // string path = @"C:\ERP_Temp\Reliability_Report" + "_" + dateTo.ToString("MMMyyyy") + ".xlsx";
                exportExcelTool.ExportToReliabilityReportAdding7DaysAddingRawData(pathTemplate, PathSave, ListReliability, ListReliabilityDept, ListReliabilityClient7Days, ListReliabilityDept7Days, rawReliabilities, dateFrom, dateTo);
            }

            catch (Exception ex)
            {

              //  SystemLog.Output(SystemLog.MSG_TYPE.Err, "SendMailReliabilityReportWeekly()", ex.Message);
                return false;
            }
            return true;
        }
        public bool SendMailReliabilityReporAdding7DaysYear(string PathSave)
        {
            try
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar cal = dfi.Calendar;
                int WeekNo = cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
               // DateTimeControl.ReturnDateTimeForMonthly(ref dateFrom, ref dateTo);
                dateFrom = new DateTime(DateTime.Now.Year, 1, 1);
                dateTo = DateTime.Now;
                ReliabilityClass realabilityReport = new ReliabilityClass();
                List<ReliabilitySummary> ListReliability = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityDept = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityClient7Days = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityDept7Days = new List<ReliabilitySummary>();
                List<RawReliability> rawReliabilities = GetDataRawReliability(dateFrom, dateTo);
                ListReliability = realabilityReport.GetDataForReliability(dateFrom, dateTo, rawReliabilities, out ListReliabilityDept, out ListReliabilityClient7Days, out ListReliabilityDept7Days);
                ToolSupport exportExcelTool = new ToolSupport();
                // string path = @"C:\ERP_Temp\Reliability_Report" + "_" + dateTo.ToString("MMMyyyy") + ".xlsx";
                exportExcelTool.ExportToReliabilityReportAdding7DaysAddingRawData(pathTemplate, PathSave, ListReliability, ListReliabilityDept, ListReliabilityClient7Days, ListReliabilityDept7Days, rawReliabilities, dateFrom, dateTo);
            }

            catch (Exception ex)
            {

                //  SystemLog.Output(SystemLog.MSG_TYPE.Err, "SendMailReliabilityReportWeekly()", ex.Message);
                return false;
            }
            return true;
        }
        public bool SendMailReliabilityReporAdding7DayPeriodTime(string PathSave, DateTime dateFrom, DateTime dateTo)
        {
            try
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                Calendar cal = dfi.Calendar;
                int WeekNo = cal.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            //    DateTimeControl.ReturnDateTimeForMonthly(ref dateFrom, ref dateTo);
                //dateFrom = new DateTime(DateTime.Now.Year, 1, 1);
                //dateTo = DateTime.Now;
                ReliabilityClass realabilityReport = new ReliabilityClass();
                List<ReliabilitySummary> ListReliability = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityDept = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityClient7Days = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityDept7Days = new List<ReliabilitySummary>();
                List<RawReliability> rawReliabilities = GetDataRawReliability(dateFrom, dateTo);
                ListReliability = realabilityReport.GetDataForReliability(dateFrom, dateTo, rawReliabilities, out ListReliabilityDept, out ListReliabilityClient7Days, out ListReliabilityDept7Days);
                ToolSupport exportExcelTool = new ToolSupport();
                // string path = @"C:\ERP_Temp\Reliability_Report" + "_" + dateTo.ToString("MMMyyyy") + ".xlsx";
                exportExcelTool.ExportToReliabilityReportAdding7DaysAddingRawData(pathTemplate, PathSave, ListReliability, ListReliabilityDept, ListReliabilityClient7Days, ListReliabilityDept7Days, rawReliabilities, dateFrom, dateTo);
            }

            catch (Exception ex)
            {

                //  SystemLog.Output(SystemLog.MSG_TYPE.Err, "SendMailReliabilityReportWeekly()", ex.Message);
                return false;
            }
            return true;
        }
        public List<RawReliability> GetDataRawReliability(DateTime from, DateTime to)
        {
            List<RawReliability> rawReliabilities = new List<RawReliability>();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select
coptcs.TC001 as OrderCode, 
coptcs.TC002 as OrderNo,
cmsmes.ME002 as Department,
coptcs.TC003 as DateOfOrder,
copmas.MA002 as Clients_Name,
coptcs.TC010 as Clients_End,
coptcs.TC012 as Clients_Order_Code,
coptds.TD004 as Product_Code,
case when coptds.TD016 = 'Y' then 'Auto Complete'
when coptds.TD016 = 'y' then 'Manual Complete'
when coptds.TD016 = 'N' then 'Not Complete'
end as CompletedStatus,
coptds.TD008 as QuantityOfOrder,
coptds.TD009 as TotalDelivery,
copths.TH008 as QuantityOfDelivery,
copths.TH009 as WeightUnit,
coptds.TD033 as PackingQuantity,
min(moctas.TA009) as ManufactureOrderDate,
max(moctas.TA014) as ActualProductionComplete,
coptds.TD013 as ClientRequestDate,
max(coptgs.TG003) as DeliveryDate,
case when coptds.TD013 >= max(coptgs.TG003) then 'On-time'
when coptds.TD013 < max(coptgs.TG003) then 'Late'
else ''
end as Result
from COPTC coptcs
left join COPTD  coptds on coptcs.TC002 = coptds.TD002  and coptcs.TC001 = coptds.TD001 -- cong doan tao don
inner join  CMSME cmsmes on cmsmes.ME001 = coptcs.TC005
inner join COPMA copmas on copmas.MA001 = coptcs.TC004
left join MOCTA moctas on moctas.TA026 = TC001 AND moctas.TA027 = TC002
left join COPTH copths on coptcs.TC002 = copths.TH015 and  coptcs.TC001 = copths.TH014 and copths.TH004 =coptds.TD004 and copths.TH016 = coptds.TD003
left join COPTG coptgs on copths.TH002  = coptgs.TG002 and copths.TH001  = coptgs.TG001  --cong doan giao hang
where 1=1  and  coptcs.TC027 = 'Y'  and coptds.TD008 != '0' and coptds.TD009 != '0' and coptgs.TG023 = 'Y'
 ");
            //and (coptds.TD016 = 'Y' or coptds.TD016 = 'y')
            sql.Append(" and CONVERT(date,coptgs.TG003)  >= '" + from.ToString("yyyyMMdd") + "' ");
            sql.Append(" and CONVERT(date,coptgs.TG003) <= '" + to.ToString("yyyyMMdd") + "' ");

            sql.Append(@"
group by 
coptcs.TC001, 
coptcs.TC002,
coptcs.TC003,
coptds.TD016 ,
coptds.TD009,
coptds.TD013,
copmas.MA002,
coptcs.TC012,
coptcs.TC010,
coptds.TD004,
cmsmes.ME002,
coptds.TD016,
coptds.TD008,
coptds.TD009,
coptds.TD003,
coptds.TD033,
copths.TH008,
copths.TH009
");

            sqlERPCON con = new sqlERPCON();
            DataTable dt = new DataTable();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            foreach ( DataRow dr in dt.Rows)
            {
                RawReliability raw = new RawReliability();
                   raw.orderCode = (dr["OrderCode"] != null) ? dr["OrderCode"].ToString().Trim() : "";
                 raw.orderNo = (dr["OrderNo"] != null) ? dr["OrderNo"].ToString().Trim() : "";
                raw.DepartmentCode = (dr["Department"] != null) ? dr["Department"].ToString().Trim() : "";
                raw.DateofOrder = (dr["DateOfOrder"] != null && dr["DateOfOrder"].ToString() != "") ? DateTime.Parse(dr["DateOfOrder"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue;
                raw.ClientsEnd = (dr["Clients_End"] != null) ? dr["Clients_End"].ToString().Trim() : "";
                raw.Clients = dr["Clients_Name"].ToString().Trim();
                                    raw.ClientsCode = (dr["Clients_Order_Code"] != null) ? dr["Clients_Order_Code"].ToString().Trim() : "";
                raw.ProductionCode = (dr["Product_Code"] != null) ? dr["Product_Code"].ToString().Trim() : "";
                                    raw.OrderSatus = (dr["CompletedStatus"] != null) ? dr["CompletedStatus"].ToString().Trim() : "";
                                    raw.OrderQuantity = (dr["QuantityOfOrder"] != null && dr["QuantityOfOrder"].ToString() != "") ? (double.Parse(dr["QuantityOfOrder"].ToString().Trim())) : 0;
                                    raw.DeliveryQuantity = (dr["QuantityOfDelivery"] != null && dr["QuantityOfDelivery"].ToString() != "") ? (double.Parse(dr["QuantityOfDelivery"].ToString())) : 0;
                raw.TotalDelivery = (dr["TotalDelivery"] != null && dr["TotalDelivery"].ToString() != "") ? (double.Parse(dr["TotalDelivery"].ToString())) : 0;
                if (dr["WeightUnit"].ToString().Trim() == "KG")
                    raw.QtyToWeight = raw.DeliveryQuantity;
                else
                {
                   // raw.QtyToWeight = (dr["PackingQuantity"] != null && dr["PackingQuantity"].ToString() != "") ? (double.Parse(dr["PackingQuantity"].ToString())) : 0;
                    raw.QtyToWeight = ConvertToWeightKg(raw.ProductionCode, raw.DeliveryQuantity,dr["WeightUnit"].ToString().Trim());
                }
                raw.ManufactureOrder = (dr["ManufactureOrderDate"] != null && dr["ManufactureOrderDate"].ToString() != "") ? DateTime.Parse(dr["ManufactureOrderDate"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue;
                                    raw.ProductionCompleted = (dr["ActualProductionComplete"] != null && dr["ActualProductionComplete"].ToString() != "") ? DateTime.Parse(dr["ActualProductionComplete"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue;
                                    raw.ClientRequestDate = (dr["ClientRequestDate"] != null && dr["ClientRequestDate"].ToString() != "") ? DateTime.Parse(dr["ClientRequestDate"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue;
                                    raw.DeliveryDate = (dr["DeliveryDate"] != null && dr["DeliveryDate"].ToString() != "") ? DateTime.Parse(dr["DeliveryDate"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue;
                                    raw.Evaluation = dr["Result"].ToString();
                rawReliabilities.Add(raw);
            }
            
            //rawReliabilities = (from DataRow dr in dt.Rows
            //                    select new RawReliability()
            //                    {

            //                        orderCode = (dr["OrderCode"] != null) ? dr["OrderCode"].ToString().Trim() : "",
            //                        orderNo = (dr["OrderNo"] != null) ? dr["OrderNo"].ToString().Trim() : "",
            //                        DepartmentCode = (dr["Department"] != null) ? dr["Department"].ToString().Trim() : "",
            //                        DateofOrder = (dr["DateOfOrder"] != null && dr["DateOfOrder"].ToString() != "") ? DateTime.Parse(dr["DateOfOrder"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue,
            //                        ClientsEnd = (dr["Clients_End"] != null) ? dr["Clients_End"].ToString().Trim() : "",
            //                        Clients = dr["Clients_Name"].ToString().Trim(),
            //                        ClientsCode = (dr["Clients_Order_Code"] != null) ? dr["Clients_Order_Code"].ToString().Trim() : "",
            //                        ProductionCode = (dr["Product_Code"] != null) ? dr["Product_Code"].ToString().Trim() : "",
            //                        OrderSatus = (dr["CompletedStatus"] != null) ? dr["CompletedStatus"].ToString().Trim() : "",
            //                        OrderQuantity = (dr["QuantityOfOrder"] != null && dr["QuantityOfOrder"].ToString() != "") ? (double.Parse(dr["QuantityOfOrder"].ToString().Trim())) : 0,
            //                        DeliveryQuantity = (dr["QuantityOfDelivery"] != null && dr["QuantityOfDelivery"].ToString() != "") ? (double.Parse(dr["QuantityOfDelivery"].ToString())) : 0,
            //                        ManufactureOrder = (dr["ManufactureOrderDate"] != null && dr["ManufactureOrderDate"].ToString() != "") ? DateTime.Parse(dr["ManufactureOrderDate"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue,
            //                        ProductionCompleted = (dr["ActualProductionComplete"] != null && dr["ActualProductionComplete"].ToString() != "") ? DateTime.Parse(dr["ActualProductionComplete"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue,
            //                        ClientRequestDate = (dr["ClientRequestDate"] != null && dr["ClientRequestDate"].ToString() != "") ? DateTime.Parse(dr["ClientRequestDate"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue,
            //                        DeliveryDate = (dr["DeliveryDate"] != null && dr["DeliveryDate"].ToString() != "") ? DateTime.Parse(dr["DeliveryDate"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue,
            //                        Evaluation = dr["Result"].ToString(),

            //                    }).ToList();

            foreach (var item in rawReliabilities)
            {
                if (item.DateofOrder != DateTime.MinValue && item.DeliveryDate != DateTime.MinValue)
                {
                    item.OTS = (item.DeliveryDate - item.DateofOrder).Days;
                }
                if (item.DateofOrder != DateTime.MinValue && item.ClientRequestDate != DateTime.MinValue)
                {
                    item.ReqOTS = (item.ClientRequestDate - item.DateofOrder).Days;
                }
                if (item.ManufactureOrder != DateTime.MinValue && item.DateofOrder != DateTime.MinValue)
                {
                    item.SOMO = (item.ManufactureOrder - item.DateofOrder).Days;
                }
                //   if(item.ClientsEnd == "" )
                {
                    if (item.orderCode.Substring(0, 2) == "A2")
                    {
                        item.ClientsEnd = item.ProductionCode.Split('-').Count() > 0 ? item.ProductionCode.Split('-')[1] : "";
                    }
                    else if (item.orderCode.Substring(0, 2) == "B2" && item.DepartmentCode.Contains("OEM") && item.ProductionCode.Substring(0, 3) == "BPJ")
                    {
                        item.ClientsEnd = "MH";
                    }
                    else if (item.orderCode.Substring(0, 2) == "B2" && item.DepartmentCode != "挤出 BP DUN")
                    {
                        item.ClientsEnd = (item.ProductionCode.Length > 2) ? item.ProductionCode.Substring(1, 2) : "";
                    }

                    else if (item.orderCode.Substring(0, 2) == "B2" && item.DepartmentCode == "挤出 BP DUN" && item.ProductionCode == "JC-CP-001")
                    {
                        item.ClientsEnd = item.Clients;
                    }
                    else if (item.orderCode.Substring(0, 2) == "J2" && item.DepartmentCode != "挤出 BP DUN")
                    {
                        item.ClientsEnd = (item.ProductionCode.Length > 2) ? item.ProductionCode.Substring(1, 2) : "";
                    }
                    else if (item.Clients.Contains("JAMAK"))
                    {
                        item.ClientsEnd = item.Clients.Substring(0, 5);
                    }
                    else if (item.Clients.Contains("香港得霖") && item.ProductionCode.Substring(2, 2) == "JM")
                    {
                        item.ClientsEnd = "JAMAK";
                    }
                    else if (item.Clients.Contains("PROTEC-WIRE"))
                    {
                        item.ClientsEnd = "PROTEC-WIRE";
                    }
                    else if (item.orderCode.Substring(0, 2) == "Y2")
                    {
                        item.ClientsEnd = item.Clients;

                    }
                    else if (item.orderCode.Substring(0, 2) == "P2")
                    {
                        if (item.ProductionCode.Contains("P25") || item.ProductionCode.Contains("P40") || item.ProductionCode.Contains("P259"))
                            item.ClientsEnd = "JAMAK";
                        else if (item.ProductionCode.Contains("P05") || item.ProductionCode.Contains("P111"))
                            item.ClientsEnd = "MH";
                        else if (item.ProductionCode.Contains("P117"))
                            item.ClientsEnd = "PTC";
                    }

                }
            }

            return rawReliabilities;
        }
        public List<RawReliability> GetDataRawReliabilityAdding7Days(List<RawReliability> rawReliabilities)
        {
            List<RawReliability> rawReliabilities1 = new List<RawReliability>();
            List<RawReliability> rawReli = new List<RawReliability>();
            rawReli = rawReliabilities;
            {
                try
                {
                    foreach (var item in rawReli)
                    {
                        if (item.ClientRequestDate > item.DeliveryDate)
                        {
                            item.Evaluation7Days = "On-time";
                        }
                        else if (item.ClientRequestDate >= item.DeliveryDate.AddDays(-7))
                        {
                            item.Evaluation7Days = "On-time";
                        }
                        else if (item.ClientRequestDate < item.DeliveryDate.AddDays(-7))
                        {
                            item.Evaluation7Days = "Late";
                        }
                        rawReliabilities1.Add(item);
                    }
                }
                catch (Exception)
                {

                    return null;
                }
                return rawReliabilities1;
            }

        }

        public double ConvertToWeightKg(string Model, double Weight, string Unit)
        { double WeightKg = 0;
            double Weight_MD003 = 0;
            double Weight_MD004 = 0;
            try
            {
                if (Unit == "KG")
                    return Weight;
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select MB001,MB004,MD004, MD003,MD002, MB091 from INVMB 
left join INVMD on MB001 = MD001
where
1=1 ");
                stringBuilder.Append(" and MB001 = '" + Model + "' ");
                sqlERPCON con = new sqlERPCON();
                con.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                if (dt.Rows.Count == 1)
                {
                    if (Unit == dt.Rows[0]["MB004"].ToString().Trim() && dt.Rows[0]["MD002"].ToString().Trim() == "KG")

                    {
                        Weight_MD003 = double.Parse(dt.Rows[0]["MD003"].ToString());
                        Weight_MD004 = double.Parse(dt.Rows[0]["MD004"].ToString());
                        if (Weight_MD003 == 0 || Weight_MD004 == 0)
                        {
                            return 0;
                        }
                        else
                        {
                            WeightKg = Weight * Weight_MD003 / Weight_MD004;
                            return WeightKg;
                        }
                    }
                                       
                }
                else
                {
                  
                    DataRow dtRowPCS = dt.NewRow();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["MD002"].ToString().Trim() ==Unit.Trim() && dt.Rows[i]["MB004"].ToString().Trim() == "PCS")
                        {
                            dtRowPCS = dt.Rows[i];
                            Weight_MD003 = double.Parse(dtRowPCS["MD003"].ToString());
                            Weight_MD004 = double.Parse(dtRowPCS["MD004"].ToString());
                            WeightKg = Weight / Weight_MD003 * Weight_MD004;
                            break;
                        }
                    }
                    DataRow dtRowsKG = dt.NewRow();
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        if (dt.Rows[i]["MD002"].ToString().Trim() == "KG"&& dt.Rows[i]["MB004"].ToString().Trim() == "PCS")
                        {
                            dtRowsKG = dt.Rows[i];
                            Weight_MD003 = double.Parse(dtRowsKG["MD003"].ToString());
                            Weight_MD004 = double.Parse(dtRowsKG["MD004"].ToString());
                            WeightKg = WeightKg * Weight_MD003 / Weight_MD004;
                            break;
                        }
                    }
                    return WeightKg;
                }
              
            }
            catch (Exception)
            {

                return 0;
            }
            return 0;
        }
        public Dictionary<string, Dictionary<string, List<ReliabilitySummary>>> SortbyClientRealitykeyValuePairs(List<RawReliability> listRawData)
        {
            Dictionary<string, Dictionary<string, List<ReliabilitySummary>>> keyValuePairs = new Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>();

            var listGroupByClient = listRawData
                .GroupBy(u => u.ClientsEnd)
        .Select(grp => grp.ToList())
        .ToList();
            foreach (var ClientS in listGroupByClient)
            {
                var ListGroupByDept = ClientS
                     .GroupBy(u => u.DepartmentCode)
        .Select(grp => grp.ToList())
        .ToList();
                Dictionary<string, List<ReliabilitySummary>> DeptReliability = new Dictionary<string, List<ReliabilitySummary>>();
                List<ReliabilitySummary> reliabilities = new List<ReliabilitySummary>();
                List<ReliabilitySummary> reliabilitiesTotal = new List<ReliabilitySummary>();
                foreach (var dept in ListGroupByDept)
                {
                    ReliabilitySummary reliability = new ReliabilitySummary();
                    reliabilities = new List<ReliabilitySummary>();
                    reliability.Clients = dept[0].ClientsEnd;
                    reliability.DepartmentCode = dept[0].DepartmentCode;
                    int CountLate = dept.Where(d => d.Evaluation == "Late").Count();
                    int CountOntime = dept.Where(d => d.Evaluation == "On-time").Count();
                   // int CountEarly = dept.Where(d => d.Evaluation == "Early").Count();
                    reliability.DeliveryQuantity = dept.Select(d => d.DeliveryQuantity).Sum();
                    reliability.DeliveryQtyKg = dept.Select(d => d.QtyToWeight).Sum();
                    reliability.OTS = dept.Select(d => d.OTS).Average();
                    reliability.SOMO = dept.Select(d => d.SOMO).Average();
                    reliability.ReqOTS = dept.Select(d => d.ReqOTS).Average();
                    reliability.Orders = CountLate + CountOntime ;
                    reliability.OrdersOT = CountOntime;
                   // reliability.OrdesEarly = CountEarly;
                    reliability.OrdesLate = CountLate;
                    reliability.Reliability = ( reliability.OrdersOT) / reliability.Orders;
                    reliabilities.Add(reliability);
                    reliabilitiesTotal.Add(reliability);
                    DeptReliability.Add(reliability.DepartmentCode, reliabilities);
                }
                DeptReliability.Add("Total", reliabilitiesTotal);
                keyValuePairs.Add(ClientS[0].ClientsEnd, DeptReliability);
            }
            return keyValuePairs;
        }
        public Dictionary<string, Dictionary<string, List<ReliabilitySummary>>> SortbyClientRealitykeyValuePairs7Days(List<RawReliability> listRawData)
        {
            Dictionary<string, Dictionary<string, List<ReliabilitySummary>>> keyValuePairs = new Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>();

            var listGroupByClient = listRawData
                .GroupBy(u => u.ClientsEnd)
        .Select(grp => grp.ToList())
        .ToList();
            foreach (var ClientS in listGroupByClient)
            {
                var ListGroupByDept = ClientS
                     .GroupBy(u => u.DepartmentCode)
        .Select(grp => grp.ToList())
        .ToList();
                Dictionary<string, List<ReliabilitySummary>> DeptReliability = new Dictionary<string, List<ReliabilitySummary>>();
                List<ReliabilitySummary> reliabilities = new List<ReliabilitySummary>();
                List<ReliabilitySummary> reliabilitiesTotal = new List<ReliabilitySummary>();
                foreach (var dept in ListGroupByDept)
                {
                    ReliabilitySummary reliability = new ReliabilitySummary();
                    reliabilities = new List<ReliabilitySummary>();
                    reliability.Clients = dept[0].ClientsEnd;
                    reliability.DepartmentCode = dept[0].DepartmentCode;
                    int CountLate = dept.Where(d => d.Evaluation7Days == "Late").Count();
                    int CountOntime = dept.Where(d => d.Evaluation7Days == "On-time").Count();
                 //   int CountEarly = dept.Where(d => d.Evaluation7Days == "Early").Count();
                    reliability.DeliveryQuantity = dept.Select(d => d.DeliveryQuantity).Sum();
                    reliability.DeliveryQtyKg = dept.Select(d => d.QtyToWeight).Sum();
                    reliability.OTS = dept.Select(d => d.OTS).Average();
                    reliability.SOMO = dept.Select(d => d.SOMO).Average();
                    reliability.ReqOTS = dept.Select(d => d.ReqOTS).Average();
                    reliability.Orders = CountLate + CountOntime ;
                    reliability.OrdersOT = CountOntime;
                   // reliability.OrdesEarly = CountEarly;
                    reliability.OrdesLate = CountLate;
                    reliability.Reliability = ( reliability.OrdersOT) / reliability.Orders;
                    reliabilities.Add(reliability);
                    reliabilitiesTotal.Add(reliability);
                    DeptReliability.Add(reliability.DepartmentCode, reliabilities);
                }
                DeptReliability.Add("Total", reliabilitiesTotal);
                keyValuePairs.Add(ClientS[0].ClientsEnd, DeptReliability);
            }
            return keyValuePairs;
        }
        public Dictionary<string, Dictionary<string, List<ReliabilitySummary>>> SortbyDepartmentsRealitykeyValuePairs(List<RawReliability> listRawData)
        {
            Dictionary<string, Dictionary<string, List<ReliabilitySummary>>> keyValuePairs = new Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>();

            var listGroupByClient = listRawData
                .GroupBy(u => u.DepartmentCode)
        .Select(grp => grp.ToList())
        .ToList();
            foreach (var ClientS in listGroupByClient)
            {
                var ListGroupByDept = ClientS
                     .GroupBy(u => u.ClientsEnd)
        .Select(grp => grp.ToList())
        .ToList();
                Dictionary<string, List<ReliabilitySummary>> DeptReliability = new Dictionary<string, List<ReliabilitySummary>>();
                List<ReliabilitySummary> reliabilities = new List<ReliabilitySummary>();
                List<ReliabilitySummary> reliabilitiesTotal = new List<ReliabilitySummary>();
                foreach (var dept in ListGroupByDept)
                {
                    ReliabilitySummary reliability = new ReliabilitySummary();
                    reliabilities = new List<ReliabilitySummary>();
                    reliability.Clients = dept[0].ClientsEnd;
                    reliability.DepartmentCode = dept[0].DepartmentCode;
                    int CountLate = dept.Where(d => d.Evaluation == "Late").Count();
                    int CountOntime = dept.Where(d => d.Evaluation == "On-time").Count();
                 //   int CountEarly = dept.Where(d => d.Evaluation == "Early").Count();
                    reliability.DeliveryQuantity = dept.Select(d => d.DeliveryQuantity).Sum();
                    reliability.DeliveryQtyKg = dept.Select(d => d.QtyToWeight).Sum();
                    reliability.OTS = dept.Select(d => d.OTS).Average();
                    reliability.SOMO = dept.Select(d => d.SOMO).Average();
                    reliability.ReqOTS = dept.Select(d => d.ReqOTS).Average();
                    reliability.Orders = CountLate + CountOntime ;
                    reliability.OrdersOT = CountOntime;
                  //  reliability.OrdesEarly = CountEarly;
                    reliability.OrdesLate = CountLate;
                    reliability.Reliability = (reliability.OrdesEarly + reliability.OrdersOT) / reliability.Orders;
                    reliabilities.Add(reliability);
                    reliabilitiesTotal.Add(reliability);
                    DeptReliability.Add(reliability.Clients, reliabilities);
                }
                DeptReliability.Add("Total", reliabilitiesTotal);
                keyValuePairs.Add(ClientS[0].DepartmentCode, DeptReliability);
            }
            return keyValuePairs;
        }
        public Dictionary<string, Dictionary<string, List<ReliabilitySummary>>> SortbyDepartmentsRealitykeyValuePairs7Days(List<RawReliability> listRawData)
        {
            Dictionary<string, Dictionary<string, List<ReliabilitySummary>>> keyValuePairs = new Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>();

            var listGroupByClient = listRawData
                .GroupBy(u => u.DepartmentCode)
        .Select(grp => grp.ToList())
        .ToList();
            foreach (var ClientS in listGroupByClient)
            {
                var ListGroupByDept = ClientS
                     .GroupBy(u => u.ClientsEnd)
        .Select(grp => grp.ToList())
        .ToList();
                Dictionary<string, List<ReliabilitySummary>> DeptReliability = new Dictionary<string, List<ReliabilitySummary>>();
                List<ReliabilitySummary> reliabilities = new List<ReliabilitySummary>();
                List<ReliabilitySummary> reliabilitiesTotal = new List<ReliabilitySummary>();
                foreach (var dept in ListGroupByDept)
                {
                    ReliabilitySummary reliability = new ReliabilitySummary();
                    reliabilities = new List<ReliabilitySummary>();
                    reliability.Clients = dept[0].ClientsEnd;
                    reliability.DepartmentCode = dept[0].DepartmentCode;
                    int CountLate = dept.Where(d => d.Evaluation7Days == "Late").Count();
                    int CountOntime = dept.Where(d => d.Evaluation7Days == "On-time").Count();
                ///    int CountEarly = dept.Where(d => d.Evaluation7Days == "Early").Count();
                    reliability.DeliveryQuantity = dept.Select(d => d.DeliveryQuantity).Sum();
                    reliability.DeliveryQtyKg = dept.Select(d => d.QtyToWeight).Sum();
                    reliability.OTS = dept.Select(d => d.OTS).Average();
                    reliability.SOMO = dept.Select(d => d.SOMO).Average();
                    reliability.ReqOTS = dept.Select(d => d.ReqOTS).Average();
                    reliability.Orders = CountLate + CountOntime ;
                    reliability.OrdersOT = CountOntime;
                  //  reliability.OrdesEarly = CountEarly;
                    reliability.OrdesLate = CountLate;
                    reliability.Reliability = (reliability.OrdesEarly + reliability.OrdersOT) / reliability.Orders;
                    reliabilities.Add(reliability);
                    reliabilitiesTotal.Add(reliability);
                    DeptReliability.Add(reliability.Clients, reliabilities);
                }
                DeptReliability.Add("Total", reliabilitiesTotal);
                keyValuePairs.Add(ClientS[0].DepartmentCode, DeptReliability);
            }
            return keyValuePairs;
        }
        public List<ReliabilitySummary> ConvertDictionaryToList(Dictionary<string, Dictionary<string, List<ReliabilitySummary>>> keyValuePairs, string ClientOrDept)
        {
            List<ReliabilitySummary> reliabilitySummaries = new List<ReliabilitySummary>();
            foreach (var ClientsGroup in keyValuePairs)
            {
                foreach (var DeptGroup in ClientsGroup.Value)
                {

                    if (DeptGroup.Key == "Total")
                    {
                        if (ClientOrDept == "client")
                        {
                            ReliabilitySummary reliability = new ReliabilitySummary();
                            reliability.Clients = ClientsGroup.Key;
                            reliability.DepartmentCode = "Total";
                            reliability.Orders = DeptGroup.Value.Select(d => d.Orders).Sum();
                            reliability.OrdersOT = DeptGroup.Value.Select(d => d.OrdersOT).Sum();
                          //  reliability.OrdesEarly = DeptGroup.Value.Select(d => d.OrdesEarly).Sum();
                            reliability.OrdesLate = DeptGroup.Value.Select(d => d.OrdesLate).Sum();
                            reliability.Reliability = (reliability.OrdersOT) / reliability.Orders;
                            reliability.OTS = DeptGroup.Value.Select(d => d.OTS).Average();
                            reliability.DeliveryQuantity = DeptGroup.Value.Select(d => d.DeliveryQuantity).Sum();
                            reliability.DeliveryQtyKg = DeptGroup.Value.Select(d => d.DeliveryQtyKg).Sum();
                            reliability.SOMO = DeptGroup.Value.Select(d => d.SOMO).Average();
                            reliability.ReqOTS = DeptGroup.Value.Select(d => d.ReqOTS).Average();
                            reliabilitySummaries.Add(reliability);
                        }
                        else if (ClientOrDept == "dept")
                        {
                            ReliabilitySummary reliability = new ReliabilitySummary();
                            reliability.Clients = "Total";
                            reliability.DepartmentCode = ClientsGroup.Key;
                            reliability.Orders = DeptGroup.Value.Select(d => d.Orders).Sum();
                            reliability.OrdersOT = DeptGroup.Value.Select(d => d.OrdersOT).Sum();
                          //  reliability.OrdesEarly = DeptGroup.Value.Select(d => d.OrdesEarly).Sum();
                            reliability.OrdesLate = DeptGroup.Value.Select(d => d.OrdesLate).Sum();
                            reliability.Reliability = (reliability.OrdersOT ) / reliability.Orders;
                            reliability.OTS = DeptGroup.Value.Select(d => d.OTS).Average();
                            reliability.DeliveryQuantity = DeptGroup.Value.Select(d => d.DeliveryQuantity).Sum();
                            reliability.DeliveryQtyKg = DeptGroup.Value.Select(d => d.DeliveryQtyKg).Sum();
                            reliability.SOMO = DeptGroup.Value.Select(d => d.SOMO).Average();
                            reliability.ReqOTS = DeptGroup.Value.Select(d => d.ReqOTS).Average();
                            reliabilitySummaries.Add(reliability);
                        }
                    }
                    else
                    {
                        foreach (var item in DeptGroup.Value)
                        {
                            reliabilitySummaries.Add(item);
                        }
                    }
                }

            }
            return reliabilitySummaries;
        }
        public List<ReliabilitySummary> GetDataForReliability(DateTime from, DateTime to, List<RawReliability> realabilityItems, out List<ReliabilitySummary> reliabilitiesDept, out List<ReliabilitySummary> reliabilitiesClient7Days, out List<ReliabilitySummary> reliabilitiesDept7Days)
        {


            Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>
             GetdataGroupByClient = new Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>();
            Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>
           GetdataGroupByDepartments = new Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>();

            Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>
          GetdataGroupByClientAdding7Days = new Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>();
            Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>
           GetdataGroupByDepartmentsAdding7Days = new Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>();
            List<ReliabilitySummary> reliabilitySummaries = new List<ReliabilitySummary>();
            List<ReliabilitySummary> reliabilitySummariesDepartments = new List<ReliabilitySummary>();
            List<ReliabilitySummary> reliabilitySummariesAdding7Days = new List<ReliabilitySummary>();
            List<ReliabilitySummary> reliabilitySummariesDepartmentsAdding7Days = new List<ReliabilitySummary>();
            if (realabilityItems != null && realabilityItems.Count > 0)
            {
                GetdataGroupByClient = SortbyClientRealitykeyValuePairs(realabilityItems);
            }
            if (realabilityItems != null && realabilityItems.Count > 0)
            {
                GetdataGroupByDepartments = SortbyDepartmentsRealitykeyValuePairs(realabilityItems);
            }
            List<RawReliability> realabilityItemsAdding7days = GetDataRawReliabilityAdding7Days(realabilityItems);
            if (realabilityItemsAdding7days != null && realabilityItemsAdding7days.Count > 0)
            {
                GetdataGroupByClientAdding7Days = SortbyClientRealitykeyValuePairs7Days(realabilityItemsAdding7days);
            }
            if (realabilityItemsAdding7days != null && realabilityItemsAdding7days.Count > 0)
            {
                GetdataGroupByDepartmentsAdding7Days = SortbyDepartmentsRealitykeyValuePairs7Days(realabilityItemsAdding7days);
            }
            if (GetdataGroupByClient != null && GetdataGroupByClient.Count > 0)
            {
                reliabilitySummaries = ConvertDictionaryToList(GetdataGroupByClient, "client");

            }
            if (GetdataGroupByDepartments != null && GetdataGroupByDepartments.Count > 0)
            {
                reliabilitySummariesDepartments = ConvertDictionaryToList(GetdataGroupByDepartments, "dept");
            }

            if (GetdataGroupByClientAdding7Days != null && GetdataGroupByClientAdding7Days.Count > 0)
            {
                reliabilitySummariesAdding7Days = ConvertDictionaryToList(GetdataGroupByClientAdding7Days, "client");

            }
            if (GetdataGroupByDepartmentsAdding7Days != null && GetdataGroupByDepartmentsAdding7Days.Count > 0)
            {
                reliabilitySummariesDepartmentsAdding7Days = ConvertDictionaryToList(GetdataGroupByDepartmentsAdding7Days, "dept");
            }

            reliabilitiesDept = reliabilitySummariesDepartments;

            reliabilitiesClient7Days = reliabilitySummariesAdding7Days;
            reliabilitiesDept7Days = reliabilitySummariesDepartmentsAdding7Days;

            return reliabilitySummaries;
        }
    }
    public class RealabilityItems
    {

        public string Clients { get; set; }
        public string Departments { get; set; }
        public string Products { get; set; }
        public double Reliability { get; set; }
        public double Flexibility { get; set; }
        public double Orders { get; set; }
        public double OrdersOT { get; set; }
        public double OrdersEarly { get; set; }
        public double OrdersLate { get; set; }
        public int OTS_Days { get; set; }
        public int Req_Days { get; set; }
        public int SO_MO_Days { get; set; }
        public int Quantity { get; set; }

    }
    public class Realability
    {
        public string Department { get; set; }
        public string OrderCode { get; set; }
        public string Clients { get; set; }
        public string Clients_OrderCode { get; set; }
        public string Product { get; set; }
        public double Quantity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ClientsRequestDate { get; set; }
        public double Shipped_Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Remain_Quantity { get; set; }
        public double Stock_Quantity { get; set; }
        public string Semi_FinishedGoods { get; set; }
        public string Semi_Quantity { get; set; }
        public double Semi_FinishedGoods_avaiable { get; set; }
        public double ShippingPercents { get; set; }
        public int OverDueDate { get; set; }
        public string Status { get; set; }
        // public double shipped_Quantity { get; set; }
    }
    public class RawReliability
    {
        public string orderCode { get; set; }
        public string orderNo { get; set; }
        public string DepartmentCode { get; set; }
        public string Clients { get; set; }
        public string ClientsEnd { get; set; }
        public string ClientsCode { get; set; }
        public string ProductionCode { get; set; }
        public string OrderSatus { get; set; }

        public double OrderQuantity { get; set; }
        public double TotalDelivery { get; set; }
        public double DeliveryQuantity { get; set; }
        public double QtyToWeight { get; set; }
        public DateTime DateofOrder { get; set; }
        public DateTime ClientRequestDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ManufactureOrder { get; set; }
        public DateTime ProductionCompleted { get; set; }
        public string Evaluation { get; set; }
        public string Evaluation7Days { get; set; }
        public double OTS { get; set; }
        public double ReqOTS { get; set; }
        public double SOMO { get; set; }


    }
    public class ReliabilitySummary
    {
        public string Clients { get; set; }
        public string DepartmentCode { get; set; }
        public double Reliability { get; set; }
        public double Flexibility { get; set; }
        public double Orders { get; set; }
        public double OrdersOT { get; set; }
        public double OrdesEarly { get; set; }
        public double OrdesLate { get; set; }
        public double OTS { get; set; }
        public double ReqOTS { get; set; }
        public double SOMO { get; set; }
        public double DeliveryQuantity { get; set; }
        public double DeliveryQtyKg { get; set; }

    }
}
