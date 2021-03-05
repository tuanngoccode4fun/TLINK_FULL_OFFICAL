using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.NewQRcode
{
    public class GetListDocNo
    {
        public static List<string> GetListForCombox()
        {
            string temp = null;
            List<string> listReturn = new List<string>();
            try
            {
                string m_query_MOCTF = @"select distinct TF001 from MOCTF";/// included D301
                string m_query_CMSMQ = @"select * from CMSMQ a where a.MQ003 like '%58%'";/// None D301
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                DataTable dt = new DataTable();
                sqlTLVN2.sqlDataAdapterFillDatatable(m_query_MOCTF, ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    listReturn.Add(dt.Rows[i]["TF001"].ToString().Trim());
                }
                dt = new DataTable();
                sqlTLVN2.sqlDataAdapterFillDatatable(m_query_CMSMQ, ref dt);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    temp = dt.Rows[i]["MQ001"].ToString().Trim();
                    if (!listReturn.Contains(temp))
                    {
                        listReturn.Add(temp);
                    }
                }
                return listReturn;
            }
            catch (Exception ex)
            {
                listReturn = new List<string>();
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "List<string> GetListDocNo()", ex.Message);
                return listReturn;
            }
        }
        public static string GetDescribeDocNo(string DocNo)
        { 
          try
            {
                string m_query_CMSMQ = @"select distinct a.MQ002 from CMSMQ a where a.MQ001 ='" + DocNo.ToString()+"'";
                SqlTLVN2 sqlTLVN2 = new SqlTLVN2();
                return sqlTLVN2.sqlExecuteScalarString(m_query_CMSMQ);
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "string GetDescribeDocNo()", ex.Message);
                return null;
            }
}
    }
}
