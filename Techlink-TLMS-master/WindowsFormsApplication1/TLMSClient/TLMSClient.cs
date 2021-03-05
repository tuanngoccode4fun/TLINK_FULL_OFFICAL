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
using TLMSClient.Controller;
using TLMSClient.Logfile;
using TLMSClient.Model;
using TLMSClient.View;
using MetroFramework.Forms;
using System.IO;

namespace TLMSClient
{
    public partial class TLMSClient : MetroForm
    {
        private string path = Environment.CurrentDirectory;
        BackgroundWorker bgWorker;
        // this timer calls bgWorker again and again after regular intervals
        System.Windows.Forms.Timer tmrCallBgWorker;
        // this is the timer to make sure that worker gets called
        System.Threading.Timer tmrEnsureWorkerGetsCalled;
        // object used for safe access
        object lockObject = new object();
        List<ItemMaterial> ListMaterial = new List<ItemMaterial>();
        System.Windows.Forms.NotifyIcon m_notify = null;
        bool IsAllowClosing = false;
        System.Windows.Forms.ContextMenu menu = new System.Windows.Forms.ContextMenu();
        Configure SettingConfigure = new Configure();
        public TLMSClient()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
            bgWorker = new BackgroundWorker();
            bgWorker.DoWork += new DoWorkEventHandler(bg_DoWork);
            bgWorker.ProgressChanged += BgWorker_ProgressChanged;
            bgWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bg_RunWorkerCompleted);
            bgWorker.WorkerReportsProgress = true;

