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
    public partial class InputWeight : Form
    {
        public DataTable dtProductInfo;
        public int OrderSelected = -1;
        public InputWeight()
        {
            InitializeComponent();
            lbl_Header.Text = "Input weight parameter of Product";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void InputWeight_Load(object sender, EventArgs e)
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

     
    }
}
