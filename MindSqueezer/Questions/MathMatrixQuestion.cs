using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using MindSqueezer.Utilities;

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
            GenerateEquations();
            //Array with mathematical equations
            string[] equationsArr = GenerateEquations();

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

        private static string[] GenerateEquations()
        {
            int numberUpTo4 = Utilities.RandomGenerator.GetRandomNumber(4);
            int numberUpTo5 = Utilities.RandomGenerator.GetRandomNumber(5);
            int numberUpTo6 = Utilities.RandomGenerator.GetRandomNumber(6);
            string equationA = $"{numberUpTo4} * 2 + 1";
            string equationB = $"1 + 2 * {numberUpTo4}";
            string equationC = $"3 + {numberUpTo6}";
            string equationD = $"6 - {numberUpTo6}";
            string equationE = $"6 * 0 + {numberUpTo4}";
            string equationF = $"({numberUpTo5} * 2 + 2) / 2";
            return new string[] {equationA, equationB, equationC, equationD, equationE, equationF};
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
            Writer.WriteMessageOnNewLine();
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
