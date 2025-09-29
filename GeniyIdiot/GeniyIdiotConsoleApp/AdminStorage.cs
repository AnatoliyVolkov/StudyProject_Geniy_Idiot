using System.Text;

namespace GeniyIdiotApp;

public class AdminStorage
{
    public List<Admin> admins = new List<Admin>();
    private static string adminFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Admin");

    public AdminStorage()
    {
        LoadFromFile();
    }

    public void AddAdmin(string login, int password)
    {
        if (!admins.Any(admin => admin.Login == login.ToLower()))
        {
            admins.Add(new Admin(login.ToLower(), password));
            SaveToFile();
        }
    }

    public void RemoveAdmin(string login)
    {
        admins.RemoveAll(admin => admin.Login == login);
        SaveToFile();
    }

    private void SaveToFile()
    {
        try
        {
            var header = string.Format("{0,-45} || {1,-30}", "Логин", "Пароль");
            var separator = new string('=', header.Length);

            using var sw = new StreamWriter(adminFilePath, false, Encoding.UTF8);
            sw.WriteLine(header);
            sw.WriteLine(separator);

            foreach (var admin in admins)
            {
                var line = string.Format("{0,-45} || {1,-30}", admin.Login, admin.Password.ToString());
                sw.WriteLine(line);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении администраторов: {ex.Message}");
        }
    }

    private void LoadFromFile()
    {
        admins.Clear();

        if (!File.Exists(adminFilePath))
        {
            admins.Add(new Admin("qwerty", 123));
            SaveToFile();
            return;
        }

        var lines = File.ReadAllLines(adminFilePath);

        if (lines.Length < 3)
        {
            admins.Add(new Admin("qwerty", 123));
            SaveToFile();
            return;
        }

        for (int i = 2; i < lines.Length; i++)
        {
            var line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            try
            {
                var parts = line.Split(new[] { "||" }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length >= 2)
                {
                    var login = parts[0].Trim();
                    var passwordText = parts[1].Trim();

                    if (int.TryParse(passwordText, out int password))
                    {
                        admins.Add(new Admin(login, password));
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при чтении администратора: {ex.Message}");
            }
        }

        if (admins.Count == 0)
        {
            admins.Add(new Admin("qwerty", 123));
            SaveToFile();
        }
    }
}