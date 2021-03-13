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
using MetroFramework.Forms;
using WindowsFormsApplication1.ChartDrawing;

namespace WindowsFormsApplication1.MQC
{
    public partial class MQCChart : MetroForm
    {
        List<chartdatabyDate> chartdatabyDates = new List<chartdatabyDate>();
        List<chartdatabyDate> chartdatadefect= new List<chartdatabyDate>();
        List<chartdatabyDate> chartdatabyDates_old = new List<chartdatabyDate>();
        List<chartdatabyDate> chartdatadefect_old = new List<chartdatabyDate>();
        MQCItem1 MQC = new MQCItem1();
        BackgroundWorker bgWorker;
        // this timer calls bgWorker again and again after regular intervals
        System.Windows.Forms.Timer tmrCallBgWorker;
        // this is the timer to make sure that worker gets called
        System.Threading.Timer tmrEnsureWorkerGetsCalled;
        // object used for safe access
        object lockObject = new object();
        int countRefresh = Properties.Settings.Default.intCounterRefresh;
        DateTime dateTimeFrom;
        DateTime dateTimeTo;
        public MQCChart(MQCItem1 mQC,List<chartdatabyDate> chartdata, List<chartdatabyDate> chartdataDefect)
        {
            InitializeComponent();
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
            this.WindowState = FormWindowState.Maximized;
            MQC = mQC;
            chartdatabyDates = chartdata;
            chartdatabyDates_old = chartdatabyDates;
            chartdatadefect = chartdataDefect;
            chartdatadefect_old = chartdatadefect;
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
            List<MQCDataItems> listMQC = new List<MQCDataItems>();
            LoadDataMQC loadDataMQC = new LoadDataMQC();

            listMQC = loadDataMQC.listMQCDataItems(dateTimeFrom, dateTimeTo, MQC.product, MQC.PO, MQC.process);
            chartdatabyDates = new List<chartdatabyDate>();
            chartdatadefect = new List<chartdatabyDate>();
            foreach (var item in listMQC)
            {
                if (item.item == "OUTPUT")
                {
                    chartdatabyDates.Add(new chartdatabyDate { date = item.inspectdate, time = item.inspecttime, value = item.data });
                }
                else if (item.remark == "NG")
                {
                    chartdatadefect.Add(new chartdatabyDate { date = item.inspectdate, time = item.inspecttime, value = item.data });
                }
            }
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
         
            if (chartdatabyDates_old.Count != chartdatabyDates.Count || chartdatadefect_old.Count != chartdatadefect.Count)
            {
                LiveChartDrawing liveChartDrawing = new LiveChartDrawing();
                liveChartDrawing.DrawingLiveChart(MQC.TargetMQC,chartdatabyDates, chartdatadefect, ref columnChart);
                chartdatabyDates_old = chartdatabyDates;
                chartdatadefect_old = chartdatadefect;
             List<chartdataPie> listChartDataPies =    GetchartdataPies(MQC);
                liveChartDrawing.DrawingPiechart(listChartDataPies,ref pieChartDefect);
            }
            if(countRefresh == 0)
            {
                LiveChartDrawing liveChartDrawing = new LiveChartDrawing();
                liveChartDrawing.DrawingLiveChart(MQC.TargetMQC, chartdatabyDates, chartdatadefect, ref columnChart);
                chartdatabyDates_old = chartdatabyDates;
                chartdatadefect_old = chartdatadefect;
                countRefresh = Properties.Settings.Default.intCounterRefresh;
                List<chartdataPie> listChartDataPies = GetchartdataPies(MQC);
                liveChartDrawing.DrawingPiechart(listChartDataPies, ref pieChartDefect);
            }
            lb_tittlechart.Text = "Defect Reason (" + MQC.TotalNG.ToString() + " pcs )";
            lb_clock.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");

        }
    
