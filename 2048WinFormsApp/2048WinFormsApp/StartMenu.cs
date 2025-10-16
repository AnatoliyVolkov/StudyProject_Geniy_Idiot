namespace _2048WinFormsApp
{
    public partial class StartMenu : Form
    {
        public StartMenu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form userForm = new UserInput();
            userForm.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
                                               MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }

        private void InfoGameButton_Click(object sender, EventArgs e)
        {
            Form userForm = new RulesGame();
            userForm.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form resultsForm = new ResultsForm();
            resultsForm.Show();
            this.Hide();
        }

        private void StartMenu_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
                                                MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
            else { e.Cancel = true; }
        }
    }
}
