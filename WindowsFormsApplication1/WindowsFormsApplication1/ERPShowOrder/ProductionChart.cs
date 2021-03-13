using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace WindowsFormsApplication1.ERPShowOrder
{
    public partial class ProductionChart : CommonForm
    {
        public ProductionChart()
        {
            InitializeComponent();

        }
        DataTable dtchart = new DataTable();
        private void ProductionChart_Load(object sender, EventArgs e)
        {

            Class.valiballecommon va = Class.valiballecommon.GetStorage();
            txt_Production_Planning_Code.Text = Class.valiballecommon.GetStorage().value1;
            txt_Production_Planning_No.Text = Class.valiballecommon.GetStorage().value2;
            txt_Product_Code.Text = Class.valiballecommon.GetStorage().value3;
            txt_Product_Name.Text = Class.valiballecommon.GetStorage().value4;
            va.value1 = null;
            va.value2 = null;
            va.value3 = null;
            va.value4 = null;
            chartshow();
        }
        void chartshow()
        {
            string sql = @"  select  moctas.TA034 as Product_Name,
moctas.TA015 as Plan_Quanity,   (moctgs.TG011) as Finished_Goods, 
   (moctgs.TG012) as NG_Quanity,   (moctgs.TG013) as Good_Quanity,   moctgs.TG007 as Unit,  
   (CONVERT(date, moctfs.TF003)) as Input_Date   from MOCTA moctas
 
    left
   join MOCTG moctgs on moctgs.TG014 = moctas.TA001 and moctgs.TG015 = moctas.TA002
   left join MOCTF moctfs on moctfs.TF001 = moctgs.TG001 and moctfs.TF002 = moctgs.TG002
   where 1 = 1
   and moctas.TA001 = '" + txt_Production_Planning_Code.Text + "'  and moctas.TA002 = '" + txt_Production_Planning_No.Text +
   "' and  moctas.TA006 ='" +  txt_Product_Code.Text+ "' order by moctfs.TF003";
            sqlERPCON con = new sqlERPCON();
            con.sqlDataAdapterFillDatatable(sql, ref dtchart);
            chartIONG.ResetAutoValues();
            chartIONG.ResumeLayout();
            chartIONG.Series.Clear();
            chartIONG.Titles[0].Text = "CHART SHOW  PROGRESS DATA";
            chartIONG.Titles[0].Font = new Font("Arial", 16, FontStyle.Bold);
            chartIONG.ChartAreas[0].AxisX.LabelStyle.Format = "yyy-dd-MM";
            chartIONG.ChartAreas[0].AxisX.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisX2.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisY.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisY2.MajorGrid.Enabled = false;
            chartIONG.ChartAreas[0].AxisX.IntervalAutoMode = IntervalAutoMode.VariableCount;
            chartIONG.ChartAreas[0].AxisX.LabelStyle.Angle = -60;
            chartIONG.ChartAreas[0].AxisY.Title = "DATA [PCS]";

            chartIONG.Series.Add("Output");
            chartIONG.Series["Output"].ChartType = SeriesChartType.Line;
            chartIONG.Series["Output"].XValueType = ChartValueType.DateTime;
            chartIONG.Series["Output"].Color = Color.FromArgb(0, 192, 0); //blue
            chartIONG.Series["Output"].XValueMember = "Input_Date";
            chartIONG.Series["Output"].YValueMembers = "Good_Quanity";
            chartIONG.Series["Output"].BorderWidth = 5;
            chartIONG.Series["Output"].IsValueShownAsLabel = true;
            chartIONG.Series["Output"].CustomProperties = "LabelStyle=Bottom";


            chartIONG.Series.Add("Input");
            chartIONG.Series["Input"].ChartType = SeriesChartType.Line;
            chartIONG.Series["Input"].XValueType = ChartValueType.DateTime;
            chartIONG.Series["Input"].Color = Color.FromArgb(9, 9, 226);
            chartIONG.Series["Input"].YValueMembers = "Finished_Goods";
            chartIONG.Series["Input"].XValueMember = "Input_Date";
            chartIONG.Series["Input"].BorderWidth = 4;

            chartIONG.Series.Add("YEILD");
            chartIONG.Series["YEILD"].ChartType = SeriesChartType.Line;
            chartIONG.Series["YEILD"].Color = Color.FromArgb(192, 100, 0); //yellow    
            chartIONG.Series["YEILD"].BorderWidth = 1;
            chartIONG.Series["YEILD"].IsValueShownAsLabel = true;

            chartIONG.ChartAreas[0].AxisY2.Enabled = AxisEnabled.True;
            chartIONG.Series["YEILD"].YAxisType = AxisType.Secondary;
            chartIONG.ChartAreas[0].AxisX2.Enabled = AxisEnabled.True;
            chartIONG.Series["YEILD"].XAxisType = AxisType.Secondary;
            chartIONG.Series["YEILD"].XValueType = ChartValueType.DateTime;
            chartIONG.ChartAreas[0].AxisX2.LabelStyle.Format = "HH:mm";
            chartIONG.ChartAreas[0].AxisX2.LabelStyle.Angle = 0;
            chartIONG.ChartAreas[0].AxisY2.Maximum = 100;
            chartIONG.ChartAreas[0].AxisY2.Title = "YEILD [%]";
            chartIONG.Series["YEILD"].CustomProperties = "LabelStyle=Bottom";
            //for (int i = 0; i < dtchart.Rows.Count; i++)
            //{
            //    double Input = double.Parse(dtchart.Rows[i]["Finished_Goods"].ToString());
            //    double NG = double.Parse(dtchart.Rows[i]["NG_Quanity"].ToString());
            //    double yvalue = 100 - NG / Input;
            //    DateTime xvalue = DateTime.Parse(dtchart.Rows[i]["Input_Date"].ToString());
            //    chartIONG.Series["YEILD"].Points.AddXY(xvalue, yvalue);
            //    //   chartIONG.ChartAreas[0].AxisY.Maximum = double.Parse(dtchart.Rows[i].Cells["colInput"].Value.ToString()) + 5000;
            //}
           
            dgv_show.DataSource = dtchart;
            double input = 0;
            double output = 0;
            double NG = 0;
            for (int i = 0; i < dgv_show.RowCount - 1; i++)
            {
                input += double.Parse(dgv_show.Rows[i].Cells["Finished_Goods"].Value.ToString());
                output += double.Parse(dgv_show.Rows[i].Cells["Good_Quanity"].Value.ToString());
                NG += double.Parse(dgv_show.Rows[i].Cells["NG_Quanity"].Value.ToString());
                dgv_show.Rows[i].Cells["Finished_Goods"].Value = input.ToString();
                dgv_show.Rows[i].Cells["Good_Quanity"].Value = output.ToString();
                dgv_show.Rows[i].Cells["NG_Quanity"].Value = NG.ToString();
                double yvalue = Math.Round((100 - NG / input),2);
                DateTime xvalue = DateTime.Parse(dgv_show.Rows[i].Cells["Input_Date"].Value.ToString());
                chartIONG.Series["YEILD"].Points.AddXY(xvalue, yvalue);
            }
            chartIONG.DataSource = dgv_show.DataSource;
            chartIONG.DataBind();

        }
    }
}
