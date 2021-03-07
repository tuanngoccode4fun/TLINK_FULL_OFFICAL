using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.HRProject.InOutData.Model;
using WindowsFormsApplication1.HRProject.InOutData.Controller;

namespace WindowsFormsApplication1.HRProject.InOutData.View
{
    public partial class HumanResourceDept : UserControl,IDisposable
    {
    private   List<AttendanceDept> attendanceDept ;
       
        public HumanResourceDept()
        {
            InitializeComponent();
        }

        public HumanResourceDept(List<AttendanceDept> attendance)
        {
            InitializeComponent();
           attendanceDept = attendance;
            DisplayUI();
           attendanceDept = null;
            ClearMemory.CleanMemory(); 
        }
        public void DisplayUI()
        {
            if(attendanceDept !=null)
            {
                lb_Department.Text = attendanceDept[0].BigDeptName;
                lb_manager.Text = attendanceDept[0].HeadDept;

                double total = attendanceDept.Select(d => d.EmployeeOfDept).Sum();
                lb_EmployeeQty.Text = total.ToString("N0");
                double AttendanceDayeNumber = attendanceDept.Select(d => d.DayShift.attendanceActual).Sum();
                lb_attendanceDay.Text = AttendanceDayeNumber.ToString("N0");
                double AttendanceNightNumber = attendanceDept.Select(d => d.NightShift.attendanceActual).Sum();
                lb_attendanceNight.Text = AttendanceNightNumber.ToString("N0");
                double AbsenceDayNumber = attendanceDept.Select(d => d.DayShift.absence).Sum() ;
                lb_absenceDay.Text = AbsenceDayNumber.ToString("N0");
                double AbsenceNightNumber = attendanceDept.Select(d => d.NightShift.absence).Sum();
                lb_absenceNight.Text = AbsenceNightNumber.ToString("N0");
                if (AttendanceDayeNumber + AbsenceDayNumber == 0)
                {
                    lb_attendanceDayRate.Text = "";
                }
             else   lb_attendanceDayRate.Text = (AttendanceDayeNumber / (AttendanceDayeNumber + AbsenceDayNumber)).ToString("P0");
                if (AbsenceNightNumber + AttendanceNightNumber == 0)
                    lb_attendaceNightRate.Text = "";
              else  lb_attendaceNightRate.Text = (AttendanceNightNumber/ (AbsenceNightNumber+ AttendanceNightNumber)).ToString("P0");
                double indirectNumber = attendanceDept.Select(d => d.LocalWorker.WorkerIndirect).Sum();
                double directNumber = attendanceDept.Select(d => d.LocalWorker.WorkerDirect).Sum();
                lb_IndirectQty.Text = indirectNumber.ToString("N0");
                lb_directQty.Text = directNumber.ToString("N0");
                if (indirectNumber + directNumber == 0)
                    lb_IndirectRate.Text = "";
               else lb_IndirectRate.Text = (indirectNumber / (indirectNumber + directNumber)).ToString("P0");
                

                string[] ListDept = attendanceDept.Select(d => d.DetailDeptName.Split('/')[0]).ToArray();
                double[] TotalQty = attendanceDept.Select(d => (double)d.EmployeeOfDept).ToArray() ;
                double[] AttadenceQtyDay = attendanceDept.Select(d => (double)d.DayShift.attendanceActual).ToArray();
                double[] AttadenceQtyNight = attendanceDept.Select(d => (double)d.NightShift.attendanceActual).ToArray();
                double[] AttendaceQty = new double[AttadenceQtyDay.Length];
                double[] AbsenceQtyDay = attendanceDept.Select(d => (double)d.DayShift.absence).ToArray();
                double[] AbsenceNight = attendanceDept.Select(d => (double)d.NightShift.absence).ToArray();
                double[] AbsenceQty = new double[AbsenceQtyDay.Length];
                double[] IndirectQty = attendanceDept.Select(d =>(double) d.LocalWorker.WorkerIndirect).ToArray();
                for (int i = 0; i < AttadenceQtyDay.Length; i++)
                {
                    AttendaceQty[i] = AttadenceQtyDay[i] + AttadenceQtyNight[i];
                    AbsenceQty[i] = AbsenceQtyDay[i] + AbsenceNight[i];
                }

                lb_AttendaceSeasonDay.Text = (attendanceDept.Select(d => (double)d.SeasonWorkerDay.attendanceActual).Sum()).ToString("N0");
                lb_AttendaceSeasonNight.Text = (attendanceDept.Select(d => (double)d.SeasonWorkerNight.attendanceActual).Sum()).ToString("N0");
                
               // hRChartDrawing = new HRChartDrawing();
                HRChartDrawing.DrawingChart(ListDept, TotalQty, AbsenceQty, IndirectQty, ref cartesianAttendance);
               // hRChartDrawing = null;
                ListDept = null;
                TotalQty = null;
                AbsenceQty = null;
                AttadenceQtyDay = null; AttadenceQtyNight = null; AttendaceQty = null;
                AbsenceQtyDay = null; AbsenceNight = null; AbsenceQty = null;
                IndirectQty = null;
                total = 0; AbsenceDayNumber = 0;AbsenceNightNumber = 0; AttendanceDayeNumber = 0; AttendanceNightNumber = 0; indirectNumber = 0; directNumber = 0;
              
              //    hRChartDrawing.Dispose();



            }
        }


     
    }
}
