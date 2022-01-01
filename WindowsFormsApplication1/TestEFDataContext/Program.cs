using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EFTechLink;
using EFTechLink.Implementation;
using EFTechLink.Interface;

namespace TestEFDataContext
{

    class Program
    {
        private static DataContextAction dataContextAction = new DataContextAction();

        public static void Main(string[] args)
        {
            bool isExist = false;
            while (!isExist)
            {
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Test Insert!");
                        TestInsert();
                        break;
                    case "2":
                        Console.WriteLine("Test Update!");
                        TestUpdate();
                        break;
                    case "3":
                        Console.WriteLine("Test Delete!");
                        TestDelete();
                        break;
                    case "4":
                        isExist = true;
                        Console.WriteLine("Exist");
                        break;
                }
            }

            // Wait for the user to respond before closing.
            Console.Write("Press any key to close the  console app...");
            Console.ReadKey();
        }

        private static void TestInsert()
        {
            var transaction = new ImportTransaction()
            {
                QRCode = "Test at " + DateTime.Now.ToString("d"),
                TransactionStatusId = 2,
                HighlightMessage = "Test at " + DateTime.Now.ToString("hh:mm:ss"),
                HeaderCode = "1101",
                HeaderNo = DateTime.Now.ToString("yyyyMMdd"),
                HeaderSTT = "1",
                ExecutedByUser = "AN",
                ProductionOrder = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmm"),
                Lot = "Test",
                WareHouse = "A1",
                Location = "1",
            };

            dataContextAction.Insert(transaction);
        }

        private static void TestUpdate()
        {
            var transaction = new ImportTransaction()
            {
                QRCode = "Test at " + DateTime.Now.ToString("d"),
                TransactionStatusId = 2,
                HighlightMessage = "Test update at " + DateTime.Now.ToString("hh:mm:ss"),
                HeaderCode = "1101",
                HeaderNo = DateTime.Now.ToString("yyyyMMdd"),
                HeaderSTT = "1",
                ExecutedByUser = "AN",
                ProductionOrder = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmm"),
                Lot = "Test",
                WareHouse = "A1",
                Location = "1",
            };

            var transactionTraced = dataContextAction.select(transaction.QRCode, transaction.HeaderCode, transaction.HeaderNo, transaction.HeaderSTT);

            transactionTraced.HighlightMessage = transaction.HighlightMessage;

            dataContextAction.Update(transactionTraced);
        }

        private static void TestDelete()
        {
            var transaction = new ImportTransaction()
            {
                QRCode = "Test at " + DateTime.Now.ToString("d"),
                TransactionStatusId = 2,
                HighlightMessage = "Test at " + DateTime.Now.ToString("hh:mm:ss"),
                HeaderCode = "1101",
                HeaderNo = DateTime.Now.ToString("yyyyMMdd"),
                HeaderSTT = "1",
                ExecutedByUser = "AN",
                ProductionOrder = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.ToString("HHmm"),
                Lot = "Test",
                WareHouse = "A1",
                Location = "1",
            };

            var transactionTraced = dataContextAction.select(transaction.QRCode, transaction.HeaderCode, transaction.HeaderNo, transaction.HeaderSTT);

            dataContextAction.Delete(transactionTraced);
        }
    }
}
