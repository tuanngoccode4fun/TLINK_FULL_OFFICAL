using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.SettingForm.DeptForm
{
    public partial class DeptForm : CommonFormMetro
    {
        public DeptForm()
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
            sql.Append("select id, deptcode, deptname, datetimeRST from m_dept where 1=1 ");
            if (txt_deptcode.Text != "")
            {
                sql.Append("and deptcode ='" + txt_deptcode.Text + "'");
            }
            if (txt_deptname.Text != "")
            {
                sql.Append("and deptname ='" + txt_deptname.Text + "'");
            }
            sql.Append("order by deptcode");
            sqlCON tf = new sqlCON();
            tf.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[1].HeaderText = "Dept Code";
            dgv.Columns[2].HeaderText = "Dept Name";
            dgv.Columns[3].HeaderText = "Datetime Register";
            dgv.Columns[0].Visible = false;
            dgv.AutoGenerateColumns = true;
            dgv.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            if (dgv_dept.RowCount == 0) { btn_edit.Enabled = false; btn_delete.Enabled = false; }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            searchdata(ref dgv_dept, true);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_dept.RowCount > 0)
            {
                int rownumber = dgv_dept.SelectedCells[0].RowIndex;
                string deptcode = dgv_dept.Rows[rownumber].Cells[1].Value.ToString();
                string sql = "delete from m_dept where deptcode = '" + deptcode + "'";
                sqlCON connect = new sqlCON();
                connect.sqlExecuteNonQuery(sql, true);
                searchdata(ref dgv_dept, true);
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddDept frm = new AddDept();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                searchdata(ref dgv_dept, true);
            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            AddDept frm = new AddDept();
            Class.valiballecommon va = Class.valiballecommon.GetStorage();
            va.value1 = dgv_dept.Rows[dgv_dept.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            va.value2 = dgv_dept.Rows[dgv_dept.SelectedCells[0].RowIndex].Cells[2].Value.ToString();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                searchdata(ref dgv_dept, true);
            }
        }
    }
}
