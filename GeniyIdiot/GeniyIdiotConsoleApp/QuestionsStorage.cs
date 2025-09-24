namespace GeniyIdiotApp;

public static class QuestionsStorage
{
    public static List<Questions> GetQuestions()
    {
        return LoadQuestionsFromFile();
    }

    public static void CreaterFirstQuestions(string questionPath)
    {
        var lines = FileProvider.Read(questionPath);
        if (lines.Count <= 2)
        {
            foreach (var question in GetDefaultQuestions())
            {
                string formatted = $"|| {question.Question,-85} || {question.Answer,-15}";
                FileProvider.Append(questionPath, formatted);
            }
        }
    }

    private static List<Questions> LoadQuestionsFromFile()
    {
        var questions = new List<Questions>();
        var directoryPath = Directory.GetCurrentDirectory();
        var questionPath = Path.Combine(directoryPath, "Question");

        var lines = FileProvider.Read(questionPath);

        for (int i = 2 ; i < lines.Count ; i++)
        {
            var line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            try
            {
                var parts = line.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2)
                {
                    var questionText = parts[0].Trim();
                    var answerText = parts[1].Trim();
                    if (int.TryParse(answerText, out int answer))
                    {
                        questions.Add(new Questions(questionText, answer));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при парсинге вопроса: {ex.Message}");
            }
        }

        if (questions.Count == 0)
        {
            questions.AddRange(GetDefaultQuestions());
        }
        return questions;
    }

    private static List<Questions> GetDefaultQuestions()
    {
        return new List<Questions>()
        {
            new Questions("Сколько будет два плюс два умноженное на два?", 6),
            new Questions("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9),
            new Questions("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
            new Questions("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60),
            new Questions("Пять свечей горело, три потухли. Сколько свечей осталось?", 2)
        };
    }
}
