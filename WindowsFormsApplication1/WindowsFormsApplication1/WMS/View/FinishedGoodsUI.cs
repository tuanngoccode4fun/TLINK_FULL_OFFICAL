using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApplication1.ClassMysql;
using WindowsFormsApplication1.ClassObject;
using WindowsFormsApplication1.NewQRcode;
using WindowsFormsApplication1.NewQRcode.UI_mesage;
using WindowsFormsApplication1.WMS.Controller;
using WindowsFormsApplication1.WMS.Model;


namespace WindowsFormsApplication1.WMS.View
{
    public partial class FinishedGoodsUI : CommonFormMetro
    {
        List<Database.WarehouseItems> ListWarehouse = new List<Database.WarehouseItems>();
        List<string> listDocNo = new List<string>();
        DataTable dtLoaiChungTu;
        DataTable dtKhachHang;
        DataTable dtBoPhan;
        DataTable dtTienTe;
        DataTable dtExportFGs;
        DataTable dataQRInfor = new DataTable();
        string WarehouseImport = "";
        List<string> listLocation;
        StringBuilder AllitemDelete = new StringBuilder();
        List<Import_FinishGood_WareHouse> ListImportFG = new List<Import_FinishGood_WareHouse>();
        bool startGetTextChange = true;
        bool status_IsInput = false;
        Timer timerGetQR_Total;
        Timer timerGetQR_Min;
        int m_maxLine = 200;
        EventBroker.EventObserver m_observerLog = null;
        public FinishedGoodsUI()
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
            WindowState = FormWindowState.Maximized;
            lbl_Header.Text = "FINISHED GOODS IMPORT/ EXPORT";
            InitializeTimer_Total();
            InitializeTimer_Min();
        }
        private void InitializeTimer_Total()
        {
            timerGetQR_Total = new Timer();
            timerGetQR_Total.Enabled = false;
            timerGetQR_Total.Interval = 2000;
            timerGetQR_Total.Tick += TimerGetQR_Total_Tick;
        }
        private void StartTimer_Total()
        {
            timerGetQR_Total.Enabled = true;
            timerGetQR_Total.Start();
            StartTimer_Min();
        }
        private void StopTimer_Total()
        {
            timerGetQR_Total.Enabled = false;
            timerGetQR_Total.Stop();
        }
        private void InitializeTimer_Min()
        {
            timerGetQR_Min = new Timer();
            timerGetQR_Min.Enabled = false;
            timerGetQR_Min.Interval = 100;
            timerGetQR_Min.Tick += TimerGetQR_Min_Tick; 
        }

        private void TimerGetQR_Min_Tick(object sender, EventArgs e)
        {
            StopTimer_Min();
            ReceiveQR();
            if (timerGetQR_Total.Enabled == true)
            {
                StartTimer_Min();
            }
        }
        private void TimerGetQR_Total_Tick(object sender, EventArgs e)
        {
            StopTimer_Total();
            startGetTextChange = false;
            ReceiveQR();
            startGetTextChange = true;
        }
        private void StartTimer_Min()
        {
            timerGetQR_Min.Enabled = true;
            timerGetQR_Min.Start();
        }
        private void StopTimer_Min()
        {
            timerGetQR_Min.Enabled = false;
            timerGetQR_Min.Stop();
        }

        private void ReceiveQR()
        {
            string texInput = null;
            try
            {
                texInput = txt_QRImport.Text.Trim();
                if (startGetTextChange == false || texInput == "") return;
                if (texInput.StartsWith("s") && texInput.EndsWith("e"))
                {
                    StopTimer_Total();
                    txt_QRImport.Text = null;
                    string[] arraydata = Regex.Replace(texInput, " ", "").TrimStart('s').TrimEnd('e').Split(';');
                    if (arraydata.Count() <= 3)
                    {
                        AutoProcess(texInput);
                        return;
                    }
                }
                else
                {
                    if (timerGetQR_Total.Enabled == false)/// after total finish, We have to message, other situation not display.
                    {
                        ClassMessageBoxUI.Show("Your QR must be include char START: \"s\" and STOP: \"e\" ", false);
                        txt_QRImport.Text = null;
                        txt_QRImport.Focus();
                    }
                    return;
                }
                if (status_IsInput)
                {
                    ClassMessageBoxUI.Show("Please scan your location for add new item!", false);
                    txt_QRImport.Focus();
                    return;
                }
                Import_FinishGood_WareHouse valueTem = GetImportFG.ConvertQR2DataTable(texInput, cmboxWareHouse.Text.Trim(), dtgv_import);
                if (valueTem != null)
                {
                    if (valueTem.Warehouse.Trim() != cmboxWareHouse.SelectedItem.ToString().Trim())
                    {
                        ClassMessageBoxUI.Show(string.Format("It's different item WareHouse between your warehouse {0} and {1}", cmboxWareHouse.SelectedItem.ToString().Trim(), valueTem.Warehouse), false);
                        txt_QRImport.Text = null;
                        txt_QRImport.Focus();
                        return;
                    }
                    /// check all data same warehouse or not
                    if (IdentifyQR.IsWrongWareHouse(ListImportFG, valueTem) && ListImportFG.Count > 0)
                    {
                        ClassMessageBoxUI.Show(string.Format("It's different item WareHouse between {0} and {1}", ListImportFG[0].Warehouse, valueTem.Warehouse), false);
                        txt_QRImport.Text = null;
                        txt_QRImport.Focus();
                        return;
                    }
                    if (sql_QueryFromFileSQL.IsExistQR(valueTem.TransactionID)) 
                    {
                        //sql_QueryFromFileSQL.InsertQRcode(valueTem.TransactionID);
                        txt_QRImport.Text = null;
                        txt_QRImport.Focus();
                        return;
                    }

                    ///// check data input duplicate or not
                    if (!IdentifyQR.IsDuplicate(ListImportFG, valueTem))
                    {
                        Import_FinishGood_WareHouse valueGet = (Import_FinishGood_WareHouse)valueTem.Clone();
                        ////////

                        ///////
                        valueGet.Id = (uint)ListImportFG.Count() + 1;
                        ListImportFG.Add(valueGet);
                        SystemLog.Output(SystemLog.MSG_TYPE.Nor, "[ReceiveQR Success] " , valueGet.TransactionID);
                        txt_QRImport.Text = null;
                        txt_QRLocationImport.Text = "";
                        //txt_QRImport.Focus();
                    }
                    else
                    {
                        ClassMessageBoxUI.Show("QR code have already added in your list!", false);
                        txt_QRImport.Text = null;
                        txt_QRImport.Focus();
                        return;
                    }
                    status_IsInput = true;
                    if (sql_CheckCondition.Is_LocationManagement(valueTem.Warehouse) == sql_CheckCondition.QueryResult.NG)
                    {
                        status_IsInput = false;
                    }

                }
                dtgv_import.DataSource = null;
                dtgv_import.DataSource = ListImportFG;

            }
            catch (Exception ex)
            {
               //ClassMessageBoxUI.Show(ex.Message, false);
               SystemLog.Output(SystemLog.MSG_TYPE.Err, "[ReceiveQR] :" , ex.Message);
            }

        }
        private void tabPage_FinishedGood_SelectedIndexChanged(object sender, EventArgs e)
        {
            Database.GetListWarehouse getlistWarehouse = new Database.GetListWarehouse();
            switch ((sender as TabControl).SelectedIndex)
            {
                //case 0:

                //    getlistWarehouse = new Database.GetListWarehouse();
                //    ListWarehouse = new List<Database.WarehouseItems>();
                //    ListWarehouse = getlistWarehouse.GetWarehouseItems();
                //    var listwarehouse2 = ListWarehouse.Select(d => d.MC001_Wh).Distinct().ToList();
                //    cb_warehousePQC.DataSource = listwarehouse2;
                //    if (Class.valiballecommon.GetStorage().Warehouse != null)
                //        cb_warehousePQC.SelectedItem = Class.valiballecommon.GetStorage().Warehouse;
                //    break;
                case 0:
                    getlistWarehouse = new Database.GetListWarehouse();
                    ListWarehouse = new List<Database.WarehouseItems>();
                    ListWarehouse = getlistWarehouse.GetWarehouseItems();
                    break;
                case 1:
                    LoadDataForUI();
                    break;


            }
        }

