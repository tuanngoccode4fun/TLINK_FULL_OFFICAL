using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using UploadDataToDatabase.Class;
using UploadDataToDatabase;
using UploadDataToDatabase.MQC;
using UploadDataToDatabase.Report;
using UploadDataToDatabase.AttendancReport.Controller;
using UploadDataToDatabase.AttendancReport.Model;

namespace UploadDataToDatabase
{
    public partial class Form1 : CommonForm
    {
        private string path = Environment.CurrentDirectory;
        string version = "";
        // this timer calls bgWorker again and again after regular intervals
        System.Windows.Forms.Timer tmrCallBgWorker;
        // this is our worker
        BackgroundWorker bgWorker;
        System.Windows.Forms.Timer tmrSendMail;
        // this is our worker
        BackgroundWorker bgSendMailWorker;
        object lockObject = new object();
        // this is the timer to make sure that worker gets called
        System.Threading.Timer tmrEnsureWorkerGetsCalled;

        DataTable dtScheduleSendMail;
        DataTable dtListEmail;

        // object used for safe access

        object lockObjectSendMail = new object();
        List<ScheduleReportItems> listReport = new List<ScheduleReportItems>();


        string PathFoler = @"C:\ERP_Temp\";
        public string MQCForm = Environment.CurrentDirectory + @"\Resources\MQC-PQC_Template.xlsx";
        public string Directory_AbnormalCaseImport = Environment.CurrentDirectory + @"\Resources\Abnormal_Import_FS_WareHouse.xlsx";
        bool isExportExcel = false;
        enum ReportType { Daily, Weekly, Monthly, Yearly, Non }


        public Form1()
        {
            InitializeComponent();

            CreateFolderDeleteFilesExcelold();
            version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(); //AssemblyVersion을 가져온다.
            version += "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
            version += "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
            Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + " " + version;
            btn_Start.Text = "Start";

            //timer_update.Start();
            // this timer calls bgWorker again and again after regular intervals
            tmrCallBgWorker = new System.Windows.Forms.Timer();//Timer for do task
            tmrCallBgWorker.Tick += new EventHandler(tmrCallBgWorker_Tick);
            tmrCallBgWorker.Interval = 10000;

            // this is our worker
            bgWorker = new BackgroundWorker();

            // work happens in this method
            bgWorker.DoWork += new DoWorkEventHandler(bg_DoWork);
            bgWorker.ProgressChanged += BgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            bgWorker.WorkerReportsProgress = true;

            tmrSendMail = new System.Windows.Forms.Timer();
            tmrSendMail.Tick += TmrSendMail_Tick;

            bgSendMailWorker = new BackgroundWorker();
            bgSendMailWorker.DoWork += BgSendMailWorker_DoWork;
            bgSendMailWorker.RunWorkerCompleted += BgSendMailWorker_RunWorkerCompleted;
            bgSendMailWorker.WorkerReportsProgress = true;

        }
        private void CreateFolderDeleteFilesExcelold()
        {
            bool exists = System.IO.Directory.Exists(PathFoler);
            if (!exists)
                System.IO.Directory.CreateDirectory(PathFoler);
            try
            {


                DirectoryInfo d = new DirectoryInfo(PathFoler);//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles();
                foreach (FileInfo file in Files)
                {

                    File.Delete(file.FullName);
                }
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "DeleteFilesExcel : Fail ", ex.Message);
            }
        }

