namespace BallGamesWinFormsApp;

public class RandomBall : Ball
{
    static public Random random = new Random();
    public RandomBall(MainForm form) : base(form)
    {
        X = random.Next(0, form.ClientSize.Width);
        Y = random.Next(0, form.ClientSize.Height);
    }
}
