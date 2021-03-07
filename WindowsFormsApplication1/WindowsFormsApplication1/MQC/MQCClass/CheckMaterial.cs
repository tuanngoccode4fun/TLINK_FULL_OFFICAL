using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.MQC.MQCClass
{
 public   class CheckMaterial
    {
        public List<ItemMaterial> ListMaterial (string MaBP)
        {
            List<ItemMaterial> itemMaterials = new List<ItemMaterial>();
            DateTime date = DateTime.Now.AddDays(0).Date;
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
               // stringBuilder.Append()
              
                stringBuilder.Append(@"select distinct TC004,TC005,TC007,TC047,TB003 from SFCTC a
inner join SFCTB on TC001 = TB001 and TC002 = TB002
 where 1=1 ");

                stringBuilder.Append("and CONVERT(date, TB003) >=  '" + date.ToString("yyyyMMdd") + "'");

                sqlERPCON sql = new sqlERPCON();
                DataTable dt = new DataTable();
                sql.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                var InforProduction = (from DataRow dr in dt.Rows
                               select new ItemMaterial()
                               {deptCode = dr["TC007"].ToString(),
                                   IDCode = dr["TC004"].ToString(),
                                   IDName = dr["TC005"].ToString(),
                                   ID = dr["TC004"].ToString() + "-" + dr["TC005"].ToString(),
                                   Product = dr["TC047"].ToString(),
                                   DateRun = (dr["TB003"].ToString() != "") ? DateTime.Parse(dr["TB003"].ToString().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue

                               }).ToList();
          //      itemMaterials = InforProduction;
                bool ISNVL = false;
                List<MaterialItems> materialAdapts = new List<MaterialItems>();
                foreach (var item in InforProduction)
                {

                    Material material = new Material();
                    var IsCheckNVL = material.IsMaterialOK(item.IDCode, item.IDName,   out ISNVL, out materialAdapts);

                    if (ISNVL == false)
                    {
                        item.MaterialAdapts = materialAdapts;
                        itemMaterials.Add(item);
                    }
                        
                 }

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<ItemMaterial> ListMaterial (string MaBP)", ex.Message);
            }
            return itemMaterials;
        }
    }
   
    public class ItemMaterial
    {
        public string deptCode { get; set; }
        public string deptName { get; set; }
        public string IDCode { get; set; }
        public string IDName { get; set; }
        public string ID { get; set; }
        public string Product { get; set; }
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
}
