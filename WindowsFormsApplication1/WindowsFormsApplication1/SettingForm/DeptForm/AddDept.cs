using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.SettingForm.DeptForm
{
    public partial class AddDept : CommonFormMetro
    {
        public AddDept()
        {
            InitializeComponent();
            AcceptButton = btn_ok;
        }
        int addupdate = 0; //0 update, 1 add

        string sql = "";
        bool checkdata()
        {
            if (txt_deptcode.Text == "" || txt_deptname.Text == "")
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data is null", "Warning System", this);
                return false;
            }
            sqlCON connect = new sqlCON();
            if (int.Parse(connect.sqlExecuteScalarString("select count(*) from m_dept where deptcode ='" + txt_deptcode.Text + "'")) > 0 && addupdate == 1)
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
                sql = @"insert into m_dept(deptcode, deptname,  datetimeRST) values('"
                          + txt_deptcode.Text + "','" + txt_deptname.Text + "',GETDATE())";
            }
            else
            {
                sql = "update m_dept set deptname  =  '" + txt_deptname.Text + "' where deptcode= '" + txt_deptcode.Text + "'";

            }

            sqlCON connect = new sqlCON();
            connect.sqlExecuteNonQuery(sql, true);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void AddDept_Load(object sender, EventArgs e)
        {
            if (Class.valiballecommon.GetStorage().value1 != null)
            {
                txt_deptcode.Text = Class.valiballecommon.GetStorage().value1;
                txt_deptname.Text = Class.valiballecommon.GetStorage().value2;

                txt_deptcode.Enabled = false;
                Class.valiballecommon va = Class.valiballecommon.GetStorage();
                va.value1 = null;
                va.value2 = null;

                addupdate = 0;
            }
            else
            {
                addupdate = 1;

            }
        }
    }
}

