using System.Collections.Generic;
using System.Linq;
using MindSqueezer.Utilities;

namespace MindSqueezer
{
    public abstract class Question
    {
        private static HashSet<string> questions = new HashSet<string>();
        public string QuestionText { get; protected set; }

        public string Answer { get; protected set; }

        public virtual bool IsCorrectAnswer(string answer)
        {
            if (this.Answer.Equals(answer))
            {
                return true;
            }

            return false;
        }

        public abstract void GenerateQuestion();

        public static void RegisterQuestions()
        {
            var types = typeof(Question)
                .Assembly.GetTypes()
                .Where(t => t.IsSubclassOf(typeof(Question)) && !t.IsAbstract)
                .Select(t => t.ToString());

            foreach (var type in types)
            {
                questions.Add(type);
            }
        }
        public static string GetRandomQuestionType()
        {
            return questions.ToArray()[RandomGenerator.GetRandomNumber(questions.Count)];
        }
    }
}
