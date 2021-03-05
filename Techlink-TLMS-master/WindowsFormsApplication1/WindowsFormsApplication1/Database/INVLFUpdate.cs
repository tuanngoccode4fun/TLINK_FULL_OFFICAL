using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database
{
  public  class INVLFUpdate
    {
        public DataTable GetdtTop1INVLF()
        {
            DataTable dt = new DataTable();
            string querry = " select top(1) * from INVLF ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);
            return dt;
        }
		public bool InsertINVLF(Model.INVItems iNVItems, DataTable dtCommonERP)
		{
			try
			{
				double SLDongGoi = Database.INV.INVMD.ConvertToWeightKg(iNVItems.Product, iNVItems.Quantity);
				DataTable dtHeader = GetdtTop1INVLF();
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringFun = new StringBuilder();
				stringBuilder.Append(" insert into INVLF ( ");
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
						else if (dtHeader.Columns[j].ColumnName == "LF001")
						{
							valueCell = iNVItems.TypeDoccument;
						}
						else if (dtHeader.Columns[j].ColumnName == "LF002")
						{
							valueCell = iNVItems.DoccumentNo;
						}
						else if (dtHeader.Columns[j].ColumnName == "LF003")
						{
							valueCell = iNVItems.STTDoc;
						}
						else if (dtHeader.Columns[j].ColumnName == "LF004")
						{
							valueCell = iNVItems.Product;
						}
						else if (dtHeader.Columns[j].ColumnName == "LF005")
						{
							valueCell = iNVItems.Warehouse;
						}
						else if (dtHeader.Columns[j].ColumnName == "LF006")
						{
							valueCell = iNVItems.Location;
						}
						else if (dtHeader.Columns[j].ColumnName == "LF007")
						{
							valueCell = iNVItems.Lot;
						}
						else if (dtHeader.Columns[j].ColumnName == "LF008")
						{
							valueCell = iNVItems.TypeInportExport;
						}
						else if (dtHeader.Columns[j].ColumnName == "LF009")
						{
							valueCell = iNVItems.Create_Date.ToString("yyyyMMdd");
						}
						else if (dtHeader.Columns[j].ColumnName == "LF010")
						{
							valueCell =iNVItems.TypeChange;
						}
						else if (dtHeader.Columns[j].ColumnName == "LF011")
						{
							valueCell = iNVItems.Quantity.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "LF012")
						{
							valueCell = SLDongGoi.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "LF013")
						{
							valueCell = iNVItems.ProductCode;
						}
						else if (dtHeader.Columns[j].ColumnName == "LF014")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "LF015")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "LF016")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LF017")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LF018")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LF019")
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

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertINVLF(Model.INVItems iNVItems)", ex.Message);
			}
			return false;
		}

	}
}
