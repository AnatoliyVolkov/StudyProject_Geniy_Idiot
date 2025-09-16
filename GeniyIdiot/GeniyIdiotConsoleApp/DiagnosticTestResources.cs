using System;
using System.Collections.Generic;
using System.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace GeniyIdiotApp;

public static class DiagnosticTestResources
{
    public static List<string> Questions = new List<string>()
{
    "Сколько будет два плюс два умноженное на два?",
    "Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?",
    "На двух руках 10 пальцев. Сколько пальцев на 5 руках?",
    "Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?",
    "Пять свечей горело, три потухли. Сколько свечей осталось?"
};
    public static List<int> Answers = new List<int>() { 6, 9, 25, 60, 2 };
    public static List<string> Diagnoses = new List<string>()
{
    "Кретин",
    "Идиот",
    "Дурак",
    "Нормальный",
    "Талант",
    "Гений",
};

    public static List<int> ShuffleTestQuestions()
    {
        var randomQuestion = new Random();
        var questionIndexes = Enumerable.Range(0, Questions.Count).ToList();
        for (var i = questionIndexes.Count - 1 ; i > 0 ; i--)
        {
            var j = randomQuestion.Next(i + 1);
            (questionIndexes[i], questionIndexes[j]) = (questionIndexes[j], questionIndexes[i]);
        }
        return questionIndexes;
    }

    public static string CheckUsernameEntry(string name)
    {
        if (string.IsNullOrEmpty(name) || short.TryParse(name, out _))
        {
            throw new Exception("Нельзя вводить числа и оставлять поле пустым, будьте внимательней");
        }
        else
        {
            return name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
        }
    }

    public static bool GetUserConfirm(string name)
    {
        if (CheckUserAnswer().Trim().ToLower() == "да") { return true; }
        else { return false; }
    }

    public static string GetDiagnose(int correctAnswer)
    {
        var result = correctAnswer * 100.0 / Questions.Count;
        return result switch
        {
            >= 83.33 => "Гений",
            >= 66.67 => "Талант",
            >= 50.00 => "Нормальный",
            >= 33.33 => "Дурак",
            >= 16.67 => "Идиот",
            _ => "Кретин"
        };
    }

    public static string CheckUserAnswer()
    {
        while (true)
        {
            try
            {
                var answer = Console.ReadLine();
                if (string.IsNullOrEmpty(answer))
                {
                    throw new Exception($"Вы дали ответ пустой строкой.\n Пожалуйста дайте ответ Да или Нет.");
                }
                if (long.TryParse(answer, out _))
                {
                    throw new Exception($"Вы дали ответ числом.\n Пожалуйста дайте ответ Да или Нет.");
                }
                else { return answer; }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}
