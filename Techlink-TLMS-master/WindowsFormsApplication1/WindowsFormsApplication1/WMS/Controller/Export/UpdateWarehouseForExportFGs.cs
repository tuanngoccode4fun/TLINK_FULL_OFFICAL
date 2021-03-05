using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.WMS.Controller.Export
{
   public class UpdateWarehouseForExportFGs
    {
        public bool UpdateWarehouse(DataTable COPTH, DataTable dtExport)
        {
            try
            {

                Database.ADMMFUpdate aDMMF = new Database.ADMMFUpdate();
                DataTable dtADMMF = aDMMF.GetDtADMFFByUser(Class.valiballecommon.GetStorage().UserName);
                for (int i = 0; i < COPTH.Rows.Count; i++)
                {
                    Database.Model.INVItems iNVItems = new Database.Model.INVItems();
                    iNVItems.Product = COPTH.Rows[i]["TH004"].ToString().Trim();
                    iNVItems.ProductCode = "";
                    iNVItems.Lot = dtExport.Rows[i]["LotNo"].ToString().Trim();
                    iNVItems.Create_Date = DateTime.Now;
                    iNVItems.TypeDoccument = COPTH.Rows[i]["TH001"].ToString().Trim();
                    iNVItems.DoccumentNo = COPTH.Rows[i]["TH002"].ToString().Trim();
                    iNVItems.STTDoc = COPTH.Rows[i]["TH003"].ToString().Trim();
                    iNVItems.Warehouse = dtExport.Rows[i]["Warehouse"].ToString().Trim();
                    iNVItems.TypeInportExport = "-1";
                    iNVItems.TypeChange = "2";
                    iNVItems.Quantity = double.Parse(COPTH.Rows[i]["TH008"].ToString().Trim());
                    double SLDongGoi = Database.INV.INVMD.ConvertToWeightKg(COPTH.Rows[i]["TH004"].ToString().Trim(), double.Parse(COPTH.Rows[i]["TH008"].ToString().Trim()));
                    iNVItems.PackageQty = SLDongGoi;
                    iNVItems.Note = "";
                    iNVItems.Location = dtExport.Rows[i]["Location"].ToString().Trim();
                    iNVItems.ImportDate = DateTime.Now;
                    iNVItems.MainLocation = dtExport.Rows[i]["Location"].ToString().Trim();
                    Database.INVMFUpdate iNVMFUpdate = new Database.INVMFUpdate();
                    var UpdateINVMF = iNVMFUpdate.InsertINVMF(iNVItems, dtADMMF);
                    Database.INVMEUpdate iNVMEUpdate = new Database.INVMEUpdate();
                    var UpdateINVME = iNVMEUpdate.InsertOrUpdate(iNVItems, dtADMMF);
                    Database.INVLAUpdate iNVLAUpdate = new Database.INVLAUpdate();
                    var UpdateINVLA = iNVLAUpdate.InsertINVLA(iNVItems, dtADMMF);
                    Database.INVLFUpdate iNVLFUpdate = new Database.INVLFUpdate();
                    var UpdateINVLF = iNVLFUpdate.InsertINVLF(iNVItems, dtADMMF);
                    Database.INVMCUpdate iNVMCUpdate = new Database.INVMCUpdate();
                    var UpdateINVMC = iNVMCUpdate.UpdateOrInsertINVMC(iNVItems, dtADMMF);
                    Database.INV.INVMB iNVMB = new Database.INV.INVMB();
                    var UpdateINVMB = iNVMB.UpdateINVMBbyProduct(iNVItems);
                    Database.INVMMUpdate iNVMMUpdate = new Database.INVMMUpdate();

                    var UpdateINVMM = iNVMMUpdate.UpdateOrInsertINVMM(iNVItems, dtADMMF);
                    if ((UpdateINVMF && UpdateINVLA && UpdateINVLF && UpdateINVMC && UpdateINVMM) == false)
                        return false;
                }
                return true;

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "UpdateWarehouse", ex.Message);
                return false;
            }

        }
    }
}
