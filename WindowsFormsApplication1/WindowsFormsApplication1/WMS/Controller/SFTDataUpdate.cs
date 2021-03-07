using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.WMS.Model;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1.WMS.Controller
{
  public  class SFTDataUpdate
    {
        public bool InsertSFT_Transorder(FinishedGoodsItems fgItems,DataTable dtLOTMODETAIL, string TransNo, string TB002)
		{
			try
			{ GetdataSFTToDataTable getdataSFTTo = new GetdataSFTToDataTable();
				Database.GetListWarehouse getListWarehouse = new Database.GetListWarehouse();
				List<Database.WarehouseItems> listWarehouse = getListWarehouse.GetWarehouseOnly();
				DataTable dtHeader = getdataSFTTo.GetDatatableFromSFT_TRANSORDER();
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringFun = new StringBuilder();
				stringBuilder.Append(" insert into SFT_TRANSORDER ( ");
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
						if (dtHeader.Columns[j].ColumnName == "CREATER")
						{
							valueCell = Class.valiballecommon.GetStorage().UserName!=null? Class.valiballecommon.GetStorage().UserName:"" ;
						}
						else if (dtHeader.Columns[j].ColumnName == "CREATE_DATE")
						{
							valueCell = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
						}
						else if (dtHeader.Columns[j].ColumnName == "MODEIFIER")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "MODI_DATE")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "FLAG")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TRANSTYPE")
						{
							valueCell = Class.valiballecommon.GetStorage().DocNo;
						}
						else if (dtHeader.Columns[j].ColumnName == "TRANSNO")
						{
							valueCell = TransNo.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TRANSDATE")
						{
							valueCell = DateTime.Now.ToString("yyyyMMdd");
						}
						else if (dtHeader.Columns[j].ColumnName == "OUTTYPE")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "OUTDEPID")
						{
							valueCell = dtLOTMODETAIL.Rows[0]["LOCATION"].ToString(); //out den bo phan nao ??
						}
						else if (dtHeader.Columns[j].ColumnName == "OUTDEPNAME")
						{
							var name = listWarehouse.Where(d => d.MC001_Wh.Contains(dtLOTMODETAIL.Rows[0]["LOCATION"].ToString())).Select(d => d.MC002_WhName).ToList();
							valueCell = name[0]; //out den bo phan nao ??
						}
						else if (dtHeader.Columns[j].ColumnName == "INTYPE")
						{
							valueCell = "3"; //D301	IN:	3 OUt :1
						}
						else if (dtHeader.Columns[j].ColumnName == "INDEPID")
						{
							valueCell = fgItems.INDEPID; //In den bo phan nao ??
						}
						else if (dtHeader.Columns[j].ColumnName == "INDEPNAME")
						{
							var name = listWarehouse.Where(d => d.MC001_Wh == fgItems.INDEPID).Select(d => d.MC002_WhName).ToList();
							valueCell = listWarehouse.Where(d => d.MC001_Wh.Contains(fgItems.INDEPID)).Select(d => d.MC002_WhName).ToList()[0];
						}
						else if (dtHeader.Columns[j].ColumnName == "FACTORYID")
						{
							valueCell = dtLOTMODETAIL.Rows[0]["FACTORYID"].ToString(); 
						}
						else if (dtHeader.Columns[j].ColumnName == "CONFIRMCODE")
						{
							valueCell = "Y"; 
						}
						else if (dtHeader.Columns[j].ColumnName == "DOCUMENTDATE")
						{
							valueCell = DateTime.Now.ToString("yyyyMMdd");
						}
						else if (dtHeader.Columns[j].ColumnName == "INVOICECOUNT")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "TAXATIONTYPE")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "DISCOUNTDEVIDE")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "DECLARATIONDATE")
						{
							valueCell = DateTime.Now.ToString("yyyyMM");
						}
						else if (dtHeader.Columns[j].ColumnName == "SALESTAXRATE")
						{
							valueCell = "0.2";// lay theo lenh san xuat
						}
						else if (dtHeader.Columns[j].ColumnName == "COMPANYID")
						{
							valueCell = "TLVN2";// lay tu lenh sx
						}
						else if (dtHeader.Columns[j].ColumnName == "KEYID")
						{
							valueCell = fgItems.productCode;
						}
						else if (dtHeader.Columns[j].ColumnName == "STOCKINTYPE")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "TO001")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "TO007")
						{
							valueCell = Class.valiballecommon.GetStorage().DocNo;
						}
						else if (dtHeader.Columns[j].ColumnName == "TO008")
						{
							valueCell = TB002;
						}
						else if (dtHeader.Columns[j].ColumnName == "TO011")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TO012")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "COINSTYPE")
						{
							valueCell = "VND";
						}
						else if (dtHeader.Columns[j].ColumnName == "CONFIRMER")
						{
							valueCell = Class.valiballecommon.GetStorage().UserName;
						}
						else if (dtHeader.Columns[j].ColumnName == "TO013")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "TO014")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "TO015")
						{
							valueCell = "NULL";
						}
						if (j < dtHeader.Columns.Count - 1)
						{
							if(valueCell =="NULL")
								stringFun.Append(" " + valueCell + " ,");
							else stringFun.Append(" '" + valueCell + "',");
						}
						else stringFun.Append("'" + valueCell + "')");
					}
					string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
					sqlSFT sqlSFT = new sqlSFT();
					if(sqlSFT.sqlExecuteNonQuery(sqlInsert, false) == false)
					{
						MessageBox.Show("Insert SFT_TRANSORDER fail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return false;
					}
					return true;
				}
				}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertSFT_Transorder(FinishedGoodsItems fgItems)", ex.Message);
			}
            return false;
        }

		public string getTransnoOfSFT(string TRANSTYPE)
		{
			string TransNo = "";
			string sqlQuerry = " select max(TRANSNO)+1 from SFT_TRANSORDER where TRANSTYPE = '"+ TRANSTYPE +"'  and TRANSDATE = '" + DateTime.Now.ToString("yyyyMMdd") + "' ";
			sqlSFT sqlSFT = new sqlSFT();
			TransNo = sqlSFT.sqlExecuteScalarString(sqlQuerry);
			if(TransNo =="" || TransNo == string.Empty)
			{
				TransNo ="0"+ DateTime.Now.ToString("yyMMdd") + "0001";
			}
			else
			{
				TransNo = "0" + TransNo;
			}

			return TransNo;

		}


		public bool InsertSFT_WS_RUN(FinishedGoodsItems fgItems,DataTable dtLOTMODEL, string TransNo,string TB002, string sequence)
		{
			try
			{
				GetdataSFTToDataTable getdataSFTTo = new GetdataSFTToDataTable();

				DataTable dtHeader = getdataSFTTo.GetDatatableFromSFT_WS_RUN();
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringFun = new StringBuilder();
				stringBuilder.Append(" insert into SFT_WS_RUN ( ");
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
						if (dtHeader.Columns[j].ColumnName == "WSID")
						{
							valueCell = dtLOTMODEL.Rows[0]["LOCATION"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "EQID")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "OPID")
						{
							valueCell = dtLOTMODEL.Rows[0]["ERP_OPID"].ToString() + "---" + dtLOTMODEL.Rows[0]["ERP_WSID"].ToString();
						}
						
						else if (dtHeader.Columns[j].ColumnName == "ID")
						{
							valueCell = fgItems.productCode;
						}
						else if (dtHeader.Columns[j].ColumnName == "SEQUENCE")
						{
							valueCell =sequence;//sequence dem len
						}
						else if (dtHeader.Columns[j].ColumnName == "EXECUTENAME")
						{
							valueCell = "" ;
						}
						else if (dtHeader.Columns[j].ColumnName == "EXECUTETIME")
						{
							valueCell = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
						}
						else if (dtHeader.Columns[j].ColumnName == "EXECUTETYPE")
						{
							valueCell = "IntoWH";
						}
						else if (dtHeader.Columns[j].ColumnName == "ROUTESEQUENCE")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "STEPSEQUENCE")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "ALTSTEPSEQUENCE")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "OPSEQUENCE")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "EXECUTEQTY")
						{
							valueCell = fgItems.TotalQty.ToString();
						}
					
						else if (dtHeader.Columns[j].ColumnName == "USERID")
						{
							valueCell = Class.valiballecommon.GetStorage().UserCode;
						}
						else if (dtHeader.Columns[j].ColumnName == "UNITCOUNT")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "QTYPERUNIT")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "UNIT")
						{
							valueCell = dtLOTMODEL.Rows[0]["UNIT"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "QTYPER")
						{
							valueCell = "1"; 
						}
						else if (dtHeader.Columns[j].ColumnName == "PLUSINDEX")
						{
							valueCell = "0"; 
						}
						else if (dtHeader.Columns[j].ColumnName == "ERP_OPSEQ")
						{
							valueCell = "0020"; 
						}
						else if (dtHeader.Columns[j].ColumnName == "ERP_OPID")
						{
							valueCell = dtLOTMODEL.Rows[0]["ERP_OPID"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "ERP_WSID")
						{
							valueCell = dtLOTMODEL.Rows[0]["ERP_WSID"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "PKQTY")
						{
							valueCell = (fgItems.TotalQty * double.Parse(dtLOTMODEL.Rows[0]["PKQTYPER"].ToString())).ToString();     //"EXECUTEQTY*PKQTYPER"; ;// phai tinh toan the nao ??
						}
						else if (dtHeader.Columns[j].ColumnName == "PKQTYPER")
						{
							valueCell = dtLOTMODEL.Rows[0]["PKQTYPER"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "PKUNIT")
						{
							valueCell = dtLOTMODEL.Rows[0]["PKUNIT"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "WR001")
						{
							valueCell = "-1";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR002")
						{
							valueCell = Class.valiballecommon.GetStorage().DocNo+"-"+TB002;//phai tinh toan
						}
						else if (dtHeader.Columns[j].ColumnName == "WR003")
						{
							valueCell = "0001";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR004")
						{
							valueCell = fgItems.TotalQty.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "WR005")
						{
							valueCell = fgItems.TotalQty.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "WR006")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR007")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR008")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR009")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR010")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR011")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR014")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR015")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR016")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR017")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR018")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR019")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR023")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR026")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "CREATE_DATE")
						{
							valueCell = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
						}
						else if (dtHeader.Columns[j].ColumnName == "WR029")
						{
							valueCell = "1";// quan trong
						}
						else if (dtHeader.Columns[j].ColumnName == "WR030")
						{
							valueCell = "1";// quan trong
						}
						else if (dtHeader.Columns[j].ColumnName == "WR031")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR032")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "WR036")
						{
							valueCell = "0";
						}

						if (j < dtHeader.Columns.Count - 1)
						{
							if (valueCell == "NULL")
								stringFun.Append(" " + valueCell + " ,");
							else stringFun.Append(" '" + valueCell + "',");
						}
						else stringFun.Append("'" + valueCell + "')");
					}
					string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
					sqlSFT sqlSFT = new sqlSFT();
					if (sqlSFT.sqlExecuteNonQuery(sqlInsert, false) == false)
					{
						MessageBox.Show("Insert SFT_WS_RUN fail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return false;
					}
					return true;
				}
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertSFT_WS_RUN", ex.Message);
			}
			return false;
		}

		public bool InsertSFT_TRANSORDER_LINE(FinishedGoodsItems fgItems,DataTable dtLOTMODETAIL, string TransNo,string TB002, int Sequence )
		{
			try
			{
				GetdataSFTToDataTable getdataSFTTo = new GetdataSFTToDataTable();
				Database.GetListWarehouse getListWarehouse = new Database.GetListWarehouse();
				List<Database.WarehouseItems> listWarehouse = getListWarehouse.GetWarehouseOnly();
				DataTable dtHeader = getdataSFTTo.GetDatatableFromSFT_TRANSORDER_LINE();
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringFun = new StringBuilder();
				stringBuilder.Append(" insert into SFT_TRANSORDER_LINE ( ");
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
						if (dtHeader.Columns[j].ColumnName == "CREATER")
						{
							valueCell = Class.valiballecommon.GetStorage().UserName;
						}
						else if (dtHeader.Columns[j].ColumnName == "CREATE_DATE")
						{
							valueCell = DateTime.Now.ToString("yyyyMMdd HH:mm:ss");
						}
						else if (dtHeader.Columns[j].ColumnName == "MODEIFIER")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "MODI_DATE")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "FLAG")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "TRANSORDERTYPE")
						{
							valueCell = Class.valiballecommon.GetStorage().DocNo;
						}
						else if (dtHeader.Columns[j].ColumnName == "TRANSNO")
						{
							valueCell = TransNo.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "SN")
						{
							valueCell = "0001";
						}
						else if (dtHeader.Columns[j].ColumnName == "MOTYPE")
						{
							valueCell = fgItems.productCode.Split('-')[0];
						}
						else if (dtHeader.Columns[j].ColumnName == "MONO")
						{
							valueCell = fgItems.productCode.Split('-')[1];
						}
						else if (dtHeader.Columns[j].ColumnName == "OUTOPSEQ")
						{
							valueCell = "0020"; 
						}
						
						else if (dtHeader.Columns[j].ColumnName == "OUTOP")
						{
							valueCell = dtLOTMODETAIL.Rows[0]["ERP_OPID"].ToString(); 
						}
						else if (dtHeader.Columns[j].ColumnName == "INOPSEQ")
						{
							valueCell = ""; 
						}
						else if (dtHeader.Columns[j].ColumnName == "INOP")
						{
							valueCell = ""; 
						}
						else if (dtHeader.Columns[j].ColumnName == "UNIT")
						{
							valueCell = dtLOTMODETAIL.Rows[0]["UNIT"].ToString(); 
						}
						else if (dtHeader.Columns[j].ColumnName == "PATTERN")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "SCRAPQTY")
						{
							valueCell = fgItems.DefectQty.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "LABORHOUR")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "MACHINEHOUR")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "OUTDEP")
						{
							valueCell = dtLOTMODETAIL.Rows[0]["LOCATION"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "OUTORDERTYPE")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "OUTORDERNO")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "OUTORDERSEQ")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LOTNO")
						{
							valueCell = fgItems.lot;
						}
						else if (dtHeader.Columns[j].ColumnName == "EMERGENCY")
						{
							valueCell = "N";
						}
						else if (dtHeader.Columns[j].ColumnName == "TRANSQTY")
						{
							valueCell = fgItems.TotalQty.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "INDEP")
						{
							valueCell = fgItems.INDEPID;
						}
						else if (dtHeader.Columns[j].ColumnName == "ITEMID")
						{
							valueCell = fgItems.product;
						}
						else if (dtHeader.Columns[j].ColumnName == "ITEMNAME")
						{
							valueCell = dtLOTMODETAIL.Rows[0]["MO021"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "ITEMDESCRIPTION")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "INSTORAGESPACE")
						{
							valueCell = fgItems.location;
						}
						else if (dtHeader.Columns[j].ColumnName == "TC012")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC017")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC018")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC015")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TC019")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "KEYID")
						{
							valueCell = fgItems.productCode;
						}
						else if (dtHeader.Columns[j].ColumnName == "PRODUCTIONSEQ")
						{
							valueCell = "-1";// quan trong
						}
						else if (dtHeader.Columns[j].ColumnName == "TL002")
						{
							valueCell = fgItems.TotalQty.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TL003")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL004")
						{ var ConvertToKg = (fgItems.TotalQty * double.Parse((dtLOTMODETAIL.Rows[0]["PKQTYPER"]).ToString()));
							valueCell = ConvertToKg.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TL005")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL006")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "SFTUPDATE")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL055")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL007")
						{
							var ConvertToKg = (fgItems.TotalQty * double.Parse((dtLOTMODETAIL.Rows[0]["PKQTYPER"]).ToString()));
							valueCell = ConvertToKg.ToString();
						//	valueCell = (fgItems.TotalQty * (double)dtLOTMODETAIL.Rows[0]["PKQTYPER"]).ToString(); 
						}
						else if (dtHeader.Columns[j].ColumnName == "TL008")
						{
							var ConvertToKg = (fgItems.DefectQty * double.Parse((dtLOTMODETAIL.Rows[0]["PKQTYPER"]).ToString()));
							valueCell = ConvertToKg.ToString();
						//	valueCell = (fgItems.DefectQty * (double)dtLOTMODETAIL.Rows[0]["PKQTYPER"]).ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TL009")
						{
							valueCell = dtLOTMODETAIL.Rows[0]["PKUNIT"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TL010")
						{
							valueCell = DateTime.Now.ToString("yyyyMMdd");
						}
						else if (dtHeader.Columns[j].ColumnName == "TL011")
						{
							valueCell = Class.valiballecommon.GetStorage().DocNo;
						}
						else if (dtHeader.Columns[j].ColumnName == "TL012")
						{
							valueCell = TB002;
						}
						else if (dtHeader.Columns[j].ColumnName == "TL013")
						{
							valueCell = "N";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL014")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL015")
						{
							valueCell = Sequence.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "TL016")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "SPC")
						{
							valueCell = "N";//Infortance
						}
						else if (dtHeader.Columns[j].ColumnName == "TWINUNIT")
						{
							valueCell = "Y";//Infortance
						}
						else if (dtHeader.Columns[j].ColumnName == "KEY_TRANSORDER")
						{
							valueCell = "1";//Infortance
						}
						else if (dtHeader.Columns[j].ColumnName == "FACTORYID")
						{
							valueCell = dtLOTMODETAIL.Rows[0]["FACTORYID"].ToString();//Infortance
						}
						else if (dtHeader.Columns[j].ColumnName == "INWSTYPE")
						{
							valueCell = "3";
						}
						else if (dtHeader.Columns[j].ColumnName == "OUTWSTYPE")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL017")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL018")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL019")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL020")
						{
							valueCell = "NULL";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL023")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL024")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL025")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "TL027")
						{
							valueCell = "0";
						}
						if (j < dtHeader.Columns.Count - 1)
						{
							if (valueCell == "NULL")
								stringFun.Append(" " + valueCell + " ,");
							else stringFun.Append(" '" + valueCell + "',");
						}
						else stringFun.Append("'" + valueCell + "')");
					}
					string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
					sqlSFT sqlSFT = new sqlSFT();
					if (sqlSFT.sqlExecuteNonQuery(sqlInsert, false) == false)
					{
						MessageBox.Show("Insert SFT_TRANSORDER_Line fail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return false;
					}
					 else return true;
				}
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, " InsertSFT_TRANSORDER_LINE(FinishedGoodsItems fgItems, string TransNo,string TB002 )", ex.Message);
			}
			return false;
		}

		public bool UpdateMODETAIL(FinishedGoodsItems fgItems, DataTable dtLOTMODETAIL)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.Append(" update MODETAIL ");
				stringBuilder.Append(" set LASTMAINTAINDATETIME = GETDATE() , ");
				stringBuilder.Append("  MO009 = MO009 +" + fgItems.TotalQty + ", ");
				stringBuilder.Append("  MO027 =  ("+"MO009 +"+fgItems.TotalQty+ ")*"+  double.Parse(dtLOTMODETAIL.Rows[0]["PKQTYPER"].ToString()) + " ");// chinh sua cho nay
				stringBuilder.Append("where CMOID ='" + fgItems.productCode + "' ");
				sqlSFT sqlSFT = new sqlSFT();
		var result =		sqlSFT.sqlExecuteNonQuery(stringBuilder.ToString(), false);
				if (result == false)
				{
					MessageBox.Show("Insert SFT_TRANSORDER fail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}
				else return true;

			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateMODETAIL(FinishedGoodsItems fgItems)", ex.Message);
			}
			return false;
		}
		public bool InsertOrUpdateLOT(FinishedGoodsItems fgItems, DataTable dtLOTMODETAIL)
		{
			try
			{
				CheckExtinctRowInTable checkExtinctRowIn = new CheckExtinctRowInTable();
				var Exstinct = checkExtinctRowIn.CheckExstinctRow(fgItems.productCode, "99");
				if(Exstinct)
				{
					//Update Lot
				var update1=	UpdateLotforFinishedGood(fgItems,dtLOTMODETAIL, "99");
				var update2 =	UpdateLotforFinishedGood(fgItems,dtLOTMODETAIL, "130");
					if( (update1 && update2 )== false)
						SystemLog.Output(SystemLog.MSG_TYPE.War, "InsertLOTForFinishedGoods", "");
					else return true;
				}
				else
				{
					 var insert = InsertLOTForFinishedGoods(fgItems,dtLOTMODETAIL);
					if (insert == false)
						SystemLog.Output(SystemLog.MSG_TYPE.War, "InsertLOTForFinishedGoods", "");
					return true;

				}
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "InserOrUpdateLOT(FinishedGoodsItems fgItems)", ex.Message);
			}
			return false;
		}
		
		public bool UpdateLotforFinishedGood(FinishedGoodsItems fgItems, DataTable dtLOTMODETAIL, string Status)
		{
			try
			{
				StringBuilder stringBuilder = new StringBuilder();

				stringBuilder.Append("update LOT set");
				if(Status =="99")
				{
					stringBuilder.Append("  LOTSIZE =LOTSIZE + " + fgItems.TotalQty + ", ");
					stringBuilder.Append("  PKQTY = PKQTYPER * " + fgItems.TotalQty + " ");
					stringBuilder.Append(" where ID  ='" + fgItems.productCode + "' and STATUS =99");
				}
				else if(Status == "130")
				{
					stringBuilder.Append("  LOTSIZE =LOTSIZE - " + fgItems.TotalQty + ", ");
					stringBuilder.Append("  PKQTY = PKQTYPER * " + fgItems.TotalQty + " ");
					stringBuilder.Append(" where ID  ='" + fgItems.productCode + "' and STATUS =130");
				}
				
				sqlSFT sqlSFT = new sqlSFT();
			var result =	sqlSFT.sqlExecuteNonQuery(stringBuilder.ToString(), false);
				if(result == false)
				{

					MessageBox.Show("Insert SFT_TRANSORDER fail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return false;
				}
				else return true;

			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateLotforFinishedGood(FinishedGoodsItems fgItems, string Status)", ex.Message);
			}
			return false;
		}

		public bool InsertLOTForFinishedGoods(FinishedGoodsItems fgItems, DataTable dtLOTMODETAIL)
		{
			try
			{
				GetdataSFTToDataTable getdataSFTTo = new GetdataSFTToDataTable();

				DataTable dtHeader = getdataSFTTo.GetDataTableFromLot();
				StringBuilder stringBuilder = new StringBuilder();
				StringBuilder stringFun = new StringBuilder();
				stringBuilder.Append(" insert into LOT ( ");
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
						if (dtHeader.Columns[j].ColumnName == "ID")
						{
							valueCell = fgItems.productCode;
						}
						else if (dtHeader.Columns[j].ColumnName == "TYPE")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "MOID")
						{
							valueCell = fgItems.productCode;
						}
						else if (dtHeader.Columns[j].ColumnName == "RELEASEDATETIME")
						{
							valueCell = "NULL";
						}

						else if (dtHeader.Columns[j].ColumnName == "ITEMID")
						{
							valueCell = fgItems.product;//sequence dem len
						}
						else if (dtHeader.Columns[j].ColumnName == "LOTSIZE")
						{
							valueCell = fgItems.TotalQty.ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "STATUS")
						{
							valueCell = "99";
						}
						else if (dtHeader.Columns[j].ColumnName == "ISSUPPLY")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "ISPLANNED")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "UNIT")
						{
							valueCell = dtLOTMODETAIL.Rows[0]["UNIT"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "QTYPER")
						{
							valueCell = "1"; 
						}
						else if (dtHeader.Columns[j].ColumnName == "UNIT")
						{
							valueCell = "PCS"; //In den bo phan nao ??
						}
						else if (dtHeader.Columns[j].ColumnName == "QTYPER")
						{
							valueCell = "1"; //In den bo phan nao ??
						}
						else if (dtHeader.Columns[j].ColumnName == "LOCATION")
						{
							valueCell = "NULL"; //In den bo phan nao ??
						}
						else if (dtHeader.Columns[j].ColumnName == "MO_SEQUENCE")
						{
							valueCell = "0"; //In den bo phan nao ??
						}
						else if (dtHeader.Columns[j].ColumnName == "HEAD_OP_SEQ")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "SUBMITFLAG")
						{
							valueCell = "0";
						}
						else if (dtHeader.Columns[j].ColumnName == "ERP_OPSEQ")
						{
							valueCell = ""; ;
						}
						else if (dtHeader.Columns[j].ColumnName == "ERP_OPID")
						{
							valueCell = "";//A02 lay o dau
						}
						else if (dtHeader.Columns[j].ColumnName == "ERP_WSID")
						{
							valueCell = "";
						}
					
						else if (dtHeader.Columns[j].ColumnName == "LOT004")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "LOT005")
						{
							valueCell = "1";
						}
						else if (dtHeader.Columns[j].ColumnName == "PKQTY")
						{
							valueCell = (fgItems.TotalQty * double.Parse(dtLOTMODETAIL.Rows[0]["PKQTYPER"].ToString())).ToString();//"LOTSIZE*PKQTYPER";
						}
						else if (dtHeader.Columns[j].ColumnName == "PKQTYPER")
						{
							valueCell = dtLOTMODETAIL.Rows[0]["PKQTYPER"].ToString();
						}
						else if (dtHeader.Columns[j].ColumnName == "PKUNIT")
						{
							valueCell = dtLOTMODETAIL.Rows[0]["PKUNIT"].ToString();
						}

						else if (dtHeader.Columns[j].ColumnName == "LOT007")
						{
							valueCell ="0";
						}
						else if (dtHeader.Columns[j].ColumnName == "LOT008")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LOT009")
						{
							valueCell = "";
						}
						else if (dtHeader.Columns[j].ColumnName == "LOT010")
						{
							valueCell = "";
						}

						else if (dtHeader.Columns[j].ColumnName == "LOT011")
						{
							valueCell = "N";
						}

						if (j < dtHeader.Columns.Count - 1)
						{
							if (valueCell == "NULL")
								stringFun.Append(" " + valueCell + " ,");
							else stringFun.Append(" '" + valueCell + "',");
						}
						else stringFun.Append("'" + valueCell + "')");
					}
					string sqlInsert = stringBuilder.ToString() + stringFun.ToString();
					sqlSFT sqlSFT = new sqlSFT();
					if (sqlSFT.sqlExecuteNonQuery(sqlInsert, false) == false)
					{
						MessageBox.Show("Insert LOT fail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
						return false;
					}
					return true;
				}
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, "Insert LOT fail", ex.Message);
			}
			return false;
		}
		public bool SFTdataUpdate(FinishedGoodsItems fgItems,DataTable dtLOTMODETAIL, string TB002, string transno)
		{
			try
			{


				var InsertTransOrder = InsertSFT_Transorder(fgItems, dtLOTMODETAIL, transno, TB002);
				if (InsertTransOrder == false)
				{
					SystemLog.Output(SystemLog.MSG_TYPE.Err, "Upload SFT_Transorder finished", "");
				}

				int Sequence = GgetSequenceCountupSFT_WS_RUN(fgItems.productCode);
				var insertTransOrder_line = InsertSFT_TRANSORDER_LINE(fgItems, dtLOTMODETAIL, transno, TB002, Sequence);
				if (insertTransOrder_line == false)
				{
					SystemLog.Output(SystemLog.MSG_TYPE.Err, "Upload SFT_Transorder_Line finished", "");
				}

				var InsertSFT_WS_Run = InsertSFT_WS_RUN(fgItems, dtLOTMODETAIL, transno, TB002, Sequence.ToString());
				if (InsertSFT_WS_Run == false)
				{
					SystemLog.Output(SystemLog.MSG_TYPE.Err, "Upload InsertSFT_WS_Run finished", "");
				}

				var UpdateModetail = UpdateMODETAIL(fgItems, dtLOTMODETAIL);
				if (UpdateModetail == false)
				{
					SystemLog.Output(SystemLog.MSG_TYPE.Err, "Update modelDetail", "false");
				}

				var InserOrUpdateLOT = InsertOrUpdateLOT(fgItems,dtLOTMODETAIL);
				if(InserOrUpdateLOT == false)
				{
					SystemLog.Output(SystemLog.MSG_TYPE.Err, "InsertOrUpdateLOT(fgItems)", "false");
				}
				if (InsertTransOrder && insertTransOrder_line && InsertSFT_WS_Run && UpdateModetail && InserOrUpdateLOT)
				{
					return true;
				}
			}
			catch (Exception ex)
			{

				SystemLog.Output(SystemLog.MSG_TYPE.Err, " SFTdataUpdate(FinishedGoodsItems fgItems)", ex.Message);
				return false;
			}
			return false;
		}

		public int GgetSequenceCountupSFT_WS_RUN(string ID)
		{
			string sqlQuerry = "select isnull(max(SEQUENCE),'0')+ 1 from SFT_WS_RUN where ID = '" + ID + "' ";
			sqlSFT sqlSFT = new sqlSFT();
			string value = sqlSFT.sqlExecuteScalarString(sqlQuerry);
			if (value != null && value != string.Empty)
				return int.Parse(value);
			else return 0;

		}
	
    }
}
