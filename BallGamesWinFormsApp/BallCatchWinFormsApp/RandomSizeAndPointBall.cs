namespace BallCatchWinFormsApp;

public class RandomSizeAndPointBall : RandomBall
{
    public RandomSizeAndPointBall(MainForm form) : base(form)
    {
        size = random.Next(10, 90);
    }
}