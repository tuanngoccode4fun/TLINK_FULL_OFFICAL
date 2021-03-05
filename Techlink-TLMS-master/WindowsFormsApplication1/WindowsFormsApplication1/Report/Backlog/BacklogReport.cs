using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1.Report.Backlog
{
    class BacklogReport
    {
        DataTable dtShipping;

        DataTable dt;
        List<FinalItemsReport> listShipingResult = new List<FinalItemsReport>();
        List<FinalItemsReport> listBackLog = new List<FinalItemsReport>();

        List<OrderData> ListOrderData = new List<OrderData>();
        List<DataShipping> ListShipping = new List<DataShipping>();


        private string path = Environment.CurrentDirectory + @"\Resources\BackLogForm3.xlsx";
        private string pathSave = Environment.CurrentDirectory + @"\Resources\";

        public bool ExportExcelToReport( string pathSave, string version)
        {
            try
            {
                GetDataBackLogToExport();
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, " It's function : GetDataBackLogToExport() : Fail", ex.Message);
                return false;
            }

            if (listBackLog != null && listBackLog.Count > 0)
            {
                try
                {
                    Class.ToolSupport exportExcel = new Class.ToolSupport();

                    string strUser = Class.valiballecommon.GetStorage().UserName;

               

                    return exportExcel.ExportToTemplate(pathSave,path, listBackLog, DateTime.Now.ToString("yyyy-MM-dd"), strUser, version, DateTime.Now.ToString("yyyy"));

                }
                catch (Exception ex)
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Export excel error !", ex.Message);
                    return false;
                }
            }
            else return false;

        }
        public void GetDataProductionOrder()
        {
            try
            {

                // DateTime dtnow = DateTime.Now;
                //DateTime datefrom = new DateTime(dtnow.Year, 1, 1);
                DateTime dateto = DateTime.Now.AddDays(1);
                dtShipping = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append(@"select
coptcs.TC001 as Code_Type, 
coptcs.TC002 as Code_No,
cmsmes.ME002 as Department_code,
copmas.MA002 as Clients_Name,
coptcs.TC012 as Clients_Order_Code,
coptds.TD004 as Product_Code,
coptds.TD005 as Product_Name,
coptds.TD010 as Unit,
coptcs.TC005 as Department,
coptds.TD013 as Client_Request_Date,
coptds.TD008 as Order_Quantity,
coptds.TD009 as Shipped_Quantity,
coptds.TD016 as StatusOFCode,
invmbs.MB064 as Stock_Qty,
coptds.TD003 as STT
 from COPTC coptcs
left join COPTD  coptds on coptcs.TC002 = coptds.TD002  and coptcs.TC001 = coptds.TD001 -- cong doan tao don
inner join COPMA copmas on copmas.MA001 = coptcs.TC004
left join INVMB invmbs on invmbs.MB001 = coptds.TD004
left join CMSME cmsmes on cmsmes.ME001 = coptcs.TC005
where 1=1  
and  coptcs.TC027 = 'Y' 
 ");


                //  sql.Append(" and CONVERT(date,coptds.TD013)  >= '" + datefrom + "' ");
                sql.Append(" and CONVERT(date,coptds.TD013) <= '" + dateto.ToString("yyyyMMdd") + "' ");

                sql.Append("order by coptds.TD013");
                sqlERPCON con = new sqlERPCON();
                con.sqlDataAdapterFillDatatable(sql.ToString(), ref dtShipping);
            }
            catch (Exception ex)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataProductionOrder() : " , ex.Message);
            }
        }
        public DataTable GetDataProductionOrder2(DateTime todate)
        {
            try
            {

                // DateTime dtnow = DateTime.Now;
                //DateTime datefrom = new DateTime(dtnow.Year, 1, 1);
                DateTime dateto = todate;
                dtShipping = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append(@"select
coptcs.TC001 as Code_Type, 
coptcs.TC002 as Code_No,
cmsmes.ME002 as Department_code,
copmas.MA002 as Clients_Name,
coptcs.TC012 as Clients_Order_Code,
coptds.TD004 as Product_Code,
coptds.TD005 as Product_Name,
coptds.TD010 as Unit,
coptcs.TC005 as Department,
coptds.TD013 as Client_Request_Date,
coptds.TD008 as Order_Quantity,
coptds.TD009 as Shipped_Quantity,
coptds.TD016 as StatusOFCode,
invmbs.MB064 as Stock_Qty,
coptds.TD003 as STT
 from COPTC coptcs
left join COPTD  coptds on coptcs.TC002 = coptds.TD002  and coptcs.TC001 = coptds.TD001 -- cong doan tao don
inner join COPMA copmas on copmas.MA001 = coptcs.TC004
left join INVMB invmbs on invmbs.MB001 = coptds.TD004
left join CMSME cmsmes on cmsmes.ME001 = coptcs.TC005
where 1=1  
and  coptcs.TC027 = 'Y' and coptds.TD016  ='N' and coptds.TD009 < coptds.TD008
 ");


                //  sql.Append(" and CONVERT(date,coptds.TD013)  >= '" + datefrom + "' ");
                sql.Append(" and CONVERT(date,coptds.TD013) <= '" + dateto.ToString("yyyyMMdd") + "' ");

                sql.Append("order by coptds.TD013");
                sqlERPCON con = new sqlERPCON();
                con.sqlDataAdapterFillDatatable(sql.ToString(), ref dtShipping);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataProductionOrder() : " , ex.Message);
            }
            return dtShipping;
        }
        private void GetDataFromShipping()
        {
            //DateTime dtnow = DateTime.Now;
            //DateTime datefrom = new DateTime(dtnow.Year, 1, 1);
            //DateTime dateto = new DateTime(dtnow.Year, 12, 31);
            dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select
TH014, TH015,TH004,
sum(a.TH008) as Delivery_Quantity,
max(b.TG003) as Delivery_Date,
TH016
from COPTH a
inner join COPTG  b on a.TH001 = b.TG001 and a.TH002 = b.TG002
where TG023 ='Y' and TH014 !='' and TH015 != ''
 ");


            // sql.Append(" and CONVERT(date,coptds.TD013)  >= '" + datefrom + "' ");
            //    sql.Append(" and CONVERT(date,coptds.TD013) <= '" + dateto + "' ");
            sql.Append(@"group by
TH014,
TH015,
TH004,
TH016
                                    ");
            sql.Append("order by TH014, TH015, TH004");
            sqlERPCON con = new sqlERPCON();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
        }

        public void GetDataBackLogToExport()
        {

            try
            {

                GetDataProductionOrder();
                ListOrderData = new List<OrderData>();
                if (dtShipping.Rows.Count > 0)
                {
                    ListOrderData = ListGetOrderData(dtShipping);
                }
                GetDataFromShipping();
                if (dt.Rows.Count > 0)
                {
                    ListShipping = ListGetDataShipping(dt);
                }

                listShipingResult = new List<FinalItemsReport>();
                foreach (var Order in ListOrderData)
                {
                    //if(Order.OrderCode.Trim() == "A221-1810036")
                    //{
                    //    ;
                    //}

                    FinalItemsReport inf = new FinalItemsReport();
                    List<SemiFinishedgoods> listSemi = new List<SemiFinishedgoods>();
                    inf.Department = Order.Departments_code;
                    inf.OrderCode = Order.OrderCode;
                    inf.Product = Order.Product_Code;
                    inf.Clients = Order.ClientsName;
                    inf.ClientsRequestDate = Order.Client_Request_Date;
                    inf.Clients_OrderCode = Order.Clients_Order_Code;
                    inf.Quantity = Order.Order_Quantity;
                    inf.Stock_Quantity = Order.Fisnished_Goods;



                    listSemi = GetSemibyNameProduct(inf.Product);
                    if (listSemi.Count > 0)
                    {
                        if (listSemi.Count == 1)
                        {
                            inf.Semi_FinishedGoods = listSemi[0].Semi_finishedGoods;
                            inf.Semi_FinishedGoods_avaiable = listSemi[0].Stock;
                        }
                        else if (listSemi.Count > 1)
                        {
                            listSemi = listSemi.OrderBy(d => d.Stock).ToList();
                            inf.Semi_FinishedGoods = listSemi[0].Semi_finishedGoods;
                            inf.Semi_FinishedGoods_avaiable = listSemi[0].Stock;
                        }
                        foreach (var item in listSemi)
                        {
                            inf.Semi_Quantity += item.Semi_finishedGoods + " (QTy:) " + item.Stock.ToString() + "\r\n";

                        }
                    }

                    inf.OverDueDate = (DateTime.Now.Date - inf.ClientsRequestDate.Date).Days;
                    var ListProduct = ListShipping
                        .Where(w => w.OrderCode.Trim() == inf.OrderCode.Trim() && w.Product_Code.Trim() == inf.Product.Trim() && w.STT.Trim() == Order.STT.Trim())
                        .Select(d => new { d.Shipped_Quantity, d.Shipped_Date }).Distinct().ToArray();
                    if (ListProduct.Count() > 0)
                    {
                        inf.Shipped_Quantity = ListProduct[0].Shipped_Quantity;
                        inf.DeliveryDate = ListProduct[0].Shipped_Date;
                        inf.ShippingPercents = inf.Shipped_Quantity / inf.Quantity;
                        if (inf.ShippingPercents < 1)
                            inf.Remain_Quantity = inf.Quantity - inf.Shipped_Quantity;
                        else inf.Remain_Quantity = 0;
                        if (inf.ShippingPercents < 1)
                        {
                            if (inf.Stock_Quantity + inf.Semi_FinishedGoods_avaiable < inf.Remain_Quantity && DateTime.Now.Date >= Order.Client_Request_Date)
                            {
                                inf.Status = "Back Log";
                            }


                            else if (DateTime.Now.Date >= Order.Client_Request_Date && inf.Stock_Quantity + inf.Semi_FinishedGoods_avaiable >= inf.Remain_Quantity)
                            {

                                inf.Status = "Back Log";
                            }

                            else if (Order.Client_Request_Date > DateTime.Now.Date)
                            {
                                inf.Status = "Open Order";
                            }
                        }

                        else
                        {

                            if (ListProduct[0].Shipped_Date > Order.Client_Request_Date)
                            {
                                inf.Status = "Shipped-Late";
                            }

                            else if (ListProduct[0].Shipped_Date <= Order.Client_Request_Date)
                            {
                                inf.Status = "Shipped-On Time";
                            }
                            else inf.Status = "Shipped-UnDefine";

                        }
                    }
                    else
                    {

                        inf.Shipped_Quantity = 0;
                        inf.DeliveryDate = DateTime.MinValue;
                        inf.ShippingPercents = 0;
                        inf.Remain_Quantity = inf.Quantity;

                        if (inf.ShippingPercents < 1)
                        {
                            if (inf.Stock_Quantity + inf.Semi_FinishedGoods_avaiable < inf.Remain_Quantity && DateTime.Now.Date >= Order.Client_Request_Date)
                            {
                                inf.Status = "Back Log";
                            }


                            else if (inf.Stock_Quantity + inf.Semi_FinishedGoods_avaiable >= inf.Remain_Quantity && DateTime.Now.Date >= Order.Client_Request_Date)
                            {

                                inf.Status = "Back Log";
                            }

                            else if (Order.Client_Request_Date > DateTime.Now.Date)
                            {
                                inf.Status = "Open Order";
                            }
                        }


                    }


                    listShipingResult.Add(inf);
                }
                //   listBackLog = listShipingResult;
                if (listShipingResult != null && listShipingResult.Count > 0)
                {
                    listBackLog = listShipingResult.Where(d => d.Status == "Back Log" && d.OrderCode.Contains("A221-1907232") == false).OrderBy(d => d.OrderCode).ToList();

                }
                //if (listShipingResult != null && listShipingResult.Count > 0)
                //{
                //    listBackLog = listShipingResult.Where(d => d.OrderCode.Trim() == "A222-1910018").ToList();

                //}

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, " GetDataToExport ", ex.Message);


            }


        }
        private List<DataShipping> ListGetDataShipping(DataTable dta)
        {
            List<DataShipping> listOrderData = new List<DataShipping>();
            for (int i = 0; i < dta.Rows.Count; i++)
            {


                DataShipping shp = new DataShipping();
                shp.OrderCode = (string)dta.Rows[i][0].ToString().Trim() + "-" + (string)dta.Rows[i][1].ToString().Trim();
                shp.Product_Code = (string)dta.Rows[i][2].ToString().Trim();
                shp.Shipped_Quantity = (string)dta.Rows[i][3].ToString() == "" ? 0 : Math.Round(double.Parse(dta.Rows[i][3].ToString().Trim()), 2);
                shp.Shipped_Date = ((string)dta.Rows[i][4].ToString() == "") ? DateTime.MinValue : DateTime.Parse(dta.Rows[i][4].ToString().Trim().Insert(4, "-").Insert(7, "-"));
                shp.STT = (string)dta.Rows[i][5].ToString().Trim();
                listOrderData.Add(shp);



            }


            return listOrderData;
        }
        private List<OrderData> ListGetOrderData(DataTable dta)
        {
            List<OrderData> listOrderData = new List<OrderData>();
            for (int i = 0; i < dta.Rows.Count; i++)
            {
                if (dta.Rows[i][12].ToString() == "N")
                {

                    OrderData or = new OrderData();
                    or.OrderCode = (string)dta.Rows[i][0] + "-" + (string)dta.Rows[i][1];

                    or.Departments_code = (dta.Rows[i][2] != null && dta.Rows[i][2].ToString() != "") ? dta.Rows[i][2].ToString().Trim() : "N/A";
                    or.ClientsName = (string)dta.Rows[i][3].ToString().Trim();
                    or.Clients_Order_Code = (string)dta.Rows[i][4].ToString().Trim();
                    or.Product_Code = (string)dta.Rows[i][5].ToString().Trim();
                    or.Product_Name = (string)dta.Rows[i][6].ToString().Trim();
                    or.unit = (string)dta.Rows[i][7].ToString().Trim();
                    or.Departments = (string)dta.Rows[i][8].ToString().Trim();
                    or.Client_Request_Date = ((string)dta.Rows[i][9].ToString() == "") ? DateTime.MinValue : DateTime.Parse(dta.Rows[i][9].ToString().Trim().Insert(4, "-").Insert(7, "-"));
                    or.Order_Quantity = (string)dta.Rows[i][10].ToString() == "" ? 0 : Math.Round(double.Parse(dta.Rows[i][10].ToString().Trim()), 2);
                    or.Shipped_Quantity = (string)dta.Rows[i][11].ToString() == "" ? 0 : Math.Round(double.Parse(dta.Rows[i][11].ToString().Trim()), 2);

                    or.StatusOFOrder = (string)dta.Rows[i][12].ToString().Trim();
                    or.Fisnished_Goods = (string)dta.Rows[i][13].ToString() == "" ? 0 : Math.Round(double.Parse(dta.Rows[i][13].ToString().Trim()), 2);
                    or.STT = (string)dta.Rows[i][14].ToString().Trim();
                    listOrderData.Add(or);

                }

            }
            var ListItems = listOrderData
        .GroupBy(u => u.Product_Code)
        .Select(grp => grp.ToList())
        .ToList();
            var ListProduct = listOrderData.Select(d => new { d.Product_Code, d.Fisnished_Goods }).Distinct().ToDictionary(k => k, v => v);

            return listOrderData;
        }
        private string Tenbophan(string ME001, string TC001)
        {
            string tenBophan = "";
            DataTable dtRecord = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append("select distinct a.ME002 from CMSME a inner join COPTC c on a.ME001 = c.TC005 where ");
            sql.Append(" a.ME001 = '" + ME001 + "' ,");
            sql.Append(" c.TC001 = '" + TC001 + "'");

            sqlCON tf = new sqlCON();
            tenBophan = tf.sqlExecuteScalarString(sql.ToString());
            return tenBophan;
        }

        public List<BOMItems> bOMItems(string NameProduct)
        {
            List<BOMItems> bOMItems = new List<BOMItems>();
            try
            {

                DataTable dt = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append("select MD001,MD003,MD006,MD012 from BOMMD where  1=1 and MD003 like '%B-%' ");
                sql.Append(" and MD001 = '" + NameProduct + "'");
                sqlERPCON sqlCON = new sqlERPCON();
                sqlCON.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
                bOMItems = (from DataRow dr in dt.Rows
                            select new BOMItems()
                            {
                                finishedGoods = dr["MD001"].ToString().Trim(),
                                SemiFinishedgoods = dr["MD003"].ToString().Trim(),
                                Rate = (dr["MD006"].ToString() != "") ? double.Parse(dr["MD006"].ToString().Trim()) : 0,
                                Expired = (dr["MD012"].ToString() != "") ? DateTime.Parse(dr["MD012"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MaxValue
                            }).ToList();

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "bOMItems (string NameProduct)", ex.Message);
            }

            return bOMItems;
        }
        public List<StockOfSemi> stockOfSemis(string SemiProduct, double rate)
        {
            List<StockOfSemi> Semis = new List<StockOfSemi>();
            try
            {


                DataTable dt = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append("select MC001,MC002,MC007 from INVMC where  (MC002 = 'A03' or MC002 = 'A09') ");
                sql.Append(" and MC001 = '" + SemiProduct + "'");
                sqlERPCON sqlCON = new sqlERPCON();
                sqlCON.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
                Semis = (from DataRow dr in dt.Rows
                         select new StockOfSemi()
                         {
                             Semi = dr["MC001"].ToString().Trim(),

                             Stock = (dr["MC007"].ToString() != "" && rate != 0) ? Math.Round((double.Parse(dr["MC007"].ToString()) / rate), 0) : 0,
                             Warehourse = dr["MC002"].ToString().Trim()
                         }).ToList();
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "stockOfSemis(string SemiProduct, double rate)", ex.Message);
            }
            return Semis;
        }
        public List<SemiFinishedgoods> GetSemibyNameProduct(string NameProduct)
        {
            List<SemiFinishedgoods> semiFinishedgoods = new List<SemiFinishedgoods>();
            try
            {


                // List<SemiFinishedgoods> semiFinishedgoods = new List<SemiFinishedgoods>();
                List<BOMItems> listBOM = bOMItems(NameProduct);
                List<StockOfSemi> stockSemis = new List<StockOfSemi>();
                List<List<StockOfSemi>> listofSemis = new List<List<StockOfSemi>>();
                if (listBOM != null && listBOM.Count > 0)
                {
                    foreach (var item in listBOM)
                    {
                        if (item.Expired > DateTime.Now)
                        {
                            stockSemis = new List<StockOfSemi>();
                            stockSemis = stockOfSemis(item.SemiFinishedgoods, item.Rate);
                            if (stockSemis != null && stockSemis.Count > 0)
                                listofSemis.Add(stockSemis);
                        }
                    }

                    foreach (var item in listofSemis)
                    {
                        SemiFinishedgoods semi1 = new SemiFinishedgoods();
                        semi1.Semi_finishedGoods = item[0].Semi;
                        semi1.Stock = item.Select(d => d.Stock).Sum();
                        semiFinishedgoods.Add(semi1);
                    }
                }
            }
            catch (Exception ex)
            {

             //   SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetSemibyNameProduct", ex.Message);
            }
            return semiFinishedgoods;
        }
    }
    public class StatusSumary
    {
        public string OrderCode { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public string ClientsRequestDate { get; set; }

    }
    public class ShippingItems
    {
        public string OrderCode { get; set; }
        public string Clients { get; set; }
        public string Clients_OrderCode { get; set; }
        public string Product { get; set; }
        public double Quantity { get; set; }
        public DateTime ClientsRequestDate { get; set; }
        public double Shipped_Quantity { get; set; }
        public DateTime DeliveryDate { get; set; }
        public double Remain_Quantity { get; set; }
        public double Stock_Quantity { get; set; }
        public double ShippingPercents { get; set; }
        public string Status { get; set; }
        // public double shipped_Quantity { get; set; }
    }

    public class FinalItemsReport
    {
        public string Department { get; set; }
        public string OrderCode { get; set; }
        public string Clients { get; set; }
        public string Clients_OrderCode { get; set; }
        public string Product { get; set; }
        public double Quantity { get; set; }
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
    public class OrderData
    {
        public string OrderCode { get; set; }
        public string STT { get; set; }
        public DateTime DateOrder { get; set; }
        public string Departments_code { get; set; }
        public string Departments { get; set; }
        public string ClientsName { get; set; }
        public string Clients_Order_Code { get; set; }
        public string Product_Code { get; set; }
        public string Product_Name { get; set; }
        public string unit { get; set; }
        public DateTime Client_Request_Date { get; set; }
        public double Order_Quantity { get; set; }
        public double Shipped_Quantity { get; set; }
        public string StatusOFOrder { get; set; }
        public double Fisnished_Goods { get; set; }

    }
    public class SemiFinishedgoods
    {
        public string Semi_finishedGoods { get; set; }
        public double Stock { get; set; }
    }
    public class DataShipping
    {
        public string OrderCode { get; set; }
        public string Product_Code { get; set; }
        public string STT { get; set; }
        public double Shipped_Quantity { get; set; }
        public DateTime Shipped_Date { get; set; }
    }
    public class BOMItems
    {
        public string finishedGoods { get; set; }
        public string SemiFinishedgoods { get; set; }
        public double Rate { get; set; }
        public DateTime Expired { get; set; }
    }
    public class StockOfSemi
    {
        public string Semi { get; set; }
        public double Stock { get; set; }
        public string Warehourse { get; set; }
    }
}
