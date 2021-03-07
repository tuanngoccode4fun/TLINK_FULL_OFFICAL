using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace WindowsFormsApplication1.CustomsDeclarasion.View
{
    public partial class SelectBuyerWin : CommonFormMetro
    {
        public int SelectedIndex = -1;
        public static DataRow dtRowSelected = null;
        public SelectBuyerWin()
        {
            InitializeComponent();
        }

        private void dtgv_buyerSelect_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgv_buyerSelect.AllowUserToAddRows = false;
            DatagridviewSetting.settingDatagridview(dtgv_buyerSelect);
        }

        private void SelectBuyerWin_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            Database.ERPSOFT.t_TL_BuyerInfor t_TL_BuyerInfor = new Database.ERPSOFT.t_TL_BuyerInfor();
            dt = t_TL_BuyerInfor.GetAllDataTable();
            dtgv_buyerSelect.DataSource = dt;
            DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
            checkBoxCell.Name = "checkbox";
            checkBoxCell.HeaderText = "Select";
            checkBoxCell.DisplayIndex = 0;
            dtgv_buyerSelect.Columns.Add(checkBoxCell);
        }

        private void dtgv_buyerSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                if (dtgv_buyerSelect.Columns[e.ColumnIndex].Name == "checkbox" && SelectedIndex!= e.RowIndex)
                {
                    try
                    {

                        if (SelectedIndex > -1)
                            dtgv_buyerSelect.Rows[SelectedIndex].Cells["checkbox"].Value = false;
                       
                        dtgv_buyerSelect.Rows[e.RowIndex].Cells["checkbox"].Value = true;
                        SelectedIndex = e.RowIndex;
                    }
                    catch (Exception ex)
                    {

                        SystemLog.Output(SystemLog.MSG_TYPE.Err, "dtgv_BuyerInfor_CellContentClick", ex.Message);
                    }
                }

            }
        }

        private void btn_Comfirm_Click(object sender, EventArgs e)
        {
            if(SelectedIndex > -1)
            {
                dtRowSelected =((DataRowView) dtgv_buyerSelect.Rows[SelectedIndex].DataBoundItem).Row;
               
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select buyer for delivery ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
