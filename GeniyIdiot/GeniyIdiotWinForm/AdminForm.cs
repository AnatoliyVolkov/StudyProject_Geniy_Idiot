using GeniyIdiotClassLibrary;
using static GeniyIdiotWinForm.Program;

namespace GeniyIdiotWinForm
{
    public partial class AdminForm : Form
    {
        private StartForm _startForm;
        private AdminAction _currentAction;
        private string _questionsPath = QuestionsStorage.QuestionsFilePath;
        private string _adminFilePath = AdminStorage.AdminFilePath;
        private string _tempQuestion;
        private string _tempLogin;

        public enum AdminAction
        {
            None,
            ViewQuestions,
            AddQuestionText,
            AddQuestionAnswer,
            ViewResults,
            RegisterAdminLogin,
            RegisterAdminPassword,
            Back
        }

        public enum MenuChoice
        {
            ViewQuestions = 1,
            AddQuestion = 2,
            ViewResults = 3,
            RegisterAdmin = 4,
            Exit = 5,
            MainMenu = 6
        }

        public AdminForm(StartForm startForm)
        {
            InitializeComponent();
            _startForm = startForm;
            InitializeDataGridView();
            InitializeFiles();
        }

        private void InitializeDataGridView()
        {
            questionsDataGridView.Columns.Clear();
            questionsDataGridView.Columns.Add("Number", "№");
            questionsDataGridView.Columns.Add("Question", "Вопрос");
            questionsDataGridView.Columns.Add("Answer", "Ответ");
            questionsDataGridView.Columns["Number"].Width = 50;
            questionsDataGridView.Columns["Answer"].Width = 80;
            questionsDataGridView.Columns["Question"].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            questionsDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            questionsDataGridView.ReadOnly = true;
            questionsDataGridView.RowHeadersVisible = false;
            questionsDataGridView.CellDoubleClick += questionsDataGridView_CellDoubleClick;
        }

