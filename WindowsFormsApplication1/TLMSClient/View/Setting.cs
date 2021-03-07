using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using TLMSClient.Model;
using TLMSClient.Class;

namespace TLMSClient.View
{ 
    public partial class Setting : MetroForm
    {
        private string path = Environment.CurrentDirectory;
        public Setting()
        {
            InitializeComponent();
        }

        private void Btn_save_Click(object sender, EventArgs e)
        {
            Configure configure = new Configure();
            try
            {
                configure.Database = cmb_database.SelectedItem.ToString();
                configure.Timer =(int) nmr_timer.Value;
                configure.IsStartWithWindow = cb_Startup.Checked;
                if(cb_Startup.Checked == true)
                {
                    StartUpWindow.RegistrationStartUp();
                }
                else
                    StartUpWindow.DeleteStartUp();
                SaveObject.Save_data(path + @"\Configure.ini", configure);
                configure = null;
               
                MessageBox.Show("Save configure Sucessful " , "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Save configure fail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SettingTimer_Load(object sender, EventArgs e)
        {
            Configure configure = new Configure();
            if (File.Exists(path + @"\Configure.ini"))
            {
                configure = (Configure)SaveObject.Load_data(path + @"\Configure.ini");
                if (configure != null)
                {
                    nmr_timer.Value = configure.Timer;
                    cmb_database.SelectedItem = configure.Database;
                    cb_Startup.Checked = configure.IsStartWithWindow;
                }
                else
                {
                    nmr_timer.Value = 5;
                    cmb_database.SelectedIndex = -1;
                    cb_Startup.Checked = false;
                }
                   
            }
            else
            {
                nmr_timer.Value = 5;
                cmb_database.SelectedIndex = -1;
                cb_Startup.Checked = false;
            }
           

        }

        private void Setting_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Configure configure = new Configure();
            try
            {
                configure.Database = cmb_database.SelectedItem.ToString();
                configure.Timer = (int)nmr_timer.Value;
                configure.IsStartWithWindow = cb_Startup.Checked;
                SaveObject.Save_data(path + @"\Configure.ini", configure);
                configure = null;
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Save configure fail: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
