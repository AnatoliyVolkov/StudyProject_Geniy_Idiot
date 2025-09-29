namespace GeniyIdiotClassLibrary;

public static class UserResultStorage
{
    static readonly List<User> userResult = new List<User>();

    public static void LoadFromFile(string filePath)
    {
        userResult.Clear();
        var lines = FileProvider.Read(filePath);
        for (int i = 2; i < lines.Count; i++)
        {
            var line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;
            try
            {
                var parts = line.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 3)
                {
                    var fio = parts[0].Trim();
                    var answerText = parts[1].Trim();
                    var diagnostic = parts[2].Trim();

                    if (int.TryParse(answerText, out int answer))
                    {
                        userResult.Add(new User(fio, answer, diagnostic));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении результата: {ex.Message}");
            }
        }
    }

}
