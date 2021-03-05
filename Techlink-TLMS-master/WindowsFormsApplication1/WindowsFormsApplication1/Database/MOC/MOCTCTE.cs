using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace WindowsFormsApplication1.Database.MOC
{
  public  class MOCTCTE
    {
        public DataTable GetdtMOCTCTE(string type, string No)
        {
            DataTable dt = new DataTable();
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"select TE001, TE002, TE003, TE004, TE005,TE006,TE007, TE008, TE009,TE010, TE011, TE012, TE017, TE029, TC009 from MOCTC  a
inner join MOCTE b on TC001 = TE001 and TC002 = TE002
where 1 = 1 ");
            stringBuilder.Append(" and TC001 ='" + type + "' ");
            stringBuilder.Append(" and TC002 ='" + No + "' ");
            sqlERPCON sqlERPCON = new sqlERPCON();
            sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            return dt;
        }
        public bool UpdateMOCTC(DataTable dtExport)
        {
            for (int i = 0; i < dtExport.Rows.Count; i++)
            {
                string type = dtExport.Rows[i]["TE001"].ToString().Trim();
                string No = dtExport.Rows[i]["TE002"].ToString().Trim();
                string STT = dtExport.Rows[i]["TE003"].ToString().Trim();
                StringBuilder stringMOCTE = new StringBuilder();
                stringMOCTE.Append(" update MOCTE set TE019 ='Y' where 1=1 ");
                stringMOCTE.Append(" and TE001 ='" + type + "' ");
                stringMOCTE.Append(" and TE002 ='" + No + "' ");
                stringMOCTE.Append(" and TE003 ='" + STT + "' ");
                sqlERPCON sqlERPCON = new sqlERPCON();
       var result =         sqlERPCON.sqlExecuteNonQuery(stringMOCTE.ToString(), false);

            }
            StringBuilder stringMOCTC = new StringBuilder();
            string typeC = dtExport.Rows[0]["TE001"].ToString().Trim();
            string NoC= dtExport.Rows[0]["TE002"].ToString().Trim();
            stringMOCTC.Append(" update MOCTC set TC009 = 'Y' where 1=1 ");
            stringMOCTC.Append(" and TC001 ='" + typeC + "' ");
            stringMOCTC.Append(" and TC002 ='" + NoC + "' ");
            sqlERPCON sqlERPCON1 = new sqlERPCON();
        var result2=     sqlERPCON1.sqlExecuteNonQuery(stringMOCTC.ToString(), false);



            return true;
        }
    }
}
