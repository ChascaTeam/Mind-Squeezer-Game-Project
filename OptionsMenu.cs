using System;

namespace MindSqueeze.App
{
    public static class OptionsMenu
    {
        public static void Menu()
        {
            
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
            else
            {
                Console.WriteLine(Messages.WrongInput);               
                OptionsMenu.Menu(); ;
            }
            
        }
    }
}
