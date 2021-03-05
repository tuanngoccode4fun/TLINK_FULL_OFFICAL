using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.SettingForm.RegisterUsesForm
{
    public partial class RegisterUserForm : CommonFormMetro
    {
        DataTable dt;
        public RegisterUserForm()
        {
            InitializeComponent();
            AcceptButton = btn_search;
        }
        private void RegisterUserForm_Load(object sender, EventArgs e)
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
            sql.Append("select id, usercode, username, permission, datetimeRST from m_user where 1=1 ");
            if (txt_usercode.Text != "")
            {
                sql.Append("and usercode ='" + txt_usercode.Text + "'");
            }
            if (txt_username.Text != "")
            {
                sql.Append("and username ='" + txt_username.Text + "'");
            }
            sql.Append("order by usercode");
            sqlCON tf = new sqlCON();
            tf.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            dgv.DataSource = dt;
            dgv.Columns[0].HeaderText = "ID";
            dgv.Columns[1].HeaderText = "User Code";
            dgv.Columns[2].HeaderText = "User Name";
            dgv.Columns[3].HeaderText = "Permission";
            dgv.Columns[4].HeaderText = "Datetime Register";
            dgv.Columns[0].Visible = false;
            dgv.AutoGenerateColumns = true;
            dgv.DefaultCellStyle.Font  = new Font("Verdana", 8, FontStyle.Regular);
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            if (dgv_registeruser.RowCount == 0) { btn_edit.Enabled = false; btn_delete.Enabled = false; }
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            searchdata(ref dgv_registeruser, true);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            SettingForm.RegisterUserForm.AddRegisterUser frm = new SettingForm.RegisterUserForm.AddRegisterUser();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                searchdata(ref dgv_registeruser, true);
            }
        }


        private void dgv_registeruser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgv_registeruser.RowCount > 0) { btn_edit.Enabled = true; btn_delete.Enabled = true; }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            SettingForm.RegisterUserForm.AddRegisterUser frm = new SettingForm.RegisterUserForm.AddRegisterUser();
            Class.valiballecommon va = Class.valiballecommon.GetStorage();
            va.value1 = dgv_registeruser.Rows[dgv_registeruser.SelectedCells[0].RowIndex].Cells[1].Value.ToString();
            va.value2 = dgv_registeruser.Rows[dgv_registeruser.SelectedCells[0].RowIndex].Cells[2].Value.ToString();
            va.value3 = dgv_registeruser.Rows[dgv_registeruser.SelectedCells[0].RowIndex].Cells[3].Value.ToString();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                searchdata(ref dgv_registeruser, true);
            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (dgv_registeruser.RowCount > 0)
            {
                int rownumber = dgv_registeruser.SelectedCells[0].RowIndex;
                string usercode = dgv_registeruser.Rows[rownumber].Cells[1].Value.ToString();
                string sql = "delete from m_user where usercode = '" + usercode + "'";
                sqlCON connect = new sqlCON();
                connect.sqlExecuteNonQuery(sql, true);
                searchdata(ref dgv_registeruser, true);
            }
        }
    }
}
