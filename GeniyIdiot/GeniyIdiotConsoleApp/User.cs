namespace GeniyIdiotApp;

public static class User
{
    public static string UserName { get; set; }
    public static string UserSurname { get; set; }
    public static string UserPatronymic { get; set; }

    public static string userFullName => $"{UserName} {UserSurname} {UserPatronymic}";

    public static void SafeUserData(string name, string surname, string patronymic)
    {
        UserName = name;
        UserSurname = surname;
        UserPatronymic = patronymic;
    }

    public static (string userLastName, string userName, string userPatronymic) UserFIO()
    {
        Console.WriteLine("Добрый день, вы сейчас будете проходить тест на определение вашей гениальности.\n");
        Console.WriteLine("Пожалуйста введите свою фамилию.");
        var lastName = GetUserName();
        Console.WriteLine("Пожалуйста введите свое имя.");
        var name = GetUserName();
        Console.WriteLine("Пожалуйста введите свое отчество.");
        var patronymicName = GetUserName();
        SafeUserData(name, lastName, patronymicName);
        return (lastName, name, patronymicName);
    }

    static string GetUserName()
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
}