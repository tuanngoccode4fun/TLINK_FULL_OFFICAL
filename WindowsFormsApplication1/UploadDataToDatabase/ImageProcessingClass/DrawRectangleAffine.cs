
using Emgu.CV;
using Emgu.CV.UI;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;



namespace UploadDataToDatabase
{

    [Serializable]
    public class ConfigureSave
    {
     
        public System.Drawing.Rectangle rect { get; set; }
        public string Printer { get; set; }

    }



    public class My_Rectangle_Affine
    {
        public PointF[] _Array_4_Point;
        public PointF[] _Array_4_Point_region = null;
        public ImageBox mPictureBox;
        int sizeNodeRect = 6;
        private float[] Array_Y = new float[4];
        private float[] Array_X = new float[4];
        private float oldW_Picture_box;
        private float oldH_Picture_box;
        private float oldW_Image;
        private float oldH_Image;
        private float oldX;
        private float oldY;
        private bool mIsClick = false;
        private bool mMove = false;
        private bool mMove_region = false;
        public float Center_x = 0;
        public float Center_y = 0;
        public float Center_region_x = 0;
        public float Center_region_y = 0;
        private PosSizableRect nodeSelected = PosSizableRect.None;
        [DllImport("User32.dll")]
        private static extern IntPtr LoadCursorFromFile(string str);
        IntPtr Get_cur_resize = LoadCursorFromFile(Environment.CurrentDirectory + @"\Resources\Resize.cur");//phai sua nho add resource and always copy
        IntPtr Get_cur_move = LoadCursorFromFile(Environment.CurrentDirectory + @"\Resources\move.cur");//phai sua nho add resource and always copy
        public Color _Set_color = Color.Red;
        bool Check_second = false;
        bool Check_X = false;
        System.Drawing.RectangleF Rectt;
        float X = 0;
        float Y = 0;
        double scale = 1;
        Graphics gfxScreenshot = null;

