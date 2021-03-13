using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Planning
{
  public  class OrderVariable
    {
        public string Dept { get; set; }
        public string DDH { get; set; }
        public string ClientOrder { get; set; }
        public string Product { get; set; }
        public string ProductName { get; set; }
        public double ClientOrderQty { get; set; }
        public double DeliveryOverQty { get; set; }
        public double DeliveryQty { get; set; }
        public string Unit { get; set; }
        public DateTime ClientRequestDate { get; set; }

    }
    public class ShipmentPlan
    {   public string WeekRequestDate { get; set; }

        public string MonthRequest { get; set; }
        public DateTime ClientRequestDate { get; set; }
        
        public string OrderCode { get; set; }
        public string ClientCode { get; set; }
        public double DeliveryPlanQty { get; set; }
        public double NeedQty { get; set; }
        public double RemainDay { get; set; }
        public double NeedQtyPerDay { get; set; } // = NeedQty / RemainDay
    } 
    public class BOM
    {
        public string[] HEN { get; set; }
        public double[] HENStock { get; set; }
        public string[] StrHENStock { get; set; }
        public double QtyUnit { get; set; }
        public double ToolQty { get; set; }
    }
    public class SemiFinishedGoods
    {
        public string Item { get; set; }
        public double QtyNeed { get; set; }
        public double QtyInWarehouse { get; set; }
        public double QtyInMQC { get; set; }
        public double QtyOutMQC { get; set; }
        public double QTyAtMQC { get; set; }
        public double QtyInPQC { get; set; }
        public double QtyOutPQC { get; set; }
        public double QTyAtPQC { get; set; }

        public double QtyPendingWarehouse { get; set; }
        public double QtyWip { get; set; }
        public double QtyWarehouse { get; set; }   
       public List<Accessory> accessories { get; set; }
    }
    public class ProductionOrderStatus
    {
        public string productionOrder { get; set; }
        public string clientOrder { get; set; }
        public string StatusProduct { get; set; }

    }
    public class Accessory
    {
        public string Item { get; set; }
        public string Warehouse { get; set; }
        public double QtyInWarehouse { get; set; }
             
    }

    public class Production
    {
        public double ProductionQty { get; set; }
        public double PeopleQty { get; set; }
        public double targetPeople { get; set; }
        public double targetShiftA { get; set; }
        public double targetShiftB { get; set; }
        public double QtyOld { get; set; }

    }
    public class Wip
    {
        public double MQCQty { get; set; }
        public double StockInWHQTy { get; set; }
        public double PQCQty { get; set; }
        public double Warehouse { get; set; }
      
        public double SemiFinished { get; set; }
        public double TotalInWip { get; set; }
    }
    public class NeedProduceQty
    {
        public double NeedQty { get; set; }
        public double RemainDay { get; set; }
        public double NeedQtyPerDay { get; set; } // = NeedQty / RemainDay
        public DateTime ClientRequestDate { get; set; }

    }
    public class PlanningItem
    {
        public string KeyProduct { get; set; }
        public string Client { get; set; }
        public string OrderCode { get; set; }
        public List<Accessory> Accessories { get; set; }
        public List<SemiFinishedGoods> SemiFinishedGoods { get; set; }
        public BOM _bom { get; set; }
        
        public double  TotalQty { get; set; }
        public string Unit { get; set; }
        public double TotalShortage { get; set; }
        public List<ShipmentPlan> shipmentPlans { get; set; }
        public Production production { get; set; }
        public Wip wip { get; set; }
        public List<NeedProduceQty> needProduceQties { get; set; }
    }
    public class PLanningReport
    {
        Dictionary<string, PlanningItem> dicPlanningReport { get; set; }
    }
    public class SettingBOM
    {
        public string ProductName { get; set; }
        public string ProductNo { get; set; }
        public int QtyInBox { get; set; }
        public int QtyTool { get; set; }

    }
    public class SettingManufacture
    {
        public string ProductName { get; set; }
        public string ProductNo { get; set; }
        public int PlanQty { get; set; }
        public int Workertarget { get; set; }

    }
    public class SFT_WIP
    {
        public double MQC_In_Available { get; set; }
        public double MQC_Out_Available { get; set; }
        public double PQC_In_Available { get; set; }
        public double PQC_Out_Available { get; set; }
        public double StockIntoWH { get; set; }

    }
    public class DataHeader
    {
        public string products { get; set; }
        public string clients { get; set; }
        public double Amount_Of_Order { get; set; }
        public double Total_Order_Qty { get; set; }

        public double StockWH { get; set; }
        public double WIPQty { get; set; }
        public double ShortageStock { get; set; }
      
        public double MQCStock { get; set; }
        public double PQCStock { get; set; }
        public double IntoWH { get; set; }

        public double SemiStock { get; set; }
        public string HENN { get; set; }
        public string HENNStock { get; set; }
        public double QtyInBox { get; set; }
        public double ToolPcs { get; set; }
        public double ShiftA { get; set; }
        public double ShiftB { get; set; }
        public double productivity { get; set; }
        public double ManufactureQty { get; set; }
        public double WorkerQty { get; set; }
        public double WorkerTarget { get; set; }
     
        
    }

    public class dataContent
    {
        public string WeekRequestDate { get; set; }

        public string MonthRequest { get; set; }
        public DateTime ClientOrderDate { get; set; }

        public string OrderCode { get; set; }
        public string ClientOrder { get; set; }
        public double OrderQty { get; set; }
        public double Deliveried { get; set; }
        public double ShortageQty { get; set; }
        public double RemainDay { get; set; }
        public double TargetQtyDay { get; set; }
    }
    public class ProductionItem
    {
        public string Product { get; set; }
        public DateTime Create_date { get; set; }
        public TimeSpan Create_time { get; set; }
        public double OutputQty { get; set; }
        public double DefectQty { get; set; }
    }

}
