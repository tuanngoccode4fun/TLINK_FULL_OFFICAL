using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.SettingForm;
using WindowsFormsApplication1.CrisisReport;
using System.IO;


namespace WindowsFormsApplication1
{
    public partial class MainFr : CommonFormMetro
    {
        public MainFr()
        {
            InitializeComponent();
          

        }

        private void btn_registeruser_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.SettingForm.RegisterUsesForm.RegisterUserForm fr = new SettingForm.RegisterUsesForm.RegisterUserForm();
            fr.Show();
        }
        private void MainFr_Load(object sender, EventArgs e)
        {
            sqlCON connect = new sqlCON();
            connect.sqlDatatablePermision("RegisterUser", btn_registeruser);
            connect.sqlDatatablePermision("Password", btn_changepass);
            connect.sqlDatatablePermision("PermissionForm", btn_permission);
            connect.sqlDatatablePermision("LineMaster", btn_line);
            connect.sqlDatatablePermision("ModelMaster", btn_model);
            connect.sqlDatatablePermision("ModelLine", btn_modelline);
            connect.sqlDatatablePermision("Dept", btn_dept);
            connect.sqlDatatablePermision("PQMShow", btn_pqmshow);
            connect.sqlDatatablePermision("ProcessInspect", btn_process);
            connect.sqlDatatablePermision("ERPConfigMail", btn_emailconfig);
            connect.sqlDatatablePermision("ProductionReport", btn_production);
            connect.sqlDatatablePermision("ShippingReport", btn_shipping);
            connect.sqlDatatablePermision("MQCShow", btn_MQC);
            connect.sqlDatatablePermision("PlanningShow", btn_Planning);
            connect.sqlDatatablePermision("CheckMaterial", btn_CheckMaterial);  //
            connect.sqlDatatablePermision("WarehouseAlarm", btn_warehousealarm);
            connect.sqlDatatablePermision("IPPLC", btn_ipplc);
            connect.sqlDatatablePermision("Wms", btn_wms);
            connect.sqlDatatablePermision("settingLanguage", btn_settingLanguage);
            connect.sqlDatatablePermision("MQCReview", btn_MQCReview);
            connect.sqlDatatablePermision("Manpower", btn_Manpower);
            connect.sqlDatatablePermision("ReliabilityReport", btn_Reliability);
            connect.sqlDatatablePermision("BackLogReport", btn_backlogReport);
            connect.sqlDatatablePermision("SeasonalEmp", btn_SeasonalEmp);
            connect.sqlDatatablePermision("FinishedGoods", btn_FinishedGoods);
            connect.sqlDatatablePermision("OVEN", btn_Oven);
            connect.sqlDatatablePermision("TypingInfo", btn_TypingInfor);

        }

        private void btn_changepass_Click(object sender, EventArgs e)
        {
            SettingForm.Change_Password passform = new Change_Password();
            passform.Show();

        }

        private void btn_permission_Click(object sender, EventArgs e)
        {
            PermissionForm fr = new PermissionForm();
            fr.Show();
        }

        private void btn_line_Click(object sender, EventArgs e)
        {
            SettingForm.LineForm.LineForm fr = new SettingForm.LineForm.LineForm();
            fr.Show();
        }

        private void btn_modelmaster_Click(object sender, EventArgs e)
        {
            SettingForm.ModelForm.ModelForm fre = new SettingForm.ModelForm.ModelForm();
            fre.Show();
        }

        private void btn_modelline_Click(object sender, EventArgs e)
        {
            SettingForm.Line_ModelForm.ModelLine modelf = new SettingForm.Line_ModelForm.ModelLine();
            modelf.Show();
        }

        private void btn_dept_Click_1(object sender, EventArgs e)
        {
            SettingForm.DeptForm.DeptForm frnew = new SettingForm.DeptForm.DeptForm();
            frnew.Show();
        }

        private void btn_pqmshow_Click(object sender, EventArgs e)
        {
            PQM.ConnectData.ConnectData frm = new PQM.ConnectData.ConnectData();
            frm.Show();
        }

        private void btn_process_Click(object sender, EventArgs e)
        {
            SettingForm.ProcessForm.ProcessForm frew = new SettingForm.ProcessForm.ProcessForm();
            frew.Show();
        }

