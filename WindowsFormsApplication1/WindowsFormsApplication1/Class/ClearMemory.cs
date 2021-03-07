using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace WindowsFormsApplication1
{
    public class ClearMemory
    {
        [System.Runtime.InteropServices.DllImport("kernel32.dll", EntryPoint = "SetProcessWorkingSetSize", ExactSpelling = true, CharSet = System.Runtime.InteropServices.CharSet.Ansi, SetLastError = true)]
        private static extern int SetProcessWorkingSetSize(IntPtr process, int minimumWorkingSetSize, int maximumWorkingSetSize);

        public static void CleanMemoryCompletely()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
            Environment.Exit(0);

        }
        public static void CleanMemory()
        {
            GC.Collect();
            GC.WaitForPendingFinalizers();
          
           
        }
    }
}
