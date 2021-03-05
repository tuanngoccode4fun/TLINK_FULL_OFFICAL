using Microsoft.Office.Interop.Excel;
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
namespace WindowsFormsApplication1.Planning
{
    public partial class PlanningMain : CommonFormMetro
    {
        DateTime from = DateTime.MinValue;
        DateTime to = DateTime.MinValue;
        List<OrderVariable> orderVariables;
        Dictionary<string, List<dataContent>> listplanShipment = new Dictionary<string, List<dataContent>>();
        Dictionary<string, List<dataContent>> listplanShipmentPage2 = new Dictionary<string, List<dataContent>>();
        Dictionary<string, PlanningItem> ListPlanning = new Dictionary<string, PlanningItem>();
        string PathFoler = @"C:\ERP_Temp\";
        Dictionary<string, string> DicLanguageSetting = new Dictionary<string, string>();
        public PlanningMain()
        {
            InitializeComponent();
            dtp_from.Value = DateTime.Now.AddDays(0);
            dtp_to.Value = DateTime.Now.AddDays(21);
            dtpk_FromPage2.Value = DateTime.Now.AddDays(0);
            dtpk_ToPage2.Value = DateTime.Now.AddDays(21);
            from = dtp_from.Value;
            to = dtp_to.Value;
            lbl_Header.Text = "PRODUCTION PLANNING ON " + DateTime.Now.ToString("dd-MMM-yyyy");
            //    SettingDataGridviewContent();
            this.WindowState = FormWindowState.Maximized;
            if (Class.valiballecommon.GetStorage().Language == "TiengViet")
                lbl_Header.Text = "KE HOACH SAN XUAT NGAY " + DateTime.Now.ToString("dd-MMM-yyyy");
            else if (Class.valiballecommon.GetStorage().Language == "English")
                lbl_Header.Text = "PRODUCTION PLANNING ON " + DateTime.Now.ToString("dd-MMM-yyyy");
            else if (Class.valiballecommon.GetStorage().Language == "Chinese")
                lbl_Header.Text = "生产计划表     " +DateTime.Now.Year.ToString()+"  年  "  + DateTime.Now.Month.ToString() +"  月  " + DateTime.Now.Day.ToString() + " 日" ;
            //  lbl_Header.Text = "PRODUCTION PLANNING ON " + DateTime.Now.ToString("dd-MMM-yyyy");
            CreateFolderDeleteFilesExcelold();

            //     CreateDatagridview(ref dtgv_header);
        }
        #region TabPage MH Clients
        private void SettingHeaderDataGridViewHeader ( DataGridView dataGridView)
        {
            if (DicLanguageSetting == null || DicLanguageSetting.Count == 0)
            {
                dataGridView.Columns["products"].HeaderText = "Product";
                dataGridView.Columns["clients"].HeaderText = "Client";
                dataGridView.Columns["Amount_Of_Order"].HeaderText = "Amount of Orders";
                dataGridView.Columns["Amount_Of_Order"].Width = 100;
                dataGridView.Columns["Amount_Of_Order"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["Total_Order_Qty"].HeaderText = "Total Order (Qty)";
                dataGridView.Columns["Total_Order_Qty"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["StockWH"].HeaderText = "Finished Goods (Qty)";
                dataGridView.Columns["StockWH"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["ShortageStock"].HeaderText = "Shortage (Qty)";
                dataGridView.Columns["ShortageStock"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["SemiStock"].HeaderText = "Semi Finished goods (Qty)";
                dataGridView.Columns["SemiStock"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["SemiStock"].Width = 60;
                dataGridView.Columns["MQCStock"].HeaderText = "MQC Remain (Qty)";
                dataGridView.Columns["MQCStock"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["PQCStock"].HeaderText = "PQC Remain (Qty)";
                dataGridView.Columns["PQCStock"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["IntoWH"].HeaderText = "Warehouse pending (Qty)";
                dataGridView.Columns["IntoWH"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["WIPQty"].HeaderText = "WIP (Qty)";
                dataGridView.Columns["WIPQty"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["HENN"].HeaderText = "HENN";
                dataGridView.Columns["HENNStock"].HeaderText = "HENN Stock (Qty)";
                dataGridView.Columns["HENNStock"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["QtyInBox"].HeaderText = "Qty /Box";
                dataGridView.Columns["QtyInBox"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["ToolPcs"].HeaderText = "Tool (pcs)";
                dataGridView.Columns["ToolPcs"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["ShiftA"].HeaderText = "Day Shift (Qty)";
                dataGridView.Columns["ShiftA"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["ShiftB"].HeaderText = "Night Shift (Qty)";
                dataGridView.Columns["ShiftB"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["productivity"].HeaderText = "Total (Qty)";
                dataGridView.Columns["productivity"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["ManufactureQty"].HeaderText = "Manufacture Plan (Qty)";
                dataGridView.Columns["ManufactureQty"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["WorkerQty"].HeaderText = "Amount of Worker";
                dataGridView.Columns["WorkerQty"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["WorkerTarget"].HeaderText = "Target of Worker";
                dataGridView.Columns["WorkerTarget"].DefaultCellStyle.Format = "N0";
            }
            else if (DicLanguageSetting.Count > 0)
            {
                dataGridView.Columns["products"].HeaderText = DicLanguageSetting["products"];
                dataGridView.Columns["clients"].HeaderText = DicLanguageSetting["clients"];
                dataGridView.Columns["Amount_Of_Order"].HeaderText = DicLanguageSetting["Amount_Of_Order"];
                dataGridView.Columns["Amount_Of_Order"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["Total_Order_Qty"].HeaderText = DicLanguageSetting["Total_Order_Qty"];
                dataGridView.Columns["Total_Order_Qty"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["StockWH"].HeaderText = DicLanguageSetting["StockWH"];
                dataGridView.Columns["StockWH"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["ShortageStock"].HeaderText = DicLanguageSetting["ShortageStock"];
                dataGridView.Columns["ShortageStock"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["SemiStock"].HeaderText = DicLanguageSetting["SemiStock"];
                dataGridView.Columns["SemiStock"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["MQCStock"].HeaderText = DicLanguageSetting["MQCStock"];
                dataGridView.Columns["MQCStock"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["PQCStock"].HeaderText = DicLanguageSetting["PQCStock"];
                dataGridView.Columns["PQCStock"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["IntoWH"].HeaderText = DicLanguageSetting["IntoWH"];
                dataGridView.Columns["IntoWH"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["WIPQty"].HeaderText = DicLanguageSetting["WIPQty"];
                dataGridView.Columns["WIPQty"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["HENN"].HeaderText = DicLanguageSetting["HENN"];
                dataGridView.Columns["HENNStock"].HeaderText = DicLanguageSetting["HENNStock"];
                dataGridView.Columns["HENNStock"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["QtyInBox"].HeaderText = DicLanguageSetting["QtyInBox"];
                dataGridView.Columns["QtyInBox"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["ToolPcs"].HeaderText = DicLanguageSetting["ToolPcs"];
                dataGridView.Columns["ToolPcs"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["ShiftA"].HeaderText = DicLanguageSetting["ShiftA"];
                dataGridView.Columns["ShiftA"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["ShiftB"].HeaderText = DicLanguageSetting["ShiftB"];
                dataGridView.Columns["ShiftB"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["productivity"].HeaderText = DicLanguageSetting["productivity"];
                dataGridView.Columns["productivity"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["ManufactureQty"].HeaderText = DicLanguageSetting["ManufactureQty"];
                dataGridView.Columns["ManufactureQty"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["WorkerQty"].HeaderText = DicLanguageSetting["WorkerQty"];
                dataGridView.Columns["WorkerQty"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["WorkerTarget"].HeaderText = DicLanguageSetting["WorkerTarget"];
                dataGridView.Columns["WorkerTarget"].DefaultCellStyle.Format = "N0";
            }
            dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular);
            dataGridView.BackgroundColor = Color.LightSteelBlue;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;

            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.AllowUserToResizeColumns = true;
            dataGridView.AllowUserToResizeRows = true;
            dataGridView.AllowDrop = true;
            dataGridView.ColumnHeadersHeight = 100;
            dataGridView.RowHeadersWidth = 30;
            if(dataGridView.Name == "dtgv_HeaderPage2")
            {
                dataGridView.Columns["SemiStock"].Visible = false;
                dataGridView.Columns["MQCStock"].Visible = false;
                dataGridView.Columns["PQCStock"].Visible = false;

                dataGridView.Columns["IntoWH"].Visible = false;
                dataGridView.Columns["WIPQty"].Visible = false;
            }

            //for (int i = 0; i < 20; i++)
            //{
            //    dtgv_header.Columns[i].Frozen = false;
            //}
            //dtgv_header.ScrollBars = ScrollBars.Both;
        }
        private void SettingHeaderDataGridViewContent(DataGridView dataGridView)
        {if (DicLanguageSetting == null|| DicLanguageSetting.Count == 0)
            {
                dataGridView.Columns["ClientOrderDate"].HeaderText = "Client Request's Date";
                dataGridView.Columns["OrderCode"].HeaderText = "Order Code";
                dataGridView.Columns["ClientOrder"].HeaderText = "Client Order Code";
                dataGridView.Columns["OrderQty"].HeaderText = "Client Order Qty";
                dataGridView.Columns["OrderQty"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["ShortageQty"].HeaderText = "Shortage Qty";
                dataGridView.Columns["ShortageQty"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["RemainDay"].HeaderText = "Time remaining";
                dataGridView.Columns["RemainDay"].DefaultCellStyle.Format = "N1";
                dataGridView.Columns["TargetQtyDay"].HeaderText = "Target Qty/ Days";
                dataGridView.Columns["TargetQtyDay"].DefaultCellStyle.Format = "N0";
            }
        else if (DicLanguageSetting.Count > 0)
            {
                dataGridView.Columns["ClientOrderDate"].HeaderText = DicLanguageSetting["ClientOrderDate"];
                dataGridView.Columns["OrderCode"].HeaderText = DicLanguageSetting["OrderCode"];
                dataGridView.Columns["ClientOrder"].HeaderText = DicLanguageSetting["ClientOrder"];
                dataGridView.Columns["OrderQty"].HeaderText = DicLanguageSetting["OrderQty"];
                dataGridView.Columns["OrderQty"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["ShortageQty"].HeaderText = DicLanguageSetting["ShortageQty"];
                dataGridView.Columns["ShortageQty"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["RemainDay"].HeaderText = DicLanguageSetting["RemainDay"];
                dataGridView.Columns["RemainDay"].DefaultCellStyle.Format = "N1";
                dataGridView.Columns["TargetQtyDay"].HeaderText = DicLanguageSetting["TargetQtyDay"];
                dataGridView.Columns["TargetQtyDay"].DefaultCellStyle.Format = "N0";
            }
            dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular);
            dataGridView.BackgroundColor = Color.LightSteelBlue;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeight = 100;
        }
        private void SettingDataGridviewHeader ()
        {
            dtgv_header.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular);
            dtgv_header.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular);
            dtgv_header.BackgroundColor = Color.LightSteelBlue;
            dtgv_header.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dtgv_header.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            
            dtgv_header.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            dtgv_header.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgv_header.ColumnHeadersHeight = 100;
        }
        private void SettingDataGridviewContent()
        {
            dtgv_content.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular);
            dtgv_content.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular);
            dtgv_content.BackgroundColor = Color.LightSteelBlue;
            dtgv_content.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dtgv_content.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dtgv_content.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_content.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgv_content.ColumnHeadersHeight = 100;
           
        }
        private void PlanningMain_Load(object sender, EventArgs e)
        {
            //from = dtp_from.Value;
            //to = dtp_to.Value;
            //LoadDataPlanningToShow(from, to);
            SettingForm.Language.LanguageSetting languageSetting = new SettingForm.Language.LanguageSetting();
            string language = Class.valiballecommon.GetStorage().Language;
            if (language == "") language = LanguageEnum.English.ToString();
            DicLanguageSetting = languageSetting.GetNameTranslate(language, "ProductionPlan");
            

        }

       

        private void Btn_Configure_Click(object sender, EventArgs e)
        {
            SettingDataPlanning settingData = new SettingDataPlanning("MH");
            settingData.Show();
        }
        private void LoadDataPlanningToShow(DateTime from, DateTime to)
        {
            try
            {

          
            LoadDataPlanning loadData = new LoadDataPlanning();
            orderVariables = new List<OrderVariable>();
            orderVariables = loadData.LoadOrderInformationbyDate(from, to, "MH");
            List<DataHeader> dataHeaders = new List<DataHeader>();
           ListPlanning = loadData.GetPlanningReport(orderVariables);
            listplanShipment = new Dictionary<string, List<dataContent>>();
            List<dataContent> datacontents = new List<dataContent>();
            dataContent dataContent = new dataContent();
            foreach (var item in ListPlanning)
            {
                datacontents = new List<dataContent>();
                DataHeader data = new DataHeader();
                data.products = item.Value.KeyProduct;
                data.Amount_Of_Order = item.Value.shipmentPlans.Count();
                data.Total_Order_Qty = item.Value.TotalQty;
                data.clients = item.Value.Client;
                    for (int i = 0; i < item.Value._bom.HEN.Count(); i++)
                    {
                        data.HENN += item.Value._bom.HEN[i]+ Environment.NewLine;
                        data.HENNStock += item.Value._bom.HENStock[i].ToString("N0") + Environment.NewLine;
                    }
               
                data.QtyInBox = item.Value._bom.QtyUnit;
                data.ToolPcs = item.Value._bom.ToolQty;
                data.StockWH = item.Value.wip.Warehouse;
             
                data.WIPQty = item.Value.wip.TotalInWip;
                data.MQCStock = item.Value.wip.MQCQty;
                data.PQCStock = item.Value.wip.PQCQty;
                data.IntoWH = item.Value.wip.StockInWHQTy;
                data.SemiStock = item.Value.wip.SemiFinished;
                data.ShiftA = item.Value.production.targetShiftA;
                data.ShiftB = item.Value.production.targetShiftB;
                data.productivity = item.Value.production.QtyOld;
                data.WorkerQty = item.Value.production.PeopleQty;
                data.WorkerTarget = item.Value.production.targetPeople;
                data.ManufactureQty = item.Value.production.ProductionQty;
                data.ShortageStock = data.Total_Order_Qty - data.StockWH- data.WIPQty;
                dataHeaders.Add(data);
                double ShipmentQtySum = 0;
                foreach (var shipment in item.Value.shipmentPlans)
                {
                    dataContent = new dataContent();
                    dataContent.ClientOrderDate = shipment.ClientRequestDate;
                    dataContent.OrderQty = shipment.DeliveryPlanQty;
                    ShipmentQtySum += dataContent.OrderQty;
                    dataContent.ShortageQty =  ShipmentQtySum- data.StockWH - data.WIPQty;
                    dataContent.RemainDay = shipment.RemainDay;
                        if (dataContent.RemainDay == 0)
                            dataContent.TargetQtyDay = (dataContent.ShortageQty < 0) ? 0 : (dataContent.ShortageQty);
                        else dataContent.TargetQtyDay = (dataContent.ShortageQty < 0) ? 0 : (dataContent.ShortageQty / dataContent.RemainDay);
                    
                    dataContent.OrderCode = shipment.OrderCode;
                    dataContent.ClientOrder = shipment.ClientCode;
                    datacontents.Add(dataContent);

                }

                listplanShipment.Add(data.products, datacontents);

            }
            dtgv_header.DataSource = dataHeaders;
            SettingHeaderDataGridViewHeader( dtgv_header);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "LoadDataPlanningToShow(DateTime from, DateTime to)", ex.Message);
            }
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            from = dtp_from.Value;
            to = dtp_to.Value;
            LoadDataPlanningToShow(from, to);
        }

        private void Dtgv_header_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (listplanShipment != null)
                {
                    string productKey = dtgv_header.Rows[e.RowIndex].Cells[0].Value.ToString();
                    var PlanShipment = listplanShipment[productKey];
                    dtgv_content.DataSource = PlanShipment;

                    SettingHeaderDataGridViewContent(dtgv_content);
                }
            }
        }

        private void Btn_ExportExcel_Click(object sender, EventArgs e)
        {
            string pathsave = "";
            try
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Title = "Browse Excel Files";
                saveFileDialog.DefaultExt = "Excel";
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                saveFileDialog.CheckPathExists = true;
                

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pathsave = saveFileDialog.FileName;

                    saveFileDialog.RestoreDirectory = true;
                    Class.ToolSupport toolSupport = new Class.ToolSupport();
                    if (ListPlanning != null && ListPlanning.Count > 0)
                    {
                        toolSupport.ExportProductionPlan(Class.valiballecommon.GetStorage().Language,ListPlanning, pathsave);
               var resultMessage =         MessageBox.Show("Production Plan export to excel sucessful ! \n\r Do you want to open this file ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                        if(resultMessage == DialogResult.Yes)
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
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
        private void CreateFolderDeleteFilesExcelold()
        {
            bool exists = System.IO.Directory.Exists(PathFoler);
            if (!exists)
                System.IO.Directory.CreateDirectory(PathFoler);
           
        }
        #endregion


        #region TagPage FF Clients 

        private void LoadDataPlanningFFToShow(DateTime from, DateTime to)
        {
            
            try
            {    
            LoadDataPlanning loadData = new LoadDataPlanning();
            orderVariables = new List<OrderVariable>();
            orderVariables = loadData.LoadOrderInformationbyDate(from, to, "FF");
            List<DataHeader> dataHeaders = new List<DataHeader>();
            ListPlanning = loadData.GetPlanningReport(orderVariables);
                listplanShipmentPage2 = new Dictionary<string, List<dataContent>>();
            List<dataContent> datacontents = new List<dataContent>();
            dataContent dataContent = new dataContent();
            foreach (var item in ListPlanning)
            {
                datacontents = new List<dataContent>();
                DataHeader data = new DataHeader();
                data.products = item.Value.KeyProduct;
                data.Amount_Of_Order = item.Value.shipmentPlans.Count();
                data.Total_Order_Qty = item.Value.TotalQty;
                data.clients = item.Value.Client;
                    for (int i = 0; i < item.Value._bom.HEN.Count(); i++)
                    {
                        data.HENN += item.Value._bom.HEN[i] + Environment.NewLine;
                        data.HENNStock += item.Value._bom.HENStock[i].ToString("N0") + Environment.NewLine;
                    }

                    data.QtyInBox = item.Value._bom.QtyUnit;
                data.ToolPcs = item.Value._bom.ToolQty;
                data.StockWH = item.Value.wip.Warehouse;

                data.WIPQty = item.Value.wip.TotalInWip;
                data.MQCStock = item.Value.wip.MQCQty;
                data.PQCStock = item.Value.wip.PQCQty;
                data.IntoWH = item.Value.wip.StockInWHQTy;
                data.SemiStock = item.Value.wip.SemiFinished;
                data.ShiftA = item.Value.production.targetShiftA;
                data.ShiftB = item.Value.production.targetShiftB;
                data.productivity = item.Value.production.QtyOld;
                data.WorkerQty = item.Value.production.PeopleQty;
                data.WorkerTarget = item.Value.production.targetPeople;
                data.ManufactureQty = item.Value.production.ProductionQty;
                data.ShortageStock = data.Total_Order_Qty - data.StockWH - data.WIPQty;
                dataHeaders.Add(data);
                double ShipmentQtySum = 0;
                foreach (var shipment in item.Value.shipmentPlans)
                {
                    dataContent = new dataContent();
                    dataContent.ClientOrderDate = shipment.ClientRequestDate;
                    dataContent.OrderQty = shipment.DeliveryPlanQty;
                    ShipmentQtySum += dataContent.OrderQty;
                    dataContent.ShortageQty = ShipmentQtySum - data.StockWH - data.WIPQty;
                    dataContent.RemainDay = shipment.RemainDay;
                        if(dataContent.RemainDay == 0)
                            dataContent.TargetQtyDay = (dataContent.ShortageQty < 0) ? 0 : (dataContent.ShortageQty );
                        else dataContent.TargetQtyDay = (dataContent.ShortageQty < 0) ? 0 : (dataContent.ShortageQty / dataContent.RemainDay);
                    dataContent.OrderCode = shipment.OrderCode;
                    dataContent.ClientOrder = shipment.ClientCode;
                    datacontents.Add(dataContent);

                }

                    listplanShipmentPage2.Add(data.products, datacontents);

            }
            dtgv_HeaderPage2.DataSource = dataHeaders;
            SettingHeaderDataGridViewHeader( dtgv_HeaderPage2);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "LoadDataPlanningFFToShow(DateTime from, DateTime to)", ex.Message);
            }
        }


  
        #endregion

        private void Btn_SearchPage2_Click(object sender, EventArgs e)
        {
            from = dtpk_FromPage2.Value;
            to = dtpk_ToPage2.Value;
            LoadDataPlanningFFToShow(from, to);

        }

     
        private void Dtgv_HeaderPage2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (listplanShipmentPage2 != null)
                {
                    string productKey = dtgv_HeaderPage2.Rows[e.RowIndex].Cells[0].Value.ToString();
                    var PlanShipment = listplanShipmentPage2[productKey];
                    dtgv_ContentPage2.DataSource = PlanShipment;

                    SettingHeaderDataGridViewContent(dtgv_ContentPage2);
                }
            }
        }

  

        private void Btn_ExportPage2_Click(object sender, EventArgs e)
        {
            string pathsave = "";
            try
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Title = "Browse Excel Files";
                saveFileDialog.DefaultExt = "Excel";
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                saveFileDialog.CheckPathExists = true;

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pathsave = saveFileDialog.FileName;

                    saveFileDialog.RestoreDirectory = true;
                    Class.ToolSupport toolSupport = new Class.ToolSupport();
                    if (ListPlanning != null && ListPlanning.Count > 0)
                    {
                        toolSupport.ExportProductionPlan(Class.valiballecommon.GetStorage().Language, ListPlanning, pathsave);
                        var resultMessage = MessageBox.Show("Production Plan export to excel sucessful ! \n\r Do you want to open this file ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Btn_SettingPage2_Click(object sender, EventArgs e)
        {
            SettingDataPlanning settingData = new SettingDataPlanning("FF");
            settingData.Show();
        }
    }
}
