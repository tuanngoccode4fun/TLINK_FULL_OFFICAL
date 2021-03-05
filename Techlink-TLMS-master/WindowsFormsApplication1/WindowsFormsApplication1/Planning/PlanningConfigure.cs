using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Planning
{
    public partial class PlanningConfigure : CommonForm
    { DateTime from = DateTime.MinValue;
        DateTime to = DateTime.MinValue;
        List<OrderVariable> orderVariables;
        public PlanningConfigure()
        {
            InitializeComponent();
           orderVariables = new List<OrderVariable>();
            LoadConfigure();

        }
        private void LoadConfigure ()
        {
            dtp_from.Value = DateTime.Now.AddDays(1);
            dtp_to.Value = DateTime.Now.AddDays(21);
            from = dtp_from.Value;
            to = dtp_to.Value;

        }

        private void PlanningConfigure_Load(object sender, EventArgs e)
        {
            LoadDataPlanning loadData = new LoadDataPlanning();
            orderVariables = loadData.LoadOrderInformationbyDate(from, to, "");
            Dictionary<string, PlanningItem> keyValuePairs = loadData.GetPlanningReport(orderVariables);
            dt_main.DataSource = orderVariables;
        }
    }
}
