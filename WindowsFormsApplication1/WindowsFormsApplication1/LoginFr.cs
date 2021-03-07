using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

using System.Data.SqlClient;
using System.Data.Common;
using WindowsFormsApplication1.ClassMysql;
using System.CodeDom.Compiler;

namespace WindowsFormsApplication1
{
   
    public partial class LoginFr : CommonFormMetro
    {
        public static string PathSaveConfig = Environment.CurrentDirectory + @"\Resources\Configure.ini";
        
        public LoginFr()
        {
            InitializeComponent();
            AcceptButton = btn_login;
            Class.valiballecommon.GetStorage().PCName = System.Environment.MachineName;
           // SystemLog.Output(SystemLog.MSG_TYPE.Nor, "dasdsad", "dasdadasddsda");
        }
        /// <summary>
        //Data Source=LONG;Initial Catalog=TEST;Integrated Security=True
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public SqlConnection conn = DBUtils.GetDBConnection();
        private void Form1_Load(object sender, EventArgs e)
        {
        
            
            string sql = "select distinct usercode from m_user ";
            sqlCON connect = new sqlCON();
            connect.getComboBoxData(sql, ref cmb_user);
            if (System.Deployment.Application.ApplicationDeployment.IsNetworkDeployed)
            {

                Version deploy = System.Deployment.Application.ApplicationDeployment.CurrentDeployment.CurrentVersion;

                StringBuilder version = new StringBuilder();
                //version.Append("VERSION:   ");
                version.Append("TechLink Version: ");
                version.Append(deploy.Major);
                version.Append("_");
                version.Append(deploy.Minor);
                version.Append("_");
                version.Append(deploy.Build);
                version.Append("_");
                version.Append(deploy.Revision);

                Version_lbl.Text = version.ToString();
                Class.valiballecommon.GetStorage()._version = Version_lbl.Text;
                
            }

            cb_Language.Items.Add("English");
            cb_Language.Items.Add("TiengViet");
            cb_Language.Items.Add("Chinese");
           
            cb_Database.Items.Add("TECHLINK");
            cb_Database.Items.Add("TLVN2");
            cb_Database.Items.Add("TLTEST");
            Class.valiballecommon SettingGet = new Class.valiballecommon();
            if (File.Exists(PathSaveConfig))
            {
                SettingGet = (Class.valiballecommon)SaveObject.Load_data(PathSaveConfig);
                if (SettingGet.Language == null)
                {
                    cb_Language.SelectedItem = "English";
                }
                if (SettingGet.DBERP == null)
                {
                    cb_Database.SelectedItem = "TLVN2";
                }
                Class.valiballecommon.GetStorage().Warehouse = SettingGet.Warehouse;
                Class.valiballecommon.GetStorage().Department = SettingGet.Department;
                Class.valiballecommon.GetStorage().Currency = SettingGet.Currency;
                Class.valiballecommon.GetStorage().Client = SettingGet.Client;
                //tuanngoc
                Class.valiballecommon.GetStorage().DocNo = SettingGet.DocNo;
            }
            else
            {
                cb_Language.SelectedItem = "English";
                cb_Database.SelectedItem = "TLVN2";
            }
            if (SettingGet.DBERP != null)
            {
                
                cb_Database.SelectedItem = SettingGet.DBERP;

            }
            if(SettingGet.UserCode  != null)
            {
                cmb_user.SelectedItem = SettingGet.UserCode;
            }
            if(SettingGet.Language != null)
            {
                cb_Language.SelectedItem = SettingGet.Language;
            }
          
        }
        bool checkdata()
        {
            if (cmb_user.Text == "" || txt_pass.Text == "")
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data is null", "Warning System", this);
                return false;
            }
            return true;
        }
        private void btn_login_Click(object sender, EventArgs e)
        {
            //MySql_importfg_warehouse tem = new MySql_importfg_warehouse();
            //if (tem.Open())
            //{
            //    MessageBox.Show("Connect Mysql sucess");
            //    return;
            //}
            //else
            //{
            //    return;
            //}
            if (checkdata() == false)
            { return; }
            string sqlusername = "select distinct username from m_user where  usercode = '" + cmb_user.Text + "'";
            string sqlpass = "select distinct password from m_user where usercode = '" + cmb_user.Text + "'";
            string sqlpermission = "select distinct permission from m_user where  usercode = '" + cmb_user.Text + "'";
            sqlCON connect = new sqlCON();
            if (connect.sqlExecuteScalarString(sqlpass) != txt_pass.Text)
            {
                infomesge mes = new infomesge();
                mes.ErrorMesger("Password is not correct", "Warning System", this);
                txt_pass.Text = "";
                return;
            }
            sqlCON connected = new sqlCON();
            sqlCON permi = new sqlCON();
            Class.valiballecommon va = Class.valiballecommon.GetStorage();
            va.UserName = connected.sqlExecuteScalarString(sqlusername);
            va.Permission = permi.sqlExecuteScalarString(sqlpermission);
            va.UserCode = cmb_user.Text;
            if(cb_Language.SelectedItem != null)
            va.Language =(string) cb_Language.SelectedItem;
            if (cb_Database.SelectedItem != null)
            {
                if (cb_Database.SelectedItem.ToString() == "TECHLINK")
                {
                    va.DBERP = "TECHLINK";
                    va.DBSFT = "SFT_TECHLINK";
                }
                else if (cb_Database.SelectedItem.ToString() == "TLVN2")
                {
                    va.DBERP = "TLVN2";
                    va.DBSFT = "SFT_TLVN2";
                }
                else if (cb_Database.SelectedItem.ToString() == "TLTEST")
                {
                    va.DBERP = "TLTEST";
                    va.DBSFT = "SFT_TLTEST";
                }
            }
            MainLayout mainLayout = new MainLayout();
            mainLayout.Show();
            //this.Hide();
            //MainFr newfr = new MainFr();
            //newfr.Show();
            //   this.Hide();

        }

        private void LoginFr_FormClosing(object sender, FormClosingEventArgs e)
        {
           // var objectSet = Class.valiballecommon.GetStorage();


        var saveConfig =    SaveObject.Save_data(PathSaveConfig, Class.valiballecommon.GetStorage());
            if(saveConfig== false)
            {
                MessageBox.Show("Can't save configure of system", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
