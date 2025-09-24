namespace GeniyIdiotApp;


public static class QuestionsStorage
{
    public static void CreaterFirstQuestions(string questionPath)
    {
        var lines = FileProvider.Read(questionPath);
        if (lines.Count <= 3)
        {
            foreach (var question in GetQuestions)
            {
                string formatted = $"|| {question.Question,-85} || {question.Answer,-15}";
                FileProvider.Append(questionPath, formatted);
            }
        }
    }

    public static List<Questions> GetQuestions = new List<Questions>()
    {
        new Questions("Сколько будет два плюс два умноженное на два?",6),
        new Questions("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",9),
        new Questions("На двух руках 10 пальцев. Сколько пальцев на 5 руках?",25),
        new Questions("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",60),
        new Questions("Пять свечей горело, три потухли. Сколько свечей осталось?",2)
    };
}

