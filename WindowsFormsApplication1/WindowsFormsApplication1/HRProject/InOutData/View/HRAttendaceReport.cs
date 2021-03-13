using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;
using WindowsFormsApplication1.HRProject.InOutData.Controller;
using WindowsFormsApplication1.HRProject.InOutData.Controller.TimeWorking;
using WindowsFormsApplication1.HRProject.InOutData.Model;
using WindowsFormsApplication1.HRProject.InOutData.View;


namespace WindowsFormsApplication1.HRProject.InOutData.View
{
    public partial class HRAttendaceReport : CommonFormMetro, IDisposable
    {
        HumanResourceDept ResourceDept = null;
        List<AttendanceDept> attendanceDepts = new List<AttendanceDept>();
        List<List<AttendanceDept>> ListAttendance = new List<List<AttendanceDept>>();
        int CurrentStart = 0;
        BackgroundWorker bgWorker;
        // this timer calls bgWorker again and again after regular intervals
        System.Windows.Forms.Timer tmrCallBgWorker;
        // this is the timer to make sure that worker gets called
        System.Threading.Timer tmrEnsureWorkerGetsCalled;
        object lockObject = new object();
        HumanResourceDept ResourceDept1;
        HumanResourceDept ResourceDept2;

        enum HRReportStatus
        {
            start, stop, pause
        }
        HRReportStatus hRReport = HRReportStatus.pause;
        public HRAttendaceReport()
        {
            InitializeComponent();

            lbl_Header.Text = "Tech-Link manpower daily report on " + DateTime.Now.ToString("dd-MM-yyyy");
          //  Screen[] screens = Screen.AllScreens;
           
            var scrProgram = Screen.FromControl(this);
            if (scrProgram.Primary)
            {
                // StartPosition was set to FormStartPosition.Manual in the properties window.
                Rectangle screen = Screen.PrimaryScreen.WorkingArea;
                int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
                int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
                // this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
                this.Location = new Point(0, 0);
                this.Size = new Size(w, h);
            }
            else
            {
                Rectangle screen = scrProgram.WorkingArea;
                int w = Width >= screen.Width ? screen.Width : (screen.Width + Width) / 2;
                int h = Height >= screen.Height ? screen.Height : (screen.Height + Height) / 2;
                // this.Location = new Point((screen.Width - w) / 2, (screen.Height - h) / 2);
                this.Location = new Point(0, 0);
                this.Size = new Size(w, h);
            }
            
        //    this.tableLayoutPanel1.Size = new Size(w - 10, h - 10);

            bgWorker = new BackgroundWorker();
            
            // work happens in this method
         
          
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            bgWorker.WorkerReportsProgress = true;
            //timer_update.Start();
            // this timer calls bgWorker again and again after regular intervals
            tmrCallBgWorker = new System.Windows.Forms.Timer();//Timer for do task
            tmrCallBgWorker.Tick += new EventHandler(tmrCallBgWorker_Tick);
            hRReport = HRReportStatus.pause;
        }

