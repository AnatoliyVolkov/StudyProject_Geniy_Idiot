
namespace GeniyIdiotClassLibrary
{
    public class TestEngine
    {
        public  int CurrentQuestionIndex { get; set; } = 0;
        public  int CorrectAnswersCount { get; set; }
        public  List<int> shuffledQuestionIndexes { get; set; }
        public  List<Question> _Question { get; set; }
        public string QuestionsPath { get; set; }
        public bool IsTestFinished => CurrentQuestionIndex >= _Question.Count;


        public TestEngine(string questionsPath)
        {
            this.QuestionsPath = questionsPath;
            this._Question = QuestionsStorage.GetQuestions(questionsPath);
            this.shuffledQuestionIndexes = DiagnosticTestResources.ShuffleTestQuestions(_Question.Count);
        }

        public (bool success, int result, string error, bool testFinished) ProcessAnswer(string userInput)
        {
            if (CurrentQuestionIndex >= _Question.Count)
                return (false, 0, "Тест завершен", true);
            var questionIndex = shuffledQuestionIndexes[CurrentQuestionIndex];
            var answerResult = User.RightAnswerSafe(userInput, User.UserName, questionIndex, QuestionsPath);
            if (answerResult.success)
            {
                CorrectAnswersCount += answerResult.result;
                CurrentQuestionIndex++;
                bool testFinished = CurrentQuestionIndex >= _Question.Count;
                return (true, answerResult.result, null, testFinished);
            }
            else
            {
                return (false, 0, answerResult.error, false);
            }
        }
    }
}
