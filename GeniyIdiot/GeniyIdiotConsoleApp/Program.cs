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
        ChekFile();
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
        var SaveResult = $"{diagnostic} {answer}";
        Append.SaveData("test_results", SaveResult);
        Console.WriteLine($"\n{userName}, вы ответили верно на {answer} вопросов.");
        Console.WriteLine($"Ваш результат: {diagnostic}");
    }

    public static void ShowAllResult()
    {
        Console.WriteLine($"Хотите посмотреть все результаты тестирования? (да/нет)");
        if (DiagnosticTestResources.CheckUserAnswer().Trim().ToLower() == "да")
        {
            Append.ShowResults("test_results");
            Append.ShowResults("Question");
        }
    }

    public static void ChekFile()
    {
        var directoryPath = Directory.GetCurrentDirectory();
        var TestPath = Path.Combine(directoryPath, "test_results");
        var QuestionPath = Path.Combine(directoryPath, "Question");
        Directory.CreateDirectory(directoryPath);
        var TestExists = Append.CheckFileExists(TestPath);
        var QuestionExists = Append.CheckFileExists(QuestionPath);
        if (QuestionExists) { return; }
        else
        {
            foreach (var question in Questions.GetQuestions)
            {
                var q = $"{question.Question}|{question.Answer}";
                Append.SaveData("Question", q);
            }
        }
    }
}
