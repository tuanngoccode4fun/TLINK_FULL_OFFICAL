using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database
{
  public  class INVMEUpdate
    {
        public DataTable GetDtTop1INVME()
        {
            DataTable dt = new DataTable();
            string querry = " select top(1) * from INVME ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);
            return dt;
        }
		public bool CheckExistINVME(Model.INVItems iNVItems)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" select * from INVME ");
				stringBuilder.Append(" where 1=1 ");
				stringBuilder.Append(" and ME001 = '" + iNVItems.Product + "' ");
				stringBuilder.Append(" and ME002 = '" + iNVItems.Lot + "' ");
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
		public bool UpdateINVME(Model.INVItems iNVItems, DataTable dtCommonERP)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" update INVME ");
				stringBuilder.Append(" set MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "', ");
				stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "', ");
				stringBuilder.Append("  FLAG = FLAG+1 ,  ");
				stringBuilder.Append("  MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,");
				stringBuilder.Append("  MODI_AP = '" + "SFT" + "' ,");
				stringBuilder.Append("  MODI_PRID = '" + "MOCI05" + "' ");

				stringBuilder.Append(" where ME001 ='" + iNVItems.Product + "' ");
				stringBuilder.Append(" and ME002 ='" + iNVItems.Lot + "' ");


				SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
				var result = sqlTLVN2.sqlExecuteNonQuery(stringBuilder.ToString(), false);
				if (result == false)
				{
					SystemLog.Output(SystemLog.MSG_TYPE.War, "UpdateSFCTAForFinishedGoods(FinishedGoodsItems fgItems)", "");
					return false;
				}
				else return true;

			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateSFCTAForFinishedGoods(FinishedGoodsItems fgItems, string TA003)", ex.Message);
			}
			return false;
		}
		public bool InsertOrUpdate(Model.INVItems iNVItems, DataTable dtCommonERP)
		{
			if(CheckExistINVME(iNVItems))
			{
			var update =	UpdateINVME(iNVItems, dtCommonERP);
				return update;
			}
			else
			{
				var insert = InsertINVME(iNVItems, dtCommonERP);
				return insert;
			}
		}
		public bool InsertINVME(Model.INVItems iNVItems, DataTable dtCommonERP)
		{
			try
			{
				DataTable dtHeader = GetDtTop1INVME();
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringFun = new StringBuilder();
				stringBuilder.Append(" insert into INVME ( ");
				for (int i = 0; i < dtHeader.Columns.Count; i++)
				{
					if (i < dtHeader.Columns.Count - 1)
						stringBuilder.Append(dtHeader.Columns[i].ColumnName + ",");
					else stringBuilder.Append(dtHeader.Columns[i].ColumnName + ") values ( ");
				}
				if (dtHeader != null && dtHeader.Rows.Count == 1)
				{
					for (int j = 0; j < dtHeader.Columns.Count; j++)
					{
						string valueCell = "NULL";
						if (dtHeader.Columns[j].ColumnName == "COMPANY")
						{
							valueCell = dtCommonERP.Rows[0]["COMPANY"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "CREATOR")
						{
							valueCell = Class.valiballecommon.GetStorage().UserName;
						}
						else if (dtHeader.Columns[j].ColumnName == "USR_GROUP")
						{
							valueCell = dtCommonERP.Rows[0]["MF004"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "CREATE_DATE")
						{
							valueCell = DateTime.Now.ToString("yyyyMMdd");
						}
						else if (dtHeader.Columns[j].ColumnName == "FLAG")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "CREATE_TIME")
						{
							valueCell = DateTime.Now.ToString("HH:mm:ss");
						}

						else if (dtHeader.Columns[j].ColumnName == "CREATE_AP")
						{
							valueCell = "SFT";
						}
						else if (dtHeader.Columns[j].ColumnName == "CREATE_PRID")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "ME001")
						{
							valueCell = iNVItems.Product;
						}
						else if (dtHeader.Columns[j].ColumnName == "ME002")
						{
							valueCell = iNVItems.Lot;
						}
						else if (dtHeader.Columns[j].ColumnName == "ME003")
						{
							valueCell = iNVItems.Create_Date.ToString("yyyyMMdd");
						}
						else if (dtHeader.Columns[j].ColumnName == "ME004")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "ME005")
						{
							valueCell = iNVItems.TypeDoccument;
						}
						else if (dtHeader.Columns[j].ColumnName == "ME006")
						{
							valueCell = iNVItems.DoccumentNo;
						}
						else if (dtHeader.Columns[j].ColumnName == "ME007")
						{
							valueCell = "N";
						}
						else if (dtHeader.Columns[j].ColumnName == "ME008")
						{
							valueCell = iNVItems.ProductCode.Replace("-","");
						}
						else if (dtHeader.Columns[j].ColumnName == "ME009")
						{
							int ExpireDay = Database.INV.INVMB.ExpireDaybyProduct(iNVItems.Product);
							valueCell = DateTime.Now.AddDays(ExpireDay).ToString("yyyyMMdd");
						}
						else if (dtHeader.Columns[j].ColumnName == "ME010")
						{
							int ExpireDay = Database.INV.INVMB.ExpireDayInspectbyProduct(iNVItems.Product);
							valueCell = DateTime.Now.AddDays(ExpireDay).ToString("yyyyMMdd");
							
						}
						else if (dtHeader.Columns[j].ColumnName == "ME011")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "ME012")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "ME013")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "ME014")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "ME015")
						{
							valueCell = "";
						}
						
						else if (dtHeader.Columns[j].ColumnName == "ME500")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "ME501")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "ME502")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "ME503")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "ME504")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "ME505")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "ME506")
						{
							valueCell = "";
						}

						else if (dtHeader.Columns[j].ColumnName == "UDF01")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "UDF02")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "UDF03")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "UDF04")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "UDF05")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "UDF06")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "UDF07")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "UDF08")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "UDF09")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "UDF10")
						{
							valueCell = "0";
						}

						if (j < dtHeader.Columns.Count - 1)
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
					if (sqlTLVN2.sqlExecuteNonQuery(sqlInsert, false) == false)
					{
						//MessageBox.Show("Insert SFT_TRANSORDER fail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return false;
					}
					return true;

				}
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertINVMF(Model.INVItems iNVItems)", ex.Message);
			}
			return false;
		}
	}
}
