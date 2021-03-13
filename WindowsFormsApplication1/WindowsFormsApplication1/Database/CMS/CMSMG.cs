using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.CMS
{
  public  class CMSMG
    {
        public static DataTable GetdtConvetTienTe(string Currency, DateTime date)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@" SELECT * FROM CMSMG WHERE MG001 ='"+ Currency+ "' ");
            stringBuilder.Append(" and MG002 = (select max(cast(MG002 as date)) from CMSMG where MG001 ='" + Currency + "' ");
            stringBuilder.Append(" and cast(MG002 as date) < '" + date.ToString("yyyyMMdd") + "' )");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
    }
}
