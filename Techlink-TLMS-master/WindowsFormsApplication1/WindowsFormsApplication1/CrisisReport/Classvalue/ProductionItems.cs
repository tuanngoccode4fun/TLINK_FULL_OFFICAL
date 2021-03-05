using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.CrisisReport.Classvalue
{
    class ProductionItems
    {
        public DateTime Date { get; set; }
        public TimeSpan Time { get; set; }
        public string Dept { get; set; }
        public string ProductionCode { get; set; }
        public double OutputTarget { get; set; }
        public double ActualOutput { get; set; }
        public double ActualDefectQty { get; set; }
        public double ScrapTargetRate { get; set; }
        public double ScrapActualtRate { get; set; }

    }
    class ProductionSummary
    {
       
        public string Dept { get; set; }
        public string ProductionCode { get; set; }
        public double OutputTarget { get; set; }
        public double ActualOutput { get; set; }
        public string QuantityEvaluation { get; set; }
        public double ActualDefectQty { get; set; }
        public double ScrapTargetRate { get; set; }
        public double ScrapActualtRate { get; set; }
        public string QualityEvaluation { get; set; }
    }
}
