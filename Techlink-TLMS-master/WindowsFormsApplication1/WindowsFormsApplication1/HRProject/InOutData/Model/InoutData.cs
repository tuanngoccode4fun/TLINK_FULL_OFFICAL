using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.HRProject.InOutData.Model
{
  public  class InoutData
    {
        public string EmpID { get; set; }
        public string EmpCode { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string CardNo { get; set; }
        public DateTime FDateTime { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public string InOut { get; set; }
        public string MachNo { get; set; }
        public string Shift { get; set; }

    }
}
