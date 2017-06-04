using System;
using System.Collections.Generic;
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

        public override void GenerateQuestion()
        {
            throw new NotImplementedException();
        }

        public override bool IsCorrectAnswer(string answer)
        {
            return this.Answer.ToLower() == answer.ToLower() && answer.Length != 0;
        }
    }
}
