using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UploadDataToDatabase.Class;
using UploadDataToDatabase;

namespace UploadDataToDatabase.Report
{
 public   class GetDataEmail
    {

        public List<ScheduleReportItems> GetScheduleReportCommon(string ReportName,string ReportType)
        {

            List<ScheduleReportItems> list = new List<ScheduleReportItems>();
            DataTable dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append("select reportname, reporttype, Minutes,hours, day, date, month,isBodyHTML,subject, attach, comments from t_report_schedule where 1=1 ");
              sql.Append(" and reportname = '" + ReportName  + "' " );
            sql.Append(" and reporttype = '" + ReportType + "' ");
            sqlCON tf = new sqlCON();
            tf.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ScheduleReportItems item = new ScheduleReportItems();
                item.ReportName = dt.Rows[i]["reportname"].ToString();
                item.ReportType = dt.Rows[i]["reporttype"].ToString();
                item.Minutes = dt.Rows[i]["Minutes"].ToString();
                item.Hours = dt.Rows[i]["hours"].ToString();
                item.Day = dt.Rows[i]["day"].ToString();
                item.Date = dt.Rows[i]["date"].ToString();
                item.Month = dt.Rows[i]["month"].ToString();
                item.IsBodyHTML = bool.Parse(dt.Rows[i]["isBodyHTML"].ToString());
                item.Subject = dt.Rows[i]["subject"].ToString();
                item.AttachedFolder = dt.Rows[i]["attach"].ToString();
                item.Contents = dt.Rows[i]["comments"].ToString();
                list.Add(item);
            }
            dt = null;
            return list;

        }
        public List<EmailNeedSend> GetEmailNeedSends(string reportName)
        {
            List<EmailNeedSend> listEmailsend = new List<EmailNeedSend>();
            try
            {

                DataTable dt = new DataTable();
                StringBuilder sqllistmail = new StringBuilder();
                sqllistmail.Append("select emailaddress, deptcode, status, usingfunction from m_email where status = 'YES' and usingfunction = '" + reportName + "'");
                sqlCON tf = new sqlCON();
                tf.sqlDataAdapterFillDatatable(sqllistmail.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    EmailNeedSend item = new EmailNeedSend();
                    item.EmailReceive = dt.Rows[i]["emailaddress"].ToString();
                    item.DepartmentCode = dt.Rows[i]["deptcode"].ToString();
                    item.Status = dt.Rows[i]["status"].ToString();
                    item.Function = dt.Rows[i]["usingfunction"].ToString();

                    listEmailsend.Add(item);
                }
                dt = null;
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Load list email send fail ", ex.Message);
            }

            return listEmailsend;
        }
    }
}
