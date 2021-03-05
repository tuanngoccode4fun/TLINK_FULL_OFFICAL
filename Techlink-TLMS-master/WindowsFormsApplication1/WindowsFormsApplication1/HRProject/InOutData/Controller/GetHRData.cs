using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;

namespace WindowsFormsApplication1.HRProject.InOutData.Controller
{
   public class GetHRData
    {
        public List<Model.EmployeeData> GetEmployeeDatas(string code, string name, string dept, string sex, DateTime hireDate)
        {
           List< Model.EmployeeData> employeeDatas = new List<Model.EmployeeData>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  eml.ID as EmpID, eml.Code as EmpCode,eml.Name as Name,dept.LongName as Dept, 
case 
when Sex = 0 then 'Male'
when Sex = 1  then 'Female'
else 'Undified'
end as Sex, convert(char(10), PyDate, 103) as HireDate  from ZlEmployee eml
left join ZlDept dept on eml.Dept = dept.Code
where 1 = 1 and  State = 0 ");
                if (code != "")
                    stringBuilder.Append(" and eml.Code like '%" + code + "%'");
                if (name != "")
                    stringBuilder.Append(" and eml.Name like '%" + name + "%'");
                if(dept != "")
                    stringBuilder.Append(" and dept.LongName like '%" +dept + "%'");
                if(sex != "")
                    stringBuilder.Append(" and dept.LongName like '%" + sex + "%'");
                if (hireDate > DateTime.MinValue)
                    stringBuilder.Append(" and PyDate  >= '" + hireDate.ToString("yyyyMMdd") + "'");
                stringBuilder.Append(" order by EmpID ");
                DataTable dt = new DataTable();
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Model.EmployeeData employee = new Model.EmployeeData();
                    employee.EmpID = dt.Rows[i]["EmpID"].ToString();
                    employee.EmpCode = dt.Rows[i]["EmpCode"].ToString();
                    employee.Name = dt.Rows[i]["Name"].ToString();
                    employee.Dept = dt.Rows[i]["Dept"].ToString();
                    employee.Sex = dt.Rows[i]["Sex"].ToString();

                    employee.HiredDate = dt.Rows[i]["HireDate"].ToString();
                    employee.Status = "Working";
                    employeeDatas.Add(employee);
                }
               

            }
            catch (Exception ex)
            {

                throw;
                
            }
            return employeeDatas;
        }
        public List<Model.InoutData> GetInoutDatas(string State,string EmpCode, string Dept, DateTime from, DateTime to)
        {
            List<Model.InoutData> inoutDatas = new List<Model.InoutData>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  ISNULL(eml.ID,'') as EmpID, ISNULL(eml.Code,'') as EmpCode,ISNULL(eml.Name,'') as Name,ISNULL(dept.LongName,'') as Dept,ISNULL(InO.CardNo,'') as CardNo,
FDateTime,convert(char(10), FDateTime, 103) as Date,
convert(char(5), FDateTime, 108) as Time,
case 
when (convert(char(5), FDateTime, 108) >'07:00' and convert(char(5), FDateTime, 108) < '15:00' ) then 'In-Time' 
when (convert(char(5), FDateTime, 108) > '15:00' and convert(char(5), FDateTime, 108) < '23:99' ) then 'Out-Time'
else 'Undified'
end as 'InOut',
MachNo
from ZlEmployee eml
right join ZlDept dept on eml.Dept = dept.Code
right join Kq_Source InO on InO.EmpID = eml.ID
where 1=1 and (MachNo != '03'  and MachNo !='10') 
");
                if (State != "")
                    stringBuilder.Append(" and State = '"+ State + "'");
                if(EmpCode !="")
                    stringBuilder.Append(" and eml.Code like '%" + EmpCode + "%'");
                if (Dept != "")
                    stringBuilder.Append(" and dept.LongName = '" +Dept + "'");
                stringBuilder.Append(" and CONVERT(date, FDateTime) >= '" + from.Date.ToString("yyyyMMdd") + "'");
                stringBuilder.Append(" and CONVERT(date, FDateTime) <= '" + to.Date.ToString("yyyyMMdd") + "'");
                stringBuilder.Append(" order by eml.ID, FDateTime ");
                SqlHR sqlHR = new SqlHR();
                DataTable dt = new DataTable();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    Model.InoutData inout = new Model.InoutData();
                    inout.EmpID = dt.Rows[i]["EmpID"].ToString();
                    inout.EmpCode = dt.Rows[i]["EmpCode"].ToString();
                    inout.Name = dt.Rows[i]["Name"].ToString();
                    inout.Dept = dt.Rows[i]["Dept"].ToString();
                    inout.CardNo = dt.Rows[i]["CardNo"].ToString();
                    inout.FDateTime = (DateTime) dt.Rows[i]["FDateTime"];
                    inout.Date = dt.Rows[i]["Date"].ToString();
                    inout.Time = dt.Rows[i]["Time"].ToString();
                    inout.InOut = dt.Rows[i]["InOut"].ToString();
                    inout.MachNo = dt.Rows[i]["MachNo"].ToString();
                    inoutDatas.Add(inout);
                }

            }
            catch (Exception)
            {

                throw;
            }
            return inoutDatas;
        }
        public DataTable GetDataTableGanCong(string DateTime, string Dept, string Code)
        {
            DataTable dt = new DataTable();
            try
            {
              
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select b.Memo,b.AllDays,e.Code,e.Name,t.LongName,t.Note, a.* from dbo.Kq_PaiBan a
left join S_Session b on a.SessionID = b.ID 
left join ZlEmployee e on a.EmpID = e.ID
left join ZlDept t on e.Dept = t.Code
where 1=1 
");
                stringBuilder.Append(" and b.Memo like '%" + DateTime + "%'");
                if(Dept !="")
                    stringBuilder.Append(" and t.LongName like '%" + Dept + "%'");
                if (Code != "")
                    stringBuilder.Append(" and e.Code like '%" + Code + "%'");
                stringBuilder.Append(" order by e.Code ");
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }

        public Dictionary<string, Model.MonthInOut> GetKeyValuePairsInOut (List<Model.InoutData> inoutDatas,string YearMonth)
        {
            Dictionary<string, Model.MonthInOut> keyValuePairs = new Dictionary<string, Model.MonthInOut>();
            try
            {
                var listCode = inoutDatas.Select(d => d.EmpCode).Distinct().ToList();
                foreach (var code in listCode)
                {
                    Model.MonthInOut monthInOut = new Model.MonthInOut();
                    monthInOut.EmpCode = code;
                    monthInOut.InData = new string[31];
                    monthInOut.OutData = new string[31];
                    monthInOut.WorkingTime= new double[31];
                    monthInOut.InOutEvaluation = new string[31];
                    for (int i = 1; i <= 31; i++)
                    {
                        if (i <= 29)
                        {
                            DateTime DateTime = new DateTime(2020, 2, i);
                            var rows = inoutDatas.Where(d => d.EmpCode == code && d.Date == DateTime.Date.ToString("dd/MM/yyyy")).ToList();
                            if (rows.Count > 0)
                            {
                                var MaxInTime = rows.Where(d => d.InOut == "In-Time").ToList();
                                if (MaxInTime.Count > 0)
                                {
                                    monthInOut.InData[i - 1] = MaxInTime.Min(d => d.Time);
                                    var Timespan = TimeSpan.ParseExact(monthInOut.InData[i - 1], "h\\:mm", CultureInfo.CurrentCulture);
                                    //if (Timespan > new TimeSpan(8, 0, 0))
                                    //    monthInOut.InOutEvaluation[i - 1] = "In Late ";
                                }
                                else monthInOut.InData[i - 1] = "";
                                var MaxOutTime = rows.Where(d => d.InOut == "Out-Time").ToList();
                                if (MaxOutTime.Count > 0)

                                {
                                    monthInOut.OutData[i - 1] = MaxOutTime.Max(d => d.Time);
                                    var Timespan = TimeSpan.ParseExact(monthInOut.OutData[i - 1], "h\\:mm", CultureInfo.CurrentCulture);
                                    //if (Timespan < new TimeSpan(17, 0, 0))
                                    //    monthInOut.InOutEvaluation[i - 1] += "Out Early ";
                                }
                                else monthInOut.OutData[i - 1] = "";
                            }
                            string GanCong = GanCongMa(code, YearMonth, i);
                            monthInOut.WorkingTime[i - 1] = WorkingTimeCalculate(monthInOut.InData[i - 1], monthInOut.OutData[i - 1], DateTime, GanCong, out monthInOut.InOutEvaluation[i - 1]);
                        }
                        else
                        {
                            monthInOut.InData[i - 1] = "";
                            monthInOut.OutData[i - 1] = "";
                            monthInOut.InOutEvaluation[i - 1] = " ";
                        }
                     
                    }
                    keyValuePairs.Add(code, monthInOut);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return keyValuePairs;
        }
        public double WorkingTimeCalculate(string InTime, string OutTime,DateTime workingDay, string GanCong, out string Status )
        {
            double WorkingTime = 0;
            if(InTime == null || InTime =="")
            {
                Status = "[abnormal-In]";
                return 0;
            }
            if (OutTime == null || OutTime == "")
            {
                Status = "[abnormal-Out]";
                return 0;
            }
            TimeSpan hourIn = TimeSpan.ParseExact(InTime, "h\\:mm", CultureInfo.CurrentCulture);
            TimeSpan hourOut = TimeSpan.ParseExact(OutTime, "h\\:mm", CultureInfo.CurrentCulture);
            TimeSpan HourIntarget = new TimeSpan(); DateTime DateInTarget = new DateTime();
            TimeSpan HourOutTarget = new TimeSpan();DateTime DateOutTarget = new DateTime();
            DataTable dt = new DataTable();
            string sqlQuery = " select * from WorkingSetting where id = '" + GanCong + "'";
            SqlHR sqlHR = new SqlHR();
            sqlHR.sqlDataAdapterFillDatatable(sqlQuery, ref dt);
            string tam = "";
            if (dt.Rows.Count == 1)
            {


                if (dt.Rows[0]["InTime"].ToString().Contains("T") == false)
                {
                    HourIntarget = TimeSpan.ParseExact(dt.Rows[0]["InTime"].ToString().Trim(), "h\\:mm", CultureInfo.CurrentCulture);
                    DateInTarget = workingDay;

                }
                else
                {
                    HourIntarget = TimeSpan.ParseExact(dt.Rows[0]["InTime"].ToString().Trim().Substring(1), "h\\:mm", CultureInfo.CurrentCulture);
                    DateInTarget = workingDay.AddDays(1);
                }
                if (dt.Rows[0]["OutTime"].ToString().Contains("T") == false)
                {
                   HourOutTarget = TimeSpan.ParseExact(dt.Rows[0]["OutTime"].ToString().Trim(), "h\\:mm", CultureInfo.CurrentCulture);
                    DateOutTarget = workingDay;
                }
                else
                {
                    HourOutTarget = TimeSpan.ParseExact(dt.Rows[0]["OutTime"].ToString().Trim().Substring(1), "h\\:mm", CultureInfo.CurrentCulture);
                    DateOutTarget = workingDay.AddDays(1);
                }
            }
            string massage = "";
           if(hourIn <= HourIntarget && hourOut >= HourOutTarget)
            {
                massage += "[Normal]";
                WorkingTime =( HourOutTarget - HourIntarget).Add(- new TimeSpan(1,0,0)).TotalHours;
                WorkingTime = Math.Round(WorkingTime, 1);
            }
            if (hourIn > HourIntarget)
            {
                massage += "[In-Late]";
                if(hourIn <= new TimeSpan(12,0,0))
                WorkingTime = (HourOutTarget - hourIn).Add(-new TimeSpan(1, 0, 0)).TotalHours;
                else
                    WorkingTime = (HourOutTarget - hourIn).TotalHours;
                WorkingTime = Math.Round(WorkingTime, 1);
            }
            if (hourOut < HourOutTarget)
            {
                massage += "[Out-Early]";
                WorkingTime = (hourOut - HourIntarget).Add(-new TimeSpan(1, 0, 0)).TotalHours;
                WorkingTime = Math.Round(WorkingTime, 1);
            }
            if(hourOut< HourOutTarget && hourIn < HourIntarget)
            {
                WorkingTime = (hourOut - hourIn).Add(-new TimeSpan(1, 0, 0)).TotalHours;
                WorkingTime = Math.Round(WorkingTime, 1);
            }
            Status = massage;
            return WorkingTime;
        }
        public string GanCongMa (string code, string YearMonth, int Date)
        {
            string GanCong = "";
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select B" + Date.ToString());
                stringBuilder.Append(@" from dbo.Kq_PaiBan a
left join S_Session b on a.SessionID = b.ID 
left join ZlEmployee e on a.EmpID = e.ID
where 1=1 ");
                stringBuilder.Append(" and e.Code ='" + code +"'");
                stringBuilder.Append(" and b.Memo like '%" + YearMonth + "%'");
                SqlHR sqlHR = new SqlHR();
                GanCong = sqlHR.sqlExecuteScalarString(stringBuilder.ToString());
                if(GanCong !="")
                {
                    GanCong = GanCong.Trim();
                }


            }
            catch (Exception)
            {

                throw;
            }
            return GanCong;
        }
    }
}
