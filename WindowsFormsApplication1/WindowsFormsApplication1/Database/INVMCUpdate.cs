using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database
{
   public class INVMCUpdate
    {//INVMC la table chua thong tin san pham co trong nhung kho nao, so luong bao nhieu
        public DataTable GetDtTop1INVMC()
        {
            DataTable dt = new DataTable();
            string querry = " select top(1) * from INVMC ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);
            return dt;
        }
		public bool InsertINVMC(Model.INVItems iNVItems, DataTable dtCommonERP)
		{
			try
			{
				double ConvertToKg = INV.INVMD.ConvertToWeightKg(iNVItems.Product, iNVItems.Quantity);
				DataTable dtHeader = GetDtTop1INVMC();
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringFun = new StringBuilder();
				stringBuilder.Append(" insert into INVMC ( ");
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
						else if (dtHeader.Columns[j].ColumnName == "MC001")
						{
							valueCell = iNVItems.Product;
						}
						else if (dtHeader.Columns[j].ColumnName == "MC002")
						{
							valueCell = iNVItems.Warehouse;
						}
						else if (dtHeader.Columns[j].ColumnName == "MC003")
						{
							valueCell = iNVItems.Location;
						}
						else if (dtHeader.Columns[j].ColumnName == "MC004")
						{
							valueCell ="0";
						}
						else if (dtHeader.Columns[j].ColumnName == "MC005")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "MC006")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "MC007")
						{
							valueCell = iNVItems.Quantity.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "MC008")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "MC009")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "MC010")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "MC011")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "MC012")
						{
							valueCell = iNVItems.Create_Date.ToString("yyyyMMdd");
						}
						else if (dtHeader.Columns[j].ColumnName == "MC013")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "MC014")
						{
							valueCell = ConvertToKg.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "MC015")
						{
							valueCell = iNVItems.Location;
						}
						else if (dtHeader.Columns[j].ColumnName == "MC016")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "MC017")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "MC018")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "MC019")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "MC020")
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

		public bool CheckExistINVMC(Model.INVItems iNVItems)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" select * from INVMC ");
				stringBuilder.Append(" where 1=1 ");
				stringBuilder.Append(" and MC001 = '" + iNVItems.Product +"' ");
				stringBuilder.Append(" and MC002 = '" + iNVItems.Warehouse + "' ");
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
		public bool UpdateINVMC(Model.INVItems iNVItems, DataTable dtCommonERP)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" update INVMC ");
				stringBuilder.Append(" set MODIFIER = '" + Class.valiballecommon.GetStorage().UserName + "', ");
				stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "', ");
				stringBuilder.Append("  FLAG = FLAG+1 ,  ");
				stringBuilder.Append("  MODI_TIME = '" + DateTime.Now.ToString("HH:mm:ss") + "' ,");
				stringBuilder.Append("  MODI_AP = '" + "SFT" + "' ,");
				stringBuilder.Append("  MODI_PRID = '" + "MOCI05" + "' ,");
				if (iNVItems.TypeInportExport == "1")//nhap kho
				{
					stringBuilder.Append("  MC007 = MC007 + " + iNVItems.Quantity + " ,");
					stringBuilder.Append("  MC014 = MC014 + " + iNVItems.PackageQty + " ,");
					stringBuilder.Append("  MC012 = '" + iNVItems.Create_Date.ToString("yyyyMMdd") + "' ");
				}
				else if(iNVItems.TypeInportExport == "-1")//xuat kho
				{
					stringBuilder.Append("  MC007 = MC007 - " + iNVItems.Quantity + " ,");
					stringBuilder.Append("  MC014 = MC014 - " + iNVItems.PackageQty + " ,");
					stringBuilder.Append("  MC013 = '" + iNVItems.Create_Date.ToString("yyyyMMdd") + "' ");
				}
				
				stringBuilder.Append(" where MC001 ='" + iNVItems.Product + "' ");
				stringBuilder.Append(" and MC002 ='" + iNVItems.Warehouse + "' ");
				


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
		public bool UpdateOrInsertINVMC(Model.INVItems iNVItems, DataTable dtCommonERP)
		{
			try
			{
				if (CheckExistINVMC(iNVItems))
				{
					var Update = UpdateINVMC(iNVItems, dtCommonERP);
					return Update;
				}
				else
				{
					var Insert = InsertINVMC(iNVItems, dtCommonERP);
					return Insert;
				}
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateOrInsertINVMC(Model.INVItems iNVItems, DataTable dtCommonERP)", ex.Message);
				
			}
			return false;
		}



	}
}
