using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.ChartDrawing;


namespace WindowsFormsApplication1.MQC
{
    public partial class MQCReview : CommonFormMetro
    {
        List<MQCItemSummary> listMQCSummary = new List<MQCItemSummary>();
        List<chartdatabyDate> ListChartbyDate = new List<chartdatabyDate>();
        public MQCReview()
        {
            InitializeComponent();
            lbl_Header.Text = "MQC SUMMARY REPORT";
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {

            if(rd_date.Checked)
                DrawingMQCSummary("Date");
            else if (rd_Week.Checked)
                DrawingMQCSummary("Week");
            else if (rd_Month.Checked)
                DrawingMQCSummary("Month");
            else if (rd_Year.Checked)
                DrawingMQCSummary("Year");
        }
        private void DrawingMQCSummary(string byPreriodTime)
        {
            DateTime from = new DateTime(dtpk_fromDate.Value.Year, dtpk_fromDate.Value.Month, dtpk_fromDate.Value.Day,
                  tpk_from.Value.Hour, tpk_from.Value.Minute, tpk_from.Value.Second);
            DateTime to = new DateTime(dtpk_ToDate.Value.Year, dtpk_ToDate.Value.Month, dtpk_ToDate.Value.Day,
               tpk_to.Value.Hour, tpk_to.Value.Minute, tpk_to.Value.Second);
            if (byPreriodTime =="Date")
            {
                LoadDataSummary dataSummary = new LoadDataSummary();
               
                listMQCSummary = dataSummary.GetMQCSummary(from, to, "B01", "MQC");
                LiveChartDrawing liveChartDrawing = new LiveChartDrawing();
                liveChartDrawing.DrawingLiveChartDataSummary(listMQCSummary, ref ProductionLine);
                dtgv_data.DataSource = listMQCSummary;
            }
        else    if(byPreriodTime == "Week")
            {
                LoadDataSummary dataSummary = new LoadDataSummary();
                listMQCSummary = dataSummary.GetMQCSummarybyWeek(from, to, "B01", "MQC");
                var ListMQCbyProduct = listMQCSummary
                  .OrderBy(d => int.Parse(d.Time_from))
                   .GroupBy(u => u.Time_from)
                   .Select(grp => grp.ToList())
                  .ToList();
                listMQCSummary = new List<MQCItemSummary>();
                foreach (var ItemGroup in ListMQCbyProduct)
                {
                    MQCItemSummary itemSummary = new MQCItemSummary();
                    itemSummary.OutputQty = ItemGroup.Select(d => d.OutputQty).Sum();
                    itemSummary.NGQty = ItemGroup.Select(d => d.NGQty).Sum();
                    itemSummary.ReworkQty = ItemGroup.Select(d => d.ReworkQty).Sum();
                    itemSummary.QuantityTotal = itemSummary.OutputQty + itemSummary.NGQty/*+ itemSummary.ReworkQty*/;
                    itemSummary.OutputRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.OutputQty / itemSummary.QuantityTotal) : 0;
                    itemSummary.DefectRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.NGQty / itemSummary.QuantityTotal) : 0;
                    itemSummary.ReworkRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.ReworkQty / itemSummary.QuantityTotal) : 0;
                    itemSummary.Time_from = "Week: "+ ItemGroup[0].Time_from;

                    listMQCSummary.Add(itemSummary);
                }
                LiveChartDrawing liveChartDrawing = new LiveChartDrawing();
                liveChartDrawing.DrawingLiveChartDataSummary(listMQCSummary, ref ProductionLine);
                dtgv_data.DataSource = listMQCSummary;
            }
            else if (byPreriodTime == "Month")
            {
                LoadDataSummary dataSummary = new LoadDataSummary();
                listMQCSummary = dataSummary.GetMQCSummarybyMonth(from, to, "B01", "MQC");
                var ListMQCbyProduct = listMQCSummary
                   .GroupBy(u => u.Time_from)
                   .Select(grp => grp.ToList())
                  .ToList();
                listMQCSummary = new List<MQCItemSummary>();
                foreach (var ItemGroup in ListMQCbyProduct)
                {
                    MQCItemSummary itemSummary = new MQCItemSummary();
                    itemSummary.OutputQty = ItemGroup.Select(d => d.OutputQty).Sum();
                    itemSummary.NGQty = ItemGroup.Select(d => d.NGQty).Sum();
                    itemSummary.ReworkQty = ItemGroup.Select(d => d.ReworkQty).Sum();
                    itemSummary.QuantityTotal = itemSummary.OutputQty + itemSummary.NGQty/*+ itemSummary.ReworkQty*/;
                    itemSummary.OutputRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.OutputQty / itemSummary.QuantityTotal) : 0;
                    itemSummary.DefectRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.NGQty / itemSummary.QuantityTotal) : 0;
                    itemSummary.ReworkRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.ReworkQty / itemSummary.QuantityTotal) : 0;
                    itemSummary.Time_from = ItemGroup[0].Time_from;

                    listMQCSummary.Add(itemSummary);
                }
                LiveChartDrawing liveChartDrawing = new LiveChartDrawing();
                liveChartDrawing.DrawingLiveChartDataSummary(listMQCSummary, ref ProductionLine);
                dtgv_data.DataSource = listMQCSummary;
            }
            else if (byPreriodTime =="Year")
            {
                LoadDataSummary dataSummary = new LoadDataSummary();
                listMQCSummary = dataSummary.GetMQCSummarybyYear(from, to, "B01", "MQC");
                var ListMQCbyProduct = listMQCSummary
                   .GroupBy(u => u.Time_from)
                   .Select(grp => grp.ToList())
                  .ToList();
                listMQCSummary = new List<MQCItemSummary>();
                foreach (var ItemGroup in ListMQCbyProduct)
                {
                    MQCItemSummary itemSummary = new MQCItemSummary();
                    itemSummary.OutputQty = ItemGroup.Select(d => d.OutputQty).Sum();
                    itemSummary.NGQty = ItemGroup.Select(d => d.NGQty).Sum();
                    itemSummary.ReworkQty = ItemGroup.Select(d => d.ReworkQty).Sum();
                    itemSummary.QuantityTotal = itemSummary.OutputQty + itemSummary.NGQty/*+ itemSummary.ReworkQty*/;
                    itemSummary.OutputRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.OutputQty / itemSummary.QuantityTotal) : 0;
                    itemSummary.DefectRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.NGQty / itemSummary.QuantityTotal) : 0;
                    itemSummary.ReworkRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.ReworkQty / itemSummary.QuantityTotal) : 0;
                    itemSummary.Time_from = ItemGroup[0].Time_from;

                    listMQCSummary.Add(itemSummary);
                }
                LiveChartDrawing liveChartDrawing = new LiveChartDrawing();
                liveChartDrawing.DrawingLiveChartDataSummary(listMQCSummary, ref ProductionLine);
                dtgv_data.DataSource = listMQCSummary;
            }
        }
        private void Dtgv_data_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SettingDatagridview(ref dtgv_data);
            dtgv_data.Columns["product"].Visible = false;
            dtgv_data.Columns["Time_To"].Visible = false;
            dtgv_data.Columns["Lot"].Visible = false;
            dtgv_data.Columns["Line"].Visible = false;
            dtgv_data.Columns["Remark"].Visible = false;
            //   dtgv_data.Columns["defectItems"].Visible = false;

            dtgv_data.Columns["Time_from"].HeaderText = "Date";
            dtgv_data.Columns["QuantityTotal"].HeaderText = "Total Quantity";
            dtgv_data.Columns["QuantityTotal"].DefaultCellStyle.Format = "N0";
            dtgv_data.Columns["OutputQty"].HeaderText = "Output Quantity";
            dtgv_data.Columns["OutputQty"].DefaultCellStyle.Format = "N0";
            dtgv_data.Columns["OutputRate"].HeaderText = "Output (%)";
            dtgv_data.Columns["OutputRate"].DefaultCellStyle.Format = "P1";
            dtgv_data.Columns["NGQty"].HeaderText = "Defect Quantity";
            dtgv_data.Columns["NGQty"].DefaultCellStyle.Format = "N0";
            dtgv_data.Columns["DefectRate"].HeaderText = "Defect (%)";
            dtgv_data.Columns["DefectRate"].DefaultCellStyle.Format = "P1";
            dtgv_data.Columns["ReworkQty"].HeaderText = "Rework Quantity";
            dtgv_data.Columns["ReworkQty"].DefaultCellStyle.Format = "N0";
            dtgv_data.Columns["ReworkRate"].HeaderText = "Rework (%)";
            dtgv_data.Columns["ReworkRate"].DefaultCellStyle.Format = "P1";


        }
        private void SettingDatagridview(ref DataGridView dataGrid)
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
        private List<chartdatabyDate>ConvertToChartdata(List<MQCItemSummary> mQCItemSummaries, string Name)
        {
            List<chartdatabyDate> chartdatabies = new List<chartdatabyDate>();
            try
            {
                foreach (var item in mQCItemSummaries)
                {
                    chartdatabyDate chartdatabyDate = new chartdatabyDate();
                    if(Name =="Output")
                    {
                        chartdatabyDate.date =DateTime.ParseExact(item.Time_from,"dd-MM-yyyy", CultureInfo.InvariantCulture);
                        chartdatabyDate.value = item.OutputQty;

                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
            return chartdatabies;
        }

        private void Dtgv_data_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                ContextMenuStrip m = new ContextMenuStrip();
                m.Name = "TabExport";
                m.BackColor = Color.AntiqueWhite;

                // m.MenuItems.Add(new MenuItem("delete"));
                int currentMouseOverRow = dtgv_data.HitTest(e.X, e.Y).RowIndex;
               RowIndexClick = currentMouseOverRow;
                if (currentMouseOverRow >= 0)
                {
                    m.Items.Add("Defect Export");
                    m.ItemClicked += M_ItemClicked;
                }

                m.Show(dtgv_data, new Point(e.X, e.Y));

            }
        }
        public int RowIndexClick = -1;
        private void M_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            try
            {
                string ItemClick = e.ClickedItem.ToString();
                if (ItemClick == "Defect Export")
                {
                    Class.ToolSupport toolSupport = new Class.ToolSupport();
                    var dataRow = dtgv_data.Rows[RowIndexClick].DataBoundItem as MQCItemSummary;
                    string pathsave = "";
                    string pathMonth = Environment.CurrentDirectory + @"\Resources\Month.xls";

                    System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();

                        saveFileDialog.Title = "Browse Excel Files";
                        saveFileDialog.DefaultExt = "Excel";
                        saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                        saveFileDialog.CheckPathExists = true;

                        if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        {
                            pathsave = saveFileDialog.FileName;

                            saveFileDialog.RestoreDirectory = true;

                            toolSupport.ExportToTemplateTop5Defect(pathMonth, pathsave, dataRow);
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
                else if (ItemClick == "Rework Export")
                {

                }
                    
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, " M_ItemClicked(object sender, ToolStripItemClickedEventArgs e)", ex.Message);
            }
        }


        private void Btn_ExportExcel_Click(object sender, EventArgs e)
        {
            MQCReport mQCReport = new MQCReport();
           
            string pathsave = "";
            System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();

            saveFileDialog.Title = "Browse Excel Files";
            saveFileDialog.DefaultExt = "Excel";
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

            saveFileDialog.CheckPathExists = true;

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pathsave = saveFileDialog.FileName;

                saveFileDialog.RestoreDirectory = true;
                DateTime from = new DateTime(dtpk_fromDate.Value.Year, dtpk_fromDate.Value.Month, dtpk_fromDate.Value.Day,
                    tpk_from.Value.Hour, tpk_from.Value.Minute, tpk_from.Value.Second);
                DateTime To = new DateTime(dtpk_ToDate.Value.Year, dtpk_ToDate.Value.Month, dtpk_ToDate.Value.Day,
                   tpk_to.Value.Hour, tpk_to.Value.Minute, tpk_to.Value.Second);
                if (mQCReport.ExportReportProductionFromToNewForm(from,To, pathsave))
                {
                   SystemLog.Output(SystemLog.MSG_TYPE.Nor, "[Btn_ExportExcel_Click]", "Export MQC report to excel sucessfull");
                    var resultMessage = MessageBox.Show("MQC Report exported to excel sucessful ! \n\r Do you want to open this file ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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

        private void MQCReview_Load(object sender, EventArgs e)
        {
            tpk_from.Format = DateTimePickerFormat.Custom;
            tpk_from.CustomFormat = "HH:mm";
            tpk_to.Format = DateTimePickerFormat.Custom;
            tpk_to.CustomFormat = "HH:mm";
        }
    }
}
