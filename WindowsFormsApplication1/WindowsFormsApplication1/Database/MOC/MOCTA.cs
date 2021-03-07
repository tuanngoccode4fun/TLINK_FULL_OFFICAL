using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.MOC
{
 public   class MOCTA
    {
        public static string GetProductFromMOCTA (string product)
        {
            string sp = "";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@" select distinct TA006 from MOCTA 
inner join INVMB on MB001 = TA006
where  (MB031 = '' or CAST(MB031 as datetime) >= GETDATE()) ");
            stringBuilder.Append(" and TA006 like '%" + product + "%' ");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sp = sqlTLVN2.sqlExecuteScalarString(stringBuilder.ToString());
            return sp;
        }
        public bool UpdateMOCTAForFinishedGoods(DataTable dtERPPQC)
        {
            try
            {

                for (int i = 0; i < dtERPPQC.Rows.Count; i++)
                {
                    double SLDongGoi = Database.INV.INVMD.ConvertToWeightKg(dtERPPQC.Rows[i]["Product"].ToString(), double.Parse(dtERPPQC.Rows[i]["Quantity"].ToString()));
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(" update MOCTA ");
                    stringBuilder.Append(" set MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "', ");
                    stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "', ");
                    stringBuilder.Append("  FLAG = FLAG+1 ,  ");
                    stringBuilder.Append("  MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,");
                    stringBuilder.Append("  MODI_AP = '" + "SFT" + "' ,");
                    stringBuilder.Append("  MODI_PRID = '" + "" + "' ,");
                    stringBuilder.Append("  TA014 =  '" + DateTime.Now.ToString("yyyyMMdd") + "' ,");
                    stringBuilder.Append("  TA017 = TA017 + " + dtERPPQC.Rows[i]["Quantity"] + " ,");
                    stringBuilder.Append("  TA046 = TA046 + " + SLDongGoi.ToString() + " ");
                    stringBuilder.Append(" where TA001 ='" + dtERPPQC.Rows[i]["ProductOrder"].ToString().Trim().Split('-')[0] + "' ");
                    stringBuilder.Append(" and TA002 ='" + dtERPPQC.Rows[i]["ProductOrder"].ToString().Trim().Split('-')[1] + "' ");

                    SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                    var result = sqlTLVN2.sqlExecuteNonQuery(stringBuilder.ToString(), false);
                    if (result == false)
                    {
                        SystemLog.Output(SystemLog.MSG_TYPE.War, "UpdateSFCTAForFinishedGoods(FinishedGoodsItems fgItems)", "");
                        return false;
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
        public static bool IsMOCTA_TA013_CONFIRM_Y(string productCode)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select TA013 as TA013 from MOCTA where 1=1");
            stringBuilder.Append(" and TA001 ='" + productCode.Split('-')[0] + "' ");
            stringBuilder.Append(" and TA002 ='" + productCode.Split('-')[1] + "' ");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            string status = sqlTLVN2.sqlExecuteScalarString(stringBuilder.ToString());
            if (status.Trim() == "") return false;
            if (status.Trim() == "Y")
            {
                return true;
            }
            return false;
        }
        public static bool IscheckQantityAndWeight(string productCode, double Quantity, double Weight)
        {
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select ISNULL(TA015,0) as TA015,ISNULL(TA017,0) as TA017,ISNULL(TA018,0) as TA018,ISNULL(TA045,0) as TA045,ISNULL(TA046,0) as TA046,ISNULL(TA047,0) as TA047
from MOCTA where 1 =1 ");
                stringBuilder.Append(" and TA001 ='" + productCode.Split('-')[0] + "' ");
                stringBuilder.Append(" and TA002 ='" + productCode.Split('-')[1] + "' ");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                if (dt.Rows.Count == 1)
                {
                    double TA015 = double.Parse(dt.Rows[0]["TA015"].ToString());
                    double TA017 = double.Parse(dt.Rows[0]["TA017"].ToString());
                    double TA018 = double.Parse(dt.Rows[0]["TA018"].ToString());
                    double TA045 = double.Parse(dt.Rows[0]["TA045"].ToString());
                    double TA046 = double.Parse(dt.Rows[0]["TA046"].ToString());
                    double TA047 = double.Parse(dt.Rows[0]["TA047"].ToString());

                    if (TA015 < TA017 + TA018 + Quantity)
                        return false;
                    else if (TA045 < TA046 + TA047 + Weight)
                        return false;
                    else return true;

                }

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "IscheckQantityAndWeight(string productCode, double Quantity, double Weight)", ex.Message);
            }
            return false;
        }
    }
}
