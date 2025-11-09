using BallLibrary;
using Timer = System.Windows.Forms.Timer;

namespace FrutNinjaWinFormsApp;

public partial class FrutNinjaMainForm : Form
{
    private List<FruitBall> balls = new List<FruitBall>();
    Timer timer = new Timer();
    private Random random = new Random();
    int count = 0;

    public FrutNinjaMainForm()
    {
        InitializeComponent();
        this.SetStyle(ControlStyles.AllPaintingInWmPaint |
                        ControlStyles.UserPaint |
                        ControlStyles.DoubleBuffer |
                        ControlStyles.OptimizedDoubleBuffer, true);

        this.BackgroundImageLayout = ImageLayout.Stretch;
        timer.Tick += SpawnTimer_Tick;
    }

    private void FrutNinjaMainForm_Load(object sender, EventArgs e)
    {
        timer.Start();
    }

    private void SpawnTimer_Tick(object sender, EventArgs e)
    {
        if (balls.Count < 8)
        {
            StartBall();
        }

        RemoveInactiveBalls();
    }

    private void RemoveInactiveBalls()
    {
        for (int i = balls.Count - 1 ; i >= 0 ; i--)
        {
            var ball = balls[i];
            if (ball.IsHidden || ball.CenterY > this.ClientSize.Height + 100)
            {
                balls.RemoveAt(i);
            }
        }
    }

    private void StartBall()
    {
        var direction = random.Next(0, 2) == 0 ? 1f : -1f;

        float x;
        if (direction > 0)
        {
            x = -50;
        }
        else
        {
            x = this.ClientRectangle.Right + 50;
        }

        var ball = new FruitBall(this, x, direction);

        var ballType = random.Next(0, 100);
        if (ballType < 15)
        {
            ball.MakeBomb();
        }
        ball.Start();
        balls.Add(ball);
    }


    private void FrutNinjaMainForm_MouseMove(object sender, MouseEventArgs e)
    {
        CheckBallCollision(e.X, e.Y);
    }

    private void CheckBallCollision(float mouseX, float mouseY)
    {
        foreach (var ball in balls.ToList())
        {
            if (!ball.IsHidden && IsMouseOverBall(mouseX, mouseY, ball))
            {
                count++;
                countLabel.Text = count.ToString();
                HandleBallTouch(ball);
            }
        }
    }
    private bool IsMouseOverBall(float mouseX, float mouseY, FruitBall ball)
    {
        float distance = (float)Math.Sqrt(
            Math.Pow(mouseX - ball.CenterX, 2) +
            Math.Pow(mouseY - ball.CenterY, 2)
        );
        return distance <= ball.Radius + 15;
    }

    private void HandleBallTouch(FruitBall ball)
    {
        if (ball.IsBomb)
        {
            StopAllBalls();
            MessageBox.Show($"Игра окончена!");
            Application.Exit();
            return;
        }
        ball.HideBall();
        balls.Remove(ball);
    }

    private void StopAllBalls()
    {
        foreach (var ball in balls)
        {
            ball.Stop();
        }
        timer.Stop();
    }

}


