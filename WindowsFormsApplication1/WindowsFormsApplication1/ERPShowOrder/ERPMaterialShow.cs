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
    public partial class ERPMaterialShow : CommonForm
    {
        public ERPMaterialShow()
        {
            InitializeComponent();
            AcceptButton = btn_search;

        }
        DataTable dt;
        DataTable dtShow;
        private void ERPMaterialShow_Load(object sender, EventArgs e)
        {

            string sql_cmb_COPTC_TC001 = @"select distinct
moctas.TA026 as MaDDH
from MOCTA moctas
where moctas.TA026 != '' and moctas.TA027 != '' and moctas.TA013 = 'Y'";
            sqlERPCON conERP = new sqlERPCON();
            conERP.getComboBoxData(sql_cmb_COPTC_TC001, ref cmb_COPTC_TC001);
            if (cmb_COPTC_TC001.Items != null)
            {
                cmb_COPTC_TC001.SelectedIndex = 0;

            }
            //string sql_cmb_MOCTA_TA001 = "select distinct TA001 from MOCTA where TA001 != '' order by TA001";
            // conERP = new sqlERPCON();
            //conERP.getComboBoxData(sql_cmb_MOCTA_TA001, ref cmb_MOCTA_TA001);
        }
        private void cmd_COPTC_TC001_SelectedIndexChanged(object sender, EventArgs e)
        {

            string sql = "select distinct  TA027 from MOCTA where TA027 !='' and TA013 ='Y' and TA026 ='" + cmb_COPTC_TC001.Text + "' order by TA027";
            sqlERPCON conERP = new sqlERPCON();
            conERP.getComboBoxData(sql, ref cmb_COPTC_TC002);
            if (cmb_COPTC_TC002.Items != null)
            {
                cmb_COPTC_TC002.SelectedIndex = 0;
            //    datashow();

            }

        }
        private void cmb_COPTC_TC002_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select distinct  TA001, TA002 from MOCTA where  TA013 ='Y' and  TA026 ='" + cmb_COPTC_TC001.Text + "' and  TA027 ='" + cmb_COPTC_TC002.Text + "'  order by TA001";
            sqlERPCON conERP = new sqlERPCON();
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


        }
        private void cmb_MOCTA_TA001_SelectedIndexChanged(object sender, EventArgs e)
        {
            //string sql = "select distinct  TA002 from MOCTA where TA001 ='" + cmb_MOCTA_TA001.Text + "' order by TA002";
            //sqlERPCON conERP = new sqlERPCON();
            //conERP.getComboBoxData(sql, ref cmb_MOCTA_TA002);
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            getERPdata();
            // dtShow = new DataTable();
            // datashow();
            dtgv_material.DataSource = dt;
           // dtgv_material.DataSource = dtShow;
            dtgv_material.AutoGenerateColumns = true;
            dtgv_material.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dtgv_material.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dtgv_material.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dtgv_material.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgv_material.AllowUserToAddRows = false;
        }
        void getERPdata()
        {
            DateTime dateto = dtp_to.Value.Date;
            DateTime datefrom = dtp_from.Value.Date;
            dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"
                                                       select distinct
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
moctas.TA015 as Product_Quanity,
moctbs.TB003 as Material_Code,
moctbs.TB012 as Material_Name,
moctbs.TB009 as Warehourse_Code,
moctbs.TB015 as Ready_Material_Date,
moctbs.TB004 as amount_of_material_receive,
moctbs.TB005 as amount_of_material_use,
invmbs.MB064 as Avaiable_Material_Quanity,
sum(moctes.TE005) as Production_Material_Quantity,
moctbs.TB007 as Unit
from MOCTA moctas
left join MOCTB moctbs on moctas.TA001 = moctbs.TB001 and moctas.TA002 = moctbs.TB002
left join INVMB invmbs on moctbs.TB003 = invmbs.MB001
left join MOCTE moctes on  moctes.TE004 =moctbs.TB003 and moctes.TE011 =moctas.TA001 and  moctes.TE012 =moctas.TA002
                            where 1=1  and moctes.TE001 not like '%6%' ");
            if ((string)cmb_MOCTA_TA001.Text != "")
            {
                sql.Append(" and moctas.TA001   = '" + (string)cmb_MOCTA_TA001.Text + "'");
            }
            if ((string)cmb_MOCTA_TA002.Text != "")
            {
                sql.Append(" and moctas.TA002   = '" + (string)cmb_MOCTA_TA002.Text + "'");
            }
            if ((string)cmb_COPTC_TC001.Text != "")
            {
                sql.Append(" and moctas.TA026   = '" + (string)cmb_COPTC_TC001.Text + "'");
            }
            if ((string)cmb_COPTC_TC002.Text != "")
            {
                sql.Append(" and moctas.TA027   = '" + (string)cmb_COPTC_TC002.Text + "'");
            }
              else
            {
                sql.Append(" and CONVERT(date,moctas.CREATE_DATE) >= '" + datefrom + "' ");
                sql.Append(" and CONVERT(date,moctas.CREATE_DATE) <= '" + dateto + "' ");
            }

            sql.Append(@" group by
 moctas.CREATE_DATE,
                                    moctas.TA001 ,
                                    moctas.TA002 ,
                                    moctas.TA003,
                                    moctas.TA006,
                                    moctas.TA009 ,
                                    moctas.TA010 ,
                                    moctas.TA012 ,
                                    moctas.TA013 ,
                                    moctas.TA015,
                                    moctas.TA024 ,
                                    moctas.TA025,
                                    moctas.TA026 ,
                                    moctas.TA027,
                                    moctas.TA034,
                                    moctbs.TB003,
                                    moctbs.TB012,
                                    moctbs.TB009,
                                    moctbs.TB015,
                                    moctbs.TB004,
                                    moctbs.TB005,
                                    moctbs.TB007,
									invmbs.MB064
									
");

            sql.Append(" order by moctas.TA002");
            sqlERPCON con = new sqlERPCON();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
          //  checkdata
            if (dt.Rows.Count > 0)
            {
                try
                {


                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        string sqlcheck = "";

                        string MaDDH = dt.Rows[i]["Code_Type"].ToString();
                        string SoDDH = dt.Rows[i]["Code_No"].ToString();
                        string MaLSX = dt.Rows[i]["Production_Planning_Code"].ToString();
                        string SoLSX = dt.Rows[i]["Production_Planning_No"].ToString();
                        string codeSanPham = dt.Rows[i]["Product_Code"].ToString();
                        string MaVatLieu = dt.Rows[i]["Material_Code"].ToString();

                        double SoNVLCanLanh = (dt.Rows[i]["amount_of_material_receive"] != null && dt.Rows[i]["amount_of_material_receive"].ToString() != "") ? double.Parse(dt.Rows[i]["amount_of_material_receive"].ToString()) : 0;
                        double SoNVLTrongKho = (dt.Rows[i]["Avaiable_Material_Quanity"] != null && dt.Rows[i]["Avaiable_Material_Quanity"].ToString() != "") ? double.Parse(dt.Rows[i]["Avaiable_Material_Quanity"].ToString()) : 0;


                        sqlcheck = @"select COUNT(*) from t_OCTD where TD02 = '" + MaDDH + "' and TD03 ='" + SoDDH + "' and TD04='" + MaLSX + "' and TD05='" + SoLSX
                         + "' and TD07 ='" + codeSanPham + "' and TD15 ='" + MaVatLieu + "'";
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
                            sqlinsert.Append("insert into t_OCTD ");
                            sqlinsert.Append(@"(TD01,TD02,TD03,TD04,TD05,TD06,TD07,TD08,TD09,TD10,TD11,TD12,TD13,TD14,TD15,TD16,TD17,TD18,TD19,TD20,TD21,TD31,TD32,TD33,UserName,datetimeRST) values ( ");
                            sqlinsert.Append(list);
                            if (SoNVLTrongKho > SoNVLCanLanh)
                            {
                                sqlinsert.Append("'OK', 'OK' , '0' " + ",");
                            }
                            else if (SoNVLTrongKho == SoNVLCanLanh)
                            {
                                sqlinsert.Append("'OK', 'OK' , '1' " + ",");
                            }
                            else if (SoNVLTrongKho < SoNVLCanLanh)
                            {
                                sqlinsert.Append("'NG', 'NG' , '2' " + ",");

                            }
                            sqlinsert.Append("'" + Class.valiballecommon.GetStorage().UserName + "',GETDATE())");
                            sqlCON insert = new sqlCON();
                            insert.sqlExecuteNonQuery(sqlinsert.ToString(), false);
                        }
                        else //update
                        {

                            StringBuilder sqlupdate = new StringBuilder();
                            sqlupdate.Append("update t_OCTD set ");
                            sqlupdate.Append(@"TD18 = '" + dt.Rows[i]["amount_of_material_receive"].ToString() + "',");
                            sqlupdate.Append(@"TD18 = '" + dt.Rows[i]["amount_of_material_use"].ToString() + "',");
                            sqlupdate.Append(@"TD19 = '" + dt.Rows[i]["Avaiable_Material_Quanity"].ToString() + "',");
                            sqlupdate.Append(@"TD20 = '" + dt.Rows[i]["Production_Material_Quantity"].ToString() + "'");
                            if (SoNVLTrongKho > SoNVLCanLanh)
                            {
                                sqlupdate.Append(@", TD31 = 'OK' ,");
                                sqlupdate.Append(@" TD32 = 'OK' ,");
                                sqlupdate.Append(@"TD33 = '0', ");
                            }
                            else if (SoNVLTrongKho == SoNVLCanLanh)
                            {
                                sqlupdate.Append(@", TD31 = 'OK' ,");
                                sqlupdate.Append(@" TD32 = 'OK' ,");
                                sqlupdate.Append(@"TD33 = '1' ,");
                            }
                            else if (SoNVLTrongKho < SoNVLCanLanh)
                            {
                                sqlupdate.Append(@", TD31 = 'NG' ,");
                                sqlupdate.Append(@" TD32 = 'NG' ,");
                                sqlupdate.Append(@"TD33 = '2' ,");
                            }
                            sqlupdate.Append(@" UserName = '" + Class.valiballecommon.GetStorage().UserName + "' ,");
                            sqlupdate.Append(@" datetimeRST = GETDATE()");

                            sqlupdate.Append(@" where TD02 = '" + MaDDH + "' and TD03 ='" + SoDDH + "' and TD04='" + MaLSX + "' and TD05='" + SoLSX
                         + "' and TD07 ='" + codeSanPham + "' and TD15 ='" + MaVatLieu + "'");

                            sqlCON update = new sqlCON();
                            update.sqlExecuteNonQuery(sqlupdate.ToString(), false);
                        }
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show("Update or Insert to database fail: " + ex.Message, "Error");
                }
            }
        }
        void datashow()
        {
            DateTime dateto = dtp_to.Value.Date ;
            DateTime datefrom = dtp_from.Value.Date;
            dtShow = new DataTable();
            StringBuilder sql = new StringBuilder();

            sql.Append(@"select
CONVERT(date,TD01) as Create_Date,
TD02 as Code_Type,
TD03  as Code_No,
TD04 as Production_Planning_Code,
TD05 as Production_Planning_No,
TD06 as Product_Code,
TD07 as Product_Name,
TD08 as Production_Start_Date,
TD09 as Estimate_Complete_Date,
TD10 as Actual_Production_Date,
TD11 as Confirm,
TD12 as Product_Quanity,
TD13 as Material_Code,
TD14 as Material_Name,
TD15 as Warehourse_Code,
TD16 as Ready_Material_Date,
TD17 as amount_of_material_receive,
TD18 as amount_of_material_use,
TD19 as Avaiable_Material_Quanity,
TD20 as Unit,
TD31,
TD32,
TD33
from t_OCTD
where 1=1");
          
            if (cmb_COPTC_TC001.Text != "")
            {
                sql.Append(" and TD02  = '" + cmb_COPTC_TC001.Text + "'");
            }
            if ((string)cmb_COPTC_TC002.Text != "")
            {
                sql.Append(" and TD03   = '" + cmb_COPTC_TC002.Text + "'");
            }
            if ((string)cmb_MOCTA_TA001.Text != "")
            {
                sql.Append(" and TD04  = '" + cmb_MOCTA_TA001.Text + "'");
            }
            if ((string)cmb_MOCTA_TA002.Text != "")
            {
                sql.Append(" and TD05  = '" + cmb_MOCTA_TA002.Text + "'");
            }
            // else
            {
                sql.Append(" and CONVERT(date,TD01) >= '" + datefrom + "' ");
                sql.Append(" and CONVERT(date,TD01) <= '" + dateto + "' ");
              
            }
            sql.Append("order by TD02");
            sqlCON con = new sqlCON();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dtShow);
            //FormShowTest form = new FormShowTest((string)cmb_COPTC_TC001.SelectedItem, (string)cmb_COPTC_TC002.SelectedItem, dtShow);
            //form.ShowDialog();
        }

        private void Btn_ExportExcel_Click(object sender, EventArgs e)
        {
            Class.ToolSupport toolSupport = new Class.ToolSupport();
            toolSupport.dtgvExport2Excel(dtgv_material, @"C:\Users\Tech-Link\Downloads\test3.xls");

        }
    }
    


}

