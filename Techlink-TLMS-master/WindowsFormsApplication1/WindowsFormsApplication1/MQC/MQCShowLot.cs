using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1.MQC
{
    public partial class MQCShowLot : MetroFramework.Forms.MetroForm
    {
        NGPanel nGPanel = new NGPanel(null);
        RWPanel nGRework = new RWPanel(null);
        BackgroundWorker bgWorker;
        // this timer calls bgWorker again and again after regular intervals
        System.Windows.Forms.Timer tmrCallBgWorker;
        // this is the timer to make sure that worker gets called
        System.Threading.Timer tmrEnsureWorkerGetsCalled;
        // object used for safe access
        object lockObject = new object();
        DateTime dateTimeFrom;
        DateTime dateTimeTo;
        MQCItem1 mQCItem = new MQCItem1();
        string dept = "";
        string process = "";
        string product = "";
        string po = "";
        bool IsStartup = false;
        string deptFull = "";
        int widthWindow = 0;
        int heightWindow = 0;
        int countRefresh = Properties.Settings.Default.intCounterRefresh;
        string Line= "";
        string Lot = "";
        string Model = "";
        public MQCShowLot(string line, string lot, string model, string dept)
        {
            InitializeComponent();
            Line = line;
            Lot = lot;
            Model = model;
            deptFull = dept;
            IsStartup = false;
            // this is our worker
            bgWorker = new BackgroundWorker();

            // work happens in this method
            bgWorker.DoWork += new DoWorkEventHandler(bg_DoWork);
            bgWorker.ProgressChanged += BgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            bgWorker.WorkerReportsProgress = true;
            //timer_update.Start();
            // this timer calls bgWorker again and again after regular intervals
            tmrCallBgWorker = new System.Windows.Forms.Timer();//Timer for do task
            tmrCallBgWorker.Tick += new EventHandler(tmrCallBgWorker_Tick);
        }
        #region Backround worker task
        void bg_DoWork(object sender, DoWorkEventArgs e)
        {

            var worker = sender as BackgroundWorker;
            LoadDataERPMQCToShow();
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
                    {
                        bgWorker.RunWorkerAsync();
                        countRefresh--;
                    }
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


            LoadUIFromMQCITEM();
            lb_mesage_defect.Left += 10;
            lb_messageMaterial.Left += 10;
        }
        public void LoadUIFromMQCITEM()
        {
            try
            {
                GC.Collect();
                GC.WaitForPendingFinalizers();
                lb_outputTotal.Text = mQCItem.TotalOutput.ToString("N0"); /*1234.567 ("N", en-US) -> 1,234.57*/
                lb_TargetValue.Text = mQCItem.TargetMQC.TargetOutput.ToString("N0");
                lb_NotyetSFT.Text = mQCItem.InputMaterialNotYet.ToString("N0");
                lb_TotalNG.Text = mQCItem.TotalNG.ToString("N0");
                lb_TotalRW.Text = mQCItem.TotalRework.ToString("N0");
                lb_percentNG.Text = mQCItem.percentNG.ToString("P1");
                lb_percentRW.Text = mQCItem.percentRework.ToString("P1");
                lb_dept.Text = deptFull;
                lb_po.Text = mQCItem.PO;
                lb_process.Text = mQCItem.line;
                lb_product.Text = mQCItem.product;
                if (mQCItem.Status == ProductionStatus.ShortageMaterial.ToString())
                {
                    lb_messageMaterial.Text = mQCItem.Measage;
                }
                if (mQCItem.Status == ProductionStatus.HighDefect.ToString())
                {
                    lb_mesage_defect.Text = mQCItem.Measage;
                }
                if (mQCItem.Status == ProductionStatus.Normal.ToString())
                {
                    lb_messageMaterial.Text = "";
                    lb_mesage_defect.Text = "";
                }
                nGPanel.Dispose();
                nGPanel = new NGPanel(mQCItem.listNGItems);
                pa_NGPanel.Controls.Clear();

                if (!pa_NGPanel.Controls.Contains(nGPanel))
                {
                    nGPanel.Name = mQCItem.product;

                    nGPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
                    pa_NGPanel.Controls.Add(nGPanel);

                    //    nGPanel.Dispose();
                }


                pa_rework.Controls.Clear();
                nGRework.Dispose();
                nGRework = new RWPanel(mQCItem.listRWItems);
                if (!pa_rework.Controls.Contains(nGRework))
                {

                    nGRework.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                         | System.Windows.Forms.AnchorStyles.Left)
                         | System.Windows.Forms.AnchorStyles.Right)));
                    pa_rework.Controls.Add(nGRework);

                    //  nGRework.Dispose();
                }
                lb_clock.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                GC.Collect();
                GC.WaitForPendingFinalizers();

            }
            catch (Exception ex)
            {
                SystemLog.Output(SystemLog.MSG_TYPE.Err, "LoadUIFromMQCITEM()", ex.Message);


            }

        }
        #endregion backround worker task
        int oldHScrollBar = 0;
        int oldscrollbarRW = 0;
        private void HScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            nGPanel.Left = nGPanel.Left - (hScrollBar1.Value - oldHScrollBar);
            oldHScrollBar = hScrollBar1.Value;
        }

        private void HScrollbarRework_Scroll(object sender, ScrollEventArgs e)
        {
            nGRework.Left = nGRework.Left - (hScrollbarRework.Value - oldscrollbarRW);
            oldscrollbarRW = hScrollbarRework.Value;
        }

        private void MQCShowLot_Load(object sender, EventArgs e)
        {

            SettingTimerForBrwoker(); //Setting Timer for run backround worker
            SettingTimeFromDateTodate();
            LoadcbInUI();
            LoadDataERPMQCToShow();
            LoadUIFromMQCITEM();

            IsStartup = true;
            hScrollBar1.Maximum = nGPanel.Width - layoutPanelNG.Width;
            hScrollbarRework.Maximum = nGRework.Width - layoutPanelRW.Width;
            this.WindowState = FormWindowState.Maximized;
        }
        private void SettingTimerForBrwoker()
        {
            int timerInterval = Properties.Settings.Default.intTimerMQCShow;

            tmrCallBgWorker.Interval = timerInterval;
            tmrCallBgWorker.Start();
        }

        #region Private function
        //Load data from database 172.0.16.12, tabble m_ERPMQC
        private void SettingTimeFromDateTodate()
        {
            //Setting DateTime from and To to limit data in database
            var lastDayOfMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);//avoid end of month
            if (DateTime.Now.Day < lastDayOfMonth)
            {
                dateTimeFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                dateTimeTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day + 1, 8, 0, 0);
            }
            else if (DateTime.Now.Day == lastDayOfMonth)
            {
                if (DateTime.Now.Month < 12)
                {
                    dateTimeFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                    dateTimeTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1, 8, 0, 0);
                }
                else if (DateTime.Now.Month == 12) //avoid 31/12
                {
                    dateTimeFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                    dateTimeTo = new DateTime(DateTime.Now.Year + 1, 1, 1, 8, 0, 0);
                }
            }

        }
        private void LoadcbInUI()
        {
            lb_dept.Text = deptFull;
            lb_process.Text = mQCItem.line;
            lb_product.Text = mQCItem.product;
            dept = mQCItem.department;
            process = "MQC";
            product = lb_product.Text;
            po = lb_po.Text;
        }
        private void LoadDataERPMQCToShow()
        {
            //Load data from m_ERPMQC

            LoadDataMQC dataMQC = new LoadDataMQC();
        //    DataTable dataLot = new DataTable();
         
                mQCItem = dataMQC.GetQCCItemLineLot(dateTimeFrom, dateTimeTo, Line,Model, Lot, process);
        //    }


        }
        #endregion
        private void MQCShowLot_FormClosed(object sender, FormClosedEventArgs e)
        {
            nGPanel.Dispose();
            nGRework.Dispose();
            nGPanel = null;
            nGRework = null;
            bgWorker.DoWork -= new DoWorkEventHandler(bg_DoWork);
            bgWorker.ProgressChanged -= BgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            tmrCallBgWorker.Tick -= new EventHandler(tmrCallBgWorker_Tick);
            tmrCallBgWorker.Stop();
            bgWorker.Dispose();
            tmrCallBgWorker.Dispose();
        }

        private void MQCShowLot_Resize(object sender, EventArgs e)
        {

            if (IsStartup)
            {

                if (this.WindowState == FormWindowState.Maximized)
                {
                    Lb_OutputLable.Font = new Font("Times New Roman", 50, FontStyle.Bold);
                    Lb_Target.Font = new Font("Times New Roman", 50, FontStyle.Bold);
                    Lb_SFTNotLable.Font = new Font("Times New Roman", 35, FontStyle.Bold);
                    Lb_TotalNGLabel.Font = new Font("Times New Roman", 50, FontStyle.Bold);
                    Lb_reworkLB.Font = new Font("Times New Roman", 50, FontStyle.Bold);


                    lb_outputTotal.Font = new Font("Times New Roman", 110, FontStyle.Bold);
                    lb_TargetValue.Font = new Font("Times New Roman", 80, FontStyle.Bold);
                    lb_NotyetSFT.Font = new Font("Times New Roman", 80, FontStyle.Bold);
                    lb_percentNG.Font = new Font("Times New Roman", 50, FontStyle.Bold);
                    lb_TotalNG.Font = new Font("Times New Roman", 50, FontStyle.Bold);
                    lb_TotalRW.Font = new Font("Times New Roman", 50, FontStyle.Bold);
                    lb_percentRW.Font = new Font("Times New Roman", 50, FontStyle.Bold);



                    //  lb_percentNG.Font = new Font("Times New Roman", lb_percentNG.Font.SizeInPoints + 10);
                }
                else if (this.WindowState == FormWindowState.Normal && this.Size.Width == widthWindow)
                {
                    Lb_OutputLable.Font = new Font("Times New Roman", 30, FontStyle.Bold);
                    Lb_Target.Font = new Font("Times New Roman", 30, FontStyle.Bold);
                    Lb_SFTNotLable.Font = new Font("Times New Roman", 25, FontStyle.Bold);
                    Lb_TotalNGLabel.Font = new Font("Times New Roman", 30, FontStyle.Bold);
                    Lb_reworkLB.Font = new Font("Times New Roman", 30, FontStyle.Bold);

                    lb_outputTotal.Font = new Font("Times New Roman", 30, FontStyle.Bold);
                    lb_TargetValue.Font = new Font("Times New Roman", 30, FontStyle.Bold);
                    lb_NotyetSFT.Font = new Font("Times New Roman", 30, FontStyle.Bold);
                    lb_percentNG.Font = new Font("Times New Roman", 30, FontStyle.Bold);
                    lb_TotalNG.Font = new Font("Times New Roman", 30, FontStyle.Bold);
                    lb_TotalRW.Font = new Font("Times New Roman", 30, FontStyle.Bold);
                    lb_percentRW.Font = new Font("Times New Roman", 30, FontStyle.Bold);

                }
                else
                {
                    widthWindow = this.Size.Width;
                    heightWindow = this.Size.Height;
                }
            }
            else
            {
                widthWindow = this.Size.Width;
                heightWindow = this.Size.Height;
            }
        }
    } 
}
