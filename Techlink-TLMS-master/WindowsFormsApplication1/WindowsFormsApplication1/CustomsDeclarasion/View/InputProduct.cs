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
    public partial class InputProduct : Form
    {
        public DataTable dtProductInfo;
        public int OrderSelected = -1;
        public InputProduct()
        {
            InitializeComponent();
            lbl_Header.Text = "Input Informations of Product";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
            t_TL_Product.InsertProductInforToDBbymodel(txt_productSearch.Text);
                 
        }

        private void InputProduct_Load(object sender, EventArgs e)
        {
            dtgv_ProductInfor.DataSource = null;
            dtgv_ProductInfor.Columns.Clear();
            Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
            dtProductInfo = t_TL_Product.GetdataProduct();
            dtgv_ProductInfor.DataSource = dtProductInfo;

            DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
            checkBoxCell.Name = "checkbox";
            checkBoxCell.HeaderText = "Select";
            checkBoxCell.DisplayIndex = 0;
            dtgv_ProductInfor.Columns.Add(checkBoxCell);
        }

        private void dtgv_ProductInfor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            dtgv_ProductInfor.AllowUserToAddRows = false;
            DatagridviewSetting.settingDatagridview(dtgv_ProductInfor);
            
            
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            OrderSelected = -1;
            dtgv_ProductInfor.DataSource = null;
            dtgv_ProductInfor.Columns.Clear();
            Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
            dtProductInfo = t_TL_Product.GetdataProduct(txt_productSearch.Text.Trim());
            dtgv_ProductInfor.DataSource = dtProductInfo;

            DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
            checkBoxCell.Name = "checkbox";
            checkBoxCell.HeaderText = "Select";
            checkBoxCell.DisplayIndex = 0;
            dtgv_ProductInfor.Columns.Add(checkBoxCell);

        }

        private void dtgv_ProductInfor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                if (dtgv_ProductInfor.Columns[e.ColumnIndex].Name == "checkbox" && OrderSelected != e.RowIndex)
                {
                    try
                    {
                        if (OrderSelected > -1)
                            dtgv_ProductInfor.Rows[OrderSelected].Cells["checkbox"].Value = false;
                        var strTemp = dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB001"].Value.ToString();
                      
                        txt_productName.Text = dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB001"].Value.ToString();
                      //  var te = dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB004"].Value as DBNull;
                        //var test = (string)dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB004"].Value;
                        txt_description.Text = dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB004"].Value != DBNull.Value ? (string)dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB004"].Value : "";
                        nmr_QtyCarton.Value = dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB005"].Value != DBNull.Value ? (decimal)dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB005"].Value : 0;
                        txt_DimensionCarton.Text = dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB006"].Value != DBNull.Value ? (string)dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB006"].Value : "";
                        nmr_weightofCarton.Value = dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB007"].Value != DBNull.Value ? (decimal)dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB007"].Value : 0;
                        txt_DimensionOfPallet.Text = dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB008"].Value != DBNull.Value ? (string)dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB008"].Value : "";
                        nmr_weightofPallet.Value = dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB009"].Value != DBNull.Value ? (decimal)dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB009"].Value : 0;
                        nmr_SplintWeight.Value = dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB010"].Value != DBNull.Value ? (decimal)dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB010"].Value : 0;
                        nmr_CartonPallet.Value = dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB011"].Value != DBNull.Value ? (decimal)dtgv_ProductInfor.Rows[e.RowIndex].Cells["MB011"].Value : 0;
                        dtgv_ProductInfor.Rows[e.RowIndex].Cells["checkbox"].Value = true;
                        OrderSelected = e.RowIndex;

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Input data wrong format", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }

            }
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = new DataTable();
                Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
                dt = t_TL_Product.GetTop1Table();

                dt.Rows[0]["MB001"] = txt_productName.Text.Trim();
                dt.Rows[0]["MB004"] = txt_description.Text.Trim();
                dt.Rows[0]["MB005"] = nmr_QtyCarton.Value;
                dt.Rows[0]["MB006"] = txt_DimensionCarton.Text.Trim();
                dt.Rows[0]["MB007"] = nmr_weightofCarton.Value;
                dt.Rows[0]["MB008"] = txt_DimensionOfPallet.Text.Trim();
                dt.Rows[0]["MB009"] = nmr_weightofPallet.Value;
                dt.Rows[0]["MB010"] = nmr_SplintWeight.Value;
                dt.Rows[0]["MB011"] = nmr_CartonPallet.Value;
             //   dt.Rows[0]["MB011"] = nmr_SplintQty.Value;
                var updateResult = t_TL_Product.UpdateProductInfor(dt);
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Update parameter of product fail", ex.Message);
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            var mesResult = MessageBox.Show("Do you want to delete this product: " + txt_productName.Text.Trim() + " ?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if(mesResult == DialogResult.Yes)
            {
                Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
                var deleteResult = t_TL_Product.DeleteRowbyProduct(txt_productName.Text.Trim());

            }
            
        }
    }
}
