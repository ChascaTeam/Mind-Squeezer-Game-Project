using System;

namespace MindSqueezer.Questions
{
    public class ColorQuestion : Question
    {
        private static readonly string[] colors = new string[]
        {
            "Gray", "White", "Yellow", "Green", "Blue", "Red"
        };

        public ColorQuestion(string questionText)
        {
            this.QuestionText = questionText;
        }
        public ColorQuestion()
            : this(Messages.QuestionTypeColorGuess)
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
            return this.Answer.ToLower().Contains(answer.ToLower()) && answer.Length != 0;
        }
    }
}