        private void Update_list_location(string nameWarehouse)
        {
            listLocation = ListWarehouse.Where(d => d.MC001_Wh.Trim() == nameWarehouse)
                .Select(d => d.NL002_Location).ToList();
            Class.valiballecommon.GetStorage().Warehouse = nameWarehouse;
            cb_locationImport.DataSource = listLocation;
            cb_locationImport.SelectedIndex = -1;
            txt_QRLocationImport.Text = "";
            var WarehouseName = ListWarehouse.Where(d => d.MC001_Wh.Trim() == nameWarehouse)
                .Select(d => d.MC002_WhName).ToList();
            if (WarehouseName.Count > 0)
                lbl_WarehouseImport.Text = "Warehouse: " + WarehouseName[0];
            txt_QRImport.Focus();
        }
        private void FinishedGoodsUI_Load(object sender, EventArgs e)
        {

            Database.GetListWarehouse getlistWarehouse = new Database.GetListWarehouse();
            getlistWarehouse = new Database.GetListWarehouse();
            ListWarehouse = new List<Database.WarehouseItems>();
            ListWarehouse = getlistWarehouse.GetWarehouseItems();
            var listwarehouse2 = ListWarehouse.Select(d => d.MC001_Wh).Distinct().ToList();
            cmboxWareHouse.DataSource = null;
            cmboxWareHouse.DataSource = listwarehouse2.ToList();
            string wh = "";
            if (Class.valiballecommon.GetStorage().Warehouse != null)
             wh = Class.valiballecommon.GetStorage().Warehouse.Trim();
            cmboxWareHouse.SelectedIndex = listwarehouse2.ToList().FindIndex(x => x.Trim() == wh.Trim());
            /////////
            Update_list_location(wh);
            /// Tuanngoc Add
            listDocNo = new List<string>();
            listDocNo = GetListDocNo.GetListForCombox();
            cmboxDocNo.DataSource = null;
            cmboxDocNo.DataSource = listDocNo.ToList();
            cmboxDocNo.SelectedIndex = -1;
            var doc = (Class.valiballecommon.GetStorage().DocNo == null) ? "" : Class.valiballecommon.GetStorage().DocNo.Trim();
            cmboxDocNo.SelectedIndex = listDocNo.ToList().FindIndex(x => x.Trim() == doc.Trim());
            lb_indicate.Text = GetListDocNo.GetDescribeDocNo(doc.Trim());
            m_observerLog = new EventBroker.EventObserver(OnReceiveLog);
            EventBroker.AddObserver(EventBroker.EventID.etLog, m_observerLog);

            SystemLog.Output(SystemLog.MSG_TYPE.Nor, "------------Start-----------  ", Text);
        }

        private void btn_search4_Click(object sender, EventArgs e)
        {
            DeleteAllValuesUI();
            Database.ERPSOFT.ERPOutPQCQR eRPOutPQCQR = new Database.ERPSOFT.ERPOutPQCQR();
            dataQRInfor = new DataTable();
            dataQRInfor = eRPOutPQCQR.GetDataTableImportFinishedGoods(txt_QRImport.Text);
            dtgv_import.DataSource = dataQRInfor;

        }




        private void dtgv_import_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void DeleteAllValuesUI()
        {
            //  txt_productImport.Text = "";

        }

