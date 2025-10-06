using GeniyIdiotClassLibrary;
using static GeniyIdiotWinForm.Program;

namespace GeniyIdiotWinForm
{
    public partial class AdminForm : Form
    {
        private StartForm _startForm;
        private string _currentAction;
        private string _questionsPath = QuestionsStorage.QuestionsFilePath;
        private string _adminFilePath = AdminStorage.AdminFilePath;
        private string _tempQuestion;
        private string _tempLogin;

        public AdminForm()
        {
            InitializeComponent();
        }

        public AdminForm(StartForm startForm)
        {
            InitializeComponent();
            _startForm = startForm;
            try
            {
                if (!FileProvider.Exists(_questionsPath))
                {
                    QuestionsStorage.CreateFirst(_questionsPath);
                }

                if (!FileProvider.Exists(_adminFilePath))
                {
                    var adminStorage = new AdminStorage(_adminFilePath);
                }

                if (!FileProvider.Exists(UserResultStorage.ResultsFilePath))
                {
                    FileProvider.Create(UserResultStorage.ResultsFilePath, "ФИО||Правильные ответы||Диагноз");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации файлов: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AdminForm_Load(object sender, EventArgs e)
        {
            InitializeAdminMenu();
        }

        private void InitializeAdminMenu()
        {
            adminInfoLabel.Text = Messages.AdminMode;
            adminPromptLabel.Text = Messages.ChooseAction;
            adminListBox.Items.Clear();

            string[] menuItems = {
                Messages.AdminMenu.Split('\n')[0].Trim(),
                Messages.AdminMenu.Split('\n')[1].Trim(),
                 Messages.AdminMenu.Split('\n')[2].Trim(),
                 Messages.AdminMenu.Split('\n')[3].Trim(),
                 Messages.AdminMenu.Split('\n')[4].Trim(),
                 Messages.AdminMenu.Split('\n')[5].Trim(),
                 Messages.AdminMenu.Split('\n')[6].Trim()
            };

            foreach (var item in menuItems)
            {
                adminListBox.Items.Add(item);
            }

            adminInputTextBox.Visible = false;
            adminListBox.Visible = true;
            adminPromptLabel.Visible = true;
            adminActionButton.Text = "Выполнить";
        }

        private void adminActionButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_currentAction))
            {
                ProcessMenuSelection();
            }
            else
            {
                ProcessAdminAction();
            }
        }

