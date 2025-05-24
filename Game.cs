using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Who_Wants_to_Be_a_Millionaire
{

    internal class Game
    {

        private StreamReader streamReader;
        private Question question;
        private Help help = new Help();
        private All_The_Questions allQuestions = new All_The_Questions();
        private Dictionary<int, int> keyValuePairs = new Dictionary<int, int>()
        {
            { 1, 10000 },
            { 2, 20000 },
            { 3, 50000 },
            { 4, 100000 },
            { 5, 250000 },
            { 6, 500000 },
            { 7, 750000 },
            { 8, 1000000 },
            { 9, 1500000 },
            { 10, 10000000 },
            { 11, 5000000 },
            { 12, 10000000 },
            { 13, 15000000 },
            { 14, 25000000 },
            { 15, 50000000 },
        };

        private Random random = new Random();


        private string playerName;
        private int playerLevel;
        private All_The_Questions allTheQuestions;

        private string questionFilePath = "C:\\Users\\Bence\\Desktop\\Iskola\\Programozás alap\\2024-25-ös tanév (C#)\\Who_Wants_to_Be_a_Millionaire\\kerdes.txt";
        private string rowQuestionFilePath = "C:\\Users\\Bence\\Desktop\\Iskola\\Programozás alap\\2024-25-ös tanév (C#)\\Who_Wants_to_Be_a_Millionaire\\sorkerdes.txt";

        private bool gameLogic = true;

        public Game() {
            fileInit();

            Console.WriteLine("Please enter your name:");

            playerName = Console.ReadLine();
            playerLevel = 0;
            Console.WriteLine(new string('-', 30));
            Console.WriteLine("\n");

            GenerateRowQuestion();

            if(gameLogic == true)
            {
                do
                {
                    question = allQuestions.QuestionsByLevels[playerLevel][random.Next(0, allQuestions.QuestionsByLevels[playerLevel].Count - 1)];
                    question.DisplayQuestion();

                    if(help.UsedHelp < 3)
                    {
                        Console.WriteLine($"\n[ You have {3-help.UsedHelp} help available left ]\n[ If you need help type: \"HELP\"  ]\n");
                    }
                    else
                    {
                        Console.WriteLine("\n[ You have no help available left ]\n");
                    }

                    Console.WriteLine("\nPlease enter the letter of the correct answer:");

                    string answer = Console.ReadLine();

                    if (answer.ToLower().Contains("help") && help.UsedHelp < 3)
                    {
                        help.HelpMenu(question);

                        Console.WriteLine("\nPlease enter the letter of the correct answer:");
                        answer = Console.ReadLine();
                    }

                    if (answer.ToUpper() == question.CorrectAnswer)
                    {
                        playerLevel++;
                        Console.WriteLine("\n\nCorrect answer!");

                        Console.Write("\n\nThe current prize is");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($" {keyValuePairs[playerLevel-1]} HUF");
                        Console.ResetColor();
                        Console.Write("!");
                        Console.WriteLine($"\nYou are now on level {playerLevel}!");

                        Console.WriteLine(new string('-', 30));
                        Console.WriteLine("\n");
                    }
                    else
                    {
                        gameLogic = false;
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("\nWrong answer!");
                        Console.WriteLine("Unfortunately the game is over for you");
                        Console.ResetColor();

                        if (playerLevel < 5)
                        {
                            Console.WriteLine($"You won nothing =(");
                        }
                        else if (playerLevel < 10)
                        {
                            Console.WriteLine($"But you won {keyValuePairs[5]} HUF");
                        }
                        else if (playerLevel < 15)
                        {
                            Console.WriteLine($"However you won {keyValuePairs[10]} HUF and you can try again next time! =)"); //TODO: add a restart option
                        }
                        /*
                        else
                        {
                            Console.WriteLine($"You won {keyValuePairs[15]} HUF and you are the winner of this game! Congratulations! =)");
                        }*/
                    }
                }while (gameLogic == true && playerLevel < 15);

                if(playerLevel == 15)
                {
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"\n\nCongratulations, {playerName}! You are the winner of this game! =)");
                    Console.ResetColor();
                    Console.Write("You won ");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write($"{keyValuePairs[15]} HUF");
                    Console.ResetColor();
                    Console.Write("!\n");
                }
            }

        }


        private void fileInit()
        {

            if (File.Exists(questionFilePath))
            {
                //FILE READING
                streamReader = new StreamReader(questionFilePath);
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    question = new Question(line);


                    if (question != null)
                    {
                        allQuestions.AddQuestion(question);
                    }
                }

                streamReader.Close();
            }
            else
            {
                Console.WriteLine("File not found.");
            }


            if (File.Exists(rowQuestionFilePath))
            {
                //FILE READING
                streamReader = new StreamReader(rowQuestionFilePath);
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    question = new Question(line);


                    if (question != null)
                    {
                        allQuestions.AddQuestion(question);
                    }
                }

                streamReader.Close();

            }
            else
            {
                Console.WriteLine("File not found.");
            }
        }


        private void GenerateRowQuestion()
        {
            Question rowQuestion = allQuestions.QuestionsByLevels[0][random.Next(0, allQuestions.QuestionsByLevels[0].Count - 1)];


            rowQuestion.DisplayQuestion();

            Console.WriteLine("\nPlease enter the letters of options in the correctorder:");
            string answer = Console.ReadLine();

            if(answer.ToUpper() == rowQuestion.CorrectAnswer)
            {
                playerLevel++;
                Console.WriteLine("\nCorrect answer!");
                Console.WriteLine($"You are now in the real game.\n");
            }
            else
            {
                gameLogic = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWrong answer!");
                Console.ResetColor();
            }
        }
    }
}
