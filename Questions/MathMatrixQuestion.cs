using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MindSqueeze.App;

namespace MindSqueezer.Questions
{
    public class MathMatrixQuestion : Question
    {
        private const int rows = 6;
        private const int cols = 6;
        private int[][] matrix = new int[rows][];
        private List<string> correctAnswers = new List<string>();
        public MathMatrixQuestion(string equation)
        {
            this.QuestionText = String.Format(Messages.MathMatrixEquationCoordinates, equation);
        }

        public MathMatrixQuestion()
        {
            this.QuestionText = String.Format(Messages.MathMatrixEquationCoordinates);
        }
        public override void GenerateQuestion()
        {
            //Array with mathematical equations
            string[] equationsArr = new string[]
            {
                "4 + 3", "1 + 7", "16 / 4 + 3", "12/3 + 3", "12/3 + 2", "12/4 + 3", "13/13 + 0",
                "15*0 + 8", "2 + 7", "1 + 4", "2 + 3 - 4", "12/3 - 1 + 4", "(14 - 10) * 2",
                "10*0 + 9", "7 - 5 + 2", "2 * 3 + 1", "2 * 4 - 2", "12 - 7", "13 - 9", "9 - 8 + 2 + 3 + 1", "6 + 1 - 7"
            };

            //Matrix initialization.
            InitializeMatrix();

            //Choosing a random equation.
            int equationIndex = RandomGenerator.GetRandomNumber(equationsArr.Length);

            string equation = equationsArr[equationIndex];

            //Printing the equation.
            PrintEquation(equation);

            //Calculating the equation.
            int result = CalculateEquation(equation);
            
            //Populating the matrix containing at least one occurrence of the result.
            PopulateMatrix(result);

            //Printing the matrix.
            PrintMatrix(matrix);

           
        }

        private void InitializeMatrix()
        {
            for (int rowIndex = 0; rowIndex < rows; rowIndex++)
            {
                matrix[rowIndex] = new int[cols];
            }
        }

        private void PopulateMatrix(int result)
        {
            int row = RandomGenerator.GetRandomNumber(matrix.Length);
            int col = RandomGenerator.GetRandomNumber(matrix[0].Length);

            matrix[row][col] = result;
            correctAnswers.Add($"{(char)(row+65)} {col+1}");
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    if (rowIndex != row && colIndex != col)
                    {
                        int numToAdd = RandomGenerator.GetRandomNumber(10);
                        matrix[rowIndex][colIndex] = numToAdd;
                        if (numToAdd == result)
                        {
                            correctAnswers.Add($"{(char)(rowIndex + 65)} {colIndex + 1}");
                        }
                    }
                }
            }
        }

        private static void PrintEquation(string equation)
        {
            Writer.WriteMessageOnNewLine($"{equation} = X");
            Writer.WriteMessageOnNewLine("Example answer: A 1");
        }

        private static int CalculateEquation(string equation)
        {
            DataTable dt = new DataTable();
            var v = int.Parse(dt.Compute(equation, "").ToString());
            return v;
        }

        public override bool IsCorrectAnswer(string answer)
        {
            return this.correctAnswers.Contains(answer) && answer.Length != 0;
        }

        private static void PrintMatrix(int[][] matrix)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("- 1 2 3 4 5 6");
            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write((char)(rowIndex + 65));
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" " + matrix[rowIndex][colIndex]);
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }
    }
}
