using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Planning.Model
{
  public  class SemiFinishedsGoodsItems
    {   public string Product { get; set; }
        public string SemiFinishedGoods { get; set; }
     public double SemiFGsRequire { get; set; }
        public double QtyWarehouse { get; set; }
        public double QtyWip { get; set; }
        public double QtyInMQC { get; set; }
        public double QtyOutMQC { get; set; }
        public double QTyAtMQC { get; set; }
        public double QtyInPQC { get; set; }
        public double QtyOutPQC { get; set; }
        public double QTyAtPQC { get; set; }

        public double QtyPendingWarehouse { get; set; }
        
       
        public string Accessory { get; set; }
        public string AccessoryStock { get; set; }
        public string WarehouseofAccessory { get; set; }
    }
}
