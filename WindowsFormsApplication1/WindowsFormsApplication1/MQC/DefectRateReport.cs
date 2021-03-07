using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1.MQC
{
    public enum PeriodProduction
    {
        dayshift,// 8am-8pm - send mail at 20:15
        nightshift, // 8pm-8am - send mail at 8:15
        AllDay

    }
  public  class DefectRateReport
    {
        public DefectRateData GetDefectRateReportAmountOfTime(DateTime from, DateTime to, string Dept, string codeProcess)
        {
            DefectRateData defectRate = new DefectRateData();
            try
            {

                LoadDataSummary loadData = new LoadDataSummary();
                MQCItemSummary mQCItems = loadData.GetMQCItemSummaryByAmountOfTime(from, to, Dept, "MQC");
                defectRate.TotalQuantity = mQCItems.QuantityTotal;
                defectRate.DefectQuantity = mQCItems.NGQty;
                defectRate.OutputQuantity = mQCItems.OutputQty;
                defectRate.Line = mQCItems.Line;
                defectRate.DefectRate = (defectRate.TotalQuantity != 0) ? (defectRate.DefectQuantity / defectRate.TotalQuantity) : 0;
                LoadDefectMapping loadDefectTop5 = new LoadDefectMapping();
                List<NGItemsMapping> listTop5 = loadDefectTop5.listNGMappingGetReport(Dept, "MQC");
                List<DefectItem> listDefectTop5 = new List<DefectItem>();
                for (int i = 0; i < listTop5.Count; i++)
                {
                    var getlist = mQCItems.defectItems.Where(d => d.DefectSFT == listTop5[i].NGCode_SFT).ToList();

                    DefectItem defect = new DefectItem();
                    if (getlist != null && getlist.Count > 0)
                    {
                        defect = getlist[0];
                        defect.Quantity = getlist.Select(s => s.Quantity).Sum();

                    }
                    defect.Note = listTop5[i].Note;
                    listDefectTop5.Add(defect);
                }
                var listDefectTop5Groupby = listDefectTop5.OrderBy(d => d.Note).ToList();
                defectRate.defectItems = listDefectTop5Groupby;

            }
            catch (Exception ex)
            {
               SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDefectRateReport(DateTime from, DateTime to, string Dept, string codeProcess)", ex.Message);


            }
            return defectRate;
        }
        public DefectRateData GetDefectRateReportByLotTop13(DateTime from, TimeSpan time_From, DateTime to, TimeSpan time_to, string Dept, string codeProcess, string lot)
        {
            DefectRateData defectRate = new DefectRateData();
            try
            {

                //code lay tren ERP va SFT
                //     StringBuilder sql = new StringBuilder();
                //     sql.Append("select sum(TA011) as outputQty, sum(TA012) as DefectQTy, sum(TA011)+ sum(TA012) as TotalQty ");
                //     sql.Append("from SFCTA ");
                //     sql.Append("where 1=1 ");
                //     sql.Append("and TA004 = '" + Dept + "'");
                //     sql.Append("and TA003 = '" + codeProcess + "'");
                //     sql.Append("and CREATE_DATE >= '" + from.ToString("yyyyMMdd") + "'");
                //     sql.Append("and CREATE_DATE <= '" + to.ToString("yyyyMMdd") + "'");
                //     sqlERPCON sqlERPCON = new sqlERPCON();
                //     DataTable dt = new DataTable();
                //     sqlERPCON.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);

                //var     defectItems = (from DataRow dr in dt.Rows
                //                        select new DefectRateData()
                //                        {
                //                           TotalQuantity  =double.Parse( dr["TotalQty"].ToString()),
                //                            DefectQuantity = double.Parse( dr["DefectQTy"].ToString()),
                //                            OutputQuantity = double.Parse(dr["outputQty"].ToString())

                //                        }).ToList();

                //     defectRate = defectItems[0];
                //     defectRate.DateTime_from = from;
                //     defectRate.DateTime_to = to;
                //     defectRate.DefectRate = (defectRate.TotalQuantity != 0) ? (defectRate.DefectQuantity / defectRate.TotalQuantity) : 0;


                LoadDataSummary loadData = new LoadDataSummary();
                MQCItemSummary mQCItems = loadData.GetMQCItemSummarybyLot(from, time_From, to, time_to, Dept, "MQC", lot);
                defectRate.Product = mQCItems.product;
                defectRate.Lot = lot;
                defectRate.Line = mQCItems.Line;
                defectRate.TotalQuantity = mQCItems.QuantityTotal;
                defectRate.DefectQuantity = mQCItems.NGQty;
                defectRate.OutputQuantity = mQCItems.OutputQty;
                defectRate.DateTime_from = mQCItems.Time_from;
                defectRate.DateTime_to = mQCItems.Time_To;
                defectRate.DefectRate = (defectRate.TotalQuantity != 0) ? (defectRate.DefectQuantity / defectRate.TotalQuantity) : 0;
                LoadDefectMapping loadDefectTop16 = new LoadDefectMapping();
                List<NGItemsMapping> listTop16 = loadDefectTop16.listNGMappingGetReportTop13(Dept, "MQC");
                List<DefectItem> listDefectTop16 = new List<DefectItem>();
                for (int i = 0; i < listTop16.Count; i++)
                {
                    var getlist = mQCItems.defectItems.Where(d => d.DefectSFT == listTop16[i].NGCode_SFT).ToList();

                    DefectItem defect = new DefectItem();
                    if (getlist != null && getlist.Count > 0)
                    {
                        defect = getlist[0];
                        defect.Quantity = getlist.Select(s => s.Quantity).Sum();

                    }
                    defect.Note = listTop16[i].Note;
                    listDefectTop16.Add(defect);
                }
                var listDefectTop16Groupby = listDefectTop16.OrderBy(d => d.Note).ToList();
                defectRate.defectItems = listDefectTop16Groupby;

            }
            catch (Exception ex)
            {
               SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDefectRateReport(DateTime from, DateTime to, string Dept, string codeProcess)", ex.Message);


            }
            return defectRate;
        }
        public DefectRateData GetDefectRateReportByLot(DateTime from, TimeSpan time_From, DateTime to, TimeSpan time_to, string Dept, string codeProcess, string lot)
        {
            DefectRateData defectRate = new DefectRateData();
            try
            {

                //code lay tren ERP va SFT
                //     StringBuilder sql = new StringBuilder();
                //     sql.Append("select sum(TA011) as outputQty, sum(TA012) as DefectQTy, sum(TA011)+ sum(TA012) as TotalQty ");
                //     sql.Append("from SFCTA ");
                //     sql.Append("where 1=1 ");
                //     sql.Append("and TA004 = '" + Dept + "'");
                //     sql.Append("and TA003 = '" + codeProcess + "'");
                //     sql.Append("and CREATE_DATE >= '" + from.ToString("yyyyMMdd") + "'");
                //     sql.Append("and CREATE_DATE <= '" + to.ToString("yyyyMMdd") + "'");
                //     sqlERPCON sqlERPCON = new sqlERPCON();
                //     DataTable dt = new DataTable();
                //     sqlERPCON.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);

                //var     defectItems = (from DataRow dr in dt.Rows
                //                        select new DefectRateData()
                //                        {
                //                           TotalQuantity  =double.Parse( dr["TotalQty"].ToString()),
                //                            DefectQuantity = double.Parse( dr["DefectQTy"].ToString()),
                //                            OutputQuantity = double.Parse(dr["outputQty"].ToString())

                //                        }).ToList();

                //     defectRate = defectItems[0];
                //     defectRate.DateTime_from = from;
                //     defectRate.DateTime_to = to;
                //     defectRate.DefectRate = (defectRate.TotalQuantity != 0) ? (defectRate.DefectQuantity / defectRate.TotalQuantity) : 0;


                LoadDataSummary loadData = new LoadDataSummary();
                MQCItemSummary mQCItems = loadData.GetMQCItemSummarybyLot(from, time_From, to, time_to, Dept, "MQC", lot);
                defectRate.Product = mQCItems.product;
                defectRate.Line = mQCItems.Line;
                defectRate.Lot = lot;
                defectRate.TotalQuantity = mQCItems.QuantityTotal;
                defectRate.DefectQuantity = mQCItems.NGQty;
                defectRate.OutputQuantity = mQCItems.OutputQty;
                defectRate.ReworkQuantity = mQCItems.ReworkQty;
                defectRate.ReworkRate = mQCItems.ReworkRate;
                defectRate.DateTime_from = mQCItems.Time_from;
                defectRate.DateTime_to = mQCItems.Time_To;
                defectRate.DefectRate = mQCItems.DefectRate;
                LoadDefectMapping loadDefectTop16 = new LoadDefectMapping();
                List<NGItemsMapping> listTop16 = loadDefectTop16.listNGMappingGetReportTop16(Dept, "MQC");
                List<DefectItem> listDefectTop16 = new List<DefectItem>();
                for (int i = 0; i < listTop16.Count; i++)
                {
                    var getlist = mQCItems.defectItems.Where(d => d.DefectSFT == listTop16[i].NGCode_SFT).ToList();

                    DefectItem defect = new DefectItem();
                    if (getlist != null && getlist.Count > 0)
                    {
                        defect = getlist[0];
                        defect.Quantity = getlist.Select(s => s.Quantity).Sum();

                    }
                    defect.Note = listTop16[i].Note;
                    listDefectTop16.Add(defect);
                }
                var listDefectTop16Groupby = listDefectTop16.OrderBy(d => d.Note).ToList();
                defectRate.defectItems = listDefectTop16Groupby;

            }
            catch (Exception ex)
            {
               SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDefectRateReport(DateTime from, DateTime to, string Dept, string codeProcess)", ex.Message);


            }
            return defectRate;
        }
        public DefectRateData GetDefectRateReportAmountOfTimeDaily(DateTime from, DateTime to, string Dept, string codeProcess)
        {
            DefectRateData defectRate = new DefectRateData();
            try
            {

                //code lay tren ERP va SFT
                //     StringBuilder sql = new StringBuilder();
                //     sql.Append("select sum(TA011) as outputQty, sum(TA012) as DefectQTy, sum(TA011)+ sum(TA012) as TotalQty ");
                //     sql.Append("from SFCTA ");
                //     sql.Append("where 1=1 ");
                //     sql.Append("and TA004 = '" + Dept + "'");
                //     sql.Append("and TA003 = '" + codeProcess + "'");
                //     sql.Append("and CREATE_DATE >= '" + from.ToString("yyyyMMdd") + "'");
                //     sql.Append("and CREATE_DATE <= '" + to.ToString("yyyyMMdd") + "'");
                //     sqlERPCON sqlERPCON = new sqlERPCON();
                //     DataTable dt = new DataTable();
                //     sqlERPCON.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);

                //var     defectItems = (from DataRow dr in dt.Rows
                //                        select new DefectRateData()
                //                        {
                //                           TotalQuantity  =double.Parse( dr["TotalQty"].ToString()),
                //                            DefectQuantity = double.Parse( dr["DefectQTy"].ToString()),
                //                            OutputQuantity = double.Parse(dr["outputQty"].ToString())

                //                        }).ToList();

                //     defectRate = defectItems[0];
                //     defectRate.DateTime_from = from;
                //     defectRate.DateTime_to = to;
                //     defectRate.DefectRate = (defectRate.TotalQuantity != 0) ? (defectRate.DefectQuantity / defectRate.TotalQuantity) : 0;


                LoadDataSummary loadData = new LoadDataSummary();
                MQCItemSummary mQCItems = loadData.GetMQCItemSummaryByAmountOfTime(from, to, Dept, "MQC");
                defectRate.Line = mQCItems.Line;
                defectRate.TotalQuantity = mQCItems.QuantityTotal;
                defectRate.DefectQuantity = mQCItems.NGQty;
                defectRate.OutputQuantity = mQCItems.OutputQty;
                defectRate.ReworkQuantity = mQCItems.ReworkQty;
                defectRate.ReworkRate = mQCItems.ReworkRate;
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

            }
            catch (Exception ex)
            {
               SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDefectRateReport(DateTime from, DateTime to, string Dept, string codeProcess)", ex.Message);


            }
            return defectRate;
        }
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
               SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDefectRateReport(DateTime from, DateTime to, string Dept, string codeProcess)", ex.Message);

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
                    TimeSpan timeSpan = to- from;
                    defectRate.TargetMQC = loadTarget.GetArraystarget(defectRate.Product, from, from.AddDays(Math.Round(timeSpan.TotalDays - 1, 0)));
                    defectRates.Add(defectRate);
                }
            }
            catch (Exception ex)
            {
               SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetDefectRateReport(DateTime from, DateTime to, string Dept, string codeProcess)", ex.Message);

            }
            return defectRates;
        }
    }
}
