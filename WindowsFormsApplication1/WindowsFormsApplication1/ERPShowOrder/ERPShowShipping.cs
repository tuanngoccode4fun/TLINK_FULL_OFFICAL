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
    public partial class ERPShowShipping : CommonForm
    {
        public ERPShowShipping()
        {
            InitializeComponent();
        }

        DataTable dt;
        private void cmd_COPTC_TC001_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select distinct  TC002 from COPTC where TC001 ='" + cmd_COPTC_TC001.Text + "' order by TC002";
            sqlERPCON conERP = new sqlERPCON();
            conERP.getComboBoxData(sql, ref cmd_COPTC_TC002);
        }

        private void ERPShowShipping_Load(object sender, EventArgs e)
        {
            string sql = "select distinct TC001 from COPTC where TC001 != '' order by TC001";
            sqlERPCON conERP = new sqlERPCON();
            conERP.getComboBoxData(sql, ref cmd_COPTC_TC001);
            if (Class.valiballecommon.GetStorage().value1 != null)
            {
                Class.valiballecommon va = Class.valiballecommon.GetStorage();
                cmd_COPTC_TC002.Text = Class.valiballecommon.GetStorage().value2;
                cmd_COPTC_TC001.Text = Class.valiballecommon.GetStorage().value1;
                //  string test = Class.valiballecommon.GetStorage().value3;
                dtp_from.Value = (Class.valiballecommon.GetStorage().value3.Length > 8) ? Convert.ToDateTime(Class.valiballecommon.GetStorage().value3) : DateTime.MinValue;
                va.value3 = null;
                va.value1 = null;
                va.value2 = null;
                btn_search_Click(sender, e);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            getERPdata();
            // dtShow = new DataTable();
            //datashow();
            DataView dv = dt.DefaultView;
            dv.Sort = "Shipping_Percent ASC";
            dgv_show.DataSource = dv;
            //  alrma();
            dgv_show.AutoGenerateColumns = true;
            dgv_show.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv_show.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dgv_show.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgv_show.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_show.AllowUserToAddRows = false;
            MakeAlarmForWarning(dgv_show);
        }
        private void MakeAlarmForWarning(DataGridView dtgv)
        {
            if (dtgv.Rows.Count > 0)
            {
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



                    if (ShippingPercent < 100 && Deadline <= DateTime.Now)
                    {
                        dtgv["Shipping_Percent", count].Style.BackColor = Color.Red;//to color the row
                        dtgv["Client_Request_Date", count].Style.BackColor = Color.Red;


                    }
                    else if (ShippingPercent < 100 && Deadline <= DeliveryDate)
                    {
                        dtgv["Shipping_Percent", count].Style.BackColor = Color.DarkRed;//to color the row
                        dtgv["Client_Request_Date", count].Style.BackColor = Color.DarkRed;

                    }
                    else if (ShippingPercent >= 100 && DeliveryDate <= Deadline)
                    {
                        dtgv["Shipping_Percent", count].Style.BackColor = Color.Green;//to color the row
                        dtgv["Client_Request_Date", count].Style.BackColor = Color.Green;
                    }
                    else if (ShippingPercent >= 100 && DeliveryDate >= Deadline)
                    {
                        dtgv["Delivery_Date", count].Style.BackColor = Color.LightCyan;//to color the row
                        dtgv["Client_Request_Date", count].Style.BackColor = Color.LightCyan;
                    }
                    else if (ShippingPercent < 90 && Deadline >= DateTime.Now.AddDays(7))
                    {
                        dtgv["Shipping_Percent", count].Style.BackColor = Color.Orange;//to color the row
                        dtgv["Client_Request_Date", count].Style.BackColor = Color.Orange;
                    }

                    count++;
                }



            }
        }
        void getERPdata()
        {
            DateTime dateto = dtp_to.Value;
            DateTime datefrom = dtp_from.Value;
            dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select
CONVERT(date,coptcs.CREATE_DATE) as Create_Date,
coptcs.TC001 as Code_Type, 
coptcs.TC002 as Code_No,
coptcs.TC005 as Department_code,
copmas.MA002 as Clients_Name,
coptcs.TC012 as Clients_Order_Code, 
coptds.TD004 as Product_Code,
coptds.TD005 as Product_Name,
coptds.TD008 as Order_Quanity,
coptds.TD010 as Unit,
coptcs.TC005 as Department,
coptds.TD047 as Client_Request_Date,
sum(copths.TH008) as Quanity_Delivery,
copths.TH004 as Product_Delivery,
copths.TH001 as Delivery_Code,
copths.TH005 as Name_Product_Delivery,
max(coptgs.TG003) as Delivery_Date,
coptjs.TJ008 as Quanity_Return,
coptis.TI003 as Return_Date,
 (sum(copths.TH008)/coptds.TD008)*100 as Shipping_Percent
 from COPTC coptcs
left join COPTD  coptds on coptcs.TC002 = coptds.TD002  and coptcs.TC001 = coptds.TD001 -- cong doan tao don
left join MOCTB  moctbs on coptcs.TC002 = moctbs.TB002  and coptcs.TC001 = moctbs.TB001
inner join COPMA copmas on copmas.MA001 = coptcs.TC004
left join COPTH copths on coptcs.TC002 = copths.TH015 and  coptcs.TC001 = copths.TH014--cong doan giao hang
left join COPTG coptgs on copths.TH002  = coptgs.TG002 and copths.TH001  = coptgs.TG001 --cong doan giao hang
left join COPTJ coptjs on coptcs.TC002 = coptjs.TJ019 and coptcs.TC001 = coptjs.TJ018-- cong doan tra hang
left join COPTI coptis on coptjs.TJ002 = coptis.TI002 and coptjs.TJ001 = coptis.TI001 --cong doan tra hang
where 1=1  
and copths.TH004  = coptds.TD004 ");
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
            sql.Append(@"group by 
                                   coptcs.CREATE_DATE,
                                    coptcs.TC001 ,
                                    coptcs.TC002 ,
                                    coptcs.TC005 ,
                                    copmas.MA002, 
                                   coptcs.TC012,
                                    coptds.TD004,
                                    coptds.TD005,
                                   coptds.TD008,
                                    coptds.TD010,
                                    coptcs.TC005,
                                    coptds.TD047,
                                    copths.TH004,
                                    copths.TH001,
                                    copths.TH005,
                                  --  coptgs.TG003,
                                    coptjs.TJ008,
                                    coptis.TI003
                                    ");
            sql.Append("order by coptcs.TC001, coptcs.TC002");
            sqlERPCON con = new sqlERPCON();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            //checkdata
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string sqlcheck = "";

                    string MaTaoDon = dt.Rows[i]["Code_Type"].ToString().Replace("'", "");
                    string codeDon = dt.Rows[i]["Code_No"].ToString().Replace("'", "");
                    string codeSanPham = dt.Rows[i]["Product_Code"].ToString().Replace("'", "");
                    string ShippingPercent = dt.Rows[i]["Shipping_Percent"].ToString().Replace("'", "");

                    sqlcheck = "select COUNT(*) from t_OCTC where TC02 = '" + MaTaoDon + "' and TC03 ='" + codeDon + "' and TC06='" + codeSanPham + "'";
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
                        sqlinsert.Append("insert into t_OCTC ");
                        sqlinsert.Append(@"(TC01,TC02,TC03,TC04,TC05,TC06,TC07,TC08,TC09,TC10,TC11,TC12,TC13,TC14,TC15,TC16,TC17,TC18,TC19,TC32,TC31,UserName,datetimeRST) values ( ");
                        sqlinsert.Append(list);
                        if (ShippingPercent != "")
                        {
                            if (double.Parse(ShippingPercent) >= 100)
                                sqlinsert.Append("'OK',");
                            else
                            {
                                sqlinsert.Append("'WAITING',");
                            }
                        }
                        else { sqlinsert.Append("'WAITING',"); }
                        sqlinsert.Append("'" + Class.valiballecommon.GetStorage().UserName + "',GETDATE())");
                        sqlCON insert = new sqlCON();
                        insert.sqlExecuteNonQuery(sqlinsert.ToString(), false);
                    }
                    else //update
                    {

                        StringBuilder sqlupdate = new StringBuilder();
                        sqlupdate.Append("update t_OCTC set ");
                        sqlupdate.Append(@"TC13 = '" + dt.Rows[i]["Quanity_Delivery"].ToString().Replace("'", "") + "',");
                        sqlupdate.Append(@"TC17 = '" + dt.Rows[i]["Delivery_Date"].ToString().Replace("'", "") + "',");
                        sqlupdate.Append(@"TC32 = '" + ShippingPercent + "',");
                        if (ShippingPercent != "")
                        {
                            if (double.Parse(ShippingPercent) >= 100)
                                sqlupdate.Append(@"TC31 = 'OK'");
                            else
                            {
                                sqlupdate.Append(@"TC31 = 'WAITING'");
                            }
                        }
                        else { sqlupdate.Append(@"TC31 = 'WAITING'"); }
                        sqlupdate.Append(@" where TC02 = '" + MaTaoDon + "' and TC03 ='" + codeDon + "' and TC06='" + codeSanPham + "'");

                        sqlCON update = new sqlCON();
                        update.sqlExecuteNonQuery(sqlupdate.ToString(), false);
                    }
                }
            }
        }

    }
}
