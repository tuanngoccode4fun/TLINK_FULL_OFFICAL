using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Printing;



namespace UploadDataToDatabase
{
    public class PrinPDFFile
    {
        public void PrintPDfile(string pathFile)
        {
            //PdfDocument doc = new PdfDocument();
            //doc.LoadFromFile(pathFile);

            ////Use the default printer to print all the pages
            ////doc.PrintDocument.Print();

            ////Set the printer and select the pages you want to print

            //PrintDialog dialogPrint = new PrintDialog();
            //dialogPrint.AllowPrintToFile = true;
            //dialogPrint.AllowSomePages = true;
            //dialogPrint.PrinterSettings.MinimumPage = 1;
            //dialogPrint.PrinterSettings.MaximumPage = doc.Pages.Count;
            //dialogPrint.PrinterSettings.FromPage = 1;
            //dialogPrint.PrinterSettings.ToPage = doc.Pages.Count;
            
            //if (dialogPrint.ShowDialog() == DialogResult.OK)
            //{
            //    //Set the pagenumber which you choose as the start page to print
            //    doc.PrintFromPage = dialogPrint.PrinterSettings.FromPage;
            //    //Set the pagenumber which you choose as the final page to print
            //    doc.PrintToPage = dialogPrint.PrinterSettings.ToPage;
            //    //Set the name of the printer which is to print the PDF
            //    doc.PrinterName = dialogPrint.PrinterSettings.PrinterName;
            //    doc.PageScaling = PdfPrintPageScaling.ActualSize;
            //    PrintDocument printDoc = doc.PrintDocument;
            //    dialogPrint.Document = printDoc;
            //    printDoc.Print();
            //}
        }


    }
}

