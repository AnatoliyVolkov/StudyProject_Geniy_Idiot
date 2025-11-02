namespace SalutWinFormsApp
{

    public partial class SolutMainForm : Form
    {
        private Random random = new Random();
        public SolutMainForm()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
        }

        private void SolutMainForm_MouseDown(object sender, MouseEventArgs e)
        {
            var count = random.Next(3, 16);

            for (int i = 0 ; i < count ; i++)
            {
                var salut = new SolutBall(this, e.X, e.Y);
                salut.Start();
            }
        }
    }
}
