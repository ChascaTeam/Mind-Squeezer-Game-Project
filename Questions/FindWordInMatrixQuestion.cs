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
            throw new NotImplementedException();
        }

        public override bool IsCorrectAnswer(string answer)
        {
            return base.IsCorrectAnswer(answer);
        }
    }
}
