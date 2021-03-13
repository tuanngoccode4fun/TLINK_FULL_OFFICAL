using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Planning.Controler
{
  public  class GetAccessory
    {
        public List<Accessory> GetAccessories(string dept ,string product)
        {
            List<Accessory> accessories = new List<Accessory>();
            try
            {
                //DataTable dt = new DataTable();
                //StringBuilder stringBuilder = new StringBuilder();
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(@" select MD003,MC002,MC007 from BOMMD 
inner join  INVMC on MD003 = MC001
where 1=1 and MD012 ='' and MC007  > '0'
");
                stringBuilder.Append(" and MD001   like '%" + product + "%' ");
                if (dept == "B01-MH"|| dept == "B01-FF")
                {
                    if (product.Contains("BMH") || product.Contains("BWT") || product.Contains("FF"))
                    {

                        stringBuilder.Append("  and (MD003   like '%BPJHC%'  or ( MD003   like '%BPJ-%' and ISNUMERIC(SUBSTRING(MD003,5,1)) = '1' )) ");
                        stringBuilder.Append(" and ( MC002 = 'Y22' or MC002 = 'Y12' ) ");

                    }
                }
                else if (dept == "A01-Gia Dung")
                {

                    stringBuilder.Append("  and (MD003 like 'ABL%' or MD003 like 'AWJ%' )  ");
                    stringBuilder.Append(" and (MC002 = 'A07' or MC002 ='A01' or MC002 = 'W01' or MC002 = '002') ");
                }
                else if (dept == "A01-PTC")
                {

                    stringBuilder.Append("  and (MD003 like 'ABL%' or MD003 like 'AWJ%' )  ");
                    stringBuilder.Append(" and (MC002 = 'A07' or MC002 ='A01' or MC002 = 'W01' or MC002 = '002') ");
                }
                else if (dept == "A01-JM")
                {

                    stringBuilder.Append("  and (MD003 like 'ABL%' or MD003 like 'AWJ%' )  ");
                    stringBuilder.Append(" and (MC002 = 'A07' or MC002 ='A01' or MC002 = 'W01' or MC002 = '002') ");
                }

                sqlERPCON sqlERPCON = new sqlERPCON();
                DataTable dt = new DataTable();
                sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Accessory accessory = new Accessory();
                    accessory.Item = dt.Rows[i]["MD003"].ToString();
                    accessory.Warehouse = dt.Rows[i]["MC002"].ToString();
                    accessory.QtyInWarehouse = double.Parse(dt.Rows[i]["MC007"].ToString().Trim());
                    accessories.Add(accessory);



                }


            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, " List<Accessory> GetAccessories: "+ product, ex.Message);
            }
            return accessories;

        }
    }
}
