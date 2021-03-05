using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.SettingForm.IPPLC
{
    public partial class AddIPPLC : CommonFormMetro
    {
        public AddIPPLC()
        {
            InitializeComponent();
            AcceptButton = btn_ok;
        }
        int addupdate = 1;
        private void AddIPPLC_Load(object sender, EventArgs e)
        {
            sqlCON data = new sqlCON();
            if (Class.valiballecommon.GetStorage().value1 != null)
            {

                if (Class.valiballecommon.GetStorage().value6 == "True")
                {
                    chk_active.Checked = true;
                }
                else
                {
                    chk_active.Checked = false;
                }
                cmb_factory.Text = Class.valiballecommon.GetStorage().value1;
                cmb_process.Text = Class.valiballecommon.GetStorage().value2; ;
                cmb_line.Text = Class.valiballecommon.GetStorage().value3;
                txt_modelPLC.Text = Class.valiballecommon.GetStorage().value4;
                cmb_ip.Text = Class.valiballecommon.GetStorage().value5;
               // chk_active.Enabled = false;
                cmb_ip.Enabled = false;
                Class.valiballecommon va = Class.valiballecommon.GetStorage();
                va.value1 = null;
                va.value2 = null;

                addupdate = 0;
            }
            else
            {
                addupdate = 1;
                data.getComboBoxData("select distinct IPPLC from m_ipPLC", ref cmb_ip);
                data.getComboBoxData("select distinct factory from m_ipPLC", ref cmb_factory);
                data.getComboBoxData(" select distinct process from m_ipPLC", ref cmb_process);
                data.getComboBoxData("select distinct line from m_ipPLC", ref cmb_line);
            }

        }

        private void cmb_factory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder();
            if (checkdata() == false)
            {
                return;
            }
            if (addupdate == 1)
            {
                sql.Append("insert into m_ipPLC(factory, process,  line, modelPLC, IPPLC, isactive, datetimeRST) values('"
                          + cmb_factory.Text + "','" + cmb_process.Text + "','" + cmb_line.Text + "','" + txt_modelPLC.Text + "','" + cmb_ip.Text + "','");
                if(chk_active.Checked == true)
                {
                    sql.Append("true', GETDATE())");
                }
                else
                {
                    sql.Append("false', GETDATE())");
                }
               


            }
            else
            {
               

                if (chk_active.Checked == true)
                {
                    sql.Append("update m_ipPLC set isactive  =  'true',  line = '"+ cmb_line .Text+ "' where IPPLC= '" + cmb_ip.Text + "'");
                }
                else
                {
                    sql.Append("update m_ipPLC set isactive  =  'false' ,  line = '" + cmb_line.Text + "' where IPPLC= '" + cmb_ip.Text + "'");
                }

            }

            sqlCON connect = new sqlCON();
            connect.sqlExecuteNonQuery(sql.ToString(), true);
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        bool checkdata()
        {
            if (cmb_process.Text == "" || cmb_line.Text == "" || cmb_factory.Text == "" || cmb_ip.Text == "")
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data is null", "Warning System", this);
                return false;
            }
            sqlCON connect = new sqlCON();
            if (int.Parse(connect.sqlExecuteScalarString("select count(*) from m_ipPLC where IPPLC ='" + cmb_ip.Text + "'")) > 0 && addupdate == 1)
            {
                infomesge mes = new infomesge();
                mes.ErrorMesger("UserCode is duplicate", "Error System", this);
                return false;
            }
            return true;
        }
    }
}
