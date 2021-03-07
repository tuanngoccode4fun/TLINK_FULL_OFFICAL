using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.SettingForm.ProcessForm
{
    public partial class ProcessForm : CommonFormMetro
    {
        public ProcessForm()
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
            sql.Append("select id, modelcode,processcode, processname, itemcode, itemname, datetimeRST from m_process where 1=1 ");
            if (cmb_modelcode.Text != "")
            {
                sql.Append("and modelcode ='" + cmb_modelcode.Text + "'");
            }
            if (txt_processcode.Text != "")
            {
                sql.Append("and processcode ='" + txt_processcode.Text + "'");
            }
            sql.Append("order by modelcode"); //stop
            sqlCON tf = new sqlCON();
            tf.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[1].HeaderText = "Model Code";
            dgv.Columns[2].HeaderText = "Process Code";
            dgv.Columns[3].HeaderText = "Process Name";
            dgv.Columns[4].HeaderText = "Item Code";
            dgv.Columns[5].HeaderText = "Item Name";
            dgv.Columns[6].HeaderText = "Datetime Register";
            dgv.Columns[0].Visible = false;
            dgv.AutoGenerateColumns = true;
            dgv.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            if (dgv_process.RowCount == 0) { btn_edit.Enabled = false; btn_delete.Enabled = false; }
        }
        private void btn_search_Click(object sender, EventArgs e)
        {
            searchdata( ref dgv_process, true);
        }

        private void ProcessForm_Load(object sender, EventArgs e)
        {
            sqlCON connect = new sqlCON();
            string sql = "select distinct modelcode from m_model order by modelcode";
            connect.getComboBoxData(sql, ref cmb_modelcode);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_process.RowCount > 0)
            {
                int rownumber = dgv_process.SelectedCells[0].RowIndex;
                string id =dgv_process.Rows[rownumber].Cells[0].Value.ToString();
                string sql = "delete from m_process where id = " + id + "";
                sqlCON connect = new sqlCON();
                connect.sqlExecuteNonQuery(sql, true);
                searchdata(ref dgv_process, true);
            }
        }
        private void btn_add_Click(object sender, EventArgs e)

        {
            AddProcessForm frm = new AddProcessForm();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                searchdata(ref dgv_process, true);
            }
        }
        private void btn_edit_Click(object sender, EventArgs e)
        {

            //AddProcessForm frm = new AddProcessForm();
            //Class.valiballecommon va = Class.valiballecommon.GetStorage();
            //va.value1 = dgv_process.Rows[dgv_process.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            //va.value2 = dgv_process.Rows[dgv_process.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
            //va.value3 = dgv_process.Rows[dgv_process.SelectedCells[0].RowIndex].Cells[3].Value.ToString();

            //if (frm.ShowDialog() == DialogResult.OK)
            //{
            //    searchdata(ref dgv_process, true);
            //}
        }
    }
}
