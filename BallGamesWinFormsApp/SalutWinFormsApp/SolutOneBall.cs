namespace SalutWinFormsApp;

public class SolutOneBall : MoveBall
{
    public SolutOneBall(Form form) : base(form)
    {
        Vx = 0;
        Vy = -5;
        CenterY = form.ClientRectangle.Bottom + 55;
    }

    public void HideBall()
    {
        Stop(); 
        Draw(new SolidBrush(Color.Transparent));
    }

}
