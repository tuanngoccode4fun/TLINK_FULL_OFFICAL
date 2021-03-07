using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace UploadDataToDatabase
{
    public static  class ImageProcessing

    {
        public static Rectangle CropImage(this PictureBox pb, int x, int y, int w, int h)
        {
            var imageRect = pb.GetImageRectangle();
            var image = pb.Image;
            float scaleX = (float)image.Width / imageRect.Width;
            float scaleY = (float)image.Height / imageRect.Height;
            var cropRect = new Rectangle();
            cropRect.X = Scale(x - imageRect.X, scaleX, image.Width);
            cropRect.Y = Scale(y - imageRect.Y, scaleY, image.Height);
            cropRect.Width = Scale(w, scaleX, image.Width - cropRect.X);
            cropRect.Height = Scale(h, scaleY, image.Height - cropRect.Y);
            //var result = new Bitmap(cropRect.Width, cropRect.Height, image.PixelFormat);
            //using (var g = Graphics.FromImage(result))
            //    g.DrawImage(image, new Rectangle(new Point(0, 0), cropRect.Size), cropRect, GraphicsUnit.Pixel);
            //return result;
            return cropRect;
        }

        public static PointF[] Convert_point_scale_for_save(this PictureBox pb, PointF[] Input_array_point)
        {
            PointF[] _Array_return = new PointF[4];
            var imageRect = pb.GetImageRectangle();
            var image = pb.Image;
            float scaleX = (float)image.Width / imageRect.Width;
            float scaleY = (float)image.Height / imageRect.Height;
            PointF Temp;
            for (int i = 0; i < 4; i++)
            {
                Temp = new PointF();
                Temp.X = Scale((int)Input_array_point[i].X - imageRect.X, scaleX, image.Width);
                Temp.Y = Scale((int)Input_array_point[i].Y - imageRect.Y, scaleY, image.Height);
                _Array_return[i] = Temp;
            }

            return _Array_return;
        }
        public static PointF Convert_ONE_point_scale_for_save(this PictureBox pb, PointF Input_array_point)
        {
            var imageRect = pb.GetImageRectangle();
            var image = pb.Image;
            float scaleX = (float)image.Width / imageRect.Width;
            float scaleY = (float)image.Height / imageRect.Height;
            PointF _Array_return = new PointF();
            _Array_return.X = Scale((int)Input_array_point.X - imageRect.X, scaleX, image.Width);
            _Array_return.Y = Scale((int)Input_array_point.Y - imageRect.Y, scaleY, image.Height);
            return _Array_return;
        }
        static int Scale(int value, float scale, int maxValue)
        {
            int result = (int)(value * scale);
            return result < 0 ? 0 : result > maxValue ? maxValue : result;
        }

        public static Rectangle GetImageRectangle(this PictureBox pb)
        {
            var rect = pb.ClientRectangle;
            var padding = pb.Padding;
            rect.X += padding.Left;
            rect.Y += padding.Top;
            rect.Width -= padding.Horizontal;
            rect.Height -= padding.Vertical;
            var image = pb.Image;
            var sizeMode = pb.SizeMode;
            //if (sizeMode == PictureBoxSizeMode.Normal || sizeMode == PictureBoxSizeMode.AutoSize)
            //    rect.Size = image.Size;
            //else if (sizeMode == PictureBoxSizeMode.CenterImage)
            //{
            //    rect.X += (rect.Width - image.Width) / 2;
            //    rect.Y += (rect.Height - image.Height) / 2;
            //    rect.Size = image.Size;
            //}
            if (sizeMode == PictureBoxSizeMode.Zoom)
            {
                var imageSize = image.Size;
                var zoomSize = pb.ClientSize;
                float ratio = Math.Min((float)zoomSize.Width / imageSize.Width, (float)zoomSize.Height / imageSize.Height);
                rect.Width = (int)(imageSize.Width * ratio);
                rect.Height = (int)(imageSize.Height * ratio);
                rect.X = (pb.ClientRectangle.Width - rect.Width) / 2;
                rect.Y = (pb.ClientRectangle.Height - rect.Height) / 2;
            }
            return rect;
        }
        public static PointF[] Return_point_Rect(Rectangle Rect)
        {
            PointF[] ListPoint = new PointF[4];
            ListPoint[0] = new Point(Rect.X, Rect.Y);
            ListPoint[1] = new Point(Rect.X + Rect.Width, Rect.Y);
            ListPoint[2] = new Point(Rect.X + Rect.Width, Rect.Y + Rect.Height);
            ListPoint[3] = new Point(Rect.X, Rect.Y + Rect.Height);
            return ListPoint;
        }
        public static System.Drawing.Rectangle Round_rectangle_Polyon(List<PointF> points)
        {
            var minX = points.Min(p => p.X);
            var minY = points.Min(p => p.Y);
            var maxX = points.Max(p => p.X);
            var maxY = points.Max(p => p.Y);
            return new System.Drawing.Rectangle(new System.Drawing.Point((int)minX, (int)minY), new System.Drawing.Size((int)maxX - (int)minX, (int)maxY - (int)minY));
        }
        public static byte[] ImageToByte2(Image img)
        {
            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
                return stream.ToArray();
            }
        }
    }
}
