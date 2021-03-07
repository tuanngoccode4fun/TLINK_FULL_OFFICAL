using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using WindowsFormsApplication1.MQC;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
namespace WindowsFormsApplication1.Warehouse
{
    public partial class CheckMaterial : CommonForm
    {
        public CheckMaterial()
        {
            InitializeComponent();
            AcceptButton = btn_search;
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder();
            DataTable dt = new DataTable();
            //sql.Append("select   ROW_NUMBER() OVER(order by CAST(ME009 as date)asc) AS Row,ME001, ME002, ME003, ME005, ME006, ME010,");
            //sql.Append("CAST(ME009 as datetime) as newdate,");
            //sql.Append(" DATEDIFF(dayofyear, GETDATE(),CAST(ME009 as datetime)),");
            //sql.Append("  case when CAST(ME009 as date) > GETDATE()+10 then 'OK' ");
            //sql.Append(" when CAST(ME009 as date) >= GETDATE()  and  CAST(ME009 as date) <= GETDATE()+10  then 'ALARM' ");
            //sql.Append(" else 'NG' end as STATUS");
            //sql.Append(" from INVME  where ME009 not like '' and ME009 like '201%'");
            sql.Append(@"SELECT ROW_NUMBER() OVER(order by G1.DIFFIRENT) as ROWS, G1.ME001, G2.MB023, G1.ME002 ,G1.DATET ,
G1.ME005, G1.ME006,  G1.STATUS, cast(G1.HSD as varchar(10)) as HSD,
G1.DIFFIRENT, G1.LF005, G1.TONKHO
FROM 
(
SELECT ROW_NUMBER() OVER(order by b1.DIFFIRENT) as ROWS, b1.ME001, b1.ME002,CAST(CAST( b1.ME003 AS DATE) as varchar(10))  AS DATET ,
b1.ME005, b1.ME006,  b1.STATUS,  b1.newdate AS HSD ,
b1.DIFFIRENT, b2.LF005, (b2.SLNHAP - b2.SLXUAT ) AS TONKHO
FROM 
(select   ME001, ME002, ME003, ME005, ME006, ME010,CAST(ME009 as date) as newdate, 
DATEDIFF(dayofyear, GETDATE(),CAST(ME009 as datetime)) AS DIFFIRENT, 
case
when CAST(ME009 as date) > GETDATE()+10 then 'OK'
when CAST(ME009 as date) >= GETDATE()  and  CAST(ME009 as date) <= GETDATE()+10  then 'ALARM'  
else 'NG' end as STATUS 
from INVME
where ME009 not like '' and ME009 like '201%' )  AS b1
inner  JOIN
(
SELECT A.LF004, A.LF005, A.LF007,  SLNHAP, SLXUAT FROM
(select LF004, LF005, LF007, LF008, SUM  (LF011) AS SLNHAP from INVLF
WHERE 1=1
AND LF008 =1
GROUP BY LF004, LF005, LF007, LF008 ) AS   A
LEFT JOIN
(select LF004, LF005, LF007, LF008,SUM  (LF011) AS SLXUAT from INVLF
WHERE 1=1
AND LF008 =-1
GROUP BY LF004, LF005, LF007, LF008) AS B ON A.LF007= B.LF007 AND A.LF004 = B.LF004 and A.LF005 = B.LF005
WHERE 1=1
AND SLNHAP > SLXUAT
) AS b2 ON b1.ME001 = b2.LF004 and b1.ME002 = b2.LF007

) AS G1
LEFT JOIN INVMB G2 ON G1.ME001 = G2.MB001
where 1=1


");
            if (txt_materialcode.Text != "")
            {
                sql.Append(" and G1.ME001 like '%" + txt_materialcode.Text + "%'");
            }
            else if (txt_Lot.Text != "")
            {
                sql.Append(" and G1.ME002 like '%" + txt_Lot.Text + "%'");
            }
            else if (cmb_warehousecode.Text != "")
            {

                sql.Append(" and G1.LF005 like '%" + cmb_warehousecode.Text + "%'");
            }
            else
            {
               
                sql.Append("  and G1.HSD  <= '" + dtp_to.Value + "'");
            }
         


            sqlERPCON sqlcon = new sqlERPCON();
            sqlcon.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            dgv_show.DataSource = dt;
            changeHeaderName(ref dgv_show);
        }
        void changeHeaderName(ref DataGridView dgv_)
        {
            // ROWS, b1.ME001, b1.ME002, b1.ME003, b1.ME005, b1.ME006, b1.ME010, b1.STATUS, b1.newdate, b1.DIFFIRENT,
            // b2.LF005, b2.SLNHAP, b2.SLXUAT
            dgv_.AutoGenerateColumns = true;
            dgv_.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv_.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dgv_.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_.AllowUserToAddRows = false;
            dgv_.ReadOnly = true;
            dgv_.Columns[0].HeaderCell.Value = "Row";
            dgv_.Columns[1].HeaderCell.Value = "Code";
            dgv_.Columns[2].HeaderCell.Value = "Days of Expiry";
            dgv_.Columns[3].HeaderCell.Value = "Lot";
            dgv_.Columns[4].HeaderCell.Value = "Update Date";
            dgv_.Columns[5].HeaderCell.Value = "CT Type";
            dgv_.Columns[6].HeaderCell.Value = "CT Code";
           // dgv_.Columns[6].HeaderCell.Value = "Check Date";
            dgv_.Columns[7].HeaderCell.Value = "STATUS";
            dgv_.Columns[8].HeaderCell.Value = "Expiry Date";
            dgv_.Columns[9].HeaderCell.Value = "Date Diff";
            dgv_.Columns[10].HeaderCell.Value = "Warehouse Code";
            dgv_.Columns[11].HeaderCell.Value = "Stock Qty";
           // dgv_.Columns[12].HeaderCell.Value = "Export Qty";
            for (int i = 0; i < dgv_.RowCount; i++)
            {
                if (dgv_.Rows[i].Cells["STATUS"].Value.ToString() == "NG")
                    dgv_.Rows[i].Cells["STATUS"].Style.BackColor = Color.Red;
                else if (dgv_.Rows[i].Cells["STATUS"].Value.ToString() == "ALARM")
                    dgv_.Rows[i].Cells["STATUS"].Style.BackColor = Color.Yellow;
                //  dgv_.Rows[i].DefaultCellStyle.BackColor = Color.Yellow;
            }
        }
        private void btn_save_Click(object sender, EventArgs e)
        {
            if (dgv_show.RowCount > 0)
            {
                string pathsave = "";
                try
                {

                    FolderBrowserDialog fl = new FolderBrowserDialog();
                    fl.SelectedPath = "d:\\";
                    fl.ShowNewFolderButton = true;
                    if (fl.ShowDialog() == DialogResult.OK)
                    {
                        pathsave = fl.SelectedPath;
                    }
                    exportExcel(dgv_show, pathsave, "CheckMaterial_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx");
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }
            }
        }
        void exportExcel(DataGridView dataGrid, string pathSaveExcel, string filename)
        {
            try
            {
                Excel.Application excelApp = new Excel.Application();
                excelApp.Workbooks.Add();
                Excel.Worksheet ws = excelApp.ActiveSheet;


                for (int k = 0; k <= dataGrid.ColumnCount - 1; k++)
                {
                    string cell = dataGrid.Columns[k].HeaderText;
                    ws.Cells[1, k + 1] = cell;
                }

                for (int i = 0; i < dataGrid.Rows.Count; i++)
                {
                    for (int j = 0; j < dataGrid.Columns.Count; j++)
                    {
                        if (dataGrid[j, i].Value != null)

                            ws.Cells[(i + 2), (j + 1)] = dataGrid[j, i].Value.ToString();
                        if (dataGrid.Rows[i].Cells["STATUS"].Value.ToString() == "NG")
                            ws.Cells[i + 2, 8].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        else if (dataGrid.Rows[i].Cells["STATUS"].Value.ToString() == "ALARM")
                            ws.Cells[i + 2, 8].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                    }
                }
                excelApp.Visible = true;

                ws.SaveAs(pathSaveExcel + @"\" + filename + ".xlsx");
                MessageBox.Show("Export to excel sucessful !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show("Export to excel fail: " + ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void dtp_from_ValueChanged(object sender, EventArgs e)
        {

        }

        private void CheckMaterial_Load(object sender, EventArgs e)
        {
            string sql = "select distinct LF005 from INVLF";
            sqlERPCON sqlcon = new sqlERPCON();
            sqlcon.getComboBoxData(sql.ToString(), ref cmb_warehousecode);

        }
    }
}

