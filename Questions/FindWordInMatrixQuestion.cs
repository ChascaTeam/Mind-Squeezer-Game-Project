namespace MindSqueezer.Questions
{
    using MindSqueeze.App;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FindWordInMatrixQuestion : Question
    {
        public FindWordInMatrixQuestion(string questionText)
        {
            this.QuestionText = questionText;
        }

        public FindWordInMatrixQuestion() 
            : this(Messages.QuestionTypeFindWordInMatrix)
        {

        }

        public override void GenerateQuestion()
        {
            Console.WriteLine();

            // Array with 4 and 5 letters words
            string[] words = new string[]
            {
                "quake", "glazy", "japan", "joker", "pizza", "quick", "zombi",
                "quirk", "jazz", "quiz", "jump", "junk", "cozy", "joke", "java",
                "lazy", "maze", "zoom", "kick", "haze", "mock", "back", "wick",
                "judo", "pump", "exam", "bump", "zone", "pack", "doze", "quit",
                "juice", "knock", "prize", "klick", "hazel", "query", "zebra",
                "chump", "mummy", "check", "chick", "puppy", "eject", "enjoy", "glaze"
            };

            // Array with alphabet
            char[] alphabet = new char[]
            {
                'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm',
                'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'
            };

            // Initializing of matix
            int rows = 4;
            int cols = 5;
            char[][] matrix = new char[rows][];

            for (int currRow = 0; currRow < 4; currRow++)
            {
                matrix[currRow] = new char[cols];
            }

            // Choosing random word from the array
            Random random = new Random();
            int wordIndex = random.Next(0, words.Length - 1);
            int count = 0;
        }

        public override bool IsCorrectAnswer(string answer)
        {
            return base.IsCorrectAnswer(answer);
        }
    }
}
