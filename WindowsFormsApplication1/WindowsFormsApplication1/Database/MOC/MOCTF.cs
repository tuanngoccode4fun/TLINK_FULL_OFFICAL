using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.MOC
{
  public  class MOCTF
    {
		public static DataTable GetTop1DataTable()
		{
			DataTable dt = new DataTable();
			string querry = "select top(1) * from MOCTF ";
			SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
			sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);
			return dt;
		}
		public bool InsertData(DataTable dtdata)

		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();

				stringBuilder.Append(" insert into MOCTF ( ");
				for (int i = 0; i < dtdata.Columns.Count - 1; i++)
				{
					if (i < dtdata.Columns.Count - 2)
					{
						if (dtdata.Columns[i].ColumnName != "CFIELD01")
							stringBuilder.Append(dtdata.Columns[i].ColumnName + ",");
					}
					else stringBuilder.Append(dtdata.Columns[i].ColumnName + ") values ( ");
				}
				for (int i = 0; i < dtdata.Rows.Count; i++)
				{

					StringBuilder stringFun = new StringBuilder();
					for (int j = 0; j < dtdata.Columns.Count - 1; j++)
					{
						string valueCell = "NULL";

						if (dtdata.Rows[i][dtdata.Columns[j].ColumnName] != null)
						{

							if (dtdata.Rows[i][dtdata.Columns[j].ColumnName].GetType() == typeof(DBNull))
							{
								valueCell = "NULL";
							}
							else
								valueCell = dtdata.Rows[i][dtdata.Columns[j].ColumnName].ToString();
						}
						if (j < dtdata.Columns.Count - 2)
						{
							if (dtdata.Columns[j].ColumnName != "CFIELD01")
							{
								if (valueCell == "NULL")
									stringFun.Append(" " + valueCell + " ,");
								else stringFun.Append(" '" + valueCell + "',");
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

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "MOCTF", ex.Message);
			}
			return false;
		}
	}
}
