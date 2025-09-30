
namespace GeniyIdiotClassLibrary
{
    public static class Messages
    {
        public static string Welcome = "Добро пожаловать в программу оценки гениальности!";
        public static string ChooseRole = "Вы хотите войти как пользователь? да/нет";
        public static string ContinueAsAdmin = "Вы продолжаете как администратор.";
        public static string EnterLogin = "Введите логин:";
        public static string EnterPassword = "Введите пароль (только цифры):";
        public static string AuthSuccess = "Авторизация успешна!";
        public static string AuthFailed = "НЕВЕРНО! У вас осталось {0} попыток.";
        public static string MaxAttempts = "Превышено максимальное количество попыток. \n За вами выехал наряд ФСБ, собирайте вещи. \n Пока он едет пройдите наш тест.";

        public static string AdminMode = "РЕЖИМ АДМИНИСТРАТОРА";
        public static string AdminMenu =
            "1. Просмотреть вопросы\n" +
            "2. Добавить вопрос\n" +
            "3. Удалить вопрос\n" +
            "4. Просмотреть результаты\n" +
            "5. Зарегистрировать нового администратора\n" +
            "6. Выйти из программы\n" +
            "7. Выйти в главное меню";
        public static string ChooseAction = "Выберите действие (1-7):";
        public static string ExitAdministrator = "Выход из режима администратора.";
        public static string InvalidChoice = "Неверный выбор!";
        public static string PressEnter = "\nНажмите Enter для продолжения...";

        public static string WelcomeTest = "Добрый день, вы сейчас будете проходить тест на определение вашей гениальности.\n";
        public static string EnterLastName = "Пожалуйста введите свою фамилию.";
        public static string EnterFirstName = "Пожалуйста введите свое имя.";
        public static string EnterPatronymic = "Пожалуйста введите свое отчество.";
        public static string WelcomeUser = "Добро пожаловать {0}! Мы приступаем.";
        public static string RetakeTest = "{0}, хотите пройти тест еще раз? (да/нет)";
        public static string ViewAllResults = "Хотите посмотреть все результаты тестирования? (да/нет)";
        public static string Thanks = "Спасибо {0}, что прошли наш тест. Всего хорошего.";
        public static string ExitAdministrator = "Выход из режима администратора";

        public static string TestResult = "{0}, вы ответили верно на {1} вопросов.";
        public static string DiagnosisResult = "Ваш результат: {0}";

        public static string EnterQuestion = "Введите вопрос для добавления";
        public static string EnterAnswer = "Введите ответ на ваш вопрос";
        public static string QuestionEmpty = "Вопрос не может быть пустым!";
        public static string QuestionAdded = "Вопрос успешно добавлен";
        public static string QuestionDeleted = "Вопрос успешно удален!";
        public static string EnterLineNumber = "Введите номер строки для удаления:";
        public static string InvalidQuestionNumber = "Некорректный номер вопроса!";
        public static string LineNotExists = "Ошибка: Строка с номером {0} не существует!";
        public static string TotalLines = "В файле всего {0} строк(и).";

        public static string RegisterAdmin = "Добавление нового администратора";
        public static string AdminExists = "Администратор с таким логином уже существует!";
        public static string AdminRegistered = "Новый администратор успешно зарегистрирован!";
        public static string RegisterError = "Ошибка при регистрации: {0}";

        public static string EmptyField = "Нельзя оставлять поле пустым, будьте внимательней";
        public static string NumbersNotAllowed = "Нельзя вводить числа, будьте внимательней";
        public static string SingleWord = "Можно вводить только одно слово без пробелов, будьте внимательней";
        public static string InvalidChars = "Были введены не допустимые символы, будьте внимательней";
        public static string NextTry = "Повторите попытку ввода еще раз.";
        public static string EmptyAnswer = "Вы дали ответ пустой строкой.\n Пожалуйста дайте ответ Да или Нет.";
        public static string NumberAnswer = "Вы дали ответ числом.\n Пожалуйста дайте ответ Да или Нет.";
        public static string InvalidAnswer = "Вы дали не корректный ответ.\n Пожалуйста дайте ответ Да или Нет.";
        public static string TooBigNumber = "{0}, вы ввели слишком большое число, Вам нужно ввести число не длинее 6 знаков.";
        public static string LetterInput = "{0}, вы ввели букву, Вам нужно ввести число не длинее 6 знаков.";
        public static string EmptyNumber = "Вы дали ответ пустой строкой.\n Вам нужно ввести число не длинее 6 знаков.";

        public static string FileNotFound = "Файл не найден: {0}";
    }
}
