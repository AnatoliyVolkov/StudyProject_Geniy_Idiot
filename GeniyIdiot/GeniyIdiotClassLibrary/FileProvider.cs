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
}
