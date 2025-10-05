using System.Text;

namespace GeniyIdiotClassLibrary;

public static class QuestionsStorage
{
    public static string QuestionsFilePath { get; set; } = "Question";
    public static List<Question> GetQuestions(string questionPath)
    {
        return GetFromFile(questionPath);
    }


    public static void CreateFirst(string questionPath)
    {
        var lines = FileProvider.Read(questionPath);

        if (lines.Count == 0)
        {
            var defaultQuestions = GetDefault();
            var testLine = "1 || Тестовый вопрос || 0";
            var header = "П/П || Вопрос || Ответ";
            var separator = new string('=', testLine.Length);
            using var sw = new StreamWriter(questionPath, false, Encoding.UTF8);
            sw.WriteLine(header);
            sw.WriteLine(separator);
            for (int i = 0 ; i < defaultQuestions.Count ; i++)
            {
                var formatted = $"{i + 1 }|| {defaultQuestions[i]._Question} || {defaultQuestions[i].Answer}";
                sw.WriteLine(formatted);
            }
        }
    }

    public static List<Question> GetFromFile(string questionPath)
    {
        List<Question> questions = new List<Question>();
        var lines = FileProvider.Read(questionPath);

        for (int i = 0 ; i < lines.Count ; i++)
        {
            var line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            if (line.Contains("П/П") || line.Contains("===") || line.Contains("Вопрос") || line.Contains("Ответ"))
                continue;

            var parts = line.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
            if (parts.Length >= 3)
            {
                var questionText = parts[1].Trim();
                var answerText = parts[2].Trim();

                if (int.TryParse(answerText, out int answer))
                {
                    questions.Add(new Question(questionText, answer));
                }
            }
        }
        if (questions.Count == 0)
        {
            questions.AddRange(GetDefault());
        }
        return questions;
    }

    public static void Delete(int lineNumber, string questionPath)
    {
        var lines = FileProvider.Read(questionPath);

        int fileLineNumber = lineNumber + 2;
        if (fileLineNumber < 1 || fileLineNumber > lines.Count)
        {
            throw new Exception($"Ошибка: Строка с номером {lineNumber} не существует! В файле всего {lines.Count - 2} строк(и).");
        }
        lines.RemoveAt(fileLineNumber - 1);
        using var sw = new StreamWriter(questionPath, false, Encoding.UTF8);
        sw.WriteLine(lines[0]);
        sw.WriteLine(lines[1]);
        for (int i = 2 ; i < lines.Count ; i++)
        {
            var parts = lines[i].Split("||");
            if (parts.Length >= 3)
            {
                var newQuestion = $"{i - 1} || {parts[1].Trim()} || {parts[2].Trim()}";
                sw.WriteLine(newQuestion);
            }
        }

    }

    public static void Add(string question, int answer, string questionPath)
    {
        if (string.IsNullOrWhiteSpace(question))
        {
            throw new Exception(Messages.QuestionEmpty);
        }

        var existingQuestions = GetFromFile(questionPath);
        var questionNumber = existingQuestions.Count + 1;

        var newQuestion = $" {questionNumber}|| {question} || {answer}"; 
        FileProvider.Append(questionPath, newQuestion);
    }

    private static List<Question> GetDefault()
    {
        return new List<Question>()
        {
            new Question("Сколько будет два плюс два умноженное на два?", 6),
            new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9),
            new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25),
            new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60),
            new Question("Пять свечей горело, три потухли. Сколько свечей осталось?", 2)
        };
    }
}
