using System;
using System.Collections.Generic;
using System.Linq;

namespace MindSqueezer
{
    public static class OptionsMenu
    {
        public static void Menu()
        {
            List<string> menu = Messages.MainMenu.Split('\n').ToList();
            int pointer = 2;

            var response = String.Empty;

            while (true)
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Clear();
                int current = 1;

                foreach (var line in menu)
                {
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    if (current == pointer)
                    {
                        Console.BackgroundColor = ConsoleColor.White;
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    Console.WriteLine($"{line}");
                    current++;
                }

                var key = Console.ReadKey();
                switch (key.Key.ToString())
                {
                    case "UpArrow":
                        if (pointer > 2) pointer--;
                        break;
                    case "DownArrow":
                        if (pointer < menu.Count()) pointer++;
                        break;
                    case "Enter":
                        goto breakOut;
                    case "Escape":
                        return;
                }
                
            }
            breakOut:
            switch (pointer)
            {
                case 2:
                    response = "Start";
                    break;
                case 3:
                    response = "Info";
                    break;
                case 4:
                    response = "HighScores";
                    break;
                case 5:
                    response = "Quit";
                    break;
            }

            if (response == "Info")
            {
                Writer.WriteMessageOnNewLine(Messages.Info);
            }
            else if (response == "Start")
            {
                //TODO               
            }
            else if (response == "HighScores")
            {
                //TODO
            }
            else if (response == "Quit")
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Environment.Exit(0);
            }
        }
    }
}
