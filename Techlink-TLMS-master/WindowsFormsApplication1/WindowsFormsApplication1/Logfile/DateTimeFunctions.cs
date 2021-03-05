using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
   public static class DateTimeFunctions
    {
        public static DateTime RoundUp(this DateTime dt, TimeSpan d)
        {
            var modTicks = dt.Ticks % d.Ticks;
            var delta = modTicks != 0 ? d.Ticks - modTicks : 0;
            return new DateTime(dt.Ticks + delta, dt.Kind);
        }

        public static DateTime RoundDown(this DateTime dt, TimeSpan d)
        {
            var delta = dt.Ticks % d.Ticks;
            return new DateTime(dt.Ticks - delta, dt.Kind);
        }

        public static DateTime RoundToNearest(this DateTime dt, TimeSpan d)
        {
            var delta = dt.Ticks % d.Ticks;
            bool roundUp = delta > d.Ticks / 2;
            var offset = roundUp ? d.Ticks : 0;

            return new DateTime(dt.Ticks + offset - delta, dt.Kind);
        }

        public static TimeSpan RoundUp(this TimeSpan dt, TimeSpan d)
        {
            var modTicks = dt.Ticks % d.Ticks;
            var delta = modTicks != 0 ? d.Ticks - modTicks : 0;
            return new TimeSpan(dt.Ticks + delta);
        }

        public static TimeSpan RoundDown(this TimeSpan dt, TimeSpan d)
        {
            var delta = dt.Ticks % d.Ticks;
            return new TimeSpan(dt.Ticks - delta);
        }

        public static TimeSpan RoundToNearest(this TimeSpan dt, TimeSpan d)
        {
            var delta = dt.Ticks % d.Ticks;
            bool roundUp = delta > d.Ticks / 2;
            var offset = roundUp ? d.Ticks : 0;

            return new TimeSpan(dt.Ticks + offset - delta);
        }
        public static List<string>ListDateInPeriodDate(DateTime from, DateTime to)
        {
            List<string> listDate = new List<string>();
            if (to.Date < from.Date)
                return null;
            else if (to.Date == from.Date)
            {
                listDate.Add(from.Date.ToString("dd.MM"));
            }
            else
            {
                for (int i = 0; i <= (to - from).Days; i++)
                {
                    listDate.Add(from.Date.AddDays(i).ToString("dd.MM"));
                }
            }

            return listDate;
        }
        public static List<string> ListDateNameInPeriodDate(DateTime from, DateTime to)
        {
            List<string> listDate = new List<string>();
            if (to.Date < from.Date)
                return null;
            else if (to.Date == from.Date)
            {
                listDate.Add(from.Date.DayOfWeek.ToString());
            }
            else
            {
                for (int i = 0; i <= (to - from).Days; i++)
                {
                    listDate.Add(from.Date.AddDays(i).DayOfWeek.ToString());
                }
            }

            return listDate;
        }
    }
}
