using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.SFT
{
  public  class SFT_LOT
    {
		public static string getProductionOrder(string Product)
		{
			DataTable dt = new DataTable();
			string productionOrder = "";
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(@" select ID from LOT where LOTSIZE > 0  and STATUS = 50
and ERP_OPSEQ ='0020' ");
			stringBuilder.Append(" and ITEMID like  '%" + Product + "%' ");

			sqlSFT sqlSFT = new sqlSFT();

			sqlSFT.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
			if (dt.Rows.Count > 0)
				productionOrder = dt.Rows[0]["ID"].ToString();
			return productionOrder;
		}
		public static DataTable GetDataTableLot(string ProductOrder)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select top(1) * from LOT where  ID ='" + ProductOrder + "' ");
            sqlSFT sqlSFT = new sqlSFT();
            sqlSFT.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;

        }
		public bool CheckExstinctRow(string producCode, string Status, string ERP_OPSEQ)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" select * from LOT ");
				stringBuilder.Append(" where 1=1 ");
				stringBuilder.Append(" and ID = '" + producCode + "' ");
				stringBuilder.Append(" and STATUS = '" + Status + "' ");
				stringBuilder.Append(" and ERP_OPSEQ ='" + ERP_OPSEQ + "' ");
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

		public bool UpdateLotforFinishedGood(DataRow dtTRansOrderLine, string Status, string ERP_OPSEQ)
		{
			try
			{

				string PO = dtTRansOrderLine["KEYID"].ToString().Trim();
				DataTable dtLot = Database.SFT.SFT_LOT.GetDataTableLot(PO);

				StringBuilder stringBuilder = new StringBuilder();

					stringBuilder.Append("update LOT set");
					if (Status == "99")
					{
						stringBuilder.Append("  LOTSIZE =LOTSIZE + " + dtTRansOrderLine["TRANSQTY"] + ", ");
					stringBuilder.Append("  PKQTY = PKQTY + "+ double.Parse(dtTRansOrderLine["TRANSQTY"].ToString()) * double.Parse(dtLot.Rows[0]["PKQTYPER"].ToString()) + " ");
					stringBuilder.Append(" where ID  ='" + dtTRansOrderLine["KEYID"] + "' and STATUS =99");
					//stringBuilder.Append(" and ERP_OPSEQ ='" + ERP_OPSEQ + "' ");
					}
					else if (Status == "130")
					{
					stringBuilder.Append("  LOTSIZE =LOTSIZE - " + dtTRansOrderLine["TRANSQTY"] + ", ");
					stringBuilder.Append("  PKQTY = PKQTY - " + double.Parse(dtTRansOrderLine["TRANSQTY"].ToString()) * double.Parse(dtLot.Rows[0]["PKQTYPER"].ToString()) + " ");
					stringBuilder.Append(" where ID  ='" + dtTRansOrderLine["KEYID"] + "' and STATUS =130");
					stringBuilder.Append(" and ERP_OPSEQ ='" + ERP_OPSEQ + "' ");
				}

					sqlSFT sqlSFT = new sqlSFT();
					var result = sqlSFT.sqlExecuteNonQuery(stringBuilder.ToString(), false);
					if (result == false)
					{

						
						return false;
					}
				
				
			 return true;

			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateLotforFinishedGood(FinishedGoodsItems fgItems, string Status)", ex.Message);
			}
			return false;
		}

	   
		public bool UpdateLotforIntoWH(DataRow dtERPPQC, string Status)
		{
			try
			{

				string PO = dtERPPQC["ProductOrder"].ToString().Trim();
				DataTable dtLot = Database.SFT.SFT_LOT.GetDataTableLot(PO);

				StringBuilder stringBuilder = new StringBuilder();

				stringBuilder.Append("update LOT set");
				if (Status == "50")
				{
					stringBuilder.Append("  LOTSIZE =LOTSIZE - " + dtERPPQC["Quantity"] + ", ");
					stringBuilder.Append("  PKQTY = PKQTY - " + double.Parse(dtERPPQC["Quantity"].ToString()) * double.Parse(dtLot.Rows[0]["PKQTYPER"].ToString()) + " ");
					stringBuilder.Append(" where ID  ='" + dtERPPQC["ProductOrder"] + "' and STATUS =50");
					stringBuilder.Append(" and ERP_OPSEQ ='" + "0020" + "' ");
				}
				else if (Status == "130")
				{
					stringBuilder.Append("  LOTSIZE =LOTSIZE + " + dtERPPQC["Quantity"] + ", ");
					stringBuilder.Append("  PKQTY = PKQTY + " + double.Parse(dtERPPQC["Quantity"].ToString()) * double.Parse(dtLot.Rows[0]["PKQTYPER"].ToString()) + " ");
					stringBuilder.Append(" where ID  ='" + dtERPPQC["ProductOrder"] + "' and STATUS = 130");
					stringBuilder.Append(" and ERP_OPSEQ ='" +"0020" + "' ");
				}

				sqlSFT sqlSFT = new sqlSFT();
				var result = sqlSFT.sqlExecuteNonQuery(stringBuilder.ToString(), false);
				if (result == false)
				{


					return false;
				}

				return true;

			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateLotforFinishedGood(FinishedGoodsItems fgItems, string Status)", ex.Message);
			}
			return false;
		}
		public bool InsertData(DataTable dtdata)

		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();

				stringBuilder.Append(" insert into LOT ( ");
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
								
									valueCell = "NULL";
							
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
					if (result == false)
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
		public bool InsertOrUpdate(DataRow dtTRansOrderLine)
		{
			string PO = dtTRansOrderLine["KEYID"].ToString();
			var Exstinct = CheckExstinctRow(PO, "99","");
			if(Exstinct)
			{
				var update1 = UpdateLotforFinishedGood(dtTRansOrderLine, "99","0020");
				var update2 = UpdateLotforFinishedGood(dtTRansOrderLine, "130","0020");
				DeleteRowIntoWarehouseEmptyStock(PO, "130");
				if ((update1 && update2) == false)
					SystemLog.Output(SystemLog.MSG_TYPE.War, "InsertLOTForFinishedGoods", "");
				else return true;
			}
			else
			{
				WMS.Controller.ConvertDataTable convertDataTable = new WMS.Controller.ConvertDataTable();
				DataTable dtLot = convertDataTable.GetDataTableLOT(dtTRansOrderLine,99);
				var insert = InsertData(dtLot);
				var update2 = UpdateLotforFinishedGood(dtTRansOrderLine, "130", "0020");
				DeleteRowIntoWarehouseEmptyStock(PO, "130");

				if ((insert )== false)
					SystemLog.Output(SystemLog.MSG_TYPE.War, "InsertLOTForFinishedGoods", "");
				return true;
			}
			return true;
		}

		public bool InsertOrUpdateIntoWH(DataTable dtERPPQC)
		{
			for (int i = 0; i < dtERPPQC.Rows.Count; i++)
			{

				string PO = dtERPPQC.Rows[i]["ProductOrder"].ToString();
				var Exstinct = CheckExstinctRow(PO, "130", "0020");
				if (Exstinct)
				{
					var update1 = UpdateLotforIntoWH(dtERPPQC.Rows[i], "50");
					var update2 = UpdateLotforIntoWH(dtERPPQC.Rows[i], "130");
					
					if ((update1 && update2) == false)
						SystemLog.Output(SystemLog.MSG_TYPE.War, "InsertLOTForFinishedGoods", "");
					
				}
				else
				{
					WMS.Controller.ConvertDataTable convertDataTable = new WMS.Controller.ConvertDataTable();
					DataTable dtLot = convertDataTable.GetDataTableLOTbyERP(dtERPPQC.Rows[i], 130);
					var insert = InsertData(dtLot);
					var update1 = UpdateLotforIntoWH(dtERPPQC.Rows[i], "50");
					if ((insert) == false)
						SystemLog.Output(SystemLog.MSG_TYPE.War, "InsertLOTForFinishedGoods", "");
				}

			}
				return true;
			
			
		}
		public  bool InsertUpdateLot(DataTable dtTRansOrderLine)
		{
			try
			{
			for (int i = 0; i < dtTRansOrderLine.Rows.Count; i++)
			{
				InsertOrUpdate(dtTRansOrderLine.Rows[i]);
			}
			}
			catch (Exception ex)
			{
				SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertUpdateLot(DataTable dtTRansOrderLine)", ex.Message);
				return false;
			}
			return true;
		}
		public static double GetPQCStock(string productionOrder)
		{
			double PQCStock = 0;
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(" select LOTSIZE from LOT where STATUS = 50 and ERP_OPSEQ = '0020' AND ERP_OPID ='B02'");
			stringBuilder.Append(" AND ID = '" + productionOrder + "' ");
			sqlSFT sqlSFT = new sqlSFT();
			string value = sqlSFT.sqlExecuteScalarString(stringBuilder.ToString());
			if (value != "")
				PQCStock = double.Parse(value);
			return PQCStock;
		}
		public void DeleteRowIntoWarehouseEmptyStock (string ID, string status )
		{
			StringBuilder builder = new StringBuilder();
			builder.Append("select DEFECTQTY from SFT_OP_REALRUN where SEQUENCE = 0 and OPID = 'B02---B01' ");
			builder.Append(" and ID = '" + ID + "' ");
			sqlSFT sFT = new sqlSFT();
			var QtyDefect = sFT.sqlExecuteScalarString(builder.ToString());
			if (double.Parse(QtyDefect) == 0) // Neu con defect thi khong duoc xoa Lot pending warehouse
			{

				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" delete from LOT where 1=1 ");
				stringBuilder.Append(" and ID = '" + ID + "' ");
				stringBuilder.Append(" and STATUS = '" + status + "' ");
				stringBuilder.Append(" and LOTSIZE = '0' ");
				
				var result = sFT.sqlExecuteNonQuery(stringBuilder.ToString(), false);
			}

		}
	}
}
