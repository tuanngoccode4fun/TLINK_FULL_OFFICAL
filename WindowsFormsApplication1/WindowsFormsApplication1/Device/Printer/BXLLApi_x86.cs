using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Runtime.InteropServices;

namespace WindowsFormsApplication1.Device.Printer
{
    class BXLLApi_x86
    {
        //////////////////////////////////////////////////////////////////////
        //  Function List
        //////////////////////////////////////////////////////////////////////
        [DllImport("BXLLApi.dll")]
        public static extern int ConnectPrinterEx(
            int nInterface,
            [MarshalAs(UnmanagedType.LPStr)]string szPortName,
            int nBaudRate,
            int nDataBits,
            int nParity,
            int nStopBits);

        [DllImport("BXLLApi.dll")]
        public static extern int ConnectPrinterExW(
            int nInterface,
            [MarshalAs(UnmanagedType.LPWStr)]string szPortName,
            int nBaudRate,
            int nDataBits,
            int nParity,
            int nStopBits);

        [DllImport("BXLLApi.dll")]
        public static extern bool ConnectPrinter(
            int nInterface,
            [MarshalAs(UnmanagedType.LPStr)]string szPortName,
            int nBaudRate,
            int nDataBits,
            int nParity,
            int nStopBits);

        [DllImport("BXLLApi.dll")]
        public static extern bool ConnectPrinterW(
            int nInterface,
            [MarshalAs(UnmanagedType.LPWStr)]string szPortName,
            int nBaudRate,
            int nDataBits,
            int nParity,
            int nStopBits);

        [DllImport("BXLLApi.dll")]
        public static extern bool ConnectSerial(
            [MarshalAs(UnmanagedType.LPStr)]string szPortName,
            int nBaudRate,
            int nDataBits,
            int nParity,
            int nStopBits);

        [DllImport("BXLLApi.dll")]
        public static extern bool ConnectSerialW(
            [MarshalAs(UnmanagedType.LPWStr)]string szPortName,
            int nBaudRate,
            int nDataBits,
            int nParity,
            int nStopBits);

        [DllImport("BXLLApi.dll")]
        public static extern bool ConnectUsb();

        [DllImport("BXLLApi.dll")]
        public static extern bool ConnectParallel([MarshalAs(UnmanagedType.LPStr)]string szPortName);

        [DllImport("BXLLApi.dll")]
        public static extern bool ConnectParallelW([MarshalAs(UnmanagedType.LPWStr)]string szPortName);

        [DllImport("BXLLApi.dll")]
        public static extern bool ConnectNet([MarshalAs(UnmanagedType.LPStr)]string szIpAddr, int nPortNum);

        [DllImport("BXLLApi.dll")]
        public static extern bool ConnectNetW([MarshalAs(UnmanagedType.LPWStr)]string szIpAddr, int nPortNum);

        [DllImport("BXLLApi.dll")]
        public static extern bool DisconnectPrinter();

        [DllImport("BXLLApi.dll")]
        public static extern int GetPrinterDPI();

        [DllImport("BXLLApi.dll")]
        public static extern bool GetDllVersion(StringBuilder strDllVersion);

        [DllImport("BXLLApi.dll")]
        public static extern bool Print1DBarcode(int nHorizontalPos,
                                                 int nVerticalPos,
                                                 int nBarcodeType,
                                                 int nNarrowBarWidth,
                                                 int nWideBarWidth,
                                                 int nBarcodeHeight,
                                                 int nRotation,
                                                 int nHRI,
                                                 [MarshalAs(UnmanagedType.LPStr)]string pData);
         
        [DllImport("BXLLApi.dll")]
        public static extern bool Print1DBarcode(int nHorizontalPos,
                                                 int nVerticalPos,
                                                 int nBarcodeType,
                                                 int nNarrowBarWidth,
                                                 int nWideBarWidth,
                                                 int nBarcodeHeight,
                                                 int nRotation,
                                                 int nHRI,
                                                 Byte[] pData);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintDeviceFont(int nHorizontalPos,
                                                  int nVerticalPos,
                                                  int nFontName,
                                                  int nHorizontalMulti,
                                                  int nVerticalMulti,
                                                  int nRotation,
                                                  bool bBold,
                                                  [MarshalAs(UnmanagedType.LPStr)]string szText);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintDeviceFontW(//int nCodePage, 
                                                   int nHorizontalPos,
                                                   int nVerticalPos,
                                                   int nFontName,
                                                   int nHorizontalMulti,
                                                   int nVerticalMulti,
                                                   int nRotation,
                                                   bool bBold,
                                                   [MarshalAs(UnmanagedType.LPWStr)]string szText);

