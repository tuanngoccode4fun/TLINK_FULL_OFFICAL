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
    
    public partial class CommonFormMetro : MetroForm
    {
        public CommonFormMetro()
        {
            InitializeComponent();
            lbl_user.Text = "User:" + Class.valiballecommon.GetStorage().UserName + "--[" + Class.valiballecommon.GetStorage().Permission + "]";
            lbl_user.Font = new Font("Times New Roman", 12, FontStyle.Bold);
            lb_language.Text = "[Language: " + Class.valiballecommon.GetStorage().Language+ "]";
            lbl_database.Text = "[Database: " + Class.valiballecommon.GetStorage().DBERP + "]";
        }
    }
}
