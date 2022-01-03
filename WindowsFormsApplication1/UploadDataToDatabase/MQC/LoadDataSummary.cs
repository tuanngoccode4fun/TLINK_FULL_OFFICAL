using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using UploadDataToDatabase.Class;


namespace UploadDataToDatabase.MQC
{
    class LoadDataSummary
    {
        public List<MQCItemSummary> GetMQCItemSummaries( PeriodProduction period,string site, string process)
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
                    .OrderBy(d=>d.line)
                     .GroupBy(u => u.model)
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
     
        public MQCItemSummary GetMQCItemSummaryByAmountOfTime(DateTime from, DateTime to, string site, string process)
        {
            MQCItemSummary itemSummary = new MQCItemSummary();

            try
            {
                LoadDataMQC dataMQC = new LoadDataMQC();
                List<MQCDataItems> mQCDataItems = dataMQC.listMQCDataItemsbyAmountOfTime(from, to, site, process);
                //Nhom theo san pham
                var ListItemsData = mQCDataItems
               .GroupBy(u => u.item)
               .Select(grp => grp.ToList())
              .ToList();

                var ListItemsTime = mQCDataItems
            .GroupBy(u => u.inspecttime)
           .ToList();
                itemSummary.product = "";
                itemSummary.defectItems = new List<DefectItem>();

                //Khi thay doi ngay can phai chinh lai thoi gian
                itemSummary.Time_from = mQCDataItems.Min(d => d.inspecttime).ToString();
                itemSummary.Time_To = mQCDataItems.Max(d => d.inspecttime).ToString();

                foreach (var itemData in ListItemsData)
                {
                    itemSummary.product = itemData[0].model;
                    itemSummary.Line = itemData[0].line;
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
                    else if(itemData[0].remark == "RW")
                    {
                        DefectItem item = new DefectItem();
                        item.DefectCode = itemData[0].item;
                        item.Quantity = itemData.Select(d => d.data).Sum();
                     
                        itemSummary.ReworkQty += item.Quantity;
                    }
                }
                itemSummary.QuantityTotal = itemSummary.OutputQty + itemSummary.NGQty + itemSummary.ReworkQty;
                itemSummary.DefectRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.NGQty / itemSummary.QuantityTotal) : 0;
                itemSummary.ReworkRate= (itemSummary.QuantityTotal != 0) ? (itemSummary.ReworkQty / itemSummary.QuantityTotal) : 0;


            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "GetMQCItemSummaries(DateTime from, DateTime to, string site, string process)", ex.Message);
            }
            return itemSummary;
        }
        public MQCItemSummary GetMQCItemSummarybyLot(DateTime from, DateTime to,  string site, string process,string lot)
        {
            MQCItemSummary itemSummary = new MQCItemSummary();

            try
            {
                LoadDataMQC dataMQC = new LoadDataMQC();
                List<MQCDataItems> mQCDataItems = dataMQC.listMQCDataItemsbylot(from, to, site, process,lot);
                //Nhom theo san pham
                var ListItemsData = mQCDataItems
               .GroupBy(u => u.remark)
               .Select(grp => grp.ToList())
              .ToList();


              
                itemSummary.defectItems = new List<DefectItem>();

                //Khi thay doi ngay can phai chinh lai thoi gian
                itemSummary.Time_from = dataMQC.GetMinTimeProductionOfProduct(ListItemsData[0][0].model, from, to);
                itemSummary.Time_To = dataMQC.GetMaxTimeProductionOfProduct(ListItemsData[0][0].model, from, to);

                foreach (var itemData in ListItemsData)
                {
                    itemSummary.product = itemData[0].model;
                    itemSummary.Line = itemData[0].line;
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
                itemSummary.QuantityTotal = itemSummary.OutputQty + itemSummary.NGQty+ itemSummary.ReworkQty;
                itemSummary.DefectRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.NGQty / itemSummary.QuantityTotal) : 0;
                itemSummary.ReworkRate = (itemSummary.QuantityTotal != 0) ? (itemSummary.ReworkQty / itemSummary.QuantityTotal) : 0;
                

            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "GetMQCItemSummaries(DateTime from, DateTime to, string site, string process)", ex.Message);
            }
            return itemSummary;
        }
        public List<MQCItemSummary> GetMQCItemSummariesFromTo(DateTime from, DateTime to, string site, string process)
        {

            List<MQCItemSummary> qCItemSummaries = new List<MQCItemSummary>();

            try
            {
                LoadDataMQC dataMQC = new LoadDataMQC();
                List<MQCDataItems> mQCDataItems = dataMQC.listMQCDataItemsbySite(from, to, site, process);
                //Nhom theo san pham
                var ListMQCbyProduct = mQCDataItems
                    .OrderBy(d => d.line)
                     .GroupBy(u => u.model)
                     .Select(grp => grp.ToList())
                    .ToList();
                foreach (var qCDataItems in ListMQCbyProduct)
                {
                    MQCItemSummary itemSummary = new MQCItemSummary();
                    itemSummary.product = qCDataItems[0].model;
                    itemSummary.defectItems = new List<DefectItem>();
                    itemSummary.ReworkItems = new List<DefectItem>();
                    var ListItemsData = qCDataItems
                 .GroupBy(u => u.item)
                 .Select(grp => grp.ToList())
                .ToList();


                    itemSummary.Time_from = dataMQC.GetMinTimeProductionOfProduct(itemSummary.product, from, to);
                    itemSummary.Time_To = dataMQC.GetMaxTimeProductionOfProduct(itemSummary.product, from, to);
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
                            LoadDefectMapping defectMapping = new LoadDefectMapping();
                            NGItemsMapping nGItemsMapping = defectMapping.GetNGMapping(site, process, item.DefectCode.Replace("RW","NG"));
                            item.DefectSFT = nGItemsMapping.NGCode_SFT;
                            item.DefectSFTName = nGItemsMapping.NGCodeName_SFT;
                            itemSummary.ReworkItems.Add(item);
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

    }
}
