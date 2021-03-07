using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadDataToDatabase.MQC.Report
{
   public class DefectRateReport
    {
        public List<DefectRateData> GetListDefectRateReportAmountOfTimeDaily(string Dept, string codeProcess, PeriodProduction period)
        {
            List<DefectRateData> defectRates = new List<DefectRateData>();
            try
            {
                LoadDataSummary loadData = new LoadDataSummary();
                List<MQCItemSummary> ListmQCItems = loadData.GetMQCItemSummaries(period, Dept, "MQC");
                foreach (var mQCItems in ListmQCItems)
                {
                    DefectRateData defectRate = new DefectRateData();
                    defectRate.Lot = mQCItems.Lot;
                    defectRate.Line = mQCItems.Line;
                    defectRate.Product = mQCItems.product;
                    defectRate.DateTime_from = mQCItems.Time_from;
                    defectRate.DateTime_to = mQCItems.Time_To;
                    defectRate.TotalQuantity = mQCItems.QuantityTotal;
                    defectRate.ReworkQuantity = mQCItems.ReworkQty;
                    defectRate.ReworkRate = mQCItems.ReworkRate;

                    defectRate.DefectQuantity = mQCItems.NGQty;
                    defectRate.OutputQuantity = mQCItems.OutputQty;
                    defectRate.DefectRate = (defectRate.TotalQuantity != 0) ? (defectRate.DefectQuantity / defectRate.TotalQuantity) : 0;
                    LoadDefectMapping loadDefectTop13 = new LoadDefectMapping();
                    List<NGItemsMapping> listTop13 = loadDefectTop13.listNGMappingGetReportTop13(Dept, "MQC");
                    List<DefectItem> listDefectTop13 = new List<DefectItem>();
                    for (int i = 0; i < listTop13.Count; i++)
                    {
                        var getlist = mQCItems.defectItems.Where(d => d.DefectSFT == listTop13[i].NGCode_SFT).ToList();

                        DefectItem defect = new DefectItem();
                        if (getlist != null && getlist.Count > 0)
                        {
                            defect = getlist[0];
                            defect.Quantity = getlist.Select(s => s.Quantity).Sum();

                        }
                        defect.Note = listTop13[i].Note;
                        listDefectTop13.Add(defect);
                    }
                    var listDefectTop13Groupby = listDefectTop13.OrderBy(d => d.Note).ToList();
                    defectRate.defectItems = listDefectTop13Groupby;
                    DateTime dateTarget = DateTime.Now.Date;
                    if (period == PeriodProduction.AllDay)
                        dateTarget = DateTime.Now.Date.AddDays(-1);
                    else if (period == PeriodProduction.dayshift)
                        dateTarget = DateTime.Now.Date;
                    else if (period == PeriodProduction.nightshift)
                        dateTarget = DateTime.Now.Date.AddDays(-1);
                    defectRate.TargetMQC = new TargetMQC();
                    LoadTargetProduction loadTarget = new LoadTargetProduction();
                    defectRate.TargetMQC = loadTarget.GetTargetMQC(defectRate.Product, dateTarget.ToString("yyyyMMdd"));
                    defectRates.Add(defectRate);
                }
            }
            catch (Exception ex)
            {
                Logfile.Output(StatusLog.Error, "GetDefectRateReport(DateTime from, DateTime to, string Dept, string codeProcess)", ex.Message);

            }
            return defectRates;
        }

        public List<DefectRateData> GetListDefectRateReportFromTo(string Dept, string codeProcess, DateTime from, DateTime to)
        {
            List<DefectRateData> defectRates = new List<DefectRateData>();
            try
            {
                LoadDataSummary loadData = new LoadDataSummary();
                List<MQCItemSummary> ListmQCItems = loadData.GetMQCItemSummariesFromTo(from, to, Dept, "MQC");
                foreach (var mQCItems in ListmQCItems)
                {
                    DefectRateData defectRate = new DefectRateData();
                    defectRate.Lot = mQCItems.Lot;
                    defectRate.Line = mQCItems.Line;
                    defectRate.Product = mQCItems.product;
                    defectRate.DateTime_from = mQCItems.Time_from;
                    defectRate.DateTime_to = mQCItems.Time_To;
                    defectRate.TotalQuantity = mQCItems.QuantityTotal;
                    defectRate.ReworkQuantity = mQCItems.ReworkQty;
                    defectRate.ReworkRate = mQCItems.ReworkRate;

                    defectRate.DefectQuantity = mQCItems.NGQty;
                    defectRate.OutputQuantity = mQCItems.OutputQty;
                    defectRate.DefectRate = (defectRate.TotalQuantity != 0) ? (defectRate.DefectQuantity / defectRate.TotalQuantity) : 0;
                    LoadDefectMapping loadDefectTop13 = new LoadDefectMapping();
                    List<NGItemsMapping> listTop13 = loadDefectTop13.listNGMappingGetReportTop13(Dept, "MQC");
                    List<DefectItem> listDefectTop13 = new List<DefectItem>();
                    for (int i = 0; i < listTop13.Count; i++)
                    {
                        var getlist = mQCItems.defectItems.Where(d => d.DefectSFT == listTop13[i].NGCode_SFT).ToList();

                        DefectItem defect = new DefectItem();
                        if (getlist != null && getlist.Count > 0)
                        {
                            defect = getlist[0];
                            defect.Quantity = getlist.Select(s => s.Quantity).Sum();

                        }
                        defect.Note = listTop13[i].Note;
                        listDefectTop13.Add(defect);
                    }
                    var listDefectTop13Groupby = listDefectTop13.OrderBy(d => d.Note).ToList();
                    defectRate.defectItems = listDefectTop13Groupby;
                    defectRate.ReworkItems = mQCItems.ReworkItems;
                    defectRate.TargetMQC = new TargetMQC();
                    LoadTargetProduction loadTarget = new LoadTargetProduction();
                    TimeSpan timeSpan = to - from;
                    defectRate.TargetMQC = loadTarget.GetArraystarget(defectRate.Product, from, from.AddDays(Math.Round(timeSpan.TotalDays - 1, 0)));
                   
                    defectRates.Add(defectRate);
                }
            }
            catch (Exception ex)
            {
               Logfile.Output(StatusLog.Error, "GetDefectRateReport(DateTime from, DateTime to, string Dept, string codeProcess)", ex.Message);

            }
            return defectRates;
        }
    }
}
