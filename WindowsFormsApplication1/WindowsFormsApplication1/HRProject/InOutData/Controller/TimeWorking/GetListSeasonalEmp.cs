using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WindowsFormsApplication1.HRProject.InOutData.Model.TimeWorking;
namespace WindowsFormsApplication1.HRProject.InOutData.Controller.TimeWorking
{
 public   class GetListSeasonalEmp
    {
        public List<SeasonalEmployee> GetSeasonalEmployees(DateTime from, DateTime to)
        {
            List<SeasonalEmployee> seasonalEmployees = new List<SeasonalEmployee>();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(@"select distinct k.CardNo, ISNULL(z.Name,'') as EmpName
from Kq_Source k
left join ZlEmployee z on k.EmpID = z.ID
where 1=1 ");
                stringBuilder.Append(" and EmpID is null ");
                stringBuilder.Append(" and CAST(FDateTime as date ) >='" + from.ToString("yyyyMMdd") + "' ");
                stringBuilder.Append(" and CAST(FDateTime as date ) <='" + to.ToString("yyyyMMdd") + "' ");
                DataTable dt = new DataTable();
                SqlHR sqlHR = new SqlHR();
                sqlHR.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    seasonalEmployees.Add(new SeasonalEmployee
                    {
                        FingerCode = dt.Rows[i]["CardNo"].ToString(),
                        Name = dt.Rows[i]["EmpName"].ToString(),
                        Supplier = ""
                    });
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetSeasonalEmployees(DateTime from, DateTime to)", ex.Message);
            }
            return seasonalEmployees;
        }
    }
}
