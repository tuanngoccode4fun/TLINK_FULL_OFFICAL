using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.UI;

namespace UploadDataToDatabase
{
    public partial class PrintEmployeeCard :Form
    { 
        VideoCapture _capture;
        Image<Bgr, byte> imgInput;
        Bitmap BitmapFace ;
        My_Rectangle_Affine My_rectangle;
        ConfigureSave ConfigureLoad = new ConfigureSave();
        private string path = Environment.CurrentDirectory;
        string folderStorage = "";
        string configureFolder = "";
        Bitmap imgDisplay;
        string version = "";
        public PrintEmployeeCard()
        {
            InitializeComponent();
            img_camera.MouseEnter += Picture_box_object_MouseEnter;
            img_camera.MouseLeave += Picture_box_object_MouseLeave;
            img_camera.MouseMove += Picture_box_object_MouseMove;
            img_camera.SizeMode = PictureBoxSizeMode.StretchImage;
            img_camera.FunctionalMode = ImageBox.FunctionalModeOption.Minimum;
            img_cat.FunctionalMode = ImageBox.FunctionalModeOption.Minimum;
            img_cat.SizeMode = PictureBoxSizeMode.StretchImage;
            folderStorage = path +"\\"+ "THE_NHAN_VIEN";
            configureFolder = path + "\\" + "Configure";
            bool exists = System.IO.Directory.Exists(folderStorage);
            if (!exists)
                System.IO.Directory.CreateDirectory(folderStorage);
            bool exists2 = System.IO.Directory.Exists(configureFolder);
            if (!exists2)
                System.IO.Directory.CreateDirectory(configureFolder);
            version = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Major.ToString(); //AssemblyVersion을 가져온다.
            version += "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Minor.ToString();
            version += "." + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.Build.ToString();
            Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name + " " + version;
        }
        private void _capture_ImageGrabbed(object sender, EventArgs e)
        {

            try
            {
                Mat m = new Mat();
                _capture.Retrieve(m);
                imgInput = m.ToImage<Bgr, byte>();
                try
                {
                    if (imgInput == null)
                    {
                       img_camera.Image = null;
                        return;


                    }
                    img_camera.Image = imgInput; ;
                    // CvInvoke.Imshow("image", imgInput);
                    // DetectFaceHaar();
                }
                catch (Exception ex)
                {
                    System.Windows.Forms.MessageBox.Show(ex.Message);
                }


            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);

            }

        }

