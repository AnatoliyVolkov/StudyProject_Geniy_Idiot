using GeniyIdiotClassLibrary;

namespace GeniyIdiotWinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            var countRightAnswers = 0;
            var questions = QuestionsStorage.GetQuestions();
            var questionOrder = DiagnosticTestResources.ShuffleTestQuestions();
            for (var i = 0 ; i < questions.Count ; i++)
            {
                var questionIndex = questionOrder[i];

                questionNumberLabel.Text = $"\nВопрос номер: {i + 1}";
                questionTextLabel.Text = QuestionsStorage.GetQuestions()[questionIndex]._Question;
                 countRightAnswers += User.RightAnswer(questionIndex);
            }
        }
        private void userAnswerTextBox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}






