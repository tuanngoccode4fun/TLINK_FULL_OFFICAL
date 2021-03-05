using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.WMS
{
    class LabelItem
    {
        public string PurchasingCode { get; set; }
        public string Location { get; set; }
        public string MaterialCode { get; set; }
        public string Commodity { get; set; }
        public string Quantity { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string LotPo { get; set; }
        public string Invoice { get; set; }
        public string Remark { get; set; }
    }
    class InvertoryItem
    {
        public string KeyID { get; set; }
        public string Material { get; set; }
        public string LotPo { get; set; }
        public double Quantity{ get; set; }
        public string Warehouse { get; set; }
        public string Position{ get; set; }
        public DateTime InvertoryDate { get; set; }
       
    }
    class InOutItem
    {
        public string Code { get; set; }
      
        public string STT { get; set; }
        public string MaterialCode { get; set; }
        public string InOut { get; set; }
        public double Quantity { get; set; }
        public DateTime DateTime { get; set; }
        public string Warehouse { get; set; }
        public string Position { get; set; }

    }
    public class PURTD
    {   public bool CheckBox { get; set; }
        public string TD001_Ma { get; set; }
        public string TD002_Code { get; set; }
        public string TD003_STT { get; set; }
        public string TD004_MaSP { get; set; }
        public string TD005_TenSP { get; set; }
        public string Lot { get; set; }
        public string TD009_Unit { get; set; }
        public double TD008_SL { get; set; }
        public double SLThucgiao { get; set; }
        public double TD015_SLDaGiao { get; set; }
     //   public string TD009_Unit { get; set; }
        public string TD007_Kho { get; set; }
        public string warehouse { get; set; }
        public string location { get; set; }

        public DateTime ExpiryDate { get; set; }
        public string Invoice { get; set; }

        public DateTime TD012_DeliveryEstimate { get; set; }
      
        public string TD018_MaXacNhan { get; set; }
    

    }
    public class gridviewInStock
    {
        public string TD001_Ma { get; set; }
        public string TD002_Code { get; set; }
        public string TD003_STT { get; set; }
        public string TD004_MaSP { get; set; }
        public string TD005_TenSP { get; set; }

        public double TD008_SL { get; set; }
        public double SLThucte { get; set; }
        public string TD009_Unit { get; set; }
        public string TD007_Kho { get; set; }
        public string _Kho { get; set; }
        public string _VitriKho { get; set; }
        public DateTime _ExpiryDay { get; set; }
        public DateTime TD012_DeliveryEstimate { get; set; }
        public string Lot { get; set; }
        public string Invoice { get; set; }
    }
    public class  InforWH
    {
        public string WH { get; set; }
        public string Name { get; set; }
      public  List<Position> positions { get; set; }
    }
    public class Position
    {
        public string position { get; set; }

    }

    
}
