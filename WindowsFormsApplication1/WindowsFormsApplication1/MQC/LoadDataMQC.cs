using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace WindowsFormsApplication1.MQC
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
            listMQC= listMQCDataItems(from, to, model, lot, process);
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
                mQCItem.line = listMQC[0].line;
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
            listMQC_Error = listMQCData_ErrorItems(from, to, model, lot, process);
            mQCItem.InputMaterialNotYet = listMQC_Error.Where(w =>w.remark == "OP" || w.remark == "NG").Select(d=>d.data).ToArray().Sum();
                double targetDefect = 0;
                if (mQCItem.TargetMQC.TargetOutput != 0)
                {
                   targetDefect = (mQCItem.TargetMQC.TargetDefect / (mQCItem.TargetMQC.TargetDefect + mQCItem.TargetMQC.TargetOutput));
                }
               
                if (mQCItem.InputMaterialNotYet > 0)
                {
                    mQCItem.Status = ProductionStatus.ShortageMaterial.ToString();
                    mQCItem.Measage = "SHORTAGE MATERIAL";
                }
                else if (mQCItem.percentNG > targetDefect && targetDefect >0)
                {
                    mQCItem.Status = ProductionStatus.HighDefect.ToString();
                    mQCItem.Measage = "HIGH DEFECT";
                }
                else
                {
                    mQCItem.Status = ProductionStatus.Normal.ToString();
                }
                    mQCItem.InputSFT =( mQCItem.TotalOutput+mQCItem.TotalNG) - mQCItem.InputMaterialNotYet;
            }
            catch (Exception ex)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetQCCItemOK", ex.Message);
            }
            // sql.Append()
            return mQCItem;
            
        }

        public MQCItem1 GetQCCItemLineLot(DateTime from, DateTime to, string line,string model, string lot, string process)
        {
            MQCItem1 mQCItem = new MQCItem1();
            try
            {


                LoadDefectMapping defectMapping = new LoadDefectMapping();
                List<NGItemsMapping> nGItemsMappings = defectMapping.listNGMapping("B01", "MQC");
                mQCItem.TargetMQC = new TargetMQC();
                LoadTargetProduction loadTarget = new LoadTargetProduction();
                mQCItem.TargetMQC = loadTarget.GetTargetMQC(model, DateTime.Now.Date.ToString("yyyyMMdd"));
                List<MQCDataItems> listMQC = new List<MQCDataItems>();
                listMQC = listMQCDataItemsLineLot(from, to, line, lot, process);
                //Load MQCItem to show
                mQCItem.process = process;
                mQCItem.department = "B01";
                mQCItem.product = model;

                mQCItem.PO = (listMQC != null && listMQC.Count > 0) ? listMQC[0].lot : "";
                var TotalOutputQty = listMQC
                    .Where(d => d.remark == "OP")
                    .Select((s => s.data))
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
                mQCItem.TotalRework = TotalRework.Sum();
                mQCItem.percentNG = (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) != 0 ? mQCItem.TotalNG / (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) : 0;
                mQCItem.percentRework = (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) != 0 ? mQCItem.TotalRework / (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) : 0;
                var listNGItem = listMQC
                 .Where(d => d.remark == "NG")
                 .Select((s => new { s.item, s.data }))
                 .ToList();
                mQCItem.listNGItems = new List<NGItems>();
                mQCItem.line = listMQC[0].line;
                foreach (var item in listNGItem)
                {
                    NGItems nGItems = new NGItems();
                    var _NG_SFT = nGItemsMappings.Where(d => d.NGCode_Process == item.item).Select(s => s.NGCode_SFT).ToArray();
                    string NG_SFT = (_NG_SFT != null && _NG_SFT.Count() > 0) ? _NG_SFT[0] : "";
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
                listMQC_Error = listMQCData_ErrorItems(from, to, model, lot, process);
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
                    mQCItem.Measage = "Defect is so high";
                }
                else
                {
                    mQCItem.Status = ProductionStatus.Normal.ToString();
                }
                mQCItem.InputSFT = (mQCItem.TotalOutput + mQCItem.TotalNG) - mQCItem.InputMaterialNotYet;
            }
            catch (Exception ex)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetQCCItemOK", ex.Message);
            }
            // sql.Append()
            return mQCItem;

        }
        public MQCItem1 GetQCCItembyline(DateTime from, DateTime to, string model, string lot, string site, string process)
        {
            MQCItem1 mQCItem = new MQCItem1();
            try
            {

                LoadDefectMapping defectMapping = new LoadDefectMapping();
                List<NGItemsMapping> nGItemsMappings = defectMapping.listNGMapping("B01", "MQC");
                mQCItem.TargetMQC = new TargetMQC();
                LoadTargetProduction loadTarget = new LoadTargetProduction();
                mQCItem.TargetMQC = loadTarget.GetTargetMQC(model, DateTime.Now.Date.ToString("yyyyMMdd"));
                List<MQCDataItems> listMQC = new List<MQCDataItems>();
                listMQC = listMQCDataItems(from, to, model, lot, process);
                //Load MQCItem to show
                mQCItem.process = process;
                mQCItem.department = site;
                mQCItem.product = model;

                mQCItem.PO = (listMQC != null && listMQC.Count > 0) ? listMQC[0].lot : "";
                var TotalOutputQty = listMQC
                    .Where(d => d.remark == "OP")
                    .Select((s => s.data))
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
                mQCItem.TotalRework = TotalRework.Sum();
                mQCItem.percentNG = (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) != 0 ? mQCItem.TotalNG / (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) : 0;
                mQCItem.percentRework = (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) != 0 ? mQCItem.TotalRework / (mQCItem.TotalOutput + mQCItem.TotalNG + mQCItem.TotalRework) : 0;
                var listNGItem = listMQC
                 .Where(d => d.remark == "NG")
                 .Select((s => new { s.item, s.data }))
                 .ToList();
                mQCItem.listNGItems = new List<NGItems>();
                mQCItem.line = listMQC[0].line;
                foreach (var item in listNGItem)
                {
                    NGItems nGItems = new NGItems();
                    var _NG_SFT = nGItemsMappings.Where(d => d.NGCode_Process == item.item).Select(s => s.NGCode_SFT).ToArray();
                    string NG_SFT = (_NG_SFT != null && _NG_SFT.Count() > 0) ? _NG_SFT[0] : "";
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
                listMQC_Error = listMQCData_ErrorItems(from, to, model, lot, process);
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
                    mQCItem.Measage = "Defect is so high";
                }
                else
                {
                    mQCItem.Status = ProductionStatus.Normal.ToString();
                }
                mQCItem.InputSFT = (mQCItem.TotalOutput + mQCItem.TotalNG) - mQCItem.InputMaterialNotYet;
            }
            catch (Exception ex)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetQCCItemOK", ex.Message);
            }
            // sql.Append()
            return mQCItem;

        }
        public List<MQCItem1> listMQCItemsOfDept(DateTime from, DateTime to,  string site, string process)
        {
            List<MQCItem1> listMQCReturn = new List<MQCItem1>();
            try
            {

           
            List<MQCDataItems> listMQC = new List<MQCDataItems>();
            listMQC = listMQCDataItemsbySite(from, to, site, process);
                //var maxdate = listMQC.Select(d => d.inspectdate).Max();
                //var maxTime = listMQC.Where(d => d.inspectdate == maxdate).Select(d => d.inspecttime).Max();
                //var Maxdatetime = maxdate + maxTime;
            var ListItems = listMQC
    .GroupBy(u => u.lot)
    .Select(grp => grp.ToList())
    .ToList();

            foreach (var mQCDatas in ListItems)
            {
                MQCItem1 mQCItem = new MQCItem1();

                mQCItem.process = process;
                mQCItem.department = site;
                mQCItem.product = mQCDatas[mQCDatas.Count-1].model;
                mQCItem.PO = mQCDatas[mQCDatas.Count - 1].lot;
                    var maxdate = mQCDatas.Select(d => d.inspectdate).Max();
                    var maxTime = mQCDatas.Where(d => d.inspectdate == maxdate).Select(d => d.inspecttime).Max();
                    var Maxdatetime = maxdate + maxTime;
                    mQCItem.DateRun = Maxdatetime;
                    mQCItem.line = mQCDatas[mQCDatas.Count - 1].line;
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
                    listMQC_Error = listMQCData_ErrorItems(from, to, mQCItem.product, mQCItem.PO, process);
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

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "listMQCItemsOfDept()", ex.Message);
            }
            return listMQCReturn;

        }
        public List<MQCItem1> listMQCItemsOfLine(DateTime from, DateTime to, string line, string process)
        {
            List<MQCItem1> listMQCReturn = new List<MQCItem1>();
            try
            {


                List<MQCDataItems> listMQC = new List<MQCDataItems>();
                listMQC = listMQCDataItemsbyLine(from, to, line, process);
                //var maxdate = listMQC.Select(d => d.inspectdate).Max();
                //var maxTime = listMQC.Where(d => d.inspectdate == maxdate).Select(d => d.inspecttime).Max();
                //var Maxdatetime = maxdate + maxTime;
                var ListItems = listMQC
        .GroupBy(u => u.lot)
        .Select(grp => grp.ToList())
        .ToList();
                int STT = 0;
                foreach (var mQCDatas in ListItems)
                {
                    MQCItem1 mQCItem = new MQCItem1();
                    mQCItem.STTRun = STT;
                    mQCItem.process = process;
                    mQCItem.department = "B01";
                    mQCItem.line = line;
                    mQCItem.product = mQCDatas[mQCDatas.Count - 1].model;
                    mQCItem.PO = mQCDatas[mQCDatas.Count - 1].lot;
                    var maxdate = mQCDatas.Select(d => d.inspectdate).Max();
                    var maxTime = mQCDatas.Where(d => d.inspectdate == maxdate).Select(d => d.inspecttime).Max();
                    var Maxdatetime = maxdate + maxTime;
                    mQCItem.DateRun = Maxdatetime;
                 //   mQCItem.line = mQCDatas[mQCDatas.Count - 1].line;
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
                    listMQC_Error = listMQCData_ErrorItems(from, to, mQCItem.product, mQCItem.PO, process);
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
                    STT++;
                }

            }
            catch (Exception ex)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "listMQCItemsOfDept()", ex.Message);
            }
            return listMQCReturn;

        }
        public List<MQCDataItems> listMQCDataItems(DateTime from, DateTime to, string model,string lot, string process)
        {
            List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
            try
            {

            StringBuilder sql = new StringBuilder();
            sql.Append("select distinct serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, status, remark ");
            sql.Append("from m_ERPMQC_REALTIME ");
            sql.Append("where 1=1   ");
            sql.Append("and model = '" + model + "' ");
            sql.Append("and lot = '" + lot + "' ");
            sql.Append("and process = '" + process + "' ");
                //  sql.Append("and inspectdate >= '" + from.ToString("yyyy-MM-dd") + "' ");
                //  sql.Append("and inspecttime >= '" + from.ToString("hh:mm:ss") + "' ");
                //  sql.Append("and inspectdate <= '" + to.ToString("yyyy-MM-dd") + "' ");
                ////  sql.Append("and inspecttime <= '" + to.ToString("hh:mm:ss") + "' ");
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
                               inspectdate =(dr["inspectdate"].ToString() != "")?  DateTime.Parse (dr["inspectdate"].ToString()): DateTime.MinValue,
                               inspecttime =(dr["inspecttime"].ToString() != "")?  TimeSpan.Parse(dr["inspecttime"].ToString()) : TimeSpan.MinValue,
                               data =(dr["data"].ToString() != "") ? double.Parse( dr["data"].ToString()): 0,
                               judge = dr["judge"].ToString(),
                               status = dr["status"].ToString(),
                               remark = dr["remark"].ToString()

                           }).ToList();
            }
            catch (Exception ex)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "listMQCDataItems()", ex.Message);
            }
            return listMQCDataItems;
        }
        public List<MQCDataItems> listMQCDataItemsLineLot(DateTime from, DateTime to, string line, string lot, string process)
        {
            List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
            try
            {

                StringBuilder sql = new StringBuilder();
                sql.Append("select distinct serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, status, remark ");
                sql.Append("from m_ERPMQC_REALTIME ");
                sql.Append("where 1=1   ");
                sql.Append("and line = '" + line + "' ");
                sql.Append("and lot = '" + lot + "' ");
                sql.Append("and process = '" + process + "' ");
                //sql.Append("and inspectdate >= '" + from.ToString("yyyy-MM-dd") + "' ");
                //sql.Append("and inspecttime >= '" + from.ToString("hh:mm:ss") + "' ");
                //sql.Append("and inspectdate <= '" + to.ToString("yyyy-MM-dd") + "' ");
                //  sql.Append("and inspecttime <= '" + to.ToString("hh:mm:ss") + "' ");
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

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "listMQCDataItems()", ex.Message);
            }
            return listMQCDataItems;
        }

        public List<MQCDataItems> listMQCDataItemsbyLine(DateTime from, DateTime to, string line, string process)
        {
            List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
            try
            {

                StringBuilder sql = new StringBuilder();
                sql.Append("select distinct serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, status, remark ");
                sql.Append("from m_ERPMQC_REALTIME ");
                sql.Append("where 1=1   ");
                sql.Append("and line = '" + line + "' ");
                sql.Append("and process = '" + process + "' ");
                //sql.Append("and inspectdate >= '" + from.ToString("yyyy-MM-dd") + "' ");
                //sql.Append("and inspecttime >= '" + from.ToString("hh:mm:ss") + "' ");
                //sql.Append("and inspectdate <= '" + to.ToString("yyyy-MM-dd") + "' ");
                //  sql.Append("and inspecttime <= '" + to.ToString("hh:mm:ss") + "' ");
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

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "listMQCDataItems()", ex.Message);
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
                sql.Append("where 1=1 and data != '0'   ");
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

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "listMQCDataItemsbySite()", ex.Message);
            }

            return listMQCDataItems;
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
            var time =  DateTime.Parse( sql12.sqlExecuteScalarString(stringBuilder.ToString()));
            return time.ToString("dd-MM-yyyy HH:mm");

        }
        public string GetMinTimeProductionOfProduct(string model,DateTime from, DateTime to)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"select min(cast(inspectdate as datetime) + CAST (inspecttime as datetime)) from m_ERPMQC_REALTIME
