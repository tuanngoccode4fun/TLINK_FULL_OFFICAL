using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.OVEN.Database
{
   public class GetdataOven
    {
        public DataTable GetUpdateTemperature()
        {
            DataTable dt = new DataTable();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select * from m_OVEN_REALTIME 
where cast(inspecttime as time) = (select max(cast(inspecttime as time)) from m_OVEN_REALTIME 
where cast(inspectdate as date)= (select max(cast(inspectdate as date)) from m_OVEN_REALTIME )) ");

                sqlCON sqlCON = new sqlCON();
                sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetUpdateTemperature()", ex.Message);
            }
            return dt;
        }
    }
}
