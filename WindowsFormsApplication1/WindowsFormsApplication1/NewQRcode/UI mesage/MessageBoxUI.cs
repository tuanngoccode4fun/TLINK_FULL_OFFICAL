using MetroFramework.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.NewQRcode.UI_mesage
{
    public partial class MessageBoxUI : MetroForm
    {
        enum status {ok,ng };
        status t = status.ok;
        Timer m_Timer = new Timer();
        public MessageBoxUI()
        {
            InitializeComponent();
            m_Timer.Enabled = true;
            m_Timer.Interval = 2000;
            m_Timer.Tick += M_Timer_Tick;
            m_Timer.Start();
        }
        public MessageBoxUI(string content,bool status,int timer)
        {
            InitializeComponent();
            m_Timer.Enabled = true;
            m_Timer.Interval = timer;
            m_Timer.Tick += M_Timer_Tick;
            m_Timer.Start();
            lb_messagebox.Text = content;
            lb_messagebox.BackColor = (status == true) ? Color.GreenYellow : Color.Red;
            lb_messagebox.ForeColor = (status == true) ? Color.Black : Color.Yellow;
        }

        private void M_Timer_Tick(object sender, EventArgs e)
        {
            m_Timer.Stop();
            m_Timer.Enabled = false;
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
