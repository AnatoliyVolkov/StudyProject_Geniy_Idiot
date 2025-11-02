using BallLibrary;
using Timer = System.Windows.Forms.Timer;

namespace DiffusionBallWinFormsApp;

public partial class DiffusionBallMainForm : Form
{
    List<BillyardBall> redBalls;
    List<BillyardBall> blueBalls;
    Timer timer = new Timer();
    int ball;

    public DiffusionBallMainForm(int ball)
    {
        InitializeComponent();
        redBalls = new List<BillyardBall>();
        blueBalls = new List<BillyardBall>();
        this.ball = ball;
        timer.Interval = 100;
        timer.Tick += Timer_Tick;

        SetStyle(ControlStyles.AllPaintingInWmPaint |
            ControlStyles.UserPaint |
            ControlStyles.DoubleBuffer, true);
    }

    private void DiffusionBallMainForm_Load(object sender, EventArgs e)
    {
        for (int i = 0; i < ball; i++)
        {
            var ball = new DiffusionBall(this, isRed: true);
            ball.OnHited += MaveRandomBall_OnHited;
            redBalls.Add(ball);
            ball.Start();
        }

        for (int i = 0; i < ball; i++)
        {
            var ball = new DiffusionBall(this, isRed: false);
            ball.OnHited += MaveRandomBall_OnHited;
            blueBalls.Add(ball);
            ball.Start();
        }
        countRedLableLeft.Hide();
        countRedLableRight.Hide();
        countBlueLabelLeft.Hide();
        countBlueLableRight.Hide();
        timer.Start();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {

        if (DetermingPositionBalls())
        {
            StopDiffision();
            countRedLableLeft.Show();
            countRedLableRight.Show();
            countBlueLabelLeft.Show();
            countBlueLableRight.Show();
        }
    }

    private void MaveRandomBall_OnHited(object? sender, HitEventArgs e)
    {
        if (sender is Ball ball && redBalls.Contains(ball))
        {
            switch (e.Side)
            {
                case Side.Left:
                    leftRedLabel.Text = (int.Parse(leftRedLabel.Text) + 1).ToString();
                    break;
                case Side.Right:
                    rightRedLabel.Text = (int.Parse(rightRedLabel.Text) + 1).ToString();
                    break;
                case Side.Top:
                    topRedLabel.Text = (int.Parse(topRedLabel.Text) + 1).ToString();
                    break;
                case Side.Down:
                    dawnRedLabel.Text = (int.Parse(dawnRedLabel.Text) + 1).ToString();
                    break;
            }
        }
        if (sender is Ball blueball && blueBalls.Contains(blueball))
        {
            switch (e.Side)
            {
                case Side.Left:
                    leftBlueLabel.Text = (int.Parse(leftBlueLabel.Text) + 1).ToString();
                    break;
                case Side.Right:
                    rightBlueLabel.Text = (int.Parse(rightBlueLabel.Text) + 1).ToString();
                    break;
                case Side.Top:
                    topBlueLabel.Text = (int.Parse(topBlueLabel.Text) + 1).ToString();
                    break;
                case Side.Down:
                    dawnBlueLabel.Text = (int.Parse(dawnBlueLabel.Text) + 1).ToString();
                    break;
            }
        }
    }

    private void MouseKlickStartStopBall_MouseDown(object sender, MouseEventArgs e)
    {
        ToggleBalls(redBalls);
        ToggleBalls(blueBalls);
    }

    private void StopDiffision()
    {
        StopBalls(redBalls);
        StopBalls(blueBalls);
        timer.Stop();
    }

    private void StopBalls(IEnumerable<Ball> balls)
    {
        foreach (var ball in balls)
        {
            ball.Stop();
        }
    }

    private void ToggleBalls(IEnumerable<Ball> balls)
    {
        foreach (var ball in balls)
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

    private bool DetermingPositionBalls()
    {
        var blueCount = 0;
        var redCount = 0;
        for (int i = 0; i < redBalls.Count; i++)
        {
            if (redBalls[i].CenterX > this.ClientSize.Width / 2)
            {
                redCount++;
                countRedLableRight.Text = redCount.ToString();
                countRedLableLeft.Text = (redBalls.Count - redCount).ToString();
            }
        }

        for (int i = 0; i < blueBalls.Count; i++)
        {
            if (blueBalls[i].CenterX < this.ClientSize.Width / 2)
            {
                blueCount++;
                countBlueLabelLeft.Text = blueCount.ToString();
                countBlueLableRight.Text = (blueBalls.Count - blueCount).ToString();
            }
        }
        var positionBall = (blueCount+redCount) * 100.0 / (redBalls.Count + blueBalls.Count);
        var minValueProcent = 48.0;
        var maxValueProcent = 53.0;
        return positionBall >= minValueProcent && maxValueProcent <= 53;
    }

    private void DiffusionBallMainForm_FormClosed(object sender, FormClosedEventArgs e)
    {
        Application.Exit();
    }
}