        [DllImport("BXLLApi.dll")]
        public static extern bool SetConfigOfPrinter(int nSpeed,
                                                     int nDensity,
                                                     int nOrientation,
                                                     bool bAutoCut,
                                                     int nCuttingPeriod,
                                                     bool bBackFeeding);

        [DllImport("BXLLApi.dll")]
        public static extern bool Prints(int nLabelSet, int nCopiesOfEachLabel);

        [DllImport("BXLLApi.dll")]
        public static extern bool SetCharacterset(int nInternationalCharacterSet, int nCodepage);

        [DllImport("BXLLApi.dll")]
        public static extern bool SetPaper(int nHorizontalMagin,
                                           int nVerticalMargin,
                                           int nPaperWidth,
                                           int nPaperLength,
                                           int nMediaType,
                                           int nOffSet,
                                           int nGapLengthORThicknessOfBlackLine);

        [DllImport("BXLLApi.dll")]
        public static extern bool ClearBuffer();

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintBlock(int nHorizontalStartPos,
                                             int nVerticalStartPos,
                                             int nHorizontalEndPos,
                                             int nVerticalEndPos,
                                             int nOption,
                                             int nThickness);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintCircle(int nHorizontalStartPos,
                                             int nVerticalStartPos,
                                             int nDiameter,
                                             int nMulti);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintDirect([MarshalAs(UnmanagedType.LPStr)]string pDirectData, bool bAddCrLf);

        [DllImport("BXLLAPI.dll")]
        public static extern bool PrintTrueFont(
                                        int nXPos,
                                        int nYPos,
                                        [MarshalAs(UnmanagedType.LPStr)]string strFontName,
                                        int nFontSize,
                                        int nRotaion,
                                        bool bItalic,
                                        bool bBold,
                                        bool bUnderline,
                                        [MarshalAs(UnmanagedType.LPStr)]string strText, bool bDataCompression);

        [DllImport("BXLLAPI.dll")]
        public static extern bool PrintTrueFontW(
                                        int nXPos,
                                        int nYPos,
                                        [MarshalAs(UnmanagedType.LPWStr)]string strFontName,
                                        int nFontSize,
                                        int nRotaion,
                                        bool bItalic,
                                        bool bBold,
                                        bool bUnderline,
                                        [MarshalAs(UnmanagedType.LPWStr)]string strText, bool bDataCompression);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintTrueFontLib( int nXPos,
                                                    int nYPos,
                                                    [MarshalAs(UnmanagedType.LPStr)]string strFontName,
                                                    int nFontSize,
                                                    int nRotaion,
                                                    bool bItalic,
                                                    bool bBold,
                                                    bool bUnderline,
                                                    [MarshalAs(UnmanagedType.LPStr)]string strText, bool bDataCompression);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintTrueFontLibW(int nXPos,
                                                    int nYPos,
                                                    [MarshalAs(UnmanagedType.LPWStr)]string strFontName,
                                                    int nFontSize,
                                                    int nRotaion,
                                                    bool bItalic,
                                                    bool bBold,
                                                    bool bUnderline,
                                                    [MarshalAs(UnmanagedType.LPWStr)]string strText, bool bDataCompression);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintTrueFontLibWithAlign(int nXPos,
                                                    int nYPos,
                                                    [MarshalAs(UnmanagedType.LPStr)]string strFontName,
                                                    int nFontSize,
                                                    int nRotaion,
                                                    bool bItalic,
                                                    bool bBold,
                                                    bool bUnderline,
                                                    [MarshalAs(UnmanagedType.LPStr)]string strText,
                                                    int nReserved, /*not used*/
                                                    int nAlignment,
                                                    bool bDataCompression);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintTrueFontLibWithAlignW(int nXPos,
                                                    int nYPos,
                                                    [MarshalAs(UnmanagedType.LPWStr)]string strFontName,
                                                    int nFontSize,
                                                    int nRotaion,
                                                    bool bItalic,
                                                    bool bBold,
                                                    bool bUnderline,
                                                    [MarshalAs(UnmanagedType.LPWStr)]string strText,
                                                    int nReserved, /*not used*/
                                                    int nAlignment,
                                                    bool bDataCompression);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintVectorFont(
                                                    int nXPos,
                                                    int nYPos,
                                                    [MarshalAs(UnmanagedType.LPStr)]string FontSelection,
                                                    int FontWidth,
                                                    int FontHeight,
                                                    [MarshalAs(UnmanagedType.LPStr)]string RightSideCharSpacing,
                                                    bool bBold,
                                                    bool ReversePrinting,
                                                    bool TextStyle,
                                                    int Rotation,
                                                    [MarshalAs(UnmanagedType.LPStr)]string TextAlignment,
                                                    int TextDirection,
                                                    [MarshalAs(UnmanagedType.LPStr)]string pData);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintVectorFontW( //int nCodePage,
                                                    int nXPos,
                                                    int nYPos,
                                                    [MarshalAs(UnmanagedType.LPStr)]string FontSelection,
                                                    int FontWidth,
                                                    int FontHeight,
                                                    [MarshalAs(UnmanagedType.LPStr)]string RightSideCharSpacing,
                                                    bool bBold,
                                                    bool ReversePrinting,
                                                    bool TextStyle,
                                                    int Rotation,
                                                    [MarshalAs(UnmanagedType.LPStr)]string TextAlignment,
                                                    int TextDirection,
                                                    [MarshalAs(UnmanagedType.LPWStr)]string pData);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintQRCode(int nXPos,
                           int nYPos,
                           int nModel,
                           int nECCLevel,
                           int nSize,
                           int nRotation,
                           [MarshalAs(UnmanagedType.LPStr)]string pData);
        
