namespace BallLibrary;

public class PiontBall : Ball
{
    public PiontBall(MainForm form, int x, int y) : base(form)
    {
        this.X = x -35;
        this.Y = y -35;
    }
}