        private void LoadSchedule_ListEmail()
        {
            try
            {

                dtScheduleSendMail = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append("select reportname, reporttype, Minutes,hours, day, date, month,isBodyHTML,subject, attach, comments from t_report_schedule where 1=1 ");
                sqlCON tf = new sqlCON();
                tf.sqlDataAdapterFillDatatable(sql.ToString(), ref dtScheduleSendMail);
                dgv_show.DataSource = dtScheduleSendMail;
                dgv_show.Refresh();
                listReport = new List<ScheduleReportItems>();
                listReport = Listreport(dtScheduleSendMail);
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Load from t_report_schedule in SQL fail: ", ex.Message);

            }

        }
        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            btn_Start.Text = "Starting";


        }

        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            LoadSchedule_ListEmail();

        }

        void bg_DoWork(object sender, DoWorkEventArgs e)
        {
            // does a job like writing to serial communication, webservices etc
            var worker = sender as BackgroundWorker;

            //foreach (var item in listReport)
            //{
            //    if(item.ReportName == "BackLogReport" && item.AttachedFolder != "")
            //    {
            //        if (cb_Backlog2Excel.Checked)
            //        {
            //            ExportDataBackLogToExcel(item.ReportName, int.Parse(item.Hours)-1);
            //        }
            //    }
            //}
            // Export to excel two 
            //MQCReport mQCReport = new MQCReport();
            //mQCReport.ExportReportProduction();

            //  System.Diagnostics.Debug.WriteLine("run !");
            System.Threading.Thread.Sleep(100);
        }
        void tmrCallBgWorker_Tick(object sender, EventArgs e)
        {
            if (Monitor.TryEnter(lockObject))
            {
                try
                {
                    // if bgworker is not busy the call the worker
                    if (!bgWorker.IsBusy)
                        bgWorker.RunWorkerAsync();
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }

            }
            else
            {

                // as the bgworker is busy we will start a timer that will try to call the bgworker again after some time
                tmrEnsureWorkerGetsCalled = new System.Threading.Timer(new TimerCallback(tmrEnsureWorkerGetsCalled_Callback), null, 0, 10);

            }

        }
        void tmrEnsureWorkerGetsCalled_Callback(object obj)
        {
            // this timer was started as the bgworker was busy before now it will try to call the bgworker again
            if (Monitor.TryEnter(lockObject))
            {
                try
                {
                    if (!bgWorker.IsBusy)
                        bgWorker.RunWorkerAsync();
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
                tmrEnsureWorkerGetsCalled = null;
            }
        }
        private void BgSendMailWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {


        }
        void tmrEnsureWorkerSendmailGetsCalled_Callback(object obj)
        {
            // this timer was started as the bgworker was busy before now it will try to call the bgworker again
            if (Monitor.TryEnter(lockObjectSendMail))
            {
                try
                {
                    if (!bgSendMailWorker.IsBusy)
                        bgSendMailWorker.RunWorkerAsync();
                }
                finally
                {
                    Monitor.Exit(lockObjectSendMail);
                }
                tmrEnsureWorkerGetsCalled = null;
            }
        }




        private void Btn_Start_Click(object sender, EventArgs e)
        {


            if (btn_Start.Text == "Start")
            {
                int timerInterval = (int)(num_hours.Value * 3600 + num_minutes.Value * 60 + num_seconds.Value) * 1000;

                tmrCallBgWorker.Interval = timerInterval;
                tmrCallBgWorker.Start();
                btn_Start.Text = "Starting";
            }
            else
            {
                tmrCallBgWorker.Stop();
                btn_Start.Text = "Start";
            }


        }


        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfigure saveConfigure = new SaveConfigure();

            saveConfigure.hours = (int)num_hours.Value;
            saveConfigure.minutes = (int)num_minutes.Value;
            saveConfigure.seconds = (int)num_seconds.Value;
            saveConfigure.hours_mail = (int)nmr_hoursSendmail.Value;
            saveConfigure.minutes_mail = (int)nmr_minutesSendMail.Value;
            saveConfigure.seconds_mail = (int)nmr_secondSendmail.Value;


            try
            {
                SaveObject.Save_data(path + @"\Configure.ini", saveConfigure);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Save configure fail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SaveConfigure saveConfigure = new SaveConfigure();
            if (File.Exists(path + @"\Configure.ini"))
            {
                saveConfigure = (SaveConfigure)SaveObject.Load_data(path + @"\Configure.ini");

                if (saveConfigure != null)
                {
                    //dtp_from.Value = saveConfigure.fromdate;
                    //dtp_todate.Value = saveConfigure.tomdate;
                    num_hours.Value = saveConfigure.hours;
                    num_minutes.Value = saveConfigure.minutes;
                    num_seconds.Value = saveConfigure.seconds;
                    nmr_hoursSendmail.Value = saveConfigure.hours_mail;
                    nmr_minutesSendMail.Value = saveConfigure.minutes_mail;
                    nmr_secondSendmail.Value = saveConfigure.seconds_mail;

                }
                else
                {

                    num_hours.Value = 0;
                    num_minutes.Value = 0;
                    num_seconds.Value = 10;
                    nmr_hoursSendmail.Value = 0;
                    nmr_minutesSendMail.Value = 0;
                    nmr_secondSendmail.Value = 0;
                }
            }
            else
            {

                num_hours.Value = 0;
                num_minutes.Value = 0;
                num_seconds.Value = 10;
                nmr_hoursSendmail.Value = 0;
                nmr_minutesSendMail.Value = 0;
                nmr_secondSendmail.Value = 10;

            }
            dgv_show.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgv_show.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_show.AutoGenerateColumns = true;
            dgv_show.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv_show.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgv_show.AllowUserToAddRows = false;
            LoadSchedule_ListEmail();


        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            FormConfig.ReportSchechuleForm reportSchechule = new FormConfig.ReportSchechuleForm();
            reportSchechule.FormClosed += ReportSchechule_FormClosed;
            reportSchechule.ShowDialog();
        }

        private void ReportSchechule_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                dtScheduleSendMail = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append("select reportname, reporttype,Minutes ,hours, day, date, month,isBodyHTML,subject, attach, comments from t_report_schedule where 1=1 ");
                sqlCON tf = new sqlCON();
                tf.sqlDataAdapterFillDatatable(sql.ToString(), ref dtScheduleSendMail);
                dgv_show.DataSource = dtScheduleSendMail;
                dgv_show.Refresh();
                listReport = new List<ScheduleReportItems>();
                listReport = Listreport(dtScheduleSendMail);
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "Load data from SQL fail: ", ex.Message);
            }

        }

        private void Btn_Remove_Click(object sender, EventArgs e)
        {
            if (dgv_show.RowCount > 0)
            {
                int rownumber = dgv_show.SelectedCells[0].RowIndex;
                string reportname = dgv_show.Rows[rownumber].Cells[0].Value.ToString();
                string reportType = dgv_show.Rows[rownumber].Cells[1].Value.ToString();
                string minutes = dgv_show.Rows[rownumber].Cells[2].Value.ToString();
                string hours = dgv_show.Rows[rownumber].Cells[3].Value.ToString();
                string day = dgv_show.Rows[rownumber].Cells[4].Value.ToString();
                string date = dgv_show.Rows[rownumber].Cells[5].Value.ToString();
                string month = dgv_show.Rows[rownumber].Cells[6].Value.ToString();
                StringBuilder sql = new StringBuilder();
                sql.Append("delete from t_report_schedule where ");
                sql.Append("reportname = '" + reportname + "' and ");
                sql.Append("reporttype = '" + reportType + "' and ");
                sql.Append("Minutes = '" + minutes + "' and ");
                sql.Append("hours = '" + hours + "' and ");
                sql.Append("day = '" + day + "' and ");
                sql.Append("date = '" + date + "' and ");
                sql.Append("month = '" + month + "'");

                sqlCON connect = new sqlCON();
                connect.sqlExecuteNonQuery(sql.ToString(), true);
                dtScheduleSendMail = new DataTable();
                StringBuilder sql2 = new StringBuilder();
                sql2.Append("select reportname, reporttype,Minutes  ,hours, day, date, month,isBodyHTML, subject,attach, comments from t_report_schedule where 1=1 ");
                sqlCON tf = new sqlCON();
                tf.sqlDataAdapterFillDatatable(sql2.ToString(), ref dtScheduleSendMail);
                dgv_show.DataSource = dtScheduleSendMail;
                dgv_show.Refresh();

            }
        }

        private void Dgv_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_show.RowCount > 0) { btn_Remove.Enabled = true; }
        }

        private void Btn_startSendmail_Click(object sender, EventArgs e)
        {

            if (btn_startSendmail.Text == "Start")
            {
                int timerInterval = (int)(nmr_hoursSendmail.Value * 3600 + nmr_minutesSendMail.Value * 60 + nmr_secondSendmail.Value) * 1000;

                tmrSendMail.Interval = timerInterval;
                tmrSendMail.Start();
                btn_startSendmail.Text = "Starting";
            }
            else
            {
                tmrSendMail.Stop();
                btn_startSendmail.Text = "Start";
            }
        }
        private List<ScheduleReportItems> Listreport(DataTable dt)
        {
            List<ScheduleReportItems> list = new List<ScheduleReportItems>();
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
            return list;
        }
        private List<EmailNeedSend> ListEmailNeedSend(DataTable dt)
        {
            List<EmailNeedSend> list = new List<EmailNeedSend>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                EmailNeedSend item = new EmailNeedSend();
                item.EmailReceive = dt.Rows[i]["emailaddress"].ToString();
                item.DepartmentCode = dt.Rows[i]["deptcode"].ToString();
                item.Status = dt.Rows[i]["status"].ToString();
                item.Function = dt.Rows[i]["usingfunction"].ToString();

                list.Add(item);
            }
            return list;
        }
        private bool SendEmailStatus(List<ScheduleReportItems> listReport)
        {
            foreach (var item in listReport)
            {
                if (item.ReportType == "Daily")
                {

                    if (DateTime.Now.Hour == int.Parse(item.Hours) && DateTime.Now.Minute == int.Parse(item.Minutes))
                    {
                        List<EmailNeedSend> emailNeeds = new List<EmailNeedSend>();
                        emailNeeds = EmailNeedSends(item.ReportName);
                        if (CheckIsSentMailComplete(item) == false)
                        {
                            if (emailNeeds != null && emailNeeds.Count > 0)
                            {
                                if (item.ReportName == "BackLogReport")
                                {
                                    SendMailFunction sendmail = new SendMailFunction();
                                    var isOK = sendmail.SendMailwithExportExcelbyCompanyMail(item, emailNeeds, ref dgv_export, item.AttachedFolder, version);

                                    if (isOK)
                                    {
                                        InsertSendMailtoRecord(item, item.AttachedFolder);
                                        isExportExcel = false;
                                    }
                                    else Logfile.Output(StatusLog.Normal, "Send mail Back-log Report fail ");
                                }
                                else if (item.ReportName == "MQC_Daily")
                                {
                                    SendMailFunction sendmail = new SendMailFunction();

                                    DateTime DateFrom = DateTime.Now.Date.AddDays(-1) + new TimeSpan(11, 0, 0);
                                    DateTime DateTo = DateTime.Now.Date + new TimeSpan(11, 0, 0);

                                    var isOK = sendmail.SendMailwithExportExceMQCbyCompanyMail(DateFrom, DateTo, item, emailNeeds);

                                    if (isOK)
                                    {
                                        InsertSendMailtoRecord(item, item.AttachedFolder);
                                        isExportExcel = false;

                                    }
                                    else Logfile.Output(StatusLog.Normal, "Send mail MQC_Daily fail ");
                                }
                                else if (item.ReportName == "AttendanceReport")
                                {
                                    SendMailFunction sendmail = new SendMailFunction();
                                    DateTime DateReport = DateTime.Now;
                                    if (DateTime.Now.Date.DayOfWeek == DayOfWeek.Monday)
                                        DateReport = DateTime.Now.Date.AddDays(-3);
                                    else if (DateTime.Now.Date.DayOfWeek == DayOfWeek.Tuesday || DateTime.Now.Date.DayOfWeek == DayOfWeek.Wednesday ||
                                        DateTime.Now.Date.DayOfWeek == DayOfWeek.Thursday || DateTime.Now.Date.DayOfWeek == DayOfWeek.Friday)
                                        DateReport = DateTime.Now.Date.AddDays(-1);

                                    if (DateTime.Now.DayOfWeek != DayOfWeek.Sunday && DateTime.Now.DayOfWeek != DayOfWeek.Saturday)
                                    {
                                        var isOK = sendmail.SendAttendanceReport(item, emailNeeds, DateReport);

                                        if (isOK)
                                        {
                                            InsertSendMailtoRecord(item, item.AttachedFolder);
                                            isExportExcel = false;

                                        }
                                        else Logfile.Output(StatusLog.Normal, "Send mail MQC_Daily fail ");
                                    }
                                }
                                //else if (item.ReportName == "Abnormal_ImportFsWareHouse")
                                //{
                                //    SendMailFunction sendmail = new SendMailFunction();
                                //    var isOK = sendmail.SendMailReportObnormal();
                                //}

                            }
                        }
                    }

                }
                else if (item.ReportType == "Weekly")
                {

                    if (DateTime.Now.DayOfWeek.ToString() == item.Day && DateTime.Now.Hour == int.Parse(item.Hours) && DateTime.Now.Minute == int.Parse(item.Minutes))
                    {
                        if (CheckIsSentMailComplete(item) == false)
                        {
                            if (item.ReportName == "Reliability_Report")
                            {
                                GetDataEmail getDataEmail = new GetDataEmail();
                                List<ScheduleReportItems> scheduleReportItems = getDataEmail.GetScheduleReportCommon(item.ReportName, item.ReportType);
                                List<EmailNeedSend> emailNeedSends = getDataEmail.GetEmailNeedSends(item.ReportName);

                                if (scheduleReportItems != null && scheduleReportItems.Count == 1)
                                {
                                    if (emailNeedSends != null && emailNeedSends.Count > 0)
                                    {
                                        SendMailFunction sendmail = new SendMailFunction();
                                        if (sendmail.SendMailwithExportExceReliabilityAdding7daysbyCompanyMail(scheduleReportItems[0], emailNeedSends))
                                        {
                                            InsertSendMailtoRecord(item, item.AttachedFolder);
                                        }
                                        else Logfile.Output(StatusLog.Normal, "Send mail Reliability report fail ");
                                    }

                                }
                            }
                        }
                    }

                }
                else if (item.ReportType == "Monthly")
                {
                    var lastDayOfMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);//avoid end of month

                    if (DateTime.Now.Day == lastDayOfMonth && DateTime.Now.Hour == int.Parse(item.Hours) && DateTime.Now.Minute == int.Parse(item.Minutes))
                    {
                        if (CheckIsSentMailComplete(item) == false)
                        {
                            if (item.ReportName == "Reliability_Report")
                            {
                                GetDataEmail getDataEmail = new GetDataEmail();
                                List<ScheduleReportItems> scheduleReportItems = getDataEmail.GetScheduleReportCommon(item.ReportName, item.ReportType);
                                List<EmailNeedSend> emailNeedSends = getDataEmail.GetEmailNeedSends(item.ReportName);

                                if (scheduleReportItems != null && scheduleReportItems.Count == 1)
                                {
                                    if (emailNeedSends != null && emailNeedSends.Count > 0)
                                    {
                                        SendMailFunction sendmail = new SendMailFunction();
                                        if (sendmail.SendMailwithExportExceReliabilitybyCompanyMailForMonthly(scheduleReportItems[0], emailNeedSends))
                                        {
                                            InsertSendMailtoRecord(item, item.AttachedFolder);
                                        }
                                        else Logfile.Output(StatusLog.Normal, "Send mail Reliability report fail ");
                                    }

                                }
                            }
                        }
                    }
                }
                else if (item.ReportType == "Yearly")
                {
                    if (DateTime.Now.ToString("MMMM") == item.Month && DateTime.Now.Date.ToString() == item.Date && DateTime.Now.Hour == int.Parse(item.Hours) && DateTime.Now.Minute == int.Parse(item.Minutes))
                    {
                        List<EmailNeedSend> emailNeeds = new List<EmailNeedSend>();
                        emailNeeds = EmailNeedSends(item.ReportName);
                        if (CheckIsSentMailComplete(item) == false)
                        {

                            if (emailNeeds != null && emailNeeds.Count > 0)
                            {
                                SendMailFunction sendmail = new SendMailFunction();
                                if (sendmail.SendMailtoReportByCompanyMail(item, emailNeeds))
                                {
                                    InsertSendMailtoRecord(item, item.AttachedFolder);
                                }
                            }
                        }
                    }

                }

            }
            return false;
        }
        private void BgSendMailWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            if (listReport != null && listReport.Count > 0)
            {
                SendEmailStatus(listReport);
            }
        }

        private void TmrSendMail_Tick(object sender, EventArgs e)
        {
            if (Monitor.TryEnter(lockObjectSendMail))
            {
                try
                {
                    // if bgworker is not busy the call the worker
                    if (!bgSendMailWorker.IsBusy)
                        bgSendMailWorker.RunWorkerAsync();
                }
                finally
                {
                    Monitor.Exit(lockObjectSendMail);
                }
            }
            else
            {

                // as the bgworker is busy we will start a timer that will try to call the bgworker again after some time
                tmrEnsureWorkerGetsCalled = new System.Threading.Timer(new TimerCallback(tmrEnsureWorkerSendmailGetsCalled_Callback), null, 0, 10);

            }
        }
        private bool CheckIsSentMailComplete(ScheduleReportItems scheduleReport)
        {
            if (scheduleReport.ReportType == "Daily")
            {
                DataTable dtRecord = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append("select reportname,reporttype,Minutes,hours,day,date,month,subject,attach,inputdate from t_email_record where ");
                sql.Append("reportname = '" + scheduleReport.ReportName + "' and ");
                sql.Append("reporttype = '" + scheduleReport.ReportType + "' and ");
                sql.Append("Minutes = '" + scheduleReport.Minutes + "' and ");
                sql.Append("hours = '" + scheduleReport.Hours + "' and ");
                sql.Append("inputdate > '" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "'");
                sqlCON tf = new sqlCON();
                tf.sqlDataAdapterFillDatatable(sql.ToString(), ref dtRecord);
                if (dtRecord.Rows.Count > 0)
                    return true;
                else return false;
            }
            else if (scheduleReport.ReportType == "Weekly")
            {
                DataTable dtRecord = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append("select reportname,reporttype,hours,day,date,month,subject,attach,inputdate from t_email_record where ");
                sql.Append("reportname = '" + scheduleReport.ReportName + "' and ");
                sql.Append("reporttype = '" + scheduleReport.ReportType + "' and ");
                sql.Append("day = '" + scheduleReport.Day + "' and ");
                sql.Append("hours = '" + scheduleReport.Hours + "' and ");
                sql.Append("Minutes = '" + scheduleReport.Minutes + "' and ");
                sql.Append("inputdate > '" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "'");
                sqlCON tf = new sqlCON();
                tf.sqlDataAdapterFillDatatable(sql.ToString(), ref dtRecord);
                if (dtRecord.Rows.Count > 0)
                    return true;
                else return false;
            }
            else if (scheduleReport.ReportType == "Monthly")
            {
                var lastDayOfMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);//avoid end of month
                DataTable dtRecord = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append("select reportname,reporttype,hours,day,date,month,subject,attach,inputdate from t_email_record where ");
                sql.Append("reportname = '" + scheduleReport.ReportName + "' and ");
                sql.Append("reporttype = '" + scheduleReport.ReportType + "' and ");

                sql.Append("date = '" + lastDayOfMonth.ToString() + "' and ");
                sql.Append("hours = '" + scheduleReport.Hours + "' and ");
                sql.Append("Minutes = '" + scheduleReport.Minutes + "'");
                sql.Append(" and inputdate > '" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "'");
                sqlCON tf = new sqlCON();
                tf.sqlDataAdapterFillDatatable(sql.ToString(), ref dtRecord);
                if (dtRecord.Rows.Count > 0)
                    return true;
                else return false;
            }
            else if (scheduleReport.ReportType == "Yearly")
            {
                DataTable dtRecord = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append("select reportname,reporttype,hours,day,date,month,subject,attach,inputdate from t_email_record where ");
                sql.Append("reportname = '" + scheduleReport.ReportName + "' and ");
                sql.Append("reporttype = '" + scheduleReport.ReportType + "' and ");
                sql.Append("month = '" + scheduleReport.Month + "' and ");
                sql.Append("date = '" + scheduleReport.Date + "' and ");
                sql.Append("hours = '" + scheduleReport.Hours + "' and ");
                sql.Append("Minutes = '" + scheduleReport.Minutes + "' and ");
                sql.Append("inputdate > '" + DateTime.Now.Date.ToString("yyyy-MM-dd") + "'");
                sqlCON tf = new sqlCON();
                tf.sqlDataAdapterFillDatatable(sql.ToString(), ref dtRecord);
                if (dtRecord.Rows.Count > 0)
                    return true;
                else return false;
            }
            return false;
        }
        private bool InsertSendMailtoRecord(ScheduleReportItems schedule, string attachFile)
        {
            StringBuilder sqlinsert = new StringBuilder();
            sqlinsert.Append("insert into t_email_record ");
            sqlinsert.Append(@"(reportname,reporttype,Minutes,hours,day,date,month,subject,attach,inputdate) values ('");
            sqlinsert.Append(schedule.ReportName + "' , '" + schedule.ReportType + "' , '" + schedule.Minutes + "' , '" + schedule.Hours + "', '" + schedule.Day + "' , '" + schedule.Date + "', '");
            sqlinsert.Append(schedule.Month + "' , '" + schedule.Subject + "' , '" + attachFile + "' , GETDATE() )");
            sqlCON insert = new sqlCON();
            return insert.sqlExecuteNonQuery(sqlinsert.ToString(), false);

        }
        private List<EmailNeedSend> EmailNeedSends(string reportName)
        {
            List<EmailNeedSend> listEmailsend = new List<EmailNeedSend>();
            try
            {
                dtListEmail = new DataTable();
                StringBuilder sqllistmail = new StringBuilder();
                sqllistmail.Append("select emailaddress, deptcode, status, usingfunction from m_email where status = 'YES' and usingfunction = '" + reportName + "'");
                sqlCON tf = new sqlCON();
                tf.sqlDataAdapterFillDatatable(sqllistmail.ToString(), ref dtListEmail);
                listEmailsend = ListEmailNeedSend(dtListEmail);

            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "Load list email send fail ", ex.Message);
            }

            return listEmailsend;
        }

        private void Button1_Click_1(object sender, EventArgs e)
        {
            UploadDataToDatabase.BackLogReport.BacklogReport backlog = new BackLogReport.BacklogReport();
            string FileName = "BackLog Report";
            if (backlog.ExportExcelToReport(ref dgv_export, PathFoler, version))
            {

                Logfile.Output(StatusLog.Normal, "Export Excel File Complete ! ");

            }
            else
            {
                Logfile.Output(StatusLog.Normal, "Export Excel File fail ! ");
            }
        }


        private void Button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();
            string pathsave = "";
            saveFileDialog.Title = "Browse Excel Files";
            saveFileDialog.DefaultExt = "Excel";
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

            saveFileDialog.CheckPathExists = true;

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GetAttendanceHR getAttendance = new GetAttendanceHR();
                List<AttendanceDept> attendanceDepts = getAttendance.GetAttendanceDeptsNew(DateTime.Now.AddDays(-1));
                HRReport hRReport = new HRReport();
                pathsave = saveFileDialog.FileName;

                saveFileDialog.RestoreDirectory = true;

                hRReport.ExportAttendanceDaily(attendanceDepts, pathsave, DateTime.Now.AddDays(-1));
                var resultMessage = MessageBox.Show("Attendance Daily Report export to excel sucessful ! \n\r Do you want to open this file ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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

        private void btn_testGmail_Click(object sender, EventArgs e)
        {
            var emailNeeds = EmailNeedSends("BackLogReport");
            var item = listReport.Find(d => d.ReportName == "BackLogReport");

            if (item.ReportName == "BackLogReport")
            {
                SendMailFunction sendmail = new SendMailFunction();
                var isOK = sendmail.SendMailwithExportExcelbyCompanyMail(item, emailNeeds, ref dgv_export, item.AttachedFolder, version);

                if (isOK)
                {
                    InsertSendMailtoRecord(item, item.AttachedFolder);
                    isExportExcel = false;
                }
                else Logfile.Output(StatusLog.Normal, "Send mail Back-log Report fail ");
            }
        }

        private void btn_test_emailTL_Click(object sender, EventArgs e)
        {
            SendMailFunction sendMailFunction = new SendMailFunction();
            sendMailFunction.SendMailtoReportbyTLEmailtest();
        }
    }

}
