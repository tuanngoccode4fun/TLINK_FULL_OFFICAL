using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Globalization;

namespace WindowsFormsApplication1.HRProject.InOutData.Controller.TimeWorking
{
    public class GetInoutDataFromEmployee
    {
        public List<Model.InoutData> GetInoutDatasFromEmpFinger(string EmpFinger, DateTime from, DateTime to)
        {
            List<Model.InoutData> inoutDatas = new List<Model.InoutData>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select CardNo,FDateTime,MachNo,CAST(FDateTime as date ) as DateFinger, convert(char(5), FDateTime, 108) as TimeFinger,
case 
when  convert(char(5), FDateTime, 108) >='19:00' and convert(char(5), FDateTime, 108) <'20:00' then 'In-Night'
when  convert(char(5), FDateTime, 108) >='07:00' and convert(char(5), FDateTime, 108) <'08:10' then 'In-Day'
when  convert(char(5), FDateTime, 108) >='05:00' and convert(char(5), FDateTime, 108) <='06:00' then 'Out-Night8'
when  convert(char(5), FDateTime, 108) >='08:10' and convert(char(5), FDateTime, 108) <='09:00' then 'Out-Night12'
when  convert(char(5), FDateTime, 108) >='17:00' and convert(char(5), FDateTime, 108) <='18:00' then 'Out-Day8'
when  convert(char(5), FDateTime, 108) >='20:00' and convert(char(5), FDateTime, 108) <='21:00' then 'Out-Day12'
else 'Undefined'
end as InOut
from Kq_Source
where 1=1 and  Dept like '%999%' ");
                stringBuilder.Append(" and CardNo ='" + EmpFinger + "' ");
                stringBuilder.Append(" and CAST(FDateTime as date ) >='" + from.ToString("yyyyMMdd") + "' ");
                stringBuilder.Append(" and CAST(FDateTime as date ) <='" + to.ToString("yyyyMMdd") + "' ");
                stringBuilder.Append(" order by CAST(FDateTime as datetime )  ");

                DataTable dt = new DataTable();
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    inoutDatas.Add(new Model.InoutData
                    {
                        CardNo = dt.Rows[i]["CardNo"].ToString(),
                        FDateTime = (DateTime)dt.Rows[i]["FDateTime"],
                        MachNo = dt.Rows[i]["MachNo"].ToString(),
                        Date = dt.Rows[i]["DateFinger"].ToString(),
                        Time = dt.Rows[i]["TimeFinger"].ToString(),
                        InOut = dt.Rows[i]["InOut"].ToString()

                    });
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetInoutDatasFromEmpFinger ( string EmpFinger, DateTime from, DateTime to)", ex.Message);
            }
            return inoutDatas;
        }

        public List<Model.InoutData> GetInoutDatasFromDateTime(DateTime from, DateTime to)
        {
            List<Model.InoutData> inoutDatas = new List<Model.InoutData>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select isnull(d.Name,'') as Dept,isnull(z.Code,'') as Code, isnull(z.Name,'') as Name,isnull(z.ID,'') as ID, k.CardNo,FDateTime,MachNo,CAST(FDateTime as date ) as DateFinger, convert(char(5), FDateTime, 108) as TimeFinger,
case 
when  convert(char(5), FDateTime, 108) >='19:00' and convert(char(5), FDateTime, 108) <'20:00' then 'In-Night'
when  convert(char(5), FDateTime, 108) >='07:00' and convert(char(5), FDateTime, 108) <'08:10' then 'In-Day'
when  convert(char(5), FDateTime, 108) >='05:00' and convert(char(5), FDateTime, 108) <='06:00' then 'Out-Night8'
when  convert(char(5), FDateTime, 108) >='08:10' and convert(char(5), FDateTime, 108) <='09:00' then 'Out-Night12'
when  convert(char(5), FDateTime, 108) >='17:00' and convert(char(5), FDateTime, 108) <='18:00' then 'Out-Day8'
when  convert(char(5), FDateTime, 108) >='20:00' and convert(char(5), FDateTime, 108) <='21:00' then 'Out-Day12'
else 'Undefined'
end as InOut
from Kq_Source k
left join ZlEmployee z on k.EmpID = z.ID
left join ZlDept d on z.Dept = d.Code
where 1=1 
");             stringBuilder.Append("  and (z.Dept like '%999%' ) ");
             //   stringBuilder.Append("  and (z.Dept like '%888%' or EmpID is null) ");
                stringBuilder.Append(" and CAST(FDateTime as date ) >='" + from.ToString("yyyyMMdd") + "' ");
                stringBuilder.Append(" and CAST(FDateTime as date ) <='" + to.ToString("yyyyMMdd") + "' ");
                stringBuilder.Append(" order by CAST(FDateTime as datetime )  ");
                DataTable dt = new DataTable();
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    inoutDatas.Add(new Model.InoutData
                    {
                        Dept = dt.Rows[i]["Dept"].ToString(),
                        EmpCode = dt.Rows[i]["Code"].ToString(),
                        Name = dt.Rows[i]["Name"].ToString(),
                        EmpID = dt.Rows[i]["ID"].ToString(),
                        CardNo = dt.Rows[i]["CardNo"].ToString(),
                        FDateTime = (DateTime)dt.Rows[i]["FDateTime"],
                        MachNo = dt.Rows[i]["MachNo"].ToString(),
                        Date = dt.Rows[i]["DateFinger"].ToString(),
                        Time = dt.Rows[i]["TimeFinger"].ToString(),
                        InOut = dt.Rows[i]["InOut"].ToString()

                    });
                }

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetInoutDatasFromDateTime(DateTime from, DateTime to)", ex.Message);
            }
            return inoutDatas;
        }
        public int GetSessionID(DateTime date)
        {
            int SessionID = -1;
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select ID from S_Session where 1 = 1 ");
            stringBuilder.Append("  and (CAST('" + date.ToString("yyyy-MM-dd") + "' as datetime)) BETWEEN CAST(Date0 as datetime) and CAST(Date1 as datetime)");
            SqlHR sqlHR = new SqlHR();
            string value = sqlHR.sqlExecuteScalarString(stringBuilder.ToString());
            try
            {
                SessionID = int.Parse(value);
            }
            catch (Exception)
            {

                SessionID = -1;
            }
            return SessionID;
        }
        public DataTable GetDataPaipan(int SessionID, string IDEmp)
        {
            DataTable dtpainPan = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select * from Kq_PaiBan where 1=1 ");
            stringBuilder.Append(" and SessionID = '"+ SessionID+ "' ");
            stringBuilder.Append(" and  EmpID = '" + IDEmp + "' ");
            SqlHR sqlHR = new SqlHR();
            sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dtpainPan);
            return dtpainPan;
        }
    }
}
