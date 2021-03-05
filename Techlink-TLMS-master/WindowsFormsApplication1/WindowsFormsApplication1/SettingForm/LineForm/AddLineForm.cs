using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.SettingForm.LineForm
{
    public partial class AddLineForm : CommonFormMetro
    {
        public AddLineForm()
        {
            InitializeComponent();
            AcceptButton = btn_ok;
        }
        int addupdate = 0; //0 update, 1 add

        string sql = "";
        bool checkdata()
        {
            if (txt_linecode.Text == "" || txt_linename.Text == "" )
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data is null", "Warning System", this);
                return false;
            }
            sqlCON connect = new sqlCON();
            if (int.Parse(connect.sqlExecuteScalarString("select count(*) from m_line where linecode ='" +txt_linecode.Text + "'")) > 0 && addupdate == 1)
            {
                infomesge mes = new infomesge();
                mes.ErrorMesger("UserCode is duplicate", "Error System", this);
                return false;
            }
            return true;
        }
        private void AddLineForm_Load(object sender, EventArgs e)
        {
            if (Class.valiballecommon.GetStorage().value1 != null)
            {
                txt_linecode.Text = Class.valiballecommon.GetStorage().value1;
                txt_linename.Text = Class.valiballecommon.GetStorage().value2;

                txt_linecode.Enabled = false;
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

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (checkdata() == false)
            {
                return;
            }
            if (addupdate == 1)
            {
                sql = @"insert into m_line(linecode, linename,  datetimeRST) values('"
                          + txt_linecode.Text + "','" +txt_linename.Text + "',GETDATE())";
            }
            else
            {
                sql = "update m_line set linename  =  '" + txt_linename.Text + "' where linecode= '" + txt_linecode.Text + "'";

            }

            sqlCON connect = new sqlCON();
            connect.sqlExecuteNonQuery(sql, true);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
