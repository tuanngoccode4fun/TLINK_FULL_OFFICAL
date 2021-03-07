using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TLMSClient
{
    class infomesge
    {
        public void WarningMesger(string message, string caption, Form fr)
        {
            DialogResult result = MessageBox.Show(message, caption,MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Warning);

            
            if (result == DialogResult.No)
            {
                fr.Close();
            }
        }
        public void ErrorMesger(string message, string caption, Form fr)
        {
            DialogResult result = MessageBox.Show(message, caption, MessageBoxButtons.YesNo,
                                         MessageBoxIcon.Error);


            if (result == DialogResult.No)
            {
                fr.Close();
            }
        }
    }
}
