using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Class;

namespace WindowsFormsApplication1.ERPShowOrder
{
    public partial class ERPShowMain : CommonForm
    {
        string PathFoler = @"C:\ERP_Temp\";
        bool IscheckDepartment = false;
        public ERPShowMain()
        {
            InitializeComponent();
            AcceptButton = btn_search;
            bool exists = System.IO.Directory.Exists(PathFoler);
            if (!exists)
                System.IO.Directory.CreateDirectory(PathFoler);
            LoadTreeviewDeptment();
            this.WindowState = FormWindowState.Maximized;

        }
        DataTable dtshow;
        DataTable dt;
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
        private string ChooseDeptoSQLcommand(TreeView treeView)
        {
            IscheckDepartment = false;
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

                        sqlquerry += " t_octcs.TC04 =  '" + node.Text.Split(':')[0] + "'";

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
        private void ERPShowMain_Load(object sender, EventArgs e)
        {
            string sql = "select distinct TC001 from COPTC where TC001 != '' order by TC001";
            sqlERPCON conERP = new sqlERPCON();
            conERP.getComboBoxData(sql, ref cmd_COPTC_TC001);
        }

        private void cmd_MOCTA_TA001_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd_COPTC_TC002.Items.Clear();
            string sql = "select distinct  TC002 from COPTC where TC001 ='" + cmd_COPTC_TC001.Text + "' order by TC002";
            sqlERPCON conERP = new sqlERPCON();
            conERP.getComboBoxData(sql, ref cmd_COPTC_TC002);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            getERPdata();
            datashow();
            if (dtshow != null && dtshow.Rows.Count >0)
            {
                DataView dv = dtshow.DefaultView;

                dv.Sort = "Shipping_Percent ASC";
                dgv_show.DataSource = dv;
                // dgv_show.DataSource = dtshow;
                dgv_show.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
                dgv_show.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                dgv_show.AutoGenerateColumns = true;
                dgv_show.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
                dgv_show.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
                dgv_show.AllowUserToAddRows = false;
                MakeAlarmForWarning(dgv_show);
            }
            else
            {
                dgv_show.DataSource = null;
            }
        }
        private void MakeAlarmForWarning(DataGridView dtgv)
        {
            if (dtgv.Rows.Count > 0)
            {
                //string ColumnsAlam = "";
                //DataGridViewColumn dtCol = new DataGridViewColumn();
                //dtCol.Name = "colAlam";
                //dtCol.HeaderText = "ColumnsAlarm";
                //dtCol.Frozen = false;
                //dtCol.CellTemplate = new DataGridViewTextBoxCell();
                //dtgv.Columns.Insert(10, dtCol);
                int count = 0;
                foreach (DataGridViewRow row in dtgv.Rows)
                {
                    double ShippingPercent = Convert.ToDouble(row.Cells["Shipping_Percent"].Value);
                    DateTime Deadline = DateTime.MinValue;
                    DateTime DeliveryDate = DateTime.MinValue;
                    object test = row.Cells["Client_Request_Date"].Value;
                    object delivery = row.Cells["Delivery_Date"].Value;
                    if (row.Cells["Client_Request_Date"].Value != null && row.Cells["Client_Request_Date"].Value.ToString().Length == 8)
                    {
                        Deadline = Convert.ToDateTime(row.Cells["Client_Request_Date"].Value.ToString().Insert(4, "-").Insert(7, "-"));

                    }
                    if (row.Cells["Delivery_Date"].Value != null && row.Cells["Delivery_Date"].Value.ToString().Length == 8)
                    {
                        DeliveryDate = Convert.ToDateTime(row.Cells["Delivery_Date"].Value.ToString().Insert(4, "-").Insert(7, "-"));
                    }

                    //  dtshow.Columns.Add("Shipping Status", typeof(string)).SetOrdinal(10);

                    if (ShippingPercent < 100 && Deadline <= DateTime.Now) //backlog
                    {
                        dtgv["Shipping_Percent", count].Style.BackColor = Color.Red;//to color the row
                        dtgv["Delivery_Date", count].Style.BackColor = Color.Red;
                        dtgv["Client_Request_Date", count].Style.BackColor = Color.Red;
                        dtgv["Production_Status", count].Value = "BackLog";
                      //  ColumnsAlam = "BACKLOG";
                        // Delivery_Date
                    }

                    else if (ShippingPercent >= 100 && DeliveryDate >= Deadline) //late
                    {
                        dtgv["Shipping_Percent", count].Style.BackColor = Color.Orange;//to color the row
                        dtgv["Delivery_Date", count].Style.BackColor = Color.Orange;
                        dtgv["Client_Request_Date", count].Style.BackColor = Color.Orange;
                        dtgv["Production_Status", count].Value = "Late";
                    }
                    else if (ShippingPercent < 70 && Deadline >= DateTime.Now.AddDays(7)) //Crisis
                    {
                        dtgv["Shipping_Percent", count].Style.BackColor = Color.Yellow;//to color the row
                        dtgv["Delivery_Date", count].Style.BackColor = Color.Yellow;
                        dtgv["Client_Request_Date", count].Style.BackColor = Color.Yellow;
                        dtgv["Production_Status", count].Value = "Crisis";
                    }
                    else
                    {
                        dtgv["Production_Status", count].Value = "Normal";
                    }
                    //dtgv["colAlam", count].Value = ColumnsAlam;
                    StringBuilder sqlupdate = new StringBuilder();
                    sqlupdate.Append("update t_OCTM set ");
                    sqlupdate.Append(@"TM12 = '" + row.Cells["Shipping_Percent"].Value.ToString() + "',"); //percent
                    sqlupdate.Append(@"TM11 = '" + dtgv["Production_Status", count].Value.ToString() + "'");
                    sqlupdate.Append(@" where TM02 = '" + row.Cells["Code_Type"].Value.ToString() + "' and TM03 ='" + row.Cells["Code_No"].Value.ToString() + "'");

                    sqlCON update = new sqlCON();
                    update.sqlExecuteNonQuery(sqlupdate.ToString(), false);
                    count++;
                }
            }
        }
        void getERPdata()
        {

            DateTime dateto = dtp_to.Value.Date;
            DateTime datefrom = dtp_from.Value.Date;
            dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select
CONVERT(date,coptcs.CREATE_DATE) as Create_Date,
coptcs.TC001 as Code_Type, 
coptcs.TC002 as Code_No,
coptcs.TC012 as Customer_No

 from COPTC coptcs
where 1=1 ");
            //if(ChooseDeptoSQLcommand(trv_department) != "")
            // {
            //     sql.Append(ChooseDeptoSQLcommand(trv_department));
            // }
            if (cmd_COPTC_TC001.Text != "")
            {
                sql.Append(" and coptcs.TC001   = '" + cmd_COPTC_TC001.Text + "'");
            }
            if (cmd_COPTC_TC002.Text != "")
            {
                sql.Append(" and coptcs.TC002   = '" + cmd_COPTC_TC002.Text + "'");
            }


            else
            {
                sql.Append(" and CONVERT(date,coptcs.CREATE_DATE)  >= '" + datefrom + "' ");
                sql.Append(" and CONVERT(date,coptcs.CREATE_DATE) <= '" + dateto + "' ");
            }
            sql.Append(@" group by 
                                   coptcs.CREATE_DATE,
                                    coptcs.TC001 ,
                                    coptcs.TC002 ,
                                   coptcs.TC012
                                    ");
            sql.Append(" order by coptcs.TC001, coptcs.TC002");
            sqlERPCON con = new sqlERPCON();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            //checkdata
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sqlcheck = "";
                    string NgayTaoDon = dt.Rows[i]["Create_Date"].ToString().Replace("'", "");
                    string MaTaoDon = dt.Rows[i]["Code_Type"].ToString().Replace("'", "");
                    string codeDon = dt.Rows[i]["Code_No"].ToString().Replace("'", "");
                    string MAHK = dt.Rows[i]["Customer_No"].ToString().Replace("'", "");
                    sqlcheck = "select COUNT(*) from t_OCTM where TM01 = '" + NgayTaoDon + "' and TM02 ='" + MaTaoDon + "' and TM03= '" + codeDon + "' and TM04 = '" + MAHK + "'";
                    sqlCON check = new sqlCON();
                    if (int.Parse(check.sqlExecuteScalarString(sqlcheck)) == 0) //insert
                    {
                        string list = "";
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            list += "'";
                            list += dt.Rows[i][j].ToString().Replace("'", "") + "',";
                        }
                        StringBuilder sqlinsert = new StringBuilder();
                        sqlinsert.Append("insert into t_OCTM ");
                        sqlinsert.Append(@"(TM01,TM02,TM03,TM04,UserName,datetimeRST) values ( ");
                        sqlinsert.Append(list);
                        sqlinsert.Append("'" + Class.valiballecommon.GetStorage().UserName + "',GETDATE())");
                        sqlCON insert = new sqlCON();
                        insert.sqlExecuteNonQuery(sqlinsert.ToString(), false);
                    }

                }

            }

        }

        void datashow()
        {
            dtshow = new DataTable();
            DateTime dateto = dtp_to.Value;
            DateTime datefrom = dtp_from.Value;
            string strChooseDeptoFilter = ChooseDeptoSQLcommand(trv_department);
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select 
CONVERT(date,t_octcs.TC01) as Create_Date, 
t_octcs.TC02 as Code_Type, 
t_octcs.TC03 as Code_No, 
t_octcs.TC05 as Clients, 
t_octcs.TC06 as  Clients_Order_Code, 
t_octcs.TC07 as Product_Code, 
t_octcs.TC08 as Product_Name, 
avg(CAST(t_octcs.TC32 as float)) as Shipping_Percent ,
max(CONVERT(date,t_octcs.TC17)) as Delivery_Date , 
max(CONVERT(date,t_octcs.TC12)) as Client_Request_Date,
t_octbs.TB13 as FinishedGoods,
t_octbs.TB14 as NGQuantity,
t_octbs.TB15 as OKQuantity,
t_octbs.TB32 as Good_product_ratio,
t_octbs.TB34 as Production_Rate,
t_octms.TM10 as Production_Status
from   t_OCTM t_octms 
left join  t_OCTC t_octcs  on t_octcs.TC02 = t_octms.TM02 and t_octcs.TC03 = t_octms.TM03 
left join  t_OCTB t_octbs  on t_octcs.TC02 = t_octbs.TB02 and t_octcs.TC03 = t_octbs.TB03 

");
            sql.Append(" where 1=1 ");
            if (cmd_COPTC_TC001.Text != "" && cmd_COPTC_TC002.Text != "")
            {
                sql.Append(" and t_octcs.TC02   = '" + cmd_COPTC_TC001.Text + "'");
                sql.Append(" and t_octcs.TC03   = '" + cmd_COPTC_TC002.Text + "'");

            }
            else
            {

                if (ChooseDeptoSQLcommand(trv_department) != "")
                {
                    sql.Append(ChooseDeptoSQLcommand(trv_department));

                }
                else
                {
                    MessageBox.Show("Please choose departments which you want to search data ! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                sql.Append(" and CONVERT(date,t_octcs.TC01)  >= '" + datefrom + "' ");
                sql.Append(" and CONVERT(date,t_octcs.TC01) <= '" + dateto + "' ");
            }
          

            
            sql.Append(@" group by t_octcs.TC01, t_octcs.TC03 , t_octcs.TC02, t_octcs.TC05, t_octcs.TC06, t_octcs.TC07, t_octcs.TC08,t_octbs.TB13,t_octbs.TB14,t_octbs.TB15,t_octbs.TB32,t_octbs.TB34,t_octms.TM10");
            sql.Append(" order by t_octcs.TC02,  t_octcs.TC03");
            sqlCON con = new sqlCON();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dtshow);

        }
        private void dgv_show_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_show.RowCount == 0)
            {
                return;
            }
            int i = e.RowIndex;
            int j = e.ColumnIndex;
            Class.valiballecommon va = Class.valiballecommon.GetStorage();
            va.value1 = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells["Code_Type"].Value.ToString();
            va.value2 = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells["Code_No"].Value.ToString();
            va.value3 = dtp_from.Value.ToString("yyyy-MM-dd");
            if (dgv_show.Rows[i].Cells["Shipping_Percent"].Selected || dgv_show.Rows[i].Cells["Delivery_Date"].Selected || dgv_show.Rows[i].Cells["Client_Request_Date"].Selected)
            {
                ERPShowShipping shipping = new ERPShowShipping();
                shipping.ShowDialog();
            }
            else if (dgv_show.Rows[i].Cells["FinishedGoods"].Selected || dgv_show.Rows[i].Cells["NGQuantity"].Selected || dgv_show.Rows[i].Cells["OKQuantity"].Selected ||
                dgv_show.Rows[i].Cells["Good_product_ratio"].Selected || dgv_show.Rows[i].Cells["Production_Rate"].Selected)
            {
                ERPShowOrder showOrder = new ERPShowOrder();
                showOrder.ShowDialog();
            }

        }

        private void ShippingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERPShowShipping shipping = new ERPShowShipping();
            shipping.ShowDialog();
        }

        private void ProductionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERPShowOrder eRPShowOrder = new ERPShowOrder();
            eRPShowOrder.ShowDialog();
        }

        private void MaterialToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ERPMaterialShow eRPMaterialShow = new ERPMaterialShow();
            eRPMaterialShow.ShowDialog();
        }

        private void Btn_toExcel_Click(object sender, EventArgs e)
        {

            ToolSupport tool = new ToolSupport();
            tool.dtgvExport2Excel(dgv_show, PathFoler + DateTime.Now.ToString("yyyyMMdd HHmmss") + ".xls");
        }
    }
}
