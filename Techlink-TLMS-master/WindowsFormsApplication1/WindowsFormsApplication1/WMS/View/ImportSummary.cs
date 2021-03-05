using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace WindowsFormsApplication1.WMS.View
{
    public partial class ImportSummary : CommonFormMetro
    {
        DataTable dtImportSummary;

        public ImportSummary()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            try
            {
                Database.ERPSOFT.ERPOutPQCQR eRPOutPQCQR = new Database.ERPSOFT.ERPOutPQCQR();
                dtImportSummary = eRPOutPQCQR.GetDataTableImportSummary(dtpk_from.Value, dtpk_to.Value, (bool) rd_ImportDate.Checked);
                dtgv_importSummary.DataSource = dtImportSummary;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Can't get data import summary", ex.Message);
            }
        }

        private void dtgv_importSummary_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_importSummary);
            dtgv_importSummary.ReadOnly = false;
            dtgv_importSummary.AllowUserToAddRows = false;
            if (dtgv_importSummary.Rows.Count > 0)
            {
                dtgv_importSummary.Columns["SubQR"].Visible = false;
             //   dtgv_importSummary.Columns["KeyID"].Visible = false;
              //  dtgv_importSummary.Columns["KeyNo"].Visible = false;
                dtgv_importSummary.Columns["TL101"].Visible = false;
                dtgv_importSummary.Columns["TL102"].Visible = false;
                dtgv_importSummary.Columns["TL103"].Visible = false;
                dtgv_importSummary.Columns["TL104"].Visible = false;
                dtgv_importSummary.Columns["dateUpdate"].Visible = false;
                //  dtgv_importSummary.Columns["ImportFlag"].Visible = false;
                dtgv_importSummary.Columns["TL111"].Visible = false;
                dtgv_importSummary.Columns["TL112"].Visible = false;
             //   dtgv_importSummary.Columns["TL113"].Visible = false;
                dtgv_importSummary.Columns["TL114"].Visible = false;
                //  dtgv_importSummary.Columns["dateImport"].Visible = false;
                
                dtgv_importSummary.Columns["ProductOrder"].HeaderText = "Production Order";

                dtgv_importSummary.Columns["Quantity"].HeaderText = "Import Quantity (pcs)";
                dtgv_importSummary.Columns["Quantity"].DefaultCellStyle.Format = "N0";
                dtgv_importSummary.Columns["LotNo"].HeaderText = "Lot No";
                dtgv_importSummary.Columns["dateCreate"].HeaderText = "Request's Date";
                dtgv_importSummary.Columns["ImportFlag"].HeaderText = "Already Imported";
                dtgv_importSummary.Columns["dateImport"].HeaderText = "Import Date";
                dtgv_importSummary.Columns["TL113"].HeaderText = "ERP Doc";
                dtgv_importSummary.Columns["ProductOrder"].ReadOnly = true;
                dtgv_importSummary.Columns["Product"].ReadOnly = true;
                dtgv_importSummary.Columns["STT"].ReadOnly = true;
                dtgv_importSummary.Columns["Quantity"].ReadOnly = true;
                dtgv_importSummary.Columns["LotNo"].ReadOnly = true;
                dtgv_importSummary.Columns["Warehouse"].ReadOnly = true;
                dtgv_importSummary.Columns["dateCreate"].ReadOnly = true;
                dtgv_importSummary.Columns["dateCreate"].ReadOnly = true;
                dtgv_importSummary.Columns["ImportFlag"].ReadOnly = true;
                dtgv_importSummary.Columns["dateImport"].ReadOnly = true;


            }
        }

        private void txt_IDFillter_TextChanged(object sender, EventArgs e)
        {
            if (dtImportSummary != null && dtImportSummary.Rows.Count > 0)
            {
                dtImportSummary.DefaultView.RowFilter = string.Format("CONVERT(KeyNo, 'System.String') like '%{0}%'", txt_IDFillter.Text.Trim());

            }
        }

        private void txt_productFillter_TextChanged(object sender, EventArgs e)
        {

            if (dtImportSummary != null && dtImportSummary.Rows.Count > 0)
            {
                dtImportSummary.DefaultView.RowFilter = string.Format("Product like '%{0}%'", txt_productFillter.Text.Trim());

            }
        }

        private void btn_exportExcel_Click(object sender, EventArgs e)
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
                if(dtgv_importSummary.Rows.Count > 0)
                {
                    Class.ToolSupport toolSupport = new Class.ToolSupport();
                    toolSupport.dtgvExport2Excel(dtgv_importSummary, pathsave);
                  
                }
            }
        }
    }
}
