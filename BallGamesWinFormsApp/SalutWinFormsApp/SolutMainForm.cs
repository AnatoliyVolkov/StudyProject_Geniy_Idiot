using BallLibrary;
using Timer = System.Windows.Forms.Timer;

namespace SalutWinFormsApp;
public partial class SolutMainForm : Form
{
    private SolutOneBall currentBall;
    Timer timer = new Timer();
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
        currentBall = new SolutOneBall(this);
        currentBall.Start();
        timer.Tick += CheckBallPosition;
        timer.Start();
    }

    private void CheckBallPosition(object sender, EventArgs e)
    {
        if (random.Next(0, 100) < 7 || currentBall.CenterY == -35)
        {
            StartSolut(currentBall.CenterX, currentBall.CenterY);
            currentBall.HideBall();
        }
    }

    private void StartSolut(float x, float y)
    {
        var count = random.Next(3, 16);

        for (int i = 0 ; i < count ; i++)
        {
            var salut = new SolutBall(this, x, y);
            salut.Start();
            timer.Stop();
        }
    }


}
