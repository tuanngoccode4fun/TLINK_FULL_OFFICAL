using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Zen.Barcode;
using WindowsFormsApplication1.Device.Printer;
using System.Globalization;

namespace WindowsFormsApplication1.WMS
{
   
    public partial class GenerateQRCode : CommonFormMetro
    {
        string QRForm = Environment.CurrentDirectory + @"\Resources\Form_Location.PNG";
        Bitmap imgDisplay;
        PictureBox picQR = new PictureBox();
        public GenerateQRCode()
        {
            InitializeComponent();

        }

        private void Btn_QRGenerate_Click(object sender, EventArgs e)
        {
            CodeQrBarcodeDraw barcode = BarcodeDrawFactory.CodeQr;
            string QRInfor =txt_warehouseName.Text + ";"+ txt_location.Text+";"+ txt_rack.Text+";"+DateTime.Now.ToString("dd/MM/yyyy");

            pic_QRCode.Image= barcode.Draw(QRInfor, 50);
            testDrawQRCODE(pic_QRCode);
        }
        private void testDrawQRCODE( PictureBox QRCode)
        {
            try
            {


                string FontFamily = "Times New Roman";

                //string Template= @"C:\Users\Admin\template.png";
                //     string fileName2 = @"C:\Users\Admin\";

                // Size keyCardSize = new Size(90, 60); // 170x108mm
                float Dpi = 200f;
                //  Bitmap bmp = new Bitmap(keyCardSize.Width, keyCardSize.Height);
                // Bitmap bmp = new Bitmap(Template);
                Bitmap bmp = (Bitmap)Image.FromFile(QRForm);
                // Bitmap bmp = new Bitmap(original, new Size(321, 208));
                //   bmp.Save(fileName2 +"template.png");
                bmp.SetResolution(Dpi, Dpi);

                // test data:
                Bitmap photo = (Bitmap)QRCode.Image.Clone();
                Bitmap resized = new Bitmap(photo, new Size(photo.Width, photo.Height));
                //   Bitmap photo = new Bitmap(@"C:\Users\Admin\Pictures\ImageHuman.png") ;
                // I have measured the photo should be 30mm wide
                // so with 25.4mm to the inch we calculate a fitting dpi for it:  
                float photoDpi = bmp.Width * 50.8f / 60f;

                resized.SetResolution(photoDpi, photoDpi);

                Font font1 = new Font(FontFamily, 8f, FontStyle.Bold);
                Font font2 = new Font(FontFamily, 10f, FontStyle.Bold);
                Font font3 = new Font(FontFamily, 12f, FontStyle.Bold);
                Color myRgbColor = new Color();
                myRgbColor = Color.FromArgb(11, 82, 148);


                using (Graphics G = Graphics.FromImage(bmp))
                using (SolidBrush brush1 = new SolidBrush(myRgbColor))
                using (SolidBrush brush2 = new SolidBrush(myRgbColor))
                {
                    //  G.Clear(Color.White);
                    G.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    G.PageUnit = GraphicsUnit.Millimeter;
                    G.SmoothingMode = SmoothingMode.HighQuality;

                    StringFormat sf = StringFormat.GenericTypographic;

                    //float lBorder = (float)numericUpDown6.Value;
                    //float rBorder = (float)numericUpDown5.Value;
                    //float rBorder2 = (float)numericUpDown9.Value;
                    //float y1 = (float)numericUpDown1.Value;
                    //float y2 = (float)numericUpDown2.Value;
                    //float y3 = (float)numericUpDown3.Value;
                    //float y4 = (float)numericUpDown4.Value;
                    float x1 = 0;
                    float y5 = 0;
                    //float y6 = (float)numericUpDown8.Value;
                    //..
                    //G.DrawImage(logo, imgLoc1);
                   G.DrawImage(resized, new PointF(x1, y5).X, new PointF(x1, y5).Y, 25, 25);
                    //G.DrawImage(img3, imgLoc3);
                    //G.DrawImage(img4, imgLoc4);
                    //G.DrawImage(img5, imgLoc5);


                    // test data:
                    //string txt1 = txt_hoten.Text;
                    //string txt2 = txt_bophan.Text;
                    //string txt3 = txt_chucvu.Text;
                    //string txt4 = txt_maso.Text;
                    //string txt5 = dtp_ngayvao.Value.ToString("dd-MM-yyyy").Replace('-', '/');

                    //..

                    //SizeF s1 = G.MeasureString(txt1, font1, PointF.Empty, sf);
                    //SizeF s2 = G.MeasureString(txt2, font1, PointF.Empty, sf);
                    //SizeF s3 = G.MeasureString(txt3, font1, PointF.Empty, sf);
                    //SizeF s4 = G.MeasureString(txt4, font1, PointF.Empty, sf);
                    //SizeF s5 = G.MeasureString(txt5, font1, PointF.Empty, sf);

                    ////..

                    //G.DrawString(txt1, font1, brush1, new PointF((int)(rBorder), y1));


                    ////..

                    //G.DrawString(txt2, font1, brush1, new PointF((int)(rBorder), y2));


                    ////..

                    //G.DrawString(txt3, font1, brush1, new PointF((int)(rBorder), y3));


                    ////..

                    //G.DrawString(txt4, font1, brush1, new PointF((int)(rBorder), y4));



                    //G.DrawString(txt5, font1, brush1, new PointF((int)(rBorder), y6));


                    //G.DrawString(txt3, font2, brush2, txtLoc3);
                    //..
                    //G.DrawString(txt7, font3, brush2, txtLoc7);

                    //  G.FillRectangle(brush1, new RectangleF(rBorder - 1.5f, 52f, 1.5f, 46f));

                }
                var imgsave = new Bitmap(bmp);
                imgsave.Clone();
                imgsave.Save(@"C:ERP_Temp" + "\\" + DateTime.Now.ToString("ddMMyyyy hhmmss") + ".png", System.Drawing.Imaging.ImageFormat.Png);
                imgDisplay = new Bitmap(bmp);
                imgDisplay.Clone();
                pic_QRLocationForm.Image = imgDisplay;
                font1.Dispose();
                font2.Dispose();
                font3.Dispose();

                photo.Dispose();
                //  imgsave.Dispose();

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }



        }

