using GeniyIdiotClassLibrary;
using System.IO;
using static GeniyIdiotWinForm.Program;


namespace GeniyIdiotWinForm
{
    public partial class UserForm : Form
    {
        private UserTestService _userTestService;
        private StartForm startForm;

        //public UserForm()
        //{
        //    InitializeComponent();
        //}

        public UserForm(StartForm startForm)
        {
            InitializeComponent();
            this.startForm = startForm;
            this.FormClosing += UserForm_FormClosing;
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            _userTestService = new UserTestService();
            UpdateFormFromState();
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var input = userInputTextBox.Text.Trim();

            var result = _userTestService.ProcessUserInfo(input);

            if (result.success)
            {
                UpdateFormFromState();
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

            userInputTextBox.Focus();
        }

        private void submitAnswerButton_Click(object sender, EventArgs e)
        {
            var userAnswer = userInputTextBox.Text.Trim();
            var result = _userTestService.ProcessAnswer(userAnswer);
            if (result.success)
            {
                UpdateFormFromState();
            }
            else
            {
                MessageBox.Show(result.errorMessage, "Ошибка ввода",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userInputTextBox.Focus();
            }
        }

        private void restartAppButton_Click(object sender, EventArgs e)
        {
            this.FormClosing -= UserForm_FormClosing;
            Application.Restart();
        }

        private void restartTestButton_Click(object sender, EventArgs e)
        {
            _userTestService.RestartTest();
            UpdateFormFromState();
        }

        private void viewResultsButton_Click(object sender, EventArgs e)
        {
            ShowResultsTable();
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
                if (e.CloseReason == CloseReason.UserClosing)
                {
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
                        }
                    }
                }
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}

