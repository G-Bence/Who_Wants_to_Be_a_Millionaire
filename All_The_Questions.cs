using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Who_Wants_to_Be_a_Millionaire
{
    internal class All_The_Questions
    {
        private List<Question>[] questionsByLevels = new List<Question>[16];

        public All_The_Questions()
        {
            for (int i = 0; i < questionsByLevels.Length; i++)
            {
                questionsByLevels[i] = new List<Question>();
            }
        }

        public List<Question>[] QuestionsByLevels
        {
            get { return questionsByLevels; }
        }

        public void AddQuestion(Question question)
        {
            if (question == null)
            {
                throw new ArgumentException("Line cannot be empty");
            }
            else
            {
                int index = question.QuestionLevel;

                if (index < 0 || index >= questionsByLevels.Length)
                {
                    throw new ArgumentOutOfRangeException($"Invalid question level: {index}");
                }
                else
                {
                    questionsByLevels[index].Add(question);
                }
            }

        }
    }
}
