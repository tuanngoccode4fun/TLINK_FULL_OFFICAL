using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UploadDataToDatabase.Class;

namespace UploadDataToDatabase.FormConfig
{
    public partial class ReportSchechuleForm : CommonForm
    {
        public ReportSchechuleForm()
        {

            InitializeComponent();
        }

        private void Btn_confirm_Click(object sender, EventArgs e)
        {
       

            sqlCON connect = new sqlCON();

            string sqladd = @"insert into t_report_schedule (reportname, reporttype, Minutes,hours, day, date,month,isBodyHTML, subject, attach,comments,inputdate) values ('"
+ txt_ReportName.Text + "','" + cmb_typeReport.Text + "','"+ nmr_Minutes.Value.ToString() + "','"
+ nmr_hours.Value.ToString() + "','" + cmb_day.Text+ "','"+ nmr_date.Value.ToString()+ "','"+ cmb_month.Text+ "','"+ rtb_IsBodyHTML.Checked.ToString()+"','" +txt_subject.Text+ "','"+ txt_attach.Text+ "','"+ rtb_comment.Text+ "',GETDATE())";
            connect.sqlExecuteNonQuery(sqladd, false);
            this.Close();
        }
       

        private void cmb_typeReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cmb_typeReport.Text == "Daily")
            {
                nmr_Minutes.Visible = true;
                nmr_hours.Visible = true;
                cmb_day.Visible = false;
                nmr_date.Visible = false;
                cmb_month.Visible = false;
            }
            else if (cmb_typeReport.Text == "Weekly")
            {
                nmr_Minutes.Visible = true;
                nmr_hours.Visible = true;
                cmb_day.Visible = true;
                nmr_date.Visible = false;
                cmb_month.Visible = false;
            }
            else if (cmb_typeReport.Text == "Monthly")
            {
                nmr_Minutes.Visible = true;
                nmr_hours.Visible = true;
                cmb_day.Visible =false;
                nmr_date.Visible = true;
                cmb_month.Visible = false;
            }
            else if (cmb_typeReport.Text == "Yearly")
            {
                nmr_Minutes.Visible = true;
                nmr_hours.Visible = true;
                cmb_day.Visible = false;
                nmr_date.Visible = true;
                cmb_month.Visible = true;
            }

        }

        private void ReportSchechuleForm_Load(object sender, EventArgs e)
        {
            cmb_typeReport.Items.Add("Daily");
            cmb_typeReport.Items.Add("Weekly");
            cmb_typeReport.Items.Add("Monthly");
            cmb_typeReport.Items.Add("Yearly");

            DateTime month = DateTime.MinValue;
            for (int i = 0; i < 7; i++)
            {

                cmb_day.Items.Add(month.ToString("dddd"));
                month = month.AddDays(1);
            }
            for (int i = 0; i < 12; i++)
            {
                
                cmb_month.Items.Add(month.ToString("MMMM"));
                month= month.AddMonths(1);
            }
            nmr_Minutes.Visible = false;
            nmr_hours.Visible = false;
            cmb_day.Visible = false;
            nmr_date.Visible = false;
            cmb_month.Visible = false;
        }


        private void Btn_attach_Click_1(object sender, EventArgs e)
        {
            FolderBrowserDialog openFileDialog = new FolderBrowserDialog();

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                txt_attach.Text = openFileDialog.SelectedPath;
            }
        }

        private void Rtb_IsBodyHTML_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
