using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace GeniyIdiotClassLibrary;

public static class QuestionsStorage
{
    public static string QuestionsFilePath { get; set; } = "Question.json";
    public static List<Question> GetQuestions(string questionsFilePath)
    {
        return GetFromJsonFile(questionsFilePath);
    }

    public static void CreateFirst(string questionsFilePath)
    {
        var defaultQuestions = GetDefault();
        SaveToJsonFile(defaultQuestions, questionsFilePath);
    }

    public static List<Question> GetFromJsonFile(string filePath)
    {
        try
        {
            if (!FileProvider.Exists(filePath))
            {
                CreateFirst(filePath);
                return GetDefault();
            }

            var lines = FileProvider.Read(filePath);
            if (lines.Count == 0)
            {
                return GetDefault();
            }

            var json = string.Join("", lines);
            var questions = JsonConvert.DeserializeObject<List<Question>>(json);
            return questions ?? GetDefault();
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка чтения вопросов из JSON: {ex.Message}");
        }
    }

    private static void SaveToJsonFile(List<Question> questions, string filePath)
    {
        try
        {
            var json = JsonConvert.SerializeObject(questions, Formatting.Indented);
            using var sw = new StreamWriter(filePath, false, Encoding.UTF8);
            sw.Write(json);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка сохранения вопросов в JSON: {ex.Message}");
        }
    }

    public static void Delete(int questionNumber, string questionsFilePath)
    {
        var questions = GetFromJsonFile(questionsFilePath);

        if (questionNumber < 1 || questionNumber > questions.Count)
        {
            throw new Exception($"Ошибка: Вопроса с номером {questionNumber} не существует! В файле всего {questions.Count} вопросов.");
        }
        questions.RemoveAt(questionNumber - 1);
        SaveToJsonFile(questions, questionsFilePath);
    }

    public static void Add(string questionText, int answer, string questionsFilePath)
    {
        if (string.IsNullOrWhiteSpace(questionText))
        {
            throw new Exception(Messages.QuestionEmpty);
        }

        var questions = GetFromJsonFile(questionsFilePath);
        questions.Add(new Question(questionText, answer));
        SaveToJsonFile(questions, questionsFilePath);
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
