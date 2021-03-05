using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.COP
{
  public  class COPTD
    {
        public bool UpdateCOPTDDelivery(DataTable dtCOPTH)
        {
            try
            {

                for (int i = 0; i < dtCOPTH.Rows.Count; i++)
                {
                   // double SLDongGoi = Database.INV.INVMD.ConvertToWeightKg(dtCOPTH.Rows[i]["TH004"].ToString(), double.Parse(dtCOPTH.Rows[i]["TH008"].ToString()));
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(" update COPTD ");
                    stringBuilder.Append(" set MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "', ");
                    stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "', ");
                    stringBuilder.Append("  FLAG = FLAG+1 ,  ");
                    stringBuilder.Append("  MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,");
                    stringBuilder.Append("  MODI_AP = '" + "SFT" + "' ,");
                    stringBuilder.Append("  MODI_PRID = '" + "COPI06" + "' ,");
                    stringBuilder.Append("  TD009 = TD009 +" + dtCOPTH.Rows[i]["TH008"] + " ,");
                    stringBuilder.Append("  TD033 = TD033 +" + dtCOPTH.Rows[i]["TH039"] + ", ");
                    stringBuilder.Append("  TD011 = " + dtCOPTH.Rows[i]["TH012"] + ", ");
                    stringBuilder.Append("  TD012 = TD012 + " + dtCOPTH.Rows[i]["TH013"] + ", ");
                    stringBuilder.Append("  TD068 = TD068 + " + dtCOPTH.Rows[i]["TH061"] + " ");//TH061

                    stringBuilder.Append(" where TD001 ='" +dtCOPTH.Rows[i]["TH014"] +"' ");
                    stringBuilder.Append(" and TD002 ='" + dtCOPTH.Rows[i]["TH015"] + "' ");
                    stringBuilder.Append(" and TD003 ='" + dtCOPTH.Rows[i]["TH016"] + "' ");


                    SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                    var result = sqlTLVN2.sqlExecuteNonQuery(stringBuilder.ToString(), false);
                    
                    if (result == false)
                    {
                        SystemLog.Output(SystemLog.MSG_TYPE.War, "UpdateSFCTAForFinishedGoods(FinishedGoodsItems fgItems)", "");
                        return false;
                    }
                    else
                    {
                        isCheckDeliverySucucess(dtCOPTH.Rows[i]["TH014"].ToString().Trim(), dtCOPTH.Rows[i]["TH015"].ToString().Trim(), dtCOPTH.Rows[i]["TH016"].ToString().Trim());
                    }
                }
                return true;

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateSFCTAForFinishedGoods(FinishedGoodsItems fgItems, string TA003)", ex.Message);
            }
            return false;
        }
        public bool isCheckDeliverySucucess(string TD001, string TD002, string TD003)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"  select 
  case
  when ( TD009 >= TD008 and TD033 >=TD032) then 'Y'
  else 'N'
  end as DeliveryStatus
  from COPTD
");
            stringBuilder.Append(" where 1=1 ");
            stringBuilder.Append(" and TD001 = '"+ TD001+"' ");
            stringBuilder.Append(" and TD002 = '" + TD002 + "' ");
            stringBuilder.Append(" and TD003 = '" + TD003 + "' ");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            var strReturn = sqlTLVN2.sqlExecuteScalarString(stringBuilder.ToString());
            if (strReturn == "Y")
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(" update COPTD ");
                builder.Append(" set MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "', ");
                builder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' , ");
                builder.Append("  FLAG = FLAG+1 ,  ");
                builder.Append("  MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,");
                builder.Append("  MODI_AP = '" + "SFT" + "' ,");
                builder.Append("  MODI_PRID = '" + "COPI06" + "' ,");
                builder.Append("  TD016 = 'Y' ");
                builder.Append(" where TD001 ='" + TD001 + "' ");
                builder.Append(" and TD002 ='" + TD002 + "' ");
                builder.Append(" and TD003 ='" + TD003 + "' ");
                sqlTLVN2.sqlExecuteNonQuery(builder.ToString(), false);
                return true;
            }
            else return false;

        }
        public static DataTable GetdtCOPTDby(string TD001, string TD002, string TD003)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select * from COPTD ");
            stringBuilder.Append(" where 1=1 ");
            stringBuilder.Append(" and TD001 ='" + TD001 + "' ");
            stringBuilder.Append(" and TD002 ='" + TD002 + "' ");
            stringBuilder.Append(" and TD003 ='" + TD003 + "' ");

            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
    }
}
