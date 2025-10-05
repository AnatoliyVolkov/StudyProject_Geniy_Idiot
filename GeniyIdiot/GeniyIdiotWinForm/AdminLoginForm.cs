using GeniyIdiotClassLibrary;

namespace GeniyIdiotWinForm
{
    public partial class AdminLoginForm : Form
    {
        private StartForm _startForm;
        private int _attemptsLeft = 3;
        private string _adminFilePath = AdminStorage.AdminFilePath;

        public AdminLoginForm(StartForm startForm)
        {
            InitializeComponent();
            _startForm = startForm;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            var login = loginTextBox.Text.Trim();
            var password = passwordTextBox.Text.Trim();
            var result = AdminService.TryLogin(() => (login, password), _adminFilePath);
            if (result.success)
            {
                MessageBox.Show(result.message, "Успех",
                              MessageBoxButtons.OK, MessageBoxIcon.Information);

                var adminForm = new AdminForm(_startForm);
                adminForm.Show();
                this.Hide();
            }
            else
            {
                _attemptsLeft--;

                if (_attemptsLeft > 0)
                {
                    MessageBox.Show(string.Format(Messages.AuthFailed, _attemptsLeft),
                                  "Ошибка авторизации",
                                  MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    passwordTextBox.Text = "";
                    passwordTextBox.Focus();
                }
                else
                {
                    MessageBox.Show(Messages.MaxAttempts, "Доступ запрещен",
                                  MessageBoxButtons.OK, MessageBoxIcon.Error);

                    var userForm = new UserForm(_startForm);
                    userForm.Show();
                    this.Hide();
                }
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            _startForm.Show();
            this.Close();
        }
    }
}