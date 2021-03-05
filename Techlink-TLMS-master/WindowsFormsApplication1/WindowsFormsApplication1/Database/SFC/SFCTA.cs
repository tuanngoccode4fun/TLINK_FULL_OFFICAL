using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WindowsFormsApplication1.WMS.Model;

namespace WindowsFormsApplication1.Database.SFC
{
   public class SFCTA
    {
        public static string getProductionOrder(string Product)
        {
            DataTable dt = new DataTable();
            string productionOrder = "";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"   SELECT a.TA001+'-'+a.TA002 as PO FROM SFCTA a
 INNER JOIN MOCTA b on a.TA001 = b.TA001 and a.TA002 = b.TA002
 WHERE a.TA010>a.TA011+a.TA012 and a.TA003 = '0020' and b.TA011 not in ('y','Y') and CAST(a.CREATE_DATE as datetime) > '20200301' ");
            stringBuilder.Append(" and  b.TA006 like  '%" + Product + "%' ");
            stringBuilder.Append("  order by CAST(a.CREATE_DATE as datetime) ASC  ");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            if (dt.Rows.Count > 0)
                productionOrder = dt.Rows[0]["PO"].ToString();
            return productionOrder;
        }
        public static string getProductionOrder(List<PQCOutStock> ListSelected, string Product, out bool NoMorePO)
        {
            DataTable dt = new DataTable();
            string productionOrder = "";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"   SELECT a.TA001+'-'+a.TA002 as PO FROM SFCTA a
 INNER JOIN MOCTA b on a.TA001 = b.TA001 and a.TA002 = b.TA002
 WHERE a.TA010>a.TA011+a.TA012 and a.TA003 = '0020' and b.TA011 not in ('y','Y') and CAST(a.CREATE_DATE as datetime) > '20200201' ");
            stringBuilder.Append(" and  b.TA006 like  '%" + Product + "%' ");
            stringBuilder.Append("  order by CAST(b.CREATE_DATE as datetime) + CAST(b.CREATE_TIME as datetime) DESC  ");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            double PQCStock = 0;
            bool duplicate = false;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                 PQCStock = Database.SFT.SFT_LOT.GetPQCStock(dt.Rows[i]["PO"].ToString());
               
                    var checkDuplicateOrder = ListSelected.Select(d => d.ProductOrder).ToList();
                if (PQCStock > 0)
                {
                    if (checkDuplicateOrder.Contains(dt.Rows[i]["PO"].ToString()) == false)
                    {
                  
                        productionOrder = dt.Rows[i]["PO"].ToString();//ti sua lai la i
                        NoMorePO = false;
                        return productionOrder;
                    }
                    else
                    {
                        duplicate = true;
                    }

                }
            }

            //if (PQCStock == 0 && productionOrder == "")
            //{
                
