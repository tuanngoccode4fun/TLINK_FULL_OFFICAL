using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ERPShowOrder.ERP_KPI.ERPPKI_Data.ERPPlanForm
{
    public partial class DailyTagetForm : CommonForm
    {
        public DailyTagetForm()
        {
            InitializeComponent();
        }
        string keyid = "";
        private void DailyTagetForm_Load(object sender, EventArgs e)
        {
            sqlERPCON conndept = new sqlERPCON();
            conndept.getComboBoxData("select distinct TC004  from SFCTC order by TC004", ref cmb_dept);
        }

        private void cmb_dept_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_productioncode.Items.Clear();
            sqlERPCON connproductioncode = new sqlERPCON();
            connproductioncode.getComboBoxData("select distinct TC047  from SFCTC where TC004 like '" + cmb_dept.Text + "%'order by TC047", ref cmb_productioncode);
        }
        bool CheckNull()
        {
            if (cmb_dept.Text == "")
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data " + lbl_dept.Text + " is null", "Warning System !!!", this);
                return false;
            }
            if (cmb_productioncode.Text == "")
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data " + lbl_productioncode.Text + " is null !!!", "Warning System", this);
                return false;
            }
            if (txt_tagetoutput.Text == "")
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data " + lbl_tagetoutput.Text + " is null !!!", "Warning System", this);
                return false;
            }
            if (txt_tagetNG.Text == "")
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data " + lbl_tagetng.Text + " is null !!!", "Warning System", this);
                return false;
            }
            if (cmb_type.Text == "")
            {
                infomesge mes = new infomesge();
                mes.WarningMesger("Data " + lbl_Type.Text + " is null !!!", "Warning System", this);
                return false;
            }
            return true;
        }
        bool keycheck()
        {
            StringBuilder sqlcheck = new StringBuilder();

            if (cmb_type.Text == "Daily")
            {
                sqlcheck.Append("select count(*) from t_ERP_planning where 1=1");
                sqlcheck.Append(" and  deptcode = '" + cmb_dept.Text + "'");
                sqlcheck.Append(" and  datetime_planning = '" + dtp_dateplaning.Text + "'");
                sqlcheck.Append(" and type = '" + cmb_type.Text + "'");
                sqlcheck.Append(" and  production_code = '" + cmb_productioncode.Text + "'");
                sqlCON connectsql = new sqlCON();
                if (int.Parse(connectsql.sqlExecuteScalarString(sqlcheck.ToString())) == 0) return false;
            }
            if (cmb_type.Text == "Monthly")
            {
                string month = DateTime.Now.ToString("MM");
                sqlcheck.Append(" select max(datetime_planning) from t_ERP_planning where 1 = 1");
                sqlcheck.Append(" and  deptcode = '" + cmb_dept.Text + "'");
                sqlcheck.Append(" and type = '" + cmb_type.Text + "'");
                sqlcheck.Append(" and  production_code = '" + cmb_productioncode.Text + "'");
                sqlCON connectsql = new sqlCON();
                string a = connectsql.sqlExecuteScalarString(sqlcheck.ToString());
                if (connectsql.sqlExecuteScalarString(sqlcheck.ToString()) == "") return false;
                if (connectsql.sqlExecuteScalarString(sqlcheck.ToString()).Substring(5, 2) != month) return false;

            }


            infomesge info = new infomesge();
            info.ErrorMesger("Data is dulicate !!!", "Error Messenger", this);
            return true;

        }
        private void btn_app_Click(object sender, EventArgs e)
        {
            if (CheckNull() && keycheck() == false)
            {
                try
                {
                    StringBuilder sqladd = new StringBuilder();
                    sqladd.Append("insert into t_ERP_planning(deptcode, datetime_planning,type,production_code,output_taget,ng_taget,  datetimeRST) values('");
                    sqladd.Append(cmb_dept.Text + "','");
                    sqladd.Append(dtp_dateplaning.Value + "','");
                    sqladd.Append(cmb_type.Text + "','");
                    sqladd.Append(cmb_productioncode.Text + "','");
                    sqladd.Append(txt_tagetoutput.Text + "','");
                    sqladd.Append(txt_tagetNG.Text + "',");
                    sqladd.Append("GETDATE())");
                    sqlCON add = new sqlCON();
                    add.sqlExecuteNonQuery(sqladd.ToString(), true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            btn_search_Click(sender, e);
        }
        private void btn_edit_Click(object sender, EventArgs e)
        {
            if (keyid == "") return;
            if (CheckNull())
            {
                try
                {
                    StringBuilder sqladd = new StringBuilder();
                    sqladd.Append("update  t_ERP_planning set output_taget = '" + txt_tagetoutput.Text + "',ng_taget = '" + txt_tagetNG.Text + "' ");
                    sqladd.Append("where id = '" + keyid + "'");
                    sqlCON add = new sqlCON();
                    add.sqlExecuteNonQuery(sqladd.ToString(), true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            btn_search_Click(sender, e);
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            DataTable dtshow = new DataTable();
            searchdata(ref dtshow);
            dgv_show.DataSource = dtshow;
            colordesign(dgv_show);
            editheader(dgv_show);
        }
        void editheader(DataGridView dgv_)
        {
            dgv_.ReadOnly = true;
            dgv_.AutoGenerateColumns = true;
            dgv_.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv_.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dgv_.AllowUserToAddRows = false;
            dgv_.Columns["id"].HeaderText = "ID Planning";
            dgv_.Columns["deptcode"].HeaderText = "Dept Code";
            dgv_.Columns["datetime_planning"].HeaderText = "Date Planning";
            dgv_.Columns["type"].HeaderText = "Type Planning";
            dgv_.Columns["production_code"].HeaderText = "Production Code";
            dgv_.Columns["output_taget"].HeaderText = "Output Target";
            dgv_.Columns["ng_taget"].HeaderText = "Not Good Target";
            dgv_.Columns["datetimeRST"].HeaderText = "DateTime Add";
        }
        void colordesign(DataGridView dgv_)
        {
            if (dgv_.RowCount < 2) return;
            for (int i = 0; i < dgv_.RowCount; i = i + 2)
            {
                dgv_.Rows[i].DefaultCellStyle.BackColor = Color.LemonChiffon;
            }
        }
        private void searchdata(ref DataTable dt)
        {
            dt = new DataTable();
            StringBuilder sqlsearch = new StringBuilder();
            sqlsearch.Append("select id, deptcode, datetime_planning,type,production_code,output_taget,ng_taget, datetimeRST from t_ERP_planning where 1=1 ");
            sqlsearch.Append(" and datetime_planning =  '" + dtp_dateplaning.Text + "' ");
            if (cmb_dept.Text != "")
            {
                sqlsearch.Append(" and deptcode like '" + cmb_dept.Text + "'");
            }
            if (cmb_productioncode.Text != "")
            {
                sqlsearch.Append(" and production_code like '" + cmb_productioncode.Text + "%' ");
            }
            if (cmb_type.Text != "")
            {
                sqlsearch.Append(" and type ='" + cmb_type.Text + "' ");
            }
            sqlsearch.Append(" order by datetime_planning, datetimeRST");
            sqlCON connectdt = new sqlCON();
            connectdt.sqlDataAdapterFillDatatable(sqlsearch.ToString(), ref dt);
            txt_tagetNG.Text = "";
            txt_tagetoutput.Text = "";
            keyid = "";
        }

        private void dgv_show_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_show.RowCount == 0)
            {
                return;
            }
            int i = e.RowIndex;
            int j = e.ColumnIndex;
            Class.valiballecommon va = Class.valiballecommon.GetStorage();
            cmb_dept.Text = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells["deptcode"].Value.ToString();
            cmb_productioncode.Text = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells["production_code"].Value.ToString();
            txt_tagetoutput.Text = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells["output_taget"].Value.ToString();
            txt_tagetNG.Text = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells["ng_taget"].Value.ToString();
            cmb_type.Text = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells["type"].Value.ToString();
            keyid = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells["id"].Value.ToString();
            //cmb_dept.Enabled = false;
            //cmb_productioncode.Enabled = false;


        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (keyid == "")
            {
                return;
            }
            string sqldelete = @"delete from t_ERP_planning where id  = '" + keyid + "'";
            sqlCON connectdelete = new sqlCON();
            connectdelete.sqlExecuteNonQuery(sqldelete, true);
            infomesge info = new infomesge();
            info.WarningMesger("One Row is deleted !!!", "Deleted OK", this);
            cmb_productioncode.Text = "";
            btn_search_Click(sender, e);

        }
    }
}
