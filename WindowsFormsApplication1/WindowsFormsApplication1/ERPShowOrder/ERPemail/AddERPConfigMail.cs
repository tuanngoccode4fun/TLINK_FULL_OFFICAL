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
    public partial class AddERPConfigMail : CommonForm
    {
        public AddERPConfigMail()
        {
            InitializeComponent();
        }
        int addupdate = 0; //0 update, 1 add
        string sql = "";
        private void AddERPConfigMail_Load(object sender, EventArgs e)
        {
            sqlCON dept = new sqlCON();
            string sqldept = "select distinct deptcode from m_dept order by deptcode";
            dept.getComboBoxData(sqldept, ref cmb_deptcode);
            sqlCON function = new sqlCON();
            string sqlfunction = "select distinct usingfunction from m_email order by usingfunction";
            function.getComboBoxData(sqlfunction, ref cmb_usingfunction);
            cmb_defaultstatus.Items.Add("YES");
            cmb_defaultstatus.Items.Add("NO");
            if (Class.valiballecommon.GetStorage().value1 != null)
            {
                cmb_deptcode.Text = Class.valiballecommon.GetStorage().value1;
                txt_emailaddress.Text = Class.valiballecommon.GetStorage().value2;
                cmb_usingfunction.Text = Class.valiballecommon.GetStorage().value3;
                cmb_defaultstatus.Text = Class.valiballecommon.GetStorage().value4;
                txt_emailaddress.Enabled = false;
                Class.valiballecommon va = Class.valiballecommon.GetStorage();
                va.value1 = null;
                va.value2 = null;
                va.value3 = null;
                va.value4 = null;
              
                addupdate = 0;
            }
            else
            {
                addupdate = 1;
            }
        }
        bool checkdata()
        {
            if (cmb_deptcode.Text == "" || txt_emailaddress.Text == "" || cmb_usingfunction.Text == "" || cmb_defaultstatus.Text == "")
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data is null", "Warning System", this);
                return false;
            }
            sqlCON connect = new sqlCON();
            if (int.Parse(connect.sqlExecuteScalarString("select count(*) from m_email where emailaddress ='" + txt_emailaddress.Text + "' and usingfunction ='" + cmb_usingfunction.Text + "'")) > 0 && addupdate == 1)
            {
                infomesge mes = new infomesge();
                mes.ErrorMesger("UserCode is duplicate", "Error System", this);
                return false;
            }
            return true;
        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (checkdata() == false)
            {
                return;
            }
            if (addupdate == 1) //add
            {
                sql = @"insert into m_email(emailaddress, deptcode, status, usingfunction, datetimeRST) values('"
                          + txt_emailaddress.Text + "','" + cmb_deptcode.Text + "','" + cmb_defaultstatus.Text + "','" + cmb_usingfunction.Text + "',GETDATE())";
            }
            else //update
            {
                sql = "update m_email set deptcode  =  '" + cmb_deptcode.Text + "', status = '" + cmb_defaultstatus.Text + "', usingfunction ='" + cmb_usingfunction.Text + "' where id = '" + Class.valiballecommon.GetStorage().valuleID + "'";
                Class.valiballecommon va = Class.valiballecommon.GetStorage();
                va.valuleID = null;
            }

            sqlCON connect = new sqlCON();
            connect.sqlExecuteNonQuery(sql, true);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

    }
}
