using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Who_Wants_to_Be_a_Millionaire
{
    internal class Program
    {
        static StreamReader streamReader;
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Bence\\Desktop\\Iskola\\Programozás alap\\2024-25-ös tanév (C#)\\Who_Wants_to_Be_a_Millionaire\\Questions.txt";

            if (File.Exists(filePath))
            {
                // Read all the content in one string
                // and display the string
                streamReader = new StreamReader(filePath);
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    Question question = new Question();
                    question.StringToClass(line);
                }

                streamReader.Close();
            }


            Console.ReadLine();
        }


        /*
        static void PrintOption(string option, ConsoleColor color)
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

                if (i < (sequence-1))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    Console.Write(new string(' ', Console.BufferWidth));
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                }

            }
        }*/
    }
}