        private void InitializeFiles()
        {
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
                    UserResultStorage.CreateEmptyResultsFile(UserResultStorage.ResultsFilePath);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка инициализации файлов: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ShowQuestionsInGridView()
        {
            try
            {
                var questions = QuestionsStorage.GetQuestions(_questionsPath);
                questionsDataGridView.Rows.Clear();

                for (int i = 0 ; i < questions.Count ; i++)
                {
                    questionsDataGridView.Rows.Add(
                        i + 1,
                        questions[i]._Question,
                        questions[i].Answer
                    );
                }

                questionsDataGridView.Visible = true;
                deleteQuestionButton.Visible = true;
                backFromQuestionsButton.Visible = true;

                adminListBox.Visible = false;
                adminInputTextBox.Visible = false;
                adminActionButton.Visible = false;
                adminPromptLabel.Visible = false;
                adminBackButton.Visible = false;
                adminInfoLabel.Text = $"УПРАВЛЕНИЕ ВОПРОСАМИ (всего: {questions.Count})";

                _currentAction = AdminAction.ViewQuestions;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при загрузке вопросов: {ex.Message}",
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
            };

            foreach (var item in menuItems)
            {
                adminListBox.Items.Add(item);
            }

            adminInputTextBox.Visible = false;
            adminListBox.Visible = true;
            adminPromptLabel.Visible = true;
            adminActionButton.Text = "Выполнить";
            _currentAction = AdminAction.None;
        }

        private void deleteQuestionButton_Click(object sender, EventArgs e)
        {
            DeleteSelectedQuestion();
        }

        private void DeleteSelectedQuestion()
        {
            if (questionsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Выберите вопрос для удаления!", "Внимание",
                              MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedRow = questionsDataGridView.SelectedRows[0];
            var questionNumber = (int)selectedRow.Cells["Number"].Value;
            var questionText = selectedRow.Cells["Question"].Value.ToString();

            var result = MessageBox.Show(
                $"Вы уверены, что хотите удалить вопрос?\n\n{questionText}",
                "Подтверждение удаления",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.Yes)
            {
                try
                {
                    QuestionsStorage.Delete(questionNumber, _questionsPath);

                    ShowQuestionsInGridView();

                    MessageBox.Show("Вопрос успешно удален!", "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при удалении вопроса: {ex.Message}",
                                  "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void backFromQuestionsButton_Click(object sender, EventArgs e)
        {
            ResetToMenu();
        }

        private void adminActionButton_Click(object sender, EventArgs e)
        {
            if (_currentAction == AdminAction.None)
            {
                ProcessMenuSelection();
            }
            else if (_currentAction == AdminAction.Back)
            {
                ResetToMenu();
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

            if (Enum.TryParse<MenuChoice>(choice, out var menuChoice))
            {
                switch (menuChoice)
                {
                    case MenuChoice.ViewQuestions:
                        ShowQuestionsInGridView();
                        break;
                    case MenuChoice.AddQuestion:
                        PrepareAddQuestion();
                        break;
                    case MenuChoice.ViewResults:
                        ShowResults();
                        break;
                    case MenuChoice.RegisterAdmin:
                        PrepareRegisterAdmin();
                        break;
                    case MenuChoice.Exit:
                        Application.Exit();
                        break;
                    case MenuChoice.MainMenu:
                        ReturnToMainMenu();
                        break;
                }
            }
            else
            {
                MessageBox.Show(Messages.InvalidChoice, "Ошибка",
                              MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ProcessAdminAction()
        {
            var input = adminInputTextBox.Text.Trim();
            switch (_currentAction)
            {
                case AdminAction.AddQuestionText:
                case AdminAction.AddQuestionAnswer:
                    AddQuestion(input);
                    break;
                case AdminAction.RegisterAdminLogin:
                case AdminAction.RegisterAdminPassword:
                    RegisterAdmin(input);
                    break;
                case AdminAction.Back:
                    ResetToMenu();
                    break;
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

                adminListBox.Visible = false;
                adminBackButton.Visible = false;
                adminInfoLabel.Text = "ДОБАВЛЕНИЕ НОВОГО ВОПРОСА";

                _currentAction = AdminAction.AddQuestionText;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при подготовке добавления вопроса: {ex.Message}",
                              "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AddQuestion(string input)
        {
            if (_currentAction == AdminAction.AddQuestionText)
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
                adminActionButton.Text = "Добавить";
                _currentAction = AdminAction.AddQuestionAnswer;
            }
            else if (_currentAction == AdminAction.AddQuestionAnswer)
            {
                var result = AdminService.AddQuestion(
                    () => (_tempQuestion, input),
                    _questionsPath
                );

                if (result.success)
                {
                    MessageBox.Show(Messages.QuestionAdded, "Успех",
                                  MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ShowQuestionsInGridView();
                }
                else
                {
                    MessageBox.Show(result.message, "Ошибка",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                adminActionButton.Visible = true;
                adminBackButton.Visible = false;
                adminPromptLabel.Visible = false;
                adminInfoLabel.Text = "РЕЗУЛЬТАТЫ ТЕСТИРОВАНИЯ";
                _currentAction = AdminAction.Back;
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

            adminListBox.Visible = false;
            adminBackButton.Visible = false;
            adminPromptLabel.Visible = true;
            adminInfoLabel.Text = "РЕГИСТРАЦИЯ НОВОГО АДМИНИСТРАТОРА";
            backFromQuestionsButton.Visible = true;

            _currentAction = AdminAction.RegisterAdminLogin;
        }

        private void RegisterAdmin(string input)
        {
            if (_currentAction == AdminAction.RegisterAdminLogin)
            {
                var loginValidation = ValidationHelper.ChekLogin(input);
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
                _currentAction = AdminAction.RegisterAdminPassword;
                Refresh();
            }
            else if (_currentAction == AdminAction.RegisterAdminPassword)
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
            _currentAction = AdminAction.None;
            _tempQuestion = null;
            _tempLogin = null;

            questionsDataGridView.Visible = false;
            deleteQuestionButton.Visible = false;
            backFromQuestionsButton.Visible = false;

            adminActionButton.Visible = true;
            adminPromptLabel.Visible = true;
            adminInfoLabel.Visible = true;
            adminListBox.Visible = true;

            InitializeAdminMenu();
        }

        private void adminBackButton_Click(object sender, EventArgs e)
        {
            if (_currentAction == AdminAction.Back)
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

        private void questionsDataGridView_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DeleteSelectedQuestion();
            }
        }
    }
}