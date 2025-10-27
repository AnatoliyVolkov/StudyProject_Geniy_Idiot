using GeniyIdiotClassLibrary;

namespace GeniyIdiotConsoleApp;

public class Services
{
    public UserService _userService;
    public TestService _testService;
    public AdminMenu _adminMenu;
    public File _fileService;

    public string _directoryPath;
    public string _questionPath;
    public string _testPath;
    public string _adminPath;

    public Services()
    {
        _directoryPath = Directory.GetCurrentDirectory();
        _questionPath = Path.Combine(_directoryPath, QuestionsStorage.QuestionsFilePath);
        _testPath = Path.Combine(_directoryPath, UserResultStorage.ResultsFilePath);
        _adminPath = Path.Combine(_directoryPath, AdminStorage.AdminFilePath);

        _fileService = new File(_directoryPath, _questionPath, _testPath);
        _userService = new UserService();
        _testService = new TestService(_questionPath, _testPath);
        _adminMenu = new AdminMenu(_questionPath, _adminPath);
    }

    public void Run()
    {
        try
        {
            _fileService.CheckFiles();
            StartApp();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private void StartApp()
    {
        while (true)
        {
            if (_userService.CheckLogin())
            {
                RunUserMode();
            }
            else
            {
                RunAdminMode();
            }

            Console.WriteLine("\nВернуться в главное меню? (да/нет)");
            var answer = Console.ReadLine();
            if (answer?.ToLower() != "да")
            {
                break;
            }
        }
    }

    private void RunUserMode()
    {
        var user = _userService.GetUserInfo();
        Console.WriteLine(string.Format(Messages.WelcomeUser, User.UserName));

        var restart = true;
        while (restart)
        {
            var score = _testService.RunTest(user);
            _testService.ShowResults(user, score);
            Console.WriteLine(string.Format(Messages.RetakeTest, User.UserName));
            restart = _userService.GetUserConfirm(User.UserName);
        }

        TestService.ShowAllResults();
        Console.WriteLine(string.Format(Messages.Thanks, User.UserName));
    }

    public void RunAdminMode()
    {
        int maxAttempts = 3;

        for (int i = 0 ; i < maxAttempts ; i++)
        {
            var authResult = _adminMenu.TryLogin();
            int attemptsLeft = maxAttempts - i - 1;

            Console.WriteLine(authResult.message);

            if (authResult.success)
            {
                _adminMenu.ShowAdminMenu(StartApp);
                return;
            }

            bool canContinue = attemptsLeft > 0 &&
                              !authResult.message.Contains("Нельзя вводить числа") &&
                              !authResult.message.Contains("Нельзя оставлять поле пустым") &&
                              !authResult.message.Contains("не допустимые символы");

            if (canContinue)
            {
                Console.WriteLine($"У вас осталось {attemptsLeft} попыток.");
            }
            else
            {
                Console.WriteLine(Messages.MaxAttempts);
                Console.WriteLine("\nВозврат в главное меню...");
                return;
            }
        }
    }
}