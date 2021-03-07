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
using WindowsFormsApplication1.HRProject.InOutData.Controller;
using WindowsFormsApplication1.HRProject.InOutData.Controller.TimeWorking;
using WindowsFormsApplication1.HRProject.InOutData.Model;
using WindowsFormsApplication1.HRProject.InOutData.Model.TimeWorking;

namespace WindowsFormsApplication1.HRProject.InOutData.View
{
    public partial class TimeWorking : CommonFormMetro
    {
        public List<SeasonalEmployee> seasonalEmployees = null;
        List<InoutData> listInoutSeasonal = new List<InoutData>();
        List<InoutData> inoutDatasAfterConvert = new List<InoutData>();
        Dictionary<string, Model.MonthInOut> keyValuePairs = new Dictionary<string, Model.MonthInOut>();
        public TimeWorking()
        {
            InitializeComponent();
        }
        private void settingdatagridview(DataGridView dataGridView)
        {
            dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular);
            dataGridView.BackgroundColor = Color.LightSteelBlue;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeight = 100;
        }
        private void btn_SearchPage2_Click(object sender, EventArgs e)
        {
            try
            {
                if (dtpk_from.Value.Month != dtpk_to.Value.Month)
                {
                    MessageBox.Show("You have to select data in same month", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (dtpk_from.Value > dtpk_to.Value)
                {
                    MessageBox.Show("You have to select 'To date' > 'From date' ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                    GetInoutDataFromEmployee inoutDataFromEmployee = new GetInoutDataFromEmployee();
                listInoutSeasonal = inoutDataFromEmployee.GetInoutDatasFromDateTime(dtpk_from.Value, dtpk_to.Value);
                inoutDatasAfterConvert = ListInOutAfterPaipanTable(listInoutSeasonal);
                

                LoadTreeViewFromListInoutData(inoutDatasAfterConvert);   
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "data NG", ex.Message);
            }
        }
        private List<InoutData> ListInOutAfterPaipanTable(List<InoutData> inoutDatas)
        {
            List<InoutData> listInoutReturn = new List<InoutData>();
            GetInoutDataFromEmployee inoutDataFromEmployee = new GetInoutDataFromEmployee();
                 int SessionID = -1;
            DataTable dtpaiPan = new DataTable();
            for (int i = 0; i < inoutDatas.Count; i++)
            {
                InoutData inout = new InoutData();
                inout = inoutDatas[i];
                  SessionID = inoutDataFromEmployee.GetSessionID(inoutDatas[i].FDateTime);
                int Date = inoutDatas[i].FDateTime.Day;

                dtpaiPan = inoutDataFromEmployee.GetDataPaipan(SessionID, inoutDatas[i].EmpID);
                if(dtpaiPan.Rows.Count ==1)
                {
                    var Value = dtpaiPan.Rows[0]["B" + Date];
                    if(Value == DBNull.Value)
                    {
                        inout.Shift = "NoShift";
                    }
                    else if((string)Value.ToString().Trim() ==  "03" || (string)Value.ToString().Trim() == "07")
                    {
                        inout.Shift = "Night";
                    }
                    else
                    {
                        inout.Shift = "Day";
                    }

                }

                listInoutReturn.Add(inout);


            }
            return listInoutReturn;
        }
        public string GetShiftofemployee(string ID, int Day, int SessionID)
        {
            string shift = "";


            return shift;
        }
        
        private void LoadTreeViewFromListInoutData(List<InoutData> listInoutSeasonal)
        {
            TrViewSeasonal.Nodes.Clear();
            try
            {
                if (listInoutSeasonal == null || listInoutSeasonal.Count == 0)
                    return;
         
               TreeNode newNode = new TreeNode("Seasonnal Employee");

            var listDept = listInoutSeasonal.Select(d => d.Dept).Distinct().ToList();
            for (int i = 0; i < listDept.Count; i++)
            {
                int CountEmp = listInoutSeasonal.Where(d => d.Dept == listDept[i]).Select(d => d.Name).Distinct().Count();

                TreeNode newNode_lv2 = new TreeNode(listDept[i]);
                newNode_lv2.Name = listDept[i];
                newNode_lv2.Text = listDept[i] + ": " + CountEmp;
                var listEmp = listInoutSeasonal.Where(d => d.Dept == listDept[i]).Select(d => d.Name).Distinct().ToList();
                for (int k = 0; k < listEmp.Count; k++)
                {
                    newNode_lv2.Nodes.Add(listEmp[k], listEmp[k]);
                }
                newNode.Nodes.Add(newNode_lv2);
            }

            TrViewSeasonal.Nodes.Add(newNode);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "LoadTreeViewFromListInoutData(List<InoutData> listInoutSeasonal)", ex.Message);
            }
        }

        private void btn_ExportExcel_Click(object sender, EventArgs e)
        {
            string pathsave = "";
            try
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Title = "Browse Excel Files";
                saveFileDialog.DefaultExt = "Excel";
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                saveFileDialog.CheckPathExists = true;


                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pathsave = saveFileDialog.FileName;

                    saveFileDialog.RestoreDirectory = true;

                    //GetListSeasonalEmp getListSeasonal = new GetListSeasonalEmp();
                    //seasonalEmployees = getListSeasonal.GetSeasonalEmployees(dtpk_from.Value, dtpk_to.Value);

                    //Dictionary<string, Model.MonthInOut> keyValuePairs = new Dictionary<string, Model.MonthInOut>();
                    //GetMonthInoutSeasonalEmp getMonthInoutSeasonalEmp = new GetMonthInoutSeasonalEmp();
                    //keyValuePairs = getMonthInoutSeasonalEmp.GetKeyValuePairsInOut(seasonalEmployees, dtpk_from.Value, dtpk_to.Value);
                    //List<string> ListHeader = DateTimeFunctions.ListDateInPeriodDate(dtpk_from.Value, dtpk_to.Value);
                    //List<string> ListDayofWeek = DateTimeFunctions.ListDateNameInPeriodDate(dtpk_from.Value, dtpk_to.Value);
                    if (keyValuePairs != null && keyValuePairs.Count > 0)
                    {
                        var result = false;
                        ExportExcelHRData exportExcelHRData = new ExportExcelHRData();
                        if (keyValuePairs.Values.ToList()[0].dept == "HOANG THAI DAI PHAT")
                        {
                         result = exportExcelHRData.ExportListSeasonalEmployeeTDP(pathsave, dtpk_from.Value, dtpk_to.Value, keyValuePairs);
                        }
                        else
                        {
                            result = exportExcelHRData.ExportListSeasonalEmployee(pathsave, keyValuePairs);
                        }
                        if (result)
                        {
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
                        else
                        {
                            MessageBox.Show("Export excel fail", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("the data is null", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Export to excel", ex.Message);
            }
        }

        private void TrViewSeasonal_AfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {

           
            var selectNode = e.Node;
            string selectKeyNode = selectNode.Name;
            var listInOut = inoutDatasAfterConvert.Where(d => d.Dept == selectKeyNode).ToList();
            var listEmp = listInOut.Select(d => d.EmpCode).Distinct().ToList();
            List<InOutDataMonth> listInoutMonth = new List<InOutDataMonth>();
            keyValuePairs = new Dictionary<string, MonthInOut>();
            for (int i = 0; i < listEmp.Count; i++)
            {
                var listInoutByemp = listInOut.Where(d => d.EmpCode == listEmp[i]).ToList();
                GetMonthInoutSeasonalEmp getInoutDataFrom = new GetMonthInoutSeasonalEmp();

                Model.MonthInOut monthInOut = getInoutDataFrom.GetMonthInOutFromInoutdata(listInoutByemp);
              
                var name = listInOut.Where(d => d.EmpCode == listEmp[i]).Select(d => d.Name).Distinct().ToList();
                monthInOut.EmpCode = listEmp[i];
                monthInOut.Name = name[0];
                monthInOut.dept = selectKeyNode;
              keyValuePairs.Add(listEmp[i], monthInOut);
                InOutDataMonth inOutData = ConvertInOutDataMonthFromMonthInout(listEmp[i],name[0], monthInOut);


                listInoutMonth.Add(inOutData);
            }

            dtgv_WorkingTime.DataSource = listInoutMonth;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "TrViewSeasonal_AfterSelect(object sender, TreeViewEventArgs e)", ex.Message);
            }
        }
        private InOutDataMonth ConvertInOutDataMonthFromMonthInout(string empCode,string name, Model.MonthInOut monthInOut)
        {
            InOutDataMonth inOutData = new InOutDataMonth();
            try
            {

         
            inOutData.EmpFinger = empCode;
            inOutData.Dept = name;
            
            for (int k = 0; k < 31; k++)
            {
                if (monthInOut.InData[k] != null)
                {
                    if (k == 0)
                    {
                        inOutData.Day1 = monthInOut.InData[k] + Environment.NewLine;
                        inOutData.Day1 += monthInOut.OutData[k] + Environment.NewLine;
                        inOutData.Day1 += monthInOut.WorkingTime[k] + Environment.NewLine;
                    }
                    else if (k == 1)
                        inOutData.Day2 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k]+ Environment.NewLine + monthInOut.Shift[k];
                    else if (k == 2)
                        inOutData.Day3 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 3)
                        inOutData.Day4 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 4)
                        inOutData.Day5 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 5)
                        inOutData.Day6 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 6)
                        inOutData.Day7 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 7)
                        inOutData.Day8 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k ==8)
                        inOutData.Day9 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 9)
                        inOutData.Day10 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 10)
                        inOutData.Day11 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 11)
                        inOutData.Day12 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 12)
                        inOutData.Day13 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 13)
                        inOutData.Day14 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 14)
                        inOutData.Day15 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 15)
                        inOutData.Day16 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 16)
                        inOutData.Day17 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 17)
                        inOutData.Day18 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 18)
                        inOutData.Day19 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 19)
                        inOutData.Day20 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 20)
                        inOutData.Day21 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 21)
                        inOutData.Day22 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 22)
                        inOutData.Day23 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 23)
                        inOutData.Day24 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 24)
                        inOutData.Day25 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 25)
                        inOutData.Day26 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 26)
                        inOutData.Day27 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 27)
                        inOutData.Day28 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 28)
                        inOutData.Day29 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 29)
                        inOutData.Day30 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                        else if (k == 30)
                        inOutData.Day31 = monthInOut.InData[k] + Environment.NewLine + monthInOut.OutData[k] + Environment.NewLine + monthInOut.WorkingTime[k] + Environment.NewLine + monthInOut.Shift[k];
                    }

            }
            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "ConvertInOutDataMonthFromMonthInout(string empCode,string name, Model.MonthInOut monthInOut)", ex.Message);

            }
            return inOutData;
        }
        
        private void dtgv_WorkingTime_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            try
            {
                settingdatagridview(dtgv_WorkingTime);
                SetHeaderContentDatagridview();
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "dtgv_WorkingTime_DataBindingComplete", ex.Message);
            }
            
        }
        private void SetHeaderContentDatagridview()
        {
            List<string> ListHeader = DateTimeFunctions.ListDateInPeriodDate(dtpk_from.Value, dtpk_to.Value);
            List<string> ListDayofWeek = DateTimeFunctions.ListDateNameInPeriodDate(dtpk_from.Value, dtpk_to.Value);
            if (dtgv_WorkingTime.Rows.Count > 0)
            {
                dtgv_WorkingTime.Columns[0].HeaderText = "Code";
                dtgv_WorkingTime.Columns[1].HeaderText = "Name";
                for (int i = 2; i < dtgv_WorkingTime.Columns.Count; i++)
                {
                    if (ListHeader.Count > (i - 2))
                        dtgv_WorkingTime.Columns[i].HeaderText = ListHeader[i - 2] + Environment.NewLine + "[ " + ListDayofWeek[i - 2] + " ]";
                    else dtgv_WorkingTime.Columns[i].HeaderText = "";
                }
            }
        }
    }
}

