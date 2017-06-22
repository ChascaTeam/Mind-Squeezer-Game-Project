using System;

namespace MindSqueezer
{
   public static class Writer
    {
        public static void WriteMessage(string message)
        {
            Console.Write(message);
        }

        public static void WriteMessageOnNewLine(string message)
        {
            Console.WriteLine(message);
        }

        public static void WriteMessageOnNewLine()
        {
            Console.WriteLine();
        }            
    }
}
