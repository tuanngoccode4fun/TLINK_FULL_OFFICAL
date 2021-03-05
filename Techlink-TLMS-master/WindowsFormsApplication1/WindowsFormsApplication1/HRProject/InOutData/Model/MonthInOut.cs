using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.HRProject.InOutData.Model
{
  public  class MonthInOut
    {   public string EmpCode { get; set; }
        public string Name { get; set; }
        public string dept { get; set; }
        public string Session { get; set; }
        public string YearMonth { get; set; }
        public string [] InData { get; set; }
        public string[] OutData { get; set; }
        public double [] WorkingTime { get; set; }
        public string[] Shift { get; set; }
        public string []InOutEvaluation { get; set; }
        
    }
   
}
