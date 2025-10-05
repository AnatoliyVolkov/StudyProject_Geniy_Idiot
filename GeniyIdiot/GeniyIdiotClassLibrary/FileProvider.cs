using System.Data;
using System.Text;

namespace GeniyIdiotClassLibrary;

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
            throw new Exception($"Ошибка при проверке файла {filePath}: {ex.Message}");
        }
    }

    public static void Create(string filePath, string header)
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
            throw new Exception($"Ошибка при создании файла {filePath}: {ex.Message}");
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
            throw new Exception($"Ошибка при записи в файл {filePath}: {ex.Message}");
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
            throw new Exception($"Ошибка чтения файла {filePath}: {ex.Message}");
        }
    }


    public static void RemoveLine(string filePath, int lineNumber)
    {
        try
        {
            var lines = Read(filePath);
            if (lineNumber > 0 && lineNumber <= lines.Count)
            {
                lines.RemoveAt(lineNumber - 1);
                File.WriteAllLines(filePath, lines, Encoding.UTF8);
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Ошибка удаления строки: {ex.Message}");
        }
    }

  }
