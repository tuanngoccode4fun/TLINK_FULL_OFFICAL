using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TLMSClient.Model
{

    public class ItemMaterial
    {
        public string deptCode { get; set; }
        public string deptName { get; set; }
        public string IDCode { get; set; }
        public string IDName { get; set; }
        public string ID { get; set; }
        public string Product { get; set; }
        public double Quantity { get; set; }
        public DateTime DateRun { get; set; }
        public double MinPercent { get; set; }
        public List<MaterialItems> MaterialAdapts { get; set; }
    }
    public class ItemMaterialShow
    {
        //public string deptCode { get; set; }
        public string deptName { get; set; }
        //public string IDCode { get; set; }
        //public string IDName { get; set; }
        public string ID { get; set; }
        public string Product { get; set; }
        public double Quantity { get; set; }
        public DateTime DateRun { get; set; }
        public double Percent { get; set; }
        // public List<MaterialAdapt> MaterialAdapts { get; set; }
    }
    public class MaterialDetail
    {
        public string IDCode { get; set; }
        public string percent { get; set; }
        public double Qty_Need { get; set; }
        public double Qty_Get { get; set; }
    }
    public class MaterialItems
    {
 
        public string Material { get; set; }
        public double PlanQty { get; set; }
        public double NeedQty { get; set; }
        public double Current { get; set; }
        public double Percent { get; set; }
        public string Status { get; set; }
        

    }
}