        private enum PosSizableRect
        {
            LeftBottom,
            LeftUp,
            RightUp,
            RightBottom,
            Centeroid,
            LeftBottom_region,
            LeftUp_region,
            RightUp_region,
            RightBottom_region,
            Centeroid_region,
            None


        };
        public My_Rectangle_Affine(PointF[] input_reload)
        {
            _Array_4_Point = input_reload;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Rect"></param>
        public My_Rectangle_Affine(System.Drawing.Rectangle Rect)
        {
            _Array_4_Point = Convert_Rect_4_Point(Rect);//get pointF
        }
        public My_Rectangle_Affine(PointF[] Rect, PointF[] Rect_region)
        {
            _Array_4_Point = Rect;//get pointF
            _Array_4_Point_region = Rect_region;
            mMove_region = true;
        }
        public static PointF[] Convert_Rect_4_Point(System.Drawing.Rectangle Rect)
        {
            PointF[] _Array_Temp = new PointF[4];
            _Array_Temp[0] = new PointF(Rect.X, Rect.Y);
            _Array_Temp[1] = new PointF(Rect.X + Rect.Width, Rect.Y);
            _Array_Temp[2] = new PointF(Rect.X + Rect.Width, Rect.Y + Rect.Height);
            _Array_Temp[3] = new PointF(Rect.X, Rect.Y + Rect.Height);
            return _Array_Temp;
        }
        /// </summary>
        /// <param name="Rect"></param>
        /// <returns></returns>

        /// <summary>
        /// collect information my rectangle affine
        /// </summary>
        /// <param name="Center_Point"></param>
        /// <returns></returns>

        public void SetPictureBox(ImageBox p)
        {

            this.mPictureBox = p;
            mPictureBox.FunctionalMode = ImageBox.FunctionalModeOption.Minimum;
            mPictureBox.Resize += MPictureBox_Resize;
            mPictureBox.MouseEnter += MPictureBox_MouseEnter;
            mPictureBox.MouseLeave += MPictureBox_MouseLeave;
            mPictureBox.MouseDown += new MouseEventHandler(mPictureBox_MouseDown);
            mPictureBox.MouseUp += new MouseEventHandler(mPictureBox_MouseUp);
            mPictureBox.MouseMove += new MouseEventHandler(mPictureBox_MouseMove);
            mPictureBox.Paint += new PaintEventHandler(mPictureBox_Paint);
            mPictureBox.MouseWheel += new MouseEventHandler(Picture_box_MouseWheel);
        }

        private void MPictureBox_MouseLeave(object sender, EventArgs e)
        {
            if (mPictureBox.Focused)
            {
                mPictureBox.Parent.Focus();
            }
            Debug.WriteLine(_Array_4_Point_region);
        }

        private void MPictureBox_MouseEnter(object sender, EventArgs e)
        {
            if (!mPictureBox.Focused)
            {
                mPictureBox.Focus();
            }
            Debug.WriteLine(_Array_4_Point_region);
        }

        //public Bitmap grab_picture_screen(int X, int Y, int SIZE)
        //{
        //    System.Drawing.Rectangle rect = Support_running.CreateRectSizableNode(X, Y, SIZE);
        //    Bitmap bmpScreenshot;
        //    try
        //    {
        //        bmpScreenshot = new Bitmap(rect.Width,
        //                          rect.Height);
        //        gfxScreenshot = Graphics.FromImage(bmpScreenshot);
        //        gfxScreenshot.CopyFromScreen(rect.X,
        //                                    rect.Y,
        //                                    0,
        //                                    0,
        //                                    bmpScreenshot.Size);
        //        gfxScreenshot = null;
        //        return bmpScreenshot;
        //    }
        //    catch
        //    {
        //        return null;
        //    }
        //}
       
        private void Picture_box_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                if (e.Delta < 0)
                {
                    //mPictureBox.Scale( e.X, e.Y);
                    //Picture_box.Top = (int)(Picture_box.Top + (Picture_box.Height * 0.025));
                    //Picture_box.Left = (int)(Picture_box.Left + (Picture_box.Width * 0.025));

                    //mPictureBox.Height = (int)(mPictureBox.Height - (mPictureBox.Height * 0.05));
                    //mPictureBox.Width = (int)(mPictureBox.Width - (mPictureBox.Width * 0.05));
                    //mPictureBox.Top = (int)(e.Y + 1.05 * (e.Y - mPictureBox.Top));
                    //mPictureBox.Left = (int)(e.X + 1.05 * (e.X - mPictureBox.Left));
                    scale = scale - 0.05;
                    mPictureBox.SetZoomScale(scale, new System.Drawing.Point(e.X, e.Y));
                }
                else
                {
                    //Picture_box.Top = (int)(Picture_box.Top - (Picture_box.Height * 0.025));
                    //Picture_box.Left = (int)(Picture_box.Left - (Picture_box.Width * 0.025));
                    //mPictureBox.Height = (int)(mPictureBox.Height + (mPictureBox.Height * 0.05));
                    //mPictureBox.Width = (int)(mPictureBox.Width + (mPictureBox.Width * 0.05));
                    //mPictureBox.Height = (int)(mPictureBox.Height + (mPictureBox.Height * 0.05));
                    //mPictureBox.Width = (int)(mPictureBox.Width + (mPictureBox.Width * 0.05));
                    //mPictureBox.Top = (int)(e.Y - 1.05 * (e.Y - mPictureBox.Top));
                    //mPictureBox.Left = (int)(e.X - 1.05 * (e.X - mPictureBox.Left));
                    scale = scale + 0.05;
                    mPictureBox.SetZoomScale(scale, new System.Drawing.Point(e.X, e.Y));
                }
            }
            catch (Exception EX)
            {
             //   Log.Output(StatusLog.Warning, EX.Message);
                return;
            }
            //run_move_auto_resize();
        }
        //private void run_move_auto_resize()
        //{
        //    Rectt = GetImageRectangle(mPictureBox);

