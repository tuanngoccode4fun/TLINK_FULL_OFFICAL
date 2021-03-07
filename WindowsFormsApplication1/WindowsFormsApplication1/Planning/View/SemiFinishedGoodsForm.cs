using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.Planning.Model;

namespace WindowsFormsApplication1.Planning.View
{
    public partial class SemiFinishedGoodsForm : CommonFormMetro
    {
        public SemiFinishedGoodsForm()
        {
            InitializeComponent();
        }
      
        public SemiFinishedGoodsForm(List<SemiFinishedGoods> semiFinishedGoods)
        {
            InitializeComponent();
            DisplaySemiFinishedGoodstoDtgv(semiFinishedGoods);

        }
        public void DisplaySemiFinishedGoodstoDtgv(List<SemiFinishedGoods> semiFinishedGoods)
        {
            List<SemiFinishedsGoodsItems> semiFinishedsGoodsItems = new List<SemiFinishedsGoodsItems>();
            foreach (var item in semiFinishedGoods)
            {
                SemiFinishedsGoodsItems semiFinisheds = new SemiFinishedsGoodsItems();
                semiFinisheds.SemiFinishedGoods = item.Item;
                semiFinisheds.QTyAtMQC = item.QTyAtMQC;
                semiFinisheds.QTyAtPQC = item.QTyAtPQC;
                semiFinisheds.QtyInMQC = item.QtyInMQC;
                semiFinisheds.QtyInPQC = item.QtyInPQC;
                semiFinisheds.SemiFGsRequire = item.QtyNeed;
                semiFinisheds.QtyOutMQC = item.QtyOutMQC;
                semiFinisheds.QtyOutPQC = item.QtyOutPQC;
                semiFinisheds.QtyPendingWarehouse = item.QtyPendingWarehouse;
                semiFinisheds.QtyWarehouse = item.QtyWarehouse;
                semiFinisheds.QtyWip = item.QtyWip;
                if (item.accessories != null)
                {
                    for (int i = 0; i < item.accessories.Count; i++)
                    {
                        semiFinisheds.Accessory += item.accessories[i].Item + Environment.NewLine;
                        semiFinisheds.AccessoryStock += item.accessories[i].QtyInWarehouse + Environment.NewLine;
                        semiFinisheds.WarehouseofAccessory += item.accessories[i].Warehouse + Environment.NewLine;

                    }

                }
                semiFinishedsGoodsItems.Add(semiFinisheds);
            }
            dtgv_SemiFiGoods.DataSource = semiFinishedsGoodsItems;
          
        }

        private void dtgv_SemiFiGoods_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DatagridviewSetting.settingDatagridview(dtgv_SemiFiGoods);
            if (dtgv_SemiFiGoods.Rows.Count > 0)
            {
                dtgv_SemiFiGoods.Columns["Product"].HeaderText = "Product";
                dtgv_SemiFiGoods.Columns["Product"].Visible = false;

                dtgv_SemiFiGoods.Columns["SemiFinishedGoods"].HeaderText = "Semi-Finished Goods";

                dtgv_SemiFiGoods.Columns["QtyWarehouse"].HeaderText = "Warehouse (pcs)";
                dtgv_SemiFiGoods.Columns["QtyWarehouse"].DefaultCellStyle.Format = "N0";


                dtgv_SemiFiGoods.Columns["SemiFGsRequire"].HeaderText = "Amount needed to produce (pcs)";
                dtgv_SemiFiGoods.Columns["SemiFGsRequire"].DefaultCellStyle.Format = "N0";

                dtgv_SemiFiGoods.Columns["QtyInMQC"].HeaderText = "IN MQC";
                dtgv_SemiFiGoods.Columns["QtyInMQC"].DefaultCellStyle.Format = "N0";
                dtgv_SemiFiGoods.Columns["QtyInMQC"].Visible = false;

                dtgv_SemiFiGoods.Columns["QtyOutMQC"].HeaderText = "OUT MQC";
                dtgv_SemiFiGoods.Columns["QtyOutMQC"].DefaultCellStyle.Format = "N0";
                dtgv_SemiFiGoods.Columns["QtyOutMQC"].Visible= false;


                dtgv_SemiFiGoods.Columns["QTyAtMQC"].HeaderText = "MQC Station (pcs)";
                dtgv_SemiFiGoods.Columns["QTyAtMQC"].DefaultCellStyle.Format = "N0";


                dtgv_SemiFiGoods.Columns["QtyInPQC"].HeaderText = "IN PQC";
                dtgv_SemiFiGoods.Columns["QtyInPQC"].DefaultCellStyle.Format = "N0";
                dtgv_SemiFiGoods.Columns["QtyInPQC"].Visible = false;

                dtgv_SemiFiGoods.Columns["QtyOutPQC"].HeaderText = "OUT PQC";
                dtgv_SemiFiGoods.Columns["QtyOutPQC"].DefaultCellStyle.Format = "N0";
                dtgv_SemiFiGoods.Columns["QtyOutPQC"].Visible = false;


                dtgv_SemiFiGoods.Columns["QTyAtPQC"].HeaderText = "PQC Station (pcs)";
                dtgv_SemiFiGoods.Columns["QTyAtPQC"].DefaultCellStyle.Format = "N0";

                dtgv_SemiFiGoods.Columns["QtyPendingWarehouse"].HeaderText = "Into Warehouse Pending (pcs)";
                dtgv_SemiFiGoods.Columns["QtyPendingWarehouse"].DefaultCellStyle.Format = "N0";

                dtgv_SemiFiGoods.Columns["QtyWip"].HeaderText = "WIP (pcs)";
                dtgv_SemiFiGoods.Columns["QtyWip"].DefaultCellStyle.Format = "N0";

                dtgv_SemiFiGoods.Columns["Accessory"].HeaderText = "Accessory";
                dtgv_SemiFiGoods.Columns["AccessoryStock"].HeaderText = "Accessory Stock";
                dtgv_SemiFiGoods.Columns["WarehouseofAccessory"].HeaderText = "Accessory Warehouse";

                dtgv_SemiFiGoods.Columns["Accessory"].Visible = false;
                dtgv_SemiFiGoods.Columns["AccessoryStock"].Visible = false;
                dtgv_SemiFiGoods.Columns["WarehouseofAccessory"].Visible = false;


            }


        }
    }
}
