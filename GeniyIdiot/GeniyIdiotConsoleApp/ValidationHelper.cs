namespace GeniyIdiotApp;

public static class ValidationHelper
{
    public static int CheckAnswerUserQuestion(string userName, int questionIndex)
    {
        while (true)
        {
            try
            {
                var userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    throw new Exception($"Вы дали ответ пустой строкой.\n Вам нужно ввести число не длинее 6 знаков.");
                }
                if (short.TryParse(userInput, out var answer))
                {
                    return answer == QuestionsStorage.GetQuestions()[questionIndex].Answer ? 1 : 0;
                }
                if (long.TryParse(userInput, out var _))
                {
                    throw new Exception($"{userName}, вы ввели слишком большое число, Вам нужно ввести число не длинее 6 знаков.");
                }
                else
                {
                    throw new Exception($"{userName}, вы ввели букву, Вам нужно ввести число не длинее 6 знаков.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }

    public static string CheckUsernameEntry(string name)
    {

        if (string.IsNullOrEmpty(name))
        {
            throw new Exception("Нельзя оставлять поле пустым, будьте внимательней");
        }
        if (short.TryParse(name, out _))
        {
            throw new Exception("Нельзя вводить числа, будьте внимательней");
        }
        if (name.Contains(" "))
        {
            throw new Exception("Можно вводить только одно слово без пробелов, будьте внимательней");
        }
        if (name.Any(c => DiagnosticTestResources.InvalidChars.Contains(c)))
        {
            throw new Exception("Были введены не допустимые символы, будьте внимательней");
        }
        else
        {
            return name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
        }
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
                if (answer.Trim().ToLower() == "нет" || answer.Trim().ToLower() == "да")
                { return answer; }
                else { throw new Exception($"Вы дали не корректный ответ.\n Пожалуйста дайте ответ Да или Нет."); }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }

    public static string GetUserName()
    {
        while (true)
        {
            try
            {
                var name = Console.ReadLine();
                return ValidationHelper.CheckUsernameEntry(name);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Повторите попытку ввода еще раз.");
            }
        }
    }

    public static bool CheckLogin()
    {
        Console.WriteLine("Добро пожаловать в программу оценки гениальности!\n" +
            "Вы хотите войти как пользователь? да/нет");
        var answer = CheckUserAnswer();
        if (answer == "да") { return true; }
        return false;
    }

    public static int CheckAdminInput()
    {
        while (true)
        {
            try
            {
                var userInput = Console.ReadLine();
                if (string.IsNullOrEmpty(userInput))
                {
                    throw new Exception($"Вы дали ответ пустой строкой.\n Вам нужно ввести число не длинее 6 знаков.");
                }
                if (short.TryParse(userInput, out var answer))
                {
                    return answer;
                }
                if (long.TryParse(userInput, out var _))
                {
                    throw new Exception($"Вы ввели слишком большое число, Вам нужно ввести число не длинее 6 знаков.");
                }
                else
                {
                    throw new Exception($"Вы ввели букву, Вам нужно ввести число не длинее 6 знаков.");
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}