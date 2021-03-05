using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.HRProject.InOutData.Controller.TimeWorking
{
  public  class GetSessionID
    {
        public static int GetsessionID (DateTime dtGet)
        {
            int intSessionID = 0;
            DateTime firstDay = new DateTime(dtGet.Year, dtGet.Month, 1);
            DateTime LastDate = new DateTime(dtGet.Year, dtGet.Month, DateTime.DaysInMonth(dtGet.Year, dtGet.Month));
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select ID from S_Session where 1=1 ");
            stringBuilder.Append(" and CAST(Date0 as datetime) >= '" + firstDay.ToString("yyyyMMdd") + "'  ");
            stringBuilder.Append(" and CAST(Date0 as datetime) <= '" +  LastDate.ToString("yyyyMMdd") + "'  ");
            SqlHR sqlHR = new SqlHR();
            string strGet = sqlHR.sqlExecuteScalarString(stringBuilder.ToString());
            if (strGet != "")
                intSessionID = int.Parse(strGet);
            return intSessionID;


        }
    }

}
