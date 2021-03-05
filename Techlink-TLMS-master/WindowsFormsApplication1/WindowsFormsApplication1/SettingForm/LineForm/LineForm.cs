using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.SettingForm.LineForm
{
    public partial class LineForm : CommonFormMetro
    {
        DataTable dt;
        public LineForm()
        {
            InitializeComponent();
            AcceptButton = btn_search;
        }

        private void LineForm_Load(object sender, EventArgs e)
        {
            btn_delete.Enabled = false;
            btn_edit.Enabled = false;
        }
        public void searchdata(ref DataGridView dgv, bool load)
        {
            if (load == true)
            {
                dgv.DataSource = null;
            }
            dt = new DataTable();
            StringBuilder sql = new StringBuilder();
            sql.Append("select id, linecode, linename, datetimeRST from m_line where 1=1 ");
            if (txt_linecode.Text != "")
            {
                sql.Append("and linecode ='" +txt_linecode.Text + "'");
            }
            if (txt_linename.Text != "")
            {
                sql.Append("and linename ='" + txt_linename.Text + "'");
            }
            sql.Append("order by linecode");
            sqlCON tf = new sqlCON();
            tf.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[1].HeaderText = "Line Code";
            dgv.Columns[2].HeaderText = "Line Name";
            dgv.Columns[3].HeaderText = "Datetime Register";
            dgv.Columns[0].Visible = false;
            dgv.AutoGenerateColumns = true;
            dgv.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            if (dgv_line.RowCount == 0) { btn_edit.Enabled = false; btn_delete.Enabled = false; }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            searchdata(ref dgv_line, true);
        }
        private void dgv_line_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_line.RowCount > 0) { btn_edit.Enabled = true; btn_delete.Enabled = true; }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_line.RowCount > 0)
            {
                int rownumber = dgv_line.SelectedCells[0].RowIndex;
                string linecode = dgv_line.Rows[rownumber].Cells[1].Value.ToString();
                string sql = "delete from m_line where linecode = '" + linecode + "'";
                sqlCON connect = new sqlCON();
                connect.sqlExecuteNonQuery(sql, true);
                searchdata(ref dgv_line, true);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddLineForm frm = new AddLineForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                searchdata(ref dgv_line, true);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            AddLineForm frm = new AddLineForm();
            Class.valiballecommon va = Class.valiballecommon.GetStorage();
            va.value1 = dgv_line.Rows[dgv_line.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            va.value2 =dgv_line.Rows[dgv_line.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
           
            if (frm.ShowDialog() == DialogResult.OK)
            {
                searchdata(ref dgv_line, true);
            }
        }
    }
}
