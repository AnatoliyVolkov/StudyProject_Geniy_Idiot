namespace GeniyIdiotClassLibrary;

public static class QuestionsStorage
{

    static string directoryPath = Directory.GetCurrentDirectory();
    static string questionPath = Path.Combine(directoryPath, "Question");
    public static List<Question> GetQuestions()
    {
        return GetFromFile();
    }

    public static void CreaterFirst(string questionPath)
    {
        var lines = FileProvider.Read(questionPath);
        if (lines.Count <= 2)
        {
            var lin = lines.Count - 2;
            foreach (var question in GetDefault())
            {
                var formatted = $"{lin + 1,-5}|| {question._Question,-85} || {question.Answer,-15}";
                FileProvider.Append(questionPath, formatted);
                lin++;
            }
        }
    }

    public static List<Question> GetFromFile()
    {
        List<Question> questions = new List<Question>();
        var lines = FileProvider.Read(questionPath);
        for (int i = 2 ; i < lines.Count ; i++)
        {
            var line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            try
            {
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
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при парсинге вопроса: {ex.Message}");
            }
        }

        if (questions.Count == 0)
        {
            questions.AddRange(GetDefault());
        }
        return questions;
    }

    public static void Delete(string questionPath)
    {
        List<string> lines = FileProvider.Read(questionPath);
        FileProvider.Show(questionPath);
        Console.WriteLine("Введите номер строки для удаления:");

        if (!int.TryParse(Console.ReadLine(), out int questionNumber) || questionNumber < 1)
        {
            Console.WriteLine("Некорректный номер вопроса!");
            return;
        }

        int fileLineNumber = questionNumber + 2;
        if (fileLineNumber < 1 || fileLineNumber > lines.Count)
        {
            Console.WriteLine($"Ошибка: Строка с номером {questionNumber} не существует!");
            Console.WriteLine($"В файле всего {lines.Count - 2} строк(и).");
            return;
        }

        FileProvider.RemoveLine(questionPath, fileLineNumber);
        Console.WriteLine("Вопрос успешно удален!");
    }

    public static void Add(string questionPath)
    {
        List<string> lines = FileProvider.Read(questionPath);
        Console.WriteLine("Введите вопрос для добавления");
        var question = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(question))
        {
            Console.WriteLine("Вопрос не может быть пустым!");
            return;
        }

        Console.WriteLine("Введите ответ на ваш вопрос");
        var validatedAnswer = ValidationHelper.CheckAdminInput();
        var questionNumber = lines.Count - 1;
        var newQuestion = $"{questionNumber,-5}|| {question,-85} || {validatedAnswer,-15}";
        FileProvider.Append(questionPath, newQuestion);

        Console.WriteLine("Вопрос успешно добавлен");
        FileProvider.Show(questionPath);
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
