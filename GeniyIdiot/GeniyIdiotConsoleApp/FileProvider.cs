using System;
using System.IO;
using System.Reflection.Metadata;
using static GeniyIdiotApp.Program;

namespace GeniyIdiotApp;

public static class FileProvider
{
    static string directoryPath = Directory.GetCurrentDirectory();
    static string filePath = Path.Combine(directoryPath, "test_results.txt");

    public static void SaveResults(int correctAnswer, string diagnostic)
    {
        var userFullName = $"{User.UserName} {User.UserSurname} {User.UserPatronymic}";
        using (var sw = new StreamWriter(filePath, true))
        {
            if (sw.BaseStream.Length == 0)
            {
                try
                {
                    sw.WriteLine("|| {0,-35} || {1,-25} || {2,-15} ||", "ФИО", "Набранные баллы", "Диагноз");
                    sw.WriteLine(new string('=', 115));
                }
                catch (Exception ex) { Console.WriteLine($"Ошибка при создании заголовка файла: {ex.Message}"); }
            }
            try
            {
                sw.WriteLine("|| {0,-35} || {1,-25} || {2,-15} ||",
                            userFullName,
                            correctAnswer,
                            diagnostic);
            }
            catch (Exception ex) { Console.WriteLine($"Ошибка при сохранении данных в файл: {ex.Message}"); }
        }
    }

    public static void ShowResults()
    {
        var filePath = Path.Combine(Directory.GetCurrentDirectory(), "test_results.txt");
        try
        {
            if (File.Exists(filePath))
            {
                Console.WriteLine("\n=== РЕЗУЛЬТАТЫ ТЕСТИРОВАНИЯ ===\n");
                using (var sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(line);
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл с результатами не найден.");
            }
        }
        catch (Exception ex) { Console.WriteLine($"Ошибка чтения данных с файла: {ex.Message}"); }
    }
}