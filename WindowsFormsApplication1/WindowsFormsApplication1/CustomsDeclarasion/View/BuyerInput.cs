using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
namespace WindowsFormsApplication1.CustomsDeclarasion.View
{
    public partial class BuyerInput : Form
    {
        public int OrderSelected = -1;
        public BuyerInput()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            OrderSelected = -1;
            dtgv_BuyerInfor.Columns.Clear();
            Database.ERPSOFT.t_TL_BuyerInfor BuyerInfor = new Database.ERPSOFT.t_TL_BuyerInfor();
        var insertRow =    BuyerInfor.InsertRowTableBuyerInfor(txt_BuyerCode.Text.Trim(), txt_BuyerERP.Text.Trim(), txt_buyerInfor.Text.Trim(), txt_buyerConsignee.Text.Trim());
            DataTable dtData = BuyerInfor.GetAllDataTable();
            dtgv_BuyerInfor.DataSource = dtData;
            DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
            checkBoxCell.Name = "checkbox";
            checkBoxCell.HeaderText = "Select";
            checkBoxCell.DisplayIndex = 0;
            dtgv_BuyerInfor.Columns.Add(checkBoxCell);
        }

        private void dtgv_BuyerInfor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgv_BuyerInfor.AllowUserToAddRows = false;
            DatagridviewSetting.settingDatagridview(dtgv_BuyerInfor);
        }

        private void BuyerInput_Load(object sender, EventArgs e)
        {
          
            LoadDataBuyerInformation();
        }

        private void dtgv_BuyerInfor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                if(dtgv_BuyerInfor.Columns[e.ColumnIndex].Name == "checkbox" && OrderSelected  != e.RowIndex )
                {
                    try
                    {

                        if (OrderSelected > -1)
                            dtgv_BuyerInfor.Rows[OrderSelected].Cells["checkbox"].Value = false;
                        txt_BuyerCode.Text = dtgv_BuyerInfor.Rows[e.RowIndex].Cells["BuyerCode"].Value.ToString().Trim();
                        txt_BuyerERP.Text = dtgv_BuyerInfor.Rows[e.RowIndex].Cells["Buyer_ERP"].Value.ToString().Trim();
                        txt_buyerInfor.Text = dtgv_BuyerInfor.Rows[e.RowIndex].Cells["Buyer_Infor"].Value.ToString().Trim();
                        txt_buyerConsignee.Text = dtgv_BuyerInfor.Rows[e.RowIndex].Cells["Buyer_Consignee"].Value.ToString().Trim();
                        dtgv_BuyerInfor.Rows[e.RowIndex].Cells["checkbox"].Value = true;
                        OrderSelected = e.RowIndex;
                    }
                    catch (Exception ex)
                    {

                        SystemLog.Output(SystemLog.MSG_TYPE.Err, "dtgv_BuyerInfor_CellContentClick", ex.Message);
                    }
                }

            }

        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (txt_BuyerCode.Text.Trim() != "")
            {
                try
                {

              
                DataTable dt = new DataTable();
                Database.ERPSOFT.t_TL_BuyerInfor buyerInfor = new Database.ERPSOFT.t_TL_BuyerInfor();
                dt = buyerInfor.GetTop1Table();
                dt.Rows[0]["BuyerCode"] = txt_BuyerCode.Text.Trim();
                dt.Rows[0]["Buyer_ERP"] = txt_BuyerERP.Text.Trim();
                dt.Rows[0]["Buyer_Infor"] = txt_buyerInfor.Text.Trim();
                dt.Rows[0]["Buyer_Consignee"] = txt_buyerConsignee.Text.Trim();
                    var updateResult = buyerInfor.UpdateBuyerInfor(dt);
                    if(updateResult)
                    {
                        LoadDataBuyerInformation();
                    }
                }
                catch (Exception ex)
                {

                    SystemLog.Output(SystemLog.MSG_TYPE.Err, "update parameter of buyer fail", ex.Message);
                }

            }

        }
        private void LoadDataBuyerInformation()
        {
            OrderSelected = -1;
            dtgv_BuyerInfor.Columns.Clear();
            Database.ERPSOFT.t_TL_BuyerInfor BuyerInfor = new Database.ERPSOFT.t_TL_BuyerInfor();
            DataTable dtData = BuyerInfor.GetAllDataTable();
            dtgv_BuyerInfor.DataSource = dtData;
            DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
            checkBoxCell.Name = "checkbox";
            checkBoxCell.HeaderText = "Select";
            checkBoxCell.DisplayIndex = 0;
            dtgv_BuyerInfor.Columns.Add(checkBoxCell);
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var mesResult = MessageBox.Show("Do you want to delete this buyer: " + txt_BuyerCode.Text.Trim() + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (mesResult == DialogResult.Yes)
            {
                Database.ERPSOFT.t_TL_BuyerInfor buyerInfor = new Database.ERPSOFT.t_TL_BuyerInfor();
                var deleteResult = buyerInfor.DeleteRowbyBuyer(txt_BuyerCode.Text.Trim());
                if (deleteResult)
                {
                    LoadDataBuyerInformation();
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
            dtgv_BuyerInfor.Columns.Clear();
            Database.ERPSOFT.t_TL_BuyerInfor BuyerInfor = new Database.ERPSOFT.t_TL_BuyerInfor();
            DataTable dtData = BuyerInfor.GetdatabyTextSearch(txt_BuyerSearch.Text.Trim());
            dtgv_BuyerInfor.DataSource = dtData;
            DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
            checkBoxCell.Name = "checkbox";
            checkBoxCell.HeaderText = "Select";
            checkBoxCell.DisplayIndex = 0;
            dtgv_BuyerInfor.Columns.Add(checkBoxCell);
        }
    }
}
