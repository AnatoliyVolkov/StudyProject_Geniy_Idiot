namespace BallLibrary;

public class RandomSizeAndPointBall : RandomBall
{
    public RandomSizeAndPointBall(Form form) : base(form)
    {
        size = random.Next(10, 90);
    }
}