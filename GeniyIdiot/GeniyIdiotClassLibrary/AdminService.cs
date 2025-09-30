namespace GeniyIdiotClassLibrary;

public static class AdminService
{
    private static string adminFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Admin");

    public static bool TryLogin(int attempts = 3)
    {
        int count = 0;
        while (count < attempts)
        {
            try
            {
                Console.WriteLine(Messages.ContinueAsAdmin);
                Console.WriteLine(Messages.EnterLogin);
                var login = ValidationHelper.CheckUsernameEntry(Console.ReadLine());
                Console.WriteLine(Messages.EnterPassword);
                var password = ValidationHelper.CheckAdminInput();

                if (Admin.CheckAdmin(login, password))
                {
                    Console.WriteLine(Messages.AuthSuccess);
                    return true;
                }
                else
                {
                    count++;
                    Console.WriteLine(string.Format(Messages.AuthFailed, attempts - count));
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
        Console.WriteLine(Messages.MaxAttempts);
        Test.GetStart();
        return false;
    }

    public static void RegisterAdmin()
    {
        try
        {
            var adminStorage = new AdminStorage();

            Console.WriteLine(Messages.RegisterAdmin);
            Console.WriteLine(Messages.EnterLogin);
            var login = ValidationHelper.CheckUsernameEntry(Console.ReadLine());
            Console.WriteLine(Messages.EnterPassword);
            var password = ValidationHelper.CheckAdminInput();

            if (adminStorage.admins.Any(admin => admin.Login == login.ToLower()))
            {
                Console.WriteLine(Messages.AdminExists);
                return;
            }

            adminStorage.AddAdmin(login.ToLower(), password);
            Console.WriteLine(Messages.AdminRegistered);
        }
        catch (Exception ex)
        {
            Console.WriteLine(string.Format(Messages.RegisterError, ex.Message));
        }
    }

    public static void Menu(string questionPath)
    {
        while (true)
        {
            Console.WriteLine(Messages.AdminMenu);

            switch (Console.ReadLine())
            {
                case "1": FileProvider.Show(questionPath); break;
                case "2": QuestionsStorage.Add(questionPath); break;
                case "3": QuestionsStorage.Delete(questionPath); break;
                case "4": FileProvider.Show("test_results"); break;
                case "5": RegisterAdmin(); break;
                case "6":
                    Console.WriteLine(Messages.ExitAdministrator);
                    Environment.Exit(0);
                    return;
                case "7": Test.GetStart(); return;
                default: Console.WriteLine(Messages.InvalidChoice); break;
            }

            Console.WriteLine(Messages.PressEnter);
            Console.ReadLine();
        }
    }
}