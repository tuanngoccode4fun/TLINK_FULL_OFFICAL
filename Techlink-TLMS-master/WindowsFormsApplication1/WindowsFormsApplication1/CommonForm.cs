using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace WindowsFormsApplication1
{
    public partial class CommonForm : Form
    {
        public CommonForm()
        {
            InitializeComponent();
            lbl_username.Text = "User Name: "+ Class.valiballecommon.GetStorage().UserName + " ---["+Class.valiballecommon.GetStorage().Permission + "]";
            
        }

        private void CommonForm_Load(object sender, EventArgs e)
        {
            

        }
    }
}
