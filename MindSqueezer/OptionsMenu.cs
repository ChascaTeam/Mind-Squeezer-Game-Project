using System;
using System.Collections.Generic;
using System.Linq;
using MindSqueezer.Questions;
using MindSqueezer.Utilities;

namespace MindSqueezer
{
    public static class OptionsMenu
    {
        public static int TotalScore;
        private static List<string> menu = Messages.MainMenu.Split('\n').ToList();

        public static void Menu()
        {
            int pointer = 2;
            var response = String.Empty;

            while (true)
            {
                DefaultColors();
                Console.Clear();
                int current = 1;

                foreach (var line in menu)
                {
                    DefaultColors();

                    if (current == 1)
                    {
                        ColorChanger.ChangeColor(ConsoleColor.Yellow, ConsoleColor.Black);
                    }
                    if (current == pointer)
                    {
                        if (current == 6)
                        {
                            ColorChanger.ChangeColor(ConsoleColor.Red, ConsoleColor.Black);
                            Writer.WriteMessageOnNewLine($"{line} <");
                        }
                        else
                        {
                            CurrentChoiceColors();
                            Writer.WriteMessageOnNewLine($"{line} <");
                        }
                    }
                    else
                    {
                        Writer.WriteMessageOnNewLine($"{line}");
                    }

                    current++;
                }

                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.Escape:
                        pointer = 6;
                        break;
                    case ConsoleKey.UpArrow:
                        if (pointer > 2) pointer--;
                        else pointer = 6;
                        break;
                    case ConsoleKey.DownArrow:
                        if (pointer < menu.Count()) pointer++;
                        else pointer = 2;
                        break;
                    case ConsoleKey.Enter:
                        goto breakOut;
                }
            }

            breakOut:
            switch (pointer)
            {
                case 2:
                    Start();
                    break;
                case 3:
                    Tutorial();
                    break;
                case 4:
                    GameRules();
                    break;
                case 5:
                    HighScores();
                    break;
                case 6:
                    Credits();
                    break;
                case 7:
                    Quit();
                    break;
            }
        }

        private static void Tutorial()
        {
            foreach (var question in Question.GetRegistredQuestions())
            {
                Console.Clear();

                ColorChanger.ChangeColor(ConsoleColor.Red, ConsoleColor.Black);
                Writer.WriteMessageOnNewLine(".: Tutorial :. ");
                ColorChanger.ChangeColor(ConsoleColor.Green, ConsoleColor.Black);
                Writer.WriteMessageOnNewLine($"Game: {question.Substring(question.LastIndexOf('.') + 1)}\n\n");

                ColorChanger.DefaultColor();

                Question quest =
                    Activator.CreateInstance(Type.GetType(question)) as Question;

                Writer.WriteMessageOnNewLine(quest.QuestionText + '\n');
                quest.GenerateQuestion();
                Writer.WriteMessageOnNewLine();

                ColorChanger.DefaultColor();

                Writer.WriteMessage($"\n\nThe answer is ");
                ColorChanger.ChangeColor(ConsoleColor.DarkGreen, ConsoleColor.Black);
                if (question.Contains("Math"))
                {
                    Writer.WriteMessage(string.Join(" | ", (quest as MathMatrixQuestion).GetAnswers()));
                }
                else
                {
                    Writer.WriteMessage(quest.Answer);
                }
                DefaultColors();
                Writer.WriteMessageOnNewLine(" ! Try to figure it yourself!");

                ColorChanger.ChangeColor(ConsoleColor.Yellow, ConsoleColor.Black);
                Writer.WriteMessageOnNewLine("\n\nPress space to see the solution or any key to continue...");

                if (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    Console.Clear();
                    ColorChanger.ChangeColor(ConsoleColor.Blue, ConsoleColor.Black);
                    quest.PrintSolution();
                    ColorChanger.DefaultColor();
                    Writer.WriteMessageOnNewLine("\n\nPress any key to continue...");
                    Console.ReadKey();
                }
            }
        }

        private static void CurrentChoiceColors()
        {
            ColorChanger.ChangeColor(ConsoleColor.Green, ConsoleColor.Black);
        }

        private static void DefaultColors()
        {
            ColorChanger.ChangeColor(ConsoleColor.White, ConsoleColor.Black);
        }

