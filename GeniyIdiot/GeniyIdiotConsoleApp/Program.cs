using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GeniyIdiotApp;

internal partial class Program
{
    static void Main(string[] args)
    {
        var userNameInfo = User.UserFIO();
        Console.WriteLine($"Добро пожаловать {userNameInfo.userName}! Мы приступаем.");
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

    static int RunTest(string userName)
    {
        var countRightAnswers = 0;
        var questionOrder = DiagnosticTestResources.ShuffleTestQuestions();
        for (var i = 0 ; i < Questions.GetQuestions.Count ; i++)
        {
            var questionIndex = questionOrder[i];

            Console.WriteLine($"\nВопрос номер: {i + 1}");
            Console.WriteLine(Questions.GetQuestions[questionIndex].Question);
            countRightAnswers += Questions.CheckAnswerUserQuestion(userName, questionIndex);
        }
        return countRightAnswers;
    }

    static void ShowResults(string userName, int answer)
    {
        var diagnostic = DiagnosticTestResources.GetDiagnose(answer);
        FileProvider.SaveResults(answer, diagnostic);
        Console.WriteLine($"\n{userName}, вы ответили верно на {answer} вопросов.");
        Console.WriteLine($"Ваш результат: {diagnostic}");
    }

    public static void ShowAllResult()
    {
        Console.WriteLine($"Хотите посмотреть все результаты тестирования? (да/нет)");
        if (DiagnosticTestResources.CheckUserAnswer().Trim().ToLower() == "да")
        {
            FileProvider.ShowResults();
        }
    }
}
