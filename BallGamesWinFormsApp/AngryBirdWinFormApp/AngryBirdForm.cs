using BallLibrary;
using Timer = System.Windows.Forms.Timer;

namespace AngryBirdWinFormApp;

public partial class AngryBirdForm : Form
{
    private Bird bird;
    private GameManager gameManager;
    private Timer gameTimer;
    private const int GroundLevel = 400;
    private const float Gravity = 0.5f;
    private const float Elasticity = 0.7f;
    private Random random;
    private bool isLevelTransition = false;

    public AngryBirdForm()
    {
        InitializeComponent();
        this.Size = new Size(800, 600);
        gameManager = new GameManager(this);
        InitializeGame();
        SetupTimer();
        DoubleBuffered = true;
    }

    private void InitializeGame()
    {
        bird = new Bird(this, 50, GroundLevel - 20, 20);
        gameManager.InitializePigs(ClientSize.Width, GroundLevel, 15);
    }

    private void SetupTimer()
    {
        gameTimer = new Timer();
        gameTimer.Interval = 16;
        gameTimer.Tick += GameTimer_Tick;
        gameTimer.Start();
    }

    private void GameTimer_Tick(object sender, EventArgs e)
    {
        if (!bird.IsAtStartPosition && bird.IsMoving)
        {
            bird.ApplyGravity(Gravity);
            bird.Move();

            foreach (var pig in gameManager.Pigs.ToList())
            {
                if (CheckCollision(bird, pig))
                {
                    gameManager.RemovePig(pig);
                    break;
                }
            }

            if (bird.CenterY >= GroundLevel - bird.Radius)
            {
                bird.SetPosition(bird.CenterX, GroundLevel - bird.Radius);
                float newVx = bird.Vx * 0.7f;
                float newVy = -bird.Vy * Elasticity * 0.8f;
                if (Math.Abs(newVx) < 0.1f && Math.Abs(newVy) < 1f)
                {
                    newVx = 0;
                    newVy = 0;
                    bird.Stop();
                }

                bird.SetVelocity(newVx, newVy);
            }

            if (bird.CenterX <= bird.Radius)
            {
                bird.SetPosition(bird.Radius, bird.CenterY);
                bird.SetVelocity(-bird.Vx * Elasticity, bird.Vy);
            }
        }

        bool isOutOfBounds = bird.CenterY < -bird.Radius ||
              bird.CenterX > ClientSize.Width + bird.Radius;

        bool isStoppedOnGround = bird.CenterY >= GroundLevel - bird.Radius - 2 &&
                               Math.Abs(bird.Vx) < 0.3f &&
                               Math.Abs(bird.Vy) < 0.3f;

        if ((isOutOfBounds || isStoppedOnGround) && !isLevelTransition)
        {
            bird.ResetToStart(50, GroundLevel - 20);

            if (gameManager.AllPigsDestroyed())
            {
                isLevelTransition = true;
                gameManager.NextLevel();
                gameManager.InitializePigs(ClientSize.Width, GroundLevel, 15);
                isLevelTransition = false;

                bird.ResetToStart(50, GroundLevel - 20);
            }
        }

        Invalidate();
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);

        e.Graphics.FillRectangle(Brushes.LightBlue, 0, 0, ClientSize.Width, GroundLevel);
        e.Graphics.FillRectangle(Brushes.Brown, 0, GroundLevel, ClientSize.Width, ClientSize.Height - GroundLevel);

        bird.Show(e.Graphics);
        foreach (var pig in gameManager.Pigs)
        {
            pig.Show(e.Graphics);
        }

        string gameInfo = $"Уровень: {gameManager.Level}\n" +
                        $"Очки: {gameManager.Score}\n" +
                        $"Свинки: {gameManager.Pigs.Count}/{gameManager.PigsCount}";

        e.Graphics.DrawString(gameInfo, new Font("Arial", 12), Brushes.Black, 10, 10);
    }

    protected override void OnMouseDown(MouseEventArgs e)
    {
        base.OnMouseDown(e);

        if (bird.IsAtStartPosition && e.Button == MouseButtons.Left && !gameManager.IsLevelComplete)
        {
            LaunchBird(e.Location);
        }
    }

    private void LaunchBird(Point targetPoint)
    {
        PointF birdCenter = new PointF(bird.CenterX, bird.CenterY);

        float dx = targetPoint.X - birdCenter.X;
        float dy = targetPoint.Y - birdCenter.Y;

        float distance = (float)Math.Sqrt(dx * dx + dy * dy);

        float maxDistance = 200f;
        float maxSpeed = 15f;

        if (distance > maxDistance)
        {
            distance = maxDistance;
        }

        float speed = (distance / maxDistance) * maxSpeed;

        if (distance > 0)
        {
            bird.SetVelocity(dx / distance * speed, dy / distance * speed);
        }
    }

    private bool CheckCollision(Bird b, Pig p)
    {
        float dx = b.CenterX - p.CenterX;
        float dy = b.CenterY - p.CenterY;
        float distance = (float)Math.Sqrt(dx * dx + dy * dy);

        return distance < (b.Radius + p.Radius);
    }

    protected override void OnResize(EventArgs e)
    {
        base.OnResize(e);
        Invalidate();
    }
}