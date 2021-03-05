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
using WindowsFormsApplication1.Planning.Controler;
using WindowsFormsApplication1.Planning.Model;

namespace WindowsFormsApplication1.Planning.View
{
    public partial class ProductionPLan : CommonFormMetro
    {
        DateTime from = DateTime.MinValue;
        DateTime to = DateTime.MinValue;
        List<OrderVariable> orderVariables;
        Dictionary<string, List<dataContent>> listplanShipment = new Dictionary<string, List<dataContent>>();
        List<SemiFinishedGoods> ListSemiFinishedGoods;
        List<SemiFinishedGoods> ListSemiFinishedGoodsExport;
        Dictionary<string, PlanningItem> ListPlanning = new Dictionary<string, PlanningItem>();
        Dictionary<string, string> DicLanguageSetting = new Dictionary<string, string>();
        List<DataHeaderPlanning> dataHeaderPlanning = new List<DataHeaderPlanning>();
      
        DataTable dtHeader;
        
        public ProductionPLan()
        {
            InitializeComponent();
            var scrProgram = Screen.FromControl(this);
            if (scrProgram.Primary)
            {
                // StartPosition was set to FormStartPosition.Manual in the properties window.
                Rectangle screen = Screen.PrimaryScreen.WorkingArea;
                int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
                int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
                // this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
                this.Location = new Point(0, 0);
                this.Size = new Size(w, h);
            }
            else
            {
                Rectangle screen = scrProgram.WorkingArea;
                int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
                int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
                // this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
                this.Location = new Point(0, 0);
                this.Size = new Size(w, h);
            }
            initialize();
            lbl_Header.Text = "PRODUCTION PLANNING ON " + DateTime.Now.ToString("dd-MM-yyyy");
            dtpk_from.Value = DateTime.Now.AddDays(0);

            dtpk_to.Value = DateTime.Now.AddDays(21);
            from = dtpk_from.Value;
            to = dtpk_to.Value;

        }
        public void initialize()
        {
            cb_Department.Items.Clear();
            cb_Department.Items.Add("A01-Gia Dung");
            cb_Department.Items.Add("B01-MH");
            cb_Department.Items.Add("B01-FF");           
            cb_Department.Items.Add("A01-PTC");
            cb_Department.Items.Add("A01-JM");
            cb_Department.Items.Add("A01-MH");
            cb_Department.SelectedIndex = 0;
            dtpk_from.Value = DateTime.Now;
            dtpk_to.Value = DateTime.Now.AddDays(21);
            rd_date.Checked = true;
            
                
        }
        private void ProductionPLan_Load(object sender, EventArgs e)
        {
            SettingForm.Language.LanguageSetting languageSetting = new SettingForm.Language.LanguageSetting();
            string language = Class.valiballecommon.GetStorage().Language;
            if (language == "") language = LanguageEnum.English.ToString();
            DicLanguageSetting = languageSetting.GetNameTranslate(language, "ProductionPlan");
        }

