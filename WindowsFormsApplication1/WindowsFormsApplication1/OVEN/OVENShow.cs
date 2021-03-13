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
using System.Data;
using LiveCharts.Wpf;
using Brushes = System.Windows.Media.Brushes;
using System.Windows.Media;
using System.Windows;

namespace WindowsFormsApplication1.OVEN
{
    
    public partial class OVENShow : CommonFormMetro
    {
        BackgroundWorker bgWorker;
        // this timer calls bgWorker again and again after regular intervals
        System.Windows.Forms.Timer tmrCallBgWorker;
        // this is the timer to make sure that worker gets called
        System.Threading.Timer tmrEnsureWorkerGetsCalled;
        // object used for safe access
        object lockObject = new object();
        DataTable dtOvens = new DataTable();

        public OVENShow()
        {
            InitializeComponent();

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
            OVEN.Database.GetdataOven getdataOven = new Database.GetdataOven();

            dtOvens = getdataOven.GetUpdateTemperature();


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


            LoadUIFromOvenData(dtOvens);


        }
        public void LoadUIFromOvenData( DataTable dtOvens)
        {
            try
            {
                angularGauge1.Sections.Clear();
                angularGauge2.Sections.Clear();
                angularGauge3.Sections.Clear();
                angularGauge4.Sections.Clear();
                angularGauge5.Sections.Clear();
                angularGauge6.Sections.Clear();

                if (dtOvens.Rows.Count > 0)
                {
                    for (int i = 1; i < 7; i++)
                    {
                        var dt = dtOvens.Select("model = 'OVEN-" + i.ToString() + "' ");
                        double PVValue = 0;
                        double SVValues = 0;
                        if (i == 1)
                        {

                            for (int j = 0; j < dt.Count(); j++)
                            {
                                if (dt[j]["item"].ToString() == "SV")
                                {
                                    
                                    xuiCard1.Text1 = "OVEN 1";
                                    SVValues = double.Parse(dt[j]["data"].ToString());
                                }

                                else if (dt[j]["item"].ToString() == "PV")
                                {

                                    xuiCard1.Text2 = "Temperature : " + dt[j]["data"].ToString() + " o C";
                                    PVValue = double.Parse(dt[j]["data"].ToString());

                                }


                                else if (dt[j]["item"].ToString() == "STATUS")
                                {

                                    xuiCard1.Text3 = "Auto Mode : " + dt[j]["data"].ToString();

                                }
                            }
                            int Per = ((int) ( PVValue / (SVValues + 20)*100));

                            angularGauge1.Value = PVValue;
                            angularGauge1.FromValue = 50;
                            angularGauge1.ToValue = SVValues+50;
                            angularGauge1.TicksForeground = Brushes.White;
                            angularGauge1.Base.Foreground = Brushes.White;
                            angularGauge1.Base.FontWeight = FontWeights.Bold;
                            angularGauge1.Base.FontSize = 16;
                            angularGauge1.SectionsInnerRadius = 0.5;

                            angularGauge1.Sections.Add(new AngularSection
                            {
                                FromValue = 50,
                                ToValue = SVValues,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(23, 226, 4))
                            });
                            angularGauge1.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues,
                                ToValue = SVValues + 10,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(223, 254, 4))
                            });
                            angularGauge1.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues+10,
                                ToValue = SVValues+20,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 190, 2))
                            });
                            angularGauge1.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues+20,
                                ToValue = SVValues + 50,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
                            }) ;

                        }

                    else    if (i == 2)
                        {

                            for (int j = 0; j < dt.Count(); j++)
                            {
                                if (dt[j]["item"].ToString() == "SV")
                                {
                                   
                                    xuiCard2.Text1 = "OVEN 2";
                                    SVValues = double.Parse(dt[j]["data"].ToString());
                                }

                                else if (dt[j]["item"].ToString() == "PV")
                                {

                                    xuiCard2.Text2 = "Temperature : " + dt[j]["data"].ToString() + " o C";
                                    PVValue = double.Parse(dt[j]["data"].ToString());
                                }


                                else if (dt[j]["item"].ToString() == "STATUS")
                                {

                                    xuiCard2.Text3 = "Auto Mode : " + dt[j]["data"].ToString();

                                }
                            }
                            angularGauge2.Value = PVValue;
                            angularGauge2.FromValue = 50;
                            angularGauge2.ToValue = SVValues + 50;
                            angularGauge2.TicksForeground = Brushes.White;
                            angularGauge2.Base.Foreground = Brushes.White;
                            angularGauge2.Base.FontWeight = FontWeights.Bold;
                            angularGauge2.Base.FontSize = 16;
                            angularGauge2.SectionsInnerRadius = 0.5;

                            angularGauge2.Sections.Add(new AngularSection
                            {
                                FromValue = 50,
                                ToValue = SVValues,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(23, 226, 4))
                            });
                            angularGauge2.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues,
                                ToValue = SVValues + 10,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(223, 254, 4))
                            });
                            angularGauge2.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues + 10,
                                ToValue = SVValues + 20,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 190, 2))
                            });
                            angularGauge2.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues + 20,
                                ToValue = SVValues + 50,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
                            });
                        }
                    else    if (i ==3)
                        {

                            for (int j = 0; j < dt.Count(); j++)
                            {
                                if (dt[j]["item"].ToString() == "SV")
                                {
                                    
                                    xuiCard3.Text1 = "OVEN 3";
                                    SVValues = double.Parse(dt[j]["data"].ToString());
                                }

                                else if (dt[j]["item"].ToString() == "PV")
                                {

                                    xuiCard3.Text2 = "Temperature : " + dt[j]["data"].ToString() + " o C";
                                    PVValue = double.Parse(dt[j]["data"].ToString());
                                }


                                else if (dt[j]["item"].ToString() == "STATUS")
                                {

                                    xuiCard3.Text3 = "Auto Mode : " + dt[j]["data"].ToString();

                                }
                            }
                            angularGauge3.Value = PVValue;
                            angularGauge3.FromValue = 50;
                            angularGauge3.ToValue = SVValues + 50;
                            angularGauge3.TicksForeground = Brushes.White;
                            angularGauge3.Base.Foreground = Brushes.White;
                            angularGauge3.Base.FontWeight = FontWeights.Bold;
                            angularGauge3.Base.FontSize = 16;
                            angularGauge3.SectionsInnerRadius = 0.5;

                            angularGauge3.Sections.Add(new AngularSection
                            {
                                FromValue = 50,
                                ToValue = SVValues,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(23, 226, 4))
                            });
                            angularGauge3.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues,
                                ToValue = SVValues + 10,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(223, 254, 4))
                            });
                            angularGauge3.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues + 10,
                                ToValue = SVValues + 20,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 190, 2))
                            });
                            angularGauge3.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues + 20,
                                ToValue = SVValues + 50,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
                            });
                        }
                        else if (i == 4)
                        {

                            for (int j = 0; j < dt.Count(); j++)
                            {
                                if (dt[j]["item"].ToString() == "SV")
                                {
                                    
                                    xuiCard4.Text1 = "OVEN 4";
                                    SVValues = double.Parse(dt[j]["data"].ToString());
                                }

                                else if (dt[j]["item"].ToString() == "PV")
                                {

                                    xuiCard4.Text2 = "Temperature : " + dt[j]["data"].ToString() + " o C";
                                    PVValue = double.Parse(dt[j]["data"].ToString());
                                }


                                else if (dt[j]["item"].ToString() == "STATUS")
                                {

                                    xuiCard4.Text3 = "Auto Mode : " + dt[j]["data"].ToString();

                                }
                            }
                            angularGauge4.Value = PVValue;
                            angularGauge4.FromValue = 50;
                            angularGauge4.ToValue = SVValues + 50;
                            angularGauge4.TicksForeground = Brushes.White;
                            angularGauge4.Base.Foreground = Brushes.White;
                            angularGauge4.Base.FontWeight = FontWeights.Bold;
                            angularGauge4.Base.FontSize = 16;
                            angularGauge4.SectionsInnerRadius = 0.5;

                            angularGauge4.Sections.Add(new AngularSection
                            {
                                FromValue = 50,
                                ToValue = SVValues,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(23, 226, 4))
                            });
                            angularGauge4.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues,
                                ToValue = SVValues + 10,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(223, 254, 4))
                            });
                            angularGauge4.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues + 10,
                                ToValue = SVValues + 20,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 190, 2))
                            });
                            angularGauge4.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues + 20,
                                ToValue = SVValues + 50,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
                            });
                        }
                        else if (i == 5)
                        {

                            for (int j = 0; j < dt.Count(); j++)
                            {
                                if (dt[j]["item"].ToString() == "SV")
                                {
                                   
                                    xuiCard5.Text1 = "OVEN 5";
                                    SVValues = double.Parse(dt[j]["data"].ToString());
                                }

                                else if (dt[j]["item"].ToString() == "PV")
                                {

                                    xuiCard5.Text2 = "Temperature : " + dt[j]["data"].ToString() + " o C";
                                    PVValue = double.Parse(dt[j]["data"].ToString());
                                }


                                else if (dt[j]["item"].ToString() == "STATUS")
                                {

                                    xuiCard5.Text3 = "Auto Mode : " + dt[j]["data"].ToString();

                                }
                            }
                            angularGauge5.Value = PVValue;
                            angularGauge5.FromValue = 50;
                            angularGauge5.ToValue = SVValues + 50;
                            angularGauge5.TicksForeground = Brushes.White;
                            angularGauge5.Base.Foreground = Brushes.White;
                            angularGauge5.Base.FontWeight = FontWeights.Bold;
                            angularGauge5.Base.FontSize = 16;
                            angularGauge5.SectionsInnerRadius = 0.5;

                            angularGauge5.Sections.Add(new AngularSection
                            {
                                FromValue = 50,
                                ToValue = SVValues,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(23, 226, 4))
                            });
                            angularGauge5.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues,
                                ToValue = SVValues + 10,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(223, 254, 4))
                            });
                            angularGauge5.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues + 10,
                                ToValue = SVValues + 20,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 190, 2))
                            });
                            angularGauge5.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues + 20,
                                ToValue = SVValues + 50,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
                            });
                        }
                        else if (i == 6)
                        {

                            for (int j = 0; j < dt.Count(); j++)
                            {
                                if (dt[j]["item"].ToString() == "SV")
                                {
                                    xuiCard6.Text1 = "OVEN 6";
                                    SVValues = double.Parse(dt[j]["data"].ToString());
                                }

                                else if (dt[j]["item"].ToString() == "PV")
                                {

                                    xuiCard6.Text2 = "Temperature : " + dt[j]["data"].ToString() + " o C";
                                    PVValue = double.Parse(dt[j]["data"].ToString());
                                }


                                else if (dt[j]["item"].ToString() == "STATUS")
                                {

                                    xuiCard6.Text3 = "Auto Mode : " + dt[j]["data"].ToString();

                                }
                            }
                            angularGauge6.Value = PVValue;
                            angularGauge6.FromValue = 50;
                            angularGauge6.ToValue = SVValues + 50;
                            angularGauge6.TicksForeground = Brushes.White;
                            angularGauge6.Base.Foreground = Brushes.White;
                            angularGauge6.Base.FontWeight = FontWeights.Bold;
                            angularGauge6.Base.FontSize = 16;
                            angularGauge6.SectionsInnerRadius = 0.5;

                            angularGauge6.Sections.Add(new AngularSection
                            {
                                FromValue = 50,
                                ToValue = SVValues,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(23, 226, 4))
                            });
                            angularGauge6.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues,
                                ToValue = SVValues + 10,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(223, 254, 4))
                            });
                            angularGauge6.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues + 10,
                                ToValue = SVValues + 20,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 190, 2))
                            });
                            angularGauge6.Sections.Add(new AngularSection
                            {
                                FromValue = SVValues + 20,
                                ToValue = SVValues + 50,
                                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(254, 57, 57))
                            });
                        }

                    }
                }
                lbl_datetime.Text = "Last updated : "+  DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");
                tableLayoutPanel1.Refresh();
                GC.Collect();
                GC.WaitForPendingFinalizers();
               

           
             

            }
            catch (Exception ex)
            {
               


            }

        }
        #endregion backround worker task

        private void SettingTimerForBrwoker()
        {
            int timerInterval = Properties.Settings.Default.intTimerMQCShow;

            tmrCallBgWorker.Interval = timerInterval;
            tmrCallBgWorker.Start();
        }

        private void OVENShow_Load(object sender, EventArgs e)
        {
            SettingTimerForBrwoker();
            OVEN.Database.GetdataOven getdataOven = new Database.GetdataOven();

            dtOvens = getdataOven.GetUpdateTemperature();
            LoadUIFromOvenData(dtOvens);
            WindowState = FormWindowState.Maximized;

        }
    }
}
