using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainLayout : CommonFormMetro
    {
        public MainLayout()
        {
            InitializeComponent();
        }

        private void xuiButton2_Click(object sender, EventArgs e)
        {
            openChildForm(new mainUI.SystemUI());
        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            xuiWidgetPanel1.Controls.Add(childForm);
            xuiWidgetPanel1.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void xuiButton1_Click(object sender, EventArgs e)
        {
            openChildForm(new mainUI.UserSettingUI());
        }

        private void xuiButton3_Click(object sender, EventArgs e)
        {
            openChildForm(new mainUI.ProductionUI());
        }

        private void xuiButton4_Click(object sender, EventArgs e)
        {
            openChildForm(new mainUI.HRManagement());
        }

        private void MainLayout_Load(object sender, EventArgs e)
        {
            sqlCON connect = new sqlCON();
            connect.sqlDatatablePermision("HRManagement", btn_HRManagement);
            connect.sqlDatatablePermision("ProductionManagement", btn_productionManagement);
            connect.sqlDatatablePermision("SystemConfigure", btn_SystemConfig);
            connect.sqlDatatablePermision("UserSetting", btn_userSetting);
        }
    }
}
