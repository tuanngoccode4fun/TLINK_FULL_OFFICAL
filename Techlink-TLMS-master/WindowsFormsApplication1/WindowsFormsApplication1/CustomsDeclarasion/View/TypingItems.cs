using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.CustomsDeclarasion
{
    public partial class TypingItems : CommonFormMetro
    {
        public TypingItems()
        {
            InitializeComponent();
            //Class.valiballecommon.GetStorage().UserName = "TEST4";
            //Class.valiballecommon.GetStorage().UserCode = "TEST4";
            //Class.valiballecommon.GetStorage().DBERP = "TLVN2";
            //Class.valiballecommon.GetStorage().DBSFT = "SFT_TLVN2";

        }


        private void inputProductInformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new View.InputProduct());

        }
        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            PanelChildForm.Controls.Add(childForm);
            PanelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void inputWeightProductToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new View.InputWeight());
        }

        private void inputPackingInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new View.InputExcel());
        }

        private void buyerInforToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new View.BuyerInput());
        }

        private void shipmentInforToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new View.ShipmentInformation());
        }

        private void bOMOFPRODUCTDECLARASIONToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new View.BOMDeclarasionWin());
        }

        private void fromExcelFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new WMS.View.PrintQRCodeLabel());
        }

        private void printQRToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openChildForm(new PrintQRCode.PrintQRCode());
        }
    }

}
