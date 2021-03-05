using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace UploadDataToDatabase.MQC
{
    class LoadTargetProduction
    {
       public TargetMQC GetTargetMQC (string model, string date)
        {
            TargetMQC target = new TargetMQC();
            try
            {
                StringBuilder sql = new StringBuilder();
                sql.Append("select distinct DATE, PRODCODE,OUTPUT,SCRAP ");
                sql.Append("from DAILYTARGET ");
                sql.Append("where 1=1 ");
                sql.Append("and PRODCODE = '" + model + "'");
                sql.Append("and DATE = '" + date + "'");
                SQLERPTarget sqlERPtarget = new SQLERPTarget();
                DataTable dt = new DataTable();
                sqlERPtarget.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
                var target1 = (from DataRow dr in dt.Rows
                               select new TargetMQC()
                               {
                                   Date = dr["DATE"].ToString(),
                                   model = dr["PRODCODE"].ToString(),
                                   TargetOutput = (dr["OUTPUT"].ToString() != "") ? double.Parse(dr["OUTPUT"].ToString()) : 0,
                                   TargetDefect = (dr["SCRAP"].ToString() != "") ? double.Parse(dr["SCRAP"].ToString()) : 0

                               }).ToList();
                if (target1 != null && target1.Count > 0)
                    target = target1[0];
            }
            catch (Exception EX)
            {

                Log.Logfile.Output(Log.StatusLog.Error, "GetTargetMQC (string model, string date)", EX.Message);
            }
            return target;
        }
    }
}
