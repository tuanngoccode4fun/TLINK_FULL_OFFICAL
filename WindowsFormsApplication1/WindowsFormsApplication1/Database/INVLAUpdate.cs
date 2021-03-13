using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database
{
  public  class INVLAUpdate
    {
        public DataTable GetdtTop1INVLA()
        {
            DataTable dt = new DataTable();
            string querry = " select top(1) * from INVLA ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);
            return dt;
        }
		public bool InsertINVLA(Model.INVItems iNVItems, DataTable dtCommonERP)
		{
			try
			{
				double SLDongGoi = Database.INV.INVMD.ConvertToWeightKg(iNVItems.Product, iNVItems.Quantity);
				DataTable dtHeader = GetdtTop1INVLA();
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringFun = new StringBuilder();
				stringBuilder.Append(" insert into INVLA ( ");
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
						else if (dtHeader.Columns[j].ColumnName == "LA001")
						{
							valueCell = iNVItems.Product;
						}
						else if (dtHeader.Columns[j].ColumnName == "LA004")
						{
							valueCell = iNVItems.Create_Date.ToString("yyyyMMdd");
						}
						else if (dtHeader.Columns[j].ColumnName == "LA005")
						{
							valueCell = iNVItems.TypeInportExport;
						}
						else if (dtHeader.Columns[j].ColumnName == "LA006")
						{
							valueCell = iNVItems.TypeDoccument;
						}
						else if (dtHeader.Columns[j].ColumnName == "LA007")
						{
							valueCell = iNVItems.DoccumentNo;
						}
						else if (dtHeader.Columns[j].ColumnName == "LA008")
						{
							valueCell = iNVItems.STTDoc;
						}
						else if (dtHeader.Columns[j].ColumnName == "LA009")
						{
							valueCell = iNVItems.Warehouse;
						}
						else if (dtHeader.Columns[j].ColumnName == "LA010")
						{
							valueCell = iNVItems.ProductCode;
						}
						else if (dtHeader.Columns[j].ColumnName == "LA011")
						{
							valueCell = iNVItems.Quantity.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "LA012")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA013")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA014")
						{
							valueCell = iNVItems.TypeChange;
						}
						else if (dtHeader.Columns[j].ColumnName == "LA015")
						{
							valueCell = "Y";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA016")
						{
							valueCell = iNVItems.Lot;
						}
						else if (dtHeader.Columns[j].ColumnName == "LA017")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA018")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA019")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA020")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA021")
						{
							valueCell = SLDongGoi.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "LA022")
						{
							valueCell = iNVItems.Location;
						}
						else if (dtHeader.Columns[j].ColumnName == "LA023")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA024")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA025")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA026")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA027")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA028")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA029")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA030")
						{
							valueCell = "";
						}

						else if (dtHeader.Columns[j].ColumnName == "LA031")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA032")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA033")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LA034")
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

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertINVLA(Model.INVItems iNVItems)", ex.Message);
			}
			return false;
		}
	}
}
