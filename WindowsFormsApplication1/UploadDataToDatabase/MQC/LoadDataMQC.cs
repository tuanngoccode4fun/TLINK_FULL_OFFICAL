﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UploadDataToDatabase.Class;

namespace UploadDataToDatabase.MQC
{
    public enum ProductionStatus { NotYet, Finished, Normal, HighDefect, ShortageMaterial, BreakTime}
   
   
    class LoadDataMQC
    {
       
       public MQCItem1 GetQCCItemOK(DateTime from, DateTime to, string model, string lot, string site, string process)
        {
            MQCItem1 mQCItem = new MQCItem1();
            try
            {

            LoadDefectMapping defectMapping = new LoadDefectMapping();
            List<NGItemsMapping> nGItemsMappings = defectMapping.listNGMapping("B01","MQC");
                mQCItem.TargetMQC = new TargetMQC();
                LoadTargetProduction loadTarget = new LoadTargetProduction();
                mQCItem.TargetMQC = loadTarget.GetTargetMQC(model, DateTime.Now.Date.ToString("yyyyMMdd"));
            List<MQCDataItems> listMQC = new List<MQCDataItems>();
            listMQC= listMQCDataItems(from, to, model, lot, site, process);
            //Load MQCItem to show
            mQCItem.process = process;
            mQCItem.department = site;
            mQCItem.product = model;
          
            mQCItem.PO = (listMQC != null && listMQC.Count >0) ?   listMQC[0].lot: "";
            var TotalOutputQty = listMQC
                .Where(d => d.remark == "OP")
                .Select((s=> s.data))
                .ToList();
            mQCItem.TotalOutput = TotalOutputQty.Sum();
            var TotalNGQty = listMQC
                 .Where(d => d.remark == "NG")
                 .Select((s => s.data))
                 .ToList();
            mQCItem.TotalNG = TotalNGQty.Sum();
            var TotalRework = listMQC
               .Where(d => d.remark == "RW")
               .Select((s => s.data))
               .ToList();
            mQCItem.TotalRework= TotalRework.Sum();
            mQCItem.percentNG = (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework)!= 0 ? mQCItem.TotalNG / (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) :0;
            mQCItem.percentRework = (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) != 0 ? mQCItem.TotalRework / (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) : 0;
            var listNGItem = listMQC
             .Where(d => d.remark== "NG")
             .Select((s => new {s.item,s.data}))
             .ToList();
            mQCItem.listNGItems = new List<NGItems>();
            foreach (var item in listNGItem)
            {
                NGItems nGItems = new NGItems();
                var _NG_SFT = nGItemsMappings.Where(d => d.NGCode_Process == item.item).Select(s => s.NGCode_SFT).ToArray();
                string NG_SFT = (_NG_SFT != null && _NG_SFT.Count() > 0) ?_NG_SFT[0] : "";
                nGItems.NGType = NG_SFT;
                var _NGName_SFT = nGItemsMappings.Where(d => d.NGCode_Process == item.item).Select(s => s.NGCodeName_SFT).ToArray();
                string NGName_SFT = (_NGName_SFT != null && _NGName_SFT.Count() > 0) ? _NGName_SFT[0] : "";
                nGItems.NGName = NGName_SFT;

                nGItems.NGKey = item.item;
                nGItems.NGQuantity = item.data;
                mQCItem.listNGItems.Add(nGItems);
            }
            var listRWItem = listMQC
             .Where(d => d.item.Contains("RW"))
             .Select((s => new { s.item, s.data }))
             .ToList();
            mQCItem.listRWItems = new List<NGItems>();
            foreach (var item in listRWItem)
            {
                NGItems nGItems = new NGItems();
                    string strReplace = item.item.Replace("RW", "NG");
                    var _NG_SFT = nGItemsMappings.Where(d => d.NGCode_Process == strReplace).Select(s => s.NGCode_SFT).ToArray();
                    string NG_SFT = (_NG_SFT != null && _NG_SFT.Count() > 0) ? _NG_SFT[0] : "";
                    nGItems.NGType = NG_SFT;
                    var _NGName_SFT = nGItemsMappings.Where(d => d.NGCode_Process == strReplace).Select(s => s.NGCodeName_SFT).ToArray();
                    string NGName_SFT = (_NGName_SFT != null && _NGName_SFT.Count() > 0) ? _NGName_SFT[0] : "";
                    nGItems.NGName = NGName_SFT;
                    nGItems.NGKey = item.item;
                nGItems.NGQuantity = item.data;
                mQCItem.listRWItems.Add(nGItems);
            }
            List<MQCDataItems> listMQC_Error = new List<MQCDataItems>();
            listMQC_Error = listMQCData_ErrorItems(from, to, model, lot, site, process);
            mQCItem.InputMaterialNotYet = listMQC_Error.Where(w =>w.remark == "OP" || w.remark == "NG").Select(d=>d.data).ToArray().Sum();
                double targetDefect = 0;
                if (mQCItem.TargetMQC.TargetOutput != 0)
                {
                   targetDefect = (mQCItem.TargetMQC.TargetDefect / (mQCItem.TargetMQC.TargetDefect + mQCItem.TargetMQC.TargetOutput));
                }
               
                if (mQCItem.InputMaterialNotYet > 0)
                {
                    mQCItem.Status = ProductionStatus.ShortageMaterial.ToString();
                    mQCItem.Measage = "Please supply material for production";
                }
                else if (mQCItem.percentNG > targetDefect && targetDefect >0)
                {
                    mQCItem.Status = ProductionStatus.HighDefect.ToString();
                    mQCItem.Measage = "Defect is too much";
                }
                else
                {
                    mQCItem.Status = ProductionStatus.Normal.ToString();
                }
                    mQCItem.InputSFT =( mQCItem.TotalOutput+mQCItem.TotalNG) - mQCItem.InputMaterialNotYet;
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "GetQCCItemOK", ex.Message);
            }
            // sql.Append()
            return mQCItem;
            
        }

