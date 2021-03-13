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
using System.Windows.Forms.DataVisualization.Charting;
using WindowsFormsApplication1.Class;
using WindowsFormsApplication1.ERPShowOrder;
using WindowsFormsApplication1.CrisisReport;

namespace WindowsFormsApplication1
{
    public partial class ShippingReport : CommonForm
    {
        DataTable dt;
        DataTable dtShipping;
        DataTable dtDisplay;
        List<StatusSumary> ShippingSummary = new List<StatusSumary>();
        List<ShippingItems> listShipingResult = new List<ShippingItems>();
        string[] XlabelLate;
        int[] YValueLate;
        string[] XlabelBackLog;
        int[] YValueBacklog;
        string[] XlabelOpenOrder;
        int[] YValueOpenOrder;
        string[] XlabelShippedOntime;
        int[] YValueShippedOntime;
        string[] XlabelShippedLate;
        int[] YValueShippedLate;
        private string path = Environment.CurrentDirectory+ @"\Resources\ShippingForm.xls";

        public ShippingReport()
        {
            InitializeComponent();
          
        }
        private void LoadTreeviewDeptment()
        {

            TreeNode trnode = new TreeNode("ALL DEPARTMENTS");
            trnode.Name = "Node_Depts";
            trv_department.Nodes.Clear();
            dt = new DataTable();
            sqlERPCON conERP = new sqlERPCON();
            conERP.sqlDataAdapterFillDatatable("select distinct b.TC005,a.ME002 from CMSME a inner join COPTC b on a.ME001 = b.TC005 order by b.TC005 ", ref dt);
            TreeNode child = new TreeNode();

            foreach (DataRow row in dt.Rows)
            {
                child = new TreeNode(row[0].ToString() + ": " + row[1].ToString());
                trnode.Nodes.Add(child);

            }

            trv_department.Nodes.Add(trnode);

            trv_department.AfterCheck += Trv_department_AfterCheck;
            trnode.Checked = true;
        }

