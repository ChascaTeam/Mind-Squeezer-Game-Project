using System;
using MindSqueezer.Utilities;

namespace MindSqueezer.Questions
{
    public class ColorQuestion : Question
    {
        private static readonly string[] colors = new string[]
        {
            "Gray", "White", "Yellow", "Green", "Blue", "Red"
        };

        public ColorQuestion(string questionText, int seconds)
        {
            this.QuestionText = questionText;
            this.Seconds = seconds;
        }
        public ColorQuestion()
            : this(Messages.QuestionTypeColorGuess, 5)
        {
        }
        
        public override void GenerateQuestion()
        {
            var curColor = Console.ForegroundColor;

            this.Answer = colors[RandomGenerator.GetRandomNumber(colors.Length)];

            Console.ForegroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), this.Answer);

            Writer.WriteMessageOnNewLine(colors[RandomGenerator.GetRandomNumber(colors.Length)]);

            Console.ForegroundColor = curColor;
        }

        public override bool IsCorrectAnswer(string answer)
        {
            return this.Answer.ToLower().Equals(answer.ToLower()) && answer.Length != 0;
        }

        public override void PrintSolution()
        {
            Writer.WriteMessageOnNewLine($"The Correct Answer is:\n\n{Answer.ToUpper()}");
        }
    }
}
