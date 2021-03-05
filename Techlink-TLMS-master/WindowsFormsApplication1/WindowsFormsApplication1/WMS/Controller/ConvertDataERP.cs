using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows;

namespace WindowsFormsApplication1.WMS.Controller
{
  public  class ConvertDataERP
    {
        public DataTable GetDataTableSFCTC(DataTable ERPPQC, string TB002,string confirm)
        {
            DataTable dt = new DataTable();
            try
            {

            dt = Database.SFC.SFCTC.GetTop1DataTable();
            if (ERPPQC.Rows.Count > 1)
            {
                for (int i = 1; i < ERPPQC.Rows.Count; i++)
                {
                    var newRow = dt.NewRow();
                    dt.Rows.Add(newRow);
                }
            }
            Database.ADMMFUpdate aDMMF = new Database.ADMMFUpdate();
            DataTable dtADMMF = aDMMF.GetDtADMFFByUser(Class.valiballecommon.GetStorage().UserName);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["COMPANY"] = dtADMMF.Rows[0]["COMPANY"];
                dt.Rows[i]["CREATOR"] = Class.valiballecommon.GetStorage().UserName;
                dt.Rows[i]["USR_GROUP"] = dtADMMF.Rows[0]["MF004"].ToString();
                dt.Rows[i]["CREATE_DATE"] = DateTime.Now.ToString("yyyyMMdd");
                dt.Rows[i]["MODIFIER"] = DBNull.Value;
                dt.Rows[i]["MODI_DATE"] = DBNull.Value;
                dt.Rows[i]["FLAG"] = 1;
                dt.Rows[i]["CREATE_TIME"] = DateTime.Now.ToString("HH:mm:ss");
                dt.Rows[i]["CREATE_AP"] = "SFT";
                dt.Rows[i]["CREATE_PRID"] = "SFT";
                dt.Rows[i]["MODI_TIME"] = DBNull.Value;
                dt.Rows[i]["MODI_AP"] = DBNull.Value;
                dt.Rows[i]["MODI_PRID"] = DBNull.Value;

                dt.Rows[i]["TC001"] = Class.valiballecommon.GetStorage().DocNo;
                dt.Rows[i]["TC002"] = TB002;
                dt.Rows[i]["TC003"] = (i + 1).ToString("0000");
                dt.Rows[i]["TC004"] = ERPPQC.Rows[i]["ProductOrder"].ToString().Trim().Split('-')[0];
                dt.Rows[i]["TC005"] = ERPPQC.Rows[i]["ProductOrder"].ToString().Trim().Split('-')[1];
                dt.Rows[i]["TC006"] = "0020";
                DataTable dtSFCTA = Database.SFC.SFCTA.GetDataTableSFCTA(ERPPQC.Rows[i]["ProductOrder"].ToString());/// 
                if (dtSFCTA.Rows.Count == 0)
                {
                        MessageBox.Show("dtSFCTA =" + dtSFCTA.Rows.Count.ToString());
                }
                else
                {
                        dt.Rows[i]["TC007"] = dtSFCTA.Rows[0]["TA004"].ToString();
                        dt.Rows[i]["TC010"] = dtSFCTA.Rows[0]["TA020"].ToString();
                        dt.Rows[i]["TC023"] = dtSFCTA.Rows[0]["TA006"].ToString();
                    }
                dt.Rows[i]["TC008"] = "";
                dt.Rows[i]["TC009"] = "";
                //dt.Rows[i]["TC010"] = dtSFCTA.Rows[0]["TA020"].ToString();
                    dt.Rows[i]["TC011"] = DBNull.Value;
                    dt.Rows[i]["TC012"] = DBNull.Value;
                    dt.Rows[i]["TC013"] = "1";
                dt.Rows[i]["TC014"] = ERPPQC.Rows[i]["Quantity"];
                dt.Rows[i]["TC015"] = 0;
                dt.Rows[i]["TC016"] = 0;
                dt.Rows[i]["TC017"] = 0;
                dt.Rows[i]["TC018"] = 0;
                dt.Rows[i]["TC019"] = 0;
                dt.Rows[i]["TC020"] = 0;
                dt.Rows[i]["TC021"] = 0;
                dt.Rows[i]["TC022"] = confirm;
                //dt.Rows[i]["TC023"] = dtSFCTA.Rows[0]["TA006"].ToString();
                dt.Rows[i]["TC024"] = DBNull.Value;
                dt.Rows[i]["TC025"] = 0;
                dt.Rows[i]["TC026"] = "N";
                dt.Rows[i]["TC027"] = "N";
                    dt.Rows[i]["TC028"] = DBNull.Value;
                    dt.Rows[i]["TC029"] = DBNull.Value;
                    dt.Rows[i]["TC030"] = DBNull.Value;
                    dt.Rows[i]["TC031"] = DBNull.Value;
                    dt.Rows[i]["TC032"] = ERPPQC.Rows[i]["LotNo"].ToString().Trim();
                    int ExpireDay = Database.INV.INVMB.ExpireDaybyProduct(ERPPQC.Rows[i]["Product"].ToString().Trim());
                    int ExpireDay2 = Database.INV.INVMB.ExpireDayInspectbyProduct(ERPPQC.Rows[i]["Product"].ToString().Trim());
                    dt.Rows[i]["TC033"] = DateTime.Now.AddDays(ExpireDay).ToString("yyyyMMdd");
                    dt.Rows[i]["TC034"] = DateTime.Now.AddDays(ExpireDay2).ToString("yyyyMMdd");
                    dt.Rows[i]["TC035"] = "N";
                dt.Rows[i]["TC036"] = ERPPQC.Rows[i]["Quantity"];
                dt.Rows[i]["TC037"] = "0";
                dt.Rows[i]["TC038"] = DateTime.Now.ToString("yyyyMMdd");
                dt.Rows[i]["TC039"] = 0; 
                dt.Rows[i]["TC041"] = ERPPQC.Rows[i]["Warehouse"].ToString().Trim();
                
                //DataTable dtLot = Database.SFT.SFT_LOT.GetDataTableLot(ERPPQC.Rows[i]["ProductOrder"].ToString());
               // dt.Rows[i]["TC042"] = (double.Parse(ERPPQC.Rows[i]["Quantity"].ToString()))*(double.Parse(dtLot.Rows[0]["PKQTYPER"].ToString()));
                //dt.Rows[i]["TC043"] = (double.Parse(ERPPQC.Rows[i]["Quantity"].ToString())) * (double.Parse(dtLot.Rows[0]["PKQTYPER"].ToString()));
                dt.Rows[i]["TC044"] = 0;
                dt.Rows[i]["TC045"] = 0;
                dt.Rows[i]["TC046"] = 0;
                dt.Rows[i]["TC047"] = ERPPQC.Rows[i]["Product"].ToString().Trim();
               /*     DataTable dtINVMB = Database.INV.INVMB.GetDatabyProduct(ERPPQC.Rows[i]["Product"].ToString().Trim());
                dt.Rows[i]["TC048"] = dtINVMB.Rows[0]["MB002"].ToString();
                    dt.Rows[i]["TC049"] = dtINVMB.Rows[0]["MB003"].ToString();*/ //Temporate ignore wait confirm.
                   // dt.Rows[i]["TC050"] = dtLot.Rows[0]["PKUNIT"].ToString();
                    dt.Rows[i]["TC051"] = 0;
                dt.Rows[i]["TC052"] = ERPPQC.Rows[i]["Location"].ToString();//add tuanngoc;
                dt.Rows[i]["TC053"] = 0;
                dt.Rows[i]["TC054"] = 0;
                dt.Rows[i]["TC055"] = "N";
                  
                    dt.Rows[i]["TC056"] = DBNull.Value;
                    dt.Rows[i]["TC057"] = DBNull.Value;
                    dt.Rows[i]["TC058"] = DBNull.Value;
                    dt.Rows[i]["TC059"] = DBNull.Value;
                    dt.Rows[i]["TC060"] = 0;
                dt.Rows[i]["UDF06"] = 0;
                dt.Rows[i]["UDF07"] = 0;
                dt.Rows[i]["UDF08"] = 0;
                dt.Rows[i]["UDF09"] = 0;
                dt.Rows[i]["UDF10"] = 0;
            }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataTableSFCTC", ex.Message);
            }

