using System;
using System.Collections.Generic;
using System.Data;
using MindSqueezer.Utilities;

namespace MindSqueezer.Questions
{
    public class MathMatrixQuestion : Question
    {
        private const int Rows = 6;
        private const int Cols = 6;
        private readonly int[][] _matrix = new int[Rows][];
        private readonly List<string> _correctAnswers = new List<string>();
        public MathMatrixQuestion(string message, int seconds)
        {
            this.QuestionText = message;
            this.Seconds = seconds;
        }

        public MathMatrixQuestion()
            : this(Messages.MathMatrixEquationCoordinates, 20)
        {
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
            int result = Calculator.CalculateEquation(equation);

            //Populating the matrix containing at least one occurrence of the result.
            PopulateMatrix(result);

            //Printing the matrix.
            PrintMatrix(_matrix);


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
            for (int rowIndex = 0; rowIndex < Rows; rowIndex++)
            {
                _matrix[rowIndex] = new int[Cols];
            }
        }

        private void PopulateMatrix(int result)
        {
            int row = RandomGenerator.GetRandomNumber(_matrix.Length);
            int col = RandomGenerator.GetRandomNumber(_matrix[0].Length);

            _matrix[row][col] = result;
            _correctAnswers.Add($"{(char)(row+65)} {col+1}");
            for (int rowIndex = 0; rowIndex < _matrix.Length; rowIndex++)
            {
                for (int colIndex = 0; colIndex < _matrix[0].Length; colIndex++)
                {
                    if (rowIndex != row && colIndex != col)
                    {
                        int numToAdd = RandomGenerator.GetRandomNumber(10);
                        _matrix[rowIndex][colIndex] = numToAdd;
                        if (numToAdd == result)
                        {
                            _correctAnswers.Add($"{(char)(rowIndex + 65)} {colIndex + 1}");
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

        

        public override bool IsCorrectAnswer(string answer)
        {
            return this._correctAnswers.Contains(answer) && answer.Length != 0;
        }

        public string[] GetAnswers()
        {
            return this._correctAnswers.ToArray();
        }

        private void PrintMatrix(int[][] matrix, bool showAnswer = false)
        {
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("- 1 2 3 4 5 6");

            for (int rowIndex = 0; rowIndex < matrix.Length; rowIndex++)
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write((char)(rowIndex + 65));
                for (int colIndex = 0; colIndex < matrix[0].Length; colIndex++)
                {
                    if (this._correctAnswers.Contains("" + (rowIndex + 'A') + " " + (colIndex + 1)))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    Console.Write(" " + matrix[rowIndex][colIndex]);
                }
                Console.WriteLine();
                Console.ResetColor();
            }
        }

        public override void PrintSolution()
        {
            Writer.WriteMessageOnNewLine(Messages.MathMatrixAdditionalInfo);
            Writer.WriteMessage($"| {string.Join(" | ", GetAnswers())} |");
        }
    }
}
