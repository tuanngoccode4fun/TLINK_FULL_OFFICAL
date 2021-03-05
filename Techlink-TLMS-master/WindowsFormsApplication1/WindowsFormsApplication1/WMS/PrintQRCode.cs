using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Device.Printer;


namespace WindowsFormsApplication1.WMS
{
    public partial class PrintQRCode : CommonFormMetro
    {
        List<InforWH> ListInforWhs = new List<InforWH>();
        public PrintQRCode()
        {
            InitializeComponent();
            lbl_Header.Text = "QR barcode Generating Function";
            DBOperation dBOperation = new DBOperation();
            ListInforWhs = dBOperation.GetInforWHs();

        }

        private void Btn_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                int numberPrint =(int) nmr_quanityPrinting.Value;
                PritingLabel pritingLabel = new PritingLabel();
                LabelItem labelItem = new LabelItem();
                labelItem.Location = "";
                labelItem.PurchasingCode = txt_Purchasingcode.Text;
                labelItem.MaterialCode = txt_materialCode.Text;
               
                labelItem.Quantity = nmr_quantity.Value.ToString("N2");
                
                labelItem.LotPo =txt_LotPo.Text;
                labelItem.ExpiryDate =dt_ExpiryDate.Value;
                labelItem.Invoice = txt_Invoice.Text.Trim();
                DBOperation dBOperation = new DBOperation();
                DataTable dt = dBOperation.GetNameOfProductCode(labelItem.MaterialCode);
                if (dt != null && dt.Rows.Count > 0)
                    {
                    if (dt.Rows[0]["TD005"].ToString().Length > 10)
                    {
                        labelItem.Commodity = dt.Rows[0]["TD005"].ToString().Substring(0, 9);
                    }
                    else labelItem.Commodity = dt.Rows[0]["TD005"].ToString();
                }
                else labelItem.Commodity = "";

                //string QRInfor = txt_warehouseName.Text + ";" + txt_location.Text + ";" + txt_rack.Text;
                pritingLabel.PrintLabelQRCode(labelItem,numberPrint);
            }
            catch (Exception ex)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "Btn_Generate_Click(object sender, EventArgs e)", ex.Message);
            }
          
        }

        private void Btn_GenerateLocation_Click(object sender, EventArgs e)
        {
            try
            {
                PritingLabel pritingLabel = new PritingLabel();
                string QRInfor = txt_warehouse.Text + ";" + txt_location.Text + ";" + txt_Rack.Text;
              var name =  ListInforWhs.Where(d => d.WH == txt_warehouse.Text.Trim()).Select(d => d.Name).ToList()[0];
                pritingLabel.PrintQRCode(QRInfor,name);
            }
            catch (Exception ex)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "Btn_Generate_Click(object sender, EventArgs e)", ex.Message);
            }
        }

        private void Btn_Generatecode_Click(object sender, EventArgs e)
        {
            PritingLabel pritingLabel = new PritingLabel();
            string QRInfor = txt_code.Text;
            pritingLabel.PrintQRCodeConfirm(QRInfor,txt_Name.Text);
        }

        private void Nmr_quanityPrinting_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PritingLabel pritingLabel = new PritingLabel();
            string QRInfor = txt_QRERP.Text;
            pritingLabel.PrintQRCodErp( txt_QRERP.Text);
        }
    }
    
}
