using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database
{
  public  class CMSMQ // data loai chung tu
    {
    public static DataTable GetDataTableCThethong(string MQ003)
        {
            DataTable dt = new DataTable();
            string querry = "select * from CMSMQ where MQ003 ='" + MQ003 + "' ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);

            return dt;
        }
    }
}
