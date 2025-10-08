using GeniyIdiotClassLibrary;
using System;

namespace GeniyIdiotConsoleApp;

public class AdminMenu
{
    private readonly string _questionPath;
    private readonly string _adminPath;

    public AdminMenu(string questionPath, string adminPath)
    {
        _questionPath = questionPath;
        _adminPath = adminPath;
    }

    public (bool success, string message) TryLogin()
    {
        return AdminService.TryLogin(GetAdminCredentials, _adminPath);
    }

    public void ShowAdminMenu(Action returnToMainMenu)
    {
        while (true)
        {
            Console.WriteLine(Messages.AdminMode);
            Console.WriteLine(Messages.AdminMenu);
            Console.Write(Messages.ChooseAction);
            var choice = Console.ReadLine();

            ProcessAdminChoice(choice, returnToMainMenu);

            Console.WriteLine(Messages.PressEnter);
            Console.ReadLine();
        }
    }

    private void ProcessAdminChoice(string choice, Action returnToMainMenu)
    {
        switch (choice?.Trim())
        {
            case "1":
                ShowQuestionsList();
                break;
            case "2":
                AddQuestion();
                break;
            case "3":
                TestService.PrintResultsAsTable(UserResultStorage.LoadFromFile(UserResultStorage.ResultsFilePath));
                break;
            case "4":
                RegisterAdmin();
                break;
            case "5":
                Environment.Exit(0);
                break;
            case "6":
                returnToMainMenu();
                break;
            default:
                Console.WriteLine(Messages.InvalidChoice);
                break;
        }
    }

    private (string login, string password) GetAdminCredentials()
    {
        Console.WriteLine(Messages.ContinueAsAdmin);
        Console.WriteLine(Messages.EnterLogin);
        string login = Console.ReadLine();
        Console.WriteLine(Messages.EnterPassword);
        string password = Console.ReadLine();
        return (login, password);
    }

    private void AddQuestion()
    {
        Console.WriteLine(Messages.EnterQuestion);
        string question = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(question))
        {
            Console.WriteLine(Messages.QuestionEmpty);
            return;
        }

        Console.WriteLine(Messages.EnterAnswer);
        string answerInput = Console.ReadLine();

        var result = AdminService.AddQuestion(
            () => (question, answerInput),
            _questionPath
        );

        Console.WriteLine(result.message);
    }

    private void ShowQuestionsList()
    {
        try
        {
            var questions = QuestionsStorage.GetQuestions(_questionPath);

            if (questions.Count == 0)
            {
                Console.WriteLine("Нет доступных вопросов.");
                return;
            }

            Console.WriteLine("СПИСОК ВОПРОСОВ:");
            Console.WriteLine("==================");

            for (int i = 0 ; i < questions.Count ; i++)
            {
                Console.WriteLine($"{i + 1}. {questions[i]._Question} (Ответ: {questions[i].Answer})");
            }

            Console.WriteLine("Введите номер вопроса для удаления:");

            if (int.TryParse(Console.ReadLine(), out int questionNumber))
            {
                if (questionNumber >= 1 && questionNumber <= questions.Count)
                {
                    QuestionsStorage.Delete(questionNumber, _questionPath);
                    Console.WriteLine($"Вопрос номер {questionNumber} успешно удален!");
                }
                else
                {
                    Console.WriteLine($"Некорректный номер вопроса! Допустимый диапазон: 1-{questions.Count}");
                }
            }
            else
            {
                Console.WriteLine("Некорректный ввод! Введите число.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке вопросов: {ex.Message}");
        }
    }

    private void RegisterAdmin()
    {
        Console.WriteLine(Messages.RegisterAdmin);
        var result = AdminService.RegisterAdmin(GetAdminCredentials, _adminPath);
        Console.WriteLine(result.message);
    }
}
