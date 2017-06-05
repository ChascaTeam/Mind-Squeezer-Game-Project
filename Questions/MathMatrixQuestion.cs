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

            //Matrix initialization
            int rows = 6;
            int cols = 6;
            int[][] matrix = new int[rows][];

            for (int row = 0; row < rows; row++)
            {
                matrix[row] = new int[cols];
            }

            //Choosing an equation
            
            int equationIndex = RandomGenerator.GetRandomNumber(equationsArr.Length);

            string equation = equationsArr[equationIndex];

            //Print the equation
            Console.WriteLine($"{equation} = X");

            //Equations calculator
            int result = CalculateEquation(equation);
        }

        private static int CalculateEquation(string equation)
        {
            DataTable dt = new DataTable();
            var v = (int)dt.Compute(equation, "");
            return v;
        }

        public override bool IsCorrectAnswer(string answer)
        {
            return this.Answer.ToLower().Equals(answer.ToLower()) && answer.Length != 0;
        }
    }
}
