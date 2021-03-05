using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace WindowsFormsApplication1.Database.MOC
{
  public  class MOCTG
    {
		public static DataTable GetTop1DataTable()
		{
			DataTable dt = new DataTable();
			string querry = "select top(1) * from MOCTG ";
			SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
			sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);
			return dt;
		}
		public bool InsertData(DataTable dtdata)

		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();

				stringBuilder.Append(" insert into MOCTG ( ");
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
					SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
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

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "MOCTG", ex.Message);
			}
			return false;
		}
	}
}
