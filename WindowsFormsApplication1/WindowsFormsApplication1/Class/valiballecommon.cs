using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1.Class
{
    [Serializable]
    public   class valiballecommon
    {
        private static readonly valiballecommon storage = new valiballecommon();

        
        public static valiballecommon GetStorage()
        {
            return storage;
        }
        public string UserName { get; set; }
        public string UserCode { get; set; }
        public string Permission { get; set; }
        public string PCName { get; set; }
        public string Language { get; set; }
        public string _version { get; set; }
        public string value1 { get; set; }
        public string value2 { get; set; }
        public string value3 { get; set; }
        public string value4{ get; set; }
        public string value5 { get; set; }
        public string value6 { get; set; }
        public string valuleID { get; set; }
        public string DBERP { get; set; }
        public string DBSFT { get; set; }
        public string Department { get; set; }
        public string Warehouse { get; set; }
        public DateTime LastUser { get; set; }
        public string Client { get; set; }
        public string Currency { get; set; }
        
        public string DocNo { get; set; }

        //class Storage_Static
        //{
        //    public static string Username { get; set; }
        //}
    }
}