        private static void ReturnButton()
        {
            CurrentChoiceColors();
            Writer.WriteMessageOnNewLine("\n Return <");
            ConsoleKeyInfo key = Console.ReadKey(true);

            while (key.Key != ConsoleKey.Enter)
            {
                key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }

        private static void Start()
        {
            TotalScore = 0;

            while (true)
            {
                Console.Clear();

                Question quest =
                    Activator.CreateInstance(Type.GetType(Question.GetRandomQuestionType())) as Question;

                int seconds = quest.Seconds - TotalScore / 3;

                string name; 
                
                Writer.WriteMessageOnNewLine();

                Writer.WriteMessage(" Current Level: ");
                ColorChanger.ChangeColor(ConsoleColor.Green, ConsoleColor.Black);
                Writer.WriteMessage($"0{TotalScore / 3 + 1}\n");
                ColorChanger.DefaultColor();

                Writer.WriteMessageOnNewLine(quest.QuestionText);

                quest.GenerateQuestion();
                Writer.WriteMessageOnNewLine();

                bool success = Timer.TryReadLine(out name, seconds * 1000);

                if (!success)
                {
                    ColorChanger.ChangeColor(ConsoleColor.Red, ConsoleColor.Black);
                    Writer.WriteMessageOnNewLine();
                    Writer.WriteMessageOnNewLine(Messages.TimeUp);
                    ColorChanger.DefaultColor();

                    break;
                }

                if (!quest.IsCorrectAnswer(name))
                {
                    ColorChanger.ChangeColor(ConsoleColor.Red, ConsoleColor.Black);
                    Writer.WriteMessageOnNewLine(Messages.EndMsg);
                    ColorChanger.DefaultColor();

                    break;
                }

                Writer.WriteMessageOnNewLine();
                TotalScore = Score.Add(TotalScore);
                Writer.WriteMessageOnNewLine($"Total score: {TotalScore}");
                ColorChanger.ChangeColor(ConsoleColor.Green, ConsoleColor.Black);
                Writer.WriteMessageOnNewLine(Messages.RightInput);
                ColorChanger.DefaultColor();
                
                if (TotalScore % 3 == 0)
                {
                    Writer.WriteMessageOnNewLine(Messages.LevelUp);
                    System.Threading.Thread.Sleep(1000);
                }
                else
                {
                    System.Threading.Thread.Sleep(1000);
                }
            }

            ColorChanger.ChangeColor(ConsoleColor.Yellow, ConsoleColor.Black);
            Writer.WriteMessageOnNewLine($"Your score: {TotalScore}");
            ColorChanger.DefaultColor();
            System.Threading.Thread.Sleep(500);

            if (Score.CheckIfTopScore(TotalScore))
            {
                Writer.WriteMessageOnNewLine();
                ColorChanger.ChangeColor(ConsoleColor.Green, ConsoleColor.Black);
                Writer.WriteMessageOnNewLine(Messages.EnterTopThree);
                ColorChanger.DefaultColor();
                Writer.WriteMessage(Messages.WriteYourName);

                Score.IsInTheTop(TotalScore);
            }
            
            ReturnButton();
        }

        private static void GameRules()
        {
            Console.Clear();

            int indexOfOne = Messages.GameRules.IndexOf("1");
            int indexOfTwo = Messages.GameRules.IndexOf("2");
            int indexOfThree = Messages.GameRules.IndexOf("3");
            int indexOfFour = Messages.GameRules.IndexOf("4");

            ColorChanger.ChangeColor(ConsoleColor.Green, ConsoleColor.Black);
            Writer.WriteMessage(Messages.GameRules.Substring(0, 17));
            ColorChanger.ChangeColor(ConsoleColor.Yellow, ConsoleColor.Black);
            Writer.WriteMessage(Messages.GameRules.Substring(indexOfOne, 19));
            ColorChanger.DefaultColor();
            Writer.WriteMessage(Messages.GameRules.Substring(indexOfOne + 19, Messages.ColorQuestionRules.Length + 2));
            ColorChanger.ChangeColor(ConsoleColor.Yellow, ConsoleColor.Black);
            Writer.WriteMessage(Messages.GameRules.Substring(indexOfTwo, 22));
            ColorChanger.DefaultColor();
            Writer.WriteMessage(Messages.GameRules.Substring(indexOfTwo + 22, Messages.FindWordInMatrixRules.Length + 2));
            ColorChanger.ChangeColor(ConsoleColor.Yellow, ConsoleColor.Black);
            Writer.WriteMessage(Messages.GameRules.Substring(indexOfThree, 24));
            ColorChanger.DefaultColor();
            Writer.WriteMessage(Messages.GameRules.Substring(indexOfThree + 24, Messages.MathMatrixQuestionRules.Length + 2));
            ColorChanger.ChangeColor(ConsoleColor.Yellow, ConsoleColor.Black);
            Writer.WriteMessage(Messages.GameRules.Substring(indexOfFour, 34));
            ColorChanger.DefaultColor();
            Writer.WriteMessageOnNewLine(Messages.GameRules.Substring(indexOfFour + 34, Messages.ReadSentenceInMatrixQuestionRules.Length));

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
            ColorChanger.ChangeColor(ConsoleColor.White, ConsoleColor.Black);
            Environment.Exit(0);
        }
    }
}
