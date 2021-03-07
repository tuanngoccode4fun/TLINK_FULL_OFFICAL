using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadDataToDatabase.HR_Audit
{
 public   class SpecialList
    {
        public string No { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public string status { get; set; }

    }
    public class FingerData
    {
        public string Dept { get; set; }
        public string ID { get; set; }
        public string Name { get; set; }
        public string DateTime { get; set; }
        public string unkownG { get; set; }
        public string unkownH { get; set; }
        public string TimeIn { get; set; }
        public string TimeOut { get; set; }
        public string DayWorkingTime { get; set; }
        public string NightWorkingTime { get; set; }
        public string AproveTimeabsent { get; set; }

    }
    public class WorkingTimeData
    {   public string month { get; set; }
        public string ngay { get; set; }

        public string workingHour { get; set; }
        public string Shift { get; set; }
    }
    public class  WorkingDateData
    {
        public string dept { get; set; }
        public string ID { get; set; }
        public string Name { get; set;}
        public string col_Dept { get; set; }
        public string col_date { get; set; }
     public   List<WorkingTimeData> WorkingTimeDatas { get; set; }

    }
    public class m_workingData
    {
        public string  ID { get; set; }
        public string Name { get; set; }
        public string Dept { get; set; }
        public string Year { get; set; }
        public string Month { get; set; }
        public string Shift { get; set; }
        public string N1 { get; set; }
        public string N2 { get; set; }
        public string N3 { get; set; }
        public string N4 { get; set; }
        public string N5 { get; set; }
        public string N6 { get; set; }
        public string N7 { get; set; }
        public string N8 { get; set; }
        public string N9 { get; set; }
        public string N10 { get; set; }
        public string N11 { get; set; }
        public string N12 { get; set; }
        public string N13 { get; set; }
        public string N14 { get; set; }
        public string N15 { get; set; }
        public string N16 { get; set; }
        public string N17 { get; set; }
        public string N18 { get; set; }
        public string N19 { get; set; }
        public string N20 { get; set; }
        public string N21 { get; set; }
        public string N22 { get; set; }
        public string N23 { get; set; }
        public string N24 { get; set; }
        public string N25 { get; set; }
        public string N26 { get; set; }
        public string N27 { get; set; }
        public string N28 { get; set; }
        public string N29 { get; set; }
        public string N30 { get; set; }
        public string N31 { get; set; }
    }
    public class auditItem
    {
        public string ID { get; set; }
        public string Ca { get; set; }
        public string Ngay { get; set; }
        public string Finger { get; set; }
        public string Working { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
    }
    public class AuditInOut
    {
        public string ID { get; set; }
        public DateTime TimeIn { get; set; }
       public DateTime TimeOut { get; set; }
        public string Status { get; set; }
    }

}