        #endregion backround worker task
        private void MQCChart_Load(object sender, EventArgs e)
        {
            SettingTimeFromDateTodate();
            LoadDataERPMQCToShow();
            LiveChartDrawing liveChartDrawing = new LiveChartDrawing();
            liveChartDrawing.DrawingLiveChart(MQC.TargetMQC,chartdatabyDates, chartdatadefect, ref columnChart);
            List<chartdataPie> listChartDataPies = GetchartdataPies(MQC);
            liveChartDrawing.DrawingPiechart(listChartDataPies, ref pieChartDefect);
         //   liveChartDrawing.DrawingGaugeChart(listChartDataPies, ref GaugeChartTarget);
            SettingTimerForBrwoker();
         
            lb_tittlechart.Text = "Defect Reason (" + MQC.TotalNG.ToString() + " pcs )";
            lb_clock.Text = DateTime.Now.ToString("dd-MMM-yyyy HH:mm:ss");
            lb_LotValue.Text = MQC.PO;
            lb_ProductValue.Text = MQC.product;


        }
        private void SettingTimerForBrwoker()
        {
            int timerInterval = Properties.Settings.Default.intTimerMQCChart;

            tmrCallBgWorker.Interval = timerInterval;
            tmrCallBgWorker.Start();
        }
        private void LoadDataERPMQCToShow()
        {
            //Load data from m_ERPMQC
            LoadDataMQC dataMQC = new LoadDataMQC();
            DataTable dataLot = new DataTable();
            dataLot = dataMQC.GetMQCDataFromLine(MQC.line);

            if (dataLot != null && dataLot.Rows.Count == 1)
            {
                MQC = dataMQC.GetQCCItemOK(dateTimeFrom, dateTimeTo, dataLot.Rows[0][1].ToString(), dataLot.Rows[0][0].ToString(), MQC.department, MQC.process);
            }

        }
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
                    dateTimeFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day,8 , 0, 0);
                    dateTimeTo = new DateTime(DateTime.Now.Year, DateTime.Now.Month + 1, 1, 8, 0, 0);
                }
                else if (DateTime.Now.Month == 12) //avoid 31/12
                {
                    dateTimeFrom = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 8, 0, 0);
                    dateTimeTo = new DateTime(DateTime.Now.Year + 1, 1, 1, 8, 0, 0);
                }
            }
            
        }
        public List<chartdataPie> GetchartdataPies (MQCItem1 mQC)
        {
            List<chartdataPie> chartdatas = new List<chartdataPie>();
            List<chartdataPie> chartdatasReturn = new List<chartdataPie>();
            for (int i = 0; i < mQC.listNGItems.Count; i++)
            {if (mQC.listNGItems[i].NGQuantity > 0)
                {
                    chartdatas.Add(new chartdataPie
                    {
                        Label = mQC.listNGItems[i].NGName,
                        value = mQC.listNGItems[i].NGQuantity,
                        Percent = (mQC.percentNG != 0) ? (mQC.listNGItems[i].NGQuantity / mQC.percentNG) : 0
                    });
                }
            }
  var group =    chartdatas
            .GroupBy(u => u.Label)
                    .Select(grp => grp.ToList())
                   .ToList();

            foreach (var item in group)
            {
                chartdataPie pie = new chartdataPie();
                pie = item[0];
                pie.value = item.Select(d => d.value).Sum();
                pie.Percent = (mQC.percentNG != 0) ? (pie.value / mQC.percentNG) : 0;
                chartdatasReturn.Add(pie);
            }
            return chartdatasReturn;
        }

        private void MQCChart_FormClosed(object sender, FormClosedEventArgs e)
        {
            bgWorker.DoWork -= new DoWorkEventHandler(bg_DoWork);
            bgWorker.ProgressChanged -= BgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            tmrCallBgWorker.Tick -= new EventHandler(tmrCallBgWorker_Tick);
            tmrCallBgWorker.Stop();
            bgWorker.Dispose();
            tmrCallBgWorker.Dispose();
        }
       
    }
}
