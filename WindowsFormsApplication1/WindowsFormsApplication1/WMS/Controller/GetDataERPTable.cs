using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.WMS.Controller
{
 public   class GetDataERPTable
    {
        public DataTable GetDataTableSFCTC()
        {
            DataTable dt = new DataTable();
            string sqlQuerry = "select top(1) * from SFCTC ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);
            return dt;
        }
        public DataTable GetDataTableSFCTB()
        {
            DataTable dt = new DataTable();
            string sqlQuerry = "select top(1) * from SFCTB ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(sqlQuerry, ref dt);
            return dt;
        }
        public DataTable GetDataTableSFCTA(string productCode)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("select * from SFCTA where 1=1 and TA003 = '0020' ");
            stringBuilder.Append(" and TA001 ='" + productCode.Split('-')[0]+ "' ");
            stringBuilder.Append(" and TA002 ='" + productCode.Split('-')[1] + "' ");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
    }
}
