using System;
using System.Linq;

namespace MindSqueeze.App.Questions
{
    public class ColorQuestion : Question
    {
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

            this.Answer = Enum.GetName(typeof(ConsoleColor),
                RandomGenerator.GetRandomNumber(Enum.GetValues(typeof(ConsoleColor)).Length));

            Console.ForegroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), this.Answer);

            Writer.WriteMessageOnNewLine(Enum.GetName(typeof(ConsoleColor),
                RandomGenerator.GetRandomNumber(Enum.GetValues(typeof(ConsoleColor)).Length)));

            Console.ForegroundColor = curColor;
        }

        public override bool IsCorrectAnswer(string answer)
        {
            return this.Answer.ToLower().Contains(answer.ToLower()) && answer.Length != 0;
        }
    }
}
