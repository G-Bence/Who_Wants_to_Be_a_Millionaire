using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Who_Wants_to_Be_a_Millionaire
{
    internal class Question
    {
        private string questionText;
        private List<string> options;
        private List<string> correctAnswer;

        public Question(string questionText, List<string> options, List<string> correctAnswer)
        {
            this.questionText = questionText;
            this.options = options;
            this.correctAnswer = correctAnswer;
        }

        public string QuestionText { get; set; }
        public List<string> Options { get; set; }
        public List<string> CorrectAnswer { get; set; }


        private static void PrintOption(string option, ConsoleColor color)
        {
            string border = new string('-', 30);
            int space = (border.Length - 3);
            Console.WriteLine(border);
            Console.Write("|");
            Console.BackgroundColor = color;
            Console.Write($" {option.PadRight(space, ' ')}");
            Console.ResetColor();
            Console.Write("|\n");
            Console.WriteLine(border);
        }

        public void DisplayQuestion()
        {
            Console.WriteLine(questionText);
            for (int i = 0; i < options.Count; i++)
            {
                   PrintOption(options[i], ConsoleColor.Blue);
            }
        }
    }
}
