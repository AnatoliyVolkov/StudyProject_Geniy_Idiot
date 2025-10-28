using BallLibrary;

public class MoveBall : RandomSizeAndPointBall
{
    public MoveBall(Form form) : base(form)
    {
        var random = new Random();
        Vx = random.Next(-10, 10);
        Vy = random.Next(-10, 10);
    }
}
