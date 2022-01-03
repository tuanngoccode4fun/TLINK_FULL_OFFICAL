using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace UploadDataToDatabase.HR_Audit
{
    public partial class HR_Audit : Form
    {
        public HR_Audit()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog FSopen = new OpenFileDialog();
            FSopen.CheckFileExists = false;
            FSopen.CheckPathExists = false;
            FSopen.ShowReadOnly = true;
            FSopen.FileName = "Select file finger data";
            if (FSopen.ShowDialog() == DialogResult.OK)
            {
                txt_loadFingerdata.Text = FSopen.FileName;
              
            }
        }

        private void Btn_workingtime_Click(object sender, EventArgs e)
        {
            OpenFileDialog FSopen = new OpenFileDialog();
            FSopen.CheckFileExists = false;
            FSopen.CheckPathExists = false;
            FSopen.ShowReadOnly = true;
            FSopen.FileName = "Select working-time data";
            if (FSopen.ShowDialog() == DialogResult.OK)
            {
                txt_workingtime.Text = FSopen.FileName;

            }
        }

        private void Btn_specicallist_Click(object sender, EventArgs e)
        {

            OpenFileDialog FSopen = new OpenFileDialog();
            FSopen.CheckFileExists = false;
            FSopen.CheckPathExists = false;
            FSopen.ShowReadOnly = true;
            FSopen.FileName = "Select special list data";
            if (FSopen.ShowDialog() == DialogResult.OK)
            {
                txt_specicallist.Text = FSopen.FileName;

            }
        }

     
        private void Btn_check_Click(object sender, EventArgs e)
        {
            ReadExcelFile readExcel = new ReadExcelFile();
            if (txt_loadFingerdata.Text != "")
            {
                List<FingerData> GetfingerDatas = readExcel.GetFingerDatas(txt_loadFingerdata.Text);
            }
            if (txt_specicallist.Text != "")
            {
                List<SpecialList> specialLists = readExcel.GetSpecialLists(txt_specicallist.Text);
            }
            if (txt_workingtime.Text != "")
            {
                List<WorkingDateData> workingDateDatas = readExcel.GetWorkingDateDatasVanPhong(txt_workingtime.Text, (int)numericUpDown1.Value);
            }
            //dtgv_workingtime.DataSource = workingDateDatas;
            //DataControl dataControl = new DataControl();
            //DataTable dt = new DataTable();
            //List<m_workingData> m_WorkingDatas = dataControl.GetWorkingData("TL-0291",ref dt);
            //List<FingerData> GetFingerDatas = dataControl.GetFingerDatas("TL-0291");
            //List<auditItem> auditItems = GetAuditItems(dt, GetFingerDatas);
            //dtgv_workingtime.DataSource = auditItems;
        }
        public List<auditItem> GetAuditItems(DataTable dt, List<FingerData> fingerDatas)
        {
            List<auditItem> auditItems = new List<auditItem>();
            try
            {
               
                var WorkingHours = fingerDatas.Select(d => d.DayWorkingTime).ToList();
                var WorkingHours2 = fingerDatas.Select(d => d.NightWorkingTime).ToList();
                for (int i = 0; i < dt.Rows.Count; i++)
                {if (i == 0)
                    {
                        for (int j = 1; j < 32; j++)
                        {
                            string WorkDayj = dt.Rows[i][j + 5].ToString();
                            if (WorkDayj.Trim() != WorkingHours[j - 1].Trim())
                            {if (WorkDayj.Trim() == "0" && WorkingHours[j - 1].Trim() == "")
                                    ;
                            else
                                auditItems.Add(new auditItem { Ca = "Day", Ngay = j.ToString(), ID = dt.Rows[i][0].ToString(), Status = "false", Finger = WorkingHours[j - 1], Working = WorkDayj});
                            }
                        }
                    }
                else if( i==1)
                    {
                        for (int j = 1; j < 32; j++)
                        {
                            string WorkDayj = dt.Rows[i][j + 5].ToString();
                            if (WorkDayj.Trim() != WorkingHours2[j - 1].Trim())
                            {
                                if (WorkDayj.Trim() == "0" && WorkingHours2[j - 1].Trim() == "")
                                    ;
                                else
                                    auditItems.Add(new auditItem { Ca = "night", Ngay = j.ToString(), ID = dt.Rows[i][0].ToString(), Status = "false", Finger = WorkingHours2[j - 1], Working = WorkDayj });
                            }
                        }
                    }
                }
           

            }
            catch (Exception)
            {

                return null;
            }
            return auditItems;
        }
        public Dictionary<string, List<auditItem>> DicListNG = new Dictionary<string, List<auditItem>>();
        public List<string> listThieuFingerData = new List<string>();
        List<auditItem> listwrongWorkingHours = new List<auditItem>();
        public void FindListNG ()
        {
            DicListNG = new Dictionary<string, List<auditItem>>();
            listThieuFingerData = new List<string>();
            listwrongWorkingHours = new List<auditItem>();
               DataControl dataControl = new DataControl();
            DataTable dataIDName = new DataTable();
            dataControl.GetListIDName(ref dataIDName, numericUpDown1.Value.ToString());

            for (int i = 0; i < dataIDName.Rows.Count; i++)
            {
                string ID = dataIDName.Rows[i][0].ToString().Trim();
                DataTable dt = new DataTable();
                List<m_workingData> m_WorkingDatas = dataControl.GetWorkingData(ID, ref dt, numericUpDown1.Value.ToString());
                List<FingerData> GetFingerDatas = dataControl.GetFingerDatas(ID, numericUpDown1.Value.ToString());
                if (GetFingerDatas == null || GetFingerDatas.Count == 0)
                {
                    listThieuFingerData.Add(ID);

                }
                else
                {
                    List<auditItem> auditItems = GetAuditItems(dt, GetFingerDatas);
                    if (auditItems != null && auditItems.Count > 0 && DicListNG.ContainsKey(ID) == false)
                    {
                        DicListNG.Add(ID, auditItems);
                        foreach (var item in auditItems)
                        {
                            listwrongWorkingHours.Add(item);
                        }
                    }
                }
            }
         
            dtgv_inout.DataSource = listThieuFingerData.Select(x => new { Value = x }).ToList(); 
            dtgv_workingtime.DataSource = listwrongWorkingHours;
        }
        public List<AuditInOut> listAuditInout = new List<AuditInOut>();
        public List<auditItem> listAudit = new List<auditItem>();
        public void FindListWrong12hours ()
        {
            listAudit = new List<auditItem>();
               DataControl dataControl = new DataControl();
            DataTable dataIDName = new DataTable();
            dataControl.GetListIDFinger(ref dataIDName, numericUpDown1.Value.ToString());
          
            for (int i = 0; i < dataIDName.Rows.Count; i++)
            {
                string ID = dataIDName.Rows[i][0].ToString().Trim();
                if (ID != "")
                {
                    List<FingerData> GetFingerDatas = new List<FingerData>();
                    GetFingerDatas = dataControl.GetFingerDatas(ID, numericUpDown1.Value.ToString());
                    List<AuditInOut> auditInOuts = dataControl.GetAuditInOuts(GetFingerDatas);
                    foreach (var item in auditInOuts)
                    {
                        listAuditInout.Add(item);
                    }
                }
            }
            dtgv_12hours.DataSource = listAuditInout;
        }
        public void FindSpecialRule ()
        {
            listAudit = new List<auditItem>();
               DataControl dataControl = new DataControl();
            DataTable dataIDName = new DataTable();
            dataControl.GetListIDSpecial(ref dataIDName);

            for (int i = 0; i < dataIDName.Rows.Count; i++)
            {
                string ID = dataIDName.Rows[i][0].ToString().Trim();
                string Depart= dataIDName.Rows[i][1].ToString().Trim();
                DateTime dateFrom = (dataIDName.Rows[i][2].ToString().Trim() != "") ? (DateTime.ParseExact(dataIDName.Rows[i][2].ToString().Trim().Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture)) : DateTime.MinValue;
                DateTime dateTo = (dataIDName.Rows[i][3].ToString().Trim() != "") ? (DateTime.ParseExact(dataIDName.Rows[i][3].ToString().Trim().Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture)) : DateTime.MinValue;


                if (ID != "")
                {
                    DataTable dt = new DataTable();
                    List<m_workingData> m_WorkingDatas = dataControl.GetWorkingData(ID, ref dt, numericUpDown1.Value.ToString());
                    List<FingerData> GetFingerDatas = new List<FingerData>();
                    GetFingerDatas = dataControl.GetFingerDatas(ID, numericUpDown1.Value.ToString());
                    if (m_WorkingDatas != null)
                    {
                        List<auditItem> auditItems = ListSpecialwrongruleFingerData(GetFingerDatas, Depart, dateFrom, dateTo );
                        if(auditItems != null)
                        {
                            foreach (var item in auditItems)
                            {
                                listAudit.Add(item);
                            }
                        }
                    }
                }
            }
            dtgv_bau.DataSource = listAudit;
            
        }
        public List<auditItem> ListSpecialwrongrule( DataTable dt, string Dept, DateTime from, DateTime to)
        {
            List<auditItem> auditItems = new List<auditItem>();
            try
            {
                double workingHours = 0;


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (i == 0)
                    {
                        int year = dt.Rows[i][3].ToString().Trim() != "" ? (int.Parse(dt.Rows[i][3].ToString().Trim())) : 2019;
                        int Month = dt.Rows[i][4].ToString().Trim() != "" ? (int.Parse(dt.Rows[i][4].ToString().Trim())) : 1;
                        int lastDayOfMonth = DateTime.DaysInMonth(year, Month);//avoid end of month
                        for (int j = 1; j < lastDayOfMonth + 1; j++)
                        { 
                            DateTime workingDate = new DateTime(year, Month, j);
                            string WorkDayj = dt.Rows[i][j + 5].ToString();
                            if(WorkDayj != "" && WorkDayj != "0")
                            {
                                try
                                {
                                    workingHours = double.Parse(WorkDayj.Trim());
                                }
                                catch (Exception ex)
                                {
                                    workingHours = 0;
                                    ;
                                }
                                if (from != DateTime.MinValue && to != DateTime.MinValue)
                                {
                                    if (Dept.Contains("VP"))
                                    {
                                        
                                            if (workingHours > 7 && from <= workingDate && to > workingDate)
                                            {
                                                auditItems.Add(new auditItem { Ca = "day", Ngay = workingDate.ToString("dd-MM-yyyy"), ID = dt.Rows[i][0].ToString(), Status = "lam it hon 1 gio", Finger = "", Working = WorkDayj });
                                            }
                                        
                                    }
                                    else
                                    {
                                        if (workingHours > 9)
                                        {
                                            auditItems.Add(new auditItem { Ca = "day", Ngay = j.ToString(), ID = dt.Rows[i][0].ToString(), Status = "lam it hon 1 gio", Finger = "", Working = WorkDayj });
                                        }
                                    }

                                    }
                            }
                        
                        }
                    }
                    else if (i == 1)
                    {
                        int year = dt.Rows[i][3].ToString().Trim() != "" ? (int.Parse(dt.Rows[i][3].ToString().Trim())) : 2019;
                        int Month = dt.Rows[i][4].ToString().Trim() != "" ? (int.Parse(dt.Rows[i][4].ToString().Trim())) : 1;
                       int lastDayOfMonth = DateTime.DaysInMonth(year, Month);//avoid end of month
                        for (int j = 1; j < lastDayOfMonth+1; j++)
                        {
                          
                            DateTime workingDate = new DateTime(year, Month, j);

                            string WorkDayj = dt.Rows[i][j + 5].ToString().Trim();
                            if (WorkDayj != "" && WorkDayj != "0")
                            {
                                if (WorkDayj != "" && WorkDayj != "0" && from <= workingDate && to > workingDate)
                                {
                                    auditItems.Add(new auditItem { Ca = "night", Ngay = j.ToString(), ID = dt.Rows[i][0].ToString(), Status = "ko lam ca dem", Finger = "", Working = WorkDayj });
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return null;
            }
            return auditItems;
        }
        public List<auditItem> ListSpecialwrongruleFingerData(List<FingerData> fingerDatas, string Dept, DateTime from, DateTime to)
        {
            List<auditItem> auditItems = new List<auditItem>();
            try
            {
                double workingHours = 0;
                DateTime workingDate = DateTime.MinValue;

                foreach (var data in fingerDatas)
                {
                   if(data.DayWorkingTime.Trim() != "" && data.DayWorkingTime.Trim() != "0")
                    {
                        try
                        {
                            workingHours = double.Parse(data.DayWorkingTime);
                            workingDate = DateTime.ParseExact(data.DateTime.Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture );
                           
                        }
                        catch (Exception)
                        {

                            workingHours = 0;
                        }

                        if (from != DateTime.MinValue && to != DateTime.MinValue)
                        {
                            if (Dept.Contains("VP"))
                            {

                                if (workingHours > 7 && from <= workingDate && to > workingDate)
                                {
                                    auditItems.Add(new auditItem { Ca = "day", Ngay = workingDate.ToString("dd-MM-yyyy"), ID = data.ID, Status = "VP lam it hon 1 gio", Finger = data.DayWorkingTime, Working = "" });
                                }

                            }
                            else
                            {
                                if (workingHours > 9 && from <= workingDate && to > workingDate)
                                {
                                    auditItems.Add(new auditItem { Ca = "day", Ngay = workingDate.ToString("dd-MM-yyyy"), ID = data.ID, Status = "CN lam it hon 1 gio", Finger = data.DayWorkingTime, Working = "" });
                                }
                            }

                        }

                    }
                   if(data.NightWorkingTime.Trim() != "" && data.NightWorkingTime.Trim() != "0" && from <= workingDate && to > workingDate)
                    {
                        try
                        {
                           // workingHours = double.Parse(data.DayWorkingTime);
                            workingDate = DateTime.ParseExact(data.DateTime.Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture);

                        }
                        catch (Exception)
                        {

                            workingHours = 0;
                        }
                        auditItems.Add(new auditItem { Ca = "night", Ngay = workingDate.ToString("dd-MM-yyyy"), ID = data.ID, Status = "ko lam ca dem", Finger = data.DayWorkingTime, Working = "" });
                    }
                }
              
            }
            catch (Exception ex)
            {

                return null;
            }
            return auditItems;
        }

        public static string sample(object arr)
        {

            object[] res = arr as object[];
            if (res != null)
            {
                string[] sRes = res.OfType<string>().ToArray();
            }
            return "";
        }

        private void Btn_test_Click(object sender, EventArgs e)
        {
            FindListNG();
            FindListWrong12hours();
        }

        private void Btn_test2_Click(object sender, EventArgs e)
        {
            FindListWrong12hours();
        }

        private void Btn_babau_Click(object sender, EventArgs e)
        {
            FindSpecialRule();
        }

        private void Btn_kiemtra_Click(object sender, EventArgs e)
        {
            System.Windows.Input.Cursor oldCursor = Mouse.OverrideCursor;
           
            try
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                WindowState = FormWindowState.Minimized;
                FindListNG();
                FindListWrong12hours();
                FindSpecialRule();
                WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {

                Logfile.Output(StatusLog.Error, "check error", ex.Message);
            }
            finally
            {
                Mouse.OverrideCursor = oldCursor;
            }

        }
    }
}
