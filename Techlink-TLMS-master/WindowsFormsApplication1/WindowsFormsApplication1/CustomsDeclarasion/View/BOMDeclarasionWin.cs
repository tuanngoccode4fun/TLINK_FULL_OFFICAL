using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.CustomsDeclarasion.View
{
    public partial class BOMDeclarasionWin : Form
    {
        List<Model.HQERPBOM> ListhQERPBOMs;
        public BOMDeclarasionWin()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgv_BOMInfor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgv_BOMInforHQ.AllowUserToAddRows = false;
            DatagridviewSetting.settingDatagridview(dtgv_BOMInforHQ);

        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            Database.ERPSOFT.t_HQ_ERP_MAPPING t_HQ_ERP_MAPPING = new Database.ERPSOFT.t_HQ_ERP_MAPPING();

            DataTable dtHQ = t_HQ_ERP_MAPPING.GetDataTableFromHQ_ERP_MAPPINGbyproductSearch(txt_productSearch.Text.Trim());
            dtgv_MASPHQ.DataSource = dtHQ;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            Database.ERPSOFT.t_HQ_ERP_MAPPING t_HQ_ERP_MAPPING = new Database.ERPSOFT.t_HQ_ERP_MAPPING();
            t_HQ_ERP_MAPPING.UploadProductCodebyCustomsDB();
        }

        private void BOMDeclarasionWin_Load(object sender, EventArgs e)
        {

            Database.ERPSOFT.t_HQ_ERP_MAPPING t_HQ_ERP_MAPPING = new Database.ERPSOFT.t_HQ_ERP_MAPPING();

            DataTable dtHQ = t_HQ_ERP_MAPPING.GetDataTableFromHQ_ERP_MAPPING();
            dtgv_MASPHQ.DataSource = dtHQ;

        }

        private void dtgv_MASPHQ_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgv_MASPHQ.AllowUserToAddRows = false;
            DatagridviewSetting.settingDatagridview(dtgv_MASPHQ);
        }

        private void dtgv_MASPHQ_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //if(e.RowIndex >=0 && e.ColumnIndex >=0)
            //{
            //    string Ma_SP_HQ = dtgv_MASPHQ.Rows[e.RowIndex].Cells["MA_SP"].Value.ToString().Trim();
            //    string Ma_HS_HQ = dtgv_MASPHQ.Rows[e.RowIndex].Cells["MA_HS"].Value.ToString().Trim();
            //    string ma_SP_ERP = dtgv_MASPHQ.Rows[e.RowIndex].Cells["MA_SP_ERP"].Value.ToString().Trim();

            //    Database.CustomsDeclar.GetBOMCustoms getBOMCustoms = new Database.CustomsDeclar.GetBOMCustoms();

            // DataTable dtBPMHQ =   getBOMCustoms.BOMHAIQUANTheoMaSp(Ma_SP_HQ);
            //    dtgv_BOMInforHQ.DataSource = dtBPMHQ;
            //    Database.BOM.BOMHQ bOMHQ = new Database.BOM.BOMHQ();
            //    DataTable dtBOMERP = bOMHQ.GetDataTableBOMHQonERP(ma_SP_ERP);
            //    dtgv_BOMERP.DataSource = dtBOMERP;
            //}

        }

        private void dtgv_BOMERP_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgv_BOMERP.AllowUserToAddRows = false;
            DatagridviewSetting.settingDatagridview(dtgv_BOMERP);
        }

        private void btn_compare_Click(object sender, EventArgs e)
        {
            Database.ERPSOFT.t_HQ_ERP_MAPPING t_HQ_ERP_MAPPING = new Database.ERPSOFT.t_HQ_ERP_MAPPING();
            DataTable dtMA_SP_HQ = t_HQ_ERP_MAPPING.GetAllDataTableFromHQ_ERP_MAPPING();
            Controller.CompareBOMHQERP compareBOMHQERP = new Controller.CompareBOMHQERP();

            ListhQERPBOMs = compareBOMHQERP.listHQERPBoms(dtMA_SP_HQ);
            dtgv_MASPHQ.DataSource = ListhQERPBOMs;

        }

        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            string pathsave = "";
            try
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Title = "Browse Excel Files";
                saveFileDialog.DefaultExt = "Excel";
                saveFileDialog.Filter = "Excel files (*.xls)|*.xls";

                saveFileDialog.CheckPathExists = true;


                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pathsave = saveFileDialog.FileName;

                    saveFileDialog.RestoreDirectory = true;
                    Controller.ExportCustomsDeclaration exportCustoms = new Controller.ExportCustomsDeclaration();
                    if (ListhQERPBOMs.Count > 0)
                    {
                        exportCustoms.ExportCompareasionBOM(pathsave, ListhQERPBOMs);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void txt_productSearch_TextChanged(object sender, EventArgs e)
        {
            if(txt_productSearch.Text != "")
            {
                var ListFillter = ListhQERPBOMs.Where(d => d.MA_SP_ERP.Contains(txt_productSearch.Text.Trim())).ToList();
                dtgv_MASPHQ.DataSource = ListFillter;
            }
        }
    }
}
