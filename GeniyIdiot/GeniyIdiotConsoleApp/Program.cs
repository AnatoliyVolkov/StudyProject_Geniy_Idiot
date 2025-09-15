using System;

namespace GeniyIdiotConsoleApp
{
    internal class Program
    {



        static void Main(string[] args)
        {


            do
            {
                string userName = GetName();

                int countQuestions = 5;

                string[] questions = GetQuestions(countQuestions);

                int[] answers = GetAnswers(countQuestions);

                int countRightAnswers = 0;

                MixQuestions(questions, answers, countQuestions);


                for (int i = 0; i < countQuestions; i++)
                {
                    Console.WriteLine("Вопрос №" + (i + 1));

                    Console.WriteLine(questions[i]);

                    int userAnswer;
                    string userAnswerStr = Console.ReadLine();
                    if (int.TryParse(userAnswerStr, out userAnswer))
                    {
                        int rightAnswer = answers[i];

                        if (userAnswer == rightAnswer)
                        {
                            countRightAnswers++;
                        }
                    }
                    else
                    {
                        i--;
                        Console.WriteLine("Неверный формат. Ответ должен быть числовым");
                    }

                }

                Console.WriteLine("Количество правильных ответов: " + countRightAnswers);

                string diagnoses = GetDiagnoses(countQuestions, countRightAnswers);

                Console.WriteLine(userName + " Ваш диагноз: " + diagnoses);

                Console.WriteLine("Хотите повторить тест? Для повторения теста введите \"Да\", для выхода нажмите любую клавишу и Enter ");


            }
            while (Console.ReadLine().ToLower() == "да");
        }

        static string[] GetQuestions(int countQuestions)
        {
            string[] questions = new string[countQuestions];
            questions[0] = "Сколько будет два плюс два умноженное на два?";
            questions[1] = "Бревно нужно распилить на 10 частей, сколько надо сделать распилов?";
            questions[2] = "На двух руках 10 пальцев. Сколько пальцев на 5 руках?";
            questions[3] = "Укол делают каждые пол часа, сколько нужно минут для трех уколов?";
            questions[4] = "Пять свечей горело, две потухли. Сколько свечей осталось?";
            return questions;
        }
        static int[] GetAnswers(int countQuestions)
        {
            int[] answers = new int[countQuestions];
            answers[0] = 6;
            answers[1] = 9;
            answers[2] = 25;
            answers[3] = 60;
            answers[4] = 2;
            return answers;
        }
        static string GetDiagnoses(int countQuestions, int countRightAnswers)
        {
            string[] diagnoses = new string[6];
            diagnoses[0] = "Идиот";
            diagnoses[1] = "Кретин";
            diagnoses[2] = "Дурак";
            diagnoses[3] = "Нормальный";
            diagnoses[4] = "Талант";
            diagnoses[5] = "Гений";

            int resultIndex = 0;
            double index = (double)countRightAnswers / (double)countQuestions;

            resultIndex = index switch
            {
                1 => 5,
                0.8 => 4,
                0.6 => 3,
                0.4 => 2,
                0.2 => 1,

            };

            return diagnoses[resultIndex];
        }

        static string GetName()
        {
            Console.WriteLine("Введите Ваше имя:");
            return Console.ReadLine();

        }

        static void MixQuestions(string[] questions, int[] answers, int countQuestions)

        {
            Random random = new Random();

            for (int i = 0; i < countQuestions; i++)
            {
                int j = random.Next(i + 1);

                string tempQuestion = questions[j];
                questions[j] = questions[i];
                questions[i] = tempQuestion;

                int tempAnswers = answers[j];
                answers[j] = answers[i];
                answers[i] = tempAnswers;
            }

        }
    }
}


