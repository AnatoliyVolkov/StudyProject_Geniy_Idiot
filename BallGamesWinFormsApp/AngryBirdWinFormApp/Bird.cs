using BallLibrary;

namespace AngryBirdWinFormApp;

public class Bird : SolutBall
{
    public bool IsMoving => Math.Abs(Vx) > 0.1f || Math.Abs(Vy) > 0.1f;
    public bool IsAtStartPosition { get; private set; } = true;
    private float startX, startY;

    public Bird(Form form, float x, float y, int radius) : base(form, x, y)
    {
        CenterX = x;
        CenterY = y;
        Radius = radius;
        startX = x;
        startY = y;
        Vx = 0;
        Vy = 0;
        Stop();
    }

    public void SetPosition(float x, float y)
    {
        CenterX = x;
        CenterY = y;
    }

    public void SetVelocity(float vx, float vy)
    {
        Vx = vx;
        Vy = vy;
        IsAtStartPosition = false;
        Start();
    }

    public new void Move()
    {
        if (!IsStopped)
        {
            base.Go();
            IsAtStartPosition = false;
        }
    }

    public void ApplyGravity(float gravity)
    {
        Vy += gravity;
    }

    public void ResetToStart(float x, float y)
    {
        Stop();
        CenterX = x;
        CenterY = y;
        Vx = 0;
        Vy = 0;
        startX = x;
        startY = y;
        IsAtStartPosition = true;
        Stop();
    }

    public void Show(Graphics g)
    {
        g.FillEllipse(Brushes.Red, CenterX - Radius, CenterY - Radius, Radius * 2, Radius * 2);

        g.FillEllipse(Brushes.White, CenterX + Radius / 2 - 3, CenterY - Radius / 2 - 3, 6, 6);
        g.FillEllipse(Brushes.Black, CenterX + Radius / 2 - 1, CenterY - Radius / 2 - 1, 3, 3);
    }
}