        private void PrintEmployeeCard_Load(object sender, EventArgs e)
        {
            try
            {
                if (File.Exists(configureFolder + @"\Configure.ini"))
                {
                    ConfigureLoad = (ConfigureSave)SaveObject.Load_data(configureFolder + @"\Configure.ini");
                }
                else
                {
                    ConfigureLoad.rect = new System.Drawing.Rectangle(70, 70, 170, 190);


                }
               
            }
            catch (Exception ex)
            {
                ConfigureLoad.rect = new System.Drawing.Rectangle(70, 70, 170, 190);
                System.Windows.Forms.MessageBox.Show("Load file configure : " + ex.Message);
            }
            LoadCamera();

        }
        private void LoadCamera()
        {
            try
            {

                if (_capture == null)
                {
                    _capture = new VideoCapture();
                }

                _capture.ImageGrabbed += _capture_ImageGrabbed;
                _capture.Start();
             
               btn_Start.Text = "START";
            }
            catch (Exception ex)
            {


                System.Windows.Forms.MessageBox.Show("Camera can't open : " + ex.Message);
            }
        }
        private void testDrawEmployeeCard()
        {
            string FontFamily = "Times New Roman";

         //string Template= @"C:\Users\Admin\template.png";
         //     string fileName2 = @"C:\Users\Admin\";

           // Size keyCardSize = new Size(90, 60); // 170x108mm
            float Dpi = 200f;
            //  Bitmap bmp = new Bitmap(keyCardSize.Width, keyCardSize.Height);
            // Bitmap bmp = new Bitmap(Template);
           Bitmap bmp = (Bitmap)Image.FromFile(folderStorage + @"\Template.png");
           // Bitmap bmp = new Bitmap(original, new Size(321, 208));
           //   bmp.Save(fileName2 +"template.png");
            bmp.SetResolution(Dpi, Dpi);

            // test data:
            Bitmap photo = (Bitmap)BitmapFace.Clone();
           Bitmap resized = new Bitmap(photo, new Size(photo.Width, photo.Height ));
            //   Bitmap photo = new Bitmap(@"C:\Users\Admin\Pictures\ImageHuman.png") ;
            // I have measured the photo should be 30mm wide
            // so with 25.4mm to the inch we calculate a fitting dpi for it:  
            float photoDpi = bmp.Width * 50.8f / 60f;

            resized.SetResolution(photoDpi, photoDpi);

            Font font1 = new Font(FontFamily, 11f);
            Font font2 = new Font(FontFamily, 10f);
            Font font3 = new Font(FontFamily, 12f);

            using (Graphics G = Graphics.FromImage(bmp))
            using (SolidBrush brush1 = new SolidBrush(Color.Black))
            using (SolidBrush brush2 = new SolidBrush(Color.Gray))
            {
              //  G.Clear(Color.White);
                G.InterpolationMode = InterpolationMode.HighQualityBicubic;
                G.PageUnit = GraphicsUnit.Millimeter;
                G.SmoothingMode = SmoothingMode.HighQuality;

                StringFormat sf = StringFormat.GenericTypographic;

                int lBorder =(int) numericUpDown6.Value;
                int rBorder = (int)numericUpDown5.Value;
                int y1 = (int)numericUpDown1.Value;
                int y2 = (int)numericUpDown2.Value;
                int y3 = (int)numericUpDown3.Value;
                //..
                int y4 = (int)numericUpDown4.Value;
                int y5 = (int)numericUpDown7.Value;
                int y6 = (int)numericUpDown8.Value;
                //..
                //G.DrawImage(logo, imgLoc1);
                G.DrawImage(resized, new Point(lBorder, y5).X, new Point(lBorder, y5).Y,32,33);
                //G.DrawImage(img3, imgLoc3);
                //G.DrawImage(img4, imgLoc4);
                //G.DrawImage(img5, imgLoc5);


                // test data:
                string txt1 = txt_hoten.Text;
                string txt2 = txt_bophan.Text;
                string txt3 = txt_chucvu.Text;
                string txt4 = txt_maso.Text;
                string txt5 = dtp_ngayvao.Value.ToString("dd-MM-yyyy");

                //..

                SizeF s1 = G.MeasureString(txt1, font1, PointF.Empty, sf);
                SizeF s2 = G.MeasureString(txt2, font1, PointF.Empty, sf);
                SizeF s3 = G.MeasureString(txt3, font1, PointF.Empty, sf);
                SizeF s4 = G.MeasureString(txt4, font1, PointF.Empty, sf);
                SizeF s5 = G.MeasureString(txt5, font1, PointF.Empty, sf);

                //..
                if(txt1.Length <5)
                G.DrawString(txt1, font1, brush1, new Point((int)(rBorder - s1.Width-5), y1));
                else if (txt1.Length >= 5 && txt1.Length <= 14)
                G.DrawString(txt1, font1, brush1, new Point((int)(rBorder - s1.Width), y1));
                else G.DrawString(txt1, font2, brush1, new Point((int)(rBorder - s1.Width +5), y1));

                //..
                if (txt2.Length < 5)
                    G.DrawString(txt2, font1, brush1, new Point((int)(rBorder - s2.Width - 5), y2));
                else if (txt2.Length >= 5 && txt1.Length <= 14)
                    G.DrawString(txt2, font1, brush1, new Point((int)(rBorder - s2.Width), y2));
                else G.DrawString(txt2, font2, brush1, new Point((int)(rBorder - s2.Width+7), y2));

                //..
                if (txt3.Length < 5)
                    G.DrawString(txt3, font1, brush1, new Point((int)(rBorder - s3.Width - 5), y3));
                else if (txt3.Length >= 5 && txt1.Length <= 14)
                    G.DrawString(txt3, font1, brush1, new Point((int)(rBorder - s3.Width), y3));
                else G.DrawString(txt3, font2, brush1, new Point((int)(rBorder - s3.Width+5), y3));

                //..
                if (txt4.Length < 5)
                    G.DrawString(txt4, font1, brush1, new Point((int)(rBorder - s4.Width - 5), y4));
                else if (txt4.Length >= 5 && txt1.Length <= 14)
                    G.DrawString(txt4, font1, brush1, new Point((int)(rBorder - s4.Width), y4));
                else G.DrawString(txt4, font2, brush1, new Point((int)(rBorder - s4.Width+5), y4));

                if (txt5.Length < 5)
                    G.DrawString(txt5, font1, brush1, new Point((int)(rBorder - s5.Width - 5), y6));
                else if (txt5.Length >= 5 && txt1.Length <= 14)
                    G.DrawString(txt5, font1, brush1, new Point((int)(rBorder - s5.Width), y6));
                else G.DrawString(txt5, font2, brush1, new Point((int)(rBorder - s5.Width+5), y6));
               
                //G.DrawString(txt3, font2, brush2, txtLoc3);
                //..
                //G.DrawString(txt7, font3, brush2, txtLoc7);

                //  G.FillRectangle(brush1, new RectangleF(rBorder - 1.5f, 52f, 1.5f, 46f));

            }
            var imgsave = new Bitmap(bmp);
            imgsave.Clone();
            imgsave.Save(folderStorage +"\\"+ txt_hoten.Text+".png",System.Drawing.Imaging.ImageFormat.Png);
            imgDisplay = new Bitmap(bmp);
            imgDisplay.Clone();
            pic_theview.Image = imgDisplay;
            font1.Dispose();
            font2.Dispose();
            font3.Dispose();

            photo.Dispose();
          //  imgsave.Dispose();

           
            
     

        }

