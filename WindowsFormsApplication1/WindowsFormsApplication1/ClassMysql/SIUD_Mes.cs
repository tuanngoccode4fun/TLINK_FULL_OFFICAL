
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using TLMSMESGETDATA.SQLUpload;

namespace WindowsFormsApplication1.ClassMysql
{
    class SIUD_Mes
    {

        public static DataTable GetFormatTableMySQL(DataTable ImportFSWareHouse)
        {
            DataRow rowtemp;
            MysqlMES mysqlMES = new MysqlMES();
            DataTable Temp = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("SHOW COLUMNS FROM t_importfg_warehouse");
            mysqlMES.sqlDataAdapterFillDatatable(stringBuilder.ToString(),ref Temp);
            DataTable returndt = new DataTable();
            DataRow toInsert = returndt.NewRow();
            returndt.Rows.Add(toInsert);
            foreach (DataRow item in Temp.Rows)
            {
                DataColumn dc = new DataColumn(item.ItemArray[0].ToString());
                returndt.Columns.Add(dc);
            }
            for (int k = 0; k < ImportFSWareHouse.Rows.Count; k++)
            {
                if (k!=0)
                {
                    rowtemp = returndt.NewRow();
                    returndt.Rows.Add(rowtemp);
                }
                returndt.Rows[k]["TransactionID"] = ImportFSWareHouse.Rows[k]["TransactionID"];
                returndt.Rows[k]["STT"]           = ImportFSWareHouse.Rows[k]["STT"];
                returndt.Rows[k]["UserID"]        = ImportFSWareHouse.Rows[k]["UserID"];
                returndt.Rows[k]["ProductOrder"]  = ImportFSWareHouse.Rows[k]["ProductOrder"];
                returndt.Rows[k]["Product"]       = ImportFSWareHouse.Rows[k]["Product"];
                returndt.Rows[k]["Quantity"]      = ImportFSWareHouse.Rows[k]["Quantity"];
                returndt.Rows[k]["LotNo"]         = ImportFSWareHouse.Rows[k]["LotNo"];
                returndt.Rows[k]["Warehouse"]     = ImportFSWareHouse.Rows[k]["Warehouse"];
                returndt.Rows[k]["dateImport"]    = Convert.ToDateTime( ImportFSWareHouse.Rows[k]["dateImport"]).ToString("yyyy-MM-dd HH-mm-ss");
                returndt.Rows[k]["ImportFlag"]    = "Y";
                returndt.Rows[k]["dateCreate"] = Convert.ToDateTime(ImportFSWareHouse.Rows[k]["dateImport"]).ToString("yyyy-MM-dd HH-mm-ss");
                returndt.Rows[k]["SubQR"] = ImportFSWareHouse.Rows[k]["Product"]+"-"+DateTime.Now.ToString("yyyyy");
                //returndt.Rows[k]["TransactionID"] = ImportFSWareHouse.Rows[k]["TransactionID"];

            }
            return returndt;
        }
        public static bool Insert(DataTable ImportFSWareHouse)
        {
            try
            {
                StringBuilder stringbuider = new StringBuilder();
                stringbuider.Append("insert into t_importfg_warehouse (");
                DataTable DtForInsert = GetFormatTableMySQL(ImportFSWareHouse);
                // List<string> ListHeader = GetFormatTableMySQL().AsEnumerable().Select(x => x[0].ToString()).ToList();
                for (int i = 0; i < DtForInsert.Columns.Count; i++)
                {
                    if (i < DtForInsert.Columns.Count - 1)
                        stringbuider.Append(DtForInsert.Columns[i].ColumnName + ",");
                    else stringbuider.Append(DtForInsert.Columns[i].ColumnName + ") values ( ");
                }
                for (int i = 0; i < DtForInsert.Rows.Count; i++)
                {

                    StringBuilder stringFun = new StringBuilder();
                    for (int j = 0; j < DtForInsert.Columns.Count; j++)
                    {
                        string valueCell = "NULL";

                        if (DtForInsert.Rows[i][DtForInsert.Columns[j].ColumnName] != null)
                        {
                            string tt = DtForInsert.Rows[i][DtForInsert.Columns[j].ColumnName].ToString();
                            if (DtForInsert.Columns[j].DataType == typeof(DateTime))
                            {
                                if (DtForInsert.Columns[j].ColumnName == "MODI_DATE")
                                    valueCell = "NULL";
                                else
                                    valueCell = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                            }
                            else if (DtForInsert.Rows[i][DtForInsert.Columns[j].ColumnName].GetType() == typeof(DBNull))
                            {
                                valueCell = "NULL";
                            }
                            else
                                valueCell = DtForInsert.Rows[i][DtForInsert.Columns[j].ColumnName].ToString();
                        }
                        if (j < DtForInsert.Columns.Count - 1)
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
                    string sqlInsert = stringbuider.ToString() + stringFun.ToString();
                    MysqlMES sqlTLVN2 = new MysqlMES();
                    var result = sqlTLVN2.sqlExecuteNonQuery(sqlInsert, false);
                    if (result == false)
                    {

                        return false;
                    }

                }
                return true;
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Insert(DataTable ImportFSWareHouse)", ex.Message);
            }
            return false;
        }
    }
}
