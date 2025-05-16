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
        private List<Question> QuestionList = new List<Question>();

        public All_The_Questions(Question newQuestion)
        {
            QuestionList.Add(newQuestion);
        }
    }
}
