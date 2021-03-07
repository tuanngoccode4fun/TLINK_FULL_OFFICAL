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
    public partial class ShipmentInformation : Form
    {
        public int OrderSelected = -1;
        public ShipmentInformation()
        {
            InitializeComponent();
            cb_shipmentType.Items.Add("BY AIR");
            cb_shipmentType.Items.Add("BY SEA");
            cb_shipmentType.SelectedIndex = -1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {   OrderSelected = -1;
            dtgv_ShipmentInfor.Columns.Clear();
            Database.ERPSOFT.t_TL_Shipment t_TL_Shipment = new Database.ERPSOFT.t_TL_Shipment();
            var insertRow = t_TL_Shipment.InsertRowTableBuyerInfor(txt_ShipmentCode.Text.Trim(), cb_shipmentType.SelectedItem.ToString().Trim(), 
                txt_departurePort.Text.Trim(), txt_DestinationPort.Text.Trim());
            DataTable dtData = t_TL_Shipment.GetAllDataTable();
            dtgv_ShipmentInfor.DataSource = dtData;
            DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
            checkBoxCell.Name = "checkbox";
            checkBoxCell.HeaderText = "Select";
            checkBoxCell.DisplayIndex = 0;
            dtgv_ShipmentInfor.Columns.Add(checkBoxCell);
        }

        private void dtgv_ShipmentInfor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                if (dtgv_ShipmentInfor.Columns[e.ColumnIndex].Name == "checkbox" && OrderSelected != e.RowIndex)
                {
                    try
                    {

                        if (OrderSelected > -1)
                            dtgv_ShipmentInfor.Rows[OrderSelected].Cells["checkbox"].Value = false;
                        txt_ShipmentCode.Text = dtgv_ShipmentInfor.Rows[e.RowIndex].Cells["ShipmentCode"].Value.ToString().Trim();
                        cb_shipmentType.SelectedItem = dtgv_ShipmentInfor.Rows[e.RowIndex].Cells["ShipmentType"].Value.ToString().Trim();
                        txt_departurePort.Text = dtgv_ShipmentInfor.Rows[e.RowIndex].Cells["ShipmentInfor1"].Value.ToString().Trim();
                        txt_DestinationPort.Text = dtgv_ShipmentInfor.Rows[e.RowIndex].Cells["ShipmentInfor2"].Value.ToString().Trim();
                        dtgv_ShipmentInfor.Rows[e.RowIndex].Cells["checkbox"].Value = true;
                        OrderSelected = e.RowIndex;
                    }
                    catch (Exception ex)
                    {

                        SystemLog.Output(SystemLog.MSG_TYPE.Err, "dtgv_BuyerInfor_CellContentClick", ex.Message);
                    }
                }

            }
        }

        private void dtgv_ShipmentInfor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgv_ShipmentInfor.AllowUserToAddRows = false;
            DatagridviewSetting.settingDatagridview(dtgv_ShipmentInfor);
        }

        private void ShipmentInformation_Load(object sender, EventArgs e)
        {
            LoadDataInformation();
        }
        private void LoadDataInformation()
        {
            OrderSelected = -1;
            dtgv_ShipmentInfor.Columns.Clear();
            Database.ERPSOFT.t_TL_Shipment t_TL_Shipment = new Database.ERPSOFT.t_TL_Shipment();
            DataTable dtData = t_TL_Shipment.GetAllDataTable();
            dtgv_ShipmentInfor.DataSource = dtData;
            DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
            checkBoxCell.Name = "checkbox";
            checkBoxCell.HeaderText = "Select";
            checkBoxCell.DisplayIndex = 0;
            dtgv_ShipmentInfor.Columns.Add(checkBoxCell);
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if( txt_ShipmentCode.Text.Trim() != "")
            {
                try
                {


                    DataTable dt = new DataTable();
                    Database.ERPSOFT.t_TL_Shipment t_TL_Shipment = new Database.ERPSOFT.t_TL_Shipment();
                    dt = t_TL_Shipment.GetTop1Table();
                    dt.Rows[0]["ShipmentCode"] = txt_ShipmentCode.Text.Trim();
                    dt.Rows[0]["ShipmentType"] = cb_shipmentType.SelectedItem.ToString().Trim();
                    dt.Rows[0]["ShipmentInfor1"] = txt_departurePort.Text.Trim();
                    dt.Rows[0]["ShipmentInfor2"] = txt_DestinationPort.Text.Trim();
                    var updateResult = t_TL_Shipment.UpdateBuyerInfor(dt);
                    if (updateResult)
                    {
                        LoadDataInformation();
                    }
                }
                catch (Exception ex)
                {

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "update parameter of buyer fail", ex.Message);
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var mesResult = MessageBox.Show("Do you want to delete this shipment code: " + txt_ShipmentCode.Text.Trim() + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (mesResult == DialogResult.Yes)
            {
                Database.ERPSOFT.t_TL_Shipment t_TL_Shipment = new Database.ERPSOFT.t_TL_Shipment();
                var deleteResult = t_TL_Shipment.DeleteRowby(txt_ShipmentCode.Text.Trim());
                if (deleteResult)
                {
                    LoadDataInformation();
                    MessageBox.Show("you deleted sucessful", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("you deleted fail", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            OrderSelected = -1;
            dtgv_ShipmentInfor.Columns.Clear();
            Database.ERPSOFT.t_TL_Shipment t_TL_Shipment = new Database.ERPSOFT.t_TL_Shipment();
            DataTable dtData = t_TL_Shipment.GetdatabyTextSearch(txt_ShipmentSearch.Text.Trim());
            dtgv_ShipmentInfor.DataSource = dtData;
            DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
            checkBoxCell.Name = "checkbox";
            checkBoxCell.HeaderText = "Select";
            checkBoxCell.DisplayIndex = 0;
            dtgv_ShipmentInfor.Columns.Add(checkBoxCell);
        }
    }
}
