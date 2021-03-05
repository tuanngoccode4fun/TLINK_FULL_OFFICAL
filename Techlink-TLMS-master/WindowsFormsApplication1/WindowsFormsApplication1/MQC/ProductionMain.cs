using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;


namespace WindowsFormsApplication1.MQC
{
    public partial class ProductionMain :MetroForm
    {
        bool isStartup = false;
        DateTime dateTimeFrom;
        DateTime dateTimeTo;
        string dept = "";
        string process = "";
        BackgroundWorker bgWorker;
        // this timer calls bgWorker again and again after regular intervals
        System.Windows.Forms.Timer tmrCallBgWorker;
        // this is the timer to make sure that worker gets called
        System.Threading.Timer tmrEnsureWorkerGetsCalled;
        // object used for safe access
        object lockObject = new object();
        MQCItem1 MQCItem1 = new MQCItem1();
        List<MQCItem1> ListMQCshow = new List<MQCItem1>();
        List<MQCItem1> ListMQCTake= new List<MQCItem1>();
        int CountColumn = Properties.Settings.Default.IntLayoutMQCColumn;
        int CountRow = Properties.Settings.Default.intLayoutMQCRows;
        int width = 0; int height = 0;
        LineUI line = new LineUI(null,null,12);
        public string pathMonth = Environment.CurrentDirectory + @"\Resources\Month.xls";
        public ProductionMain()
        {
            InitializeComponent();
            IntializeforTableLayout();
            string screenWidth = Screen.PrimaryScreen.Bounds.Width.ToString();
            string screenHeight = Screen.PrimaryScreen.Bounds.Height.ToString();
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
                LoadDataERPMQCToShow();
            }
            catch (Exception ex)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "LoadDataERPMQCToShow()", ex.Message);
            }
          

        }
        #endregion backround worker task
        public void IntializeforTableLayout ()
        {
            layoutMain.Controls.Clear();
            layoutMain.ColumnCount = CountColumn;
            layoutMain.RowCount = CountRow;
            float Percerntwidth = (float)(100 / layoutMain.ColumnCount);
            float Percerntheight= (float)(100 / layoutMain.RowCount);
            layoutMain.ColumnStyles.Clear();
            for (int i = 0; i < layoutMain.ColumnCount-1; i++)
            {
                layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, Percerntwidth));
            }
            layoutMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent,100 - (Percerntwidth* (layoutMain.ColumnCount - 1))));
            layoutMain.RowStyles.Clear();
            for (int i = 0; i < layoutMain.RowCount-1; i++)
            {
                layoutMain.RowStyles.Add(new RowStyle(SizeType.Percent, Percerntheight));
            }
            layoutMain.RowStyles.Add(new RowStyle(SizeType.Percent,100- Percerntheight *(layoutMain.RowCount - 1)));
            for (int i = 0; i < layoutMain.ColumnCount; i++)
            {
                for (int j = 0; j < layoutMain.RowCount; j++)
                {
                   // line.Dispose();
                    if (this.WindowState == FormWindowState.Normal)
                    line = new LineUI(MQCItem1,cb_Department.Text,20);
                    else if (this.WindowState == FormWindowState.Maximized)
                        line = new LineUI(MQCItem1, cb_Department.Text, 25);

                    line.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
                    layoutMain.Controls.Add(line, i, j);
                    
                }
            }
            isStartup = true;


        }
        private void SettingTimerForBrwoker()
        {
            int timerInterval = Properties.Settings.Default.intTimerMQC;

            tmrCallBgWorker.Interval = timerInterval;
            tmrCallBgWorker.Start();
        }
        private void ProductionMain_Load(object sender, EventArgs e)
        { LoaddataConfigure loaddata = new LoaddataConfigure();
            List<DeptCodeName> deptCodeNames = loaddata.deptCodeNames(ref cb_Department);
            cb_Department.SelectedItem = "[B01] - 胶管OEM生产线ONGOEM";
            SettingTimerForBrwoker();
            SettingTimeFromDateTodate();
            LoadDataERPMQCToShow();
            lb_Clock.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
            this.WindowState = FormWindowState.Maximized;
        }

        private void ProductionMain_Resize(object sender, EventArgs e)
        {

       
            if (isStartup)
            {
                if (this.WindowState == FormWindowState.Maximized )
                {
                    cb_Department.Font = new Font("Times New Roman", 35, FontStyle.Bold);
                    lb_Clock.Font = new Font("Times New Roman", 30, FontStyle.Bold);
                    //lb_Clock.AutoSize = true;
                 //  scaleFont(lb_Clock);
                }
                else if (this.WindowState == FormWindowState.Normal && this.Size.Width == width )
                {
                    cb_Department.Font = new Font("Times New Roman", 20, FontStyle.Bold);
                   // scaleFont(lb_Clock);
                    lb_Clock.Font = new Font("Times New Roman", 20, FontStyle.Bold);
                 //   lb_Clock.AutoSize = true;
                }
               else
                {
                    width = this.Size.Width;
                    height = this.Size.Height;
                }
            }
           else
            {
                width = this.Size.Width;
                height = this.Size.Height;
              //  scaleFont(lb_Clock);
            }
           // ScaleFont(lb_Clock);
          //  lb_Clock.AutoSize = true;
        }
        private void scaleFont(Label lab)
        {
            Image fakeImage = new Bitmap(1, 1); //As we cannot use CreateGraphics() in a class library, so the fake image is used to load the Graphics.
            Graphics graphics = Graphics.FromImage(fakeImage);

            SizeF extent = graphics.MeasureString(lab.Text, lab.Font);

            float hRatio = lab.Height / extent.Height;
            float wRatio = lab.Width / extent.Width;
            float ratio = (hRatio < wRatio) ? hRatio : wRatio;

            float newSize = lab.Font.Size * ratio;

            lab.Font = new Font(lab.Font.FontFamily, newSize, lab.Font.Style);
        }
        //private void ScaleFont(Label lab)
        //{
        //    SizeF extent = TextRenderer.MeasureText(lab.Text, lab.Font);

        //    float hRatio = lab.Height / extent.Height;
        //    float wRatio = lab.Width / extent.Width;
        //    float ratio = (hRatio < wRatio) ? hRatio : wRatio;

        //    float newSize = lab.Font.Size * ratio;

        //    lab.Font = new Font(lab.Font.FontFamily, newSize, lab.Font.Style);
        //}
        private void LoadDataERPMQCToShow()
        {
            //Load data from m_ERPMQC
            LoadDataMQC dataMQC = new LoadDataMQC();
            dept = "B01";
            process = "MQC";
            ListMQCshow = dataMQC.listMQCItemsOfDept(dateTimeFrom, dateTimeTo, dept, process);
            var listshowline = ListMQCshow
                .OrderBy(u=>u.line)
                .GroupBy(u => u.line)               
    .Select(grp => grp.ToList())
    .ToList();
            List<MQCItem1> ListShowbyLine = new List<MQCItem1>();
            foreach (var LineData in listshowline)
            {
                MQCItem1 mQC = new MQCItem1();
                   DateTime maxDate = LineData.Select(d => d.DateRun).Max();
                mQC = LineData.Where(d => d.DateRun == maxDate).ToList()[0];
                
                ListShowbyLine.Add(mQC);
            }

            int topCount = CountColumn * CountRow;
            //ListMQCTake = ListMQCshow.Take(topCount).ToList();
            layoutMain.Controls.Clear();

            if (ListShowbyLine.Count <= topCount)
            {
                int countList = 0;
                for (int i = 0; i < CountRow; i++)
                {
                    for (int j = 0; j < CountColumn; j++)
                    {
                        if (countList < ListShowbyLine.Count)
                        {
                         //   line.Dispose();
                            if (this.WindowState == FormWindowState.Normal)
                                line = new LineUI(ListShowbyLine[countList], cb_Department.Text, 20);
                            else if (this.WindowState == FormWindowState.Maximized)
                                line = new LineUI(ListShowbyLine[countList], cb_Department.Text, 25);
                            line.Name = ListShowbyLine[countList].line;

                            line.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right)));

                            layoutMain.Controls.Add(line, j, i);
                            countList++;
                        }
                    }
                }
            }


            lb_Clock.Text = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

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

   

       

        private void ProductionMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            bgWorker.DoWork -= new DoWorkEventHandler(bg_DoWork);
            bgWorker.ProgressChanged -= BgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted -= new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            tmrCallBgWorker.Tick -= new EventHandler(tmrCallBgWorker_Tick);
            if (line != null)
            {
                line.Dispose();
                line = null;
            }
            tmrCallBgWorker.Stop();
            bgWorker.Dispose();
            tmrCallBgWorker.Dispose();
            
        }

        private void Label2_Click(object sender, EventArgs e)
        {
           
            
        }
    }
}
