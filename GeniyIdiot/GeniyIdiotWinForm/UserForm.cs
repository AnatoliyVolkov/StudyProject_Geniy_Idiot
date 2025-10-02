using GeniyIdiotClassLibrary;
using System.IO;


namespace GeniyIdiotWinForm
{
    public partial class UserForm : Form
    {
        private int currentStep = 0;
        private int currentQuestionIndex = 0;
        private int correctAnswersCount = 0;
        private List<Question> questions;
        private List<int> shuffledQuestionIndexes;

        private readonly string[] userInfoSteps =
        {
            Messages.EnterLastName,
            Messages.EnterFirstName,
            Messages.EnterPatronymic
        };

        public UserForm()
        {
            InitializeComponent();
        }

        private void UserForm_Load(object sender, EventArgs e)
        {
            infoUserLabel.Text = Messages.WelcomeTest;
            InitializeTest();
            UpdateUserInfoStep();
        }

        private void InitializeTest()
        {
            string questionsPath = "questions.txt";
            QuestionsStorage.CreateFirst(questionsPath);
            questions = QuestionsStorage.GetQuestions(questionsPath);
            shuffledQuestionIndexes = DiagnosticTestResources.ShuffleTestQuestions(questions.Count);
        }

        private void UpdateUserInfoStep()
        {
            if (currentStep < userInfoSteps.Length)
            {
                infoUserInputLabel.Text = userInfoSteps[currentStep];
                userInputTextBox.Text = "";
                userInputTextBox.Focus();

                nextButton.Visible = true;
                submitAnswerButton.Visible = false;
                userInputTextBox.Visible = true;
                questionLabel.Visible = false;

                restartAppButton.Visible = false;
                restartTestButton.Visible = false;
                exitButton.Visible = false;
                viewResultsButton.Visible = false;
            }
            else
            {
                StartTest();
            }
        }

        private void StartTest()
        {
            infoUserLabel.Text = string.Format(Messages.WelcomeUser, User.UserName);
            infoUserInputLabel.Text = "Введите ответ на вопрос:";

            nextButton.Visible = false;
            submitAnswerButton.Visible = true;
            userInputTextBox.Visible = true;
            questionLabel.Visible = true;
            userInputTextBox.Text = "";
            userInputTextBox.Focus();

            // Скрываем кнопки управления
            restartAppButton.Visible = false;
            restartTestButton.Visible = false;
            exitButton.Visible = false;
            viewResultsButton.Visible = false;

            ShowCurrentQuestion();
        }

        private void ShowCurrentQuestion()
        {
            if (currentQuestionIndex < shuffledQuestionIndexes.Count)
            {
                var questionIndex = shuffledQuestionIndexes[currentQuestionIndex];
                var question = questions[questionIndex];

                questionLabel.Text = $"Вопрос {currentQuestionIndex + 1} из {questions.Count}\n\n{question._Question}";
            }
            else
            {
                FinishTest();
            }
        }

        private void nextButton_Click(object sender, EventArgs e)
        {
            var input = userInputTextBox.Text.Trim();

            var validationResult = ValidationHelper.CheckUsernameEntry(input);
            if (!validationResult._Success)
            {
                MessageBox.Show(validationResult.ErrorMessage + "\n" + Messages.NextTry,
                              "Ошибка ввода", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userInputTextBox.Focus();
                return;
            }

            switch (currentStep)
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

            currentStep++;
            UpdateUserInfoStep();
        }

        private void submitAnswerButton_Click(object sender, EventArgs e)
        {
            var userAnswer = userInputTextBox.Text.Trim();

            if (string.IsNullOrEmpty(userAnswer))
            {
                MessageBox.Show(Messages.EmptyNumber, "Внимание",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var questionIndex = shuffledQuestionIndexes[currentQuestionIndex];
            var validationResult = User.RightAnswerSafe(userAnswer, User.UserName, questionIndex, "questions.txt");

            if (validationResult.success)
            {
                if (validationResult.result == 1)
                {
                    correctAnswersCount++;
                }

                currentQuestionIndex++;
                userInputTextBox.Text = "";
                userInputTextBox.Focus();
                ShowCurrentQuestion();
            }
            else
            {
                MessageBox.Show(validationResult.error, "Ошибка ввода",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                userInputTextBox.Focus();
            }
        }

        private void FinishTest()
        {
            var diagnose = DiagnosticTestResources.GetDiagnose(correctAnswersCount, questions.Count);

            string resultsPath = "test_results.txt";
            UserResultStorage.SaveResult(resultsPath, User.userFullName, correctAnswersCount, diagnose);

            infoUserLabel.Text = string.Format(Messages.Thanks, User.UserName);
            questionLabel.Text = string.Format(Messages.TestResult, User.UserName, correctAnswersCount);
            infoUserInputLabel.Text = string.Format(Messages.DiagnosisResult, diagnose);

            userInputTextBox.Visible = false;
            submitAnswerButton.Visible = false;

            // ПОКАЗЫВАЕМ кнопки управления
            restartAppButton.Visible = true;
            restartTestButton.Visible = true;
            exitButton.Visible = true;
            viewResultsButton.Visible = true;

            MessageBox.Show(
                $"Тест завершен!\n\n" +
                $"{string.Format(Messages.TestResult, User.UserName, correctAnswersCount)}\n" +
                $"{string.Format(Messages.DiagnosisResult, diagnose)}",
                "Результаты теста",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        // КНОПКИ УПРАВЛЕНИЯ
        private void restartAppButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Перезапустить приложение? Текущий прогресс будет потерян.",
                "Перезапуск приложения",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Restart();
            }
        }

        private void restartTestButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Начать тест заново?",
                "Новое тестирование",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                // Сброс теста
                currentStep = 0;
                currentQuestionIndex = 0;
                correctAnswersCount = 0;
                shuffledQuestionIndexes = DiagnosticTestResources.ShuffleTestQuestions(questions.Count);

                UpdateUserInfoStep();

                // Скрываем кнопки управления
                restartAppButton.Visible = false;
                restartTestButton.Visible = false;
                exitButton.Visible = false;
                viewResultsButton.Visible = false;
            }
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show(
                "Выйти из приложения?",
                "Выход",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void viewResultsButton_Click(object sender, EventArgs e)
        {
            ShowResultsTable();
        }

        private void ShowResultsTable()
        {
            try
            {
                string resultsPath = "test_results.txt";

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
    }
}