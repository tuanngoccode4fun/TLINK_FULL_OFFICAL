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

                Logfile.Output(StatusLog.Error, "GetTargetMQC (string model, string date)", EX.Message);
            }
            return target;
        }

        public TargetMQC GetArraystarget(string model, DateTime from, DateTime to)
        {
            try
            {


                TargetMQC targetReurn = new TargetMQC();
                int[] target = new int[2];
                StringBuilder stringBuilder = new StringBuilder();
                stringBuilder.Append(" select distinct  ISNULL(sum(cast(OUTPUT as int)),0) as output,ISNULL(sum(cast(SCRAP as int)),0) as scrap from DAILYTARGET where 1=1 ");
                stringBuilder.Append(" and PRODCODE = '" + model + "'");
                stringBuilder.Append(" and cast(DATE as DATE) >= '" + from.ToString("yyyyMMdd") + "' ");
                stringBuilder.Append(" and cast(DATE as DATE) <= '" + to.ToString("yyyyMMdd") + "' ");
                DataTable dt = new DataTable();
                SQLERPTarget sqlERPtarget = new SQLERPTarget();
                sqlERPtarget.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
                if (dt.Rows.Count == 1)
                {
                    target[0] = int.Parse(dt.Rows[0]["output"].ToString().Trim());
                    target[1] = int.Parse(dt.Rows[0]["scrap"].ToString().Trim());

                    targetReurn.model = model;
                    targetReurn.TargetOutput = target[0];
                    targetReurn.TargetDefect = target[1];
                }
                return targetReurn;
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
