using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.WMS.Model;

namespace WindowsFormsApplication1.WMS
{
    public partial class PickingLocation : CommonFormMetro
    {
        List<INVLF_Locate> iNVLF_Locates = new List<INVLF_Locate>();
        string _QRcode = "";
        string _STT = "";
        public PickingLocation(string QRCode, string STT, List<INVLF_Locate> iNVLF)
        {
            InitializeComponent();
            _QRcode = QRCode;
            _STT = STT;
            iNVLF_Locates = iNVLF;
          
        }
        private void MakeUpDatagridChooseLocation(DataGridView gridView)
        {


            gridView.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);

            gridView.BackgroundColor = Color.LightSteelBlue;
            gridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;

            gridView.Columns["checkbox"].HeaderText = "Choose";
            gridView.Columns["LF004_Sp"].HeaderText = "Product";
            gridView.Columns["LF005_Kho"].HeaderText = "Warehouse";
            gridView.Columns["LF007_Lot"].HeaderText = "Lot";
            gridView.Columns["LF006_Vitri"].HeaderText = "Warehouse";
            gridView.Columns["Quantity"].HeaderText = "Quantity";
            gridView.Columns["Quantity"].DefaultCellStyle.Format = "N2";

            gridView.Columns["LF004_Sp"].ReadOnly = true;
            gridView.Columns["LF005_Kho"].ReadOnly = true;
            gridView.Columns["LF007_Lot"].ReadOnly = true;
            gridView.Columns["LF006_Vitri"].ReadOnly = true;
          

            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
        }

        private void PickingLocation_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (int i = 0; i < dtgv_location.Rows.Count; i++)
            {

            }
        }

        private void PickingLocation_Load(object sender, EventArgs e)
        {
            dtgv_location.DataSource = iNVLF_Locates;
            MakeUpDatagridChooseLocation(dtgv_location);
        }
    }
}
