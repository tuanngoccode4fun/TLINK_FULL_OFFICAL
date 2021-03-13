using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.ClassObject;

namespace WindowsFormsApplication1.NewQRcode
{
    class sql_QueryFromFileSQL
    {
        static SqlConnection conn = DBUtils.GetTLVN2DBConnection(); //get from user database
        static string ReturnYN(bool value)
        {
            if (value) return "Y";
            else return "N";
        }
        public static bool IsExistQR(string QR_Code)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("select Status from t_QRImport where 1=1 and ");
                stringBuilder.Append("IDQRCODE = '" + QR_Code.Trim() + "'");
                sqlCON sqlTLVN2 = new sqlCON();
                string status = sqlTLVN2.sqlExecuteScalarString(stringBuilder.ToString());
                if (status=="True")
                {

                    SystemLog.Output(SystemLog.MSG_TYPE.War, "IsExistQR", "This QR have already insert complete.");
                    return true;
                }
                return false;

            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "IsExistQR", ex.Message);
                return false;
            }
        }
        public static void InsertQRcode(string QR_Code)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("insert into t_QRImport (IDQRCODE,Status,Update_Date) values('");
                stringBuilder.Append( QR_Code.Trim() + "',");
                stringBuilder.Append("'" + 1 + "',");
                stringBuilder.Append("'" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "')");
                sqlCON sqlTLVN2 = new sqlCON();
                sqlTLVN2.sqlExecuteNonQuery(stringBuilder.ToString(),false);
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertQRcode", ex.Message);
            }

        }
        public static void UpdateQRcodeByID(string ID)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("update t_QRImport set Status ='0'");
                stringBuilder.Append("WHERE Id ="+ ID.Trim());
                sqlCON sqlTLVN2 = new sqlCON();
                sqlTLVN2.sqlExecuteNonQuery(stringBuilder.ToString(), false);
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateQRcode", ex.Message);
            }
        }
        public static void UpdateQRcodeByQR(string QRcode)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("update t_QRImport set Status ='1'");
                stringBuilder.Append(" WHERE IDQRCODE = '" + QRcode.Trim()+"'");
                sqlCON sqlTLVN2 = new sqlCON();
                sqlTLVN2.sqlExecuteNonQuery(stringBuilder.ToString(), false);
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateQRcode", ex.Message);
            }
        }
        public static List<QRImportClass> SelectQRCode(string QR_CODE)
        {
            List<QRImportClass> _listReturn = new List<QRImportClass>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("select * from t_QRImport where IDQRCODE = '");
                stringBuilder.Append(QR_CODE.Trim() + "'");
                sqlCON sqlTLVN2 = new sqlCON();
                DataTable dataTable = new DataTable();
                
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dataTable);
                _listReturn = (from DataRow dr in dataTable.Rows
                                select new QRImportClass()
                                {
                                    ID = (dr["Id"] != null) ? dr["Id"].ToString().Trim() : "",
                                    QRCODE = (dr["IDQRCODE"] != null) ? dr["IDQRCODE"].ToString().Trim() : "",
                                    STATUS = (dr["Status"].ToString() != null) ? dr["Status"].ToString().Trim() : "",
                                    DATE = (dr["Update_Date"].ToString() != null) ?dr["Update_Date"].ToString().Trim() : ""
                                }).ToList();
                
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertQRcode", ex.Message);
            }
            return _listReturn;
        }
        public static List<QRImportClass> SelectQRCodeBaseStatus(string QR_CODE, bool status)
        {
            List<QRImportClass> _listReturn = new List<QRImportClass>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append("select * from t_QRImport where IDQRCODE = '");
                stringBuilder.Append(QR_CODE.Trim() + "'"+"and Status ='"+ status+"'");
                sqlCON sqlTLVN2 = new sqlCON();
                DataTable dataTable = new DataTable();

                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dataTable);
                _listReturn = (from DataRow dr in dataTable.Rows
                               select new QRImportClass()
                               {
                                   ID = (dr["Id"] != null) ? dr["Id"].ToString().Trim() : "",
                                   QRCODE = (dr["IDQRCODE"] != null) ? dr["IDQRCODE"].ToString().Trim() : "",
                                   STATUS = (dr["Status"].ToString() != null) ? dr["Status"].ToString().Trim() : "",
                                   DATE = (dr["Update_Date"].ToString() != null) ? dr["Update_Date"].ToString().Trim() : ""
                               }).ToList();

            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertQRcode", ex.Message);
            }
            return _listReturn;
        }
        static sql_CheckCondition.QueryResult InsertFunction(DataRow ERPPQC, int i, string TF002, bool IsCheckQuantity_Weight, string nameFile)
        {
            try
            {
                //conn.Open();
                string fullText = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\NewQRcode\FileQuerySQL\"+ nameFile.Trim());
                string script = null;
                script = fullText.Replace("@PO_VALUE", ERPPQC["ProductOrder"].ToString().Trim().Replace("-", ""))
                                            .Replace("@LOT_VALUE", ERPPQC["LotNo"].ToString().Trim())
                                            .Replace("@USER_VALUE", Class.valiballecommon.GetStorage().UserName)
                                            .Replace("@WAREHOUSE_VALUE", ERPPQC["Warehouse"].ToString().Trim())
                                            .Replace("@LOCATION_VALUE", ERPPQC["Location"].ToString())
                                            .Replace("@QUANTITY_VALUE", ERPPQC["Quantity"].ToString())
                                            .Replace("@TF001_VALUE", Class.valiballecommon.GetStorage().DocNo)
                                            .Replace("@TF002_VALUE", TF002)
                                            .Replace("@STT_VALUE", (i + 1).ToString("0000"))
                                            .Replace("@Confirm_VALUE", ReturnYN(IsCheckQuantity_Weight));
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                string  status = sqlTLVN2.sqlExecuteScalarString(script.ToString());
                if (status== "End script with sucessful")
                {
                    if (sql_QueryFromFileSQL.SelectQRCodeBaseStatus(ERPPQC["TransactionID"].ToString().Trim(), false).Count > 0)
                    {
                        UpdateQRcodeByQR(ERPPQC["TransactionID"].ToString().Trim());
                    }
                    else
                    { 
                        InsertQRcode(ERPPQC["TransactionID"].ToString());
                    }
                    return sql_CheckCondition.QueryResult.OK;
                }
                else
                {
                    return sql_CheckCondition.QueryResult.Exception;
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertFunction" , "NameFile: "+ nameFile+"\n"+ ex.Message);
                return sql_CheckCondition.QueryResult.Exception;
            }
            finally
            {
                conn.Close();
            }
           //   return sql_CheckCondition.QueryResult.Exception;
        
        }
        /// <summary>
        /// Full insert 
        /// </summary>
        /// <param name="ERPPQC"></param>
        /// <param name="TB002"></param>
        /// <param name="IsCheckQuantity_Weight"></param>
        /// <returns></returns>
        /// 
        public static sql_CheckCondition.QueryResult managestage_managelot_managelocation_07(DataRow ERPPQC,int i,string TF002, bool IsCheckQuantity_Weight)
        {
          return  InsertFunction(ERPPQC, i, TF002, IsCheckQuantity_Weight, "07_manage stage_manage lot_ manage location.sql");//111
        }
        public static sql_CheckCondition.QueryResult managestage_managelot_managelocation_06(DataRow ERPPQC, int i, string TF002, bool IsCheckQuantity_Weight)
        {
            return InsertFunction(ERPPQC, i, TF002, IsCheckQuantity_Weight, "06_manage stage_manage lot_no location.sql");//110
        }
        public static sql_CheckCondition.QueryResult managestage_managelot_managelocation_05(DataRow ERPPQC, int i, string TF002, bool IsCheckQuantity_Weight)
        {
            return InsertFunction(ERPPQC, i, TF002, IsCheckQuantity_Weight, "05_manage stage_no lot_manage location.sql");//101
        }
        public static sql_CheckCondition.QueryResult managestage_managelot_managelocation_04(DataRow ERPPQC, int i, string TF002, bool IsCheckQuantity_Weight)
        {
            return InsertFunction(ERPPQC, i, TF002, IsCheckQuantity_Weight, "04_manage stage_no lot_no location.sql");//100
        }
        public static sql_CheckCondition.QueryResult managestage_managelot_managelocation_03(DataRow ERPPQC, int i, string TF002, bool IsCheckQuantity_Weight)
        {
            return InsertFunction(ERPPQC, i, TF002, IsCheckQuantity_Weight, "03_no stage_manage lot_manage location.sql");
        }
        public static sql_CheckCondition.QueryResult managestage_managelot_managelocation_02(DataRow ERPPQC, int i, string TF002, bool IsCheckQuantity_Weight)
        {
            return InsertFunction(ERPPQC, i, TF002, IsCheckQuantity_Weight, "02_no stage_manage lot_no location.sql");
        }
        public static sql_CheckCondition.QueryResult managestage_managelot_managelocation_01(DataRow ERPPQC, int i, string TF002, bool IsCheckQuantity_Weight)
        {
            return InsertFunction(ERPPQC, i, TF002, IsCheckQuantity_Weight, "01_no stage_no lot_manage location.sql");
        }
        public static sql_CheckCondition.QueryResult managestage_managelot_managelocation_00(DataRow ERPPQC, int i, string TF002, bool IsCheckQuantity_Weight)
        {
            return InsertFunction(ERPPQC, i, TF002, IsCheckQuantity_Weight, "00_no stage_no lot_no location.sql");
        }
        //public static sql_CheckCondition.QueryResult InsertNoStageManagementAndLotManagement(DataRow ERPPQC, int i, string TF002, bool IsCheckQuantity_Weight)
        //{
        //    try
        //    {
        //        conn.Open();
        //        string fullText = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\NewQRcode\FileQuerySQL\not_stageManagement_LotManagement.sql");
        //        string script = null;
        //        script = fullText.Replace("@PO_VALUE", ERPPQC["ProductOrder"].ToString().Trim().Replace("-", ""))
        //                                    .Replace("@LOT_VALUE", ERPPQC["LotNo"].ToString().Trim())
        //                                    .Replace("@USER_VALUE", Class.valiballecommon.GetStorage().UserName)
        //                                    .Replace("@WAREHOUSE_VALUE", ERPPQC["Warehouse"].ToString().Trim())
        //                                    .Replace("@LOCATION_VALUE", ERPPQC["Location"].ToString())
        //                                    .Replace("@QUANTITY_VALUE", ERPPQC["Quantity"].ToString())
        //                                    .Replace("@TF001_VALUE", Class.valiballecommon.GetStorage().DocNo)
        //                                    .Replace("@TF002_VALUE", TF002)
        //                                    .Replace("@STT_VALUE", (i + 1).ToString("0000"))
        //                                    .Replace("@Confirm_VALUE", ReturnYN(IsCheckQuantity_Weight));
        //        using (var command = new SqlCommand(script, conn))
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        return sql_CheckCondition.QueryResult.OK;
        //    }
        //    catch (Exception ex)
        //    {
        //        SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertHaveStageManagementAndLotManagement", ex.Message);
        //        return sql_CheckCondition.QueryResult.Exception;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //public static sql_CheckCondition.QueryResult InsertNoStageManagementAndNoLotManagement(DataRow ERPPQC, int i, string TF002, bool IsCheckQuantity_Weight)
        //{
        //    try
        //    {
        //        conn.Open();
        //        string fullText = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\NewQRcode\FileQuerySQL\not_stageManagement_NoLotManagement.sql");
        //        string script = null;
        //        script = fullText.Replace("@PO_VALUE", ERPPQC["ProductOrder"].ToString().Trim().Replace("-", ""))
        //                                    .Replace("@LOT_VALUE", ERPPQC["LotNo"].ToString().Trim())
        //                                    .Replace("@USER_VALUE", Class.valiballecommon.GetStorage().UserName)
        //                                    .Replace("@WAREHOUSE_VALUE", ERPPQC["Warehouse"].ToString().Trim())
        //                                    .Replace("@LOCATION_VALUE", ERPPQC["Location"].ToString())
        //                                    .Replace("@QUANTITY_VALUE", ERPPQC["Quantity"].ToString())
        //                                    .Replace("@TF001_VALUE", Class.valiballecommon.GetStorage().DocNo)
        //                                    .Replace("@TF002_VALUE", TF002)
        //                                    .Replace("@STT_VALUE", (i + 1).ToString("0000"))
        //                                    .Replace("@Confirm_VALUE", ReturnYN(IsCheckQuantity_Weight));
        //        using (var command = new SqlCommand(script, conn))
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        return sql_CheckCondition.QueryResult.OK;
        //    }
        //    catch (Exception ex)
        //    {
        //        SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertHaveStageManagementAndLotManagement", ex.Message);
        //        return sql_CheckCondition.QueryResult.Exception;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
        //public static sql_CheckCondition.QueryResult InsertHaveStageManagementAndNoLotManagement(DataRow ERPPQC, int i, string TF002, bool IsCheckQuantity_Weight)
        //{
        //    try
        //    {
        //        conn.Open();
        //        string fullText = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\NewQRcode\FileQuerySQL\StageManagement_NotLotManagement.sql");
        //        string script = null;
        //        script = fullText.Replace("@PO_VALUE", ERPPQC["ProductOrder"].ToString().Trim().Replace("-", ""))
        //                                    .Replace("@LOT_VALUE", ERPPQC["LotNo"].ToString().Trim())
        //                                    .Replace("@USER_VALUE", Class.valiballecommon.GetStorage().UserName)
        //                                    .Replace("@WAREHOUSE_VALUE", ERPPQC["Warehouse"].ToString().Trim())
        //                                    .Replace("@LOCATION_VALUE", ERPPQC["Location"].ToString())
        //                                    .Replace("@QUANTITY_VALUE", ERPPQC["Quantity"].ToString())
        //                                    .Replace("@TF001_VALUE", Class.valiballecommon.GetStorage().DocNo)
        //                                    .Replace("@TF002_VALUE", TF002)
        //                                    .Replace("@STT_VALUE", (i + 1).ToString("0000"))
        //                                    .Replace("@Confirm_VALUE", ReturnYN(IsCheckQuantity_Weight));
        //        using (var command = new SqlCommand(script, conn))
        //        {
        //            command.ExecuteNonQuery();
        //        }
        //        return sql_CheckCondition.QueryResult.OK;
        //    }
        //    catch (Exception ex)
        //    {
        //        SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertHaveStageManagementAndLotManagement", ex.Message);
        //        return sql_CheckCondition.QueryResult.Exception;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}
    }
}
