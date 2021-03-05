using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Device.Printer
{
    class PritingLabel
    {
        public const int ISerial = 0;
        public const int IParallel = 1;
        public const int IUsb = 2;
        public const int ILan = 3;
        public const int IBluetooth = 5;
        private string ByteToString(byte[] strByte)
        {
            string str = Encoding.Default.GetString(strByte);
            return str;
        }
        // String -> byte[] 
        private byte[] StringToByte(string str)
        {
            byte[] StrByte = Encoding.UTF8.GetBytes(str);
            return StrByte;
        }
        private bool ConnectPrinter()
        {
            string strPort = "";
            int nInterface = ISerial;
            int nBaudrate = 115200, nDatabits = 8, nParity = 0, nStopbits = 0;
            int nStatus = (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR;

            //if (rdoIF_Serial.Checked)
            //{
            //    // SERIAL (COM)
            //    nInterface = ISerial;
            //    strPort = cmbSerial_Port.Text;
            //    nBaudrate = Convert.ToInt32(cmbSerial_Baudrate.Text);
            //    nDatabits = Convert.ToInt32(cmbSerial_Databits.Text);
            //    nParity = cmbSerial_Parity.SelectedIndex;
            //    nStopbits = cmbSerial_Stopbits.SelectedIndex;
            //}
            //else if (rdoIF_Bluetooth.Checked)
            //{
            //    // BLUETOOTH (COM)
            //    nInterface = IBluetooth;
            //    strPort = cmbSerial_Port.Text;
            //}
            //else if (rdoIF_Parallel.Checked)
            //{
            //    // PARALLEL (LPT)
            //    nInterface = IParallel;
            //    strPort = cmbLPT_Port.Text;
            //}
            //else if (rdoIF_Usb.Checked)
            //{
                // USB
                nInterface = IUsb;
            //}
            //else if (rdoIF_Lan.Checked)
            //{
            //    // NETWORK
            //    nInterface = ILan;
            //    strPort = txtNet_IPAddr.Text;
            //    nBaudrate = Convert.ToInt32(txtNet_PortNum.Text);
            //}

            nStatus = BXLLApi.ConnectPrinterEx(nInterface, strPort, nBaudrate, nDatabits, nParity, nStopbits);

            if (nStatus != (int)SLCS_ERROR_CODE.ERR_CODE_NO_ERROR)
            {
                BXLLApi.DisconnectPrinter();
                MessageBox.Show(GetStatusMsg(nStatus));
                return false;
            }
            return true;
        }
        private string GetStatusMsg(int nStatus)
        {
            string errMsg = "";
            switch ((SLCS_ERROR_CODE)nStatus)
            {
                case SLCS_ERROR_CODE.ERR_CODE_NO_ERROR: errMsg = "No Error"; break;
                case SLCS_ERROR_CODE.ERR_CODE_NO_PAPER: errMsg = "Paper Empty"; break;
                case SLCS_ERROR_CODE.ERR_CODE_COVER_OPEN: errMsg = "Cover Open"; break;
                case SLCS_ERROR_CODE.ERR_CODE_CUTTER_JAM: errMsg = "Cutter jammed"; break;
                case SLCS_ERROR_CODE.ERR_CODE_TPH_OVER_HEAT: errMsg = "TPH overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_AUTO_SENSING: errMsg = "Gap detection Error (Auto-sensing failure)"; break;
                case SLCS_ERROR_CODE.ERR_CODE_NO_RIBBON: errMsg = "Ribbon End"; break;
                case SLCS_ERROR_CODE.ERR_CODE_BOARD_OVER_HEAT: errMsg = "Board overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_MOTOR_OVER_HEAT: errMsg = "Motor overheat"; break;
                case SLCS_ERROR_CODE.ERR_CODE_WAIT_LABEL_TAKEN: errMsg = "Waiting for the label to be taken"; break;
                case SLCS_ERROR_CODE.ERR_CODE_CONNECT: errMsg = "Port open error"; break;
                case SLCS_ERROR_CODE.ERR_CODE_GETNAME: errMsg = "Unknown (or Not supported) printer name"; break;
                case SLCS_ERROR_CODE.ERR_CODE_OFFLINE: errMsg = "Offline (The printer is in an error status)"; break;
                default: errMsg = "Unknown error"; break;
            }
            return errMsg;
        }
        public void PrintQRCodeConfirm(string stingQR, string Name)
        {
            if (!ConnectPrinter())
                return;

            int multiplier = 1;
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int resolution = BXLLApi.GetPrinterDPI();
            int dotsPer1mm = (int)Math.Round((float)resolution / 25.4f);
            if (resolution >= 600)
                multiplier = 3;

            SendPrinterSettingCommand();

            BXLLApi.PrintBlock(1 * dotsPer1mm, 13 * dotsPer1mm, 75 * dotsPer1mm, 14 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.LINE_OVER_WRITING, 0);
            BXLLApi.PrintDeviceFont(6 * dotsPer1mm, 17 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_37X58, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "Function Name: " + Name);

            string QRCode_data = "s" + stingQR + "e";
            BXLLApi.PrintQRCode(30 * dotsPer1mm, 25 * dotsPer1mm, (int)SLCS_QRCODE_MODEL.QRMODEL_2, (int)SLCS_QRCODE_ECC_LEVEL.QRECCLEVEL_H, (int)SLCS_QRCODE_SIZE.QRSIZE_9, (int)SLCS_ROTATION.ROTATE_0, QRCode_data);

            //	Print Command
            BXLLApi.Prints(1, 1);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();
        }
        public void PrintQRCodErp(string stingQR)
        {
            if (!ConnectPrinter())
                return;

            int multiplier = 1;
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int resolution = BXLLApi.GetPrinterDPI();
            int dotsPer1mm = (int)Math.Round((float)resolution / 25.4f);
            if (resolution >= 600)
                multiplier = 3;

            SendPrinterSettingCommand();

            // BXLLApi.PrintBlock(1 * dotsPer1mm, 13 * dotsPer1mm, 75 * dotsPer1mm, 14 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.LINE_OVER_WRITING, 0);
            //  BXLLApi.PrintDeviceFont(6 * dotsPer1mm, 17 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_37X58, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "Function Name: " + Name);

            string QRCode_data = stingQR;
            BXLLApi.PrintQRCode(30 * dotsPer1mm, 25 * dotsPer1mm, (int)SLCS_QRCODE_MODEL.QRMODEL_2, (int)SLCS_QRCODE_ECC_LEVEL.QRECCLEVEL_H, (int)SLCS_QRCODE_SIZE.QRSIZE_9, (int)SLCS_ROTATION.ROTATE_0, QRCode_data);

            //	Print Command
            BXLLApi.Prints(1, 1);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();
        }
        public void PrintQRCodeOut(string stingQR)
        {
            if (!ConnectPrinter())
                return;

            int multiplier = 1;
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int resolution = BXLLApi.GetPrinterDPI();
            int dotsPer1mm = (int)Math.Round((float)resolution / 25.4f);
            if (resolution >= 600)
                multiplier = 3;

            SendPrinterSettingCommand();



            string QRCode_data = stingQR;
            BXLLApi.PrintQRCode(30 * dotsPer1mm, 25 * dotsPer1mm, (int)SLCS_QRCODE_MODEL.QRMODEL_2, (int)SLCS_QRCODE_ECC_LEVEL.QRECCLEVEL_H, (int)SLCS_QRCODE_SIZE.QRSIZE_9, (int)SLCS_ROTATION.ROTATE_0, QRCode_data);

            //	Print Command
            BXLLApi.Prints(1, 1);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();
        }
        public void PrintQRCode(string stingQR,string name)
        {
            if (!ConnectPrinter())
                return;

            int multiplier = 1;
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int resolution = BXLLApi.GetPrinterDPI();
            int dotsPer1mm = (int)Math.Round((float)resolution / 25.4f);
            if (resolution >= 600)
                multiplier = 3;

            SendPrinterSettingCommand();

            // Prints string using TrueFont
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Font Name
            //  P4 : Font Size
            //  P5 : Rotation : (0 : 0 degree , 1 : 90 degree, 2 : 180 degree, 3 : 270 degree)
            //  P6 : Italic
            //  P7 : Bold
            //  P8 : Underline
            //  P9 : RLE (Run-length encoding)
            //BXLLApi.PrintTrueFontLib(2 * dotsPer1mm, 5 * dotsPer1mm, "Arial", 14, 0, true, true, false, "Sample Label-1", false);
            //   BXLLApi.PrintTrueFont(2 * dotsPer1mm, 5 * dotsPer1mm, "Arial", 14, 0, true, true, false, "Sample Label-1", false);

            //	Draw Lines
            //    BXLLApi.PrintBlock(1 * dotsPer1mm, 8 * dotsPer1mm, 75 * dotsPer1mm, 9 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.LINE_OVER_WRITING, 0);

            //Print string using Vector Font
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Font selection
            //        U: ASCII (1Byte code)
            //        K: KS5601 (2Byte code)
            //        B: BIG5 (2Byte code)
            //        G: GB2312 (2Byte code)
            //        J: Shift-JIS (2Byte code)
            // P4  : Font width (W)[dot]
            // P5  : Font height (H)[dot]
            // P6  : Right-side character spacing [dot], Plus (+)/Minus (-) option can be used. Ex) 5, +3, -10	
            // P7  : Bold
            // P8  : Reverse printing
            // P9  : Text style  (N : Normal, I : Italic)
            // P10 : Rotation (0 ~ 3)
            // P11 : Text Alignment
            //        L: Left
            //        R: Right
            //        C: Center
            // P12 : Text string write direction (0 : left to right, 1 : right to left)
            // P13 : data to print
            // ※ : Third parameter, 'ASCII' must be set if Bixolon printer is SLP-T400, SLP-T403, SRP-770 and SRP-770II.
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 5 * dotsPer1mm, "Arial", 24, 0, true, true, false, "WAREHOUSE: " + name, false);

            BXLLApi.PrintBlock(1 * dotsPer1mm, 13 * dotsPer1mm, 75 * dotsPer1mm, 14 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.LINE_OVER_WRITING, 0);
            BXLLApi.PrintDeviceFont(6 * dotsPer1mm, 17 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_37X58, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "Location: " + stingQR);
            
            string QRCode_data = "s"+stingQR+"e";
            BXLLApi.PrintQRCode(30* dotsPer1mm, 25 * dotsPer1mm, (int)SLCS_QRCODE_MODEL.QRMODEL_2, (int)SLCS_QRCODE_ECC_LEVEL.QRECCLEVEL_H, (int)SLCS_QRCODE_SIZE.QRSIZE_9, (int)SLCS_ROTATION.ROTATE_0, QRCode_data);
          

            //	Print Command
            BXLLApi.Prints(1, 1);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();
        }
        public void PrintLabelQRCode(WMS.LabelItem labelItem, int Prints)
        {
            if (!ConnectPrinter())
                return;

            int multiplier = 1;
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int resolution = BXLLApi.GetPrinterDPI();
            int dotsPer1mm = (int)Math.Round((float)resolution / 25.4f);
            if (resolution >= 600)
                multiplier = 3;

            SendPrinterSettingCommand();

            // Prints string using TrueFont
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Font Name
            //  P4 : Font Size
            //  P5 : Rotation : (0 : 0 degree , 1 : 90 degree, 2 : 180 degree, 3 : 270 degree)
            //  P6 : Italic
            //  P7 : Bold
            //  P8 : Underline
            //  P9 : RLE (Run-length encoding)
            //BXLLApi.PrintTrueFontLib(2 * dotsPer1mm, 5 * dotsPer1mm, "Arial", 14, 0, true, true, false, "Sample Label-1", false);
            //   BXLLApi.PrintTrueFont(2 * dotsPer1mm, 5 * dotsPer1mm, "Arial", 14, 0, true, true, false, "Sample Label-1", false);

            //	Draw Lines
            BXLLApi.PrintBlock(1 * dotsPer1mm, 8 * dotsPer1mm, 45 * dotsPer1mm, 9 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.LINE_OVER_WRITING, 0);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 10 * dotsPer1mm, "Arial", 32, 0,false, true, false, "Purchasing code: " + labelItem.PurchasingCode, false);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 15 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Material Code: " + labelItem.MaterialCode, false);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 20 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Commodity: " + labelItem.Commodity, false);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 25 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Quantity: " + labelItem.Quantity, false);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 30 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Expiry Date: " + labelItem.ExpiryDate.ToString("dd/MM/yyyy"), false);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 35 * dotsPer1mm, "Arial", 32, 0, false, true, false, "LOT/PO: " + labelItem.LotPo, false);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 40 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Invoice: " + labelItem.Invoice, false);

            string QRCode_data = "s" + labelItem.PurchasingCode + ";"+ labelItem.MaterialCode+";"+labelItem.Quantity+";"+labelItem.ExpiryDate.ToString("dd/MM/yyyy")+";"+ labelItem.LotPo+";"+ labelItem.Invoice + "e";
            BXLLApi.PrintQRCode(54 * dotsPer1mm, 18 * dotsPer1mm, (int)SLCS_QRCODE_MODEL.QRMODEL_2, (int)SLCS_QRCODE_ECC_LEVEL.QRECCLEVEL_H, (int)SLCS_QRCODE_SIZE.QRSIZE_8, (int)SLCS_ROTATION.ROTATE_0, QRCode_data);
            BXLLApi.PrintBlock(1 * dotsPer1mm, 44 * dotsPer1mm, 45 * dotsPer1mm, 45 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.LINE_OVER_WRITING, 0);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 47 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Remark:", false);
         
            

            //	Print Command
            BXLLApi.Prints(1, Prints);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();
        }
        public void PrintLabelQRCodeInstock(WMS.LabelItem labelItem)
        {
            if (!ConnectPrinter())
                return;

            int multiplier = 1;
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int resolution = BXLLApi.GetPrinterDPI();
            int dotsPer1mm = (int)Math.Round((float)resolution / 25.4f);
            if (resolution >= 600)
                multiplier = 3;

            SendPrinterSettingCommand();

            // Prints string using TrueFont
            //  P1 : Horizontal position (X) [dot]
            //  P2 : Vertical position (Y) [dot]
            //  P3 : Font Name
            //  P4 : Font Size
            //  P5 : Rotation : (0 : 0 degree , 1 : 90 degree, 2 : 180 degree, 3 : 270 degree)
            //  P6 : Italic
            //  P7 : Bold
            //  P8 : Underline
            //  P9 : RLE (Run-length encoding)
            //BXLLApi.PrintTrueFontLib(2 * dotsPer1mm, 5 * dotsPer1mm, "Arial", 14, 0, true, true, false, "Sample Label-1", false);
            //   BXLLApi.PrintTrueFont(2 * dotsPer1mm, 5 * dotsPer1mm, "Arial", 14, 0, true, true, false, "Sample Label-1", false);

            //	Draw Lines
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm,2 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Location: " + labelItem.Location, false);
         //   BXLLApi.PrintDeviceFont(2 * dotsPer1mm, 5 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_24X38, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "Location: " + labelItem.Location);
            BXLLApi.PrintBlock(1 * dotsPer1mm, 6 * dotsPer1mm, 45 * dotsPer1mm, 7 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.LINE_OVER_WRITING, 0);

            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 9 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Purchasing code: " + labelItem.PurchasingCode, false);
            //   BXLLApi.PrintDeviceFont(2 * dotsPer1mm, 10 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_24X38, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "Purchasing code: " + labelItem.PurchasingCode);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 14 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Material Code: " + labelItem.MaterialCode, false);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 19 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Commodity: " + labelItem.Commodity, false);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 24 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Quantity: " + labelItem.Quantity, false);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 29 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Import Date: " + labelItem.ImportDate.ToString("dd/MM/yyyy"), false);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 34 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Expiry Date: " + labelItem.ExpiryDate.ToString("dd/MM/yyyy"), false);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 39 * dotsPer1mm, "Arial", 32, 0, false, true, false, "LOT/PO: " + labelItem.LotPo, false);

            string QRCode_data = "s" + labelItem.Location+";" + labelItem.PurchasingCode + ";" + labelItem.MaterialCode + ";" + labelItem.Commodity + ";" + labelItem.Quantity + ";" + labelItem.ImportDate.ToString("dd/MM/yyyy") + ";" + labelItem.ExpiryDate.ToString("dd/MM/yyyy") + ";" + labelItem.LotPo + "e";
            BXLLApi.PrintQRCode(60 * dotsPer1mm, 22 * dotsPer1mm, (int)SLCS_QRCODE_MODEL.QRMODEL_2, (int)SLCS_QRCODE_ECC_LEVEL.QRECCLEVEL_L, (int)SLCS_QRCODE_SIZE.QRSIZE_8, (int)SLCS_ROTATION.ROTATE_0, QRCode_data);
            BXLLApi.PrintBlock(1 * dotsPer1mm, 45 * dotsPer1mm, 45 * dotsPer1mm, 46 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.LINE_OVER_WRITING, 0);
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 48 * dotsPer1mm, "Arial", 32, 0, false, true, false, "Remark: ", false);


            //	Print Command
            BXLLApi.Prints(1, 1);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();
        }
        private void SendPrinterSettingCommand()
        {
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int dotsPer1mm = (int)Math.Round((float)BXLLApi.GetPrinterDPI() / 25.4f);
            int nPaper_Width = Convert.ToInt32(91* dotsPer1mm);
            int nPaper_Height = Convert.ToInt32(61 * dotsPer1mm);
            int nMarginX = Convert.ToInt32(3* dotsPer1mm);
            int nMarginY = Convert.ToInt32(3 * dotsPer1mm);
            int nSpeed = (int)SLCS_PRINT_SPEED.PRINTER_SETTING_SPEED;
            int nDensity = Convert.ToInt32(14);
            int nOrientation = (int)SLCS_ORIENTATION.TOP2BOTTOM;

            int nSensorType = (int)SLCS_MEDIA_TYPE.GAP;
            //if (rdoBmark.Checked) nSensorType = (int)SLCS_MEDIA_TYPE.BLACKMARK;
            //else if (rdoContinuous.Checked) nSensorType = (int)SLCS_MEDIA_TYPE.CONTINUOUS;

            //	Clear Buffer of Printer
            BXLLApi.ClearBuffer();

            // Rewinder is only available for XT series printers (XT5-40, XT5-43, XT5-46)
            //if (rdoRewind.Checked)
            //{
            //    BXLLApi.PrintDirect("RWDy", true);
            //}

            //	Set Label and Printer
            //BXLLApi.SetConfigOfPrinter(BXLLApi.SPEED_50, 17, BXLLApi.TOP, false, 0, true);
            BXLLApi.SetConfigOfPrinter(nSpeed, nDensity, nOrientation, false, 1, true);

            // Select international character set and code table.To
            BXLLApi.SetCharacterset((int)SLCS_INTERNATIONAL_CHARSET.ICS_CHINA, (int)SLCS_CODEPAGE.FCP_CP1252);

            /* 
                1 Inch : 25.4mm
                1 mm   :  7.99 Dots (XT5-40, SLP-TX400, SLP-DX420, SLP-DX220, SLP-DL410, SLP-T400, SLP-D420, SLP-D220, SRP-770/770II/770III)
                1 mm   :  7.99 Dots (SPP-L310, SPP-L410, SPP-L3000, SPP-L4000) 
                1 mm   :  7.99 Dots (XD3-40d, XD3-40t, XD5-40d, XD5-40t, XD5-40LCT)
                1 mm   : 11.81 Dots (XT5-43, SLP-TX403, SLP-DX423, SLP-DX223, SLP-DL413, SLP-T403, SLP-D423, SLP-D223)
                1 mm   : 11.81 Dots (XD5-43d, XD5-43t, XD5-43LCT)
                1 mm   : 23.62 Dots (XT5-46)
            */

            BXLLApi.SetPaper(nMarginX, nMarginY, nPaper_Width, nPaper_Height, nSensorType, 0, 2 * dotsPer1mm);

            // Direct thermal
        //    if (true)
                BXLLApi.PrintDirect("STd", true);
            //else // Thermal transfer
            //    BXLLApi.PrintDirect("STt", true);
        }

        public bool PrintQRCodePQCOUt(string stingQR, string warehouse)
        {
            try
            {

           
            if (!ConnectPrinter())
                return false;

            int multiplier = 1;
            // 203 DPI : 1mm is about 7.99 dots
            // 300 DPI : 1mm is about 11.81 dots
            // 600 DPI : 1mm is about 23.62 dots
            int resolution = BXLLApi.GetPrinterDPI();
            int dotsPer1mm = (int)Math.Round((float)resolution / 25.4f);
            if (resolution >= 600)
                multiplier = 3;

            SendPrinterSettingCommand();

           
            BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 5 * dotsPer1mm, "Arial", 24, 0, true, true, false, "Import Finished Goods: " + warehouse, false);

            BXLLApi.PrintBlock(1 * dotsPer1mm, 13 * dotsPer1mm, 75 * dotsPer1mm, 14 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.LINE_OVER_WRITING, 0);
            BXLLApi.PrintDeviceFont(6 * dotsPer1mm, 17 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_37X58, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "QR code: " + stingQR);

                string QRCode_data = stingQR;
            BXLLApi.PrintQRCode(30 * dotsPer1mm, 25 * dotsPer1mm, (int)SLCS_QRCODE_MODEL.QRMODEL_2, (int)SLCS_QRCODE_ECC_LEVEL.QRECCLEVEL_H, (int)SLCS_QRCODE_SIZE.QRSIZE_9, (int)SLCS_ROTATION.ROTATE_0, QRCode_data);


            //	Print Command
            BXLLApi.Prints(1, 1);

            // Disconnect printer
            BXLLApi.DisconnectPrinter();
                return true;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "print label fail", ex.Message);
                return false;
            }
        }
        public bool PrintQRCodeWarehouse(WMS.Model.WarehouseInfor infor)
        {
            try
            {


                if (!ConnectPrinter())
                    return false;

                int multiplier = 1;
                // 203 DPI : 1mm is about 7.99 dots
                // 300 DPI : 1mm is about 11.81 dots
                // 600 DPI : 1mm is about 23.62 dots
                int resolution = BXLLApi.GetPrinterDPI();
                int dotsPer1mm = (int)Math.Round((float)resolution / 25.4f);
                if (resolution >= 600)
                    multiplier = 3;

                SendPrinterSettingCommand();


                BXLLApi.PrintTrueFontW(2 * dotsPer1mm, 3 * dotsPer1mm, "Arial", 24, 0, true, true, false, "Warehouse: " + infor.Warehouse , false);

                BXLLApi.PrintBlock(1 * dotsPer1mm, 6 * dotsPer1mm, 45 * dotsPer1mm, 7 * dotsPer1mm, (int)SLCS_BLOCK_OPTION.LINE_OVER_WRITING, 0);
                BXLLApi.PrintDeviceFont(6 * dotsPer1mm, 10 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_24X38, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "Material: " + infor.Material);
                BXLLApi.PrintDeviceFont(6 * dotsPer1mm, 14 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_24X38, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "Lot: " + infor.Lot);
                BXLLApi.PrintDeviceFont(6 * dotsPer1mm, 18 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_24X38, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "Quantity: " + infor.quantity.ToString("N3")+" "+infor.Unit);
                BXLLApi.PrintDeviceFont(6 * dotsPer1mm, 22 * dotsPer1mm, (int)SLCS_DEVICE_FONT.ENG_24X38, multiplier, multiplier, (int)SLCS_ROTATION.ROTATE_0, false, "Expiry Date: " + infor.expiryDate.ToString("dd/MM/yyyy") );

                string QRCode_data = infor.Warehouse+";"+infor.Material+";"+infor.Lot+";"+infor.quantity+";"+infor.ImportDate.ToString("ddMMyyyy")+";"+infor.expiryDate.ToString("ddMMyyyy");
                BXLLApi.PrintQRCode(47 * dotsPer1mm, 25 * dotsPer1mm, (int)SLCS_QRCODE_MODEL.QRMODEL_2, (int)SLCS_QRCODE_ECC_LEVEL.QRECCLEVEL_H, (int)SLCS_QRCODE_SIZE.QRSIZE_9, (int)SLCS_ROTATION.ROTATE_0, QRCode_data);


                //	Print Command
                BXLLApi.Prints(1, 1);

                // Disconnect printer
                BXLLApi.DisconnectPrinter();
                return true;
            }
            catch (Exception ex)
            {

                SystemLog.Output(SystemLog.MSG_TYPE.Err, "print label fail", ex.Message);
                return false;
            }
        }

    }
}
