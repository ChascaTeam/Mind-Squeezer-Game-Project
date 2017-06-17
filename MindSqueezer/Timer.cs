using System;
using System.Threading;
using MindSqueezer.Utilities;

namespace MindSqueezer
{
    class Timer
    {
        private static Thread inputThread;
        private static string input;
        private static bool gotInput;

        private static void reader()
        {
            while (true)
            {                
                input = Console.ReadLine();
                gotInput = true;            
            }
        }
      
        public static bool TryReadLine(out string line, int timeOutMillisecs = Timeout.Infinite)
        {         
            inputThread = new Thread(reader);
            gotInput = false;
            inputThread.IsBackground = true;
            inputThread.Start();
          
            for (int i = timeOutMillisecs; i >= 0 ; i -= 500)
            {
                if (gotInput)
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

            if (gotInput)
            {
                line = input;
                inputThread.Abort();
            }
            else
            {
                line = null;
                inputThread.Abort();
            }               
            return gotInput;
        }

    }
}
