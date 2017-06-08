using System;
using MindSqueeze.App.Questions;

namespace MindSqueeze.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Question.RegisterQuestions();

            Writer.WriteMessageOnNewLine(Messages.EntryMsg);

            while (true)
            {
                OptionsMenu.Menu();
                
                var totalScore = 0;

                while (true)
                {
                    Console.Clear();

                    Question quest =
                        Activator.CreateInstance(Type.GetType(Question.GetRandomQuestionType())) as Question;

                    Writer.WriteMessageOnNewLine(quest.QuestionText);

                    quest.GenerateQuestion();

                    if (!quest.IsCorrectAnswer(Console.ReadLine()))
                    {
                        Console.WriteLine("wrong");
                        break;
                    }

                    totalScore = Score.Add(totalScore);

                    Writer.WriteMessageOnNewLine(Messages.RightInput);
                }

                Writer.WriteMessageOnNewLine(Messages.EndMsg);
                //CheckIfTopScore(totalScore);

                totalScore = 0;                            
            }
        }
    }
}
