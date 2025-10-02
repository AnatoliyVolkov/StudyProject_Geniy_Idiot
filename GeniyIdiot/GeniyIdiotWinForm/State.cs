namespace GeniyIdiotWinForm
{
    public class State
    {
        public string Message { get; set; } = "";
        public string InputPrompt { get; set; } = "";
        public string QuestionText { get; set; } = "";
        public string ProgressText { get; set; } = "";
        public bool ShowNextButton { get; set; } = false;
        public bool ShowSubmitButton { get; set; } = false;
        public bool ShowInputTextBox { get; set; } = false;
        public bool ShowQuestionLabel { get; set; } = false;
        public bool ShowRestartButton { get; set; } = false;
        public bool ShowExitButton { get; set; } = false;
        public bool ClearInput { get; set; } = false;
    }
}