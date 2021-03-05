using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.WMS.Model
{
    class dataWarehouse
    {   public bool checkbox { get; set; }
 
        public string maSP_MM001 { get; set; }
        public string Lot_MM004 { get; set; }

        public string location_MM003 { get; set; }
        public string location_Transfer { get; set; }
        public double Soluong_MM005 { get; set; }
        public double Soluong_Transfer { get; set; }
        public string warehouse_MM002 { get; set; }
        public DateTime ExpiryDate { get; set; }
    }
}
