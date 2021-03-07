using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Spire.Barcode;

namespace WindowsFormsApplication1.Device.QRGenerate
{
 public class QRGenerate
    {
        public Image GeneratingQRCode(string QR)
        {
            Image QRImage = null;
            BarcodeSettings.ApplyKey("your key");//you need a key from e-iceblue, otherwise the watermark 'E-iceblue' will be shown in barcode
            BarcodeSettings settings = new BarcodeSettings();
            settings.Type = BarCodeType.QRCode;
            settings.Unit = GraphicsUnit.Pixel;
            settings.ShowText = false;
            settings.ResolutionType = ResolutionType.UseDpi;
            string data = QR;
            settings.Data = data;
            settings.X = 10;
            BarCodeGenerator generator = new BarCodeGenerator(settings);
            QRImage = generator.GenerateImage();
            return QRImage;
        }
    }
}
