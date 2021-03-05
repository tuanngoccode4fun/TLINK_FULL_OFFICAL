using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.WMS.Model
{
    class QRStockIn
    {
        public string IDQRCODE { get; set; }
        public string PurchasingCode { get; set; }
        public string MaterialCode { get; set; }
        public string Commodity { get; set; }
        public string Specification { get; set; }
        public double Quantity { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Lot_Po { get; set; }
        public string Invoice { get; set; }
        public string Remark { get; set; }
        public string IDQRLocaction { get; set; }
        public string Warehouse { get; set; }
        public string Location { get; set; }
        public string Rack { get; set; }

    }
}
