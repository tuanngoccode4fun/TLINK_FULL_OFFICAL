using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UploadDataToDatabase
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
           Application.Run(new Form1());
       //   Application.Run(new FormConfig.FormDataGridShow());
            //   Application.Run(new Report.ReliabilityReportWeekly());
        //  Application.Run(new Report.ReliabilityReportMonthly());
          //  Application.Run(new Report.BacklogReport());
        }
    }
}
