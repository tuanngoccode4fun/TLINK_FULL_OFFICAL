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
    public partial class ShipmentTypeSelectWin : CommonFormMetro
    {
        public int SelectedIndex = -1;
        public static DataRow dtRowSelected = null;
        public ShipmentTypeSelectWin()
        {
            InitializeComponent();
        }

        private void dtgv_ShipmentSelect_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                if (dtgv_ShipmentSelect.Columns[e.ColumnIndex].Name == "checkbox" && SelectedIndex != e.RowIndex)
                {
                    try
                    {

                        if (SelectedIndex > -1)
                            dtgv_ShipmentSelect.Rows[SelectedIndex].Cells["checkbox"].Value = false;

                        dtgv_ShipmentSelect.Rows[e.RowIndex].Cells["checkbox"].Value = true;
                        SelectedIndex = e.RowIndex;
                    }
                    catch (Exception ex)
                    {

                        SystemLog.Output(SystemLog.MSG_TYPE.Err, "dtgv_BuyerInfor_CellContentClick", ex.Message);
                    }
                }

            }
        }

        private void dtgv_ShipmentSelect_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgv_ShipmentSelect.AllowUserToAddRows = false;
            DatagridviewSetting.settingDatagridview(dtgv_ShipmentSelect);
            
        }

        private void btn_Comfirm_Click(object sender, EventArgs e)
        {
            if (SelectedIndex > -1)
            {
                dtRowSelected = ((DataRowView)dtgv_ShipmentSelect.Rows[SelectedIndex].DataBoundItem).Row;

                this.Close();
            }
            else
            {
                MessageBox.Show("Please select shipment type for delivery ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShipmentTypeSelectWin_Load(object sender, EventArgs e)
        {
            Database.ERPSOFT.t_TL_Shipment t_TL_Shipment = new Database.ERPSOFT.t_TL_Shipment();
            DataTable dt = t_TL_Shipment.GetAllDataTable();
            dtgv_ShipmentSelect.DataSource = dt;
            DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
            checkBoxCell.Name = "checkbox";
            checkBoxCell.HeaderText = "Select";
            checkBoxCell.DisplayIndex = 0;
            dtgv_ShipmentSelect.Columns.Add(checkBoxCell);
        }
    }
}
