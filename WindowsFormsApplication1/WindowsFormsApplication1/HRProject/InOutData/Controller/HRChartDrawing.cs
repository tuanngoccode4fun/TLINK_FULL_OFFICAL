using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using WindowsFormsApplication1.HRProject.InOutData.Model;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace WindowsFormsApplication1.HRProject.InOutData.Controller
{
 public   class HRChartDrawing : IDisposable
    {
        private IntPtr _bufferPtr;
        public int BUFFER_SIZE = 1024 * 1024; // 1 MB
        private bool _disposed = false;
        public static void DrawingChart(string[] LabelArray, double[] ValueArrayTotal, double[]AbsenceNumber, double[] IndirectNumber, ref CartesianChart chart)
        {
            try
            {

           
            double YmaxValue = 0;
            double YminValue = 0;
            YminValue = ValueArrayTotal.Min()==0?1: ValueArrayTotal.Min();
            YmaxValue = ValueArrayTotal.Max();
            chart.Series.Clear();
            chart.AxisX.Clear();
            chart.AxisY.Clear();
            chart.Controls.Clear();
            List<String> lables = new List<string>();
            ChartValues<double> valuesTotal = new ChartValues<double>();
            ChartValues<double> ValueabsenceQty = new ChartValues<double>();
            ChartValues<double> ValueIndirectQty = new ChartValues<double>();

            for (int i = 0; i < LabelArray.Length; i++)
            {
                lables.Add(LabelArray[i]);
                valuesTotal.Add(ValueArrayTotal[i]);
                    ValueabsenceQty.Add(AbsenceNumber[i]);
                    ValueIndirectQty.Add(IndirectNumber[i]);
            }
            chart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Employees",
                    Values = valuesTotal,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green,
                   ScalesYAt =0,
                   FontSize = 8
                }

            };
                chart.Series.Add(
                new ColumnSeries
                {
                    Title = "Absence",
                    Values = ValueabsenceQty,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Red,
                    ScalesYAt = 0,
                    FontSize = 8

                });
                 chart.Series.Add(
                new ColumnSeries
                {
                    Title = "Indirect",
                    Values = ValueIndirectQty,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.LightBlue,
                    ScalesYAt = 0,
                    FontSize = 8

                }
            );

                chart.DefaultLegend.Margin = new Thickness(15);
            chart.DefaultLegend.FontSize = 20;
            chart.LegendLocation = LegendLocation.Top;


            //x axis labels
            chart.AxisX.Add(new Axis
            {
                Title = "Dept",
                Labels = lables,
                Unit = 1,
                FontSize = 12,
                
                FontFamily = new System.Windows.Media.FontFamily("Times New Roman"),
                Foreground = System.Windows.Media.Brushes.Black,
                Separator = new LiveCharts.Wpf.Separator
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                },
                LabelsRotation = 0,
            });


            //y axis label
            chart.AxisY.Add(new Axis
            {
                Title = "People Number",
                LabelFormatter = value => value.ToString("N0"),
                FontSize = 10,

                FontFamily = new System.Windows.Media.FontFamily("Times New Roman"),

                Foreground = System.Windows.Media.Brushes.Black,
                MaxValue = YmaxValue * 1.2,
                MinValue = 0,
                Width = 5,
                Position = AxisPosition.LeftBottom
            });
               
                LabelArray = null;
                lables = null;
                 valuesTotal = null;
                 ValueabsenceQty = null;
                ValueIndirectQty = null;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "Drawing chart ", ex.Message);
            }
            
            ClearMemory.CleanMemory();
        }
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
            }

            // Free any unmanaged objects here.
            Marshal.FreeHGlobal(_bufferPtr);
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        ~HRChartDrawing()
        {
            Dispose(false);
        }
    }

}
