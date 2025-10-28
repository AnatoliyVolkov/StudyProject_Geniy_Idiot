namespace BallLibrary;

public class RandomSizeAndPointBall : MoveBall
{
    public RandomSizeAndPointBall(Form form) : base(form)
    {
        Radius = random.Next(7, 50);
    }
}