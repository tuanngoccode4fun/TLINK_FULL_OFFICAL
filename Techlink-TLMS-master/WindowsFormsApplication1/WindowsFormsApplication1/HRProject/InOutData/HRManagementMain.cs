using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.HRProject.InOutData.Model;
using WindowsFormsApplication1.HRProject.InOutData.Controller;
using System.IO;

namespace WindowsFormsApplication1.HRProject.InOutData
{
    public partial class HRManagementMain : CommonFormMetro
    {
        public Dictionary<string,string> GetDeptDescription = new Dictionary<string, string>();
        public HRManagementMain()
        {
            InitializeComponent();
        }

        private void Btn_Search_Click(object sender, EventArgs e)
        {
            //List<Model.EmployeeData> employeeDatas = new List<Model.EmployeeData>();
            //Controller.GetHRData getHRData = new Controller.GetHRData();
            //employeeDatas = getHRData.GetEmployeeDatas("", "", "", "", DateTime.MinValue);
            //GetAttendanceHR getAttendance = new GetAttendanceHR();
            //List<AttendanceDept> attendanceDepts = getAttendance.GetAttendanceDepts(DateTime.Now);
            //dtgv_EmloyeeData.DataSource = attendanceDepts;
        }
        private void SettingDatagridview(ref DataGridView dataGrid)
        {

            dataGrid.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            dataGrid.BackgroundColor = Color.LightSteelBlue;
            dataGrid.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.ColumnHeadersHeight = 100;

        }
        private void Dtgv_EmloyeeData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SettingDatagridview(ref dtgv_EmloyeeData);
            //dtgv_EmloyeeData.Columns["EmpID"].HeaderText ="Employee ID";
            //dtgv_EmloyeeData.Columns["EmpCode"].HeaderText = "Employee Code";
            //dtgv_EmloyeeData.Columns["Name"].HeaderText = "Employee Name";
            //dtgv_EmloyeeData.Columns["Dept"].HeaderText = "Department";
            //dtgv_EmloyeeData.Columns["Sex"].HeaderText = "Male/Female";
            //dtgv_EmloyeeData.Columns["HiredDate"].HeaderText = "Hire Date";
            //dtgv_EmloyeeData.Columns["Status"].HeaderText = "Status";
            //dtgv_EmloyeeData.Columns["Status"].Visible = false;

        }

        private void Dtgv_EmloyeeData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if(e.RowIndex >=0 && e.ColumnIndex >=0)
            //    {
            //        var selectedRow = dtgv_EmloyeeData.Rows[e.RowIndex];
            //        var Employee = (Model.EmployeeData)selectedRow.DataBoundItem;
            //        EmployeeUpdate employeeUpdate = new EmployeeUpdate(Employee);
            //        employeeUpdate.Show();

            //    }
            //}
            //catch (Exception)
            //{

            //    throw;
            //}
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            //GetAttendanceHR getAttendance = new GetAttendanceHR();
            //List<AttendanceDept> attendanceDepts = getAttendance.GetAttendanceDepts(DateTime.Now);
            //System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();
            //string pathsave = "";
            //saveFileDialog.Title = "Browse Excel Files";
            //saveFileDialog.DefaultExt = "Excel";
            //saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

            //saveFileDialog.CheckPathExists = true;

            //if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            //{
            //    HRReport hRReport = new HRReport();
            //    pathsave = saveFileDialog.FileName;

            //    saveFileDialog.RestoreDirectory = true;

            //    hRReport.ExportExcelHRAttendaceReport(pathsave, attendanceDepts, DateTime.Now);
            //    var resultMessage = MessageBox.Show("Attendance Daily Report export to excel sucessful ! \n\r Do you want to open this file ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            //    if (resultMessage == DialogResult.Yes)
            //    {

