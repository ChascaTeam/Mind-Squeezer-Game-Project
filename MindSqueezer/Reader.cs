using System;
using System.Text;

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

            if (inputName.Length > limit)
            {
                inputName = inputName.Substring(0, limit);
            }
            return inputName;
        }
    }
}
