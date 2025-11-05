namespace BallLibrary;

public class RandomBall : Ball
{
    static public Random random = new Random();

    public RandomBall(Form form) : base(form)
    {
        CenterX = random.Next(55, form.ClientSize.Width-55);
        CenterY = random.Next(55, form.ClientSize.Height-55);
    }
}
