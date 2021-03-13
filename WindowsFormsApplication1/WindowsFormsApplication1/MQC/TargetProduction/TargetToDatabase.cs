using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1.MQC.TargetProduction
{
  public  class TargetToDatabase
    {

        public List<targetItems> GetDataTarget ()
        {
            List<targetItems> targetItems = new List<targetItems>();


            return targetItems;
        }
        public bool InsertTargetData2DB (ref DataGridView dt)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                StringBuilder sql = new StringBuilder();

            }
            return true;
        }
    }
    public class targetItems
    {
        public string Dept { get; set; }
        public string Product { get; set; }
        public string Creater { get; set; }
        public DateTime Cre_Date { get; set; }
        public string Modifier { get; set; }
        public DateTime Modi_Date { get; set; }
        public DateTime Apply_Date { get; set; }
        public DateTime Expire_Date { get; set; }
        public string targetType { get; set; }
        public string Flag { get; set; }
        public string TA01 { get; set; }
        public string TA02 { get; set; }
        public string TA03 { get; set; }
        public string TA04 { get; set; }
        public string TA05 { get; set; }
        public string TA06 { get; set; }
        public string TA07 { get; set; }
        public string TA08 { get; set; }
        public string TA09 { get; set; }
        public string TA10 { get; set; }
        public string TA11 { get; set; }
        public string TA12 { get; set; }

    }
}
