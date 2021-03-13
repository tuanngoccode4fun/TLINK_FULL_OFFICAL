using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TLMSClient.Model;

namespace TLMSClient.Controller
{
    class CheckMaterial
    {
        public List<ItemMaterial> ListMaterial(string MaBP)
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
                                       {
                                           deptCode = dr["TC007"].ToString(),
                                           IDCode = dr["TC004"].ToString(),
                                           IDName = dr["TC005"].ToString(),
                                           ID = dr["TC004"].ToString() + "-" + dr["TC005"].ToString(),
                                           Product = dr["TC047"].ToString(),
                                           DateRun = (dr["TB003"].ToString() != "") ? DateTime.Parse(dr["TB003"].ToString().Insert(4, "-").Insert(7, "-")) : DateTime.MinValue

                                       }).ToList();
                //      itemMaterials = InforProduction;
                bool ISNVL = false; bool isSL = false;
                List<MaterialItems> materialAdapts = new List<MaterialItems>();
                foreach (var item in InforProduction)
                {

                    Material material = new Material();
                    double Qty = 0;
                    var IsCheckNVL = material.IsMaterialOK(item.IDCode, item.IDName, out ISNVL, out materialAdapts, out Qty);
                    item.Quantity = Qty;
                    if (ISNVL == false)
                    {
                        item.MaterialAdapts = materialAdapts;
                       
                        itemMaterials.Add(item);
                    }

                }

            }
            catch (Exception ex)
            {

                throw;
            }
            return itemMaterials;
        }
    }
}
