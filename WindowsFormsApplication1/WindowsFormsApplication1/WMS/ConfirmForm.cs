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
using WindowsFormsApplication1.WMS.Model;

namespace WindowsFormsApplication1.WMS
{
    public partial class ConfirmForm : CommonFormMetro
    {
        List<Model.LotINVMEMF> _lotINVMEMFs = new List<Model.LotINVMEMF>();
        List<Model.LotINVMEMF> LotAdjust = new List<Model.LotINVMEMF>();
        string _QRcode = "";
        string _STT = "";
        public ConfirmForm(string QRCode, string STT,List<Model.LotINVMEMF> lotINVMEMFs)
        {
            InitializeComponent();
            _lotINVMEMFs = lotINVMEMFs;
            _QRcode = QRCode;
            _STT = STT;
        }
        private void MakeUpDatagridChooseLot(DataGridView gridView)
        {

            gridView.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);

            gridView.BackgroundColor = Color.LightSteelBlue;
            gridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            gridView.Columns["checkbox"].HeaderText = "Choose";

            gridView.Columns["STT"].HeaderText = "No";
            gridView.Columns["MF001_Sp"].HeaderText = "Product";
            gridView.Columns["MF002_Lot"].HeaderText = "Lot";
            gridView.Columns["MF007_kho"].HeaderText = "Warehouse";
            gridView.Columns["MF002_Location"].HeaderText = "Location";
            gridView.Columns["SL_TrongKho"].HeaderText = "Stock (Qty)";
            gridView.Columns["SL_TrongKho"].DefaultCellStyle.Format = "N2";
            gridView.Columns["SL"].HeaderText = "Picking Quantity";
            gridView.Columns["SL"].DefaultCellStyle.Format = "N2";
            gridView.Columns["ME003_ImportDate"].HeaderText = "Import Date";
            gridView.Columns["ME009_ExpiryDate"].HeaderText = "Expiry Date";

            gridView.Columns["MF001_Sp"].ReadOnly = true;
            gridView.Columns["MF002_Lot"].ReadOnly = true;
            gridView.Columns["MF007_kho"].ReadOnly = true;
            gridView.Columns["SL_TrongKho"].ReadOnly = true;
            gridView.Columns["MF002_Location"].ReadOnly = true;

            gridView.Columns["ME003_ImportDate"].ReadOnly = true;
            gridView.Columns["ME009_ExpiryDate"].ReadOnly = true;

            gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

          

        }
        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            LotAdjust = new List<Model.LotINVMEMF>();
            for (int i = 0; i < dtgv_display.Rows.Count; i++)
            {
                if(dtgv_display.Rows[i].Cells[0].Value != null && dtgv_display.Rows[i].Cells[0].Value.ToString() == "True")
                {
                    Model.LotINVMEMF lotINVMEMF = new Model.LotINVMEMF();
                    lotINVMEMF.MF001_Sp = dtgv_display.Rows[i].Cells["MF001_Sp"].Value.ToString();
                    lotINVMEMF.MF002_Lot = dtgv_display.Rows[i].Cells["MF002_Lot"].Value.ToString();
                    lotINVMEMF.MF007_kho = dtgv_display.Rows[i].Cells["MF007_kho"].Value.ToString();
                    lotINVMEMF.MF002_Location = dtgv_display.Rows[i].Cells["MF002_Location"].Value.ToString();
                    lotINVMEMF.SL = double.Parse(dtgv_display.Rows[i].Cells["SL"].Value.ToString());
                    string date = dtgv_display.Rows[i].Cells["ME003_ImportDate"].Value.ToString();
                    try
                    {
                        lotINVMEMF.ME003_ImportDate = (DateTime.ParseExact(dtgv_display.Rows[i].Cells["ME003_ImportDate"].Value.ToString().Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture));
                        lotINVMEMF.ME009_ExpiryDate = (DateTime.ParseExact(dtgv_display.Rows[i].Cells["ME009_ExpiryDate"].Value.ToString().Substring(0, 10), "dd/MM/yyyy", CultureInfo.InvariantCulture));
                    }
                    catch (Exception ex)
                    {
                        lotINVMEMF.ME003_ImportDate = (DateTime)dtgv_display.Rows[i].Cells["ME003_ImportDate"].Value;
                        lotINVMEMF.ME009_ExpiryDate = (DateTime)dtgv_display.Rows[i].Cells["ME009_ExpiryDate"].Value;
                        SystemLog.Output(SystemLog.MSG_TYPE.Err, "convert to datetime is not correct format", ex.Message);
                    }
                  


                    LotAdjust.Add(lotINVMEMF);
                }
            }
            if (LotAdjust.Count > 0)
            {
                DBOperation dBOperation = new DBOperation();
                dBOperation.UpdateStockOutERPForm(_QRcode, _STT, LotAdjust);
           }
            this.Close();
        }

      

        private void Dtgv_display_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;

            if (RowIndex >= 0 && ColumnsIndex >=0)
            {
                if (dtgv_display.Columns[ColumnsIndex].Name == "MF002_Location")
                {
                    DBOperation dBOperation = new DBOperation();
                    string sp = dtgv_display.Rows[e.RowIndex].Cells["MF001_Sp"].Value.ToString();
                    string kho = dtgv_display.Rows[e.RowIndex].Cells["MF007_kho"].Value.ToString();
                    string lot = dtgv_display.Rows[e.RowIndex].Cells["MF002_Lot"].Value.ToString();
                    List<INVLF_Locate> iNVLF_Locates = new List<INVLF_Locate>();
                    iNVLF_Locates = dBOperation.GetLocationofLot(sp, kho, lot);
                    PickingLocation pickingLocation = new PickingLocation(_QRcode,_STT,iNVLF_Locates);

                    pickingLocation.Show();

                }

            }

        }

    

        private void ConfirmForm_Load(object sender, EventArgs e)
        {
            dtgv_display.DataSource = _lotINVMEMFs;
            MakeUpDatagridChooseLot(dtgv_display);

            for (int i = 0; i < dtgv_display.Rows.Count; i++)
            {
                var date = (DateTime)dtgv_display.Rows[i].Cells["ME009_ExpiryDate"].Value;
                if (date < DateTime.Now)
                {
                    dtgv_display.Rows[i].ReadOnly = true;
                    dtgv_display.Rows[i].Frozen = true;

                    dtgv_display.Rows[i].Cells["ME009_ExpiryDate"].Style.BackColor = Color.Red;
                      dtgv_display.Rows[i].DefaultCellStyle.BackColor = Color.LightGray;


                }

            }
        }

        private void Dtgv_display_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >=0)
            {
                if (dtgv_display.Columns[e.ColumnIndex].Name == "SL")
                {
                    try
                    {
                        if ((double)dtgv_display.Rows[e.RowIndex].Cells[e.ColumnIndex].Value > (double)dtgv_display.Rows[e.RowIndex].Cells["SL_TrongKho"].Value)
                        {
                            MessageBox.Show("Transfer quantity less than or equal to stock quantity ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dtgv_display.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtgv_display.Rows[e.RowIndex].Cells["SL_TrongKho"].Value;
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Input data wrong format", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            else    if (dtgv_display.Columns[e.ColumnIndex].Name == "checkbox")
                {
                    try
                    {
                        if ((double)dtgv_display.Rows[e.RowIndex].Cells["SL"].Value > (double)dtgv_display.Rows[e.RowIndex].Cells["SL_TrongKho"].Value)
                        {
                            MessageBox.Show("Transfer quantity less than or equal to stock quantity ", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            dtgv_display.Rows[e.RowIndex].Cells["SL"].Value = dtgv_display.Rows[e.RowIndex].Cells["SL_TrongKho"].Value;
                        }
                    }
                    catch (Exception)
                    {

                        MessageBox.Show("Input data wrong format", "warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
        }
    }
}
