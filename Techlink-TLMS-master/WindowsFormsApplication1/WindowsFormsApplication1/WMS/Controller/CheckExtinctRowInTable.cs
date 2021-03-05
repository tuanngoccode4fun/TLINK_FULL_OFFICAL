using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.WMS.Controller
{
  public  class CheckExtinctRowInTable
    {
        public bool CheckExstinctRow(string producCode, string Status)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" select * from LOT ");
				stringBuilder.Append(" where 1=1 " );
				stringBuilder.Append(" and ID = '" + producCode + "' ");
				stringBuilder.Append(" and STATUS = '" + Status + "' ");
				sqlSFT sqlSFT = new sqlSFT();
				DataTable dt = new DataTable();
				sqlSFT.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
				if (dt.Rows.Count > 0)
				{
					return true;
				}
				else return false;
				
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "CheckExtinctRow(string Table, string ID, string ID2)", ex.Message);
				return false;
			}
          
        }
		public bool CheckExstinctRowSFCTA(string producCode, string TA003)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" select * from SFCTA ");
				stringBuilder.Append(" where 1=1 ");
				stringBuilder.Append(" and TA001 = '" + producCode.Split('-')[0] + "' ");
				stringBuilder.Append(" and TA002 = '" + producCode.Split('-')[1] + "' ");
				stringBuilder.Append(" and TA003 = '" + TA003 + "' ");
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

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "CheckExtinctRow(string Table, string ID, string ID2)", ex.Message);
				return false;
			}

		}
	}
}
