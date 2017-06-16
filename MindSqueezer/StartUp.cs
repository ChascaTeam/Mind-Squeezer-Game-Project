using System;
using MindSqueezer.Utilities;

namespace MindSqueezer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Question.RegisterQuestions();

            ColorChanger.ChangeColor(ConsoleColor.Green, ConsoleColor.Black);
            Writer.WriteMessageOnNewLine(Messages.EntryMsg);
            System.Threading.Thread.Sleep(2000);

            while (true)
            {
               
                OptionsMenu.Menu();
                
            }
        }
    }
}
