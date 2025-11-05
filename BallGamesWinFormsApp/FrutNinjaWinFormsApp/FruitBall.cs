using BallLibrary;
namespace FrutNinjaWinFormsApp;

public class FruitBall : SolutOneBall
{
    public bool IsBomb { get; protected set; } = false;
    public bool IsHidden { get; private set; } = false;
    private Brush ballBrush;

    public FruitBall(Form form, float x) : base(form, x)
    {
        Vx = random.Next(-5, 6);
        Vy = random.Next(-15, -8);
        ballBrush = Brushes.Orange;
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

    protected override void Go()
    {
        if (IsHidden) return;
        base.Go();
        Vy += 0.3f;
    }

    public void HideBall()
    {
        if (IsHidden) return;

        IsHidden = true;
        Stop();
        Clear();
    }
}