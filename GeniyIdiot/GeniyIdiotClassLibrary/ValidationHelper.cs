using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace GeniyIdiotClassLibrary;

public static class ValidationHelper
{
    public static ValidationResult<int> CheckAnswerUserQuestion(string userInput, string userName, int questionIndex, string questionPath)
    {
        try
        {
            if (string.IsNullOrEmpty(userInput))
                return ValidationResult<int>.Fail(Messages.EmptyNumber);

            if (short.TryParse(userInput, out var answer))
            {
                bool isCorrect = answer == QuestionsStorage.GetQuestions(questionPath)[questionIndex].Answer;
                return ValidationResult<int>.Success(isCorrect ? 1 : 0);
            }

            if (long.TryParse(userInput, out _))
                return ValidationResult<int>.Fail(string.Format(Messages.TooBigNumber, userName));

            return ValidationResult<int>.Fail(string.Format(Messages.LetterInput, userName));
        }
        catch (Exception ex)
        {
            return ValidationResult<int>.Fail(ex.Message);
        }
    }

    public static ValidationResult<string> ChekLogin(string log)
    {
        if (string.IsNullOrEmpty(log))
            return ValidationResult<string>.Fail(Messages.EmptyField);

        if (short.TryParse(log, out _))
            return ValidationResult<string>.Fail(Messages.NumbersNotAllowed);

        if (log.Contains(" "))
            return ValidationResult<string>.Fail(Messages.SingleWord);

        return ValidationResult<string>.Success(log);
    }

    public static ValidationResult<string> CheckUsernameEntry(string name)
    {
        try
        {
                if (ChekLogin(name)._Success &&
                name.Any(c => DiagnosticTestResources.InvalidChars.Contains(c)))
                    return ValidationResult<string>.Fail(Messages.InvalidChars);

                string formattedName = name.Substring(0, 1).ToUpper() + name.Substring(1).ToLower();
                return ValidationResult<string>.Success(formattedName);
        }
        catch (Exception ex)
        {
            return ValidationResult<string>.Fail(ex.Message);
        }
        
    }

    public static ValidationResult<string> CheckUserAnswer(string input)
    {
        try
        {
            if (string.IsNullOrEmpty(input))
                return ValidationResult<string>.Fail(Messages.EmptyAnswer);

            if (long.TryParse(input, out _))
                return ValidationResult<string>.Fail(Messages.NumberAnswer);

            string normalizedInput = input.Trim().ToLower();

            if (normalizedInput == "нет" || normalizedInput == "да")
                return ValidationResult<string>.Success(normalizedInput);

            return ValidationResult<string>.Fail(Messages.InvalidAnswer);
        }
        catch (Exception ex)
        {
            return ValidationResult<string>.Fail(ex.Message);
        }   
    }

    public static ValidationResult<int> CheckAdminInput(string userInput)
    {
        try
        {
            if (string.IsNullOrEmpty(userInput))
                return ValidationResult<int>.Fail(Messages.EmptyNumber);

            if (short.TryParse(userInput, out var answer))
                return ValidationResult<int>.Success(answer);

            if (long.TryParse(userInput, out _))
                return ValidationResult<int>.Fail(Messages.TooBigNumber);

            return ValidationResult<int>.Fail(Messages.LetterInput);
        }
        catch (Exception ex)
        {
            return ValidationResult<int>.Fail(ex.Message);
        }
    }
}
