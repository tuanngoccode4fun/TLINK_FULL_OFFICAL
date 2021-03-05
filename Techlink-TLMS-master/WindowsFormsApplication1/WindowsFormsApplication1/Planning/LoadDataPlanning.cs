using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WindowsFormsApplication1.Class;
using WindowsFormsApplication1.Planning.Controler;
namespace WindowsFormsApplication1.Planning
{
    class LoadDataPlanning
    {
        public List<OrderVariable> LoadOrderInformationbyDate(DateTime from, DateTime to, string Clients)
        {
            List<OrderVariable> orderVariables = new List<OrderVariable>();
            try
            {
                DataTable dt = new DataTable();
                sqlERPCON sqlERPCON = new sqlERPCON();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select smes.ME002 as Dept,TD001 + '-' + TD002 as DDH, TC012 as ClientOrder,TD004 as product ,TD005 as productName,
sum(TD008) as QuantityOfOrder, sum(TD009) as QuantityOfDelivery, TD013 as ClientRequestDate from COPTD ptd
inner join COPTC ptc on ptc.TC001 = ptd.TD001 and ptc.TC002 = ptd.TD002
left join CMSME smes on smes.ME001 = ptc.TC005
where  ptc.TC027 ='Y' and TD001 like '%B%' and TD016 ='N'
");
                if(Clients == "MH")
                stringBuilder.Append(" and ( TD004 like '%BMH%' or  TD004 like '%BWTX%') ");
                else if (Clients == "FF")
                    stringBuilder.Append(" and ( TD004 like '%BFF%' ) ");

                stringBuilder.Append(" and CONVERT(date,ptd.TD013)  >= '" + from.ToString("yyyyMMdd") + "' ");
                stringBuilder.Append(" and CONVERT(date,ptd.TD013) <= '" + to.ToString("yyyyMMdd") + "' ");
                stringBuilder.Append(@" group by TD001,TC012, TD002,TD005, TD013,smes.ME002,TD004
order by TD013 ");

                sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                foreach (DataRow dr in dt.Rows)
                {
                    OrderVariable order = new OrderVariable();
                    order.Dept = (dr["Dept"] != null) ? dr["Dept"].ToString().Trim() : "";
                    order.DDH = (dr["DDH"] != null) ? dr["DDH"].ToString().Trim() : "";
                    order.ClientOrder = (dr["ClientOrder"] != null) ? dr["ClientOrder"].ToString().Trim() : "";
                    order.Product = (dr["product"] != null) ? dr["product"].ToString().Trim() : "";
                    order.ProductName = (dr["productName"] != null) ? dr["productName"].ToString().Trim() : "";
                    order.ClientOrderQty = (dr["QuantityOfOrder"] != null && dr["QuantityOfOrder"].ToString() != "") ? (double.Parse(dr["QuantityOfOrder"].ToString().Trim())) : 0;
                    order.DeliveryQty = (dr["QuantityOfDelivery"] != null && dr["QuantityOfDelivery"].ToString() != "") ? (double.Parse(dr["QuantityOfDelivery"].ToString().Trim())) : 0;
                    order.DeliveryOverQty = QuantityOfNotYetDelivery(order.DDH.Split('-')[0], order.DDH.Split('-')[1], order.Product,from);
                    order.ClientOrderQty = order.ClientOrderQty - order.DeliveryOverQty- order.DeliveryQty;
                    order.ClientRequestDate = (dr["ClientRequestDate"] != null && dr["ClientRequestDate"].ToString() != "") ? DateTime.Parse(dr["ClientRequestDate"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue;
                    orderVariables.Add(order);
                }
             
                //orderVariables = (from DataRow dr in dt.Rows
                //                  select new OrderVariable()
                //                  {
                //                      Dept = (dr["Dept"] != null) ? dr["Dept"].ToString().Trim() : "",
                //                      DDH = (dr["DDH"] != null) ? dr["DDH"].ToString().Trim() : "",
                //                      ClientOrder = (dr["ClientOrder"] != null) ? dr["ClientOrder"].ToString().Trim() : "",
                //                      Product = (dr["product"] != null) ? dr["product"].ToString().Trim() : "",
                //                      ProductName = (dr["productName"] != null) ? dr["productName"].ToString().Trim() : "",
                //                      ClientOrderQty = (dr["QuantityOfOrder"] != null && dr["QuantityOfOrder"].ToString() != "") ? (double.Parse(dr["QuantityOfOrder"].ToString().Trim())) : 0,
                //                      DeliveryQty = (dr["QuantityOfDelivery"] != null && dr["QuantityOfDelivery"].ToString() != "") ? (double.Parse(dr["QuantityOfDelivery"].ToString())) : 0,
                //                      ClientRequestDate = (dr["ClientRequestDate"] != null && dr["ClientRequestDate"].ToString() != "") ? DateTime.Parse(dr["ClientRequestDate"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue
                //                  }).ToList();
                
            }
            catch (Exception)
            {

                return null;
            }
            return orderVariables;
        }

        public List<OrderVariable> LoadOrderInformationbyDatebyDept(DateTime from, DateTime to, string DeptCients)
        {
            List<OrderVariable> orderVariables = new List<OrderVariable>();
            try
            {
                DataTable dt = new DataTable();
                sqlERPCON sqlERPCON = new sqlERPCON();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select smes.ME002 as Dept,TD001 + '-' + TD002 as DDH, TC012 as ClientOrder,TD004 as product ,TD005 as productName,
sum(TD008) as QuantityOfOrder, sum(TD009) as QuantityOfDelivery,TD010 as Unit, TD013 as ClientRequestDate from COPTD ptd
inner join COPTC ptc on ptc.TC001 = ptd.TD001 and ptc.TC002 = ptd.TD002
left join CMSME smes on smes.ME001 = ptc.TC005
where  ptc.TC027 ='Y'  and TD016 ='N'
");
                if (DeptCients == "B01-MH")
                    stringBuilder.Append("  and TD001 like 'B%' and ( TD004 like '%BMH%' or  TD004 like '%BWTX%') ");
                else if (DeptCients == "B01-FF")
                    stringBuilder.Append("  and TD001 like 'B%' and ( TD004 like '%BFF%' ) ");
                else if (DeptCients == "A01-Gia Dung")
                    stringBuilder.Append(" and TD001 like 'A%' ");
                else if (DeptCients == "A01-PTC")
                    stringBuilder.Append(" and TD001 like 'P%' ");
                else if (DeptCients == "A01-MH")
                    stringBuilder.Append("and TD001 like 'J%' and TD004 like 'JMH%' ");
                else if (DeptCients == "A01-JM")
                    stringBuilder.Append(" and TD001 like 'J%' and TD004 like 'JM%' ");

                stringBuilder.Append(" and CONVERT(date,ptd.TD013)  >= '" + from.ToString("yyyyMMdd") + "' ");
                stringBuilder.Append(" and CONVERT(date,ptd.TD013) <= '" + to.ToString("yyyyMMdd") + "' ");
                stringBuilder.Append(@" group by TD001,TC012, TD002,TD005,TD010, TD013,smes.ME002,TD004
order by TD013 ");

                sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                foreach (DataRow dr in dt.Rows)
                {
                    OrderVariable order = new OrderVariable();
                    order.Dept = (dr["Dept"] != null) ? dr["Dept"].ToString().Trim() : "";
                    order.DDH = (dr["DDH"] != null) ? dr["DDH"].ToString().Trim() : "";
                    order.ClientOrder = (dr["ClientOrder"] != null) ? dr["ClientOrder"].ToString().Trim() : "";
                    order.Unit = (dr["Unit"] != null) ? dr["Unit"].ToString().Trim() : "";
                    order.Product = (dr["product"] != null) ? dr["product"].ToString().Trim() : "";
                    order.ProductName = (dr["productName"] != null) ? dr["productName"].ToString().Trim() : "";
                    order.ClientOrderQty = (dr["QuantityOfOrder"] != null && dr["QuantityOfOrder"].ToString() != "") ? (double.Parse(dr["QuantityOfOrder"].ToString().Trim())) : 0;
                    order.DeliveryQty = (dr["QuantityOfDelivery"] != null && dr["QuantityOfDelivery"].ToString() != "") ? (double.Parse(dr["QuantityOfDelivery"].ToString().Trim())) : 0;
                    order.DeliveryOverQty = QuantityOfNotYetDelivery(order.DDH.Split('-')[0], order.DDH.Split('-')[1], order.Product, from);
                 //   order.ClientOrderQty = order.ClientOrderQty - order.DeliveryOverQty - order.DeliveryQty;
                    order.ClientRequestDate = (dr["ClientRequestDate"] != null && dr["ClientRequestDate"].ToString() != "") ? DateTime.Parse(dr["ClientRequestDate"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue;
                    orderVariables.Add(order);
                }

              

            }
            catch (Exception)
            {

                return null;
            }
            return orderVariables;
        }
        public double QuantityOfNotYetDelivery(string TD001_Ma, string TD002_Code, string TD004_product,DateTime to)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"select sum(TD008) - sum(TD009) as NeedQty from COPTD
where 1=1 and( (TD016 ='y' and TD009 !='0') or (TD016 =='Y' ) or  (TD016 ='N' and TD009 !='0')) 
");
//            stringBuilder.Append(@"select sum(TD008) - sum(TD009) as NeedQty from COPTD
//where 1=1 and( (TD016 ='y' and TD009 !='0') or (TD016 !='y' ) ) and TD016 !='N'
//");
            stringBuilder.Append(" and TD001 ='" + TD001_Ma + "' ");
            stringBuilder.Append(" and TD002 ='" + TD002_Code + "' ");
            stringBuilder.Append(" and TD004 ='" + TD004_product + "' ");
            stringBuilder.Append(" and TD004 ='" + TD004_product + "' ");         
            stringBuilder.Append(" and CONVERT(date,TD013) <= '" + to.ToString("yyyyMMdd") + "' ");
            sqlERPCON sqlERPCON = new sqlERPCON();
            string strNeedQty = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
            if (strNeedQty != null && strNeedQty != "")
                return double.Parse(strNeedQty);
            return 0;
        }
        public Dictionary<string, PlanningItem> GetPlanningReport (List<OrderVariable> orders )
        {
            Dictionary<string, PlanningItem> keyValuePairs = new Dictionary<string, PlanningItem>();
            List<List<OrderVariable>> listOders = new List<List<OrderVariable>>();
            listOders = ListOrdervariables(orders);
            List<SettingBOM> listSettingBoms = LoadingSettingBOMs();
            List<SettingManufacture> lisSettingManufactures = LoadingSettingManufacture();
            SFT_WIP sFT_WIP = new SFT_WIP();
            
            try
            {

                foreach (var order in listOders)
                {
                    PlanningItem pLanning = new PlanningItem();
                    pLanning.KeyProduct = order[0].Product;
                    // base on product to defind Dept
                   
                    if(order[0].Product.Contains("BMH"))
                    {
                        pLanning.Client = "MH";
                    }
                    else
                    {
                        pLanning.Client = order[0].Product.Replace(order[0].ProductName, "").Substring(1);
                    }
                    // Define Shiment Plan of production
                    pLanning.shipmentPlans = new List<ShipmentPlan>();
                    pLanning.needProduceQties = new List<NeedProduceQty>();
                    foreach (var or in order)
                    {
                        ShipmentPlan shipment = new ShipmentPlan();
                        shipment.ClientRequestDate = or.ClientRequestDate;
                        shipment.ClientCode = or.ClientOrder;
                        shipment.DeliveryPlanQty = or.ClientOrderQty;
                        shipment.NeedQty = or.ClientOrderQty;
                        shipment.RemainDay = (or.ClientRequestDate - DateTime.Now.Date).Days;
                        shipment.NeedQtyPerDay = shipment.NeedQty / shipment.RemainDay;
                        shipment.OrderCode = or.DDH;
                        pLanning.shipmentPlans.Add(shipment);

                        NeedProduceQty need = new NeedProduceQty();
                        need.ClientRequestDate = or.ClientRequestDate;
                        need.NeedQty = or.ClientOrderQty;
                        need.RemainDay =( or.ClientRequestDate - DateTime.Now.Date).Days;
                        need.NeedQtyPerDay = need.NeedQty / need.RemainDay;
                        pLanning.needProduceQties.Add(need);
                    }
                    pLanning.TotalQty = pLanning.shipmentPlans.Select(d => d.DeliveryPlanQty).Sum();
                    pLanning._bom = new BOM();
                    List<string> ListHENN = ListHENNofProduct(pLanning.KeyProduct);
                   if(ListHENN != null)
                    {
                        pLanning._bom.HEN = new string[ListHENN.Count];
                        pLanning._bom.HENStock = new double[ListHENN.Count];
                        pLanning._bom.StrHENStock = new string[ListHENN.Count];

                        for (int i = 0; i < ListHENN.Count; i++)
                        {
                            pLanning._bom.HEN [i]= ListHENN[i];
                           
                            pLanning._bom.HENStock[i] = StockOfHENN(ListHENN[i]);

                        }
                       
                    }
                   else
                    {
                        pLanning._bom.HEN = new string[1];
                        pLanning._bom.HENStock = new double[1];
                        pLanning._bom.StrHENStock = new string[1];
                    }
                    var _bom = listSettingBoms.Where(d => d.ProductName == pLanning.KeyProduct).ToList();
                    if (_bom.Count > 0)
                    {
                        pLanning._bom.QtyUnit = _bom[0].QtyInBox;
                        pLanning._bom.ToolQty = _bom[0].QtyTool;
                    }
                    pLanning.wip = new Wip();
                    pLanning.wip.Warehouse = StockOfProduct(order[0].Product);
                 
                    pLanning.production = new Production();
                    var _productItem = lisSettingManufactures.Where(d => d.ProductName == pLanning.KeyProduct).ToList();
                    if(_productItem.Count > 0)
                    {
                        pLanning.production.ProductionQty = _productItem[0].PlanQty;
                        pLanning.production.targetPeople = _productItem[0].Workertarget;
                        pLanning.production.PeopleQty =(pLanning.production.targetPeople==0) ? 0: pLanning.production.ProductionQty / pLanning.production.targetPeople;
                    }
                    sFT_WIP = GetSFT_WIPofProducts(order[0].Product);

                    pLanning.wip.MQCQty = sFT_WIP.MQC_Out_Available;
                    pLanning.wip.PQCQty = sFT_WIP.PQC_In_Available + sFT_WIP.PQC_Out_Available;
                    pLanning.wip.StockInWHQTy = sFT_WIP.StockIntoWH;
                    pLanning.wip.TotalInWip = pLanning.wip.MQCQty + pLanning.wip.PQCQty + pLanning.wip.StockInWHQTy ;
                    pLanning.TotalShortage = pLanning.TotalQty - pLanning.wip.Warehouse - pLanning.wip.TotalInWip;

                    Production pro = new Production();
                    pro = GetProductionFromProduct(pLanning.KeyProduct);

                    if (pro != null)
                    {
                        pLanning.production.QtyOld = pro.QtyOld;
                        pLanning.production.targetShiftA = pro.targetShiftA;
                        pLanning.production.targetShiftB = pro.targetShiftB;
                    }
                    else

                    {
                        pLanning.production.QtyOld = 0;
                        pLanning.production.targetShiftA = 0;
                        pLanning.production.targetShiftB = 0;
                    }
                    keyValuePairs.Add(pLanning.KeyProduct, pLanning);
                }
            }
            catch (Exception)
            {

                return null;
            }
            return keyValuePairs;
        }
        public Dictionary<string, PlanningItem> GetPlanningReportbyDept(string dept,List<OrderVariable> orders)
        {
            Dictionary<string, PlanningItem> keyValuePairs = new Dictionary<string, PlanningItem>();
            List<List<OrderVariable>> listOders = new List<List<OrderVariable>>();
            listOders = ListOrdervariables(orders);

            try
            {

                foreach (var order in listOders)
                {
                    PlanningItem pLanning = new PlanningItem();
                
                    GetSemiFinishedgoods getSemiFinishedgoods = new GetSemiFinishedgoods();
                    pLanning.KeyProduct = order[0].Product;
                    pLanning.Unit = order[0].Unit;
                    //  List<Accessory> ListAccessories = getAccessory.GetAccessories(pLanning.KeyProduct);
                   
                    // base on product to defind Dept

                    if (order[0].Product.Contains("BMH") && order[0].DDH.Contains("B"))
                    {
                        pLanning.Client = "MH";
                    }
                    else if (order[0].Product.Contains("BWT") && order[0].DDH.Contains("B"))
                    {
                        pLanning.Client = "WT";
                    }
                    else if (order[0].Product.Contains("BFF") && order[0].DDH.Contains("B"))
                    {
                        pLanning.Client = "FF";
                    }
                   else if (order[0].Product.Contains("P25") || order[0].Product.Contains("P40") || order[0].Product.Contains("P259"))
                        pLanning.Client = "JAMAK";
                    else if (order[0].Product.Contains("P05") || order[0].Product.Contains("P111"))
                        pLanning.Client = "MH";
                    else if (order[0].Product.Contains("P117"))
                        pLanning.Client = "PTC";
                  else  if (order[0].DDH.Contains("A"))
                    {
                        pLanning.Client = order[0].Product.Split('-').Count() > 0 ? order[0].Product.Split('-')[1] : "";
                    }
                    else
                    {
                        pLanning.Client = order[0].Product.Replace(order[0].ProductName, "").Substring(1);
                    }
                    // Define Shiment Plan of production
                    pLanning.shipmentPlans = new List<ShipmentPlan>();
                    pLanning.needProduceQties = new List<NeedProduceQty>();
                    foreach (var or in order)
                    {
                        ShipmentPlan shipment = new ShipmentPlan();
                        shipment.ClientRequestDate = or.ClientRequestDate;
                        shipment.ClientCode = or.ClientOrder;
                        shipment.DeliveryPlanQty = or.DeliveryQty;
                        shipment.NeedQty = or.ClientOrderQty;
                        shipment.RemainDay = (or.ClientRequestDate - DateTime.Now.Date).Days;
                        shipment.NeedQtyPerDay = shipment.NeedQty / shipment.RemainDay;
                        shipment.OrderCode = or.DDH;
                        pLanning.shipmentPlans.Add(shipment);

                        NeedProduceQty need = new NeedProduceQty();
                        need.ClientRequestDate = or.ClientRequestDate;
                        need.NeedQty = or.ClientOrderQty;
                        need.RemainDay = (or.ClientRequestDate - DateTime.Now.Date).Days;
                        need.NeedQtyPerDay = need.NeedQty / need.RemainDay;
                        pLanning.needProduceQties.Add(need);
                    }
                    pLanning.TotalQty = pLanning.shipmentPlans.Select(d => d.NeedQty).Sum();

                    pLanning.SemiFinishedGoods = new List<SemiFinishedGoods>();
                    if (dept == "B01-MH")
                    {
                        var StockSFT = getSemiFinishedgoods.GetStockGoodsONSFT(dept, pLanning.KeyProduct);
                        pLanning.SemiFinishedGoods.Add(StockSFT);
                    }
                    else if (dept == "B01-FF")
                    {
                        var StockSFT = getSemiFinishedgoods.GetStockGoodsONSFT(dept, pLanning.KeyProduct);
                        pLanning.SemiFinishedGoods.Add(StockSFT);
                    }
                    else if (dept == "A01-Gia Dung")
                        pLanning.SemiFinishedGoods = getSemiFinishedgoods.ListGetSemiFinishedGoods(dept, pLanning.KeyProduct, pLanning.TotalQty);
                    else if (dept == "A01-PTC")
                        pLanning.SemiFinishedGoods = getSemiFinishedgoods.ListGetSemiFinishedGoods(dept, pLanning.KeyProduct, pLanning.TotalQty);

                    keyValuePairs.Add(pLanning.KeyProduct, pLanning);
                }
            }
            catch (Exception ex)
            {

                return null;
            }
            return keyValuePairs;
        }
        public List<List<OrderVariable>> ListOrdervariables (List<OrderVariable> orders)
        {
            List<List<OrderVariable>> orderVariables = new List<List<OrderVariable>>();
            try
            { if (orders != null)
                {
                     orderVariables = orders
                    .GroupBy(u => u.ProductName)
            .Select(grp => grp.ToList())
            .ToList();
                }
            }
            catch (Exception)
            {

                return null;
            }
            return orderVariables;
        }
//        public List<string> ListHENNofProduct(string ProductNO)
//        {
          

//            try
//            {
//                StringBuilder stringBuilder = new StringBuilder();
//                stringBuilder.Append(@" select distinct TE017 from MOCTA 
// left join MOCTE on TA001 = TE011 and TA002 = TE012
// where  (TE018 like '%HENN%' ) and TE019 ='Y' 
//");
//                stringBuilder.Append(" and TA034   = '"+ ProductNO+"' ");
//                sqlERPCON sqlERPCON = new sqlERPCON();
//                DataTable dt = new DataTable();
//                sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
//                if (dt != null && dt.Rows.Count > 0)
//                    return dt.AsEnumerable()
//                            .Select(r => r.Field<string>("TE017"))
//                            .ToList();
//                else return null;

//            }
//            catch (Exception ex)
//            {
//                SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<string> ListHENNofProduct(string ProductNO)", ex.Message);
//                return null;
//            }
          
//        }
        public List<string> ListHENNofProduct(string ProductNO)
        {


            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select distinct MD003 from BOMMD where 1=1 
");
                stringBuilder.Append(" and MD001   like '%" + ProductNO + "%' ");
                stringBuilder.Append("  and (MD003   like '%BPJHC%'  or ( MD003   like '%BPJ-%' and ISNUMERIC(SUBSTRING(MD003,5,1)) = '1' )) ");
                stringBuilder.Append(" and MD012 = '"+"" +"'");
                sqlERPCON sqlERPCON = new sqlERPCON();
                DataTable dt = new DataTable();
                sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                if (dt != null && dt.Rows.Count > 0)
                    return dt.AsEnumerable()
                            .Select(r => r.Field<string>("MD003"))
                            .ToList();
                else return null;

            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<string> ListHENNofProduct(string ProductNO)", ex.Message);
                return null;
            }

        }
        public double StockOfProduct (string ProducNo)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select MB064 from INVMB where 1=1 
");
                stringBuilder.Append(" and MB001   = '" + ProducNo + "' ");
                sqlERPCON sqlERPCON = new sqlERPCON();
                string data = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
                if (data != string.Empty)
                {
                    try
                    {
                        return double.Parse(data);
                    }
                    catch (Exception)
                    {

                        return 0;
                    }
                }
            }
            catch (Exception)
            {

                return 0;
            }
            return 0;
        }
        public double StockOfHENN(string HENNName)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"  select  MC007 from INVMC
where 1=1 
");
                if (HENNName.Contains("BPJHC"))
                stringBuilder.Append(" and MC002 = 'Y22' " );
                else if (HENNName.Contains("BPJ-"))
                    stringBuilder.Append(" and MC002 = 'A12' ");
                stringBuilder.Append(" and MC001  like '%" + HENNName + "%' ");
                sqlERPCON sqlERPCON = new sqlERPCON();
                string data = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
                if (data != string.Empty)
                {
                    try
                    {
                        return double.Parse(data);
                    }
                    catch (Exception)
                    {

                        return 0;
                    }
                }
            }
            catch (Exception)
            {

                return 0;
            }
            return 0;
        }

