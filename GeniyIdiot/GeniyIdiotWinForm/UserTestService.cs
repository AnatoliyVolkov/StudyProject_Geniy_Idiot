using GeniyIdiotClassLibrary;


namespace GeniyIdiotWinForm
{
    public class UserTestService
    {
        private TestEngine _testEngine;
        private int _currentUserInfoStep = 0;
        private string[] _userInfoSteps =
    {
        Messages.EnterLastName,
        Messages.EnterFirstName,
        Messages.EnterPatronymic
    };
        public UserTestService()
        {
            _testEngine = new TestEngine(QuestionsStorage.QuestionsFilePath);
        }

        public (bool success, string errorMessage) ProcessUserInfo(string userInput)
        {
            var validationResult = ValidationHelper.CheckUsernameEntry(userInput);
            if (!validationResult._Success)
                return (false, validationResult.ErrorMessage);

            switch (_currentUserInfoStep)
            {
                case 0: User.UserSurname = validationResult.Value; break;
                case 1: User.UserName = validationResult.Value; break;
                case 2: User.UserPatronymic = validationResult.Value; break;
            }

            _currentUserInfoStep++;
            return (true, null);
        }

        public (bool success, string errorMessage) ProcessAnswer(string userAnswer)
        {
            var answerResult = _testEngine.ProcessAnswer(userAnswer);
            if (answerResult.success && answerResult.testFinished)
            {
                SaveTestResults();
            }
            return (answerResult.success, answerResult.error);
        }

        public State GetState()
        {
            var state = new State();

            if (_currentUserInfoStep < _userInfoSteps.Length)
            {
                state.Message = Messages.WelcomeTest;
                state.InputPrompt = _userInfoSteps[_currentUserInfoStep];
                state.ShowNextButton = true;
                state.ShowInputTextBox = true;
                state.ClearInput = true;
            }
            else if (!_testEngine.IsTestFinished)
            {
                state.Message = string.Format(Messages.WelcomeUser, User.UserName);
                state.InputPrompt = "Введите ответ на вопрос:";
                state.ShowSubmitButton = true;
                state.ShowInputTextBox = true;
                state.ShowQuestionLabel = true;
                state.ClearInput = true;

                var questionIndex = _testEngine.shuffledQuestionIndexes[_testEngine.CurrentQuestionIndex];
                var question = _testEngine._Question[questionIndex];
                state.QuestionText = $"Вопрос {_testEngine.CurrentQuestionIndex + 1} из {_testEngine._Question.Count}\n\n{question._Question}";
            }
            else
            {
                state.Message = string.Format(Messages.Thanks, User.UserName);
                state.QuestionText = string.Format(Messages.TestResult, User.UserName, _testEngine.CorrectAnswersCount);
                state.InputPrompt = string.Format(Messages.DiagnosisResult,
                    DiagnosticTestResources.GetDiagnose(_testEngine.CorrectAnswersCount, _testEngine._Question.Count));
                state.ShowRestartButton = true;
                state.ShowExitButton = true;
                state.ShowInputTextBox = false;
            }

            return state;
        }

        private void SaveTestResults()
        {
            try
            {
                string resultsPath = UserResultStorage.ResultsFilePath;
                var diagnose = DiagnosticTestResources.GetDiagnose(_testEngine.CorrectAnswersCount, _testEngine._Question.Count);
                UserResultStorage.SaveResult(resultsPath, User.userFullName, _testEngine.CorrectAnswersCount, diagnose);
            }
            catch (Exception ex)
            { throw new Exception($"Ошибка сохранения результатов теста"); }
        }

        public void RestartTest()
        {
            _testEngine = new TestEngine(QuestionsStorage.QuestionsFilePath);
            _currentUserInfoStep = 0;
        }
    }
}