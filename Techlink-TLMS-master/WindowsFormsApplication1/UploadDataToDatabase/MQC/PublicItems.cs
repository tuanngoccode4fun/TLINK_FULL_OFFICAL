using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadDataToDatabase.MQC
{
    class PublicItems
    {
    }
    public class MQCItem1
    {
        public string department { get; set; }
        public string process { get; set; }
        public string product { get; set; }
        public string PO { get; set; }
        public double TotalOutput { get; set; }
        public double InputSFT { get; set; }
        public double InputMaterialNotYet { get; set; }
        public double TotalNG { get; set; }
        public double percentNG { get; set; }
        public double TotalRework { get; set; }
        public double percentRework { get; set; }
        public TargetMQC TargetMQC { get; set; }
        public List<NGItems> listNGItems { get; set; }
        public List<NGItems> listRWItems { get; set; }
        public string Status { get; set; }
        public string Measage { get; set; }

    }
    public class NGItems
    {
        public string NGKey { get; set; }
        public string NGName { get; set; }
        public string NGType { get; set; }
        public double NGQuantity { get; set; }
    }
    public class NGItemsMapping
    {
        public string Department { get; set; }
        public string NGCode_Process { get; set; }
        public string NGCodeName_Process { get; set; }
        public string NGCode_SFT { get; set; }
        public string NGCodeName_SFT { get; set; }
        public int Note { get; set; }
    }
    public class MQCDataItems
    {
        public string serno { get; set; }
        public string lot { get; set; }
        public string model { get; set; }
        public string site { get; set; }
        public string factory { get; set; }
        public string line { get; set; }
        public string process { get; set; }
        public string item { get; set; }
        public DateTime inspectdate { get; set; }
        public TimeSpan inspecttime { get; set; }
        public double data { get; set; }
        public string judge { get; set; }
        public string status { get; set; }
        public string remark { get; set; }
    }

    public class MQCItemSummary
    {
        public string product { get; set; }
        public string Time_from { get; set; }
        public string Time_To { get; set; }
        public double QuantityTotal { get; set; }
        public double OutputQty { get; set; }
        public double NGQty { get; set; }
        public double DefectRate { get; set; }
        public string Remark { get; set; }
        public string Lot { get; set; }
        public List<DefectItem> defectItems { get; set; }

    }

    public class DefectItem
    {
        public string DefectCode { get; set; }
        public string DefectSFT { get; set; }
        public string DefectSFTName { get; set; }
        public double Quantity { get; set; }
        public int Note { get; set; }
    }
    public class TargetMQC
    {
        public string model { get; set; }
        public string Date { get; set; }
        public int month { get; set; }
        public int year { get; set; }
        public double TargetOutput { get; set; }
        public double TargetDefect { get; set; }
    }
    public class DefectRateData
    {
        public string DateTime_from { get; set; }
        public string DateTime_to { get; set; }
        public string Product { get; set; }
        public string Lot { get; set; }
        public double TotalQuantity { get; set; }
        public double OutputQuantity { get; set; }
        public double DefectQuantity { get; set; }
        public double DefectRate { get; set; }
        public List<DefectItem> defectItems { get; set; }//top 5 + khac
        public TargetMQC TargetMQC { get; set; }

    }
}
