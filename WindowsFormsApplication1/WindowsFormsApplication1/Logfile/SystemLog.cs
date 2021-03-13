using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApplication1
{
    public class SystemLog
    {
        static SystemLog s_myInstance = null;
        string m_startUpPath = "";
        public enum MSG_TYPE
        {
            Nor,
            Err,
            War
        };
        private SystemLog()
        {
            try
            {
                m_startUpPath = Directory.GetCurrentDirectory();
                m_startUpPath += "\\Log\\";
                if (!Directory.Exists(m_startUpPath))
                    Directory.CreateDirectory(m_startUpPath);
            }
            catch (Exception /*ex*/) { }
        }

        public static void Output(MSG_TYPE msgType, string name, string str)
        {
            if (s_myInstance == null)
                s_myInstance = new SystemLog();
            s_myInstance.logout(msgType, name, str);
        }
        public static void Output(MSG_TYPE msgType, string name, string format, params object[] args)
        {
            if (s_myInstance == null)
                s_myInstance = new SystemLog();
            s_myInstance.logout(msgType, name, string.Format(format, args));
        }
        private void logout(MSG_TYPE msgType, string name, string str)
        {
            string filePath = m_startUpPath+"Log_" + DateTime.Now.ToString("yyyy_MM_dd") + ".txt";
            string output = name + " : " + str;
            try
            {
                using (System.IO.StreamWriter file = new System.IO.StreamWriter(@filePath, true))
                {
                    file.WriteLine(DateTime.Now.ToString("HH:mm:ss.fff ") + output);
                }
            }
            catch (Exception) { }
            
            EventBroker.AsyncSend(EventBroker.EventID.etLog, new EventBroker.EventParam(this, (int)msgType, output));
        }


    }
}
