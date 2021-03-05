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

namespace WindowsFormsApplication1
{
    public partial class CrisisReportShow : CommonForm
    {
        DataTable dt;
        DataTable dtShipping;
      
        public CrisisReportShow()
        {
            InitializeComponent();
        }
      
        private void Btn_search_Click(object sender, EventArgs e)
        {
            GetDataFollowProduction();

            dgv_show.DataSource = dt;

        }
        private void GetDataFollowProduction ()
        {
            dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select 
a.CREATE_DATE as Ngaytao,
a.TA001 as LSX,
a.TA002 as LSXNo,
a.TA026 as DDH,
a.TA027 as DDHNo,
a.TA006 as Product_Code,
a.TA034 as Product_Name,
sum(b.TG011 )as finished_good,
sum(b.TG012) as NG_Qty,
sum(b.TG013 )as OK_Qty,
b.TG010 as LoaiKho,
b.TG034 as vitrikho
from MOCTA a
left join MOCTG b on a.TA001 = b.TG014 and a.TA002 = b.TG015
where CONVERT(date,a.CREATE_DATE) > '2019-09-01' and a.TA001 like '%51%' and
(b.TG010  = 'A04' or b.TG010  = 'B02' or b.TG010  = 'B03' or b.TG010  = 'P04' or b.TG010  = 'Y04') and a.TA026 != '' --and a.TA001 = 'P511' and  a.TA002 = '19080055'
group by
a.CREATE_DATE ,
a.TA001 ,
a.TA002,
a.TA026,
a.TA027 ,
a.TA006 ,
a.TA034 ,
b.TG010,
b.TG034 ");
            sqlERPCON con = new sqlERPCON();
            con.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            ListDDH(dt);
        }
        private List<string[]> ListDDH(DataTable dt)
        {
            List<string[]> listDDH = new List<string[]>();
            List<DataTable> listShipping = new List<DataTable>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] str = new string[4];
                str[0] = dt.Rows[i]["LSX"].ToString();
                str[1] = dt.Rows[i]["LSXNo"].ToString();
                str[2] = dt.Rows[i]["DDH"].ToString();
                str[3] = dt.Rows[i]["DDHNo"].ToString();
                dtShipping = new DataTable();
                StringBuilder sql = new StringBuilder();
                sql.Append(@" ---thong so chay theo ma don hang 
select
coptcs.CREATE_DATE as ngaytaodon,
coptcs.TC001 as malamdon, 
coptcs.TC002 as code,
coptcs.TC012 as makh, 
coptds.TD004 as codesp,
coptds.TD005 as nametensp,
coptds.TD008 as soluongdathang,
coptds.TD010 as donvi,
coptcs.TC005 as bophan,
coptds.TD047 as deadline,
copths.TH008 as SLdagiao,
copths.TH004 as spduocgiao,
copths.TH001 as maDongiaohang,
copths.TH005 as namespdcgiao,
coptgs.TG003 as ngayGiaohang,
coptjs.TJ008 as SLDatralai,
coptis.TI003 as ngaytrahang
from COPTC coptcs
left join COPTD  coptds on coptcs.TC002 = coptds.TD002  and coptcs.TC001 = coptds.TD001 -- cong doan tao don
left join MOCTB  moctbs on coptcs.TC002 = moctbs.TB002  and coptcs.TC001 = moctbs.TB001
left join COPTH copths on coptcs.TC002 = copths.TH015 and  coptcs.TC001 = copths.TH014--cong doan giao hang
left join COPTG coptgs on copths.TH002  = coptgs.TG002 and copths.TH001  = coptgs.TG001 --cong doan giao hang
left join COPTJ coptjs on coptcs.TC002 = coptjs.TJ019 and coptcs.TC001 = coptjs.TJ018-- cong doan tra hang
left join COPTI coptis on coptjs.TJ002 = coptis.TI002 and coptjs.TJ001 = coptis.TI001 --cong doan tra hang
where coptcs.TC001   = '" + str[2] + "'  and coptcs.TC001= '" + str[3] + "'");
                sqlERPCON con = new sqlERPCON();
                con.sqlDataAdapterFillDatatable(sql.ToString(), ref dtShipping);
                listShipping.Add(dtShipping);

            }

            {
               

                return listDDH;

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

        private void CrisisReportShow_Load(object sender, EventArgs e)
        {
            LoadTreeviewDeptment();
        }
    }
}
