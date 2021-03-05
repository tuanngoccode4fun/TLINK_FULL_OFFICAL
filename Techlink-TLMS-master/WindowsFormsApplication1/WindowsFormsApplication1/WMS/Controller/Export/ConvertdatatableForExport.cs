using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.WMS.Controller.Export
{
   public class ConvertdatatableForExport
    {
        public DataTable ConverttoDtCOPTH(DataTable dtExport)
        {
            DataTable dt= Database.COPTH.GetdtTop1COPTH();
            Database.ADMMFUpdate aDMMF = new Database.ADMMFUpdate();
            DataTable dtADMMF = aDMMF.GetDtADMFFByUser(Class.valiballecommon.GetStorage().UserName);
            dt.Rows.Clear();

            for (int i = 0; i < dtExport.Rows.Count; i++)
            {
                DataRow dtRow = dt.NewRow();
                dt.Rows.Add(dtRow);
            }
            try
            {

                string KeyCOPTGTH = Database.COPTG.KeyCOPTGTH(DateTime.Now, dtExport.Rows[0]["DocNo"].ToString().Trim());
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
                dt.Rows[i]["MODI_AP"] = "";//Class.valiballecommon.GetStorage().PCName;
                dt.Rows[i]["CREATE_PRID"] = "COPI08";

                dt.Rows[i]["TH001"] = dtExport.Rows[0]["DocNo"].ToString().Trim();
                dt.Rows[i]["TH002"] = KeyCOPTGTH;
                dt.Rows[i]["TH003"] = dtExport.Rows[i]["STT"].ToString().Trim();
                dt.Rows[i]["TH004"] = dtExport.Rows[i]["Product"].ToString().Trim();

                DataTable dtINVMB = Database.INV.INVMB.GetDatabyProduct(dtExport.Rows[i]["Product"].ToString().Trim());
                   
                    StringBuilder stringBuilder = new StringBuilder();
                    dt.Rows[i]["TH005"] = dtINVMB.Rows[0]["MB002"];
                dt.Rows[i]["TH006"] = dtINVMB.Rows[0]["MB003"];
                dt.Rows[i]["TH007"] = dtExport.Rows[i]["Warehouse"].ToString().Trim();
                dt.Rows[i]["TH008"] = dtExport.Rows[i]["Quantity"];
                dt.Rows[i]["TH009"] = dtINVMB.Rows[0]["MB004"];
                dt.Rows[i]["TH010"] = 0;
                dt.Rows[i]["TH011"] = "";
                dt.Rows[i]["TH012"] = dtExport.Rows[i]["PriceUnit"]; //Don gia lay o dau
                dt.Rows[i]["TH013"] = double.Parse(dtExport.Rows[i]["Quantity"].ToString()) * double.Parse(dt.Rows[i]["TH012"].ToString());//Don gia lay o dau
                dt.Rows[i]["TH014"] = dtExport.Rows[i]["ClientCode"];
                dt.Rows[i]["TH015"] = dtExport.Rows[i]["ClientOrder"];
                dt.Rows[i]["TH016"] = dtExport.Rows[i]["OrderSTT"];
                dt.Rows[i]["TH017"] = dtExport.Rows[i]["LotNo"]; ;//So lo
                dt.Rows[i]["TH018"] = "";//So lo
                dt.Rows[i]["TH019"] = "";//ma san pham khach hang
                dt.Rows[i]["TH020"] = "Y";
                dt.Rows[i]["TH021"] = "N";
                dt.Rows[i]["TH022"] = "";
                dt.Rows[i]["TH023"] = "";
                dt.Rows[i]["TH024"] = 0;
                dt.Rows[i]["TH025"] = 1;
                dt.Rows[i]["TH026"] = "N";
                dt.Rows[i]["TH027"] = "";
                dt.Rows[i]["TH028"] = "";
                dt.Rows[i]["TH029"] = "";
                dt.Rows[i]["TH030"] = "";
                dt.Rows[i]["TH031"] = "1";
                dt.Rows[i]["TH032"] = "";
                dt.Rows[i]["TH033"] = "";
                dt.Rows[i]["TH034"] = "";
                dt.Rows[i]["TH035"] = dt.Rows[i]["TH013"];
               DataTable dtCMSMG = Database.CMS.CMSMG.GetdtConvetTienTe(dtExport.Rows[i]["Currency"].ToString().Trim(), DateTime.Now);
                dt.Rows[i]["TH036"] = 0;// THUE XUAT = 0

                dt.Rows[i]["TH037"] = double.Parse(dt.Rows[i]["TH013"].ToString())* double.Parse(dtCMSMG.Rows[0]["MG012"].ToString());// TIEN HOAN DOI RA TIEN VIET
                dt.Rows[i]["TH038"] = 0;
               double SLDongGoi = Database.INV.INVMD.ConvertToWeightKg(dt.Rows[i]["TH004"].ToString(), double.Parse(dt.Rows[i]["TH008"].ToString()));
                    DataTable dtCOPTD = Database.COP.COPTD.GetdtCOPTDby(dt.Rows[i]["TH014"].ToString(), dt.Rows[i]["TH015"].ToString(), dt.Rows[i]["TH016"].ToString());
                    dt.Rows[i]["TH039"] = SLDongGoi;
                dt.Rows[i]["TH040"] = 0;
                dt.Rows[i]["TH041"] = dtCOPTD.Rows[0]["TD036"];//DON VI DONG GOI
                dt.Rows[i]["TH042"] = "N";
                dt.Rows[i]["TH043"] = 0;
                dt.Rows[i]["TH044"] = 0;
                dt.Rows[i]["TH045"] = 0;
                dt.Rows[i]["TH046"] = 0;
                dt.Rows[i]["TH047"] = 0;
                dt.Rows[i]["TH048"] = 0;
                dt.Rows[i]["TH049"] = 0;
                dt.Rows[i]["TH050"] = 0;
                dt.Rows[i]["TH051"] = "";
                dt.Rows[i]["TH052"] = 0;
                dt.Rows[i]["TH053"] = 0;
                dt.Rows[i]["TH054"] = "N";
                dt.Rows[i]["TH055"] = "";
                dt.Rows[i]["TH056"] = "";
                dt.Rows[i]["TH057"] = 0;
                dt.Rows[i]["TH058"] = "";
                dt.Rows[i]["TH059"] = "";
                dt.Rows[i]["TH060"] = dtExport.Rows[i]["Location"];
                dt.Rows[i]["TH061"] = dtExport.Rows[i]["Quantity"];
                dt.Rows[i]["TH062"] = dtINVMB.Rows[0]["MB004"];//PCS
                dt.Rows[i]["TH063"] = 0;
                dt.Rows[i]["TH064"] = 0;
                dt.Rows[i]["TH065"] = "";
                dt.Rows[i]["TH066"] = "";
                dt.Rows[i]["TH067"] = "";
                dt.Rows[i]["TH068"] = "N";
                dt.Rows[i]["TH069"] = 0;
                dt.Rows[i]["TH070"] = "";
                dt.Rows[i]["TH071"] = 0;
                dt.Rows[i]["TH072"] = 0;
                dt.Rows[i]["TH073"] = 0;
                dt.Rows[i]["TH074"] = 0;
                dt.Rows[i]["TH075"] = "";
                dt.Rows[i]["TH076"] = "";
                dt.Rows[i]["TH077"] = "";
                dt.Rows[i]["TH078"] = "";
                dt.Rows[i]["TH079"] = "";
                dt.Rows[i]["TH080"] = 0;

                dt.Rows[i]["UDF06"] = 0;
                dt.Rows[i]["UDF07"] = 0;
                dt.Rows[i]["UDF08"] = 0;
                dt.Rows[i]["UDF09"] = 0;
                dt.Rows[i]["UDF10"] = 0;

                dt.Rows[i]["TH091"] = 0;
            }
            }
            catch (Exception ex) 
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Convert to COPTH", ex.Message);
                dt = new DataTable();
            }
            return dt;
        }

        public DataTable ConvertdtCOPTG(DataTable COPTH, DataTable dtExport)
        {
            DataTable dt = Database.COPTG.GetdtTop1COPTG();
            dt.Rows.Clear();
            DataRow dataRow = dt.NewRow();
            dt.Rows.Add(dataRow);
            Database.ADMMFUpdate aDMMF = new Database.ADMMFUpdate();
            DataTable dtADMMF = aDMMF.GetDtADMFFByUser(Class.valiballecommon.GetStorage().UserName);
            try
            {
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
                    dt.Rows[i]["CREATE_TIME"] = DateTime.Now.ToString("HH:mm:ss");
                    dt.Rows[i]["CREATE_AP"] = "SFT";
                    dt.Rows[i]["CREATE_PRID"] = "SFT";
                    dt.Rows[i]["MODI_TIME"] = DBNull.Value;
                    dt.Rows[i]["MODI_AP"] = "";//Class.valiballecommon.GetStorage().PCName;
                    dt.Rows[i]["CREATE_PRID"] = "COPI08";
                    dt.Rows[i]["TG001"] = COPTH.Rows[0]["TH001"];
                    dt.Rows[i]["TG002"] = COPTH.Rows[0]["TH002"];
                    dt.Rows[i]["TG003"] = DateTime.Now.ToString("yyyyMMdd");
                    dt.Rows[i]["TG004"] = dtExport.Rows[0]["Client"];
                    dt.Rows[i]["TG005"] = dtExport.Rows[0]["DeptCode"];
                    dt.Rows[i]["TG006"] = "";
                    DataTable dtCOPMA = Database.COPMA.GetDataTableKhachhangbyClientCode(dtExport.Rows[0]["Client"].ToString().Trim());

                    dt.Rows[i]["TG007"] = dtCOPMA.Rows[0]["MA003"];//ten day du khach hang
                    dt.Rows[i]["TG008"] = "";
                    dt.Rows[i]["TG009"] = "";
                    dt.Rows[i]["TG010"] = "TL";
                    dt.Rows[i]["TG011"] = dtExport.Rows[0]["Currency"];
                    DataTable dtCMSMG = Database.CMS.CMSMG.GetdtConvetTienTe(dtExport.Rows[i]["Currency"].ToString().Trim(), DateTime.Now);
                    dt.Rows[i]["TG012"] = dtCMSMG.Rows[0]["MG012"]; 
                    var MonneySaled = COPTH.AsEnumerable().Sum(x => x.Field<decimal>("TH013"));
                    dt.Rows[i]["TG013"] = MonneySaled; //so tien ban
                    dt.Rows[i]["TG014"] = "";
                    dt.Rows[i]["TG015"] = "";
                    dt.Rows[i]["TG016"] = "3";
                    dt.Rows[i]["TG017"] = "3";
                    dt.Rows[i]["TG018"] = "";
                    dt.Rows[i]["TG019"] = "";
                    dt.Rows[i]["TG020"] = "";
                    dt.Rows[i]["TG021"] = "";//ngay hoa don
                    dt.Rows[i]["TG022"] = 0;
                    dt.Rows[i]["TG023"] = "Y";
                    dt.Rows[i]["TG024"] = "N";
                    dt.Rows[i]["TG025"] = 0;
                    dt.Rows[i]["TG026"] = "";
                    dt.Rows[i]["TG027"] = "";
                    dt.Rows[i]["TG028"] = "";
                    dt.Rows[i]["TG029"] = "";
                    dt.Rows[i]["TG030"] = "N";
                    dt.Rows[i]["TG031"] = "2";
                    dt.Rows[i]["TG032"] = 0;
                    dt.Rows[i]["TG033"] = 0;
                    dt.Rows[i]["TG032"] = 0;
                    var SumQty = COPTH.AsEnumerable().Sum(x => x.Field<decimal>("TH008"));
                    dt.Rows[i]["TG033"] = SumQty;
                    dt.Rows[i]["TG034"] = "N";
                    dt.Rows[i]["TG035"] = "";
                    dt.Rows[i]["TG036"] = "N";
                    dt.Rows[i]["TG037"] = "N";
                    dt.Rows[i]["TG038"] = DateTime.Now.ToString("yyyyMM");
                    dt.Rows[i]["TG039"] = "";
                    dt.Rows[i]["TG040"] = dtExport.Rows[0]["Invoice"].ToString().Trim();
                    dt.Rows[i]["TG041"] = 0;
                    dt.Rows[i]["TG042"] = DateTime.Now.ToString("yyyyMMdd");
                    dt.Rows[i]["TG043"] = Class.valiballecommon.GetStorage().UserName;
                    dt.Rows[i]["TG044"] = 0;
                    var TongTienViet = COPTH.AsEnumerable().Sum(x => x.Field<decimal>("TH037"));
                    dt.Rows[i]["TG045"] = TongTienViet;//So tien ban tinh sao
                    dt.Rows[i]["TG046"] = 0;
                    dt.Rows[i]["TG047"] = "";
                    dt.Rows[i]["TG048"] = "";
                    dt.Rows[i]["TG049"] = "";
                    dt.Rows[i]["TG050"] = "";
                    dt.Rows[i]["TG051"] = "";
                    dt.Rows[i]["TG052"] = 0;
                    dt.Rows[i]["TG053"] = 0;
                    var SumPackingKg = COPTH.AsEnumerable().Sum(x => x.Field<decimal>("TH039"));
                    dt.Rows[i]["TG054"] = SumPackingKg;
                    dt.Rows[i]["TG055"] = "N";
                    dt.Rows[i]["TG056"] = "N";
                    dt.Rows[i]["TG057"] = "";
                    dt.Rows[i]["TG058"] = "";
                    dt.Rows[i]["TG059"] = "N";
                    dt.Rows[i]["TG060"] = "";
                    dt.Rows[i]["TG061"] = "N";
                    dt.Rows[i]["TG062"] = "0";
                    dt.Rows[i]["TG063"] = 0;
                    dt.Rows[i]["TG064"] = "";
                    dt.Rows[i]["TG065"] = "";
                    dt.Rows[i]["TG066"] = "";
                    dt.Rows[i]["TG067"] = "";
                    dt.Rows[i]["TG068"] = "1";
                    dt.Rows[i]["TG069"] = 0;
                    dt.Rows[i]["TG070"] = "N";
                    dt.Rows[i]["TG071"] = 0;
                    dt.Rows[i]["TG072"] = "";
                    dt.Rows[i]["TG073"] = "";
                    dt.Rows[i]["TG074"] = "";
                    dt.Rows[i]["TG075"] = "";
                    dt.Rows[i]["TG076"] = dtCOPMA.Rows[0]["MA003"];
                    dt.Rows[i]["TG077"] = "";
                    dt.Rows[i]["TG078"] = "";
                    dt.Rows[i]["TG079"] = "";
                    dt.Rows[i]["TG080"] = "";
                    dt.Rows[i]["TG081"] = "";
                    dt.Rows[i]["TG082"] = "1";
                    dt.Rows[i]["TG083"] = "";
                    dt.Rows[i]["TG084"] = 0;
                    dt.Rows[i]["TG085"] = 0;
                    dt.Rows[i]["TG086"] = "2";
                    dt.Rows[i]["TG087"] = "";
                    dt.Rows[i]["TG088"] = "";
                    dt.Rows[i]["TG089"] = "N";
                    dt.Rows[i]["TG090"] = "";
                    dt.Rows[i]["TG091"] = 0;
                    dt.Rows[i]["TG092"] = "";
                    dt.Rows[i]["TG093"] = "";
                    dt.Rows[i]["TG094"] = "003";// cai nay lay o dau
                    dt.Rows[i]["TG095"] = "";
                    dt.Rows[i]["TG096"] = "";
                    dt.Rows[i]["TG097"] = "N";
                    dt.Rows[i]["TG098"] = "";
                    dt.Rows[i]["TG099"] = 0;
                    dt.Rows[i]["TG100"] = "N";
                    dt.Rows[i]["TG101"] = 1;
                    dt.Rows[i]["TG102"] = "";
                    dt.Rows[i]["TG103"] = "";
                    dt.Rows[i]["TG104"] = "";
                    dt.Rows[i]["TG105"] = "";
                    dt.Rows[i]["TG106"] = "";
                    dt.Rows[i]["TG107"] = "";
                    dt.Rows[i]["TG108"] = "";
                    dt.Rows[i]["TG109"] = "";
                    dt.Rows[i]["TG110"] = "";
                    dt.Rows[i]["TG111"] = "0";
                    dt.Rows[i]["UDF06"] = 0;
                    dt.Rows[i]["UDF07"] = 0;
                    dt.Rows[i]["UDF08"] = 0;
                    dt.Rows[i]["UDF09"] = 0;
                    dt.Rows[i]["UDF10"] = 0;

                }
               
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Convert to COPTG", ex.Message);
                dt = new DataTable();
            }
            return dt;
        }


    }
}
