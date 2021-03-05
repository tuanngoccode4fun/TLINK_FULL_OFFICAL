using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.ERPSOFT
{
    class t_HQ_ERP_MAPPING
    {
		public static DataTable GetTop1DataTable()
		{
			DataTable dt = new DataTable();
			string querry = "select top(1) * from t_HQ_ERP_MAPING ";
			sqlCON sqlCON = new sqlCON();
			sqlCON.sqlDataAdapterFillDatatable(querry, ref dt);
			return dt;
		}
		public bool InsertData(DataTable dtdata)

		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();

				stringBuilder.Append(" insert into t_HQ_ERP_MAPING ( ");
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
								if (dtdata.Columns[dtdata.Columns[j].ColumnName].DataType == typeof(DateTime))
								{
									valueCell = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
								}
								else valueCell = dtdata.Rows[i][dtdata.Columns[j].ColumnName].ToString();
							}
						}

						if (j < dtdata.Columns.Count - 1)
						{
							if (valueCell == "NULL")
								stringFun.Append(" " + valueCell + " , ");
							else
							{ if(dtdata.Columns[j].ColumnName.ToString().Contains("TEN_SP"))
								{
									stringFun.Append(" N'" + valueCell + "', ");
								}
								else stringFun.Append(" '" + valueCell + "', ");
							}
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
					//if (result == false)
					//{

					//	return false;
					//}

				}
				return true;
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "insert into t_ExportFGoods", ex.Message);
			}
			return false;
		}

		public DataTable ConvertHQdataToERPMAPPING(DataTable dtHQ)
		{
			DataTable dt = new DataTable();
			dt = GetTop1DataTable();
			dt.Rows.Clear();
			for (int i = 0; i < dtHQ.Rows.Count; i++)
			{
				var newRow = dt.NewRow();
				dt.Rows.Add(newRow);
			}
			for (int i = 0; i < dt.Rows.Count; i++)
			{
				dt.Rows[i]["SPID"] = dtHQ.Rows[i]["SPID"];
				dt.Rows[i]["MA_HQ"] = dtHQ.Rows[i]["MA_HQ"];
				dt.Rows[i]["MA_DV"] = dtHQ.Rows[i]["MA_DV"];
				dt.Rows[i]["MA_SP"] = dtHQ.Rows[i]["MA_SP"];
				dt.Rows[i]["TEN_SP"] = dtHQ.Rows[i]["TEN_SP"];
				dt.Rows[i]["TEN_SP1"] = dtHQ.Rows[i]["TEN_SP1"];
				dt.Rows[i]["MA_HS"] = dtHQ.Rows[i]["MA_HS"];
				dt.Rows[i]["MA_DVT"] = dtHQ.Rows[i]["MA_DVT"];
				dt.Rows[i]["MA_SP_ERP"] = dtHQ.Rows[i]["MA_SP"].ToString().Substring(3);

			}
			return dt;
		}
		public bool UploadProductCodebyCustomsDB()
		{
			CustomsDeclar.GetBOMCustoms getBOMCustoms = new CustomsDeclar.GetBOMCustoms();
			DataTable dtHQ = getBOMCustoms.LayMaSpHQNam20();
			DataTable dtget = ConvertHQdataToERPMAPPING(dtHQ);
			var insertResult = InsertData(dtget);
			return insertResult;
		}
		public DataTable GetDataTableFromHQ_ERP_MAPPING()
		{
			StringBuilder stringBuilder = new StringBuilder();
			DataTable dt = new DataTable();
			stringBuilder.Append(" select top(100) * from t_HQ_ERP_MAPING ");
			sqlCON sqlCON = new sqlCON();
			sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
			return dt;
		}
		public DataTable GetAllDataTableFromHQ_ERP_MAPPING()
		{
			StringBuilder stringBuilder = new StringBuilder();
			DataTable dt = new DataTable();
			stringBuilder.Append(" select  * from t_HQ_ERP_MAPING ");
			sqlCON sqlCON = new sqlCON();
			sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
			return dt;
		}
		public DataTable GetDataTableFromHQ_ERP_MAPPINGbyproductSearch(string maSP)
		{
			StringBuilder stringBuilder = new StringBuilder();
			DataTable dt = new DataTable();
			stringBuilder.Append(" select  * from t_HQ_ERP_MAPING where 1=1 ");
			stringBuilder.Append(" and MA_SP like '%" + maSP + "%' ");
			sqlCON sqlCON = new sqlCON();
			sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
			return dt;
		}

	}
}