        [DllImport("BXLLApi.dll")]
        public static extern bool PrintQRCode(int nXPos,
                           int nYPos,
                           int nModel,
                           int nECCLevel,
                           int nSize,
                           int nRotation,
                           Byte[] pData);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintPDF417(int nXPos,
                            int nYPos,
                            int nMaxRow,
                            int nMaxCol,
                            int nECLevel,
                            int nDataType,
                            bool bHRI,
                            int nOriginPoint,
                            int nModuleWidth,
                            int nBarHeight,
                            int nRotation,
                           [MarshalAs(UnmanagedType.LPStr)]string pData);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintMaxiCode(int nXPos,
                           int nYPos,
                           int nMode,
                           [MarshalAs(UnmanagedType.LPStr)]string pData);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintDataMatrix(int nXPos,
                           int nYPos,
                           int nSize,
                           bool bReverse,
                           int nRotation,
                           [MarshalAs(UnmanagedType.LPStr)]string pData);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintImageLib(int nHorizontalStartPos,
                                                int nVerticalStartPos,
                                                [MarshalAs(UnmanagedType.LPStr)]string pBitmapFilename,
                                                int nDither,
                                                bool bDataCompression);

        [DllImport("BXLLApi.dll")]
        public static extern bool PrintImageLibW(int nHorizontalStartPos,
                                                 int nVerticalStartPos,
                                                 [MarshalAs(UnmanagedType.LPWStr)]string pBitmapFilename,
                                                 int nDither,
                                                 bool bDataCompression);

        [DllImport("BXLLApi.dll")]
        public static extern bool SetShowMsgBox(bool bShow);

        [DllImport("BXLLAPI.dll")]
        public static extern int checkStatus();

        [DllImport("BXLLAPI.dll")]
        public static extern int CheckStatus();

        [DllImport("BXLLApi.dll")]
        public static extern bool WriteBuff(byte[] pBuffer, int dwNumberOfBytesToWrite, ref int dwWritten);

        [DllImport("BXLLApi.dll")]
        public static extern bool ReadBuff(byte[] pBuffer, int dwNumberOfBytesToRead, ref int dwReaded);

        [DllImport("BXLLApi.dll")]
        public static extern bool RFIDSetup(int RFIDType,
                                            int NumberOfRetries,
                                            int NumberOfLabel,
                                            int RadioPower);
        [DllImport("BXLLApi.dll")]
        public static extern bool RFIDCalibration();

        [DllImport("BXLLApi.dll")]
        public static extern bool RFIDWrite(int DataType,
                                            int StartingBlockNumber,
                                            int WriteByte,
                                            [MarshalAs(UnmanagedType.LPStr)]string Data);
        [DllImport("BXLLApi.dll")]
        public static extern bool RFIDPassword([MarshalAs(UnmanagedType.LPStr)]string OldAccessPwd,
                                               [MarshalAs(UnmanagedType.LPStr)]string OldKillPwd,
                                               [MarshalAs(UnmanagedType.LPStr)]string NewAccessPwd,
                                               [MarshalAs(UnmanagedType.LPStr)]string NewKillPwd);

        [DllImport("BXLLApi.dll")]
        public static extern bool RFIDLock();

    }
}
