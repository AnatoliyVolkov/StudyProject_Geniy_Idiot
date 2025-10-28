using BallLibrary;

namespace BillyardBallWinFormsApp
{
    public partial class MainFormBillyardBall : Form
    {
        List<BillyardBall> moveBalls;
        public MainFormBillyardBall()
        {
            InitializeComponent();
            SetStyle(ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer, true);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            moveBalls = new List<BillyardBall>();
            int i = 0;
            while (i < 10)
            {
                var maveRandomBall = new BillyardBall(this);
                moveBalls.Add(maveRandomBall);
                maveRandomBall.OnHited += MaveRandomBall_OnHited;
                maveRandomBall.Start();
                i++;
            }
        }

        private void MaveRandomBall_OnHited(object? sender, HitEventArgs e)
        {
            switch (e.Side)
            {
                case Side.Left:
                    leftLabel.Text=(int.Parse(leftLabel.Text)+1).ToString();
                    break;
                case Side.Right:
                    rightLabel.Text = (int.Parse(rightLabel.Text) + 1).ToString();
                    break;
                case Side.Top:
                    topLabel.Text = (int.Parse(topLabel.Text) + 1).ToString();
                    break;
                case Side.Down:
                    dawnLabel.Text = (int.Parse(dawnLabel.Text) + 1).ToString();
                    break;
            }
        }

    }
}
