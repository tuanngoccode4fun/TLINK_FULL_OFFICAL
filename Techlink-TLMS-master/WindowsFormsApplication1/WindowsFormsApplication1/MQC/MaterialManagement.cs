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

using WindowsFormsApplication1.MQC.MQCClass;

namespace WindowsFormsApplication1.MQC
{
    public partial class MaterialManagement : CommonForm
    {
        BackgroundWorker bgWorker;
        // this timer calls bgWorker again and again after regular intervals
        System.Windows.Forms.Timer tmrCallBgWorker;
        // this is the timer to make sure that worker gets called
        System.Threading.Timer tmrEnsureWorkerGetsCalled;
        // object used for safe access
        object lockObject = new object();
        List<ItemMaterial> ListMaterial = new List<ItemMaterial>();
        public MaterialManagement()
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
            tmrCallBgWorker.Interval = 5000;
            tmrCallBgWorker.Start();
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
                if (dtgv_material.Rows.Count > 0)
                    this.WindowState = FormWindowState.Maximized;
            }
            catch (Exception ex)
            {

               SystemLog.Output(SystemLog.MSG_TYPE.Err, "LoadDataERPMQCToShow()", ex.Message);
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
                    if (item.MaterialAdapts != null)
                        show.Percent = item.MaterialAdapts.Select(d => d.Percent).Min();
                    itemMaterialShows.Add(show);
                }
                dtgv_material.Columns.Clear();
                dtgv_material.DataSource = itemMaterialShows;
                MakeUpDatagridview(dtgv_material);
            }

        }

        private void Btn_search_Click(object sender, EventArgs e)
        {

      
            CheckMaterial checkMaterial = new CheckMaterial();
           ListMaterial =     checkMaterial.ListMaterial("");
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
                    if (item.MaterialAdapts != null)
                        show.Percent = item.MaterialAdapts.Select(d => d.Percent).Min();
                    itemMaterialShows.Add(show);
                }
                dtgv_material.Columns.Clear();
                dtgv_material.DataSource = itemMaterialShows;
                MakeUpDatagridview(dtgv_material);
            }

        }
        private void MakeUpDatagridview(DataGridView gridView)
        {  
            DataGridViewImageColumn dgvImageExpand = new DataGridViewImageColumn();
            dgvImageExpand.Name = "ImageExpand";
            dgvImageExpand.Image = global::WindowsFormsApplication1.Properties.Resources.expand_icon;
            dgvImageExpand.Visible = true;
            dgvImageExpand.Width = 20;
            gridView.Columns.Insert(0,dgvImageExpand);
            gridView.DefaultCellStyle.Font = new Font("Times New Roman",12, FontStyle.Regular);
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            gridView.Columns[0].HeaderText = "";
            gridView.Columns[1].HeaderText = "Department";
            gridView.Columns[1].MinimumWidth = 100;
            gridView.Columns[2].HeaderText = "Production Order";
            gridView.Columns[2].MinimumWidth = 100;
            gridView.Columns[3].HeaderText = "Product";
            gridView.Columns[3].MinimumWidth = 100;
            gridView.Columns[4].HeaderText = "Production's Date";
            gridView.Columns[4].MinimumWidth = 100;
            gridView.Columns[5].HeaderText = "Percent (%)";
            gridView.Columns[5].MinimumWidth = 100;
            gridView.Columns[5].DefaultCellStyle.Format = "P1";
            
            gridView.BackgroundColor = Color.LightSteelBlue;
            gridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;

         
        }

        private void Dtgv_material_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            dtgv_material.Controls.Clear();
            DataGridViewImageColumn cols = (DataGridViewImageColumn)dtgv_material.Columns[0];
            if (cols.Name == "ImageExpand")
            {
                DataGridView gridViewDetail = new DataGridView();
                String Filterexpression = dtgv_material.Rows[e.RowIndex].Cells[2].Value.ToString();
                var list = ListMaterial.Where(d => d.ID == Filterexpression).ToList();

                dtgv_material.Controls.Add(gridViewDetail);
                Rectangle dgvRectangle = dtgv_material.GetCellDisplayRectangle(1, e.RowIndex, true);
                gridViewDetail.Size = new Size(dtgv_material.Width, 200);

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
                 dtgv_material.Columns[0].Name = "Close";
                tmrCallBgWorker.Stop();
                cols.Image = global::WindowsFormsApplication1.Properties.Resources.close_icon;
            }
            else if(cols.Name == "Close")
            {
                dtgv_material.Controls.Clear();
                dtgv_material.Columns[0].Name = "ImageExpand";
                cols.Image = global::WindowsFormsApplication1.Properties.Resources.expand_icon;
                tmrCallBgWorker.Start();
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            dtgv_material.Controls.Clear();
        }
    }
}
