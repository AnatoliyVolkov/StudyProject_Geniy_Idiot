using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
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

            Console.WriteLine($"\nВопрос номер: {i  + 1}");
            Console.WriteLine(Questions.GetQuestions[questionIndex].Question);
            countRightAnswers += Questions.CheckAnswerUserQuestion(userName, questionIndex);
        }
        return countRightAnswers;
    }

    static void ShowResults(string userName, int answer)
    {
        var diagnostic = DiagnosticTestResources.GetDiagnose(answer);
        var testPath = Path.Combine(Directory.GetCurrentDirectory(), "test_results");

        string line = string.Format("|| {0,-35} || {1,-25} || {2,-15} ||",
            User.userFullName,
            answer.ToString(),
            diagnostic);

        FileProvider.AppendLine(testPath, line);

        Console.WriteLine($"\n{userName}, вы ответили верно на {answer} вопросов.");
        Console.WriteLine($"Ваш результат: {diagnostic}");
    }

    public static void ShowAllResult()
    {
        Console.WriteLine($"Хотите посмотреть все результаты тестирования? (да/нет)");
        if (DiagnosticTestResources.CheckUserAnswer().Trim().ToLower() == "да")
        {
            var dir = Directory.GetCurrentDirectory();
            FileProvider.ShowFile(Path.Combine(dir, "test_results"), "РЕЗУЛЬТАТЫ ТЕСТИРОВАНИЯ");
            FileProvider.ShowFile(Path.Combine(dir, "Question"), "ТАБЛИЦА ВОПРОС/ОТВЕТ");
        }
    }

    public static void ChekFile()
    {
        var directoryPath = Directory.GetCurrentDirectory();
        var TestPath = Path.Combine(directoryPath, "test_results");
        var QuestionPath = Path.Combine(directoryPath, "Question");
        Directory.CreateDirectory(directoryPath);

        string testHeader = string.Format("|| {0,-35} || {1,-25} || {2,-15} ||", "ФИО", "Набранные баллы", "Диагноз");
        string questionHeader = string.Format("|| {0,-85} || {1,-15}", "Вопрос", "Ответ");

        FileProvider.FileCreater(TestPath, testHeader);
        FileProvider.FileCreater(QuestionPath, questionHeader);

        var lines = FileProvider.ReadAllLines(QuestionPath);
        if (lines.Count <= 3) 
        {
            foreach (var question in Questions.GetQuestions)
            {
                string formatted = $"|| {question.Question,-85} || {question.Answer,-15}";
                FileProvider.AppendLine(QuestionPath, formatted);
            }
        }
    }
}
