using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.NewQRcode.UI_mesage
{
  public  class ClassMessageBoxUI
    {
       public static void Show(string content, bool status,int displaytime=1000)
        {
            MessageBoxUI tem = new MessageBoxUI(content, status,displaytime);
            tem.TopMost = true;
            tem.StartPosition = FormStartPosition.CenterParent;
            tem.ShowDialog();
        }
    }
}
