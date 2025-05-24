using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Who_Wants_to_Be_a_Millionaire
{
    internal class Help
    {
        private Random random = new Random();
        private int usedHelp = 0;
        private Dictionary<int, char> keyValuePairs = new Dictionary<int, char>()
        {
            { 0, 'A' },
            { 1, 'B' },
            { 2, 'C' },
            { 3, 'D' }
        };

        private Dictionary<char, int> valueKeyPairs = new Dictionary<char, int>()
        {
            { 'A', 0 },
            { 'B', 1 },
            { 'C', 2 },
            { 'D', 3 }
        };

        private Dictionary<string, bool> help_logic = new Dictionary<string, bool>()
        {
            { "Half_The_Options", true },
            { "Ask_the_audience", true },
            { "Phone_a_friend", true },
            { "Ask_the_host", true }
        };

        public Help()
        {

        }

        public int UsedHelp { get => usedHelp; set => usedHelp = value; }

        public void HelpMenu(Question question)
        {
            if (usedHelp < 3)
            {
                Console.WriteLine("\nPlease choose a help option below:\n");


                Console.WriteLine("------------------------------");

                Console.Write("|");
                if (!help_logic["Half_The_Options"])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" 1. Half the options        ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(" 1. Half the options        ");
                }
                Console.WriteLine("|");

                Console.WriteLine("------------------------------");

                Console.Write("|");
                if (!help_logic["Ask_the_audience"])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" 2. Ask the audience        ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(" 2. Ask the audience        ");
                }
                Console.WriteLine("|");

                Console.WriteLine("------------------------------");

                Console.Write("|");
                if (!help_logic["Phone_a_friend"])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" 3. Phone a friend          ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(" 3. Phone a friend          ");
                }
                Console.WriteLine("|");

                Console.WriteLine("------------------------------");

                Console.Write("|");
                if (!help_logic["Ask_the_host"])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(" 4. Ask the host            ");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write(" 4. Ask the host            ");
                }
                Console.WriteLine("|");

                Console.WriteLine("------------------------------");


                Console.WriteLine("\nWrite here the number of the choosen option:");
                bool isValidInput;
                string input;

                do
                {
                    input = Console.ReadLine();
                    isValidInput = true;
                    switch (input)
                    {
                        case "1":
                            if (help_logic["Half_The_Options"])
                            {
                                Half_The_Options(question);
                                UsedHelp++;
                                help_logic["Half_The_Options"] = false;
                            }
                            else
                            {
                                Console.WriteLine("You have already used this help option.");
                                isValidInput = false;
                            }

                            break;

                        case "2":
                            if (help_logic["Ask_the_audience"])
                            {
                                Ask_the_audience(question);
                                UsedHelp++;
                                help_logic["Ask_the_audience"] = false;
                            }
                            else
                            {
                                Console.WriteLine("You have already used this help option.");
                                isValidInput = false;
                            }

                            break;

                        case "3":
                            if (help_logic["Phone_a_friend"])
                            {
                                Phone_a_friend(question);
                                UsedHelp++;
                                help_logic["Phone_a_friend"] = false;
                            }
                            else
                            {
                                Console.WriteLine("You have already used this help option.");
                                isValidInput = false;
                            }

                            break;

                        case "4":
                            if(help_logic["Ask_the_host"])
                            {
                                Ask_the_host(question);
                                UsedHelp++;
                                help_logic["Ask_the_host"] = false;
                            }
                            else
                            {
                                Console.WriteLine("You have already used this help option.");
                                isValidInput = false;
                            }

                            break;

                        default:
                            Console.WriteLine("Invalid option. Please try again.");
                            isValidInput = false;
                            break;
                    }
                }while (!isValidInput);

            }
        }

        public void Half_The_Options(Question question)
        {
            List<string> originalOptions = new List<string>(question.Options);
            List<string> options = new List<string>(question.Options);

            int correctIndex = valueKeyPairs[Convert.ToChar(question.CorrectAnswer)];

            List<int> wrongIndices = Enumerable.Range(0, options.Count).Where(i => i != correctIndex).ToList();

            int wrongToKeepIndex = wrongIndices[random.Next(wrongIndices.Count)];

            for (int i = 0; i < options.Count; i++)
            {
                if (i != correctIndex && i != wrongToKeepIndex)
                {
                    options[i] = "";
                }
            }

            Console.WriteLine("");

            question.Options.Clear();
            question.Options.AddRange(options);

            question.DisplayQuestion();

            question.Options.Clear();
            question.Options.AddRange(originalOptions);

        }



        public void Ask_the_audience(Question question)
        {
            List<string> options = new List<string>(question.Options);
            int correctIndex = valueKeyPairs[Convert.ToChar(question.CorrectAnswer)];
            int percentage = 100;

            Dictionary<int, int> audienceVotes = new Dictionary<int, int>();

            audienceVotes[correctIndex] = random.Next(40, 60);
            percentage -= audienceVotes[correctIndex];

            for (int i = 0; i < options.Count; i++)
            {
                if (i != correctIndex)
                {
                    audienceVotes[i] = random.Next(0, (percentage + 1));
                    percentage -= audienceVotes[i];
                }
            }

            int index = 0;
            foreach (var item in audienceVotes)
            {
                if (item.Value == 0)
                {
                    audienceVotes[item.Key] = percentage;
                }
                index++;
            }

            Console.WriteLine("");

            for (int i = 0; i < options.Count; i++)
            {
                string border = new string('-', 30);
                int space = (border.Length - (8 + Convert.ToString(audienceVotes[i]).Length));
                Console.WriteLine(border);
                Console.Write("|");
                Console.BackgroundColor = ConsoleColor.Cyan;
                Console.ForegroundColor = ConsoleColor.Black;
                Console.Write($" {keyValuePairs[i]}: {options[i].PadRight(space, ' ')}{audienceVotes[i]}% ");
                Console.ResetColor();
                Console.Write("|\n");
                Console.WriteLine(border);
            }
        }



        public void Phone_a_friend(Question question)
        {
            List<string> options = new List<string>(question.Options);
            int correctIndex = valueKeyPairs[Convert.ToChar(question.CorrectAnswer)];
            int percentage = 100;

            Dictionary<int, int> friendChance = new Dictionary<int, int>();


            friendChance[correctIndex] = random.Next(30, 50);
            percentage -= friendChance[correctIndex];

            for (int i = 0; i < options.Count; i++)
            {
                if (i != correctIndex)
                {
                    friendChance[i] = random.Next(0, (percentage + 1));
                    percentage -= friendChance[i];
                }
            }

            /*
            FOR EXTRA UNCERTAINITY ;-):
            int index = 0;
            foreach (var item in friendChance)
            {
                if (index == friendChance.Count-1)
                {
                    friendChance[item.Key] += percentage;
                }
                index++;
            }*/

            int maxValue = 0;

            for (int i = 0; i < friendChance.Count; i++)
            {
                if (friendChance[i] > maxValue)
                {
                    maxValue = friendChance[i];

                }
            }

            int winnerIndex = friendChance.ToLookup(x => x.Value, x => x.Key)[maxValue].FirstOrDefault();
            Console.WriteLine($"\nUhmm... I think the answer is the '{keyValuePairs[winnerIndex]}' {options[winnerIndex]}.\nI'm {maxValue}% shure. Now be clever! Hello!");
        }



        public void Ask_the_host(Question question)
        {
            List<string> options = new List<string>(question.Options);
            int correctIndex = valueKeyPairs[Convert.ToChar(question.CorrectAnswer)];
            int percentage = 100;

            Dictionary<int, int> hostChance = new Dictionary<int, int>();


            hostChance[correctIndex] = random.Next(30, 65);
            percentage -= hostChance[correctIndex];

            for (int i = 0; i < options.Count; i++)
            {
                if (i != correctIndex)
                {
                    hostChance[i] = random.Next(0, (percentage + 1));
                    percentage -= hostChance[i];
                }
            }

            int index = 0;
            foreach (var item in hostChance)
            {
                if (index == hostChance.Count-1)
                {
                    hostChance[item.Key] += percentage;
                }
                index++;
            }

            int maxValue = 0;

            for (int i = 0; i < hostChance.Count; i++)
            {
                if (hostChance[i] > maxValue)
                {
                    maxValue = hostChance[i];

                }
            }

            int winnerIndex = hostChance.ToLookup(x => x.Value, x => x.Key)[maxValue].FirstOrDefault();
            Console.WriteLine($"\nWell...  I would choose the answer '{keyValuePairs[winnerIndex]}', {options[winnerIndex]}.\nIn my opinion, this is the most certain option");
        }
    }
}