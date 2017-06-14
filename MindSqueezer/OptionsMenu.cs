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
                        Writer.WriteMessageOnNewLine($">{line}<");
                    }
                    else
                    {
                        Writer.WriteMessageOnNewLine($" {line}");
                    }

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
                    Start();                  
                    break;
                case 3: 
                    GameRules();
                    break;
                case 4: 
                    HighScores();
                    break;
                case 5: 
                    Credits();
                    break;
                case 6: 
                    Quit();                 
                    break;
            }
        }

        private static void ReturnButton()
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Writer.WriteMessageOnNewLine(">return<");
            var key = Console.ReadKey();
        }

        private static void Start()
        {
            var totalScore = 0;

            while (true)
            {
                Console.Clear();

                Question quest =
                    Activator.CreateInstance(Type.GetType(Question.GetRandomQuestionType())) as Question;

                int secs = 25000;
                string name;

                Writer.WriteMessageOnNewLine($"You have {secs / 1000} seconds to answer.\n");
                Writer.WriteMessageOnNewLine(quest.QuestionText);

                quest.GenerateQuestion();

                bool success = Timer.TryReadLine(out name, secs);

                if (!success)
                {
                    Writer.WriteMessageOnNewLine(Messages.TimeUp);
                    break;
                }
                else if (!quest.IsCorrectAnswer(name))
                {
                    Writer.WriteMessageOnNewLine(Messages.WrongInput);
                    break;
                }

                totalScore = Score.Add(totalScore);
                Writer.WriteMessageOnNewLine($"Total score: {totalScore}");
                Writer.WriteMessageOnNewLine(Messages.RightInput);
                System.Threading.Thread.Sleep(1000);
            }

            Writer.WriteMessageOnNewLine($"Your score: {totalScore}");
            Writer.WriteMessageOnNewLine(Messages.EndMsg);
            System.Threading.Thread.Sleep(1000);
            if (Score.CheckIfTopScore(totalScore))
            {
                Writer.WriteMessageOnNewLine(Messages.EnterTopThree);
                Writer.WriteMessage(Messages.WriteYourName);

                Score.IsInTheTop(totalScore);
            }

            System.Threading.Thread.Sleep(1000);
        }

        private static void GameRules()
        {
            Console.Clear();
            Writer.WriteMessageOnNewLine(Messages.GameRules);
            ReturnButton();
        }

        private static void HighScores()
        {
            Console.Clear();
            Writer.WriteMessageOnNewLine(Messages.HighScores);
            Writer.WriteMessageOnNewLine(Messages.LongLine);
            Writer.WriteMessageOnNewLine(Messages.HighScoresPanel);
            Writer.WriteMessageOnNewLine(Messages.LongLine);
            Score.CheckHighScores();
            Writer.WriteMessageOnNewLine(Messages.LongLine);
            ReturnButton();
        }

        private static void Credits()
        {
            Console.Clear();
            Writer.WriteMessageOnNewLine(Messages.Credits);
            ReturnButton();
           
        }

        private static void Quit()
        {
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }
    }
}
