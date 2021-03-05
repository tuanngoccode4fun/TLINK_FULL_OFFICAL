using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Planning.Model;
using System.Data;


namespace WindowsFormsApplication1.Planning.Controler
{
  public  class GetStockinINVMC
    {
        public List<ItemsInINVMC> GetItemsInINVMCs(string dept, string product)
        {
            List<ItemsInINVMC> finishedGoods = new List<ItemsInINVMC>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select MC001,MC002,MC007 from INVMC where 1=1 ");
                stringBuilder.Append("and MC001 ='" + product + "' ");
                DataTable dt = new DataTable();
                sqlERPCON sqlERPCON = new sqlERPCON();
                sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (double.Parse(dt.Rows[i]["MC007"].ToString()) > 0)
                    {
                        finishedGoods.Add(new ItemsInINVMC
                        {

                            Product = dt.Rows[i]["MC001"].ToString(),
                            Quantity = double.Parse(dt.Rows[i]["MC007"].ToString()),
                            Warehouse = dt.Rows[i]["MC002"].ToString()
                        });
                    }

                }
            }
            catch (Exception ex)
            {

                return null;
            }
            return finishedGoods;
        }
        public double StockOfProduct(string ProducNo)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select MB064 from INVMB where 1=1 
");
                stringBuilder.Append(" and MB001   = '" + ProducNo + "' ");
                sqlERPCON sqlERPCON = new sqlERPCON();
                string data = sqlERPCON.sqlExecuteScalarString(stringBuilder.ToString());
                if (data != string.Empty)
                {
                    try
                    {
                        return double.Parse(data);
                    }
                    catch (Exception)
                    {

                        return 0;
                    }
                }
            }
            catch (Exception)
            {

                return 0;
            }
            return 0;
        }
    }
}
