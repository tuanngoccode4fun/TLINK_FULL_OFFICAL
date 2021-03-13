using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.INV
{
  public  class INVMD
    {
        public static double ConvertToWeightKg(string Model, double Weight)
        {
            double WeightKg = 0;
            double Weight_MD003 = 0;
            double Weight_MD004 = 0;
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select MB001,MB004,MD004, MD003,MD002, MB091 from INVMB 
left join INVMD on MB001 = MD001
where
((MB091 = 'Y' 
and  MD002 = 'KG' ) or (MB091 = 'N' 
and  MB004 = 'KG' )) ");
                stringBuilder.Append(" and MB001 = '" + Model + "' ");
                SqlTLVN2 con = new SqlTLVN2();
                con.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0]["MB091"].ToString() == "Y")
                    {
                        Weight_MD003 = double.Parse(dt.Rows[0]["MD003"].ToString());
                        Weight_MD004 = double.Parse(dt.Rows[0]["MD004"].ToString());
                        if (Weight_MD003 == 0 || Weight_MD004 == 0)
                        {
                            return 0;
                        }
                        else
                        {
                            WeightKg = Weight * Weight_MD003 / Weight_MD004;
                            return WeightKg;
                        }
                    }
                    else if (dt.Rows[0]["MB091"].ToString() == "N")
                    {
                        if (dt.Rows[0]["MB004"].ToString() == "KG")
                            return Weight;
                    }
                    else return 0;
                }
                else
                {
                    return 0;
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
