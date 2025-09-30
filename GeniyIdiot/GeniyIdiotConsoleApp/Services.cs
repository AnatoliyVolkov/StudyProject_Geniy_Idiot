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
        _questionPath = Path.Combine(_directoryPath, "Question");
        _testPath = Path.Combine(_directoryPath, "test_results");
        _adminPath = Path.Combine(_directoryPath, "Admin");

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
        if (_userService.CheckLogin())
        {
            RunUserMode();
        }
        else
        {
            RunAdminMode();
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

        _testService.ShowAllResults();
        Console.WriteLine(string.Format(Messages.Thanks, User.UserName));
    }

    private void RunAdminMode()
    {
        bool success = false;
        var attempts = 3;
        for (int i = 0 ; i < attempts ; i++)
        {
            var authResult = _adminMenu.TryLogin();
            

            if (authResult.success)
            {
                Console.WriteLine(authResult.message);
                _adminMenu.ShowAdminMenu(StartApp);
                return;
            }
            else
            {
                Console.WriteLine(authResult.message);
                if (authResult.message == Messages.MaxAttempts)
                {
                    Console.WriteLine("\nВозврат в главное меню...");
                    StartApp();
                    return;
                }
            }
            
        }
        Console.WriteLine(Messages.MaxAttempts);
        Console.WriteLine("\nВозврат в главное меню...");
        StartApp();
        
    }
}