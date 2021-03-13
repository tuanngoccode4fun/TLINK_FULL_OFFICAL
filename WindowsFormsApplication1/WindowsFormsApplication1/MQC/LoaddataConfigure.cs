using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;


namespace WindowsFormsApplication1.MQC
{
    class LoaddataConfigure
    {
        
        public List<DeptCodeName> deptCodeNames ( ref ComboBox comboBox)
        {
            comboBox.Items.Clear();
            List<DeptCodeName> deptCodes = new List<DeptCodeName>();
            StringBuilder sql = new StringBuilder();
            sql.Append("select MD001,MD002 ");
            sql.Append("from dbo.ERP_CMSMD ");
            sql.Append("where 1=1 ");
            sqlSFT sqlSFT = new sqlSFT();
            DataTable dt = new DataTable();
            sqlSFT.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            deptCodes = (from DataRow dr in dt.Rows
                                select new DeptCodeName()
                                {
                                    DeptCode= dr["MD001"].ToString(),
                                    DeptName = "[" + dr["MD001"].ToString() + "] - " + dr["MD002"].ToString()
                                    

                                }).ToList();

            foreach (var item in deptCodes)
            {
                comboBox.Items.Add(item.DeptName);

            }

            return deptCodes;
        }
        public List<DeptCodeName> deptCodeNames()
        {
       
            List<DeptCodeName> deptCodes = new List<DeptCodeName>();
            StringBuilder sql = new StringBuilder();
            sql.Append("select MD001,MD002 ");
            sql.Append("from dbo.ERP_CMSMD ");
            sql.Append("where 1=1 ");
            sqlSFT sqlSFT = new sqlSFT();
            DataTable dt = new DataTable();
            sqlSFT.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            deptCodes = (from DataRow dr in dt.Rows
                         select new DeptCodeName()
                         {
                             DeptCode = dr["MD001"].ToString(),
                             DeptName = "[" + dr["MD001"].ToString() + "] - " + dr["MD002"].ToString()


                         }).ToList();

        

            return deptCodes;
        }
        public List<string>ListProduct (string dept)
        {
            List<string> listproduct = new List<string>();
            List<DeptCodeName> deptCodes = new List<DeptCodeName>();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"SELECT DISTINCT TC047 FROM SFCTA
left join SFCTC on TA001 = TC004 and TA002 = TC005 ");
            sql.Append("where 1=1 and TA011+TA012 <TA010 ");
            sql.Append("and TA004 = '" + dept +"'" );
            sqlERPCON sqlERPCON = new sqlERPCON();
            DataTable dt = new DataTable();
            sqlERPCON.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            listproduct = dt.AsEnumerable()
                           .Select(r => r.Field<string>("TC047"))
                           .ToList();

            return listproduct;
        }
    }
    public class DeptCodeName
    {
        public string DeptCode { get; set; }
        public string DeptName { get; set; }
    }
}