            //        FileInfo fi = new FileInfo(pathsave);
            //        if (fi.Exists)
            //        {
            //            System.Diagnostics.Process.Start(pathsave);
            //        }
            //        else
            //        {
            //            MessageBox.Show("File doestn't exist !", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //        }
            //    }
            //}
        }
        private void TabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch ((sender as TabControl).SelectedIndex)
            {
                case 0:

                    // Do nothing here (let's suppose that TabPage index 0 is the address information which is already loaded.
                    break;
                case 1:
                    LoadTabPageDataInOut();
                    break;
                case 2:


                    break;
            }
        }
        public void LoadTabPageDataInOut()
        {
            string strSQl = "select distinct LongName,ISNULL(Note,'') as Note from dbo.ZlDept ";
            DataTable dt = new DataTable();
            SqlHR sqlHR = new SqlHR();
            sqlHR.sqlDataAdapterFillDatatable(strSQl, ref dt);
            GetDeptDescription = new Dictionary<string, string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                GetDeptDescription.Add(dt.Rows[i][0].ToString(), dt.Rows[i][1].ToString());
              
            }
            cb_department.Items.Clear();
            cb_department.DataSource = GetDeptDescription.Keys.ToList();
        }

        private void Cb_department_SelectedIndexChanged(object sender, EventArgs e)
        { 
            lb_deptDecribe.Text = (string)GetDeptDescription[cb_department.SelectedItem.ToString()];
        }

        private void Btn_SearchPage2_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.GetHRData getHRData = new Controller.GetHRData();
                List<Model.InoutData> inoutDatas = new List<Model.InoutData>();
                inoutDatas = getHRData.GetInoutDatas("0", txt_employeeCode.Text, cb_department.Text, dtpk_from.Value, dtpk_to.Value);
           
                //  dtgv_InoutData.DataSource = inoutDatas;
                string strYear = dtpk_from.Value.Year.ToString();
                string strMonth = dtpk_from.Value.Month.ToString("00");
                string YearMonth = strYear + "年" + strMonth + "月";
                Dictionary<string, Model.MonthInOut> DicMonthInout = getHRData.GetKeyValuePairsInOut(inoutDatas, YearMonth);
                DataTable dataTableGanCong = new DataTable();
                dataTableGanCong = getHRData.GetDataTableGanCong(YearMonth, cb_department.Text, txt_employeeCode.Text);
                DataTable dtDisplay = new DataTable();
                int RowCout = dataTableGanCong.Rows.Count;
                for (int i = 0; i < RowCout; i++)
                {
                    var Code = dataTableGanCong.Rows[2*i]["Code"].ToString();
                    var Inout = DicMonthInout[Code];

                    DataRow dataRow = dataTableGanCong.NewRow();
                    for (int j = 1; j <= 31; j++)
                    {
                        if (Inout.InData[j - 1] != null || Inout.OutData[j - 1] != null)
                        {
                             dataRow["B" + j.ToString()] ="In:"+Inout.InData[j-1] + " Out:"+ Inout.OutData[j - 1] + Environment.NewLine +"Working Time : "+ Inout.WorkingTime[j - 1].ToString()+ Environment.NewLine+ Inout.InOutEvaluation[j - 1].ToString();
                        //    dataRow["B" + j.ToString()] = Inout.InOutEvaluation[j - 1].ToString();
                        }
                        else
                            dataRow["B" + j.ToString()] = "";
                    }

                    dataTableGanCong.Rows.InsertAt(dataRow, (2*i + 1));
                }
                dtgv_InoutData.DataSource = dataTableGanCong;

            }
            catch (Exception ex)
            {

                throw;
            }
        }

        private void Dtgv_InoutData_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SettingDatagridview(ref dtgv_InoutData);
            
            dtgv_InoutData.Columns["SessionID"].Visible = false;
            dtgv_InoutData.Columns["EmpID"].Visible = false;
            for (int i = 1; i <= 31; i++)
            {
                dtgv_InoutData.Columns["B" + i.ToString()].HeaderText = convertHeader(dtpk_from.Value, dtgv_InoutData.Columns["B" + i.ToString()].HeaderText) ;
            }

        }
        private string convertHeader(DateTime datetime,string Header)
        {
            string HeaderConvert = "";
            string strDate = Header.Substring(1).Trim();
            int intDate = int.Parse(strDate);
            var lastDayOfMonth = DateTime.DaysInMonth(datetime.Year, datetime.Month);
            if (intDate <= lastDayOfMonth)
                HeaderConvert = (new DateTime(datetime.Year, datetime.Month, intDate)).ToString("dd/MM/yyyy")+ Environment.NewLine + (new DateTime(datetime.Year, datetime.Month, intDate)).DayOfWeek.ToString() ;
            else HeaderConvert = "";
            return HeaderConvert;

        }

          
    }
    
}