        public List<SettingBOM> GetSettingBOMs(string part)
        {
            List<SettingBOM> settingBOMs = new List<SettingBOM>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select distinct ProductName, productNo 
from (
select smes.ME002 as Dept,TD001, TD002, TD004 as ProductName,TD005 as productNo,
sum(TD008) as ClientRequestQty,sum(TD009) as DeliveryQty, TD013 as ClientRequestDate from COPTD ptd
inner join COPTC ptc on ptc.TC001 = ptd.TD001 and ptc.TC002 = ptd.TD002
left join CMSME smes on smes.ME001 = ptc.TC005
where  ptc.TC027 ='Y' and TD001 like '%B%' ");
    
                if(part =="MH")
                stringBuilder.Append("   and ( TD004 like '%BMH%' or  TD004 like '%BWTX%') ");
                else if ( part =="FF")
                    stringBuilder.Append("   and ( TD004 like '%BFF%' ) ");

                stringBuilder.Append(" group by TD001,TD002,TD005, TD013,smes.ME002,TD004 ) DDH  ");
              
                sqlERPCON sqlERPCON = new sqlERPCON();
                DataTable dt = new DataTable();
                sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                settingBOMs = (from DataRow dr in dt.Rows
                                  select new SettingBOM()
                                  {
                                      ProductName = (dr["ProductName"] != null) ? dr["ProductName"].ToString().Trim() : "",
                                      ProductNo = (dr["productNo"] != null) ? dr["productNo"].ToString().Trim() : "",
                                    
                                  }).ToList();
            }
            catch (Exception)
            {

                return null;
            }
            return settingBOMs;
        }
        public bool InsertToBOMSettingTableIntilizer(List<SettingBOM> settingBOMs)
        {
            
            foreach (var item in settingBOMs)
            {
                string sqlQuerry = "";
                sqlQuerry += "insert into t_settingBOM (productName, productNo, QTyinBox, QtyTool, Update_Date ) values( '";
                sqlQuerry += item.ProductName + "', '" + item.ProductNo  +"', '" + item.QtyInBox + "', '" + item.QtyTool + "',GETDATE() )" ;
                sqlCON sqlCON = new sqlCON();
                sqlCON.sqlExecuteNonQuery(sqlQuerry, false);


            }
            return true;
        }

