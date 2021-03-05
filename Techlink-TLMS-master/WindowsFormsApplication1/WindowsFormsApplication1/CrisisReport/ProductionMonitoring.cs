using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.CrisisReport.Classvalue;

namespace WindowsFormsApplication1.CrisisReport
{
    public partial class ProductionMonitoring : CommonForm
    {
        DataTable dt;
        DataTable dtProduction;
        DataTable dtDisplay;
        string MaboPhan = "";
        List<ProductionItems> ListproductionItems = new List<ProductionItems>();
        List<ProductionSummary> listSummary = new List<ProductionSummary>();
        List<ProductionItems> listSort = new List<ProductionItems>();

        public ProductionMonitoring()
        {
            InitializeComponent();
        }
        private void GetDataProduction()
        {
            DateTime dateto = dtp_to.Value;
            DateTime datefrom = dtp_from.Value;
            dtProduction = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select
b.TB001 as Ma,
b.TB002 as MaNo,
c.TC004 as LSX,
c.TC005 as LSXNo,
c.TC047 as MaSP,
c.TC048 as TenSP,
b.TB005 as bophanchuyen,
b.TB006 as tenbophanchuyen,
b.TB010 as maxuong,
CONVERT(date,b.TB015) as Ngay,
CONVERT(time,b.CREATE_TIME) as gio,
c.TC014 as SLNhiemthu,
c.TC016 as SLBaoPhe,
c.TC036 as SL,
c.TC041 as BoPhanChuyenNhap,
c.TC038 as ngayNghiemthu,
c.TC042 as SLDongGoiChuyenCD,
c.TC043 as SLDGNT,
c.TC044 as SLDGTRaLai
from SFCTB b
left join SFCTC c on b.TB001 = c.TC001 and b.TB002 = c.TC002 
where 1=1 and c.TC004 != '' and c.TC005 != '' ");
            if (ChooseDeptoSQLcommand(trv_department) != "")
            {
                sql.Append(ChooseDeptoSQLcommand(trv_department));

            }
            else
            {
                MessageBox.Show("Please choose departments which you want to search data ! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            sql.Append(" and c.TC041 = '" + cb_Product.SelectedItem.ToString() + "' ");
            sql.Append(" and CONVERT(date,b.TB015)  >= '" + datefrom + "' ");
            sql.Append(" and CONVERT(date,b.TB015) <= '" + dateto + "' ");

            sql.Append("order by b.TB015");
            sqlERPCON con = new sqlERPCON();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dtProduction);
        }
        private List<ProductionItems> ListProductionItems(DataTable dta)

        {

            List<ProductionItems> list = new List<ProductionItems>();
            listSummary = new List<ProductionSummary>();
            for (int i = 0; i < dta.Rows.Count; i++)
            {
                object item9 = dta.Rows[i][9];//Create_date
                object item10 = dta.Rows[i][10];//Create_date
                object item6 = dta.Rows[i][6];//Create_date
                object item11 = dta.Rows[i][11];//Create_date
                object item12 = dta.Rows[i][12];//Create_date

                ProductionItems items = new ProductionItems();
                items.Date = (DateTime)item9;
                items.Time = (TimeSpan)item10;
                items.Dept = (string)dta.Rows[i][14];
                items.ProductionCode = (string)dta.Rows[i][4];
                items.ActualOutput = double.Parse(dta.Rows[i][11].ToString());
                items.ActualDefectQty = double.Parse(dta.Rows[i][12].ToString());
                double[] target = new double[2];
                if (rd_Monthly.Checked)
                {
                   target = GetTargetfromDatabase("Monthly", items.ProductionCode, new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1));
                }
                else if (rd_daily.Checked)
                {
                   target = GetTargetfromDatabase("Daily", items.ProductionCode, DateTime.Now.Date);
                }
                if(target[0] == 0 && target[1]==0)
                {
                    target[0] = 1000; target[1] = 0.3;
                }
                items.OutputTarget = target[0];
                items.ScrapTargetRate = target[1];
                list.Add(items);
            }

            var groupedListItems = list
   .GroupBy(u => u.ProductionCode)
   .Select(grp => grp.ToList())
   .ToList();
            foreach (var item in groupedListItems)
            {
                ProductionSummary production = new ProductionSummary();
                var SumOutput = item.Sum(a => a.ActualOutput);
                var SumScrap = item.Sum(a => a.ActualDefectQty);
           
                production.Dept = item[0].Dept;
                production.ProductionCode = item[0].ProductionCode;
                production.OutputTarget = item[0].OutputTarget;
                production.ScrapTargetRate = item[0].ScrapTargetRate; 

                production.ActualOutput = SumOutput;
                production.ActualDefectQty = SumScrap;
                production.ScrapActualtRate = Math.Round(SumScrap / (SumOutput + SumScrap), 2);
             
                if (production.ActualOutput >= production.OutputTarget)
                    production.QuantityEvaluation = "Good";
                else if (production.ActualOutput < production.OutputTarget)
                    production.QuantityEvaluation = "Not Good";
                if (production.ScrapActualtRate < production.ScrapTargetRate)
                    production.QualityEvaluation = "Good";
                else if (production.ScrapActualtRate >= production.ScrapTargetRate)
                    production.QualityEvaluation = "Not Good";
                listSummary.Add(production);
            }


            return list;

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

                        sqlquerry += " c.TC004 =  '" + node.Text.Split(':')[0] + "'";

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
        private void SetTimetoSearch()
        {
            if (rd_yearly.Checked)
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
                DateTime firstDay = StartOfWeek(DayOfWeek.Monday);
                DateTime lastDay = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 7);
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
        public DateTime StartOfWeek(DayOfWeek startOfWeek)
        {
            int diff = (7 + (DateTime.Now.DayOfWeek - startOfWeek)) % 7;
            return DateTime.Now.AddDays(-1 * diff).Date;
        }

        private void Rd_custom_CheckedChanged(object sender, EventArgs e)
        {
            dtp_from.Enabled = rd_custom.Checked;
            dtp_to.Enabled = rd_custom.Checked;
            SetTimetoSearch();
        }

        private void ProductionMonitoring_Load(object sender, EventArgs e)
        {
            LoadTreeviewDeptment();
        }
        private void LoadTreeviewDeptment()
        {

            TreeNode trnode = new TreeNode("ALL DEPARTMENTS");
            trnode.Name = "Node_Depts";
            trv_department.Nodes.Clear();
            dt = new DataTable();
            sqlERPCON conERP = new sqlERPCON();
            conERP.sqlDataAdapterFillDatatable("select distinct TC004 from SFCTC  ", ref dt);
            TreeNode child = new TreeNode();


            foreach (DataRow row in dt.Rows)
            {
                child = new TreeNode(row[0].ToString());

                trnode.Nodes.Add(child);

            }

            trv_department.Nodes.Add(trnode);
            trv_department.NodeMouseClick += Trv_department_NodeMouseClick;
            trv_department.AfterCheck += Trv_department_AfterCheck;

            trnode.Checked = false;
        }

        private void Trv_department_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            MaboPhan = e.Node.Text;
            cb_Product.Items.Clear();
            string sql = "select distinct  TC041 from SFCTC where TC004 ='" + e.Node.Text + "' " + "  and CONVERT(date,CREATE_DATE) >  '" + DateTime.Now.AddMonths(-6) + "' " + " order by TC041 ";
            sqlERPCON conERP = new sqlERPCON();
            conERP.getComboBoxData(sql, ref cb_Product);
            if (cb_Product.Items.Count > 0)
            {
                cb_Product.SelectedIndex = 0;
            }
        }

