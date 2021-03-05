using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.ClassMysql
{
   class Class_ExportFG_WareHouse:ICloneable
    {
        public UInt32 Id { get; set; }
        public string TransactionID { get; set; }
        public string STT { get; set; }
        public string Client { get; set; }
        public string ClientCode { get; set; }
        public string ClientOrder { get; set; }
        public string OrderSTT { get; set; }
        public string CustomerOrder { get; set; }
        public string Product { get; set; }
        public string DocNo { get; set; }
        public string DeptCode { get; set; }
        public UInt32 Quantity { get; set; }
        public string Unit { get; set; }
        public string LotNo { get; set; }
        public string Warehouse { get; set; }
        public string Location { get; set; }
        public UInt32 PriceUnit { get; set; }
        public string Invoice { get; set; }
        public string Currency { get; set; }
        public DateTime dateCreate { get; set; }
        public string TL201 { get; set; }
        public string TL202 { get; set; }
        public string TL203 { get; set; }
        public string TL204 { get; set; }
        public DateTime dateUpdate { get; set; }
        public string ExportFlag { get; set; }
        public string TL211 { get; set; }
        public string TL212 { get; set; }
        public string TL213 { get; set; }
        public string TL214 { get; set; }
        public DateTime dateExport { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone() ;
        }
    }
}
