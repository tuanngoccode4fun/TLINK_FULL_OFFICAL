using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.CustomsDeclarasion.Controller
{
 public   class GetToKhaiNhap
    {
        public DataTable GetTableToKHaiNhap(string Ma_NPL, string HsCode)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"   select distinct b.NGAY_DK, a.SOTK, a.MA_LH, a.MA_HQ, NUOC_XX, TEN_NUOC_XX, MA_DVT, a.LUONG, a.DGIA_KB from [dbo].[DHANGMDDK] a
   inner join dbo.CX_ECX_NPLNHAP_TL b on a.SOTK = b.SOTK
  where CAST(b.NGAY_DK as date) >= '2019-06-01' ");
            stringBuilder.Append(" and MA_NPL_SP = '" + Ma_NPL + "' ");
            stringBuilder.Append(" and  MA_HANGKB = '" + HsCode + "' ");
            SQLCustoms sQLCustoms = new SQLCustoms();
            sQLCustoms.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);


            return dt;
        }
    }
}
