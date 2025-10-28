namespace BallLibrary;

public class RandomSizeAndPointBall : RandomBall
{
    public RandomSizeAndPointBall(Form form) : base(form)
    {
        Radius = random.Next(10, 90);
    }
}