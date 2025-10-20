
namespace _2048WinFormsApp
{
    public partial class UserInput : Form
    {
        public UserInput()
        {
            InitializeComponent();
        }


        private void ButtonStartGame_Click(object sender, EventArgs e)
        {
            var name = ValidationHelper.CheckUsernameEntry(userTextBox.Text);
            var size = ValidationHelper.CheckMapSize(userTextBoxMapSize.Text);
            if (name != string.Empty && size != string.Empty)
            {
                var mapSize = int.Parse(size);
                Form gameMap = new Map(mapSize, name);
                gameMap.Show();
                this.Hide();
            }

        }

        private void UserInput_FormClosing(object sender, FormClosingEventArgs e)
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
