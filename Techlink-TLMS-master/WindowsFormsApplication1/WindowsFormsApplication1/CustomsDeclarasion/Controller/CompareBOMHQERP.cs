using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.CustomsDeclarasion.Controller
{
   public class CompareBOMHQERP
    {
       
       public List<Model.HQERPBOM> listHQERPBoms (DataTable dtMASPHQ)
        {

            List<Model.HQERPBOM> hQERPBOMs = new List<Model.HQERPBOM>();
            Database.CustomsDeclar.GetBOMCustoms getBOMCustoms = new Database.CustomsDeclar.GetBOMCustoms();
            Database.BOM.BOMHQ bOMHQ = new Database.BOM.BOMHQ(); 
            for (int i = 0; i < dtMASPHQ.Rows.Count; i++)
            {
                Model.HQERPBOM hQERPBOM = new Model.HQERPBOM();
                hQERPBOM.MA_SP_HQ = dtMASPHQ.Rows[i]["MA_SP"].ToString().Trim();
                hQERPBOM.MA_SP_HS = dtMASPHQ.Rows[i]["MA_HS"].ToString().Trim();
                hQERPBOM.MA_SP_ERP = dtMASPHQ.Rows[i]["MA_SP_ERP"].ToString().Trim();


                DataTable dtNVLERP = bOMHQ.GetDataTableBOMHQonERP(hQERPBOM.MA_SP_ERP);
                for (int k = 0; k < dtNVLERP.Rows.Count; k++)
                {
                    hQERPBOM.MA_NVL_ERP += dtNVLERP.Rows[k]["MA_NVL"].ToString() + Environment.NewLine;
                    hQERPBOM.DM_ERP += dtNVLERP.Rows[k]["DM_SD"].ToString() + Environment.NewLine;
                    hQERPBOM.DVT_ERP += dtNVLERP.Rows[k]["MA_DVT"].ToString() + Environment.NewLine;

                }
                DataTable dtNVLHQ = getBOMCustoms.BOMHAIQUANTheoMaSp(hQERPBOM.MA_SP_HQ);
                for (int j = 0; j < dtNVLHQ.Rows.Count; j++)
                {
                    hQERPBOM.MA_NVL_HQ += dtNVLHQ.Rows[j]["MA_NPL"].ToString().Trim() + Environment.NewLine;
                    hQERPBOM.MA_NVL_HS += dtNVLHQ.Rows[j]["MA_HS"].ToString().Trim() + Environment.NewLine;
                    hQERPBOM.DM_HQ += dtNVLHQ.Rows[j]["DM_SD"].ToString().Trim()+ Environment.NewLine;
                    hQERPBOM.DVT_HQ += dtNVLHQ.Rows[j]["MA_DVT"].ToString().Trim()+Environment.NewLine;
                    var dtRowNVLERP = dtNVLERP.AsEnumerable().Where(d => d.Field<string>("MA_NVL").Trim() == dtNVLHQ.Rows[j]["MA_NPL"].ToString().Trim()).ToList();
                    if(dtRowNVLERP.Count == 1)
                    {
                        var DM_ERP_SS = dtRowNVLERP[0]["DM_SD"];
                        var DM_HQ_SS = dtNVLHQ.Rows[j]["DM_SD"];
                        var DVT_HQ_SS = dtNVLHQ.Rows[j]["MA_DVT"];
                        var DVT_ER_SS = dtRowNVLERP[0]["MA_DVT"];
                        if (DM_ERP_SS != DM_HQ_SS)
                        {
                            hQERPBOM.Issue += "[Khác nhau Định Mức]  " ;
                        }
                        else if (DVT_HQ_SS != DVT_ER_SS)
                        {
                            hQERPBOM.Issue += "[Khác nhau DVT] ";
                        }
                    }
                    else if (dtRowNVLERP.Count == 0)
                    {
                        hQERPBOM.Issue += "[Không có mã "+ dtNVLHQ.Rows[j]["MA_NPL"].ToString() +"]";
                    }
                    hQERPBOM.Issue += Environment.NewLine;
                }
                //DataTable dtNVLERP = bOMHQ.GetDataTableBOMHQonERP(hQERPBOM.MA_SP_ERP);
                //for (int k = 0; k < dtNVLERP.Rows.Count; k++)
                //{
                //    hQERPBOM.MA_NVL_ERP += dtNVLERP.Rows[k]["MA_NVL"].ToString() + Environment.NewLine;
                //    hQERPBOM.DM_ERP += dtNVLERP.Rows[k]["DM_SD"].ToString() + Environment.NewLine;
                //    hQERPBOM.DVT_ERP += dtNVLERP.Rows[k]["MA_DVT"].ToString() + Environment.NewLine;

                //}
              
                hQERPBOMs.Add(hQERPBOM);
            }
            return hQERPBOMs;
        }
    }
}
