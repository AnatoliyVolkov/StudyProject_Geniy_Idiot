namespace GeniyIdiotClassLibrary;

public  class User
{
    public static string UserName { get; set; }
    public static string UserSurname { get; set; }
    public static string UserPatronymic { get; set; }
    public static int Answer { get; set; }
    public static string Diagnostic { get; set; }
    public static string userFullName => $"{UserName} {UserSurname} {UserPatronymic}";

    public string FullName { get; set; }
    public int Score { get; set; }
    public string Diagnosis { get; set; }

    public User(string fio, int answer, string diagnostic)
    {
        FullName = fio;
        Score = answer;
        Diagnosis = diagnostic;
    }

    public static void SafeData(string name, string surname, string patronymic)
    {
        UserName = name;
        UserSurname = surname;
        UserPatronymic = patronymic;
    }

    public static (bool success, int result, string error) RightAnswerSafe(string userInput, string userName, int questionIndex, string questionsPath)
    {
        var validationResult = ValidationHelper.CheckAnswerUserQuestion(userInput, userName, questionIndex, questionsPath);
        if (validationResult._Success)
            return (true, validationResult.Value, null);
        else
            return (false, 0, validationResult.ErrorMessage);
    }

}