        public List<MQCItem1> listMQCItemsOfDept(DateTime from, DateTime to, string site, string process)
        {
            List<MQCItem1> listMQCReturn = new List<MQCItem1>();
            try
            {

           
            List<MQCDataItems> listMQC = new List<MQCDataItems>();
            listMQC = listMQCDataItemsbySite(from, to, site, process);
            var ListItems = listMQC
    .GroupBy(u => u.model)
    .Select(grp => grp.ToList())
    .ToList();

            foreach (var mQCDatas in ListItems)
            {
                MQCItem1 mQCItem = new MQCItem1();

                mQCItem.process = process;
                mQCItem.department = site;
                mQCItem.product = mQCDatas[0].model;
                mQCItem.PO = mQCDatas[0].lot;
                    mQCItem.TargetMQC = new TargetMQC();
                    LoadTargetProduction loadTarget = new LoadTargetProduction();
                    mQCItem.TargetMQC = loadTarget.GetTargetMQC(mQCItem.product, DateTime.Now.Date.ToString("yyyyMMdd"));
                    var TotalOutputQty = mQCDatas
                    .Where(d => d.remark == "OP")
                    .Select((s => s.data))
                    .ToList();
                mQCItem.TotalOutput = TotalOutputQty.Sum();
                var TotalNGQty = mQCDatas
                     .Where(d => d.remark == "NG")
                     .Select((s => s.data))
                     .ToList();
                mQCItem.TotalNG = TotalNGQty.Sum();
                var TotalRework = mQCDatas
                   .Where(d => d.remark == "RW")
                   .Select((s => s.data))
                   .ToList();
                mQCItem.TotalRework = TotalRework.Sum();
                mQCItem.percentNG = (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) != 0 ? mQCItem.TotalNG / (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) : 0;
                mQCItem.percentRework = (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) != 0 ? mQCItem.TotalRework / (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) : 0;
                    List<MQCDataItems> listMQC_Error = new List<MQCDataItems>();
                    listMQC_Error = listMQCData_ErrorItems(from, to, mQCItem.product, mQCItem.PO, site, process);
                    mQCItem.InputMaterialNotYet = listMQC_Error.Where(w => w.remark == "OP" || w.remark == "NG").Select(d => d.data).ToArray().Sum();
                    double targetDefect = 0;
                    if (mQCItem.TargetMQC.TargetOutput != 0)
                    {
                        targetDefect = (mQCItem.TargetMQC.TargetDefect / (mQCItem.TargetMQC.TargetDefect + mQCItem.TargetMQC.TargetOutput));
                    }
                    if (mQCItem.InputMaterialNotYet > 0)
                    {
                        mQCItem.Status = ProductionStatus.ShortageMaterial.ToString();
                        mQCItem.Measage = "Please supply material for production";
                    }
                    else if (mQCItem.percentNG > targetDefect && targetDefect > 0)
                    {
                        mQCItem.Status = ProductionStatus.HighDefect.ToString();
                        mQCItem.Measage = "Defect is too much";
                    }
                    else
                    {
                        mQCItem.Status = ProductionStatus.Normal.ToString();
                    }
                    mQCItem.InputSFT = (mQCItem.TotalOutput + mQCItem.TotalNG) - mQCItem.InputMaterialNotYet;
                    listMQCReturn.Add(mQCItem);

            }

            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "listMQCItemsOfDept()", ex.Message);
            }
            return listMQCReturn;

        }
        public List<MQCDataItems> listMQCDataItems(DateTime from, DateTime to, string model,string lot, string site, string process)
        {
            List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
            try
            {

            StringBuilder sql = new StringBuilder();
            sql.Append("select distinct serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, status, remark ");
            sql.Append("from m_ERPMQC_REALTIME ");
                sql.Append("where 1=1  and data  != '0' ");
                sql.Append("and model = '" + model + "' ");
            sql.Append("and lot like '%" + lot + "%' ");
            sql.Append("and site = '" + site + "' ");
            sql.Append("and process = '" + process + "' ");
                sql.Append("and cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '" + from.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                sql.Append("and cast(inspectdate as datetime) + CAST (inspecttime as datetime) <= '" + to.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                sql.Append(" order by inspectdate, inspecttime ");
                sqlCON sql12 = new sqlCON();
            DataTable dt = new DataTable();
            sql12.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            listMQCDataItems = (from DataRow dr in dt.Rows
                           select new MQCDataItems()
                           {
                               serno = dr["serno"].ToString(),
                               lot = dr["lot"].ToString(),
                               model = dr["model"].ToString(),
                               site = dr["site"].ToString(),
                               factory = dr["factory"].ToString(),
                               line = dr["line"].ToString(),
                               process = dr["process"].ToString(),
                               item = dr["item"].ToString(),
                               inspectdate = (dr["inspectdate"].ToString() != "") ? DateTime.Parse(dr["inspectdate"].ToString()) : DateTime.MinValue,
                               inspecttime = (dr["inspecttime"].ToString() != "") ? TimeSpan.Parse(dr["inspecttime"].ToString()) : TimeSpan.MinValue,
                               data = (dr["data"].ToString() != "") ? double.Parse(dr["data"].ToString()) : 0,
                               judge = dr["judge"].ToString(),
                               status = dr["status"].ToString(),
                               remark = dr["remark"].ToString()

                           }).ToList();
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "listMQCDataItems()", ex.Message);
            }
            return listMQCDataItems;
        }
        public List<MQCDataItems> listMQCDataItemsbySite(DateTime from, DateTime to, string site, string process)
        {
            List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
            try
            {

        
          //  List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
            StringBuilder sql = new StringBuilder();
            sql.Append("select distinct serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, status, remark ");
            sql.Append("from m_ERPMQC_REALTIME ");
                sql.Append("where 1=1  and data  != '0' ");
                sql.Append("and site = '" + site + "' ");
            sql.Append("and process = '" + process + "' ");
                sql.Append("and cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '" + from.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                sql.Append("and cast(inspectdate as datetime) + CAST (inspecttime as datetime) <= '" + to.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                sql.Append(" order by inspectdate, inspecttime ");
                sqlCON sql12 = new sqlCON();
            DataTable dt = new DataTable();
            sql12.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            listMQCDataItems = (from DataRow dr in dt.Rows
                                select new MQCDataItems()
                                {
                                    serno = dr["serno"].ToString(),
                                    lot = dr["lot"].ToString(),
                                    model = dr["model"].ToString(),
                                    site = dr["site"].ToString(),
                                    factory = dr["factory"].ToString(),
                                    line = dr["line"].ToString(),
                                    process = dr["process"].ToString(),
                                    item = dr["item"].ToString(),
                                    inspectdate = (dr["inspectdate"].ToString() != "") ? DateTime.Parse(dr["inspectdate"].ToString()) : DateTime.MinValue,
                                    inspecttime = (dr["inspecttime"].ToString() != "") ? TimeSpan.Parse(dr["inspecttime"].ToString()) : TimeSpan.MinValue,
                                    data = (dr["data"].ToString() != "") ? double.Parse(dr["data"].ToString()) : 0,
                                    judge = dr["judge"].ToString(),
                                    status = dr["status"].ToString(),
                                    remark = dr["remark"].ToString()

                                }).ToList();
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "listMQCDataItemsbySite()", ex.Message);
            }

            return listMQCDataItems;
        }
        public List<MQCDataItems> listMQCDataItemsbyAmountOfTime(DateTime from, DateTime to, string site, string process)
        {
            List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
            try
            {


                //  List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
                StringBuilder sql = new StringBuilder();
                sql.Append("select distinct serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, status, remark ");
                sql.Append("from m_ERPMQC_REALTIME ");
                   sql.Append("where 1=1  and data  != '0' ");
                sql.Append("and site = '" + site + "' ");
                sql.Append("and process = '" + process + "' ");
                sql.Append("and cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '" + from.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                sql.Append("and cast(inspectdate as datetime) + CAST (inspecttime as datetime) <= '" + to.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                sql.Append(" order by inspectdate, inspecttime ");
                sqlCON sql12 = new sqlCON();
                DataTable dt = new DataTable();
                sql12.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
                listMQCDataItems = (from DataRow dr in dt.Rows
                                    select new MQCDataItems()
                                    {
                                        serno = dr["serno"].ToString(),
                                        lot = dr["lot"].ToString(),
                                        model = dr["model"].ToString(),
                                        site = dr["site"].ToString(),
                                        factory = dr["factory"].ToString(),
                                        line = dr["line"].ToString(),
                                        process = dr["process"].ToString(),
                                        item = dr["item"].ToString(),
                                        inspectdate = (dr["inspectdate"].ToString() != "") ? DateTime.Parse(dr["inspectdate"].ToString()) : DateTime.MinValue,
                                        inspecttime = (dr["inspecttime"].ToString() != "") ? TimeSpan.Parse(dr["inspecttime"].ToString()) : TimeSpan.MinValue,
                                        data = (dr["data"].ToString() != "") ? double.Parse(dr["data"].ToString()) : 0,
                                        judge = dr["judge"].ToString(),
                                        status = dr["status"].ToString(),
                                        remark = dr["remark"].ToString()

                                    }).ToList();
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "listMQCDataItemsbySite()", ex.Message);
            }

            return listMQCDataItems;
        }
        public List<MQCDataItems> listMQCDataItemsbylot(DateTime from, DateTime to,  string site, string process, string lot)
        {
            List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
            try
            {


                //  List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
                StringBuilder sql = new StringBuilder();
                sql.Append("select distinct serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, status, remark ");
                sql.Append("from m_ERPMQC_REALTIME ");
                sql.Append("where 1=1  and data  != '0' ");
                sql.Append("and site = '" + site + "' ");
                sql.Append("and process = '" + process + "' ");
                sql.Append("and lot = '" + lot + "' ");
                sql.Append("and cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '" + from.ToString("yyyy-MM-dd HH:mm:ss") + "'");
                sql.Append("and cast(inspectdate as datetime) + CAST (inspecttime as datetime) <= '" + to.ToString("yyyy-MM-dd HH:mm:ss") + "'");

                sql.Append(" order by inspectdate, inspecttime ");
                sqlCON sql12 = new sqlCON();
                DataTable dt = new DataTable();
                sql12.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
                listMQCDataItems = (from DataRow dr in dt.Rows
                                    select new MQCDataItems()
                                    {
                                        serno = dr["serno"].ToString(),
                                        lot = dr["lot"].ToString(),
                                        model = dr["model"].ToString(),
                                        site = dr["site"].ToString(),
                                        factory = dr["factory"].ToString(),
                                        line = dr["line"].ToString(),
                                        process = dr["process"].ToString(),
                                        item = dr["item"].ToString(),
                                        inspectdate = (dr["inspectdate"].ToString() != "") ? DateTime.Parse(dr["inspectdate"].ToString()) : DateTime.MinValue,
                                        inspecttime = (dr["inspecttime"].ToString() != "") ? TimeSpan.Parse(dr["inspecttime"].ToString()) : TimeSpan.MinValue,
                                        data = (dr["data"].ToString() != "") ? double.Parse(dr["data"].ToString()) : 0,
                                        judge = dr["judge"].ToString(),
                                        status = dr["status"].ToString(),
                                        remark = dr["remark"].ToString()

                                    }).ToList();
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "listMQCDataItemsbySite()", ex.Message);
            }

            return listMQCDataItems;
        }
        public List<MQCDataItems> listMQCData_ErrorItems(DateTime from, DateTime to, string model, string lot, string site, string process)
        {
            List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
            try
            {

          
            StringBuilder sql = new StringBuilder();
            sql.Append("select distinct serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, status, remark ");
            sql.Append("from m_ERPMQC_Error ");
            sql.Append("where 1=1 and status !='OK' ");
            sql.Append("and model = '" + model + "' ");
            sql.Append("and lot like '%" + lot + "%' ");
            sql.Append("and site = '" + site + "' ");
            sql.Append("and process = '" + process + "' ");
           sql.Append("and cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '" + from.ToString("yyyy-MM-dd HH:mm:ss") + "'");
             sql.Append("and cast(inspectdate as datetime) + CAST (inspecttime as datetime) <= '" + to.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            sql.Append(" order by inspectdate, inspecttime ");
                sqlCON sql12 = new sqlCON();
            DataTable dt = new DataTable();
            sql12.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            listMQCDataItems = (from DataRow dr in dt.Rows
                                select new MQCDataItems()
                                {
                                    serno = dr["serno"].ToString(),
                                    lot = dr["lot"].ToString(),
                                    model = dr["model"].ToString(),
                                    site = dr["site"].ToString(),
                                    factory = dr["factory"].ToString(),
                                    line = dr["line"].ToString(),
                                    process = dr["process"].ToString(),
                                    item = dr["item"].ToString(),
                                    inspectdate = (dr["inspectdate"].ToString() != "") ? DateTime.Parse(dr["inspectdate"].ToString()) : DateTime.MinValue,
                                    inspecttime = (dr["inspecttime"].ToString() != "") ? TimeSpan.Parse(dr["inspecttime"].ToString()) : TimeSpan.MinValue,
                                    data = (dr["data"].ToString() != "") ? double.Parse(dr["data"].ToString()) : 0,
                                    judge = dr["judge"].ToString(),
                                    status = dr["status"].ToString(),
                                    remark = dr["remark"].ToString()

                                }).ToList();
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "listMQCData_ErrorItems()", ex.Message);
            }

            return listMQCDataItems;
        }
        public List<MQCItemSummary> GetMQCItemSummaries(PeriodProduction period, string site, string process)
        {
            DateTime from = new DateTime(); DateTime to = new DateTime();
            DateTimeControl.ReturnDateTimePeriodProduction(period, ref from, ref to);
            string date = from.ToString("yyyy-MM-dd");
            string time = from.ToString("HH:mm:ss");
            List<MQCItemSummary> qCItemSummaries = new List<MQCItemSummary>();

            try
            {
                LoadDataMQC dataMQC = new LoadDataMQC();
                List<MQCDataItems> mQCDataItems = dataMQC.listMQCDataItemsbySite(from, to, site, process);
                //Nhom theo san pham
                var ListMQCbyProduct = mQCDataItems
                    .OrderBy(d => d.line)
                     .GroupBy(u => u.lot)
                     .Select(grp => grp.ToList())
                    .ToList();
                foreach (var qCDataItems in ListMQCbyProduct)
                {
                    MQCItemSummary itemSummary = new MQCItemSummary();
                    itemSummary.product = qCDataItems[0].model;
                    itemSummary.defectItems = new List<DefectItem>();
                    var ListItemsData = qCDataItems
                 .GroupBy(u => u.item)
                 .Select(grp => grp.ToList())
                .ToList();

                    var ListItemsDate = qCDataItems
                .GroupBy(u => u.inspectdate)
               .ToList();
                    foreach (var itemDate in ListItemsDate)
                    {
                        var ListItemsTime = qCDataItems
             .GroupBy(u => u.inspecttime)
            .ToList();
                        
                            itemSummary.Time_from = dataMQC.GetMinTimeProductionOfProduct(itemSummary.product, from, to);
                            itemSummary.Time_To = dataMQC.GetMaxTimeProductionOfProduct(itemSummary.product, from, to);
                          
                       
                    }
                    //Khi thay doi ngay can phai chinh lai thoi gian

                    foreach (var itemData in ListItemsData)
                    {
                        itemSummary.product = itemData[0].model;
                        itemSummary.Line = itemData[0].line;
                        itemSummary.Lot = itemData[0].lot;

                        if (itemData[0].remark == "OP")
                        {
                            itemSummary.OutputQty = itemData.Select(d => d.data).Sum();
                        }
                        else if (itemData[0].remark == "NG")
                        {
                            DefectItem item = new DefectItem();
                            item.DefectCode = itemData[0].item;
                            item.Quantity = itemData.Select(d => d.data).Sum();
                            LoadDefectMapping defectMapping = new LoadDefectMapping();
                            NGItemsMapping nGItemsMapping = defectMapping.GetNGMapping(site, process, item.DefectCode);
                            item.DefectSFT = nGItemsMapping.NGCode_SFT;
                            item.DefectSFTName = nGItemsMapping.NGCodeName_SFT;
                            itemSummary.defectItems.Add(item);
                            itemSummary.NGQty += item.Quantity;
                        }
                        else if (itemData[0].remark == "RW")
                        {
                            DefectItem item = new DefectItem();
                            item.DefectCode = itemData[0].item;
                            item.Quantity = itemData.Select(d => d.data).Sum();

                            itemSummary.ReworkQty += item.Quantity;
                        }
                    }
                    itemSummary.QuantityTotal = itemSummary.OutputQty + itemSummary.NGQty/*+ itemSummary.ReworkQty*/;
                    itemSummary.DefectRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.NGQty / itemSummary.QuantityTotal) : 0;
                    itemSummary.ReworkRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.ReworkQty / itemSummary.QuantityTotal) : 0;
                    qCItemSummaries.Add(itemSummary);
                }
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "GetMQCItemSummaries(DateTime from, DateTime to, string site, string process)", ex.Message);
            }
            return qCItemSummaries;
        }

        public string GetMaxTimeProductionOfProduct(string model, DateTime from, DateTime to)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"select max(cast(inspectdate as datetime) + CAST (inspecttime as datetime)) from m_ERPMQC_REALTIME
where 1=1 and data != '0'   and site = 'B01' and process = 'MQC' 
");
            stringBuilder.Append(" and cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '" + from.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            stringBuilder.Append(" and cast(inspectdate as datetime) + CAST (inspecttime as datetime) <= '" + to.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            stringBuilder.Append(" and model = '" + model + "' ");
            sqlCON sql12 = new sqlCON();
            return sql12.sqlExecuteScalarString(stringBuilder.ToString());
        }
        public string GetMinTimeProductionOfProduct(string model, DateTime from, DateTime to)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"select min(cast(inspectdate as datetime) + CAST (inspecttime as datetime)) from m_ERPMQC_REALTIME
where 1=1 and data != '0'   and site = 'B01' and process = 'MQC' 
");
            stringBuilder.Append(" and cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '" + from.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            stringBuilder.Append(" and cast(inspectdate as datetime) + CAST (inspecttime as datetime) <= '" + to.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            stringBuilder.Append(" and model = '" + model + "' ");
            sqlCON sql12 = new sqlCON();
            return sql12.sqlExecuteScalarString(stringBuilder.ToString());
        }

    }
}
