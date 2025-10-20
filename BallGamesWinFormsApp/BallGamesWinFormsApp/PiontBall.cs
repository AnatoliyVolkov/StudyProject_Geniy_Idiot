namespace BallGamesWinFormsApp;

public class PiontBall : Ball
{
    public PiontBall(MainForm form, int x, int y) : base(form)
    {
        this.x = x -35;
        this.y = y -35;
    }
}
