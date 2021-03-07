using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.INV
{
 public   class INVMC
    {
		public static bool IsStockAvaiable(string product, string warehouse, double Quantity)
		{
			try
			{


				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" select * from INVMC ");
				stringBuilder.Append(" where 1=1 ");
				stringBuilder.Append(" and MC001 = '" + product + "' ");
				stringBuilder.Append(" and MC002 = '" + warehouse + "' ");
				stringBuilder.Append(" and MC007 >= " + Quantity);


				SqlTLVN2 sqlTLVN2 = new SqlTLVN2();

				DataTable dt = new DataTable();
				sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
				if (dt.Rows.Count > 0)
				{
					return true;
				}
				else return false;
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "IsStockAvaiable(string product, string warehouse, string location, string lot, double Quantity )", ex.Message);
			}
			return false;

		}
	}
}
