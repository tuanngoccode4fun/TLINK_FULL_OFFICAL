using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.WMS.Model
{
    public class PQCOutStock
    {
        public string KeyID { get; set; }
        public string KeyNo { get; set; }
        public string STT { get; set; }
        public string ProductOrder { get; set; }
        public string Product { get; set; }
        
        public string LotNo { get; set; }
        public double PQCStock { get; set; }
        public double Quantity { get; set; }
        public string Warehouse { get; set; }
        public string QRcodeGenarate { get; set; }
    }
}
