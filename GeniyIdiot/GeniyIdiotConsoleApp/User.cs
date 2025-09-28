namespace GeniyIdiotApp;

public  class User
{
    public static string UserName { get; set; }
    public static string UserSurname { get; set; }
    public static string UserPatronymic { get; set; }
    public static int Answer { get; set; }
    public static string Diagnostic { get; set; }
    public static string userFullName => $"{UserName} {UserSurname} {UserPatronymic}";

    public User(string fio, int answer, string diagnostic)
    {
        Answer = answer;
        Diagnostic = diagnostic;
    }

    public static void SafeData(string name, string surname, string patronymic)
    {
        UserName = name;
        UserSurname = surname;
        UserPatronymic = patronymic;
    }

    public static int RightAnswer(int questionIndex)
    {
        return ValidationHelper.CheckAnswerUserQuestion(UserName, questionIndex);
    }

}