        private void Trv_department_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked)
            {
                DiselectParentNodes(e.Node.Parent);
                DiselectChildNodes(e.Node.Nodes);
            }


            if (e.Node.Name == "Node_Depts")
            {
                foreach (TreeNode tn in e.Node.Nodes)
                {
                    tn.Checked = e.Node.Checked;
                    MaboPhan = e.Node.Text;

                }
            }

        }
        private void DiselectParentNodes(TreeNode parent)
        {
            while (parent != null)
            {
                if (parent.Checked)
                    parent.Checked = false;
                parent = parent.Parent;

            }
        }

        private void DiselectChildNodes(TreeNodeCollection childes)
        {
            foreach (TreeNode oneChild in childes)
            {
                if (oneChild.Checked)
                    oneChild.Checked = false;
                DiselectChildNodes(oneChild.Nodes);
            }
        }
        private void Btn_search_Click(object sender, EventArgs e)
        {
            GetDataProduction();
            if (dtProduction.Rows.Count > 0)
            {
                ListproductionItems = new List<ProductionItems>();
                ListproductionItems = ListProductionItems(dtProduction);
            }
            if (ListproductionItems != null && ListproductionItems.Count > 0)
            {
                dgv_show.DataSource = listSummary;
                dgv_show.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgv_show.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgv_show.AutoGenerateColumns = true;
                dgv_show.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
                dgv_show.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
                dgv_show.AllowUserToAddRows = false;
                dgv_show.Columns[0].HeaderText = "Department";
                dgv_show.Columns[1].HeaderText = "Production Code";
                dgv_show.Columns[2].HeaderText = "Target Output ";
                dgv_show.Columns[2].DefaultCellStyle.Format = "N0";             
                dgv_show.Columns[3].HeaderText = "Actual Output";
                dgv_show.Columns[3].DefaultCellStyle.Format = "N0";
                dgv_show.Columns[4].HeaderText = "Quantity Evaluation";
                dgv_show.Columns[5].HeaderText = "Actual Scrap Qty";
                dgv_show.Columns[5].DefaultCellStyle.Format = "N0";
                dgv_show.Columns[6].HeaderText = "Target Scrap(%)";
                dgv_show.Columns[6].DefaultCellStyle.Format = "0%";
                dgv_show.Columns[7].HeaderText = "Actual Scrap (%)";
                dgv_show.Columns[7].DefaultCellStyle.Format = "0%";
                dgv_show.Columns[8].HeaderText = "Quality Evaluation";
            }
      
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
            string OrderCode = dgv_show.Rows[i].Cells["ProductionCode"].Value.ToString();
            dtDisplay = new DataTable();
            if (dgv_show.Rows[i].Cells["ProductionCode"].Selected)
            {
                var dr = ListproductionItems.Where(d => d.ProductionCode == OrderCode).ToList();
                if (rd_Monthly.Checked)
                {
                    var groupedListItems = dr
    .GroupBy(u => u.Date)
    .Select(grp => grp.ToList())
    .ToList();
                    listSort = new List<ProductionItems>();
                    foreach (var item in groupedListItems)
                    {
                        ProductionItems production = new ProductionItems();
                        var SumOutput = item.Sum(a => a.ActualOutput);
                        var SumScrap = item.Sum(a => a.ActualDefectQty);
                        production.Date = item[0].Date;
                        production.Dept = item[0].Dept;
                        production.OutputTarget = item[0].OutputTarget;
                        production.ScrapTargetRate = item[0].ScrapTargetRate;
                        production.ProductionCode = item[0].ProductionCode;
                        production.ActualOutput = SumOutput;
                        production.ActualDefectQty = SumScrap;
                        production.ScrapActualtRate = Math.Round(SumScrap / (SumOutput + SumScrap), 2);

                        listSort.Add(production);

                    }
                    dtDisplay = ConvertToDataTable(listSort);
                    double[] target = new double[2];
                    target[0] = (double) listSort[0].OutputTarget;
                    target[1] = (double)listSort[0].ScrapTargetRate;
                    CrisisReport.DiplayChartDatagrid display = new CrisisReport.DiplayChartDatagrid(dtDisplay, "Monthly", target);

                    display.ShowDialog();
                }
                if (rd_daily.Checked)
                {
                    var groupedListItems = dr
   .GroupBy(u => u.Time)
   .Select(grp => grp.ToList())
   .ToList();
                    listSort = new List<ProductionItems>();
                    foreach (var item in groupedListItems)
                    {
                        ProductionItems production = new ProductionItems();
                        var SumOutput = item.Sum(a => a.ActualOutput);
                        var SumScrap = item.Sum(a => a.ActualDefectQty);
                        production.Date = item[0].Date;
                        production.Dept = item[0].Dept;
                        production.Time = item[0].Time;
                        production.OutputTarget = item[0].OutputTarget;
                        production.ScrapTargetRate = item[0].ScrapTargetRate;
                        production.ProductionCode = item[0].ProductionCode;
                        production.ActualOutput = SumOutput;
                        production.ActualDefectQty = SumScrap;
                        production.ScrapActualtRate = Math.Round(SumScrap / (SumOutput + SumScrap), 1);

                        listSort.Add(production);

                    }

                    dtDisplay = ConvertToDataTable(listSort);

                    double[] target = new double[2];
                    target[0] = (double)listSort[0].OutputTarget;
                    target[1] = (double)listSort[0].ScrapTargetRate;
                    CrisisReport.DiplayChartDatagrid display = new CrisisReport.DiplayChartDatagrid(dtDisplay, "Daily", target);

                    display.ShowDialog();
                }




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
        private double[] GetTargetfromDatabase(string targetfor, string production_code, DateTime dta)
        {

            double[] target = new double[2];
            dt = new DataTable();
            sqlCON con = new sqlCON();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select distinct output_taget,ng_taget from t_ERP_planning where 1=1 ");
            sql.Append(" and type = '" + targetfor + "' ");
            sql.Append(" and production_code = '" + production_code + "' ");
            sql.Append(" and datetime_planning >=  '" + dta + "' ");
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            if(dt.Rows.Count ==1)
            {
                target[0] = double.Parse(dt.Rows[0]["output_taget"].ToString());
                if (target[0] != 0)
                    target[1] = Math.Round(double.Parse(dt.Rows[0]["ng_taget"].ToString())/ (target[0] + double.Parse(dt.Rows[0]["ng_taget"].ToString())),2);
                
            }
            return target;
        }

    }
}

