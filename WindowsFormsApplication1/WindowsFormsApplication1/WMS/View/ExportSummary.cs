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
    public partial class ExportSummary : CommonFormMetro
    {
        DataTable dtExportSummary;
        public ExportSummary()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {

            try
            {
                Database.ERPSOFT.t_ExportFGoods t_ExportFGoods = new Database.ERPSOFT.t_ExportFGoods();
                dtExportSummary = t_ExportFGoods.GetDataTableExportSummary(dtpk_from.Value, dtpk_to.Value, (bool)rd_exportDate.Checked);
                dtgv_ExportSummary.DataSource = dtExportSummary;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Can't get data import summary", ex.Message);
            }
        }

        private void dtgv_ExportSummary_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_ExportSummary);
            dtgv_ExportSummary.AllowUserToAddRows = false;
           if(dtgv_ExportSummary.Rows.Count > 0)
            {
                dtgv_ExportSummary.Columns["TL201"].Visible = false;
                dtgv_ExportSummary.Columns["TL202"].Visible = false;
                dtgv_ExportSummary.Columns["TL203"].Visible = false;
                dtgv_ExportSummary.Columns["TL204"].Visible = false;
                dtgv_ExportSummary.Columns["dateUpdate"].Visible = false;
                dtgv_ExportSummary.Columns["TL211"].Visible = false;
                dtgv_ExportSummary.Columns["TL212"].Visible = false;
                dtgv_ExportSummary.Columns["TL213"].Visible = false;
                dtgv_ExportSummary.Columns["TL214"].Visible = false;
                dtgv_ExportSummary.Columns["PriceUnit"].Visible = false;
                dtgv_ExportSummary.Columns["Currency"].Visible = false;

            }
        }

        private void txt_IDFillter_TextChanged(object sender, EventArgs e)
        {
            if (dtExportSummary != null && dtExportSummary.Rows.Count > 0)
            {
                dtExportSummary.DefaultView.RowFilter = string.Format("CONVERT(KeyNo, 'System.String') like '%{0}%'", txt_IDFillter.Text.Trim());

            }
        }

        private void txt_productFillter_TextChanged(object sender, EventArgs e)
        {

            if (dtExportSummary != null && dtExportSummary.Rows.Count > 0)
            {
                dtExportSummary.DefaultView.RowFilter = string.Format("Product like '%{0}%'", txt_productFillter.Text.Trim());

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
                if (dtgv_ExportSummary.Rows.Count > 0)
                {
                    Class.ToolSupport toolSupport = new Class.ToolSupport();
                    toolSupport.dtgvExport2Excel(dtgv_ExportSummary, pathsave);

                }
            }
        }
    }
}
