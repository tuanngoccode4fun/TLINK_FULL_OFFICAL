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


namespace WindowsFormsApplication1.Report.Reliability
{
    public partial class ReliabilityReport : CommonFormMetro
    {
        public ReliabilityReport()
        {
            InitializeComponent();
            dtpk_From.Enabled = false;
            dtpk_To.Enabled = false;
            lbl_Header.Text = "Reliability Metrics Report";
        }

        private void Btn_ExportExcel_Click(object sender, EventArgs e)
        {
            try
            {
         
            string pathsave = "";
                System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Title = "Browse Excel Files";
                saveFileDialog.DefaultExt = "Excel";
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                saveFileDialog.CheckPathExists = true;


                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pathsave = saveFileDialog.FileName;

                    saveFileDialog.RestoreDirectory = true;


                    if (radio_thisMonth.Checked)
                    {
                        ReliabilityClass reliabilityClass = new ReliabilityClass();
                        if (reliabilityClass.SendMailReliabilityReporAdding7DaystMonthly(pathsave))
                        {
                           SystemLog.Output(SystemLog.MSG_TYPE.Nor, "[Btn_ExportExcel_Click]", "Export Reliability report to excel sucessfull");
                        }

                    }
                    else if (radio_Week.Checked)
                    {
                        ReliabilityClass reliabilityClass = new ReliabilityClass();
                        if (reliabilityClass.SendMailReliabilityReportAdding7Days(pathsave))
                        {
                           SystemLog.Output(SystemLog.MSG_TYPE.Nor, "[Btn_ExportExcel_Click]", "Export Reliability report to excel sucessfull");
                        }
                    }
                    else if (radio_Year.Checked)
                    {

                        ReliabilityClass reliabilityClass = new ReliabilityClass();
                        if (reliabilityClass.SendMailReliabilityReporAdding7DaysYear(pathsave))
                        {
                           SystemLog.Output(SystemLog.MSG_TYPE.Nor, "[Btn_ExportExcel_Click]", "Export Reliability report to excel sucessfull");
                        }
                    }
                    else if (radio_periodtime.Checked)
                    {
                        ReliabilityClass reliabilityClass = new ReliabilityClass();
                        if (reliabilityClass.SendMailReliabilityReporAdding7DayPeriodTime(pathsave,dtpk_From.Value, dtpk_To.Value))
                        {
                           SystemLog.Output(SystemLog.MSG_TYPE.Nor, "[Btn_ExportExcel_Click]", "Export Reliability report to excel sucessfull");
                        }
                    }
                    var resultMessage = MessageBox.Show("Production Plan export to excel sucessful ! \n\r Do you want to open this file ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (resultMessage == DialogResult.Yes)
                    {

                        FileInfo fi = new FileInfo(pathsave);
                        if (fi.Exists)
                        {
                            System.Diagnostics.Process.Start(pathsave);
                        }
                        else
                        {
                            MessageBox.Show("File doestn't exist !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void Radio_periodtime_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_periodtime.Checked)
            {
                dtpk_From.Enabled = true;
                dtpk_To.Enabled = true;
            }
            else
            {
                dtpk_From.Enabled = false;
                dtpk_To.Enabled = false;
            }
        }

        private void Radio_Week_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_periodtime.Checked)
            {
                dtpk_From.Enabled = true;
                dtpk_To.Enabled = true;
            }
            else
            {
                dtpk_From.Enabled = false;
                dtpk_To.Enabled = false;
            }
        }

        private void Radio_Year_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_periodtime.Checked)
            {
                dtpk_From.Enabled = true;
                dtpk_To.Enabled = true;
            }
            else
            {
                dtpk_From.Enabled = false;
                dtpk_To.Enabled = false;
            }
        }

        private void Radio_thisMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (radio_periodtime.Checked)
            {
                dtpk_From.Enabled = true;
                dtpk_To.Enabled = true;
            }
            else
            {
                dtpk_From.Enabled = false;
                dtpk_To.Enabled = false;
            }
        }

        private void ReliabilityReport_Load(object sender, EventArgs e)
        {
            DateTime dateFirtYear = new DateTime(DateTime.Now.Year, 1, 1);
            DateTime dateFirtMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime dateEndMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
            radio_Week.Text = "From " + dateFirtMonth.ToString("dd-MMM") + " To " + DateTime.Now.ToString("dd-MMM");
            radio_thisMonth.Text = "From " + dateFirtMonth.ToString("dd-MMM") + " To " + dateEndMonth.ToString("dd-MMM");
            radio_Year.Text = "From " + dateFirtYear.ToString("dd-MMM") + " To " + DateTime.Now.ToString("dd-MMM");
        }
    }
}
