using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WindowsFormsApplication1.HRProject.InOutData.Model;
using WindowsFormsApplication1.HRProject.InOutData.Controller.TimeWorking;

namespace WindowsFormsApplication1.HRProject.InOutData.Controller
{
   public class GetAttendanceHR
    {
        public DataTable  GetUpCodeDept()
        {
            DataTable dt = new DataTable();
            try
            {

                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select * from ZlDept where TreeLevel = 1 and Code not like '%999%' ");
              //  stringBuilder.Append(" select * from ZlDept where TreeLevel = 1 and Code not like '%888%' and Code not like '%666%' ");
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "DataTable  GetUpCodeDept()", ex.Message);
            }
            return dt;
        }
        public DataTable GetCountEmployeeByUpcode(string Upcode)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select  e.Dept, d.DeptDesc, d.LongName, d.UpCode,isnull(d.Note,'') as Note,isnull(d.Manager,'') as Manager, count (e.Code) as countEmployee  
from ZlEmployee e
left join ZlDept d on e.Dept = d.Code 
where   e.State =0 and e.Dept not like '%999%' ");
                stringBuilder.Append(" and  d.UpCode = '" + Upcode + "' ");
                stringBuilder.Append(" group by e.Dept, d.DeptDesc, d.LongName, d.UpCode, d.Note, d.Manager ");
                stringBuilder.Append(" order by e.Dept ");
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);

            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        public List<AttendanceDept> GetAttendanceDeptsNew(DateTime date)
        {
            List<AttendanceDept> attendanceDepts = new List<AttendanceDept>();
            try
            {
                DataTable dtGetUpCode = new DataTable();
                dtGetUpCode = GetUpCodeDept();
                GetdataInout getdataInout = new GetdataInout();
                int IDSession = GetSessionID.GetsessionID(date);

                List<EmployeeAbsence> employeeAbsencesDay = getdataInout.GetEmployeeAbsencesDayShift(date, IDSession);
                List<EmployeeAbsence> employeeAbsencesDayNotPaiPan = getdataInout.GetEmployeeAbsencesDayShiftNotPaipan(date, IDSession);
                List<EmployeeAbsence> employeeAbsencesNightShift = getdataInout.GetEmployeeAbsencesNightShift(date, IDSession);
                List<EmployeeAttendance> employeeAttendancesDay = getdataInout.GetEmployeeAttendancesDayShift(date, IDSession);
                List<EmployeeAttendance> employeeAttendancesDayNotPaiPan = getdataInout.GetEmployeeAttandanceDayShiftNotPaipan(date, IDSession);
                List<EmployeeAttendance> employeeAttendancesNight = getdataInout.GetEmployeeAttendancesNightShift(date, IDSession);
                List<EmployeeAttendance> employeeAttendancesSeasonal = getdataInout.GetEmployeeAttendancesSeasonal(date);
                List<EmployeeAttendance> employeeAttendancesSeasonalNight = getdataInout.GetEmployeeAttendancesSeasonalNight(date);
                for (int i = 0; i < dtGetUpCode.Rows.Count; i++)
                {
                    AttendanceDept attendance = new AttendanceDept();
                    attendance.BigDeptCode = dtGetUpCode.Rows[i]["Code"].ToString();
                    attendance.BigDeptName = dtGetUpCode.Rows[i]["Name"].ToString();
                    DataTable dtDeptDetail = new DataTable();
                    dtDeptDetail = GetCountEmployeeByUpcode(attendance.BigDeptCode);
                  
                    for (int j = 0; j < dtDeptDetail.Rows.Count; j++)
                    {
                        AttendanceDept attendance1 = new AttendanceDept();
                        attendance1.BigDeptCode = attendance.BigDeptCode;
                        attendance1.BigDeptName = attendance.BigDeptName;
                        attendance1.DetailDeptCode = dtDeptDetail.Rows[j]["Dept"].ToString();
                        attendance1.HeadDept = dtDeptDetail.Rows[j]["Manager"].ToString();
                        if (dtDeptDetail.Rows[j]["Note"].ToString() != "")
                            attendance1.DetailDeptName = dtDeptDetail.Rows[j]["LongName"].ToString() + " / " + dtDeptDetail.Rows[j]["Note"].ToString();
                        else attendance1.DetailDeptName = dtDeptDetail.Rows[j]["LongName"].ToString();
                        attendance1.EmployeeOfDept = int.Parse(dtDeptDetail.Rows[j]["countEmployee"].ToString());

                        DataTable dtShift = GetDataTableCountShiftbyDeptShift(attendance1.DetailDeptCode, date.Day);
                        DataTable dtGetShiftWorker = GetDataTableCountShiftbyDept(attendance1.DetailDeptCode, date.Day);
                        attendance1.DayShift = new WorkingState();
                        attendance1.NightShift = new WorkingState();
                        attendance1.LocalWorker = new WorkerType();
                        attendance1.SeasonWorkerDay = new WorkingState();
                        attendance1.SeasonWorkerNight = new WorkingState();


                        if (dtGetShiftWorker.Rows.Count == 1)
                        {
                            attendance1.LocalWorker.WorkerIndirect = int.Parse(dtGetShiftWorker.Rows[0]["CountInDirect"].ToString());
                            attendance1.LocalWorker.WorkerDirect = attendance1.EmployeeOfDept - attendance1.LocalWorker.WorkerIndirect;
                        }

                        attendance1.LocalWorker.TotalWorker = attendance1.LocalWorker.WorkerIndirect + attendance1.LocalWorker.WorkerDirect;
                        for (int k = 0; k < dtShift.Rows.Count; k++)
                        {
                            if (dtShift.Rows[k]["Outtime"].ToString().Contains("T"))

                            {

                                attendance1.NightShift.attendance += int.Parse(dtShift.Rows[k]["EmpQty"].ToString());

                            }

                            else

                            {

                                attendance1.DayShift.attendance += int.Parse(dtShift.Rows[k]["EmpQty"].ToString());

                            }
                        }
                        int AttendanceDeptDay = employeeAttendancesDay.Where(d => d.DeptCode == attendance1.DetailDeptCode).Count();
                        int AttendanceDeptDayNotPaipan = employeeAttendancesDayNotPaiPan.Where(d => d.DeptCode == attendance1.DetailDeptCode).Count();
                        int AbsenceDay = employeeAbsencesDay.Where(d=>d.DeptCode == attendance1.DetailDeptCode).Count();
                       int AbsenceDayNotPaiPan = employeeAbsencesDayNotPaiPan.Where(d => d.DeptCode == attendance1.DetailDeptCode).Count();
                        int AttendanceNight = employeeAttendancesNight.Where(d => d.DeptCode == attendance1.DetailDeptCode).Count();
                        int AbsenceNight = employeeAbsencesNightShift.Where(d => d.DeptCode == attendance1.DetailDeptCode).Count();
                        int attendanceSeasonal = employeeAttendancesSeasonal.Count();
                        int atttenSeasonalNight = employeeAttendancesSeasonalNight.Count();
                        attendance1.NightShift.attendanceActual = AttendanceNight;
                        attendance1.DayShift.attendanceActual = AttendanceDeptDay+ AttendanceDeptDayNotPaipan;
                        attendance1.NightShift.absence = AbsenceNight;
                        attendance1.DayShift.absence = AbsenceDay+AbsenceDayNotPaiPan ;
                        attendance1.SeannWorkerDayNotID = attendanceSeasonal - atttenSeasonalNight;
                        attendance1.SeannWorkerNightNotID = atttenSeasonalNight;

                        attendanceDepts.Add(attendance1);
                    }
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetAttendanceDeptsNew(DateTime date)", ex.Message);
            }
            return attendanceDepts;
        }
     
       
      
        

        public DataTable GetDataTableCountShiftbyDept (string Dept, int date)
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select COUNT(e.Code) as CountInDirect from ZlEmployee e  ");
                stringBuilder.Append(" left join Kq_PaiBan p on p.EmpID = e.ID  ");
                stringBuilder.Append(" where State ='0' ");
                stringBuilder.Append(" and  e.Dept = '"+Dept + "' ");
                stringBuilder.Append(" and p.B"+date+" = '04' ");
                stringBuilder.Append(@"  and SessionID =
(select MAX(SessionID) from ZlEmployee e 
left join Kq_PaiBan p on p.EmpID = e.ID ");
                stringBuilder.Append(" where e.Dept = '" + Dept + "' )");

                
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);


            }
            catch (Exception)
            {

                throw;
            }
            return dt;
        }
        public DataTable GetDataTableCountShiftbyDeptShift(string Dept, int date)

        {

            DataTable dt = new DataTable();

            try

            {

                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.Append(" select e.Dept, p.B" + date + ",w.InTime as Intime, w.OutTime as Outtime, count(B" + date + ") as EmpQty from Kq_PaiBan p ");

                stringBuilder.Append(" right join ZlEmployee e on p.EmpID = e.ID ");

                stringBuilder.Append(" right join ZlDept d on e.Dept = d.Code ");

                stringBuilder.Append(" right join WorkingSetting w  on  w.Id = p.B" + date);

                stringBuilder.Append(" where   e.State ='0' and e.Dept not like '%999%'  and SessionID = ( ");

                stringBuilder.Append(@" select max(SessionID) from Kq_PaiBan b right join ZlEmployee a on b.EmpID = a.ID

 where a.Dept = '" + Dept + "' ) ");

               // stringBuilder.Append(" and p.B" + date + " is not null");

                stringBuilder.Append(" and e.Dept ='" + Dept + "' ");

                stringBuilder.Append(" group by e.Dept, w.InTime, w.OutTime, B" + date);

                stringBuilder.Append(" order by e.Dept ");

                SqlHR sqlHR = new SqlHR();

                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);

            }

            catch (Exception)

            {



                throw;

            }

            return dt;

        }



    }
}
