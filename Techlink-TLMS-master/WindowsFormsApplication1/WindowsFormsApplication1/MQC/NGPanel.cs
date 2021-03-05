using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.MQC
{
    public partial class NGPanel : UserControl
    {
        List<NGItems> listNGItems = new List<NGItems>();
        List<Label> listLabel = new List<Label>();
        List<Label> listLabelName = new List<Label>();
        public  List<NGItems> nGItems;
       
        public NGPanel(List<NGItems> nGItems)
        {
            InitializeComponent();
            listNGItems = nGItems;
            UpdateUIForNG(nGItems);
            Disposed += OnDispose;
        }
        private void OnDispose(object sender, EventArgs e)
        {
            this.Load -= new System.EventHandler(this.NGPanel_Load);
            listLabel = null;
            listLabelName = null;
            // do stuff on dispose
        }
        public void UpdateUIForNG(List<NGItems> NGItems)
        {
           
            LoadListLabelNG();
            LoadListLabelNGName();
            if (NGItems == null)
            {
                for (int i = 0; i < 32; i++)
                {

                    listLabelName[i].Text = "";
                    listLabel[i].Text = "";
                    // listLabelName[i].Update();

                }
                return;
            }
            else if (NGItems.Count > 0)
            {
                var ListItems = NGItems
      .Where(d => d.NGQuantity > 0)
      .OrderBy(d => d.NGQuantity)
      .GroupBy(u => u.NGKey)
      .Select(grp => grp.ToList())
      .ToList();
                var listOfLists = ListItems.OrderByDescending(a => a.Sum(x => x.NGQuantity)).ToList();
                List<NGItems> ListNG = new List<NGItems>();
                for (int i = 0; i < listOfLists.Count; i++)
                {
                    ListNG = listOfLists[i];

                    listLabelName[i].Text = ListNG[0].NGName;
                    listLabel[i].Text = ListNG.Sum(d => d.NGQuantity).ToString();
                    listLabelName[i].Update();

                }
                for (int i = listOfLists.Count; i < 31; i++)
                {

                    listLabelName[i].Text = "";
                    listLabel[i].Text = "";
                    listLabelName[i].Update();

                }
            }
        }
        public void LoadListLabelNG()
        {
            listLabel.Add(lb_NGValue1);
            listLabel.Add(lb_NGValue2);
            listLabel.Add(lb_NGValue3);
            listLabel.Add(lb_NGValue4);
            listLabel.Add(lb_NGValue5);
            listLabel.Add(lb_NGValue6);
            listLabel.Add(lb_NGValue7);
            listLabel.Add(lb_NGValue8);
            listLabel.Add(lb_NGValue9);
            listLabel.Add(lb_NGValue10);
            listLabel.Add(lb_NGValue11);
            listLabel.Add(lb_NGValue12);
            listLabel.Add(lb_NGValue13);
            listLabel.Add(lb_NGValue14);
            listLabel.Add(lb_NGValue15);
            listLabel.Add(lb_NGValue16);
            listLabel.Add(lb_NGValue17);
            listLabel.Add(lb_NGValue18);
            listLabel.Add(lb_NGValue19);
            listLabel.Add(lb_NGValue20);
            listLabel.Add(lb_NG21Value);
            listLabel.Add(lb_NG22Value);
            listLabel.Add(lb_NG23Value);
            listLabel.Add(lb_NG24Value);
            listLabel.Add(lb_NG25Value);
            listLabel.Add(lb_NG26Value);
            listLabel.Add(lb_NG27Value);
            listLabel.Add(lb_NG28Value);
            listLabel.Add(lb_NG29Value);
            listLabel.Add(lb_NG30Value);
            listLabel.Add(lb_NG31Value);
            listLabel.Add(lb_NG32Value);
        }
        public void LoadListLabelNGName()
        {
            listLabelName.Add(lb_NG1);
            listLabelName.Add(lb_NG2);
            listLabelName.Add(lb_NG3);
            listLabelName.Add(lb_NG4);
            listLabelName.Add(lb_NG5);
            listLabelName.Add(lb_NG6);
            listLabelName.Add(lb_NG7);
            listLabelName.Add(lb_NG8);
            listLabelName.Add(lb_NG9);
            listLabelName.Add(lb_NG10);
            listLabelName.Add(lb_NG11);
            listLabelName.Add(lb_NG12);
            listLabelName.Add(lb_NG13);
            listLabelName.Add(lb_NG14);
            listLabelName.Add(lb_NG15);
            listLabelName.Add(lb_NG16);
            listLabelName.Add(lb_NG17);
            listLabelName.Add(lb_NG18);
            listLabelName.Add(lb_NG19);
            listLabelName.Add(lb_NG20);
            listLabelName.Add(lb_NG21);
            listLabelName.Add(lb_NG22);
            listLabelName.Add(lb_NG23);
            listLabelName.Add(lb_NG24);
            listLabelName.Add(lb_NG25);
            listLabelName.Add(lb_NG26);
            listLabelName.Add(lb_NG27);
            listLabelName.Add(lb_NG28);
            listLabelName.Add(lb_NG29);
            listLabelName.Add(lb_NG30);
            listLabelName.Add(lb_NG31);
            listLabelName.Add(lb_NG32);
        }
        private void NGPanel_Load(object sender, EventArgs e)
        {
            LoadListLabelNG();
            LoadListLabelNGName();
        }

    }
}
