using System.Windows.Forms;

namespace BallCatchWinFormsApp
{
    public partial class MainForm : Form
    {
        List<MoveBall> MoveBalls;
        public MainForm()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.DoubleBuffer, true);
        }

        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            var pointBall = new PiontBall(this, e.X, e.Y);
            pointBall.Show();
        }

        private void CreateRandomBullToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Invalidate();
            this.Update();
            cathBallToolStripTextBox.Text = "0";
            MoveBalls = new List<MoveBall>();
            int i = 0;
            while (i < 20)
            {
                var maveRandomBall = new MoveBall(this);
                MoveBalls.Add(maveRandomBall);
                maveRandomBall.Start();
                i++;
            }
        }

        private void MainForm_MouseClick(object sender, MouseEventArgs e)
        {
            int count = 0;
            for (int i = 0 ; i < MoveBalls.Count ; i++)
            {
                double distance = Math.Sqrt(Math.Pow(e.X - MoveBalls[i].X, 2) +
                                   Math.Pow(e.Y - MoveBalls[i].Y, 2));
                if (MoveBalls[i].X - MoveBalls[i].radius >= ClientRectangle.Left &&
                    MoveBalls[i].X + MoveBalls[i].radius <= ClientRectangle.Right &&
                    MoveBalls[i].Y - MoveBalls[i].radius >= ClientRectangle.Top &&
                    MoveBalls[i].Y + MoveBalls[i].radius <= ClientRectangle.Bottom &&
                    distance <= MoveBalls[i].radius)
                {
                    count++;
                }
            }
            cathBallToolStripTextBox.Text = count.ToString();
        }
    }
}
