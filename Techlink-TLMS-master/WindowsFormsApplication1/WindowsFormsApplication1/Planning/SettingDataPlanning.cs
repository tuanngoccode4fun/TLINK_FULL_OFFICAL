using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Planning
{
    public partial class SettingDataPlanning : MetroFramework.Forms.MetroForm
    {
        List<SettingBOM> settingBOMs;
        LoadDataPlanning loadData;
        List<SettingManufacture> settingManufactures;
        Dictionary<string, string> DicLanguageSetting = new Dictionary<string, string>();
        string partFilter = "";
        public SettingDataPlanning(string part)
        {
            InitializeComponent();
            partFilter = part;
            WindowState = FormWindowState.Maximized;
         //  IntilizialBOMSetting();
        }
        private void SettingDatagridview (ref DataGridView dataGrid)
        {

            dataGrid.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            dataGrid.BackgroundColor = Color.LightSteelBlue;
            dataGrid.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.ColumnHeadersHeight = 100;
            
        }
        private void SettingHeaderDataGridViewBom()
        {
            dtgv_SettingBom.Columns["ProductName"].HeaderText = DicLanguageSetting["ProductName"];
            dtgv_SettingBom.Columns["ProductNo"].HeaderText = DicLanguageSetting["ProductNo"];
            dtgv_SettingBom.Columns["QtyInBox"].HeaderText = DicLanguageSetting["QtyInBox"];
            dtgv_SettingBom.Columns["QtyInBox"].DefaultCellStyle.Format = "N0";
            dtgv_SettingBom.Columns["QtyTool"].HeaderText = DicLanguageSetting["QtyTool"];
            dtgv_SettingBom.Columns["QtyTool"].DefaultCellStyle.Format = "N0";
        }
        private void SettingHeaderDataGridViewManufacture()
        {
            dtgv_manufacture.Columns["ProductName"].HeaderText = DicLanguageSetting["ProductName"];
            dtgv_manufacture.Columns["ProductNo"].HeaderText = DicLanguageSetting["ProductNo"];
            dtgv_manufacture.Columns["PlanQty"].HeaderText = DicLanguageSetting["PlanQty"];
            dtgv_manufacture.Columns["PlanQty"].DefaultCellStyle.Format = "N0";
            dtgv_manufacture.Columns["Workertarget"].HeaderText = DicLanguageSetting["Workertarget"];
            dtgv_manufacture.Columns["Workertarget"].DefaultCellStyle.Format = "N0";
        }
        private void IntilizialBOMSetting()
        {
            settingBOMs = new List<SettingBOM>();
           loadData = new LoadDataPlanning();

            settingBOMs = loadData.GetSettingBOMs("FF");
            loadData.InsertToBOMSettingTableIntilizer(settingBOMs);
        }
        private void LoadingSettingBOM()
        {
            settingBOMs = new List<SettingBOM>();
        loadData = new LoadDataPlanning();

            settingBOMs = loadData.LoadingSettingBOMs();
            dtgv_SettingBom.DataSource = settingBOMs;
            SettingHeaderDataGridViewBom();
            SettingDatagridview(ref dtgv_SettingBom);
        }

    
        private void Dtgv_SettingBom_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                txt_productName.Text = dtgv_SettingBom.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_productNo.Text = dtgv_SettingBom.Rows[e.RowIndex].Cells[1].Value.ToString();
                nmr_QtyPackage.Value = int.Parse(dtgv_SettingBom.Rows[e.RowIndex].Cells[2].Value.ToString());
                nmr_toolpcs.Value = int.Parse(dtgv_SettingBom.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if(txt_productNo.Text != "")
            {
                try
                {
                    int intQtyPacking = (int)nmr_QtyPackage.Value;
                    int intQtyTool = (int)nmr_toolpcs.Value;
                    loadData.UpdateToDatabase(txt_productNo.Text.Trim(), intQtyPacking, intQtyTool);
                    settingBOMs = loadData.LoadingSettingBOMs();
                    dtgv_SettingBom.DataSource = settingBOMs;
                    SettingHeaderDataGridViewBom();
                    SettingDatagridview(ref dtgv_SettingBom);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void Btn_delete_Click(object sender, EventArgs e)
        {
            if (txt_productNo.Text != "")
            {
                try
                {
                    int intQtyPacking = (int)nmr_QtyPackage.Value;
                    int intQtyTool = (int)nmr_toolpcs.Value;
                    loadData.DeleteRowofProduct(txt_productNo.Text.Trim());
                    settingBOMs = loadData.LoadingSettingBOMs();
                    dtgv_SettingBom.DataSource = settingBOMs;
                    SettingHeaderDataGridViewBom();
                    SettingDatagridview(ref dtgv_SettingBom);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void Btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_productNo.Text != "" && txt_productName.Text != "")
            {
                try
                {
                    int intQtyPacking = (int)nmr_QtyPackage.Value;
                    int intQtyTool = (int)nmr_toolpcs.Value;
                    loadData.InsertRowofProduct(txt_productName.Text.Trim(), txt_productNo.Text.Trim(), intQtyPacking, intQtyTool);
                    settingBOMs = loadData.LoadingSettingBOMs();
                    dtgv_SettingBom.DataSource = settingBOMs;
                    SettingHeaderDataGridViewBom();
                    SettingDatagridview(ref dtgv_SettingBom);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void Dtgv_SettingBom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                txt_productName.Text = dtgv_SettingBom.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_productNo.Text = dtgv_SettingBom.Rows[e.RowIndex].Cells[1].Value.ToString();
                nmr_QtyPackage.Value = int.Parse(dtgv_SettingBom.Rows[e.RowIndex].Cells[2].Value.ToString());
                nmr_toolpcs.Value = int.Parse(dtgv_SettingBom.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
        }


        private void Btn_Search_Click(object sender, EventArgs e)
        {

            settingBOMs = new List<SettingBOM>();
            loadData = new LoadDataPlanning();
            settingBOMs = loadData.LoadingSettingBOMsFilter(txt_productFilter.Text.Trim());

            dtgv_SettingBom.DataSource = settingBOMs;
            SettingHeaderDataGridViewBom();
            SettingDatagridview(ref dtgv_SettingBom);
        }
        private void LoadingSettingManufacture()
        {
            settingManufactures = new List<SettingManufacture>();
            loadData = new LoadDataPlanning();

            settingManufactures = loadData.LoadingSettingManufacture();
            dtgv_manufacture.DataSource = settingManufactures;
            SettingHeaderDataGridViewManufacture();
            SettingDatagridview(ref dtgv_manufacture);
        }
        private void Tabcontrol_Selected(object sender, TabControlEventArgs e)
        {
            int intTabIndex = e.TabPageIndex;
            if(intTabIndex == 0)
            {
              
                SettingForm.Language.LanguageSetting languageSetting = new SettingForm.Language.LanguageSetting();
                string language = Class.valiballecommon.GetStorage().Language;
                if (language == "") language = LanguageEnum.English.ToString();

                DicLanguageSetting = languageSetting.GetNameTranslate(language, "SettingBOM");
                LoadingSettingBOM();
            }
            else if (intTabIndex == 1)
            {
               
                SettingForm.Language.LanguageSetting languageSetting = new SettingForm.Language.LanguageSetting();
                string language = Class.valiballecommon.GetStorage().Language;
                if (language == "") language = LanguageEnum.English.ToString();
                DicLanguageSetting = languageSetting.GetNameTranslate(language, "SettingManufacture");
                LoadingSettingManufacture();
            }
        }

        private void Dtgv_manufacture_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                txt_productsInput2.Text = dtgv_manufacture.Rows[e.RowIndex].Cells[0].Value.ToString();
                txt_productNoInput2.Text = dtgv_manufacture.Rows[e.RowIndex].Cells[1].Value.ToString();
                nmr_PlanQty.Value = int.Parse(dtgv_manufacture.Rows[e.RowIndex].Cells[2].Value.ToString());
                nmr_WorkerPerformance.Value = int.Parse(dtgv_manufacture.Rows[e.RowIndex].Cells[3].Value.ToString());
            }
        }

        private void Btn_Add2_Click(object sender, EventArgs e)
        {
            if (txt_productNoInput2.Text != "" && txt_productsInput2.Text != "")
            {
                try
                {
                    int intWorkerQty = (int)nmr_PlanQty.Value;
                    int intWorkerTarget = (int)nmr_WorkerPerformance.Value;
                    loadData.InsertRowofManufacture(txt_productsInput2.Text.Trim(), txt_productNoInput2.Text.Trim(), intWorkerQty, intWorkerTarget);
                    settingManufactures = loadData.LoadingSettingManufacture();
                    dtgv_manufacture.DataSource = settingManufactures;
                    SettingHeaderDataGridViewManufacture();
                    SettingDatagridview(ref dtgv_manufacture);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void Btn_Update2_Click(object sender, EventArgs e)
        {
            if (txt_productNoInput2.Text != "")
            {
                try
                {
                    int intWorkerQty = (int)nmr_PlanQty.Value;
                    int intWorkertarget= (int)nmr_WorkerPerformance.Value;
                    loadData.UpdateToManufacture(txt_productNoInput2.Text.Trim(), intWorkerQty, intWorkertarget);
                    settingManufactures = loadData.LoadingSettingManufacture();
                    dtgv_manufacture.DataSource = settingManufactures;
                    SettingHeaderDataGridViewManufacture();
                    SettingDatagridview(ref dtgv_manufacture);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void Btn_Delete2_Click(object sender, EventArgs e)
        {
            if (txt_productNoInput2.Text != "")
            {
                try
                {
                 
                    loadData.DeleteRowofManufaccture(txt_productNoInput2.Text.Trim());
                    settingManufactures = loadData.LoadingSettingManufacture();
                    dtgv_manufacture.DataSource = settingManufactures;
                    SettingHeaderDataGridViewManufacture();
                    SettingDatagridview(ref dtgv_manufacture);
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }

        private void Txt_Search2_Click(object sender, EventArgs e)
        {
            settingManufactures = new List<SettingManufacture>();
            loadData = new LoadDataPlanning();
            settingManufactures = loadData.LoadingSettingManufactureFilter(txt_productFilter2.Text.Trim());
            dtgv_manufacture.DataSource = settingManufactures;
            SettingHeaderDataGridViewManufacture();
            SettingDatagridview(ref dtgv_manufacture);
        }

        private void SettingDataPlanning_Load(object sender, EventArgs e)
        {
            lbl_Header.Text = "PRODUCTION PLANNING CONFIGURE";
         //   Tabcontrol.SelectedIndex = 0;
            SettingForm.Language.LanguageSetting languageSetting = new SettingForm.Language.LanguageSetting();
            string language = Class.valiballecommon.GetStorage().Language;
            if (language == "") language = LanguageEnum.English.ToString();

            DicLanguageSetting = languageSetting.GetNameTranslate(language, "SettingBOM");
            LoadingSettingBOM();
        }

        private void Tabcontrol_SelectedIndexChanged(object sender, EventArgs e)
        {
            SettingForm.Language.LanguageSetting languageSetting = new SettingForm.Language.LanguageSetting();
            string language = Class.valiballecommon.GetStorage().Language;
            switch ((sender as TabControl).SelectedIndex)
            {  
                case 0:
                  
                 
                    if (language == "") language = LanguageEnum.English.ToString();

                    DicLanguageSetting = languageSetting.GetNameTranslate(language, "SettingBOM");
                    LoadingSettingBOM();
                    break;
                case 1:
                   languageSetting = new SettingForm.Language.LanguageSetting();
                  
                    if (language == "") language = LanguageEnum.English.ToString();
                    DicLanguageSetting = languageSetting.GetNameTranslate(language, "SettingManufacture");
                    LoadingSettingManufacture();
                    break;
                case 2:
                 

                    break;
            }
        }
    }
}
