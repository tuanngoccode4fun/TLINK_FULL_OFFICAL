using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadDataToDatabase.AttendancReport.Model
{

    public class AttendanceDept
    {
        public string BigDeptCode { get; set; }
        public string BigDeptName { get; set; }
        public string DetailDeptCode { get; set; }
        public string DetailDeptName { get; set; }
        public int EmployeeOfDept { get; set; }
        public string Position { get; set; }
        public string HeadDept { get; set; }
        public int SeannWorkerDayNotID { get; set; }
        public int SeannWorkerNightNotID { get; set; }
        public WorkingState DayShift { get; set; }
        public WorkingState NightShift { get; set; }
        public WorkingState SeasonWorkerDay { get; set; }
        public WorkingState SeasonWorkerNight { get; set; }
        public int TotalEmployeesInCompany { get; set; }
        public WorkerType LocalWorker { get; set; }
        public WorkerType ChineseWorker { get; set; }
        public WorkingState Oursource { get; set; }
    }
    public class WorkingState
    {
        public int attendance { get; set; }
        public int attendanceActual { get; set; }
        public int absence { get; set; }
    }
    public class WorkerType
    {
        public int WorkerDirect { get; set; }
        public int WorkerIndirect { get; set; }
        public int TotalWorker { get; set; }
    }
    public class EmployeeAbsence
    {
        public string Dept { get; set; }
        public string DeptCode { get; set; }
        public string Manager { get; set; }
        public string Date { get; set; }
        public string Shift { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }

    }
    public class EmployeeAttendance
    {
        public string Dept { get; set; }
        public string DeptCode { get; set; }
        public string Manager { get; set; }
        public string Date { get; set; }
        public string Shift { get; set; }
        public string EmpCode { get; set; }
        public string EmpName { get; set; }

    }
}
