using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UploadDataToDatabase
{

        public enum StatusLog { Normal, Warning, Error };
        public class Logfile
        {
            private static readonly Logfile instance = new Logfile();
            private string mFilePath = string.Empty;
            private const int QUEUE_SIZE = 20;
            private Queue<KeyValuePair<StatusLog, string>> mLogQueue = new Queue<KeyValuePair<StatusLog, string>>(QUEUE_SIZE + 1);
            private static Object mSynce = new Object();
            public delegate void MessageReceivedCallback(object sender, StatusLog isError, string message);
            public static event MessageReceivedCallback MessageReceivedEventHandler;

            public static void Output(StatusLog isError, string format, params object[] param)
            {
                instance._Output(isError, format, param);
            }
            public static void Output(StatusLog isError, string format)
            {
                instance._Output(isError, format);
            }
            public static void Output(object sender, StatusLog isError, string format)
            {
                instance._Output(isError, format);
            }
            public static KeyValuePair<StatusLog, string>[] GetLogQueue()
            {
                return instance.mLogQueue.ToArray();
            }
            public static void DeleteOldFile()
            {
                instance._deleteOldFile();
            }

            private Logfile()
            {
                try
                {
                    mFilePath = Directory.GetCurrentDirectory();
                    mFilePath += "\\Log\\";
                    if (!Directory.Exists(mFilePath))
                        Directory.CreateDirectory(mFilePath);
                }
                catch (Exception /*ex*/) { }
            }


            private string FileName
            {
                get
                {
                    DateTime dateNow = DateTime.Now;
                    string fileName = mFilePath + "Log_";
                    fileName += dateNow.ToString("yyyy_MM_dd");
                    fileName += ".txt";
                    return fileName;
                }
            }


            private void _Output(StatusLog isError, string format, params object[] param)
            {
                try
                {
                    lock (mSynce)
                    {
                        string logMsg = string.Format("{0}{1}", DateTime.Now.ToString("[HH:mm:ss.fff] "), String.Format(format, param));
                        if (mLogQueue.Count >= QUEUE_SIZE)
                            mLogQueue.Dequeue();
                        mLogQueue.Enqueue(new KeyValuePair<StatusLog, string>(isError, logMsg));
                        using (StreamWriter writer = new StreamWriter(FileName, true))
                        {
                            writer.WriteLine(logMsg);
                        }
                        MessageReceivedEventHandler?.Invoke(this, isError, logMsg);
                    }
                }
                catch (Exception)
                {

                }
            }

            public void _deleteOldFile()
            {
                try
                {
                    DirectoryInfo dinfo = new DirectoryInfo(mFilePath);
                    if (dinfo.Exists == true)
                    {
                        int month = DateTime.Now.Month;
                        foreach (var fi in dinfo.GetFiles())
                        {
                            if (fi.CreationTime.Month != month)
                            {
                                try
                                {
                                    fi.Delete();
                                }
                                catch (Exception /*ex*/) { }
                            }

                        }
                    }
                }
                catch (Exception /*ex*/) { }
            }
        }
}
