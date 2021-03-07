using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WindowsFormsApplication1.WMS.Model;
using System.Windows;

namespace WindowsFormsApplication1.WMS.Controller
{
   public class ERPDataUpdate
    {
		string GetFormat(string TF001)
		{
			string formatReturn = "";
			string formatReturn_Temp = "";
			///TB025 Tháng khai báo
			///TB001 Loại phiếu chuyển
			///TB002 Mã phiếu chuyển
			///
			string temp = @"select MQ006 from CMSMQ where MQ001 =@TF001";
			string sqlQuerry = temp.Replace("@TF001", "'" + TF001.Trim() + "'");
			SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
			formatReturn_Temp = sqlTLVN2.sqlExecuteScalarString(sqlQuerry).Trim();
			if (formatReturn_Temp == "4")
			{
				formatReturn = "0001";
			}
			else if (formatReturn_Temp == "3")
			{
				formatReturn = "001";
			}
			else if (formatReturn_Temp == "5")
			{
				formatReturn = "00001";
			}
			else if (formatReturn_Temp == "6")
			{
				formatReturn = "000001";
			}
			return formatReturn;

		}
		public string getTB002(string TB001)
		{
			string TB002= "";
			///TB025 Tháng khai báo
			///TB001 Loại phiếu chuyển
			///TB002 Mã phiếu chuyển
			///
			string format = GetFormat(TB001);
			string temp= @" Declare @TF002 Varchar(20)
IF(NOT EXISTS(SELECT TOP 1 TF002 as MADON FROM MOCTF WHERE TF001 = @TF001 and SUBSTRING(TF003, 0, 7) = (SELECT LEFT(CONVERT(varchar, GetDate(), 112), 6)) UNION
			SELECT TOP 1 TB002 as MADON FROM SFCTB WHERE TB001 = @TF001 and TB025 = (SELECT LEFT(CONVERT(varchar, GetDate(), 112), 6))))
			SET @TF002 = (select convert(char(4), getdate(), 12)) + @Format_TT_Count
			ELSE
			SET @TF002 = (SELECT MAX(MaxValue) FROM
			(SELECT ISNULL((MAX(TF002) + 1), 0) as MaxValue FROM MOCTF WHERE TF001 = @TF001 and SUBSTRING(TF003, 0, 7) = (SELECT LEFT(CONVERT(varchar, GetDate(), 112), 6))
			UNION SELECT ISNULL(MAX(TB002) + 1, 0) as MaxValue FROM SFCTB WHERE TB001 = @TF001 and TB025 = (SELECT LEFT(CONVERT(varchar, GetDate(), 112), 6))) as T1)
  select @TF002

";
			string sqlQuerry = temp.Replace("@TF001", "'" + TB001.Trim() + "'").Replace("@Format_TT_Count", "'" + format.Trim() + "'");
		    //" select max(TB002)+1 from SFCTB where TB001 = '"+TB001+ "' and TB025 ='"+ DateTime.Now.ToString("yyyyMM")+"' " ;
			SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
			TB002 = sqlTLVN2.sqlExecuteScalarString(sqlQuerry);
			if (TB002 == "" || TB002 == string.Empty)
			{
				TB002 = DateTime.Now.ToString("yyMM") + "0001";
			}

			return TB002;

		}
		public string getTF002(string TF001)
		{
			string TB002 = "";
			///TB025 Tháng khai báo
			///TB001 Loại phiếu chuyển
			///TB002 Mã phiếu chuyển
			string sqlQuerry = " select max(TF002)+1 from MOCTF where TF001 = '" + TF001 + "' and TF012 like '%" + DateTime.Now.ToString("yyyyMM") + "%' ";
			SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
			TB002 = sqlTLVN2.sqlExecuteScalarString(sqlQuerry);
			if (TB002 == "" || TB002 == string.Empty)
			{
				TB002 = DateTime.Now.ToString("yyMM") + "0001";
			}

			return TB002;

		}
		public bool InsertSFCTCForFinishedGoods(FinishedGoodsItems fgItems,DataTable dtADMMF, DataTable dtSFCTA, DataTable dtMODELLOT, string TB002)
		{
			try
			{
				GetDataERPTable getDataERPTable = new GetDataERPTable();
				DataTable dtHeader = getDataERPTable.GetDataTableSFCTC();
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringFun = new StringBuilder();
				stringBuilder.Append(" insert into SFCTC ( ");
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
						string valueCell = "";
						if (dtHeader.Columns[j].ColumnName == "COMPANY")
						{
							valueCell = dtSFCTA.Rows[0]["COMPANY"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "CREATOR")
						{
							valueCell = Class.valiballecommon.GetStorage().UserName;
						}
						else if (dtHeader.Columns[j].ColumnName == "USR_GROUP")
						{
							valueCell = dtADMMF.Rows[0]["MF004"].ToString();
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
						else if (dtHeader.Columns[j].ColumnName == "MODIFIER")
						{
							valueCell ="NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "MODI_DATE")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "CREATE_AP")
						{
							valueCell = "SFT";
						}
						else if (dtHeader.Columns[j].ColumnName == "CREATE_PRID")
						{
							valueCell = "Sftb03";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC001")
						{
							valueCell = Class.valiballecommon.GetStorage().DocNo;
						}
						else if (dtHeader.Columns[j].ColumnName == "TC002")
						{
							valueCell = TB002; 
						}
						else if (dtHeader.Columns[j].ColumnName == "TC003")
						{
							valueCell = "0001";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC004")
						{
							valueCell = fgItems.productCode.Split('-')[0];
						}
						else if (dtHeader.Columns[j].ColumnName == "TC005")
						{
							valueCell = fgItems.productCode.Split('-')[1];
						}
						else if (dtHeader.Columns[j].ColumnName == "TC006")
						{
							valueCell = "0020";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC007")
						{
							valueCell = dtSFCTA.Rows[0]["TA004"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TC010")
						{
							 valueCell = dtSFCTA.Rows[0]["TA020"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TC013")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC014")
						{
							valueCell = fgItems.TotalQty.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TC015")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC016")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC017")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC018")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC019")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC020")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC021")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC022")
						{
							valueCell = "Y";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC023")
						{
							valueCell = dtSFCTA.Rows[0]["TA006"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TC025")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC026")
						{
							valueCell = "N";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC027")
						{
							valueCell = "N";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC035")
						{
							valueCell = "N";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC036")
						{
							valueCell = fgItems.TotalQty.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TC037")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC038")
						{
							valueCell = DateTime.Now.ToString("yyyyMMdd");
						}
						else if (dtHeader.Columns[j].ColumnName == "TC039")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC041")
						{
							valueCell = fgItems.INDEPID;
						}
						else if (dtHeader.Columns[j].ColumnName == "TC042")
						{
							valueCell = (double.Parse(dtMODELLOT.Rows[0]["PKQTYPER"].ToString())* fgItems.TotalQty).ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TC043")
						{
							valueCell = (double.Parse(dtMODELLOT.Rows[0]["PKQTYPER"].ToString()) * fgItems.TotalQty).ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TC044")
						{
							valueCell ="0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC045")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC046")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC047")
						{
							valueCell = fgItems.product;
						}
						else if (dtHeader.Columns[j].ColumnName == "TC048")
						{
							valueCell = dtMODELLOT.Rows[0]["MO021"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TC050")
						{
							valueCell = dtMODELLOT.Rows[0]["PKUNIT"].ToString();//cai nay lay o dau
						}
						else if (dtHeader.Columns[j].ColumnName == "TC051")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC052")
						{
							valueCell = fgItems.location;
						}
						else if (dtHeader.Columns[j].ColumnName == "TC053")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC054")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC055")
						{
							valueCell = "N";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC060")
						{
							valueCell = "0";
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

				SystemLog.Output(SystemLog.MSG_TYPE.Err, " InsertSFCTCForFinishedGoods(FinishedGoodsItems fgItems)", ex.Message);
			}
			return false;
		}

		public bool InsertSFCTBForFinishedGoods(FinishedGoodsItems fgItems,DataTable dtADMMF, DataTable dtSFCTA, DataTable dtMODELLOT, string TransNo,string TB002)
		{
			try
			{
				GetDataERPTable getDataERPTable = new GetDataERPTable();
				DataTable dtHeader = getDataERPTable.GetDataTableSFCTB();
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringFun = new StringBuilder();
				stringBuilder.Append(" insert into SFCTB ( ");
				for (int i = 0; i < dtHeader.Columns.Count-1; i++)
				{
					if (i < dtHeader.Columns.Count - 2)
					{
						if (dtHeader.Columns[i].ColumnName != "CFIELD01")
							stringBuilder.Append(dtHeader.Columns[i].ColumnName + ",");
					}
					else  stringBuilder.Append(dtHeader.Columns[i].ColumnName + ") values ( ");
				}
				if (dtHeader != null && dtHeader.Rows.Count == 1)
				{
					for (int j = 0; j < dtHeader.Columns.Count-1; j++)
					{
						string valueCell = "";
						if (dtHeader.Columns[j].ColumnName == "COMPANY")
						{
							valueCell = dtSFCTA.Rows[0]["COMPANY"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "CREATOR")
						{
							valueCell = Class.valiballecommon.GetStorage().UserName;
						}
						else if (dtHeader.Columns[j].ColumnName == "USR_GROUP")
						{
							valueCell = dtADMMF.Rows[0]["MF004"].ToString();
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
							valueCell = "Sftb03";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB001")
						{
							valueCell = Class.valiballecommon.GetStorage().DocNo;
						}
						else if (dtHeader.Columns[j].ColumnName == "TB002")
						{
							valueCell = TB002; 
						}
						else if (dtHeader.Columns[j].ColumnName == "TB003")
						{
							valueCell = DateTime.Now.ToString("yyyyMMdd");
						}
						else if (dtHeader.Columns[j].ColumnName == "TB004")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB005")
						{
							valueCell = dtSFCTA.Rows[0]["TA006"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TB006")
						{
							valueCell = dtSFCTA.Rows[0]["TA007"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TB007")
						{
							valueCell = "3";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB008")
						{
							valueCell = fgItems.INDEPID; 
						}
						else if (dtHeader.Columns[j].ColumnName == "TB009")
						{
							valueCell = fgItems.INDEPNAME;// Ten kho den
						}
						else if (dtHeader.Columns[j].ColumnName == "TB010")
						{
							valueCell = dtMODELLOT.Rows[0]["FACTORYID"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TB011")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB012")
						{
							valueCell = "N";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB013")
						{
							valueCell = "Y";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB014")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB015")
						{
							valueCell = DateTime.Now.ToString("yyyyMMdd");
						}
						else if (dtHeader.Columns[j].ColumnName == "TB016")
						{
							valueCell = Class.valiballecommon.GetStorage().UserName;
						}
						else if (dtHeader.Columns[j].ColumnName == "TB017")
						{
							valueCell = "N";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB018")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB019")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB022")
						{
							valueCell ="1";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB023")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB025")
						{
							valueCell = DateTime.Now.ToString("yyyyMM");
						}
						else if (dtHeader.Columns[j].ColumnName == "TB026")
						{
							valueCell = "0.2";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB027")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB029")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB030")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB031")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB036")
						{
							valueCell = dtSFCTA.Rows[0]["TA018"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TB037")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB038")
						{
							valueCell = Class.valiballecommon.GetStorage().DocNo;
						}
						else if (dtHeader.Columns[j].ColumnName == "TB039")
						{
							valueCell = TransNo;
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
						else if (dtHeader.Columns[j].ColumnName == "TB200")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB201")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB202")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TB042")
						{
							valueCell = "";
						}
						//if (j < dtHeader.Columns.Count - 1)
						//{
						//	if (dtHeader.Columns[j].ColumnName != "CFIELD01")
						//		stringFun.Append(" '" + valueCell + "',");
						//}

						//else stringFun.Append("'" + valueCell + "')");

						if (j < dtHeader.Columns.Count - 2)
						{
							if (valueCell == "NULL")
								stringFun.Append(" " + valueCell + " ,");
							else stringFun.Append(" '" + valueCell + "',");
						}
						else
						{
							if (valueCell == "NULL")
								stringFun.Append(" " + valueCell + " )");
							else 
							    stringFun.Append(" '" + valueCell + "')");

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

				SystemLog.Output(SystemLog.MSG_TYPE.Err, " InsertSFCTCForFinishedGoods(FinishedGoodsItems fgItems)", ex.Message);
			}
			return false;
		}

		public bool InsertOrUpdateSFCTA(FinishedGoodsItems fgItems)
		{
			try
			{

			
			CheckExtinctRowInTable checkExtinctRowInTable = new CheckExtinctRowInTable();
			if(checkExtinctRowInTable.CheckExstinctRowSFCTA(fgItems.productCode,"0020"))
			{
					//Update
					UpdateSFCTAForFinishedGoods(fgItems, "0020");
			}
			else
			{
				//Insert
			}
			}
			catch (Exception ex)
			{
				SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertOrUpdateSFCTA(FinishedGoodsItems fgItems)", ex.Message);
				return false;
			}
			return true;
		}
	
		public bool UpdateSFCTAForFinishedGoods(FinishedGoodsItems fgItems, string TA003)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" update SFCTA ");
				stringBuilder.Append(" set MODIFIER = '"+Class.valiballecommon.GetStorage().UserName +"', ");
				stringBuilder.Append("  MODI_DATE = '" + DateTime.Now.ToString("yyyyMMdd") + "', ");
				stringBuilder.Append("  FLAG = FLAG+1 ,  ");
				stringBuilder.Append("  MODI_TIME = '"+ DateTime.Now.ToString("HH:mm:ss") + "' ,");
				stringBuilder.Append("  MODI_AP = '" +"SFT" + "' ,");
				stringBuilder.Append("  MODI_PRID = '" + "Sftb03" + "' ,");
				stringBuilder.Append("  TA017 = TA017 + "+ fgItems.TotalQty  + " ,");
				stringBuilder.Append("  TA045 = TA045 +" + (fgItems.TotalQty*0).ToString() + " ");
				stringBuilder.Append(" where TA001 ='" + fgItems.productCode.Split('-')[0] + "' ");
				stringBuilder.Append(" and TA002 ='" + fgItems.productCode.Split('-')[1] + "' ");
				stringBuilder.Append(" and TA003 ='" + TA003 + "' ");


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

		public bool UploadtoERPDBForFinishedGoods(FinishedGoodsItems fgItems,DataTable dtADMMF,DataTable dtLotMODETAIL,string TB002, string TransNo)
		{
			try
			{
				if(fgItems != null)
				{
					GetDataERPTable getDataERPTable = new GetDataERPTable();
					DataTable dtSFCTA = getDataERPTable.GetDataTableSFCTA(fgItems.productCode);
					var InsertSFCTC = InsertSFCTCForFinishedGoods(fgItems,dtADMMF, dtSFCTA, dtLotMODETAIL, TB002);
					if (InsertSFCTC == false)
					{
						SystemLog.Output(SystemLog.MSG_TYPE.War, "InsertSFCTCForFinishedGoods(fgItems, TB002))", "False");
					}
					var InsertSFCTB = InsertSFCTBForFinishedGoods(fgItems,dtADMMF, dtSFCTA, dtLotMODETAIL, TransNo, TB002);
					if (InsertSFCTB == false)
					{
						SystemLog.Output(SystemLog.MSG_TYPE.War, "InsertSFCTBForFinishedGoods(fgItems, TransNo, TB002)", "False");
					}
					var InsertOrUpdate = InsertOrUpdateSFCTA(fgItems);
					if (InsertOrUpdate == false)
					{
						SystemLog.Output(SystemLog.MSG_TYPE.War, "InsertOrUpdateSFCTA(fgItems)", "false");
					}
					if (InsertSFCTC && InsertSFCTB && InsertOrUpdate)
					{
						return true;
					}
				}
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UploadtoERPDBForFinishedGoods(FinishedGoodsItems fgItems)", ex.Message);
				return false;
			}
			return false;
		}
		public bool UploadtoERPDBForFinishedGoods(DataTable ERPPQC, DataTable dtADMMF, string TB002, string TransNo)
		{
			try
			{
				
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UploadtoERPDBForFinishedGoods(FinishedGoodsItems fgItems)", ex.Message);
				return false;
			}
			return false;
		}
	}
}
