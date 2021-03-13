using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ERPShowOrder
{
    public partial class ERPShowOrder : CommonForm
    {
        public ERPShowOrder()
        {
            InitializeComponent();
            AcceptButton = btn_search;
        }
        DataTable dt;
        DataTable dtShow;
        DataGridViewButtonColumn dtCol;
        private void btn_search_Click(object sender, EventArgs e)
        {
            getERPdata();
            dtShow = new DataTable();
            datashow();
            DataView dv = dtShow.DefaultView;
            dv.Sort = "Good_Qty_Percent ASC";
            dgv_show.DataSource = dv;
            dgv_show.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgv_show.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_show.AllowUserToAddRows = false;
            // dgv_show.DataSource = dv;
            dgv_show.AutoGenerateColumns = true;
            dgv_show.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv_show.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            MakeAlarmForWarning(dgv_show);
            addColumn(ref dgv_show);
        }

        private void MakeAlarmForWarning(DataGridView dtgv)
        {
            if (dtgv.Rows.Count > 0)
            {
                int count = 0;
                foreach (DataGridViewRow row in dtgv.Rows)
                {
                    double Good_Qty_Percent = Convert.ToDouble(row.Cells["Good_Qty_Percent"].Value);




                    if (Good_Qty_Percent >= 100)
                    {
                        dtgv["Good_Qty_Percent", count].Style.BackColor = Color.Green;//to color the row
                        dtgv["Status", count].Style.BackColor = Color.Green;


                    }
                    else if (Good_Qty_Percent >= 98 && Good_Qty_Percent < 100)
                    {
                        dtgv["Good_Qty_Percent", count].Style.BackColor = Color.GreenYellow;//to color the row
                        dtgv["Status", count].Style.BackColor = Color.GreenYellow;

                    }
                    else if (Good_Qty_Percent >= 95 && Good_Qty_Percent < 98)
                    {
                        dtgv["Good_Qty_Percent", count].Style.BackColor = Color.Orange;//to color the row
                        dtgv["Status", count].Style.BackColor = Color.Orange;

                    }
                    else if (Good_Qty_Percent >= 70 && Good_Qty_Percent < 95)
                    {
                        dtgv["Good_Qty_Percent", count].Style.BackColor = Color.Red;//to color the row
                        dtgv["Status", count].Style.BackColor = Color.Red;

                    }
                    else if (Good_Qty_Percent < 70)
                    {
                        dtgv["Good_Qty_Percent", count].Style.BackColor = Color.DarkRed;//to color the row
                        dtgv["Status", count].Style.BackColor = Color.DarkRed;

                    }
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
            sql.Append(@"
                            select
                            CONVERT(date,moctas.CREATE_DATE) as Create_Date,
                            moctas.TA026 as Code_Type,
                            moctas.TA027 as Code_No,
                            moctas.TA001 as Production_Planning_Code,
                            moctas.TA002 as Production_Planning_No,
                            moctas.TA006 as Product_Code,
                            moctas.TA034 as Product_Name,
                            moctas.TA009 as Production_Start_Date,
                            moctas.TA010 as Estimate_Complete_Date,
                            moctas.TA012 as Actual_Production_Date,
                            moctas.TA013 as Confirm,
                            moctas.TA015 as Plan_Quanity,
                            sum(moctgs.TG011) as Finished_Goods,
                            sum(moctgs.TG012) as NG_Quanity,
                            sum(moctgs.TG013) as Good_Quanity,
                            moctgs.TG007 as Unit, 
                            max(CONVERT(date,moctfs.TF003)) as Input_Date
                            from MOCTA moctas
                            left join MOCTG moctgs on moctgs.TG014 = moctas.TA001 and moctgs.TG015 = moctas.TA002
                            left join MOCTF moctfs on moctfs.TF001 = moctgs.TG001 and moctfs.TF002 = moctgs.TG002
                            where 1=1 ");
            if ((string)cmb_COPTC_TC001.Text != "")
            {
                sql.Append(" and moctas.TA026   = '" + (string)cmb_COPTC_TC001.Text + "'");
            }

            if (cmb_MOCTA_TA001.Text != "")
            {
                sql.Append(" and moctas.TA001   = '" + cmb_MOCTA_TA001.Text + "'");
            }
            if (cmb_MOCTA_TA002.Text != "")
            {
                sql.Append(" and moctas.TA002   = '" + cmb_MOCTA_TA002.Text + "'");
            }
            if ((string)cmb_COPTC_TC002.Text != "")
            {
                sql.Append(" and moctas.TA027   = '" + (string)cmb_COPTC_TC002.Text + "'");
            }
            else
            {
                sql.Append(" and CONVERT(date,moctas.CREATE_DATE) >= '" + datefrom + "'");
                sql.Append(" and CONVERT(date,moctas.CREATE_DATE) <= '" + dateto + "'");
            }

            sql.Append(@" group by 
                                    moctas.CREATE_DATE,
                                    moctas.TA001 ,
                                    moctas.TA002 ,                                   
                                    moctas.TA006,
                                    moctas.TA009 ,
                                    moctas.TA010 ,
                                    moctas.TA012 ,
                                    moctas.TA013 ,
                                    moctas.TA015,
                                    moctas.TA034,
                                    moctas.TA026 ,
                                    moctas.TA027,
                                    
                                    moctgs.TG007 ");

            sql.Append(" order by moctas.TA002");
            sqlERPCON con = new sqlERPCON();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            //checkdata
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string MaTaoDon = dt.Rows[i]["Code_Type"].ToString().Replace("'", "");
                    string codeTaoLenh = dt.Rows[i]["Code_No"].ToString().Replace("'", "");
                    string sqlcheck = "select COUNT(*) from t_OCTB where TB02 = '" + MaTaoDon + "' and TB03 ='" + codeTaoLenh + "'";
                    double FinishedGoodQty = 0;
                    double NGQty = 0;
                    double OKQty = 0;
                    double PercentofOKQty = 0;
                    try
                    {
                        FinishedGoodQty = double.Parse(dt.Rows[i]["Finished_Goods"].ToString().Replace("'", ""));
                        NGQty = double.Parse(dt.Rows[i]["NG_Quanity"].ToString().Replace("'", ""));
                        OKQty = double.Parse(dt.Rows[i]["Good_Quanity"].ToString().Replace("'", ""));
                        if (FinishedGoodQty != 0)
                            PercentofOKQty = Math.Round((OKQty / FinishedGoodQty) * 100, 2);

                    }
                    catch (Exception ex)
                    {
                        FinishedGoodQty = 0;
                        NGQty = 0;
                        OKQty = 0;
                        SystemLog.Output(SystemLog.MSG_TYPE.Err, "getERPdata()", ex.Message);
                        //MessageBox.Show(ex.Message);

                    }


                    sqlCON check = new sqlCON();
                    if (int.Parse(check.sqlExecuteScalarString(sqlcheck)) == 0) //insert
                    {
                        string list = "";
                        for (int j = 0; j < dt.Columns.Count; j++)
                        {
                            list += "'";
                            list += dt.Rows[i][j].ToString() + "',";
                        }
                        StringBuilder sqlinsert = new StringBuilder();
                        sqlinsert.Append("insert into t_OCTB ");
                        sqlinsert.Append(@"(TB01,TB02,TB03,TB04,TB05,TB06,TB07,TB08,TB09,TB10,TB11,TB12,TB13,TB14,TB15,TB16,TB17,TB31,TB32,TB33,UserName,datetimeRST) values ( ");
                        sqlinsert.Append(list);
                        if (PercentofOKQty >= 100)
                        {
                            sqlinsert.Append("'OK', '" + PercentofOKQty.ToString() + " ' , '0' " + ",");
                        }
                        else if (PercentofOKQty > 98)
                        {
                            sqlinsert.Append("'OK', '" + PercentofOKQty.ToString() + " ' , '1' " + ",");
                        }
                        else if (PercentofOKQty < 98 && PercentofOKQty > 95)
                        {
                            sqlinsert.Append("'OK', '" + PercentofOKQty.ToString() + " ' , '2' " + ",");
                        }
                        else if (PercentofOKQty < 95)
                        {
                            sqlinsert.Append("'NG', '" + PercentofOKQty.ToString() + " ' , '0' " + ",");
                        }

                        sqlinsert.Append("'" + Class.valiballecommon.GetStorage().UserName + "',GETDATE())");
                        sqlCON insert = new sqlCON();
                        insert.sqlExecuteNonQuery(sqlinsert.ToString(), false);
                    }
                    else //update
                    {
                        StringBuilder sqlupdate = new StringBuilder();
                        sqlupdate.Append("update t_OCTB set ");
                        sqlupdate.Append(@"TB13 = '" + dt.Rows[i]["Finished_Goods"].ToString() + "',");
                        sqlupdate.Append(@"TB14 = '" + dt.Rows[i]["NG_Quanity"].ToString() + "',");
                        sqlupdate.Append(@"TB15 = '" + dt.Rows[i]["Good_Quanity"].ToString() + "',");
                        sqlupdate.Append(@"TB17 = '" + dt.Rows[i]["Input_Date"].ToString() + "'");
                        if (PercentofOKQty >= 100)
                        {
                            sqlupdate.Append(@", TB31 = 'OK' ,");
                            sqlupdate.Append(@" TB32 = ' " + PercentofOKQty.ToString() + "' ,");
                            sqlupdate.Append(@"TB33 = '0' ");
                        }
                        else if (PercentofOKQty > 98)
                        {
                            sqlupdate.Append(@", TB31 = 'OK' ,");
                            sqlupdate.Append(@" TB32 = ' " + PercentofOKQty.ToString() + "' ,");
                            sqlupdate.Append(@"TB33 = '1' ");
                        }
                        else if (PercentofOKQty < 98 && PercentofOKQty > 95)
                        {
                            sqlupdate.Append(@", TB31 = 'OK' ,");
                            sqlupdate.Append(@" TB32 = ' " + PercentofOKQty.ToString() + "' ,");
                            sqlupdate.Append(@"TB33 = '2' ");

                        }
                        else if (PercentofOKQty < 95)
                        {
                            sqlupdate.Append(@", TB31 = 'NG' ,");
                            sqlupdate.Append(@" TB32 = ' " + PercentofOKQty.ToString() + "' ,");
                            sqlupdate.Append(@"TB33 = '0' ");
                        }
                        //  sqlupdate.Append("'" + Class.valiballecommon.GetStorage().UserName + "',GETDATE())");

                        sqlupdate.Append(@" where TB02 = '" + MaTaoDon + "' and TB03 ='" + codeTaoLenh + "'");

                        sqlCON update = new sqlCON();
                        update.sqlExecuteNonQuery(sqlupdate.ToString(), false);
                    }
                }
            }
        }
        void datashow()
        {
            DateTime dateto = dtp_to.Value.Date;
            DateTime datefrom = dtp_from.Value.Date;
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select CONVERT(date,TB01) as Create_Date,TB02 as Code_Type,TB03 as Code_No,TB04 as Production_Planning_Code,TB05 as Production_Planning_No,TB06 as Product_Code,");
            sql.Append("TB07 as Product_Name,TB08 as Production_Start_Date,TB09 as Estimate_Complete_Date,TB10 as Actual_Production_Date,TB11 as Confirm,TB12 as Plan_Quanity,");
            sql.Append("TB13 as Finished_Goods,TB14 as NG_Quanity,TB15 as Good_Quanity,TB16 as Unit,TB17 as Input_Date,");
            sql.Append("TB30, TB31 as Status, cast( TB32 as float) as Good_Qty_Percent, TB33 as Alarm");
            sql.Append(" from t_OCTB where 1 = 1 ");
            if ((string)cmb_COPTC_TC001.Text != "")
            {
                sql.Append(" and TB02 = '" + cmb_COPTC_TC001.Text + "'");
            }

            if (cmb_MOCTA_TA001.Text != "")
            {
                sql.Append(" and TB04   = '" + cmb_MOCTA_TA001.Text + "'");
            }
            if (cmb_MOCTA_TA002.Text != "")
            {
                sql.Append(" and TB05   = '" + cmb_MOCTA_TA002.Text + "'");
            }
            if ((string)cmb_COPTC_TC002.Text != "")
            {
                sql.Append(" and TB03  = '" + cmb_COPTC_TC002.Text + "'");
            }
            else
            {
                sql.Append(" and CONVERT(date,TB01) >= '" + datefrom + "'");
                sql.Append(" and CONVERT(date,TB01) <= '" + dateto + "'");
            }
            sql.Append(" order by TB02");
            sqlCON con = new sqlCON();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dtShow);
        }
        private void ERPShowOrder_Load(object sender, EventArgs e)
        {
            
            if (Class.valiballecommon.GetStorage().value1 != null)
            {
                Class.valiballecommon va = Class.valiballecommon.GetStorage();
                cmb_COPTC_TC002.Text = Class.valiballecommon.GetStorage().value2;
                cmb_COPTC_TC001.Text = Class.valiballecommon.GetStorage().value1;
                //  string test = Class.valiballecommon.GetStorage().value3;
                dtp_from.Value = (Class.valiballecommon.GetStorage().value3.Length > 8) ? Convert.ToDateTime(Class.valiballecommon.GetStorage().value3) : DateTime.MinValue;
                va.value3 = null;
                va.value1 = null;
                va.value2 = null;
                btn_search_Click(sender, e);
            }
            else
            {
                string sql_cmb_COPTC_TC001 = @"select distinct
moctas.TA026 as MaDDH
from MOCTA moctas
where moctas.TA026 != '' and moctas.TA027 != '' and moctas.TA013 = 'Y'";
                sqlERPCON conERP = new sqlERPCON();
                cmb_COPTC_TC001.Items.Clear();
                conERP.getComboBoxData(sql_cmb_COPTC_TC001, ref cmb_COPTC_TC001);
                if (cmb_COPTC_TC001.Items != null)
                {
                    cmb_COPTC_TC001.SelectedIndex = 0;

                }
            }
        }

        private void cmd_MOCTA_TA001_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_MOCTA_TA002.Items.Clear();
            string sql = "select distinct  TA002 from MOCTA where TA001 ='" + cmb_MOCTA_TA001.Text + "' order by TA002";
            sqlERPCON conERP = new sqlERPCON();
            conERP.getComboBoxData(sql, ref cmb_MOCTA_TA002);
        }

        private void Cmb_COPTC_TC001_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_COPTC_TC002.Items.Clear();
            string sql = "select distinct  TA027 from MOCTA where TA027 !='' and TA013 ='Y' and TA026 ='" + cmb_COPTC_TC001.Text + "' order by TA027";
            sqlERPCON conERP = new sqlERPCON();
            conERP.getComboBoxData(sql, ref cmb_COPTC_TC002);
            if (cmb_COPTC_TC002.Items != null)
            {
                cmb_COPTC_TC002.SelectedIndex = 0;
                //    datashow();

            }
        }

        private void Cmb_COPTC_TC002_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select distinct  TA001, TA002 from MOCTA where  TA013 ='Y' and  TA026 ='" + cmb_COPTC_TC001.Text + "' and  TA027 ='" + cmb_COPTC_TC002.Text + "'  order by TA001";
            sqlERPCON conERP = new sqlERPCON();
            cmb_MOCTA_TA001.Items.Clear();
            cmb_MOCTA_TA002.Items.Clear();
            conERP.getComboBoxData(sql, ref cmb_MOCTA_TA001, ref cmb_MOCTA_TA002);
            if (cmb_MOCTA_TA001.Items != null)
            {
                cmb_MOCTA_TA001.Items.Add("");
                cmb_MOCTA_TA001.SelectedIndex = 0;

            }
            if (cmb_MOCTA_TA002.Items != null)
            {
                cmb_MOCTA_TA002.Items.Add("");
                cmb_MOCTA_TA002.SelectedIndex = 0;
            }
            cmb_MOCTA_TA001.Text = "";
            cmb_MOCTA_TA002.Text = "";
        }
        void addColumn(ref DataGridView dgv)
        {
            if (dgv.Rows.Count > 0)
            {

                if (dgv.Rows[0].Cells[0].Value.ToString() != "Chart")
                {
                    dtCol = new DataGridViewButtonColumn();
                    dtCol.Name = "colChart";
                    dtCol.Text = "Chart";
                    dtCol.HeaderText = "ChartShow";
                    dtCol.UseColumnTextForButtonValue = true;
                    dgv_show.Columns.Insert(0, dtCol);
                }
            }
        }

        private void dgv_show_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int curRow = int.Parse(e.RowIndex.ToString());

            if (dgv_show.Columns[e.ColumnIndex] == dtCol && curRow >= 0)
            {
                Class.valiballecommon va = Class.valiballecommon.GetStorage();
                va.value1 = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells["Production_Planning_Code"].Value.ToString();
                va.value2 = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells["Production_Planning_No"].Value.ToString();
                va.value3 = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells["Product_Code"].Value.ToString();
                va.value4 = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells["Product_Name"].Value.ToString();
                ProductionChart chart = new ProductionChart();
                chart.ShowDialog();
            }
        }
    }
}
