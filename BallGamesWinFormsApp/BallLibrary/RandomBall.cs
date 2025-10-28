namespace BallLibrary;

public class RandomBall : Ball
{
    static public Random random = new Random();

    public RandomBall(Form form) : base(form)
    {
        CenterX = random.Next(0, form.ClientSize.Width);
        CenterY = random.Next(0, form.ClientSize.Height);
    }
}
