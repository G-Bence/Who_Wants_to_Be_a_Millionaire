using System.Diagnostics;
using System.Drawing;

namespace Who_Wants_to_Be_a_Millionaire
{
    internal class Program
    {
        static void Main(string[] args)
        {
            PrintOption("Hello in Blue", ConsoleColor.Blue);
            PrintOption("Hello in Green", ConsoleColor.Green);
            PrintOption("Hello in Red", ConsoleColor.Red);

            WinnerOption("Winner in Blue");


            Console.ReadLine();
        }


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
            string border = new string('-', 30);
            int space = (border.Length - 3);
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
                Console.WriteLine(border);
                Console.Write("|");
                Console.BackgroundColor = color;
                Console.Write($" {option.PadRight(space, ' ')}");
                Console.ResetColor();
                Console.Write("|\n");
                Console.WriteLine(border);

                Thread.Sleep(300);

                if (i < (sequence-1))
                {
                    Console.SetCursorPosition(0, Console.CursorTop - 2);
                    Console.Write(new string(' ', Console.BufferWidth));
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                }

            }
        }
    }
}
