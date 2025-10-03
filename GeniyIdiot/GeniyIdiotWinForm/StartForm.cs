using GeniyIdiotClassLibrary;

namespace GeniyIdiotWinForm
{
    public partial class StartForm : Form
    {
        public StartForm()
        {
            InitializeComponent();
        }

        private void adminStartButton_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.Show();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userHelloLabel.Text = Messages.Welcome;
            userChooseLabel.Text = Messages.ChooseRole;
        }

        private void userStartButton_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(this);
            userForm.Show();
            this.Hide();
        }


        private void Form1_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show(
                "Вы действительно хотите выйти из приложения?",
                "Подтверждение выхода",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
