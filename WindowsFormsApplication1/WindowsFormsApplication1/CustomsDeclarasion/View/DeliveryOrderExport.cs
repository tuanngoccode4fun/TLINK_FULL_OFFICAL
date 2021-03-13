using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.CustomsDeclarasion.Model;

namespace WindowsFormsApplication1.CustomsDeclarasion.View
{
    public partial class DeliveryOrderExport : CommonFormMetro
    {
        public DataTable dtExport ;
        List<SummaryDelivery> listSummary;
        public DeliveryOrderExport()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            lbl_Header.Text = "CUSTOMS DECLARATION FILES EXPORT ";
        }

   

        private void txt_packingNo_TextChanged(object sender, EventArgs e)
        {
            if(txt_packingNo.Text.Length ==13)
            {
                
                dtgv_BOMCustoms.Columns.Clear();
                dtgv_BOMCustoms.Controls.Clear();

                Database.ERPSOFT.t_ExportFGoods t_ExportFGoods = new Database.ERPSOFT.t_ExportFGoods();
                dtExport = t_ExportFGoods.GetDataTableExportFinishedGoods(txt_packingNo.Text);
               
                if(dtExport.Rows.Count > 0)
                {
                    lb_client.Text = "Client : " + dtExport.Rows[0]["Client"].ToString().Trim();
                    lb_Invoice.Text = "Invoice: "+ dtExport.Rows[0]["Invoice"].ToString().Trim();
                    txt_buyerSelect.Text = dtExport.Rows[0]["TL202"].ToString().Trim();
                    txt_ShipmentType.Text = dtExport.Rows[0]["TL203"].ToString().Trim();
                    lb_dateExportWarehouse.Text = "Warehouse Export Date : "+ dtExport.Rows[0]["dateExport"].ToString().Trim();
                }
                var ListProduct = (from r in dtExport.AsEnumerable()
                         select r["Product"]).Distinct().ToList() ;
                listSummary = new List<SummaryDelivery>();
                for (int i = 0; i < ListProduct.Count; i++)
                {
                    SummaryDelivery summary = new SummaryDelivery();
                    summary.Product =(string) ListProduct[i];
                    decimal TotalQty = 0;
                    TotalQty = dtExport.AsEnumerable().Where(d => d.Field<string>("Product") == summary.Product)
                                .Sum(d => d.Field<decimal>("Quantity"));
                    summary.TotalQuantity = TotalQty;
                    summary.PriceUnit = dtExport.AsEnumerable().Where(d => d.Field<string>("Product") == summary.Product)
                                .Select(d => d.Field<decimal>("PriceUnit")).ToList()[0];
                    summary.price = summary.TotalQuantity * summary.PriceUnit;
                    summary.Unit = dtExport.AsEnumerable().Where(d => d.Field<string>("Product") == summary.Product)
                                .Select(d => d.Field<string>("Unit")).ToList()[0];
                    summary.Currency = dtExport.AsEnumerable().Where(d => d.Field<string>("Product") == summary.Product)
                                .Select(d => d.Field<string>("Currency")).ToList()[0];

                    listSummary.Add(summary);

                }
                dtgv_deliveryInfo.DataSource = listSummary;

                dtgv_BOMCustoms.DataSource = listSummary;
                DataGridViewButtonColumn dataGridViewButton = new DataGridViewButtonColumn();
                dataGridViewButton.HeaderText = "BOM Customs Declar";
                dataGridViewButton.Name = "BOM";
                dataGridViewButton.Width = 100;
               
                dtgv_BOMCustoms.Columns.Add(dataGridViewButton);

            }
        }

