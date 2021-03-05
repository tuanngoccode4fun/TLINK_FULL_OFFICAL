using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.mainUI
{
    public partial class HRManagement : Form
    {
        public HRManagement()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_SeasonalEmp_Click(object sender, EventArgs e)
        {
            WindowsFormsApplication1.HRProject.InOutData.View.TimeWorking timeWorking = new HRProject.InOutData.View.TimeWorking();
            timeWorking.WindowState = FormWindowState.Maximized;
            timeWorking.Show();
        }

        private void btn_Manpower_Click(object sender, EventArgs e)
        {
            HRProject.InOutData.View.HRAttendaceReport rAttendaceReport = new HRProject.InOutData.View.HRAttendaceReport();
            rAttendaceReport.WindowState = FormWindowState.Maximized;
            rAttendaceReport.Show();
        }

        private void HRManagement_Load(object sender, EventArgs e)
        {
            sqlCON connect = new sqlCON();
            connect.sqlDatatablePermision("Manpower", btn_Manpower);
            connect.sqlDatatablePermision("SeasonalEmp", btn_SeasonalEmp);
        }
    }
}
