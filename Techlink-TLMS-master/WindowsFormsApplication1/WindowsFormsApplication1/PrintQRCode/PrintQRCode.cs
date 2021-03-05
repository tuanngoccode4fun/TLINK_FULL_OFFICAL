using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.PrintQRCode
{
    public partial class PrintQRCode : Form
    {
        public PrintQRCode()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_printForm1_Click(object sender, EventArgs e)
        {
            try
            {

          
            WMS.Model.WarehouseInfor warehouseInfor = new WMS.Model.WarehouseInfor();
            warehouseInfor.Material = txt_partNo1.Text.Trim();
            warehouseInfor.Lot = txt_lot1.Text.Trim();
            warehouseInfor.quantity = nmr_quantity1.Value;
            warehouseInfor.Unit = cb_unit1.SelectedItem.ToString();
            warehouseInfor.ImportDate = dtpk_import1.Value;
            warehouseInfor.expiryDate = dtpk_expiry1.Value;
                Device.Printer.PritingLabel pritingLabel = new Device.Printer.PritingLabel();
                pritingLabel.PrintQRCodeWarehouse(warehouseInfor);

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "btn_printForm1_Click(object sender, EventArgs e)", ex.Message);
            }

        }

        private void btn_PrintForm2_Click(object sender, EventArgs e)
        {
            try
            {


                WMS.Model.WarehouseInfor warehouseInfor = new WMS.Model.WarehouseInfor();
                warehouseInfor.Material = txt_partno2.Text.Trim();
                warehouseInfor.Lot = txt_lot2.Text.Trim();
                warehouseInfor.quantity = nmr_quantity2.Value;
                warehouseInfor.Unit = cb_unit2.SelectedItem.ToString();
                warehouseInfor.ImportDate = dtpk_import2.Value;
                warehouseInfor.expiryDate = dtpk_expiry2.Value;
                Device.Printer.PritingLabel pritingLabel = new Device.Printer.PritingLabel();
                pritingLabel.PrintQRCodeWarehouse(warehouseInfor);

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "btn_printForm1_Click(object sender, EventArgs e)", ex.Message);
            }
        }
    }
}
