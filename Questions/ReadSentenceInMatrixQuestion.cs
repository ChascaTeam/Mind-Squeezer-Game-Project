using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MindSqueeze.App;

namespace MindSqueezer.Questions
{
    class ReadSentenceInMatrixQuestion : Question
    {
        public ReadSentenceInMatrixQuestion(string questionText)
        {
            this.QuestionText = questionText;
        }
        public ReadSentenceInMatrixQuestion()
            : this(Messages.QuestionTypeColorGuess)
        {
        }

        public override void GenerateQuestion()
        {
            // Creates random six word sentence
            string[] sentence = Sentence();

            // Creates char matrix
            char[][] matrix = Matrix();

            // Choose matrix type
            Random random = new Random();
            int randomMatrixType = random.Next(0, 3);

            // all types fill the matrix in zig-zag form
            // FirstType - 0 takes from top left to top right (up&down)
            // FirstType - 1 takes from bottom left to bottom right (down&up)
            // SecondType - 0 takes from top right to top left (up&down)
            // SecondType - 1 takes from bottom right to bottom left (down&up)

            if (randomMatrixType == 0)
            {
                matrix = FirstType(sentence, matrix, 0);
            }
            else if (randomMatrixType == 1)
            {
                matrix = FirstType(sentence, matrix, 1);
            }
            else if (randomMatrixType == 2)
            {
                matrix = SecondType(sentence, matrix, 0);
            }
            else if (randomMatrixType == 3)
            {
                matrix = SecondType(sentence, matrix, 1);
            }
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }

        }

        public static string[] Sentence()
        {
            Console.WriteLine();

            // Arrays with words for the sentence building
            string[] firstWord = new string[]
            {
                "advanced","affected","autistic","catholic","abstract",
                "powerful","precious", "romantic", "southern", "suburban",
                "superior", "terrible", "thousand"
            };
            string[] secondWord = new string[]
            {
                "dogs", "cats", "bugs", "apes", "bees",
                "elks", "boys", "gods"
            };
            string[] thirdWord = new string[]
            {
                "ate","bit","did","dug","got",
                "had","hid","led","met","saw"
            };
            string[] fifthWord = new string[]
            {
                "acid","aged","army","cool","cold",
                "desk","evil","lost"
            };
            string[] sixthWord = new string[]
            {
                "computer","economic","evidence","graphics","homeless",
                "homepage","keyboard","producer","provider","princess",
                "software","solution","universe","advocate","alliance",
                "bacteria","children"
            };

            //making random sentence
            Random random = new Random();
            int[] indexes = new int[5];
            indexes[0] = random.Next(0, firstWord.Length - 1);
            indexes[1] = random.Next(0, secondWord.Length - 1);
            indexes[2] = random.Next(0, thirdWord.Length - 1);
            indexes[3] = random.Next(0, fifthWord.Length - 1);
            indexes[4] = random.Next(0, sixthWord.Length - 1);

            string[] sentence = new String[] {

                firstWord[indexes[0]], secondWord[indexes[1]], thirdWord[indexes[2]],
                "the", fifthWord[indexes[3]], sixthWord[indexes[4]]
            };

            return sentence;
        }

        public static char[][] Matrix()
        {
            int rows = 6;
            int cols = 5;
            char[][] matrix = new char[rows][];
            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new char[cols];
            }

            return matrix;
        }

        public static Queue<char> Queue(string[] sentence)
        {
            string matrixSentence = string.Join("", sentence);
            Queue<char> queue = new Queue<char>();
            foreach (var letter in matrixSentence)
            {
                queue.Enqueue(letter);
            }
            return queue;
        }

        public static char[][] FirstType(string[] sentence, char[][] matrix, int direction)
        {
            Queue<char> matrixFiller = Queue(sentence);

            while (matrixFiller.Count != 0)
            {
                for (int col = 0; col < matrix.Length - 1; col++)
                {
                    if (col % 2 == direction)
                    {
                        for (int row = 0; row <= matrix[col].Length; row++)
                        {
                            matrix[row][col] = matrixFiller.Dequeue();
                        }
                    }
                    else
                    {
                        for (int row = matrix[col].Length; row >= 0; row--)
                        {
                            matrix[row][col] = matrixFiller.Dequeue();
                        }
                    }
                }
            }

            return matrix;
        }
        public static char[][] SecondType(string[] sentence, char[][] matrix, int direction)
        {
            Queue<char> matrixFiller = Queue(sentence);

            while (matrixFiller.Count != 0)
            {
                for (int col = matrix.Length - 2; col >= 0; col--)
                {
                    if (col % 2 == direction)
                    {
                        for (int row = 0; row <= matrix[col].Length; row++)
                        {
                            matrix[row][col] = matrixFiller.Dequeue();
                        }
                    }
                    else
                    {
                        for (int row = matrix[col].Length; row >= 0; row--)
                        {
                            matrix[row][col] = matrixFiller.Dequeue();
                        }
                    }
                }
            }

            return matrix;
        }

        public override bool IsCorrectAnswer(string answer)
        {
            return this.Answer.ToLower().Contains(answer.ToLower()) && answer.Length != 0;
        }
    }
}
