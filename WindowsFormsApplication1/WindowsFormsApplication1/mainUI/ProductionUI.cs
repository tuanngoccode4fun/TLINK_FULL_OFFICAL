using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsApplication1.mainUI
{
    public partial class ProductionUI : Form
    {
        public ProductionUI()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_MQC_Click(object sender, EventArgs e)
        {
            MQC.ProductionMain productionMain = new MQC.ProductionMain();
            productionMain.WindowState = FormWindowState.Maximized;
            productionMain.Show();
        }

        private void btn_MQCReview_Click(object sender, EventArgs e)
        {
            MQC.MQCReview mQCReview = new MQC.MQCReview();
            mQCReview.WindowState = FormWindowState.Maximized;
            mQCReview.Show();
        }

        private void btn_Oven_Click(object sender, EventArgs e)
        {
            OVEN.OVENShow oVENShow = new OVEN.OVENShow();
          //  oVENShow.WindowState = FormWindowState.Maximized;
            oVENShow.Show();
        }

        private void btn_Reliability_Click(object sender, EventArgs e)
        {
            Report.Reliability.ReliabilityReport reliabilityReport = new Report.Reliability.ReliabilityReport();
            reliabilityReport.WindowState = FormWindowState.Maximized;
            reliabilityReport.Show();
        }

        private void btn_backlogReport_Click(object sender, EventArgs e)
        {

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
                Report.Backlog.BacklogReport backlogReport = new Report.Backlog.BacklogReport();
                backlogReport.ExportExcelToReport(pathsave, Class.valiballecommon.GetStorage()._version);
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

        private void btn_TypingInfor_Click(object sender, EventArgs e)
        {

            CustomsDeclarasion.TypingItems typingItems = new CustomsDeclarasion.TypingItems();
            WindowState = FormWindowState.Maximized;
            typingItems.Show();
        }

        private void btn_FinishedGoods_Click(object sender, EventArgs e)
        {
            string user = Class.valiballecommon.GetStorage().UserName;


            if (Database.ADMMFUpdate.IsHavePermisionUser(user))
            {
                WMS.View.FinishedGoodsUI finishedGoodsUI = new WMS.View.FinishedGoodsUI();
                finishedGoodsUI.WindowState = FormWindowState.Maximized;
                finishedGoodsUI.Show();
            }
            else
            {
                MessageBox.Show("You don't have permission to use this function ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Planning_Click(object sender, EventArgs e)
        {
            Planning.View.ProductionPLan planningMain = new Planning.View.ProductionPLan();
            planningMain.WindowState = FormWindowState.Maximized;
            planningMain.Show();
        }

        private void btn_wms_Click(object sender, EventArgs e)
        {
            string user = Class.valiballecommon.GetStorage().UserName;


            if (Database.ADMMFUpdate.IsHavePermisionUser(user))
            {
                WMS.INOUTManagement iNOUTManagement = new WMS.INOUTManagement();
                iNOUTManagement.WindowState = FormWindowState.Maximized;
                iNOUTManagement.Show();
            }
            else
            {
                MessageBox.Show("You don't have permission to use this function ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Hose_Click(object sender, EventArgs e)
        {
            Planning.PlanningMain planningMain = new Planning.PlanningMain();
            planningMain.WindowState = FormWindowState.Maximized;
            planningMain.Show();
        }


     

        private void btn_customsDeclaration_Click(object sender, EventArgs e)
        {
            CustomsDeclarasion.View.DeliveryOrderExport deliveryOrderExport = new CustomsDeclarasion.View.DeliveryOrderExport();
            deliveryOrderExport.WindowState = FormWindowState.Maximized;
            deliveryOrderExport.Show();
        }
    }
}
