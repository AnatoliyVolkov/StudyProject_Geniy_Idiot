using GeniyIdiotClassLibrary;

namespace GeniyIdiotWinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void adminStartButton_Click(object sender, EventArgs e)
        {
            AdminForm adminForm = new AdminForm();
            adminForm.ShowDialog();
            this.Hide();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            userHelloLabel.Text = Messages.Welcome;
            userChooseLabel.Text = Messages.ChooseRole;
        }

        private void userStartButton_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm();
            userForm.ShowDialog();
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
