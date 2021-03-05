using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.HRProject.InOutData.Controller;
using WindowsFormsApplication1.HRProject.InOutData.Model;

namespace WindowsFormsApplication1.HRProject.InOutData.View
{
    public partial class WindowAbsenceList : CommonFormMetro
    {
        List<EmployeeAbsence> employeeAbsences = new List<EmployeeAbsence>();
        public WindowAbsenceList(List<EmployeeAbsence> _absenceList)
        {
            InitializeComponent();
            employeeAbsences = _absenceList;
            DisplayDataGridview();
        }
        public void DisplayDataGridview ()
        {
            dtgv_Display.DataSource = employeeAbsences;
        }

        private void Dtgv_Display_BindingContextChanged(object sender, EventArgs e)
        {

        }
        private void SettingDatagridview(ref DataGridView dataGrid)
        {

            dataGrid.DefaultCellStyle.Font = new Font("Times New Roman", 12, FontStyle.Regular);
            dataGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Times New Roman", 14, FontStyle.Regular);
            dataGrid.BackgroundColor = Color.LightSteelBlue;
            dataGrid.RowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dataGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.LightSkyBlue;
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.ColumnHeadersHeight = 100;

        }

        private void Dtgv_Display_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            SettingDatagridview(ref dtgv_Display);
        }
    }
}
