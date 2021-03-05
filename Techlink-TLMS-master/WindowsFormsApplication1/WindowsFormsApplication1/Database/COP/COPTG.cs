using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace WindowsFormsApplication1.Database
{
  public  class COPTG
    {
        public static string KeyCOPTGTH(DateTime dt, string TG001)
        {
            string keyTG002 = "";
            string dateFormat = dt.ToString("yyMM");
            string countFormatReset = "0001";

            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            var strData = sqlTLVN2.sqlExecuteScalarString("SELECT MAX(TG002)+1 from COPTG where TG001 ='" + TG001 +"' and TG002 like '" + dateFormat + "%'");
            if (strData == "" || strData == String.Empty || strData == null)
                keyTG002 = dateFormat + countFormatReset;
            else keyTG002 = strData;
            return keyTG002;
        }
        public static DataTable GetdtTop1COPTG()
        {
            DataTable dt = new DataTable();
            string querry = " select top(1) * from COPTG ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);
            return dt;
        }
		public bool InsertData(DataTable dtdata)

		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();

				stringBuilder.Append(" insert into COPTG ( ");
				for (int i = 0; i < dtdata.Columns.Count; i++)
				{
					if (i < dtdata.Columns.Count - 1)
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

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "COPTG", ex.Message);
			}
			return false;
		}
	}
}
