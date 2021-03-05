using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.WMS.View
{
    public partial class PrintQRCodeLabel : Form
    {
        DataTable dtwarehouseInfor;
        public PrintQRCodeLabel()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void xuiSuperButton1_Click(object sender, EventArgs e)
        {
            CustomsDeclarasion.Controller.ReadExcelFile readExcelFile = new CustomsDeclarasion.Controller.ReadExcelFile();
            dtwarehouseInfor = readExcelFile.GetDataFromExcelWarehouseStock(txt_linkFile.Text);
            dtgv_WarehouseInfor.DataSource = dtwarehouseInfor;
        }

        private void xuiSuperButton3_Click(object sender, EventArgs e)
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

        private void dtgv_WarehouseInfor_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_WarehouseInfor);
            dtgv_WarehouseInfor.AllowUserToAddRows = false;
        }

        private void dtgv_WarehouseInfor_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >= 0 )
            {
                string material = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                string Unit = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                string Lot = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                string ExpiryDate = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                string Position = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
                string Quantity = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[11].Value.ToString().Trim();
                string PO = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[12].Value.ToString().Trim();
                txt_itemsName.Text = material;
                lb_unit.Text = Unit;
                txt_Lot.Text = Lot;
                if (Quantity != "")
                    nmr_Quantity.Value = decimal.Parse(Quantity);
                if (ExpiryDate != "")
                    dtpk_ImportDate.Value = DateTime.ParseExact(ExpiryDate,"dd/MM/yyyy", CultureInfo.CurrentCulture);
            }
        }

        private void dtgv_WarehouseInfor_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                string material = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                string Unit = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[3].Value.ToString().Trim();
                string Lot = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[4].Value.ToString().Trim();
                string ExpiryDate = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[5].Value.ToString().Trim();
                string location = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[7].Value.ToString().Trim();
                string Quantity = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[11].Value.ToString().Trim();
                string PO = dtgv_WarehouseInfor.Rows[e.RowIndex].Cells[12].Value.ToString().Trim();
                txt_itemsName.Text = material;
                lb_unit.Text = Unit;
                txt_Lot.Text = Lot;
                txt_location.Text = location;
                if (Quantity != "")
                    nmr_Quantity.Value = decimal.Parse(Quantity);
                else nmr_Quantity.Value = 0;
                if (ExpiryDate != "")
                    dtpk_expiryDate.Value = DateTime.ParseExact(ExpiryDate, "dd/MM/yyyy", CultureInfo.CurrentCulture);
                else dtpk_expiryDate.Value = DateTime.Now;
            }
        }

        private void xuiSuperButton2_Click(object sender, EventArgs e)
        {
            Model.WarehouseInfor wInfor = new Model.WarehouseInfor();
            wInfor.Material = txt_itemsName.Text;
            wInfor.Lot = txt_Lot.Text;
            wInfor.quantity = nmr_Quantity.Value;
            wInfor.Unit = lb_unit.Text;
            wInfor.Warehouse = "B05";
            wInfor.locationOrigin = txt_location.Text;
            wInfor.ImportDate = dtpk_ImportDate.Value;
            wInfor.expiryDate = dtpk_expiryDate.Value;
            Device.Printer.PritingLabel pritingLabel = new Device.Printer.PritingLabel();
            pritingLabel.PrintQRCodeWarehouse(wInfor);
        }
    }
}
