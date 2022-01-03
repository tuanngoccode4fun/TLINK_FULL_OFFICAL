using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UploadDataToDatabase;
using System.IO;
using System.Threading;

namespace UploadDataToDatabase.MQC
{
   
   public class MQCReport
    {
         string PathFolder = @"\\172.16.0.5\Program\export\Done\";
      //  string PathFolder = @"D:\Done";
        public string MQCForm = Environment.CurrentDirectory + @"\Resources\MQC-PQC_Template.xlsx";
        public string pathMonth = Environment.CurrentDirectory + @"\Resources\Month.xls";
        public string pathDaily = Environment.CurrentDirectory + @"\Resources\MQC_Daily.xlsx";
        public string pathSaveProduction = @"\\172.16.0.5\Program\ProductionData\";
        string PathErrorFiles = @"\\172.16.0.5\Program\export\Done_ErrorFiles\";
        string PathDoneMoving = @"\\172.16.0.5\Program\export\Done_Moving\";
        public bool iSHaveFileDone (ref string StartTime,ref string StartDate, ref string endTime,ref string endDate, ref string lot,ref string fileread)
        {
            if(Directory.Exists(PathFolder))
            {
                string[] fileInfos = Directory.GetFiles(PathFolder,"*.csv");
                if(fileInfos != null && fileInfos.Count()>0)
                {
                    fileread = fileInfos[0];
                    string[] ReadAllLine = File.ReadAllLines(fileInfos[0]);
                    string[] lineData = ReadAllLine[1].Split(',');
                    StartDate = lineData[0]; StartTime = lineData[1]; endDate = lineData[2]; endTime= lineData[3]; lot = lineData[4];
                    Logfile.Output(StatusLog.Normal, "Have files " + lineData[0]);
                    return true;
                }


            }

            return false;
        }
        
        public void ExportReportProduction()
        {
            string startTime = "";string Startdate = ""; string endTime = "";string endDate = ""; string lot = "";string fileRead = "";
            var ishaveFile = iSHaveFileDone(ref startTime,ref Startdate, ref endTime,ref endDate, ref lot, ref fileRead);
            if(ishaveFile)
            {
              
                try
                {

            //    Thread.Sleep(10000);
                DateTime StartDate = DateTime.Parse(Startdate).Date;
                DateTime EndDate = DateTime.Parse(endDate).Date;
              
                TimeSpan timeStart = TimeSpan.Parse(startTime);
                TimeSpan timeEnd = TimeSpan.Parse(endTime);

                    DateTime from = StartDate + timeStart;
                    DateTime To = EndDate + timeEnd;
                    DefectRateData defectRateData = new DefectRateData();
                DefectRateReport defectRateReport = new DefectRateReport();
                defectRateData = defectRateReport.GetDefectRateReportByLot(from, To,  "B01", "0010", lot);
                if (defectRateData.TotalQuantity > 0)
                {
                    ExportExcelTool exportExcel = new ExportExcelTool();
                    checkFolderSaveProduction( defectRateData.Line,true);
                    exportExcel.ExportToTemplateMQCDefectTop16(MQCForm, pathSaveProduction + DateTime.Now.ToString("yyyy-MM-dd") + "\\"+defectRateData.Line + "\\" + "MQC_" + lot + "" + "-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + ".xlsx", defectRateData);;
                }
                   
                if (File.Exists(fileRead))
                        File.Move(fileRead, PathDoneMoving + new FileInfo(fileRead).Name);
                }
                catch (Exception ex)
                {

                    Logfile.Output(StatusLog.Normal, "ExportReportProduction()", ex.Message);
                    if (File.Exists(fileRead))
                    {
                        //   string temp = PathErrorFiles + new FileInfo(fileRead).Name;
                        if (File.Exists(PathErrorFiles + new FileInfo(fileRead).Name) == false)
                            File.Move(fileRead, PathErrorFiles + new FileInfo(fileRead).Name);
                        else File.Delete(fileRead);
                    }
                }
            }
        }
        private bool checkFolderSaveProduction( string line, bool createFolder = true)
        {
            if (createFolder)
            {
                if (Directory.Exists(pathSaveProduction + DateTime.Now.ToString("yyyy-MM-dd")+"\\" + line) == false)
                    Directory.CreateDirectory(pathSaveProduction + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + line);
            }
            else
            {
                return Directory.Exists(pathSaveProduction + DateTime.Now.ToString("yyyy-MM-dd") + "\\" + line);
            }
            return true;
        }
        public bool ExportReportProductionMonthly()
        {
            try
            {

                DefectRateReport defectRateReport = new DefectRateReport();
                DateTime date_from = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime date_to = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                DefectRateData defectRateData = new DefectRateData();
                defectRateData = defectRateReport.GetDefectRateReportAmountOfTime(date_from, date_to, "B01", "0010");
                if (defectRateData.TotalQuantity == 0)
                    return false;
                ExportExcelTool exportExcel = new ExportExcelTool();
                exportExcel.ExportToTemplateMQCDefectAmountOfTime(date_from, date_to, pathMonth, @"C:\ERP_Temp\MQC_Monthly_Report" + "-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + ".xlsx", defectRateData);
                return true;
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "ExportReportProductionDaiLy()", ex.Message);
                return false;
            }
        }
        public bool ExportReportProductionWeekly()
        {
            try
            {

                DefectRateReport defectRateReport = new DefectRateReport();
                DateTime date_from =Class.DateTimeControl.StartOfWeek(DayOfWeek.Monday);
                DateTime date_to = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 7);
                DefectRateData defectRateData = new DefectRateData();
                defectRateData = defectRateReport.GetDefectRateReportAmountOfTime(date_from, date_to, "B01", "0010");
                if (defectRateData.TotalQuantity == 0)
                    return false;
                ExportExcelTool exportExcel = new ExportExcelTool();
                exportExcel.ExportToTemplateMQCDefectAmountOfTime(date_from, date_to, pathMonth, @"C:\ERP_Temp\MQC_Weekly_Report" + "-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + ".xlsx", defectRateData);
                return true;
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "ExportReportProductionDaiLy()", ex.Message);
                return false;
            }
        }
        public bool ExportReportProductionDaiLy(PeriodProduction period)
        {
            try
            {

            DefectRateReport defectRateReport = new DefectRateReport();
          
                List<DefectRateData> defectRateDatas = new List<DefectRateData>();
            defectRateDatas = defectRateReport.GetListDefectRateReportAmountOfTimeDaily( "B01", "0010", period);

                if (defectRateDatas.Count == 0)
                    return false;
                ExportExcelTool exportExcel = new ExportExcelTool();
            exportExcel.ExportToTemplateMQCDefectDaily(pathDaily, @"C:\ERP_Temp\MQC_Daily_Report" + "-" + DateTime.Now.ToString("yyyyMMdd hhmmss") + ".xlsx", defectRateDatas);
                return true;
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "ExportReportProductionDaiLy()", ex.Message);
                return false;
            }
        }
    }
}
