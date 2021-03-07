using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1.WMS.Controller.Export
{
 public   class UpdatERPFinishedGoods
    {
        public bool UploadERPFinishedGoods(DataTable dtExport, out string DeliveryNo)
        {

            DeliveryNo = "";
            var isStockAvaiable = IsCheckStockAvaiable(dtExport);
            if (isStockAvaiable == false)
                return false;
               ConvertdatatableForExport convertdatatableForExport = new ConvertdatatableForExport();
            DataTable dtCOPTH = convertdatatableForExport.ConverttoDtCOPTH(dtExport);
            DataTable dtCOPTG = convertdatatableForExport.ConvertdtCOPTG(dtCOPTH,dtExport);
            if(dtCOPTH.Rows.Count == 0)
            {
                MessageBox.Show("Convert to COPTH fail ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if(dtCOPTG.Rows.Count == 0)
            {
                MessageBox.Show("Convert to COPTG fail ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Database.COPTH cOPTH = new Database.COPTH();
           var insertCOPTH = cOPTH.InsertData(dtCOPTH);
            if(insertCOPTH == false)
            {
                MessageBox.Show("Insert COPTH fail ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Database.COPTG cOPTG = new Database.COPTG();
          var insertCOPTG = cOPTG.InsertData(dtCOPTG);
            if(insertCOPTG == false)
            {
                MessageBox.Show("Insert COPTG fail ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            UpdateWarehouseForExportFGs updateWarehouseForExportFGs = new UpdateWarehouseForExportFGs();
          var update = updateWarehouseForExportFGs.UpdateWarehouse(dtCOPTH, dtExport);
            if (update == false)
            {
                MessageBox.Show("Update warehouse stock fail ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            Database.COP.COPTD cOPTD = new Database.COP.COPTD();
           var updateCOPTD = cOPTD.UpdateCOPTDDelivery(dtCOPTH);
            if (updateCOPTD == false)
            {
                MessageBox.Show("Update COPTD fail ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            DeliveryNo = dtCOPTG.Rows[0]["TG001"].ToString().Trim() + "-" + dtCOPTG.Rows[0]["TG002"].ToString().Trim();
            Database.ERPSOFT.t_ExportFGoods t_ExportFGoods = new Database.ERPSOFT.t_ExportFGoods();
          var UpdateERPExport =  t_ExportFGoods.UpdateExportWarehouse(dtExport,DeliveryNo);
            if (UpdateERPExport == false)
            {
                MessageBox.Show("Update Out Stock QR fail ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
           

            return true;
        }
        public bool IsCheckStockAvaiable(DataTable dtExportFGs)
        {
            for (int i = 0; i < dtExportFGs.Rows.Count; i++)
            {
                string product = dtExportFGs.Rows[i]["Product"].ToString().Trim();
                string LotNo = dtExportFGs.Rows[i]["LotNo"].ToString().Trim();
                string warehouse = dtExportFGs.Rows[i]["Warehouse"].ToString().Trim();
                string Location = dtExportFGs.Rows[i]["Location"].ToString().Trim();
                double Quantity = dtExportFGs.Rows[i]["Quantity"].ToString().Trim() != "" ?double.Parse( dtExportFGs.Rows[i]["Quantity"].ToString().Trim()):0 ;
             var isAvaiableINVMM =   Database.INV.INVMM.IsStockAvaiable(product, warehouse, Location, LotNo, Quantity);
                if (isAvaiableINVMM == false)
                {
                    MessageBox.Show(" Stock: "+ product+" , warehouse: "+ warehouse + " , LOT: "   + LotNo + " is not enough to export in INVMM", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                var isAvaiableINVMC = Database.INV.INVMC.IsStockAvaiable(product, warehouse, Quantity);
                if(isAvaiableINVMC == false)
                {
                    MessageBox.Show("  Stock: " + product + " , warehouse: " + warehouse + " is not enough to export in INVMC", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
                //var isAvaiableINVMB = Database.INV.INVMB.IsStockAvaiable(product, Quantity);
                //if (isAvaiableINVMB == false)
                //{
                //    MessageBox.Show(" Stock " + product + " is not enough to export in INVMB", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                //    return false;
                //}
            }
            return true;
        }
    }
}
