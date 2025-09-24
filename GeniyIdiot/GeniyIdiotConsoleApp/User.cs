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
}