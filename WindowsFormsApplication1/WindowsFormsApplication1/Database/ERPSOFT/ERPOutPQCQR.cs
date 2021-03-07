using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.ERPSOFT
{
  public  class ERPOutPQCQR
    {
        public bool InsertERPOutPQC(WMS.Model.PQCOutStock pQCOutStock)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" insert into t_ERP_OutPQCQR (KeyID,KeyNo,STT,ProductOrder ,Product, Quantity, LotNo, Warehouse, dateCreate, TL111, SubQR) values (");
				stringBuilder.Append(" '" + pQCOutStock.KeyID + "', ");
				stringBuilder.Append(" '" + pQCOutStock.KeyNo + "', ");
				stringBuilder.Append(" '" + pQCOutStock.STT + "', ");
				stringBuilder.Append(" '" + pQCOutStock.ProductOrder + "', ");
				stringBuilder.Append(" '" + pQCOutStock.Product + "', ");
				stringBuilder.Append(" '" + pQCOutStock.Quantity + "', ");
				stringBuilder.Append(" '" + pQCOutStock.LotNo + "', ");
				stringBuilder.Append(" '" + pQCOutStock.Warehouse + "', ");
				stringBuilder.Append(" " + "GETDATE()" + ", ");
				stringBuilder.Append(" '" + Class.valiballecommon.GetStorage().DBERP + "', ");
				stringBuilder.Append(" '" + pQCOutStock.QRcodeGenarate + "') ");
				sqlCON sqlCON = new sqlCON();
			return	sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);

			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertERPOutPQC(WMS.Model.PQCOutStock pQCOutStock)", ex.Message);
					
			}
            return false;
        }
		public static string GetKeyNo(DateTime dt)
		{
			string keyNo = "";
			string dateFormat = dt.ToString("yyMM");
			string countFormatReset = "0001";

			sqlCON sqlCON = new sqlCON();
			var strData = sqlCON.sqlExecuteScalarString("SELECT MAX(KeyNo)+1 from t_ERP_OutPQCQR where KeyID ='" + "TL01" + "' and KeyNo like '" + dateFormat + "%'");
			if (strData == "" || strData == String.Empty || strData == null)
				keyNo = dateFormat + countFormatReset;
			else keyNo = strData;
			return keyNo;
		}
		public DataTable GetDataTableImportFinishedGoods(string KeyCode)
		{
			DataTable dt = new DataTable();
			try
			{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" select * from t_ERP_OutPQCQR where 1=1 ");
			stringBuilder.Append(" and KeyID = '" + KeyCode.Split('-')[0] + "' ");
			stringBuilder.Append(" and KeyNo = '" + KeyCode.Split('-')[1] + "' ");
			sqlCON sqlCON = new sqlCON();
			sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "get data from QR code", ex.Message);
			}
			return dt;
		}

		public bool UpdateImportWarehouse(DataTable dtOutPQC, string ERPCode)
		{
			try
			{
				for (int i = 0; i < dtOutPQC.Rows.Count; i++)
				{
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.Append(" update t_ERP_OutPQCQR ");
					stringBuilder.Append(" set ImportFlag = '" +"Y" + "', ");
					stringBuilder.Append(" TL112 = '" + Class.valiballecommon.GetStorage().DBERP + "', ");
					stringBuilder.Append(" TL113 = '" + ERPCode + "', ");
					stringBuilder.Append(" dateImport = '" + DateTime.Now.ToString("yyyyMMdd HH:mm:ss") + "' ");
					stringBuilder.Append(" where KeyID ='" + dtOutPQC.Rows[i]["KeyID"].ToString() + "' ");
					stringBuilder.Append(" and KeyNo ='" + dtOutPQC.Rows[i]["KeyNo"].ToString() + "' ");
					stringBuilder.Append(" and STT ='" + dtOutPQC.Rows[i]["STT"].ToString() + "' ");
					sqlCON sqlCON = new sqlCON();
					var update = sqlCON.sqlExecuteNonQuery(stringBuilder.ToString(), false);
					if(update == false)
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
		public DataTable GetDataTableImportSummary(DateTime dtFrom, DateTime dtTo, bool rd_importdate)
		{
			DataTable dt = new DataTable();
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" select * from t_ERP_OutPQCQR where 1=1 ");
				if (rd_importdate == false)
				{
					stringBuilder.Append(" and dateCreate >= '" + dtFrom.ToString("yyyyMMdd") + "' ");
					stringBuilder.Append(" and dateCreate <= '" + dtTo.AddDays(1).ToString("yyyyMMdd") + "' ");
				}
				else
				{
					stringBuilder.Append(" and dateImport >= '" + dtFrom.ToString("yyyyMMdd") + "' ");
					stringBuilder.Append(" and dateImport <= '" + dtTo.AddDays(1).ToString("yyyyMMdd") + "' ");
				}
				stringBuilder.Append(" and TL111 = '" +Class.valiballecommon.GetStorage().DBERP + "' ");
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
