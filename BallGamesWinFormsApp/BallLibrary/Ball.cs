using Timer = System.Windows.Forms.Timer;

namespace BallLibrary;

public class Ball
{
    private Form mainForm;
    public int Vx { get; protected set; } = 3;
    public int Vy { get; protected set; } = 4;
    public int CenterX { get; protected set; } = 150;
    public int CenterY { get; protected set; } = 150;
    public int Radius { get; protected set; } = 35;
    public bool IsStopped { get; protected set; } = false;

    private Timer _timer;
   
    public Ball(Form form)
    {
        this.mainForm = form;
        _timer = new Timer();
        _timer.Interval = 20;
        _timer.Tick += _timer_Tick;
    }

    public void Start() { _timer.Start(); }

    public void Stop() { _timer.Stop(); IsStopped = true; }

    public bool IsForm(int x, int y, int radius, Panel ballPanel)
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

    public void Show()
    {
        var brush = Brushes.Green;
        Draw(brush);
    }

    public void Move()
    {
        Clear();
        Go();
        Show();
    }

    private void Go()
    {
        CenterX += Vx;
        CenterY += Vy;
    }

    private void Clear()
    {
        var brush = SystemBrushes.Control;
        Draw(brush);
    }

    private void Draw(Brush brush)
    {
        var graphiscs = mainForm.CreateGraphics();
        var rectangle = new Rectangle(CenterX - Radius / 2, CenterY - Radius / 2, Radius, Radius);
        graphiscs.FillEllipse(brush, rectangle);
    }
 private void _timer_Tick(object? sender, EventArgs e)
    {
        Move();
    }
}
