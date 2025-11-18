using Timer = System.Windows.Forms.Timer;
namespace AngryBerdWinFormsApp;

public class Bird
{
    public float CenterX { get; set; }
    public float CenterY { get; set; }
    public float Vx { get; set; }
    public float Vy { get; set; }
    public int Radius { get; set; }
    public bool IsMoving => Math.Abs(Vx) > 0.1f || Math.Abs(Vy) > 0.1f;
    public bool IsAtStartPosition { get; private set; } = true;


    public Bird(float x, float y, int radius)
    {
        CenterX = x;
        CenterY = y;
        Radius = radius;
    }

    public void Move()
    {
        CenterX += Vx;
        CenterY += Vy;
        IsAtStartPosition = false;
    }

    public void ApplyGravity(float gravity)
    {
        Vy += gravity;
    }

    public void SetVelocity(float vx, float vy)
    {
        Vx = vx;
        Vy = vy;
        IsAtStartPosition = false;
    }

    public void ResetToStart(float x, float y)
    {
        CenterX = x;
        CenterY = y;
        Vx = 0;
        Vy = 0;
        IsAtStartPosition = true;
    }

    public void Draw(Graphics g, Brush brush)
    {
        g.FillEllipse(brush, CenterX - Radius, CenterY - Radius, Radius * 2, Radius * 2);
        g.FillEllipse(Brushes.White, CenterX + Radius / 2 - 3, CenterY - Radius / 2 - 3, 6, 6);
        g.FillEllipse(Brushes.Black, CenterX + Radius / 2 - 1, CenterY - Radius / 2 - 1, 3, 3);
    }
}
