using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.ERPSOFT
{
   public class t_ExportFGoods
    {
		public static DataTable GetTop1DataTable()
		{
			DataTable dt = new DataTable();
			string querry = "select top(1) * from t_ExportFGoods ";
			sqlCON sqlCON = new sqlCON();
			sqlCON.sqlDataAdapterFillDatatable(querry, ref dt);
			return dt;
		}
		public bool InsertData(DataTable dtdata)

		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();

				stringBuilder.Append(" insert into t_ExportFGoods ( ");
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

							if (dtdata.Rows[i][dtdata.Columns[j].ColumnName].GetType() == typeof(DBNull))
							{
								valueCell = "NULL";
							}
							else
							{
								if(dtdata.Columns[dtdata.Columns[j].ColumnName].DataType == typeof(DateTime))
									{
									valueCell = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
								}
								else valueCell = dtdata.Rows[i][dtdata.Columns[j].ColumnName].ToString();
							}
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
					sqlCON sqlCON = new sqlCON();
					var result = sqlCON.sqlExecuteNonQuery(sqlInsert, false);
					if (result == false)
					{

						return false;
					}

				}
				return true;
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "insert into t_ExportFGoods", ex.Message);
			}
			return false;
		}
		public bool UpdateExportWarehouse(DataTable dtExport, string ERPCode)
		{
			try
			{
				for (int i = 0; i < dtExport.Rows.Count; i++)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append(" update t_ExportFGoods ");
					stringBuilder.Append(" set ExportFlag = '" + "Y" + "', ");
					stringBuilder.Append("  TL212 = '" + Class.valiballecommon.GetStorage().DBERP + "', ");
					stringBuilder.Append("  TL213 = '" + ERPCode + "', ");
					stringBuilder.Append(" dateExport = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' ");
					stringBuilder.Append(" where KeyID ='" + dtExport.Rows[i]["KeyID"].ToString() + "' ");
					stringBuilder.Append(" and KeyNo ='" + dtExport.Rows[i]["KeyNo"].ToString() + "' ");
					stringBuilder.Append(" and STT ='" + dtExport.Rows[i]["STT"].ToString() + "' ");
					sqlCON sqlCON = new sqlCON();
					var update = sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);
					if (update == false)
					{
						SystemLog.Output(SystemLog.MSG_TYPE.Err, "Update Flag Import finished goods fail!", "");
						return false;
					}

				}
				return true;
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateImportWarehouse(DataTable dtOutPQC)", ex.Message);
				return false;
			}

		}
		public static string GetKeyNo(DateTime dt)
		{
			string keyNo = "";
			string dateFormat = dt.ToString("yyMM");
			string countFormatReset = "0001";

			sqlCON sqlCON = new sqlCON();
			var strData = sqlCON.sqlExecuteScalarString("SELECT MAX(KeyNo)+1 from t_ExportFGoods where KeyID ='" + "TL02" + "' and KeyNo like '" + dateFormat + "%'");
			if (strData == "" || strData == String.Empty || strData == null)
				keyNo = dateFormat + countFormatReset;
			else keyNo = strData;
			return keyNo;
		}
		public DataTable GetDataTableExportFinishedGoods(string KeyCode)
		{
			DataTable dt = new DataTable();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" select * from t_ExportFGoods where 1=1   ");
			stringBuilder.Append(" and KeyID = '" + KeyCode.Split('-')[0] + "' ");
			stringBuilder.Append(" and KeyNo = '" + KeyCode.Split('-')[1] + "' ");
			sqlCON sqlCON = new sqlCON();
			sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
			return dt;
		}
		public DataTable GetDataTableExportFinishedGoodsShipped(string KeyCode)
		{
			DataTable dt = new DataTable();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" select * from t_ExportFGoods where 1=1 and ExportFlag ='Y'  ");
			stringBuilder.Append(" and KeyID = '" + KeyCode.Split('-')[0] + "' ");
			stringBuilder.Append(" and KeyNo = '" + KeyCode.Split('-')[1] + "' ");
			sqlCON sqlCON = new sqlCON();
			sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
			return dt;
		}
		public DataTable GetDataTableExportSummary(DateTime dtFrom, DateTime dtTo, bool rd_importdate)
		{
			DataTable dt = new DataTable();
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" select * from t_ExportFGoods where 1=1 ");
				if (rd_importdate == false)
				{
					stringBuilder.Append(" and dateCreate >= '" + dtFrom.ToString("yyyyMMdd") + "' ");
					stringBuilder.Append(" and dateCreate <= '" + dtTo.AddDays(1).ToString("yyyyMMdd") + "' ");
				}
				else
				{
					stringBuilder.Append(" and dateExport >= '" + dtFrom.ToString("yyyyMMdd") + "' ");
					stringBuilder.Append(" and dateExport <= '" + dtTo.AddDays(1).ToString("yyyyMMdd") + "' ");
				}
				stringBuilder.Append(" and TL211 = '" + Class.valiballecommon.GetStorage().DBERP + "' ");
				sqlCON sqlCON = new sqlCON();
				sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);


			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, " GetDataTableImportSummary(DateTime dtFrom, DateTime dtTo)", ex.Message);
			}
			return dt;
		}
	}
}
