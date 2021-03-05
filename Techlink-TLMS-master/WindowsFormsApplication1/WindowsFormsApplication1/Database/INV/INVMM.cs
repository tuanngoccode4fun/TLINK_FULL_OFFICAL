using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace WindowsFormsApplication1.Database.INV
{
  public  class INVMM
    {
        public static bool IsExistModelLot(string warehouse,string product, string lot  )
        {
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" select * from INVMM ");
				stringBuilder.Append(" where 1=1 ");
				stringBuilder.Append(" and MM001 = '" + product + "' ");
				stringBuilder.Append(" and MM002 = '" + warehouse + "' ");
				stringBuilder.Append(" and MM004 = '" + lot + "' ");

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

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "CheckExistINVMM(Model.INVItems iNVItems)", ex.Message);
				return false;
			}
		}

		public static bool IsStockAvaiable(string product, string warehouse, string location, string lot, double Quantity )
		{
			try
			{

			
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" select * from INVMM ");
			stringBuilder.Append(" where 1=1 ");
			stringBuilder.Append(" and MM001 = '" + product + "' ");
			stringBuilder.Append(" and MM002 = '" + warehouse + "' ");
			stringBuilder.Append(" and MM003 = '" + location + "' ");
			stringBuilder.Append(" and MM004 = '" + lot + "' ");
			stringBuilder.Append(" and MM005 >= " + Quantity);


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

