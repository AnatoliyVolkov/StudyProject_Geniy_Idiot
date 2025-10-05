namespace GeniyIdiotClassLibrary;

public static class UserResultStorage
{
    public static string ResultsFilePath { get; set; } = "test_results";

    public static List<User> LoadFromFile(string filePath)
    {
        try
        {
            var userResults = new List<User>();

            if (!File.Exists(filePath))
                return userResults;

            var lines = FileProvider.Read(filePath);

            int startIndex = 0;
            if (lines.Count > 2)
            {
                if (lines[0].Contains("ФИО") && lines[1].Contains("="))
                {
                    startIndex = 2;
                }
            }

            for (int i = startIndex ; i < lines.Count ; i++)
            {
                var line = lines[i];
                if (string.IsNullOrWhiteSpace(line)) continue;

                var parts = line.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 3)
                {
                    var fio = parts[0].Trim();
                    var answerText = parts[1].Trim();
                    var diagnostic = parts[2].Trim();

                    if (int.TryParse(answerText, out int answer))
                    {
                        userResults.Add(new User(fio, answer, diagnostic));
                    }
                }
            }
            return userResults;
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка загрузки результатов: {ex.Message}");
        }
    }

    public static void SaveResult(string filePath, string userFullName, int answer, string diagnostic)
    {
        try
        {
            var line = userFullName + "||" + answer.ToString() + "||" + diagnostic;
            FileProvider.Append(filePath, line);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка сохранения результата: {ex.Message}");
        }
    }
}
