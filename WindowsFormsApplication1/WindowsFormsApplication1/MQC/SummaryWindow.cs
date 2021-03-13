using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
namespace WindowsFormsApplication1.MQC
{
    public partial class SummaryWindow : MetroForm
    {
        public List<MQCItemSummary> qCItemSummaries = new List<MQCItemSummary>();
        List<string> listHeader = new List<string>();
        public string path = Environment.CurrentDirectory + @"\Resources\Template_MQC.xlsx";
        public SummaryWindow(List<MQCItemSummary> summaries) 
        {
            InitializeComponent();
            qCItemSummaries = summaries;
            lb_tiltle.Text = "Production Summary data";
        }

        private void SummaryWindow_Load(object sender, EventArgs e)
        {
            // dtgv_summary.DataSource = qCItemSummaries;
            CreateDatagridview();
            FillDataToDataGridView();

        }
        public void CreateDatagridview ()
        {
            DataGridViewCell cell = new DataGridViewTextBoxCell();
            cell.Style.Font = new Font("Times New Roman", 12);
            DataGridViewColumn newCol = new DataGridViewColumn(); // add a column to the grid
            newCol.CellTemplate = cell;
            newCol.HeaderText = @"
Tên sản phẩm
 品名";
            newCol.Name = "col1";
            newCol.Visible = true;
            newCol.Width = 100;
            dtgv_summary.Columns.Add(newCol);

            DataGridViewColumn newCol2 = new DataGridViewColumn(); // add a column to the grid
          
            newCol2.CellTemplate = cell;
            newCol2.HeaderText = @"
时间
Thời gian
";
            newCol2.Name = "col2";
            newCol2.Visible = true;
            newCol2.Width = 100;
            dtgv_summary.Columns.Add(newCol2);


            DataGridViewColumn newCol3 = new DataGridViewColumn(); // add a column to the grid

            newCol3.CellTemplate = cell;
            newCol3.HeaderText = @"
Số lượng nhận
数量
Quantity received
";
            newCol3.Name = "col3";
            newCol3.Visible = true;
            newCol3.Width = 100;
            dtgv_summary.Columns.Add(newCol3);
            LoadDefectMapping defectMapping = new LoadDefectMapping();
            List<NGItemsMapping> nGItemsMappings = defectMapping.listNGMapping("B01", "MQC");
            foreach (var mQCItem in qCItemSummaries)
            {
                foreach (var defect in mQCItem.defectItems)
                {
                    if (listHeader.Contains(defect.DefectSFT) == false)
                    {
                        DataGridViewColumn col = new DataGridViewColumn(); // add a column to the grid
                  
                    col.CellTemplate = cell;
                    col.HeaderText = defect.DefectSFTName; 
                    col.Name = defect.DefectSFT;
                    col.Visible = true;
                    col.Width = 100;
                        dtgv_summary.Columns.Add(col);
                        listHeader.Add(defect.DefectSFT);
                    }
                }
            }

            DataGridViewColumn newCol4 = new DataGridViewColumn(); // add a column to the grid

            newCol4.CellTemplate = cell;
            newCol4.HeaderText = @"
Số lượng đạt
合格数
Good part quantity
";
            newCol4.Name = "col4";
            newCol4.Visible = true;
            newCol4.Width = 100;
            dtgv_summary.Columns.Add(newCol4);

            DataGridViewColumn newCol5 = new DataGridViewColumn(); // add a column to the grid

            newCol5.CellTemplate = cell;
            newCol5.HeaderText = @"
Số lượng lỗi
不良数
Quantity of defect
";
            newCol5.Name = "col5";
            newCol5.Visible = true;
            newCol5.Width = 100;
            dtgv_summary.Columns.Add(newCol5);

            DataGridViewColumn newCol6 = new DataGridViewColumn(); // add a column to the grid

            newCol6.CellTemplate = cell;
            newCol6.HeaderText = @"
Tỷ lệ % lỗi
不良率(%)
Defect rate
(%)
";
            newCol6.Name = "col6";
            newCol6.Visible = true;
            newCol6.Width = 100;
            dtgv_summary.Columns.Add(newCol6);

            DataGridViewColumn newCol7 = new DataGridViewColumn(); // add a column to the grid

            newCol7.CellTemplate = cell;
            newCol7.HeaderText = @"
Ghi chú
备注
Remarks
";
            newCol7.Name = "col7";
            newCol7.Visible = true;
            newCol7.Width = 100;
            dtgv_summary.Columns.Add(newCol7);
        }
        public void FillDataToDataGridView()
        {
            for (int i = 0; i < qCItemSummaries.Count; i++)
            {

                int rowId = dtgv_summary.Rows.Add();

                // Grab the new row!
                DataGridViewRow row = dtgv_summary.Rows[rowId];

                // Add the data
                row.Cells["col1"].Value = qCItemSummaries[i].product;
                row.Cells["col2"].Value = qCItemSummaries[i].Time_from + " to " + qCItemSummaries[i].Time_To;
                row.Cells["col3"].Value = qCItemSummaries[i].QuantityTotal.ToString("N0");
                foreach (var header in listHeader)
                {
                    var data = qCItemSummaries[i].defectItems.Where(s => s.DefectSFT == header).ToList();
                    if(data != null && data.Count ==1)
                    row.Cells[header].Value = data[0].Quantity.ToString("N0");
                }
                // Add the data
                row.Cells["col4"].Value = qCItemSummaries[i].OutputQty.ToString("N0");
                row.Cells["col5"].Value = qCItemSummaries[i].NGQty.ToString("N0");
                row.Cells["col6"].Value = qCItemSummaries[i].DefectRate.ToString("P1");
            }
            dtgv_summary.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_summary.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgv_summary.Refresh();
        }

        private void Btn_ExportExcel_Click(object sender, EventArgs e)
        {
            Class.ToolSupport exportExcel = new Class.ToolSupport();
            exportExcel.ExportToTemplate(path, @"C:\ERP_Temp\Temp2.xlsx", dtgv_summary);
          //  exportExcel.dtgvExport2Excel(dtgv_summary, @"C:\ERP_Temp\Temp2.xls");
        }

        private void Dtgv_summary_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
