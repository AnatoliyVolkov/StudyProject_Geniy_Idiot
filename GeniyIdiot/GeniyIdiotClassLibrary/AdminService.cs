namespace GeniyIdiotClassLibrary;

public static class AdminService
{
    public static (bool success, string message) TryLogin(
    Func<(string login, string password)> getUserData, string adminFilePath)
    {
        var (login, password) = getUserData();

        var loginValidation = ValidationHelper.CheckUsernameEntry(login);
        if (!loginValidation._Success)
            return (false, loginValidation.ErrorMessage);

        var passwordValidation = ValidationHelper.CheckAdminInput(password);
        if (!passwordValidation._Success)
            return (false, passwordValidation.ErrorMessage);

        if (Admin.CheckAdmin(loginValidation.Value, password, adminFilePath))
            return (true, Messages.AuthSuccess);

        return (false, "НЕВЕРНО!");
    }

    public static (bool success, string message) RegisterAdmin(Func<(string login, string password)> getCredentials, string adminFilePath)
    {
        try
        {
            var adminStorage = new AdminStorage(adminFilePath);
            var (login, password) = getCredentials();

            var loginValidation = ValidationHelper.CheckUsernameEntry(login);
            if (!loginValidation._Success)
                return (false, loginValidation.ErrorMessage);

            var passwordValidation = ValidationHelper.CheckAdminInput(password);
            if (!passwordValidation._Success)
                return (false, passwordValidation.ErrorMessage);

            string validLogin = loginValidation.Value;
            int validPassword = passwordValidation.Value;

            if (adminStorage.admins.Any(admin =>
                admin.Login.Equals(validLogin.ToLower(), StringComparison.OrdinalIgnoreCase)))
                return (false, Messages.AdminExists);

            adminStorage.AddAdmin(validLogin.ToLower(), validPassword);
            return (true, Messages.AdminRegistered);
        }
        catch (Exception ex)
        {
            return (false, string.Format(Messages.RegisterError, ex.Message));
        }
    }

    public static (bool success, string message) GetMenu(string choice, string questionPath)
    {
        switch (choice?.Trim())
        {
            case "1":
                var questions = FileProvider.Read(questionPath);
                return (true, string.Join("\n", questions));
            case "2":
                return (true, Messages.EnterQuestion);
            case "3":
                return (true, Messages.EnterLineNumber);
            case "4":
                var results = FileProvider.Read("test_results");
                return (true, string.Join("\n", results));
            case "5":
                return (true, Messages.RegisterAdmin);
            case "6":
                return (true, Messages.ExitAdministrator);
            case "7":
                return (true, "exit_to_main");
            default:
                return (false, Messages.InvalidChoice);
        }
    }

    public static (bool success, string message) AddQuestion(Func<(string question, string answer)> getQuestionData, string questionPath)
    {
        try
        {
            var (question, answerInput) = getQuestionData();

            if (string.IsNullOrWhiteSpace(question))
                return (false, Messages.QuestionEmpty);

            var answerValidation = ValidationHelper.CheckAdminInput(answerInput);
            if (!answerValidation._Success)
                return (false, answerValidation.ErrorMessage);

            QuestionsStorage.Add(question, answerValidation.Value, questionPath);
            return (true, Messages.QuestionAdded);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }

    public static (bool success, string message) DeleteQuestion(Func<int> getLineNumber, string questionPath)
    {
        try
        {
            int lineNumber = getLineNumber();
            QuestionsStorage.Delete(lineNumber, questionPath);
            return (true, Messages.QuestionDeleted);
        }
        catch (Exception ex)
        {
            return (false, ex.Message);
        }
    }
}
