using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UploadDataToDatabase.Log;
using UploadDataToDatabase.Class;
namespace UploadDataToDatabase.BackLogReport
{
 public   class RealabilityReport
    {

        List<FinalItemsReport> listShipingResult = new List<FinalItemsReport>();
        List<FinalItemsReport> listBackLog = new List<FinalItemsReport>();

        List<OrderData> ListOrderData = new List<OrderData>();
        List<DataShipping> ListShipping = new List<DataShipping>();


        string pathTemplate = Environment.CurrentDirectory + @"\Resources\Reliability.xlsx";
        private  DateTime dateFrom = DateTime.MinValue;
        private DateTime dateTo = DateTime.MinValue;

        public bool SendMailReliabilityReportWeekly()
        {
            try
            {

            DateTimeControl.ReturnDateTimeForWeekly(ref dateFrom, ref dateTo);
            RealabilityReport realabilityReport = new RealabilityReport();
            List<ReliabilitySummary> ListReliability = new List<ReliabilitySummary>();
            List<ReliabilitySummary> ListReliabilityDept = new List<ReliabilitySummary>();
            ListReliability = realabilityReport.GetDataForReliability(dateFrom, dateTo, out ListReliabilityDept);
            ExportExcelTool exportExcelTool = new ExportExcelTool();
            string path = @"C:\ERP_Temp\Reliability_Report_" + DateTime.Now.ToString("ddMMyy HHmmss") + ".xlsx";
            exportExcelTool.ExportToReliabilityReport(pathTemplate, path, ListReliability, ListReliabilityDept, dateFrom, dateTo);
            }

            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "SendMailReliabilityReportWeekly()", ex.Message);
                return false;
            }
            return true;
        }
        public bool SendMailReliabilityReportMonthly()
        {
            try
            {

                DateTimeControl.ReturnDateTimeForMonthly(ref dateFrom, ref dateTo);
                RealabilityReport realabilityReport = new RealabilityReport();
                List<ReliabilitySummary> ListReliability = new List<ReliabilitySummary>();
                List<ReliabilitySummary> ListReliabilityDept = new List<ReliabilitySummary>();
                ListReliability = realabilityReport.GetDataForReliability(dateFrom, dateTo, out ListReliabilityDept);
                ExportExcelTool exportExcelTool = new ExportExcelTool();
                string path = @"C:\ERP_Temp\Reliability_Report_" + DateTime.Now.ToString("ddMMyy HHmmss") + ".xlsx";
                exportExcelTool.ExportToReliabilityReport(pathTemplate, path, ListReliability, ListReliabilityDept, dateFrom, dateTo);
            }

            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "SendMailReliabilityReportWeekly()", ex.Message);
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
coptds.TD009 as QuantityOfDelivery,
min(moctas.TA009) as ManufactureOrderDate,
max(moctas.TA014) as ActualProductionComplete,
coptds.TD013 as ClientRequestDate,
max(coptgs.TG003) as DeliveryDate,
case when coptds.TD013 > max(coptgs.TG003) then 'Early'
when coptds.TD013 = max(coptgs.TG003) then 'On-time'
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
where 1=1  and  coptcs.TC027 = 'Y' and coptcs.TC001 != ''  and (coptds.TD016 = 'Y' or coptds.TD016 = 'y'
or (coptds.TD016 ='N' and coptds.TD008 <= coptds.TD009 )) and coptds.TD008 != '0' and coptds.TD009 != '0' and coptgs.TG023 != 'V'
 ");
            //--and (coptds.TD016 = 'Y' or coptds.TD016 = 'y')
            sql.Append(" and CONVERT(date,coptgs.TG003)  >= '" +from.ToString("yyyyMMdd")+ "' ");
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
coptds.TD009 ");

            sqlERPCON con = new sqlERPCON();
            DataTable dt = new DataTable();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
       rawReliabilities = (from DataRow dr in dt.Rows
                                    select new RawReliability()
                                    {

                                        orderCode =(dr["OrderCode"] != null) ? dr["OrderCode"].ToString().Trim():"",
                                        orderNo = (dr["OrderNo"] != null) ? dr["OrderNo"].ToString().Trim() : "",
                                        DepartmentCode = (dr["Department"] != null) ? dr["Department"].ToString().Trim():"",
                                        DateofOrder =(dr["DateOfOrder"] != null  && dr["DateOfOrder"].ToString() != "" )? DateTime.Parse(dr["DateOfOrder"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue,  
                                        ClientsEnd = (dr["Clients_End"] != null) ? dr["Clients_End"].ToString().Trim() : "",
                                        Clients =  dr["Clients_Name"].ToString().Trim(),
                                        ClientsCode = (dr["Clients_Order_Code"] != null) ? dr["Clients_Order_Code"].ToString().Trim():"",
                                        ProductionCode = (dr["Product_Code"] != null) ? dr["Product_Code"].ToString().Trim():"",
                                        OrderSatus = (dr["CompletedStatus"] != null) ? dr["CompletedStatus"].ToString().Trim():"",
                                        OrderQuantity = (dr["QuantityOfOrder"] != null && dr["QuantityOfOrder"].ToString() != "") ? (double.Parse(dr["QuantityOfOrder"].ToString().Trim())) : 0,
                                        DeliveryQuantity = (dr["QuantityOfDelivery"] != null && dr["QuantityOfDelivery"].ToString() != "") ? (double.Parse(dr["QuantityOfDelivery"].ToString())):0,
                                        ManufactureOrder = (dr["ManufactureOrderDate"] != null && dr["ManufactureOrderDate"].ToString() != "") ? DateTime.Parse(dr["ManufactureOrderDate"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue,
                                        ProductionCompleted = (dr["ActualProductionComplete"] != null && dr["ActualProductionComplete"].ToString() != "") ? DateTime.Parse(dr["ActualProductionComplete"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue,
                                        ClientRequestDate = (dr["ClientRequestDate"] != null &&  dr["ClientRequestDate"].ToString() != "") ? DateTime.Parse(dr["ClientRequestDate"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue,
                                        DeliveryDate = (dr["DeliveryDate"] != null && dr["DeliveryDate"].ToString() != "" )? DateTime.Parse(dr["DeliveryDate"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue,
                                        Evaluation = dr["Result"].ToString(),  
                                      
                                    }).ToList();

            foreach (var item in rawReliabilities)
            {
                if(item.DateofOrder != DateTime.MinValue && item.DeliveryDate != DateTime.MinValue)
                {
                    item.OTS = (item.DeliveryDate - item.DateofOrder).Days;
                }
                if (item.DateofOrder!= DateTime.MinValue && item.ClientRequestDate!= DateTime.MinValue)
                {
                    item.ReqOTS = (item.ClientRequestDate - item.DateofOrder).Days;
                }
                if(item.ManufactureOrder != DateTime.MinValue && item.DateofOrder != DateTime.MinValue)
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
        public Dictionary<string,Dictionary<string, List<ReliabilitySummary>>> SortbyClientRealitykeyValuePairs(List<RawReliability> listRawData)
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
                    int CountLate = dept.Where(d => d.Evaluation == "Late").Count() ;
                    int CountOntime = dept.Where(d => d.Evaluation == "On-time").Count();
                    int CountEarly = dept.Where(d => d.Evaluation == "Early").Count();
                    reliability.DeliveryQuantity = dept.Select(d => d.DeliveryQuantity).Sum();
                    reliability.OTS = dept.Select(d => d.OTS).Average();
                    reliability.SOMO = dept.Select(d => d.SOMO).Average();
                    reliability.ReqOTS = dept.Select(d => d.ReqOTS).Average();
                    reliability.Orders = CountLate + CountOntime + CountEarly;
                    reliability.OrdersOT = CountOntime;
                    reliability.OrdesEarly = CountEarly;
                    reliability.OrdesLate = CountLate;
                    reliability.Reliability = (reliability.OrdesEarly + reliability.OrdersOT) / reliability.Orders;
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
                    int CountEarly = dept.Where(d => d.Evaluation == "Early").Count();
                    reliability.DeliveryQuantity = dept.Select(d => d.DeliveryQuantity).Sum();
                    reliability.OTS = dept.Select(d => d.OTS).Average();
                    reliability.SOMO = dept.Select(d => d.SOMO).Average();
                    reliability.ReqOTS = dept.Select(d => d.ReqOTS).Average();
                    reliability.Orders = CountLate + CountOntime + CountEarly;
                    reliability.OrdersOT = CountOntime;
                    reliability.OrdesEarly = CountEarly;
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
        public List<ReliabilitySummary> ConvertDictionaryToList(Dictionary<string, Dictionary<string, List<ReliabilitySummary>>> keyValuePairs,string ClientOrDept)
        {
            List<ReliabilitySummary> reliabilitySummaries = new List<ReliabilitySummary>();
            foreach (var ClientsGroup in keyValuePairs)
            {
                foreach (var DeptGroup in ClientsGroup.Value)
                {

                    if (DeptGroup.Key == "Total")
                    { if (ClientOrDept == "client")
                        {
                            ReliabilitySummary reliability = new ReliabilitySummary();
                            reliability.Clients = ClientsGroup.Key;
                            reliability.DepartmentCode = "Total";
                            reliability.Orders = DeptGroup.Value.Select(d => d.Orders).Sum();
                            reliability.OrdersOT = DeptGroup.Value.Select(d => d.OrdersOT).Sum();
                            reliability.OrdesEarly = DeptGroup.Value.Select(d => d.OrdesEarly).Sum();
                            reliability.OrdesLate = DeptGroup.Value.Select(d => d.OrdesLate).Sum();
                            reliability.Reliability = (reliability.OrdersOT + reliability.OrdesEarly) / reliability.Orders;
                            reliability.OTS = DeptGroup.Value.Select(d => d.OTS).Average();
                            reliability.DeliveryQuantity = DeptGroup.Value.Select(d => d.DeliveryQuantity).Sum();
                            reliability.SOMO = DeptGroup.Value.Select(d => d.SOMO).Average();
                            reliability.ReqOTS = DeptGroup.Value.Select(d => d.ReqOTS).Average();
                            reliabilitySummaries.Add(reliability);
                        }
                    else if (ClientOrDept == "dept")
                        {
                            ReliabilitySummary reliability = new ReliabilitySummary();
                            reliability.Clients ="Total";
                            reliability.DepartmentCode = ClientsGroup.Key;
                            reliability.Orders = DeptGroup.Value.Select(d => d.Orders).Sum();
                            reliability.OrdersOT = DeptGroup.Value.Select(d => d.OrdersOT).Sum();
                            reliability.OrdesEarly = DeptGroup.Value.Select(d => d.OrdesEarly).Sum();
                            reliability.OrdesLate = DeptGroup.Value.Select(d => d.OrdesLate).Sum();
                            reliability.Reliability = (reliability.OrdersOT + reliability.OrdesEarly) / reliability.Orders;
                            reliability.OTS = DeptGroup.Value.Select(d => d.OTS).Average();
                            reliability.DeliveryQuantity = DeptGroup.Value.Select(d => d.DeliveryQuantity).Sum();
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
     public List<ReliabilitySummary> GetDataForReliability (DateTime from, DateTime to, out List<ReliabilitySummary> reliabilitiesDept )
        {
            List<RawReliability> realabilityItems = GetDataRawReliability(from, to);
            Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>
             GetdataGroupByClient = new Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>();
            Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>
           GetdataGroupByDepartments = new Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>();
            List<ReliabilitySummary> reliabilitySummaries = new List<ReliabilitySummary>();
            List<ReliabilitySummary> reliabilitySummariesDepartments = new List<ReliabilitySummary>();
            if (realabilityItems  != null && realabilityItems.Count > 0)
            {
               GetdataGroupByClient = SortbyClientRealitykeyValuePairs(realabilityItems);
            }
            if (realabilityItems != null && realabilityItems.Count > 0)
            {
                GetdataGroupByDepartments = SortbyDepartmentsRealitykeyValuePairs(realabilityItems);
            }
            if (GetdataGroupByClient != null && GetdataGroupByClient.Count > 0)
            {
                reliabilitySummaries = ConvertDictionaryToList(GetdataGroupByClient,"client");
            }
            if (GetdataGroupByDepartments != null && GetdataGroupByDepartments.Count > 0)
            {
                reliabilitySummariesDepartments = ConvertDictionaryToList(GetdataGroupByDepartments,"dept");
            }
            reliabilitiesDept = reliabilitySummariesDepartments;
        

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
        public string DepartmentName { get; set; }
        public string Clients{ get; set; }
        public string ClientsEnd { get; set; }
        public string ClientsCode { get; set; }
        public string ProductionCode { get; set; }
        public string OrderSatus { get; set; }

        public double OrderQuantity { get; set; }
        public double DeliveryQuantity { get; set; }
        public DateTime DateofOrder { get; set; }
        public DateTime ClientRequestDate{ get; set; }
        public DateTime DeliveryDate { get; set; }
        public DateTime ManufactureOrder { get; set; }
        public DateTime ProductionCompleted { get; set; }
        public string Evaluation { get; set; }
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

    }
}
