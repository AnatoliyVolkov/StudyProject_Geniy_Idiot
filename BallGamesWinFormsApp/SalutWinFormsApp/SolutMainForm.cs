using BallLibrary;

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
            StartSolut(e.X, e.Y);
        }

        private void SolutMainForm_Load(object sender, EventArgs e)
        {
            var solutOneBall = new SolutOneBall(this);
            solutOneBall.Start();
            if (solutOneBall.CenterY == random.Next(-50, this.ClientRectangle.Bottom))
            {
                StartSolut(solutOneBall.CenterX, solutOneBall.CenterY);
            }
        }

        private void StartSolut(float x, float y)
        {
            var count = random.Next(3, 16);

            for (int i = 0 ; i < count ; i++)
            {
                var salut = new SolutBall(this, x, y);
                salut.Start();
            }
        }


    }


}
