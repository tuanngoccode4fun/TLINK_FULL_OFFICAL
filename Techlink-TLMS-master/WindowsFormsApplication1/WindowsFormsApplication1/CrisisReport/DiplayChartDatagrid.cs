using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.CrisisReport
{
    public partial class DiplayChartDatagrid : CommonForm
    {
        DataTable DataTable = new DataTable();
        List<string> ListTP;
        string TScale = "";
        double[] targetRef = new double[2];

        public DiplayChartDatagrid(DataTable dt, string TimeScale, double[] target)
        {
            InitializeComponent();

            DataTable = dt;
            dtgv_show.DataSource = dt;
            dtgv_show.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dtgv_show.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dtgv_show.AutoGenerateColumns = true;
            dtgv_show.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dtgv_show.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Bold);
            dtgv_show.AllowUserToAddRows = false;
            dtgv_show.Columns[0].HeaderText = "Date";
            dtgv_show.Columns[1].HeaderText = "Time";
            dtgv_show.Columns[2].HeaderText = "Department";
            dtgv_show.Columns[3].HeaderText = "Production Code";
            dtgv_show.Columns[4].HeaderText = "Target Output";
            dtgv_show.Columns[4].DefaultCellStyle.Format = "N0";
            dtgv_show.Columns[5].HeaderText = "Actual Output"; ;
            dtgv_show.Columns[5].DefaultCellStyle.Format = "N0";
            dtgv_show.Columns[6].HeaderText = "Actual Scrap Qty";
            dtgv_show.Columns[6].DefaultCellStyle.Format = "N0";
            dtgv_show.Columns[7].HeaderText = "Target Scrap(%)";
            dtgv_show.Columns[7].DefaultCellStyle.Format = "0%";
            dtgv_show.Columns[8].HeaderText = "Actual Scrap (%)";
            dtgv_show.Columns[8].DefaultCellStyle.Format = "0%";
            ListTP = ListFinishedGoods();
            TScale = TimeScale;
            targetRef = target;

        }
        string[] strDate;
        string[] strTime;
        double[] dobOutput;
        double[] dobTargetOutput;
        double[] dobScrap;
        double[] dobScrapRate;
        double[] dobTargetScrapRate;
        private void GetDataForDrawing( DataTable dt, double[] target)
        {
            strDate = dt.AsEnumerable().Select(s => s.Field<DateTime>("Date").ToString("dd/MM")).ToArray<string>();
            dobOutput = dt.AsEnumerable().Select(s => s.Field<double>("ActualOutput")).ToArray<double>();
            dobTargetOutput = dt.AsEnumerable().Select(s => s.Field<double>("OutputTarget")).ToArray<double>();
            dobScrap = dt.AsEnumerable().Select(s => s.Field<double>("ActualDefectQty")).ToArray<double>();
            dobTargetScrapRate = dt.AsEnumerable().Select(s => s.Field<double>("ScrapTargetRate")).ToArray<double>();
            dobScrapRate = dt.AsEnumerable().Select(s => s.Field<double>("ScrapActualtRate")).ToArray<double>();

            strTime = dt.AsEnumerable().OrderBy(d => d.Field<TimeSpan>("Time")).Select(s => s.Field<TimeSpan>("Time").ToString()).ToArray<string>();

            if (TScale == "Monthly")
            {
                ChartDrawing.ChartDrawing.DrawChartDateInMonths(DateTime.Now,strDate, dobOutput,  strDate, dobTargetOutput, strDate, dobScrapRate, strDate, dobTargetScrapRate, ref ch_production, "Production Management");

                // ChartDrawing.ChartDrawing.DrawTwoChartInside(strDate, dobOutput, dobScrapRate, target[0], target[1], ref ch_production, "Production Management");
            }
            if (TScale == "Daily")
            {

                Dictionary<string, double> keyValuesOutput = DicChangeTime(strTime, dobOutput);
                Dictionary<string, double> keyValuesScrap = DicChangeTime(strTime, dobScrapRate);
                string[] TimeChanged = keyValuesOutput.Keys.ToArray();
                double[] OutputChanged = keyValuesOutput.Values.ToArray();
                double[] ScraprateChanged = keyValuesScrap.Values.ToArray();
              
                ChartDrawing.ChartDrawing.DrawTwoChartInside(TimeChanged, OutputChanged, ScraprateChanged, target[0], target[1], ref ch_production, "Production Management ");
            }

        }
        private List<string> ListFinishedGoods()
        {
            List<string> list = new List<string>();
            list.Add("A04");
            list.Add("B02");
            list.Add("B03");
            list.Add("P04");
            list.Add("Y04");
            return list;
        }

        private void DiplayChartDatagrid_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            
          GetDataForDrawing(DataTable,targetRef);
        }
        private Dictionary<string, double> DicChangeTime (string []time, double [] Axis)
        {
            Dictionary<string, double> dic = new Dictionary<string, double>();
          
            dic.Add("8-10", 0);
             dic.Add("10-12", 0);
            dic.Add("12-14", 0);
            dic.Add("14-16", 0);
            dic.Add("16-18", 0);
            dic.Add("18-20", 0);
            dic.Add("20-22", 0);
            dic.Add("22-24", 0);
            dic.Add("0-2", 0);
            dic.Add("2-4", 0);
            dic.Add("4-6", 0);
            dic.Add("6-8", 0);
            for (int i = 0; i < time.Count(); i++)
            {
                if(int.Parse(time[i].Split(':')[0]) %2 ==0)
                {
                    string key = (int.Parse(time[i].Split(':')[0])).ToString() + "-" + (int.Parse(time[i].Split(':')[0]) + 2).ToString();
                    dic[key] += Axis[i];
                }
                else
                {
                    string key = (int.Parse(time[i].Split(':')[0])-1).ToString() + "-" + (int.Parse(time[i].Split(':')[0]) + 1).ToString();
                    dic[key] += Axis[i];
                }
            }
            return dic;
        }
      
    }
}