        private void btn_ERPshowmain_Click(object sender, EventArgs e)
        {
            ERPShowOrder.ERPShowMain show = new ERPShowOrder.ERPShowMain();
            show.Show();
        }

        private void Btn_emailconfig_Click(object sender, EventArgs e)
        {
            ERPShowOrder.ERPConfigMail show = new ERPShowOrder.ERPConfigMail();
            show.Show();
        }

        private void Btn_OrderReport_Click(object sender, EventArgs e)
        {
            ShippingReport shippingShow = new ShippingReport();
            shippingShow.Show();
        }

        private void Btn_production_Click(object sender, EventArgs e)
        {
            ProductionMonitoring productionShow = new ProductionMonitoring();
            productionShow.Show();
        }

        private void Btn_MQC_Click(object sender, EventArgs e)
        {
            MQC.ProductionMain productionMain = new MQC.ProductionMain();
            productionMain.Show();
        }

        private void Btn_material_Click(object sender, EventArgs e)
        {
            MQC.MaterialManagement materialManagement = new MQC.MaterialManagement();
            materialManagement.Show();
        }

        private void btn_CheckMaterial_Click(object sender, EventArgs e)
        {
            Warehouse.CheckMaterial fr = new Warehouse.CheckMaterial();

            fr.Show();
        }

        private void btn_warehousealarm_Click(object sender, EventArgs e)
        {
            Warehouse.WarehouseAlarm wfr = new Warehouse.WarehouseAlarm();
            wfr.Show();
        }

        private void btn_ipplc_Click(object sender, EventArgs e)
        {
            SettingForm.IPPLC.IPPLC dt = new SettingForm.IPPLC.IPPLC();
            dt.Show();
        }

        private void Btn_Planning_Click(object sender, EventArgs e)
        {
            Planning.View.ProductionPLan planningMain = new Planning.View.ProductionPLan();
            planningMain.Show();
        }

        private void Btn_wms_Click(object sender, EventArgs e)
        {
            string user = Class.valiballecommon.GetStorage().UserName;


            if (Database.ADMMFUpdate.IsHavePermisionUser(user))
            {
                WMS.INOUTManagement iNOUTManagement = new WMS.INOUTManagement();
                iNOUTManagement.Show();
            }
            else
            {
                MessageBox.Show("You don't have permission to use this function ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
           
        }

        private void Btn_settingLanguage_Click(object sender, EventArgs e)
        {
            SettingForm.Language.SettingLanguage settingLanguage = new SettingForm.Language.SettingLanguage();
            settingLanguage.Show();

        }


        private void Btn_MQCReview_Click_1(object sender, EventArgs e)
        {

            MQC.MQCReview mQCReview = new MQC.MQCReview();
            mQCReview.Show();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            HRProject.InOutData.View.HRAttendaceReport rAttendaceReport = new HRProject.InOutData.View.HRAttendaceReport();
            rAttendaceReport.Show();
        }

        private void Reliability_Click_1(object sender, EventArgs e)
        {
            Report.Reliability.ReliabilityReport reliabilityReport = new Report.Reliability.ReliabilityReport();
            reliabilityReport.Show();
        }

        private void Btn_backlogReport_Click(object sender, EventArgs e)
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

        private void btn_SeasonalEmp_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.HRProject.InOutData.View.TimeWorking timeWorking = new HRProject.InOutData.View.TimeWorking();
            timeWorking.Show();
        }

        private void btn_FinishedGoods_Click(object sender, EventArgs e)
        {
            string user = Class.valiballecommon.GetStorage().UserName;


            if (Database.ADMMFUpdate.IsHavePermisionUser(user))
            {
                WMS.View.FinishedGoodsUI finishedGoodsUI = new WMS.View.FinishedGoodsUI();
                finishedGoodsUI.Show();
                
            }
            else
            {
                MessageBox.Show("You don't have permission to use this function ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btn_Oven_Click(object sender, EventArgs e)
        {
            OVEN.OVENShow oVENShow = new OVEN.OVENShow();
            oVENShow.ShowDialog();
        }

        private void btn_TypingInfor_Click(object sender, EventArgs e)
        {
            CustomsDeclarasion.TypingItems typingItems = new CustomsDeclarasion.TypingItems();
            typingItems.ShowDialog();
        }

        private void btn_order_pdc_Click(object sender, EventArgs e)
        {

        }
    }
}
