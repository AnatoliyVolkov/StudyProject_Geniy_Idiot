using GeniyIdiotClassLibrary;


namespace GeniyIdiotConsoleApp;

public class TestService
{
    private readonly string _questionPath;
    private readonly string _testPath;
    private const int TimePerQuestion = 10;
    private bool _timeExpired = false;

    public TestService(string questionPath, string testPath)
    {
        _questionPath = questionPath;
        _testPath = testPath;
    }

    public int RunTest(User user)
    {
        var testEngine = new TestEngine(_questionPath);
        var questionOrder = testEngine.shuffledQuestionIndexes;

        for (var i = 0 ; i < testEngine._Question.Count ; i++)
        {
            _timeExpired = false;

            Console.WriteLine($"\nВопрос номер: {i + 1}");
            var currentQuestionIndex = questionOrder[i];
            Console.WriteLine(testEngine._Question[currentQuestionIndex]._Question);

            string userInput = GetUserInputWithTimeout();
            if (_timeExpired)
            {
                
                Console.WriteLine("\nВремя вышло! Ответ не засчитан.");
                userInput = "999";
            }

            var answerResult = testEngine.ProcessAnswer(userInput);

            if (!answerResult.success)
            {
                Console.WriteLine(answerResult.error);
                i--;
            }
        }
        return testEngine.CorrectAnswersCount;
    }

    private string GetUserInputWithTimeout()
    {
        string input = "";
        _timeExpired = false;
        var cts = new CancellationTokenSource();

        Console.WriteLine($"Время на ответ: {TimePerQuestion} сек.");
        Console.Write("Ответ: ");

        var inputTask = Task.Run(() =>
        {
            input = Console.ReadLine();
            cts.Cancel();
        });

        var timerTask = Task.Run(async () =>
        {
            for (int timeLeft = TimePerQuestion ; timeLeft > 0 ; timeLeft--)
            {
                if (cts.Token.IsCancellationRequested)
                    break;

                
                int currentLeft = Console.CursorLeft;
                int currentTop = Console.CursorTop;

                Console.SetCursorPosition(0, Console.CursorTop - 1); 
                Console.Write($"Время на ответ: {timeLeft} сек.    "); 
                Console.SetCursorPosition(currentLeft, currentTop); 

                try
                {
                    await Task.Delay(1000, cts.Token);
                }
                catch (TaskCanceledException)
                {
                    break;
                }
            }

            if (!inputTask.IsCompleted && !cts.Token.IsCancellationRequested)
            {
                _timeExpired = true;
                cts.Cancel();
            }
        });

        try
        {
            Task.WaitAny(new[] { inputTask, timerTask });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
        finally
        {
            cts.Cancel();
        }

        Console.WriteLine(); 
        return input ?? "";
    }

    public void ShowResults(User user, int score)
    {
        try
        {
            var questions = QuestionsStorage.GetQuestions(_questionPath);
            var diagnose = DiagnosticTestResources.GetDiagnose(score, questions.Count);
            UserResultStorage.SaveResult(_testPath, User.userFullName, score, diagnose);
            Console.WriteLine(string.Format(Messages.TestResult, User.UserName, score));
            Console.WriteLine(string.Format(Messages.DiagnosisResult, diagnose));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка при сохранении результатов: {ex.Message}");
        }
    }

    public static void ShowAllResults()
    {
        Console.WriteLine(Messages.ViewAllResults);
        var userService = new UserService();
        if (userService.GetUserConfirm(""))
        {
            try
            {
                var results = UserResultStorage.LoadFromFile(UserResultStorage.ResultsFilePath);

                if (results.Count == 0)
                {
                    Console.WriteLine("Результатов тестирования отсутствуют.");
                    return;
                }

                PrintResultsAsTable(results);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке результатов: {ex.Message}");
                Console.WriteLine("Файл результатов поврежден. Будет создан новый файл.");
                UserResultStorage.CreateEmptyResultsFile(UserResultStorage.ResultsFilePath);
            }
        }
    }

    public static void PrintResultsAsTable(List<User> results)
    {
        Console.WriteLine("|| {0,-25} || {1,-20} || {2,-25} ||", "ФОИ", "Правильных ответов", "Результаты теста");
        Console.WriteLine(new string('=', 95));

        foreach (var result in results)
        {
            Console.WriteLine($"|| {result.FullName,-25} || {result.Score,-20} || {result.Diagnosis,-25} ||");
        }
    }
}