        private void Btn_PrintQRCode_Click(object sender, EventArgs e)
        {
            PritingLabel pritingLabel = new PritingLabel();
            string QRInfor = txt_warehouseName.Text + ";" + txt_location.Text + ";" + txt_rack.Text;
       //     pritingLabel.PrintQRCode(QRInfor);
        }

        private void Btn_search_Click(object sender, EventArgs e)
        {
            DBOperation dBOperation = new DBOperation();
            List<InvertoryItem> invertoryItems = new List<InvertoryItem>();
            if (cbm_warehouse.SelectedItem.ToString() != "")
            {
                invertoryItems = dBOperation.GetInvertoryItemsFillter(new DateTime(2019, 12, 18), cbm_warehouse.SelectedItem.ToString());
                dtgv_materialList.DataSource = invertoryItems;
            }

        }

        private void Dtgv_materialList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int RowIndex = e.RowIndex;
            int ColumnsIndex = e.ColumnIndex;
            if (RowIndex >= 0 && ColumnsIndex >= 0)
            {
                txt_commodity.Text = dtgv_materialList.Rows[e.RowIndex].Cells[1].Value.ToString();
               txt_quantity.Text = double.Parse(dtgv_materialList.Rows[e.RowIndex].Cells[3].Value.ToString()).ToString("N0");
                txt_warehouse.Text = dtgv_materialList.Rows[e.RowIndex].Cells[4].Value.ToString();
                txt_ERPlocation.Text = dtgv_materialList.Rows[e.RowIndex].Cells[5].Value.ToString();
                txt_importDate.Text= dtgv_materialList.Rows[e.RowIndex].Cells[6].Value.ToString().Substring(0,10);
                txt_lotpo.Text = dtgv_materialList.Rows[e.RowIndex].Cells[2].Value.ToString();
            }
        }

        private void Btn_printQR_Click(object sender, EventArgs e)
        {
            PritingLabel pritingLabel = new PritingLabel();
            LabelItem labelItem = new LabelItem();
            labelItem.Location = txt_warehouse.Text + "-" + txt_ERPlocation.Text;
            labelItem.PurchasingCode = txt_ERPlocation.Text;
            labelItem.MaterialCode = txt_commodity.Text;
            labelItem.Commodity = "";
            labelItem.Quantity = txt_quantity.Text;
            labelItem.ImportDate = DateTime.ParseExact(txt_importDate.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            labelItem.LotPo = txt_lotpo.Text;
            labelItem.ExpiryDate  = DateTime.ParseExact(txt_expiryDay.Text, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            //string QRInfor = txt_warehouseName.Text + ";" + txt_location.Text + ";" + txt_rack.Text;
          //  pritingLabel.PrintLabelQRCode(labelItem);
        }

        private void GenerateQRCode_Load(object sender, EventArgs e)
        {
            string sqlQuery = "select distinct TD005 from  INVTD where 1=1 and CONVERT(date,TD002) >= '" + new DateTime(2019, 12, 18).ToString("yyyyMMdd") + "'";
            sqlERPCON sqlERPCON = new sqlERPCON();
            sqlERPCON.getComboBoxData(sqlQuery, ref cbm_warehouse);
            if(cbm_warehouse.Items.Count >0)
            cbm_warehouse.SelectedIndex = 0;
        }

        private void GenerateQRCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            var keyboard = sender;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            PritingLabel pritingLabel = new PritingLabel();
            string QRInfor =txt_confirm.Text;
          //  pritingLabel.PrintQRCodeConfirm(QRInfor);
        }
    }
}
