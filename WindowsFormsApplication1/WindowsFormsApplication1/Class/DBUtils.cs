using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    class DBUtils
    {
        public static bool TLINK = false;// [True]: Test TechLink  [False]: Test LOCAL PC
        public static SqlConnection GetDBConnection()
        {


            string datasource = "172.16.0.12";
            string database = "ERPSOFT";
            string username = "ERPUSER";
            string password = "12345";
            if (TLINK)// TLINK
            {
                return DBSQLServerUtils.GetDBConnection(datasource, database, username, password);
            }
            else// Test local 
            {
                 string connecString = string.Format("Data Source=ADMIN;Initial Catalog={0};Integrated Security=True", database);
                 return new SqlConnection(connecString);
            }
        }
        public static SqlConnection GetERPDBConnection()
        {
            //Data Source = LONG; Initial Catalog = TEST; Integrated Security = True
            string datasource = "172.16.0.11";
            string database = (Class.valiballecommon.GetStorage().DBERP != null) ? Class.valiballecommon.GetStorage().DBERP : "TLVN2";
            string username = "soft";
            string password = "techlink@!@#";
            return DBSQLServerUtils.GetERPDBConnection(datasource, database, username, password);
        }
        public static SqlConnection GetTLVN2DBConnection()
        {

            var test = Class.valiballecommon.GetStorage().DBERP;
            string datasource = "172.16.0.11";
            string database = (Class.valiballecommon.GetStorage().DBERP != null) ? Class.valiballecommon.GetStorage().DBERP : "TLVN2";
            string username = "soft";
            string password = "techlink@!@#";
            if (TLINK)// TLINK
            {
                return DBSQLServerUtils.GetTLVN2Connection(datasource, database, username, password);
            }
            else// Test local 
            {
                string connecString = string.Format("Data Source=ADMIN;Initial Catalog={0};Integrated Security=True", database);
                return new SqlConnection(connecString);
            }         
        }
        public static SqlConnection GetSFTDBConnection()
        {
            //Data Source = LONG; Initial Catalog = TEST; Integrated Security = True
            string datasource = "172.16.0.11";
            string database = (Class.valiballecommon.GetStorage().DBSFT != null) ? Class.valiballecommon.GetStorage().DBSFT : "SFT_TLVN2";
            string username = "soft";
            string password = "techlink@!@#";


            return DBSQLServerUtils.GetSFTDBConnection(datasource, database, username, password);
        }
        public static SqlConnection GetERPTargetBConnection()
        {
            //Data Source = LONG; Initial Catalog = TEST; Integrated Security = True
            string datasource = "172.16.0.11";
            string database = "SOT";
            string username = "soft";
            string password = "techlink@!@#";


            return DBSQLServerUtils.GetSFTDBConnection(datasource, database, username, password);
        }
        public static SqlConnection GetHRDATAConnection()
        {
            //Data Source = LONG; Initial Catalog = TEST; Integrated Security = True
            string datasource = "172.16.0.9\\tx";
            string database = "txcard";
            string username = "sa";
            string password = "ppnn13";
            return DBSQLServerUtils.GetHRDataConnection(datasource, database, username, password);
        }
        public static SqlConnection GetCustomsConnection()
        {
            //Data Source = LONG; Initial Catalog = TEST; Integrated Security = True
            string datasource = "172.16.2.12\\SQLEXPRESS";
            string database = "ECUS5VNACCS_DG";
            string username = "sa";
            string password = "";
            return DBSQLServerUtils.GetCustomsConnection(datasource, database, username, password);
        }
    }

}