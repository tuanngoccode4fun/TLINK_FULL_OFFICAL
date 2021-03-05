using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.mainUI
{
    public partial class UserSettingUI : Form
    {
        public UserSettingUI()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_registeruser_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.SettingForm.RegisterUsesForm.RegisterUserForm fr = new SettingForm.RegisterUsesForm.RegisterUserForm();
            fr.Show();
        }

        private void btn_permission_Click(object sender, EventArgs e)
        {
            SettingForm.PermissionForm fr = new SettingForm.PermissionForm();
            fr.Show();
        }

        private void btn_changepass_Click(object sender, EventArgs e)
        {
            SettingForm.Change_Password passform = new SettingForm.Change_Password();
            passform.Show();
        }

        private void UserSettingUI_Load(object sender, EventArgs e)
        {

            sqlCON connect = new sqlCON();
            connect.sqlDatatablePermision("RegisterUser", btn_registeruser);
            connect.sqlDatatablePermision("Password", btn_changepass);
            connect.sqlDatatablePermision("PermissionForm", btn_permission);
        }
    }
}
