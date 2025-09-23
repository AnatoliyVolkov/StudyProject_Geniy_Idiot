using System.Text;

namespace GeniyIdiotApp;

public static class FileProvider
{
    public static bool Exists(string filePath)
    {
        try
        {
            return File.Exists(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при проверке файла {filePath}: {ex.Message}");
            return false;
        }
    }

    public static void Creater(string filePath, string header)
    {
        try
        {
            if (!File.Exists(filePath))
            {
                using var sw = new StreamWriter(filePath, false, Encoding.UTF8);
                if (!string.IsNullOrWhiteSpace(header))
                {
                    sw.WriteLine(header);
                    sw.WriteLine(new string('=', header.Length));
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при создании файла {filePath}: {ex.Message}");
        }
    }

    public static void Append(string filePath, string line)
    {
        try
        {
            using var sw = new StreamWriter(filePath, true, Encoding.UTF8);
            sw.WriteLine(line);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при записи данных в файл {filePath}: {ex.Message}");
        }
    }

    public static List<string> Read(string filePath)
    {
        try
        {
            if (!File.Exists(filePath)) return new List<string>();
            return File.ReadAllLines(filePath).ToList();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка чтения файла {filePath}: {ex.Message}");
            return new List<string>();
        }
    }

    public static void Show(string filePath, string title)
    {
        if (!File.Exists(filePath))
        {
            Console.WriteLine($"Файл не найден: {filePath}");
            return;
        }
        Console.WriteLine($"\n=== {title} ===\n");
        foreach (var line in Read(filePath))
        {
            Console.WriteLine(line);
        }
    }
}
