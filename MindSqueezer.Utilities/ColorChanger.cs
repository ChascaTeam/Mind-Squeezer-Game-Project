using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindSqueezer.Utilities
{
    public static class ColorChanger
    {
        public static void ChangeColor (ConsoleColor foreColor, ConsoleColor backColor)
        {
            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = backColor;
        }

        public static void DefaultColor()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
