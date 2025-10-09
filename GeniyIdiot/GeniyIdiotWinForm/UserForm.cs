using GeniyIdiotClassLibrary;
using System.IO;
using static GeniyIdiotWinForm.Program;


namespace GeniyIdiotWinForm
{
    public partial class UserForm : Form
    {
        private UserTestService _userTestService;
        private StartForm startForm;
        private TimerService _timerService;
        private int timerForQuestion = 10;

        public UserForm(StartForm startForm)
        {
            InitializeComponent();
            this.startForm = startForm;
            this.FormClosing += UserForm_FormClosing;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            _userTestService = new UserTestService();
            timerLable.Hide();
            InitializeTimer();
            UpdateFormFromState();
        }

        private void InitializeTimer()
        {
            _timerService = new TimerService(timerForQuestion, OnTimeExpired, OnTimerTick);
        }

        private void OnTimerTick(int timeRemaining)
        {
            if (infoUserLabel.InvokeRequired)
            {
                infoUserLabel.Invoke(new Action<int>(OnTimerTick), timeRemaining);
                return;
            }

            var currentText = infoUserLabel.Text;
            var baseMessage = GetMessageState();

            timerLable.Show();
            timerLable.Text = $"Осталось: {timeRemaining} сек.";
        }

        private string GetMessageState()
        {
            var state = _userTestService?.GetState();
            if (state != null && !string.IsNullOrEmpty(state.Message))
            {
                return state.Message;
            }
            return "";
        }

        private void OnTimeExpired()
        {
            MessageBox.Show("Время вышло! Ответ не засчитан.", "Время истекло",
                   MessageBoxButtons.OK, MessageBoxIcon.Warning);

            var result = _userTestService.ProcessAnswer("", true);
            if (result.success)
            {
                UpdateFormFromState();
                StartTimerIfQuestion();
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var input = userInputTextBox.Text.Trim();
            var result = _userTestService.ProcessUserInfo(input);

            if (result.success)
            {
                UpdateFormFromState();
                StartTimerIfQuestion();
            }
            else
            {
                MessageBox.Show(result.errorMessage, "Ошибка ввода",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userInputTextBox.Focus();
            }
        }

        private void UpdateFormFromState()
        {
            var state = _userTestService.GetState();
        


            infoUserLabel.Text = state.Message;
            infoUserInputLabel.Text = state.InputPrompt;
            questionLabel.Text = state.QuestionText;
            nextButton.Visible = state.ShowNextButton;
            submitAnswerButton.Visible = state.ShowSubmitButton;
            userInputTextBox.Visible = state.ShowInputTextBox;
            questionLabel.Visible = state.ShowQuestionLabel;
            restartAppButton.Visible = state.ShowRestartButton;
            restartTestButton.Visible = state.ShowRestartButton;
            exitButton.Visible = state.ShowExitButton;
            viewResultsButton.Visible = state.ShowExitButton;

            if (state.ClearInput)
                userInputTextBox.Text = "";
            timerLable.Visible = state.ShowQuestionLabel && state.ShowSubmitButton && state.ShowInputTextBox;

            userInputTextBox.Focus();
        }

        private void submitAnswerButton_Click(object sender, EventArgs e)
        {
            var userAnswer = userInputTextBox.Text.Trim();
            

            var result = _userTestService.ProcessAnswer(userAnswer, false);
            if (result.success)
            {
                _timerService.Stop();
                UpdateFormFromState();
                StartTimerIfQuestion();
            }
            else
            {
                MessageBox.Show(result.errorMessage, "Ошибка ввода",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userInputTextBox.Focus();
                userInputTextBox.SelectAll();
            }
        }

        private void StartTimerIfQuestion()
        {
            var state = _userTestService.GetState();

            if (state.ShowQuestionLabel && state.ShowSubmitButton && state.ShowInputTextBox && !string.IsNullOrEmpty(state.QuestionText))
            {
                _timerService.Restart();
            }
            else
            {
                _timerService.Stop();
            }
        }

        private void restartAppButton_Click(object sender, EventArgs e)
        {
            this.FormClosing -= UserForm_FormClosing;
            _timerService.Dispose();
            Application.Restart();
        }

        private void restartTestButton_Click(object sender, EventArgs e)
        {
            _timerService.Stop();
            _userTestService.RestartTest();
            UpdateFormFromState();
        }

        private void viewResultsButton_Click(object sender, EventArgs e)
        {
            _timerService.Stop();
            ShowResultsTable();
            StartTimerIfQuestion();
        }

        private void ShowResultsTable()
        {
            try
            {
                string resultsPath = UserResultStorage.ResultsFilePath;

                if (!File.Exists(resultsPath))
                {
                    MessageBox.Show("Файл с результатами не найден.", "Результаты",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var results = UserResultStorage.LoadFromFile(resultsPath);

                if (results.Count == 0)
                {
                    MessageBox.Show("Результатов тестирования пока нет.", "Результаты",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                var tableForm = new Form()
                {
                    Text = "Результаты тестирования",
                    Size = new Size(600, 400),
                    StartPosition = FormStartPosition.CenterParent
                };

                var dataGridView = new DataGridView()
                {
                    Dock = DockStyle.Fill,
                    ReadOnly = true,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                    AllowUserToAddRows = false,
                    RowHeadersVisible = false
                };
                dataGridView.Columns.Add("FullName", "ФИО");
                dataGridView.Columns.Add("Score", "Правильные ответы");
                dataGridView.Columns.Add("Diagnosis", "Диагноз");

                foreach (var result in results)
                {
                    dataGridView.Rows.Add(result.FullName, result.Score, result.Diagnosis);
                }

                var closeButton = new Button()
                {
                    Text = "Закрыть",
                    Size = new Size(100, 30),
                    Location = new Point(250, 320)
                };
                closeButton.Click += (s, e) => tableForm.Close();

                tableForm.Controls.Add(dataGridView);
                tableForm.Controls.Add(closeButton);
                tableForm.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке результатов: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void userInputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (nextButton.Visible)
                {
                    nextButton.PerformClick();
                }
                else if (submitAnswerButton.Visible)
                {
                    submitAnswerButton.PerformClick();
                }
            }
        }

        private void UserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                _timerService.Dispose();

                if (AppState.AdminFormHidden)
                {
                    Environment.Exit(0);
                }
                else
                {
                    var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
                                                MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        e.Cancel = true;
                        StartTimerIfQuestion();
                    }
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            _timerService.Dispose();
            Application.Exit();
        }

    }
}

