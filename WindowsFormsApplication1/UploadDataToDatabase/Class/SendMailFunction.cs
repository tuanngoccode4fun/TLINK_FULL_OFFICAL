using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;
using UploadDataToDatabase.MQC;

namespace UploadDataToDatabase.Class
{
    public class SendMailFunction
    {
        public string path = Environment.CurrentDirectory + @"\Resources\EmailTemplate.html";

        public SmtpClient SmtpClient { get; set; }
        public SendMailFunction()
        {
            SmtpClient = new SmtpClient("pro56.emailserver.vn", 25);
            SmtpClient.Credentials = new System.Net.NetworkCredential("tlms@techlink.vn", "techlink@123");
        }

        public bool SendMailtoReportByCompanyMail(ScheduleReportItems items, List<EmailNeedSend> emailNeedSends)
        {
            try
            {
                if (emailNeedSends.Count > 0)
                {
                    MailMessage mail = new MailMessage();
                    if (items.IsBodyHTML)
                        mail.IsBodyHtml = true;
                    else mail.IsBodyHtml = false;

                    mail.From = new MailAddress("tlms@techlink.vn");
                    //  mail.To.Add("tranducan.bkhcm11@gmail.com");
                    foreach (var email in emailNeedSends)
                    {

                        mail.To.Add(email.EmailReceive);

                    }
                    mail.Subject = items.Subject + " On " + DateTime.Now.ToString("MMM-dd-yyyy");

                    if (items.IsBodyHTML)
                    {
                        string pathTemplate = Environment.CurrentDirectory + @"\Resources\EmailTemplate.html";
                        if (File.Exists(pathTemplate))
                        {
                            string html = File.ReadAllText(pathTemplate);
                            string htmlReplaced = "";
                            htmlReplaced = html.Replace("@Replace1", items.Subject);
                            htmlReplaced = htmlReplaced.Replace("@Replace2", DateTime.Now.ToString("MMM-dd-yyyy"));
                            mail.Body = htmlReplaced;
                        }
                    }
                    else
                    {
                        mail.Body = items.Contents;
                    }
                    List<string> listfileattached = new List<string>();
                    if (items.AttachedFolder != "" && items.AttachedFolder != null)
                    {
                        DirectoryInfo d = new DirectoryInfo(items.AttachedFolder);//Assuming Test is your Folder
                        FileInfo[] Files = d.GetFiles(); //Getting excel files

                        foreach (FileInfo file in Files)
                        {
                            System.Net.Mail.Attachment attachment;

                            if (file.Name.Contains(items.ReportName))
                            {
                                attachment = new System.Net.Mail.Attachment(file.FullName);
                                mail.Attachments.Add(attachment);
                                listfileattached.Add(file.FullName);

                            }

                        }
                        if (mail.Attachments.Count > 0)
                        {
                            SmtpClient.Send(mail);
                            mail.Dispose();
                            SmtpClient.Dispose();
                        }
                        else
                        {
                            mail.Dispose();
                            SmtpClient.Dispose();
                            return false;
                        }
                    }
                    try
                    {
                        foreach (var item in listfileattached)
                        {
                            if (File.Exists(item))
                            {
                                File.Delete(item);//Xoa file after send file

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Logfile.Output(StatusLog.Error, "Delete file attached fail :", ex.Message);

                    }
                    Logfile.Output(StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Send mail fail :", ex.Message);
            }

            return false;
        }

        public bool SendMailwithExportExcelbyCompanyMail(ScheduleReportItems items, List<EmailNeedSend> emailNeedSends,
          ref DataGridView dgv_export, string PathFoler, string version)
        {
            try
            {
                UploadDataToDatabase.BackLogReport.BacklogReport backlog = new BackLogReport.BacklogReport();

                if (backlog.ExportExcelToReport(ref dgv_export, PathFoler, version))
                {
                    Logfile.Output(StatusLog.Normal, "Export excel sucessfull");
                }
                else
                {
                    Logfile.Output(StatusLog.Normal, "Export excel fail");
                    return false;
                }

            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "Export excel fail!", ex.Message);
            }
            try
            {
                if (emailNeedSends.Count > 0)
                {
                    MailMessage mail = new MailMessage();
                    if (items.IsBodyHTML)
                        mail.IsBodyHtml = true;
                    else mail.IsBodyHtml = false;

                    mail.From = new MailAddress("tlms@techlink.vn");
                    //   mail.To.Add("ducan.tran@techlink.vn");
                    foreach (var email in emailNeedSends)
                    {
                        mail.To.Add(email.EmailReceive);

                    }
                    mail.Subject = items.Subject + " On " + DateTime.Now.ToString("MMM-dd-yyyy");

                    if (items.IsBodyHTML)
                    {
                        string pathTemplate = Environment.CurrentDirectory + @"\Resources\EmailTemplate.html";
                        if (File.Exists(pathTemplate))
                        {
                            string html = File.ReadAllText(pathTemplate);
                            string htmlReplaced = "";
                            htmlReplaced = html.Replace("@Replace1", items.Subject);
                            htmlReplaced = htmlReplaced.Replace("@Replace2", DateTime.Now.ToString("MMM-dd-yyyy"));
                            mail.Body = htmlReplaced;
                        }
                    }
                    else
                    {
                        mail.Body = items.Contents;
                    }

                    List<string> listfileattached = new List<string>();
                    if (items.AttachedFolder != "" && items.AttachedFolder != null)
                    {
                        DirectoryInfo d = new DirectoryInfo(items.AttachedFolder);//Assuming Test is your Folder
                        FileInfo[] Files = d.GetFiles(); //Getting excel files

                        foreach (FileInfo file in Files)
                        {
                            System.Net.Mail.Attachment attachment;

                            if (file.Name.Contains(items.ReportName))
                            {
                                attachment = new System.Net.Mail.Attachment(file.FullName);
                                mail.Attachments.Add(attachment);
                                listfileattached.Add(file.FullName);

                            }

                        }
                        if (mail.Attachments.Count > 0)
                        {
                            SmtpClient.Send(mail);
                            mail.Dispose();
                            SmtpClient.Dispose();
                        }
                        else
                        {
                            mail.Dispose();
                            SmtpClient.Dispose();
                            return false;
                        }
                    }

                    try
                    {
                        foreach (var item in listfileattached)
                        {
                            if (File.Exists(item))
                            {
                                File.Delete(item);//Xoa file after send file

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Logfile.Output(StatusLog.Error, "Delete file attached fail :", ex.Message);

                    }
                    Logfile.Output(StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Send mail fail :", ex.Message);
            }

            return false;
        }



        public bool SendMailwithExportExceMQCbyCompanyMail(DateTime from, DateTime to, ScheduleReportItems items, List<EmailNeedSend> emailNeedSends)
        {
            try
            {
                MQC.Report.MQCReport mQCReport = new MQC.Report.MQCReport();

                if (mQCReport.ExportReportProductionFromTo(items.AttachedFolder,from, to))
                {
                    Logfile.Output(StatusLog.Normal, "Export MQC report to excel sucessfull");
                }
                else // return false de khoi gui mail
                {
                    Logfile.Output(StatusLog.Normal, "Export MQC report to excel fail");
                    return false;
                }

            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "Export MQC report to excel fail!", ex.Message);
            }
            try
            {
                if (emailNeedSends.Count > 0)
                {
                    MailMessage mail = new MailMessage();
                    if (items.IsBodyHTML)
                        mail.IsBodyHtml = true;
                    else mail.IsBodyHtml = false;

                    mail.From = new MailAddress("tlms@techlink.vn");
                    //  mail.To.Add("ducan.tran@techlink.vn");
                    foreach (var email in emailNeedSends)
                    {
                        mail.To.Add(email.EmailReceive);

                    }
                    mail.Subject = items.Subject + " On " + DateTime.Now.ToString("MMM-dd-yyyy");

                    if (items.IsBodyHTML)
                    {
                        string pathTemplate = Environment.CurrentDirectory + @"\Resources\EmailTemplate.html";
                        if (File.Exists(pathTemplate))
                        {
                            string html = File.ReadAllText(pathTemplate);
                            string htmlReplaced = "";
                            htmlReplaced = html.Replace("@Replace1", items.Subject);
                            htmlReplaced = htmlReplaced.Replace("@Replace2", DateTime.Now.ToString("MMM-dd-yyyy"));
                            mail.Body = htmlReplaced;
                        }
                    }
                    else
                    {
                        mail.Body = items.Contents;
                    }

                    List<string> listfileattached = new List<string>();
                    if (items.AttachedFolder != "" && items.AttachedFolder != null)
                    {
                        DirectoryInfo d = new DirectoryInfo(items.AttachedFolder);//Assuming Test is your Folder
                        FileInfo[] Files = d.GetFiles(); //Getting excel files

                        foreach (FileInfo file in Files)
                        {
                            System.Net.Mail.Attachment attachment;

                            if (file.Name.Contains(items.ReportName))
                            {
                                attachment = new System.Net.Mail.Attachment(file.FullName);
                                mail.Attachments.Add(attachment);
                                listfileattached.Add(file.FullName);

                            }

                        }
                        if (mail.Attachments.Count > 0)
                        {
                            SmtpClient.Send(mail);
                            mail.Dispose();
                            SmtpClient.Dispose();
                        }
                        else
                        {
                            mail.Dispose();
                            SmtpClient.Dispose();
                            return false;
                        }
                    }


                    try
                    {
                        foreach (var item in listfileattached)
                        {
                            if (File.Exists(item))
                            {
                                File.Delete(item);//Xoa file after send file

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Logfile.Output(StatusLog.Error, "Delete file attached fail :", ex.Message);

                    }
                    Logfile.Output(StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Send mail fail :", ex.Message);
            }


            return false;
        }
        public bool SendMailwithExportExceReliabilitybyCompanyMail(ScheduleReportItems items, List<EmailNeedSend> emailNeedSends)
        {
            try
            {
                BackLogReport.RealabilityReport realabilityReport = new BackLogReport.RealabilityReport();

                if (realabilityReport.SendMailReliabilityReportWeekly())
                {
                    Logfile.Output(StatusLog.Normal, "Export Reliability report to excel sucessfull");
                }
                else // return false de khoi gui mail
                {
                    Logfile.Output(StatusLog.Normal, "Export Reliability  report to excel fail");
                    return false;
                }

            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "Export Reliability  report to excel fail!", ex.Message);
            }
            try
            {
                if (emailNeedSends.Count > 0)
                {
                    MailMessage mail = new MailMessage();
                    if (items.IsBodyHTML)
                        mail.IsBodyHtml = true;
                    else mail.IsBodyHtml = false;

                    mail.From = new MailAddress("tlms@techlink.vn");
                    //  mail.To.Add("ducan.tran@techlink.vn");
                    foreach (var email in emailNeedSends)
                    {
                        mail.To.Add(email.EmailReceive);


                    }
                    mail.Subject = items.Subject + " On " + DateTime.Now.ToString("MMM-dd-yyyy");

                    if (items.IsBodyHTML)
                    {
                        string pathTemplate = Environment.CurrentDirectory + @"\Resources\EmailTemplate.html";
                        if (File.Exists(pathTemplate))
                        {
                            string html = File.ReadAllText(pathTemplate);
                            string htmlReplaced = "";
                            htmlReplaced = html.Replace("@Replace1", items.Subject);
                            htmlReplaced = htmlReplaced.Replace("@Replace2", DateTime.Now.ToString("MMM-dd-yyyy"));
                            mail.Body = htmlReplaced;
                        }
                    }
                    else
                    {
                        mail.Body = items.Contents;
                    }

                    List<string> listfileattached = new List<string>();
                    if (items.AttachedFolder != "" && items.AttachedFolder != null)
                    {
                        DirectoryInfo d = new DirectoryInfo(items.AttachedFolder);//Assuming Test is your Folder
                        FileInfo[] Files = d.GetFiles(); //Getting excel files

                        foreach (FileInfo file in Files)
                        {
                            System.Net.Mail.Attachment attachment;

                            if (file.Name.Contains(items.ReportName))
                            {
                                attachment = new System.Net.Mail.Attachment(file.FullName);
                                mail.Attachments.Add(attachment);
                                listfileattached.Add(file.FullName);

                            }

                        }
                        if (mail.Attachments.Count > 0)
                        {
                            SmtpClient.Send(mail);
                            mail.Dispose();
                            SmtpClient.Dispose();
                        }
                        else
                        {
                            mail.Dispose();
                            SmtpClient.Dispose();
                            return false;
                        }
                    }


                    try
                    {
                        foreach (var item in listfileattached)
                        {
                            if (File.Exists(item))
                            {
                                File.Delete(item);//Xoa file after send file

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Logfile.Output(StatusLog.Error, "Delete file attached fail :", ex.Message);
                        return false;
                    }
                    Logfile.Output(StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Send mail fail :", ex.Message);
                return false;
            }


            return false;
        }
        public bool SendMailwithExportExceReliabilityAdding7daysbyCompanyMail(ScheduleReportItems items, List<EmailNeedSend> emailNeedSends)
        {
            try
            {
                BackLogReport.RealabilityReport realabilityReport = new BackLogReport.RealabilityReport();

                if (realabilityReport.SendMailReliabilityReportAdding7Days(items.AttachedFolder))
                {
                    Logfile.Output(StatusLog.Normal, "Export Reliability report to excel sucessfull");
                }
                else // return false de khoi gui mail
                {
                    Logfile.Output(StatusLog.Normal, "Export Reliability  report to excel fail");
                    return false;
                }

            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "Export Reliability  report to excel fail!", ex.Message);
            }
            try
            {
                if (emailNeedSends.Count > 0)
                {
                    MailMessage mail = new MailMessage();
                    if (items.IsBodyHTML)
                        mail.IsBodyHtml = true;
                    else mail.IsBodyHtml = false;

                    mail.From = new MailAddress("tlms@techlink.vn");
                    //   mail.To.Add("ducan.tran@techlink.vn");
                    foreach (var email in emailNeedSends)
                    {
                        mail.To.Add(email.EmailReceive);


                    }
                    mail.Subject = items.Subject + " On " + DateTime.Now.ToString("MMM-dd-yyyy");

                    if (items.IsBodyHTML)
                    {
                        string pathTemplate = Environment.CurrentDirectory + @"\Resources\EmailTemplate.html";
                        if (File.Exists(pathTemplate))
                        {
                            string html = File.ReadAllText(pathTemplate);
                            string htmlReplaced = "";
                            htmlReplaced = html.Replace("@Replace1", items.Subject);
                            htmlReplaced = htmlReplaced.Replace("@Replace2", DateTime.Now.ToString("MMM-dd-yyyy"));
                            mail.Body = htmlReplaced;
                        }
                    }
                    else
                    {
                        mail.Body = items.Contents;
                    }

                    List<string> listfileattached = new List<string>();
                    if (items.AttachedFolder != "" && items.AttachedFolder != null)
                    {
                        DirectoryInfo d = new DirectoryInfo(items.AttachedFolder);//Assuming Test is your Folder
                        FileInfo[] Files = d.GetFiles(); //Getting excel files

                        foreach (FileInfo file in Files)
                        {
                            System.Net.Mail.Attachment attachment;

                            if (file.Name.Contains(items.ReportName))
                            {
                                attachment = new System.Net.Mail.Attachment(file.FullName);
                                mail.Attachments.Add(attachment);
                                listfileattached.Add(file.FullName);

                            }

                        }
                        if (mail.Attachments.Count > 0)
                        {
                            SmtpClient.Send(mail);
                            mail.Dispose();
                            SmtpClient.Dispose();
                        }
                        else
                        {
                            mail.Dispose();
                            SmtpClient.Dispose();
                            return false;
                        }
                    }


                    try
                    {
                        foreach (var item in listfileattached)
                        {
                            if (File.Exists(item))
                            {
                                File.Delete(item);//Xoa file after send file

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Logfile.Output(StatusLog.Error, "Delete file attached fail :", ex.Message);
                        return false;
                    }
                    Logfile.Output(StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Send mail fail :", ex.Message);
                return false;
            }


            return false;
        }
        public bool SendMailwithExportExceReliabilitybyCompanyMailForMonthly(ScheduleReportItems items, List<EmailNeedSend> emailNeedSends)
        {
            try
            {
                BackLogReport.RealabilityReport realabilityReport = new BackLogReport.RealabilityReport();

                if (realabilityReport.SendMailReliabilityReporAdding7DaystMonthly(items.AttachedFolder))
                {
                    Logfile.Output(StatusLog.Normal, "Export Reliability report to excel sucessfull");
                }
                else // return false de khoi gui mail
                {
                    Logfile.Output(StatusLog.Normal, "Export Reliability  report to excel fail");
                    return false;
                }

            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "Export Reliability  report to excel fail!", ex.Message);
            }
            try
            {
                if (emailNeedSends.Count > 0)
                {
                    MailMessage mail = new MailMessage();
                    if (items.IsBodyHTML)
                        mail.IsBodyHtml = true;
                    else mail.IsBodyHtml = false;

                    mail.From = new MailAddress("tlms@techlink.vn");
                    //  mail.To.Add("ducan.tran@techlink.vn");
                    foreach (var email in emailNeedSends)
                    {
                        mail.To.Add(email.EmailReceive);

                    }
                    mail.Subject = items.Subject + " On " + DateTime.Now.ToString("MMM-dd-yyyy");

                    if (items.IsBodyHTML)
                    {
                        string pathTemplate = Environment.CurrentDirectory + @"\Resources\EmailTemplate.html";
                        if (File.Exists(pathTemplate))
                        {
                            string html = File.ReadAllText(pathTemplate);
                            string htmlReplaced = "";
                            htmlReplaced = html.Replace("@Replace1", items.Subject);
                            htmlReplaced = htmlReplaced.Replace("@Replace2", DateTime.Now.ToString("MMM-dd-yyyy"));
                            mail.Body = htmlReplaced;
                        }
                    }
                    else
                    {
                        mail.Body = items.Contents;
                    }

                    List<string> listfileattached = new List<string>();
                    if (items.AttachedFolder != "" && items.AttachedFolder != null)
                    {
                        DirectoryInfo d = new DirectoryInfo(items.AttachedFolder);//Assuming Test is your Folder
                        FileInfo[] Files = d.GetFiles(); //Getting excel files

                        foreach (FileInfo file in Files)
                        {
                            System.Net.Mail.Attachment attachment;

                            if (file.Name.Contains(items.ReportName))
                            {
                                attachment = new System.Net.Mail.Attachment(file.FullName);
                                mail.Attachments.Add(attachment);
                                listfileattached.Add(file.FullName);

                            }

                        }
                        if (mail.Attachments.Count > 0)
                        {
                            SmtpClient.Send(mail);
                            mail.Dispose();
                            SmtpClient.Dispose();
                        }
                        else
                        {
                            mail.Dispose();
                            SmtpClient.Dispose();
                            return false;
                        }
                    }
                    try
                    {
                        foreach (var item in listfileattached)
                        {
                            if (File.Exists(item))
                            {
                                File.Delete(item);//Xoa file after send file

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Logfile.Output(StatusLog.Error, "Delete file attached fail :", ex.Message);

                    }
                    Logfile.Output(StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Send mail fail :", ex.Message);
            }


            return false;
        }


        public bool SendMailReportObnormal()
        {

            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("only4testproject@gmail.com");
                mail.To.Add("tuanngoccode4fun@gmail.com");
                mail.Subject = "Mail for Test";
                mail.Body = "Hello Tuanngoc";
                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                SmtpServer.Credentials = new System.Net.NetworkCredential("only4testproject@gmail.com", "tuanngoc123$");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                mail.Dispose();
                SmtpServer.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Send mail fail :", ex.Message);
            }
            return false;
        }


        public bool SendAttendanceReport(ScheduleReportItems items, List<EmailNeedSend> emailNeedSends, DateTime dateReport)
        {
            try
            {

                AttendancReport.Controller.GetAttendanceHR getAttendance = new AttendancReport.Controller.GetAttendanceHR();
                List<AttendancReport.Model.AttendanceDept> attendanceDepts = getAttendance.GetAttendanceDeptsNew(dateReport);
                AttendancReport.Controller.HRReport hRReport = new AttendancReport.Controller.HRReport();
                string pathsave = items.AttachedFolder+ @"\AttendanceReport" + "_" + dateReport.ToString("ddMMMyyyy") + ".xlsx";


                if (hRReport.ExportAttendanceDaily(attendanceDepts, pathsave, dateReport))
                {
                    Logfile.Output(StatusLog.Normal, "Export Reliability report to excel sucessfull");
                }
                else // return false de khoi gui mail
                {
                    Logfile.Output(StatusLog.Normal, "Export Reliability  report to excel fail");
                    return false;
                }

            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "Export Reliability  report to excel fail!", ex.Message);
            }
            try
            {
                if (emailNeedSends.Count > 0)
                {
                    MailMessage mail = new MailMessage();
                    if (items.IsBodyHTML)
                        mail.IsBodyHtml = true;
                    else mail.IsBodyHtml = false;
                    SmtpClient SmtpServer = new SmtpClient("103.18.179.112", 25);
                    mail.From = new MailAddress("tlms@techlink.vn");
                    //  mail.To.Add("ducan.tran@techlink.vn");
                    foreach (var email in emailNeedSends)
                    {
                        mail.To.Add(email.EmailReceive);


                    }
                    mail.Subject = items.Subject + " On " + DateTime.Now.ToString("MMM-dd-yyyy");

                    if (items.IsBodyHTML)
                    {
                        string pathTemplate = Environment.CurrentDirectory + @"\Resources\EmailTemplate.html";
                        if (File.Exists(pathTemplate))
                        {
                            string html = File.ReadAllText(pathTemplate);
                            string htmlReplaced = "";
                            htmlReplaced = html.Replace("@Replace1", items.Subject);
                            htmlReplaced = htmlReplaced.Replace("@Replace2", DateTime.Now.ToString("MMM-dd-yyyy"));
                            mail.Body = htmlReplaced;
                        }
                    }
                    else
                    {
                        mail.Body = items.Contents;
                    }

                    List<string> listfileattached = new List<string>();
                    if (items.AttachedFolder != "" && items.AttachedFolder != null)
                    {
                        DirectoryInfo d = new DirectoryInfo(items.AttachedFolder);//Assuming Test is your Folder
                        FileInfo[] Files = d.GetFiles(); //Getting excel files

                        foreach (FileInfo file in Files)
                        {
                            System.Net.Mail.Attachment attachment;

                            if (file.Name.Contains(items.ReportName))
                            {
                                attachment = new System.Net.Mail.Attachment(file.FullName);
                                mail.Attachments.Add(attachment);
                                listfileattached.Add(file.FullName);

                            }

                        }
                        if (mail.Attachments.Count > 0)
                        {
                            SmtpServer.Port = 25;
                            SmtpServer.Credentials = new System.Net.NetworkCredential("tlms@techlink.vn", "techlink@123");
                            //  SmtpServer.EnableSsl = true;  // dung email cong ty thi bo dong nay
                            SmtpServer.Send(mail);
                            mail.Dispose();
                            SmtpServer.Dispose();
                        }
                        else
                        {
                            mail.Dispose();
                            SmtpServer.Dispose();
                            return false;
                        }
                    }
                    try
                    {
                        foreach (var item in listfileattached)
                        {
                            if (File.Exists(item))
                            {
                                File.Delete(item);//Xoa file after send file

                            }
                        }

                    }
                    catch (Exception ex)
                    {
                        Logfile.Output(StatusLog.Error, "Delete file attached fail :", ex.Message);

                    }
                    Logfile.Output(StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Send mail fail :", ex.Message);
            }



            return false;

        }

        public bool SendMailtoReportbyTLEmailtest()
        {
            try
            {
                MailMessage mail = new MailMessage();

                mail.IsBodyHtml = true;
                mail.From = new MailAddress("tlms@techlink.vn");
                mail.To.Add("tranducan.bkhcm11@gmail.com");
                mail.To.Add("test.bkhcm11@gmail.com");

                mail.Subject = "Test" + " On " + DateTime.Now.ToString("MMM-dd-yyyy");

                string pathTemplate = Environment.CurrentDirectory + @"\Resources\EmailTemplate.html";
                if (File.Exists(pathTemplate))
                {
                    string html = File.ReadAllText(pathTemplate);
                    mail.Body = html;
                }
                DirectoryInfo d = new DirectoryInfo(@"C:\ERP_Temp\");//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles(); //Getting excel files

                SmtpClient.Send(mail);
                mail.Dispose();
                SmtpClient.Dispose();

                Logfile.Output(StatusLog.Normal, "Send mail suscess :", "Test Mail");

                return true;

            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "Send mail fail :", ex.Message);
            }

            return false;
        }
    }


}
