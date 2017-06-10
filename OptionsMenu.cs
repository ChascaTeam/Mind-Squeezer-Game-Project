using System;

namespace MindSqueezer
{
    public static class OptionsMenu
    {
        public static void Menu()
        {
            Writer.WriteMessageOnNewLine(Messages.MainMenu);
            string response = Reader.ReadLine();

            if(response == "Info")
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
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine(Messages.WrongInput);               
                OptionsMenu.Menu(); ;
            }
            
        }
    }
}
