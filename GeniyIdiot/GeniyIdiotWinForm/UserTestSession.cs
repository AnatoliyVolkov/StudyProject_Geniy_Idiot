using GeniyIdiotClassLibrary;


namespace GeniyIdiotWinForm
{
    public class UserTestSession
    {
        public int CurrentStep { get; set; } = 0;
        public int CurrentQuestionIndex { get; set; } = 0;
        public int CorrectAnswersCount { get; set; } = 0;
        public bool IsTestStarted { get; set; } = false;
        public bool IsTestFinished { get; set; } = false;
        public string FinalDiagnose { get; set; } = "";
        public List<Question> Questions { get; set; } = new List<Question>();
        public List<int> ShuffledQuestionIndexes { get; set; } = new List<int>();

        public string[] UserInfoSteps { get; } =
        {
            Messages.EnterLastName,
            Messages.EnterFirstName,
            Messages.EnterPatronymic
        };
    }
}