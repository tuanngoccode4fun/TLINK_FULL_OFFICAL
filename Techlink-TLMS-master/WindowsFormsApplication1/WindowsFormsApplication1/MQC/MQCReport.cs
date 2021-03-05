using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.MQC
{
    class MQCReport
    {
        
        //  string PathFolder = @"D:\Done";
        public string MQCForm = Environment.CurrentDirectory + @"\Resources\MQC-PQC_Template.xlsx";
        public string pathMonth = Environment.CurrentDirectory + @"\Resources\Month.xls";
        public string pathDaily = Environment.CurrentDirectory + @"\Resources\MQC_Daily.xlsx";
        public string pathDailyNew = Environment.CurrentDirectory + @"\Resources\FORM_MQC_DAILY.xlsx";
        public string pathSaveProduction = @"\\172.16.0.5\Program\ProductionData\";
      




       
        public bool ExportReportProductionDaiLy(PeriodProduction period, string Pathsave)
        {
            try
            {

                DefectRateReport defectRateReport = new DefectRateReport();

                List<DefectRateData> defectRateDatas = new List<DefectRateData>();
                defectRateDatas = defectRateReport.GetListDefectRateReportAmountOfTimeDaily("B01", "0010", period);

                if (defectRateDatas.Count == 0)
                    return false;
                Class.ToolSupport exportExcel = new Class.ToolSupport();
                return true;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportReportProductionDaiLy()", ex.Message);
                return false;
            }
        }

        public bool ExportReportProductionFromTo(DateTime from, DateTime To, string Pathsave)
        {
            try
            {

                DefectRateReport defectRateReport = new DefectRateReport();

                List<DefectRateData> defectRateDatas = new List<DefectRateData>();
                defectRateDatas = defectRateReport.GetListDefectRateReportFromTo("B01", "0010", from, To);

                if (defectRateDatas.Count == 0)
                    return false;
                Class.ToolSupport exportExcel = new Class.ToolSupport();
                exportExcel.ExportToTemplateMQCDefectDaily(pathDaily, Pathsave, defectRateDatas, from, To);
                return true;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportReportProductionDaiLy()", ex.Message);
                return false;
            }
        }

        public bool ExportReportProductionFromToNewForm(DateTime from, DateTime To, string Pathsave)
        {
            try
            {

                DefectRateReport defectRateReport = new DefectRateReport();

                List<DefectRateData> defectRateDatas = new List<DefectRateData>();
                defectRateDatas = defectRateReport.GetListDefectRateReportFromTo("B01", "0010", from, To);

                if (defectRateDatas.Count == 0)
                    return false;
                List<string> listHeaderRW25 = GetListStringHeaderReworkTop25();
                MQCExportData mQCExportData = new MQCExportData();
             
                mQCExportData.ExportToTemplateMQCDefectDaily(pathDailyNew, Pathsave, listHeaderRW25, defectRateDatas, from, To);
                return true;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ExportReportProductionDaiLy()", ex.Message);
                return false;
            }
        }
        public List<string> GetListStringHeaderReworkTop25()
        {
            List<string> headerRW25 = new List<string>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select top(16) sum(cast(data as int)) as Tong, item, itemname from m_ERPMQC_REALTIME
inner join m_process on processcode = REPLACE(item,'RW','NG')
where remark ='RW'
group by item,itemname
order by Tong DESC ");
                DataTable dt = new DataTable();
                sqlCON sqlCON = new sqlCON();
                sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    headerRW25.Add(dt.Rows[i]["itemname"].ToString());
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<string> GetListStringHeaderReworkTop25()", ex.Message);
            }
            return headerRW25;
        }
    }
}