where 1=1 and data != '0'   and site = 'B01' and process = 'MQC' 
");
            stringBuilder.Append(" and cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '" + from.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            stringBuilder.Append(" and cast(inspectdate as datetime) + CAST (inspecttime as datetime) <= '" + to.ToString("yyyy-MM-dd HH:mm:ss") + "'");
            stringBuilder.Append(" and model = '" + model + "' ");
            sqlCON sql12 = new sqlCON();
            var time = DateTime.Parse(sql12.sqlExecuteScalarString(stringBuilder.ToString()));
            return time.ToString("dd-MM-yyyy HH:mm");
        }
        public List<MQCDataItems> listMQCDataItemsbyLine(DateTime from, DateTime to, string site, string process, string line)
        {
            List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
            try
            {


                //  List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
                StringBuilder sql = new StringBuilder();
                sql.Append("select distinct serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, status, remark ");
                sql.Append("from m_ERPMQC_REALTIME ");
                sql.Append("where 1=1  ");
                sql.Append("and site = '" + site + "' ");
                sql.Append("and process = '" + process + "' ");
                sql.Append("and line = '" + line + "' ");
                //sql.Append("and inspectdate >= '" + from.ToString("yyyy-MM-dd") + "' ");
                //sql.Append("and inspecttime >= '" + from.ToString("hh:mm:ss") + "' ");
                //sql.Append("and inspectdate <= '" + to.ToString("yyyy-MM-dd") + "' ");
                //     sql.Append("and inspecttime <= '" + to.ToString("hh:mm:ss") + "' ");
                //   sql.Append("order by inspectdate, inspectdate ");
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

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "listMQCDataItemsbySite()", ex.Message);
            }

            return listMQCDataItems;
        }
        public List<MQCDataItems> listMQCDataItemsbylot(DateTime from, DateTime to, string process, string lot)
        {
            List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
            try
            {


                //  List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
                StringBuilder sql = new StringBuilder();
                sql.Append("select distinct serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, status, remark ");
                sql.Append("from m_ERPMQC_REALTIME ");
                sql.Append("where 1=1 ");
                sql.Append("and process = '" + process + "' ");
                sql.Append("and lot = '" + lot + "' ");
                //sql.Append("and inspectdate >= '" + from.ToString("yyyy-MM-dd") + "' ");
                //sql.Append("and inspecttime >= '" + from.ToString("hh:mm:ss") + "' ");
                //sql.Append("and inspectdate <= '" + to.ToString("yyyy-MM-dd") + "' ");
                //    sql.Append("and inspecttime <= '" + to.ToString("hh:mm:ss") + "' ");
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

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "listMQCDataItemsbySite()", ex.Message);
            }

            return listMQCDataItems;
        }
        public List<MQCDataItems> listMQCData_ErrorItems(DateTime from, DateTime to, string model, string lot, string process)
        {
            List<MQCDataItems> listMQCDataItems = new List<MQCDataItems>();
            try
            {

          
            StringBuilder sql = new StringBuilder();
            sql.Append("select distinct serno, lot, model, site, factory, line, process, item, inspectdate, inspecttime, data, judge, status, remark ");
            sql.Append("from m_ERPMQC_Error ");
            sql.Append("where 1=1 and status !='OK' ");
            sql.Append("and model = '" + model + "' ");
            sql.Append("and lot = '" + lot + "' ");
             sql.Append("and process = '" + process + "' ");
                //sql.Append("and inspectdate >= '" + from.ToString("yyyy-MM-dd") + "' ");
                //sql.Append("and inspecttime >= '" + from.ToString("hh:mm:ss") + "' ");
                //sql.Append("and inspectdate <= '" + to.ToString("yyyy-MM-dd") + "' ");
                //    sql.Append("and inspecttime <= '" + to.ToString("hh:mm:ss") + "' ");\
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

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "listMQCData_ErrorItems()", ex.Message);
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
                //sql.Append(" and  inspectdate >= '" + from.ToString("yyyy-MM-dd") + "'  ");
                //sql.Append(" and  inspectdate <= '" + to.ToString("yyyy-MM-dd") + "'  ");
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

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "listMQCDataItemsbySite()", ex.Message);
            }

            return listMQCDataItems;
        }

        public DataTable  GetMQCDataFromLine(string line)
        {


            DataTable dt = new DataTable();
            try
            {
              
  
            string sqlQuerry = " select  distinct lot,model  from m_ERPMQC_REALTIME  where line = '" + line + "' and ";
sqlQuerry += " cast(inspectdate as datetime) + CAST(inspecttime as datetime) >= (select max(cast(inspectdate as datetime) + CAST(inspecttime as datetime)) from m_ERPMQC_REALTIME   where line ='" + line + "' )";
                sqlCON sqlCON = new sqlCON();
               sqlCON.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);
            }
            catch (Exception ex)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, " GetMQCDataFromLine(string line)", ex.Message);
                return null;
            }

            return dt;
          
        }
        public List<MQCDataItems> listMQCDataItemsbylot(DateTime from, TimeSpan time_from, DateTime to, TimeSpan time_to, string site, string process, string lot)
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
                //sql.Append("and inspectdate >= '" + from.ToString("yyyy-MM-dd") + "' ");
                //sql.Append("and inspectdate <= '" + to.ToString("yyyy-MM-dd") + "' ");
                //sql.Append("and inspecttime >= '" + time_from + "' ");
                //sql.Append("and inspecttime <= '" + time_to + "' ");
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

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "listMQCDataItemsbySite()", ex.Message);
            }

            return listMQCDataItems;
        }



    }
}
