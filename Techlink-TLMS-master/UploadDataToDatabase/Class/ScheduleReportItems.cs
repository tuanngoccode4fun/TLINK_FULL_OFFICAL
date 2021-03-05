using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UploadDataToDatabase.Class
{
    public class ScheduleReportItems
    {

        public string ReportName { get; set; }
        public string ReportType { get; set; }
        public string Minutes { get; set; }
        public string Hours { get; set; }
        public string Day { get; set; }
        public string Date { get; set; }
        public string Month { get; set; }
        public string Subject { get; set; }
        public string AttachedFolder { get; set; }
        public string Contents { get; set; }
        private bool _IsBodyHTML = false;

        public bool IsBodyHTML
        {
            get { return _IsBodyHTML; }
            set { _IsBodyHTML = value; }
        }
        private bool _issendmail = false;

        public bool isSentMail
        {
            get { return _issendmail; }
            set { _issendmail = value; }
        }

    }
    public class EmailNeedSend
        {
        public string EmailReceive { get; set; }
        public string DepartmentCode { get; set; }
        public string Status { get; set; }
        public string Function { get; set; }
    }
    
}
