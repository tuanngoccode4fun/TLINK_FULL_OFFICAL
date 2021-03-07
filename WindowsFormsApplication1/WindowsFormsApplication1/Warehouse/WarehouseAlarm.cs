using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace WindowsFormsApplication1.Warehouse
{
    public partial class WarehouseAlarm : CommonForm
    {
        public WarehouseAlarm()
        {
            InitializeComponent();
        }

        private void WarehouseAlarm_Load(object sender, EventArgs e)
        {
            string sql = @"select distinct C.MC002
from INVMC C
LEFT JOIN INVMB B ON C.MC001 = B.MB002
WHERE C.MC004 != 0 AND(C.MC002 LIKE 'D%' OR  C.MC002 LIKE 'B%')";
            sqlERPCON sqlcon = new sqlERPCON();
            sqlcon.getComboBoxData(sql.ToString(), ref cmb_warehouseno);

            nation();
        }
        void nation()
        {
            cmb_nation.Items.Clear();
            string sql = "select distinct MR004 from CMSMR";
            sqlERPCON sqlcon = new sqlERPCON();
            sqlcon.getComboBoxData(sql.ToString(), ref cmb_nation);

        }
       
        private void btn_search_Click(object sender, EventArgs e)
        {
            StringBuilder sql = new StringBuilder();
            sql.Append(@"select a.Row, a.TENKHO, a.MANVL, a.TENSP, a.QUYCACH, a.DVTONKHO, a.SLANTOAN, a.SLTONKHO,a.CHENHLECH, substring(cast(a.PHANTRAM as varchar(100)),0,5) as PHAMTRAM,
a.Status, b.DONXINMUA, CAST(cast(b.NGAYXINMUA as date) as varchar(10)) as NGAYXINMUA, b.SLXINMU, b.DONMUA,cast( b.NGAYMUA as date) as NGAYMUA,b.SLMUA,b.SLCHUAGIAO, cast( b.NgayGiaoHangDK as date) as NgayGiaoHangDK ,
QuocGia
from (
select ROW_NUMBER() OVER(order by ROUND(((C.MC007 - 0) / C.MC004)*100, 3) asc) AS Row,
    C.MC002 AS TENKHO, C.MC001 AS MANVL, B.MB002 AS TENSP,B.MB003 AS QUYCACH,  B.MB004 AS DVTONKHO,  
C.MC004 AS SLANTOAN, C.MC007 AS SLTONKHO, (C.MC007 - C.MC004) AS CHENHLECH, ROUND(((C.MC007 - 0) / C.MC004)*100, 3) as PHANTRAM, 
CASE when   ROUND(((C.MC007 - 0) / C.MC004)*100, 3) > 200 then 'High'
WHEN ROUND(((C.MC007-0)/ C.MC004),3)*100 >= 100 and ROUND(((C.MC007-0)/ C.MC004)*100,3) <= 200 then 'OK'
WHEN ROUND(((C.MC007-0)/ C.MC004),3)*100 < 100 then 'Not Enough' end as 'Status'
from INVMC C
LEFT JOIN INVMB B ON C.MC001 = B.MB001
WHERE C.MC004 != 0 AND(C.MC002 LIKE 'D%' OR  C.MC002 LIKE 'B%')
) as a

left join
(
(select purtb.TB004 as MANVL, purta.TA001 + '-' + purta.TA002 as DONXINMUA, 
purta.TA013 as NGAYXINMUA,
 purtb.TB009 as SLXINMU,
DONMUA = null, 
NGAYMUA = null, 
SLMUA = null,SLCHUAGIAO = null,
NgayGiaoHangDK = null,
QuocGia = null
From PURTA purta
left join PURTB purtb on purta.TA001 = purtb.TB001 and purta.TA002 = purtb.TB002
where 1 = 1
--and TB004 = 'BPJHC55-AIR-FKM'
and purta.TA007 = 'Y' and purtb.TB022 like '' and
purtb.TB039 = 'N')
union all
(select  purtb.TB004 as MANVL, purta.TA001 + '-' + purta.TA002 as DONXINMUA, 
purta.TA013 as NGAYXINMUA,
 purtb.TB009 as SLXINMU,
purtc.TC001 + '-' + purtc.TC002 as DONMUA, 
NGAYMUA = purtc.TC024, 
purtd.TD008 as SLMUA, (purtd.TD008 - purtd.TD015) as SLCHUAGIAO,
purtd.TD012 as NgayGiaoHangDK,
cmsmr.MR004 as QuocGia 
From PURTA purta
left join PURTB purtb on purta.TA001 = purtb.TB001 and purta.TA002 = purtb.TB002
left join PURTD purtd on  purtb.TB022 = (purtd.TD001 + '-' + purtd.TD002 + '-' + purtd.TD003)
left join PURTC purtc on purtc.TC001 = purtd.TD001 and  purtc.TC002 = purtd.TD002
left join PURMA purma on purtc.TC004 = purma.MA001
left join CMSMR cmsmr on cmsmr.MR002 = purma.MA006
where 1 = 1
--and TB004 = 'BPJHC55-AIR-FKM'
and purta.TA007 = 'Y'
and purtd.TD016 = 'N'
and purtc.TC014 = 'Y')
) b on a.MANVL = b.MANVL where 1=1

");

            //  



            if (cmb_warehouseno.Text != "")
            {
                sql.Append(" and TENKHO = '" + cmb_warehouseno.Text + "'");
            }
            if (cmb_status.Text != "")
            {
                sql.Append("and Status = '" + cmb_status.Text + "'");
            }
            if (txt_materialcode.Text != "")
            {
                sql.Append(" and a.MANVL like '%" + txt_materialcode.Text + "%'");
            }
            if(txt_materialname.Text !="")
            {
                sql.Append(" and a.TENSP like '%" + txt_materialname.Text + "%'");
            }
            if (cmb_nation.Text != "")
            {
                sql.Append(" and QuocGia = '"+cmb_nation.Text+"'");
            }
            sql.Append(" order by a.Row");
            DataTable dt = new DataTable();
            sqlERPCON sqlcon = new sqlERPCON();
            sqlcon.sqlDataAdapterFillDatatable(sql.ToString(), ref dt);
            dgv_show.DataSource = dt;
            changeHeaderName(ref dgv_show);
        }
        void changeHeaderName(ref DataGridView dgv_)
        {
            dgv_.AutoGenerateColumns = true;
            dgv_.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dgv_.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dgv_.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgv_.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgv_.AllowUserToAddRows = false;
            dgv_.ReadOnly = true;
            dgv_.Columns[0].HeaderCell.Value = "Row";
            dgv_.Columns[1].HeaderCell.Value = "WH No";
            dgv_.Columns[2].HeaderCell.Value = "Material Code";
            dgv_.Columns[3].HeaderCell.Value = "Material Name";
            dgv_.Columns[4].HeaderCell.Value = "Form";
            dgv_.Columns[5].HeaderCell.Value = "Unit";
            dgv_.Columns[6].HeaderCell.Value = "Tagert No";
            dgv_.Columns[7].HeaderCell.Value = "Actual No";
            dgv_.Columns[8].HeaderCell.Value = "Gap Unit";
            dgv_.Columns[9].HeaderCell.Value = "Gap percent";
            dgv_.Columns[10].HeaderCell.Value = "Status";
            // dgv_.Columns[11].HeaderCell.Value = "Material Code";
            dgv_.Columns[11].HeaderCell.Value = "Order Request Code";
            dgv_.Columns[12].HeaderCell.Value = "Order Request Date";
            dgv_.Columns[13].HeaderCell.Value = "Order Request Qty";
            dgv_.Columns[14].HeaderCell.Value = "Order Code";
            dgv_.Columns[15].HeaderCell.Value = "Order Date";
            dgv_.Columns[16].HeaderCell.Value = "Order Qty";
            dgv_.Columns[17].HeaderCell.Value = "Not Delivered";
            dgv_.Columns[18].HeaderCell.Value = "Client Request Date";
            dgv_.Columns[19].HeaderCell.Value = "Nation";

            for (int i = 0; i < dgv_.RowCount; i++)
            {
                if (dgv_.Rows[i].Cells["Status"].Value.ToString() == "Not Enough")
                    dgv_.Rows[i].Cells["Status"].Style.BackColor = Color.Red;
                else if (dgv_.Rows[i].Cells["Status"].Value.ToString() == "High")
                    dgv_.Rows[i].Cells["Status"].Style.BackColor = Color.Yellow;
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
                    exportExcel(dgv_show, pathsave, "WarehouseAlarm_" + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx");
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
                        if (dataGrid.Rows[i].Cells["Status"].Value.ToString() == "Not Enough")
                            ws.Cells[i + 2, 11].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                        else if (dataGrid.Rows[i].Cells["Status"].Value.ToString() == "High")
                            ws.Cells[i + 2, 11].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
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
        private void cmb_warehouseno_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
