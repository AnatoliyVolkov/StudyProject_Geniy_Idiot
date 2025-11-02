namespace SalutWinFormsApp;

public class SolutBall : MoveBall
{
    private float G { get; set; } = 0.2f;

    public SolutBall(Form form, int CentrX, int CentrY) : base(form) 
    {
        this.CenterX = CentrX;
        this.CenterY = CentrY;
        Vy = -Math.Abs(Vy);

    }

    protected override void Go()
    {
        base.Go();
        Vy += G;
    }

    public override void Show()
    {
        var brush = CreateRandomBrush();
        Draw(brush);
    }

    private Brush CreateRandomBrush()
    {
        Color randomColor = Color.FromArgb(
            random.Next(100, 256),
            random.Next(100, 256),
            random.Next(100, 256)
        );
        return new SolidBrush(randomColor);
    }
}
