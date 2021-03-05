using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using LiveCharts;
using LiveCharts.WinForms;
using LiveCharts.Wpf;
using WindowsFormsApplication1.MQC;
using CartesianChart = LiveCharts.WinForms.CartesianChart;

namespace WindowsFormsApplication1.ChartDrawing
{
  public  class LiveChartDrawing
    {
public void DrawingLiveChart(TargetMQC target, List<chartdatabyDate> chartdatabyDates, List<chartdatabyDate> chartdataDefect, ref CartesianChart chart)
        {
            //xu ly data de chon cac thong so cua chart
            double YmaxValue = 0;
            double YminValue = 0;
            Dictionary<string, double> ValueConvert = new Dictionary<string, double>();
            Dictionary<string, double> ValueConvertDefect = new Dictionary<string, double>();
            if (chartdatabyDates != null && chartdatabyDates.Count > 0)
            {
                chart.Series.Clear();
                chart.AxisX.Clear();
                chart.AxisY.Clear();
                chart.Controls.Clear();
                //      chart.Base.Foreground = new SolidColorBrush(Color.FromRgb(66, 66, 66));

                //  chart.Background = System.Windows.Media.Brushes.BlanchedAlmond;

                ValueConvert = DicChangeTime(chartdatabyDates);
                ValueConvertDefect = DicChangeTime(chartdataDefect);
                string[] TimeChanged = ValueConvert.Keys.ToArray();
                double[] OutputChanged = ValueConvert.Values.ToArray();
                double[] OutputChangedDefect = ValueConvertDefect.Values.ToArray();
                YmaxValue = OutputChanged.Max();
               
                YminValue = OutputChanged.Min();
                ChartValues<double> values = new ChartValues<double>();
                ChartValues<double> valuesTarget = new ChartValues<double>();
                ChartValues<double> valuesDefect = new ChartValues<double>();
                ChartValues<double> PercentQuantity = new ChartValues<double>();
                ChartValues<double> Defecttarget = new ChartValues<double>();
                double per = 0;
                for (int i = 0; i < OutputChanged.Count(); i++)
                {
                    values.Add(OutputChanged[i]);
                  
                    //  valuesTarget.Add(100);
                    if ((OutputChangedDefect[i] + OutputChanged[i]) != 0)
                        valuesDefect.Add(OutputChangedDefect[i] / (OutputChangedDefect[i] + OutputChanged[i]));
                    else valuesDefect.Add(0);
                    valuesTarget.Add(OutputChangedDefect[i]);
                    if (target.TargetOutput > 0)
                    {
                        per += OutputChanged[i] / target.TargetOutput;
                        PercentQuantity.Add(per);
                        Defecttarget.Add(target.TargetDefect / target.TargetOutput);
                    }
                }
                YmaxValue = values.Max();
               // YmaxValue = (values.Max() > valuesTarget.Max())? values.Max() : valuesTarget.Max();
                List<String> lables = new List<string>();
                for (int i = 0; i < TimeChanged.Count(); i++)
                {

                    lables.Add(TimeChanged[i]);
                }
                chart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Output Quantity",
                    Values = values,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green,
                   ScalesYAt =0,
                   FontSize = 15
                }

            };
                chart.Series.Add(
                new ColumnSeries
                {
                    Title = "Defect Quantity",
                    Values = valuesTarget,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Red,
                    ScalesYAt = 0,
                    FontSize = 15

                }
            );
                chart.Series.Add(
                new LineSeries
                {
                    Title = "Defect Rate (%)",
                    Values = valuesDefect,
                    DataLabels = true,
                    Foreground = System.Windows.Media.Brushes.Orange,
                    PointForeground = System.Windows.Media.Brushes.Red,
                    ScalesYAt = 1,
                    FontSize = 15

                });
                  chart.Series.Add(
                new LineSeries
                {
                    Title = "Target Quantity(%)",
                    Values = PercentQuantity,
                    DataLabels = true,
                    Foreground = System.Windows.Media.Brushes.BlueViolet,
                    PointForeground = System.Windows.Media.Brushes.BlueViolet,
                    ScalesYAt = 1,
                    FontSize = 15

                }
            ) ;
                chart.Series.Add(
             new LineSeries
             {
                 Title = "Defect target(%)",
                 Values = Defecttarget,
                 DataLabels = true,
                 Foreground = System.Windows.Media.Brushes.DarkKhaki,
                 PointForeground = System.Windows.Media.Brushes.DarkKhaki,
                 ScalesYAt = 1,
                 FontSize = 15

             }
         );
                chart.DefaultLegend.Margin = new Thickness(30);
                chart.DefaultLegend.FontSize = 20;
                chart.LegendLocation = LegendLocation.Top;
              

