using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UploadDataToDatabase.BackLogReport;
using UploadDataToDatabase.Class;

namespace UploadDataToDatabase.Report
{
    public partial class BacklogReport : Form
    {
        public BacklogReport()
        {
            InitializeComponent();
        }

        private void BacklogReport_Load(object sender, EventArgs e)
        {
            string ReportName = "BackLogReport";
            GetDataEmail getDataEmail = new GetDataEmail();
            List<ScheduleReportItems> scheduleReportItems = getDataEmail.GetScheduleReportCommon(ReportName);
            List<EmailNeedSend> emailNeedSends = getDataEmail.GetEmailNeedSends(ReportName);
            string PathFoler = @"C:\ERP_Temp\";
            if (scheduleReportItems != null && scheduleReportItems.Count == 1)
            {
                if (emailNeedSends != null && emailNeedSends.Count > 0)
                {
                    SendMailFunction sendmail = new SendMailFunction();
                    var isOK = sendmail.SendMailwithExportExcelbyCompanyMail(scheduleReportItems[0], emailNeedSends, ref dtgr, PathFoler, "");
                    if (isOK)
                        Log.Logfile.Output(Log.StatusLog.Normal, "Send mail BackLogReport OK");
                    else Log.Logfile.Output(Log.StatusLog.Normal, "Send mail BackLogReport fail ");
                }

            }
            this.Close();
        }
    }
}
