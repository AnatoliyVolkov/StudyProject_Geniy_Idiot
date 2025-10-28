namespace BillyardBallWinFormsApp
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var ball =new BillyardBall(this, billyardBallPanel);
            ball.Start();
        }
    }
}
