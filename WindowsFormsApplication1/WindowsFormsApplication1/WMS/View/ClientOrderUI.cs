using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1.WMS.View
{
    public partial class ClientOrderUI : CommonFormMetro
    {
        string clientCode = "";
        string dept = "";
       public string warehouse = "";
        public static DataTable dtSelectClientOrder = new DataTable();
        public static DataTable dtSelectLot = new DataTable();
        public static DataTable dtExportFG = null;
        public int OrderSelected = -1;
        public List<int> LotIndexSelected = new List<int>();
        DataTable dtClientOrder = null;
        public string Currency = "";
        public DataTable dtStockout;
        public ClientOrderUI(DataTable _dtStockOut,string _clientCode, string _dept, string _Currency, string _warehouse)
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            clientCode = _clientCode;
            dept = _dept;
            warehouse = _warehouse;
            lb_Client.Text = "Client : " + _clientCode;
            Currency = _Currency;
            lbl_currency.Text = Currency;
            dtStockout = _dtStockOut;
            dtExportFG = new DataTable();
        }

        private void ClientOrderUI_Load(object sender, EventArgs e)
        {
            dtClientOrder = Database.COPTCTD.GetClientOrder(clientCode, dept,Currency);
            dtgv_clientOrder.Columns.Clear();
            dtgv_clientOrder.DataSource = null;
            dtgv_clientOrder.DataSource = dtClientOrder;
            DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
            checkBoxCell.Name = "checkbox";
            checkBoxCell.HeaderText = "Select";
            checkBoxCell.DisplayIndex = 0;

            dtgv_clientOrder.ReadOnly = true;
            dtgv_clientOrder.AllowUserToAddRows = false;
            dtgv_clientOrder.Columns.Add(checkBoxCell);
         
        }

        private void dtgv_clientOrder_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_clientOrder);
            if(dtgv_clientOrder.Rows.Count > 0)
            {
                dtgv_clientOrder.Columns["TC005"].Visible = false;
                dtgv_clientOrder.Columns["TC004"].Visible = false;
                dtgv_clientOrder.Columns["TD032"].Visible = false;
                dtgv_clientOrder.Columns["TD036"].Visible = false;
                dtgv_clientOrder.Columns["TD016"].Visible = false;
                dtgv_clientOrder.Columns["TD021"].Visible = false;
                dtgv_clientOrder.Columns["TD005"].Visible = false;

                dtgv_clientOrder.Columns["TC012"].HeaderText = "Client Order";
                dtgv_clientOrder.Columns["TD001"].HeaderText = "Order Code";
                dtgv_clientOrder.Columns["TD002"].HeaderText = "Order No";
                dtgv_clientOrder.Columns["TD003"].HeaderText = "STT";
                dtgv_clientOrder.Columns["TD004"].HeaderText = "Product";
                dtgv_clientOrder.Columns["TD008"].HeaderText = "Order Quantity";
                dtgv_clientOrder.Columns["TD008"].DefaultCellStyle.Format = "N0";
                dtgv_clientOrder.Columns["TD009"].HeaderText = "Delivery Quantity";
                dtgv_clientOrder.Columns["TD009"].DefaultCellStyle.Format = "N0";
                dtgv_clientOrder.Columns["TD010"].HeaderText = "Unit";
                dtgv_clientOrder.Columns["TD013"].HeaderText = "Client Request Date";

                dtgv_clientOrder.Columns["TC012"].ReadOnly = true;
                dtgv_clientOrder.Columns["TD001"].ReadOnly = true;
                dtgv_clientOrder.Columns["TD002"].ReadOnly = true;
                dtgv_clientOrder.Columns["TD003"].ReadOnly = true;
                dtgv_clientOrder.Columns["TD004"].ReadOnly = true;
                dtgv_clientOrder.Columns["TD008"].ReadOnly = true;
                dtgv_clientOrder.Columns["TD009"].ReadOnly = true;
                dtgv_clientOrder.Columns["TD010"].ReadOnly = true;
                dtgv_clientOrder.Columns["TD013"].ReadOnly = true;

            }
        }

        private void dtgv_clientOrder_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                if (dtgv_clientOrder.Columns[e.ColumnIndex].Name == "checkbox" && OrderSelected != e.RowIndex)
                {
                    try
                    {
                        for (int i = 0; i < dtStockout.Rows.Count; i++)
                        {
                            string OrderCode = dtStockout.Rows[i]["ClientCode"].ToString();
                            string OrderNo = dtStockout.Rows[i]["ClientOrder"].ToString();
                            string STT = dtStockout.Rows[i]["OrderSTT"].ToString();
                            if(OrderCode == dtgv_clientOrder.Rows[e.RowIndex].Cells["TD001"].Value.ToString() 
                                && OrderNo == dtgv_clientOrder.Rows[e.RowIndex].Cells["TD002"].Value.ToString()
                                && STT == dtgv_clientOrder.Rows[e.RowIndex].Cells["TD003"].Value.ToString())
                            {
                                MessageBox.Show("Order: [" + OrderCode + "-" + OrderNo + "_ " + STT + " ] is selected, Cannot select again ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                              
                                return;
                            }
                        }
                        if(OrderSelected>-1)
                        dtgv_clientOrder.Rows[OrderSelected].Cells["checkbox"].Value = false;
                        var strTemp = dtgv_clientOrder.Rows[e.RowIndex].Cells["TD008"].Value.ToString();
                        var DeliveryRemain = double.Parse(dtgv_clientOrder.Rows[e.RowIndex].Cells["TD008"].Value.ToString()) - double.Parse(dtgv_clientOrder.Rows[e.RowIndex].Cells["TD009"].Value.ToString());
                        nmr_deliveryQty.Value =(decimal) DeliveryRemain;
                        txt_DeliveryProduct.Text = dtgv_clientOrder.Rows[e.RowIndex].Cells["TD004"].Value.ToString();
                       
                        dtgv_clientOrder.Rows[e.RowIndex].Cells["checkbox"].Value = true;
                        OrderSelected = e.RowIndex;
                       
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Input data wrong format", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

            }
        }

        private void btn_selectClientOrder_Click(object sender, EventArgs e)
        {
            try
            {
                if(numericPriceUnit.Value == 0)
                {
                    MessageBox.Show("The price must be bigger than 0", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if(txt_DeliveryProduct.Text == "")
                {
                    MessageBox.Show("You have to select the client order !", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            LotIndexSelected = new List<int>();
            nmr_selectedQty.Value = 0;
            DataTable dtStock = Database.INVMMUpdate.GetDataTableINVMMbyProductWarehouse(txt_DeliveryProduct.Text,warehouse);
                int CountRow = dtStock.Rows.Count;
                
                DataTable dtrow = new DataTable();
                dtrow = dtStock.Clone();
               
                for (int i = 0; i < CountRow; i++)
                {
                    string product = dtStock.Rows[i]["MM001"].ToString().Trim();
                    string Lot = dtStock.Rows[i]["MM004"].ToString().Trim();
                    string warehouse = dtStock.Rows[i]["MM002"].ToString().Trim();
                    string location = dtStock.Rows[i]["MM003"].ToString().Trim();
                    string Qty = dtStock.Rows[i]["MM005"].ToString().Trim();

                    decimal QtySelected = dtStockout.AsEnumerable().Where(d => d.Field<string>("LotNo").Trim() == Lot && d.Field<string>("Product").Trim() == product)
                        .Sum(x => x.Field<decimal>("Quantity"));
                    dtStock.Rows[i]["MM005"] = decimal.Parse(Qty)- QtySelected;
                    if(decimal.Parse(Qty) - QtySelected > 0)
                    {
                        dtrow.LoadDataRow(dtStock.Rows[i].ItemArray, true);
                    }
                   
                }
               

            dtgv_stockWH.Columns.Clear();
            dtgv_stockWH.DataSource = null;


            dtgv_stockWH.DataSource = dtrow;
            DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
            checkBoxCell.Name = "checkbox";
            checkBoxCell.HeaderText = "Select";
            checkBoxCell.DisplayIndex = 0;

            dtgv_stockWH.ReadOnly = true;
            dtgv_stockWH.AllowUserToAddRows = false;
            dtgv_stockWH.Columns.Add(checkBoxCell);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Choosen client order", ex.Message);
            }
        }

        private void dtgv_stockWH_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgv_stockWH.ReadOnly = true;
            dtgv_stockWH.AllowUserToAddRows = false;
            DatagridviewSetting.settingDatagridview(dtgv_stockWH);
            if(dtgv_stockWH.Rows.Count > 0)
            {
                dtgv_stockWH.Columns["MM001"].HeaderText = "Product";
                dtgv_stockWH.Columns["MM002"].HeaderText = "Warehouse";
                dtgv_stockWH.Columns["MM003"].HeaderText = "Location";
                dtgv_stockWH.Columns["MM004"].HeaderText = "Lot No";
                dtgv_stockWH.Columns["MM005"].HeaderText = "Quantity (pcs)";
                dtgv_stockWH.Columns["MM005"].DefaultCellStyle.Format = "N0";
                dtgv_stockWH.Columns["MM006"].HeaderText = "Weight (kg)";
                dtgv_stockWH.Columns["MM006"].DefaultCellStyle.Format = "N3";
                dtgv_stockWH.Columns["MM008"].HeaderText = "Import date";
                dtgv_stockWH.Columns["MM009"].HeaderText = "Export date";
                dtgv_stockWH.Columns["MM016"].HeaderText = "QR Import";

                dtgv_stockWH.Columns["MM001"].ReadOnly = true;
                dtgv_stockWH.Columns["MM002"].ReadOnly = true;
                dtgv_stockWH.Columns["MM003"].ReadOnly = true;
                dtgv_stockWH.Columns["MM004"].ReadOnly = true;
                dtgv_stockWH.Columns["MM005"].ReadOnly = true;
                dtgv_stockWH.Columns["MM006"].ReadOnly = true;
                dtgv_stockWH.Columns["MM008"].ReadOnly = true;
                dtgv_stockWH.Columns["MM009"].ReadOnly = true;
                dtgv_stockWH.Columns["MM016"].ReadOnly = true;

                dtgv_stockWH.Columns["MM007"].Visible = false;
                dtgv_stockWH.Columns["MM010"].Visible = false;


            }

        }
       
        private void dtgv_stockWH_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                if (dtgv_stockWH.Columns[e.ColumnIndex].Name == "checkbox")
                {
                    try
                    {
                       
                            

                        
                        if (dtgv_stockWH.Rows[e.RowIndex].Cells["checkbox"].Value != null)
                        {
                            if ((bool)dtgv_stockWH.Rows[e.RowIndex].Cells["checkbox"].Value == true)
                            {
                                LotIndexSelected.Remove(e.RowIndex);
                                dtgv_stockWH.Rows[e.RowIndex].Cells["checkbox"].Value = false;
                               
                            }

                            else
                            {
                                LotIndexSelected.Add(e.RowIndex);
                                dtgv_stockWH.Rows[e.RowIndex].Cells["checkbox"].Value = true;
                               
                            }
                        }
                        else
                        {
                            LotIndexSelected.Add(e.RowIndex);
                            dtgv_stockWH.Rows[e.RowIndex].Cells["checkbox"].Value = true;
                           
                        }
                      
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Input data wrong format", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

            }
        }

      
        decimal QtySelected = 0;
        private void dtgv_stockWH_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;

            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                if (dtgv_stockWH.Columns[e.ColumnIndex].Name == "checkbox")
                {

                    try
                    {
                        if (dtgv_stockWH.Rows[e.RowIndex].Cells["checkbox"].Value != null)
                        {

                            if ((bool)dtgv_stockWH.Rows[e.RowIndex].Cells["checkbox"].Value == true)
                            {

                                var Qty = decimal.Parse(dtgv_stockWH.Rows[e.RowIndex].Cells["MM005"].Value.ToString());
                                QtySelected += Qty;

                                for (int i = 0; i < LotIndexSelected.Count; i++)
                                {
                                    if (dtgv_stockWH.Rows[i].Cells["checkbox"].Value == null )
                                    {
                                        MessageBox.Show("You have to select Lot No follow FIFO rule", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        dtgv_stockWH.Rows[e.RowIndex].Cells["checkbox"].Value = false;
                                        LotIndexSelected.Remove(e.RowIndex);
                                        return;

                                    }
                                  else  if ((bool) dtgv_stockWH.Rows[i].Cells["checkbox"].Value == false)
                                    {
                                        MessageBox.Show("You have to select Lot No follow FIFO rule", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        dtgv_stockWH.Rows[e.RowIndex].Cells["checkbox"].Value = false;
                                        LotIndexSelected.Remove(e.RowIndex);
                                        return;

                                    }
                                }



                                if (nmr_selectedQty.Value >= nmr_deliveryQty.Value)
                                {
                                    MessageBox.Show("You selected too much quantity for delivery", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    dtgv_stockWH.Rows[e.RowIndex].Cells["checkbox"].Value = false;
                                    LotIndexSelected.Remove(e.RowIndex);

                                }

                            }

                            else
                            {
                                var Qty = decimal.Parse(dtgv_stockWH.Rows[e.RowIndex].Cells["MM005"].Value.ToString());
                                QtySelected -= Qty;
                                for (int i = e.RowIndex; i < dtgv_stockWH.Rows.Count; i++)
                                {
                                    if (dtgv_stockWH.Rows[i].Cells["checkbox"].Value != null)
                                    {
                                        if ((bool)dtgv_stockWH.Rows[i].Cells["checkbox"].Value == true)
                                        {
                                            MessageBox.Show("You have to unselect Lot No follow FIFO rule", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                            return;
                                        }
                                    }

                                }


                            }
                            nmr_selectedQty.Value = QtySelected;
                        }


                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Input data wrong format", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }




                }

            }
        }

        private void btn_ComfirmExport_Click_1(object sender, EventArgs e)
        {
            for (int i = 0; i < LotIndexSelected.Count; i++)
            {
                if (dtgv_stockWH.Rows[LotIndexSelected[i]].Cells["MM016"].Value != null)
                {
                    
                    string ImportQR = dtgv_stockWH.Rows[LotIndexSelected[i]].Cells["MM016"].Value.ToString();
                    //if (ImportQR != "")
                    //{
                    //    for (int j = 0; j < dtgv_stockWH.Rows.Count; j++)
                    //    {
                    //        if (LotIndexSelected.Contains(j) == false)
                    //        {
                    //            if (dtgv_stockWH.Rows[j].Cells["MM016"].Value.ToString() == ImportQR)
                    //            {
                    //                MessageBox.Show("You have to select all lot of 1 QR import code", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    //                return;
                    //            }
                    //        }
                    //    }
                    //}
                }
            }
            dtExportFG = Database.ERPSOFT.t_ExportFGoods.GetTop1DataTable();
            dtExportFG.Rows.Clear();
            DataRow rowOrder;
            int indexRowOrder = 0;
            try
            {
                for (int i = 0; i < dtgv_clientOrder.Rows.Count; i++)
                {
                    if (dtgv_clientOrder.Rows[i].Cells["checkbox"].Value != null)
                    {
                        if ((bool)dtgv_clientOrder.Rows[i].Cells["checkbox"].Value == true)
                        {
                            indexRowOrder = i;
                        }
                    }
                }
                for (int i = 0; i < LotIndexSelected.Count; i++)
                {
                    DataRow dataRow = dtExportFG.NewRow();
                    dtExportFG.Rows.Add(dataRow);
                }

                double QuantityDelivery = double.Parse(nmr_deliveryQty.Value.ToString());
                double QuantitySelected = double.Parse(nmr_selectedQty.Value.ToString());
                double TongTemp = 0;
                for (int i = 0; i < LotIndexSelected.Count; i++)
                {
                  
                        if (dtgv_stockWH.Rows[LotIndexSelected[i]].Cells["checkbox"].Value != null)
                        {
                            if ((bool)dtgv_stockWH.Rows[LotIndexSelected[i]].Cells["checkbox"].Value == true)
                            {
                                DataRow rowStock = (dtgv_stockWH.Rows[LotIndexSelected[i]].DataBoundItem as DataRowView).Row;
                                rowOrder = (dtgv_clientOrder.Rows[indexRowOrder].DataBoundItem as DataRowView).Row;
                                dtExportFG.Rows[i]["STT"] = (i + 1).ToString("0000");
                                dtExportFG.Rows[i]["ClientCode"] = rowOrder["TD001"];
                                dtExportFG.Rows[i]["ClientOrder"] = rowOrder["TD002"];
                                dtExportFG.Rows[i]["OrderSTT"] = rowOrder["TD003"];
                                dtExportFG.Rows[i]["Unit"] = rowOrder["TD010"];
                                dtExportFG.Rows[i]["CustomerOrder"] = rowOrder["TC012"];
                                dtExportFG.Rows[i]["Product"] = rowOrder["TD004"];
                                dtExportFG.Rows[i]["DeptCode"] = rowOrder["TC005"];
                            if (i < LotIndexSelected.Count - 1)
                            {
                                dtExportFG.Rows[i]["Quantity"] = rowStock["MM005"];
                                TongTemp +=double.Parse( rowStock["MM005"].ToString());
                            }
                            else 
                                {
                                if(QuantitySelected > QuantityDelivery)
                                dtExportFG.Rows[i]["Quantity"] = QuantityDelivery - TongTemp;
                                else
                                {
                                    dtExportFG.Rows[i]["Quantity"] = rowStock["MM005"];
                                }
                            }
                                dtExportFG.Rows[i]["LotNo"] = rowStock["MM004"];
                                dtExportFG.Rows[i]["Warehouse"] = rowStock["MM002"];
                                dtExportFG.Rows[i]["Location"] = rowStock["MM003"];
                                dtExportFG.Rows[i]["Client"] = clientCode;
                            dtExportFG.Rows[i]["TL204"] = rowStock["MM016"];
                            if (rd_exportPacking.Checked)
                                dtExportFG.Rows[i]["TL201"] = "Package";
                            else if (rd_exportPallet.Checked)
                                dtExportFG.Rows[i]["TL201"] = "Pallet";

                                try
                                {
                                    dtExportFG.Rows[i]["PriceUnit"] = numericPriceUnit.Value;
                                }
                                catch (Exception ex)
                                {

                                    dtExportFG.Rows[i]["PriceUnit"] = 0;
                                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Convert to numeric fail", ex.Message);
                                    MessageBox.Show("Convert to numeric fail");
                                }

                                //  dtExportFG.Rows[i]["Quantity"] = rowStock[""]

                            }
                        }
                   
                }

                this.Close();
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "btn_ComfirmExport_Click_1(object sender, EventArgs e)", ex.Message);
            }
        }

        private void txt_filterProduct_TextChanged(object sender, EventArgs e)
        {
            if (dtClientOrder != null && dtClientOrder.Rows.Count > 0)
            {
                dtClientOrder.DefaultView.RowFilter = string.Format("TD004 like '%{0}%'", txt_filterProduct.Text.Trim());
                OrderSelected = -1;

            }
        }

        private void txt_ClientOrderFillter_TextChanged(object sender, EventArgs e)
        {
            if (dtClientOrder != null && dtClientOrder.Rows.Count > 0)
            {
                dtClientOrder.DefaultView.RowFilter = string.Format("TC012 like '%{0}%'", txt_ClientOrderFillter.Text.Trim());
                OrderSelected = -1;

            }
        }
    }
}
