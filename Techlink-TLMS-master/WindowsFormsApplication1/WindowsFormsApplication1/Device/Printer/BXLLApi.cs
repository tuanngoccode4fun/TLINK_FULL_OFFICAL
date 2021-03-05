using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace WindowsFormsApplication1.Device.Printer

{
    enum SLCS_HRI
    {
	    HRI_NOT_PRINT	= 0,
	    HRI_BELOW_SIZE1	= 1,
	    HRI_ABOVE_SIZE1	= 2,
	    HRI_BELOW_SIZE2	= 3,
	    HRI_ABOVE_SIZE2	= 4,
	    HRI_BELOW_SIZE3	= 5,
	    HRI_ABOVE_SIZE3	= 6,
	    HRI_BELOW_SIZE4	= 7,
	    HRI_ABOVE_SIZE4	= 8,
    }

    enum SLCS_PDF417_ECC_LEVEL
    {
	    PDF417_ECC_LEVEL0	=0,
	    PDF417_ECC_LEVEL1	=1,
	    PDF417_ECC_LEVEL2	=2,
	    PDF417_ECC_LEVEL3	=3,
	    PDF417_ECC_LEVEL4	=4,
	    PDF417_ECC_LEVEL5	=5,
	    PDF417_ECC_LEVEL6	=6,
	    PDF417_ECC_LEVEL7	=7,
	    PDF417_ECC_LEVEL8	=8
    }

    enum SLCS_CIRCLE_SIZE
    {
	    CIRCLE_SIZE_1	= 1,	// 40 x 40 in dot unit
	    CIRCLE_SIZE_2	= 2,	// 56 x 56 in dot unit
	    CIRCLE_SIZE_3	= 3,	// 72 x 72 in dot unit
	    CIRCLE_SIZE_4	= 4,	// 88 x 88 in dot unit
	    CIRCLE_SIZE_5	= 5,	// 104 x 104 in dot unit
	    CIRCLE_SIZE_6	= 6		// 168 x 168 in dot unit
    }

    enum SLCS_PDF417_DATA_TYPE
    {
	    PDF417_TEXT_TYPE	= 0,
	    PDF417_NUMERIC_TYPE	= 1,
	    PDF417_BINARY_TYPE	= 2,
    }

    enum SLCS_INTERNATIONAL_CHARSET 
    {
        ICS_USA = 0,
        ICS_FRANCE = 1,
        ICS_GERMANY = 2,
        ICS_UK = 3,
        ICS_DENMARK_I = 4,
        ICS_SWEDEN = 5,
        ICS_ITALY = 6,
        ICS_SPAIN_I = 7,
        ICS_JAPAN = 8,
        ICS_NORWAY = 9,
        ICS_DENMARK_II = 10,
        ICS_SPAIN_II = 11,
        ICS_LATIN_AMERICA = 12,
        ICS_KOREA = 13,
        ICS_SLOVENIA_CROATIA = 14,
        ICS_CHINA = 15
    }

    enum SLCS_CODEPAGE 
    {
        FCP_CP437 = 0,
        FCP_CP850 = 1,  // OEM Multilingual Latin 1; Western European (DOS)
        FCP_CP852 = 2,  // OEM Latin 2; Central European (DOS)
        FCP_CP860 = 3,  // OEM Portuguese; Portuguese (DOS)
        FCP_CP863 = 4,  // OEM French Canadian; French Canadian (DOS)
        FCP_CP865 = 5,  // OEM Nordic; Nordic (DOS)
        FCP_CP1252 = 6, // ANSI Latin 1; Western European (Windows)
        FCP_CP857 = 8,  // OEM Turkish; Turkish (DOS)
        FCP_CP737 = 9,  // OEM Greek (formerly 437G); Greek (DOS) 
        FCP_CP1250 = 10, // ANSI Central European; Central European (Windows)// MPOS_CODEPAGE_CP1250 ??
        FCP_CP1253 = 11, // ANSI Greek; Greek (Windows)
        FCP_CP1254 = 12, // ANSI Turkish; Turkish (Windows)
        FCP_CP855 = 13, // OEM Cyrillic (primarily Russian)
        FCP_CP862 = 14, // OEM Hebrew; Hebrew (DOS)
        FCP_CP866 = 15, // OEM Russian; Cyrillic (DOS)
        FCP_CP1251 = 16, // ANSI Cyrillic; Cyrillic (Windows) 
        FCP_CP1255 = 17, // ANSI Hebrew; Hebrew (Windows) 
        FCP_CP928 = 18, // Greek
        FCP_CP775 = 20, // OEM Baltic; Baltic (DOS) 
        FCP_CP1257 = 21, // ANSI Baltic; Baltic (Windows)
        FCP_CP858 = 22, //  OEM Multilingual Latin 1 + Euro symbol
    }

    enum SLCS_DITHER_OPTION
    {
	    DITHER_NONE = -1,
	    DITHER_1	= 0,
	    DITHER_2	= 1,
	    DITHER_3	= 6,
	    DITHER_4	= 7
    }

    enum SLCS_DATAMATRIX_SIZE
    {
	    DATAMATRIX_SIZE_1	= 1,
	    DATAMATRIX_SIZE_2	= 2,
	    DATAMATRIX_SIZE_3	= 3,
	    DATAMATRIX_SIZE_4	= 4
    }

    enum SLCS_QRCODE_MODEL
    {
	    QRMODEL_1   = 1,
	    QRMODEL_2   = 2
    }

    enum SLCS_QRCODE_SIZE
    {
	    QRSIZE_1     = 1,
	    QRSIZE_2     = 2,
	    QRSIZE_3     = 3,
	    QRSIZE_4     = 4,
	    QRSIZE_5     = 5,
	    QRSIZE_6     = 6,
	    QRSIZE_7     = 7,
	    QRSIZE_8     = 8,
	    QRSIZE_9     = 9,
              QRSIZE_15 = 15
    }

    enum SLCS_QRCODE_ECC_LEVEL
    {
	    QRECCLEVEL_L     = 1,	// 7%
	    QRECCLEVEL_M     = 2,	// 15%
	    QRECCLEVEL_Q     = 3,	// 25%
	    QRECCLEVEL_H     = 4	// 30%
    }

    enum SLCS_DEVICE_FONT
    {
        ENG_9X15 = 0,
        ENG_12X20 = 1,
        ENG_16X25 = 2,
        ENG_19X30 = 3,
        ENG_24X38 = 4,
        ENG_32X50 = 5,
        ENG_48X76 = 6,
        ENG_22X34 = 7,
        ENG_28X44 = 8,
        ENG_37X58 = 9,
        KOR_16X16 = 0x61,
        KOR_24X24 = 0x62,
        KOR_20X20 = 0x63,
        KOR_20X26 = 0x65,
        KOR_38X38 = 0x66,
        JPN_ShiftJIS = 0x6A,
        CHN_GB2312 = 0x6D,
        CHN_BIG5 = 0x6E
    }

    enum SLCS_BARCODE
    {
        CODE39 = 0,
        CODE128 = 1,
        I2OF5 = 2,
        CODABAR = 3,
        CODE93 = 4,
        UPC_A = 5,
        UPC_E = 6,
        EAN13 = 7,
        EAN8 = 8,
        UCC_EAN128 = 9
    }

    enum SLCS_ORIENTATION
    {
        TOP2BOTTOM = 0,
        BOTTOM2TOP = 1
    }

    enum SLCS_MEDIA_TYPE
    {
        GAP = 0,
        CONTINUOUS = 1,
        BLACKMARK = 2
    }

    enum SLCS_PRINT_SPEED
    {
        PRINTER_SETTING_SPEED = -1,
        PRINTER_SPEED_0 = 0,
        PRINTER_SPEED_1 = 1,
        PRINTER_SPEED_2 = 2,
        PRINTER_SPEED_3 = 3,
        PRINTER_SPEED_4 = 4,
        PRINTER_SPEED_5 = 5,
        PRINTER_SPEED_6 = 6,
        PRINTER_SPEED_7 = 7,
        PRINTER_SPEED_8 = 8,
        PRINTER_SPEED_9 = 9,
        PRINTER_SPEED_10 = 10,
        PRINTER_SPEED_11 = 11,
        PRINTER_SPEED_12 = 12,
    }

    enum SLCS_ROTATION
    {
        ROTATE_0 = 0,
        ROTATE_90 = 1,
        ROTATE_180 = 2,
        ROTATE_270 = 3
    }

    enum SLCS_BLOCK_OPTION
    {
	    LINE_OVER_WRITING	= 0,
	    LINE_EXCLUSIVE_OR	= 1,
	    LINE_DELETE			= 2,
	    SLOPE				= 3,
	    BOX					= 4
    }

    enum SLCS_ALIGNMENT
    {
	    ALIGN_LEFT			= 0,
	    ALIGN_CENTER		= 1,
	    ALIGN_RIGHT			= 2,
	    ALIGN_BOTH_SIDE		= 3
    }

    enum SLCS_FONT_ALIGNMENT
    {
        LEFTALIGN   = 'L',
        RIGHTALIGN  = 'R',
        CENTERALIGN = 'C'
    }

    enum SLCS_FONT_DIRECTION
    {
	    LEFTTORIGHT     = 0,
	    RIGHTTOLEFT     = 1
    }

    enum SLCS_VECTOR_FONT
    {
	    ASCII       = 'U',
        KS5601      = 'K',
        BIG5        = 'B',
        GB2312      = 'G',
        ShiftJIS    = 'J',
    }

    enum SLCS_RFID_TRANSPONDER_TYPE
    {
	    //	RFID Transponder Type
	    RFID_NONE					= 0,
	    RFID_ISO18000_6TYPEA		= 1,
	    RFID_ISO18000_6TYPEB		= 2,
	    RFID_EPC_CLASS0				= 3,
	    RFID_EPC_CLASS1				= 4,
	    RFID_EPC_CLASS1_GENERATION2 = 5
    }

    enum SLCS_RFID_DATA_TYPE
    {
	    RFID_ASCII			= 1,
	    RFID_HEXADECIMAL	= 2,
	    RFID_USER			= 3,
	    RFID_EPC			= 4
    }

    enum SLCS_ERROR_CODE
    {
        ERR_CODE_NO_ERROR       = 0,	// Success
        ERR_CODE_NO_PAPER       = 1,	// Paper Empty
        ERR_CODE_COVER_OPEN     = 2,	// Cover Open
        ERR_CODE_CUTTER_JAM     = 3,	// Cutter jammed
        ERR_CODE_TPH_OVER_HEAT  = 4,	// Thermal Head(TPH) overheat
        ERR_CODE_AUTO_SENSING   = 5,	// Gap detection Error (Auto-sensing failure)
        ERR_CODE_NO_RIBBON      = 6,	// Ribbon End
        ERR_CODE_BOARD_OVER_HEAT    = 11,	// Board overheat
        ERR_CODE_MOTOR_OVER_HEAT    = 12,	// Motor overheat
        ERR_CODE_WAIT_LABEL_TAKEN   = 13,	// Waiting for the label to be taken
        ERR_CODE_CONNECT        = 71,   // Port open error
        ERR_CODE_GETNAME        = 72,   // Unknown (or Not supported) printer name
        ERR_CODE_OFFLINE        = 73,   // Offline (The printer is in an error status)
        ERR_CODE_UNKNOWN        = 99	// Unknown error
    }

    partial class BXLLApi
    {
        public static bool Is64Bit()
        {
            bool retVal = true;
            if (System.Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE") == "x86")
                retVal = false;

            return retVal;
        }

        public static int ConnectPrinterEx(int nInterface, string szPortName, int nBaudRate, int nDataBits, int nParity, int nStopBits)
        {
            if (Is64Bit())
                return BXLLApi_x64.ConnectPrinterEx(nInterface, szPortName, nBaudRate, nDataBits, nParity, nStopBits);
            else
                return BXLLApi_x86.ConnectPrinterEx(nInterface, szPortName, nBaudRate, nDataBits, nParity, nStopBits);
        }

        public static bool ConnectSerial(string szPortName, int nBaudRate, int nDataBits, int nParity, int nStopBits)
        {
            if (Is64Bit())
                return BXLLApi_x64.ConnectSerial(szPortName, nBaudRate, nDataBits, nParity, nStopBits);
            else
                return BXLLApi_x86.ConnectSerial(szPortName, nBaudRate, nDataBits, nParity, nStopBits);
        }

        public static bool ConnectUsb()
        {
            if (Is64Bit())
                return BXLLApi_x64.ConnectUsb();
            else
                return BXLLApi_x86.ConnectUsb();
        }

        public static bool ConnectParallel(string szPortName)
        {
            if (Is64Bit())
                return BXLLApi_x64.ConnectParallel(szPortName);
            else
                return BXLLApi_x86.ConnectParallel(szPortName);
        }

        public static bool ConnectNet(string szIpAddr, int nPortNum)
        {
            if (Is64Bit())
                return BXLLApi_x64.ConnectNet(szIpAddr, nPortNum);
            else
                return BXLLApi_x86.ConnectNet(szIpAddr, nPortNum);
        }

        public static bool DisconnectPrinter()
        {
            if (Is64Bit())
                return BXLLApi_x64.DisconnectPrinter();
            else
                return BXLLApi_x86.DisconnectPrinter();
        }

        public static int GetPrinterDPI()
        {
            if (Is64Bit())
                return BXLLApi_x64.GetPrinterDPI();
            else
                return BXLLApi_x86.GetPrinterDPI();
        }


        public static bool GetDllVersion(StringBuilder strDllVersion)
        {
            if (Is64Bit())
                return BXLLApi_x64.GetDllVersion(strDllVersion);
            else
                return BXLLApi_x86.GetDllVersion(strDllVersion);
        }

        
        public static bool Print1DBarcode(int nHorizontalPos, int nVerticalPos, int nBarcodeType, int nNarrowBarWidth, int nWideBarWidth, int nBarcodeHeight, int nRotation, int nHRI, string pData)
        {
            if (Is64Bit())
                return BXLLApi_x64.Print1DBarcode(nHorizontalPos, nVerticalPos, nBarcodeType, nNarrowBarWidth, nWideBarWidth, nBarcodeHeight, nRotation, nHRI, pData);
            else
                return BXLLApi_x86.Print1DBarcode(nHorizontalPos, nVerticalPos, nBarcodeType, nNarrowBarWidth, nWideBarWidth, nBarcodeHeight, nRotation, nHRI, pData);
        }

        public static bool Print1DBarcode(int nHorizontalPos, int nVerticalPos, int nBarcodeType, int nNarrowBarWidth, int nWideBarWidth, int nBarcodeHeight, int nRotation, int nHRI, Byte[] pData)
        {
            if (Is64Bit())
                return BXLLApi_x64.Print1DBarcode(nHorizontalPos, nVerticalPos, nBarcodeType, nNarrowBarWidth, nWideBarWidth, nBarcodeHeight, nRotation, nHRI, pData);
            else
                return BXLLApi_x86.Print1DBarcode(nHorizontalPos, nVerticalPos, nBarcodeType, nNarrowBarWidth, nWideBarWidth, nBarcodeHeight, nRotation, nHRI, pData);
        }


        public static bool PrintDeviceFont(int nHorizontalPos, int nVerticalPos, int nFontName, int nHorizontalMulti, int nVerticalMulti, int nRotation, bool bBold, string szText)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintDeviceFont(nHorizontalPos, nVerticalPos, nFontName, nHorizontalMulti, nVerticalMulti, nRotation, bBold, szText);
            else
                return BXLLApi_x86.PrintDeviceFont(nHorizontalPos, nVerticalPos, nFontName, nHorizontalMulti, nVerticalMulti, nRotation, bBold, szText);
        }

        public static bool PrintDeviceFontW(int nHorizontalPos, int nVerticalPos, int nFontName, int nHorizontalMulti, int nVerticalMulti, int nRotation, bool bBold, string szText)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintDeviceFontW(nHorizontalPos, nVerticalPos, nFontName, nHorizontalMulti, nVerticalMulti, nRotation, bBold, szText);
            else
                return BXLLApi_x86.PrintDeviceFontW(nHorizontalPos, nVerticalPos, nFontName, nHorizontalMulti, nVerticalMulti, nRotation, bBold, szText);
        }

        public static bool SetConfigOfPrinter(int nSpeed, int nDensity, int nOrientation, bool bAutoCut, int nCuttingPeriod, bool bBackFeeding)
        {
            if (Is64Bit())
                return BXLLApi_x64.SetConfigOfPrinter(nSpeed, nDensity, nOrientation, bAutoCut, nCuttingPeriod, bBackFeeding);
            else
                return BXLLApi_x86.SetConfigOfPrinter(nSpeed, nDensity, nOrientation, bAutoCut, nCuttingPeriod, bBackFeeding);
        }


        public static bool Prints(int nLabelSet, int nCopiesOfEachLabel)
        {
            if (Is64Bit())
                return BXLLApi_x64.Prints(nLabelSet, nCopiesOfEachLabel);
            else
                return BXLLApi_x86.Prints(nLabelSet, nCopiesOfEachLabel);
        }

        public static bool SetCharacterset(int nInternationalCharacterSet, int nCodepage)
        {
            if (Is64Bit())
                return BXLLApi_x64.SetCharacterset(nInternationalCharacterSet, nCodepage);
            else
                return BXLLApi_x86.SetCharacterset(nInternationalCharacterSet, nCodepage);
        }

        public static bool SetPaper(int nHorizontalMagin, int nVerticalMargin, int nPaperWidth, int nPaperLength, int nMediaType, int nOffSet, int nGapLengthORThicknessOfBlackLine)
        {
            if (Is64Bit())
                return BXLLApi_x64.SetPaper(nHorizontalMagin, nVerticalMargin, nPaperWidth, nPaperLength, nMediaType, nOffSet, nGapLengthORThicknessOfBlackLine);
            else
                return BXLLApi_x86.SetPaper(nHorizontalMagin, nVerticalMargin, nPaperWidth, nPaperLength, nMediaType, nOffSet, nGapLengthORThicknessOfBlackLine);
        }

        public static bool ClearBuffer()
        {
            if (Is64Bit())
                return BXLLApi_x64.ClearBuffer();
            else
                return BXLLApi_x86.ClearBuffer();
        }


        public static bool PrintBlock(int nHorizontalStartPos, int nVerticalStartPos, int nHorizontalEndPos, int nVerticalEndPos, int nOption, int nThickness)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintBlock(nHorizontalStartPos, nVerticalStartPos, nHorizontalEndPos, nVerticalEndPos, nOption, nThickness);
            else
                return BXLLApi_x86.PrintBlock(nHorizontalStartPos, nVerticalStartPos, nHorizontalEndPos, nVerticalEndPos, nOption, nThickness);
        }

        
        public static bool PrintCircle(int nHorizontalStartPos, int nVerticalStartPos, int nDiameter, int nMulti)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintCircle(nHorizontalStartPos, nVerticalStartPos, nDiameter, nMulti);
            else
                return BXLLApi_x86.PrintCircle(nHorizontalStartPos, nVerticalStartPos, nDiameter, nMulti);
        }

        
        public static bool PrintDirect(string pDirectData, bool bAddCrLf)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintDirect(pDirectData, bAddCrLf);
            else
                return BXLLApi_x86.PrintDirect(pDirectData, bAddCrLf);
        }

        public static bool PrintTrueFont(int nXPos, int nYPos, string strFontName, int nFontSize, int nRotaion, bool bItalic, bool bBold, bool bUnderline, string strText, bool bDataCompression)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintTrueFont(nXPos, nYPos, strFontName, nFontSize, nRotaion, bItalic, bBold, bUnderline, strText, bDataCompression);
            else
                return BXLLApi_x86.PrintTrueFont(nXPos, nYPos, strFontName, nFontSize, nRotaion, bItalic, bBold, bUnderline, strText, bDataCompression);
        }

        public static bool PrintTrueFontW(int nXPos, int nYPos, string strFontName, int nFontSize, int nRotaion, bool bItalic, bool bBold, bool bUnderline, string strText, bool bDataCompression)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintTrueFontW(nXPos, nYPos, strFontName, nFontSize, nRotaion, bItalic, bBold, bUnderline, strText, bDataCompression);
            else
                return BXLLApi_x86.PrintTrueFontW(nXPos, nYPos, strFontName, nFontSize, nRotaion, bItalic, bBold, bUnderline, strText, bDataCompression);
        }

        public static bool PrintTrueFontLib(int nXPos, int nYPos, string strFontName, int nFontSize, int nRotaion, bool bItalic, bool bBold, bool bUnderline, string strText, bool bDataCompression)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintTrueFontLib(nXPos, nYPos, strFontName, nFontSize, nRotaion, bItalic, bBold, bUnderline, strText, bDataCompression);
            else
                return BXLLApi_x86.PrintTrueFontLib(nXPos, nYPos, strFontName, nFontSize, nRotaion, bItalic, bBold, bUnderline, strText, bDataCompression);
        }

        public static bool PrintTrueFontLibW(int nXPos, int nYPos, string strFontName, int nFontSize, int nRotaion, bool bItalic, bool bBold, bool bUnderline, string strText, bool bDataCompression)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintTrueFontLibW(nXPos, nYPos, strFontName, nFontSize, nRotaion, bItalic, bBold, bUnderline, strText, bDataCompression);
            else
                return BXLLApi_x86.PrintTrueFontLibW(nXPos, nYPos, strFontName, nFontSize, nRotaion, bItalic, bBold, bUnderline, strText, bDataCompression);
        }

        public static bool PrintTrueFontLibWithAlign(int nXPos, int nYPos, string strFontName, int nFontSize, int nRotaion, bool bItalic, bool bBold, bool bUnderline, string strText, int nPrintWidth, int nAlignment, bool bDataCompression)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintTrueFontLibWithAlign(nXPos, nYPos, strFontName, nFontSize, nRotaion, bItalic, bBold, bUnderline, strText, nPrintWidth, nAlignment, bDataCompression);
            else
                return BXLLApi_x86.PrintTrueFontLibWithAlign(nXPos, nYPos, strFontName, nFontSize, nRotaion, bItalic, bBold, bUnderline, strText, nPrintWidth, nAlignment, bDataCompression);
        }

        public static bool PrintTrueFontLibWithAlignW(int nXPos, int nYPos, string strFontName, int nFontSize, int nRotaion, bool bItalic, bool bBold, bool bUnderline, string strText, int nPrintWidth, int nAlignment, bool bDataCompression)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintTrueFontLibWithAlignW(nXPos, nYPos, strFontName, nFontSize, nRotaion, bItalic, bBold, bUnderline, strText, nPrintWidth, nAlignment, bDataCompression);
            else
                return BXLLApi_x86.PrintTrueFontLibWithAlignW(nXPos, nYPos, strFontName, nFontSize, nRotaion, bItalic, bBold, bUnderline, strText, nPrintWidth, nAlignment, bDataCompression);
        }
        
        public static bool PrintVectorFont(int nXPos, int nYPos, string FontSelection, int FontWidth, int FontHeight, string RightSideCharSpacing, bool bBold, bool ReversePrinting, bool TextStyle, int Rotation, string TextAlignment, int TextDirection, string pData)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintVectorFont(nXPos, nYPos, FontSelection, FontWidth, FontHeight, RightSideCharSpacing, bBold, ReversePrinting, TextStyle, Rotation, TextAlignment, TextDirection, pData);
            else
                return BXLLApi_x86.PrintVectorFont(nXPos, nYPos, FontSelection, FontWidth, FontHeight, RightSideCharSpacing, bBold, ReversePrinting, TextStyle, Rotation, TextAlignment, TextDirection, pData);
        }

        public static bool PrintVectorFontW(int nXPos, int nYPos, string FontSelection, int FontWidth, int FontHeight, string RightSideCharSpacing, bool bBold, bool ReversePrinting, bool TextStyle, int Rotation, string TextAlignment, int TextDirection, string pData)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintVectorFontW(nXPos, nYPos, FontSelection, FontWidth, FontHeight, RightSideCharSpacing, bBold, ReversePrinting, TextStyle, Rotation, TextAlignment, TextDirection, pData);
            else
                return BXLLApi_x86.PrintVectorFontW(nXPos, nYPos, FontSelection, FontWidth, FontHeight, RightSideCharSpacing, bBold, ReversePrinting, TextStyle, Rotation, TextAlignment, TextDirection, pData);
        }
        
        public static bool PrintQRCode(int nXPos, int nYPos, int nModel, int nECCLevel, int nSize, int nRotation, string pData)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintQRCode(nXPos, nYPos, nModel, nECCLevel, nSize, nRotation, pData);
            else
                return BXLLApi_x86.PrintQRCode(nXPos, nYPos, nModel, nECCLevel, nSize, nRotation, pData);
        }

        public static bool PrintQRCode(int nXPos, int nYPos, int nModel, int nECCLevel, int nSize, int nRotation, Byte[] pData)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintQRCode(nXPos, nYPos, nModel, nECCLevel, nSize, nRotation, pData);
            else
                return BXLLApi_x86.PrintQRCode(nXPos, nYPos, nModel, nECCLevel, nSize, nRotation, pData);
        }
        public static bool PrintPDF417(int nXPos, int nYPos, int nMaxRow, int nMaxCol, int nECLevel, int nDataType, bool bHRI, int nOriginPoint, int nModuleWidth, int nBarHeight, int nRotation, string pData)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintPDF417(nXPos, nYPos, nMaxRow, nMaxCol, nECLevel, nDataType, bHRI, nOriginPoint, nModuleWidth, nBarHeight, nRotation, pData);
            return BXLLApi_x86.PrintPDF417(nXPos, nYPos, nMaxRow, nMaxCol, nECLevel, nDataType, bHRI, nOriginPoint, nModuleWidth, nBarHeight, nRotation, pData);
        }


        public static bool PrintMaxiCode(int nXPos, int nYPos, int nMode, string pData)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintMaxiCode(nXPos, nYPos, nMode, pData);
            return BXLLApi_x86.PrintMaxiCode(nXPos, nYPos, nMode, pData);
        }

        public static bool PrintDataMatrix(int nXPos, int nYPos, int nSize, bool bReverse, int nRotation, string pData)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintDataMatrix(nXPos, nYPos, nSize, bReverse, nRotation, pData);
            return BXLLApi_x86.PrintDataMatrix(nXPos, nYPos, nSize, bReverse, nRotation, pData);
        }
        public static bool PrintImageLib(int nHorizontalStartPos, int nVerticalStartPos, string pBitmapFilename, int nDither, bool bDataCompression)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintImageLib(nHorizontalStartPos, nVerticalStartPos, pBitmapFilename, nDither, bDataCompression);
            else
                return BXLLApi_x86.PrintImageLib(nHorizontalStartPos, nVerticalStartPos, pBitmapFilename, nDither, bDataCompression);
        }

        public static bool PrintImageLibW(int nHorizontalStartPos, int nVerticalStartPos, string pBitmapFilename, int nDither, bool bDataCompression)
        {
            if (Is64Bit())
                return BXLLApi_x64.PrintImageLibW(nHorizontalStartPos, nVerticalStartPos, pBitmapFilename, nDither, bDataCompression);
            else
                return BXLLApi_x86.PrintImageLibW(nHorizontalStartPos, nVerticalStartPos, pBitmapFilename, nDither, bDataCompression);
        }
        
        public static bool SetShowMsgBox(bool bShow)
        {
            if (Is64Bit())
                return BXLLApi_x64.SetShowMsgBox(bShow);
            else
                return BXLLApi_x86.SetShowMsgBox(bShow);
        }

        public static int CheckStatus()
        {
            if (Is64Bit())
                return BXLLApi_x64.CheckStatus();
            else
                return BXLLApi_x86.CheckStatus();
        }

        public static bool WriteBuff(byte[] pBuffer, int dwNumberOfBytesToWrite, ref int dwWritten)
        {
            if (Is64Bit())
                return BXLLApi_x64.WriteBuff(pBuffer, dwNumberOfBytesToWrite, ref dwWritten);
            else
                return BXLLApi_x86.WriteBuff(pBuffer, dwNumberOfBytesToWrite, ref dwWritten);
        }

        public static bool ReadBuff(byte[] pBuffer, int dwNumberOfBytesToRead, ref int dwReaded)
        {
            if (Is64Bit())
                return BXLLApi_x64.ReadBuff(pBuffer, dwNumberOfBytesToRead, ref dwReaded);
            else
                return BXLLApi_x86.ReadBuff(pBuffer, dwNumberOfBytesToRead, ref dwReaded);
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////
        // RFID Functions
        /////////////////////////////////////////////////////////////////////////////////////////////////////
        public static bool RFIDSetup(int RFIDType, int NumberOfRetries, int NumberOfLabel, int RadioPower)
        {
            if (Is64Bit())
                return BXLLApi_x64.RFIDSetup(RFIDType, NumberOfRetries, NumberOfLabel, RadioPower);
            else
                return BXLLApi_x86.RFIDSetup(RFIDType, NumberOfRetries, NumberOfLabel, RadioPower);
        }

        public static bool RFIDCalibration()
        {
            if (Is64Bit())
                return BXLLApi_x64.RFIDCalibration();
            else
                return BXLLApi_x86.RFIDCalibration();
        }

        public static bool RFIDWrite(int DataType, int StartingBlockNumber, int WriteByte, string Data)
        {
            if (Is64Bit())
                return BXLLApi_x64.RFIDWrite(DataType, StartingBlockNumber, WriteByte, Data);
            else
                return BXLLApi_x86.RFIDWrite(DataType, StartingBlockNumber, WriteByte, Data);
        }

        public static bool RFIDPassword(string OldAccessPwd, string OldKillPwd, string NewAccessPwd, string NewKillPwd)
        {
            if (Is64Bit())
                return BXLLApi_x64.RFIDPassword(OldAccessPwd, OldKillPwd, NewAccessPwd, NewKillPwd);
            else
                return BXLLApi_x86.RFIDPassword(OldAccessPwd, OldKillPwd, NewAccessPwd, NewKillPwd);
        }

        public static bool RFIDLock()
        {
            if (Is64Bit())
                return BXLLApi_x64.RFIDLock();
            else
                return BXLLApi_x86.RFIDLock();
        }
    }
}
