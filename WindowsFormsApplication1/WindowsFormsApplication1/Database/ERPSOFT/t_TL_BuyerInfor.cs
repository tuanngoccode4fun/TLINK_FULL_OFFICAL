using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.ERPSOFT
{
  public  class t_TL_BuyerInfor
    {
        public DataTable GetTop1Table()
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select top(1) * from t_TL_BuyerInfo ");
            sqlCON sqlCON = new sqlCON();
            sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public DataTable ConvertDataInsert(string buyerCode, string buyer_ERP, string buyer_Info, string buyer_Consignee)
        {
            DataTable dt = new DataTable();

             dt = GetTop1Table();
            dt.Rows.Clear();
           var newrow  = dt.NewRow();
            dt.Rows.Add(newrow);
            dt.Rows[0]["BuyerCode"] = buyerCode;
            dt.Rows[0]["Buyer_ERP"] = buyer_ERP;
            dt.Rows[0]["Buyer_Infor"] = buyer_Info;
            dt.Rows[0]["Buyer_Consignee"] = buyer_Consignee;

            return dt;
        }
        public bool InsertRowTableBuyerInfor(string buyerCode, string buyer_ERP, string buyer_Info, string buyer_Consignee)
        {

            DataTable dtdata = ConvertDataInsert(buyerCode, buyer_ERP, buyer_Info, buyer_Consignee);
            var insertResult = InsertData(dtdata);

            return insertResult;
        }
        public bool InsertData(DataTable dtdata)

        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(" insert into t_TL_BuyerInfo ( ");
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
                                if (dtdata.Columns[j].ColumnName == "Date_Update")
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

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "insert data t_TL_BuyerInfor", ex.Message);
            }
            return false;
        }
        public DataTable GetAllDataTable()
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select  * from t_TL_BuyerInfo ");
            sqlCON sqlCON = new sqlCON();
            sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public DataTable GetdatabyTextSearch(string textSearch)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select  * from t_TL_BuyerInfo where 1=1 ");
            stringBuilder.Append(" and  BuyerCode like '%"+ textSearch +"%'" );

            sqlCON sqlCON = new sqlCON();
            sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public bool UpdateBuyerInfor(DataTable dtRowUpdate)
        {
            try
            {

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" update t_TL_BuyerInfo ");
                stringBuilder.Append(" set Buyer_ERP = '" + dtRowUpdate.Rows[0]["Buyer_ERP"] + "' , ");
                stringBuilder.Append(" Buyer_Infor = '" + dtRowUpdate.Rows[0]["Buyer_Infor"] + "' , ");
                stringBuilder.Append(" Buyer_Consignee = '" + dtRowUpdate.Rows[0]["Buyer_Consignee"] + "', ");
                stringBuilder.Append(" Date_Update = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' ");
                stringBuilder.Append(" where BuyerCode = '" + dtRowUpdate.Rows[0]["BuyerCode"] + "' ");

                sqlCON sqlCON = new sqlCON();
                var update = sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);
                if (update == false)
                {
                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateBuyerInfor(DataTable dtRowUpdate)", "false");
                    return false;
                }
                return true;

                }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateBuyerInfor(DataTable dtRowUpdate)", ex.Message);
                return false;

            }

        }
        public bool DeleteRowbyBuyer(string buyer)
        {
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" delete from t_TL_BuyerInfo where 1=1 ");
                stringBuilder.Append(" and BuyerCode = '" + buyer + "' ");
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

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Delete 1 row of buyer table fail", ex.Message);
            }
            return false;
        }
    }
}
