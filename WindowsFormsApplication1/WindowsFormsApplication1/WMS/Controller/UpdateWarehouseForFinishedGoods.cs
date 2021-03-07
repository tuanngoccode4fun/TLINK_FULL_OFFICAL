using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WindowsFormsApplication1.WMS.Model;

namespace WindowsFormsApplication1.WMS.Controller
{
   public class UpdateWarehouseForFinishedGoods
    {
        public bool UpdateWarehouse(DataTable dtERPPQC, string TB002)
        {
            try
            {

            Database.ADMMFUpdate aDMMF = new Database.ADMMFUpdate();
            DataTable dtADMMF = aDMMF.GetDtADMFFByUser(Class.valiballecommon.GetStorage().UserName);
            for (int i = 0; i < dtERPPQC.Rows.Count; i++)
            {
                Database.Model.INVItems iNVItems = new Database.Model.INVItems();
                iNVItems.Product = dtERPPQC.Rows[i]["Product"].ToString().Trim();
                iNVItems.ProductCode = dtERPPQC.Rows[i]["ProductOrder"].ToString().Trim();
                iNVItems.Lot = dtERPPQC.Rows[i]["LotNo"].ToString().Trim();
                iNVItems.Create_Date = DateTime.Now;
                iNVItems.TypeDoccument = Class.valiballecommon.GetStorage().DocNo;
                iNVItems.DoccumentNo = TB002;// DEM LEN TU BANG SFCTB TB002
                iNVItems.STTDoc = dtERPPQC.Rows[i]["STT"].ToString().Trim();/// NO 0001-> 
                iNVItems.Warehouse = dtERPPQC.Rows[i]["Warehouse"].ToString().Trim();
                iNVItems.TypeInportExport = "1";
                iNVItems.TypeChange = "1";
                iNVItems.Quantity = double.Parse(dtERPPQC.Rows[i]["Quantity"].ToString());
                double SLDongGoi = Database.INV.INVMD.ConvertToWeightKg(dtERPPQC.Rows[i]["Product"].ToString().Trim(), double.Parse(dtERPPQC.Rows[i]["Quantity"].ToString()));
                iNVItems.PackageQty = SLDongGoi;
                iNVItems.Note = dtERPPQC.Rows[i]["ProductOrder"].ToString().Trim();
                iNVItems.Location = dtERPPQC.Rows[i]["Location"].ToString().Trim();
                iNVItems.ImportDate = DateTime.Now;
                iNVItems.MainLocation = dtERPPQC.Rows[i]["Location"].ToString().Trim();
                iNVItems.ImportQR = null;// dtERPPQC.Rows[i]["KeyID"].ToString().Trim() +"-"+ dtERPPQC.Rows[i]["KeyNo"].ToString().Trim();
                   
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
                if ((UpdateINVMF && UpdateINVLA && UpdateINVLF && UpdateINVMC && UpdateINVMM)==false)
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
