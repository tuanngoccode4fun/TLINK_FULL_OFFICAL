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
    public partial class BOMDeclarWin : CommonFormMetro
    {
        Model.SummaryDelivery _summary = new Model.SummaryDelivery();
        int RowSelect = -1;
        int RowNPLSelect = -1;
        public BOMDeclarWin(Model.SummaryDelivery summary)
        {
            InitializeComponent();
            _summary = summary;
            

        }

        private void BOMDeclarWin_Load(object sender, EventArgs e)
        {
            Controller.GetBOMDeclar getBOMDeclar = new Controller.GetBOMDeclar();
            List<Model.BOMCustomsDeclar> customsDeclars = getBOMDeclar.GetBOMCustomsDeclars(_summary);
            dtgv_BOMDeclar.DataSource = customsDeclars;
            if(_summary != null)
            {
                lb_Sanpham.Text = customsDeclars[0].Product;
                lb_Soluong.Text = _summary.TotalQuantity.ToString("N3");
                lb_donviSL.Text = _summary.Unit;
                lb_dongia.Text = _summary.PriceUnit.ToString("N3");
                lb_donviDG.Text = _summary.Currency;
                lb_thanhtien.Text =_summary.price.ToString("N3");
                lb_DonviTT.Text =_summary.Currency;

            }
        }

        private void dtgv_BOMDeclar_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_BOMDeclar);
            dtgv_BOMDeclar.AllowUserToAddRows = false;
            if(dtgv_BOMDeclar.Rows.Count > 0)
            {
                dtgv_BOMDeclar.Columns["Product"].Visible = false;
                dtgv_BOMDeclar.Columns["SLSanpham"].Visible = false;
                dtgv_BOMDeclar.Columns["GiaTriSp"].Visible = false;
                dtgv_BOMDeclar.Columns["DonviSp"].Visible = false;

            }
        }

        private void dtgv_BOMDeclar_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.ColumnIndex >=0 && e.RowIndex >=0)
            {
                dtgv_TKHQNhap.Columns.Clear();
                string ma_NPL =(string) dtgv_BOMDeclar.Rows[e.RowIndex].Cells["MaNVL"].Value;
                string ma_HSCode = (string)dtgv_BOMDeclar.Rows[e.RowIndex].Cells["MaHS"].Value;
                Controller.GetToKhaiNhap getToKhaiNhap = new Controller.GetToKhaiNhap();
                DataTable dtTKN = getToKhaiNhap.GetTableToKHaiNhap(ma_NPL, ma_HSCode);
                dtgv_TKHQNhap.DataSource = dtTKN;
                DataGridViewCheckBoxColumn checkBoxCell = new DataGridViewCheckBoxColumn();
                checkBoxCell.Name = "checkbox";
                checkBoxCell.HeaderText = "Select";
                checkBoxCell.DisplayIndex = 0;
                dtgv_TKHQNhap.Columns.Add(checkBoxCell);
                RowNPLSelect = e.RowIndex;
            }
        }

        private void dtgv_TKHQNhap_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_TKHQNhap);
            dtgv_TKHQNhap.AllowUserToAddRows = false;
        }

        private void btn_Comfirm_Click(object sender, EventArgs e)
        {
            if(RowSelect > -1 && (bool) dtgv_TKHQNhap.Rows[RowSelect].Cells["checkbox"].Value == true)
            {
                string So_TK = dtgv_TKHQNhap.Rows[RowSelect].Cells["SOTK"].Value.ToString();
                string Nuoc_XX = dtgv_TKHQNhap.Rows[RowSelect].Cells["TEN_NUOC_XX"].Value.ToString();
                dtgv_BOMDeclar.Rows[RowNPLSelect].Cells["TKHQ"].Value = So_TK;
                dtgv_BOMDeclar.Rows[RowNPLSelect].Cells["NuocXuatXu"].Value = Nuoc_XX;
                dtgv_BOMDeclar.EndEdit();
            }
        }

        private void dtgv_TKHQNhap_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex >= 0 && e.ColumnIndex >=0)
            {
                if(dtgv_TKHQNhap.Columns[e.ColumnIndex].Name== "checkbox" && RowSelect != e.RowIndex )
                {
                    if (RowSelect > -1)
                        dtgv_TKHQNhap.Rows[RowSelect].Cells["checkbox"].Value = false;
                    dtgv_TKHQNhap.Rows[e.RowIndex].Cells["checkbox"].Value = true;
                    RowSelect= e.RowIndex;

                }

            }
        }
    }
}
