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

namespace WindowsFormsApplication1.Report.Backlog
{
    public partial class BacklogReportReview : Form
    {
        DataTable dtOrder;
        Dictionary<string, Planning.SemiFinishedGoods> DicOrderStock;
        Dictionary<string, List<Planning.SemiFinishedGoods>> DicListSemiFGs;
        Dictionary<string, DataTable> DicProductionOrder;
        public BacklogReportReview()
        {
            InitializeComponent();
            Class.valiballecommon.GetStorage().DBERP = "TECHLINK";
            Class.valiballecommon.GetStorage().DBSFT = "SFT_TECHLINK";
        }

        private void BacklogReportReview_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Report.Backlog.BacklogReport backlog = new BacklogReport();

           dtOrder = backlog.GetDataProductionOrder2(dtpk_To.Value);
            DicOrderStock = new Dictionary<string, Planning.SemiFinishedGoods>();
            DicListSemiFGs = new Dictionary<string, List<Planning.SemiFinishedGoods>>();
            DicProductionOrder = new Dictionary<string, DataTable>();

            for (int i = 0; i < dtOrder.Rows.Count; i++)
            {
               string CO_Code = dtOrder.Rows[i]["Code_Type"].ToString().Trim();
                string CO_No = dtOrder.Rows[i]["Code_No"].ToString().Trim();
                string CO_STT = dtOrder.Rows[i]["STT"].ToString().Trim();
                string product = dtOrder.Rows[i]["Product_Code"].ToString().Trim();
               string ClientOrder = dtOrder.Rows[i]["Code_Type"].ToString().Trim() + "-" + dtOrder.Rows[i]["Code_No"].ToString().Trim()+ "-"+ dtOrder.Rows[i]["STT"].ToString().Trim();
                Planning.SemiFinishedGoods semiFinishedGoods = new Planning.SemiFinishedGoods();
                Planning.Controler.GetSemiFinishedgoods getSemi = new Planning.Controler.GetSemiFinishedgoods();
                semiFinishedGoods = getSemi.GetStockGoodsONSFT("", product);
                List<Planning.SemiFinishedGoods> semis = getSemi.ListGetSemiFinishedGoods("", product);
                Planning.Controler.GetProductionOrder getProductionOrder = new Planning.Controler.GetProductionOrder();
            
               
          var dtPO =      getProductionOrder.GetProductionOrderStatus(CO_Code, CO_No, CO_STT);

                DicOrderStock.Add(ClientOrder, semiFinishedGoods);
                DicListSemiFGs.Add(ClientOrder, semis);
                DicProductionOrder.Add(ClientOrder, dtPO);
            }

            dataGridView1.DataSource = dtOrder;
        }

        private void dataGridView1_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dataGridView1);
            dataGridView1.AllowUserToAddRows = false;
        }

        private void button2_Click(object sender, EventArgs e)
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
                    ExportExelBacklogOverview exportExelBacklogOverview = new ExportExelBacklogOverview();

                    exportExelBacklogOverview.ExportBacklogOverview(pathsave, dtOrder, DicOrderStock, DicListSemiFGs, DicProductionOrder);

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

            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
}
}