        private void Trv_department_AfterCheck(object sender, TreeViewEventArgs e)
        {

            if (e.Node.Name == "Node_Depts")
            {
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    tn.Checked = e.Node.Checked;

                }
            }

        }
        private void GetDataShipping()
        {
            DateTime dateto = dtp_to.Value;
            DateTime datefrom = dtp_from.Value;
            dtShipping = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select
CONVERT(date,coptcs.CREATE_DATE) as Create_Date, 
coptcs.TC001 as Code_Type, 
coptcs.TC002 as Code_No,
cmsmes.ME002 as Department_code,
copmas.MA002 as Clients_Name,
coptcs.TC012 as Clients_Order_Code,
coptds.TD004 as Product_Code,
coptds.TD005 as Product_Name,
coptds.TD010 as Unit,
coptcs.TC005 as Department,
coptds.TD013 as Client_Request_Date,
max(coptgs.TG003) as Delivery_Date,
sum(coptds.TD008) as Order_Quantity,
sum(coptds.TD009) as SLDaGiao,
sum(copths.TH008) as Delivery_Quantity,
invmbs.MB064 as Stock_Qty,
coptds.TD016 as StatusOFCode
 from COPTC coptcs
left join COPTD  coptds on coptcs.TC002 = coptds.TD002  and coptcs.TC001 = coptds.TD001 -- cong doan tao don
left join MOCTB  moctbs on coptcs.TC002 = moctbs.TB002  and coptcs.TC001 = moctbs.TB001
inner join COPMA copmas on copmas.MA001 = coptcs.TC004
left join COPTH copths on coptcs.TC002 = copths.TH015 and  coptcs.TC001 = copths.TH014 and copths.TH004 =coptds.TD004
left join COPTG coptgs on copths.TH002  = coptgs.TG002 and copths.TH001  = coptgs.TG001 --cong doan giao hang
--left join COPTJ coptjs on coptcs.TC002 = coptjs.TJ019 and coptcs.TC001 = coptjs.TJ018-- cong doan tra hang
--left join COPTI coptis on coptjs.TJ002 = coptis.TI002 and coptjs.TJ001 = coptis.TI001 --cong doan tra hang
left join INVMB invmbs on invmbs.MB001 = coptds.TD004
left join CMSME cmsmes on cmsmes.ME001 = coptcs.TC005
where 1=1  
and  coptcs.TC027 = 'Y' 
and coptgs.TG023 ='Y'
");
            if (ChooseDeptoSQLcommand(trv_department) != "")
            {
                sql.Append(ChooseDeptoSQLcommand(trv_department));

            }
            else
            {
                MessageBox.Show("Please choose departments which you want to search data ! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            sql.Append(" and CONVERT(date,coptds.TD013)  >= '" + datefrom + "' ");
            sql.Append(" and CONVERT(date,coptds.TD013) <= '" + dateto + "' ");

            sql.Append(@"group by 
                                    coptcs.CREATE_DATE,
                                    coptcs.TC001 ,
                                    coptcs.TC002 ,
                                    cmsmes.ME002 ,
                                    copmas.MA002, 
                                    coptcs.TC012,
                                    coptds.TD004,
									 coptds.TD005,
                                    coptds.TD010,
                                    coptcs.TC005,
                                    coptds.TD013,
                                    invmbs.MB064,
									coptds.TD016

                                    ");
            sql.Append("order by coptcs.TC001, coptcs.TC002");
            sqlERPCON con = new sqlERPCON();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dtShipping);
        }
        private string ChooseDeptoSQLcommand(TreeView treeView)
        {

            string sqlquerry = "";
            var treeviewNodes = treeView.Nodes["Node_Depts"];
            if (treeviewNodes.GetNodeCount(false) > 0)
            {
                int count = 0;
                int countNodeCheck = 0;
                foreach (TreeNode node in treeviewNodes.Nodes)
                {
                    if (countNodeCheck == 0 && node.Checked == true)
                    {
                        sqlquerry += "and ( ";
                    }
                    else if (countNodeCheck > 0 && node.Checked == true)
                    {
                        sqlquerry += " or ";
                    }
                    if (node.Checked == true)
                    {

                        sqlquerry += " coptcs.TC005 =  '" + node.Text.Split(':')[0] + "'";

                        countNodeCheck++;
                    }
                    if ((count == treeviewNodes.Nodes.Count - 1) && countNodeCheck > 0)
                    {
                        sqlquerry += " ) ";
                    }

                    count++;
                }

            }
            return sqlquerry;
        }
        private void ShippingReport_Load(object sender, EventArgs e)
        {
            LoadTreeviewDeptment();

        }
      
     

      

        private void SetTimetoSearch()
        {
            if(rd_yearly.Checked)
            {
                DateTime firstDay = new DateTime(DateTime.Now.Year, 1, 1);
                DateTime lastDay = new DateTime(DateTime.Now.Year, 12, 31);
                dtp_from.Value = firstDay;
                dtp_to.Value = lastDay;
            }
            else if (rd_Monthly.Checked)
            {
                DateTime firstDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                DateTime lastDay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month));
                dtp_from.Value = firstDay;
                dtp_to.Value = lastDay;
            }
            else if (rd_weekly.Checked)
            {
                DateTime firstDay =StartOfWeek(DayOfWeek.Monday);
                DateTime lastDay = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek+7);
                dtp_from.Value = firstDay;
                dtp_to.Value = lastDay;
            }
            else if (rd_daily.Checked)
            {
                DateTime firstDay = DateTime.Now.Date;
                DateTime lastDay = DateTime.Now.AddDays(1).Date;
                dtp_from.Value = firstDay;
                dtp_to.Value = lastDay;
            }
          

        }
        public  DateTime StartOfWeek( DayOfWeek startOfWeek)
        {
            int diff = (7 + (DateTime.Now.DayOfWeek - startOfWeek)) % 7;
            return DateTime.Now.AddDays(-1 * diff).Date;
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            try
            {

           
               SetTimetoSearch();
                DoJobForReliability();
                DrawingChartForShipping(ShippingSummary);
                DrawingChartPercentShipping(ShippingSummary);
            //    if (listShipingResult != null && listShipingResult.Count > 0)
            //{
            //    dgv_show.DataSource = listShipingResult;
            //    dgv_show.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            //    dgv_show.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            //    dgv_show.AutoGenerateColumns = true;
            //    dgv_show.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            //    dgv_show.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            //    dgv_show.AllowUserToAddRows = false;
            //    dgv_show.Columns[0].HeaderText = "Date";
            //    dgv_show.Columns[1].HeaderText = "Order Code";
            //    dgv_show.Columns[2].HeaderText = "Clients";
            //    dgv_show.Columns[3].HeaderText = "Clients Order";
            //    dgv_show.Columns[4].HeaderText = "Product";
            //    dgv_show.Columns[5].HeaderText = "Order Qty";
            //    dgv_show.Columns[6].HeaderText = "Finished Goods Qty";
            //    dgv_show.Columns[7].HeaderText = "Clients Request Date";
            //    dgv_show.Columns[8].HeaderText = "Delivery Date";
            //    dgv_show.Columns[9].HeaderText = "Shipping Percernt";
            //    dgv_show.Columns[10].HeaderText = "Status";
            ////    MakeColorForDatagridview(dgv_show);
            //    DrawingChartForShipping(ShippingSummary);
            //    DrawingChartPercentShipping(ShippingSummary);
            //}
            //else
            //{
            //    dgv_show.DataSource = null;
            //}
            ClearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

                
            }
        }
        private void DoJobForReliability()
        {
            ReliabilitySummary reliability = new ReliabilitySummary();
            List<FinalItemsReport> List = reliability.GetDataBackLogToExport(dtp_from.Value, dtp_to.Value);
            List<FinalItemsReport> ListSort = List.Where(d => d.Status == "Back Log" || d.Status == "Late" || d.Status == "Open Order").ToList();
            var ListItems = ListSort
      .GroupBy(u => u.Status)
      .Select(grp => grp.ToList())
      .ToList();
            ShippingSummary = new List<StatusSumary>();
            foreach (var item in ListItems)
            {
                StatusSumary st = new StatusSumary();
                st.Status = item[0].Status;
                st.Quantity = item.Count;
                ShippingSummary.Add(st);
            }
           
            var ListItems2 = ListSort
.OrderBy(o => o.ClientsRequestDate)
.GroupBy(u => u.ClientsRequestDate.Month)
.Select(grp => grp.ToList())
.ToList();


            List<StatusSumary> ShippingSummary2 = new List<StatusSumary>();

            foreach (var item in ListItems2)
            {
                var ListItems3 = item
.GroupBy(u => new { u.Status })
.Select(grp => grp.ToList())
.ToList();
                foreach (var item2 in ListItems3)
                {
                    StatusSumary st = new StatusSumary();
                    st.Status = item2[0].Status;
                    st.Quantity = item2.Count;
                    st.ClientsRequestDate = item2[0].ClientsRequestDate.ToString("MMM");
                    ShippingSummary2.Add(st);
                }
            }
            var ListItems4 = ShippingSummary2
.GroupBy(u => u.Status)
.Select(grp => grp.ToList())
.ToList();

            for (int i = 0; i < ListItems4.Count; i++)
            {
                if (ListItems4[i][0].Status == "Late")
                {
                    XlabelLate = ListItems4[i].Select(d => d.ClientsRequestDate).ToArray();
                    YValueLate = ListItems4[i].Select(d => d.Quantity).ToArray();
                }
                if (ListItems4[i][0].Status == "Back Log")
                {
                    XlabelBackLog = ListItems4[i].Select(d => d.ClientsRequestDate).ToArray();
                    YValueBacklog = ListItems4[i].Select(d => d.Quantity).ToArray();
                }
                if (ListItems4[i][0].Status == "Open Order")
                {
                    XlabelOpenOrder = ListItems4[i].Select(d => d.ClientsRequestDate).ToArray();
                    YValueOpenOrder = ListItems4[i].Select(d => d.Quantity).ToArray();
                }
                if (ListItems4[i][0].Status == "Shipped-Late")
                {
                    XlabelShippedLate = ListItems4[i].Select(d => d.ClientsRequestDate).ToArray();
                    YValueShippedLate = ListItems4[i].Select(d => d.Quantity).ToArray();
                }
                if (ListItems4[i][0].Status == "Shipped-On Time")
                {
                    XlabelShippedOntime = ListItems4[i].Select(d => d.ClientsRequestDate).ToArray();
                    YValueShippedOntime = ListItems4[i].Select(d => d.Quantity).ToArray();
                }

            }
            string tiltle = "Reliability On-time Shipment Report " + "from: " + dtp_from.Value.ToString("dd - MM - yyyy") + " to: " + dtp_to.Value.ToString("dd - MM - yyyy");

            string tiltle2 = "Back Log Report " + "from: " + dtp_from.Value.ToString("dd - MM - yyyy") + " to: " + dtp_to.Value.ToString("dd - MM - yyyy");

            ChartDrawing.ChartDrawing.DrawCrisisReport(XlabelLate, YValueLate, XlabelBackLog, YValueBacklog, XlabelOpenOrder, YValueOpenOrder, ref chart_Shipping, tiltle2);
           // ChartDrawing.ChartDrawing.DrawCrisisReportShipped(XlabelShippedLate, YValueShippedLate, XlabelShippedOntime, YValueShippedOntime, ref chart_shipped, tiltle);
        }
        private void MakeColorForDatagridview(DataGridView dtgv)
        {
            if (dtgv.Rows.Count > 0)
            {
                int count = 0;
                foreach (DataGridViewRow row in dtgv.Rows)
                {
                 
                    if (dtgv["Status", count].Value.ToString() == "Late") //backlog
                    {
                        dtgv["Status", count].Style.BackColor = Color.Red;//to color the row

                    }
                    else if (dtgv["Status", count].Value.ToString() == "Back Log") //backlog
                    {
                        dtgv["Status", count].Style.BackColor = Color.Yellow;//to color the row

                    }
                    else if (dtgv["Status", count].Value.ToString() == "Open Order") //backlog
                    {
                        dtgv["Status", count].Style.BackColor = Color.Green;//to color the row

                    }
                    
                    count++;
                }
            }

        }
        private void DrawingChartForShipping(List<StatusSumary> list)
        {
            this.chart_Quantity.Series.Clear();
            this.chart_Quantity.Titles.Clear();
            Title title = new Title();
            title.Font = new Font("Arial", 12, FontStyle.Bold);
           
            title.Text = "Reliability Shipment Summary Report" + '\n'+ "From: " + dtp_from.Value.ToString("dd - MM - yyyy") + " To: " + dtp_to.Value.ToString("dd - MM - yyyy");
          
            this.chart_Quantity.Titles.Add(title);
            
            Series series = this.chart_Quantity.Series.Add("Shipping Status");
            series.ChartType = SeriesChartType.Column;
            series.AxisLabel = "Shipping Status";
            series.IsValueShownAsLabel = true;
            series.IsVisibleInLegend = false;
            chart_Quantity.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chart_Quantity.ChartAreas[0].AxisX.MinorGrid.Enabled = false;
            chart_Quantity.ChartAreas[0].AxisX.LabelStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            double Max= list.Max(a => a.Quantity)*1.2;
            chart_Quantity.ChartAreas[0].AxisX.Title = "Status";

            chart_Quantity.ChartAreas[0].AxisX.TitleForeColor = Color.Blue;
            chart_Quantity.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.Blue;
            chart_Quantity.ChartAreas[0].AxisY.Maximum = Max + 1;
            chart_Quantity.ChartAreas[0].AxisY.Title = "Quantity (pcs)";
            chart_Quantity.ChartAreas[0].AxisY.TitleForeColor = Color.Blue;
            chart_Quantity.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.Blue;
            chart_Quantity.ChartAreas[0].AxisY.LabelStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            chart_Quantity.ChartAreas[0].AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            //chart_shipping.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            //chart_shipping.ChartAreas[0].AxisY.MinorGrid.Enabled = false;
            foreach (var item in list)
            {
          
                series.Points.AddXY(item.Status, item.Quantity);

                 if (item.Status == "Late")
                {
                    series.Points[series.Points.Count - 1].Color = System.Drawing.Color.Red;
                }
                else if (item.Status == "Back Log")
                {
                    series.Points[series.Points.Count - 1].Color = System.Drawing.Color.Yellow;
                }
                else if (item.Status == "Open Order")
                {
                    series.Points[series.Points.Count - 1].Color = System.Drawing.Color.Blue;
                }
                //else if (item.Status == "Shipped-Late")
                //{
                //    series.Points[series.Points.Count - 1].Color = System.Drawing.Color.Orange;
                //}
                //else if (item.Status == "Shipped-On Time")
                //{
                //    series.Points[series.Points.Count - 1].Color = System.Drawing.Color.Green;
                //}

            }
             
        }
        private void DrawingChartPercentShipping(List<StatusSumary> list)
        {
            this.Chart_Percent.Series.Clear();
            this.Chart_Percent.Titles.Clear();
            Title title = new Title();
            title.Font = new Font("Arial", 12, FontStyle.Bold);

            title.Text = "Reliability Shipment Summary (%)" + '\n' + "From: " + dtp_from.Value.ToString("dd-MM-yyyy") + " To: " + dtp_to.Value.ToString("dd-MM-yyyy");
            this.Chart_Percent.Titles.Add(title);
            double Total = list.Sum(a => a.Quantity);
            Series series2 = this.Chart_Percent.Series.Add("Shipping Rate Analysis");
            series2.ChartType = SeriesChartType.Pie;
            // Chart_PercentShipping.Series[.ChartType = SeriesChartType.Pie;
            series2.LabelFormat = "0' %'";
           
            series2.IsValueShownAsLabel = true;
             series2.IsVisibleInLegend = true;
            this.Chart_Percent.ChartAreas[0].Area3DStyle.Enable3D = true;
            Chart_Percent.Legends[0].Enabled = true;
            double test = 0;
            foreach (var item in list)
            {


                if (item.Status == list[list.Count - 1].Status)
                    series2.Points.AddXY(item.Status, 100 - test);
                else
                {
                    series2.Points.AddXY(item.Status, Math.Round((double)(item.Quantity * 100 / Total), 0));
                    test += Math.Round(((double)item.Quantity * 100 / Total), 0);
                }

                if (item.Status == "Late")
                {
                    series2.Points[series2.Points.Count - 1].Color = System.Drawing.Color.Red;
                }
                else if (item.Status == "Back Log")
                {
                    series2.Points[series2.Points.Count - 1].Color = System.Drawing.Color.Yellow;
                }
                else if (item.Status == "Open Order")
                {
                    series2.Points[series2.Points.Count - 1].Color = System.Drawing.Color.Blue;
                }
                else if (item.Status == "Shipped-Late")
                {
                    series2.Points[series2.Points.Count - 1].Color = System.Drawing.Color.Orange;
                }
                else if (item.Status == "Shipped-On Time")
                {
                    series2.Points[series2.Points.Count - 1].Color = System.Drawing.Color.Green;
                }


            }

        }

        private void Chart_shipping_Click(object sender, EventArgs e)
        {
         

        }

        private void Rd_custom_CheckedChanged(object sender, EventArgs e)
        {
            dtp_from.Enabled= rd_custom.Checked;
            dtp_to.Enabled = rd_custom.Checked;
            SetTimetoSearch();
        }

        private void Rd_yearly_CheckedChanged(object sender, EventArgs e)
        {
            SetTimetoSearch(); 
        }

        private void Rd_Monthly_CheckedChanged(object sender, EventArgs e)
        {
            SetTimetoSearch(); 
        }

        private void Rd_weekly_CheckedChanged(object sender, EventArgs e)
        {
            SetTimetoSearch();
        }

        private void Rd_daily_CheckedChanged(object sender, EventArgs e)
        {
            SetTimetoSearch();
        }

        private void Dgv_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Dgv_show_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_show.RowCount == 0)
            {
                return;
            }
            int i = e.RowIndex;
            int j = e.ColumnIndex;
            string[] OrderCode = dgv_show.Rows[i].Cells["OrderCode"].Value.ToString().Split('-');
            if (OrderCode.Count() != 2)
                return;

            dtDisplay = new DataTable();
            if (dgv_show.Rows[i].Cells["Status"].Selected || dgv_show.Rows[i].Cells["OrderCode"].Selected )
            {
                DataRow[] dr = dtShipping.Select(string.Format("Code_No ='{0}' ", OrderCode[1])+ " and Code_Type = '" + OrderCode[0]+"'");
                dtDisplay = dr.CopyToDataTable();
            
                CrisisReport.DisplayDetail display = new CrisisReport.DisplayDetail(dtDisplay);

                display.ShowDialog();
            }
           
        }

        private void Chart_shipping_MouseClick(object sender, MouseEventArgs e)
        {
            HitTestResult hit = chart_shipped.HitTest(e.X, e.Y, ChartElementType.DataPoint);

            if (hit.PointIndex >= 0 && hit.Series != null)
            {
                DataPoint dp = chart_shipped.Series[0].Points[hit.PointIndex];
                string label = dp.AxisLabel;
                var dr = listShipingResult.Where( d => d.Status == label).ToList();
                dtDisplay = ConvertToDataTable(dr);
                CrisisReport.DisplayDetail display = new CrisisReport.DisplayDetail(dtDisplay);
                display.ShowDialog();
            }
           

        }
        public DataTable ConvertToDataTable<T>(IList<T> data)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable();
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }
            return table;

        }

      

        private void Btn_toExcel_Click(object sender, EventArgs e)
        {
          
            if (File.Exists(path) != true)
            {
                MessageBox.Show("File  Export Excel Template don't exists ");
                return;
            }
            string pathsave = "";
            try
            {
                System.Windows.Forms.SaveFileDialog saveFileDialog = new SaveFileDialog();

                saveFileDialog.Title = "Browse Excel Files";
                saveFileDialog.DefaultExt = "Excel";
                saveFileDialog.Filter = "Excel files (*.xls)|*.xls";

            //   saveFileDialog.CheckPathExists = true;

                if (saveFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    pathsave = saveFileDialog.FileName.Split('.')[0];

                    saveFileDialog.RestoreDirectory = true;
                    ToolSupport tool = new ToolSupport();
                    string strUser = Class.valiballecommon.GetStorage().UserName;
                    string strVersion = Class.valiballecommon.GetStorage()._version;
                   //  tool.dtgvExport2Excel(dgv_show, pathsave + "-" + DateTime.Now.ToString("yyyyMMdd HHmmss") + ".xls");
                    tool.editexcelshipping(DateTime.Now.ToString("yyyy-MM-dd"), strUser, strVersion, DateTime.Now.ToString("yyyy"), dgv_show, pathsave + "-" + DateTime.Now.ToString("yyyyMMdd HHmmss") + ".xls", path);
                }
            }
            catch (Exception ex)
            {

                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        private void Chart_Quantity_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            HitTestResult hit = chart_Quantity.HitTest(e.X, e.Y, ChartElementType.DataPoint);

            if (hit.PointIndex >= 0 && hit.Series != null)
            {
                DataPoint dp = chart_Quantity.Series[0].Points[hit.PointIndex];
                string label = dp.AxisLabel;
                var dr = listShipingResult.Where(d => d.Status == label).ToList();
                dtDisplay = ConvertToDataTable(dr);
                CrisisReport.DisplayDetail display = new CrisisReport.DisplayDetail(dtDisplay);
                display.ShowDialog();
            }
        }

        private void Chart_Percent_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {

           
            HitTestResult hit = Chart_Percent.HitTest(e.X, e.Y, ChartElementType.DataPoint);

            if (hit.PointIndex >= 0 && hit.Series != null)
            {
                DataPoint dp = Chart_Percent.Series[0].Points[hit.PointIndex];
                string label = dp.AxisLabel;
                var dr = listShipingResult.Where(d => d.Status == label).ToList();
                dtDisplay = ConvertToDataTable(dr);
                CrisisReport.DisplayDetail display = new CrisisReport.DisplayDetail(dtDisplay);
                display.ShowDialog();
            }
            }
            catch (Exception)
            {

               
            }
        }

        private void Chart_shipping_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {

        
            HitTestResult hit = chart_shipped.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            Series s = null; string strseri = "";
            if (hit != null) s = hit.Series;
            if (s != null)
            {
                strseri = s.LegendText != "" ? s.LegendText : s.Name;
            }
            if (hit.PointIndex >= 0 && hit.Series != null&& hit.PointIndex < chart_shipped.Series[0].Points.Count())
            {
                DataPoint dp = chart_shipped.Series[0].Points[hit.PointIndex];
                string label = dp.AxisLabel;
                string Label2 = dp.LegendText;
                var dr = listShipingResult.Where(d => d.ClientsRequestDate.ToString("MMM")== label && d.Status==strseri).ToList();
                dtDisplay = ConvertToDataTable(dr);
                CrisisReport.DisplayDetail display = new CrisisReport.DisplayDetail(dtDisplay);
                display.ShowDialog();
            }
            }
            catch (Exception)
            {

               
            }
        }
        private void ClearData()
        {
            XlabelLate = new string[1];
            YValueLate =new int[1];
            XlabelBackLog = new string[1]; 
            YValueBacklog = new int[1]; 
            XlabelOpenOrder = new string[1]; 
            YValueOpenOrder = new int[1];
            XlabelShippedLate = new string[1];
            YValueShippedLate = new int[1];
            XlabelShippedOntime = new string[1];
            YValueShippedOntime = new int[1];
            ShippingSummary = new List<StatusSumary>();
        }

        private void Chart_Shipping_MouseDoubleClick_1(object sender, MouseEventArgs e)
        {
            try
            {

            
            HitTestResult hit = chart_Shipping.HitTest(e.X, e.Y, ChartElementType.DataPoint);
            Series s = null; string strseri = "";
            if (hit != null) s = hit.Series;
            if (s != null)
            {
                strseri = s.LegendText != "" ? s.LegendText : s.Name;
            }
            if (hit.PointIndex >= 0 && hit.Series != null&& hit.PointIndex < chart_shipped.Series[0].Points.Count())
            {
                DataPoint dp = chart_shipped.Series[0].Points[hit.PointIndex];
                string label = dp.AxisLabel;
                string Label2 = dp.LegendText;
                var dr = listShipingResult.Where(d => d.ClientsRequestDate.ToString("MMM") == label && d.Status == strseri).ToList();
                dtDisplay = ConvertToDataTable(dr);
                CrisisReport.DisplayDetail display = new CrisisReport.DisplayDetail(dtDisplay);
                display.ShowDialog();
            }
            }
            catch (Exception)
            {
                
               
            }
        }
    }
}
