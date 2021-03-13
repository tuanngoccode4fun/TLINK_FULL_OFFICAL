using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using WindowsFormsApplication1.Device.Printer;
using WindowsFormsApplication1.WMS.Model;
using WindowsFormsApplication1.WMS.View;
using System.Windows.Documents;
using WindowsFormsApplication1.WMS.Controller;


namespace WindowsFormsApplication1.WMS
{
    public partial class INOUTManagement : CommonFormMetro
    {
        List<InforWH> ListInforWhs = new List<InforWH>();
        List<gridviewInStock> gridviewInStocks = new List<gridviewInStock>();
        List<INVTATB> ListINVTATB_NoChose = new List<INVTATB>();
        List<INVTATB> ListINVTATBdtgv = new List<INVTATB>();
        List<INVTATB> ListINVTATB = new List<INVTATB>();
        DateTimePicker oDateTimePicker;
        string IndexFormGenerate = "";
        LabelItem labelItemQRPurchase = new LabelItem();
        List<PURTD> ListPURTDS = new List<PURTD>();
        string STTHientai = "";
        Dictionary<string, int> DicNumberofCodeINVTA = new Dictionary<string, int>();
        EventBroker.EventObserver m_observerLog = null;
        int m_maxLine = 200;
        TransferMaterialUI MaterialUI = new TransferMaterialUI();
        List<dataWarehouse> ListDataChooseTransfer = new List<dataWarehouse>();
        Dictionary<string, string> GetKeyValuesDepartment = new Dictionary<string, string>();
        List<Database.WarehouseItems> ListWarehouse = new List<Database.WarehouseItems>();
        public INOUTManagement()
        {
            InitializeComponent();

            lbl_Header.Text = "WAREHOUSE MANAGEMENT SYSTEM";
            this.WindowState = FormWindowState.Maximized;

        }

        private void MakeUpDatagridview(DataGridView gridView)
        {


            gridView.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);

            gridView.Columns["TD001_Ma"].Visible = false;
            gridView.Columns["TD002_Code"].Visible = false;
            gridView.Columns["TD018_MaXacNhan"].Visible = false;
            gridView.Columns["TD012_DeliveryEstimate"].Visible = false;

            gridView.Columns["TD003_STT"].HeaderText = "No";
            gridView.Columns["TD003_STT"].ReadOnly = true;
            gridView.Columns["TD004_MaSP"].HeaderText = "Product";
            gridView.Columns["TD005_TenSP"].HeaderText = "Commodity";
            gridView.Columns["TD008_SL"].HeaderText = "Order (qty)";
            gridView.Columns["TD008_SL"].DefaultCellStyle.Format = "N2";
            gridView.Columns["TD015_SLDaGiao"].HeaderText = "Deliveried (qty)";
            gridView.Columns["TD015_SLDaGiao"].DefaultCellStyle.Format = "N2";
            gridView.Columns["TD009_Unit"].HeaderText = "Unit";
            gridView.Columns["TD007_Kho"].HeaderText = "Warehouse refer";
            gridView.Columns["SLThucgiao"].HeaderText = "Stock in (qty)";
            gridView.Columns["SLThucgiao"].DefaultCellStyle.Format = "N2";
            gridView.Columns["warehouse"].HeaderText = "Warehouse";
            gridView.Columns["location"].HeaderText = "Location";
            gridView.Columns["CheckBox"].HeaderText = "In Stock";
            gridView.Columns["ExpiryDate"].HeaderText = "Expiry Date";

            gridView.Columns["TD004_MaSP"].ReadOnly = true;
            gridView.Columns["TD005_TenSP"].ReadOnly = true;
            gridView.Columns["TD008_SL"].ReadOnly = true;
            gridView.Columns["TD015_SLDaGiao"].ReadOnly = true;
            gridView.Columns["TD009_Unit"].ReadOnly = true;
            gridView.Columns["TD007_Kho"].ReadOnly = true;
            gridView.Columns["warehouse"].HeaderText = "Warehouse";
            gridView.Columns["location"].HeaderText = "Location";
            gridView.Columns["CheckBox"].HeaderText = "In Stock";

            gridView.BackgroundColor = Color.LightSteelBlue;
            gridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;

        }

