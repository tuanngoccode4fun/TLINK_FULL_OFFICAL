using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.SFT
{
   public class SFT_OP_REALRUN
    {
        public static DataTable GetDataTableSFT_OP_REALRUN()
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select top(1) * from SFT_OP_REALRUN ");
            sqlSFT sqlSFT = new sqlSFT();
            sqlSFT.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public static int GetSequenceInSFT_OP_REALRUN(string ID, string ERP_OPSEQ, string ERP_OPID,string ERP_WSID)
        {
            string sequence = "";
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select MAX(SEQUENCE)+1 from SFT_OP_REALRUN where 1=1 ");
            stringBuilder.Append("and ERP_OPSEQ ='" + ERP_OPSEQ + "' ");
            stringBuilder.Append("and ERP_OPID ='" + ERP_OPID + "' ");
            stringBuilder.Append("and ERP_WSID ='" + ERP_WSID + "' ");
            stringBuilder.Append("and ID ='" + ID + "' ");
            sqlSFT sqlSFT = new sqlSFT();
            sequence = sqlSFT.sqlExecuteScalarString(stringBuilder.ToString());
            if (sequence == String.Empty || sequence == "")
            {
                sequence = "1";
                return 1;
            }
            return int.Parse(sequence);
        }
		public bool InsertData(DataTable dtdata)

		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();

				stringBuilder.Append(" insert into SFT_OP_REALRUN ( ");
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
								if (dtdata.Columns[j].ColumnName == "OUTTIME")
									valueCell = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
								else valueCell = "NULL";

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

		public bool UpdateOPREALRUN(string ID, string ERP_OPSEQ, string ERP_OPID, string ERP_WSID, DataRow dtERPPQC)
		{
			try
			{
			string PO = dtERPPQC["ProductOrder"].ToString();
			DataTable dtLot = Database.SFT.SFT_LOT.GetDataTableLot(PO);
			StringBuilder stringBuilder = new StringBuilder();

			stringBuilder.Append("update SFT_OP_REALRUN set ");
			stringBuilder.Append(" OUTQTY = OUTQTY +" + dtERPPQC["Quantity"] + ", ");
			stringBuilder.Append(" PKQTY = PKQTY +" + double.Parse(dtERPPQC["Quantity"].ToString()) * double.Parse(dtLot.Rows[0]["PKQTYPER"].ToString()) + ", ");
			stringBuilder.Append(" OR023 = OR023 -" + double.Parse(dtERPPQC["Quantity"].ToString()) * double.Parse(dtLot.Rows[0]["PKQTYPER"].ToString()) + ", ");
			stringBuilder.Append(" OUTTIME = '"+ DateTime.Now.ToString("yyyyMMdd HH:mm:ss")+ "' ");
			stringBuilder.Append(" where ID ='" + ID + "' ");
			stringBuilder.Append(" and ERP_OPSEQ ='" + ERP_OPSEQ + "' ");
			stringBuilder.Append(" and ERP_OPID ='" + ERP_OPID + "' ");
			stringBuilder.Append(" and ERP_WSID ='" + ERP_WSID + "' ");
			stringBuilder.Append(" and SEQUENCE ='" + 0 + "' ");
			sqlSFT sqlSFT = new sqlSFT();
		var update =	sqlSFT.sqlExecuteNonQuery(stringBuilder.ToString(), false);
			if(update == false)
			{
				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateOPREALRUN", "False");
				return false;
			}
			else return true;

			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateOPREALRUN", ex.Message);
			}

			return false;
		}
		public bool CheckExstinctRow(string ID,  string ERP_OPSEQ, string ERP_OPID, string ERP_WSID)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" select * from SFT_OP_REALRUN ");
				stringBuilder.Append(" where 1=1 ");
				stringBuilder.Append(" and ID ='" + ID + "' ");
				stringBuilder.Append(" and ERP_OPSEQ ='" + ERP_OPSEQ + "' ");
				stringBuilder.Append(" and ERP_OPID ='" + ERP_OPID + "' ");
				stringBuilder.Append(" and ERP_WSID ='" + ERP_WSID + "' ");
				stringBuilder.Append(" and REPORTSTOCKIN ='" + 1 + "' ");
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
		public bool UpdateOrInsert(DataTable dtERPPQC, int [] WS_Sequence)
		{
			try
			{
				for (int i = 0; i < dtERPPQC.Rows.Count; i++)
				{
					//if(CheckExstinctRow(dtERPPQC.Rows[i]["ProductOrder"].ToString(),"0020","B02","B01"))
					//{
					//	var update = UpdateOPREALRUN(dtERPPQC.Rows[i]["ProductOrder"].ToString(), "0020", "B02", "B01", dtERPPQC.Rows[i]);
					//}
					//else
					{
						WMS.Controller.ConvertDataTable convertDataTable = new WMS.Controller.ConvertDataTable();
						DataTable dtREALRUN = convertDataTable.ConvertToREALRUN(dtERPPQC.Rows[i], WS_Sequence[i]);
						var insert = InsertData(dtREALRUN);
						var update = UpdateOPREALRUN(dtERPPQC.Rows[i]["ProductOrder"].ToString(), "0020", "B02", "B01", dtERPPQC.Rows[i]);

					}
				}
				return true;
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateOrInsert(DataTable dtERPPQC)", ex.Message);
				return false;
			}
			
		}
	}
}
