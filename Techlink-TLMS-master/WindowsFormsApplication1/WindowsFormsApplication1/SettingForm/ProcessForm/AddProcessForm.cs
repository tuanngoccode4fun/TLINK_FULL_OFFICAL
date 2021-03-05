using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.SettingForm.ProcessForm
{
    public partial class AddProcessForm : CommonFormMetro
    {
        public AddProcessForm()
        {
            InitializeComponent();
            AcceptButton = btn_ok;
        }


        private void AddProcessForm_Load_2(object sender, EventArgs e)
        {
            sqlCON connect = new sqlCON();
            string sql = "select distinct modelcode from m_model order by modelcode";
            connect.getComboBoxData(sql, ref cmb_modelcode);
            if (Class.valiballecommon.GetStorage().value1 != null)
            {
                cmb_modelcode.Text = Class.valiballecommon.GetStorage().value1;
                cmb_processcode.Text = Class.valiballecommon.GetStorage().value2;
                txt_processname.Text = Class.valiballecommon.GetStorage().value3;
                cmb_processcode.Enabled = false;
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
        private void cmb_modelcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_modelcode.Text == "") return;
            cmb_processcode.Text = "";
            cmb_processcode.DataSource = null;
            cmb_modelcode.DataSource = null;

            sqlCON connect = new sqlCON();
            string sql = "select distinct processcode from m_process where modelcode = '" + cmb_modelcode.Text + "' order by processcode";
            connect.getComboBoxData(sql, ref cmb_processcode);
        }
        private void cmb_processcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmb_processcode.Text == "") return;
            cmb_itemcode.Text = "";
            txt_processname.Text = "";
           // txt_processname.Enabled = false;
            cmb_itemcode.DataSource = null;
            sqlCON connect = new sqlCON();
            string sql = "select distinct itemcode from m_process where modelcode = '" + cmb_modelcode.Text + "' order by itemcode";
            connect.getComboBoxData(sql, ref cmb_itemcode);
            sqlCON processname = new sqlCON();
            string proname = "select distinct processname from m_process where processcode =  '" + cmb_processcode.Text + "'";
            txt_processname.Text = processname.sqlExecuteScalarString(proname);

        }
        private void cmb_itemcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            txt_itemname.Text = "";
           // txt_itemname.Enabled = false;
            sqlCON processname = new sqlCON();
            if (cmb_itemcode.Text == "") return;
            string proname = "select distinct itemname from m_process where itemcode =  '" + cmb_itemcode.Text + "'";
            txt_itemname.Text = processname.sqlExecuteScalarString(proname);
        }
       
        int addupdate = 0; //0 update, 1 add
        string sql = "";
        bool checkdata()
        {
            if (cmb_modelcode.Text == "" || cmb_processcode.Text == "" || cmb_itemcode.Text == "")
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data is null", "Warning System", this);
                return false;
            }
            sqlCON connect = new sqlCON();
            if (int.Parse(connect.sqlExecuteScalarString("select count(*) from m_process where processcode ='" + cmb_processcode.Text + "' and modelcode ='" + cmb_modelcode.Text + "' and itemcode ='" + cmb_itemcode.Text + "'")) > 0 && addupdate == 1)
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
                sql = @"insert into m_process(modelcode, processcode, processname, itemcode, itemname,  datetimeRST) values('"
                          + cmb_modelcode.Text + "','" + cmb_processcode.Text + "','" + txt_processname.Text + "','"+ cmb_itemcode.Text +"','"+ txt_itemname.Text + "',GETDATE())";
            }
            else //update
            {
            //  sql = "update m_process set itemcode  =  '" + txt_itemname.Text + "', itemname = '"+ txt_itemname.Text +"' where processcode = '" + cmb_processcode.Text + "' and modelcode = '" + cmb_modelcode.Text + "'";

            }

            sqlCON connect = new sqlCON();
            connect.sqlExecuteNonQuery(sql, true);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

      
    }
}
