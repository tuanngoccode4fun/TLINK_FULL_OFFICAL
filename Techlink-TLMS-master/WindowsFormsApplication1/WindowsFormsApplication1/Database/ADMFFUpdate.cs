using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database
{
  public  class ADMMFUpdate //Table User
    {
        public DataTable GetDtADMFFByUser(string User)
        {
            DataTable dt = new DataTable();
            string querry = " select * from ADMMF where MF001 ='"+User +"' ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);
            return dt;
        }
        public static bool  IsHavePermisionUser(string User)
        {
            DataTable dt = new DataTable();
            string querry = " select * from ADMMF where MF001 ='" + User + "' ";
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(querry, ref dt);
            if (dt.Rows.Count == 1)
                return true;
            return false;
        }
    }
}
