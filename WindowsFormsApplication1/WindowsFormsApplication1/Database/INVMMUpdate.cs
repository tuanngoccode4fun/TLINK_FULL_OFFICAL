using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database
{
  public  class INVMMUpdate
    {
        //INVMM 
        public DataTable GetDtTop1INVMM()
        {
            DataTable dt = new DataTable();
            string querry = " select top(1) * from INVMM ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);
            return dt;
        }
		public bool InsertINVMM(Model.INVItems iNVItems, DataTable dtCommonERP)
		{
			try
			{
				double SLDongGoi = Database.INV.INVMD.ConvertToWeightKg(iNVItems.Product, iNVItems.Quantity);
				DataTable dtHeader = GetDtTop1INVMM();
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringFun = new StringBuilder();
				stringBuilder.Append(" insert into INVMM ( ");
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
						else if (dtHeader.Columns[j].ColumnName == "MM001")
						{
							valueCell = iNVItems.Product;
						}
						else if (dtHeader.Columns[j].ColumnName == "MM002")
						{
							valueCell = iNVItems.Warehouse;
						}
						else if (dtHeader.Columns[j].ColumnName == "MM003")
						{
							valueCell = iNVItems.Location;
						}
						else if (dtHeader.Columns[j].ColumnName == "MM004")
						{
							valueCell = iNVItems.Lot;
						}
						else if (dtHeader.Columns[j].ColumnName == "MM005")
						{
							if(iNVItems.TypeInportExport == "1")
							   valueCell = iNVItems.Quantity.ToString();
							else if (iNVItems.TypeInportExport == "-1")
								valueCell = (-1*iNVItems.Quantity).ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "MM006")
						{
							if (iNVItems.TypeInportExport == "1")
								valueCell = SLDongGoi.ToString();
							else if (iNVItems.TypeInportExport == "-1")
								valueCell = (-1 * SLDongGoi).ToString();
							
						}
						else if (dtHeader.Columns[j].ColumnName == "MM007")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "MM008")
						{
							valueCell = iNVItems.Create_Date.ToString("yyyyMMdd") ;
						}
						else if (dtHeader.Columns[j].ColumnName == "MM009")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "MM010")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "MM011")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "MM012")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "MM013")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "MM014")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "MM015")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "MM016")
						{
							valueCell = iNVItems.ImportQR;
						}
						else if (dtHeader.Columns[j].ColumnName == "MM017")
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

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertINVMM(Model.INVItems iNVItems)", ex.Message);
			}
			return false;
		}
		public bool CheckExistINVMM(Model.INVItems iNVItems)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" select * from INVMM ");
				stringBuilder.Append(" where 1=1 ");
				stringBuilder.Append(" and MM001 = '" + iNVItems.Product + "' ");
				stringBuilder.Append(" and MM002 = '" + iNVItems.Warehouse + "' ");
				stringBuilder.Append(" and MM003 = '" + iNVItems.Location + "' ");
				stringBuilder.Append(" and MM004 = '" + iNVItems.Lot + "' ");

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
		public bool UpdateINVMM(Model.INVItems iNVItems, DataTable dtCommonERP)
		{
			try
			{
				double SLDongGoi = Database.INV.INVMD.ConvertToWeightKg(iNVItems.Product, iNVItems.Quantity);
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" update INVMM ");
				stringBuilder.Append(" set MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "', ");
				stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "', ");
				stringBuilder.Append("  FLAG = FLAG+1 ,  ");
				stringBuilder.Append("  MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,");
				stringBuilder.Append("  MODI_AP = '" + "SFT" + "' ,");
				stringBuilder.Append("  MODI_PRID = '" + "MOCI05" + "' ,");
				if (iNVItems.TypeInportExport == "1")
				{
					stringBuilder.Append("  MM005 = MM005 + " + iNVItems.Quantity + " ,");
					stringBuilder.Append("  MM006 = MM006 + " + SLDongGoi + " ,");
				}
				else if(iNVItems.TypeInportExport == "-1")
				{
					stringBuilder.Append("  MM005 = MM005 - " + iNVItems.Quantity + " ,");
					stringBuilder.Append("  MM006 = MM006 - " + SLDongGoi + " ,");
				}
				stringBuilder.Append("  MM008= '" + iNVItems.Create_Date.ToString("yyyyMMdd") + "' ");
				stringBuilder.Append(" where MM001 ='" + iNVItems.Product + "' ");
				stringBuilder.Append(" and MM002 ='" + iNVItems.Warehouse + "' ");
				stringBuilder.Append(" and MM003 ='" + iNVItems.Location + "' ");
				stringBuilder.Append(" and MM004 ='" + iNVItems.Lot + "' ");

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
		public bool UpdateOrInsertINVMM(Model.INVItems iNVItems, DataTable dtCommonERP)
		{
			try
			{
				if (CheckExistINVMM(iNVItems))
				{
					var Update = UpdateINVMM(iNVItems, dtCommonERP);
					return Update;
				}
				else
				{
					var Insert = InsertINVMM(iNVItems, dtCommonERP);
					return Insert;
				}
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateOrInsertINVMM(Model.INVItems iNVItems, DataTable dtCommonERP)", ex.Message);

			}
			return false;
		}

		public DataTable GetDataTableINVMMbyProduct(string product, string warehouse)
		{
			DataTable dt = new DataTable();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("  select * from INVMM where 1=1  ");
			stringBuilder.Append(" and  MM001 like '%" + product + "%' ");
			stringBuilder.Append(" and  MM002 like '%" + warehouse + "%' ");
			stringBuilder.Append(" and  MM005 > 0 ");
			stringBuilder.Append(" order by CAST(CREATE_DATE as datetime) ");
			SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
			sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
			return dt;
		}


		public static DataTable GetDataTableINVMMbyProductWarehouse(string product,string warehouse)
		{
			DataTable dt = new DataTable();
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append("  select  MM001, MM002,MM003,MM004,MM005,MM006, MM007, MM008,MM009,MM010,MM016 from INVMM where 1=1  ");
			stringBuilder.Append(" and  MM001 like '%" + product + "%' ");
			stringBuilder.Append(" and MM002 = '" + warehouse + "' ");
			stringBuilder.Append(" and  MM005 > 0 ");
			stringBuilder.Append(" order by CAST(CREATE_DATE as datetime) + CAST(CREATE_TIME as datetime) ASC ");
			SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
			sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
			return dt;
		}
	}
}
