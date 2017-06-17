using System;
using System.Threading;
using MindSqueezer.Utilities;

namespace MindSqueezer
{
    class Timer
    {
        private static Thread inputThread;
        private static AutoResetEvent getInput, gotInput;
        private static string input;
        private static bool gotInputt = false;

        private static void reader()
        {
            while (true)
            {
                getInput.WaitOne();
                input = Console.ReadLine();
                gotInputt = true;
                gotInput.Set();
            }
        }
      
        public static bool TryReadLine(out string line, int timeOutMillisecs = Timeout.Infinite)
        {
            getInput = new AutoResetEvent(false);
            gotInput = new AutoResetEvent(false);
            inputThread = new Thread(reader);
            gotInputt = false;
            inputThread.IsBackground = true;
            inputThread.Start();
            getInput.Set();

            
            //var success = false;

            for (int i = timeOutMillisecs; i >= 0 ; i -= 500)
            {
                if (gotInputt)
                {
                    break;
                }

                var cursorTop = Console.CursorTop;
                var cursorLeft = Console.CursorLeft;
                Console.SetCursorPosition(0, 0);

                ColorChanger.ChangeColor(ConsoleColor.Gray, ConsoleColor.Black);
                Writer.WriteMessage("You have ");
                ColorChanger.ChangeColor(ConsoleColor.Red, ConsoleColor.Black);
                Writer.WriteMessage($"{i / 1000}");
                ColorChanger.ChangeColor(ConsoleColor.Gray, ConsoleColor.Black);
                Writer.WriteMessage(" seconds to answer.\n");
                ColorChanger.ChangeColor(ConsoleColor.White, ConsoleColor.Black);

                Console.SetCursorPosition(cursorLeft, cursorTop);
                Thread.Sleep(500);
            }

            if (gotInputt)
            {
                line = input;
                inputThread.Abort();
            }
            else
            {
                line = null;
                inputThread.Abort();
            }               
            return gotInputt;
        }

    }
}
