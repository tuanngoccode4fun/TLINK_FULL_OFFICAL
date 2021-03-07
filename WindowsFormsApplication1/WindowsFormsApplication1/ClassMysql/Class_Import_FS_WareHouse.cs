using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.ClassObject
{
    class Import_FinishGood_WareHouse: ICloneable
    {
        public UInt32 Id { get; set; }
        public string TransactionID { get; set; }
        public string STT { get; set; }
        public string Location { get; set; }
        public string UserID { get; set; }
        public string ProductOrder { get; set; }
        public string Product { get; set; }
        public UInt32 Quantity { get; set; }
        public string LotNo { get; set; }
        public string Warehouse { get; set; }
        public DateTime dateCreate { get; set; }
        public string TL101 { get; set; }
        public string TL102 { get; set; }
        public string TL103 { get; set; }
        public string TL104 { get; set; }
        public DateTime dateUpdate { get; set; }
        public string SubQR { get; set; }
        public string ImportFlag { get; set; }
        public string TL111 { get; set; }
        public string TL112 { get; set; }
        public string TL113 { get; set; }
        public string TL114 { get; set; }
        public DateTime dateImport { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }
    }
}
