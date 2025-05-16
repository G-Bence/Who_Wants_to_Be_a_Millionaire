using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Who_Wants_to_Be_a_Millionaire
{
    internal class Question
    {
        private int questionLevel;
        private string questionText;
        private List<string> options;
        private string correctAnswer;

        public Question(string line)
        {
            string[] parts = line.Split(';');

            //It would better for check if the first element could be converted to int

            if (parts.Length <= 7)
            {
                questionLevel = 0;
                questionText = parts[0];
                for (int i = 1; i <= 4; i++)
                {
                    options.Add(parts[i]);
                }
                correctAnswer = parts[5];
            }
            else
            {
                questionLevel = int.Parse(parts[0]);
                questionText = parts[1];
                for (int i = 2; i <= 5; i++)
                {
                    options.Add(parts[i]);
                }
                correctAnswer = parts[6];
            }
            //string questionText, List<string> options, string correctAnswer
            /* this.questionText = questionText;
             this.options = options;
             this.correctAnswer = correctAnswer;*/
        }

        public int QuestionLevel { get; set; }
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


        static void WinnerOption(string option)
        {
            int sequence = 7;

            ConsoleColor color;
            for (int i = 0; i < sequence; i++)
            {
                if (i % 2 == 0)
                {
                    color = ConsoleColor.Green;
                }
                else
                {
                    color = ConsoleColor.Blue;
                }

                PrintOption(option, color);

                Thread.Sleep(300);

                if (i < (sequence - 1))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    Console.Write(new string(' ', Console.BufferWidth));
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                }

            }
        }

        //WinnerOption (?)
        //Make the "All the Questions" class to the innheritance of the Question class (?)

        public void DisplayQuestion()
        {
            Console.WriteLine(questionText);
            for (int i = 0; i < options.Count; i++)
            {
                   PrintOption(options[i], ConsoleColor.Blue);
            }
        }

        public void StringToClass(string line)
        {
            string[] parts = line.Split(';');

            //It would better for check if the first element could be converted to int

            if (parts.Length <= 7)
            {
                questionLevel = 0;
                questionText = parts[0];
                for(int i = 1; i <=4; i++)
                {
                    options.Add(parts[i]);
                }
                correctAnswer = parts[5];
            }
            else
            {
                questionLevel = int.Parse(parts[0]);
                questionText = parts[1];
                for (int i = 2; i <= 5; i++)
                {
                    options.Add(parts[i]);
                }
                correctAnswer = parts[6];
            }
        }
    }
}
