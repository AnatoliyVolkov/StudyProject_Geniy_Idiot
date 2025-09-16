using System;
using System.IO;

namespace GeniyIdiotApp;

public class SaveUserTest
{
    string userName { get; }
    string userSurname { get; }
    string userPatronymic { get; }
    string directoryPath;
    string filePath;

    public SaveUserTest(string userLastName, string userName, string userPatronymic)
    {
        this.userName = userName;
        this.userSurname = userLastName;
        this.userPatronymic = userPatronymic;
        this.directoryPath = Directory.GetCurrentDirectory();
        this.filePath = Path.Combine(directoryPath, "test_results.txt");

        if (!File.Exists(filePath))
        {
            CreateFileHeader();
        }
    }

    private void CreateFileHeader()
    {
        using (StreamWriter sw = new StreamWriter(filePath, false))
        {
            sw.WriteLine("|| {0,-35} || {1,-25} || {2,-15} ||", "ФИО", "Набранные баллы", "Диагноз");
            sw.WriteLine(new string('=', 85));
        }
    }

    public void SaveTestResults(int correctAnswer, string diagnostic)
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

    public static void ShowAllTestResults()
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