        private void Cb_Department_SelectedIndexChanged(object sender, EventArgs e)
        {
           if((string) cb_Department.SelectedItem =="B01-MH")
             {
                labelDeptName.Text = "胶管OEM生产线ONGOEM";
            }
           else if ((string)cb_Department.SelectedItem == "B01-FF")
            {
                labelDeptName.Text = "胶管OEM生产线ONGOEM";
            }
            else if ((string)cb_Department.SelectedItem == "A01-Gia Dung")
            {
                labelDeptName.Text = "家用品模压生产线GIADUNG-DUCEP";
            }
            else if ((string)cb_Department.SelectedItem == "A01-PTC")
            {
                labelDeptName.Text = "家用品模压生产线GIADUNG-DUCEP";
            }
            else if ((string)cb_Department.SelectedItem == "A01-JM")
            {
                labelDeptName.Text = "家用品模压生产线GIADUNG-DUCEP";
            }
            else if ((string)cb_Department.SelectedItem == "A01-MH")
            {
                labelDeptName.Text = "家用品模压生产线GIADUNG-DUCEP";
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            dtgv_content.DataSource = null;
            dtgv_header.DataSource = null;
            from = dtpk_from.Value;
            to = dtpk_to.Value;
            if(cb_Department.SelectedItem.ToString().Contains("A01-Gia Dung"))
            {
                LoadPlanningItemsA01 loadPlanningItems = new LoadPlanningItemsA01();
                dataHeaderPlanning = loadPlanningItems.GetDataHeaderPlanningA01GiaDung((string)cb_Department.SelectedItem,from, to, out listplanShipment, out ListSemiFinishedGoods);
                ListSemiFinishedGoodsExport = GroupbySemifinished(ListSemiFinishedGoods);

                //   settingdatagridview(dtgv_header);



                dtgv_header.DataSource = dataHeaderPlanning;
            }
            else if(cb_Department.SelectedItem.ToString().Contains("A01-PTC"))
            {
                LoadPlanningItemsA01 loadPlanningItems = new LoadPlanningItemsA01();
                dataHeaderPlanning = loadPlanningItems.GetDataHeaderPlanningA01PTC((string)cb_Department.SelectedItem,from, to, out listplanShipment);
            //    settingdatagridview(dtgv_header);
                dtgv_header.DataSource = dataHeaderPlanning;
            }
            else if (cb_Department.SelectedItem.ToString().Contains("A01-JM"))
            {
                LoadPlanningItemsA01 loadPlanningItems = new LoadPlanningItemsA01();
                dataHeaderPlanning = loadPlanningItems.GetDataHeaderPlanningA01JM((string)cb_Department.SelectedItem, from, to, out listplanShipment);
                
              //  settingdatagridview(dtgv_header);
                dtgv_header.DataSource = dataHeaderPlanning;
            }
            else if (cb_Department.SelectedItem.ToString().Contains("B01-MH"))
            {
                LoadPlanningItemsB01 loadPlanningItems = new LoadPlanningItemsB01();
                dataHeaderPlanning = loadPlanningItems.GetDataHeaderPlanningBMH((string)cb_Department.SelectedItem, from, to, out listplanShipment);
             //   settingdatagridview(dtgv_header);
                dtgv_header.DataSource = dataHeaderPlanning;
              //  SettingHeaderDataGridViewHeader(dtgv_header);
            }
            else if (cb_Department.SelectedItem.ToString().Contains("B01-FF"))
            {
                LoadPlanningItemsB01 loadPlanningItems = new LoadPlanningItemsB01();
                dataHeaderPlanning = loadPlanningItems.GetDataHeaderPlanningBMH((string)cb_Department.SelectedItem, from, to, out listplanShipment);
                //  settingdatagridview(dtgv_header);
                dtgv_header.DataSource = dataHeaderPlanning;
            }
            // LoadDataPlanningToShow(from, to);
            settingDataGridViewColumn((string)cb_Department.SelectedItem, dtgv_header);
        }
        private List<SemiFinishedGoods> GroupbySemifinished(List<SemiFinishedGoods> ListFinishedGoods)
        {
            List<SemiFinishedGoods> ListSemiFGs = new List<SemiFinishedGoods>();

         var   semiFinisheds = ListFinishedGoods.GroupBy(d => d.Item) .Select(grp => grp.ToList())
    .ToList();
            for (int i = 0; i <semiFinisheds.Count; i++)
            {
                SemiFinishedGoods semi = new SemiFinishedGoods();
                semi.Item = semiFinisheds[i][0].Item;
                semi.QtyNeed = semiFinisheds[i].Select(d => d.QtyNeed).Sum();
                semi.QtyWarehouse = semiFinisheds[i][0].QtyWarehouse;
                semi.QtyWip = semiFinisheds[i][0].QtyWip;
                semi.QTyAtPQC = semiFinisheds[i][0].QTyAtMQC;
                semi.QTyAtPQC = semiFinisheds[i][0].QTyAtPQC;
                semi.QtyPendingWarehouse = semiFinisheds[i][0].QtyPendingWarehouse;
                ListSemiFGs.Add(semi);
            }

            return ListSemiFGs;
        }
        private void LoadDataPlanningToShow(DateTime from, DateTime to)
        {
            try
            {


                LoadDataPlanning loadData = new LoadDataPlanning();
                orderVariables = new List<OrderVariable>();
                orderVariables = loadData.LoadOrderInformationbyDatebyDept(from, to,(string)cb_Department.SelectedItem);
                List<DataHeader> dataHeaders = new List<DataHeader>();
                ListPlanning = loadData.GetPlanningReportbyDept("",orderVariables);
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
                    if (item.Value.SemiFinishedGoods != null)
                    {
                        for (int i = 0; i < item.Value.SemiFinishedGoods.Count; i++)
                        {
                            data.HENN += item.Value.SemiFinishedGoods[i].Item + Environment.NewLine;
                            data.HENNStock += item.Value.SemiFinishedGoods[i].QtyWarehouse.ToString("N0") + Environment.NewLine;
                        }
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
            //    SettingHeaderDataGridViewHeader(dtgv_header);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "LoadDataPlanningToShow(DateTime from, DateTime to)", ex.Message);
            }
        }
        private void SettingHeaderDataGridViewHeader(DataGridView dataGridView)
        {
         //   if (DicLanguageSetting == null || DicLanguageSetting.Count == 0)
            {
                dataGridView.Columns["product"].HeaderText = "Product";
                dataGridView.Columns["client"].HeaderText = "Client";
                dataGridView.Columns["Amount_Of_Order"].HeaderText = "Amount of Orders";
                dataGridView.Columns["Amount_Of_Order"].Width = 100;
                dataGridView.Columns["Amount_Of_Order"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["Total_Order_Qty"].HeaderText = "Total Order (Qty)";
                dataGridView.Columns["Total_Order_Qty"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["StockInWarehouse"].HeaderText = "Warehouse Stock";
                dataGridView.Columns["StockInWarehouse"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["SemiFinishedGoods"].HeaderText = "Semi-FGs";
                dataGridView.Columns["SemiFinishedGoods"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["StockSemiFinished"].HeaderText = "Semi_FGs Stock";
                dataGridView.Columns["StockSemiFinished"].DefaultCellStyle.Format = "N0";
              //  dataGridView.Columns["MQCStock"].Width = 60;
                dataGridView.Columns["MQCStock"].HeaderText = "MQC State (Qty)";
                dataGridView.Columns["MQCStock"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["PQCStock"].HeaderText = "PQC State (Qty)";
                dataGridView.Columns["PQCStock"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["PendingWarehouse"].HeaderText = "intoWH pending (Qty)";
                dataGridView.Columns["PendingWarehouse"].DefaultCellStyle.Format = "N0";
                dataGridView.Columns["Accessories"].HeaderText = "Accessories";
                
                dataGridView.Columns["StockAccessory"].HeaderText = "Accessories Stock";
                dataGridView.Columns["StockAccessory"].DefaultCellStyle.Format = "N0";

            }
            //else if (DicLanguageSetting.Count > 0)
            //{
            //    dataGridView.Columns["products"].HeaderText = DicLanguageSetting["products"];
            //    dataGridView.Columns["clients"].HeaderText = DicLanguageSetting["clients"];
            //    dataGridView.Columns["Amount_Of_Order"].HeaderText = DicLanguageSetting["Amount_Of_Order"];
            //    dataGridView.Columns["Amount_Of_Order"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["Total_Order_Qty"].HeaderText = DicLanguageSetting["Total_Order_Qty"];
            //    dataGridView.Columns["Total_Order_Qty"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["StockWH"].HeaderText = DicLanguageSetting["StockWH"];
            //    dataGridView.Columns["StockWH"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["ShortageStock"].HeaderText = DicLanguageSetting["ShortageStock"];
            //    dataGridView.Columns["ShortageStock"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["SemiStock"].HeaderText = DicLanguageSetting["SemiStock"];
            //    dataGridView.Columns["SemiStock"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["MQCStock"].HeaderText = DicLanguageSetting["MQCStock"];
            //    dataGridView.Columns["MQCStock"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["PQCStock"].HeaderText = DicLanguageSetting["PQCStock"];
            //    dataGridView.Columns["PQCStock"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["IntoWH"].HeaderText = DicLanguageSetting["IntoWH"];
            //    dataGridView.Columns["IntoWH"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["WIPQty"].HeaderText = DicLanguageSetting["WIPQty"];
            //    dataGridView.Columns["WIPQty"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["HENN"].HeaderText = DicLanguageSetting["HENN"];
            //    dataGridView.Columns["HENNStock"].HeaderText = DicLanguageSetting["HENNStock"];
            //    dataGridView.Columns["HENNStock"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["QtyInBox"].HeaderText = DicLanguageSetting["QtyInBox"];
            //    dataGridView.Columns["QtyInBox"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["ToolPcs"].HeaderText = DicLanguageSetting["ToolPcs"];
            //    dataGridView.Columns["ToolPcs"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["ShiftA"].HeaderText = DicLanguageSetting["ShiftA"];
            //    dataGridView.Columns["ShiftA"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["ShiftB"].HeaderText = DicLanguageSetting["ShiftB"];
            //    dataGridView.Columns["ShiftB"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["productivity"].HeaderText = DicLanguageSetting["productivity"];
            //    dataGridView.Columns["productivity"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["ManufactureQty"].HeaderText = DicLanguageSetting["ManufactureQty"];
            //    dataGridView.Columns["ManufactureQty"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["WorkerQty"].HeaderText = DicLanguageSetting["WorkerQty"];
            //    dataGridView.Columns["WorkerQty"].DefaultCellStyle.Format = "N0";
            //    dataGridView.Columns["WorkerTarget"].HeaderText = DicLanguageSetting["WorkerTarget"];
            //    dataGridView.Columns["WorkerTarget"].DefaultCellStyle.Format = "N0";
            //}
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
            if (dataGridView.Name == "dtgv_HeaderPage2")
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
        private void settingdatagridview(DataGridView dataGridView)
        {
            dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular);
            dataGridView.BackgroundColor = Color.LightSteelBlue;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeight = 100;
        }
        private void settingDataGridViewColumn(string dept, DataGridView dataGridView )
        {
            dataGridView.Columns["StockSemiFinished"].Visible = true;
            dataGridView.Columns["SemiFinishedGoods"].Visible = true;
            if (dept == "A01-Gia Dung")
            {

            }
            else if(dept == "A01-PTC")
            {

            }
            else if(dept == "A01-JM")
            {

            }
            else if(dept == "B01-MH")
            {
                dataGridView.Columns["StockSemiFinished"].Visible = false;
                dataGridView.Columns["SemiFinishedGoods"].Visible = false;
                dataGridView.Columns["Semi_FGs_Needed_Qty"].Visible = false;


            }
            else if (dept == "B01-FF")
            {
                dataGridView.Columns["StockSemiFinished"].Visible = false;
                dataGridView.Columns["SemiFinishedGoods"].Visible = false;
                dataGridView.Columns["Semi_FGs_Needed_Qty"].Visible = false;
            }
        }
        private void SettingHeaderDataGridViewContent(DataGridView dataGridView)
        {
            if (DicLanguageSetting == null || DicLanguageSetting.Count == 0)
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

        private void dtgv_header_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                if (listplanShipment != null)
                {
                    string productKey = dtgv_header.Rows[e.RowIndex].Cells[0].Value.ToString();
                    var PlanShipment = listplanShipment[productKey];
                    dtgv_content.DataSource = PlanShipment;
                  //  settingdatagridview(dtgv_content);
                }
                if(dtgv_header.Columns[e.ColumnIndex].Name == "SemiFinishedGoods")
                {
                    string product = dtgv_header.Rows[e.RowIndex].Cells["product"].Value.ToString();
                    string SemiFGs = dtgv_header.Rows[e.RowIndex].Cells["SemiFinishedGoods"].Value.ToString();

                    GetSemiFinishedgoods getSemiFinishedgoods = new GetSemiFinishedgoods();
                    List<SemiFinishedGoods> semiFinishedGoods = getSemiFinishedgoods.ListGetSemiFinishedGoods(cb_Department.SelectedItem.ToString(),product,1);
                    for (int i = 0; i < semiFinishedGoods.Count; i++)
                    {
                        var semigroupbyItem = ListSemiFinishedGoods.Where(d => d.Item == semiFinishedGoods[i].Item).ToList();
                        //if (semigroupbyItem.Count > 1)
                        //    ;
                        semiFinishedGoods[i].QtyNeed = ListSemiFinishedGoods.Where(d => d.Item == semiFinishedGoods[i].Item).Select(d => d.QtyNeed).Sum();
                    }
                    
                    SemiFinishedGoodsForm semiFinishedGoodsForm = new SemiFinishedGoodsForm(semiFinishedGoods);
                    semiFinishedGoodsForm.Show();

                }
                else if (dtgv_header.Columns[e.ColumnIndex].Name == "StockInWarehouse")
                {
                    string product = dtgv_header.Rows[e.RowIndex].Cells["product"].Value.ToString();
                    List<ItemsInINVMC> itemsInINVMCs = new List<ItemsInINVMC>();
                    GetStockinINVMC getStockinINVMC = new GetStockinINVMC();
                    itemsInINVMCs = getStockinINVMC.GetItemsInINVMCs("", product);
                    StockInWarehouseShow inWarehouseShow = new StockInWarehouseShow(itemsInINVMCs);
                    inWarehouseShow.Show();
                }
            }
        }

        private void btn_ExportExcel_Click(object sender, EventArgs e)
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
                    Controler.ExportExcelPlanning exportExcelPlanning = new ExportExcelPlanning();
                    if (dataHeaderPlanning != null && dataHeaderPlanning.Count > 0)
                    {
                        Class.valiballecommon.GetStorage().Language = "English";
                        if(rd_date.Checked)
                        exportExcelPlanning.ExportListPlanningItemToExcelForm((string)cb_Department.SelectedItem, "Date",pathsave,dtpk_from.Value, dtpk_to.Value,
                            dataHeaderPlanning, listplanShipment, ListSemiFinishedGoodsExport);
                        else if (rd_Week.Checked)
                        {
                            exportExcelPlanning.ExportListPlanningItemToExcelForm((string)cb_Department.SelectedItem, "Week", pathsave,dtpk_from.Value, dtpk_to.Value,
                                dataHeaderPlanning, listplanShipment, ListSemiFinishedGoodsExport);
                        }
                        else if(rd_Month.Checked)
                        {
                            exportExcelPlanning.ExportListPlanningItemToExcelForm((string)cb_Department.SelectedItem, "Month", pathsave, dtpk_from.Value, dtpk_to.Value,
                                dataHeaderPlanning, listplanShipment, ListSemiFinishedGoodsExport);
                        }
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
                    else
                    {
                        MessageBox.Show("Don't have data to export excel, pls click Search button first !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

      

        private void dtgv_content_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_content);
            if (dtgv_content.Rows.Count > 0)
            {
                dtgv_content.ColumnHeadersHeight = 100;
                dtgv_content.Columns["WeekRequestDate"].HeaderText = "Client's Request Week";
                dtgv_content.Columns["MonthRequest"].HeaderText = "Client's Request Month";
                dtgv_content.Columns["ClientOrderDate"].HeaderText = "Client's Request Date";
                dtgv_content.Columns["OrderCode"].HeaderText = "Order Code";
                dtgv_content.Columns["ClientOrder"].HeaderText = "Client Order";
                dtgv_content.Columns["Deliveried"].HeaderText = "Deliveried Qty";
                dtgv_content.Columns["Deliveried"].DefaultCellStyle.Format = "N0";

                dtgv_content.Columns["OrderQty"].HeaderText = "Order Qty";
                dtgv_content.Columns["OrderQty"].DefaultCellStyle.Format = "N0";

                dtgv_content.Columns["ShortageQty"].HeaderText = "Shortage Qty";
                dtgv_content.Columns["ShortageQty"].DefaultCellStyle.Format = "N0";
                dtgv_content.Columns["RemainDay"].HeaderText = "Day Countdown";
                dtgv_content.Columns["RemainDay"].DefaultCellStyle.Format = "N0";

                dtgv_content.Columns["TargetQtyDay"].HeaderText = "Target/Day";
                dtgv_content.Columns["TargetQtyDay"].DefaultCellStyle.Format = "N0";
            }
        }

        private void dtgv_header_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_header);
            
           if(dtgv_header.Rows.Count > 0)
            {
                dtgv_header.ColumnHeadersHeight = 100;
                dtgv_header.Columns["product"].HeaderText = "Product";
                dtgv_header.Columns["client"].HeaderText = "Client";
                dtgv_header.Columns["Amount_Of_Order"].HeaderText = "Amount of Orders";
                dtgv_header.Columns["Amount_Of_Order"].Width = 100;
                dtgv_header.Columns["Amount_Of_Order"].DefaultCellStyle.Format = "N0";
                dtgv_header.Columns["Total_Order_Qty"].HeaderText = "Total Order";
                dtgv_header.Columns["Total_Order_Qty"].DefaultCellStyle.Format = "N0";
                dtgv_header.Columns["StockInWarehouse"].HeaderText = "Finished Goods";
                dtgv_header.Columns["StockInWarehouse"].DefaultCellStyle.Format = "N0";
                dtgv_header.Columns["SemiFinishedGoods"].HeaderText = "Semi-FGs";
                dtgv_header.Columns["SemiFinishedGoods"].DefaultCellStyle.Format = "N0";

                dtgv_header.Columns["Semi_FGs_Needed_Qty"].HeaderText = "Semi-FGs Needed";
                dtgv_header.Columns["Semi_FGs_Needed_Qty"].DefaultCellStyle.Format = "N0";

                dtgv_header.Columns["StockSemiFinished"].HeaderText = "Semi-FGs Stock";
                dtgv_header.Columns["StockSemiFinished"].DefaultCellStyle.Format = "N0";
                //  dtgv_header.Columns["MQCStock"].Width = 60;
                dtgv_header.Columns["MQCStock"].HeaderText = "MQC Station";
                dtgv_header.Columns["MQCStock"].DefaultCellStyle.Format = "N0";
                dtgv_header.Columns["PQCStock"].HeaderText = "PQC Station";
                dtgv_header.Columns["PQCStock"].DefaultCellStyle.Format = "N0";
                dtgv_header.Columns["PendingWarehouse"].HeaderText = "IntoWH pending";
                dtgv_header.Columns["PendingWarehouse"].DefaultCellStyle.Format = "N0";
                dtgv_header.Columns["Accessories"].HeaderText = "Accessories";

                dtgv_header.Columns["StockAccessory"].HeaderText = "Accessories Stock";
                dtgv_header.Columns["StockAccessory"].DefaultCellStyle.Format = "N0";
            }

        }

        private void btn_Configure_Click(object sender, EventArgs e)
        {
            SettingDataPlanning settingData = new SettingDataPlanning("MH");
            settingData.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (dataHeaderPlanning != null )
            {


                var listFillted = dataHeaderPlanning.Where(d => d.product.Contains(txt_filterProduct.Text.Trim().ToUpper())).ToList();
                dtgv_header.DataSource = listFillted;
            }
        }
    }
}