        #region Backround worker task
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {

            var worker = sender as BackgroundWorker;
            //if(CurrentStart == 0)
            //{
            //    //tmrCallBgWorker.Stop();
            //    GetAttendanceHR getAttendance = new GetAttendanceHR();
            //    attendanceDepts = getAttendance.GetAttendanceDepts();
            //    ClearMemory.CleanMemoryCompletely();
               
            ////    tmrCallBgWorker.Start();
            //}


            System.Threading.Thread.Sleep(100);
        }
        void tmrCallBgWorker_Tick(object sender, EventArgs e)
        {
            if (Monitor.TryEnter(lockObject))
            {
                try
                {
                    // if bgworker is not busy the call the worker
                    if (!bgWorker.IsBusy)
                        bgWorker.RunWorkerAsync();
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }

            }
            else
            {

                // as the bgworker is busy we will start a timer that will try to call the bgworker again after some time
                tmrEnsureWorkerGetsCalled = new System.Threading.Timer(new TimerCallback(tmrEnsureWorkerGetsCalled_Callback), null, 0, 10);

            }

        }
        void tmrEnsureWorkerGetsCalled_Callback(object obj)
        {
            // this timer was started as the bgworker was busy before now it will try to call the bgworker again
            if (Monitor.TryEnter(lockObject))
            {
                try
                {
                    if (!bgWorker.IsBusy)
                        bgWorker.RunWorkerAsync();
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
                tmrEnsureWorkerGetsCalled = null;
            }
        }
        private void BgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {



        }

        void bg_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {
                tmrCallBgWorker.Stop();
                if (CurrentStart < ListAttendance.Count)
                {
                   IntializeforTableLayout(ListAttendance, CurrentStart);
                    CurrentStart = CurrentStart + 2;
                }
                else
                {
                    CurrentStart = 0;
                   IntializeforTableLayout(ListAttendance, CurrentStart);
                }
                tmrCallBgWorker.Start();
            }
            catch (Exception ex)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "LoadDataERPMQCToShow()", ex.Message);
            }


        }
        #endregion backround worker task

        private void Button1_Click(object sender, EventArgs e)
        {
            System.Windows.Input.Cursor oldCursor = Mouse.OverrideCursor;
            try
            {
               
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                tmrCallBgWorker.Interval = 30000;
                GetAttendanceHR getAttendance = new GetAttendanceHR();
                attendanceDepts = getAttendance.GetAttendanceDeptsNew(dtpk_choose.Value);
                DisplayLabelCompany();
                ListAttendance = attendanceDepts.GroupBy(u => u.BigDeptCode)
        .Select(grp => grp.ToList())
        .ToList();
              ResourceDept1 = new HumanResourceDept(ListAttendance[0]);
               ResourceDept2 = new HumanResourceDept(ListAttendance[1]);
                ResourceDept1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
               | System.Windows.Forms.AnchorStyles.Left)
               | System.Windows.Forms.AnchorStyles.Right)));
                ResourceDept2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
               | System.Windows.Forms.AnchorStyles.Left)
               | System.Windows.Forms.AnchorStyles.Right)));
                IntializeforTableLayout(ListAttendance, CurrentStart);
                //pic_loader.Visible = false;

                tmrCallBgWorker.Start();
                hRReport = HRReportStatus.start;
                btn_HRReport.BackColor = Color.Green;
              
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "", ex.Message);
            }
            finally
            {
                Mouse.OverrideCursor = oldCursor;
            }

        }
        public void DisplayLabelCompany()
        {
           
            double EmpOfCompany = attendanceDepts.Select(d => d.EmployeeOfDept).Sum();
            double EmpInCompany = attendanceDepts.Select(d => d.LocalWorker.TotalWorker).Sum();
            double AttendanceDay = attendanceDepts.Select(d => d.DayShift.attendanceActual).Sum();
            double AbsenceDay = attendanceDepts.Select(d => d.DayShift.absence).Sum();

            double AttendanceNight = attendanceDepts.Select(d => d.NightShift.attendanceActual).Sum();
            double AbsenceNight = attendanceDepts.Select(d => d.NightShift.absence).Sum();
            double IndirectCompany = attendanceDepts.Select(d => d.LocalWorker.WorkerIndirect).Sum();
            double DirectCompany = attendanceDepts.Select(d => d.LocalWorker.WorkerDirect).Sum();
            //lb_AttandanceINCompany.Text = (AttendanceDay + AttendanceNight).ToString("N0");
            lb_absenceOfCompany.Text = (AbsenceDay + AbsenceNight).ToString("N0");
            lb_AttendanceDay.Text = AttendanceDay.ToString("N0");
            lb_AbsenceDay.Text = AbsenceDay.ToString("N0");
            lb_attendanceNight.Text = AttendanceNight.ToString("N0");
            lb_AbsenceNight.Text = AbsenceNight.ToString("N0");
            lb_AttendaceDayRate.Text = (AttendanceDay / (AbsenceDay + AttendanceDay)).ToString("P1");
            lb_AttendanceNightRate.Text = (AttendanceNight / (AbsenceNight + AttendanceNight)).ToString("P1");
            lb_indirectCompany.Text = IndirectCompany.ToString("N0");
            lb_directCompany.Text = DirectCompany.ToString("N0");
          
            lb_IndirectRate.Text = (IndirectCompany / EmpInCompany).ToString("P0");
          //  lb_dateReport.Text = DateTime.Now.Date.ToString("dd.MM.yyyy");
          double SeasonDay = attendanceDepts.Select(d => d.SeasonWorkerDay.attendanceActual).Sum() + attendanceDepts[0].SeannWorkerDayNotID;
            double SeasonNight = attendanceDepts.Select(d => d.SeasonWorkerNight.attendanceActual).Sum() + attendanceDepts[0].SeannWorkerNightNotID;
            lb_SeasonDay.Text = SeasonDay.ToString("N0");
            lb_SeasonNight.Text = SeasonNight.ToString("N0");
            lb_seasonTotal.Text = "Seasonal employees" + Environment.NewLine + (SeasonDay + SeasonNight).ToString("N0");
            lb_AttandanceINCompany.Text = (AttendanceDay + AttendanceNight+ SeasonDay+SeasonNight).ToString("N0");
            //this.WindowState = FormWindowState.Maximized;
        }

        public void IntializeforTableLayout(List<List<AttendanceDept>> attendanceDepts, int Start)
        {
            layoutMain.Visible = false;       
            layoutMain.Controls.Clear();
            layoutMain.ColumnStyles.Clear();
            layoutMain.RowStyles.Clear();
            
            layoutMain.ColumnCount = 1;
            layoutMain.RowCount = 2;
            float Percerntwidth = (float)(100 / layoutMain.ColumnCount);
            float Percerntheight = (float)(100 / layoutMain.RowCount);
            for (int i = 0; i < layoutMain.ColumnCount - 1; i++)
            {
                layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Percerntwidth));
            }
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100 - (Percerntwidth * (layoutMain.ColumnCount - 1))));
            for (int i = 0; i < layoutMain.RowCount - 1; i++)
            {
                layoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, Percerntheight));
            }
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100 - Percerntheight * (layoutMain.RowCount - 1)));
            if (attendanceDepts == null)
                return;
            int count = Start;
            if (count < ListAttendance.Count)
            {
               

                   ResourceDept1.Dispose();
                
               
                GC.SuppressFinalize(ResourceDept1);
                ResourceDept1 = null;
                // HumanResourceDept.attendanceDept = ListAttendance[count];
                ResourceDept1 = new HumanResourceDept(ListAttendance[count]);

                ClearMemory.CleanMemory();
                ResourceDept1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
 | System.Windows.Forms.AnchorStyles.Left)
 | System.Windows.Forms.AnchorStyles.Right)));
             //   HumanResourceDept.attendanceDept = ListAttendance[count];


                layoutMain.Controls.Add(ResourceDept1, 0, 0);
            }
            
            count++;
            if (count < ListAttendance.Count)
            {
                ResourceDept2.Dispose();
                GC.SuppressFinalize(ResourceDept2);
                ResourceDept2 = null;
                
                ClearMemory.CleanMemory();
                ResourceDept2 = new HumanResourceDept(ListAttendance[count]);
                ResourceDept2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                 | System.Windows.Forms.AnchorStyles.Left)
                 | System.Windows.Forms.AnchorStyles.Right)));
               // HumanResourceDept.attendanceDept = ListAttendance[count];
              
                layoutMain.Controls.Add(ResourceDept2, 0, 1);
            }
          //  count++;
            //for (int i = 0; i < layoutMain.ColumnCount; i++)
            //{
            //    for (int j = 0; j < layoutMain.RowCount; j++)
            //    {

            //        if (count < attendanceDepts.Count)
            //        {

            //            //  ResourceDept = new HumanResourceDept(attendanceDepts[count]);
            //       //     ResourceDept.attendanceDept = attendanceDepts[count];
            //            ResourceDept.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //    | System.Windows.Forms.AnchorStyles.Left)
            //    | System.Windows.Forms.AnchorStyles.Right)));
            //            layoutMain.Controls.Add(ResourceDept, i, j);


            //        //    count++;
            //        }
            //    }
            //}

            layoutMain.Visible = true;

         
            
            ResourceDept = null;
            ClearMemory.CleanMemory();
            


        }

        private void Button1_Click_1(object sender, EventArgs e)
        {if (CurrentStart == 0)
            {
                return;
                
            }
        else
            {
                CurrentStart = CurrentStart - 2;
                IntializeforTableLayout(ListAttendance, CurrentStart);
            }
        }

        private void Btn_NextPage_Click(object sender, EventArgs e)
        {
            if (CurrentStart > ListAttendance.Count-2)
            {
                return;

            }
            else
            {
                CurrentStart = CurrentStart + 2;
                IntializeforTableLayout(ListAttendance, CurrentStart);
            }
        }

        private void Btn_ExportExcel_Click(object sender, EventArgs e)
        {
            
            System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();
            string pathsave = "";
            saveFileDialog.Title = "Browse Excel Files";
            saveFileDialog.DefaultExt = "Excel";
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

            saveFileDialog.CheckPathExists = true;

            if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                GetAttendanceHR getAttendance = new GetAttendanceHR();
                List<AttendanceDept> attendanceDepts = getAttendance.GetAttendanceDeptsNew(dtpk_choose.Value);
                HRReport hRReport = new HRReport();
                pathsave = saveFileDialog.FileName;

                saveFileDialog.RestoreDirectory = true;

                hRReport.ExportExcelHRAttendaceReport(pathsave, attendanceDepts, dtpk_choose.Value);
                var resultMessage = MessageBox.Show("Attendance Daily Report export to excel sucessful ! \n\r Do you want to open this file ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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



        private void Btn_absenceList_Click(object sender, EventArgs e)
        {
            System.Windows.Input.Cursor oldCursor = Mouse.OverrideCursor;
            try
            {
                Mouse.OverrideCursor = System.Windows.Input.Cursors.Wait;
                //pic_loader.Visible = true;
                //pic_loader.Image = global::WindowsFormsApplication1.Properties.Resources.loader;
               
            
                System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();
                string pathsave = "";
                saveFileDialog.Title = "Browse Excel Files";
                saveFileDialog.DefaultExt = "Excel";
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx";

                saveFileDialog.CheckPathExists = true;

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    GetdataInout getdataInout = new GetdataInout();

                    List<EmployeeAbsence> employeeAbsences = new List<EmployeeAbsence>();
                    int IDSession = GetSessionID.GetsessionID(dtpk_choose.Value);
                    List<EmployeeAbsence> employeeAbsencesDay = getdataInout.GetEmployeeAbsencesDayShift(dtpk_choose.Value, IDSession);
                    List<EmployeeAbsence> employeeAbsencesDayNotPaiPan = getdataInout.GetEmployeeAbsencesDayShiftNotPaipan(dtpk_choose.Value, IDSession);
                    List<EmployeeAbsence> employeeAbsencesNightShift = getdataInout.GetEmployeeAbsencesNightShift(dtpk_choose.Value, IDSession);
                    
                    employeeAbsences.AddRange(employeeAbsencesDay);
                    employeeAbsences.AddRange(employeeAbsencesDayNotPaiPan);
                    employeeAbsences.AddRange(employeeAbsencesNightShift);
                   
                    HRReport hRReport = new HRReport();
                    pathsave = saveFileDialog.FileName;

                    saveFileDialog.RestoreDirectory = true;
                    hRReport.ExportExcelAbsenceReport(pathsave, employeeAbsences, dtpk_choose.Value);
                    var resultMessage = MessageBox.Show("Absence Daily Report export to excel sucessful ! \n\r Do you want to open this file ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
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

                //    WindowAbsenceList windowAbsenceList = new WindowAbsenceList(employeeAbsences);
                //windowAbsenceList.Show();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                Mouse.OverrideCursor = oldCursor;
            }
        }

      
        private void HRAttendaceReport_FormClosed(object sender, FormClosedEventArgs e)
        {
           
            bgWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            tmrCallBgWorker.Tick -= new EventHandler(tmrCallBgWorker_Tick);
            
        }

        private void dtpk_choose_ValueChanged(object sender, EventArgs e)
        {
            lbl_Header.Text = "Tech-Link manpower daily report on " + dtpk_choose.Value.ToString("dd-MM-yyyy");
        }

        private void btn_stop_Click(object sender, EventArgs e)
        {
            if (hRReport == HRReportStatus.pause)
            {
                //pic_loader.Visible = true;
                //pic_loader.Image = global::WindowsFormsApplication1.Properties.Resources.loader;
 
                //pic_loader.Visible = false;

                tmrCallBgWorker.Start();
                hRReport = HRReportStatus.start;
                btn_HRReport.BackColor = Color.Green;
            }
            else if (hRReport == HRReportStatus.start)
            {
                tmrCallBgWorker.Stop();
                hRReport = HRReportStatus.stop;
                btn_HRReport.BackColor = Color.Red;

            }
            else if (hRReport == HRReportStatus.stop)
            {
                tmrCallBgWorker.Start();
                hRReport = HRReportStatus.start;
                btn_HRReport.BackColor = Color.Green;
            }
        }

       
    }
}
