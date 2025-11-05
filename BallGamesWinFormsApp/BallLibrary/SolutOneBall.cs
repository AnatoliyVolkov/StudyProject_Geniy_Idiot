namespace BallLibrary;

public class SolutOneBall : MoveBall
{
    public SolutOneBall(Form form,float x) : base(form)
    {
        Vx = 0;
        Vy = -5;
        CenterX = x;
        CenterY = form.ClientRectangle.Bottom + Radius;
    }

    public void HideBall()
    {
        Stop(); 
        Draw(new SolidBrush(Color.Transparent));
    }

}
