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
        var userName = GetUserName();
        Console.WriteLine($"Добро пожаловать {userName}! Приступаем к тесту.");

        var restart = true;
        while (restart)
        {
            var score = RunTest(userName);
            ShowResults(userName, score);
            Console.WriteLine($"\n{userName} хотите пройти тест еще раз?");
            restart = DiagnosticTestResources.GetUserConfirm(Console.ReadLine(), userName);
        }
    }

    static string GetUserName()
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
            countRightAnswers += GetCorrectAnswer(userName, questionIndex);
        }
        return countRightAnswers;
    }

    static int GetCorrectAnswer(string userName, int questionIndex)
    {
        while (true)
        {
            var userInput = Console.ReadLine();
            if (short.TryParse(userInput, out var answer))
            {
                return answer == DiagnosticTestResources.Answers[questionIndex] ? 1 : 0;
            }
            if (long.TryParse(userInput, out _))
            {
                Console.WriteLine($"{userName}, вы ввели число, превышающее допустимое значение. Вам нужно ввести число не длинее 6 знаков.\n Повторите ввод ответа.");
                continue;
            }
            else { Console.WriteLine($"{userName}, вы ввели букву или оставили поле пустым. Вам нужно ввести число не длинее 6 знаков.\n Повторите ввод ответа."); }
        }
    }

    static void ShowResults(string userName, int answer)
    {
        Console.WriteLine($"\n{userName}, вы ответили верно на {answer} вопросов.");
        Console.WriteLine($"Ваш результат: {DiagnosticTestResources.Diagnoses[answer]}");
    }
}




