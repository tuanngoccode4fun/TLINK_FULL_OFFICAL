using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
  public  class DatagridviewSetting
    {
        public static void settingDatagridview( DataGridView gridView)
        {
            try
            {


                gridView.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
                gridView.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);

                gridView.BackgroundColor = Color.LightSteelBlue;
                gridView.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
                gridView.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;


                gridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                gridView.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
                
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "MakeUpDatagridStockOut(DataGridView gridView)", ex.Message);
            }
        }
    }
}
