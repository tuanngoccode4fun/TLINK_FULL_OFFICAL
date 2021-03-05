using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.WMS.Controller
{
  public  class ConvertDataTable
    {
        public DataTable ERPPQCtoSFTTRANSORDERLINE(DataTable ERPPQC, string TranSorder,string TB002, string Location)
        {
            DataTable dt = new DataTable();

            try
            {
            Database.SFT.SFT_TRANSORDER_LINE sFT_TRANSORDER_LINE = new Database.SFT.SFT_TRANSORDER_LINE();
           dt = sFT_TRANSORDER_LINE.GetTop1DataTable();
           if(ERPPQC.Rows.Count > 1)
            {
                for (int i = 1; i < ERPPQC.Rows.Count; i++)
                { var newRow = dt.NewRow();
                    dt.Rows.Add(newRow);
                }
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string PO = ERPPQC.Rows[i]["ProductOrder"].ToString();
                DataTable dtLot = Database.SFT.SFT_LOT.GetDataTableLot(PO);
                DataTable dtMODETAIL = Database.SFT.MODETAIL.GetDataTable(PO);
                var Sequence = GgetSequenceCountupSFT_WS_RUN(PO);
                var ConvertToKg = (double.Parse((ERPPQC.Rows[i]["Quantity"]).ToString()) * double.Parse((dtLot.Rows[0]["PKQTYPER"]).ToString()));
                
                dt.Rows[i]["CREATER"] = Class.valiballecommon.GetStorage().UserName;
                dt.Rows[i]["CREATE_DATE"] = DateTime.Now;
                dt.Rows[i]["MODI_DATE"] = DBNull.Value;
                dt.Rows[i]["FLAG"] = "0";
                dt.Rows[i]["TRANSORDERTYPE"] = Class.valiballecommon.GetStorage().DocNo;
                dt.Rows[i]["TRANSNO"] = TranSorder;
                dt.Rows[i]["SN"] = (i + 1).ToString("0000");
                dt.Rows[i]["MOTYPE"] = ERPPQC.Rows[i]["ProductOrder"].ToString().Trim().Split('-')[0];
                dt.Rows[i]["MONO"] = ERPPQC.Rows[i]["ProductOrder"].ToString().Trim().Split('-')[1];
                dt.Rows[i]["OUTOPSEQ"] = "0020";
                dt.Rows[i]["OUTOP"] = "B02";
                dt.Rows[i]["INOPSEQ"] = "";
                dt.Rows[i]["INOP"] = "";
                dt.Rows[i]["UNIT"] = "PCS";
                dt.Rows[i]["PATTERN"] = "1";
                dt.Rows[i]["SCRAPQTY"] = "0";
                dt.Rows[i]["LABORHOUR"] = "0";
                dt.Rows[i]["MACHINEHOUR"] = "0";
                dt.Rows[i]["OUTDEP"] = "B01";
                dt.Rows[i]["OUTORDERTYPE"] = "";
                dt.Rows[i]["OUTORDERNO"] = "";
                dt.Rows[i]["OUTORDERSEQ"] = "";
                dt.Rows[i]["LOTNO"] = ERPPQC.Rows[i]["LotNo"];
                dt.Rows[i]["EMERGENCY"] = "N";
                dt.Rows[i]["TRANSQTY"] = ERPPQC.Rows[i]["Quantity"];
                dt.Rows[i]["INDEP"] = ERPPQC.Rows[i]["Warehouse"];
                dt.Rows[i]["ITEMID"] = ERPPQC.Rows[i]["Product"];
                dt.Rows[i]["ITEMNAME"] =dtMODETAIL.Rows[0]["MO021"].ToString();
                dt.Rows[i]["ITEMDESCRIPTION"] = dtMODETAIL.Rows[0]["MO022"].ToString();
                dt.Rows[i]["INSTORAGESPACE"] = Location;
                dt.Rows[i]["TC012"] = "";
                dt.Rows[i]["TC017"] = "0";
                dt.Rows[i]["TC018"] = "0";
                dt.Rows[i]["TC015"] = "0";
                dt.Rows[i]["TC019"] = "0";
                dt.Rows[i]["KEYID"] = ERPPQC.Rows[i]["ProductOrder"];
                dt.Rows[i]["PRODUCTIONSEQ"] = "-1";
                dt.Rows[i]["TL002"] = ERPPQC.Rows[i]["Quantity"];
                dt.Rows[i]["TL003"] =0;
                dt.Rows[i]["TL004"] = ConvertToKg;
                dt.Rows[i]["TL005"] = "0";
                dt.Rows[i]["TL006"] = "0";
                dt.Rows[i]["SFTUPDATE"] = "0";
               
                dt.Rows[i]["TL007"] = ConvertToKg ;
                dt.Rows[i]["TL008"] = "0";
                dt.Rows[i]["TL009"] = dtLot.Rows[0]["PKUNIT"];
                dt.Rows[i]["TL010"] = DateTime.Now.Date.ToString("yyyyMMdd");
                dt.Rows[i]["TL011"] = Class.valiballecommon.GetStorage().DocNo;
                dt.Rows[i]["TL012"] = TB002;
                dt.Rows[i]["TL013"] = "N";
                dt.Rows[i]["TL014"] = "";
                dt.Rows[i]["TL015"] = Sequence.ToString();
                dt.Rows[i]["TL016"] = "0";
                dt.Rows[i]["SPC"] = "N";
                dt.Rows[i]["TWINUNIT"] = "Y";
                dt.Rows[i]["KEY_TRANSORDER"] = "1";
                dt.Rows[i]["FACTORYID"] = dtMODETAIL.Rows[0]["FACTORYID"];
                dt.Rows[i]["INWSTYPE"] = "3";
                dt.Rows[i]["OUTWSTYPE"] = "1";
                dt.Rows[i]["TL017"] = "0";
                dt.Rows[i]["TL018"] = "1";
                dt.Rows[i]["TL019"] = DBNull.Value;
                dt.Rows[i]["TL020"] = DBNull.Value;
                dt.Rows[i]["TL023"] = "0";
                dt.Rows[i]["TL024"] = "0";
                dt.Rows[i]["TL025"] = "0";
                dt.Rows[i]["TL027"] = "0";
            }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ERPPQCtoSFTTRANSORDERLINE(DataTable ERPPQC, string TranSorder,string TB002, string Location)", ex.Message);
                dt = new DataTable();
            }
            return dt;
        }
       public DataTable GetDataSFTTRANSORDER(DataTable ERPPQC, DataTable TRANSORDERLINE)
        {
           
            DataTable dt = new DataTable();
            try
            {

            Database.SFT.SFT_TRANSORDER sFT_TRANSORDER = new Database.SFT.SFT_TRANSORDER();
            dt = sFT_TRANSORDER.GetTop1DataTable();
            Database.GetListWarehouse getListWarehouse = new Database.GetListWarehouse();
            List<Database.WarehouseItems> listWarehouse = getListWarehouse.GetWarehouseOnly();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["CREATER"] = Class.valiballecommon.GetStorage().UserName;
                dt.Rows[i]["CREATE_DATE"] = DateTime.Now;
                dt.Rows[i]["MODI_DATE"] = DBNull.Value;
                dt.Rows[i]["FLAG"] = 0;
                dt.Rows[i]["TRANSTYPE"] = TRANSORDERLINE.Rows[0]["TRANSORDERTYPE"];
                dt.Rows[i]["TRANSNO"] = TRANSORDERLINE.Rows[0]["TRANSNO"];
                dt.Rows[i]["TRANSDATE"] = DateTime.Now.ToString("yyyyMMdd");
                dt.Rows[i]["OUTTYPE"] = "1";
                dt.Rows[i]["OUTDEPID"] = TRANSORDERLINE.Rows[0]["OUTDEP"];
                dt.Rows[i]["OUTDEPNAME"] = "胶管OEM生产线ONGOEM";
                dt.Rows[i]["INTYPE"] = "3";
                dt.Rows[i]["INDEPID"] = TRANSORDERLINE.Rows[0]["INDEP"];
                dt.Rows[i]["INDEPNAME"] = listWarehouse.Where(d => d.MC001_Wh.Contains(TRANSORDERLINE.Rows[0]["INDEP"].ToString())).Select(d => d.MC002_WhName).ToList()[0]; 
                dt.Rows[i]["FACTORYID"] = TRANSORDERLINE.Rows[0]["FACTORYID"];
                dt.Rows[i]["CONFIRMCODE"] = "Y";
                dt.Rows[i]["DOCUMENTDATE"] = DateTime.Now.ToString("yyyyMMdd");
                dt.Rows[i]["VENDORNO"] = "";
                dt.Rows[i]["INVOICECOUNT"] = 1;
                dt.Rows[i]["TAXATIONTYPE"] = 1;
                dt.Rows[i]["DISCOUNTDEVIDE"] = 1;
                dt.Rows[i]["DECLARATIONDATE"] = DateTime.Now.ToString("yyyyMM");
                dt.Rows[i]["SALESTAXRATE"] = 0.2;
                dt.Rows[i]["COMPANYID"] = "TLVN2";// qua serverchinh co the phai doi
                dt.Rows[i]["KEYID"] = TRANSORDERLINE.Rows[0]["KEYID"];
                dt.Rows[i]["STOCKINTYPE"] = 1;
                dt.Rows[i]["TO001"] = 1;
                dt.Rows[i]["TO007"] = TRANSORDERLINE.Rows[0]["TL011"];
                dt.Rows[i]["TO008"] = TRANSORDERLINE.Rows[0]["TL012"];
                dt.Rows[i]["TO011"] = 0;
                dt.Rows[i]["TO012"] = 0;
                dt.Rows[i]["COINSTYPE"] = "VND";
                dt.Rows[i]["CONFIRMER"] = Class.valiballecommon.GetStorage().UserName;
                dt.Rows[i]["TO013"] = 1;
                dt.Rows[i]["TO014"] = DBNull.Value;
                dt.Rows[i]["TO015"] = DBNull.Value;

                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, " public DataTable GetDataSFTTRANSORDER(DataTable ERPPQC, DataTable TRANSORDERLINE)", ex.Message);
                dt = new DataTable();
            }
            return dt;
        }
        public DataTable GetDataTableSFT_WS_RUN(DataTable ERPPQC, DataTable dtTranSorder_LINE)
        {
            DataTable dt = new DataTable();
            try
            {

                Database.SFT.SFT_WS_RUN sFT_WS_RUN = new Database.SFT.SFT_WS_RUN();
                dt = sFT_WS_RUN.GetTop1DataTable();
                if (ERPPQC.Rows.Count > 1)
                {
                    for (int i = 1; i < ERPPQC.Rows.Count; i++)
                    {
                        var newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                    }
                }
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string PO = ERPPQC.Rows[i]["ProductOrder"].ToString();
                    DataTable dtLot = Database.SFT.SFT_LOT.GetDataTableLot(PO);
                    dt.Rows[i]["WSID"] = "B01";
                    dt.Rows[i]["OPID"] = "B02---B01";
                    dt.Rows[i]["ID"] = ERPPQC.Rows[i]["ProductOrder"].ToString();
                    var Sequence = GgetSequenceCountupSFT_WS_RUN(ERPPQC.Rows[i]["ProductOrder"].ToString());
                    dt.Rows[i]["SEQUENCE"] = Sequence;
                    dt.Rows[i]["EXECUTENAME"] = "";
                    dt.Rows[i]["EXECUTETIME"] = DateTime.Now;
                    dt.Rows[i]["EXECUTETYPE"] = "IntoWH";
                    dt.Rows[i]["ROUTESEQUENCE"] = DBNull.Value;
                    dt.Rows[i]["STEPSEQUENCE"] = DBNull.Value;
                    dt.Rows[i]["ALTSTEPSEQUENCE"] = DBNull.Value;
                    dt.Rows[i]["OPSEQUENCE"] = DBNull.Value;
                    dt.Rows[i]["EXECUTEQTY"] = ERPPQC.Rows[i]["Quantity"] ;
                    dt.Rows[i]["USERID"] = Class.valiballecommon.GetStorage().UserName;
                    dt.Rows[i]["QTYPERUNIT"] = 0;
                    dt.Rows[i]["UNIT"] = dtTranSorder_LINE.Rows[i]["UNIT"].ToString();
                    dt.Rows[i]["QTYPER"] = 1;
                    dt.Rows[i]["PLUSINDEX"] = "0";
                    dt.Rows[i]["ERP_OPSEQ"] = "0020";
                    dt.Rows[i]["ERP_OPID"] = "B02";
                    dt.Rows[i]["ERP_WSID"] = "B01";
                    dt.Rows[i]["PKQTY"] = dtTranSorder_LINE.Rows[i]["TL007"];//kHOI LUONG 
                    dt.Rows[i]["PKQTYPER"] = dtLot.Rows[0]["PKQTYPER"];
                    dt.Rows[i]["PKUNIT"] = dtTranSorder_LINE.Rows[i]["TL009"];
                    dt.Rows[i]["WR001"] = -1;
                    dt.Rows[i]["WR002"] = dtTranSorder_LINE.Rows[i]["TL011"]+"-"+ dtTranSorder_LINE.Rows[i]["TL012"];
                    dt.Rows[i]["WR003"] = (i+1).ToString("0000");
                    dt.Rows[i]["WR004"] = ERPPQC.Rows[i]["Quantity"];
                    dt.Rows[i]["WR005"] = ERPPQC.Rows[i]["Quantity"];
                    dt.Rows[i]["WR006"] = 0;
                    dt.Rows[i]["WR007"] = "";
                    dt.Rows[i]["WR008"] = "";
                    dt.Rows[i]["WR009"] = "";
                    dt.Rows[i]["WR010"] = 0;
                    dt.Rows[i]["WR011"] = 0;
                    dt.Rows[i]["WR014"] = 1;
                    dt.Rows[i]["WR015"] = 1;
                    dt.Rows[i]["WR016"] = 0;
                    dt.Rows[i]["WR017"] = DBNull.Value;
                    dt.Rows[i]["WR018"] = DBNull.Value;
                    dt.Rows[i]["WR019"] = DBNull.Value;
                    dt.Rows[i]["WR023"] = DBNull.Value;
                    dt.Rows[i]["WR026"] = DBNull.Value;
                    dt.Rows[i]["CREATE_DATE"] = DateTime.Now;
                    dt.Rows[i]["WR029"] = "1";
                    dt.Rows[i]["WR030"] = 1;
                    dt.Rows[i]["WR031"] = 0;
                    dt.Rows[i]["WR032"] = 0;

                    dt.Rows[i]["WR036"] = 0;

                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, " public DataTable GetDataSFTTRANSORDER(DataTable ERPPQC, DataTable TRANSORDERLINE)", ex.Message);
                dt = new DataTable();
            }
            return dt;
        }
        public DataTable GetDataTableSFT_WS_RUNPendingWH(DataTable ERPPQC )
        {
            DataTable dt = new DataTable();
            int[] OutSequence = new int[ERPPQC.Rows.Count]; 
            try
            {

                Database.SFT.SFT_WS_RUN sFT_WS_RUN = new Database.SFT.SFT_WS_RUN();
                dt = sFT_WS_RUN.GetTop1DataTable();
                if (ERPPQC.Rows.Count > 1)
                {
                    for (int i = 1; i < ERPPQC.Rows.Count; i++)
                    {
                        var newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                    }
                }
               
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string PO = ERPPQC.Rows[i]["ProductOrder"].ToString();
                    DataTable dtLot = Database.SFT.SFT_LOT.GetDataTableLot(PO);
                    dt.Rows[i]["WSID"] = "B01";
                    dt.Rows[i]["OPID"] = "B02---B01";
                    dt.Rows[i]["ID"] = ERPPQC.Rows[i]["ProductOrder"].ToString();
                    var Sequence = GgetSequenceCountupSFT_WS_RUN(ERPPQC.Rows[i]["ProductOrder"].ToString());
                    OutSequence[i] = Sequence;
                    dt.Rows[i]["SEQUENCE"] = Sequence;
                    dt.Rows[i]["EXECUTENAME"] = "";
                    dt.Rows[i]["EXECUTETIME"] = DateTime.Now;
                    dt.Rows[i]["EXECUTETYPE"] = "IntoStockIn";
                    dt.Rows[i]["ROUTESEQUENCE"] = DBNull.Value;
                    dt.Rows[i]["STEPSEQUENCE"] = DBNull.Value;
                    dt.Rows[i]["ALTSTEPSEQUENCE"] = DBNull.Value;
                    dt.Rows[i]["OPSEQUENCE"] = DBNull.Value;
                    dt.Rows[i]["EXECUTEQTY"] = ERPPQC.Rows[i]["Quantity"];
                    dt.Rows[i]["USERID"] = Class.valiballecommon.GetStorage().UserName;
                    dt.Rows[i]["QTYPERUNIT"] = 0;
                    dt.Rows[i]["UNIT"] = dtLot.Rows[0]["UNIT"].ToString();
                    dt.Rows[i]["QTYPER"] = 1;
                    dt.Rows[i]["PLUSINDEX"] = "0";
                    dt.Rows[i]["ERP_OPSEQ"] = "0020";
                    dt.Rows[i]["ERP_OPID"] = "B02";
                    dt.Rows[i]["ERP_WSID"] = "B01";
                    dt.Rows[i]["PKQTY"] = double.Parse(ERPPQC.Rows[i]["Quantity"].ToString())* double.Parse(dtLot.Rows[0]["PKQTYPER"].ToString());
                    dt.Rows[i]["PKQTYPER"] = dtLot.Rows[0]["PKQTYPER"];
                    dt.Rows[i]["PKUNIT"] = dtLot.Rows[0]["PKUNIT"];
                    dt.Rows[i]["WR001"] = -1;
                    dt.Rows[i]["WR002"] = "";
                    dt.Rows[i]["WR003"] = DBNull.Value;
                    dt.Rows[i]["WR004"] = ERPPQC.Rows[i]["Quantity"];
                    dt.Rows[i]["WR005"] = ERPPQC.Rows[i]["Quantity"];
                    dt.Rows[i]["WR006"] = 0;
                    dt.Rows[i]["WR007"] = "0020";
                    dt.Rows[i]["WR008"] = "B02";
                    dt.Rows[i]["WR009"] = "B01";
                    dt.Rows[i]["WR010"] = 0;
                    dt.Rows[i]["WR011"] = 0;
                    //dt.Rows[i]["WR013"] = -1;
                    dt.Rows[i]["WR014"] = 1;
                    dt.Rows[i]["WR015"] = 1;
                    dt.Rows[i]["WR016"] = 0;
                    dt.Rows[i]["WR017"] = DBNull.Value;
                    dt.Rows[i]["WR018"] = DBNull.Value;
                    dt.Rows[i]["WR019"] = DBNull.Value;
                    dt.Rows[i]["WR021"] = Class.valiballecommon.GetStorage().UserName;
                    dt.Rows[i]["WR023"] = DBNull.Value;
                    dt.Rows[i]["CREATE_DATE"] = DateTime.Now;
                    dt.Rows[i]["WR029"] = "1";
                    dt.Rows[i]["WR030"] = 1;
                    dt.Rows[i]["WR031"] = 0;
                    dt.Rows[i]["WR032"] = 0;
                    dt.Rows[i]["WR036"] = 0;

                }
               
            }
            catch (Exception ex)
            {
               
                SystemLog.Output(SystemLog.MSG_TYPE.Err, " public DataTable GetDataSFTTRANSORDER(DataTable ERPPQC, DataTable TRANSORDERLINE)", ex.Message);
                dt = new DataTable();
            }
            return dt;
        }
        public DataTable GetDataTableLOT(DataRow dtTransOrderLine,int status)
        {
            DataTable dt = new DataTable();
            try
            {
                string PO = dtTransOrderLine["KEYID"].ToString();
                 dt = Database.SFT.SFT_LOT.GetDataTableLot(PO);
              if(dt.Rows.Count ==1)
                {
                    dt.Rows[0]["LOTSIZE"] = dtTransOrderLine["TRANSQTY"];
                    if (status == 99)
                    {
                        dt.Rows[0]["STATUS"] = status;
                        dt.Rows[0]["ERP_OPSEQ"] = "";
                        dt.Rows[0]["ERP_OPID"] = "";
                        dt.Rows[0]["ERP_WSID"] = "";
                    }
                    else if(status == 130)
                    {
                        dt.Rows[0]["STATUS"] = status;
                        dt.Rows[0]["ERP_OPSEQ"] = "0020";
                        dt.Rows[0]["ERP_OPID"] = "B02";
                        dt.Rows[0]["ERP_WSID"] = "B01";
                    }
                    dt.Rows[0]["ISSUPPLY"] = 1;
                    dt.Rows[0]["ISPLANNED"] = 1;
                    dt.Rows[0]["LOT004"] = 1;
                    dt.Rows[0]["LOT005"] = 1;
                    dt.Rows[0]["LOT005"] = 1;
                    dt.Rows[0]["PKQTY"] =double.Parse( dt.Rows[0]["PKQTYPER"].ToString())*double.Parse(dtTransOrderLine["TRANSQTY"].ToString());
                    dt.Rows[0]["QTIME1"] = DBNull.Value;
                    dt.Rows[0]["QTIME2"] = DBNull.Value;
                    dt.Rows[0]["QTIME3"] = DBNull.Value;
                    dt.Rows[0]["QTIME4"] = DBNull.Value;
                    dt.Rows[0]["QTIME5"] = DBNull.Value;
                    dt.Rows[0]["QTIME6"] = DBNull.Value;
                    dt.Rows[0]["QTIME7"] = DBNull.Value;
                    dt.Rows[0]["QTIME8"] = DBNull.Value;
                    dt.Rows[0]["LASTMAINTAINDATETIME"] = DBNull.Value;
                    dt.Rows[0]["DUEDATETIME"] = DBNull.Value;
                    dt.Rows[0]["RELEASEDATETIME"] = DBNull.Value;
                }

            }
           
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "DataTable GetDataTableLOT(DataTable ERPPQC,DataTable TRansOrderLine)", ex.Message);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable GetDataTableLOTbyERP(DataRow dtERPPQC, int status)
        {
            DataTable dt = new DataTable();
            try
            {
                string PO = dtERPPQC["ProductOrder"].ToString();
                dt = Database.SFT.SFT_LOT.GetDataTableLot(PO);
                if (dt.Rows.Count == 1)
                {
                    dt.Rows[0]["LOTSIZE"] = dtERPPQC["Quantity"];
                    if (status == 99)
                    {
                        dt.Rows[0]["STATUS"] = status;
                        dt.Rows[0]["ERP_OPSEQ"] = "";
                        dt.Rows[0]["ERP_OPID"] = "";
                        dt.Rows[0]["ERP_WSID"] = "";
                    }
                    else if (status == 130)
                    {
                        dt.Rows[0]["STATUS"] = status;
                        dt.Rows[0]["ERP_OPSEQ"] = "0020";
                        dt.Rows[0]["ERP_OPID"] = "B02";
                        dt.Rows[0]["ERP_WSID"] = "B01";
                    }
                    dt.Rows[0]["ISSUPPLY"] = 1;
                    dt.Rows[0]["ISPLANNED"] = 1;
                    dt.Rows[0]["LOT004"] = 1;
                    dt.Rows[0]["LOT005"] = 1;
                    dt.Rows[0]["LOT005"] = 1;
                    dt.Rows[0]["PKQTY"] = double.Parse(dt.Rows[0]["PKQTYPER"].ToString()) * double.Parse(dtERPPQC["Quantity"].ToString());
                    dt.Rows[0]["QTIME1"] = DBNull.Value;
                    dt.Rows[0]["QTIME2"] = DBNull.Value;
                    dt.Rows[0]["QTIME3"] = DBNull.Value;
                    dt.Rows[0]["QTIME4"] = DBNull.Value;
                    dt.Rows[0]["QTIME5"] = DBNull.Value;
                    dt.Rows[0]["QTIME6"] = DBNull.Value;
                    dt.Rows[0]["QTIME7"] = DBNull.Value;
                    dt.Rows[0]["QTIME8"] = DBNull.Value;
                    dt.Rows[0]["LASTMAINTAINDATETIME"] = DBNull.Value;
                    dt.Rows[0]["DUEDATETIME"] = DBNull.Value;
                    dt.Rows[0]["RELEASEDATETIME"] = DBNull.Value;
                }

            }

            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "DataTable GetDataTableLOT(DataTable ERPPQC,DataTable TRansOrderLine)", ex.Message);
                dt = new DataTable();
            }
            return dt;
        }
        public DataTable ConvertToREALRUN(DataRow ERPPQC, int ws_sequence)
        {
            DataTable dt = new DataTable();
            try
            {
                dt = Database.SFT.SFT_OP_REALRUN.GetDataTableSFT_OP_REALRUN();
                
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string PO = ERPPQC["ProductOrder"].ToString();
                    DataTable dtLot = Database.SFT.SFT_LOT.GetDataTableLot(PO);
                    dt.Rows[i]["ID"] = ERPPQC["ProductOrder"];
                    dt.Rows[i]["SEQUENCE"] = Database.SFT.SFT_OP_REALRUN.GetSequenceInSFT_OP_REALRUN(ERPPQC["ProductOrder"].ToString().Trim(),"0020", "B02", "B01");
                    dt.Rows[i]["OPID"] = "B02---B01";
                    dt.Rows[i]["EQID"] = "";
                    dt.Rows[i]["ROUTESEQUENCE"] =DBNull.Value;
                    dt.Rows[i]["STEPSEQUENCE"] = DBNull.Value;
                    dt.Rows[i]["ALTSTEPSEQUENCE"] = DBNull.Value;
                    dt.Rows[i]["OPSEQUENCE"] = DBNull.Value;
                   
                    dt.Rows[i]["STARTQTY"] = 0;
                    dt.Rows[i]["ENDQTY"] = 0;
                    dt.Rows[i]["ARRIVEQTY"] = 0;
                    dt.Rows[i]["OUTQTY"] = ERPPQC["Quantity"];
                    dt.Rows[i]["ARRIVETIME"] = DBNull.Value;
                    dt.Rows[i]["STARTTIME"] = DBNull.Value;
                    dt.Rows[i]["ENDTIME"] = DBNull.Value;
                    dt.Rows[i]["OUTTIME"] = DateTime.Now;
                    dt.Rows[i]["REWORKQTY"] = 0;
                    dt.Rows[i]["ALERADYDEFECTQTY"] = 0;
                    dt.Rows[i]["DEFECTQTY"] = 0;
                    dt.Rows[i]["UNKNOWQTY"] = 0;
                    dt.Rows[i]["SURPLUSQTY"] = 0;
                    dt.Rows[i]["REPORTQTY"] = DBNull.Value;
                    dt.Rows[i]["FINISHRATE"] = 0;
                    dt.Rows[i]["OPERID"] = Class.valiballecommon.GetStorage().UserName;
                    dt.Rows[i]["UNIT"] = "";
                    dt.Rows[i]["QTYPER"] = 0;
                    dt.Rows[i]["ALTOPLIMITQTY"] = 0;
                    dt.Rows[i]["OUTUNIT"] =dtLot.Rows[0]["UNIT"];
                    dt.Rows[i]["OUTQTYPER"] = dtLot.Rows[0]["QTYPER"];
                    dt.Rows[i]["ERP_OPSEQ"] = "0020";
                    dt.Rows[i]["MANWORKTIME"] = 0 ;
                    dt.Rows[i]["EQWORKTIME"] = 0;
                    dt.Rows[i]["PERLOTWORKTIME"] = 1;
                    dt.Rows[i]["ERP_TRANSQTY"] = 1;
                    dt.Rows[i]["ERP_FIXEDLEADTIME"] = 0;
                    dt.Rows[i]["ERP_VARIABLELEADTIME"] = 0;
                    dt.Rows[i]["COINSTYPE"] = "VND";
                    dt.Rows[i]["STANDARDEQWORKTIME"] = 0;
                    dt.Rows[i]["STANDARDMANWORKTIME"] = 0;
                    dt.Rows[i]["COMPLEXION"] = "1";
                    dt.Rows[i]["TA019"] =1;
                    dt.Rows[i]["TA032"] = "N";
                    dt.Rows[i]["TA038"] = 0;

                    dt.Rows[i]["TA046"] = "";
                    dt.Rows[i]["TA047"] = 0;
                    dt.Rows[i]["TA048"] = 0;
                    dt.Rows[i]["TOID"] = "";
                    dt.Rows[i]["TOSN"] = "";
                    dt.Rows[i]["PRODUCTION_REPORTID"] = "";
                    dt.Rows[i]["PRODUCTION_REPORTSN"] = "";
                    dt.Rows[i]["REPORTSTOCKIN"] = 1;
                    dt.Rows[i]["TB053"] = 0;
                    dt.Rows[i]["TB054"] = 0;
                    dt.Rows[i]["TB055"] = 0;
                    dt.Rows[i]["TB060"] = 0;
                    dt.Rows[i]["TB061"] = "";
                    dt.Rows[i]["TB062"] = "";
                    dt.Rows[i]["TB063"] = "";
                    dt.Rows[i]["TB067"] = "";
                    dt.Rows[i]["TB066"] = 0;
                    dt.Rows[i]["TB068"] = 0;
                    dt.Rows[i]["TB069"] = "";
                    dt.Rows[i]["TB070"] = 0;
                    dt.Rows[i]["TB086"] = 0;
                    dt.Rows[i]["TB087"] = 0;
                    dt.Rows[i]["TB088"] = 0;
                    dt.Rows[i]["ERP_OPID"] = "B02";
                    dt.Rows[i]["ERP_WSID"] = "B01";

                    dt.Rows[i]["OR001"] = -1;
                    dt.Rows[i]["OR002"] = "";
                    dt.Rows[i]["OR003"] = "";
                    dt.Rows[i]["OR004"] = "";
                    dt.Rows[i]["OR006"] = 0;
                    dt.Rows[i]["OR007"] = 0;
                    dt.Rows[i]["OR008"] = 0;
                    dt.Rows[i]["OR009"] = 0;
                    dt.Rows[i]["OR012"] = DBNull.Value;
                    dt.Rows[i]["OR013"] = ws_sequence;
                    dt.Rows[i]["OR014"] = Class.valiballecommon.GetStorage().UserName;
                    dt.Rows[i]["OR015"] = 1;
                    dt.Rows[i]["OR016"] = 1;
                    dt.Rows[i]["OR017"] = 0;
                    dt.Rows[i]["OR024"] = 1;
                    dt.Rows[i]["OR025"] = "N";
                    dt.Rows[i]["OR026"] = "N";
                    dt.Rows[i]["OR027"] = "N";
                    dt.Rows[i]["OR028"] = "N";
                    dt.Rows[i]["OR031"] = 1;
                    dt.Rows[i]["OR032"] = 1;
                    dt.Rows[i]["OR033"] = 1;
                    dt.Rows[i]["OR036"] = 0;
                    dt.Rows[i]["OR037"] = 0;
                    dt.Rows[i]["OR045"] = "";
                    dt.Rows[i]["OR046"] = 0;
                    dt.Rows[i]["OR047"] = "";
                    dt.Rows[i]["OR044"] = 0;
                    dt.Rows[i]["OR048"] = 0;
                    dt.Rows[i]["OR049"] = 0;
                    dt.Rows[i]["OR050"] = "";
                     dt.Rows[i]["OR051"] = "";
                    dt.Rows[i]["OR052"] = 0;
                    dt.Rows[i]["OR053"] = 0;
                    dt.Rows[i]["OR055"] = "N";

                    dt.Rows[i]["PKQTYPER"] = dtLot.Rows[0]["PKQTYPER"];
                    dt.Rows[i]["PKQTY"] =double.Parse( dtLot.Rows[0]["PKQTYPER"].ToString())*double.Parse(ERPPQC["Quantity"].ToString());
                    dt.Rows[i]["PKUNIT"] = dtLot.Rows[0]["PKUNIT"];
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ConvertToREALRUN(DataTable dtERPPQC)", ex.Message);
                dt = new DataTable();
            }
            return dt;
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
