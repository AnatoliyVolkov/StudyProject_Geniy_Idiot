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
        var questions = QuestionsStorage.GetQuestions(_questionPath);
        var diagnose = DiagnosticTestResources.GetDiagnose(score, questions.Count);
        UserResultStorage.SaveResult(_testPath, User.userFullName, score, diagnose);
        Console.WriteLine(string.Format(Messages.TestResult, User.UserName, score));
        Console.WriteLine(string.Format(Messages.DiagnosisResult, diagnose));
    }

    public void ShowAllResults()
    {
        Console.WriteLine(Messages.ViewAllResults);
        var userService = new UserService();
        if (userService.GetUserConfirm(""))
        {
            try
            {
                var lines = FileProvider.Read(_testPath);

                if (lines.Count <= 2)
                {
                    Console.WriteLine("Результаты тестирования отсутствуют.");
                    return;
                }
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при загрузке результатов: {ex.Message}");
            }
        }
    }
}
