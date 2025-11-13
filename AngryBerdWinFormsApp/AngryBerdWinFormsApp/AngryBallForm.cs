using Timer = System.Windows.Forms.Timer;

namespace AngryBerdWinFormsApp
{
    public partial class AngryBallForm : Form
    {
        private Bird bird;
        private GameManager gameManager;
        private Timer gameTimer;
        private Brush birdBrush = Brushes.Red;
        private Brush pigBrush = Brushes.Green;
        private const int GroundLevel = 400;
        private const float Gravity = 0.5f;
        private const float Elasticity = 0.7f;
        private const float MaxBallSpeed = 5f;

        public AngryBallForm()
        {
            InitializeComponent();
            this.Size = new Size(800, 600);
            Random random = new Random();

            gameManager = new GameManager();

            InitializeGame();
            SetupTimer();
        }

        private void InitializeGame()
        {
            bird = new Bird(50, GroundLevel - 20, 20);

            gameManager.InitializePigs(ClientSize.Width, GroundLevel, 15);

            DoubleBuffered = true;
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

        HandlePigCollisions();
        HandleBoundaryCollisions();

        if (ShouldResetBird())
        {
            bird.ResetToStart(50, GroundLevel - 20);
            if (gameManager.IsLevelComplete)
            {
                gameManager.NextLevel();
                gameManager.InitializePigs(ClientSize.Width, GroundLevel, 15);
            }
        }
    }
    Invalidate();
}

private void HandlePigCollisions()
{
    foreach (var pig in gameManager.Pigs.ToList())
    {
        if (CheckCollision(bird, pig))
        {
            gameManager.RemovePig(pig);
            break;
        }
    }
}

private void HandleBoundaryCollisions()
{
    if (bird.CenterY >= GroundLevel - bird.Radius)
    {
        bird.CenterY = GroundLevel - bird.Radius;
        bird.Vy = -bird.Vy * Elasticity;
        bird.Vx *= 0.9f;
    } 
    
}

private bool ShouldResetBird()
{
    bool isOutOfBounds = bird.CenterY < -bird.Radius ||
                         bird.CenterX > ClientSize.Width + bird.Radius;
    bool isStoppedOnGround = bird.CenterY >= GroundLevel - bird.Radius - 2 &&
                             Math.Abs(bird.Vx) < 0.3f &&
                             Math.Abs(bird.Vy) < 0.3f;
    return isOutOfBounds || isStoppedOnGround;
}

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(Brushes.LightBlue, 0, 0, ClientSize.Width, GroundLevel);
            e.Graphics.FillRectangle(Brushes.Brown, 0, GroundLevel, ClientSize.Width, ClientSize.Height - GroundLevel);

            bird.Draw(e.Graphics, birdBrush);
            foreach (var pig in gameManager.Pigs)
            {
                pig.Draw(e.Graphics, pigBrush);

            }

            string gameInfo = $"Уровень: {gameManager.Level}\n" +
                            $"Очки: {gameManager.Score}\n" +
                            $"Свинки: {gameManager.Pigs.Count}/{gameManager.PigsCount}";

            e.Graphics.DrawString(gameInfo, new Font("Arial", 12), Brushes.Black, 10, 10);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            if (bird.IsAtStartPosition && e.Button == MouseButtons.Left)
            {
                LaunchBird(e.Location);
            }
        }

        private void LaunchBird(Point targetPoint)
        {
            PointF birdCenter = new PointF(bird.CenterX, bird.CenterY);

            float dx = targetPoint.X - birdCenter.X;
            float dy = targetPoint.Y - birdCenter.Y;

            float distance = (float)Math.Min(Math.Sqrt(dx * dx + dy * dy), 100);
            float scale = distance / 100f * MaxBallSpeed;

            if (distance > 0)
            {
                bird.SetVelocity(dx / distance * scale, dy / distance * scale);
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
}