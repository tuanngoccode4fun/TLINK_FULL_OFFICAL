using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using WindowsFormsApplication1.Planning;

namespace WindowsFormsApplication1.Planning.Controler
{
   public class GetProductionOrder
    {
        public DataTable GetProductionOrderStatus(string Code, string No,string STT)
        {

            DataTable dt = new DataTable();
            ProductionOrderStatus POStatus = new ProductionOrderStatus();
            try
            {
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select *  from MOCTA where 1=1 ");
                stringBuilder.Append(" and TA026 ='" + Code + "' ");
                stringBuilder.Append(" and TA027 = '" + No + "' ");
                stringBuilder.Append(" and TA028 = '" + STT + "' ");
                stringBuilder.Append(" and TA013 = '" + "Y" + "' ");

                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
             
                sqlTLVN2.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            if(dt.Rows.Count > 0)
                {
                   
                }

            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetProductionOrderStatus(string clientOrder)", ex.Message);
            }
            return dt;
        }
    }
}
