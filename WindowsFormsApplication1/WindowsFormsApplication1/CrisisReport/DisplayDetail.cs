using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Class;

namespace WindowsFormsApplication1.CrisisReport
{
    public partial class DisplayDetail : CommonForm
    {
        DataTable DataTable = new DataTable();
        public DisplayDetail(DataTable dt)
        {
            InitializeComponent();
            DataTable = dt;
            dtgv_show.DataSource = dt;
            dtgv_show.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_show.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgv_show.AutoGenerateColumns = true;
            dtgv_show.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dtgv_show.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dtgv_show.AllowUserToAddRows = false;
            dtgv_show.Columns[0].HeaderText = "Date";
            dtgv_show.Columns[1].HeaderText = "Order Code";
            dtgv_show.Columns[2].HeaderText = "Clients";
            dtgv_show.Columns[3].HeaderText = "Clients Order";
            dtgv_show.Columns[4].HeaderText = "Product";
            dtgv_show.Columns[5].HeaderText = "Order Qty";
            dtgv_show.Columns[5].DefaultCellStyle.Format = "N0";
            dtgv_show.Columns[6].HeaderText = "Finished Goods Qty";
            dtgv_show.Columns[6].DefaultCellStyle.Format = "N0";
            dtgv_show.Columns[7].HeaderText = "Clients Request Date";
            dtgv_show.Columns[8].HeaderText = "Delivery Date";
            dtgv_show.Columns[9].HeaderText = "Shipped Qty";
            dtgv_show.Columns[9].DefaultCellStyle.Format = "N0";
            dtgv_show.Columns[10].HeaderText = "Remain Qty";
            dtgv_show.Columns[10].DefaultCellStyle.Format = "N0";
            dtgv_show.Columns[11].HeaderText = "Shipping Percernt";
            dtgv_show.Columns[11].DefaultCellStyle.Format = "0%";
            dtgv_show.Columns[12].HeaderText = "Status";
        }


        private void DisplayDetail_Load(object sender, EventArgs e)
        {
            
        }

        private void Btn_toExcel_Click(object sender, EventArgs e)
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
                    pathsave = saveFileDialog.FileName.Split('.')[0];

                    saveFileDialog.RestoreDirectory = true;
                    ToolSupport tool = new ToolSupport();
                    tool.dtgvExport2Excel(dtgv_show, pathsave + "-" + DateTime.Now.ToString("yyyyMMdd HHmmss") + ".xls");
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
