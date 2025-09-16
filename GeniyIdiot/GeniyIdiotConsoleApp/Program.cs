using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GeniyIdiotApp;

internal class Program
{
    private static SaveUserTest CurrentUser;

    static void Main(string[] args)
    {
        var userNameInfo = UserFIO();
        Console.WriteLine($"Добро пожаловать {userNameInfo.userName}! Мы приступаем.");

        CurrentUser = new SaveUserTest(userNameInfo.userLastName, userNameInfo.userName, userNameInfo.userPatronymic);
        var restart = true;

        while (restart)
        {
            var score = RunTest(userNameInfo.userName);
            ShowResults(userNameInfo.userName, score);
            Console.WriteLine($"\n{userNameInfo.userName}, хотите пройти тест еще раз? (да/нет)");
            restart = DiagnosticTestResources.GetUserConfirm(userNameInfo.userName);
        }

        ShowAllResult();
        Console.WriteLine($"\nСпасибо {userNameInfo.userName}, что прошли наш тест. Всего хорошего.");
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
        var diagnostic = DiagnosticTestResources.GetDiagnose(answer);
        CurrentUser.SaveTestResults(answer, diagnostic);
        Console.WriteLine($"\n{userName}, вы ответили верно на {answer} вопросов.");
        Console.WriteLine($"Ваш результат: {diagnostic}");
    }

    public static (string userLastName, string userName, string userPatronymic) UserFIO()
    {
        Console.WriteLine("Добрый день, вы сейчас будете проходить тест на определение вашей гениальности.\n");
        Console.WriteLine("Пожалуйста введите свою фамилию.");
        var lastName = GetValidUserName();
        Console.WriteLine("Пожалуйста введите свое имя.");
        var name = GetValidUserName();
        Console.WriteLine("Пожалуйста введите свое отчество.");
        var patronymicName = GetValidUserName();
        return (lastName, name, patronymicName);
    }

    public static void ShowAllResult()
    {
        Console.WriteLine($"Хотите посмотреть все результаты тестирования? (да/нет)");
        if (DiagnosticTestResources.CheckUserAnswer().Trim().ToLower() == "да")
        {
            SaveUserTest.ShowAllTestResults();
        }
    }
}
