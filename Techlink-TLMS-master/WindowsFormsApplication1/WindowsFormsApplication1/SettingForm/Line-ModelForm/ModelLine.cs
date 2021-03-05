using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.SettingForm.Line_ModelForm
{
    public partial class ModelLine : CommonFormMetro
    {
        public ModelLine()
        {
            InitializeComponent();
        }
        DataTable dt;
        private void ModelLine_Load(object sender, EventArgs e)
        {
            sqlCON connect = new sqlCON();
            string sql = "select distinct modelcode from m_model order by modelcode";
            connect.getComboBoxData(sql, ref cmb_modelcode);
            treeview();
        }

        void treeview()
        {
            TreeNode trnode = new TreeNode("Line");
            tv_line.Nodes.Clear();
            dt = new DataTable();
            sqlCON connect = new sqlCON();
            connect.sqlDataAdapterFillDatatable("select distinct linecode from m_line order by linecode", ref dt);
            TreeNode child = new TreeNode();
            foreach (DataRow row in dt.Rows)
            {
               child = new TreeNode(row[0].ToString());
                trnode.Nodes.Add(child);
            }                       
            tv_line.Nodes.Add(trnode);
        }
        
        private void cmb_modelcode_SelectedIndexChanged(object sender, EventArgs e)
        {
            getdgvfull(cmb_modelcode.Text);
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            if (cmb_modelcode.Text == "" || tv_line.Nodes[0].Nodes.Count < 1) return;
            string sqldelete = "delete from m_model_line where modelcode = '" + cmb_modelcode.Text + "'";
            sqlCON connect = new sqlCON();
            connect.sqlExecuteNonQuery(sqldelete, false); //false không xuất hiện thông báo
            for (int i = 0; i < tv_line.Nodes[0].Nodes.Count; i++)
            {
                //if (tv_line.Nodes[0].Nodes[i].Checked)
                //{
                //    MessageBox.Show(tv_line.Nodes[0].Nodes[i].Text);
                //}
               
                string sqladd = @"insert into m_model_line(modelcode, linecode, status, datetimeRST) values ('"
+ cmb_modelcode.Text + "','" + tv_line.Nodes[0].Nodes[i].Text + "','"
+ tv_line.Nodes[0].Nodes[i].Checked.ToString() + "',GETDATE())";
                connect.sqlExecuteNonQuery(sqladd, false);
            }
            infomesge infor = new infomesge();
            infor.WarningMesger("Update is Ok", "INFO", this);
            getdgvfull(cmb_modelcode.Text);
        }
        void getdgvfull(string modelcode)
        {
            dt = new DataTable();
            string sql = "select linecode, status from m_model_line  where modelcode ='" + modelcode+ "'";
            sqlCON connect = new sqlCON();
            connect.sqlDataAdapterFillDatatable(sql, ref dt);
            dgv_modeline.DataSource = dt;
            dgv_modeline.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv_modeline.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            if (cmb_modelcode.Text == "" || dgv_modeline.Rows.Count < 1)
            {
                return;
            }
            string sqldelete = "delete from m_model_line where modelcode = '" + cmb_modelcode.Text + "'";
            sqlCON connect = new sqlCON();
            connect.sqlExecuteNonQuery(sqldelete, false); //false không xuất hiện thông báo
            for (int i = 0; i < dgv_modeline.Rows.Count; i++)
            {

                string sqladd = @"insert into m_model_line(modelcode, linecode, status, datetimeRST) values ('"
+ cmb_modelcode.Text + "','" + dgv_modeline.Rows[i].Cells[0].Value.ToString() + "','"
+ dgv_modeline.Rows[i].Cells[1].Value.ToString() + "',GETDATE())";
                connect.sqlExecuteNonQuery(sqladd, false);
            }

            infomesge infor = new infomesge();
            infor.WarningMesger("Update is Ok", "INFO", this);
            getdgvfull(cmb_modelcode.Text);
        }
    }
}
