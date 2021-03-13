using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.MQC.TargetProduction
{// Declare DateTimePicker.

    public partial class TargetProdution : CommonForm
    {// Declare DateTimePicker.
        DateTimePicker dateTimePicker1;
        List<DeptCodeName> deptCodes = new List<DeptCodeName>();
        
        public TargetProdution()
        {
            InitializeComponent();
            tab_targetDaily.TabPages[0].Text = "Daily target";
            tab_targetDaily.TabPages[1].Text = "Monthly target";
            LoadDataIntilize();

        }
        public void LoadDataIntilize()
        {
            LoaddataConfigure loaddata = new LoaddataConfigure();
            deptCodes =    loaddata.deptCodeNames();
            foreach (var item in deptCodes)
            {
                col_Dept.Items.Add(item.DeptName);
            }          
            col_type.Items.Add("Date");
            col_type.Items.Add("Week");
            col_type.Items.Add("Month");
            col_type.Items.Add("Year");
            
            col_Flag.Items.Add("YES");
            col_Flag.Items.Add("NO");
            dtgv_target.EditingControlShowing += new DataGridViewEditingControlShowingEventHandler(dataGridView1_EditingControlShowing);
        }
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            ComboBox combo = e.Control as ComboBox;
            if (combo != null)
            {
                combo.SelectedIndexChanged -= new EventHandler(ComboBox_SelectedIndexChanged);
                combo.SelectedIndexChanged += new EventHandler(ComboBox_SelectedIndexChanged);
            }
         
        }

        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoaddataConfigure loaddata = new LoaddataConfigure();
            ComboBox cb = (ComboBox)sender;
            if (cb.Text.Contains("["))
            {
                string item = cb.Text;
                if (item != null)
                {
                    var DeptNo = deptCodes.Where(d => d.DeptName == item).Select(s => s.DeptCode).ToList();
                    col_product.Items.Clear();
                    List<string> ListString = loaddata.ListProduct(DeptNo[0]);
                    foreach (var model in ListString)
                    {
                        col_product.Items.Add(model);
                    }
                }
            }
        }

        private void Dtgv_target_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check the cell clicked is not the column header cell
            if (e.RowIndex != -1)
            {
                // Apply on column index in which you want to display DatetimePicker.
                // For this example it is 2.
                if (e.ColumnIndex == 3 || e.ColumnIndex == 4)
                {
                    // Initialize the dateTimePicker1.
                    dateTimePicker1 = new DateTimePicker();
                    // Adding the dateTimePicker1 into DataGridView.   
                    dtgv_target.Controls.Add(dateTimePicker1);
                    // Setting the format i.e. mm/dd/yyyy)
                    dateTimePicker1.Format = DateTimePickerFormat.Short;
                    // Create retangular area that represents the display area for a cell.
                    Rectangle oRectangle = dtgv_target.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, true);
                    // Setting area for dateTimePicker1.
                    dateTimePicker1.Size = new Size(oRectangle.Width, oRectangle.Height);
                    // Setting location for dateTimePicker1.
                    dateTimePicker1.Location = new Point(oRectangle.X, oRectangle.Y);
                    // An event attached to dateTimePicker1 which is fired when any date is selected.
                    dateTimePicker1.TextChanged += new EventHandler(DateTimePickerChange);
                    // An event attached to dateTimePicker1 which is fired when DateTimeControl is closed.
                    dateTimePicker1.CloseUp += new EventHandler(DateTimePickerClose);
                }
            }
        }
        private void DateTimePickerChange(object sender, EventArgs e)
        {
            dtgv_target.CurrentCell.Value = dateTimePicker1.Text.ToString();
          //  MessageBox.Show(string.Format("Date changed to {0}", dateTimePicker1.Text.ToString()));
        }

        private void DateTimePickerClose(object sender, EventArgs e)
        {
            dateTimePicker1.Visible = false;
        }

        private void Btn_insert_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgv_target.Rows.Count; i++)
            {
                targetItems targetItems = new targetItems();
                string dept = (dtgv_target.Rows[i].Cells["col_Dept"].Value != null ) ? dtgv_target.Rows[i].Cells["col_Dept"].Value.ToString() : "";
                string product =(dtgv_target.Rows[i].Cells["col_product"].Value != null)?  dtgv_target.Rows[i].Cells["col_product"].Value.ToString() :"";
                if (dept != "" && product != "")
                {
                    string Type = (dtgv_target.Rows[i].Cells["col_type"].Value != null) ? dtgv_target.Rows[i].Cells["col_type"].Value.ToString() : "";
                    string Aplly_Date = (dtgv_target.Rows[i].Cells["col_ApplyDate"].Value != null) ? dtgv_target.Rows[i].Cells["col_ApplyDate"].Value.ToString() : "";
                    string Expire_Date = (dtgv_target.Rows[i].Cells["col_expire"].Value != null) ? dtgv_target.Rows[i].Cells["col_expire"].Value.ToString() : "";
                    string flag = (dtgv_target.Rows[i].Cells["col_Flag"].Value != null) ? dtgv_target.Rows[i].Cells["col_Flag"].Value.ToString() : "";
                    string TA01 = (dtgv_target.Rows[i].Cells["col_TA01"].Value != null) ? dtgv_target.Rows[i].Cells["col_TA01"].Value.ToString() : "";
                    string TA02 = (dtgv_target.Rows[i].Cells["col_TA02"].Value != null) ? dtgv_target.Rows[i].Cells["col_TA02"].Value.ToString() : "";
                    string TA03 = (dtgv_target.Rows[i].Cells["col_TA03"].Value != null) ? dtgv_target.Rows[i].Cells["col_TA03"].Value.ToString() : "";
                    string TA04 = (dtgv_target.Rows[i].Cells["col_TA04"].Value != null) ? dtgv_target.Rows[i].Cells["col_TA04"].Value.ToString() : "";
                    string TA05 = (dtgv_target.Rows[i].Cells["col_TA05"].Value != null) ? dtgv_target.Rows[i].Cells["col_TA05"].Value.ToString() : "";
                    string TA06 = (dtgv_target.Rows[i].Cells["col_TA06"].Value != null) ? dtgv_target.Rows[i].Cells["col_TA06"].Value.ToString() : "";
                    string TA07 = (dtgv_target.Rows[i].Cells["col_TA07"].Value != null) ? dtgv_target.Rows[i].Cells["col_TA07"].Value.ToString() : "";
                    string TA08 = (dtgv_target.Rows[i].Cells["col_TA08"].Value != null) ? dtgv_target.Rows[i].Cells["col_TA08"].Value.ToString() : "";
                    string TA09 = (dtgv_target.Rows[i].Cells["col_TA09"].Value != null) ? dtgv_target.Rows[i].Cells["col_TA09"].Value.ToString() : "";
                    string TA10 = (dtgv_target.Rows[i].Cells["col_TA10"].Value != null) ? dtgv_target.Rows[i].Cells["col_TA10"].Value.ToString() : "";
                    string TA11 = (dtgv_target.Rows[i].Cells["col_TA11"].Value != null) ? dtgv_target.Rows[i].Cells["col_TA11"].Value.ToString() : "";
                    string TA12 = (dtgv_target.Rows[i].Cells["col_TA12"].Value != null) ? dtgv_target.Rows[i].Cells["col_TA12"].Value.ToString() : "";

                   
                }
                //   string TA03 = dtgv_target.Rows[i].Cells["col_TA01"].Value.ToString();
            }
        }
    }
}
