using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Who_Wants_to_Be_a_Millionaire
{
    internal class All_The_Questions
    {
        private List<Question>[] questionLevels = new List<Question>[11];
        //private List<Question> QuestionList = new List<Question>();
        //Make 2D list to store the questions catergorized by levels

        public All_The_Questions()
        {
            //QuestionLevels[QuestionLevels.Count()] = new List<Question>();
        }

        public List<Question>[] QuestionLevels { get; set; }

        public void AddQuestion(Question question)
        {
            int index = question.QuestionLevel;
            questionLevels[index].Add(question);
        }

    }
}
