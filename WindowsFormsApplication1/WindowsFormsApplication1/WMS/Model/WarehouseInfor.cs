using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.WMS.Model
{
  public  class WarehouseInfor
    {
        public string Material { get; set; }
        public string Warehouse { get; set; }
        public string WarehouseDrescristion { get; set; }
        public decimal quantity { get; set; }
        public string Unit { get; set; }

        public string Lot { get; set; }
        public string locationOrigin { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime expiryDate { get; set; }


    }
}
