namespace GeniyIdiotClassLibrary;

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
                    throw new Exception(Messages.EmptyNumber);
                }
                if (short.TryParse(userInput, out var answer))
                {
                    return answer == QuestionsStorage.GetQuestions()[questionIndex].Answer ? 1 : 0;
                }
                if (long.TryParse(userInput, out var _))
                {
                    throw new Exception(Messages.TooBigNumber);
                }
                else
                {
                    throw new Exception(Messages.LetterInput);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }

    public static string CheckUsernameEntry(string name)
    {

        if (string.IsNullOrEmpty(name))
        {
            throw new Exception(Messages.EmptyField);
        }
        if (short.TryParse(name, out _))
        {
            throw new Exception(Messages.NumbersNotAllowed);
        }
        if (name.Contains(" "))
        {
            throw new Exception(Messages.SingleWord);
        }
        if (name.Any(c => DiagnosticTestResources.InvalidChars.Contains(c)))
        {
            throw new Exception(Messages.InvalidChars);
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
                    throw new Exception(Messages.EmptyAnswer);
                }
                if (long.TryParse(answer, out _))
                {
                    throw new Exception(Messages.NumberAnswer);
                }
                if (answer.Trim().ToLower() == "нет" || answer.Trim().ToLower() == "да")
                { return answer; }
                else { throw new Exception(Messages.InvalidAnswer); }
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
                Console.WriteLine(Messages.NextTry);
            }
        }
    }

    public static bool CheckLogin()
    {
        Console.WriteLine(Messages.Welcome);
        Console.WriteLine(Messages.ChooseRole);
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
                    throw new Exception(Messages.EmptyNumber);
                }
                if (short.TryParse(userInput, out var answer))
                {
                    return answer;
                }
                if (long.TryParse(userInput, out var _))
                {
                    throw new Exception(Messages.TooBigNumber);
                }
                else
                {
                    throw new Exception(Messages.LetterInput);
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        }
    }
}