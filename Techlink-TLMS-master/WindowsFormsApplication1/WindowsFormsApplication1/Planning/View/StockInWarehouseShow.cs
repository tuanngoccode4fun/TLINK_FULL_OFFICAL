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
    public partial class StockInWarehouseShow : CommonFormMetro
    {
       // List<ItemsInINVMC> _itemsInINVMCs = new List<ItemsInINVMC>();
        public StockInWarehouseShow(List<ItemsInINVMC> itemsInINVMCs)
        {
            InitializeComponent();
          //  _itemsInINVMCs = itemsInINVMCs;
            dtgv_ShowItems.DataSource = itemsInINVMCs;
            settingdatagridview(dtgv_ShowItems);
        }

        private void settingdatagridview(DataGridView dataGridView)
        {
            dataGridView.DefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 12, FontStyle.Regular);
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new System.Drawing.Font("Times New Roman", 14, FontStyle.Regular);
            dataGridView.BackgroundColor = Color.LightSteelBlue;
            dataGridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGridView.ColumnHeadersHeight = 100;
        }
    }
}