        private void INOUTManagement_Load(object sender, EventArgs e)
        {

            m_observerLog = new EventBroker.EventObserver(OnReceiveLog);
            EventBroker.AddObserver(EventBroker.EventID.etLog, m_observerLog);

            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "-------------------Start---------------  ", Text);
            DBOperation dBOperation = new DBOperation();
            ListInforWhs = dBOperation.GetInforWHs();
            DicNumberofCodeINVTA = dBOperation.NumberDigitsofCodeINVTA();
            this.txt_QRCodeIN.Focus();
            //  this.tabControl1.TabPages[0].ImageIndex = imageList1.Images[0];
            this.tabControl1.ImageList = imageList1;
            this.tabControl1.TabPages[0].ImageIndex = 0;
            this.tabControl1.TabPages[1].ImageIndex = 1;
            this.tabControl1.TabPages[2].ImageIndex = 2;
            //   this.tabControl1.tab

        }
        #region Display Log
        private void OnReceiveLog(EventBroker.EventID id, EventBroker.EventParam param)
        {
            if (param == null)
                return;
            SystemLog.MSG_TYPE type = (SystemLog.MSG_TYPE)param.ParamInt;
            if (type == SystemLog.MSG_TYPE.Err)
                Output(param.ParamString, Color.Red);
            else if (type == SystemLog.MSG_TYPE.War)
                Output(param.ParamString, Color.Yellow);
            else
                Output(param.ParamString, Color.White);
        }
        private void Output(string msg, Color brush, bool isBold = false)
        {
            UpdateText(msg, brush);
        }

        private void UpdateText(String text, Color brush)
        {
            if (!IsDisposed && !Disposing && InvokeRequired)
            {
                Invoke((Action<String, Color>)UpdateText, text, brush);
            }
            else
            {
                if (rtx_log.Lines.Count() > m_maxLine) //200 lines will remove top line
                {
                    rtx_log.SelectionStart = 0;
                    rtx_log.SelectionLength = rtx_log.Text.IndexOf("\n", 0) + 1;
                    rtx_log.SelectedText = "";
                }
                rtx_log.SelectionColor = brush;
                rtx_log.AppendText("\r\n[" + DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "] " + text);



                if (rtx_outTab.Lines.Count() > m_maxLine) //200 lines will remove top line
                {
                    rtx_outTab.SelectionStart = 0;
                    rtx_outTab.SelectionLength = rtx_outTab.Text.IndexOf("\n", 0) + 1;
                    rtx_outTab.SelectedText = "";
                }
                rtx_outTab.SelectionColor = brush;
                rtx_outTab.AppendText("\r\n[" + DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "] " + text);

            }

        }
        private void Rtx_log_TextChanged(object sender, EventArgs e)
        {
            // set the current caret position to the end
            rtx_log.SelectionStart = rtx_log.Text.Length;
            // scroll it automatically
            rtx_log.ScrollToCaret();
        }

        private void Rtx_outTab_TextChanged(object sender, EventArgs e)
        {
            rtx_outTab.SelectionStart = rtx_outTab.Text.Length;
            rtx_outTab.ScrollToCaret();
        }

        #endregion
        private void Dtgv_InStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;


            if (dtgv_InStock.Columns[e.ColumnIndex].Name == "ExpiryDate" && e.RowIndex >= 0)
            {
                oDateTimePicker = new DateTimePicker();  //DateTimePicker  
                //Adding DateTimePicker control into DataGridView 
                dtgv_InStock.Controls.Add(oDateTimePicker);
                // Intially made it invisible
                oDateTimePicker.Visible = false;
                // Setting the format (i.e. 2014-10-10)
                oDateTimePicker.Format = DateTimePickerFormat.Short;  //
                oDateTimePicker.TextChanged += new EventHandler(dateTimePicker_OnTextChange);
                // Now make it visible
                oDateTimePicker.Visible = true;
                // It returns the retangular area that represents the Display area for a cell
                Rectangle oRectangle = dtgv_InStock.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                //Setting area for DateTimePicker Control
                oDateTimePicker.Size = new Size(oRectangle.Width, oRectangle.Height);
                // Setting Location
                oDateTimePicker.Location = new Point(oRectangle.X, oRectangle.Y);
                oDateTimePicker.CloseUp += new EventHandler(oDateTimePicker_CloseUp);
            }
        }
        private void dateTimePicker_OnTextChange(object sender, EventArgs e)
        {
            dtgv_InStock.CurrentCell.Value = oDateTimePicker.Value;
        }
        void oDateTimePicker_CloseUp(object sender, EventArgs e)
        {
            oDateTimePicker.Visible = false;
        }


        private void Dtgv_InStock_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (this.dtgv_InStock.CurrentCellAddress.X == 9)
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.DropDownStyle = ComboBoxStyle.DropDown;
                }
            }
            if (this.dtgv_InStock.CurrentCellAddress.X == 11)
            {
                ComboBox cb = e.Control as ComboBox;
                if (cb != null)
                {
                    cb.DropDownStyle = ComboBoxStyle.DropDown;
                }
            }
        }

        private void Btn_confirm_Click(object sender, EventArgs e)
        {
            gridviewInStocks = new List<gridviewInStock>();
            for (int i = 0; i < dtgv_InStock.Rows.Count; i++)
            {
                //  var test2 = dtgv_InStock.Rows[i].Cells[0].Value.ToString();
                if (dtgv_InStock.Rows[i].Cells["CheckBox"].Value != null && dtgv_InStock.Rows[i].Cells["CheckBox"].Value.ToString() == "True")
                {
                    gridviewInStock inStock = new gridviewInStock();
                    inStock.TD001_Ma = dtgv_InStock.Rows[i].Cells["TD001_Ma"].Value.ToString();
                    inStock.TD002_Code = dtgv_InStock.Rows[i].Cells["TD002_Code"].Value.ToString();
                    inStock.TD003_STT = dtgv_InStock.Rows[i].Cells["TD003_STT"].Value.ToString();
                    inStock.TD004_MaSP = dtgv_InStock.Rows[i].Cells["TD004_MaSP"].Value.ToString();
                    inStock.TD005_TenSP = dtgv_InStock.Rows[i].Cells["TD005_TenSP"].Value.ToString();
                    inStock.TD008_SL = double.Parse(dtgv_InStock.Rows[i].Cells["TD008_SL"].Value.ToString());
                    inStock.SLThucte = (dtgv_InStock.Rows[i].Cells["SLThucgiao"] != null && dtgv_InStock.Rows[i].Cells["SLThucgiao"].ToString() != "") ? double.Parse(dtgv_InStock.Rows[i].Cells["SLThucgiao"].Value.ToString()) : 0;
                    inStock.TD009_Unit = dtgv_InStock.Rows[i].Cells["TD009_Unit"].Value.ToString();
                    inStock.TD007_Kho = dtgv_InStock.Rows[i].Cells["TD007_Kho"].Value.ToString();
                    inStock._Kho = (dtgv_InStock.Rows[i].Cells["warehouse"].Value != null) ? dtgv_InStock.Rows[i].Cells["warehouse"].Value.ToString() : "";
                    inStock._VitriKho = (dtgv_InStock.Rows[i].Cells["location"].Value != null) ? dtgv_InStock.Rows[i].Cells["location"].Value.ToString() : "";

                    inStock._ExpiryDay = (DateTime)dtgv_InStock.Rows[i].Cells["ExpiryDate"].Value;
                    inStock.Invoice = (dtgv_InStock.Rows[i].Cells["Invoice"].Value != null) ? dtgv_InStock.Rows[i].Cells["Invoice"].Value.ToString() : "";
                    inStock.Lot = (dtgv_InStock.Rows[i].Cells["Lot"].Value != null) ? dtgv_InStock.Rows[i].Cells["Lot"].Value.ToString() : "";
                    gridviewInStocks.Add(inStock);
                }

            }
            GenerateReceiptMaterial(gridviewInStocks);

            //   PrintQRCode(gridviewInStocks);

            txt_QRCodeIN.Text = "";
            txt_WarehouseLocation.Text = "";
            txt_confirm.Text = "";
            this.txt_QRCodeIN.Focus();
        }

        public void GenerateReceiptMaterial(List<gridviewInStock> gridviewInStocks)
        {
            try
            {
                DBOperation dBOperation = new DBOperation();
                IndexFormGenerate = dBOperation.GetMaxIndexTG002();
                DataTable dataTablePURTH = dBOperation.GetDataTableTop1PURTH();
                string IndexGenerate = dBOperation.GetMaxIndexTG002();
                dBOperation.GeneratePURTH(dataTablePURTH, gridviewInStocks, IndexGenerate);
                var result = dBOperation.GenerateRowPURTG(gridviewInStocks, IndexGenerate);
                if (result)
                    txt_generatecode.Text = "3401-" + IndexGenerate;
                SystemLog.Output(SystemLog.MSG_TYPE.War, "Stock-In Receipt Code:", "3401-" + IndexGenerate);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GenerateReceiptMaterial(List<gridviewInStock> gridviewInStocks)", ex.Message);
            }


        }

        private void Txt_QRCodeIN_TextChanged(object sender, EventArgs e)
        {


            if (sender.ToString().EndsWith("e") == true)
            {
                this.txt_WarehouseLocation.Focus();


            }

        }


        private void Txt_WarehouseLocation_TextChanged(object sender, EventArgs e)
        {



            if (txt_WarehouseLocation.Text.EndsWith("e"))
            {
                string Warehouse = txt_WarehouseLocation.Text.Substring(1, txt_WarehouseLocation.Text.Length - 2);
                var textSplit = Warehouse.Split(';');
                for (int i = 0; i < dtgv_InStock.Rows.Count; i++)
                {
                    string text2 = dtgv_InStock.Rows[i].Cells["TD004_MaSP"].Value.ToString();
                    if (dtgv_InStock.Rows[i].Cells["TD004_MaSP"].Value.ToString() == labelItemQRPurchase.MaterialCode && (dtgv_InStock.Rows[i].Cells["TD003_STT"].Value.ToString() == STTHientai))
                    {
                        dtgv_InStock.Rows[i].Cells["warehouse"].Value = textSplit[0];
                        if (textSplit[2] != "")
                            dtgv_InStock.Rows[i].Cells["location"].Value = textSplit[1] + "-" + textSplit[2];
                        else
                            dtgv_InStock.Rows[i].Cells["location"].Value = textSplit[1];

                    }
                }

                this.txt_confirm.Focus();
                SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Scan location complete", Warehouse);
            }




        }



        private void Txt_QRCodeIN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {


                if (txt_QRCodeIN.Text.EndsWith("e"))
                {

                    try
                    {


                        labelItemQRPurchase = new LabelItem();
                        string QRCodeIn = txt_QRCodeIN.Text.Substring(1, txt_QRCodeIN.Text.Length - 2);
                        var textSplit = QRCodeIn.Split(';');
                        labelItemQRPurchase.PurchasingCode = textSplit[0];
                        labelItemQRPurchase.MaterialCode = textSplit[1];

                        labelItemQRPurchase.Quantity = textSplit[2];

                        labelItemQRPurchase.ExpiryDate = DateTime.ParseExact(textSplit[3], "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        labelItemQRPurchase.LotPo = textSplit[4];
                        if (textSplit.Length == 6)
                            labelItemQRPurchase.Invoice = textSplit[5].Substring(0, textSplit[5].Length);
                        else if (textSplit.Length == 5)
                            labelItemQRPurchase.Invoice = "";

                        if (dtgv_InStock.Rows.Count == 0)
                        {
                            DBOperation dBOperation = new DBOperation();
                            ListPURTDS = new List<PURTD>();
                            dtgv_InStock.Columns.Clear();
                            ListPURTDS = dBOperation.GetPURTDsfromQRCode(labelItemQRPurchase.PurchasingCode);

                            dtgv_InStock.DataSource = ListPURTDS;
                            MakeUpDatagridview(dtgv_InStock);
                        }

                        for (int i = 0; i < dtgv_InStock.Rows.Count; i++)
                        {
                            string text2 = dtgv_InStock.Rows[i].Cells["TD004_MaSP"].Value.ToString();
                            if (dtgv_InStock.Rows[i].Cells["TD004_MaSP"].Value.ToString() == labelItemQRPurchase.MaterialCode && (dtgv_InStock.Rows[i].Cells["CheckBox"].Value != null && (bool)dtgv_InStock.Rows[i].Cells["CheckBox"].Value == false))
                            {
                                dtgv_InStock.Rows[i].Cells["CheckBox"].Value = true;
                                dtgv_InStock.Rows[i].Cells["SLThucgiao"].Value = double.Parse(labelItemQRPurchase.Quantity);
                                dtgv_InStock.Rows[i].Cells["ExpiryDate"].Value = labelItemQRPurchase.ExpiryDate;
                                dtgv_InStock.Rows[i].Cells["Lot"].Value = labelItemQRPurchase.LotPo;
                                dtgv_InStock.Rows[i].Cells["Invoice"].Value = labelItemQRPurchase.Invoice;
                                STTHientai = dtgv_InStock.Rows[i].Cells["TD003_STT"].Value.ToString();
                            }
                        }

                        this.txt_WarehouseLocation.Focus();
                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Scan Purchase receipt code", txt_QRCodeIN.Text);
                    }

                    catch (Exception ex)
                    {

                        SystemLog.Output(SystemLog.MSG_TYPE.Err, "Txt_QRCodeIN_KeyDown(object sender, KeyEventArgs e)", ex.Message);
                    }
                }

            }
        }

        private void Txt_WarehouseLocation_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.txt_QRCodeIN.Focus();
            }
        }



        private void Txt_confirm_TextChanged(object sender, EventArgs e)
        {
            if (sender.ToString().EndsWith("e") == true)
            {
                if (txt_confirm.Text == "sEe")
                {
                    gridviewInStocks = new List<gridviewInStock>();
                    for (int i = 0; i < dtgv_InStock.Rows.Count; i++)
                    {
                        //  var test2 = dtgv_InStock.Rows[i].Cells[0].Value.ToString();
                        if (dtgv_InStock.Rows[i].Cells["CheckBox"].Value != null && dtgv_InStock.Rows[i].Cells["CheckBox"].Value.ToString() == "True")
                        {
                            gridviewInStock inStock = new gridviewInStock();
                            inStock.TD001_Ma = dtgv_InStock.Rows[i].Cells["TD001_Ma"].Value.ToString();
                            inStock.TD002_Code = dtgv_InStock.Rows[i].Cells["TD002_Code"].Value.ToString();
                            inStock.TD003_STT = dtgv_InStock.Rows[i].Cells["TD003_STT"].Value.ToString();
                            inStock.TD004_MaSP = dtgv_InStock.Rows[i].Cells["TD004_MaSP"].Value.ToString();
                            inStock.TD005_TenSP = dtgv_InStock.Rows[i].Cells["TD005_TenSP"].Value.ToString();
                            inStock.TD008_SL = double.Parse(dtgv_InStock.Rows[i].Cells["TD008_SL"].Value.ToString());
                            inStock.SLThucte = (dtgv_InStock.Rows[i].Cells["SLThucgiao"] != null && dtgv_InStock.Rows[i].Cells["SLThucgiao"].ToString() != "") ? double.Parse(dtgv_InStock.Rows[i].Cells["SLThucgiao"].Value.ToString()) : 0;
                            inStock.TD009_Unit = dtgv_InStock.Rows[i].Cells["TD009_Unit"].Value.ToString();
                            inStock.TD007_Kho = dtgv_InStock.Rows[i].Cells["TD007_Kho"].Value.ToString();
                            inStock._Kho = (dtgv_InStock.Rows[i].Cells["warehouse"].Value != null) ? dtgv_InStock.Rows[i].Cells["warehouse"].Value.ToString() : "";
                            inStock._VitriKho = (dtgv_InStock.Rows[i].Cells["location"].Value != null) ? dtgv_InStock.Rows[i].Cells["location"].Value.ToString() : "";

                            inStock._ExpiryDay = (DateTime)dtgv_InStock.Rows[i].Cells["ExpiryDate"].Value;
                            inStock.Invoice = (dtgv_InStock.Rows[i].Cells["Invoice"].Value != null) ? dtgv_InStock.Rows[i].Cells["Invoice"].Value.ToString() : "";
                            inStock.Lot = (dtgv_InStock.Rows[i].Cells["Lot"].Value != null) ? dtgv_InStock.Rows[i].Cells["Lot"].Value.ToString() : "";
                            gridviewInStocks.Add(inStock);
                        }

                    }
                    GenerateReceiptMaterial(gridviewInStocks);

                    //   PrintQRCode(gridviewInStocks);

                    txt_QRCodeIN.Text = "";
                    txt_WarehouseLocation.Text = "";
                    txt_confirm.Text = "";
                    this.txt_QRCodeIN.Focus();
                }
                else if (txt_confirm.Text == "sNe")
                {
                    txt_QRCodeIN.Text = "";
                    txt_WarehouseLocation.Text = "";
                    txt_confirm.Text = "";
                    this.txt_QRCodeIN.Focus();

                }
                else if (txt_confirm.Text == "sSe")
                {
                    txt_QRCodeIN.Text = "";
                    txt_WarehouseLocation.Text = "";
                    txt_confirm.Text = "";
                    dtgv_InStock.Columns.Clear();
                    this.txt_QRCodeIN.Focus();
                    //  this.ActiveControl = txt_QRCodeIN;
                    //  txt_QRCodeIN.Select(0,1);

                }
                else if (txt_confirm.Text == "sNLe")
                {
                    txt_QRCodeIN.Text = "";
                    txt_WarehouseLocation.Text = "";
                    txt_confirm.Text = "";
                    InsertNewRowDatagridviewINStock();
                    this.txt_QRCodeIN.Focus();
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Insert next lot", "complete");
                }

            }
        }
        private void PrintQRCode(List<gridviewInStock> gridviewInStocks)
        {

            foreach (var item in gridviewInStocks)
            {
                LabelItem label = new LabelItem();
                label.Location = item._Kho + "-" + item._VitriKho;
                label.PurchasingCode = item.TD001_Ma + "-" + item.TD002_Code;
                label.MaterialCode = item.TD004_MaSP;
                label.Commodity = item.TD005_TenSP;
                label.ImportDate = DateTime.Now.Date;
                label.ExpiryDate = item._ExpiryDay;
                label.LotPo = item.Lot;
                label.Quantity = item.SLThucte.ToString("N0");
                Device.Printer.PritingLabel pritingLabel = new Device.Printer.PritingLabel();
                pritingLabel.PrintLabelQRCodeInstock(label);
                DBStockInOut dBStockInOut = new DBStockInOut();
                dBStockInOut.Insert2StockIn(item);
                Thread.Sleep(300);


            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
            PrintQRCode generateQRCode = new PrintQRCode();
            generateQRCode.Show();

        }
        private void Btn_SearchOut_Click(object sender, EventArgs e)
        {
            if (txt_QRCodeOut.Text != "")
            {
                try
                {


                    dtgv_OutStock.Columns.Clear();
                    DBOperation dBOperation = new DBOperation();
                    ListINVTATB = new List<INVTATB>();
                    ListINVTATB = dBOperation.GetINVTATBs(txt_QRCodeOut.Text);
                    dtgv_OutStock.DataSource = ListINVTATB;
                    MakeUpDatagridStockOut(dtgv_OutStock);
                    for (int i = 0; i < dtgv_OutStock.Rows.Count; i++)
                    {
                        if (dtgv_OutStock.Rows[i].Cells["Evaluation"].Value.ToString() == "FIFO NG")
                        {
                            dtgv_OutStock.Rows[i].Cells["Evaluation"].Style.BackColor = Color.Red;
                            dtgv_OutStock.Rows[i].ReadOnly = true;
                        }
                        else if (dtgv_OutStock.Rows[i].Cells["Evaluation"].Value.ToString() == "FIFO OK")
                        {
                            dtgv_OutStock.Rows[i].Cells["Evaluation"].Style.BackColor = Color.Green;
                            dtgv_OutStock.Rows[i].ReadOnly = false;
                        }
                    }
                }
                catch (Exception ex)
                {

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, " Btn_SearchOut_Click(object sender, EventArgs e)", ex.Message);
                }
            }
        }
        private void MakeUpDatagridStockOut(DataGridView gridView)
        {

            try
            {


                gridView.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
                gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);

                gridView.BackgroundColor = Color.LightSteelBlue;
                gridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
                gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;


                gridView.Columns["TA001_ma"].Visible = false;
                gridView.Columns["TA002_code"].Visible = false;
                //gridView.Columns["TD018_MaXacNhan"].Visible = false;
                //gridView.Columns["TD012_DeliveryEstimate"].Visible = false;
                gridView.Columns["checkBox"].HeaderText = "Out Stock";
                gridView.Columns["TB003_STT"].HeaderText = "No";
                gridView.Columns["TA004_BP"].HeaderText = "Department";
                gridView.Columns["TB004_SP"].HeaderText = "Product";
                gridView.Columns["TB005_TenSp"].HeaderText = "Commodity";
                gridView.Columns["TB006_Quycach"].HeaderText = "Specification";
                gridView.Columns["TB007_SL"].HeaderText = "Picking (Qty)";
                gridView.Columns["TB007_SL"].DefaultCellStyle.Format = "N2";
                gridView.Columns["SLConLai"].HeaderText = "Stock (Qty)";
                gridView.Columns["SLConLai"].DefaultCellStyle.Format = "N2";
                gridView.Columns["TB014_Lot"].HeaderText = "Picking Lot";
                gridView.Columns["TB022_SLDonggoi"].HeaderText = "Packing (Qty)";
                gridView.Columns["TB022_SLDonggoi"].DefaultCellStyle.Format = "N2";
                gridView.Columns["TB012_KhoChuyen"].HeaderText = "Picking Warehouse";
                gridView.Columns["TB026_VtKhoChuyen"].HeaderText = "Picking Location";
                gridView.Columns["TB013_khoNhan"].HeaderText = "Transfering Warehouse";
                gridView.Columns["TB027_VtKhoNhan"].HeaderText = "Transfering Location";
                gridView.Columns["TB008_Unit"].HeaderText = "Unit";
                gridView.Columns["TB023_DonViDongGoi"].HeaderText = "Packing Unit";
                gridView.Columns["TB015_ExpiryDate"].HeaderText = "Expiry Date";
                gridView.Columns["TA014_ngayCT"].HeaderText = "Document Date";


                gridView.Columns["TB003_STT"].ReadOnly = true;
                gridView.Columns["TA004_BP"].ReadOnly = true;
                gridView.Columns["TB004_SP"].ReadOnly = true;
                gridView.Columns["TB005_TenSp"].ReadOnly = true;
                gridView.Columns["TB006_Quycach"].ReadOnly = true;
                gridView.Columns["SLConLai"].ReadOnly = true;
                gridView.Columns["TB014_Lot"].ReadOnly = true;
                gridView.Columns["TB022_SLDonggoi"].ReadOnly = true;
                gridView.Columns["TB012_KhoChuyen"].ReadOnly = true;
                gridView.Columns["TB026_VtKhoChuyen"].ReadOnly = true;
                gridView.Columns["TB013_khoNhan"].ReadOnly = true;
                gridView.Columns["TB027_VtKhoNhan"].ReadOnly = true;
                gridView.Columns["TB008_Unit"].ReadOnly = true;
                gridView.Columns["TB023_DonViDongGoi"].ReadOnly = true;
                gridView.Columns["TB015_ExpiryDate"].ReadOnly = true;
                gridView.Columns["TA014_ngayCT"].ReadOnly = true;


                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "MakeUpDatagridStockOut(DataGridView gridView)", ex.Message);
            }
        }

        private void Dtgv_OutStock_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                try
                {



                    if (dtgv_OutStock.Columns[ColumnsIndex].HeaderText == "Evaluation")
                    {
                        DBOperation dBOperation = new DBOperation();

                        List<Model.LotINVMEMF> lotINVMEMFs = new List<Model.LotINVMEMF>();

                        string sp = dtgv_OutStock.Rows[RowIndex].Cells["TB004_SP"].Value.ToString();
                        string Kho = dtgv_OutStock.Rows[RowIndex].Cells["TB012_KhoChuyen"].Value.ToString();
                        double SL_StockOut = double.Parse(dtgv_OutStock.Rows[RowIndex].Cells["TB007_SL"].Value.ToString());
                        List<Model.LotINVMEMF> lotsAll = new List<LotINVMEMF>();
                        lotINVMEMFs = dBOperation.GetLotINVMEMFs(sp, Kho, out lotsAll);
                        foreach (var item in lotINVMEMFs)
                        {
                            item.SL = SL_StockOut;
                        }

                        ConfirmForm confirmForm = new ConfirmForm(txt_QRCodeOut.Text.Trim(), dtgv_OutStock.Rows[RowIndex].Cells["TB003_STT"].Value.ToString(), lotsAll);
                        confirmForm.FormClosed += ConfirmForm_FormClosed;
                        confirmForm.Show();
                    }
                }
                catch (Exception ex)
                {

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Dtgv_OutStock_CellClick(object sender, DataGridViewCellEventArgs e)", ex.Message);
                }


            }

        }

        private void ConfirmForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Btn_SearchOut_Click(sender, e);
        }



        private void Btn_confirm_Click_1(object sender, EventArgs e)
        {

            ListINVTATBdtgv = new List<INVTATB>();
            ListINVTATB_NoChose = new List<INVTATB>();
            try
            {


                for (int i = 0; i < dtgv_OutStock.Rows.Count; i++)
                {
                    if (dtgv_OutStock.Rows[i].Cells[0].Value != null && dtgv_OutStock.Rows[i].Cells[0].Value.ToString() == "True")
                    {
                        INVTATB iNVTATB = new INVTATB();
                        iNVTATB.TA001_ma = dtgv_OutStock.Rows[i].Cells["TA001_ma"].Value.ToString();
                        iNVTATB.TA002_code = dtgv_OutStock.Rows[i].Cells["TA002_code"].Value.ToString();
                        iNVTATB.TB003_STT = dtgv_OutStock.Rows[i].Cells["TB003_STT"].Value.ToString();
                        iNVTATB.Evaluation = dtgv_OutStock.Rows[i].Cells["Evaluation"].Value.ToString();
                        iNVTATB.TA004_BP = dtgv_OutStock.Rows[i].Cells["TA004_BP"].Value.ToString();
                        iNVTATB.TB004_SP = dtgv_OutStock.Rows[i].Cells["TB004_SP"].Value.ToString();
                        iNVTATB.TB005_TenSp = dtgv_OutStock.Rows[i].Cells["TB005_TenSp"].Value.ToString();
                        iNVTATB.TB006_Quycach = dtgv_OutStock.Rows[i].Cells["TB006_Quycach"].Value.ToString();
                        string ngayCT = dtgv_OutStock.Rows[i].Cells["TA014_ngayCT"].Value.ToString();
                        iNVTATB.TA014_ngayCT = (DateTime)dtgv_OutStock.Rows[i].Cells["TA014_ngayCT"].Value;
                        var stringtest = dtgv_OutStock.Rows[i].Cells["TB007_SL"].Value.ToString();
                        iNVTATB.TB007_SL = double.Parse(dtgv_OutStock.Rows[i].Cells["TB007_SL"].Value.ToString());
                        iNVTATB.TB014_Lot = dtgv_OutStock.Rows[i].Cells["TB014_Lot"].Value.ToString();
                        iNVTATB.TB012_KhoChuyen = dtgv_OutStock.Rows[i].Cells["TB012_KhoChuyen"].Value.ToString();
                        iNVTATB.TB026_VtKhoChuyen = dtgv_OutStock.Rows[i].Cells["TB026_VtKhoChuyen"].Value.ToString();
                        iNVTATB.TB013_khoNhan = dtgv_OutStock.Rows[i].Cells["TB013_khoNhan"].Value.ToString();
                        iNVTATB.TB027_VtKhoNhan = dtgv_OutStock.Rows[i].Cells["TB027_VtKhoNhan"].Value.ToString();
                        ListINVTATBdtgv.Add(iNVTATB);
                    }
                    else
                    {
                        INVTATB iNVTATB = new INVTATB();
                        iNVTATB.TA001_ma = dtgv_OutStock.Rows[i].Cells["TA001_ma"].Value.ToString();
                        iNVTATB.TA002_code = dtgv_OutStock.Rows[i].Cells["TA002_code"].Value.ToString();
                        iNVTATB.TB003_STT = dtgv_OutStock.Rows[i].Cells["TB003_STT"].Value.ToString();

                        ListINVTATB_NoChose.Add(iNVTATB);
                    }
                }

                DBOperation dBOperation = new DBOperation();
                if (ListINVTATB_NoChose.Count > 0)
                {
                    dBOperation.dtgvStockOutDelete(ListINVTATB_NoChose);
                }
                if (ListINVTATBdtgv.Count > 0)
                {
                    dBOperation.dtgvOutToINVMF(ListINVTATBdtgv);
                }
                SystemLog.Output(SystemLog.MSG_TYPE.War, "Stock-out receipt complete", txt_QRCodeOut.Text);
                Btn_SearchOut_Click(sender, e);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Btn_confirm_Click_1(object sender, EventArgs e)", ex.Message);
            }

        }

        private void Btn_newRow_Click(object sender, EventArgs e)
        {
            InsertNewRowDatagridviewINStock();
        }
        public void InsertNewRowDatagridviewINStock()
        {
            PURTD newRow = new PURTD();
            try
            {
                var pURTD = ListPURTDS.Where(d => d.TD004_MaSP == labelItemQRPurchase.MaterialCode).ToList()[0];
                newRow.CheckBox = false;
                newRow.TD001_Ma = pURTD.TD001_Ma;
                newRow.TD002_Code = pURTD.TD002_Code;
                newRow.TD003_STT = (ListPURTDS.Count + 1).ToString("0000");
                newRow.TD004_MaSP = pURTD.TD004_MaSP;
                newRow.TD005_TenSP = pURTD.TD005_TenSP;
                newRow.TD008_SL = pURTD.TD008_SL;
                newRow.TD015_SLDaGiao = pURTD.TD015_SLDaGiao;
                newRow.TD009_Unit = pURTD.TD009_Unit;
                newRow.TD007_Kho = pURTD.TD007_Kho;
                ListPURTDS.Add(newRow);
                dtgv_InStock.DataSource = null;
                dtgv_InStock.DataSource = ListPURTDS;
                MakeUpDatagridview(dtgv_InStock);
            }
            catch (Exception ex)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "Add new row datagridview stock in", ex.Message);
            }
        }

        private void Txt_QRproducts_TextChanged(object sender, EventArgs e)
        {

            if (sender.ToString().EndsWith("e") == true)
            {

                txt_QRLocation.Focus();
            }
        }

        private void Txt_QROperation_TextChanged(object sender, EventArgs e)
        {
            if (sender.ToString().EndsWith("e") == true)
            {
                try
                {


                    if (txt_QROperation.Text == "sEe")
                    {
                        ListINVTATBdtgv = new List<INVTATB>();
                        ListINVTATB_NoChose = new List<INVTATB>();
                        for (int i = 0; i < dtgv_OutStock.Rows.Count; i++)
                        {
                            if (dtgv_OutStock.Rows[i].Cells["checkBox"].Value != null && dtgv_OutStock.Rows[i].Cells["checkBox"].Value.ToString() == "True")
                            {
                                INVTATB iNVTATB = new INVTATB();
                                iNVTATB.TA001_ma = dtgv_OutStock.Rows[i].Cells["TA001_ma"].Value.ToString();
                                iNVTATB.TA002_code = dtgv_OutStock.Rows[i].Cells["TA002_code"].Value.ToString();
                                iNVTATB.TB003_STT = dtgv_OutStock.Rows[i].Cells["TB003_STT"].Value.ToString();
                                iNVTATB.Evaluation = dtgv_OutStock.Rows[i].Cells["Evaluation"].Value.ToString();
                                iNVTATB.TA004_BP = dtgv_OutStock.Rows[i].Cells["TA004_BP"].Value.ToString();
                                iNVTATB.TB004_SP = dtgv_OutStock.Rows[i].Cells["TB004_SP"].Value.ToString();
                                iNVTATB.TB005_TenSp = dtgv_OutStock.Rows[i].Cells["TB005_TenSp"].Value.ToString();
                                iNVTATB.TB006_Quycach = dtgv_OutStock.Rows[i].Cells["TB006_Quycach"].Value.ToString();
                                string ngayCT = dtgv_OutStock.Rows[i].Cells["TA014_ngayCT"].Value.ToString();
                                iNVTATB.TA014_ngayCT = (DateTime)dtgv_OutStock.Rows[i].Cells["TA014_ngayCT"].Value;
                                var stringtest = dtgv_OutStock.Rows[i].Cells["TB007_SL"].Value.ToString();
                                iNVTATB.TB007_SL = double.Parse(dtgv_OutStock.Rows[i].Cells["TB007_SL"].Value.ToString());
                                iNVTATB.TB014_Lot = dtgv_OutStock.Rows[i].Cells["TB014_Lot"].Value.ToString();
                                iNVTATB.TB012_KhoChuyen = dtgv_OutStock.Rows[i].Cells["TB012_KhoChuyen"].Value.ToString();
                                iNVTATB.TB026_VtKhoChuyen = dtgv_OutStock.Rows[i].Cells["TB026_VtKhoChuyen"].Value.ToString();
                                iNVTATB.TB013_khoNhan = dtgv_OutStock.Rows[i].Cells["TB013_khoNhan"].Value.ToString();
                                iNVTATB.TB027_VtKhoNhan = dtgv_OutStock.Rows[i].Cells["TB027_VtKhoNhan"].Value.ToString();
                                ListINVTATBdtgv.Add(iNVTATB);
                            }
                            else
                            {
                                INVTATB iNVTATB = new INVTATB();
                                iNVTATB.TA001_ma = dtgv_OutStock.Rows[i].Cells["TA001_ma"].Value.ToString();
                                iNVTATB.TA002_code = dtgv_OutStock.Rows[i].Cells["TA002_code"].Value.ToString();
                                iNVTATB.TB003_STT = dtgv_OutStock.Rows[i].Cells["TB003_STT"].Value.ToString();

                                ListINVTATB_NoChose.Add(iNVTATB);
                            }

                        }


                        DBOperation dBOperation = new DBOperation();

                        if (ListINVTATBdtgv.Count > 0)
                        {
                            dBOperation.dtgvOutToINVMF(ListINVTATBdtgv);
                        }
                        if (ListINVTATB_NoChose.Count > 0)
                        {
                            dBOperation.dtgvStockOutDelete(ListINVTATB_NoChose);
                        }
                        Btn_SearchOut_Click(sender, e);
                        txt_QRproducts.Text = "";
                        txt_QRLocation.Text = "";
                        txt_QROperation.Text = "";
                        txt_QRCodeOut.Text = "";
                        SystemLog.Output(SystemLog.MSG_TYPE.War, "Stock-out receipt complete", txt_QRCodeOut.Text);
                        txt_QRCodeOut.Focus();
                    }

                    else if (txt_QROperation.Text == "sNe")
                    {
                        //   txt_QRCodeOut.Text = "";
                        txt_QRproducts.Text = "";
                        txt_QRLocation.Text = "";
                        txt_QROperation.Text = "";
                        this.txt_QRproducts.Focus();

                    }
                    else if (txt_confirm.Text == "sSe")
                    {
                        txt_QRCodeOut.Text = "";
                        txt_QRproducts.Text = "";
                        txt_QROperation.Text = "";
                        txt_QRLocation.Text = "";
                        dtgv_OutStock.Columns.Clear();


                    }
                    else if (txt_confirm.Text == "sNLe")
                    {
                        txt_QRCodeOut.Text = "";
                        txt_QRproducts.Text = "";
                        txt_QROperation.Text = "";
                        txt_QRLocation.Text = "";
                        this.txt_QRproducts.Focus();
                    }

                }
                catch (Exception ex)
                {

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Txt_QROperation_TextChanged(object sender, EventArgs e)", ex.Message);
                }
            }
        }


        private void Txt_QRLocation_TextChanged(object sender, EventArgs e)
        {
            if (sender.ToString().EndsWith("e") == true)
            {
                if (txt_QRLocation.Text.EndsWith("e"))
                {

                    string textQRProducts = txt_QRproducts.Text.Substring(1, txt_QRproducts.Text.Length - 2);
                    var ArrayLabelProduct = textQRProducts.Split(';');

                    string TextQRLocation = txt_QRLocation.Text.Substring(1, txt_QRLocation.Text.Length - 2);

                    var ArrayLabelQRlocation = TextQRLocation.Split(';');
                    for (int i = 0; i < dtgv_OutStock.Rows.Count; i++)
                    {
                        string text2 = dtgv_OutStock.Rows[i].Cells["Evaluation"].Value.ToString();
                        if (dtgv_OutStock.Rows[i].Cells["Evaluation"].Value.ToString() == "FIFO OK")
                        {
                            if (dtgv_OutStock.Rows[i].Cells["TB004_SP"].Value.ToString() == ArrayLabelProduct[1] && dtgv_OutStock.Rows[i].Cells["TB014_Lot"].Value.ToString() == ArrayLabelProduct[4])
                            {

                                if (dtgv_OutStock.Rows[i].Cells["TB012_KhoChuyen"].Value.ToString() == ArrayLabelQRlocation[0] && dtgv_OutStock.Rows[i].Cells["TB026_VtKhoChuyen"].Value.ToString().Contains(ArrayLabelQRlocation[1]))
                                {
                                    dtgv_OutStock.Rows[i].Cells["checkBox"].Value = true;
                                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "Scan QR location (Stock-out) complete", txt_QRLocation.Text);
                                    txt_QROperation.Focus();
                                    return;
                                    // MessageBox.Show("Ban da chon xuat kho vat lieu /san pham: \n" + ArrayLabelProduct[1] + "vi tri " + txt_QRLocation.Text);
                                }
                                else
                                {
                                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "You are picking Wrong location \n Please check again! ", "");
                                    MessageBox.Show("You are picking Wrong location \n Please check again! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    txt_QRLocation.Text = "";
                                    txt_QRLocation.Focus();
                                    return;

                                }
                            }

                        }
                    }


                }
            }
        }
        private void Txt_QRCodeOut_TextChanged(object sender, EventArgs e)
        {
            if (txt_QRCodeOut.Text.Length > 4)
            {
                try
                {

                    string code = txt_QRCodeOut.Text.Substring(0, 4);
                    int countNumberDigist = 0;
                    if (DicNumberofCodeINVTA.ContainsKey(code))
                        countNumberDigist = DicNumberofCodeINVTA[code];
                    if (txt_QRCodeOut.Text.Length == countNumberDigist && countNumberDigist > 0)
                    {
                        dtgv_OutStock.Columns.Clear();
                        DBOperation dBOperation = new DBOperation();
                        string maCode = txt_QRCodeOut.Text.Trim();

                        ListINVTATB = new List<INVTATB>();
                        ListINVTATB = dBOperation.GetINVTATBs(maCode);
                        dtgv_OutStock.DataSource = ListINVTATB;
                        MakeUpDatagridStockOut(dtgv_OutStock);
                        for (int i = 0; i < dtgv_OutStock.Rows.Count; i++)
                        {
                            if (dtgv_OutStock.Rows[i].Cells["Evaluation"].Value.ToString() == "FIFO NG")
                            {
                                dtgv_OutStock.Rows[i].Cells["Evaluation"].Style.BackColor = Color.Red;
                                dtgv_OutStock.Rows[i].ReadOnly = true;
                            }
                            else if (dtgv_OutStock.Rows[i].Cells["Evaluation"].Value.ToString() == "FIFO OK")
                            {
                                dtgv_OutStock.Rows[i].Cells["Evaluation"].Style.BackColor = Color.Green;
                                dtgv_OutStock.Rows[i].ReadOnly = false;
                            }
                        }
                        txt_QRproducts.Focus();
                    }

                }
                catch (Exception ex)
                {

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Txt_QRCodeOut_TextChanged(object sender, EventArgs e)", ex.Message);
                }
            }
        }

        private void Txt_QRproducts_KeyDown(object sender, KeyEventArgs e)
        {


            if (txt_QRproducts.Text.EndsWith("e"))
            {
                try
                {


                    string text = txt_QRproducts.Text.Substring(1, txt_QRproducts.Text.Length - 2);

                    var ArrayLabelProduct = text.Split(';');


                    var Item = ListINVTATB.Where(d => d.TB004_SP == ArrayLabelProduct[1] && d.TB014_Lot == ArrayLabelProduct[4]).ToList();
                    if (Item.Count == 0)
                    {
                        SystemLog.Output(SystemLog.MSG_TYPE.War, "You are picking wrong product and lot", "");
                        MessageBox.Show("You are picking wrong product and lot\n Please check again! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txt_QRproducts.Text = "";
                        txt_QRproducts.Focus();
                    }
                    else
                    {
                        SystemLog.Output(SystemLog.MSG_TYPE.War, "Scan QR material", txt_QRproducts.Text);
                        txt_QRLocation.Focus();

                    }

                }
                catch (Exception ex)
                {

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "Txt_QRproducts_KeyDown(object sender, KeyEventArgs e)", ex.Message);
                }

            }



        }

        private void INOUTManagement_FormClosed(object sender, FormClosedEventArgs e)
        {


            EventBroker.EventObserver.RemoveAll(m_observerLog, m_observerLog);
            EventBroker.Relase();//tat nhung Event chay ngam di
            m_observerLog = null;
        }


        private void Btn_load_Click(object sender, EventArgs e)
        {
            DBOperation dBOperation = new DBOperation();
            List<dataWarehouse> warehouses = dBOperation.GetDataWarehousesfromINVMM(cb_warehouse.Text, dtpicker_CreateDate.Value);
            dtgv_dataWarehouse.Columns.Clear();
            dtgv_dataWarehouse.DataSource = null;
            dtgv_dataWarehouse.DataSource = warehouses;
            MakeUpDatagridArrangement(dtgv_dataWarehouse);

        }

        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:
                    // Do nothing here (let's suppose that TabPage index 0 is the address information which is already loaded.
                    break;
                case 1:

                    break;
                case 2:
                    //Load data warehouse
                    string sqlQuerry = " select distinct MM002 from INVMM where MM002 != ''";
                    SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                    sqlTLVN2.getComboBoxData(sqlQuerry, ref cb_warehouse);
                    cb_warehouse.SelectedIndex = -1; ;
                    DBOperation dBOperation = new DBOperation();
              //      lb_CreateDate.Text = "1103-" + dBOperation.GetMaxIndexTA002(dtpicker_CreateDate.Value);
                    GetKeyValuesDepartment = dBOperation.GetKeyValuesDepartments();
                    cb_department.DataSource = GetKeyValuesDepartment.Keys.ToList();
                    cb_department.SelectedIndex = -1;
                    //  cb_warehouse.SelectedIndex = 0;

                    // cb_warehouse.Text = "Y12";
                    //   cb_warehouse.Refresh();

              
                    break;
              
            }
        }

        private void MakeUpDatagridArrangement(DataGridView gridView)
        {

            try
            {
                gridView.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
                gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);

                gridView.BackgroundColor = Color.LightSteelBlue;
                gridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
                gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;

                gridView.Columns["checkbox"].HeaderText = "Choose";
                gridView.Columns["warehouse_MM002"].HeaderText = "Warehouse";
                gridView.Columns["location_MM003"].HeaderText = "Location";
                gridView.Columns["maSP_MM001"].HeaderText = "Material";
                gridView.Columns["Lot_MM004"].HeaderText = "Lot";
                gridView.Columns["Soluong_MM005"].HeaderText = "Quanity";

                gridView.Columns["Soluong_MM005"].DefaultCellStyle.Format = "N2";
                gridView.Columns["ExpiryDate"].HeaderText = "Expiry Date";

                gridView.Columns["ExpiryDate"].DefaultCellStyle.Format = "dd/MM/yyyy";

                gridView.Columns["location_Transfer"].Visible = false;
                gridView.Columns["Soluong_Transfer"].Visible = false;
                gridView.Columns["warehouse_MM002"].Visible = false;

                gridView.Columns["warehouse_MM002"].ReadOnly = true;
                gridView.Columns["location_MM003"].ReadOnly = true;
                gridView.Columns["maSP_MM001"].ReadOnly = true;
                gridView.Columns["Lot_MM004"].ReadOnly = true;
                gridView.Columns["Soluong_MM005"].ReadOnly = true;

               
                //for (int i = 0; i < dtgv_dataWarehouse.Rows.Count; i++)
                //{
                //    if ((double)dtgv_dataWarehouse.Rows[i].Cells["Soluong_MM005"].Value <= 0)
                //        dtgv_dataWarehouse.Rows[i].Cells["checkbox"].ReadOnly = true;
                //    //if ((DateTime)dtgv_dataWarehouse.Rows[i].Cells["ExpiryDate"].Value == DateTime.MinValue)
                //    //    dtgv_dataWarehouse.Rows[i].Cells["ExpiryDate"].Value = "";
                //    // else dtgv_dataWarehouse.Rows[i].Cells["ExpiryDate"]. = "dd/MM/yyyy";
                //}

                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "MakeUpDatagridStockOut(DataGridView gridView)", ex.Message);
            }
        }
        private void MakeUpDatagridMaterialChoose(DataGridView gridView)
        {

            try
            {


                gridView.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
                gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);

                gridView.BackgroundColor = Color.LightSteelBlue;
                gridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
                gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;

                gridView.Columns["warehouse_MM002"].HeaderText = "Warehouse";
                gridView.Columns["location_MM003"].HeaderText = "Location";
                gridView.Columns["maSP_MM001"].HeaderText = "Material";
                gridView.Columns["Lot_MM004"].HeaderText = "Lot";
                gridView.Columns["Soluong_Transfer"].HeaderText = "Quanity";
                gridView.Columns["Soluong_Transfer"].DefaultCellStyle.Format = "N2";
                gridView.Columns["maSP_MM001"].ReadOnly = true;
                gridView.Columns["Lot_MM004"].ReadOnly = true;
                gridView.Columns["warehouse_MM002"].ReadOnly = true;
                gridView.Columns["checkbox"].Visible = false;
                gridView.Columns["location_MM003"].Visible = false;
                gridView.Columns["location_Transfer"].Visible = false;
                gridView.Columns["Soluong_MM005"].Visible = false;
                gridView.Columns["warehouse_MM002"].Visible = false;
                gridView.Columns["ExpiryDate"].Visible = false;
                DataGridViewComboBoxColumn comboBoxColumnLocation = new DataGridViewComboBoxColumn();
                comboBoxColumnLocation.Name = "TransferLocation";
                comboBoxColumnLocation.HeaderText = "New location";
                comboBoxColumnLocation.CellTemplate.Style.BackColor = Color.WhiteSmoke;
                comboBoxColumnLocation.CellTemplate.Style.ForeColor = Color.DarkOliveGreen;
                comboBoxColumnLocation.HeaderCell.Style.BackColor = Color.Orange;
                comboBoxColumnLocation.ToolTipText = "input new location";
                comboBoxColumnLocation.DisplayStyle = DataGridViewComboBoxDisplayStyle.ComboBox;
                DataTable dt = new DataTable();
                string sqlQuerry = "select distinct NL002 from CMSNL where NL001  = '" + cb_warehouse.Text + "'";
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    comboBoxColumnLocation.Items.Add(dt.Rows[i]["NL002"].ToString());
                }


                gridView.Columns.Insert(4, comboBoxColumnLocation);

                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "MakeUpDatagridStockOut(DataGridView gridView)", ex.Message);
            }
        }
        private void Dtgv_dataWarehouse_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                if (dtgv_dataWarehouse.Columns[e.ColumnIndex].Name == "checkbox")
                {
                    try
                    {
                        if ((double)dtgv_dataWarehouse.Rows[e.RowIndex].Cells["Soluong_MM005"].Value < 0)
                        {
                            MessageBox.Show("Stock quantity must be greater than 0 ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dtgv_dataWarehouse.Rows[e.RowIndex].Cells["checkbox"].Value = false;
                            
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Input data wrong format", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

            }
        }

        private void Btn_transfer_Click(object sender, EventArgs e)
        {

            try
            {
                ListDataChooseTransfer = new List<dataWarehouse>();
                for (int i = 0; i < dtgv_dataWarehouse.Rows.Count; i++)
                {
                    if ((bool)dtgv_dataWarehouse.Rows[i].Cells["checkbox"].Value == true)
                    {
                        dataWarehouse data = new dataWarehouse();
                        data.checkbox = true;
                        data.warehouse_MM002 = (string)dtgv_dataWarehouse.Rows[i].Cells["warehouse_MM002"].Value;
                        data.location_MM003 = (string)dtgv_dataWarehouse.Rows[i].Cells["location_MM003"].Value; ;
                        data.maSP_MM001 = (string)dtgv_dataWarehouse.Rows[i].Cells["maSP_MM001"].Value;
                        data.Lot_MM004 = (string)dtgv_dataWarehouse.Rows[i].Cells["lot_MM004"].Value;
                        data.Soluong_MM005 = (double)dtgv_dataWarehouse.Rows[i].Cells["Soluong_MM005"].Value;
                        data.Soluong_Transfer = (double)dtgv_dataWarehouse.Rows[i].Cells["Soluong_MM005"].Value;
                        ListDataChooseTransfer.Add(data);
                    }

                }
                DBOperation dBOperation = new DBOperation();
                lb_CreateDate.Text = "1103-" + dBOperation.GetMaxIndexTA002(dtpicker_CreateDate.Value);
                dtgv_materialTransfer.Columns.Clear();
                dtgv_materialTransfer.DataSource = null;
              
                if (ListDataChooseTransfer.Count > 0)
                {
                    dtgv_materialTransfer.DataSource = ListDataChooseTransfer;
                    MakeUpDatagridMaterialChoose(dtgv_materialTransfer);
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, " Btn_transfer_Click(object sender, EventArgs e)", ex.Message);
            }

        }
        public void Loadatawarehouse()
        {
            DBOperation dBOperation = new DBOperation();
            List<dataWarehouse> warehouses = dBOperation.GetDataWarehousesfromINVMM(cb_warehouse.Text,dtpicker_CreateDate.Value);
            dtgv_dataWarehouse.Columns.Clear();
            dtgv_dataWarehouse.DataSource = warehouses;
            MakeUpDatagridArrangement(dtgv_dataWarehouse);
        }
        private void Cb_warehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            DBOperation dBOperation = new DBOperation();
            List<dataWarehouse> warehouses = dBOperation.GetDataWarehousesfromINVMM(cb_warehouse.Text, dtpicker_CreateDate.Value);
            dtgv_dataWarehouse.Columns.Clear();
            dtgv_dataWarehouse.DataSource = null;
            dtgv_dataWarehouse.DataSource = warehouses;
            MakeUpDatagridArrangement(dtgv_dataWarehouse);

       
        }

        private void Btn_confirmTransfer_Click(object sender, EventArgs e)
        {
            try
            {
                if(cb_department.SelectedIndex==-1)
                {
                    MessageBox.Show("You have to choose department first!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }


                DateTime CreateDate = dtpicker_CreateDate.Value;
                if (ListDataChooseTransfer != null && ListDataChooseTransfer.Count > 0)
                {
                    for (int i = 0; i < dtgv_materialTransfer.Rows.Count; i++)
                    {
                        if (dtgv_materialTransfer.Rows[i].Cells["TransferLocation"].Value == null)
                        {
                            MessageBox.Show("You have to choose new location", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        ListDataChooseTransfer[i].location_Transfer = (string)dtgv_materialTransfer.Rows[i].Cells["TransferLocation"].Value;
                        ListDataChooseTransfer[i].Soluong_Transfer = (double)dtgv_materialTransfer.Rows[i].Cells["Soluong_Transfer"].Value;
                    }


                    DBOperation dBOperation = new DBOperation();
                    dBOperation.DoingUpdateDBFormaterialArrangement((string)cb_department.SelectedItem, ListDataChooseTransfer, CreateDate);
                    Loadatawarehouse();
                    dtgv_materialTransfer.DataSource = null;
                    dtgv_materialTransfer.Rows.Clear();
                    dtgv_materialTransfer.Columns.Clear();
                    
                }

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Btn_confirmTransfer_Click(object sender, EventArgs e)", ex.Message);
            }
        }

      

        private void Dtgv_materialTransfer_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >=0)
            {
                if (dtgv_materialTransfer.Columns[e.ColumnIndex].Name == "Soluong_Transfer")
                {
                    try
                    {
                        if ((double)dtgv_materialTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value > (double)dtgv_materialTransfer.Rows[e.RowIndex].Cells["Soluong_MM005"].Value)
                        {
                            MessageBox.Show("Transfer quantity less than or equal to stock quantity ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dtgv_materialTransfer.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtgv_materialTransfer.Rows[e.RowIndex].Cells["Soluong_MM005"].Value;
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Input data wrong format", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }


        }

        private void Cb_department_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_department.SelectedIndex >= 0)
                lb_departName.Text = GetKeyValuesDepartment[(string)cb_department.SelectedItem];
            else if (cb_department.SelectedIndex ==-1)
            {
                lb_departName.Text = "";
            }
        }

       

       

        private void Btn_fiilter_Click(object sender, EventArgs e)
        {
            try
            {


                DBOperation dBOperation = new DBOperation();
                List<dataWarehouse> warehouses = dBOperation.GetDataWarehousesfromINVMMFiltterLot(cb_warehouse.Text, dtpicker_CreateDate.Value, txt_lotFillter.Text.ToUpper(), txt_materialFilter.Text.ToUpper());
                dtgv_dataWarehouse.Columns.Clear();
                dtgv_dataWarehouse.DataSource = null;
                dtgv_dataWarehouse.DataSource = warehouses;
                MakeUpDatagridArrangement(dtgv_dataWarehouse);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Txt_lotFillter_TextChanged(object sender, EventArgs e)", ex.Message);
            }

        }

      

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
              //  ListDataChooseTransfer = new List<dataWarehouse>();
              if(dtgv_materialTransfer.Rows.Count >0)
               ListDataChooseTransfer = (List<dataWarehouse>) dtgv_materialTransfer.DataSource;
              else ListDataChooseTransfer = new List<dataWarehouse>();
                for (int i = 0; i < dtgv_dataWarehouse.Rows.Count; i++)
                {
                    if ((bool)dtgv_dataWarehouse.Rows[i].Cells["checkbox"].Value == true)
                    {
                        dataWarehouse data = new dataWarehouse();
                        data.checkbox = true;
                        data.warehouse_MM002 = (string)dtgv_dataWarehouse.Rows[i].Cells["warehouse_MM002"].Value;
                        data.location_MM003 = (string)dtgv_dataWarehouse.Rows[i].Cells["location_MM003"].Value; ;
                        data.maSP_MM001 = (string)dtgv_dataWarehouse.Rows[i].Cells["maSP_MM001"].Value;
                        data.Lot_MM004 = (string)dtgv_dataWarehouse.Rows[i].Cells["lot_MM004"].Value;
                        data.Soluong_MM005 = (double)dtgv_dataWarehouse.Rows[i].Cells["Soluong_MM005"].Value;
                        data.Soluong_Transfer = (double)dtgv_dataWarehouse.Rows[i].Cells["Soluong_MM005"].Value;

                        if (ListDataChooseTransfer.Count > 0)
                        {
                            var matches = ListDataChooseTransfer.Where(d => d.maSP_MM001 == data.maSP_MM001 && d.Lot_MM004 == data.Lot_MM004 && d.location_MM003 == data.location_MM003).ToList();
                            if(matches.Count == 0)
                            ListDataChooseTransfer.Add(data);
                        }
                        else if (ListDataChooseTransfer.Count == 0)
                            ListDataChooseTransfer.Add(data);
                    }

                }
                DBOperation dBOperation = new DBOperation();
                lb_CreateDate.Text = "1103-" + dBOperation.GetMaxIndexTA002(dtpicker_CreateDate.Value);
                dtgv_materialTransfer.Columns.Clear();
                dtgv_materialTransfer.DataSource = null;
                if (ListDataChooseTransfer.Count > 0)
                {
                    dtgv_materialTransfer.DataSource = ListDataChooseTransfer;
                    MakeUpDatagridMaterialChoose(dtgv_materialTransfer);
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, " Btn_transfer_Click(object sender, EventArgs e)", ex.Message);
            }
        }

     

    
        public int RowIndexClick = -1;
        public int ColumsIndexClick = -1;
        private void Dtgv_materialTransfer_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip m = new ContextMenuStrip();
                m.Name = "delete";
                m.BackColor = Color.OrangeRed;
               
               // m.MenuItems.Add(new MenuItem("delete"));
             

                int currentMouseOverRow = dtgv_materialTransfer.HitTest(e.X, e.Y).RowIndex;
                RowIndexClick = currentMouseOverRow;
                if (currentMouseOverRow >= 0)
                {
                    m.Items.Add("Delete");
                    
                    m.ItemClicked += M_ItemClicked;
                }

                m.Show(dtgv_materialTransfer, new Point(e.X, e.Y));

            }
        }

        private void M_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                if (dtgv_materialTransfer.Rows.Count > 0)
                {
                    ListDataChooseTransfer = (List<dataWarehouse>)dtgv_materialTransfer.DataSource;
                    ListDataChooseTransfer.RemoveAt(RowIndexClick);
                    dtgv_materialTransfer.Columns.Clear();
                    dtgv_materialTransfer.DataSource = null;
                 
                    if (ListDataChooseTransfer.Count > 0)
                    {
                        dtgv_materialTransfer.DataSource = ListDataChooseTransfer;
                        MakeUpDatagridMaterialChoose(dtgv_materialTransfer);
                    }
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, " M_ItemClicked(object sender, ToolStripItemClickedEventArgs e)", ex.Message);
            }
        }

        private void Btn_deleteAll_Click(object sender, EventArgs e)
        {         
            dtgv_materialTransfer.Columns.Clear();
            dtgv_materialTransfer.DataSource = null;
        }

        private void btn_openCoolingRoom_Click(object sender, EventArgs e)
        {
            View.ProductionMaterial productionMaterial = new ProductionMaterial();
            productionMaterial.Show();
        }
    }
}
