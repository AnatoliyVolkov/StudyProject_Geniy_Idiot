using BallLibrary;
namespace FrutNinjaWinFormsApp;

public class FruitBall : SolutOneBall
{
    public bool IsBomb { get; protected set; } = false;
    public bool IsHidden { get; private set; } = false;
    private Brush ballBrush;

    public FruitBall(Form form, float x, float direction) : base(form, x)
    {
        Vx = random.Next(4, 16) * direction;
        Vy = random.Next(-15, -8);
        Radius = random.Next(10, 45);
        ballBrush = CreateRandomBrush();
    }

    public void MakeBomb()
    {
        IsBomb = true;
        ballBrush = Brushes.Black;
        Radius = 20;
    }

    public override void Show()
    {
        if (IsHidden) return;
        Draw(ballBrush);
    }
    protected Brush CreateRandomBrush()
    {
        Color randomColor = Color.FromArgb(
            random.Next(50, 225),
            random.Next(50, 225),
            random.Next(100, 225)
        );
       return ballBrush = new SolidBrush(randomColor);
    }

    protected override void Go()
    {
        if (IsHidden) return;
        base.Go();
        Vy += 0.35f;
    }

    public void HideBall()
    {
        if (IsHidden) return;

        IsHidden = true;
        Stop();
        Clear();
    }
}