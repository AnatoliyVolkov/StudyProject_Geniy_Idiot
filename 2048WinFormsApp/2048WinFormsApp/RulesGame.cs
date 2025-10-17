
namespace _2048WinFormsApp
{
    public partial class RulesGame : Form
    {
        public RulesGame()
        {
            InitializeComponent();
        }

        private void RulesGame_Load(object sender, EventArgs e)
        {
            infoLabel.Text = "1. В каждом раунде появляется плитка номинала «2» (с вероятностью 75 %) или «4» (с вероятностью 25 %).\n" +
                 "2. Нажатием стрелки игрок может скинуть все плитки игрового поля в одну из 4 сторон.\n" +
                 "Если при сбрасывании две плитки одного номинала «налетают» одна на другую, то они превращаются в одну, номинал которой равен сумме соединившихся плиток. \n" +
                 "После каждого хода на свободной секции поля появляется новая плитка номиналом «2» или «4».\n " +
                 "Если при нажатии кнопки местоположение плиток или их номинал не изменится, то ход не совершается.\n" +
                 "3. Если в одной строчке или в одном столбце находится более двух плиток одного номинала, то при сбрасывании они начинают соединяться с той стороны, в которую были направлены.\n" +
                 "4. За каждое соединение игровые очки увеличиваются на номинал получившейся плитки.\n" +
                 "5. Игра заканчивается поражением, если после очередного хода невозможно совершить действие.";
        }

        private void ButtonBackMenu_Click(object sender, EventArgs e)
        {
            Form userForm = new StartMenu();
            userForm.Show();
            this.Hide();
        }

        private void RulesGame_FormClosing(object sender, FormClosingEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите выйти?", "Подтверждение",
                                                 MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                Environment.Exit(0);
            }
        }
    }
}
