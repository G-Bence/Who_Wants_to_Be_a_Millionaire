using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Who_Wants_to_Be_a_Millionaire
{
    internal class Question
    {
        private int questionLevel;
        private string questionText;
        private List<string> options = new List<string>();
        private string correctAnswer;

        public Question(string line)
        {
            //It would better for check if the first element could be converted to int

            if(line == null || line.Length == 0)
            {
                throw new ArgumentException("Line cannot be empty");
            }
            else
            {
                string[] parts = line.Split(';');

                if (parts.Length <= 7)
                {
                    this.questionLevel = 0;
                    this.questionText = parts[0];
                    for (int i = 1; i < 5; i++)
                    {
                        if (parts[i] != null && parts[i].Length != 0)
                        {
                            this.options.Add(parts[i]);
                        }
                    }
                    this.correctAnswer = parts[5];
                }
                else
                {
                    this.questionLevel = int.Parse(parts[0]);
                    this.questionText = parts[1];
                    for (int i = 2; i < 6; i++)
                    {
                        if (parts[i] != null && parts[i].Length != 0)
                        {
                            this.options.Add(parts[i]);
                        }

                    }
                    this.correctAnswer = parts[6];
                }
                /*
                Console.WriteLine(questionLevel);
                Console.WriteLine(questionText);
                for (int i = 0; i < options.Count; i++)
                {
                    Console.WriteLine(options[i]);
                }
                Console.WriteLine(correctAnswer);
                */
            }
        }

        
        public int QuestionLevel { get => questionLevel; set => questionLevel = value; }
        public string QuestionText { get => questionText; set => questionText = value; }
        public List<string> Options { get => options; set => options = value; }
        public string CorrectAnswer { get => correctAnswer; set => correctAnswer = value; }


        
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
