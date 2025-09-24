using System;
using System.Collections;
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
        try
        {
            if (ValidationHelper.CheckLogin())
            {
                var userNameInfo = UserFIO();
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
            else
            {
                if (AdminWork.TryLoginAdmin())
                {
                    var dir = Directory.GetCurrentDirectory();
                    var questionPath = Path.Combine(dir, "Question");

                    AdminWork.AdminMenu(questionPath);
                }
                else
                {
                    Console.WriteLine("Не удалось войти в режим администратора. Завершение работы.");
                    return;
                }
            }
        }
        catch (Exception ex) { Console.WriteLine(ex.Message); }
    }

    public static (string userLastName, string userName, string userPatronymic) UserFIO()
    {
        Console.WriteLine("Добрый день, вы сейчас будете проходить тест на определение вашей гениальности.\n");
        Console.WriteLine("Пожалуйста введите свою фамилию.");
        var lastName = ValidationHelper.GetUserName();
        Console.WriteLine("Пожалуйста введите свое имя.");
        var name = ValidationHelper.GetUserName();
        Console.WriteLine("Пожалуйста введите свое отчество.");
        var patronymicName = ValidationHelper.GetUserName();
        User.SafeUserData(name, lastName, patronymicName);
        return (lastName, name, patronymicName);
    }

    static int RunTest(string userName)
    {
        var countRightAnswers = 0;
        var questionOrder = DiagnosticTestResources.ShuffleTestQuestions();
        for (var i = 0; i < QuestionsStorage.GetQuestions().Count; i++)
        {
            var questionIndex = questionOrder[i];

            Console.WriteLine($"\nВопрос номер: {i + 1}");
            Console.WriteLine(QuestionsStorage.GetQuestions()[questionIndex].Question);
            countRightAnswers += ValidationHelper.CheckAnswerUserQuestion(userName, questionIndex);
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

        FileProvider.Append(testPath, line);

        Console.WriteLine($"\n{userName}, вы ответили верно на {answer} вопросов.");
        Console.WriteLine($"Ваш результат: {diagnostic}");
    }

    public static void ShowAllResult()
    {
        Console.WriteLine($"Хотите посмотреть все результаты тестирования? (да/нет)");
        if (ValidationHelper.CheckUserAnswer().Trim().ToLower() == "да")
        {
            var dir = Directory.GetCurrentDirectory();
            FileProvider.Show(Path.Combine(dir, "test_results"));
        }
    }

    public static void ChekFile()
    {
        var directoryPath = Directory.GetCurrentDirectory();
        var testPath = Path.Combine(directoryPath, "test_results");
        var questionPath = Path.Combine(directoryPath, "Question");
        Directory.CreateDirectory(directoryPath);

        string testHeader = string.Format("|| {0,-35} || {1,-25} || {2,-15} ||", "ФИО", "Набранные баллы", "Диагноз");
        string questionHeader = string.Format("|| {0,-85} || {1,-15}", "Вопрос", "Ответ");

        FileProvider.Creater(testPath, testHeader);
        FileProvider.Creater(questionPath, questionHeader);
        QuestionsStorage.CreaterFirstQuestions(questionPath);
    }

}