            //    NoMorePO = false;
            //    return productionOrder;
            //}
            if (dt.Rows.Count > 0 && duplicate == true)
            {

                if (ListSelected.Count > 0 )

                {
                    var OrderDuplicated = ListSelected.Where(d => d.Product.Contains(Product)).Select(d => d.ProductOrder).ToList();
                    if (OrderDuplicated.Count > 0)
                    {
                        productionOrder = OrderDuplicated[0];

                        NoMorePO = true;
                    }
                    else
                    {
                        productionOrder = "";
                        NoMorePO = false;
                    }
                }
                else
                {
                    productionOrder = "";
                    NoMorePO = false;
                }
            }
            else NoMorePO = false;
            return productionOrder;
        }
        public static DataTable GetDataTableSFCTA(string productCode)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select * from SFCTA where 1=1 and TA003 = '0020' ");
            stringBuilder.Append(" and TA001 ='" + productCode.Split('-')[0] + "' ");
            stringBuilder.Append(" and TA002 ='" + productCode.Split('-')[1] + "' ");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public bool UpdateSFCTAForFinishedGoods(DataTable dtERPPQC)
        {
            try
            {

                for (int i = 0; i < dtERPPQC.Rows.Count; i++)
                {
                    double SLDongGoi = Database.INV.INVMD.ConvertToWeightKg(dtERPPQC.Rows[i]["Product"].ToString(), double.Parse(dtERPPQC.Rows[i]["Quantity"].ToString()));
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(" update SFCTA ");
                    stringBuilder.Append(" set MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "', ");
                    stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "', ");
                    stringBuilder.Append("  FLAG = FLAG+1 ,  ");
                    stringBuilder.Append("  MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,");
                    stringBuilder.Append("  MODI_AP = '" + "SFT" + "' ,");
                    stringBuilder.Append("  MODI_PRID = '" + "Sftb03" + "' ,");
                    stringBuilder.Append("  TA011 = TA011 + " + dtERPPQC.Rows[i]["Quantity"] + " ,");
                    stringBuilder.Append("  TA039 = TA039 +" + SLDongGoi .ToString()+ " ");
                    stringBuilder.Append(" where TA001 ='" + dtERPPQC.Rows[i]["ProductOrder"].ToString().Trim().Split('-')[0] + "' ");
                    stringBuilder.Append(" and TA002 ='" + dtERPPQC.Rows[i]["ProductOrder"].ToString().Trim().Split('-')[1] + "' ") ;
                    stringBuilder.Append(" and TA003 ='" + "0020" + "' ");


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

        public bool UpdateSFCTAForFinishedGoodsNotConfirm(DataTable dtERPPQC)
        {
            try
            {

                for (int i = 0; i < dtERPPQC.Rows.Count; i++)
                {
                    double SLDongGoi = Database.INV.INVMD.ConvertToWeightKg(dtERPPQC.Rows[i]["Product"].ToString(), double.Parse(dtERPPQC.Rows[i]["Quantity"].ToString()));
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(" update SFCTA ");
                    stringBuilder.Append(" set MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "', ");
                    stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "', ");
                    stringBuilder.Append("  FLAG = FLAG+1 ,  ");
                    stringBuilder.Append("  MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,");
                    stringBuilder.Append("  MODI_AP = '" + "SFT" + "' ,");
                    stringBuilder.Append("  MODI_PRID = '" + "Sftb03" + "' ,");
                    stringBuilder.Append("  TA017 = TA017 + " + dtERPPQC.Rows[i]["Quantity"] + " ,");
                    stringBuilder.Append("  TA045 = TA045 +" + SLDongGoi.ToString() + " ");
                    stringBuilder.Append(" where TA001 ='" + dtERPPQC.Rows[i]["ProductOrder"].ToString().Trim().Split('-')[0] + "' ");
                    stringBuilder.Append(" and TA002 ='" + dtERPPQC.Rows[i]["ProductOrder"].ToString().Trim().Split('-')[1] + "' ");
                    stringBuilder.Append(" and TA003 ='" + "0020" + "' ");


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
        public static bool IsExistSFCTA(string productCode)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select * from SFCTA where 1=1 and TA003 = '0020' ");
            stringBuilder.Append(" and TA001 ='" + productCode.Split('-')[0] + "' ");
            stringBuilder.Append(" and TA002 ='" + productCode.Split('-')[1] + "' ");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            string status= sqlTLVN2.sqlExecuteScalarString(stringBuilder.ToString());
            if (status.Trim() == "")
            {
                return false;
            }
            return true;
        }
        public static bool IsSFCTA_TA010_NULL_ZERO(string productCode)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select ISNULL(TA010,0) as TA10 from SFCTA where 1=1 and TA003 = '0020'");
            stringBuilder.Append(" and TA001 ='" + productCode.Split('-')[0] + "' ");
            stringBuilder.Append(" and TA002 ='" + productCode.Split('-')[1] + "' ");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            string status = sqlTLVN2.sqlExecuteScalarString(stringBuilder.ToString());
            if ( Convert.ToDouble( status.Trim()) >0)
            {
                return true;
            }
            return false;
        }
        public static    bool IscheckQantityAndWeight(string productCode, double Quantity, double Weight)
        {
            try
            {
                DataTable dt = new DataTable();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("select ISNULL(TA010,0) as TA010,ISNULL(TA011,0) as TA011,ISNULL(TA012,0) as TA012,ISNULL(TA038,0) as TA038,ISNULL(TA039,0) as TA039,ISNULL(TA040,0) as TA040 from SFCTA where 1=1 and TA003 = '0020' ");
                stringBuilder.Append(" and TA001 ='" + productCode.Split('-')[0] + "' ");
                stringBuilder.Append(" and TA002 ='" + productCode.Split('-')[1] + "' ");
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                if (dt.Rows.Count == 1)
                {
                    double TA010 = double.Parse(dt.Rows[0]["TA010"].ToString());
                    double TA011 = double.Parse(dt.Rows[0]["TA011"].ToString());
                    double TA012 = double.Parse(dt.Rows[0]["TA012"].ToString());
                    double TA038 = double.Parse(dt.Rows[0]["TA038"].ToString());
                    double TA039 = double.Parse(dt.Rows[0]["TA039"].ToString());
                    double TA040 = double.Parse(dt.Rows[0]["TA040"].ToString());

                    if (TA010 < TA011 + TA012 + Quantity)
                        return false;
                    else if (TA038 < TA039 + TA040 + Weight)
                        return false;
                    else  return true;

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
