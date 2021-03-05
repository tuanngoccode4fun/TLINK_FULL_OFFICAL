using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database
{
   public class CMSMF
    {
        public static DataTable GetDataTableTienTe()
        {
            DataTable dt = new DataTable();
            string querry = "  select * from CMSMF ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);
            return dt;
        }
       
    }
}
