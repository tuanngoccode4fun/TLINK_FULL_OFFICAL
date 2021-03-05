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
    public partial class SystemUI : Form
    {
        public SystemUI()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_line_Click(object sender, EventArgs e)
        {
            SettingForm.LineForm.LineForm fr = new SettingForm.LineForm.LineForm();
            fr.Show();
        }

        private void btn_model_Click(object sender, EventArgs e)
        {
            SettingForm.ModelForm.ModelForm fre = new SettingForm.ModelForm.ModelForm();
            fre.Show();
        }

        private void btn_modelline_Click(object sender, EventArgs e)
        {
            SettingForm.Line_ModelForm.ModelLine modelf = new SettingForm.Line_ModelForm.ModelLine();
            modelf.Show();
        }

        private void btn_process_Click(object sender, EventArgs e)
        {
            SettingForm.ProcessForm.ProcessForm frew = new SettingForm.ProcessForm.ProcessForm();
            frew.Show();
        }

        private void btn_emailconfig_Click(object sender, EventArgs e)
        {
            ERPShowOrder.ERPConfigMail show = new ERPShowOrder.ERPConfigMail();
            show.Show();
        }

        private void btn_settingLanguage_Click(object sender, EventArgs e)
        {

            SettingForm.Language.SettingLanguage settingLanguage = new SettingForm.Language.SettingLanguage();
            settingLanguage.Show();
        }

        private void btn_dept_Click(object sender, EventArgs e)
        {

            SettingForm.DeptForm.DeptForm frnew = new SettingForm.DeptForm.DeptForm();
            frnew.Show();
        }

        private void btn_ipplc_Click(object sender, EventArgs e)
        {

            SettingForm.IPPLC.IPPLC dt = new SettingForm.IPPLC.IPPLC();
            dt.Show();
        }
    }
}