        public List<SettingBOM> LoadingSettingBOMs()
        {
            List<SettingBOM> settingBOMs = new List<SettingBOM>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select productName, productNo,QTyinBox, QtyTool  from t_settingBOM where 1=1 ");
           //     stringBuilder.Append(" and productName like '%"+ part+"%'");

                sqlCON sqlCON = new sqlCON();
                DataTable dt = new DataTable();
                sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                settingBOMs = (from DataRow dr in dt.Rows
                               select new SettingBOM()
                               {
                                   ProductName = (dr["ProductName"] != null) ? dr["ProductName"].ToString().Trim() : "",
                                   ProductNo = (dr["productNo"] != null) ? dr["productNo"].ToString().Trim() : "",
                                   QtyInBox = (dr["QTyinBox"].ToString() != null) ? int.Parse(dr["QTyinBox"].ToString().Trim()) : 0,
                                   QtyTool = (dr["QtyTool"].ToString() != null) ? int.Parse(dr["QtyTool"].ToString().Trim()) : 0
                               }).ToList();

            }
            catch (Exception)
            {

                return null;
            }
            return settingBOMs;
        }
        public bool UpdateToDatabase(string productNo,int QtyinPacking, int QtyTool)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" update t_settingBOM ");
                stringBuilder.Append(" set  QTyinBox = '" + QtyinPacking.ToString() + "' , " );
                stringBuilder.Append("  QtyTool = '" + QtyTool.ToString() + "' ");
                stringBuilder.Append(" where  productNo = '" + productNo + "'");
                sqlCON sqlCON = new sqlCON();
            return    sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);
            }
            catch (Exception)
            {

                return false;
            }

           
        }

        public bool DeleteRowofProduct(string productNo)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" delete from  t_settingBOM ");  
                stringBuilder.Append(" where  productNo = '" + productNo + "'");
                sqlCON sqlCON = new sqlCON();
                return sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool InsertRowofProduct(string productname, string productNo, int QtyBox, int QtyTool)
        {
            try
            {
                string sqlQuerry = "";
                sqlQuerry += "insert into t_settingBOM (productName, productNo, QTyinBox, QtyTool, Update_Date ) values( '";
                sqlQuerry += productname + "', '" + productNo + "', '" + QtyBox + "', '" + QtyTool + "',GETDATE() )";
                sqlCON sqlCON = new sqlCON();
             return   sqlCON.sqlExecuteNonQuery(sqlQuerry, false);
            }
            catch (Exception)
            {

                return false;
            }


        }
        public List<SettingBOM> LoadingSettingBOMsFilter(string ProductNo)
        {
            List<SettingBOM> settingBOMs = new List<SettingBOM>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select productName, productNo,QTyinBox, QtyTool  from t_settingBOM ");
                stringBuilder.Append(" where productName like '%" + ProductNo + "%'" );
                sqlCON sqlCON = new sqlCON();
                DataTable dt = new DataTable();
                sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                settingBOMs = (from DataRow dr in dt.Rows
                               select new SettingBOM()
                               {
                                   ProductName = (dr["ProductName"] != null) ? dr["ProductName"].ToString().Trim() : "",
                                   ProductNo = (dr["productNo"] != null) ? dr["productNo"].ToString().Trim() : "",
                                   QtyInBox = (dr["QTyinBox"].ToString() != null) ? int.Parse(dr["QTyinBox"].ToString().Trim()) : 0,
                                   QtyTool = (dr["QtyTool"].ToString() != null) ? int.Parse(dr["QtyTool"].ToString().Trim()) : 0
                               }).ToList();

            }
            catch (Exception)
            {

                return null;
            }
            return settingBOMs;
        }

        public bool InsertToManufactureSettingTableIntilizer(List<SettingBOM> settingBOMs)
        {

            foreach (var item in settingBOMs)
            {
                string sqlQuerry = "";
                sqlQuerry += "insert into t_settingManufacture (productName, productNo, PlanQuantity, WorkerTarget, Update_Date ) values( '";
                sqlQuerry += item.ProductName + "', '" + item.ProductNo + "', '" + 0 + "', '" + 0 + "',GETDATE() )";
                sqlCON sqlCON = new sqlCON();
                sqlCON.sqlExecuteNonQuery(sqlQuerry, false);


            }
            return true;
        }
        public List<SettingManufacture> LoadingSettingManufacture()
        {
            List<SettingManufacture> settingManuf= new List<SettingManufacture>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select productName, productNo,PlanQuantity, WorkerTarget  from t_settingManufacture ");
                sqlCON sqlCON = new sqlCON();
                DataTable dt = new DataTable();
                sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                settingManuf = (from DataRow dr in dt.Rows
                               select new SettingManufacture()
                               {
                                   ProductName = (dr["ProductName"] != null) ? dr["ProductName"].ToString().Trim() : "",
                                   ProductNo = (dr["productNo"] != null) ? dr["productNo"].ToString().Trim() : "",
                                  PlanQty = (dr["PlanQuantity"].ToString() != null) ? int.Parse(dr["PlanQuantity"].ToString().Trim()) : 0,
                                   Workertarget = (dr["WorkerTarget"].ToString() != null) ? int.Parse(dr["WorkerTarget"].ToString().Trim()) : 0
                               }).ToList();

            }
            catch (Exception)
            {

                return null;
            }
            return settingManuf;
        }
        public bool InsertRowofManufacture(string productname, string productNo, int PlanQty, int Workertarget)
        {
            try
            {
                string sqlQuerry = "";
                sqlQuerry += "insert into t_settingManufacture (productName, productNo, PlanQuantity, WorkerTarget, Update_Date ) values( '";
                sqlQuerry += productname + "', '" + productNo + "', '" + PlanQty + "', '" + Workertarget + "',GETDATE() )";
                sqlCON sqlCON = new sqlCON();
                return sqlCON.sqlExecuteNonQuery(sqlQuerry, false);
            }
            catch (Exception)
            {

                return false;
            }


        }
        public bool UpdateToManufacture(string productNo, int PlanQty, int Workertarget)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" update t_settingManufacture ");
                stringBuilder.Append(" set PlanQuantity = '" + PlanQty.ToString() + "' , ");
                stringBuilder.Append("  WorkerTarget = '" + Workertarget.ToString() + "' ");
            //    stringBuilder.Append("  Update_Date = 'GETDATE()' ");
                stringBuilder.Append(" where  productNo = '" + productNo + "'");
                sqlCON sqlCON = new sqlCON();
                return sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);
            }
            catch (Exception)
            {

                return false;
            }


        }

        public bool DeleteRowofManufaccture(string productNo)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" delete from  t_settingManufacture");
                stringBuilder.Append(" where  productNo = '" + productNo + "'");
                sqlCON sqlCON = new sqlCON();
                return sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);
            }
            catch (Exception)
            {

                return false;
            }


        }
        public List<SettingManufacture> LoadingSettingManufactureFilter(string ProductNo)
        {
            List<SettingManufacture> settingManuf = new List<SettingManufacture>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select productName, productNo,PlanQuantity, WorkerTarget  from t_settingManufacture ");
                stringBuilder.Append(" where productName like '%" + ProductNo + "%'");
                sqlCON sqlCON = new sqlCON();
                DataTable dt = new DataTable();
                sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                settingManuf = (from DataRow dr in dt.Rows
                                select new SettingManufacture()
                                {
                                    ProductName = (dr["ProductName"] != null) ? dr["ProductName"].ToString().Trim() : "",
                                    ProductNo = (dr["productNo"] != null) ? dr["productNo"].ToString().Trim() : "",
                                    PlanQty = (dr["PlanQuantity"].ToString() != null) ? int.Parse(dr["PlanQuantity"].ToString().Trim()) : 0,
                                    Workertarget = (dr["WorkerTarget"].ToString() != null) ? int.Parse(dr["WorkerTarget"].ToString().Trim()) : 0
                                }).ToList();

            }
            catch (Exception)
            {

                return null;
            }
            return settingManuf;
        }

        public SFT_WIP GetSFT_WIPofProducts (string product)
        {
            SFT_WIP sFT_WIP = new SFT_WIP();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  sum(LOTSIZE)  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0010' and a.STATUS = '0' and b.STATUS !='99' and b.STATUS !='100' 
 ");
                stringBuilder.Append(" and a.ITEMID =  '" + product + "'");
               sqlSFT sqlERPCON = new sqlSFT();
                var Temp = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
                if (Temp != null && Temp != "")
                {
                    sFT_WIP.MQC_In_Available = double.Parse(Temp.ToString());
                }
                else sFT_WIP.MQC_In_Available = 0;

                stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  sum(LOTSIZE)  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0010' and a.STATUS = '50' and b.STATUS !='99' and b.STATUS !='100' 
 ");
                stringBuilder.Append(" and a.ITEMID =  '" + product + "'");
              //  sqlERPCON sqlERPCON = new sqlERPCON();
                Temp = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
                if (Temp != null && Temp != "")
                {
                    sFT_WIP.MQC_Out_Available = double.Parse(Temp.ToString());
                }
                else sFT_WIP.MQC_Out_Available = 0;

                stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  sum(LOTSIZE)  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0020' and a.STATUS = '0' and b.STATUS !='99' and b.STATUS !='100'
 ");
                stringBuilder.Append(" and a.ITEMID =  '" + product + "'");
                //  sqlERPCON sqlERPCON = new sqlERPCON();
                Temp = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
                if (Temp != null && Temp != "")
                {
                    sFT_WIP.PQC_In_Available = double.Parse(Temp.ToString());
                }
                else sFT_WIP.PQC_In_Available = 0;

                stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  sum(LOTSIZE)  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0020' and a.STATUS = '50' and b.STATUS !='99' and b.STATUS !='100'
 ");
                stringBuilder.Append(" and a.ITEMID =  '" + product + "'");
                //  sqlERPCON sqlERPCON = new sqlERPCON();
                Temp = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
                if (Temp != null && Temp != "")
                {
                    sFT_WIP.PQC_Out_Available= double.Parse(Temp.ToString());
                }
                else sFT_WIP.PQC_Out_Available = 0;

                stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  sum(LOTSIZE)  from LOT a 
left join MODETAIL b on CMOID = ID
where  ERP_OPSEQ = '0020' and a.STATUS = '130' and b.STATUS !='99' and b.STATUS !='100' 
 ");
                stringBuilder.Append(" and a.ITEMID =  '" + product + "'");
                //  sqlERPCON sqlERPCON = new sqlERPCON();
                Temp = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
                if (Temp != null && Temp != "")
                {
                    sFT_WIP.StockIntoWH = double.Parse(Temp.ToString());
                }
                else sFT_WIP.StockIntoWH = 0;
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetSFT_WIPofProducts (string product)", ex.Message);
                return null;
            }
            return sFT_WIP;

        }

       public DateTime GetDateTimeMaxProfuct (string product)
        {
            DateTime dateTime = new DateTime();
            try
            {
                string sqlQuery = @"select MAX(CREATE_DATE)  from SFCTC where TC047 like '%" + product + "%'";
                sqlERPCON sqlERPCON = new sqlERPCON();
                string strDatetime = sqlERPCON.sqlExecuteScalarString(sqlQuery);
                if(strDatetime != "" && strDatetime != null && strDatetime.Trim().Length==8)
                {
                    dateTime = DateTime.Parse(strDatetime.Trim().Insert(4, "-").Insert(7, "-"));
                }
            }
            catch (Exception)
            {

                return DateTime.MinValue;
            }
            return dateTime;
        }
        public List<ProductionItem> GetProductionItems(string product, DateTime maxDate)
        {
            List<ProductionItem> productionItems = new List<ProductionItem>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select TC047 as product, CREATE_DATE, CREATE_TIME ,TC014 as SLNghiemThu, TC016 as SLBaophe
from SFCTC 
where 1=1 ");
                stringBuilder.Append(" and TC047 like '%" + product + "%'");
                stringBuilder.Append(" and CREATE_DATE in  ('" + maxDate.ToString("yyyyMMdd") + "', '" + maxDate.AddDays(-1).ToString("yyyyMMdd") + "')" );
                stringBuilder.Append("order by CREATE_DATE, CREATE_TIME");


               DataTable dt = new DataTable();
                sqlERPCON sqlERPCON = new sqlERPCON();
                sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                productionItems = (from DataRow dr in dt.Rows
                                select new ProductionItem()
                                {
                                    Product = (dr["product"] != null) ? dr["product"].ToString().Trim() : "",
                                    Create_date = (dr["CREATE_DATE"] != null && dr["CREATE_DATE"].ToString() != "") ? DateTime.Parse(dr["CREATE_DATE"].ToString().Trim().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue,
                                    Create_time = (dr["CREATE_TIME"].ToString() != null) ? TimeSpan.Parse(dr["CREATE_TIME"].ToString().Trim()) : TimeSpan.MinValue,
                                    OutputQty = (dr["SLNghiemThu"].ToString() != null) ? double.Parse(dr["SLNghiemThu"].ToString().Trim()) : 0,
                                    DefectQty = (dr["SLBaophe"].ToString() != null) ? double.Parse(dr["SLBaophe"].ToString().Trim()) : 0
                                }).ToList();
            }
            catch (Exception)
            {

                return null;
            }
            return productionItems;
        }
        public Production GetProduction(List<ProductionItem> productions)
        {
            Production production = new Production();
            List<ProductionItem> DayShift = new List<ProductionItem>();
            List<ProductionItem> NightShift = new List<ProductionItem>();

            try
            {
                DateTime dateMax = productions.Select(d => d.Create_date).Max();
                DateTime dateMin = productions.Select(d => d.Create_date).Min();
                TimeSpan StartdaysShift = new TimeSpan(8, 0, 0);
                TimeSpan EnddaysShift = new TimeSpan(20, 0, 0);
               

                foreach (var item in productions)
                {
                    if(item.Create_date + item.Create_time >= dateMin + StartdaysShift &&  item.Create_date + item.Create_time <= dateMin + EnddaysShift)
                    {
                        DayShift.Add(item);
                    }
                    if (item.Create_date + item.Create_time >= dateMin +EnddaysShift && item.Create_date + item.Create_time <= dateMax + StartdaysShift)
                    {
                       NightShift.Add(item);
                    }
                }

                production.targetShiftA = DayShift.Select(d => d.OutputQty).Sum();
                production.targetShiftB = NightShift.Select(d => d.OutputQty).Sum();
                production.QtyOld = production.targetShiftA + production.targetShiftB;

            }
            catch (Exception)
            {

                return null;
            }
            return production;
        }
        public Production GetProductionFromProduct (string product)
        {
            Production production = new Production();
            try
            {
                DateTime maxDate = GetDateTimeMaxProfuct(product);
                List<ProductionItem> productionItems = GetProductionItems(product, maxDate);
                if (productionItems != null)
                    production = GetProduction(productionItems);
                else return null;
            }
            catch (Exception)
            {

                return null;
            }
            return production;
                
        }
  

    }
}

