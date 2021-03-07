using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1.SettingForm.RegisterUserForm
{
    public partial class AddRegisterUser : CommonFormMetro
    {
        public AddRegisterUser()
        {
            InitializeComponent();
            AcceptButton = btn_ok;

        }
        int addupdate = 0; //0 update, 1 add
        string sql = "";
        bool checkdata()
        {
            if (txt_usercode.Text == "" || txt_username.Text == ""||cmb_permission.Text =="")
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data is null", "Warning System", this);
                return false;
            }
            sqlCON connect = new sqlCON();
            if (int.Parse(connect.sqlExecuteScalarString("select count(*) from m_user where usercode ='" + txt_usercode.Text + "'")) > 0 && addupdate == 1)
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
            if (addupdate == 1)
            {
                sql = @"insert into m_user(usercode, username, permission,password,  datetimeRST) values('"
                          + txt_usercode.Text + "','" + txt_username.Text + "','"+cmb_permission.Text+"','1111',GETDATE())";
            }
            else
            {
                sql = "update m_user set username  =  '" + txt_username.Text + "', permission = '"+ cmb_permission.Text + "' where usercode= '" + txt_usercode.Text + "'";

            }

            sqlCON connect = new sqlCON();
            connect.sqlExecuteNonQuery(sql, true);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddRegisterUser_Load(object sender, EventArgs e)
        {
            string sql = "select distinct permission from m_permission ";
            sqlCON connect = new sqlCON();
            connect.getComboBoxData(sql, ref cmb_permission);
            if (Class.valiballecommon.GetStorage().value1 != null)
            {
                txt_usercode.Text = Class.valiballecommon.GetStorage().value1;
                txt_username.Text = Class.valiballecommon.GetStorage().value2;
                cmb_permission.Text = Class.valiballecommon.GetStorage().value3;
                txt_usercode.Enabled = false;
                Class.valiballecommon va = Class.valiballecommon.GetStorage();
                va.value1 = null;
                va.value2 = null;
                va.value3 = null;
                addupdate = 0;
            }
            else
            {
                addupdate = 1;
            
            }
        }

        private void cmb_permission_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
