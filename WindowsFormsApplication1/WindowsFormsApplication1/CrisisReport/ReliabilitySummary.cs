using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1.CrisisReport
{
    class ReliabilitySummary
    {

            DataTable dtShipping;

            DataTable dt;
            List<FinalItemsReport> listShipingResult = new List<FinalItemsReport>();
            List<FinalItemsReport> listBackLog = new List<FinalItemsReport>();

            List<OrderData> ListOrderData = new List<OrderData>();
            List<DataShipping> ListShipping = new List<DataShipping>();


            private string path = Environment.CurrentDirectory + @"\Resources\BackLogForm2.xlsx";
            private string pathSave = Environment.CurrentDirectory + @"\Resources\";

       
            private void GetDataProductionOrder(DateTime datefrom, DateTime dateto)
            {
                try
                {

                  
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
invmbs.MB064 as Stock_Qty
 from COPTC coptcs
left join COPTD  coptds on coptcs.TC002 = coptds.TD002  and coptcs.TC001 = coptds.TD001 -- cong doan tao don
inner join COPMA copmas on copmas.MA001 = coptcs.TC004
left join INVMB invmbs on invmbs.MB001 = coptds.TD004
left join CMSME cmsmes on cmsmes.ME001 = coptcs.TC005
where 1=1  
and  coptcs.TC027 = 'Y' 
 ");


                    sql.Append(" and CONVERT(date,coptds.TD013)  >= '" + datefrom + "' ");
                    sql.Append(" and CONVERT(date,coptds.TD013) <= '" + dateto + "' ");

                    sql.Append("order by coptds.TD013");
                    sqlERPCON con = new sqlERPCON();
                    con.sqlDataAdapterFillDatatable(sql.ToString(), ref dtShipping);
                }
                catch (Exception ex)
                {

                   SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataProductionOrder() : " , ex.Message);
                }
            }



            private void GetDataFromShipping(DateTime datefrom, DateTime dateto)
            {
              
                dt = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append(@"select
coptcs.TC001 as Code_Type, 
coptcs.TC002 as Code_No,
coptds.TD004 as Product_Code,
sum(copths.TH008) as Delivery_Quantity,
max(coptgs.TG003) as Delivery_Date
 from COPTC coptcs
left join COPTD  coptds on coptcs.TC002 = coptds.TD002  and coptcs.TC001 = coptds.TD001 -- cong doan tao don
left join COPTH copths on coptcs.TC002 = copths.TH015 and  coptcs.TC001 = copths.TH014 and copths.TH004 =coptds.TD004
left join COPTG coptgs on copths.TH002  = coptgs.TG002 and copths.TH001  = coptgs.TG001 --cong doan giao hang
where 1=1  
and  coptcs.TC027 = 'Y' and coptgs.TG023 ='Y'
 ");


                sql.Append(" and CONVERT(date,coptds.TD013)  >= '" + datefrom + "' ");
                sql.Append(" and CONVERT(date,coptds.TD013) <= '" + dateto + "' ");
                sql.Append(@"group by 
                                   coptcs.CREATE_DATE,
                                    coptcs.TC001 ,
                                    coptcs.TC002 ,
                                   coptds.TD004
                                    ");
                sql.Append("order by coptcs.TC001, coptcs.TC002");
                sqlERPCON con = new sqlERPCON();
                con.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            }

            public List<FinalItemsReport> GetDataBackLogToExport(DateTime date_from, DateTime date_to)
            {
            List<FinalItemsReport> listSummary = new List<FinalItemsReport>();
                try
                {

                    GetDataProductionOrder(date_from, date_to);
                    ListOrderData = new List<OrderData>();
                    if (dtShipping.Rows.Count > 0)
                    {
                        ListOrderData = ListGetOrderData(dtShipping);
                    }
                    GetDataFromShipping(date_from, date_to);
                if (dt.Rows.Count > 0)
                    {
                        ListShipping = ListGetDataShipping(dt);
                    }

                    listShipingResult = new List<FinalItemsReport>();
                    foreach (var Order in ListOrderData)
                    {
                        FinalItemsReport inf = new FinalItemsReport();
                        inf.Department = Order.Departments_code;
                        inf.OrderCode = Order.OrderCode;
                        inf.Product = Order.Product_Code;
                        inf.Clients = Order.ClientsName;
                        inf.ClientsRequestDate = Order.Client_Request_Date;
                        inf.Clients_OrderCode = Order.Clients_Order_Code;
                        inf.Quantity = Order.Order_Quantity;
                        inf.Stock_Quantity = Order.Fisnished_Goods;
                        inf.OverDueDate = (DateTime.Now.DayOfYear - inf.ClientsRequestDate.DayOfYear);
                        var ListProduct = ListShipping
                            .Where(w => w.OrderCode == inf.OrderCode && w.Product_Code == inf.Product)
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
                                if (inf.Stock_Quantity < inf.Remain_Quantity && DateTime.Now.Date >= Order.Client_Request_Date)
                                {
                                    inf.Status = "Back Log";
                                }


                                else if (DateTime.Now.Date >= Order.Client_Request_Date && inf.Stock_Quantity >= inf.Remain_Quantity)
                                {

                                    inf.Status = "Late";
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
                                if (inf.Stock_Quantity < inf.Remain_Quantity && DateTime.Now.Date >= Order.Client_Request_Date)
                                {
                                    inf.Status = "Back Log";
                                }


                                else if (inf.Stock_Quantity >= inf.Remain_Quantity && DateTime.Now.Date >= Order.Client_Request_Date)
                                {

                                    inf.Status = "Late";
                                }

                                else if (Order.Client_Request_Date > DateTime.Now.Date)
                                {
                                    inf.Status = "Open Order";
                                }
                            }


                        }


                    listSummary.Add(inf);
                    }

                  


                }
                catch (Exception ex)
                {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataBackLogToExport(DateTime date_from, DateTime date_to)", ex.Message);


                }
            return listSummary;


            }
            private List<DataShipping> ListGetDataShipping(DataTable dta)
            {
                List<DataShipping> listOrderData = new List<DataShipping>();
                for (int i = 0; i < dta.Rows.Count; i++)
                {
                    DataShipping shp = new DataShipping();
                    shp.OrderCode = (string)dta.Rows[i][0] + "-" + (string)dta.Rows[i][1];
                    shp.Product_Code = (string)dta.Rows[i][2];
                    shp.Shipped_Quantity = (string)dta.Rows[i][3].ToString() == "" ? 0 : Math.Round(double.Parse(dta.Rows[i][3].ToString()), 2);
                    shp.Shipped_Date = ((string)dta.Rows[i][4].ToString() == "") ? DateTime.MinValue : DateTime.Parse(dta.Rows[i][4].ToString().Insert(4, "-").Insert(7, "-"));

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
                        //if(or.Departments_code == null)
                        //{
                        //    or.Departments_code = Tenbophan()
                        //}
                        or.Departments_code = (dta.Rows[i][2] != null && dta.Rows[i][2].ToString() != "") ? dta.Rows[i][2].ToString() : "N/A";
                        or.ClientsName = (string)dta.Rows[i][3];
                        or.Clients_Order_Code = (string)dta.Rows[i][4];
                        or.Product_Code = (string)dta.Rows[i][5];
                        or.Product_Name = (string)dta.Rows[i][6];
                        or.unit = (string)dta.Rows[i][7];
                        or.Departments = (string)dta.Rows[i][8];
                        or.Client_Request_Date = ((string)dta.Rows[i][9].ToString() == "") ? DateTime.MinValue : DateTime.Parse(dta.Rows[i][9].ToString().Insert(4, "-").Insert(7, "-"));
                        or.Order_Quantity = (string)dta.Rows[i][10].ToString() == "" ? 0 : Math.Round(double.Parse(dta.Rows[i][10].ToString()), 2);
                        or.Shipped_Quantity = (string)dta.Rows[i][11].ToString() == "" ? 0 : Math.Round(double.Parse(dta.Rows[i][11].ToString()), 2);

                        or.StatusOFOrder = (string)dta.Rows[i][12];
                        or.Fisnished_Goods = (string)dta.Rows[i][13].ToString() == "" ? 0 : Math.Round(double.Parse(dta.Rows[i][13].ToString()), 2);
                        listOrderData.Add(or);

                    }

                }
             

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
        
    }
    class StatusSumary
    {
        public string OrderCode { get; set; }
        public string Status { get; set; }
        public int Quantity { get; set; }
        public string ClientsRequestDate { get; set; }

    }
    class ShippingItems
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

    class FinalItemsReport
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
        public double ShippingPercents { get; set; }
        public int OverDueDate { get; set; }
        public string Status { get; set; }
        // public double shipped_Quantity { get; set; }
    }
    class OrderData
    {
        public string OrderCode { get; set; }
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
    class StockData
    {
        public string Production { get; set; }
        public double Stock { get; set; }
    }
    class DataShipping
    {
        public string OrderCode { get; set; }
        public string Product_Code { get; set; }
        public double Shipped_Quantity { get; set; }
        public DateTime Shipped_Date { get; set; }
    }
}
