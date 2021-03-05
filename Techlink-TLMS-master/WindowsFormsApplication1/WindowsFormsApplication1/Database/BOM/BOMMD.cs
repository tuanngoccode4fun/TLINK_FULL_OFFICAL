using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.BOM
{
  public  class BOMMD
    {
        public DataTable GetDataTableBOMbyproduct(string product)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@" with BOMLevel1 as
(select d.MD001,d.MD002, d.MD003 ,d.MD004, 1 as [Level]
from BOMMC c
inner join BOMMD d on MC001 = MD001
where MC001 = 'BFFFLX551510014400D'
union all 
select d.MD001,d.MD002, d.MD003 ,d.MD004, dlevel.Level+1
from BOMMD d
inner join BOMLevel1 dlevel on d.MD001 = dlevel.MD003
)
select distinct * from BOMLevel1 order by Level ");
            SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
            sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
    }
}
