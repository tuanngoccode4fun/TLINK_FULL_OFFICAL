using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.ERPSOFT
{
    public class t_TL_Product
    {
        public void InsertProductInforToDB()
        {
            try
            {
                DataTable dtGetINMB = Database.INV.INVMB.GetProductInfor();
                DataTable dtdata = ConvertDataTable(dtGetINMB);
                var insertResult = InsertData(dtdata);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertProductInforToDB()", ex.Message);
            }



        }
        public void InsertProductInforToDBbymodel(string model)
        {
            try
            {
                DataTable dtGetINMB = Database.INV.INVMB.GetProductInforbyModel(model);
                DataTable dtdata = ConvertDataTable(dtGetINMB);
                var insertResult = InsertData(dtdata);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertProductInforToDB()", ex.Message);
            }



        }
        public DataTable GetTop1Table()
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select top(1) * from t_TL_Product ");
            sqlCON sqlCON = new sqlCON();
            sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public DataTable ConvertDataTable(DataTable dtProduct)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = GetTop1Table();
                dt.Rows.Clear();
                if (dtProduct.Rows.Count > 0)
                {
                    for (int i = 0; i < dtProduct.Rows.Count; i++)
                    {
                        var newRow = dt.NewRow();
                        dt.Rows.Add(newRow);

                    }
                }
                Database.ADMMFUpdate aDMMF = new Database.ADMMFUpdate();
                DataTable dtADMMF = aDMMF.GetDtADMFFByUser(Class.valiballecommon.GetStorage().UserName);
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    dt.Rows[i]["COMPANY"] = dtADMMF.Rows[0]["COMPANY"];
                    dt.Rows[i]["CREATOR"] = Class.valiballecommon.GetStorage().UserName;
                    dt.Rows[i]["USR_GROUP"] = dtADMMF.Rows[0]["MF004"].ToString();
                    dt.Rows[i]["CREATE_DATE"] = DateTime.Now.ToString("yyyyMMdd");
                    dt.Rows[i]["MODIFIER"] = DBNull.Value;
                    dt.Rows[i]["MODI_DATE"] = DBNull.Value;
                    dt.Rows[i]["FLAG"] = 1;
                    dt.Rows[i]["CREATE_TIME"] = DateTime.Now.ToString("HH:mm:ss");
                    dt.Rows[i]["CREATE_AP"] = "SFT";
                    dt.Rows[i]["CREATE_PRID"] = "SFT";
                    dt.Rows[i]["MODI_TIME"] = DBNull.Value;
                    dt.Rows[i]["MODI_AP"] = DBNull.Value;
                    dt.Rows[i]["MODI_PRID"] = DBNull.Value;
                    dt.Rows[i]["MB001"] = dtProduct.Rows[i]["MB001"];
                    dt.Rows[i]["MB002"] = dtProduct.Rows[i]["MB002"];
                    dt.Rows[i]["MB003"] = dtProduct.Rows[i]["MB003"];
                    dt.Rows[i]["MB004"] = DBNull.Value;
                    dt.Rows[i]["MB005"] = DBNull.Value;
                    dt.Rows[i]["MB006"] = DBNull.Value;
                    dt.Rows[i]["MB007"] = DBNull.Value;
                    dt.Rows[i]["MB008"] = DBNull.Value;
                    dt.Rows[i]["MB009"] = DBNull.Value;
                    dt.Rows[i]["MB010"] = DBNull.Value;
                    dt.Rows[i]["MB011"] = DBNull.Value;
                    dt.Rows[i]["MB012"] = DBNull.Value;
                    dt.Rows[i]["MB013"] = DBNull.Value;
                    dt.Rows[i]["MB014"] = DBNull.Value;
                    dt.Rows[i]["MB015"] = DBNull.Value;
                    dt.Rows[i]["MB016"] = DBNull.Value;
                    dt.Rows[i]["MB017"] = DBNull.Value;
                    dt.Rows[i]["MB018"] = DBNull.Value;
                    dt.Rows[i]["MB019"] = DBNull.Value;
                    dt.Rows[i]["MB020"] = DBNull.Value;
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ConvertDataTable(DataTable dtProduct)", ex.Message);
            }
            return dt;
        }

        public bool InsertData(DataTable dtdata)

        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(" insert into t_TL_Product ( ");
                for (int i = 0; i < dtdata.Columns.Count; i++)
                {
                    if (i < dtdata.Columns.Count - 1)
                        stringBuilder.Append(dtdata.Columns[i].ColumnName + ",");
                    else stringBuilder.Append(dtdata.Columns[i].ColumnName + ") values ( ");
                }
                for (int i = 0; i < dtdata.Rows.Count; i++)
                {

                    StringBuilder stringFun = new StringBuilder();
                    for (int j = 0; j < dtdata.Columns.Count; j++)
                    {
                        string valueCell = "NULL";

                        if (dtdata.Rows[i][dtdata.Columns[j].ColumnName] != null)
                        {
                            if (dtdata.Columns[j].DataType == typeof(DateTime))
                            {
                                if (dtdata.Columns[j].ColumnName == "MODI_DATE")
                                    valueCell = "NULL";
                                else
                                    valueCell = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
                            }
                            else if (dtdata.Rows[i][dtdata.Columns[j].ColumnName].GetType() == typeof(DBNull))
                            {
                                valueCell = "NULL";
                            }
                            else
                                valueCell = dtdata.Rows[i][dtdata.Columns[j].ColumnName].ToString();
                        }
                        if (j < dtdata.Columns.Count - 1)
                        {
                            if (valueCell == "NULL")
                                stringFun.Append(" " + valueCell + " ,");
                            else stringFun.Append(" '" + valueCell + "',");
                        }
                        else
                        {
                            if (valueCell == "NULL")
                                stringFun.Append(" " + valueCell + ")");
                            else stringFun.Append(" '" + valueCell + "')");

                        }
                    }
                    string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
                    sqlCON sql = new sqlCON();
                    var result = sql.sqlExecuteNonQuery(sqlInsert, false);
                    //if (result == false)
                    //{

                    //    return false;
                    //}

                }
                return true;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "SFCTC", ex.Message);
            }
            return false;
        }
        public DataTable GetdataProduct()
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select top(100) MB001, MB002, MB003, MB004, MB005, MB006, MB007, MB008, MB009, MB010, MB011, MB012, MB013 from t_TL_Product ");
            sqlCON sqlCON = new sqlCON();
            sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public DataTable GetdataProduct( string Product)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select  MB001, MB002, MB003, MB004, MB005, MB006, MB007, MB008, MB009, MB010, MB011, MB012, MB013 from t_TL_Product ");
            stringBuilder.Append(" where MB001 like '%" + Product + "%' ");
            sqlCON sqlCON = new sqlCON();
            sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public DataTable GetdataExactllyProduct(string Product)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select  MB001, MB002, MB003, MB004, MB005, MB006, MB007, MB008, MB009, MB010, MB011, MB012, MB013 from t_TL_Product ");
            stringBuilder.Append(" where MB001 like '%" + Product + "%' ");
            sqlCON sqlCON = new sqlCON();
            sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public bool DeleteRowbyProduct(string product)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" delete from t_TL_Product where 1=1 ");
                stringBuilder.Append(" and MB001 = '" + product + "' ");
                sqlCON sqlCON = new sqlCON();
                var deleteResult = sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);
               
                if (deleteResult == false)
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateProductInfor(DataTable dtRowUpdate)", "");
                    return false;
                }
                return true;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Delete 1 row of product fail", ex.Message);
            }
            return false;
        }
        public bool UpdateProductInfor(DataTable dtRowUpdate)
        {
       
                try
                {
                   
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" update t_TL_Product ");
                stringBuilder.Append(" set MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "', ");
                stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "', ");
                stringBuilder.Append("  FLAG = FLAG+1 ,  ");
                stringBuilder.Append("  MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,");
                stringBuilder.Append("  MODI_AP = '" + "" + "' ,");
                stringBuilder.Append("  MODI_PRID = '" + "" + "' ,");
                stringBuilder.Append("  MB004 = '" + dtRowUpdate.Rows[0]["MB004"] + "' ,");
                stringBuilder.Append("  MB005 = '" + dtRowUpdate.Rows[0]["MB005"] + "' ,");
                stringBuilder.Append("  MB006 = '" + dtRowUpdate.Rows[0]["MB006"] + "' ,");
                stringBuilder.Append("  MB007 = '" + dtRowUpdate.Rows[0]["MB007"] + "' ,");
                stringBuilder.Append("  MB008 = '" + dtRowUpdate.Rows[0]["MB008"] + "' ,");
                stringBuilder.Append("  MB009 = '" + dtRowUpdate.Rows[0]["MB009"] + "', ");
                stringBuilder.Append("  MB010 = '" + dtRowUpdate.Rows[0]["MB010"] + "', ");
                stringBuilder.Append("  MB011 = '" + dtRowUpdate.Rows[0]["MB011"] + "', ");
                stringBuilder.Append("  MB013 = '" + dtRowUpdate.Rows[0]["MB013"] + "' ");
                stringBuilder.Append(" where MB001 ='" + dtRowUpdate.Rows[0]["MB001"] + "' ");
               
                sqlCON sqlCON = new sqlCON();
                        var update = sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);
                        if (update == false)
                        {
                            SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateProductInfor(DataTable dtRowUpdate)", "");
                            return false;
                        }

                    
                    return true;
                }
                catch (Exception ex)
                {

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateImportWarehouse(DataTable dtOutPQC)", ex.Message);
                    return false;
                }

            
        }
        public bool UpdateDataFromExcel(DataTable dtExcel)
        {
            try
            {
                for (int i = 0; i < dtExcel.Rows.Count; i++)
                {
                    StringBuilder stringBuilder = new StringBuilder();
                    stringBuilder.Append(" update t_TL_Product ");
                    stringBuilder.Append(" set MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "', ");
                    stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "', ");
                    stringBuilder.Append("  FLAG = FLAG+1 ,  ");
                    stringBuilder.Append("  MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,");
                    stringBuilder.Append("  MODI_AP = '" + "" + "' ,");
                    stringBuilder.Append("  MODI_PRID = '" + "" + "' ,");
                    stringBuilder.Append("  MB004 = N'" + dtExcel.Rows[i]["Mieu ta"] + "' ,");
                    stringBuilder.Append("  MB005 = N'" + dtExcel.Rows[i]["SL/thung"] + "' ,");
                    stringBuilder.Append("  MB006 = N'" + dtExcel.Rows[i]["Kich thuoc Thung"] + "' ,");
                    stringBuilder.Append("  MB007 = N'" + dtExcel.Rows[i]["Khoi luong thung giay"] + "' ,");
                    stringBuilder.Append("  MB008 = N'" + dtExcel.Rows[i]["Kich thuoc Pallet"] + "' ,");
                    stringBuilder.Append("  MB009 = N'" + dtExcel.Rows[i]["Khoi luong Pallet"] + "', ");
                    stringBuilder.Append("  MB010 = N'" + dtExcel.Rows[i]["Khoi luong Nep"] + "',  ");
                    stringBuilder.Append("  MB011 = N'" + dtExcel.Rows[i]["SL Thung/Pallet"] + "', ");
                    stringBuilder.Append("  MB013 = N'" + dtExcel.Rows[i]["Quy cach Nep"] + "' ");
                    stringBuilder.Append(" where MB001 ='" + dtExcel.Rows[i]["San Pham"] + "' ");

                    sqlCON sqlCON = new sqlCON();
                    var update = sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);
                    //if (update == false)
                    //{
                    //    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Update Flag Import finished goods fail!", "");
                    //    return false;
                    //}
                }
                return true;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateDataFromExcel(DataTable dtExcel)", ex.Message);
            }
            return false;
        }
    }
}
