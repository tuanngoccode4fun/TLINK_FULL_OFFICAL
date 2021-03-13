using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadDataToDatabase.MQC.Report
{
    class MQCReport
    {

        //  string PathFolder = @"D:\Done";
        public string MQCForm = Environment.CurrentDirectory + @"\Resources\MQC-PQC_Template.xlsx";
        public string pathMonth = Environment.CurrentDirectory + @"\Resources\Month.xls";
        public string pathDaily = Environment.CurrentDirectory + @"\Resources\FORM_MQC_DAILY.xlsx";
        public string pathSaveProduction = @"\\172.16.0.5\Program\ProductionData\";
        private string Pathsave = @"C:\ERP_Temp\MQC_Daily_Report" + "" + " - " + DateTime.Now.ToString("yyyyMMdd hhmmss") + ".xlsx";
        public bool ExportReportProductionFromTo(DateTime from, DateTime To)
        {
            try
            {

                DefectRateReport defectRateReport = new DefectRateReport();

                List<DefectRateData> defectRateDatas = new List<DefectRateData>();
                defectRateDatas = defectRateReport.GetListDefectRateReportFromTo("B01", "0010", from, To);

                if (defectRateDatas.Count == 0)
                    return false;
                SelectTopDefectItems selectTopDefect = new SelectTopDefectItems();
                List<string> listHeaderRW25 = selectTopDefect.GetListStringHeaderReworkTop25();
                ExportExcelTool exportExcel = new ExportExcelTool();
                exportExcel.ExportToTemplateMQCDefectDaily(pathDaily, Pathsave, listHeaderRW25, defectRateDatas, from, To);
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