        //    //if (oldW_Picture_box != mPictureBox.Width && oldH_Picture_box != mPictureBox.Height)
        //    //{
        //    if (Rectt.Y > 0)
        //    {
        //        //if (Check_X == true)
        //        //{
        //        //    for (int i = 0; i < 4; i++)
        //        //    {
        //        //        _Array_4_Point[i].X = Array_X[i];
        //        //    }
        //        //    oldW_Picture_box = oldW_Image;
        //        //}

        //        run_move_auto_resize_W_in();
        //        //Check_X = false;
        //    }
        //    if (Rectt.X > 0)
        //    {
        //        if (Check_X == false)
        //        {
        //            for (int i = 0; i < 4; i++)
        //            {
        //                _Array_4_Point[i].Y = ((Array_Y[i] / oldH_Image) * mPictureBox.Height);
        //            }
        //        }
        //        run_move_auto_resize_W_out();
        //        Check_X = true;
        //    }
        //    //return;
        //    //}

        //    if (oldW_Picture_box != mPictureBox.Width)
        //    {
        //        //if (Rectt.Y > 0)
        //        //{
        //        //    if (Check_X == true)
        //        //    {
        //        //        for (int i = 0; i < 4; i++)
        //        //        {
        //        //            _Array_4_Point[i].X = Array_X[i];
        //        //        }
        //        //        oldW_Picture_box = oldW_Image;
        //        //    }

        //        //    run_move_auto_resize_W_in();
        //        //    Check_X = false;
        //        //}
        //        //if (Rectt.X > 0)
        //        //{
        //        //    if (Check_X == false)
        //        //    {
        //        //        for (int i = 0; i < 4; i++)
        //        //        {
        //        //            _Array_4_Point[i].Y = ((Array_Y[i] / oldH_Image) * mPictureBox.Height);
        //        //        }
        //        //    }
        //        //    run_move_auto_resize_W_out();
        //        //    Check_X = true;
        //        //}
        //        //return;
        //    }
        //    if (oldH_Picture_box != mPictureBox.Height)
        //    {
        //        //if (Rectt.Y > 0)
        //        //{
        //        //    if (Check_X == true)
        //        //    {
        //        //        for (int i = 0; i < 4; i++)
        //        //        {
        //        //            _Array_4_Point[i].X = (Array_X[i] / oldW_Image) * Rectt.Width;
        //        //            _Array_4_Point[i].Y = (Array_Y[i] / oldH_Picture_box) * Rectt.Height;
        //        //            Array_Y[i] = _Array_4_Point[i].Y;
        //        //        }
        //        //        oldW_Picture_box = Rectt.Width;
        //        //    }
        //        //    run_move_auto_resize_H_in();
        //        //    Check_X = false;
        //        //}
        //        //if (Rectt.X > 0)
        //        //{
        //        //    if (Check_X == false)
        //        //    {
        //        //        for (int i = 0; i < 4; i++)
        //        //        {
        //        //            _Array_4_Point[i].Y = Array_Y[i];
        //        //        }
        //        //        oldH_Picture_box=oldH_Image;
        //        //    }
        //        //    run_move_auto_resize_H_out();
        //        //    Check_X = true;
        //        //}
        //        //return;
        //    }

