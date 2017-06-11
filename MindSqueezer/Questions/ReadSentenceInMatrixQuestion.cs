using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MindSqueezer.Enums;
using MindSqueezer.Utilities;

namespace MindSqueezer.Questions
{
    class ReadSentenceInMatrixQuestion : Question
    {
        public ReadSentenceInMatrixQuestion(string questionText)
        {
            this.QuestionText = questionText;
        }
        public ReadSentenceInMatrixQuestion()
            : this(Messages.QuestionTypeReadSentenceInMatrix)
        {
        }

        public override void GenerateQuestion()
        {
            // Creates random six word sentence
            string[] sentence = Sentence();

            // Creates char matrix
            char[][] matrix = Matrix();

            // Choose matrix type & fill it with the sentence
            matrix = MatrixType(sentence, matrix);

            PrintMatrix(matrix);

            this.Answer = string.Join(" ", sentence);
        }

        private static string[] Sentence()
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

        private static char[][] Matrix()
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

        private static char[][] MatrixType(string[] sentence, char[][] matrix)
        {
            SentenceInMatrixType randomMatrixType = (SentenceInMatrixType) RandomGenerator.GetRandomNumber(Enum.GetValues(typeof(SentenceInMatrixType)).Length);

            // all types fill the matrix in zig-zag form
            // |Matrix Name |matrix start |matrix end  |zig-zag direction|
            // ------------------------------------------------------------
            // |FirstType  0|top left     |top right   |up&down          |
            // |FirstType  1|bottom left  |bottom right|down&up          |
            // |SecondType 0|top right    |top left    |up&down          |
            // |SecondType 1| bottom right|bottom left |down&up          |
            // |ThirdType  0| top left    |bottom left |left&right       |
            // |ThirdType  1| top right   |bottom right|left&right       |
            // |ThirdType  0| bottom left |top left    |left&right       |
            // |ThirdType  1| bottom right|top right   |left&right       |

            switch (randomMatrixType)
            {
                case SentenceInMatrixType.TopLeftRight:
                    matrix = FirstType(sentence, matrix, 0);
                    break;

                case SentenceInMatrixType.BottomLeftRight:
                    matrix = FirstType(sentence, matrix, 1);
                    break;

                case SentenceInMatrixType.TopRightLeft:
                    matrix = SecondType(sentence, matrix, 0);
                    break;

                case SentenceInMatrixType.BottomRightLeft:
                    matrix = SecondType(sentence, matrix, 1);
                    break;

                case SentenceInMatrixType.TopLeftBottomLeft:
                    matrix = ThirdType(sentence, matrix, 0);
                    break;

                case SentenceInMatrixType.TopRightBottomRight:
                    matrix = ThirdType(sentence, matrix, 1);
                    break;

                case SentenceInMatrixType.BottomLeftTopLeft:
                    matrix = FourthType(sentence, matrix, 0);
                    break;

                case SentenceInMatrixType.BottomRightTopRight:
                    matrix = FourthType(sentence, matrix, 1);
                    break;
            }

            return matrix;
        }

        private static char[][] FirstType(string[] sentence, char[][] matrix, int direction)
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

        private static char[][] SecondType(string[] sentence, char[][] matrix, int direction)
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

        private static char[][] ThirdType(string[] sentence, char[][] matrix, int direction)
        {
            Queue<char> matrixFiller = Queue(sentence);

            while (matrixFiller.Count != 0)
            {
                for (int row = 0; row < matrix.Length; row++)
                {
                    if (row % 2 == direction)
                    {
                        for (int col = 0; col <= matrix[row].Length - 1; col++)
                        {
                            matrix[row][col] = matrixFiller.Dequeue();
                        }
                    }
                    else
                    {
                        for (int col = matrix[row].Length - 1; col >= 0; col--)
                        {
                            matrix[row][col] = matrixFiller.Dequeue();
                        }
                    }
                }
            }

            return matrix;
        }

        private static char[][] FourthType(string[] sentence, char[][] matrix, int direction)
        {
            Queue<char> matrixFiller = Queue(sentence);

            while (matrixFiller.Count != 0)
            {
                for (int row = matrix.Length - 1; row >= 0; row--)
                {
                    if (row % 2 == direction)
                    {
                        for (int col = 0; col <= matrix[row].Length - 1; col++)
                        {
                            matrix[row][col] = matrixFiller.Dequeue();
                        }
                    }
                    else
                    {
                        for (int col = matrix[row].Length - 1; col >= 0; col--)
                        {
                            matrix[row][col] = matrixFiller.Dequeue();
                        }
                    }
                }
            }

            return matrix;
        }

        private static Queue<char> Queue(string[] sentence)
        {
            string matrixSentence = string.Join("", sentence);
            Queue<char> queue = new Queue<char>();
            foreach (var letter in matrixSentence)
            {
                queue.Enqueue(letter);
            }
            return queue;
        }

        private static void PrintMatrix(char[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write($"{matrix[row][col]} ");
                }
                Console.WriteLine();
            }
        }

        public override bool IsCorrectAnswer(string answer)
        {
            return this.Answer.ToLower().Contains(answer.ToLower()) && answer.Length != 0;
        }
    }
}
