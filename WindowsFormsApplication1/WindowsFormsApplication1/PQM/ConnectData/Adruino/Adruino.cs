using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1.PQM.ConnectData
{
    public partial class Adruino : CommonForm
    {
        public Adruino()
        {
            InitializeComponent();

        }
        DataTable dt;
        private void Adruino_Load(object sender, EventArgs e)
        {
            string sql = "select distinct  machine from t_andruino  order by machine";
            sqlCON conERP = new sqlCON();
            conERP.getComboBoxData(sql, ref cmb_machine);
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder();
            dt = new DataTable();
            sql.Append("select * from t_andruino  where machine = '" + cmb_machine.Text + "' and ");
            sql.Append("cast(inspectdate as datetime) + CAST (inspecttime as datetime) >= '" + dtp_from.Value + "' ");
            sql.Append("and  cast(inspectdate as datetime) + CAST (inspecttime as datetime) <='" + dtp_to.Value + "' order by inspectdate, inspecttime desc");

            sqlCON sqlcon = new sqlCON();
            sqlcon.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            dgv_show.DataSource = dt;
            dgv_show.AutoGenerateColumns = true;
            dgv_show.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv_show.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dgv_show.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.ColumnHeader;
            dgv_show.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_show.AllowUserToAddRows = false;
            dgv_show.ReadOnly = true;
            getdata();
        }
        private void getdata()
        {
            int output = 0;
            int NG1 = 0;
            int NG2 = 0;
            int NG3 = 0;
            double percent = 0.0000;
            if (dgv_show.Rows.Count > 0)
            {
                for (int i = 0; i < dgv_show.Rows.Count - 1; i++)
                {
                    output += int.Parse(dgv_show.Rows[i].Cells["Output"].Value.ToString());
                    NG1 += int.Parse(dgv_show.Rows[i].Cells["NG1"].Value.ToString());
                    NG2 += int.Parse(dgv_show.Rows[i].Cells["NG2"].Value.ToString());
                    NG3 += int.Parse(dgv_show.Rows[i].Cells["NG3"].Value.ToString());
                }
            }
            lblOutput.Text = output.ToString();
            lblNG1.Text = NG1.ToString();
            lblNG2.Text = NG2.ToString();
            lblNG3.Text = NG3.ToString();

            if (output != 0)
            {
                percent = ((NG1 + NG2 + NG3) / output) * 100;
            }
            lblTotalNG.Text = (NG1 + NG2 + NG3).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "START AUTO SHOW")
            {
                timer1.Enabled = true;
                button1.Text = "STOP AUTO SHOW";
            }
            else
            {
                timer1.Enabled = false;
                button1.Text = "START AUTO SHOW";
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            btn_search_Click(sender, e);
        }
    }
}
