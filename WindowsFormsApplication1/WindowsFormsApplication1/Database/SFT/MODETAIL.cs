using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.SFT
{
  public  class MODETAIL
    {
        public static DataTable GetDataTable(string ProductOrder)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select top(1) * from MODETAIL where CMOID ='" + ProductOrder + "' ");
            sqlSFT sqlSFT = new sqlSFT();
            sqlSFT.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;

        }
		public bool UpdateMODETAIL(DataTable dtTRansOrderLine)
		{
			try
			{
				for (int i = 0; i < dtTRansOrderLine.Rows.Count; i++)
				{
					string PO = dtTRansOrderLine.Rows[i]["KEYID"].ToString();
					DataTable dtLot = Database.SFT.SFT_LOT.GetDataTableLot(PO);
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append(" update MODETAIL ");
					stringBuilder.Append(" set LASTMAINTAINDATETIME = GETDATE() , ");
					stringBuilder.Append("  MO009 = MO009 +" + dtTRansOrderLine.Rows[i]["TRANSQTY"] + ", ");
					stringBuilder.Append("  MO033 = '" +DateTime.Now.ToString("yyyyMMdd") + "' , ");
					stringBuilder.Append("  MO027 = MO027 + " +double.Parse( dtTRansOrderLine.Rows[i]["TRANSQTY"].ToString()) * double.Parse(dtLot.Rows[0]["PKQTYPER"].ToString()) + " ");
					stringBuilder.Append("where CMOID ='" + dtTRansOrderLine.Rows[i]["KEYID"] + "' ");
					sqlSFT sqlSFT = new sqlSFT();
					var result = sqlSFT.sqlExecuteNonQuery(stringBuilder.ToString(), false);
					if (result == false)
					{

						return false;
					}
					
				}
				return true;
			

			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateMODETAIL(FinishedGoodsItems fgItems)", ex.Message);
			}
			return false;
		}
	}
}