        private void ProcessMenuSelection()
        {
            if (adminListBox.SelectedItem == null)
            {
                MessageBox.Show(Messages.InvalidChoice, "Внимание",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedItem = adminListBox.SelectedItem.ToString();
            var choice = selectedItem.Split('.')[0].Trim();

            var result = AdminService.GetMenu(choice, _questionsPath);

            if (!result.success)
            {
                MessageBox.Show(result.message, "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (result.message == "exit_to_main")
            {
                ReturnToMainMenu();
                return;
            }

            if (result.message == Messages.ExitAdministrator)
            {
                Close();
                return;
            }

            _currentAction = choice;
            adminInfoLabel.Text = result.message;
            adminListBox.Visible = false;

            switch (choice)
            {
                case "1":
                    ShowQuestions();
                    break;
                case "2":
                    PrepareAddQuestion();
                    break;
                case "3":
                    PrepareDeleteQuestion();
                    break;
                case "4":
                    ShowResults();
                    break;
                case "5":
                    PrepareRegisterAdmin();
                    break;
                case "6":
                    Application.Exit();
                    break;
            }
        }

        private void ProcessAdminAction()
        {
            var input = adminInputTextBox.Text.Trim();
            switch (_currentAction)
            {
                case "2":
                case "2_question":
                case "2_answer":
                    AddQuestion(input);
                    break;
                case "3":
                    DeleteQuestion(input);
                    break;
                case "5":
                case "5_login":
                case "5_password":
                    RegisterAdmin(input);
                    break;
            }
        }

        private void ShowQuestions()
        {
            try
            {
                if (!FileProvider.Exists(_questionsPath))
                {
                    QuestionsStorage.CreateFirst(_questionsPath);
                }

                var questions = QuestionsStorage.GetQuestions(_questionsPath);
                adminListBox.Items.Clear();

                if (questions.Count == 0)
                {
                    adminListBox.Items.Add("Нет доступных вопросов.");
                }
                else
                {
                    for (int i = 0 ; i < questions.Count ; i++)
                    {
                        adminListBox.Items.Add($"{i + 1}. {questions[i]._Question} (Ответ: {questions[i].Answer})");
                    }
                }

                adminListBox.Visible = true;
                adminInputTextBox.Visible = false;
                adminActionButton.Text = "Назад";
                adminActionButton.Visible = false;
                adminPromptLabel.Visible = false;
                adminPromptLabel.Visible = false;
                adminInfoLabel.Visible = false;
                adminPromptLabel.Visible = false;
                _currentAction = "back";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке вопросов: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PrepareAddQuestion()
        {
            try
            {
                if (!FileProvider.Exists(_questionsPath))
                {
                    QuestionsStorage.CreateFirst(_questionsPath);
                }

                adminPromptLabel.Text = Messages.EnterQuestion;
                adminInputTextBox.Visible = true;
                adminInputTextBox.Text = "";
                adminActionButton.Text = "Далее";
                _currentAction = "2_question";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подготовке добавления вопроса: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddQuestion(string input)
        {
            if (_currentAction == "2_question")
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    MessageBox.Show(Messages.QuestionEmpty, "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                _tempQuestion = input;
                adminPromptLabel.Text = Messages.EnterAnswer;
                adminInputTextBox.Text = "";
                _currentAction = "2_answer";
            }
            else if (_currentAction == "2_answer")
            {
                var result = AdminService.AddQuestion(
                    () => (_tempQuestion, input),
                    _questionsPath
                );

                if (result.success)
                {
                    MessageBox.Show(Messages.QuestionAdded, "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetToMenu();
                }
                else
                {
                    MessageBox.Show(result.message, "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PrepareDeleteQuestion()
        {
            try
            {
                if (!FileProvider.Exists(_questionsPath))
                {
                    QuestionsStorage.CreateFirst(_questionsPath);
                }

                var questions = QuestionsStorage.GetQuestions(_questionsPath);
                adminListBox.Items.Clear();

                if (questions.Count == 0)
                {
                    adminListBox.Items.Add("Нет вопросов для удаления.");
                }
                else
                {
                    for (int i = 0 ; i < questions.Count ; i++)
                    {
                        adminListBox.Items.Add($"{i + 1}. {questions[i]._Question} (Ответ: {questions[i].Answer})");
                    }
                }

                adminListBox.Visible = true;
                adminPromptLabel.Text = Messages.EnterLineNumber;
                adminInputTextBox.Visible = true;
                adminInputTextBox.Text = "";
                adminActionButton.Text = "Удалить";
                _currentAction = "3";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке вопросов: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DeleteQuestion(string input)
        {
            if (int.TryParse(input, out int lineNumber))
            {
                var result = AdminService.DeleteQuestion(() => lineNumber, _questionsPath);

                if (result.success)
                {
                    MessageBox.Show(Messages.QuestionDeleted, "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetToMenu();
                }
                else
                {
                    MessageBox.Show(result.message, "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(Messages.InvalidQuestionNumber, "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowResults()
        {
            try
            {
                var results = UserResultStorage.LoadFromFile(UserResultStorage.ResultsFilePath);
                adminListBox.Items.Clear();

                if (results.Count == 0)
                {
                    adminListBox.Items.Add("Результатов тестирования пока нет.");
                }
                else
                {
                    foreach (var result in results)
                    {
                        adminListBox.Items.Add($"{result.FullName} - {result.Score} правильных - {result.Diagnosis}");
                    }
                }

                adminListBox.Visible = true;
                adminInputTextBox.Visible = false;
                adminActionButton.Text = "Назад";
                adminActionButton.Visible = false;
                adminPromptLabel.Visible = false;
                adminPromptLabel.Visible = false;
                adminInfoLabel.Visible = false;
                adminPromptLabel.Visible = false;
                _currentAction = "back";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке результатов: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminInputTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                adminActionButton.PerformClick();
            }
        }

        private void PrepareRegisterAdmin()
        {
            adminPromptLabel.Text = Messages.EnterLogin;
            adminInputTextBox.Visible = true;
            adminInputTextBox.Text = "";
            adminActionButton.Text = "Далее";
            _currentAction = "5_login";
        }

        private void RegisterAdmin(string input)
        {
            if (_currentAction == "5_login")
            {
                var loginValidation = ValidationHelper.CheckUsernameEntry(input);
                if (!loginValidation._Success)
                {
                    MessageBox.Show(loginValidation.ErrorMessage, "Ошибка ввода",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    adminInputTextBox.Focus();
                    return;
                }

                _tempLogin = loginValidation.Value.ToLower();
                adminPromptLabel.Text = Messages.EnterPassword;
                adminInputTextBox.Text = "";
                adminInputTextBox.Focus();
                adminActionButton.Text = "Зарегистрировать";
                _currentAction = "5_password";
                Refresh();
            }
            else if (_currentAction == "5_password")
            {
                var result = AdminService.RegisterAdmin(
                    () => (_tempLogin, input),
                    _adminFilePath
                );

                if (result.success)
                {
                    MessageBox.Show(result.message, "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ResetToMenu();
                }
                else
                {
                    MessageBox.Show(result.message, "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                    adminInputTextBox.Focus();
                }
            }
        }

        private void ResetToMenu()
        {
            _currentAction = null;
            _tempQuestion = null;
            _tempLogin = null;
            adminActionButton.Visible = true;
            adminPromptLabel.Visible = true;
            adminPromptLabel.Visible = true;
            adminInfoLabel.Visible = true; 
            adminPromptLabel.Visible = true;
            InitializeAdminMenu();
        }

        private void adminBackButton_Click(object sender, EventArgs e)
        {
            if (_currentAction == "back")
            {
                ResetToMenu();
            }
            else
            {
                ReturnToMainMenu();
            }
        }

        private void ReturnToMainMenu()
        {
            if (_startForm != null)
            {
                AppState.AdminFormHidden = true;
                _startForm.Show();
                this.Hide();
            }
            else
            {
                var startForm = new StartForm();
                AppState.AdminFormHidden = true;
                startForm.Show();
                this.Hide();
            }
        }

        private void AdminForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
                                           MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    if (_startForm != null)
                    {
                        AppState.AdminFormHidden = true;
                        _startForm.Show();
                    }
                    else
                    {
                        Application.Exit();
                    }
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }
    }
}