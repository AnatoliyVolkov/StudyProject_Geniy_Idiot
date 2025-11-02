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
}
