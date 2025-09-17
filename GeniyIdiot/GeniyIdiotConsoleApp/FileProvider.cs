using System;
using System.IO;

namespace GeniyIdiotApp;

public static class FileProvider
{
    private static string userName { get; set; }
    private static string userSurname { get; set; }
    private static string userPatronymic { get; set; }
    private static string directoryPath = Directory.GetCurrentDirectory();
    private static string filePath = Path.Combine(directoryPath, "test_results.txt");

    public static void SafeUserData (string name, string surname, string patronymic)
    {
        userName = name;
        userSurname = surname;
        userPatronymic = patronymic;
    }

    public static void CreateFileHeader()
    {
        using (StreamWriter sw = new StreamWriter(filePath, false))
        {
            sw.WriteLine("|| {0,-35} || {1,-25} || {2,-15} ||", "ФИО", "Набранные баллы", "Диагноз");
            sw.WriteLine(new string('=', 85));
        }
    }

    public static void SaveResults(int correctAnswer, string diagnostic)
    {
        var userFullName = $"{userSurname} {userName} {userPatronymic}";

        using (StreamWriter sw = new StreamWriter(filePath, true))
        {
            sw.WriteLine("|| {0,-35} || {1,-25} || {2,-15} ||",
                        userFullName,
                        correctAnswer,
                        diagnostic);
        }
    }

    public static void ShowResults()
    {
        string filePath = Path.Combine(Directory.GetCurrentDirectory(), "test_results.txt");

        if (File.Exists(filePath))
        {
            Console.WriteLine("\n=== РЕЗУЛЬТАТЫ ТЕСТИРОВАНИЯ ===\n");
            using (StreamReader sr = new StreamReader(filePath))
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
}