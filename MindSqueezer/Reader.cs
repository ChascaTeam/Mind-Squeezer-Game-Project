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

        public static int Read()
        {
            return Console.Read();
        }

        public static string ReadNameCharLimit(int limit)
        {
            StringBuilder input = new StringBuilder();
            int i, count = 0;

            while ((i = Read()) != 13)   // 13 = enter key (or other breaking condition)
            {
                if (++count > limit) break;
                input.Append((char)i);
            }

            return input.ToString();
        }
    }
}