        private void button1_Click(object sender, EventArgs e)
        {
            testDrawEmployeeCard();
        }
        private void Picture_box_object_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (img_camera.Focused)
                img_camera.Parent.Focus();
        }

        private void Picture_box_object_MouseLeave(object sender, EventArgs e)
        {
            if (img_camera.Focused)
                img_camera.Parent.Focus();
        }

        private void Picture_box_object_MouseEnter(object sender, EventArgs e)
        {
            if (!img_camera.Focused)
                img_camera.Focus();
        }

        private void btn_Start_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (btn_Start.Text == "START")
                {
                    _capture.Stop();
                   
                   btn_Start.Text = "STOP";
                }
                else if (btn_Start.Text == "STOP")
                {
                    _capture.Start();

                    btn_Start.Text = "START";
                }
               
            }
            else
            {
                _capture = new VideoCapture();
            }
                
        }

        private void PrintEmployeeCard_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveObject.Save_data(configureFolder + @"\Configure.ini", ConfigureLoad);
        }

        private void btn_chuphinh_Click(object sender, EventArgs e)
        {
            img_camera.ClearOperation();
            if ((string)btn_chuphinh.Text== "Chụp Hình")
            {
                try
                {
                    img_camera.Image = null;
                    Mat m = new Mat();
                    _capture.Retrieve(m);
                    img_camera.Image = m.ToImage<Bgr, byte>();
                    if (My_rectangle == null)
                    {
                        My_rectangle = new My_Rectangle_Affine(new System.Drawing.Rectangle(ConfigureLoad.rect.X, ConfigureLoad.rect.Y, ConfigureLoad.rect.Width, ConfigureLoad.rect.Height));
                        My_rectangle.SetPictureBox(img_camera);
                    }
                    Thread.Sleep((int)_capture.GetCaptureProperty(Emgu.CV.CvEnum.CapProp.Fps));
                    _capture.Stop();
                    btn_cathinh.Visible = true;
                }
                catch (Exception ex)
                {

                    System.Windows.Forms.MessageBox.Show(ex.Message);

                }
            }
            else if ((string)btn_chuphinh.Text == "Tải Ảnh")
            {
                img_camera.Image.Dispose();
                img_camera.Image = null;
                System.Windows.Forms.OpenFileDialog Openfile = new System.Windows.Forms.OpenFileDialog();
                if (Openfile.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imgInput = new Image<Bgr, byte>(Openfile.FileName);
                    if (imgInput.Size.Width >= 1200 && imgInput.Size.Height >= 600)
                    {
                        imgInput = imgInput.Resize(0.7, Inter.Linear);
                    }
                    img_camera.Image = imgInput;
                    btn_cathinh.Visible = true;
                    if (My_rectangle == null)
                    {
                        My_rectangle = new My_Rectangle_Affine(new System.Drawing.Rectangle(ConfigureLoad.rect.X, ConfigureLoad.rect.Y, ConfigureLoad.rect.Width, ConfigureLoad.rect.Height));
                        My_rectangle.SetPictureBox(img_camera);
                    }

                }
            }
            CleanMemory();
        }
        public static void CleanMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        private void btn_cathinh_Click(object sender, EventArgs e)
        {
            if (img_camera != null && img_camera.Image != null)
            {
                PointF[] PointfTemp = ImageProcessing.Return_point_Rect(ImageProcessing.Round_rectangle_Polyon(My_rectangle._Array_4_Point.ToList()));
                PointF[] PointfReal = ImageProcessing.Convert_point_scale_for_save(img_camera, PointfTemp);
                System.Drawing.Rectangle rect = rectangle_Polyon(PointfReal.ToList());

                ConfigureLoad.rect = rectangle_Polyon(PointfTemp.ToList());

                imgInput.ROI = rect;

                img_cat.Image = imgInput;
                BitmapFace = imgInput.Bitmap;
                btn_print.Enabled = true;
                CleanMemory();
            }
            else
            {
                MessageBox.Show("Bạn phải chụp hình trước khi cắt ảnh", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        public System.Drawing.Rectangle rectangle_Polyon(List<PointF> points)
        {
            var minX = points.Min(p => p.X);
            var minY = points.Min(p => p.Y);
            var maxX = points.Max(p => p.X);
            var maxY = points.Max(p => p.Y);

            return new System.Drawing.Rectangle(new System.Drawing.Point((int)minX, (int)minY), new System.Drawing.Size((int)maxX - (int)minX, (int)maxY - (int)minY));
        }

        private void btn_print_Click_1(object sender, EventArgs e)
        {if (pic_theview.Image != null)
            {
                PrintDocument pd = new PrintDocument();
                pd.PrintPage += PrintPage;
                //here to select the printer attached to user PC
                PrintDialog printDialog1 = new PrintDialog();
                printDialog1.Document = pd;
                DialogResult result = printDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pd.Print();//this will trigger the Print Event handeler PrintPage
                }
            }
        else
            {
                MessageBox.Show("Bạn phải xuất thẻ trước khi in", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += PrintPage;
           
            //here to select the printer attached to user PC
            PrintDialog printDialog1 = new PrintDialog();
            printDialog1.AllowPrintToFile = true;
            printDialog1.AllowSomePages = true;
            printDialog1.PrinterSettings.MinimumPage = 1;
           
            
            printDialog1.PrinterSettings.FromPage = 1;
           
            printDialog1.Document = pd;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pd.Print();//this will trigger the Print Event handeler PrintPage
            }
        }

        //The Print Event handeler
        private void PrintPage(object o, PrintPageEventArgs e)
        {
            try
            {
              //  if (File.Exists(this.path))
                {
                    //Load the image from the file
                    System.Drawing.Image img = System.Drawing.Image.FromFile(folderStorage+ "\\" + txt_hoten.Text + ".png");

                    //Adjust the size of the image to the page to print the full image without loosing any part of it
                    Rectangle m = e.MarginBounds;

                    if ((double)img.Width / (double)img.Height > (double)m.Width / (double)m.Height) // image is wider
                    {
                        m.Height = (int)((double)img.Height / (double)img.Width * (double)m.Width);
                    }
                    else
                    {
                        m.Width = (int)((double)img.Width / (double)img.Height * (double)m.Height);
                    }
                    e.Graphics.DrawImage(img, m.X,m.Y,335,225);
                }
            }
            catch (Exception)
            {

            }
        }

        private void btn_xuatpdf_Click(object sender, EventArgs e)
        {/*if(pic_theview.Image !=null )*/
            testDrawEmployeeCard();
        //else
        //    {
        //        MessageBox.Show("Bạn phải chụp hình trước khi cắt ảnh", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        }

        private void Rd_camera_CheckedChanged(object sender, EventArgs e)
        {
           if(rd_camera.Checked)
            {
                btn_chuphinh.Text = "Chụp Hình";
                rd_picture.Checked = false;

            }
            else
            {
                btn_chuphinh.Text = "Tải Ảnh";
                rd_picture.Checked = true;
                CloseCamera();
            }
           
        }

        private void Rd_picture_CheckedChanged(object sender, EventArgs e)
        {if (rd_picture.Checked)
            {
                btn_chuphinh.Text = "Tải Ảnh";
                rd_camera.Checked = false;
            }
        else
            {
                btn_chuphinh.Text = "Chụp Hình";
                rd_camera.Checked = true;
                LoadCamera();
            }
        }
    
        private void CloseCamera()
        {

            try
            {

                if (_capture != null)
                {


                    _capture.ImageGrabbed -= _capture_ImageGrabbed;
                    _capture.Pause();
                    _capture.Stop();
                    _capture.Dispose();
                  
                    btn_Start.Text = "STOP";
                    _capture = null;
                }
            }
            catch (Exception ex)
            {


                System.Windows.Forms.MessageBox.Show("Camera can't close : " + ex.Message);
            }
        }
    }

}
