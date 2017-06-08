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
            int wordIndex = RandomGenerator.GetRandomNumber(words.Length);
            int count = 0;

            // Checking the length of the word
            string currentWord = words[wordIndex];

            if (currentWord.Length == 4)
            {
                if (count % 3 == 0)
                {
                    InsertWordInFirstColumn(matrix, currentWord);
                }
                else if (count % 3 == 1)
                {
                    InsertWordInLastColumn(matrix, currentWord);
                }
                else if (count % 3 == 2)
                {
                    InsertWordInDiagonal(matrix, currentWord);
                }

                count++;
            }
            else if (currentWord.Length == 5)
            {
                if (count % 2 != 0)
                {
                    InsertWordInTopRow(matrix, currentWord);
                }
                else if (count % 2 == 0)
                {
                    InsertWordInBottomRow(matrix, currentWord);
                }

                count++;
            }

            FillingTheRestPartOfTheMatrix(matrix, alphabet);

            // Choosing rotation type
            int rotationType = RandomGenerator.GetRandomNumber(1, 4);

            if (rotationType == 1)
            {
                matrix = RotateMatrixOneTime(matrix);
            }
            else if (rotationType == 2)
            {
                matrix = RotateMatrixTwoTimes(matrix);
            }
            else if (rotationType == 3)
            {
                matrix = RotateMatrixThreeTimes(matrix);
            }

            PrintMatrix(matrix, rotationType, rows, cols);

            this.Answer = currentWord;

        }

        public override bool IsCorrectAnswer(string answer)
        {
            return this.Answer.ToLower().Equals(answer.ToLower()) && answer.Length != 0;
        }

        private static void PrintMatrix(char[][] matrix, int rotationType, int rows, int cols)
        {
            if (rotationType == 1 || rotationType == 3)
            {
                for (int currRow = 0; currRow < cols; currRow++)
                {
                    Console.WriteLine(string.Join(" ", matrix[currRow]));
                }
            }
            else
            {
                for (int currRow = 0; currRow < rows; currRow++)
                {
                    Console.WriteLine(string.Join(" ", matrix[currRow]));
                }
            }

            Console.WriteLine();
        }

        private static char[][] RotateMatrixThreeTimes(char[][] matrix)
        {
            char[][] rotatedMatrix = new char[matrix[0].Length][];

            int row = 0;

            for (int currCol = matrix[0].Length - 1; currCol >= 0; currCol--)
            {
                rotatedMatrix[row] = new char[matrix.Length];
                int col = 0;

                for (int currRow = 0; currRow < matrix.Length; currRow++)
                {
                    rotatedMatrix[row][col] = matrix[currRow][currCol];
                    col++;
                }

                row++;
            }

            return rotatedMatrix;
        }

        private static char[][] RotateMatrixTwoTimes(char[][] matrix)
        {
            char[][] rotatedMatrix = new char[matrix.Length][];

            int row = 0;

            for (int currRow = matrix.Length - 1; currRow >= 0; currRow--)
            {
                rotatedMatrix[row] = matrix[currRow].Reverse().ToArray();
                row++;
            }

            return rotatedMatrix;
        }

        private static char[][] RotateMatrixOneTime(char[][] matrix)
        {
            char[][] rotatedMatrix = new char[matrix[0].Length][];

            int row = 0;

            for (int currCol = 0; currCol < matrix[0].Length; currCol++)
            {
                rotatedMatrix[currCol] = new char[matrix.Length];
                int col = 0;

                for (int currRow = matrix.Length - 1; currRow >= 0; currRow--)
                {
                    char currElement = matrix[currRow][currCol];
                    rotatedMatrix[row][col] = currElement;
                    col++;
                }

                row++;
            }

            return rotatedMatrix;
        }

        private static void FillingTheRestPartOfTheMatrix(char[][] matrix, char[] alphabet)
        {
            for (int currRow = 0; currRow < matrix.Length; currRow++)
            {
                for (int currCol = 0; currCol < matrix[0].Length; currCol++)
                {
                    char currElement = matrix[currRow][currCol];

                    if (currElement == 0)
                    {
                        int letterIndex = RandomGenerator.GetRandomNumber(0, alphabet.Length - 1);
                        matrix[currRow][currCol] = alphabet[letterIndex];
                    }
                }
            }
        }

        private static void InsertWordInDiagonal(char[][] matrix, string currentWord)
        {
            for (int currRow = 0; currRow < matrix.Length; currRow++)
            {
                matrix[currRow][currRow] = currentWord[currRow];
            }
        }

        private static void InsertWordInLastColumn(char[][] matrix, string currentWord)
        {
            for (int currRow = 0; currRow < matrix.Length; currRow++)
            {
                matrix[currRow][matrix[0].Length - 1] = currentWord[currRow];
            }
        }

        private static void InsertWordInFirstColumn(char[][] matrix, string currentWord)
        {
            for (int currRow = 0; currRow < matrix.Length; currRow++)
            {
                matrix[currRow][0] = currentWord[currRow];
            }
        }

        private static void InsertWordInBottomRow(char[][] matrix, string currentWord)
        {
            for (int currCol = 0; currCol < matrix[matrix.Length - 1].Length; currCol++)
            {
                matrix[matrix.Length - 1][currCol] = currentWord[currCol];
            }
        }

        private static void InsertWordInTopRow(char[][] matrix, string currentWord)
        {
            for (int currCol = 0; currCol < matrix[0].Length; currCol++)
            {
                matrix[0][currCol] = currentWord[currCol];
            }
        }
    }
}
