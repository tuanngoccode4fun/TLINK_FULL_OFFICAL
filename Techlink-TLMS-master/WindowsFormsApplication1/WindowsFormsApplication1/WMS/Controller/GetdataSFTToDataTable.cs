using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.WMS.Controller
{
   public class GetdataSFTToDataTable
    {
        public DataTable GetDatatableFromSFT_TRANSORDER()
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select top(1) * from SFT_TRANSORDER ");
            sqlSFT sqlSFT = new sqlSFT();
            sqlSFT.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public DataTable GetDatatableFromSFT_TRANSORDER_LINE()
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select top(1) * from SFT_TRANSORDER_LINE ");
            sqlSFT sqlSFT = new sqlSFT();
            sqlSFT.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public DataTable GetDatatableFromSFT_WS_RUN()
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select top(1) * from  SFT_WS_RUN ");
            sqlSFT sqlSFT = new sqlSFT();
            sqlSFT.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public DataTable GetDataTableFromLot()
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(" select top(1) * from LOT ");
            sqlSFT sqlSFT = new sqlSFT();
            sqlSFT.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public DataTable GetDataTableLOTMODETAIL(string productCode)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"select  *  from LOT a 
 left join MODETAIL b on CMOID = ID
 where  1 = 1
 and ERP_OPSEQ = '0020'
 and a.STATUS = '130'
 and b.STATUS != '99' and b.STATUS != '100'
");
            stringBuilder.Append(" and a.ID= '" + productCode + "'");
            sqlSFT sqlSFT = new sqlSFT();
            sqlSFT.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
    }
}
