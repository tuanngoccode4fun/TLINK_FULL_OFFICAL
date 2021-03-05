using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.SettingForm
{
    public partial class
        PermissionForm : CommonFormMetro
    {
        public PermissionForm()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void PermissionForm_Load(object sender, EventArgs e)
        {
            string sql = "select distinct permission from m_user order by permission";
            sqlCON connect = new sqlCON();
            connect.getComboBoxData(sql, ref cmb_permission);

            getdgvfull("admin");
        }
        void getdgvfull(string permission)
        {
            dt = new DataTable();
            string sql = "select button, status from m_permission  where permission ='" + permission + "'";
            sqlCON connect = new sqlCON();
            connect.sqlDataAdapterFillDatatable(sql, ref dt);
            dgv_permission.DataSource = dt;
            dgv_permission.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv_permission.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (cmb_permission.Text == "" || dgv_permission.Rows.Count < 1)
            {
                return;
            }
            string sqldelete = "delete from m_permission where permission = '" + cmb_permission.Text + "' and permission not like 'admin'";
            sqlCON connect = new sqlCON();
            connect.sqlExecuteNonQuery(sqldelete, false); //false không xuất hiện thông báo
            for (int i = 0; i < dgv_permission.Rows.Count; i++)
            {

                string sqladd = @"insert into m_permission(permission, button, status, datetimeRST) values ('"
+ cmb_permission.Text + "','" + dgv_permission.Rows[i].Cells[0].Value.ToString() + "','"
+ dgv_permission.Rows[i].Cells[1].Value.ToString() + "',GETDATE())";
                connect.sqlExecuteNonQuery(sqladd, false);
            }

            infomesge infor = new infomesge();
            infor.WarningMesger("Update is Ok", "INFO", this);
            getdgvfull(cmb_permission.Text);

        }

        private void cmb_permission_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdgvfull(cmb_permission.Text);
        }
    }
}
