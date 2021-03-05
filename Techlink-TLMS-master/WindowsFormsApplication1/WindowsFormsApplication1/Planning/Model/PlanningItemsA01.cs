using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Planning.Model
{
 
    public class DataHeaderPlanning
    {
        public string product { get; set; }
        public string client { get; set; }
        public double Amount_Of_Order { get; set; }
        public double Total_Order_Qty { get; set; }
        public string Unit { get; set; }
        public string StockInWarehouse { get; set; }
        public string SemiFinishedGoods { get; set; }
        public string Semi_FGs_Needed_Qty { get; set; }
        public string StockSemiFinished { get; set; }
        public string MQCStock { get; set; }
        public string PQCStock { get; set; }
        public string PendingWarehouse { get; set; }
        public string Accessories { get; set; }
        public string StockAccessory { get; set; }
    }

}
