using GeniyIdiotClassLibrary;

namespace GeniyIdiotConsoleApp;

public class TestService
{
    private readonly string _questionPath;
    private readonly string _testPath;

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
            Console.WriteLine($"\nВопрос номер: {i + 1}");
            var currentQuestionIndex = questionOrder[i];
            Console.WriteLine(testEngine._Question[currentQuestionIndex]._Question);

            var userInput = Console.ReadLine();
            var answerResult = testEngine.ProcessAnswer(userInput);

            if (!answerResult.success)
            {
                Console.WriteLine(answerResult.error);
                i--;
            }
        }
        return testEngine.CorrectAnswersCount;
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
        Console.WriteLine("|| {0,-25} || {1,-20} || {2,-25} ||", "ФОИ","Правильных ответов", "Результаты теста");
        Console.WriteLine(new string('=', 95));

        foreach (var result in results)
        {
            Console.WriteLine($"|| {result.FullName,-25} || {result.Score,-20} || {result.Diagnosis,-25} ||");
        }
    }
}