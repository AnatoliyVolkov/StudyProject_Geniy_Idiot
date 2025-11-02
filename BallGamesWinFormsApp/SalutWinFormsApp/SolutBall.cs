namespace SalutWinFormsApp;

public class SolutBall : MoveBall
{
    private float G { get; set; } = 0.2f;
    private Brush ballBrush;
    public SolutBall(Form form, int CentrX, int CentrY) : base(form) 
    {
        this.CenterX = CentrX;
        this.CenterY = CentrY;
        Vy = -Math.Abs(Vy);
        ballBrush = CreateRandomBrush();

    }

    protected override void Go()
    {
        base.Go();
        Vy += G;
    }

    public override void Show()
    {
        Draw(ballBrush);
    }

    private Brush CreateRandomBrush()
    {
        Color randomColor = Color.FromArgb(
            random.Next(50, 225),
            random.Next(50, 225),
            random.Next(100, 225)
        );
        return new SolidBrush(randomColor);
    }
}
