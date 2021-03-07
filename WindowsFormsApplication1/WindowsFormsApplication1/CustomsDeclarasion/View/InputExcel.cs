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
    public partial class InputExcel : Form
    {
        public DataTable dtProductInfo;
        public InputExcel()
        {
            InitializeComponent();
        }


        private void btn_link_Click(object sender, EventArgs e)
        {
            string pathsave = "";
            System.Windows.Forms.OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Title = "Browse Excel Files";
            openFileDialog.DefaultExt = "Excel";
            openFileDialog.Filter = "Excel Files| *.xls; *.xlsx; *.xlsm";

            openFileDialog.CheckPathExists = true;


            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pathsave = openFileDialog.FileName;
                txt_linkFile.Text = pathsave;

            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            Controller.ReadExcelFile readExcelFile = new Controller.ReadExcelFile();
        dtProductInfo =    readExcelFile.GetDataFromExcel(txt_linkFile.Text);
            dtgv_ProductInfor.DataSource = dtProductInfo;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtgv_ProductInfor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_ProductInfor);
            dtgv_ProductInfor.AllowUserToAddRows = false;
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {if (dtProductInfo.Rows.Count > 0)
            {
                Database.ERPSOFT.t_TL_Product t_TL_Product = new Database.ERPSOFT.t_TL_Product();
              var update =  t_TL_Product.UpdateDataFromExcel(dtProductInfo);
            }


        }
    }
}
