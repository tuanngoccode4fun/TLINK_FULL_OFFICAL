using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database
{
   public class COPTCTD
    {
        public static DataTable GetClientOrder(string client,string dept, string currency)
        { DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"  select  TC012,TD001,TD002,TD003, TD004,TD005,TD008,TD009,TD010, cast(TD013 as date) as TD013,TD016,TD021, TD032, TD036,TC005,TC004 from COPTC
 inner join COPTD on TC001 = TD001 and TC002 = TD002
 where TC027 = 'Y' AND TD016 = 'N' AND TD008 > TD009 ");
            stringBuilder.Append(" and TC004 ='" + client + "' ");
            stringBuilder.Append(" and TC005 ='" + dept + "' ");
            stringBuilder.Append(" and TC008 ='" + currency + "' ");

            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
    }
}
