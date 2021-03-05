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
        public bool SendMailtoReport (ScheduleReportItems items, List<EmailNeedSend> emailNeedSends)
        {
            try
            {
                if (emailNeedSends.Count > 0)
                {
                    MailMessage mail = new MailMessage();
                    if (items.IsBodyHTML)
                        mail.IsBodyHtml = true;
                    else mail.IsBodyHtml = false;
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("techlinkvn.2019@gmail.com");
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
                    }
                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("techlinkvn.2019", "techlink123");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    mail.Dispose();
                    SmtpServer.Dispose();
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
                        Log.Logfile.Output(Log.StatusLog.Error, "Delete file attached fail :", ex.Message);

                    }
                    Log.Logfile.Output(Log.StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Log.Logfile.Output(Log.StatusLog.Error, "Send mail fail :", ex.Message);
            }

            return false;
        }
        public bool SendMailtoReporttest()
        {
            try
            {
                    MailMessage mail = new MailMessage();
 
                        mail.IsBodyHtml = true;

                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("techlinkvn.2019@gmail.com");
                     mail.To.Add("tranducan.bkhcm11@gmail.com");

                    mail.Subject = "Test" + " On " + DateTime.Now.ToString("MMM-dd-yyyy");

                        string pathTemplate = Environment.CurrentDirectory + @"\Resources\EmailTemplate.html";
                        if (File.Exists(pathTemplate))
                        {
                            string html = File.ReadAllText(pathTemplate);
                            mail.Body = html;
                        }
                    DirectoryInfo d = new DirectoryInfo(@"C:\ERP_Temp\");//Assuming Test is your Folder
                    FileInfo[] Files = d.GetFiles(); //Getting excel files

                    List<string> listfileattached = new List<string>();
                System.Net.Mail.Attachment attachment;
                foreach (FileInfo file in Files)
                    {

                            attachment = new System.Net.Mail.Attachment(file.FullName);
                            mail.Attachments.Add(attachment);
                            listfileattached.Add(file.FullName);                  
                }

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("techlinkvn.2019", "techlink123");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    mail.Dispose();
                   SmtpServer.Dispose();
               
                
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
                        Log.Logfile.Output(Log.StatusLog.Error, "Delete file attached fail :", ex.Message);

                    }
                    Log.Logfile.Output(Log.StatusLog.Normal, "Send mail suscess :", "Test Mail");

                    return true;

            }
            catch (Exception ex)
            {
                Log.Logfile.Output(Log.StatusLog.Error, "Send mail fail :", ex.Message);
            }

            return false;
        }
        //This function only make for Send backlog report
        public bool SendMailwithExportExcel(ScheduleReportItems items, List<EmailNeedSend> emailNeedSends, 
            ref DataGridView dgv_export, string PathFoler,string version)
        {
            try
            {
                UploadDataToDatabase.BackLogReport.BacklogReport backlog = new BackLogReport.BacklogReport();

                if (backlog.ExportExcelToReport(ref dgv_export, PathFoler, version))
                {
                    Log.Logfile.Output(Log.StatusLog.Normal, "Export excel sucessfull");
                }
                else
                {
                    Log.Logfile.Output(Log.StatusLog.Normal, "Export excel Fail ");
                    return false;
                }
             
            }
            catch (Exception ex)
            {

                Log.Logfile.Output(Log.StatusLog.Error, "Export excel fail!", ex.Message);
            }
            try
            {
                if (emailNeedSends.Count > 0)
                {
                    MailMessage mail = new MailMessage();
                    if (items.IsBodyHTML)
                        mail.IsBodyHtml = true;
                    else mail.IsBodyHtml = false;
                    SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                    mail.From = new MailAddress("techlinkvn.2019@gmail.com");
                    mail.To.Add("tranducan.bkhcm11@gmail.com");
                    //foreach (var email in emailNeedSends)
                    //{
                    //  //  mail.To.Add(email.EmailReceive);
                    // // mail.To.Add("tranducan.bkhcm11@gmail.com");

                    //}
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
                            else return false;
                        }
                    }

                    SmtpServer.Port = 587;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("techlinkvn.2019", "techlink123");
                    SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    mail.Dispose();
                    SmtpServer.Dispose();
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
                        Log.Logfile.Output(Log.StatusLog.Error, "Delete file attached fail :", ex.Message);

                    }
                    Log.Logfile.Output(Log.StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Log.Logfile.Output(Log.StatusLog.Error, "Send mail fail :", ex.Message);
            }


            return true;
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
                    SmtpClient SmtpServer = new SmtpClient("103.18.179.112", 25);
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
                            else return false;

                        }
                    }
                    SmtpServer.Port = 25;
                    SmtpServer.Credentials = new System.Net.NetworkCredential("tlms@techlink.vn", "techlink@123");
                 //   SmtpServer.EnableSsl = true;
                    SmtpServer.Send(mail);
                    mail.Dispose();
                    SmtpServer.Dispose();
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
                        Log.Logfile.Output(Log.StatusLog.Error, "Delete file attached fail :", ex.Message);

                    }
                    Log.Logfile.Output(Log.StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Log.Logfile.Output(Log.StatusLog.Error, "Send mail fail :", ex.Message);
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
                    Log.Logfile.Output(Log.StatusLog.Normal, "Export excel sucessfull");
                }
                else
                    return false;

            }
            catch (Exception ex)
            {

                Log.Logfile.Output(Log.StatusLog.Error, "Export excel fail!", ex.Message);
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
                                SmtpServer.Port = 25;
                                SmtpServer.Credentials = new System.Net.NetworkCredential("tlms@techlink.vn", "techlink@123");
                                //  SmtpServer.EnableSsl = true;  // dung email cong ty thi bo dong nay
                                SmtpServer.Send(mail);
                            }
                            else
                                return false;
                        }
                    }

               
                    mail.Dispose();
                    SmtpServer.Dispose();
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
                        Log.Logfile.Output(Log.StatusLog.Error, "Delete file attached fail :", ex.Message);

                    }
                    Log.Logfile.Output(Log.StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Log.Logfile.Output(Log.StatusLog.Error, "Send mail fail :", ex.Message);
            }


            return true;
        }

        public bool SendMailwithExportExceMQCbyCompanyMail(PeriodProduction period,ScheduleReportItems items, List<EmailNeedSend> emailNeedSends)
        {
            try
            {
               MQC.MQCReport mQCReport  = new MQC.MQCReport();

                if (mQCReport.ExportReportProductionDaiLy(period))
                {
                    Log.Logfile.Output(Log.StatusLog.Normal, "Export MQC report to excel sucessfull");
                }
                else // return false de khoi gui mail
                {
                    Log.Logfile.Output(Log.StatusLog.Normal, "Export MQC report to excel fail");
                    return false;
                }

            }
            catch (Exception ex)
            {

                Log.Logfile.Output(Log.StatusLog.Error, "Export MQC report to excel fail!", ex.Message);
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

                                SmtpServer.Port = 25;
                                SmtpServer.Credentials = new System.Net.NetworkCredential("tlms@techlink.vn", "techlink@123");
                                //  SmtpServer.EnableSsl = true;  // dung email cong ty thi bo dong nay
                                SmtpServer.Send(mail);
                            }
                            else return false;
                        }
                    }

                    mail.Dispose();
                    SmtpServer.Dispose();
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
                        Log.Logfile.Output(Log.StatusLog.Error, "Delete file attached fail :", ex.Message);

                    }
                    Log.Logfile.Output(Log.StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Log.Logfile.Output(Log.StatusLog.Error, "Send mail fail :", ex.Message);
            }


            return true;
        }
        public bool SendMailwithExportExceReliabilitybyCompanyMail( ScheduleReportItems items, List<EmailNeedSend> emailNeedSends)
        {
            try
            {
                BackLogReport.RealabilityReport realabilityReport = new BackLogReport.RealabilityReport();

                if (realabilityReport.SendMailReliabilityReportWeekly())
                {
                    Log.Logfile.Output(Log.StatusLog.Normal, "Export Reliability report to excel sucessfull");
                }
                else // return false de khoi gui mail
                {
                    Log.Logfile.Output(Log.StatusLog.Normal, "Export Reliability  report to excel fail");
                    return false;
                }

            }
            catch (Exception ex)
            {

                Log.Logfile.Output(Log.StatusLog.Error, "Export Reliability  report to excel fail!", ex.Message);
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
                   // mail.To.Add("tranducan.bkhcm11@gmail.com");
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
                                SmtpServer.Port = 25;
                                SmtpServer.Credentials = new System.Net.NetworkCredential("tlms@techlink.vn", "techlink@123");
                                //  SmtpServer.EnableSsl = true;  // dung email cong ty thi bo dong nay
                                SmtpServer.Send(mail);
                            }
                            else return false;
                        }
                    }

                
                    mail.Dispose();
                    SmtpServer.Dispose();
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
                        Log.Logfile.Output(Log.StatusLog.Error, "Delete file attached fail :", ex.Message);
                        return false;
                    }
                    Log.Logfile.Output(Log.StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Log.Logfile.Output(Log.StatusLog.Error, "Send mail fail :", ex.Message);
                return false;
            }


            return true;
        }

        public bool SendMailwithExportExceReliabilitybyCompanyMailForMonthly(ScheduleReportItems items, List<EmailNeedSend> emailNeedSends)
        {
            try
            {
                BackLogReport.RealabilityReport realabilityReport = new BackLogReport.RealabilityReport();

                if (realabilityReport.SendMailReliabilityReportMonthly())
                {
                    Log.Logfile.Output(Log.StatusLog.Normal, "Export Reliability report to excel sucessfull");
                }
                else // return false de khoi gui mail
                {
                    Log.Logfile.Output(Log.StatusLog.Normal, "Export Reliability  report to excel fail");
                    return false;
                }

            }
            catch (Exception ex)
            {

                Log.Logfile.Output(Log.StatusLog.Error, "Export Reliability  report to excel fail!", ex.Message);
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
                    //    mail.To.Add("tranducan.bkhcm11@gmail.com");
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
                                SmtpServer.Port = 25;
                                SmtpServer.Credentials = new System.Net.NetworkCredential("tlms@techlink.vn", "techlink@123");
                                //  SmtpServer.EnableSsl = true;  // dung email cong ty thi bo dong nay
                                SmtpServer.Send(mail);
                            }
                            else return false;
                        }
                    }

               
                    mail.Dispose();
                    SmtpServer.Dispose();
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
                        Log.Logfile.Output(Log.StatusLog.Error, "Delete file attached fail :", ex.Message);

                    }
                    Log.Logfile.Output(Log.StatusLog.Normal, "Send mail suscess :", items.ReportName + "|" + items.ReportType + "|" + items.Subject);

                    return true;
                }

            }
            catch (Exception ex)
            {
                Log.Logfile.Output(Log.StatusLog.Error, "Send mail fail :", ex.Message);
            }


            return true;
        }
    }
    

}
