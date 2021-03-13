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
    public partial class ProductionMaterial : CommonFormMetro
    {
        DataTable dtGet = new DataTable();
        int indexSelected = -1;

        public ProductionMaterial()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            //Class.valiballecommon.GetStorage().DBERP = "TECHLINK";
            //Class.valiballecommon.GetStorage().DBSFT = "SFT_TECHLINK";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if(txt_materialRequest.Text.Length == 12)
            {
               
                dtgv_data.Columns.Clear();
                dtgv_data.DataSource = null;
                Database.MOC.MOCTCTE mOCTCTE = new Database.MOC.MOCTCTE();
                var txtSpilit = txt_materialRequest.Text.Split('-');
                dtGet = mOCTCTE.GetdtMOCTCTE(txtSpilit[0], txtSpilit[1]);
                dtgv_data.DataSource = dtGet;
                DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
                checkBoxCell.Name = "checkbox";
                checkBoxCell.HeaderText = "Scan QR Material";
                checkBoxCell.DisplayIndex = 0;

                dtgv_data.Columns.Insert(0, checkBoxCell);
                DataGridViewCheckBoxColumn checkBoxCell2 = new DataGridViewCheckBoxColumn();
                checkBoxCell2.Name = "checkbox2";
                checkBoxCell2.HeaderText = "Scan QR Location";
                checkBoxCell2.DisplayIndex = 1;

                dtgv_data.Columns.Insert(1, checkBoxCell2);
                DataGridViewTextBoxColumn textBoxColumn = new DataGridViewTextBoxColumn();
                textBoxColumn.Name = "FEFO";
                textBoxColumn.HeaderText = "FEFO";
                textBoxColumn.DisplayIndex = 2;
                dtgv_data.Columns.Insert(1, textBoxColumn);

                for (int i = 0; i < dtgv_data.Rows.Count; i++)
                {
                    string material = dtgv_data.Rows[i].Cells["TE004"].Value.ToString().Trim();
                    string lot = dtgv_data.Rows[i].Cells["TE010"].Value.ToString().Trim();
                    string warehouse = "B05";
                    string IsConfirm = dtgv_data.Rows[i].Cells["TC009"].Value.ToString().Trim();
                    if(IsConfirm == "N")
                    {
                        lb_confirm.Text = "Not yet confirm";
                        lb_confirm.BackColor = Color.LightYellow;
                    }
                    var isFIFO = IscheckFIFO(material, lot, warehouse);
                    if (isFIFO)
                    {
                        dtgv_data.Rows[i].Cells["FEFO"].Value = "FEFO OK";
                        dtgv_data.Rows[i].Cells["FEFO"].Style.BackColor = Color.Green;
                        dtgv_data.Rows[i].ReadOnly = false;
                    }
                    else
                    {
                        dtgv_data.Rows[i].Cells["FEFO"].Value = "FEFO NG";
                        dtgv_data.Rows[i].Cells["FEFO"].Style.BackColor = Color.Red;
                        dtgv_data.Rows[i].ReadOnly = true;
                    }

                }
                txt_QrScanMaterial.Focus();
            }

        }
        public bool IscheckFIFO(string material, string lot, string warehouse)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(@"
select ME009,a.* from INVMM  a
inner join INVME b on ME001 = MM001 and ME002= MM004
where 1=1
");
            stringBuilder.Append(" and  MM002 = '" + warehouse + "' ");
            stringBuilder.Append(" and MM001 = '" + material + "' ");
            stringBuilder.Append(@" AND MM005 > 0
order by CAST(ME009 as datetime) DESC ");
            DataTable dt = new DataTable();
            sqlERPCON sqlERPCON = new sqlERPCON();
            sqlERPCON.sqlDataAdapterFillDatatable(stringBuilder.ToString(), ref dt);
            var dtrow = dt.AsEnumerable().Where(d => d.Field<string>("MM004").Trim() == lot).ToList();
            if (dtrow.Count == 1)
            {
                DateTime dtExpiryRow = DateTime.ParseExact(dtrow[0]["ME009"].ToString(), "yyyyMMdd", CultureInfo.CurrentCulture);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DateTime dtExpiryi = DateTime.ParseExact(dt.Rows[i]["ME009"].ToString(), "yyyyMMdd", CultureInfo.CurrentCulture);
                    if (dtExpiryi < dtExpiryRow)
                        return false;

                }
            }
        
            return true;
        }
        private void dtgv_data_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_data);
            dtgv_data.AllowUserToAddRows = false;
            if(dtgv_data.Rows.Count > 0)
            {
                dtgv_data.Columns["TE001"].Visible = false;
                dtgv_data.Columns["TE002"].Visible = false;
                dtgv_data.Columns["TE003"].HeaderText = "No";
                dtgv_data.Columns["TE004"].HeaderText = "Material";
                dtgv_data.Columns["TE005"].HeaderText = "Quantity";
                dtgv_data.Columns["TE006"].HeaderText = "Unit";
                dtgv_data.Columns["TE007"].Visible = false;
                dtgv_data.Columns["TE008"].HeaderText = "Warehouse";
                dtgv_data.Columns["TE009"].Visible = false;
                dtgv_data.Columns["TE010"].HeaderText = "Lot";
                dtgv_data.Columns["TE011"].HeaderText = "PO Code";
                dtgv_data.Columns["TE012"].HeaderText = "PO No";
                dtgv_data.Columns["TE017"].Visible = false;
                dtgv_data.Columns["TE029"].HeaderText = "Location";
                dtgv_data.Columns["TC009"].HeaderText = "Confirm";


            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        { var spilitChar = txt_QrScanMaterial.Text.Split(';');
            int CountChar = txt_QrScanMaterial.Text.Split(';').Count();
            if(CountChar== 6)
            {
                if(spilitChar[5].Length == 7)
                {
                    string material = spilitChar[1];
                    string lot = spilitChar[2];
                    for (int i = 0; i < dtgv_data.Rows.Count; i++)
                    {
                        string materialCheck = dtgv_data.Rows[i].Cells["TE004"].Value.ToString().Trim();
                        string lotCheck = dtgv_data.Rows[i].Cells["TE010"].Value.ToString().Trim();
                        if ((string)dtgv_data.Rows[i].Cells["FEFO"].Value == "FEFO OK")
                        {
                            if (material == materialCheck && lot == lotCheck)
                            {
                                dtgv_data.Rows[i].Cells["checkbox"].Value = true;
                                indexSelected = i;
                            }
                        }
                        else
                        {
                            MessageBox.Show("You selected Lot FEFO NG, Can't stock out this lot " + lotCheck, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    txt_QrScanMaterial.Focus();

                }
                else if (spilitChar[5].Length == 8)
                {
                    txt_QRScanLocation.Focus();
                }
            }
        }

        private void txt_QRScanLocation_TextChanged(object sender, EventArgs e)
        {
            if (txt_QRScanLocation.Text.EndsWith("e") && txt_QRScanLocation.Text.Length > 2)
            {
                string QRString = txt_QRScanLocation.Text.Substring(1, txt_QRScanLocation.Text.Length - 2);
                var textSplit = QRString.Split(';');
                if (textSplit.Length == 3)
                {
                    if (indexSelected > -1)
                    {
                        string warehouse = dtgv_data.Rows[indexSelected].Cells["TE008"].Value.ToString().Trim();
                        string location = dtgv_data.Rows[indexSelected].Cells["TE029"].Value.ToString().Trim();
                        if (textSplit[0] == warehouse)
                        {
                            if (textSplit[1] == location)
                            {
                                dtgv_data.Rows[indexSelected].Cells["checkbox2"].Value = true;
                                txt_QRScanLocation.Text = textSplit[1];
                                txt_QRManpulation.Focus();

                            }
                            else if (textSplit[1] + "_" + textSplit[2] == location)
                            {
                                dtgv_data.Rows[indexSelected].Cells["checkbox2"].Value = true;
                                txt_QRScanLocation.Text = textSplit[1];
                            }
                            else
                            {
                                MessageBox.Show("Wrong location, please check QR location: " + textSplit[1] + ";" + textSplit[2] + "\n" + "warehouse require: " + location, "Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                txt_QRScanLocation.Text = "";
                                txt_QRScanLocation.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Wrong warehouse, please check QR location: " + textSplit[0] + "\n" + "warehouse require: " + warehouse, "Warning ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txt_QRScanLocation.Text = "";
                            txt_QRScanLocation.Focus();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Wrong QR location Format, please check QR location: ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txt_QRScanLocation.Text = "";
                    txt_QRScanLocation.Focus();
                }

            }
        }

        private void txt_QRManpulation_TextChanged(object sender, EventArgs e)
        {
            if (txt_QRManpulation.Text.EndsWith("e") && txt_QRManpulation.Text.Length > 2)
            {

                string textSplit = txt_QRManpulation.Text.Substring(1, txt_QRManpulation.Text.Length - 2);


                if (textSplit == "E")
                {
                    txt_QRManpulation.Text = "";
                    txt_materialRequest.Text = "";
                    txt_QrScanMaterial.Text = "";
                    txt_QRScanLocation.Text = "";
                    txt_materialRequest.Focus();
                    UpdateERP();
                   // FinishedGoodsExportFunction();

                }
                else if (textSplit == "N")
                {
                    txt_QRManpulation.Text = "";
                    txt_QrScanMaterial.Text = "";
                    txt_QRScanLocation.Text = "";
                    txt_QrScanMaterial.Focus();
                }
                else if (textSplit == "S")
                {
                    txt_QRManpulation.Text = "";
                    txt_QrScanMaterial.Text = "";
                    txt_QRScanLocation.Text = "";
                    txt_materialRequest.Focus();
                }
            }
        }
        private void UpdateERP()
        {
            //DataTable dt = new DataTable();
            //foreach (DataGridViewColumn column in dtgv_data.Columns)
            //    dt.Columns.Add(column.Name, column.CellType); //better to have cell type
            //for (int i = 0; i < dtgv_data.Rows.Count; i++)
            //{
            //    if ((bool)dtgv_data.Rows[i].Cells["checkbox"].Value == true && (bool)dtgv_data.Rows[i].Cells["checkbox2"].Value == true)
            //    {
            //        dt.Rows.Add();
            //        dt.Rows[i]["TE001"] = dtgv_data.Rows[i].Cells["TE001"].Value;
            //        dt.Rows[i]["TE002"] = dtgv_data.Rows[i].Cells["TE002"].Value;
            //        dt.Rows[i]["TE003"] = dtgv_data.Rows[i].Cells["TE003"].Value;


            //    }
            //}

            DataTable dt = new DataTable(); // create a table for storing selected rows
            var dtTemp = dtgv_data.DataSource as DataTable; // get the source table object
            dt = dtTemp.Clone();  // clone the schema of the source table to new table
            DataTable table = new DataTable();
            for (int i = 0; i < dtgv_data.Rows.Count; i++)
            {
                if ((bool)dtgv_data.Rows[i].Cells["checkbox"].Value == true && (bool)dtgv_data.Rows[i].Cells["checkbox2"].Value == true)
                {
                    var row = dt.NewRow();  // create a new row with the schema 
                    for (int j = 0; j < dtgv_data.Columns.Count; j++)
                    {
                        row["TE001"] = dtgv_data.Rows[i].Cells["TE001"].Value.ToString().Trim();
                        row["TE002"] = dtgv_data.Rows[i].Cells["TE002"].Value.ToString();
                        row["TE003"] = dtgv_data.Rows[i].Cells["TE003"].Value.ToString();

                    }
                    dt.Rows.Add(row);  // add rows to the new table
                }
            }


            Database.MOC.MOCTCTE mOCTCTE = new Database.MOC.MOCTCTE();
            mOCTCTE.UpdateMOCTC(dt);
            lb_confirm.Text = "Confirmed";
            lb_confirm.BackColor = Color.OrangeRed;
                
        }
    }
}
