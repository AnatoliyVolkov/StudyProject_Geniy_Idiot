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
        var countRightAnswers = 0;
        var questions = QuestionsStorage.GetQuestions(_questionPath);
        var questionOrder = DiagnosticTestResources.ShuffleTestQuestions(questions.Count);

        for (var i = 0 ; i < questions.Count ; i++)
        {
            var questionIndex = questionOrder[i];
            Console.WriteLine($"\nВопрос номер: {i + 1}");
            Console.WriteLine(questions[questionIndex]._Question);

            var userInput = Console.ReadLine();
            countRightAnswers += User.RightAnswer(userInput, User.UserName, questionIndex, _questionPath);
        }
        return countRightAnswers;
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
                var results = UserResultStorage.LoadFromFile(_testPath);
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}