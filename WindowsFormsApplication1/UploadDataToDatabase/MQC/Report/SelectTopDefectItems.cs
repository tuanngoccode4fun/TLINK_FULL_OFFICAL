using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UploadDataToDatabase.MQC.Report
{
  public  class SelectTopDefectItems
    {

        public List<string> GetListStringHeaderReworkTop25()
        {
            List<string> headerRW25 = new List<string>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@" select top(16) sum(cast(data as int)) as Tong, item, itemname from m_ERPMQC_REALTIME
inner join m_process on processcode = REPLACE(item,'RW','NG')
where remark ='RW'
group by item,itemname
order by Tong DESC ");
                DataTable dt = new DataTable();
                sqlCON sqlCON = new sqlCON();
                sqlCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    headerRW25.Add(dt.Rows[i]["itemname"].ToString());
                }
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "List<string> GetListStringHeaderReworkTop25()", ex.Message);
            }
            return headerRW25;
        }
    }
}
