namespace GeniyIdiotClassLibrary;

public static class UserResultStorage
{

    public static List<User> LoadFromFile(string filePath)
    {
        try
        {
            var userResults = new List<User>();
            var lines = FileProvider.Read(filePath);

            for (int i = 2 ; i < lines.Count ; i++)
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
            var line = string.Format("|| {0,-35} || {1,-25} || {2,-15} ||",
                userFullName,
                answer.ToString(),
                diagnostic);

            FileProvider.Append(filePath, line);
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка сохранения результата: {ex.Message}");
        }
    }
}
