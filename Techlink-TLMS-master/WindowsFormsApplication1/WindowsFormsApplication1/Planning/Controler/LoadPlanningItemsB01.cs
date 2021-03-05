using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Planning.Model;
namespace WindowsFormsApplication1.Planning.Controler
{
 public   class LoadPlanningItemsB01
    {
        public List<DataHeaderPlanning> GetDataHeaderPlanningBMH(string dept, DateTime from, DateTime to, out Dictionary<string, List<dataContent>> ListPlanShipments)
        {
            List<DataHeaderPlanning> headerPlanningA01s = new List<DataHeaderPlanning>();
            try
            {
                LoadDataPlanning loadData = new LoadDataPlanning();
                var orderVariables = loadData.LoadOrderInformationbyDatebyDept(from, to, dept);
                var ListPlanning = loadData.GetPlanningReportbyDept(dept,orderVariables);
                var listplanShipment = new Dictionary<string, List<dataContent>>();

                foreach (var item in ListPlanning)
                {
                    var datacontents = new List<dataContent>();
                    DataHeaderPlanning data = new DataHeaderPlanning();
                    data.product = item.Value.KeyProduct;
                    data.Unit = item.Value.Unit;
                    data.Amount_Of_Order = item.Value.shipmentPlans.Count();
                    data.Total_Order_Qty = item.Value.TotalQty;
                    data.client = item.Value.Client;
                    GetStockinINVMC getStockFinishedGoods = new GetStockinINVMC();
                    var ListFinishedGoodsWH = getStockFinishedGoods.GetItemsInINVMCs(dept, data.product);
                    data.StockInWarehouse = ListFinishedGoodsWH.Select(d => d.Quantity).Sum().ToString("N0");
                    for (int i = 0; i < item.Value.SemiFinishedGoods.Count; i++)
                    {

                       // data.SemiFinishedGoods += item.Value.SemiFinishedGoods[i].Item + Environment.NewLine;
                       // data.StockSemiFinished += item.Value.SemiFinishedGoods[i].QtyWarehouse.ToString("N0") + Environment.NewLine;
                        data.MQCStock += item.Value.SemiFinishedGoods[i].QTyAtMQC.ToString("N0") + Environment.NewLine;
                        data.PQCStock += item.Value.SemiFinishedGoods[i].QTyAtPQC.ToString("N0") + Environment.NewLine;
                        data.PendingWarehouse += item.Value.SemiFinishedGoods[i].QtyPendingWarehouse.ToString("N0") + Environment.NewLine;
                        if (item.Value.SemiFinishedGoods[i].accessories != null)
                        {
                            //  var ItemGroup = item.Value.SemiFinishedGoods[i].accessories.GroupBy(d => d.Item).ToList();
                            var ItemGroupItem = item.Value.SemiFinishedGoods[i].accessories.GroupBy(u => u.Item)
    .Select(grp => grp.ToList())
    .ToList();
                            for (int j = 0; j < ItemGroupItem.Count; j++)
                            {
                                data.Accessories += ItemGroupItem[j][0].Item + Environment.NewLine;

                                data.StockAccessory += ItemGroupItem[j].Sum(d => d.QtyInWarehouse).ToString("N0") + Environment.NewLine;
                            }
                        }
                    }
                    double ShipmentQtySum = 0;
                    foreach (var shipment in item.Value.shipmentPlans)
                    {
                        var dataContent = new dataContent();
                        DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
                        Calendar cal = dfi.Calendar;
                        int WeekNo = cal.GetWeekOfYear(shipment.ClientRequestDate, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
                        dataContent.WeekRequestDate = "Week: " + WeekNo.ToString();
                        dataContent.MonthRequest = shipment.ClientRequestDate.ToString("MMM");
                        dataContent.ClientOrderDate = shipment.ClientRequestDate;

                        dataContent.OrderQty = shipment.DeliveryPlanQty;
                        ShipmentQtySum += dataContent.OrderQty;
                        dataContent.ShortageQty = ShipmentQtySum;
                        dataContent.RemainDay = shipment.RemainDay;
                        if (dataContent.RemainDay == 0)
                            dataContent.TargetQtyDay = (dataContent.ShortageQty < 0) ? 0 : (dataContent.OrderQty);
                        else dataContent.TargetQtyDay = (dataContent.ShortageQty < 0) ? 0 : Math.Ceiling((dataContent.OrderQty / dataContent.RemainDay));

                        dataContent.OrderCode = shipment.OrderCode;
                        dataContent.ClientOrder = shipment.ClientCode;
                        datacontents.Add(dataContent);

                    }
                    for (int k = 0; k < datacontents.Count; k++)
                    {
                        for (int l = k + 1; l < datacontents.Count; l++)
                        {
                            datacontents[k].TargetQtyDay += datacontents[l].TargetQtyDay;
                        }
                    }
                    if (listplanShipment.ContainsKey(data.product) == false)
                        listplanShipment.Add(data.product, datacontents);

                    headerPlanningA01s.Add(data);
                }
                ListPlanShipments = listplanShipment;
            }
            catch (Exception ex)
            {
                ListPlanShipments = null;
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataHeaderPlanningA01", ex.Message);
            }
            return headerPlanningA01s;

        }
    }
}
