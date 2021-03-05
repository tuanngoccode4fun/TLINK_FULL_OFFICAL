using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ERPShowOrder
{
    public partial class Order_PDC : CommonForm
    {
        public Order_PDC()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void Order_PDC_Load(object sender, EventArgs e)
        {  
            string sql = "select DISTINCT TC001 from COPTC where TC001 like '" + Class.valiballecommon.GetStorage().Permission.Substring(Class.valiballecommon.GetStorage().Permission.Length-1) + "%' order by TC001 ASC";
            // Class.valiballecommon.GetStorage().Permission
            
            sqlERPCON connect = new sqlERPCON();
            connect.getComboBoxData(sql, ref cmb_TC001);

            //phan quyen: phong ban nao chi thay phong ban do, amdin_xxxx thay tat ca trong  
            string sql2 = "select DISTINCT TA001 from MOCTA where TA001 like '" + Class.valiballecommon.GetStorage().Permission.Substring(Class.valiballecommon.GetStorage().Permission.Length - 1) + "%' order by TA001 ASC";
            // Class.valiballecommon.GetStorage().Permission
            sqlERPCON connect2 = new sqlERPCON();
            connect2.getComboBoxData(sql2, ref cmb_TA001);


        }
        private void cmb_ordercode_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select DISTINCT TC002 from COPTC where TC001 like '" + cmb_TC001.Text + "' order by TC002 ASC";
            sqlERPCON connect = new sqlERPCON();
            connect.getComboBoxData(sql, ref cmb_TC002);
        }

        private void cmd_product_cmd_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select DISTINCT TA002 from MOCTA where TA001 like '" + cmb_TA001.Text + "' order by TA002 ASC";
            sqlERPCON connect = new sqlERPCON();
            connect.getComboBoxData(sql, ref cmb_TA002);
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            if (checkdata() == false) return;

            checkdulucate(true);
            updatedata();
            checkdulucate(false);
        }
        bool checkdata()
        {
            if (cmb_TC001.Text == "" || cmb_TC002.Text == "" || cmb_TA001.Text == "" || cmb_TA002.Text == "")
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data is null", "Warning System", this);
                return false;
            }
            return true;
        }
        void checkdulucate(bool check )
        {
            dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from t_OCTA where 1=1  ");
            sql.Append(" and TA01 = '" + cmb_TA001.Text + "'");
            sql.Append(" and TA02 = '" + cmb_TA002.Text + "'");
            sql.Append(" and TA03 = '" + cmb_TC001.Text + "'");
            sql.Append(" and TA04 = '" + cmb_TC002.Text + "'");
            sql.Append("order by TAID");
            sqlCON conect = new sqlCON();
            conect.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            dgv_connectdata.DataSource = dt;
            if (dgv_connectdata.RowCount > 0 && check == true ) //checktruoc
            {
                infomesge mes = new infomesge();
                mes.ErrorMesger("UserCode is duplicate", "Infomation System", this);
            }

        }
        void updatedata()
        {
            StringBuilder sql = new StringBuilder();
            sql.Append("insert into t_OCTA(TA01, TA02, TA03, TA04,UserName, datetimeRST) values('" + cmb_TA001.Text + "','" + cmb_TA002.Text + "','" + cmb_TC001.Text + "','" + cmb_TC002.Text + "','"+Class.valiballecommon.GetStorage().UserName+ "',GETDATE())");
            sqlCON con = new sqlCON();
            con.sqlExecuteNonQuery(sql.ToString(), true);
        }
    }
}
