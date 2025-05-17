using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Who_Wants_to_Be_a_Millionaire
{
    internal class Program
    {
        static StreamReader streamReader;
        static All_The_Questions allQuestions;
        static Question question;
        //static List<Question>[] questionList = new List<Question>[11];
        static void Main(string[] args)
        {
            int index = 0;
            allQuestions = new All_The_Questions();
            string filePath = "C:\\Users\\Bence\\Desktop\\Iskola\\Programozás alap\\2024-25-ös tanév (C#)\\Who_Wants_to_Be_a_Millionaire\\kerdes.txt";

            if (File.Exists(filePath))
            {
                //FILE READING
                streamReader = new StreamReader(filePath);
                string line;

                while ((line = streamReader.ReadLine()) != null)
                {
                    question = new Question(line);

                    Console.WriteLine(question.QuestionLevel);

                    if (question != null)
                    {
                        allQuestions.AddQuestion(question);
                        index++;
                    }
                }

                streamReader.Close();
                Console.WriteLine(allQuestions.QuestionsByLevels[0]);


                //Array Check
                for (int i = 0; i < 11; i++)
                {
                    Console.WriteLine($"Index: {i}");
                    if (allQuestions.QuestionsByLevels[i] == null)
                    {
                        Console.WriteLine("null");
                    }
                    else if (allQuestions.QuestionsByLevels[i].Count == 0)
                    {
                        Console.WriteLine("empty list");
                    }
                    else
                    {
                        Console.WriteLine(allQuestions.QuestionsByLevels[i]);
                        Console.WriteLine(allQuestions.QuestionsByLevels[i].Count);
                        /*
                        for (int j = 0; j < allQuestions.QuestionsByLevels[i].Count; j++)
                        {
                            Console.WriteLine(allQuestions.QuestionsByLevels[i][j].QuestionText);
                            Console.WriteLine(allQuestions.QuestionsByLevels[i][j].CorrectAnswer);
                            Console.WriteLine(allQuestions.QuestionsByLevels[i][j].Options[0]);
                            Console.WriteLine(allQuestions.QuestionsByLevels[i][j].Options[1]);
                            Console.WriteLine(allQuestions.QuestionsByLevels[i][j].Options[2]);
                            Console.WriteLine(allQuestions.QuestionsByLevels[i][j].Options[3]);
                        }*/
                    }
                }
            }
            else
            {
                Console.WriteLine("File not found.");
            }

            Console.ReadLine();
        }
    }
}
