﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.Database.MOC;
using WindowsFormsApplication1.Database.SFC;

namespace WindowsFormsApplication1.NewQRcode
{
    public class sql_CheckCondition
    {
        public enum QueryResult { OK, NG, Exception_A_02,Exception };
        static SqlConnection conn = DBUtils.GetTLVN2DBConnection(); //get from user database
        static List<string> ListSpec = new List<string>() { "AD-", "AT-", "ED-", "ET-", "CD-", "CT-" };
        /// <summary>
        /// INVMB - MB010 : có giá tri => có công đoạn ( trừ mã MB001 bắt dau bằng AD-, AT-, ED-, ET-, CD-, CT-)
        /// </summary>
        /// <param name="MB001_product"></param>
        /// <returns></returns>
        public static QueryResult Is_stageManagement(string MB001_product)
        {
            try
            {
                string temp = MB001_product.Trim().Substring(0, 3);
                conn.Open();
                string m_query_INVMB = @"select distinct MB011 from INVMB where MB001 = '" + MB001_product.Trim() + "'"; // 
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                string GetString = sqlTLVN2.sqlExecuteScalarString(m_query_INVMB);
                if(GetString != "" || GetString != string.Empty)
                {
                    if (GetString != "A-02")
                    {
                        if (ListSpec.Contains(temp))// No managmentSTAGE
                        {
                            return QueryResult.NG;
                        }
                        else
                        {
                            return QueryResult.OK;
                        }
                    }
                    else
                    {
                        return QueryResult.Exception_A_02;
                    }
                }
                else
                {
                    return QueryResult.NG;
                }
            }
                //using (SqlCommand command = new SqlCommand(m_query_INVMB, conn))
                //using (SqlDataReader reader = command.ExecuteReader())
                //{
                //    // Kiểm tra có kết quả trả về
                //    if (reader.HasRows)
                //    {

                //        return QueryResult.OK;
                //    }
                //    else
                //    {
                //        return QueryResult.NG;
                //    }
                //}

            
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Is_stageManagement", ex.Message);
                return QueryResult.Exception;
            }
            finally
            {
                conn.Close();
            }

        }
        /// <summary>
        ///  INVMB -MB022 : gia tri là "Y" hoac "T" => quan ly so lot
        /// </summary>
        /// <param name="MB001_product"></param>
        /// <returns></returns>
        public static QueryResult Is_lotManagement(string MB001_product)
        {
            try
            {
                conn.Open();
                string m_query_INVMB = @"select distinct MB022 from INVMB where MB001 = '" + MB001_product.Trim() + "'"; // 
                using (DataTable myTable = new DataTable())
                using (SqlCommand command = new SqlCommand(m_query_INVMB, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Kiểm tra có kết quả trả về
                    if (reader.HasRows)
                    {
                        myTable.Load(reader);
                        if (myTable.Rows[0]["MB022"].ToString() == "Y" || myTable.Rows[0]["MB022"].ToString() == "T")
                        {
                            return QueryResult.OK;
                        }
                        return QueryResult.NG;
                    }
                    else
                    {
                        return QueryResult.NG;
                    }
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Is_lotManagement", ex.Message);
                return QueryResult.Exception;
            }
            finally
            {
                conn.Close();
            }
        }
        /// <summary>
        /// [Tuanngoc Dev] For check condition for all item before proceed Update data to all department.
        /// </summary>
        /// <param name="dtERPPQC"></param>
        /// <returns></returns>
        /// 
        ///////
        public static QueryResult Is_LocationManagement(string Warehouse)
        {
            try
            {
                conn.Open();
                string m_query_INVMB = @"select MC009 as QLVTLK from CMSMC where MC001 = '" + Warehouse.Trim() + "'"; // 
                using (DataTable myTable = new DataTable())
                using (SqlCommand command = new SqlCommand(m_query_INVMB, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Kiểm tra có kết quả trả về
                    if (reader.HasRows)
                    {
                        myTable.Load(reader);
                        if (myTable.Rows[0]["QLVTLK"].ToString() == "Y")
                        {
                            return QueryResult.OK;
                        }
                        return QueryResult.NG;
                    }
                    else
                    {
                        return QueryResult.NG;
                    }
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Is_LocationManagement", ex.Message);
                return QueryResult.Exception;
            }
            finally
            {
                conn.Close();
            }
        }
        public static QueryResult CheckConditionAllItemQRCodeInsert(DataTable dtERPPQC)
        {
            QueryResult ttReturn = QueryResult.OK;
            List<string> isListDistict = new List<string>();
            double notConfirmQuantity = 0;
            double demandQuantity = 0;
            try
            {
                for (int i = 0; i < dtERPPQC.Rows.Count; i++)
                {
                    string PO = dtERPPQC.Rows[i]["ProductOrder"].ToString().Trim();
                    string product = dtERPPQC.Rows[i]["Product"].ToString().Trim();
                    if (!isListDistict.Contains(PO))
                    {
                        isListDistict.Add(PO);
                        int temp = Convert.ToInt32(dtERPPQC.Rows[i]["Quantity"]);
                        string sumText = dtERPPQC.AsEnumerable().Where(row => row.Field<string>("ProductOrder") == PO).Sum(row => row.Field<UInt32>("Quantity")).ToString();
                        UInt32 sum32Int = Convert.ToUInt32(sumText);// convert success 
                        double SLDongGoi = Math.Round( Database.INV.INVMD.ConvertToWeightKg(product, sum32Int),3);
                        sql_CheckCondition.QueryResult statusStage = sql_CheckCondition.Is_stageManagement(product);/// check condition have stage management.
                        demandQuantity = GetQuantityDemandPlan(PO);
                        bool statusWeight;
                        if (Is_stageManagement(product) == QueryResult.OK)
                        {
                            statusWeight = GetWeightDemandPlan(PO, SLDongGoi);
                            if (!statusWeight)
                            {
                                ttReturn = QueryResult.NG;
                                UI_mesage.ClassMessageBoxUI.Show("[Quản lí công đoạn] Vui lòng kiểm tra lỗi nhập vượt trọng lượng", false);                               
                            }
                        }
                        else 
                        {
                            statusWeight = GetWeightDemandPlan_NoStageManagement(PO, SLDongGoi);
                            if (!statusWeight)
                            {
                                ttReturn = QueryResult.Exception;
                                SystemLog.Output(SystemLog.MSG_TYPE.Err, "CheckConditionAllItemQRCodeInsert", "Mã không quản lý công đoạn bị lỗi nhập vượt trọng lượng.");/// Không tạo phiếu và bị lỗi nhập vượt trọng lượng
                                UI_mesage.ClassMessageBoxUI.Show("[Không quản lí công đoạn] Vui lòng kiểm tra lỗi nhập vượt trọng lượng ", false);
                                break;
                            }
                        }

                        if (statusStage == QueryResult.OK)
                        {
                            notConfirmQuantity = GetQuantityNotConfirmHaveStageManagment(PO);
                            if (notConfirmQuantity != -1 && demandQuantity != -1)
                            {
                                if (demandQuantity - (notConfirmQuantity + sum32Int) < 0)
                                {
                                    ttReturn = QueryResult.NG;
                                    UI_mesage.ClassMessageBoxUI.Show("[Quản lí công đoạn] Vui lòng kiểm tra lỗi nhập vượt số lượng ", false);
                                }
                            }
                        }
                        else
                        {
                            notConfirmQuantity = GetQuantityNotConfirmNoStageManagment(PO);
                            if (notConfirmQuantity != -1 && demandQuantity != -1)
                            {
                                if (demandQuantity - (notConfirmQuantity + sum32Int) < 0)
                                {
                                    ttReturn = QueryResult.Exception;
                                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "CheckConditionAllItemQRCodeInsert", "Mã không quản lý công đoạn bị lỗi nhập vượt số lượng");// Lỗi không quả l
                                    UI_mesage.ClassMessageBoxUI.Show("[Không quản lí công đoạn] Vui lòng kiểm tra lỗi nhập vượt số lượng ", false);
                                    break;
                                }
                            }
                        }
                    }
                    if (Is_stageManagement(product)==QueryResult.OK &&SFCTA.Is_SFCTA_TA010_NO_HAVE_NULL_ZERO(PO) == false)
                    {
                        ttReturn = QueryResult.Exception;
                        SystemLog.Output(SystemLog.MSG_TYPE.Err, "CheckConditionAllItemQRCodeInsert", "Please check TA010 value of SFCTA is null or ZERO");
                        UI_mesage.ClassMessageBoxUI.Show("[Quản lý công đoạn] Vui lòng kiểm tra TA10 trong bảng SFCTA có giá trị là NULL hoặc \"0\"", false, 2000);
                        break;

                    }
                    if (Is_stageManagement(product) == QueryResult.NG && MOCTA.IsMOCTA_TA013_CONFIRM_Y(PO) == false)
                    {
                        ttReturn = QueryResult.Exception;
                        SystemLog.Output(SystemLog.MSG_TYPE.Err, "CheckConditionAllItemQRCodeInsert", "Please check IsMOCTA_TA013_CONFIRM_Y");
                        UI_mesage.ClassMessageBoxUI.Show("[Không quản lý công đoạn] Vui lòng kiểm tra TA03 trong bảng MOCTA có giá trị khác \"Y\"", false,2000);
                        break;

                    }

                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Exception message", "CheckConditionAllItemQRCodeInsert :" + ex.Message);
                return QueryResult.Exception;
            }
            return ttReturn;
        }
        public static double GetQuantityNotConfirmHaveStageManagment(string PO)
        {
            double returnValue = -1;
            try
            {
                conn.Open();
                string P = PO.Split('-')[0].Trim();
                string O = PO.Split('-')[1].Trim();
                string m_query_temp = @"Select ISNULL(sum(TC014),0)as TongCXN from SFCTC 
                                         Inner join SFCTB on TC001 = TB001 and TC002 = TB002
                                         where TC004 =  @P and TC005 = @O 
                                         and TB013 = 'N'"; // 
                string m_query_SFCTB = m_query_temp.Replace("@P", "'" + P + "'").Replace("@O","'"+O+"'");
                using (DataTable myTable = new DataTable())
                using (SqlCommand command = new SqlCommand(m_query_SFCTB, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Kiểm tra có kết quả trả về
                    if (reader.HasRows)
                    {
                        myTable.Load(reader);
                        if (myTable.Rows[0]["TongCXN"].ToString()!="")
                        {
                            returnValue= Convert.ToDouble(myTable.Rows[0]["TongCXN"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetQuantityNotConfirmHaveStageManagment", ex.Message);
            }
            finally
            {
                conn.Close();

            }
            return returnValue;
        }
        public static double GetQuantityNotConfirmNoStageManagment(string PO)
        {
            double returnValue = -1;
            try
            {
                conn.Open();
                string P = PO.Split('-')[0].Trim();
                string O = PO.Split('-')[1].Trim();
                string m_query_temp = @"Select ISNULL(sum(TG011 + TG012),0) as TongCXN from MOCTG
                                        Inner join MOCTF on TG001 = TF001 and TG002 = TF002
                                        where TG014 =  @P and TG015 = @O
                                        and TF006 = 'N'"; // 
                string m_query_MOCTG = m_query_temp.Replace("@P", "'" + P + "'").Replace("@O", "'" + O + "'");
                using (DataTable myTable = new DataTable())
                using (SqlCommand command = new SqlCommand(m_query_MOCTG, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Kiểm tra có kết quả trả về
                    if (reader.HasRows)
                    {
                        myTable.Load(reader);
                        if (myTable.Rows[0]["TongCXN"].ToString() != "")
                        {
                            returnValue = Convert.ToDouble(myTable.Rows[0]["TongCXN"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetQuantityNotConfirmNoStageManagment", ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return returnValue;
        }
        public static double GetQuantityDemandPlan(string PO)
        {
            double returnValue = -1;
            try
            {
                conn.Open();
                string P = PO.Split('-')[0].Trim();
                string O = PO.Split('-')[1].Trim();
                string m_query_temp = @"select TA015 as SLDT, TA017 as SLDSX, TA018 AS SLBP, (TA015-TA017-TA018)
                                        as SLCoTHeNhapKHo from MOCTA  where TA001 = @P and TA002 = @O"; // 
                string m_query_MOCTA = m_query_temp.Replace("@P", "'" + P + "'").Replace("@O", "'" + O + "'");
                using (DataTable myTable = new DataTable())
                using (SqlCommand command = new SqlCommand(m_query_MOCTA, conn))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Kiểm tra có kết quả trả về
                    if (reader.HasRows)
                    {
                        myTable.Load(reader);
                        if (myTable.Rows[0]["SLCoTHeNhapKHo"].ToString().Trim() != "")
                        {
                            returnValue= Convert.ToDouble(myTable.Rows[0]["SLCoTHeNhapKHo"].ToString().Trim());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetQuantityDemandPlan", ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return returnValue;
        }
        public static bool GetWeightDemandPlan(string PO, Double SLDongGoi)
        {
            try
            {
                conn.Open();
                string P = PO.Split('-')[0].Trim();
                string O = PO.Split('-')[1].Trim();
                string m_query_temp = @"select ISNULL(TA010,0) as TA010,ISNULL(TA011,0) as TA011,ISNULL(TA012,0) as TA012,ISNULL(TA038,0) as TA038,
                                        ISNULL(TA039,0) as TA039,ISNULL(TA040,0) as TA040,* from SFCTA where 1=1 and TA003 = '0020'
                                        and  TA001 = @P and TA002 = @O"; // 
                string m_query_MOCTA = m_query_temp.Replace("@P", "'" + P + "'").Replace("@O", "'" + O + "'");
                DataTable dt = new DataTable();
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(m_query_MOCTA.ToString(), ref dt);
                if (dt.Rows.Count == 1)
                {

                    double TA038 = double.Parse(dt.Rows[0]["TA038"].ToString());
                    double TA039 = double.Parse(dt.Rows[0]["TA039"].ToString());
                    double TA040 = double.Parse(dt.Rows[0]["TA040"].ToString());

                    if ( TA039 + TA040 + SLDongGoi>TA038)
                        return false;
                    else return true;

                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetWeightDemandPlan", ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }
        public static bool GetWeightDemandPlan_NoStageManagement(string PO, Double SLDongGoi)
        {
            try
            {
                conn.Open();
                string P = PO.Split('-')[0].Trim();
                string O = PO.Split('-')[1].Trim();
                string m_query_temp = @"select TA007, ISNULL(TA045,0) as TA045, ISNULL(TA046,0) as TA046,ISNULL(TA047,0) as TA047 
from MOCTA  where TA001 = @P and TA002 = @O"; // 
                string m_query_MOCTA = m_query_temp.Replace("@P", "'" + P + "'").Replace("@O", "'" + O + "'");
                DataTable dt = new DataTable();
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(m_query_MOCTA.ToString(), ref dt);
                if (dt.Rows.Count == 1)
                {
                    if (dt.Rows[0]["TA007"].ToString().ToUpper() != "KG")
                    {
                        double TA038 = double.Parse(dt.Rows[0]["TA045"].ToString());
                        double TA039 = double.Parse(dt.Rows[0]["TA046"].ToString());
                        double TA040 = double.Parse(dt.Rows[0]["TA047"].ToString());

                        if (TA039 + TA040 + SLDongGoi > TA038)
                            return false;
                        else return true;
                    }
                    else return true;

                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetWeightDemandPlan_NoStageManagement", ex.Message);
            }
            finally
            {
                conn.Close();
            }
            return false;
        }

    }
}
