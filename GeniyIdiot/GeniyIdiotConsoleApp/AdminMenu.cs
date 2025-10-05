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
            var result = AdminService.GetMenu(choice, _questionPath);

            Console.WriteLine(result.message);

            if (!result.success) continue;

            if (result.message == "exit_to_main")
            {
                returnToMainMenu();
                return;
            }
            else if (result.message == Messages.ExitAdministrator)
            {
                Environment.Exit(0);
                return;
            }
            else if (result.message == Messages.EnterQuestion)
            {
                AddQuestion();
            }
            else if (result.message == Messages.EnterLineNumber)
            {
                DeleteQuestion();
            }
            else if (result.message == Messages.RegisterAdmin)
            {
                RegisterAdmin();
            }

            Console.WriteLine(Messages.PressEnter);
            Console.ReadLine();
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
        string question = Console.ReadLine();

        Console.WriteLine(Messages.EnterAnswer);
        string answerInput = Console.ReadLine();

        var result = AdminService.AddQuestion(
            () => (question, answerInput),
            _questionPath
        );

        Console.WriteLine(result.message);
        if (result.success) 
        {
            ShowQuestionsList();
        }
    }

    private void DeleteQuestion()
    {
        try
        {
            ShowQuestionsList();
            Console.WriteLine(Messages.EnterLineNumber);

            // Получаем общее количество вопросов для валидации
            var questions = QuestionsStorage.GetFromFile(_questionPath);
            var totalQuestions = questions.Count;

            Console.WriteLine($"Всего вопросов: {totalQuestions}");

            if (int.TryParse(Console.ReadLine(), out int lineNumber))
            {
                // Проверяем, что номер вопроса в допустимом диапазоне
                if (lineNumber >= 1 && lineNumber <= totalQuestions)
                {
                    var result = AdminService.DeleteQuestion(() => lineNumber, _questionPath);
                    Console.WriteLine(result.message);
                }
                else
                {
                    Console.WriteLine($"Некорректный номер вопроса! Допустимый диапазон: 1-{totalQuestions}");
                }
            }
            else
            {
                Console.WriteLine(Messages.InvalidQuestionNumber);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void ShowQuestionsList()
    {
        try
        {
            var questions = FileProvider.Read(_questionPath);

            foreach (var question in questions)
            {
                var _question = question.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);

                // Проверяем, что массив содержит достаточно элементов
                if (_question.Length >= 3)
                {
                    Console.WriteLine(string.Format("{0,-5} || {1,-85} || {2,-15}",
                        _question[0].Trim(),
                        _question[1].Trim(),
                        _question[2].Trim()));
                }
                else
                {
                    // Если формат строки не соответствует ожидаемому, просто выводим её как есть
                    Console.WriteLine(question);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при загрузке вопросов: {ex.Message}");
        }
    }

    private void RegisterAdmin()
    {
        var result = AdminService.RegisterAdmin(GetAdminCredentials, _adminPath);
        Console.WriteLine(result.message);
    }
}