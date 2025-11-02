namespace SalutWinFormsApp
{
    public partial class SolutMainForm : Form
    {
        public SolutMainForm()
        {
            InitializeComponent();
        }

        private void SolutMainForm_MouseDown(object sender, MouseEventArgs e)
        {
            var random = new Random();
            var count = random.Next(3,16);
            for (int i = 0 ; i < count ; i++)
            {
                var salut = new SolutBall(this, e.X, e.Y);
                salut.Start();
            }
        }
    }
}
