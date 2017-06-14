using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MindSqueezer
{
    class Timer
    {
        private static Thread inputThread;
        private static AutoResetEvent getInput, gotInput;
        private static string input;

        private static void reader()
        {
            while (true)
            {
                getInput.WaitOne();
                input = Console.ReadLine();
                gotInput.Set();
            }
        }
      
        public static bool TryReadLine(out string line, int timeOutMillisecs = Timeout.Infinite)
        {
            getInput = new AutoResetEvent(false);
            gotInput = new AutoResetEvent(false);
            inputThread = new Thread(reader);
            inputThread.IsBackground = true;
            inputThread.Start();
            getInput.Set();
            bool success = gotInput.WaitOne(timeOutMillisecs);
            if (success)
            {
                line = input;
                inputThread.Abort();
            }
            else
            {
                line = null;
                inputThread.Abort();
            }               
            return success;
        }

    }
}
