using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Database.Model
{
  public  class INVItems
    {
        public string Product { get; set; }
        public string ProductCode{ get; set; }
        public string Lot { get; set; }
        public DateTime Create_Date { get; set; }
        public string TypeDoccument { get; set; }
        public string DoccumentNo { get; set; }
        public string STTDoc { get; set; }
        public string Warehouse { get; set; }
        public string TypeInportExport { get; set; }
        public string TypeChange { get; set; }
        public double Quantity { get; set; }
        public double PackageQty { get; set; }
        public string Note { get; set; }
        public string Location { get; set; }
        public DateTime ImportDate { get; set; }
        public DateTime InventedDate { get; set; }
        public DateTime ExortDate { get; set; }
        public string MainLocation { get; set; }
        public string ImportQR { get; set; }
        public string ExportQR { get; set; }
    }
}
