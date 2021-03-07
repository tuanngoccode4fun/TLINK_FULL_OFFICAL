using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.WMS.Model
{
  public  class FinishedGoodsItems
    {
        public string productCode { get; set; }
        public string product { get; set; }
        public string lot { get; set; }
        public double TotalQty { get; set; }
        public double DefectQty { get; set; }
        public string Warehouse { get; set; }
        public string location { get; set; }
        public string Unit { get; set; }
        public DateTime ImportDate { get; set; }
        public string OUTTYPE { get; set; }
        public string OUTDEPID { get; set; }
        public string OUTDEPNAME { get; set; }
        public string INTYPE { get; set; }
        public string INDEPID { get; set; }
        public string INDEPNAME { get; set; }
    }
    public class PendingWarehouseItems
    {
        public bool checkbox { get; set; }
        public string ProductCode { get; set; }
        public string product { get; set; }
        public double TotalQty { get; set; }
        public double DefectQty { get; set; }
        public string Unit { get; set; }
        public double PKQTYPER { get; set; }
        public DateTime DateExport { get; set; }
        public string OUTTYPE { get; set; }
        public string OUTDEPID { get; set; }
        public string OUTDEPNAME { get; set; }
        public string INTYPE { get; set; }
        public string INDEPID { get; set; }
        public string INDEPNAME { get; set; }






    }
}
