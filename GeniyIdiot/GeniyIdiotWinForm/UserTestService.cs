using GeniyIdiotClassLibrary;


namespace GeniyIdiotWinForm
{
    public class UserTestService
    {
        private UserTestSession _session;

        public UserTestService()
        {
            _session = new UserTestSession();
        }

        public (bool success, string errorMessage) ProcessNextStep(string userInput)
        {
            if (_session.CurrentStep < _session.UserInfoSteps.Length)
            {
                var validationResult = ValidationHelper.CheckUsernameEntry(userInput);
                if (!validationResult._Success)
                {
                    return (false, validationResult.ErrorMessage + "\n" + Messages.NextTry);
                }

                switch (_session.CurrentStep)
                {
                    case 0:
                        User.UserSurname = validationResult.Value;
                        break;
                    case 1:
                        User.UserName = validationResult.Value;
                        break;
                    case 2:
                        User.UserPatronymic = validationResult.Value;
                        break;
                }

                _session.CurrentStep++;

                if (_session.CurrentStep >= _session.UserInfoSteps.Length)
                {
                    StartTest();
                }

                return (true, null);
            }

            return (false, "Неизвестное состояние");
        }

        public (bool success, string errorMessage) ProcessAnswer(string userAnswer)
        {
            if (string.IsNullOrEmpty(userAnswer))
            {
                return (false, Messages.EmptyNumber);
            }

            if (_session.CurrentQuestionIndex >= _session.ShuffledQuestionIndexes.Count)
            {
                return (false, "Тест уже завершен");
            }

            var questionIndex = _session.ShuffledQuestionIndexes[_session.CurrentQuestionIndex];
            var validationResult = User.RightAnswerSafe(userAnswer, User.UserName, questionIndex, "questions.txt");

            if (validationResult.success)
            {
                if (validationResult.result == 1)
                {
                    _session.CorrectAnswersCount++;
                }

                _session.CurrentQuestionIndex++;

                if (_session.CurrentQuestionIndex >= _session.ShuffledQuestionIndexes.Count)
                {
                    FinishTest();
                }

                return (true, null);
            }
            else
            {
                return (false, validationResult.error);
            }
        }

        private void StartTest()
        {
            _session.IsTestStarted = true;
            _session.Questions = QuestionsStorage.GetQuestions("questions.txt");
            _session.ShuffledQuestionIndexes = DiagnosticTestResources.ShuffleTestQuestions(_session.Questions.Count);
        }

        private void FinishTest()
        {
            var diagnose = DiagnosticTestResources.GetDiagnose(_session.CorrectAnswersCount, _session.Questions.Count);

            string resultsPath = "test_results.txt";
            UserResultStorage.SaveResult(resultsPath, User.userFullName, _session.CorrectAnswersCount, diagnose);

            _session.IsTestFinished = true;
            _session.FinalDiagnose = diagnose;
        }

        public State GetState()
        {
            var state = new State();

            if (!_session.IsTestStarted && !_session.IsTestFinished)
            {
                
                state.Message = Messages.WelcomeTest;
                state.InputPrompt = _session.UserInfoSteps[_session.CurrentStep];
                state.ShowNextButton = true;
                state.ShowInputTextBox = true;
                state.ClearInput = true;
            }
            else if (_session.IsTestStarted && !_session.IsTestFinished)
            {
                
                state.Message = string.Format(Messages.WelcomeUser, User.UserName);
                state.InputPrompt = "Введите ответ на вопрос:";
                state.ShowSubmitButton = true;
                state.ShowInputTextBox = true;
                state.ShowQuestionLabel = true;
                state.ClearInput = true;

                if (_session.CurrentQuestionIndex < _session.ShuffledQuestionIndexes.Count)
                {
                    var questionIndex = _session.ShuffledQuestionIndexes[_session.CurrentQuestionIndex];
                    var question = _session.Questions[questionIndex];
                    state.QuestionText = $"Вопрос {_session.CurrentQuestionIndex + 1} из {_session.Questions.Count}\n\n{question._Question}";
                    state.ProgressText = $"Прогресс: {_session.CurrentQuestionIndex + 1}/{_session.Questions.Count}";
                }
            }
            else if (_session.IsTestFinished)
            {
               
                state.Message = string.Format(Messages.Thanks, User.UserName);
                state.QuestionText = string.Format(Messages.TestResult, User.UserName, _session.CorrectAnswersCount);
                state.InputPrompt = string.Format(Messages.DiagnosisResult, _session.FinalDiagnose);
                state.ShowRestartButton = true;
                state.ShowExitButton = true;
                state.ShowInputTextBox = false;
                state.ShowQuestionLabel = true;
            }

            return state;
        }

        public string GetUserName() => User.UserName;

        public void RestartTest()
        {
            _session = new UserTestSession();
            StartTest();
        }
    }
}