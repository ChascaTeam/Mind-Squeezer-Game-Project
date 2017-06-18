using System;
using MindSqueezer.Utilities;

namespace MindSqueezer
{
    public class Reader
    {
        public static string ReadLine()
        {
            return Console.ReadLine();
        }

        public static string ReadNameCharLimit(int limit)
        {
            string inputName = ReadLine();

            while (inputName.Length == 0 || inputName.Contains(" ") || inputName.Contains("\t"))
            {

                ColorChanger.ChangeColor(ConsoleColor.Red, ConsoleColor.Black);
                Writer.WriteMessageOnNewLine(Messages.EmptyName);
                ColorChanger.ChangeColor(ConsoleColor.White, ConsoleColor.Black);
                                                  
                inputName = ReadLine();               
            }
            

            if (inputName.Length > limit)
            {
                inputName = inputName.Substring(0, limit);
            }

            return inputName;
        }
    }
}