        //}
        //private System.Drawing.Rectangle GetImageRectangle(this PictureBox pb)
        //{
        //    var rect = pb.ClientRectangle;
        //    var padding = pb.Padding;
        //    rect.X += padding.Left;
        //    rect.Y += padding.Top;
        //    rect.Width -= padding.Horizontal;
        //    rect.Height -= padding.Vertical;
        //    var image = pb.Image;
        //    var sizeMode = pb.SizeMode;
        //    //if (sizeMode == PictureBoxSizeMode.Normal || sizeMode == PictureBoxSizeMode.AutoSize)
        //    //    rect.Size = image.Size;
        //    //else if (sizeMode == PictureBoxSizeMode.CenterImage)
        //    //{
        //    //    rect.X += (rect.Width - image.Width) / 2;
        //    //    rect.Y += (rect.Height - image.Height) / 2;
        //    //    rect.Size = image.Size;
        //    //}
        //    if (sizeMode == PictureBoxSizeMode.Zoom)
        //    {
        //        var imageSize = image.Size;
        //        var zoomSize = pb.ClientSize;
        //        float ratio = Math.Min((float)zoomSize.Width / imageSize.Width, (float)zoomSize.Height / imageSize.Height);
        //        rect.Width = (int)(imageSize.Width * ratio);
        //        rect.Height = (int)(imageSize.Height * ratio);
        //        rect.X = (pb.ClientRectangle.Width - rect.Width) / 2;
        //        rect.Y = (pb.ClientRectangle.Height - rect.Height) / 2;
        //    }
        //    return rect;
        //}
        private void run_move_auto_resize_W_out()
        {
            X = ((float)mPictureBox.Width - (float)Rectt.Width) / 2;
            if (Check_second)
            {

                for (int i = 0; i < 4; i++)
                {
                    _Array_4_Point[i].X = X + ((Array_X[i] / oldW_Image) * (float)Rectt.Width);
                    _Array_4_Point[i].Y = (_Array_4_Point[i].Y / oldH_Picture_box) * (float)mPictureBox.Height;

                }
            }
            oldW_Picture_box = mPictureBox.Width;
            oldH_Picture_box = mPictureBox.Height;
            oldW_Image = Rectt.Width;
            oldH_Image = Rectt.Height;
            for (int K = 0; K < 4; K++)
            {
                Array_X[K] = (_Array_4_Point[K].X - X);
                Array_Y[K] = _Array_4_Point[K].Y;
            }
            Check_second = true;
        }
        private void run_move_auto_resize_H_out()
        {
            X = ((float)mPictureBox.Width - (float)Rectt.Width) / 2;
            if (Check_second)
            {

                for (int i = 0; i < 4; i++)
                {
                    _Array_4_Point[i].X = X + ((Array_X[i] / oldW_Image) * (float)Rectt.Width);
                    _Array_4_Point[i].Y = (_Array_4_Point[i].Y / oldH_Picture_box) * (float)mPictureBox.Height;

                }
            }
            oldW_Picture_box = mPictureBox.Width;
            oldH_Picture_box = mPictureBox.Height;
            oldW_Image = Rectt.Width;
            oldH_Image = Rectt.Height;
            for (int K = 0; K < 4; K++)
            {
                Array_X[K] = (_Array_4_Point[K].X - X);
                Array_Y[K] = _Array_4_Point[K].Y;
            }
            Check_second = true;
        }
        private void run_move_auto_resize_W_in()
        {

            Y = ((float)mPictureBox.Height - (float)Rectt.Height) / 2;
            if (Check_second)
            {

                for (int i = 0; i < 4; i++)
                {

                    _Array_4_Point[i].X = (_Array_4_Point[i].X / oldW_Picture_box) * (float)mPictureBox.Width;
                    _Array_4_Point[i].Y = Y + ((Array_Y[i] / oldH_Image) * (float)Rectt.Height);
                }
            }
            oldW_Picture_box = mPictureBox.Width;
            oldH_Picture_box = mPictureBox.Height;
            oldW_Image = Rectt.Width;
            oldH_Image = Rectt.Height;
            for (int K = 0; K < 4; K++)
            {
                Array_Y[K] = (_Array_4_Point[K].Y - Y);
                Array_X[K] = _Array_4_Point[K].X;
            }
            Check_second = true;
        }
        private void run_move_auto_resize_H_in()
        {

            Y = ((float)mPictureBox.Height - (float)Rectt.Height) / 2;
            if (Check_second)
            {

                for (int i = 0; i < 4; i++)
                {

                    _Array_4_Point[i].X = (_Array_4_Point[i].X / oldW_Picture_box) * (float)mPictureBox.Width;
                    _Array_4_Point[i].Y = Y + Array_Y[i];
                }
            }
            oldW_Picture_box = mPictureBox.Width;
            oldH_Picture_box = mPictureBox.Height;
            oldW_Image = Rectt.Width;
            oldH_Image = Rectt.Height;
            for (int K = 0; K < 4; K++)
            {
                Array_Y[K] = (_Array_4_Point[K].Y - Y);
                Array_X[K] = _Array_4_Point[K].X;
            }
            Check_second = true;
        }
        private void MPictureBox_Resize(object sender, EventArgs e)
        {
            //run_move_auto_resize();
        }

    
        private Bitmap convert(Image input)
        {
            Bitmap originalBmp = new Bitmap(input);
            Bitmap tempBitmap = new Bitmap(originalBmp.Width, originalBmp.Height);
            using (Graphics g = Graphics.FromImage(tempBitmap))
            {
                g.DrawImage(originalBmp, 0, 0);
            }
            return tempBitmap;
        }
        /// <summary>
        /// 0 Background white , 1 background black
        /// </summary>
        /// <param name="srcImagee"></param>
        /// <param name="Rect_round"></param>
        /// <param name="white"></param>
        /// <returns></returns>
        //public Image Crop_image(Image srcImagee,out System.Drawing.Rectangle Rect_round,int white)
        //{
        //    Image image_convert = convert(srcImagee);
        //    Rect_round = Round_rectangle_Polyon(_Array_4_Point.ToList());
        //    Image dstImage = new Bitmap(image_convert.Width, image_convert.Height, image_convert.PixelFormat);
        //    Image dstImage_final = new Bitmap(Rect_round.Width, Rect_round.Height, image_convert.PixelFormat);
        //    Graphics g = Graphics.FromImage(dstImage);
        //    Graphics g_final= Graphics.FromImage(dstImage_final);
        //    Color Cl = (white == 0) ? Color.White : Color.Black;
        //    using (Brush br = new SolidBrush(Cl))
        //    {
        //        g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
        //    }
        //    GraphicsPath path = new GraphicsPath();
        //    path.AddPolygon(_Array_4_Point);
        //    Region Regi = new Region(path);
        //    g.SetClip(Regi, CombineMode.Replace);
        //    g.DrawImage(image_convert, 0, 0);
        //    g_final.DrawImage(dstImage, new RectangleF(0, 0, Rect_round.Width, Rect_round.Height), Rect_round, GraphicsUnit.Pixel);
        //    return dstImage_final;
        //}
        //public Image Crop_image_Retangle(Image srcImagee, out System.Drawing.Rectangle Rect_round, int white)
        //{
        //    Image image_convert = convert(srcImagee);
        //    Rect_round = Round_rectangle_Polyon(_Array_4_Point.ToList());
        //    Image dstImage = new Bitmap(image_convert.Width, image_convert.Height, image_convert.PixelFormat);
        //    Image dstImage_final = new Bitmap(Rect_round.Width, Rect_round.Height, image_convert.PixelFormat);
        //    Graphics g = Graphics.FromImage(dstImage);
        //    Graphics g_final = Graphics.FromImage(dstImage_final);
        //    Color Cl = (white == 0) ? Color.White : Color.Black;
        //    using (Brush br = new SolidBrush(Cl))
        //    {
        //        g.FillRectangle(br, 0, 0, dstImage.Width, dstImage.Height);
        //    }
        //    GraphicsPath path = new GraphicsPath();
        //    path.AddRectangle(Rect_round);
        //    Region Regi = new Region(path);
        //    g.SetClip(Regi, CombineMode.Replace);
        //    g.DrawImage(image_convert, 0, 0);
        //    g_final.DrawImage(dstImage, new RectangleF(0, 0, Rect_round.Width, Rect_round.Height), Rect_round, GraphicsUnit.Pixel);
        //    return dstImage_final;
        //}
        private void mPictureBox_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Draw(e.Graphics);
            }
            catch (Exception ex)
            {
              //  Log.Output(StatusLog.Error, "mPictureBox_Paint" + ex.Message);
            }
        }

        private void mPictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (mPictureBox.Focused)
            {
                mPictureBox.Parent.Focus();
            }
            ChangeCursor(e.Location);
            if (mIsClick == false)
            {
                return;
            }
            Check_second = false;
            switch (nodeSelected)
            {
                case PosSizableRect.LeftUp:
                    _Array_4_Point[0].X = _Array_4_Point[0].X + e.X - oldX;
                    _Array_4_Point[0].Y = _Array_4_Point[0].Y + e.Y - oldY;
                    break;
                case PosSizableRect.LeftUp_region:
                    _Array_4_Point_region[0].X = _Array_4_Point_region[0].X + e.X - oldX;
                    _Array_4_Point_region[0].Y = _Array_4_Point_region[0].Y + e.Y - oldY;
                    break;
                //case PosSizableRect.LeftMiddle:
                //    rect.X += e.X - oldX;
                //    rect.Width -= e.X - oldX;
                //    break;
                case PosSizableRect.LeftBottom:
                    _Array_4_Point[3].X = _Array_4_Point[3].X + e.X - oldX;
                    _Array_4_Point[3].Y = _Array_4_Point[3].Y + e.Y - oldY;
                    break;
                case PosSizableRect.LeftBottom_region:
                    _Array_4_Point_region[3].X = _Array_4_Point_region[3].X + e.X - oldX;
                    _Array_4_Point_region[3].Y = _Array_4_Point_region[3].Y + e.Y - oldY;
                    break;
                //case PosSizableRect.BottomMiddle:
                //    rect.Height += e.Y - oldY;
                //    break;
                case PosSizableRect.RightUp:
                    _Array_4_Point[1].X = _Array_4_Point[1].X + e.X - oldX;
                    _Array_4_Point[1].Y = _Array_4_Point[1].Y + e.Y - oldY;
                    break;
                case PosSizableRect.RightUp_region:
                    _Array_4_Point_region[1].X = _Array_4_Point_region[1].X + e.X - oldX;
                    _Array_4_Point_region[1].Y = _Array_4_Point_region[1].Y + e.Y - oldY;
                    break;
                case PosSizableRect.RightBottom:
                    _Array_4_Point[2].X = _Array_4_Point[2].X + e.X - oldX;
                    _Array_4_Point[2].Y = _Array_4_Point[2].Y + e.Y - oldY;
                    break;
                case PosSizableRect.RightBottom_region:
                    _Array_4_Point_region[2].X = _Array_4_Point_region[2].X + e.X - oldX;
                    _Array_4_Point_region[2].Y = _Array_4_Point_region[2].Y + e.Y - oldY;
                    break;
                //case PosSizableRect.RightMiddle:
                //    rect.Width += e.X - oldX;
                //    break;

                //case PosSizableRect.UpMiddle:
                //    rect.Y += e.Y - oldY;
                //    rect.Height -= e.Y - oldY;
                //    break;

                default:
                    if (mMove)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            _Array_4_Point[i].X = _Array_4_Point[i].X + e.X - oldX;
                            _Array_4_Point[i].Y = _Array_4_Point[i].Y + e.Y - oldY;
                        }

                    }
                    if (mMove_region)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            _Array_4_Point_region[i].X = _Array_4_Point_region[i].X + e.X - oldX;
                            _Array_4_Point_region[i].Y = _Array_4_Point_region[i].Y + e.Y - oldY;
                        }

                    }
                    break;
            }
            oldX = e.X;
            oldY = e.Y;
            //run_move_auto_resize();
            mPictureBox.Invalidate();
        }

        private void mPictureBox_MouseUp(object sender, MouseEventArgs e)
        {

            mIsClick = false;
            mMove = false;

        }

        private void mPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            mIsClick = true;
            nodeSelected = PosSizableRect.None;
            nodeSelected = GetNodeSelectable(e.Location);
            if (nodeSelected == PosSizableRect.Centeroid)
            {
                mMove = true;
            }
            if (nodeSelected == PosSizableRect.Centeroid_region)
            {
                mMove_region = true;
            }
            oldX = e.X;
            oldY = e.Y;
        }

        private PosSizableRect GetNodeSelectable(System.Drawing.Point p)
        {
            foreach (PosSizableRect r in Enum.GetValues(typeof(PosSizableRect)))
            {
                if (_Array_4_Point_region == null)
                {
                    if (!r.ToString().Contains("region"))
                    {
                        if (GetRect(r).Contains(p))
                        {
                            return r;
                        }
                    }
                }
                else
                {
                    if (GetRect(r).Contains(p))
                    {
                        return r;
                    }
                }

            }
            return PosSizableRect.None;
        }

        private System.Drawing.Rectangle GetRect(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return CreateRectSizableNode((int)_Array_4_Point[0].X, (int)_Array_4_Point[0].Y);

                case PosSizableRect.LeftUp_region:
                    return CreateRectSizableNode((int)_Array_4_Point_region[0].X, (int)_Array_4_Point_region[0].Y);
                //case PosSizableRect.LeftMiddle:
                //    return CreateRectSizableNode(rect.X, rect.Y + +rect.Height / 2);

                case PosSizableRect.LeftBottom:
                    return CreateRectSizableNode((int)_Array_4_Point[3].X, (int)_Array_4_Point[3].Y);

                case PosSizableRect.LeftBottom_region:
                    return CreateRectSizableNode((int)_Array_4_Point_region[3].X, (int)_Array_4_Point_region[3].Y);

                //case PosSizableRect.BottomMiddle:
                //    return CreateRectSizableNode(rect.X + rect.Width / 2, rect.Y + rect.Height);

                case PosSizableRect.RightUp:
                    return CreateRectSizableNode((int)_Array_4_Point[1].X, (int)_Array_4_Point[1].Y);

                case PosSizableRect.RightUp_region:
                    return CreateRectSizableNode((int)_Array_4_Point_region[1].X, (int)_Array_4_Point_region[1].Y);


                case PosSizableRect.RightBottom:
                    return CreateRectSizableNode((int)_Array_4_Point[2].X, (int)_Array_4_Point[2].Y);

                case PosSizableRect.RightBottom_region:
                    return CreateRectSizableNode((int)_Array_4_Point_region[2].X, (int)_Array_4_Point_region[2].Y);

                //case PosSizableRect.RightMiddle:
                //    return CreateRectSizableNode(rect.X + rect.Width, rect.Y + rect.Height / 2);

                //case PosSizableRect.UpMiddle:
                //    return CreateRectSizableNode(rect.X + rect.Width / 2, rect.Y);
                case PosSizableRect.Centeroid:
                    return CreateRectSizableNode((int)Center_x, (int)Center_y);
                case PosSizableRect.Centeroid_region:
                    return CreateRectSizableNode((int)Center_region_x, (int)Center_region_y);
                default:
                    return new System.Drawing.Rectangle();
            }
        }
        private void ChangeCursor(System.Drawing.Point p)
        {
            mPictureBox.Cursor = GetCursor(GetNodeSelectable(p));
        }
        private Cursor GetCursor(PosSizableRect p)
        {
            switch (p)
            {
                case PosSizableRect.LeftUp:
                    return Cursor.Current = new Cursor(Get_cur_resize);
                case PosSizableRect.LeftUp_region:
                    return Cursor.Current = new Cursor(Get_cur_resize);
                //case PosSizableRect.LeftMiddle:
                //    return Cursors.SizeWE;

                case PosSizableRect.LeftBottom:
                    return Cursor.Current = new Cursor(Get_cur_resize);
                case PosSizableRect.LeftBottom_region:
                    return Cursor.Current = new Cursor(Get_cur_resize);

                //case PosSizableRect.BottomMiddle:
                //    return Cursors.SizeNS;

                case PosSizableRect.RightUp:
                    return Cursor.Current = new Cursor(Get_cur_resize);
                case PosSizableRect.RightUp_region:
                    return Cursor.Current = new Cursor(Get_cur_resize);

                case PosSizableRect.RightBottom:
                    return Cursor.Current = new Cursor(Get_cur_resize);
                case PosSizableRect.RightBottom_region:
                    return Cursor.Current = new Cursor(Get_cur_resize);

                //case PosSizableRect.RightMiddle:
                //    return Cursors.SizeWE;

                case PosSizableRect.Centeroid:
                    return Cursor.Current = new Cursor(Get_cur_move);
                case PosSizableRect.Centeroid_region:
                    return Cursor.Current = new Cursor(Get_cur_move);
                default:
                    return Cursors.Default;
            }
        }


        private System.Drawing.Rectangle CreateRectSizableNode(int x, int y)
        {
            return new System.Drawing.Rectangle(x - sizeNodeRect / 2, y - sizeNodeRect / 2, sizeNodeRect, sizeNodeRect);
        }
        public System.Drawing.Rectangle CreateRectSizableNode(int x, int y, int sizeNodeRectt)
        {
            return new System.Drawing.Rectangle(x - sizeNodeRectt / 2, y - sizeNodeRectt / 2, sizeNodeRectt, sizeNodeRectt);
        }

        public void Draw(Graphics g)
        {
            #region //draw normal object
            Center_x = (_Array_4_Point[0].X + _Array_4_Point[1].X + _Array_4_Point[2].X + _Array_4_Point[3].X) / 4;
            Center_y = (_Array_4_Point[0].Y + _Array_4_Point[1].Y + _Array_4_Point[2].Y + _Array_4_Point[3].Y) / 4;
            g.DrawPolygon(new Pen(Color.Red), _Array_4_Point);
            int i = 0;
            foreach (PointF item in _Array_4_Point.ToList())
            {
                if (i == 0)
                {
                    g.DrawRectangle(new Pen(Color.Red, 3), CreateRectSizableNode((int)item.X, (int)item.Y));
                    i++;
                }
                else if (i == 1)
                {
                    g.DrawRectangle(new Pen(Color.Red, 2), CreateRectSizableNode((int)item.X, (int)item.Y));
                    i++;
                }
                else
                {
                    g.DrawRectangle(new Pen(Color.Red), CreateRectSizableNode((int)item.X, (int)item.Y));
                    i++;
                }

            }
            g.DrawRectangle(new Pen(Color.Red), CreateRectSizableNode((int)Center_x, (int)Center_y));
            #endregion

            #region // draw region
            if (_Array_4_Point_region != null)
            {
                //Center_region_x = (_Array_4_Point_region[0].X + _Array_4_Point_region[1].X + _Array_4_Point_region[2].X + _Array_4_Point_region[3].X) / 4;
                //Center_region_y = (_Array_4_Point_region[0].Y + _Array_4_Point_region[1].Y + _Array_4_Point_region[2].Y + _Array_4_Point_region[3].Y) / 4;
                g.DrawPolygon(new Pen(Color.Blue), _Array_4_Point_region);
                foreach (PointF item in _Array_4_Point_region.ToList())
                {
                    g.DrawRectangle(new Pen(Color.Blue), CreateRectSizableNode((int)item.X, (int)item.Y));
                }
                //g.DrawRectangle(new Pen(Color.Blue), CreateRectSizableNode((int)Center_region_x, (int)Center_region_y));
            }


            #endregion
            g = null;
        }

    }
}
