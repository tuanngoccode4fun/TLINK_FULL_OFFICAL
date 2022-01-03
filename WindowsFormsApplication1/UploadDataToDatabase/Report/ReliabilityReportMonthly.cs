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
    public partial class ReliabilityReportMonthly : Form
    {
        public ReliabilityReportMonthly()
        {
            InitializeComponent();
        }

        private void ReliabilityReportMonthly_Load(object sender, EventArgs e)
        {
            string ReportName = "Reliability_Report";
            GetDataEmail getDataEmail = new GetDataEmail();
            List<ScheduleReportItems> scheduleReportItems = getDataEmail.GetScheduleReportCommon(ReportName,"Monthly");
            List<EmailNeedSend> emailNeedSends = getDataEmail.GetEmailNeedSends(ReportName);

            if (scheduleReportItems != null && scheduleReportItems.Count == 1)
            {
                if (emailNeedSends != null && emailNeedSends.Count > 0)
                {
                    SendMailFunction sendmail = new SendMailFunction();
                    sendmail.SendMailwithExportExceReliabilitybyCompanyMailForMonthly(scheduleReportItems[0], emailNeedSends);
                }

            }
            this.Close();

        }
    }
}
