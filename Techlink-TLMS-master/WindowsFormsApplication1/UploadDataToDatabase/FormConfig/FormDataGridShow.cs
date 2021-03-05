using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UploadDataToDatabase.BackLogReport;
using UploadDataToDatabase.Log;

namespace UploadDataToDatabase.FormConfig
{
    public partial class FormDataGridShow : Form
    {
        List<Realability> listShipingResult = new List<Realability>();
        public FormDataGridShow()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            RealabilityReport realability = new RealabilityReport();
            DateTime from = dtPickerFrom.Value;
            DateTime to = dtPickerTo.Value;
            //  realability.GetDataBackLogToExport(out listShipingResult);
            List<RawReliability> realabilityItems = realability.GetDataRawReliability(from, to);
            var temp = realabilityItems.Where(d => d.DepartmentCode == "").ToList();
            Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>
                GetdataGroupByClient = realability.SortbyClientRealitykeyValuePairs(realabilityItems);
            List<ReliabilitySummary> listReliabilityToShow = new List<ReliabilitySummary>();
            foreach (var ClientsGroup in GetdataGroupByClient)
            {
                foreach (var DeptGroup in ClientsGroup.Value)
                {
                    foreach (var item in DeptGroup.Value)
                    {
                        listReliabilityToShow.Add(item);
                    }
                }
            }
          
            dataGridView1.DataSource = listReliabilityToShow;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            RealabilityReport realability = new RealabilityReport();
            DateTime from = dtPickerFrom.Value;
            DateTime to = dtPickerTo.Value;
            //  realability.GetDataBackLogToExport(out listShipingResult);
            List<RawReliability> realabilityItems = realability.GetDataRawReliability(from, to);
            //Dictionary<string, Dictionary<string, List<ReliabilitySummary>>>
            //    GetdataGroupByClient = realability.SortbyClientRealitykeyValuePairs(realabilityItems);
            //List<ReliabilitySummary> listReliabilityToShow = new List<ReliabilitySummary>();
            //foreach (var ClientsGroup in GetdataGroupByClient)
            //{
            //    foreach (var DeptGroup in ClientsGroup.Value)
            //    {
            //        foreach (var item in DeptGroup.Value)
            //        {
            //            listReliabilityToShow.Add(item);
            //        }
            //    }
            //}
            dataGridView1.DataSource = realabilityItems;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ExportExcelTool exportExcelTool = new ExportExcelTool();
            string path = @"C:\ERP_Temp\Reliability Raw_" + DateTime.Now.ToString("ddMMyy HHmmss") + ".xls";
            exportExcelTool.dtgvExport2Excel(dataGridView1, path);
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DateTime from = dtPickerFrom.Value;
            DateTime to = dtPickerTo.Value;

            //Class.DateTimeControl.ReturnDateTimeForWeekly(ref from, ref to);
            //Class.DateTimeControl.ReturnDateTimeForMonthly(ref from, ref to);
            ExportExcelTool exportExcelTool = new ExportExcelTool();
            string path = @"C:\ERP_Temp\Reliability Report_" + DateTime.Now.ToString("ddMMyy HHmmss") + ".xlsx";
            string pathTemplate = Environment.CurrentDirectory + @"\Resources\Reliability.xlsx";
            RealabilityReport realabilityReport = new RealabilityReport();
            //   realabilityReport.SendMailReliabilityReportWeekly();
            List<ReliabilitySummary> ListReliability = new List<ReliabilitySummary>();
            List<ReliabilitySummary> ListReliabilityDept = new List<ReliabilitySummary>();
            ListReliability = realabilityReport.GetDataForReliability(from, to, out ListReliabilityDept);
            exportExcelTool.ExportToReliabilityReport(pathTemplate, path, ListReliability, ListReliabilityDept, from, to);



        }
    }
}
