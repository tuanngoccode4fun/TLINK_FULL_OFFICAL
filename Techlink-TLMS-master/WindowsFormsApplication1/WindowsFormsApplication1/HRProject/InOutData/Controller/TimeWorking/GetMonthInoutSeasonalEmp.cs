using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApplication1.HRProject.InOutData.Model.TimeWorking;
using WindowsFormsApplication1.HRProject.InOutData.Controller.TimeWorking;


namespace WindowsFormsApplication1.HRProject.InOutData.Controller.TimeWorking
{
   public class GetMonthInoutSeasonalEmp
    {
        public Dictionary<string, Model.MonthInOut> GetKeyValuePairsInOut(List<SeasonalEmployee> seasonalEmployees, DateTime from, DateTime to)
        {
            Dictionary<string, Model.MonthInOut> keyValuePairs = new Dictionary<string, Model.MonthInOut>();
            GetInoutDataFromEmployee getInoutDataFrom = new GetInoutDataFromEmployee();

            List<Model.InoutData> InoutDatas = null;
            try
            {
                foreach (var item in seasonalEmployees)
                {
                    InoutDatas = getInoutDataFrom.GetInoutDatasFromEmpFinger(item.FingerCode, from, to);
                    Model.MonthInOut monthInOut = GetMonthInOutFromInoutdata(InoutDatas);
                    keyValuePairs.Add(item.FingerCode, monthInOut);
                }
                
            }
            catch (Exception ex)
            {

                throw;
            }
            return keyValuePairs;
        }
        public Model.MonthInOut GetMonthInOutFromInoutdata(List<Model.InoutData> inoutDatas)
        {
            Model.MonthInOut monthInOut = new Model.MonthInOut();
            try
            {
                monthInOut.InData = new string[31];
                monthInOut.OutData = new string[31];
                monthInOut.WorkingTime = new double[31];
                monthInOut.InOutEvaluation = new string[31];
                monthInOut.Shift = new string[31];

                for (int i =0 ; i < inoutDatas.Count; i++)
                {
                   
                    if (inoutDatas[i].Shift =="Night")
                    {
                        var TimeIn = TimeSpan.ParseExact(inoutDatas[i].Time, "h\\:mm", CultureInfo.CurrentCulture);
                        
                     //   if ( inoutDatas[i].FDateTime.Day+1 == inoutDatas[i+1].FDateTime.Day)
                     //   {
                     //       var TimeOut = TimeSpan.ParseExact(inoutDatas[i+1].Time, "h\\:mm", CultureInfo.CurrentCulture);
                     //       int day = inoutDatas[i].FDateTime.Day-1;
                     //       monthInOut.InData[day] = inoutDatas[i].Time;
                     //       monthInOut.OutData[day] = "T"+inoutDatas[i+1].Time;
                     //       monthInOut.WorkingTime[day] = 11;
                     //       monthInOut.InOutEvaluation[day] = "Night-12";
                     //   }
                     //else   if (inoutDatas[i + 1].InOut == "Out-Night8" && inoutDatas[i].FDateTime.Day + 1 == inoutDatas[i + 1].FDateTime.Day)
                     //   {
                     //       var TimeOut = TimeSpan.ParseExact(inoutDatas[i + 1].Time, "h\\:mm", CultureInfo.CurrentCulture);
                     //       int day = inoutDatas[i].FDateTime.Day - 1;
                     //       monthInOut.InData[day] = inoutDatas[i].Time;
                     //       monthInOut.OutData[day] = "T" + inoutDatas[i + 1].Time;
                     //       monthInOut.WorkingTime[day] = 8;
                     //       monthInOut.InOutEvaluation[day] = "Night-8";
                     //   }
                   
                       if (inoutDatas[i].FDateTime.Day + 1 == inoutDatas[i + 1].FDateTime.Day)
                        {
                            var TimeOut = TimeSpan.ParseExact(inoutDatas[i + 1].Time, "h\\:mm", CultureInfo.CurrentCulture);
                            int day = inoutDatas[i].FDateTime.Day;
                            monthInOut.Shift[day-1] = inoutDatas[i].Shift;
                            monthInOut.InData[day-1] = inoutDatas[i].Time;
                            monthInOut.OutData[day-1] = "T" + inoutDatas[i + 1].Time;
                            
                            if (TimeOut >= new TimeSpan(1, 0, 0))
                            {
                                var TimeConvert = ((TimeOut - new TimeSpan(20,0,0)).Add(new TimeSpan(24, 0, 0)).RoundDown(TimeSpan.FromMinutes(30)));

                                monthInOut.WorkingTime[day-1] = Math.Round(TimeConvert.TotalHours-1, 1);

                            }
                            else
                            {
                                var TimeConvert = ((TimeOut - new TimeSpan(20, 0, 0).Add(new TimeSpan(24, 0, 0)).RoundDown(TimeSpan.FromMinutes(30))));

                                monthInOut.WorkingTime[day-1] = Math.Round(TimeConvert.TotalHours, 1);
                            }
                            monthInOut.InOutEvaluation[day-1] = "Night-Undefined";
                        }
                    }
                    else if (inoutDatas[i].Shift == "Day")
                    {
                        var TimeIn = TimeSpan.ParseExact(inoutDatas[i].Time, "h\\:mm", CultureInfo.CurrentCulture);
                       // if (inoutDatas[i + 1].InOut == "Out-Day" && inoutDatas[i].FDateTime.Day == inoutDatas[i + 1].FDateTime.Day)
                       // {
                       //     var TimeOut = TimeSpan.ParseExact(inoutDatas[i + 1].Time, "h\\:mm", CultureInfo.CurrentCulture);
                       //     int day = inoutDatas[i].FDateTime.Day-1;
                       //     monthInOut.InData[day] = inoutDatas[i].Time;
                       //     monthInOut.OutData[day] =  inoutDatas[i + 1].Time;
                       //     monthInOut.WorkingTime[day] = 11;
                       //     monthInOut.InOutEvaluation[day] = "Day-12";
                            
                       // }
                       //else if (inoutDatas[i + 1].InOut == "Out-Day8" && inoutDatas[i].FDateTime.Day == inoutDatas[i + 1].FDateTime.Day)
                       // {
                       //     var TimeOut = TimeSpan.ParseExact(inoutDatas[i + 1].Time, "h\\:mm", CultureInfo.CurrentCulture);
                       //     int day = inoutDatas[i].FDateTime.Day - 1;
                       //     monthInOut.InData[day] = inoutDatas[i].Time;
                       //     monthInOut.OutData[day] = inoutDatas[i + 1].Time;
                       //     monthInOut.WorkingTime[day] = 8;
                       //     monthInOut.InOutEvaluation[day] = "Day-8";
                       // }
                      if ( inoutDatas[i].FDateTime.Day == inoutDatas[i + 1].FDateTime.Day && (inoutDatas[i + 1].FDateTime- inoutDatas[i].FDateTime) > new TimeSpan(2,0,0))
                        {
                            var TimeOut = TimeSpan.ParseExact(inoutDatas[i + 1].Time, "h\\:mm", CultureInfo.CurrentCulture);
                            int day = inoutDatas[i].FDateTime.Day;
                            monthInOut.InData[day-1] = inoutDatas[i].Time;
                            monthInOut.OutData[day-1] =  inoutDatas[i + 1].Time;
                            monthInOut.Shift[day-1] = inoutDatas[i].Shift;
                            if (TimeOut >= new TimeSpan(13, 0, 0))
                            {
                                var TimeConvert = (TimeOut - new TimeSpan(8, 0, 0)).RoundDown(TimeSpan.FromMinutes(30));
                                monthInOut.WorkingTime[day-1] = Math.Round(TimeConvert.TotalHours - 1, 1);

                            }
                            else
                            {
                                var TimeConvert = (TimeOut - new TimeSpan(8, 0, 0)).RoundDown(TimeSpan.FromMinutes(30));
                                monthInOut.WorkingTime[day-1] = Math.Round(TimeConvert.TotalHours, 1);
                            }
                            
                            monthInOut.InOutEvaluation[day-1] = "Day-Undefined";
                        }
                    }
                    else
                    {
                        int day = inoutDatas[i].FDateTime.Day;
                        monthInOut.Shift[day-1] = inoutDatas[i].Shift;
                    }
                    //else if(inoutDatas[i].InOut == "Undefined")
                    //{
                    //    int day = inoutDatas[i].FDateTime.Day;
                    //    monthInOut.InData[day] = inoutDatas[i].Date + " "+ inoutDatas[i].Time;
                    //    monthInOut.WorkingTime[day] = 0;
                    //    monthInOut.InOutEvaluation[day] = "Undefined";
                    //}
                }
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "GetMonthInOutFromInoutdata(List<Model.InoutData> inoutDatas)", ex.Message);
            }
            return monthInOut;
        
        }
    }
}