        private void dtgv_deliveryInfo_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_deliveryInfo);

            dtgv_deliveryInfo.AllowUserToAddRows = false;
            dtgv_deliveryInfo.ReadOnly = true;
            //if(dtgv_deliveryInfo.Rows.Count > 0)
            //{
            //    dtgv_deliveryInfo.Columns["KeyID"].Visible = false;
            //    dtgv_deliveryInfo.Columns["KeyNo"].Visible = false;
            //    dtgv_deliveryInfo.Columns["Client"].Visible = false;
            //    dtgv_deliveryInfo.Columns["DeptCode"].Visible = false;
            //    dtgv_deliveryInfo.Columns["Warehouse"].Visible = false;
            //    dtgv_deliveryInfo.Columns["Location"].Visible = false;
            //    dtgv_deliveryInfo.Columns["DocNo"].Visible = false; 
            //    dtgv_deliveryInfo.Columns["dateCreate"].Visible = false;
            //    dtgv_deliveryInfo.Columns["TL201"].Visible = false;
            //    dtgv_deliveryInfo.Columns["TL202"].Visible = false;
            //    dtgv_deliveryInfo.Columns["TL203"].Visible = false;
            //    dtgv_deliveryInfo.Columns["TL204"].Visible = false;
            //    dtgv_deliveryInfo.Columns["dateUpdate"].Visible = false;
            //    dtgv_deliveryInfo.Columns["ExportFlag"].Visible = false;
            //    dtgv_deliveryInfo.Columns["TL211"].Visible = false;
            //    dtgv_deliveryInfo.Columns["TL212"].Visible = false;
            //    dtgv_deliveryInfo.Columns["TL213"].Visible = false;
            //    dtgv_deliveryInfo.Columns["TL214"].Visible = false;
            //    dtgv_deliveryInfo.Columns["dateExport"].Visible = false;
            //    dtgv_deliveryInfo.Columns["Invoice"].Visible = false;




            //}
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
        {
            if(txt_packingNo.Text.Trim() == "")
            {
                MessageBox.Show("please type slip code !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txt_packingNo.Focus();
                return;
            }
            if(dtgv_deliveryInfo.Rows.Count == 0)
            {
                MessageBox.Show("Delivery data is empty, please check picking slip code !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
          
            string pathsave = "";
            System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Browse Excel Files";
            saveFileDialog.DefaultExt = "Excel";
            saveFileDialog.Filter = "Excel files (*.xls)|*.xls";

            saveFileDialog.CheckPathExists = true;


            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pathsave = saveFileDialog.FileName;

                saveFileDialog.RestoreDirectory = true;
                if (dtExport.Rows.Count > 0)
                {
                    Controller.ExportCustomsDeclaration customsDeclaration = new Controller.ExportCustomsDeclaration();
              var exportResult =       customsDeclaration.ExportCustomsDecalarationsGroupByProduct(pathsave, dtExport,listSummary,txt_buyerSelect.Text.Trim(), txt_ShipmentType.Text.Trim() );
                    if (exportResult)
                    {
                        var resultMessage = MessageBox.Show("Customs Declaration exported to excel sucessful ! \n\r Do you want to open this file ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if (resultMessage == DialogResult.Yes)
                        {

                            FileInfo fi = new FileInfo(pathsave);
                            if (fi.Exists)
                            {
                                System.Diagnostics.Process.Start(pathsave);
                            }
                            else
                            {
                                MessageBox.Show("File doestn't exist !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }






            }

     
        private void btn_buyerSelected_Click(object sender, EventArgs e)
        {
            SelectBuyerWin selectBuyerWin = new SelectBuyerWin();
            selectBuyerWin.FormClosed += SelectBuyerWin_FormClosed;
            selectBuyerWin.ShowDialog();
           
        }

        private void SelectBuyerWin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if(SelectBuyerWin.dtRowSelected != null)
            { 
                txt_buyerSelect.Text = SelectBuyerWin.dtRowSelected["BuyerCode"].ToString();
            }
        }

        private void btn_ShipmentType_Click(object sender, EventArgs e)
        {
            ShipmentTypeSelectWin shipmentTypeSelectWin = new ShipmentTypeSelectWin();
            shipmentTypeSelectWin.FormClosed += ShipmentTypeSelectWin_FormClosed;
            shipmentTypeSelectWin.ShowDialog();
        }

        private void ShipmentTypeSelectWin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (ShipmentTypeSelectWin.dtRowSelected != null)
            {
              
                txt_ShipmentType.Text = ShipmentTypeSelectWin.dtRowSelected["ShipmentCode"].ToString();
            }
        }

        private void dtgv_BOMCustoms_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_BOMCustoms);
            dtgv_BOMCustoms.AllowUserToAddRows = false;
        }

        private void dtgv_BOMCustoms_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (dtgv_BOMCustoms.Columns[e.ColumnIndex].Name == "BOM")
                {
                    string product = dtgv_BOMCustoms.Rows[e.RowIndex].Cells["Product"].Value.ToString().Trim();
                    SummaryDelivery summary = new SummaryDelivery();
                    summary.Product = DateTime.Now.ToString("yy") + "-" + product;
                    summary.TotalQuantity =(decimal)dtgv_BOMCustoms.Rows[e.RowIndex].Cells["TotalQuantity"].Value;
                    summary.Unit = dtgv_BOMCustoms.Rows[e.RowIndex].Cells["Unit"].Value.ToString().Trim();

                    summary.PriceUnit = (decimal)dtgv_BOMCustoms.Rows[e.RowIndex].Cells["PriceUnit"].Value;
                    summary.price = (decimal)dtgv_BOMCustoms.Rows[e.RowIndex].Cells["Price"].Value;
                    summary.Currency = dtgv_BOMCustoms.Rows[e.RowIndex].Cells["Currency"].Value.ToString().Trim();
                    BOMDeclarWin bOMDeclarWin = new BOMDeclarWin(summary);
                    bOMDeclarWin.ShowDialog();
                    


                }
            }
        }

       
    }
}
