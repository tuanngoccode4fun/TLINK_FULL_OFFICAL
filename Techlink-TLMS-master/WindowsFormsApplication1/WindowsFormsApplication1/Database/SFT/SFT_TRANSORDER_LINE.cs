using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.SFT
{
  public  class SFT_TRANSORDER_LINE
    {
        public DataTable GetTop1DataTable()
        {
            DataTable dt = new DataTable();
            string querry = "select top(1) * from SFT_TRANSORDER_LINE ";
            sqlSFT sqlSFT = new sqlSFT();
            sqlSFT.sqlDataAdapterFillDatatable(querry, ref dt);
            return dt;
        }
		public bool InsertData(DataTable dtdata)

		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				
				stringBuilder.Append(" insert into SFT_TRANSORDER_LINE ( ");
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
							{if (dtdata.Columns[j].ColumnName == "MODI_DATE")
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
						sqlSFT sqlSFT = new sqlSFT();
					var result = sqlSFT.sqlExecuteNonQuery(sqlInsert, false);
					if(result ==false)
						{
							
							return false;
						}
					
				}
				return true;
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "SFT_TRANSORDER_LINE", ex.Message);
			}
			return false;
		}
		
	}
}
