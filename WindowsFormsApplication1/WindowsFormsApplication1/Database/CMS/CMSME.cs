using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database
{
    public class CMSME
    {
        public static DataTable GetDataTableBophan()
        {
         DataTable dt = new DataTable();
        string querry = " select * from CMSME ";
        SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
        sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);
            return dt;
        }
    }
}