        private void btn_comfirm4_Click(object sender, EventArgs e)
        {
            confirm_auto(true);
            // sql_CheckCondition.QueryResult temp = sql_CheckCondition.Is_stageManagement("AD-APTZ0084C");
            // sql_CheckCondition.QueryResult temp_1 = sql_CheckCondition.Is_lotManagement("BMH8201733193-5");
            // sql_CheckCondition.QueryResult temp_2 = sql_CheckCondition.Is_lotManagement("BMH8201733193-6");
            //sql_CheckCondition.QueryResult test = sql_QueryFromFileSQL.InsertHaveStageManagementAndLotManagement(false);
        }
        /// <summary>
        /// confirm is true when we have to confirm message if other case is false. It will be for auto functio no need confirm message before insert 
        /// </summary>
        /// <param name="confirm"></param>
        void confirm_auto(bool confirm)
        {
            var MessageBoxResult = DialogResult.Yes;
            try
            {
                if (confirm)
                {
                    MessageBoxResult = MessageBox.Show("Are you sure want to import finished goods into warehouse ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                }
                if (MessageBoxResult == DialogResult.Yes)
                {
                    if (Class.valiballecommon.GetStorage().DocNo != null && dtgv_import.Rows.Count > 0)
                    {
                        dataQRInfor = ListToDatatable.ConvertListToDataTable((List<Import_FinishGood_WareHouse>)dtgv_import.DataSource);
                        FunctionImportWarehouse();
                        //txt_QRImport.Focus();
                    }
                    else
                    {
                        if (Class.valiballecommon.GetStorage().DocNo == null)
                        {
                            ClassMessageBoxUI.Show("Plese choose DocNo ?", false);
                            txt_QRImport.Focus();
                            return;
                        }
                        if (dtgv_import.Rows.Count == 0)
                        {
                            ClassMessageBoxUI.Show("Please add new item barcode ?", false);
                            txt_QRImport.Focus();
                            return;
                        }

                    }


                }

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "btn_comfirm4_Click(object sender, EventArgs e)", ex.Message);
            }
        }

        public string PathSaveQR = Environment.CurrentDirectory + @"\Resources\QRCODE.PNG";
        private void btn_SearchExport_Click(object sender, EventArgs e)
        {
            if (dtExportFGs.Rows.Count == 0)
            {
                MessageBox.Show("You have to add Items into Packing list", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txt_buyerSelect.Text == "")
            {

                MessageBox.Show("You have to select buyer for shipping", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (txt_ShipmentType.Text == "")
            {

                MessageBox.Show("You have to select transportation for shipping", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            ExportFGsToExcel exportFGsToExcel = new ExportFGsToExcel();

            try
            {
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
                    string keyCode = Database.ERPSOFT.t_ExportFGoods.GetKeyNo(DateTime.Now);
                    for (int i = 0; i < dtExportFGs.Rows.Count; i++)
                    {
                        dtExportFGs.Rows[i]["KeyID"] = "TL02";
                        dtExportFGs.Rows[i]["KeyNo"] = keyCode;
                        dtExportFGs.Rows[i]["ExportFlag"] = "N";
                        dtExportFGs.Rows[i]["dateCreate"] = DateTime.Now;
                        dtExportFGs.Rows[i]["dateUpdate"] = DBNull.Value;
                        dtExportFGs.Rows[i]["dateExport"] = DBNull.Value;
                        dtExportFGs.Rows[i]["Currency"] = cb_CurrentMonney.SelectedItem.ToString();
                        dtExportFGs.Rows[i]["Invoice"] = txt_InvoiceExport.Text.Trim();
                        dtExportFGs.Rows[i]["DocNo"] = cb_DocType.SelectedItem.ToString();
                        dtExportFGs.Rows[i]["TL211"] = Class.valiballecommon.GetStorage().DBERP;
                        dtExportFGs.Rows[i]["TL202"] = txt_buyerSelect.Text;
                        dtExportFGs.Rows[i]["TL203"] = txt_ShipmentType.Text;


                    }
                    Device.QRGenerate.QRGenerate qRGenerate = new Device.QRGenerate.QRGenerate();
                    Image QRCodeGenerated = qRGenerate.GeneratingQRCode("TL02-" + keyCode);
                    picBox.Image = QRCodeGenerated;
                    picBox.Image.Save(PathSaveQR, System.Drawing.Imaging.ImageFormat.Png);
                    if (dtExportFGs.Rows.Count > 0)
                    {
                        var exportResult = exportFGsToExcel.ExportToPackingList(dtExportFGs, pathsave, PathSaveQR);
                        Database.ERPSOFT.t_ExportFGoods t_ExportFGoods = new Database.ERPSOFT.t_ExportFGoods();
                        var insert = t_ExportFGoods.InsertData(dtExportFGs);
                        if (insert)
                            txt_DocumentExportNo.Text = "TL02-" + keyCode;
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

            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "btn_SearchExport_Click(object sender, EventArgs e)", ex.Message);
            }
        }

        private void dtgv_export_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {


            DatagridviewSetting.settingDatagridview(dtgv_export);
            if (dtgv_export.Rows.Count > 0)
            {
                dtgv_export.Columns["KeyID"].Visible = false;
                dtgv_export.Columns["KeyNo"].Visible = false;
                dtgv_export.Columns["dateCreate"].Visible = false;

                // dtgv_export.Columns["TL201"].Visible = false;
                dtgv_export.Columns["TL202"].Visible = false;
                dtgv_export.Columns["TL203"].Visible = false;
                dtgv_export.Columns["TL204"].Visible = false;

                dtgv_export.Columns["dateUpdate"].Visible = false;
                dtgv_export.Columns["TL211"].Visible = false;
                dtgv_export.Columns["TL212"].Visible = false;
                dtgv_export.Columns["TL213"].Visible = false;
                dtgv_export.Columns["TL214"].Visible = false;
                dtgv_export.Columns["ExportFlag"].Visible = false;
                dtgv_export.Columns["dateExport"].Visible = false;

                dtgv_export.Columns["Quantity"].HeaderText = "Quantity (pcs)";
                dtgv_export.Columns["Quantity"].DefaultCellStyle.Format = "N0";

                dtgv_export.Columns["ClientCode"].HeaderText = "Order";
                dtgv_export.Columns["ClientOrder"].HeaderText = "Order No";
                dtgv_export.Columns["OrderSTT"].HeaderText = "Order STT";
                dtgv_export.Columns["CustomerOrder"].HeaderText = "#Client Order";
                dtgv_export.Columns["DocNo"].HeaderText = "Delivery Type";
                dtgv_export.Columns["DeptCode"].HeaderText = "Department";
                dtgv_export.Columns["LotNo"].HeaderText = "Lot No";
                dtgv_export.Columns["PriceUnit"].HeaderText = "Price/PCS";
                dtgv_export.Columns["PriceUnit"].DefaultCellStyle.Format = "N3";
                dtgv_export.Columns["TL201"].HeaderText = "Pakage Type";

            }
            dtgv_export.AllowUserToAddRows = false;
            dtgv_export.ReadOnly = true;
        }

        private void cb_DocType_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> listCT = dtLoaiChungTu.AsEnumerable()
                .Where(d => d.Field<string>("MQ001") == cb_DocType.SelectedItem.ToString())
                                  .Select(r => r.Field<string>("MQ002"))
                                  .ToList();
            if (listCT.Count > 0)
                lb_docTypeName.Text = listCT[0];
        }
        private void LoadDataForUI()
        {
            dtLoaiChungTu = Database.CMSMQ.GetDataTableCThethong("23");//MQ003 = 23 la phieu xuat hang
            List<string> listCT = dtLoaiChungTu.AsEnumerable()
                                .Select(r => r.Field<string>("MQ001"))
                                .ToList();
            cb_DocType.DataSource = listCT;
            dtKhachHang = Database.COPMA.GetDataTableKhachhang();
            List<string> listKhachhang = dtKhachHang.AsEnumerable()
                               .Select(r => r.Field<string>("MA001"))
                               .ToList();
            cb_ClientCode.DataSource = listKhachhang;
            if (Class.valiballecommon.GetStorage().Client != null)
                cb_ClientCode.SelectedItem = Class.valiballecommon.GetStorage().Client;

            dtBoPhan = Database.CMSME.GetDataTableBophan();
            List<string> listBoPhan = dtBoPhan.AsEnumerable()
                                .Select(r => r.Field<string>("ME001"))
                                .ToList();
            cb_Department.DataSource = listBoPhan;
            if (Class.valiballecommon.GetStorage().Department != null)
                cb_Department.SelectedItem = Class.valiballecommon.GetStorage().Department;

            dtTienTe = Database.CMSMF.GetDataTableTienTe();
            List<string> listTienTe = dtTienTe.AsEnumerable()
                              .Select(r => r.Field<string>("MF001"))
                              .ToList();
            cb_CurrentMonney.DataSource = listTienTe;
            if (Class.valiballecommon.GetStorage().Currency != null)
                cb_CurrentMonney.SelectedItem = Class.valiballecommon.GetStorage().Currency;

            dtExportFGs = Database.ERPSOFT.t_ExportFGoods.GetTop1DataTable();

            dtExportFGs.Rows.Clear();
            dtgv_export.DataSource = dtExportFGs;

        }

        private void cb_ClientCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> listKachhang = dtKhachHang.AsEnumerable()
               .Where(d => d.Field<string>("MA001") == cb_ClientCode.SelectedItem.ToString())
                                 .Select(r => r.Field<string>("MA002"))
                                 .ToList();
            if (listKachhang.Count > 0)
                lb_ClientName.Text = listKachhang[0];
        }

        private void cb_Department_SelectedIndexChanged(object sender, EventArgs e)
        {

            List<string> listBoPhan = dtBoPhan.AsEnumerable()
            .Where(d => d.Field<string>("ME001") == cb_Department.SelectedItem.ToString())
                              .Select(r => r.Field<string>("ME002"))
                              .ToList();
            if (listBoPhan.Count > 0)
                lb_DepartmentName.Text = listBoPhan[0];


            List<string> listCT = dtLoaiChungTu.AsEnumerable()
                                .Where(d => d.Field<string>("MQ001").Substring(0, 1) == cb_Department.SelectedItem.ToString().Substring(0, 1))
                                .Select(r => r.Field<string>("MQ001"))
                                .ToList();
            cb_DocType.DataSource = listCT;
        }

        private void cb_CurrentMonney_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> listTienTe = dtTienTe.AsEnumerable()
            .Where(d => d.Field<string>("MF001") == cb_CurrentMonney.SelectedItem.ToString())
                              .Select(r => r.Field<string>("MF002"))
                              .ToList();
            if (listTienTe.Count > 0)
                lb_CurrentyName.Text = listTienTe[0];
        }

        private void btn_AddRow_Click(object sender, EventArgs e)
        {
            try
            {
                if (txt_InvoiceExport.Text == "")
                {
                    MessageBox.Show("You have to input Invoice", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                ClientOrderUI clientOrderUI = new ClientOrderUI(dtExportFGs, cb_ClientCode.SelectedItem.ToString(), cb_Department.SelectedItem.ToString(), cb_CurrentMonney.SelectedItem.ToString(), "B02");
                clientOrderUI.FormClosed += ClientOrderUI_FormClosed;
                clientOrderUI.ShowDialog();
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Add into packing list", ex.Message);
            }


        }

        private void ClientOrderUI_FormClosed(object sender, FormClosedEventArgs e)
        {

            var dtRows = ClientOrderUI.dtExportFG;

            if (dtRows != null)
            {
                for (int i = 0; i < dtRows.Rows.Count; i++)
                {
                    var dtRowAdd = dtExportFGs.NewRow();
                    dtRowAdd = dtRows.Rows[i];
                    dtRowAdd["STT"] = (dtExportFGs.Rows.Count + 1).ToString("0000");
                    dtRowAdd["Invoice"] = txt_InvoiceExport.Text.Trim();
                    dtRowAdd["Currency"] = cb_CurrentMonney.SelectedItem.ToString();
                    dtRowAdd["DocNo"] = cb_DocType.SelectedItem.ToString();
                    dtExportFGs.Rows.Add(dtRowAdd.ItemArray);
                }
            }
            dtgv_export.DataSource = dtExportFGs;

        }

        private void btn_ComfirmExport_Click(object sender, EventArgs e)
        {
            var dtCOPTHGet = ClientOrderUI.dtSelectClientOrder;

        }


        List<PQCOutStock> pQCOutStocks = new List<PQCOutStock>();


        private void txt_QRImport_KeyDown(object sender, KeyEventArgs e)
        {
            //if (e.KeyCode == Keys.Enter)
            //{
            //    DeleteAllValuesUI();
            //    Database.ERPSOFT.ERPOutPQCQR eRPOutPQCQR = new Database.ERPSOFT.ERPOutPQCQR();
            //    DataTable dataQRInfor = new DataTable();
            //    dataQRInfor = eRPOutPQCQR.GetDataTableImportFinishedGoods(txt_QRImport.Text);
            //    if (dataQRInfor.Rows.Count > 0)
            //    {
            //        dtgv_import.DataSource = dataQRInfor;
            //        string Wh = dataQRInfor.Rows[0]["Warehouse"].ToString();
            //        var listLocation = ListWarehouse.Where(d => d.MC001_Wh == Wh)
            //            .Select(d => d.NL002_Location).ToList();
            //        cb_locationImport.DataSource = listLocation;

            //    }
            //}
        }

        private void cb_locationImport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_locationImport.SelectedIndex >= 0)
            {
                txt_QRLocationImport.Text = cb_locationImport.SelectedItem.ToString();
                status_IsInput = false;
            }
            //else
            //{
            //    txt_QRLocationImport.Text = "";
            //    txt_QRImport.Focus();
            //}


        }
        void Auto_start()
        {
            try
            {
                clear_all();
            }
            catch (Exception ex)
            {
                ClassMessageBoxUI.Show(ex.Message, false);
            }
        }
        void Auto_confirm()
        {
            try
            {
                confirm_auto(false);
            }
            catch (Exception ex)
            {
                ClassMessageBoxUI.Show(ex.Message, false);
            }
        }
        bool Auto_select_location(string inputText)
        {
            try
            {
                if (inputText.StartsWith("s") && inputText.EndsWith("e"))
                {
                    string[] arraydata = Regex.Replace(inputText, " ", "").TrimStart('s').TrimEnd('e').Split(';');
                    if (arraydata.Count() == 3)
                    {
                        if (arraydata[0] == cmboxWareHouse.SelectedItem.ToString().Trim())
                        {
                            if (listLocation.Any(x=> x.Trim()==arraydata[1]))
                            {
                                cb_locationImport.SelectedIndex = listLocation.FindIndex(x=> x.Trim()== arraydata[1]);
                                txt_QRLocationImport.Text = arraydata[1];
                                ListImportFG.Where(x => x.Id == ListImportFG.Count).ToList().ForEach(k => k.Location = arraydata[1]);
                                ListImportFG.Where(x => x.Id == ListImportFG.Count).ToList().ForEach(k => k.Warehouse = arraydata[0]);
                                dtgv_import.DataSource = null;
                                dtgv_import.DataSource = ListImportFG;
                                status_IsInput = false;
                                return true;
                            }
                            else
                            {
                                ClassMessageBoxUI.Show("Your location is [" + arraydata[1] + "] no have in this warehouse [" + arraydata[0] + "].", false);
                                return false;
                            }
                        }
                        else
                        {
                            ClassMessageBoxUI.Show("Your warhouse input is not matching with warehouse setting", false);
                            return false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ClassMessageBoxUI.Show(ex.Message, false);
            }
            return false;
        }
        private bool AutoProcess(string input)
        {

            bool tt = false;
            switch (input.Trim())
            {
                case "sSe":
                    Auto_start();
                    tt = true;
                    break;
                case "sEe":
                    Auto_confirm();
                    tt = true;
                    break;
                default:
                    tt = Auto_select_location(input);
                    break;
            }
            return tt;
        }

        private void txt_QRImport_TextChanged(object sender, EventArgs e)
        {

            //if (txt_QRImport.Text.Length == 13)
            //{
            //    DeleteAllValuesUI();
            //    Database.ERPSOFT.ERPOutPQCQR eRPOutPQCQR = new Database.ERPSOFT.ERPOutPQCQR();
            //    dataQRInfor = new DataTable();
            //    dataQRInfor = eRPOutPQCQR.GetDataTableImportFinishedGoods(txt_QRImport.Text);
            //    if (dataQRInfor.Rows.Count > 0)
            //    {
            //        dtgv_import.DataSource = dataQRInfor;
            //        string Wh = dataQRInfor.Rows[0]["Warehouse"].ToString();
            //        WarehouseImport = Wh;
            //        var listLocation = ListWarehouse.Where(d => d.MC001_Wh == Wh)
            //            .Select(d => d.NL002_Location).ToList();

            //        cb_locationImport.DataSource = listLocation;
            //        cb_locationImport.SelectedIndex = -1;
            //        txt_QRLocationImport.Text = "";
            //        var WarehouseName = ListWarehouse.Where(d => d.MC001_Wh == Wh)
            //            .Select(d => d.MC002_WhName).ToList();
            //        if (WarehouseName.Count > 0)
            //            lbl_WarehouseImport.Text = "Warehouse: "+ WarehouseName[0];
            //        txt_QRLocationImport.Focus();


            //    }
            //    else
            //    {
            //        dtgv_import.DataSource = null;
            //    }

            //}
            if (timerGetQR_Total.Enabled == false&& startGetTextChange==true)
            {
                StartTimer_Total();
            }
        }

        private void dtgv_import_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                //if (e.Button == MouseButtons.Right)
                //{
                //    ContextMenuStrip m = new ContextMenuStrip();
                //    m.Name = "delete";
                //    m.BackColor = Color.OrangeRed;

                //   // m.MenuItems.Add(new MenuItem("delete"));


                //    //int currentMouseOverRow = dtgv_materialTransfer.HitTest(e.X, e.Y).RowIndex;
                //    //RowIndexClick = currentMouseOverRow;
                //    //if (currentMouseOverRow >= 0)
                //    //{
                //    //    m.Items.Add("Delete");

                //    //    m.ItemClicked += M_ItemClicked;
                //    //}

                //    m.Show(dtgv_import, new Point(e.X, e.Y));

                //}
                if (dtgv_import.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow item in dtgv_import.SelectedRows)
                    {
                        AllitemDelete = new StringBuilder();
                        AllitemDelete.Append("Id = [" + item.Cells["Id"].ToString() + "]  ");
                    }
                    if (e.Button == MouseButtons.Right)
                    {
                        ContextMenu m = new ContextMenu();
                        //m.MenuItems.Add(new MenuItem("Cut"));
                        //m.MenuItems.Add(new MenuItem("Copy"));
                        MenuItem Delete = new MenuItem("Delete");
                        Delete.Click += Delete_Click;
                        m.MenuItems.Add(Delete);
                        m.Show(dtgv_import, new Point(e.X, e.Y));

                    }
                }
            }
            catch
            {

            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                AllitemDelete = new StringBuilder();
                AllitemDelete.Append("Id= ");
                foreach (DataGridViewRow item in dtgv_import.SelectedRows)
                {
                    AllitemDelete.Append(" ["+item.Cells["Id"].Value.ToString().Trim() + "] ");
                }
                if (MessageBox.Show("Do you want delete " + AllitemDelete.ToString(), "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
                {
                    if (dtgv_import.SelectedRows.Count > 0)
                    {
                        foreach (DataGridViewRow item in dtgv_import.SelectedRows)
                        {
                            ListImportFG.RemoveAll(x => x.Id.ToString().Trim() == item.Cells["Id"].Value.ToString().Trim());
                            dtgv_import.DataSource = null;
                            dtgv_import.DataSource = ListImportFG;
                        }
                    }
                }
            }
            catch (Exception ex )
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "[Delete_Click] :",ex.Message);
            }
            //  throw new NotImplementedException();
        }

        private void btn_ClearPickingList_Click_1(object sender, EventArgs e)
        {
            dtExportFGs.Rows.Clear();
            dtgv_export.DataSource = dtExportFGs;
        }

        private void btn_SearchQRExport_Click(object sender, EventArgs e)
        {
            Database.ERPSOFT.t_ExportFGoods t_ExportFGoods = new Database.ERPSOFT.t_ExportFGoods();
            DataTable dtExportData = t_ExportFGoods.GetDataTableExportFinishedGoods(txt_QRExport.Text);
            dtgvExportFGs.DataSource = dtExportData;
        }

        private void dtgvExportFGs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgvExportFGs);
            dtgvExportFGs.AllowUserToAddRows = false;
            dtgvExportFGs.ReadOnly = false;
            if (dtgvExportFGs.Rows.Count > 0)
            {
                dtgvExportFGs.Columns["KeyID"].Visible = false;
                dtgvExportFGs.Columns["KeyNo"].Visible = false;
                dtgvExportFGs.Columns["Client"].Visible = false;
                dtgvExportFGs.Columns["ClientCode"].Visible = false;
                dtgvExportFGs.Columns["ClientOrder"].Visible = false;
                dtgvExportFGs.Columns["OrderSTT"].Visible = false;
                dtgvExportFGs.Columns["CustomerOrder"].Visible = false;
                dtgvExportFGs.Columns["DocNo"].Visible = false;
                dtgvExportFGs.Columns["Invoice"].Visible = false;
                dtgvExportFGs.Columns["Currency"].Visible = false;

                dtgvExportFGs.Columns["TL201"].Visible = false;
                dtgvExportFGs.Columns["TL202"].Visible = false;
                dtgvExportFGs.Columns["TL203"].Visible = false;
                //  dtgvExportFGs.Columns["TL204"].Visible = false;

                dtgvExportFGs.Columns["dateUpdate"].Visible = false;
                dtgvExportFGs.Columns["TL211"].Visible = false;
                dtgvExportFGs.Columns["TL212"].Visible = false;
                dtgvExportFGs.Columns["TL213"].Visible = false;
                dtgvExportFGs.Columns["TL214"].Visible = false;
                dtgvExportFGs.Columns["dateExport"].Visible = false;
                dtgvExportFGs.Columns["PriceUnit"].Visible = false;
                dtgvExportFGs.Columns["DeptCode"].Visible = false;
                //   dtgvExportFGs.Columns["DeptCode"].HeaderText = "Department";
                dtgvExportFGs.Columns["Quantity"].HeaderText = "Quantity (pcs)";
                dtgvExportFGs.Columns["Quantity"].DefaultCellStyle.Format = "N0";
                dtgvExportFGs.Columns["LotNo"].HeaderText = "Lot No";
                dtgvExportFGs.Columns["dateCreate"].HeaderText = "Date Request";
                dtgvExportFGs.Columns["ExportFlag"].HeaderText = "Export Status";
                dtgvExportFGs.Columns["TL204"].HeaderText = "QR's import";
                dtgvExportFGs.Columns["TL204"].DisplayIndex = 1;


            }
        }
        CheckBox headerCheckBox = new CheckBox();
        private void txt_QRExport_TextChanged(object sender, EventArgs e)
        {
            if (txt_QRExport.Text.Length == 13)
            {
                Database.ERPSOFT.t_ExportFGoods t_ExportFGoods = new Database.ERPSOFT.t_ExportFGoods();
                DataTable dtExportData = t_ExportFGoods.GetDataTableExportFinishedGoods(txt_QRExport.Text);

                if (dtExportData != null)
                {
                    dtgvExportFGs.DataSource = null;
                    dtgvExportFGs.Columns.Clear();
                    dtgvExportFGs.Controls.Clear();
                    headerCheckBox.Checked = false;
                    dtgvExportFGs.DataSource = dtExportData;
                    if (dtExportData.Rows.Count > 0)
                    {
                        //Add a CheckBox Column to the DataGridView Header Cell.

                        //Find the Location of Header Cell.
                        Point headerCellLocation = this.dtgvExportFGs.GetCellDisplayRectangle(0, -1, true).Location;

                        //Place the Header CheckBox in the Location of the Header Cell.
                        headerCheckBox.Location = new Point(headerCellLocation.X + 8, headerCellLocation.Y + 2);
                        headerCheckBox.BackColor = Color.White;
                        headerCheckBox.Size = new Size(18, 18);
                        headerCheckBox.Text = "Select All";
                        headerCheckBox.Click += HeaderCheckBox_Click;
                        dtgvExportFGs.Controls.Add(headerCheckBox);

                        DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
                        checkBoxCell.Name = "checkbox";
                        checkBoxCell.HeaderText = "Scan QR Import";
                        checkBoxCell.DisplayIndex = 0;

                        dtgvExportFGs.Columns.Insert(0, checkBoxCell);
                        DataGridViewCheckBoxColumn checkBoxCell2 = new DataGridViewCheckBoxColumn();
                        checkBoxCell2.Name = "checkbox2";
                        checkBoxCell2.HeaderText = "Scan QR Location";
                        checkBoxCell2.DisplayIndex = 1;

                        dtgvExportFGs.Columns.Insert(1, checkBoxCell2);
                        string warehouse = dtExportData.Rows[0]["Warehouse"].ToString();
                        var listLocation = ListWarehouse.Where(d => d.MC001_Wh == warehouse)
                           .Select(d => d.NL002_Location).ToList();
                        cb_locationExport.DataSource = listLocation;
                        txt_QRProductImport.Focus();
                    }
                }

            }
        }

        private void HeaderCheckBox_Click(object sender, EventArgs e)
        {
            //Necessary to end the edit mode of the Cell.
            dtgvExportFGs.EndEdit();
            if (headerCheckBox.Checked)
            {
                for (int i = 0; i < dtgvExportFGs.Rows.Count; i++)
                {
                    dtgvExportFGs.Rows[i].Cells["checkbox"].Value = true;
                    dtgvExportFGs.Rows[i].Cells["checkbox2"].Value = true;
                }
            }
            else if (headerCheckBox.Checked == false)
            {
                for (int i = 0; i < dtgvExportFGs.Rows.Count; i++)
                {
                    dtgvExportFGs.Rows[i].Cells["checkbox"].Value = false;
                    dtgvExportFGs.Rows[i].Cells["checkbox2"].Value = false;
                }
            }

        }
        int QRImportSelected = -1;
        private void txt_QRProductImport_TextChanged(object sender, EventArgs e)
        {
            if (txt_QRProductImport.Text.Length == 13)
            {
                Database.ERPSOFT.ERPOutPQCQR eRPOutPQCQR = new Database.ERPSOFT.ERPOutPQCQR();
                DataTable GetdataImport = eRPOutPQCQR.GetDataTableImportFinishedGoods(txt_QRProductImport.Text);
                if (GetdataImport != null)
                {
                    if (GetdataImport.Rows.Count > 0)
                    {
                        lbl_ScanQRImport.Text = "You selected product " + GetdataImport.Rows[0]["Product"].ToString();
                        dtgv_QRimportData.DataSource = null;
                        dtgv_QRimportData.Columns.Clear();

                        dtgv_QRimportData.DataSource = GetdataImport;
                        DataGridViewCheckBoxColumn checkBoxCell1 = new DataGridViewCheckBoxColumn();
                        checkBoxCell1.Name = "checkbox";
                        checkBoxCell1.HeaderText = "select";
                        checkBoxCell1.DisplayIndex = 0;
                        dtgv_QRimportData.Columns.Add(checkBoxCell1);
                        for (int i = 0; i < dtgvExportFGs.Rows.Count; i++)
                        {
                            for (int j = 0; j < GetdataImport.Rows.Count; j++)
                            {
                                if (GetdataImport.Rows[j]["Product"].ToString().Trim() == dtgvExportFGs.Rows[i].Cells["Product"].Value.ToString().Trim())
                                {
                                    if (GetdataImport.Rows[j]["LotNo"].ToString().Trim() == dtgvExportFGs.Rows[i].Cells["LotNo"].Value.ToString().Trim())
                                    {
                                        if ((decimal)GetdataImport.Rows[j]["Quantity"] >= (decimal)dtgvExportFGs.Rows[i].Cells["Quantity"].Value)
                                        {
                                            dtgvExportFGs.Rows[i].Cells["checkbox"].Value = true;
                                            dtgv_QRimportData.Rows[j].Cells["checkbox"].Value = true;
                                            QRImportSelected = i;
                                        }
                                    }
                                }
                            }
                        }
                        txt_QRExportLocation.Focus();
                    }
                }
            }
        }

        private void txt_QRExportLocation_TextChanged(object sender, EventArgs e)
        {
            if (txt_QRExportLocation.Text.EndsWith("e") && txt_QRExportLocation.Text.Length > 2)
            {
                string QRString = txt_QRExportLocation.Text.Substring(1, txt_QRExportLocation.Text.Length - 2);
                var textSplit = QRString.Split(';');
                if (textSplit.Length == 3)
                {
                    if (QRImportSelected > -1)
                    {
                        string warehouse = dtgvExportFGs.Rows[QRImportSelected].Cells["Warehouse"].Value.ToString().Trim();
                        string location = dtgvExportFGs.Rows[QRImportSelected].Cells["Location"].Value.ToString().Trim();
                        if (textSplit[0] == warehouse)
                        {
                            if (textSplit[1] == location)
                            {
                                dtgvExportFGs.Rows[QRImportSelected].Cells["checkbox2"].Value = true;
                                txt_QRExportLocation.Text = textSplit[1];
                                txt_QRManpulationEX.Focus();

                            }
                            else if (textSplit[1] + "_" + textSplit[2] == location)
                            {
                                dtgvExportFGs.Rows[QRImportSelected].Cells["checkbox2"].Value = true;
                                txt_QRExportLocation.Text = location;
                                txt_QRManpulationEX.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Wrong location, please check QR location: " + textSplit[1] + ";" + textSplit[2] + "\n" + "warehouse require: " + location, "Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txt_QRExportLocation.Text = "";
                                txt_QRExportLocation.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Wrong warehouse, please check QR location: " + textSplit[0] + "\n" + "warehouse require: " + warehouse, "Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txt_QRExportLocation.Text = "";
                            txt_QRExportLocation.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong QR location Format, please check QR location: ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_QRExportLocation.Text = "";
                    txt_QRExportLocation.Focus();
                }

            }
        }
        private void dtgv_QRimportData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_QRimportData);
            dtgv_QRimportData.AllowUserToAddRows = false;
            dtgv_QRimportData.ReadOnly = false;

            if (dtgv_QRimportData.Rows.Count > 0)
            {
                dtgv_QRimportData.Columns["KeyID"].Visible = false;
                dtgv_QRimportData.Columns["KeyNo"].Visible = false;
                dtgv_QRimportData.Columns["ProductOrder"].Visible = false;
                dtgv_QRimportData.Columns["dateCreate"].Visible = false;
                dtgv_QRimportData.Columns["SubQR"].Visible = false;
                dtgv_QRimportData.Columns["TL101"].Visible = false;
                dtgv_QRimportData.Columns["TL102"].Visible = false;
                dtgv_QRimportData.Columns["TL103"].Visible = false;
                dtgv_QRimportData.Columns["TL104"].Visible = false;
                dtgv_QRimportData.Columns["TL111"].Visible = false;
                dtgv_QRimportData.Columns["TL112"].Visible = false;
                dtgv_QRimportData.Columns["TL113"].Visible = false;
                dtgv_QRimportData.Columns["TL114"].Visible = false;
                dtgv_QRimportData.Columns["dateUpdate"].Visible = false;
            }
        }


        private void btn_ExportFGs_Click(object sender, EventArgs e)
        {
            try
            {
                var MessageBoxResult = MessageBox.Show("Are you sure want to export finished goods out warehouse ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                if (MessageBoxResult == DialogResult.Yes)
                {
                    FinishedGoodsExportFunction();


                }
            }

            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "btn_ExportFGs_Click", ex.Message);
            }

        }
        private void FinishedGoodsExportFunction()
        {
            try
            {


                for (int i = 0; i < dtgvExportFGs.Rows.Count; i++)
                {
                    if (dtgvExportFGs.Rows[i].Cells["ExportFlag"].Value != null && dtgvExportFGs.Rows[i].Cells["ExportFlag"].Value.ToString() == "Y")
                    {
                        MessageBox.Show("This request already Exported out warehouse", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                }
                DataTable dtExport = Database.ERPSOFT.t_ExportFGoods.GetTop1DataTable();
                dtExport.Rows.Clear();

                for (int i = 0; i < dtgvExportFGs.Rows.Count; i++)
                {

                    if (dtgvExportFGs.Rows[i].Cells["checkbox"].Value != null && dtgvExportFGs.Rows[i].Cells["checkbox2"].Value != null)
                    {
                        if ((bool)dtgvExportFGs.Rows[i].Cells["checkbox"].Value == true && (bool)dtgvExportFGs.Rows[i].Cells["checkbox2"].Value == true)
                        {
                            DataRow dtRow = dtExport.NewRow();
                            dtRow["KeyID"] = dtgvExportFGs.Rows[i].Cells["KeyID"].Value;
                            dtRow["KeyNo"] = dtgvExportFGs.Rows[i].Cells["KeyNo"].Value;
                            dtRow["STT"] = dtgvExportFGs.Rows[i].Cells["STT"].Value;
                            dtRow["Client"] = dtgvExportFGs.Rows[i].Cells["Client"].Value;
                            dtRow["ClientCode"] = dtgvExportFGs.Rows[i].Cells["ClientCode"].Value;
                            dtRow["ClientOrder"] = dtgvExportFGs.Rows[i].Cells["ClientOrder"].Value;
                            dtRow["OrderSTT"] = dtgvExportFGs.Rows[i].Cells["OrderSTT"].Value;
                            dtRow["CustomerOrder"] = dtgvExportFGs.Rows[i].Cells["CustomerOrder"].Value;
                            dtRow["Product"] = dtgvExportFGs.Rows[i].Cells["Product"].Value;
                            dtRow["DocNo"] = dtgvExportFGs.Rows[i].Cells["DocNo"].Value;
                            dtRow["DeptCode"] = dtgvExportFGs.Rows[i].Cells["DeptCode"].Value;
                            dtRow["Quantity"] = dtgvExportFGs.Rows[i].Cells["Quantity"].Value;
                            dtRow["LotNo"] = dtgvExportFGs.Rows[i].Cells["LotNo"].Value;
                            dtRow["Warehouse"] = dtgvExportFGs.Rows[i].Cells["Warehouse"].Value;
                            dtRow["Location"] = dtgvExportFGs.Rows[i].Cells["Location"].Value;
                            dtRow["Invoice"] = dtgvExportFGs.Rows[i].Cells["Invoice"].Value;
                            dtRow["PriceUnit"] = dtgvExportFGs.Rows[i].Cells["PriceUnit"].Value;
                            dtRow["Currency"] = dtgvExportFGs.Rows[i].Cells["Currency"].Value;
                            dtRow["dateCreate"] = dtgvExportFGs.Rows[i].Cells["dateCreate"].Value;
                            //dtRow["TL211"] = Class.valiballecommon.GetStorage().DBERP;
                            dtExport.Rows.Add(dtRow);

                        }
                    }
                }
                if (dtExport.Rows.Count == 0)
                {
                    MessageBox.Show("You have to select Items for delivery", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                Controller.Export.UpdatERPFinishedGoods updatERPFinishedGoods = new Controller.Export.UpdatERPFinishedGoods();
                string DeliveryNo = "";

                updatERPFinishedGoods.UploadERPFinishedGoods(dtExport, out DeliveryNo);

                txt_deliveryNo.Text = DeliveryNo;
                QRImportSelected = -1;
                dtExport = new DataTable();
                dtgvExportFGs.Columns.Clear();
                dtgvExportFGs.DataSource = null;
                dtgv_QRimportData.Columns.Clear();
                dtgv_QRimportData.DataSource = null;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "FinishedGoodsExportFunction()", ex.Message);
            }
        }
        private void dtgv_import_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                DatagridviewSetting.settingDatagridview(dtgv_import);
                dtgv_import.AllowUserToAddRows = false;
                //  dtgv_import.ReadOnly = true;
                if (dtgv_import.Rows.Count > 0)
                {
                    dtgv_import.Columns["SubQR"].Visible = false;
                    //       dtgv_import.Columns["KeyID"].Visible = false;
                    //      dtgv_import.Columns["KeyNo"].Visible = false;
                    dtgv_import.Columns["TL101"].Visible = false;
                    dtgv_import.Columns["TL102"].Visible = false;
                    dtgv_import.Columns["TL103"].Visible = false;
                    dtgv_import.Columns["TL104"].Visible = false;
                    dtgv_import.Columns["dateUpdate"].Visible = false;
                    dtgv_import.Columns["ImportFlag"].Visible = false;
                    dtgv_import.Columns["TL111"].Visible = false;
                    dtgv_import.Columns["TL112"].Visible = false;
                    dtgv_import.Columns["TL113"].Visible = false;
                    dtgv_import.Columns["TL114"].Visible = false;
                    dtgv_import.Columns["dateImport"].Visible = true;

                    dtgv_import.Columns["ProductOrder"].HeaderText = "Production Order";

                    dtgv_import.Columns["Quantity"].HeaderText = "Import Quantity (pcs)";
                    dtgv_import.Columns["Quantity"].DefaultCellStyle.Format = "N0";
                    dtgv_import.Columns["LotNo"].HeaderText = "Lot No";
                    dtgv_import.Columns["dateCreate"].HeaderText = "Request's Date";
                    dtgv_import.Columns["ImportFlag"].HeaderText = "Already Imported";
                    dtgv_import.Columns["dateImport"].HeaderText = "Import Date";
                    dtgv_import.Columns["ProductOrder"].ReadOnly = true;
                    dtgv_import.Columns["Product"].ReadOnly = true;
                    dtgv_import.Columns["STT"].ReadOnly = true;
                    dtgv_import.Columns["Location"].ReadOnly = true;
                    dtgv_import.Columns["Quantity"].ReadOnly = true;
                    dtgv_import.Columns["LotNo"].ReadOnly = true;
                    dtgv_import.Columns["Warehouse"].ReadOnly = true;
                    dtgv_import.Columns["dateCreate"].ReadOnly = true;
                    dtgv_import.Columns["dateCreate"].Visible = false;
                    dtgv_import.Columns["ImportFlag"].ReadOnly = true;
                    dtgv_import.Columns["dateImport"].ReadOnly = true;


                }
            }
            catch (Exception ex)
            {
                ClassMessageBoxUI.Show(ex.Message, false);
            }
        }

        int RowSelected = -1;
        void clear_all()
        {
            startGetTextChange = false;
            txt_QRImport.Text = "";
            lbl_WarehouseImport.Text = "Warehouse";
            txt_QRLocationImport.Text = null;
            cb_locationImport.SelectedIndex = -1;
            ListImportFG = new List<Import_FinishGood_WareHouse>();
            dataQRInfor = new DataTable();
            dtgv_import.DataSource = ListImportFG;
            startGetTextChange = true;
            status_IsInput = false;
        }
        private void btn_ClearFgsImport_Click(object sender, EventArgs e)
        {
            clear_all();
        }

        private void FinishedGoodsUI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cb_Department.SelectedItem != null)
                Class.valiballecommon.GetStorage().Department = cb_Department.SelectedItem.ToString();
            if (cb_ClientCode.SelectedItem != null)
                Class.valiballecommon.GetStorage().Client = cb_ClientCode.SelectedItem.ToString();
            if (cb_CurrentMonney.SelectedItem != null)
                Class.valiballecommon.GetStorage().Currency = cb_CurrentMonney.SelectedItem.ToString();
            if (cmboxWareHouse.SelectedItem != null)
                Class.valiballecommon.GetStorage().Warehouse = cmboxWareHouse.SelectedItem.ToString();// tuanngoc
            if (cmboxDocNo.SelectedItem != null)
                Class.valiballecommon.GetStorage().DocNo = cmboxDocNo.SelectedItem.ToString();// tuanngoc
        }

