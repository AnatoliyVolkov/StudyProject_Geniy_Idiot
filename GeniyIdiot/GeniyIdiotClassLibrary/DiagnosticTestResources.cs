namespace GeniyIdiotClassLibrary;

public static class DiagnosticTestResources
{
    public static List<string> Diagnoses = new List<string>()
{
    "Кретин",
    "Идиот",
    "Дурак",
    "Нормальный",
    "Талант",
    "Гений",
};

    static public char[] InvalidChars =
    {
        '!', '@', '#', '$', '%', '^', '&', '*', '(', ')',
        '_', '+', '=', '{', '}', '[', ']', '|', '\\', ':',
        ';', '"', '\'', '<', '>', ',', '.', '?', '/', '№',
    };

    public static List<int> ShuffleTestQuestions()
    {
        var questionCount = QuestionsStorage.GetQuestions().Count;
        var questionIndexes = Enumerable.Range(0, questionCount).ToList();
        var randomQuestion = new Random();

        for (var i = questionIndexes.Count - 1; i > 0; i--)
        {
            var j = randomQuestion.Next(i + 1);
            (questionIndexes[i], questionIndexes[j]) = (questionIndexes[j], questionIndexes[i]);
        }
        return questionIndexes;
    }

    public static bool GetUserConfirm(string name)
    {
        return ValidationHelper.CheckUserAnswer().Trim().ToLower() == "да";
    }

    public static string GetDiagnose(int correctAnswer)
    {
        var result = correctAnswer * 100.0 / QuestionsStorage.GetQuestions().Count;
        return result switch
        {
            >= 83.33 => "Гений",
            >= 66.67 => "Талант",
            >= 50.00 => "Нормальный",
            >= 33.33 => "Дурак",
            >= 16.67 => "Идиот",
            _ => "Кретин"
        };
    }
}
