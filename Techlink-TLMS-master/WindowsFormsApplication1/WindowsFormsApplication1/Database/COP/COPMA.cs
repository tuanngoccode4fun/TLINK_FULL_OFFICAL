using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Database
{
 public   class COPMA
    {
        public static DataTable GetDataTableKhachhang()
        {
            DataTable dt = new DataTable();
            string querry = " select * from COPMA ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);

            return dt;
        }
        public static DataTable GetDataTableKhachhangbyClientCode(string clientCode)
        {
            DataTable dt = new DataTable();
            string querry = " select * from COPMA where MA001 = '"+clientCode +"' ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);

            return dt;
        }
    }
}
