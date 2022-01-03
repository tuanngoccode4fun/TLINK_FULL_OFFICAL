using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UploadDataToDatabase.MQC;

namespace UploadDataToDatabase.Class
{
   static class DateTimeControl
    {
        public static DateTime StartOfWeek(DayOfWeek startOfWeek)
        {
            int diff = (7 + (DateTime.Now.DayOfWeek - startOfWeek)) % 7;
            return DateTime.Now.AddDays(-1 * diff).Date;
        }
        public static void ReturnDateTimePeriodProduction (PeriodProduction period,ref DateTime dateFrom, ref DateTime dateTo)
        { DateTime from = new DateTime();
            DateTime to = new DateTime();
            if(period == PeriodProduction.dayshift)
            {
                from = DateTime.Now.Date + new TimeSpan(8, 0, 0);
                to = DateTime.Now.Date + new TimeSpan(20, 0, 0);
            }
            else if(period == PeriodProduction.nightshift)
            {
                from = DateTime.Now.Date.AddDays(-1) + new TimeSpan(20, 0, 0);
                to = DateTime.Now.Date + new TimeSpan(8, 0, 0);
            }
            else if(period == PeriodProduction.AllDay)
            {
                from = DateTime.Now.Date.AddDays(-1) + new TimeSpan(8, 0, 0);
                to = DateTime.Now.Date + new TimeSpan(8, 0, 0);
            }
            dateFrom = from; dateTo = to;

        }
        public static void ReturnDateTimeForWeekly(ref DateTime dateFrom, ref DateTime dateTo)
        {
            int WeekNo = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            dateFrom = Class.DateTimeControl.StartOfWeek(DayOfWeek.Monday);
            dateTo = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 7);
      
        }
        public static void ReturnDateTimeFirstMonthToNow(ref DateTime dateFrom, ref DateTime dateTo)
        {
         //   int WeekNo = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            dateFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dateTo = DateTime.Now.Date;

        }
        public static void ReturnDateTimeForMonthly(ref DateTime dateFrom, ref DateTime dateTo)
        {
            DateTime date_From = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime date_To = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            
            dateFrom = date_From;
            dateTo = date_To;
        }
        // This presumes that weeks start with Monday.
        // Week 1 is the 1st week of the year with a Thursday in it.
        public static int GetIso8601WeekOfYear(DateTime time)
        {
            // Seriously cheat.  If its Monday, Tuesday or Wednesday, then it'll 
            // be the same week# as whatever Thursday, Friday or Saturday are,
            // and we always get those right
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            // Return the week of our adjusted day
            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }
    }
    
}
