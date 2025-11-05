using BallLibrary;
using System.Windows.Forms;
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
        StartBallSolut(e.X);
    }

    private void SolutMainForm_Load(object sender, EventArgs e)
    {
        StartBallSolut(random.Next (0, this.ClientRectangle.Right));
    }

    private void CheckBallPosition(object sender, EventArgs e)
    {
        if (currentBall.CenterY <= 155) 
        {
            StartSolut(currentBall.CenterX, currentBall.CenterY);
            currentBall.HideBall();
        }
    }

    private void StartSolut(float x, float y)
    {
        var count = random.Next(3, 7);

        for (int i = 0 ; i < count ; i++)
        {
            var salut = new SolutBall(this, x, y);
            salut.Start();
            timer.Stop();
        }
    }

    private void StartBallSolut(float x)
    {
        currentBall = new SolutOneBall(this, x);
        currentBall.Start();
        timer.Tick += CheckBallPosition;
        timer.Start();
    }


}
