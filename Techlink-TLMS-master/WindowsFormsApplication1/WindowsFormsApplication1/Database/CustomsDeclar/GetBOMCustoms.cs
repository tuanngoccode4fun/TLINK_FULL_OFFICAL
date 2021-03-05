using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.CustomsDeclar
{
 public   class GetBOMCustoms
    {
       public DataTable LayMaSpHQNam20()
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select * from dbo.CX_SSP where MA_SP like '20-%' ");
            SQLCustoms sQLCustoms = new SQLCustoms();
            sQLCustoms.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public DataTable BOMHAIQUANTheoMaSp(string MA_SP_HQ )
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"  select distinct a.MA_NPL,  b.MA_HS, cast( a.DM_SD as decimal(10,3)) as DM_SD  , a.MA_DVT from CX_DDINHMUC a
 left join CX_SNPL b on a.MA_NPL = b.MA_NPL
 where 1 = 1 ");
            stringBuilder.Append("and MA_SP = '" + MA_SP_HQ + "' ");
            SQLCustoms sQLCustoms = new SQLCustoms();
            sQLCustoms.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
    }
}
