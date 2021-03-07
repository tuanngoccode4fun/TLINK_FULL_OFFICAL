using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadDataToDatabase.HR_Audit
{
    class DataControl
    {
        public bool InsertRowofManufacture(FingerData fingerData)
        {
            try
            {
                string sqlQuerry = "";
                sqlQuerry += "insert into m_FingerData (Dept, IDName,Name, DateTime, TimeIn, TimeOut,DayWorkingTime,NightWorkingtime,ApproveTimeAbsent,Update_datetime ) values( '";
                sqlQuerry += fingerData.Dept + "', '" + fingerData.ID+ "', '" + fingerData.Name + "', '" + fingerData.DateTime + "', '" + fingerData.TimeIn+ "', '" + fingerData.TimeOut + "', '" + fingerData.DayWorkingTime  +"', '" + fingerData.NightWorkingTime + "', '" + fingerData.AproveTimeabsent + "',GETDATE() )";
                sqlCON sqlCON = new sqlCON();
                return sqlCON.sqlExecuteNonQuery(sqlQuerry, false);
            }
            catch (Exception ex)
            {

                return false;
            }


        }
        public bool InsertRowofSpecialList(SpecialList special)
        {
            try
            {
                string sqlQuerry = "";
                sqlQuerry += "insert into m_SpecialList (No, IDName,Name, Department, fromDate, toDate,Status,Update_datetime ) values( '";
                sqlQuerry += special.No + "', '" + special.ID + "', '" + special.Name + "', '" + special.Department + "', '" + special.from + "', '" + special.to + "', '" + special.status + "',GETDATE() )";
                sqlCON sqlCON = new sqlCON();
                return sqlCON.sqlExecuteNonQuery(sqlQuerry, false);
            }
            catch (Exception ex)
            {

                return false;
            }


        }
        public bool InsertRowofWorkingDate(WorkingDateData workData)
        {
            try
            {
                string sqlQuerry = "";
                sqlQuerry += "insert into m_WorkingDate ( IDName,Name, Dept,Col_Dept,Col_date,Year,Month,Shift, N1, N2, N3, N4, N5, N6, N7, N8, N9, N10,N11,"
                    + "N12,N13,N14,N15,N16,N17,N18,N19,N20,N21,N22,N23,N24,N25,N26,N27,N28,N29,N30,N31, Update_date ) values ('";
                sqlQuerry += workData.ID + "', '" + workData.Name + "', '" + workData.dept + "', '" + workData.col_Dept + "', '" + workData.col_date + "', '" + "2019" + "', '"
                    + workData.WorkingTimeDatas[0].month + "', '" + "day";

                for (int i = 0; i < workData.WorkingTimeDatas.Count; i++)
                {
                    if (workData.WorkingTimeDatas[i].Shift == "day")
                        sqlQuerry += "', '" + workData.WorkingTimeDatas[i].workingHour;

                }
                sqlQuerry += "',GETDATE() )";
                sqlCON sqlCON = new sqlCON();
                 sqlCON.sqlExecuteNonQuery(sqlQuerry, false);


                string sqlQuerry2 = "";
                sqlQuerry2 += "insert into m_WorkingDate ( IDName,Name, Dept,Col_Dept,Col_date,Year,Month,Shift, N1, N2, N3, N4, N5, N6, N7, N8, N9, N10,N11,"
                    + "N12,N13,N14,N15,N16,N17,N18,N19,N20,N21,N22,N23,N24,N25,N26,N27,N28,N29,N30,N31, Update_date ) values ('";
                sqlQuerry2 += workData.ID + "', '" + workData.Name + "', '" + workData.dept + "', '" + workData.col_Dept + "', '" + workData.col_date + "', '" + "2019" + "', '"
                    + workData.WorkingTimeDatas[0].month + "', '" + "night";

                for (int i = 0; i < workData.WorkingTimeDatas.Count; i++)
                {
                    if (workData.WorkingTimeDatas[i].Shift == "night")
                        sqlQuerry2 += "', '" + workData.WorkingTimeDatas[i].workingHour;

                }
                sqlQuerry2 += "',GETDATE() )";
                sqlCON sqlCON2 = new sqlCON();
              return  sqlCON2.sqlExecuteNonQuery(sqlQuerry2, false);
            }
            catch (Exception ex)
            {

                return false;
            }


        }

        public List<m_workingData> GetWorkingData(string IDName, ref DataTable datatable, string month)
        {
            List<m_workingData> workingDatas = new List<m_workingData>();
            try
            {
                DataTable dt = new DataTable();
                sqlCON sqlCON = new sqlCON();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select IDName,Name,Dept,Year,Month, Shift, N1,N2,N3,N4,N5,N6,N7,N8,N9,N10,
N11,N12,N13,N14,N15,N16,N17,N18,N19,N20,N21,N22,N23,N24,N25,N26,N27,N28,N29,N30,N31
from m_WorkingDate
where 1=1 ");
                stringBuilder.Append("and IDName like '%" + IDName + "%'");
                stringBuilder.Append("and Month like '%" + month+ "%'");
                sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                workingDatas = (from DataRow dr in dt.Rows
                                select new m_workingData()
                                {
                              ID = (dr["IDName"] != null) ? dr["IDName"].ToString().Trim() : "",
                              Name = (dr["Name"] != null) ? dr["Name"].ToString().Trim() : "",
                              Dept = (dr["Dept"] != null) ? dr["Dept"].ToString().Trim() : "",
                              Year = (dr["Year"] != null) ? dr["Year"].ToString().Trim() : "",
                              Month = (dr["Month"] != null) ? dr["Month"].ToString().Trim() : "",
                              Shift = (dr["Shift"] != null) ? dr["Shift"].ToString().Trim() : "",
                              N1 = (dr["N1"] != null) ? dr["N1"].ToString().Trim() : "",
                                    N2 = (dr["N2"] != null) ? dr["N2"].ToString().Trim() : "",
                                    N3 = (dr["N3"] != null) ? dr["N3"].ToString().Trim() : "",
                                    N4 = (dr["N4"] != null) ? dr["N4"].ToString().Trim() : "",
                                    N5 = (dr["N5"] != null) ? dr["N5"].ToString().Trim() : "",
                                    N6 = (dr["N6"] != null) ? dr["N6"].ToString().Trim() : "",
                                    N7 = (dr["N7"] != null) ? dr["N7"].ToString().Trim() : "",
                                    N8 = (dr["N8"] != null) ? dr["N8"].ToString().Trim() : "",
                                    N9 = (dr["N9"] != null) ? dr["N9"].ToString().Trim() : "",
                                    N10 = (dr["N10"] != null) ? dr["N10"].ToString().Trim() : "",
                                    N11 = (dr["N11"] != null) ? dr["N11"].ToString().Trim() : "",
                                    N12= (dr["N12"] != null) ? dr["N12"].ToString().Trim() : "",
                                    N13 = (dr["N13"] != null) ? dr["N13"].ToString().Trim() : "",
                                    N14 = (dr["N14"] != null) ? dr["N14"].ToString().Trim() : "",
                                    N15 = (dr["N15"] != null) ? dr["N15"].ToString().Trim() : "",
                                    N16 = (dr["N16"] != null) ? dr["N16"].ToString().Trim() : "",
                                    N17 = (dr["N17"] != null) ? dr["N17"].ToString().Trim() : "",
                                    N18 = (dr["N18"] != null) ? dr["N18"].ToString().Trim() : "",
                                    N19 = (dr["N19"] != null) ? dr["N19"].ToString().Trim() : "",
                                    N20 = (dr["N20"] != null) ? dr["N20"].ToString().Trim() : "",
                                    N21 = (dr["N21"] != null) ? dr["N21"].ToString().Trim() : "",
                                    N22 = (dr["N22"] != null) ? dr["N22"].ToString().Trim() : "",
                                    N23 = (dr["N23"] != null) ? dr["N23"].ToString().Trim() : "",
                                    N24 = (dr["N24"] != null) ? dr["N24"].ToString().Trim() : "",
                                    N25 = (dr["N25"] != null) ? dr["N25"].ToString().Trim() : "",
                                    N26 = (dr["N26"] != null) ? dr["N26"].ToString().Trim() : "",
                                    N27 = (dr["N27"] != null) ? dr["N27"].ToString().Trim() : "",
                                    N28 = (dr["N28"] != null) ? dr["N28"].ToString().Trim() : "",
                                    N29 = (dr["N29"] != null) ? dr["N29"].ToString().Trim() : "",
                                    N30 = (dr["N30"] != null) ? dr["N30"].ToString().Trim() : "",
                                    N31 = (dr["N31"] != null) ? dr["N31"].ToString().Trim() : ""

                                }
                                ).ToList();

                datatable = dt;
                }

            
            catch (Exception)
            {

                return null;
            }
            return workingDatas;

        }
        public List<FingerData> GetFingerDatas(string IDName, string month)
        {
            List<FingerData> fingerDatas = new List<FingerData>();
            try
            {
                DataTable dt = new DataTable();
                sqlCON sqlCON = new sqlCON();
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select Dept, IDName, Name, DateTime,max(TimeIn) as TimeIn, max(TimeOut) as TimeOut ,DayWorkingTime,NightWorkingtime,ApproveTimeAbsent
from m_FingerData where 1=1 ");
                stringBuilder.Append("and IDName like '%" + IDName + "%'");
                stringBuilder.Append("and DateTime like '%" + month + "/2019%'");
                stringBuilder.Append(" group by Dept, IDName, Name, DateTime,DayWorkingTime,NightWorkingtime,ApproveTimeAbsent");
                sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                fingerDatas = (from DataRow dr in dt.Rows
                               select new FingerData()
                               {

                                   Dept = (dr["Dept"] != null) ? dr["Dept"].ToString().Trim() : "",
                                   ID = (dr["IDName"] != null) ? dr["IDName"].ToString().Trim() : "",
                                   Name = (dr["Name"] != null) ? dr["Name"].ToString().Trim() : "",
                                   DateTime = (dr["DateTime"] != null) ? dr["DateTime"].ToString().Trim() : "",
                                   TimeIn = (dr["TimeIn"] != null) ? dr["TimeIn"].ToString().Trim() : "",
                                   TimeOut = (dr["TimeOut"] != null) ? dr["TimeOut"].ToString().Trim() : "",
                                   DayWorkingTime = (dr["DayWorkingTime"] != null) ? dr["DayWorkingTime"].ToString().Trim() : "",
                                   NightWorkingTime = (dr["NightWorkingtime"] != null) ? dr["NightWorkingtime"].ToString().Trim() : "",
                                   AproveTimeabsent = (dr["ApproveTimeAbsent"] != null) ? dr["ApproveTimeAbsent"].ToString().Trim() : "",
                                   
                               }
                                 ).ToList();
            }
            catch (Exception)
            {

                return null;
            }
            return fingerDatas;
        }
        
        public void GetListIDName (ref DataTable datatable, string month)
        {
            DataTable dt = new DataTable();
            sqlCON sqlCON = new sqlCON();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"select distinct IDName
from m_WorkingDate where 1=1 ");
            stringBuilder.Append("and Month like '%" + month + "%'");
            sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            datatable = dt;
            dt = null;
        }

        public void GetListIDFinger(ref DataTable datatable, string month)
        {
            DataTable dt = new DataTable();
            sqlCON sqlCON = new sqlCON();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"select distinct IDName
from m_FingerData where 1=1 ");
            stringBuilder.Append("and DateTime like '%" + month + "/20%'");
            sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            datatable = dt;
            dt = null;
        }
        public void GetListIDSpecial(ref DataTable datatable)
        {
            DataTable dt = new DataTable();
            sqlCON sqlCON = new sqlCON();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@" select IDName,Department, fromDate, toDate from m_SpecialList where 1=1 ");

            sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            datatable = dt;
            dt = null;
        }
        public List<AuditInOut> GetAuditInOuts (List<FingerData> fingerDatas)
        {
            List<AuditInOut> auditInOuts = new List<AuditInOut>();
            DateTime TimeIn = DateTime.MinValue;
            DateTime TimeOut = DateTime.MinValue;
            try
            {
                int count = 0;
                foreach (var data in fingerDatas)
                {
                    AuditInOut inOut = new AuditInOut();
                    inOut.ID = data.ID;
                   
                    
                    if (data.TimeIn != "" && data.TimeOut != "")
                    {
                        try
                        {
                        
                            inOut.TimeIn = DateTime.ParseExact(data.DateTime.Substring(0,10), "dd/MM/yyyy", CultureInfo.InvariantCulture) + TimeSpan.Parse(data.TimeIn);
                        }
                        catch (Exception ex)
                        {
                            ;

                        }
                        {
                            if (data.TimeOut.Contains("T"))
                            {
                                inOut.TimeOut = DateTime.ParseExact(data.DateTime.Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture).AddDays(1) + TimeSpan.Parse(data.TimeOut.Substring(1));
                            }
                            else
                            {
                                inOut.TimeOut = DateTime.ParseExact(data.DateTime.Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture) + TimeSpan.Parse(data.TimeOut);
                            }

                            //if ((inOut.TimeOut - inOut.TimeIn).TotalHours < 12)
                            //{
                            //    inOut.Status = "rule 12 hours";
                            //    auditInOuts.Add(inOut);
                            //}
                            if (count > 1)
                            {
                                if ((inOut.TimeIn - TimeOut).TotalHours < 12)
                                {
                                    TimeOut = inOut.TimeOut;
                                    inOut.Status = "rule 12 hours";
                                    auditInOuts.Add(inOut);
                                }
                                else
                                {
                                    TimeOut = inOut.TimeOut;
                                }
                            }
                            else if (count == 0)
                            {
                                TimeOut = inOut.TimeOut;

                            }
                        }
                    }
                    count++;
                }
                

            }
            catch (Exception ex)
            {

                return null;
            }
            return auditInOuts;
        }
    }
}
