using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.HRProject.InOutData
{
    public partial class EmployeeUpdate : CommonFormMetro
    {
        Model.EmployeeData _EmployeeData;
        public EmployeeUpdate(Model.EmployeeData employeeData)
        {
            InitializeComponent();
            _EmployeeData = employeeData;
        }

        private void EmployeeUpdate_Load(object sender, EventArgs e)
        {
            SqlHR sqlHR = new SqlHR();
            string strSql = "select  distinct LongName , Note from ZlDept ";
            DataTable dt = new DataTable();
            sqlHR.sqlDataAdapterFillDatatable(strSql, ref dt);
            var RowCb = dt.Columns[0];
            List<string> depts = dt.AsEnumerable().Select(x => x[0].ToString()).ToList();
            Dictionary<string, string> keyValuesDepts = new Dictionary<string, string>();
            
            cb_department.DataSource = depts;
            cb_Sex.Items.Add("Male");
            cb_Sex.Items.Add("Female");
            cb_Status.Items.Add("Working");
            cb_Status.Items.Add("Resigned");
            txt_empCode.Text = _EmployeeData.EmpCode;
            txt_EmpName.Text = _EmployeeData.Name;
            cb_department.Text = _EmployeeData.Dept;
            cb_Sex.Text = _EmployeeData.Sex;
            dtpk_HireDate.Text = _EmployeeData.HiredDate;
            cb_Status.Text = _EmployeeData.Status;
        }
    }
}
