using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public enum LanguageEnum
    {
        TiengViet, English, Chinese
    }
    
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
   
        [STAThread]
      
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginFr());
        //   Application.Run(new Report.Backlog.BacklogReportReview());
            //    Application.Run(new ERPShowOrder.ERPShowMain());
            //   Application.Run(new ERPShowOrder.ERPShowShipping());
            // Application.Run(new ERPShowOrder.ERPMaterialShow());
            //  Application.Run(new ERPShowOrder.ERPShowOrder());
            // Application.Run(new ShippingReport());
              //    Application.Run(new CrisisReport.ProductionMonitoring());

            //  Application.Run(new ERPShowOrder.ERP_KPI_Report());
            //  Application.Run(new MQC.MQCShowForm());
            //    Application.Run(new MQC.ProductionMain());
            //   Application.Run(new MQC.TargetProduction.TargetProdution());
            // Application.Run(new SettingForm.IPPLC.IPPLC());
            // Application.Run(new Planning.SettingDataPlanning());

            // Application.Run(new Planning.PlanningMain());
            //Application.Run(new ToolForm.CalenderDate());
            //      Application.Run(new WMS.GenerateQRCode());
            //   Application.Run(new WMS.INOUTManagement());
            //   Application.Run(new WMS.PrintQRCode());

            //    Application.Run(new SettingForm.Language.SettingLanguage());
            //    Application.Run(new HRProject.InOutData.HRManagementMain());
            //   Application.Run(new MQC.MQCReview());
            //  Application.Run(new HRProject.InOutData.View.HRAttendaceReport());

            //    Application.Run(new Report.Reliability.ReliabilityReport());
            //   Application.Run(new Planning.View.ProductionPLan());
            //   Application.Run(new HRProject.InOutData.View.TimeWorking());
            //   Application.Run(new WMS.View.FinishedGoodsUI());
            //   Application.Run(new OVEN.OVENShow());

            //   Application.Run(new CustomsDeclarasion.TypingItems());
            //   Application.Run(new MainLayout());
            //  Application.Run(new CustomsDeclarasion.View.DeliveryOrderExport());
         //   Application.Run(new WMS.View.ProductionMaterial());


        }
    }
}
