namespace BallGamesWinFormsApp;

public class RandomBall : Ball
{
    static public Random random = new Random();
    public RandomBall(MainForm form) : base(form)
    {
        x = random.Next(0, form.ClientSize.Width);
        y = random.Next(0, form.ClientSize.Height);
    }
}
