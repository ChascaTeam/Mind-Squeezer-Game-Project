using System;

namespace MindSqueezer
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Question.RegisterQuestions();

            Writer.WriteMessageOnNewLine(Messages.EntryMsg);
            System.Threading.Thread.Sleep(2000);

            while (true)
            {
                
                OptionsMenu.Menu();
                
                
              
                
                //CheckIfTopScore(totalScore);
            }
        }
    }
}
