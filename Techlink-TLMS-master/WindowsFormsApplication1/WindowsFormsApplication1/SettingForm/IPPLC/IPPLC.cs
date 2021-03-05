using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.SettingForm.IPPLC
{
    public partial class IPPLC : CommonFormMetro
    {
        public IPPLC()
        {
            InitializeComponent();
        }
        DataTable dt;

        private void IPPLC_Load(object sender, EventArgs e)
        {
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;
            sqlCON data = new sqlCON();
            data.getComboBoxData("select distinct process from m_ipPLC ", ref cmb_process);
        }

        private void cmb_process_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmb_ip.Items.Clear();
            sqlCON data = new sqlCON();
            data.getComboBoxData("select distinct IPPLC from m_ipPLC where process = '" + cmb_process.Text + "' ", ref cmb_ip);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchdata(ref dgv_ip, true);
        }
        public void searchdata(ref DataGridView dgv, bool load)
        {
            if (load == true)
            {
                dgv.DataSource = null;
            }
            dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append("select * from m_ipPLC  where 1=1 ");
            if (cmb_process.Text != "")
            {
                sql.Append("and process ='" + cmb_process.Text + "'");
            }
            if (cmb_ip.Text != "")
            {
                sql.Append("and IPPLC ='" + cmb_ip.Text + "'");
            }
            sql.Append("order by IPPLC");
            sqlCON tf = new sqlCON();
            tf.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            dgv.DataSource = dt;
            dgv.Columns[0].Visible = false;
            dgv.AutoGenerateColumns = true;
            dgv.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            if (dgv_ip.RowCount == 0) { btn_edit.Enabled = false; btn_delete.Enabled = false; }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            AddIPPLC frm = new AddIPPLC();
            Class.valiballecommon va = Class.valiballecommon.GetStorage();
            va.value1 = dgv_ip.Rows[dgv_ip.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            va.value2 = dgv_ip.Rows[dgv_ip.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
            va.value3 = dgv_ip.Rows[dgv_ip.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
            va.value4 = dgv_ip.Rows[dgv_ip.SelectedCells[0].RowIndex].Cells[4].Value.ToString();
            va.value5 = dgv_ip.Rows[dgv_ip.SelectedCells[0].RowIndex].Cells[5].Value.ToString();
            va.value6 = dgv_ip.Rows[dgv_ip.SelectedCells[0].RowIndex].Cells[6].Value.ToString();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                searchdata(ref dgv_ip, true);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_ip.RowCount > 0)
            {
                int rownumber = dgv_ip.SelectedCells[0].RowIndex;
                string ip = dgv_ip.Rows[rownumber].Cells[5].Value.ToString();
                string sql = "delete from m_ipPLC where IPPLC = '" + ip + "'";
                sqlCON connect = new sqlCON();
                connect.sqlExecuteNonQuery(sql, true);
                searchdata(ref dgv_ip, true);
            }
        }
        private void btn_add_Click(object sender, EventArgs e)
        {
            AddIPPLC frm = new AddIPPLC();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                searchdata(ref dgv_ip, true);
            }
        }

        private void dgv_ip_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_ip.RowCount > 0) { btn_edit.Enabled = true; btn_delete.Enabled = true; }
        }
    }
}
