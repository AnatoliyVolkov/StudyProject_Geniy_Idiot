namespace BallLibrary;

public class RandomBall : Ball
{
    static public Random random = new Random();

    public RandomBall(Form form) : base(form)
    {
        CenterX = random.Next(10, form.ClientSize.Width-10);
        CenterY = random.Next(10, form.ClientSize.Height-10);
    }
}
