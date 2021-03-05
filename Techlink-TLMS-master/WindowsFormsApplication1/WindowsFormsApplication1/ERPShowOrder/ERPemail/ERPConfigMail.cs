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
    public partial class ERPConfigMail : CommonFormMetro
    {
        public ERPConfigMail()
        {
            InitializeComponent();
            AcceptButton = btn_search;
        }
        DataTable dt;
        public void searchdata(ref DataGridView dgv, bool load)
        {
            if (load == true)
            {
                dgv.DataSource = null;
            }
            dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append("select id,deptcode, emailaddress, status, usingfunction,  datetimeRST from m_email where 1=1 ");
            if (txt_mailaddress.Text != "")
            {
                sql.Append("and emailaddress ='" + txt_mailaddress.Text + "'");
            }
            if (cmb_usingfunction.Text != "")
            {
                sql.Append("and usingfunction ='" + cmb_usingfunction.Text + "'");
            }
            sql.Append("order by usingfunction"); //stop
            sqlCON tf = new sqlCON();
            tf.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[1].HeaderText = "Dept Code";
            dgv.Columns[2].HeaderText = "Email Address";
            dgv.Columns[3].HeaderText = "Staus allow";
            dgv.Columns[4].HeaderText = "Using for Function";
            dgv.Columns[5].HeaderText = "Datetime Register";
            dgv.Columns[0].Visible = false;
            dgv.AutoGenerateColumns = true;
            dgv.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            if (dgv_show.RowCount == 0) { btn_edit.Enabled = false; btn_delete.Enabled = false; }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            AddERPConfigMail addshow = new AddERPConfigMail();
            if (addshow.ShowDialog() == DialogResult.OK)
            {
                searchdata(ref dgv_show, true);
            }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchdata(ref dgv_show, true);
        }

        private void ERPConfigMail_Load(object sender, EventArgs e)
        {
            sqlCON usingfunction = new sqlCON();
            usingfunction.getComboBoxData("select distinct usingfunction from m_email order by usingfunction ", ref cmb_usingfunction);
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            AddERPConfigMail frm = new AddERPConfigMail();
            Class.valiballecommon va = Class.valiballecommon.GetStorage();
            va.value1 = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            va.value2 = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
            va.value3 = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells[4].Value.ToString();
            va.value4 = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
            va.valuleID = dgv_show.Rows[dgv_show.SelectedCells[0].RowIndex].Cells[0].Value.ToString();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                searchdata(ref dgv_show, true);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_show.RowCount > 0)
            {
                int rownumber = dgv_show.SelectedCells[0].RowIndex;
                string ID = dgv_show.Rows[rownumber].Cells[0].Value.ToString();
                string sql = "delete from m_email where id = '" + ID + "'";
                sqlCON connect = new sqlCON();
                connect.sqlExecuteNonQuery(sql, true);
                searchdata(ref dgv_show, true);
            }
        }
    }
}
