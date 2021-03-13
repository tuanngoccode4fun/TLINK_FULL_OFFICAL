using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.SettingForm
{
    public partial class Change_Password : CommonFormMetro
    {
        public Change_Password()
        {
            InitializeComponent();
        }
        bool checkdata()
        {

            if (txt_pass.Text == "" || txt_pass_confirm.Text == "")
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data is null", "Warning System", this);
                return false;
            }
            if (txt_pass.Text !=  txt_pass_confirm.Text )
            {
                infomesge mes = new infomesge();
                mes.ErrorMesger("Password confirm is not correct", "Warning System", this);
                return false;
            }
            return true;

        }
        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (checkdata()== false)
            {
                return;
            }
            
            string sql = "update m_user set password ='"+ txt_pass_confirm.Text+ "' where usercode = '"+ Class.valiballecommon.GetStorage().UserCode+ "'";
            sqlCON connect = new sqlCON();
            connect.sqlExecuteNonQuery(sql, true);
        }
    }
}