                //x axis labels
                chart.AxisX.Add(new Axis
                {
                    Title = "Hours",
                    Labels = lables,
                    Unit = 1,
                    FontSize = 15,
                   
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
                    Title = "Quantity (pcs)",
                    LabelFormatter = value => value.ToString("N0"),
                    FontSize = 15,
                  
                    FontFamily = new System.Windows.Media.FontFamily("Times New Roman"),
                   
                    Foreground = System.Windows.Media.Brushes.Black,
                    MaxValue = YmaxValue * 1.2,
                    MinValue = 0,
                    Position = AxisPosition.LeftBottom
                }); 

                chart.AxisY.Add(new Axis
                {
                    Title = "percent (%)",
                    LabelFormatter = value => value.ToString("P1"),
                    FontSize = 15,
                    FontFamily = new System.Windows.Media.FontFamily("Times New Roman"),
                    Foreground = System.Windows.Media.Brushes.Black,
                    MaxValue = 1,
                    MinValue = 0,
                    Position = AxisPosition.RightTop
                });
                // chart.Zoom = ZoomingOptions.Xy;
               
            }

        }

        public void DrawingLiveChartDataSummary( List<MQCItemSummary> mQCItemSummaries, ref CartesianChart chart)
        {
            //xu ly data de chon cac thong so cua chart
            double YmaxValue = 0;
            double YminValue = 0;
            Dictionary<string, double> ValueConvert = new Dictionary<string, double>();
            Dictionary<string, double> ValueConvertDefect = new Dictionary<string, double>();
            if (mQCItemSummaries != null && mQCItemSummaries.Count > 0)
            {
                chart.Series.Clear();
                chart.AxisX.Clear();
                chart.AxisY.Clear();
                chart.Controls.Clear();
                //      chart.Base.Foreground = new SolidColorBrush(Color.FromRgb(66, 66, 66));

                //  chart.Background = System.Windows.Media.Brushes.BlanchedAlmond;

                //ValueConvert = DicChangeTime(chartdatabyDates);
                //ValueConvertDefect = DicChangeTime(chartdataDefect);
                
                string[] TimeChanged = mQCItemSummaries.Select(d=>d.Time_from).ToArray();
                double[] OutputQuantity = mQCItemSummaries.Select(d => d.OutputQty).ToArray();
                double[] DefectQuantity = mQCItemSummaries.Select(d => d.NGQty).ToArray();
                double[] DefectRate = mQCItemSummaries.Select(d => d.DefectRate).ToArray();
                double[] ReworkRate = mQCItemSummaries.Select(d => d.ReworkRate).ToArray();
                YmaxValue = OutputQuantity.Max();

                YminValue = OutputQuantity.Min();
                ChartValues<double> valuesOutput = new ChartValues<double>();
                ChartValues<double> valuesTarget = new ChartValues<double>();
                ChartValues<double> valuesDefect = new ChartValues<double>();
                ChartValues<double> ValuesDefectRate = new ChartValues<double>();
                ChartValues<double> Defecttarget = new ChartValues<double>();
                double per = 0;
                for (int i = 0; i < OutputQuantity.Count(); i++)
                {
                    valuesOutput.Add(OutputQuantity[i]);
                    valuesDefect.Add(DefectQuantity[i]);
                    ValuesDefectRate.Add(DefectRate[i]);

                    //  valuesTarget.Add(100);
                    //if ((OutputChangedDefect[i] + OutputChanged[i]) != 0)
                    //    valuesDefect.Add(OutputChangedDefect[i] / (OutputChangedDefect[i] + OutputChanged[i]));
                    //else valuesDefect.Add(0);
                    //valuesTarget.Add(OutputChangedDefect[i]);
                    //if (target.TargetOutput > 0)
                    //{
                    //    per += OutputChanged[i] / target.TargetOutput;
                    //    PercentQuantity.Add(per);
                    //    Defecttarget.Add(target.TargetDefect / target.TargetOutput);
                    //}
                }
                YmaxValue = valuesOutput.Max();
                // YmaxValue = (values.Max() > valuesTarget.Max())? values.Max() : valuesTarget.Max();
                List<String> lables = new List<string>();
                for (int i = 0; i < TimeChanged.Count(); i++)
                {

                    lables.Add(TimeChanged[i]);
                }
                chart.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "Output Quantity",
                    Values = valuesOutput,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Green,
                   ScalesYAt =0,
                   FontSize = 15
                }

            };
                chart.Series.Add(
                new ColumnSeries
                {
                    Title = "Defect Quantity",
                    Values = valuesDefect,
                    DataLabels = true,
                    Fill = System.Windows.Media.Brushes.Red,
                    ScalesYAt = 0,
                    FontSize = 15

                }
            );
                chart.Series.Add(
                new LineSeries
                {
                    Title = "Defect Rate (%)",
                    Values = ValuesDefectRate,
                    DataLabels = true,
                    Foreground = System.Windows.Media.Brushes.Orange,
                    PointForeground = System.Windows.Media.Brushes.Red,
                    ScalesYAt = 1,
                    FontSize = 15

                });
         //       chart.Series.Add(
         //     new LineSeries
         //     {
         //         Title = "Target Quantity(%)",
         //         Values = PercentQuantity,
         //         DataLabels = true,
         //         Foreground = System.Windows.Media.Brushes.BlueViolet,
         //         PointForeground = System.Windows.Media.Brushes.BlueViolet,
         //         ScalesYAt = 1,
         //         FontSize = 15

         //     }
         // );
         //       chart.Series.Add(
         //    new LineSeries
         //    {
         //        Title = "Defect target(%)",
         //        Values = Defecttarget,
         //        DataLabels = true,
         //        Foreground = System.Windows.Media.Brushes.DarkKhaki,
         //        PointForeground = System.Windows.Media.Brushes.DarkKhaki,
         //        ScalesYAt = 1,
         //        FontSize = 15

         //    }
         //);
                chart.DefaultLegend.Margin = new Thickness(30);
                chart.DefaultLegend.FontSize = 20;
                chart.LegendLocation = LegendLocation.Top;


                //x axis labels
                chart.AxisX.Add(new Axis
                {
                    Title = "",
                    Labels = lables,
                    Unit = 1,
                    FontSize = 15,

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
                    Title = "Quantity (pcs)",
                    LabelFormatter = value => value.ToString("N0"),
                    FontSize = 15,

                    FontFamily = new System.Windows.Media.FontFamily("Times New Roman"),

                    Foreground = System.Windows.Media.Brushes.Black,
                    MaxValue = YmaxValue * 1.2,
                    MinValue = 0,
                    Position = AxisPosition.LeftBottom
                });

                chart.AxisY.Add(new Axis
                {
                    Title = "percent (%)",
                    LabelFormatter = value => value.ToString("P1"),
                    FontSize = 15,
                    FontFamily = new System.Windows.Media.FontFamily("Times New Roman"),
                    Foreground = System.Windows.Media.Brushes.Black,
                    MaxValue = 1,
                    MinValue = 0,
                    Position = AxisPosition.RightTop
                });
                // chart.Zoom = ZoomingOptions.Xy;

            }

        }

        public void DrawingPiechart(List<chartdataPie> chartdatas,ref LiveCharts.WinForms.PieChart pieChart1 )
        {
            pieChart1.Series.Clear();
            pieChart1.Controls.Clear();
            pieChart1.InnerRadius = 100;
            pieChart1.LegendLocation = LegendLocation.Top;
            pieChart1.Series = new SeriesCollection();
            pieChart1.Text = " Defect Type Rate ( % )";
            pieChart1.DefaultLegend.Margin = new Thickness(30);
            pieChart1.DefaultLegend.FontSize = 20;
            pieChart1.LegendLocation = LegendLocation.Top;

            foreach (var item in chartdatas)
            {
                PieSeries pie = new PieSeries
                {
                    Title = item.Label,
                    Values = new ChartValues<double> { item.value },
                    PushOut = 5,
                   
                    
                    DataLabels = true
                };
                pieChart1.Series.Add(pie);
            }

      
        }
        public void DrawingGaugeChart(List<chartdataPie> chartdatas, ref LiveCharts.WinForms.AngularGauge angularGauge1)
        {
            angularGauge1.Value = 0.25;
            angularGauge1.FromValue = 0;
            angularGauge1.ToValue = 1;
            angularGauge1.TicksForeground = Brushes.White;
            angularGauge1.Base.Foreground = Brushes.White;
            angularGauge1.Base.FontWeight = FontWeights.Bold;
            angularGauge1.Base.FontSize = 16;
            angularGauge1.SectionsInnerRadius = 0.5;
            
            angularGauge1.Sections.Add(new AngularSection
            {
                FromValue = 0,
                ToValue = 0.25,
                Fill = new SolidColorBrush(Color.FromRgb(247, 166, 37))
            });
            angularGauge1.Sections.Add(new AngularSection
            {
                FromValue = 0.25,
                ToValue = 0.5,
                Fill = new SolidColorBrush(Color.FromRgb(220, 100, 37))
            });
            angularGauge1.Sections.Add(new AngularSection
            {
                FromValue = 0.5,
                ToValue = 0.75,
                Fill = new SolidColorBrush(Color.FromRgb(225, 10, 37))
            });
            angularGauge1.Sections.Add(new AngularSection
            {
                FromValue = 0.75,
                ToValue = 1,
                Fill = new SolidColorBrush(Color.FromRgb(254, 57, 57))
            });


        }
        public Dictionary<string, double> DicChangeTime(List<chartdatabyDate> chartdatabyDates)
        {
            string[] time = null;
            double[] Axis = null;
            Axis = chartdatabyDates.Select(v => v.value).ToArray();
            time = chartdatabyDates.OrderBy(o =>o.time).Select(t => t.time.Hours.ToString()).ToArray();
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
                if (int.Parse(time[i].Split(':')[0]) % 2 == 0)
                {
                    string key = (int.Parse(time[i].Split(':')[0])).ToString() + "-" + (int.Parse(time[i].Split(':')[0]) + 2).ToString();
                    dic[key] += Axis[i];
                }
                else
                {
                    string key = (int.Parse(time[i].Split(':')[0]) - 1).ToString() + "-" + (int.Parse(time[i].Split(':')[0]) + 1).ToString();
                    dic[key] += Axis[i];
                }
            }
            return dic;
        }
        private Dictionary<string, double> DicChangeTime(string[] time, double[] Axis)
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
                if (int.Parse(time[i].Split(':')[0]) % 2 == 0)
                {
                    string key = (int.Parse(time[i].Split(':')[0])).ToString() + "-" + (int.Parse(time[i].Split(':')[0]) + 2).ToString();
                    dic[key] += Axis[i];
                }
                else
                {
                    string key = (int.Parse(time[i].Split(':')[0]) - 1).ToString() + "-" + (int.Parse(time[i].Split(':')[0]) + 1).ToString();
                    dic[key] += Axis[i];
                }
            }
            return dic;
        }


    }
    public class chartdatabyDate
    {
        public DateTime date { get; set; }
        public TimeSpan time { get; set; }
        public double value { get; set; }

    }
    public class chartdataPie
    {
        public string Label {get;set;}
        public double value { get; set; }
        public double Percent { get; set; }


    }
}

