using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;


namespace WindowsFormsApplication1.MQC
{
    class LoadTargetProduction
    {
       public TargetMQC GetTargetMQC (string model, string date)
        {
            TargetMQC target = new TargetMQC();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select distinct DATE, PRODCODE,OUTPUT,SCRAP ");
                sql.Append("from DAILYTARGET ");
                sql.Append("where 1=1 ");
                sql.Append("and PRODCODE = '" + model + "'");
                sql.Append("and DATE = '" + date + "'");
                SQLERPTarget sqlERPtarget = new SQLERPTarget();
                DataTable dt = new DataTable();
                sqlERPtarget.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
                var target1 = (from DataRow dr in dt.Rows
                               select new TargetMQC()
                               {
                                   Date = dr["DATE"].ToString(),
                                   model = dr["PRODCODE"].ToString(),
                                   TargetOutput = (dr["OUTPUT"].ToString() != "") ? double.Parse(dr["OUTPUT"].ToString()) : 0,
                                   TargetDefect = (dr["SCRAP"].ToString() != "") ? double.Parse(dr["SCRAP"].ToString()) : 0

                               }).ToList();
                if (target1 != null && target1.Count > 0)
                    target = target1[0];
                //if( target.TargetOutput >0)
                //{
                //    target.TargetInTimeDayShift = GetTargetIntimeDayShift(target.TargetOutput / 2, 10); //630 = 10,5 gio lam viec
                //    target.TargetInTimeNightShift = GetTargetIntimeNightShift(target.TargetOutput / 2, 10); //630 = 10,5 gio lam viec
                //}
            }
            catch (Exception EX)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetTargetMQC (string model, string date)", EX.Message);
            }
            return target;
        }
        public TargetMQC GetArraystarget(string model,DateTime from, DateTime to)
        {
            try
            {

         
            TargetMQC targetReurn = new TargetMQC();
            int[] target = new int[2];
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select distinct  ISNULL(sum(cast(OUTPUT as int)),0) as output,ISNULL(sum(cast(SCRAP as int)),0) as scrap from DAILYTARGET where 1=1 ");
            stringBuilder.Append(" and PRODCODE = '" + model + "'");
            stringBuilder.Append(" and cast(DATE as DATE) >= '" + from.ToString("yyyyMMdd") +"' ");
            stringBuilder.Append(" and cast(DATE as DATE) <= '" + to.ToString("yyyyMMdd")+"' ");
            DataTable dt = new DataTable();
            SQLERPTarget sqlERPtarget = new SQLERPTarget();
            sqlERPtarget.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            if (dt.Rows.Count == 1)
            {
                target[0] = int.Parse(dt.Rows[0]["output"].ToString().Trim());
                target[1] = int.Parse(dt.Rows[0]["scrap"].ToString().Trim());

                targetReurn.model = model;
                targetReurn.TargetOutput = target[0];
                targetReurn.TargetDefect = target[1];
              }
            return targetReurn;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        public Dictionary<string,double> GetTargetIntimeDayShift (double DailyTarget, int WorkingTime)
        {
            Dictionary<string, double> dic = new Dictionary<string, double>();
            try
            {
              
                dic.Add("[8:00-9:00]", (DailyTarget / WorkingTime));
                dic.Add("[8:00-10:00]", (DailyTarget / WorkingTime)*2);
                dic.Add("[8:00-11:00]", (DailyTarget / WorkingTime) * 3);
                dic.Add("[8:00-12:00]", (DailyTarget / WorkingTime) * 4);
                dic.Add("[8:00-13:00]", (DailyTarget / WorkingTime) * 4);//break-time
                dic.Add("[8:00-14:00]", (DailyTarget / WorkingTime) * 5);
                dic.Add("[8:00-15:00]", (DailyTarget / WorkingTime) * 6);
                dic.Add("[8:00-16:00]", (DailyTarget / WorkingTime) * 7);
                dic.Add("[8:00-17:00]", (DailyTarget / WorkingTime) * 7);//break-time
                dic.Add("[8:00-18:00]", (DailyTarget / WorkingTime) * 8);
                dic.Add("[8:00-19:00]", (DailyTarget / WorkingTime) * 9);
                dic.Add("[8:00-20:00]", (DailyTarget / WorkingTime) * 10);

            }
            catch (Exception)
            {

                throw;
            }
            return dic;
        }
        public Dictionary<string, double> GetTargetIntimeNightShift(double DailyTarget, int WorkingTime)
        {
            Dictionary<string, double> dic = new Dictionary<string, double>();
            try
            {
                dic.Add("[20:00-21:00]", (DailyTarget / WorkingTime));
                dic.Add("[20:00-22:00]", (DailyTarget / WorkingTime) * 2);
                dic.Add("[20:00-23:00]", (DailyTarget / WorkingTime) * 3);
                dic.Add("[20:00-24:00]", (DailyTarget / WorkingTime) * 4);
                dic.Add("[20:00-01:00(T)]", (DailyTarget / WorkingTime) * 4);// break-time
                dic.Add("[20:00-02:00(T)]", (DailyTarget / WorkingTime) * 5);
                dic.Add("[20:00-03:00(T)]", (DailyTarget / WorkingTime) * 6);
                dic.Add("[20:00-04:00(T)]", (DailyTarget / WorkingTime) * 7);
                dic.Add("[20:00-05:00(T)]", (DailyTarget / WorkingTime) * 7);//break-time
                dic.Add("[20:00-06:00(T)]", (DailyTarget / WorkingTime) * 8);
                dic.Add("[20:00-07:00(T)]", (DailyTarget / WorkingTime) * 9);
                dic.Add("[20:00-08:00(T)]", (DailyTarget / WorkingTime) * 10);

            }
            catch (Exception)
            {

                throw;
            }
            return dic;
        }
        public int IndexOfLabelTarget(DateTime dateTime)
        {
            if (dateTime.TimeOfDay > new TimeSpan(8, 0, 0) && dateTime.TimeOfDay <= new TimeSpan(10, 0, 0))
                return 0;
            else if (dateTime.TimeOfDay > new TimeSpan(10, 0, 0) && dateTime.TimeOfDay <= new TimeSpan(11, 45, 0))
                return 1;
            else if (dateTime.TimeOfDay > new TimeSpan(11, 45, 0) && dateTime.TimeOfDay <= new TimeSpan(12, 45, 0))
                return 2;
            else if (dateTime.TimeOfDay > new TimeSpan(12, 45, 0) && dateTime.TimeOfDay <= new TimeSpan(14, 0, 0))
                return 3;
            else if (dateTime.TimeOfDay > new TimeSpan(14, 0, 0) && dateTime.TimeOfDay <= new TimeSpan(16, 0, 0))
                return 4;
            else if (dateTime.TimeOfDay > new TimeSpan(16, 0, 0) && dateTime.TimeOfDay <= new TimeSpan(16, 45, 0))
                return 5;
            else if (dateTime.TimeOfDay > new TimeSpan(16, 45, 0) && dateTime.TimeOfDay <= new TimeSpan(17, 15, 0))
                return 6;
            else if (dateTime.TimeOfDay > new TimeSpan(17, 15, 0) && dateTime.TimeOfDay <= new TimeSpan(20, 0, 0))
                return 7;

            // Ca Dem
            if (dateTime.TimeOfDay > new TimeSpan(20, 0, 0) && dateTime.TimeOfDay <= new TimeSpan(10, 0, 0))
                return 0;
            else if (dateTime.TimeOfDay > new TimeSpan(10, 0, 0) && dateTime.TimeOfDay <= new TimeSpan(11, 45, 0))
                return 1;
            else if (dateTime.TimeOfDay > new TimeSpan(11, 45, 0) && dateTime.TimeOfDay <= new TimeSpan(12, 45, 0))
                return 2;
            else if (dateTime.TimeOfDay > new TimeSpan(12, 45, 0) && dateTime.TimeOfDay <= new TimeSpan(14, 0, 0))
                return 3;
            else if (dateTime.TimeOfDay > new TimeSpan(14, 0, 0) && dateTime.TimeOfDay <= new TimeSpan(16, 0, 0))
                return 4;
            else if (dateTime.TimeOfDay > new TimeSpan(16, 0, 0) && dateTime.TimeOfDay <= new TimeSpan(16, 45, 0))
                return 5;
            else if (dateTime.TimeOfDay > new TimeSpan(16, 45, 0) && dateTime.TimeOfDay <= new TimeSpan(17, 15, 0))
                return 6;
            else if (dateTime.TimeOfDay > new TimeSpan(17, 15, 0) && dateTime.TimeOfDay <= new TimeSpan(20, 0, 0))
                return 7;




            else return -1;
        }
    }
}
