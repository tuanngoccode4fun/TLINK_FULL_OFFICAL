using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ERPShowOrder
{
    public partial class FormShowTest : CommonForm
    {
       public string orderCode;
       public string orderNo;
        public FormShowTest(string ordercode, string orderno, DataTable dtShow)
        {

            InitializeComponent();
            orderCode = ordercode;
            orderNo = orderno;
            lab_OrderCode.Text = ordercode;
            lab_OrderNo.Text = orderNo;
            dtgv_test.DataSource = dtShow;
            dtgv_test.AutoGenerateColumns = true;
            dtgv_test.DefaultCellStyle.Font = new Font("Verdana", 8, FontStyle.Regular);
            dtgv_test.ColumnHeadersDefaultCellStyle.Font = new Font("Verdana", 10, FontStyle.Bold);

        }
    }
}