            return dt;
        }
        public DataTable GetDataTableSFCTB(DataTable dtSFCTC, DataTable ERPPQC, string TransNo, string Confirm)
        {
            DataTable dt = new DataTable();
            try
            {

            dt = Database.SFC.SFCTB.GetTop1DataTable();
            Database.ADMMFUpdate aDMMF = new Database.ADMMFUpdate();
            DataTable dtADMMF = aDMMF.GetDtADMFFByUser(Class.valiballecommon.GetStorage().UserName);
            Database.GetListWarehouse getListWarehouse = new Database.GetListWarehouse();
            List<Database.WarehouseItems> listWarehouse = getListWarehouse.GetWarehouseOnly();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                dt.Rows[i]["COMPANY"] = dtADMMF.Rows[0]["COMPANY"];
                dt.Rows[i]["CREATOR"] = Class.valiballecommon.GetStorage().UserName;
                dt.Rows[i]["USR_GROUP"] = dtADMMF.Rows[0]["MF004"].ToString();
                dt.Rows[i]["CREATE_DATE"] = DateTime.Now.ToString("yyyyMMdd");
                dt.Rows[i]["MODIFIER"] = DBNull.Value;
                dt.Rows[i]["MODI_DATE"] = DBNull.Value;
                dt.Rows[i]["FLAG"] = 1;
                dt.Rows[i]["CREATE_TIME"] = DateTime.Now.ToString("HH:mm:ss");
                dt.Rows[i]["CREATE_AP"] = "SFT";
                dt.Rows[i]["CREATE_PRID"] = "SFT";
                dt.Rows[i]["MODI_TIME"] = DBNull.Value;
                dt.Rows[i]["MODI_AP"] = DBNull.Value;
                dt.Rows[i]["MODI_PRID"] = DBNull.Value;
                dt.Rows[i]["TB001"] = dtSFCTC.Rows[0]["TC001"];
                dt.Rows[i]["TB002"] = dtSFCTC.Rows[0]["TC002"];
                dt.Rows[i]["TB003"] = DateTime.Now.ToString("yyyyMMdd");
                dt.Rows[i]["TB004"] = "1";
                dt.Rows[i]["TB005"] = "B01";
                dt.Rows[i]["TB006"] = "?管OEM生??ONGOEM";
                dt.Rows[i]["TB007"] = "3";
                dt.Rows[i]["TB008"] = ERPPQC.Rows[0]["Warehouse"].ToString().Trim();
                dt.Rows[i]["TB009"] = listWarehouse.Where(d => d.MC001_Wh.Contains(ERPPQC.Rows[0]["Warehouse"].ToString())).Select(d => d.MC002_WhName).ToList()[0];
                dt.Rows[i]["TB010"] = "TL";
                dt.Rows[i]["TB011"] = 0;
                dt.Rows[i]["TB012"] = "N";
                dt.Rows[i]["TB013"] = Confirm;
                dt.Rows[i]["TB015"] = DateTime.Now.ToString("yyyyMMdd");
                dt.Rows[i]["TB016"] = Class.valiballecommon.GetStorage().UserName;
                dt.Rows[i]["TB017"] = "N";
                dt.Rows[i]["TB018"] = "";
                dt.Rows[i]["TB019"] = "1";
                dt.Rows[i]["TB022"] = "1";
                dt.Rows[i]["TB023"] = "1";
                    dt.Rows[i]["TB024"] = "";
                    dt.Rows[i]["TB025"] = DateTime.Now.ToString("yyyyMM");
                dt.Rows[i]["TB026"] = 0.2;
                dt.Rows[i]["TB027"] = 0;
                dt.Rows[i]["TB029"] = 0;
                dt.Rows[i]["TB030"] = 0;
                dt.Rows[i]["TB031"] = 0;
                //DataTable dtSFCTA = Database.SFC.SFCTA.GetDataTableSFCTA(ERPPQC.Rows[i]["ProductOrder"].ToString());
                //dt.Rows[i]["TB036"] = dtSFCTA.Rows[0]["TA018"].ToString();
                dt.Rows[i]["TB037"] = 0;
                dt.Rows[i]["TB038"] = Class.valiballecommon.GetStorage().DocNo;
                dt.Rows[i]["TB039"] = TransNo;
                dt.Rows[i]["UDF06"] = 0;
                dt.Rows[i]["UDF07"] = 0;
                dt.Rows[i]["UDF08"] = 0;
                dt.Rows[i]["UDF09"] = 0;
                dt.Rows[i]["UDF10"] = 0;
               

                var SumQty = ERPPQC.Rows[i]["Quantity"].ToString().Trim();/*ERPPQC.AsEnumerable().Sum(x =>x.Field<decimal>("Quantity"));*/
                    dt.Rows[i]["TB200"] = SumQty;
                    dt.Rows[i]["TB201"] = SumQty;
                    dt.Rows[i]["TB202"] = 0;
                    dt.Rows[i]["TB042"] = "";
            }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataTableSFCTB", ex.Message);
            }
            return dt;
        }
        public DataTable GetDataTableMOCTG(DataTable ERPPQC, string TB002)
        {
            DataTable dt = new DataTable();
            try
            {

                dt = Database.MOC.MOCTG.GetTop1DataTable();
                if (ERPPQC.Rows.Count > 1)
                {
                    for (int i = 1; i < ERPPQC.Rows.Count; i++)
                    {
                        var newRow = dt.NewRow();
                        dt.Rows.Add(newRow);
                    }
                }
                Database.ADMMFUpdate aDMMF = new Database.ADMMFUpdate();
                DataTable dtADMMF = aDMMF.GetDtADMFFByUser(Class.valiballecommon.GetStorage().UserName);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataTable dtINVMB = Database.INV.INVMB.GetDatabyProduct(ERPPQC.Rows[i]["Product"].ToString().Trim());
                    int ExpireDay = Database.INV.INVMB.ExpireDaybyProduct(ERPPQC.Rows[i]["Product"].ToString().Trim());
                    int ExpireDay2 = Database.INV.INVMB.ExpireDayInspectbyProduct(ERPPQC.Rows[i]["Product"].ToString().Trim());
                    double ConvertToKg = Database.INV.INVMD.ConvertToWeightKg(ERPPQC.Rows[i]["Product"].ToString().Trim(), double.Parse(ERPPQC.Rows[i]["Quantity"].ToString()));
                    dt.Rows[i]["COMPANY"] = dtADMMF.Rows[0]["COMPANY"];
                    dt.Rows[i]["CREATOR"] = Class.valiballecommon.GetStorage().UserName;
                    dt.Rows[i]["USR_GROUP"] = dtADMMF.Rows[0]["MF004"].ToString();
                    dt.Rows[i]["CREATE_DATE"] = DateTime.Now.ToString("yyyyMMdd");
                    dt.Rows[i]["MODIFIER"] = DBNull.Value;
                    dt.Rows[i]["MODI_DATE"] = DBNull.Value;
                    dt.Rows[i]["FLAG"] = 1;
                    dt.Rows[i]["CREATE_TIME"] = DateTime.Now.ToString("HH:mm:ss");
                    dt.Rows[i]["CREATE_AP"] = "SFT";
                    dt.Rows[i]["CREATE_PRID"] = "SFT";
                    dt.Rows[i]["MODI_TIME"] = DBNull.Value;
                    dt.Rows[i]["MODI_AP"] = DBNull.Value;
                    dt.Rows[i]["MODI_PRID"] = DBNull.Value;

                    dt.Rows[i]["TG001"] = Class.valiballecommon.GetStorage().DocNo;
                    dt.Rows[i]["TG002"] = TB002;
                    dt.Rows[i]["TG003"] = (i + 1).ToString("0000");
                    dt.Rows[i]["TG004"] = ERPPQC.Rows[i]["Product"].ToString().Trim();
                    dt.Rows[i]["TG005"] = dtINVMB.Rows[0]["MB002"];
                    dt.Rows[i]["TG006"] = dtINVMB.Rows[0]["MB003"];
                  
                    dt.Rows[i]["TG007"] = dtINVMB.Rows[0]["MB004"];
                    dt.Rows[i]["TG008"] = "";
                    dt.Rows[i]["TG009"] = 1;
                    dt.Rows[i]["TG010"] = ERPPQC.Rows[i]["Warehouse"].ToString().Trim();
                    dt.Rows[i]["TG011"] = ERPPQC.Rows[i]["Quantity"];
                    dt.Rows[i]["TG012"] = 0;
                    dt.Rows[i]["TG013"] = ERPPQC.Rows[i]["Quantity"];
                    dt.Rows[i]["TG014"] = ERPPQC.Rows[i]["ProductOrder"].ToString().Split('-')[0];
                    dt.Rows[i]["TG015"] = ERPPQC.Rows[i]["ProductOrder"].ToString().Split('-')[1];
                    dt.Rows[i]["TG016"] = "0";
                    dt.Rows[i]["TG017"] = ERPPQC.Rows[i]["LotNo"].ToString().Trim();
                    dt.Rows[i]["TG018"] = DateTime.Now.AddDays(ExpireDay).ToString("yyyyMMdd"); ;
                    dt.Rows[i]["TG019"] = DateTime.Now.AddDays(ExpireDay2).ToString("yyyyMMdd"); ;
                    dt.Rows[i]["TG020"] = "["+ ERPPQC.Rows[i]["Warehouse"].ToString().Trim()+ "]";
                    dt.Rows[i]["TG021"] = "";
                    dt.Rows[i]["TG022"] = "Y";
                    dt.Rows[i]["TG023"] = 0;
                    dt.Rows[i]["TG024"] = "N";
                    dt.Rows[i]["TG025"] = ConvertToKg;
                    dt.Rows[i]["TG026"] = 0;
                    dt.Rows[i]["TG027"] = ConvertToKg;
                    dt.Rows[i]["TG028"] =0;
                    dt.Rows[i]["TG029"] = dtINVMB.Rows[0]["MB090"];
                    dt.Rows[i]["TG030"] = "N";
                    dt.Rows[i]["TG031"] = "N";
                    dt.Rows[i]["TG032"] = 0;
                 
                    dt.Rows[i]["TG033"] ="2";
                    dt.Rows[i]["TG034"] = ERPPQC.Rows[i]["Location"].ToString();//add tuanngoc
                    dt.Rows[i]["TG035"] = 0;
                    dt.Rows[i]["TG036"] = 0;
                    dt.Rows[i]["TG037"] = "0";
                    dt.Rows[i]["TG038"] = "";
                    dt.Rows[i]["TG039"] = 0;
                    dt.Rows[i]["TG040"] = "";
                    dt.Rows[i]["TG041"] = "";

                    dt.Rows[i]["TG503"] = 0;
                    dt.Rows[i]["TG504"] = 0;
                    dt.Rows[i]["TG505"] = 0;
                    dt.Rows[i]["TG506"] = 0;

                    dt.Rows[i]["TG553"] = 0;
                    dt.Rows[i]["TG554"] = 0;
                    dt.Rows[i]["TG555"] = 0;
                    dt.Rows[i]["TG556"] = 0;

                    dt.Rows[i]["UDF06"] = 0;
                    dt.Rows[i]["UDF07"] = 0;
                    dt.Rows[i]["UDF08"] = 0;
                    dt.Rows[i]["UDF09"] = 0;
                    dt.Rows[i]["UDF10"] = 0;

                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataTableSFCTC", ex.Message);
            }

            return dt;
        }

        public DataTable GetDataTableMOCTF(DataTable MOCTG, string TB002)
        {
            DataTable dt = new DataTable();
            try
            {


                dt = Database.MOC.MOCTF.GetTop1DataTable();
                Database.ADMMFUpdate aDMMF = new Database.ADMMFUpdate();
                DataTable dtADMMF = aDMMF.GetDtADMFFByUser(Class.valiballecommon.GetStorage().UserName);
                Database.GetListWarehouse getListWarehouse = new Database.GetListWarehouse();
                List<Database.WarehouseItems> listWarehouse = getListWarehouse.GetWarehouseOnly();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    dt.Rows[i]["COMPANY"] = dtADMMF.Rows[0]["COMPANY"];
                    dt.Rows[i]["CREATOR"] = Class.valiballecommon.GetStorage().UserName;
                    dt.Rows[i]["USR_GROUP"] = dtADMMF.Rows[0]["MF004"].ToString();
                    dt.Rows[i]["CREATE_DATE"] = DateTime.Now.ToString("yyyyMMdd");
                    dt.Rows[i]["MODIFIER"] = DBNull.Value;
                    dt.Rows[i]["MODI_DATE"] = DBNull.Value;
                    dt.Rows[i]["FLAG"] = 1;
                    dt.Rows[i]["CREATE_TIME"] = DateTime.Now.ToString("HH:mm:ss");
                    dt.Rows[i]["CREATE_AP"] = "SFT";
                    dt.Rows[i]["CREATE_PRID"] = "SFT";
                    dt.Rows[i]["MODI_TIME"] = DBNull.Value;
                    dt.Rows[i]["MODI_AP"] = DBNull.Value;
                    dt.Rows[i]["MODI_PRID"] = DBNull.Value;
                    dt.Rows[i]["TF001"] = MOCTG.Rows[0]["TG001"];
                    dt.Rows[i]["TF002"] = MOCTG.Rows[0]["TG002"];
                    dt.Rows[i]["TF003"] = DateTime.Now.ToString("yyyyMMdd");
                    dt.Rows[i]["TF004"] = "TL";
                    dt.Rows[i]["TF005"] = "";
                    dt.Rows[i]["TF006"] = "Y";
                    dt.Rows[i]["TF007"] = "N";
                    dt.Rows[i]["TF008"] = 0;
                    dt.Rows[i]["TF009"] = "N";
                    dt.Rows[i]["TF010"] = "N";
                    dt.Rows[i]["TF011"] = "B01";
                    dt.Rows[i]["TF012"] = DateTime.Now.ToString("yyyyMMdd");
                    dt.Rows[i]["TF013"] = Class.valiballecommon.GetStorage().UserName;
                    dt.Rows[i]["TF014"] = "N";
                    dt.Rows[i]["TF015"] = "0";
                    dt.Rows[i]["TF016"] = 0;
                    dt.Rows[i]["TF017"] = 0;
                    dt.Rows[i]["TF018"] = 0;
                    dt.Rows[i]["TF019"] = "";
                    dt.Rows[i]["TF020"] = "";
                    dt.Rows[i]["TF021"] = "";
                    
                    dt.Rows[i]["UDF06"] = 0;
                    dt.Rows[i]["UDF07"] = 0;
                    dt.Rows[i]["UDF08"] = 0;
                    dt.Rows[i]["UDF09"] = 0;
                    dt.Rows[i]["UDF10"] = 0;


                    var SumQty = MOCTG.AsEnumerable().Sum(x => x.Field<decimal>("TG011"));
                    // dt.Rows[i]["TB200"] = SumQty;
                    dt.Rows[i]["TF200"] = SumQty;
                    dt.Rows[i]["TF201"] = 0;
                    dt.Rows[i]["TF202"] = 0;
                   
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDataTableSFCTB", ex.Message);
            }
            return dt;
        }
    }
}
