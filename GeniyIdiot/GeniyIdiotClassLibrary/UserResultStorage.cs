using Newtonsoft.Json;
using System.Text;

namespace GeniyIdiotClassLibrary;

public static class UserResultStorage
{
    public static string ResultsFilePath { get; set; } = "results.json";

    public static List<User> LoadFromFile(string filePath)
    {
        try
        {
            if (!FileProvider.Exists(filePath))
                return new List<User>();

            var lines = FileProvider.Read(filePath);
            if (lines.Count == 0)
                return new List<User>();

            var json = string.Join("", lines);
            return JsonConvert.DeserializeObject<List<User>>(json);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка загрузки результатов: {ex.Message}");
        }
    }

    public static void SaveResult(string filePath, string userFullName, int correctAnswers, string diagnosis)
    {
        try
        {
            var results = LoadFromFile(filePath);
            results.Add(new User(userFullName, correctAnswers, diagnosis));

            var json = JsonConvert.SerializeObject(results, Formatting.Indented);

            using var sw = new StreamWriter(filePath, false, Encoding.UTF8);
            sw.Write(json);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка сохранения результата: {ex.Message}");
        }
    }

    public static void CreateEmptyResultsFile(string filePath)
    {
        try
        {
            var emptyResults = new List<User>();
            var json = JsonConvert.SerializeObject(emptyResults, Formatting.Indented);

            using var sw = new StreamWriter(filePath, false, Encoding.UTF8);
            sw.Write(json);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка создания файла результатов: {ex.Message}");
        }
    }
}