using Timer = System.Windows.Forms.Timer;


namespace BallLibrary;

public class Ball
{
    protected Form form;
    public float Vx { get; protected set; } = 3;
    public float Vy { get; protected set; } = 4;
    public float CenterX { get; protected set; } = 150;
    public float CenterY { get; protected set; } = 150;
    public int Radius { get; protected set; } = 15;
    public bool IsStopped { get; protected set; } = false;
    public Brush Brush { get; protected set; } = Brushes.Green;


    private Timer _timer;

    public Ball(Form form)
    {
        this.form = form;
        _timer = new Timer();
        _timer.Interval = 20;
        _timer.Tick += _timer_Tick;
    }
    public void SetVelocity(float vx, float vy)
    {
        Vx = vx;
        Vy = vy;
    }

    public void Start() { _timer.Start(); IsStopped = false; }

    public void Stop() { _timer.Stop(); IsStopped = true; }

    public bool IsForm(float x, float y, int radius, Panel ballPanel)
    {
        if (
           x - radius >= ballPanel.Left &&
           x + radius <= ballPanel.Right &&
           y - radius >= ballPanel.Top &&
           y + radius <= ballPanel.Bottom
           )
        {
            return true;
        }
        return false;
    }

    public virtual void Show()
    {
        Draw(Brush);
    }

    public void Move()
    {
        Clear();
        Go();
        Show();
    }

    protected virtual void Go()
    {
        CenterX += Vx;
        CenterY += Vy;
    }

    protected void Clear()
    {
        var brush = SystemBrushes.Control;
        Draw(brush);
    }

    public void Draw(Brush brush)
    {
        var drawBrush = brush ?? Brushes.Green;
        var graphics = form.CreateGraphics();
        var rectangle = new RectangleF(CenterX - Radius, CenterY - Radius, Radius * 2, Radius * 2);
        graphics.FillEllipse(brush, rectangle);
    }

    private void _timer_Tick(object? sender, EventArgs e)
    {
        Move();
    }
}