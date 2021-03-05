using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.BOM
{
  public  class BOMHQ
    {
        public DataTable GetDataTableBOMHQonERP( string ma_SP)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@" with BOMLevel1 as
(select d.MD001 ,d.MD002, d.MD003 ,d.MD004,cast(MD006/MD007 as decimal(10,3)) as Amoutused, 1 as [Level]
from BOMMC c
inner join BOMMD d on MC001 = MD001 ");
            stringBuilder.Append(" where MC001 = '" + ma_SP + "' ");
            stringBuilder.Append(@" union all 
select d.MD001,d.MD002, d.MD003 ,d.MD004,cast(MD006/MD007 as decimal(10,3)) as Amoutused, dlevel.Level+1
from BOMMD d
inner join BOMLevel1 dlevel on d.MD001 = dlevel.MD003
)
select distinct d.MB201 as MA_NVL,f.XA003 as HS_CODE, cast( SUM(c.Amoutused/e.MC004 ) as decimal(10,3)) as DM_SD , c.MD004 as MA_DVT from BOMLevel1 c
inner join INVMB d on MB001 = c.MD003
inner join BOMMC e on c.MD001 = e.MC001 
inner join BOMXA f on d.MB201 = f.XA001
WHERE Level < 2 AND MB201 != ''
group by d.MB201, c.MD004,c.Level, f.XA003 ");
            sqlERPCON sqlERPCON = new sqlERPCON();
            sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
    }
}
