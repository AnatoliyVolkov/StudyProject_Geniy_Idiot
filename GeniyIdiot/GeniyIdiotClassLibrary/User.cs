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

    public static int RightAnswer(string userInput, string userName, int questionIndex, string questionsPath)
    {
        var result = ValidationHelper.CheckAnswerUserQuestion(userInput, userName, questionIndex, questionsPath);
        if (result._Success)
            return result.Value;
        else
            throw new Exception(result.ErrorMessage);
    }

}