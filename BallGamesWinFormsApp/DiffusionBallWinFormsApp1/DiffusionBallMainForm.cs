using BallLibrary;
using Timer = System.Windows.Forms.Timer;

namespace DiffusionBallWinFormsApp;

public partial class DiffusionBallMainForm : Form
{
    List<BillyardBall> redBalls;
    List<BillyardBall> blueBalls;
    Timer timer = new Timer();

    public DiffusionBallMainForm()
    {
        InitializeComponent();
        redBalls = new List<BillyardBall>();
        blueBalls = new List<BillyardBall>();

        timer.Interval = 100; 
        timer.Tick += Timer_Tick;

        SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
    }

    private void DiffusionBallMainForm_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < 10; i++)
        {
            var ball = new DiffusionBall(this, isRed: true);
            ball.OnHited += MaveRandomBall_OnHited;
            redBalls.Add(ball);
            ball.Start();
        }

        for (int i = 0; i < 10; i++)
        {
            var ball = new DiffusionBall(this, isRed: false);
            ball.OnHited += MaveRandomBall_OnHited;
            blueBalls.Add(ball);
            ball.Start();
        }

        timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        if (DetermingPositionBalls())
        {
            StopDiffision();
        }
    }

    private void MaveRandomBall_OnHited(object? sender, HitEventArgs e)
    {
        switch (e.Side)
        {
            case Side.Left:
                leftLabel.Text = (int.Parse(leftLabel.Text) + 1).ToString();
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

    private void MouseKlickStartStopBall_MouseDown(object sender, MouseEventArgs e)
    {
        foreach (var ball in redBalls)
        {
            if (ball.IsStopped)
            {
                ball.Start();
            }
            else
            {
                ball.Stop();
            }
        }

        foreach (var ball in blueBalls)
        {
            if (ball.IsStopped)
            {
                ball.Start();
            }
            else
            {
                ball.Stop();
            }
        }
    }

    private void StopDiffision()
    {
        foreach (var ball in redBalls)
        {
            ball.Stop();
        }

        foreach (var ball in blueBalls)
        {
            ball.Stop();
        }
        timer.Stop();
    }

    private bool DetermingPositionBalls()
    {
        int count = 0;
        for (int i = 0; i < redBalls.Count; i++)
        {
            if (redBalls[i].CenterX > this.ClientSize.Width / 2)
                count++;
        }

        for (int i = 0; i < blueBalls.Count; i++)
        {
            if (blueBalls[i].CenterX < this.ClientSize.Width / 2)
                count++;
        }
        double positionBall = count * 100.0 / (redBalls.Count + blueBalls.Count);
        return positionBall >= 48 && positionBall <= 53;
    }
}