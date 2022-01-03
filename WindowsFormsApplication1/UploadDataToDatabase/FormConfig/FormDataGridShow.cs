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
using UploadDataToDatabase;

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
            List<RawReliability> realabilityItemsAdding7Days = realability.GetDataRawReliabilityAdding7Days(realabilityItems);
            //List<RawReliability> raws = new List<RawReliability>();
            
            //foreach (var item in realabilityItems)
            //{
            //    raws.Add(item);
            //}
           dataGridView1.DataSource = realabilityItemsAdding7Days;



            //int count = realabilityItems.Where(d => d.Evaluation == "Late").Count();
            // List<RawReliability> realabilityItemsAdding7Days = realability.GetDataRawReliabilityAdding7Days(realabilityItems);
            //    int count3 = realabilityItems.Where(d => d.Evaluation == "Late").Count();
            // raws = null;
            // int count2 = realabilityItemsAdding7Days.Where(d => d.Evaluation == "Late").Count();
            // dtgv_adding7days.DataSource = realabilityItemsAdding7Days;
            // realabilityItems = null;
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            ExportExcelTool exportExcelTool = new ExportExcelTool();
            string path = @"C:\ERP_Temp\Reliability Raw_" + DateTime.Now.ToString("ddMMyy HHmmss") + ".xls";
            exportExcelTool.dtgvExport2Excel(dataGridView1, path);
            //path = @"C:\ERP_Temp\Reliability Raw_" + DateTime.Now.ToString("ddMMyy HHmmss") + ".xls";
            //exportExcelTool.dtgvExport2Excel(dataGridView1, dtgv_adding7days, path);
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
            List<ReliabilitySummary> ListReliabilityClient7Days = new List<ReliabilitySummary>();
            List<ReliabilitySummary> ListReliabilityDept7Days = new List<ReliabilitySummary>();
            List<RawReliability> rawReliabilities = realabilityReport.GetDataRawReliability(from, to);
            ListReliability = realabilityReport.GetDataForReliability(from, to, rawReliabilities, out ListReliabilityDept, out ListReliabilityClient7Days, out ListReliabilityDept7Days);
       //     ListReliability = realabilityReport.GetDataForReliability(from, to, out ListReliabilityDept);
            exportExcelTool.ExportToReliabilityReportAdding7DaysAddingRawData(pathTemplate, path, ListReliability, ListReliabilityDept, ListReliabilityClient7Days, ListReliabilityDept7Days, rawReliabilities, from, to);



        }
    }
}
