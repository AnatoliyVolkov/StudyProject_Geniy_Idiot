using System;
using System.IO;
using System.Reflection.Metadata;
using static GeniyIdiotApp.Program;

namespace GeniyIdiotApp;

public static class Append
{
    public static bool CheckFileExists(string filePath)
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

    public static void SaveData(string fileName, string date)
    {
        if (fileName == "test_results")
        {
            using (var sw = new StreamWriter(fileName, true))
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
                    string[] dateInput = date.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                    sw.WriteLine("|| {0,-35} || {1,-25} || {2,-15} ||",
                                User.userFullName,
                                dateInput[0],
                                dateInput[1]
                                );
                }
                catch (Exception ex) { Console.WriteLine($"Ошибка при сохранении данных в файл: {ex.Message}"); }
            }
        }
        if (fileName == "Question")
        {
            using (var sw = new StreamWriter(fileName, true))
            {
                if (sw.BaseStream.Length == 0)
                {
                    try
                    {
                        sw.WriteLine("|| {0,-85} || {1,-15}", "Вопрос", "Ответ");
                        sw.WriteLine(new string('=', 115));
                    }
                    catch (Exception ex) { Console.WriteLine($"Ошибка при создании заголовка файла: {ex.Message}"); }
                }
                    try
                    {
                        string[] dateInput = date.Split("|");
                        sw.WriteLine("|| {0,-85} || {1,-15}",
                                    dateInput[0],
                                    dateInput[1]
                                    );
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Ошибка при создании файла: {ex.Message}");
                    }
                
            }
        }
    }

    public static void ShowResults(string fileName)
    {
        if (fileName == "test_results")
        {
            try
            {
                if (File.Exists(fileName))
                {
                    Console.WriteLine("\n=== РЕЗУЛЬТАТЫ ТЕСТИРОВАНИЯ ===\n");
                    using (var sr = new StreamReader(fileName))
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
        if (fileName == "Question")
        {
            try
            {
                if (File.Exists(fileName))
                {
                    Console.WriteLine("\n=== ТАБЛИЦА ВОПРОС/ОТВЕТ ===\n");
                    using (var sr = new StreamReader(fileName))
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
}