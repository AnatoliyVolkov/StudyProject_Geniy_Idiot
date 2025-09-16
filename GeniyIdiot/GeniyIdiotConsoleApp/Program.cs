using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using System.Threading;
using System.Timers;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GeniyIdiotApp;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Добрый день, вы сейчас будете проходить тест на определение вашей гениальности.\nПожалуйста введите свое имя.");
        var userName = GetValidUserName();
        Console.WriteLine($"Добро пожаловать {userName}! Мы приступаем.");

        var restart = true;
        while (restart)
        {
            var score = RunTest(userName);
            ShowResults(userName, score);
            Console.WriteLine($"{userName} хотите пройти тест еще раз?");
            restart = DiagnosticTestResources.GetUserConfirm(userName);
        }
        Console.WriteLine($"\nСпасибо {userName}, что прошли наш тест. Всего хорошего.");
    }

    static string GetValidUserName()
    {
        while (true)
        {
            try
            {
                var name = Console.ReadLine();
                return DiagnosticTestResources.CheckUsernameEntry(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Повторите попытку ввода еще раз.");
            }
        }
    }

    static int RunTest(string userName)
    {
        var countRightAnswers = 0;
        var questionOrder = DiagnosticTestResources.ShuffleTestQuestions();
        for (var i = 0 ; i < DiagnosticTestResources.Questions.Count ; i++)
        {
            var questionIndex = questionOrder[i];

            Console.WriteLine($"\nВопрос номер: {i + 1}");
            Console.WriteLine(DiagnosticTestResources.Questions[questionIndex]);
            countRightAnswers += CheckAnswerUserQuestion(userName, questionIndex);
        }
        return countRightAnswers;
    }

    static int CheckAnswerUserQuestion(string userName, int questionIndex)
    {
        while (true)
        {
            try
            {
                var userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    throw new Exception($"Вы дали ответ пустой строкой.\n Вам нужно ввести число не длинее 6 знаков.");
                }
                if (short.TryParse(userInput, out var answer))
                {
                    return answer == DiagnosticTestResources.Answers[questionIndex] ? 1 : 0;
                }
                if (long.TryParse(userInput, out var _))
                {
                    throw new Exception($"{userName}, вы ввели слишком большое число, Вам нужно ввести число не длинее 6 знаков.");
                }
                else
                {
                    throw new Exception($"{userName}, вы ввели букву, Вам нужно ввести число не длинее 6 знаков.");
                }
                }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }

    static void ShowResults(string userName, int answer)
    {
        Console.WriteLine($"\n{userName}, вы ответили верно на {answer} вопросов.");
        Console.WriteLine($"Ваш результат: {DiagnosticTestResources.GetDiagnose(answer)}");
    }
}




