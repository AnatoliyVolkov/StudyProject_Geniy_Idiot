namespace BallLibrary;

public class DiffusionBall : BillyardBall
{

    private Brush ballBrush;

    public DiffusionBall(Form form, bool isRed) : base(form)
    {
        ballBrush = isRed ? Brushes.Red : Brushes.Blue;

        if (isRed)
        {
            CenterX = random.Next(Radius, form.ClientSize.Width / 2 - Radius);
            CenterY = random.Next(Radius, form.ClientSize.Height - Radius);
        }
        else
        {
            CenterX = random.Next(form.ClientSize.Width / 2 + Radius, form.ClientSize.Width - Radius);
            CenterY = random.Next(Radius, form.ClientSize.Height - Radius);
        }
    }

    public override void Show()
    {       
        Draw(ballBrush);
    }
}