            //timer_update.Start();
            // this timer calls bgWorker again and again after regular intervals
            tmrCallBgWorker = new System.Windows.Forms.Timer();//Timer for do task
            tmrCallBgWorker.Tick += new EventHandler(tmrCallBgWorker_Tick);
            LoadConfigureTimer();
         //   tmrCallBgWorker.Interval = 5000;
            tmrCallBgWorker.Start();
        }
        private void LoadConfigureTimer()
        {
            Configure configure = new Configure();
            if (File.Exists(path + @"\Configure.ini"))
            {
                configure = (Configure)SaveObject.Load_data(path + @"\Configure.ini");
                if (configure != null)
                {
                    tmrCallBgWorker.Interval = (int)configure.Timer > 0 ? (int)configure.Timer * 1000 : 5000;
                }
                else
                {
                    tmrCallBgWorker.Interval =  5000;
                }

            }
            else
            {
                tmrCallBgWorker.Interval = 5000;
            }
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
                FoundShortageMaterial();
                if (dtgv_main.Rows.Count > 0)
                {
                    this.WindowState = FormWindowState.Maximized;
                    this.Show();
                    toolStripStatusLabel1.Text = "Please add material for profuction !";
                }
            }
            catch (Exception ex)
            {

                Logfile.Logfile.Output(StatusLog.Error, "LoadDataERPMQCToShow()", ex.Message);
            }


        }
        #endregion backround worker task
        private void FoundShortageMaterial()
        {
            CheckMaterial checkMaterial = new CheckMaterial();
            ListMaterial = checkMaterial.ListMaterial("");
            if (ListMaterial != null && ListMaterial.Count != 0)
            {
                List<ItemMaterialShow> itemMaterialShows = new List<ItemMaterialShow>();

                foreach (var item in ListMaterial)
                {
                    ItemMaterialShow show = new ItemMaterialShow();
                    show.deptName = item.deptCode;
                    show.ID = item.ID;
                    show.Product = item.Product;
                    show.DateRun = item.DateRun;
                    show.Quantity = item.Quantity;
                    
                    if (item.MaterialAdapts != null)
                        show.Percent = item.MaterialAdapts.Select(d => d.Percent).Min();
                    itemMaterialShows.Add(show);
                }
                dtgv_main.Columns.Clear();
                dtgv_main.DataSource = itemMaterialShows;
                MakeUpDatagridview(dtgv_main);
            }

        }
        private void MakeUpDatagridview(DataGridView gridView)
        {
            DataGridViewImageColumn dgvImageExpand = new DataGridViewImageColumn();
            dgvImageExpand.Name = "ImageExpand";
            dgvImageExpand.Image = global::TLMSClient.Properties.Resources.expand_icon;
            dgvImageExpand.Visible = true;
            dgvImageExpand.Width = 20;
           
            gridView.Columns.Insert(0, dgvImageExpand);
            gridView.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            gridView.Columns[0].HeaderText = "";
            gridView.Columns[1].HeaderText = "Department";
            gridView.Columns[1].MinimumWidth = 100;
            gridView.Columns[2].HeaderText = "Production Order";
            gridView.Columns[2].MinimumWidth = 100;
            gridView.Columns[3].HeaderText = "Product";
            gridView.Columns[3].MinimumWidth = 100;
            gridView.Columns[4].HeaderText = "Quantity";
            gridView.Columns[4].MinimumWidth = 100;
            gridView.Columns[5].HeaderText = "Production's Date";
            gridView.Columns[5].MinimumWidth = 100;
            gridView.Columns[6].HeaderText = "Percent (%)";
            gridView.Columns[6].MinimumWidth = 100;
            gridView.Columns[6].DefaultCellStyle.Format = "P1";

            gridView.BackgroundColor = Color.LightSteelBlue;
            gridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;

        }

        private void Dtgv_main_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgv_main.Controls.Clear();
            DataGridViewImageColumn cols = (DataGridViewImageColumn)dtgv_main.Columns[0];
            if (cols.Name == "ImageExpand")
            {
                DataGridView gridViewDetail = new DataGridView();
                String Filterexpression = dtgv_main.Rows[e.RowIndex].Cells[2].Value.ToString();
                var list = ListMaterial.Where(d => d.ID == Filterexpression).ToList();

                dtgv_main.Controls.Add(gridViewDetail);
                Rectangle dgvRectangle = dtgv_main.GetCellDisplayRectangle(1, e.RowIndex, true);
                gridViewDetail.Size = new Size(dtgv_main.Width, 200);
                gridViewDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                gridViewDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridViewDetail.Location = new Point(dgvRectangle.X, dgvRectangle.Y + 30);
                gridViewDetail.BackgroundColor = Color.LightSteelBlue;
                gridViewDetail.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
                gridViewDetail.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
                gridViewDetail.DataSource = list[0].MaterialAdapts;

                gridViewDetail.Columns[4].DefaultCellStyle.Format = "P1";
                gridViewDetail.Columns[3].DefaultCellStyle.Format = "N1";
                gridViewDetail.Columns[2].DefaultCellStyle.Format = "N1";
                gridViewDetail.Columns[1].DefaultCellStyle.Format = "N1";
                gridViewDetail.Columns[0].MinimumWidth = 50;
                gridViewDetail.Columns[1].MinimumWidth = 50;
                gridViewDetail.Columns[2].MinimumWidth = 50;
                gridViewDetail.Columns[3].MinimumWidth = 50;
                gridViewDetail.Columns[0].HeaderText = "Material";
                gridViewDetail.Columns[1].HeaderText = "Plan Qty";
                gridViewDetail.Columns[2].HeaderText = "Actual Need Qty";
                gridViewDetail.Columns[3].HeaderText = "Available Qty";
                gridViewDetail.Columns[4].HeaderText = "Percent (%)";
                gridViewDetail.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
                gridViewDetail.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 13, FontStyle.Regular);
                gridViewDetail.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridViewDetail.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                gridViewDetail.ColumnHeadersHeight = 40;
                dtgv_main.Columns[0].Name = "Close";
                tmrCallBgWorker.Stop();
                dtgv_main.Rows[e.RowIndex].Cells[0].Value = global::TLMSClient.Properties.Resources.close_icon;
             //   cols.Image = global::TLMSClient.Properties.Resources.close_icon;
            }
            else if (cols.Name == "Close")
            {
                dtgv_main.Controls.Clear();
                dtgv_main.Columns[0].Name = "ImageExpand";
                dtgv_main.Rows[e.RowIndex].Cells[0].Value = global::TLMSClient.Properties.Resources.expand_icon;
                tmrCallBgWorker.Start();
            }
        }

        private void TLMSClient_Load(object sender, EventArgs e)
        {
       
            System.Windows.Forms.MenuItem itemSetting = new System.Windows.Forms.MenuItem();
            itemSetting.Index = 0;
            itemSetting.Text = "Setting";
            itemSetting.Click += ItemSetting_Click;
            menu.MenuItems.Add(itemSetting);
            System.Windows.Forms.MenuItem itemStop = new System.Windows.Forms.MenuItem();
            itemStop.Index = 0;
            itemStop.Text = "Stop";
            itemStop.Click += ItemStop_Click; 
            menu.MenuItems.Add(itemStop);
            System.Windows.Forms.MenuItem itemStart = new System.Windows.Forms.MenuItem();
            itemStart.Index = 0;
            itemStart.Text = "Start";
            itemStart.Enabled = false;
            itemStart.Click += ItemStart_Click;
            menu.MenuItems.Add(itemStart);
            System.Windows.Forms.MenuItem itemConfig = new System.Windows.Forms.MenuItem();
            itemConfig.Index = 0;
            itemConfig.Text = "Exit";
            itemConfig.Click += ItemConfig_Click;
            menu.MenuItems.Add(itemConfig);
            m_notify = new System.Windows.Forms.NotifyIcon();
            m_notify.Icon = Properties.Resources.Clients;
            m_notify.Visible = true;
            m_notify.DoubleClick += (object send, EventArgs args) => { this.Show(); this.WindowState = FormWindowState.Normal; this.ShowInTaskbar = true; };
            m_notify.ContextMenu = menu;
            m_notify.Text = "TLMS CLient";
            Version ver = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            string str = string.Format("TLMS CLient: v{0}.{1}.{2}", ver.Major, ver.Minor, ver.Build);
            notiftyBalloonTip(str, 1000);
            this.Hide();
            this.WindowState = FormWindowState.Minimized;
        }

        private void ItemStart_Click(object sender, EventArgs e)
        {
            tmrCallBgWorker.Start();
            menu.MenuItems[1].Enabled = true;
            menu.MenuItems[2].Enabled = false;
        }

        private void ItemStop_Click(object sender, EventArgs e)
        {
            tmrCallBgWorker.Stop();
            menu.MenuItems[1].Enabled = false;
            menu.MenuItems[2].Enabled = true;
        }

        private void ItemSetting_Click(object sender, EventArgs e)
        {
           
               Setting settingTimer = new Setting();
            settingTimer.Show();
        }

        private void notiftyBalloonTip(string message, int showTime, string title = null)
        {
            if (m_notify == null)
                return;
            if (title == null)
                m_notify.BalloonTipTitle = "TLMS Client";
            else
                m_notify.BalloonTipTitle = title;
            m_notify.BalloonTipText = message;
            m_notify.ShowBalloonTip(showTime);
        }
        private void ItemConfig_Click(object sender, EventArgs e)
        {
            IsAllowClosing = true;

            this.Close();
            Logfile.Logfile.Output(StatusLog.Normal, "program TLMS Client closing", e.ToString());
        }

        private void TLMSClient_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (IsAllowClosing == false)
            {
                e.Cancel = true;
                this.Hide();
            }
        }
    }
}