        private void btn_importSummary_Click(object sender, EventArgs e)
        {
            ImportSummary importSummary = new ImportSummary();
            importSummary.ShowDialog();

        }

        private void txt_QRLocationImport_TextChanged(object sender, EventArgs e)
        {
            if (txt_QRLocationImport.Text.EndsWith("e") && txt_QRLocationImport.Text.Length > 2)
            {

                string Warehouse = txt_QRLocationImport.Text.Substring(1, txt_QRLocationImport.Text.Length - 2);
                var textSplit = Warehouse.Split(';');
                if (textSplit.Length == 3)
                {
                    // WarehouseImport = textSplit[0];
                    if (WarehouseImport.Trim() == textSplit[0])
                    {
                        if (textSplit[2] == "")
                        { //cb_locationImport.Items.Cast<string>().Any(cbi => cbi.Trim()== textSplit[1]);
                            if (cb_locationImport.Items.Cast<string>().Any(cbi => cbi.Trim() == textSplit[1]))
                            {
                                cb_locationImport.SelectedIndex = -1;
                                txt_QRLocationImport.Text = textSplit[1];

                                txt_QRManpulation.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Location is not belong to warehouse: " + WarehouseImport, "Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txt_QRLocationImport.Text = "";
                                txt_QRLocationImport.Focus();

                            }

                        }
                        else
                        {

                            if (cb_locationImport.Items.Cast<string>().Any(cbi => cbi.Trim() == textSplit[1] + "-" + textSplit[2]))
                            {
                                cb_locationImport.SelectedIndex = -1;
                                txt_QRLocationImport.Text = textSplit[1] + "-" + textSplit[2];
                                txt_QRManpulation.Focus();
                            }
                            else
                            {
                                MessageBox.Show("Location is not belong to warehouse: " + WarehouseImport, "Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txt_QRLocationImport.Text = "";
                                txt_QRLocationImport.Focus();

                            }

                        }

                    }
                    else
                    {
                        MessageBox.Show("You can't import into warehouse : " + textSplit[0] + "\n" + "warehouse requested: " + WarehouseImport.Trim(), "Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        txt_QRLocationImport.Text = "";
                        txt_QRLocationImport.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("QR location is not correct format\n Please contact programmer !", "Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txt_QRManpulation_TextChanged(object sender, EventArgs e)
        {
            if (txt_QRManpulation.Text.EndsWith("e") && txt_QRManpulation.Text.Length > 2)
            {

                string textSplit = txt_QRManpulation.Text.Substring(1, txt_QRManpulation.Text.Length - 2);


                if (textSplit == "E")
                {
                    FunctionImportWarehouse();


                    dtgv_import.DataSource = null;
                    txt_QRManpulation.Text = "";
                    txt_QRManpulation.Focus();
                }
                else if (textSplit == "S")
                {
                    txt_QRImport.Text = "";
                    txt_QRLocationImport.Text = "";
                    txt_QRManpulation.Text = "";
                    txt_ERPDocCreate.Text = "";
                    //txt_SFTDoc.Text = "";
                    txt_QRImport.Focus();
                }

            }
        }
        private bool CheckLocation()
        {

            for (int i = 0; i < dataQRInfor.Rows.Count; i++)
            {
                if (dataQRInfor.Rows[i]["ImportFlag"] != null && dataQRInfor.Rows[i]["ImportFlag"].ToString() == "Y")
                {
                    ClassMessageBoxUI.Show("This request already imported into warehouse", false); 
                    return false;
                }

            }
            //string aaa = cmboxWareHouse.SelectedValue.ToString();
            if (txt_QRLocationImport.Text == "" && sql_CheckCondition.Is_LocationManagement(cmboxWareHouse.SelectedValue.ToString().Trim()) == sql_CheckCondition.QueryResult.OK)
            {
                ClassMessageBoxUI.Show("You must select location !", false);
                return false;
            }
            if (cb_locationImport.Items.Cast<string>().Any(cbi => cbi.Trim() == txt_QRLocationImport.Text.Trim()) == false)
            {
                ClassMessageBoxUI.Show("Location must belong to warehouse: " + WarehouseImport, false);
            }
            if (ListImportFG.Count == 0)
            {
                return false;
            }
            return true;
        }
        private void FunctionImportWarehouse()
        {
            txt_ERPDocCreate.Text = "";
            //  txt_SFTDoc.Text = "";
            //// update new QR
            ///
            sql_CheckCondition.QueryResult Update = sql_CheckCondition.QueryResult.Exception;
            if (CheckLocation())
            {
                UpdateData2DBForFinishedGoods updateData2DBForFinishedGoods = new UpdateData2DBForFinishedGoods();
                string ERPDoc = ""; //string SFTDoc = "";
                dataQRInfor = ListToDatatable.ConvertListToDataTable((List<Import_FinishGood_WareHouse>)dtgv_import.DataSource);
                ///if co cong doan
                /// Check phat lenh khong???
                /// check so luong du tinh san xuat -(da san xuat + phe+ chua confirm+ so can nhap)<0 thi okay khong bao loi ??
                /// else khong co cong doan
                /// check so luong du tinh san xuat -(da san xuat + phe+ chua confirm+ so can nhap)<0 thi okay khong bao loi ??
              //  if (sql_CheckCondition.CheckConditionAllItemQRCodeInsert(dataQRInfor) == sql_CheckCondition.QueryResult.OK)
                {
                    Update = updateData2DBForFinishedGoods.UpdateDataDBForAllDeparment(dataQRInfor, out ERPDoc);//.UpdateDataDBForFinishedGoods(dataQRInfor, out ERPDoc);
                }
                if (Update==sql_CheckCondition.QueryResult.OK)
                {
                    txt_ERPDocCreate.Text = Class.valiballecommon.GetStorage().DocNo + "-" + ERPDoc;
                    //txt_SFTDoc.Text = Class.valiballecommon.GetStorage().DocNo+"-" + SFTDoc;
                    lb_Status.Text = "Importing Finished Goods success :" + Class.valiballecommon.GetStorage().DocNo + "-" + ERPDoc;
                    //SIUD_Mes.Insert(dataQRInfor);
                    txt_QRLocationImport.Text = null;
                    cb_locationImport.SelectedIndex = -1;
                    dtgv_import.DataSource = null;
                    ListImportFG = new List<Import_FinishGood_WareHouse>();
                    ClassMessageBoxUI.Show("Import all complete!", true);
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "DocNO", "--------------"+ERPDoc+"------------");
                    SystemLog.Output(SystemLog.MSG_TYPE.Nor, "FunctionImportWarehouse", "--------------Import all complete!------------");
                    txt_QRImport.Focus(); 
                }
            }

            //////*
            /*FinishedGoodsItems finishedGoods = new FinishedGoodsItems();
            dataQRInfor = dtgv_import.DataSource as DataTable;
            var testlist = dataQRInfor.AsEnumerable();
            var ListPO = dataQRInfor.AsEnumerable().Select(x => x.Field<string>("ProductOrder")).ToList();// check 1 producorder or many producorder
            if (ListPO.Count != ListPO.Distinct().Count())
            {
                for (int i = 0; i < dataQRInfor.Rows.Count; i++)
                {
                    DataTable dtrow = new DataTable();
                    dtrow = dataQRInfor.Clone();
                    dtrow.LoadDataRow(dataQRInfor.Rows[i].ItemArray, true);
                    UpdateData2DBForFinishedGoods updateData2DBForFinishedGoods = new UpdateData2DBForFinishedGoods();
                    string ERPDoc = ""; string SFTDoc = "";
                    string productOrder = dtrow.Rows[0]["ProductOrder"].ToString();
                    string product = dtrow.Rows[0]["Product"].ToString().Trim();
                    double Quantity = double.Parse(dtrow.Rows[0]["Quantity"].ToString());
                    double SLDongGoi = Database.INV.INVMD.ConvertToWeightKg(product, Quantity);// convert quality to Kg
                    var ischeckSFCTA = Database.SFC.SFCTA.IscheckQantityAndWeight(productOrder, Quantity, SLDongGoi);

            //        var ischeckMOCTA = Database.MOC.MOCTA.IscheckQantityAndWeight(productOrder, Quantity, SLDongGoi);
            //        // KIEM TRA KHOI LUONG, SO LUONG, NEU KHOI LUONG DU THI TRA LAI 'TRUE', ELSE FALSE
            //        if (ischeckSFCTA == false || ischeckMOCTA == false)
            //        {
            //            var Update = updateData2DBForFinishedGoods.UpdateDataDBForFinishedGoodsNotConfirm(dtrow, txt_QRLocationImport.Text.Trim(), out ERPDoc, out SFTDoc);
            //            if (Update == true)
            //            {
            //                txt_ERPDocCreate.Text += "D301-" + ERPDoc + Environment.NewLine;
            //                txt_SFTDoc.Text += "D301-" + SFTDoc + Environment.NewLine;
            //                MessageBox.Show("D301-" + ERPDoc + " cannot confirm because not enough quantity or packing weight", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                lb_Status.Text = "Importing Finished Goods success, but this doccument is not confirm on ERP : D301-" + ERPDoc;
            //            }


            //        }
            //        else
            //        {


            //            var Update = updateData2DBForFinishedGoods.UpdateDataDBForFinishedGoods(dtrow, txt_QRLocationImport.Text.Trim(), out ERPDoc, out SFTDoc);
            //            if (Update == true)
            //            {
            //                txt_ERPDocCreate.Text += "D301-" + ERPDoc + Environment.NewLine;
            //                txt_SFTDoc.Text += "D301-" + SFTDoc + Environment.NewLine;
            //                lb_Status.Text = "Importing Finished Goods success : D301-" + ERPDoc;
            //            }
            //        }


            //    }
            //}
            //else
            //{
            //    bool IsEnoughWeight = true;
            //    for (int i = 0; i < dataQRInfor.Rows.Count; i++)
            //    {
            //        string productOrder = dataQRInfor.Rows[i]["ProductOrder"].ToString();
            //        string product = dataQRInfor.Rows[i]["Product"].ToString();
            //        double Quantity = double.Parse(dataQRInfor.Rows[i]["Quantity"].ToString());

            //        double SLDongGoi = Database.INV.INVMD.ConvertToWeightKg(product, Quantity);
            //        var ischeckSFCTA = Database.SFC.SFCTA.IscheckQantityAndWeight(productOrder, Quantity, SLDongGoi);
            //        var ischeckMOCTA = Database.MOC.MOCTA.IscheckQantityAndWeight(productOrder, Quantity, SLDongGoi);
            //        if (ischeckMOCTA == false || ischeckSFCTA == false)
            //        {
            //            IsEnoughWeight = false;
            //            break;
            //        }
            //    }

            //    UpdateData2DBForFinishedGoods updateData2DBForFinishedGoods = new UpdateData2DBForFinishedGoods();
            //    string ERPDoc = ""; string SFTDoc = "";
            //    if (IsEnoughWeight == false)
            //    {
            /        var Update = updateData2DBForFinishedGoods.UpdateDataDBForFinishedGoodsNotConfirm(dataQRInfor, txt_QRLocationImport.Text.Trim(), out ERPDoc, out SFTDoc);
            //        if (Update)
            //        {
            //            txt_ERPDocCreate.Text = "D301-" + ERPDoc;
            //            txt_SFTDoc.Text = "D301-" + SFTDoc;
            //            MessageBox.Show("D301-" + ERPDoc + " cannot confirm because not enough quantity or packing weight", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            lb_Status.Text = "Importing Finished Goods success, but this doccument is not confirm on ERP : D301-" + ERPDoc;
            //        }
            //    }
            //    else
            //    {
            //        var Update = updateData2DBForFinishedGoods.UpdateDataDBForFinishedGoods(dataQRInfor, txt_QRLocationImport.Text.Trim(), out ERPDoc, out SFTDoc);
            //        if (Update)
            //        {
            //            txt_ERPDocCreate.Text = "D301-" + ERPDoc;
            //            txt_SFTDoc.Text = "D301-" + SFTDoc;
            //            lb_Status.Text = "Importing Finished Goods success : D301-" + ERPDoc;
            //        }
            //    }
            //}*/
            
        }

  

        private void btn_buyerSelected_Click(object sender, EventArgs e)
        {
            CustomsDeclarasion.View.SelectBuyerWin selectBuyerWin = new CustomsDeclarasion.View.SelectBuyerWin();
            selectBuyerWin.FormClosed += SelectBuyerWin_FormClosed;
            selectBuyerWin.ShowDialog();

        }

        private void SelectBuyerWin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CustomsDeclarasion.View.SelectBuyerWin.dtRowSelected != null)
            {
                txt_buyerSelect.Text = CustomsDeclarasion.View.SelectBuyerWin.dtRowSelected["BuyerCode"].ToString();
            }
        }

        private void btn_ShipmentType_Click(object sender, EventArgs e)
        {
            CustomsDeclarasion.View.ShipmentTypeSelectWin shipmentTypeSelectWin = new CustomsDeclarasion.View.ShipmentTypeSelectWin();
            shipmentTypeSelectWin.FormClosed += ShipmentTypeSelectWin_FormClosed;
            shipmentTypeSelectWin.ShowDialog();
        }

        private void ShipmentTypeSelectWin_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (CustomsDeclarasion.View.ShipmentTypeSelectWin.dtRowSelected != null)
            {

                txt_ShipmentType.Text = CustomsDeclarasion.View.ShipmentTypeSelectWin.dtRowSelected["ShipmentCode"].ToString();
            }

        }

        private void txt_QRManpulationEX_TextChanged(object sender, EventArgs e)
        {
            if (txt_QRManpulationEX.Text.EndsWith("e") && txt_QRManpulationEX.Text.Length > 2)
            {

                string textSplit = txt_QRManpulationEX.Text.Substring(1, txt_QRManpulationEX.Text.Length - 2);


                if (textSplit == "E")
                {
                    txt_QRProductImport.Text = "";
                    txt_QRExportLocation.Text = "";
                    txt_QRManpulationEX.Text = "";
                    txt_QRExport.Focus();
                    FinishedGoodsExportFunction();

                }
                else if (textSplit == "N")
                {
                    txt_QRProductImport.Text = "";
                    txt_QRExportLocation.Text = "";
                    txt_QRManpulationEX.Text = "";
                    txt_QRProductImport.Focus();
                }
                else if (textSplit == "S")
                {
                    txt_QRExport.Text = "";
                    txt_QRProductImport.Text = "";
                    txt_QRExportLocation.Text = "";
                    txt_QRManpulationEX.Text = "";
                    txt_QRExport.Focus();
                }
            }
        }

       

        private void btn_ExportSummary_Click(object sender, EventArgs e)
        {
            ExportSummary exportSummary = new ExportSummary();
            exportSummary.ShowDialog();
        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void cmboxWareHouse_DropDownClosed(object sender, EventArgs e)
        {if(cmboxWareHouse.SelectedItem != null)
            Update_list_location(cmboxWareHouse.SelectedItem.ToString().Trim());
        }

        private void cmboxDocNo_DropDownClosed(object sender, EventArgs e)
        {
            Class.valiballecommon.GetStorage().DocNo = cmboxDocNo.SelectedItem.ToString() ;
            // Properties.Settings.Default.Save();
            SaveObject.Save_data(LoginFr.PathSaveConfig, Class.valiballecommon.GetStorage());
            lb_indicate.Text = GetListDocNo.GetDescribeDocNo(Class.valiballecommon.GetStorage().DocNo.Trim());
        }
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
                if (richTextLog.Lines.Count() > m_maxLine) //200 lines will remove top line
                {
                    richTextLog.SelectionStart = 0;
                    richTextLog.SelectionLength = richTextLog.Text.IndexOf("\n", 0) + 1;
                    richTextLog.SelectedText = "";
                }
                richTextLog.SelectionColor = brush;
                richTextLog.AppendText("\r\n[" + DateTime.Now.ToString("yyyyMMdd") + " " + DateTime.Now.ToString("HH:mm:ss") + "] " + text);

            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BT_SEARCH_Click(object sender, EventArgs e)
        {
            GRIDVIEW_DATABASE.DataSource= sql_QueryFromFileSQL.SelectQRCode(TXT_SEARCH.Text.Trim());
        }

        private void dtgv_import_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void GRIDVIEW_DATABASE_MouseClick(object sender, MouseEventArgs e)
        {
            string allID = null;
            if (GRIDVIEW_DATABASE.SelectedRows.Count > 0)
            {
                foreach (DataGridViewRow row in GRIDVIEW_DATABASE.SelectedRows)
                { allID = allID + " [" + row.Cells[0].Value.ToString() + "] "; }
            }
            if (e.Button == MouseButtons.Right)
            {
                ContextMenu m = new ContextMenu();
                //m.MenuItems.Add(new MenuItem("Cut"));
                //m.MenuItems.Add(new MenuItem("Copy"));
                MenuItem Enable = new MenuItem("Enable "+ allID);
                Enable.Click += Enable_Click; ;
                m.MenuItems.Add(Enable);
                m.Show(GRIDVIEW_DATABASE, new Point(e.X, e.Y));

            }
        }

        private void Enable_Click(object sender, EventArgs e)
        {
            if (GRIDVIEW_DATABASE.SelectedRows.Count > 0)
            {
                if (GRIDVIEW_DATABASE.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in GRIDVIEW_DATABASE.SelectedRows)
                    {
                        sql_QueryFromFileSQL.UpdateQRcodeByID(row.Cells[0].Value.ToString());

                    }
                }
            }
            GRIDVIEW_DATABASE.DataSource = sql_QueryFromFileSQL.SelectQRCode(TXT_SEARCH.Text.Trim());
        }

        private void GRIDVIEW_DATABASE_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           //
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // if (sql_QueryFromFileSQL.SelectQRCodeBaseStatus(TXT_SEARCH.Text.ToString().Trim(), false).Count > 0)
           // {
           //   sql_QueryFromFileSQL. UpdateQRcodeByQR(TXT_SEARCH.Text.ToString().Trim());
           //     GRIDVIEW_DATABASE.DataSource = sql_QueryFromFileSQL.SelectQRCode(TXT_SEARCH.Text.Trim());
           // }
        }
    }
}
